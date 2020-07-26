using UnityEngine;
using System.Collections;

public enum GUIType
{
    DisposeLoad = 0,
    Refine = 1,
    Dispense = 2
}

[System.Serializable]
public partial class MineralGUI : MonoBehaviour
{
    public GUIType ButtonType;
    public int ButtonID;
    public static int RefineOffset;
    public static int DispenseOffset;
    public GameObject BrightModel;
    public virtual void Start()
    {
        this.Invoke("InitializeGUI", 1);
        this.Invoke("RefreshGUI", 2);
    }

    public virtual void InitializeGUI()
    {
        MineralRefinery.ChildListeners.Add(this);
    }

    public virtual IEnumerator DisposeLoad()
    {
        int i = 0;
        int i2 = 0;
        MineralRefinery.StartWait(MineralSetup.DeliverLoadAnimation, MineralSetup.DeliverLoadWaitTime);
        yield return new WaitForSeconds(MineralSetup.DeliverLoadWaitTime);
        if (MineralRefinery.instance.ConnectedContainer != null)
        {
            i = 0;
            while (i < MineralRefinery.instance.ConnectedContainer.myMinerals.Count)
            {
                eMineralType _mType = MineralRefinery.instance.ConnectedContainer.myMinerals[i].mineralType;
                int _mAmount = MineralRefinery.instance.ConnectedContainer.myMinerals[i].mineralAmount;
                MineralContainer.currentMineralCount = MineralContainer.currentMineralCount - _mAmount;
                MineralRefinery.instance.InsertMineralToRefinery(_mType, _mAmount);
                i++;
            }
            MineralRefinery.instance.ConnectedContainer.myMinerals.Clear();
        }
        i = 0;
        while (i < MineralRefinery.instance.LinkedCompressedMinerals.Count)
        {
            System.Collections.Generic.List<MineralBarrel> _mData = null;
            _mData = MineralRefinery.instance.LinkedCompressedMinerals[i].MineralData;
            i2 = 0;
            while (i2 < _mData.Count)
            {
                MineralRefinery.instance.InsertMineralToRefinery(_mData[i2].mineralType, _mData[i2].mineralAmount);
                i2++;
            }
            UnityEngine.Object.Destroy(MineralRefinery.instance.LinkedCompressedMinerals[i].gameObject);
            i++;
        }
        MineralRefinery.instance.LinkedCompressedMinerals.Clear();
    }

    public virtual IEnumerator Refine()
    {
        if (MineralRefinery.instance.RawMinerals.Count > (this.ButtonID + MineralGUI.RefineOffset))
        {
            int _mType = (int) MineralRefinery.instance.RawMinerals[this.ButtonID + MineralGUI.RefineOffset].mineralType;
            int _mAmount = MineralRefinery.instance.RawMinerals[this.ButtonID + MineralGUI.RefineOffset].mineralAmount;
            if (_mAmount >= MineralRefinery.RequiredToRefine[_mType])
            {
                MineralRefinery.StartWait(MineralSetup.RefineLoadAnimation, MineralSetup.RefineLoadWaitTime);
                yield return new WaitForSeconds(MineralSetup.RefineLoadWaitTime);
                MineralRefinery.instance.ConvertMineralToRefined((eMineralType) _mType);
                Debug.Log("Refined " + MineralRefinery.instance.RawMinerals[this.ButtonID + MineralGUI.RefineOffset].mineralType.ToString());
            }
            else
            {
                Debug.Log("Not enough to refine!");
            }
        }
        else
        {
            Debug.Log("Not enough to refine!");
        }
    }

    public virtual IEnumerator Dispense()
    {
        if (MineralRefinery.instance.RefinedMinerals.Count > (this.ButtonID + MineralGUI.DispenseOffset))
        {
            MineralRefinery.StartWait(MineralSetup.DispenseLoadAnimation, MineralSetup.DispenseLoadWaitTime);
            yield return new WaitForSeconds(MineralSetup.DispenseLoadWaitTime);
            string _prefabName = MineralRefinery.instance.RefinedMinerals[this.ButtonID + MineralGUI.DispenseOffset].refinedType.ToString();
            Vector3 _pos = MineralRefinery.instance.RefineryDispenseLocation.position;
            Quaternion _rot = MineralRefinery.instance.RefineryDispenseLocation.rotation;
            GameObject _prefab = (GameObject) Resources.Load("RefinedMaterials/" + _prefabName, typeof(GameObject));
            if (_prefab != null)
            {
                GameObject _Obj = UnityEngine.Object.Instantiate(_prefab, _pos, _rot);
                MineralRefinery.instance.RemoveRefined(MineralRefinery.instance.RefinedMinerals[this.ButtonID + MineralGUI.DispenseOffset].refinedType, 1);
            }
            else
            {
                Debug.LogError(_prefabName + " was not found in Assets/Resources/RefinedMaterials/");
            }
        }
        else
        {
            Debug.Log("Not enough to Dispense!");
        }
    }

    public virtual void RefreshGUI()
    {
        switch (this.ButtonType)
        {
            case GUIType.Refine:
                if ((this.ButtonID + MineralGUI.RefineOffset) < MineralRefinery.instance.RawMinerals.Count)
                {
                    int _ind = (int) MineralRefinery.instance.RawMinerals[this.ButtonID + MineralGUI.RefineOffset].mineralType;
                    ((TextMesh) this.transform.Find("Text").GetComponent(typeof(TextMesh))).text = ("Refine " + MineralRefinery.RequiredToRefine[_ind]) + "";
                }
                else
                {
                    ((TextMesh) this.transform.Find("Text").GetComponent(typeof(TextMesh))).text = " ";
                }
                break;
            case GUIType.Dispense:
                if ((this.ButtonID + MineralGUI.DispenseOffset) < MineralRefinery.instance.RefinedMinerals.Count)
                {
                    ((TextMesh) this.transform.Find("Text").GetComponent(typeof(TextMesh))).text = "Dispense 1";
                }
                else
                {
                    ((TextMesh) this.transform.Find("Text").GetComponent(typeof(TextMesh))).text = " ";
                }
                break;
        }
    }

    public virtual void OnMouseEnter()
    {
        MineralRefinery.instance.RefreshGUI();
        this.BrightModel.SetActive(true);
    }

    public virtual void OnMouseExit()
    {
        MineralRefinery.instance.RefreshGUI();
        this.BrightModel.SetActive(false);
    }

    public virtual void OnMouseDownAsButton()
    {
        this.BrightModel.SetActive(false);
    }

    public virtual void OnMouseUpAsButton()
    {
        MineralRefinery.instance.RefreshGUI();
        if (MineralRefinery.WaitTime == 0)
        {
            switch (this.ButtonType)
            {
                case GUIType.DisposeLoad:
                    this.StartCoroutine(this.DisposeLoad());
                    break;
                case GUIType.Refine:
                    this.StartCoroutine(this.Refine());
                    break;
                case GUIType.Dispense:
                    this.StartCoroutine(this.Dispense());
                    break;
                default:
                    Debug.LogError("ButtonType has not been assigned!", this);
                    break;
            }
        }
    }

}