using System.Collections.Generic;
using UnityEngine;
using System.Collections;

[System.Serializable]
public class WaitTimeSettings : object
{
    public string AnimationName;
    public float WaitTime;
    public WaitTimeSettings(string _AnimationName, float _WaitTime)
    {
        this.AnimationName = _AnimationName;
        this.WaitTime = _WaitTime;
    }

}
[System.Serializable]
public class LinkAnimation : object
{
    public string AnimationName;
    public GameObject TargetAnimationObject;
}
[System.Serializable]
public class TextMeshObjs : object
{
     //		5 text meshes		//
    public TextMesh[] LoadText;
    public TextMesh[] RefineText;
    public TextMesh[] DispenseText;
    public TextMeshObjs()
    {
        this.LoadText = new TextMesh[5];
        this.RefineText = new TextMesh[5];
        this.DispenseText = new TextMesh[5];
    }

}
[System.Serializable]
public class rMineralAtt : object
{
    public rMineralType refinedType;
    public int refinedAmount;
    public rMineralAtt()
    {
        if (!this.initialized__rMineralAtt)
        {
            this.initialized__rMineralAtt = true;
        }
        this.refinedType = (rMineralType) 0;
        this.refinedAmount = 0;
    }

    public rMineralAtt(rMineralType _type, int _amount)
    {
        if (!this.initialized__rMineralAtt)
        {
            this.initialized__rMineralAtt = true;
        }
        this.refinedType = _type;
        this.refinedAmount = _amount;
    }

    private bool initialized__rMineralAtt;
}
[System.Serializable]
public partial class MineralRefinery : MonoBehaviour
{
    public static MineralRefinery instance;
    public static float WaitTime;
    public static System.Collections.Generic.List<MineralGUI> ChildListeners;
    public static System.Collections.Generic.Dictionary<int, int> RequiredToRefine;
    public Transform RefineryDispenseLocation;
    public Transform RefineryInterface;
    public TextMeshObjs TextMeshObjects;
    public LinkAnimation NotEnoughToDeliver;
    public LinkAnimation NotEnoughToRefine;
    public LinkAnimation NotEnoughToDispense;
    public AudioSource StateSound;
    public AudioSource NavSound;
    public MineralContainer ConnectedContainer;
    public System.Collections.Generic.List<CompressedMinerals> LinkedCompressedMinerals;
    public virtual void Awake()
    {
        MineralRefinery.instance = this;
        MineralRefinery.RequiredToRefine.Clear();
        MineralRefinery.ChildListeners.Clear();
    }

    public virtual void Start()
    {
        this.LoadRefineryData();

        {
            float _3814 = 3.9f;
            Vector3 _3815 = this.RefineryInterface.localPosition;
            _3815.y = _3814;
            this.RefineryInterface.localPosition = _3815;
        }
    }

    public virtual void OnApplicationQuit()
    {
        this.SaveRefineryData();
    }

    public virtual void LoadRefineryData()
    {
        int i = 0;
        eMineralType _type1 = default(eMineralType);
        rMineralType _type2 = default(rMineralType);
        int _amount = 0;
        string _data = null;
        string[] _split = null;
        string[] _itemData = null;
        //Raw
        if (SaveInfo.HasData(MineralRefinery.GetKey("RW")))
        {
            _data = SaveInfo.LoadData(MineralRefinery.GetKey("RW"));
            _split = _data.Split(new char[] {" "[0]});
            i = 0;
            while (i < (_split.Length - 1))
            {
                _itemData = _split[i].Split(new char[] {","[0]});
                _type1 = (eMineralType) int.Parse(_itemData[0]);
                _amount = int.Parse(_itemData[1]);
                MineralBarrel rawMineral = new MineralBarrel();
                rawMineral.mineralType = _type1;
                rawMineral.mineralAmount = _amount;
                //Add to list
                this.RawMinerals.Add(rawMineral);
                i++;
            }
        }
        //Refined
        if (SaveInfo.HasData(MineralRefinery.GetKey("RD")))
        {
            _data = SaveInfo.LoadData(MineralRefinery.GetKey("RD"));
            _split = _data.Split(new char[] {" "[0]});
            i = 0;
            while (i < (_split.Length - 1))
            {
                _itemData = _split[i].Split(new char[] {","[0]});
                _type2 = (rMineralType) int.Parse(_itemData[0]);
                _amount = int.Parse(_itemData[1]);
                rMineralAtt refMineral = new rMineralAtt();
                refMineral.refinedType = _type2;
                refMineral.refinedAmount = _amount;
                //Add to list
                this.RefinedMinerals.Add(refMineral);
                i++;
            }
        }
    }

    public virtual void SaveRefineryData()
    {
        int i = 0;
        string _data = null;
        //Raw
        _data = "";
        i = 0;
        while (i < this.RawMinerals.Count)
        {
            //public var mineralType : eMineralType;
            //public var mineralAmount : int = 0;
            int _type1 = (int) this.RawMinerals[i].mineralType;
            int _amount1 = this.RawMinerals[i].mineralAmount;
            _data = _data + (((_type1 + ",") + _amount1) + " ");
            SaveInfo.SaveData(MineralRefinery.GetKey("RW"), _data);
            i++;
        }
        //Refined
        _data = "";
        i = 0;
        while (i < this.RefinedMinerals.Count)
        {
            //public var refinedType : rMineralType;
            //public var refinedAmount : int = 0;
            int _type2 = (int) this.RefinedMinerals[i].refinedType;
            int _amount2 = this.RefinedMinerals[i].refinedAmount;
            _data = _data + (((_type2 + ",") + _amount2) + " ");
            SaveInfo.SaveData(MineralRefinery.GetKey("RD"), _data);
            i++;
        }
    }

    //Heavy task cpu usage v
    public virtual void Update()
    {
        MineralRefinery.WaitTime = Mathf.Clamp(MineralRefinery.WaitTime - Time.deltaTime, 0, 1000);
    }

    public static void StartWait(string _aniName, float _waitTime)
    {
        MineralRefinery.WaitTime = _waitTime;
        MineralSetup.instance.LoadingBarTarget.GetComponent<Animation>().Play(_aniName);
    }

    public virtual System.Collections.Generic.List<MineralBarrel> GetAllMineralData(System.Collections.Generic.List<CompressedMinerals> _list)
    {
        int i = 0;
        int i2 = 0;
        System.Collections.Generic.List<MineralBarrel> listAllItems = new List<MineralBarrel>();
        if (this.ConnectedContainer != null)
        {
            i = 0;
            while (i < this.ConnectedContainer.myMinerals.Count)
            {
                listAllItems.Add(this.ConnectedContainer.myMinerals[i]);
                i++;
            }
        }
        i = 0;
        while (i < _list.Count)
        {
            i2 = 0;
            while (i2 < _list[i].MineralData.Count)
            {
                listAllItems.Add(_list[i].MineralData[i2]);
                i2++;
            }
            i++;
        }
        return listAllItems;
    }

    public virtual void RefreshGUI()
    {
        int i = 0;
         //5 Indicates the amount of minerals that is being showed on the gui.
        int _rawCount = Mathf.Clamp(this.RawMinerals.Count - 5, 0, 1000);
        int _refinedCount = Mathf.Clamp(this.RefinedMinerals.Count - 5, 0, 1000);
        MineralGUI.RefineOffset = Mathf.Clamp(MineralGUI.RefineOffset, 0, _rawCount);
        MineralGUI.DispenseOffset = Mathf.Clamp(MineralGUI.DispenseOffset, 0, _refinedCount);
        System.Collections.Generic.List<MineralBarrel> MineralData = this.GetAllMineralData(this.LinkedCompressedMinerals);
        i = 0;
        while (i < 5)
        {
            if (MineralData.Count > i)
            {
                this.TextMeshObjects.LoadText[i].text = (MineralData[i].mineralAmount + " ") + MineralData[i].mineralType.ToString();
            }
            else
            {
                this.TextMeshObjects.LoadText[i].text = "";
            }
            if (this.RawMinerals.Count > (i + MineralGUI.RefineOffset))
            {
                this.TextMeshObjects.RefineText[i].text = (this.RawMinerals[i + MineralGUI.RefineOffset].mineralAmount + " ") + this.RawMinerals[i + MineralGUI.RefineOffset].mineralType.ToString();
            }
            else
            {
                this.TextMeshObjects.RefineText[i].text = "";
            }
            if (this.RefinedMinerals.Count > (i + MineralGUI.DispenseOffset))
            {
                this.TextMeshObjects.DispenseText[i].text = (this.RefinedMinerals[i + MineralGUI.DispenseOffset].refinedAmount + " ") + this.RefinedMinerals[i + MineralGUI.DispenseOffset].refinedType.ToString();
            }
            else
            {
                this.TextMeshObjects.DispenseText[i].text = "";
            }
            i++;
        }
        i = 0;
        while (i < MineralRefinery.ChildListeners.Count)
        {
            MineralRefinery.ChildListeners[i].RefreshGUI();
            i++;
        }
    }

    [UnityEngine.HideInInspector]
    public System.Collections.Generic.List<MineralBarrel> RawMinerals;
    [UnityEngine.HideInInspector]
    public System.Collections.Generic.List<rMineralAtt> RefinedMinerals;
    public virtual void InsertMineralToRefinery(eMineralType _mineralType, int _amount)
    {
        int i = 0;
        i = 0;
        while (i < this.RawMinerals.Count)
        {
            int eNumber = (int) _mineralType;
            int loopedNumber = (int) this.RawMinerals[i].mineralType;
            if (_mineralType == this.RawMinerals[i].mineralType)
            {
                this.RawMinerals[i].mineralAmount = this.RawMinerals[i].mineralAmount + _amount;
                this.RefreshGUI();
                return;
            }
            i++;
        }
        //else
        MineralBarrel _newClass = new MineralBarrel();
        _newClass.mineralType = _mineralType;
        _newClass.mineralAmount = _amount;
        this.RawMinerals.Add(_newClass);
        this.RefreshGUI();
    }

    public virtual void RemoveMineral(eMineralType _mineralType, int _minimumAmountToRefine)
    {
        int i = 0;
        i = 0;
        while (i < this.RawMinerals.Count)
        {
            if ((this.RawMinerals[i].mineralType == _mineralType) && (this.RawMinerals[i].mineralAmount >= _minimumAmountToRefine))
            {
                this.RawMinerals[i].mineralAmount = this.RawMinerals[i].mineralAmount - _minimumAmountToRefine;
            }
            if (this.RawMinerals[i].mineralAmount <= 0)
            {
                this.RawMinerals.RemoveAt(i);
            }
            i++;
        }
        this.RefreshGUI();
    }

    public virtual void RemoveRefined(rMineralType _mineralType, int _removeAmount)
    {
        int i = 0;
        i = 0;
        while (i < this.RefinedMinerals.Count)
        {
            if (this.RefinedMinerals[i].refinedType == _mineralType)
            {
                this.RefinedMinerals[i].refinedAmount = this.RefinedMinerals[i].refinedAmount - _removeAmount;
            }
            if (this.RefinedMinerals[i].refinedAmount <= 0)
            {
                this.RefinedMinerals.RemoveAt(i);
            }
            i++;
        }
        this.RefreshGUI();
    }

    public virtual void AddRefined(rMineralType _refinedType, int _amount)
    {
        int i = 0;
        i = 0;
        while (i < this.RefinedMinerals.Count)
        {
            if (this.RefinedMinerals[i].refinedType == _refinedType)
            {
                this.RefinedMinerals[i].refinedAmount = this.RefinedMinerals[i].refinedAmount + _amount;
                this.RefreshGUI();
                //Stops reading when material is found.
                return;
            }
            i++;
        }
        //if not found in list; will add to the list.//
        rMineralAtt newClass = new rMineralAtt();
        newClass.refinedType = _refinedType;
        newClass.refinedAmount = _amount;
        this.RefinedMinerals.Add(newClass);
        this.RefreshGUI();
    }

    public virtual void ConvertMineralToRefined(eMineralType _mineralType)
    {
        MineralSetup.instance.AddRefinedM(_mineralType);
        MineralRefinery.instance.RemoveMineral(_mineralType, MineralRefinery.RequiredToRefine[((int) _mineralType)]);
        MineralRefinery.instance.RefreshGUI();
    }

    public virtual void OnTriggerEnter(Collider col)
    {
        GameObject other = col.GetComponent<Collider>().gameObject;
        if (other.name.ToLower().Contains("compressedmineral"))
        {
            this.LinkedCompressedMinerals.Add((CompressedMinerals) other.GetComponent(typeof(CompressedMinerals)));
        }
    }

    public virtual void OnTriggerExit(Collider col)
    {
        GameObject other = col.GetComponent<Collider>().gameObject;
        if (other.name.ToLower().Contains("compressedmineral"))
        {
            this.LinkedCompressedMinerals.Remove((CompressedMinerals) other.GetComponent(typeof(CompressedMinerals)));
        }
    }

    public virtual void ToggleRefinery(bool enterRefinery)
    {
        if (enterRefinery)
        {

            {
                float _3816 = 3.8f;
                Vector3 _3817 = this.RefineryInterface.localPosition;
                _3817.y = _3816;
                this.RefineryInterface.localPosition = _3817;
            }
            this.StateSound.Play();
            this.RefreshGUI();
            this.SaveRefineryData();
        }
        else
        {

            {
                float _3818 = 3.9f;
                Vector3 _3819 = this.RefineryInterface.localPosition;
                _3819.y = _3818;
                this.RefineryInterface.localPosition = _3819;
            }
            this.StateSound.Play();
            this.RefreshGUI();
            this.SaveRefineryData();
        }
    }

    public static string GetKey(string chunk)
    {
        return "MineralRefinery/" + chunk;
    }

    public MineralRefinery()
    {
        this.LinkedCompressedMinerals = new List<CompressedMinerals>();
    }

    static MineralRefinery()
    {
        MineralRefinery.ChildListeners = new List<MineralGUI>();
        MineralRefinery.RequiredToRefine = new Dictionary<int, int>();
    }

}