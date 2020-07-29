using System.Collections.Generic;
using UnityEngine;
using System.Collections;

[System.Serializable]
public class MineralBarrel : object
{
    public eMineralType mineralType;
    public int mineralAmount;
    public MineralBarrel()
    {
        if (!this.initialized__MineralBarrel)
        {
            this.initialized__MineralBarrel = true;
        }
        this.mineralType = (eMineralType) 0;
        this.mineralAmount = 0;
    }

    public MineralBarrel(eMineralType _type, int _amount)
    {
        if (!this.initialized__MineralBarrel)
        {
            this.initialized__MineralBarrel = true;
        }
        this.mineralType = _type;
        this.mineralAmount = _amount;
    }

    private bool initialized__MineralBarrel;
}
[System.Serializable]
public partial class MineralContainer : MonoBehaviour
{
    public static MineralContainer instance;
    public static int currentMineralCount;
    public System.Collections.Generic.List<MineralBarrel> myMinerals;
    public virtual void Awake()
    {
        MineralContainer.instance = this;
    }

    public virtual void Update()
    {
        if (MineralContainer.currentMineralCount < 0)
        {
            MineralContainer.currentMineralCount = 0;
        }
    }

     /*var myEnumCount : int = System.Enum.GetNames(typeof(eMineralType)).Length;
	var i : int;
	for(i = 0; i < myEnumCount; i++)
	{
		var newMineral : MineralBarrel = new MineralBarrel();
		newMineral.mineralType = i;
		myMinerals.Add(newMineral);
	}*/    public virtual void Start()
    {
    }

    public virtual void InsertMineralToContainer(eMineralType _mineralType, int _amount)
    {
        int i = 0;
        i = 0;
        while (i < this.myMinerals.Count)
        {
            int eNumber = (int) _mineralType;
            int loopedNumber = (int) this.myMinerals[i].mineralType;
            if (_mineralType == this.myMinerals[i].mineralType)
            {
                this.myMinerals[i].mineralAmount = this.myMinerals[i].mineralAmount + _amount;
                MineralContainer.currentMineralCount = MineralContainer.currentMineralCount + _amount;
                return;
            }
            i++;
        }
        //else
        MineralBarrel _newClass = new MineralBarrel();
        _newClass.mineralType = _mineralType;
        _newClass.mineralAmount = _amount;
        this.myMinerals.Add(_newClass);
    }

    public virtual void RemoveMineral(eMineralType _mineralType)
    {
        int i = 0;
        i = 0;
        while (i < this.myMinerals.Count)
        {
            if (this.myMinerals[i].mineralType == _mineralType)
            {
                this.myMinerals.RemoveAt(i);
            }
            i++;
        }
    }

    public static void SaveDataToContainer(System.Collections.Generic.List<MineralBarrel> _listMinerals)
    {
        int i = 0;
        string _saveText = "";
        i = 0;
        while (i < _listMinerals.Count)
        {
            _saveText = _saveText + (((_listMinerals[i].mineralType + ":") + _listMinerals[i].mineralAmount) + " ");
            i++;
        }
        _listMinerals.Clear();
        PlayerPrefs.SetString("SavedMinerals", _saveText);
        PlayerPrefs.Save();
    }

    public static void LoadDataToContainer(System.Collections.Generic.List<MineralBarrel> _listMinerals)
    {
        int i = 0;
        if (PlayerPrefs.HasKey("SavedMinerals"))
        {
            string _loadText = PlayerPrefs.GetString("SavedMinerals");
            string[] _parts = _loadText.Split(new char[] {" "[0]});
            i = 0;
            while (i < (_parts.Length - 1))
            {
                eMineralType _type = (eMineralType) int.Parse(_parts[i].Split(new char[] {":"[0]})[0]);
                int _amount = int.Parse(_parts[i].Split(new char[] {":"[0]})[1]);
                MineralBarrel newMineral = new MineralBarrel(_type, _amount);
                _listMinerals.Add(newMineral);
                i++;
            }
            PlayerPrefs.DeleteKey("SavedMinerals");
            PlayerPrefs.Save();
        }
    }

    public MineralContainer()
    {
        this.myMinerals = new List<MineralBarrel>();
    }

}