using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class TerrahyptianNetwork : MonoBehaviour
{
    public Transform PriorityWaypoint;
    public Transform EnemyTarget1;
    public Transform EnemyTarget2;
    public static Transform AnExtraBigTC1;
    public static Transform AnExtraBigTC4;
    public static Transform AnExtraBigTC5;
    public static Transform AnExtraBigTC6;
    public static Transform AnExtraBigTC7;
    public static Transform AnExtraBigTC8;
    public static Transform AnExtraBigTC9;
    public Transform NukeMarker;
    public Transform TerrahyptianBase;
    public Transform AnodianBase;
    public Transform LevianBase;
    public Transform TerrahyptianGuardPost1;
    public Transform TerrahyptianGuardPost2;
    public static int AlertLVL1;
    public static int AlertLVL2;
    public static bool UnitsPresent;
    public static int TC1Nuisance;
    public static int TC4Nuisance;
    public static int TC5Nuisance;
    public static int TC6Nuisance;
    public static int TC7Nuisance;
    public static int TC8Nuisance;
    public static int TC9Nuisance;
    public static int TC0aCriminalLevel;
    public static int TC1CriminalLevel;
    public static int TC4CriminalLevel;
    public static int TC5CriminalLevel;
    public static int TC6CriminalLevel;
    public static int TC7CriminalLevel;
    public static int TC8CriminalLevel;
    public static int TC9CriminalLevel;
    public static int AlertTime;
    public static TerrahyptianNetwork instance;
    public static int CasualtyMeter;
    public static bool HasDropped;
    public virtual void Awake()
    {
        TerrahyptianNetwork.instance = this;
    }

    public virtual void Start()
    {
        this.InvokeRepeating("Tick", 1, 1);
        this.InvokeRepeating("Tick2", 0.7f, 3.3f);
        TerrahyptianNetwork.HasDropped = false;
        TerrahyptianNetwork.AlertLVL1 = 0;
        TerrahyptianNetwork.AlertLVL2 = 0;
    }

    public virtual void Tick()
    {
        //Debug.Log(TC1CriminalLevel);
        //if(EnemyTarget2)
        //Debug.Log(EnemyTarget2.name);
        if (TerrahyptianNetwork.TC1CriminalLevel < 480)
        {
            if (TerrahyptianNetwork.TC1CriminalLevel > 0)
            {
                TerrahyptianNetwork.TC1CriminalLevel = TerrahyptianNetwork.TC1CriminalLevel - 1;
            }
            if (TerrahyptianNetwork.TC1Nuisance > 2)
            {
                TerrahyptianNetwork.TC1CriminalLevel = 500;
            }
        }
        if (TerrahyptianNetwork.TC4CriminalLevel < 480)
        {
            if (TerrahyptianNetwork.TC4CriminalLevel > 0)
            {
                TerrahyptianNetwork.TC4CriminalLevel = TerrahyptianNetwork.TC4CriminalLevel - 1;
            }
            if (TerrahyptianNetwork.TC4Nuisance > 2)
            {
                TerrahyptianNetwork.TC4CriminalLevel = 500;
            }
        }
        if (TerrahyptianNetwork.TC5CriminalLevel < 480)
        {
            if (TerrahyptianNetwork.TC5CriminalLevel > 0)
            {
                TerrahyptianNetwork.TC5CriminalLevel = TerrahyptianNetwork.TC5CriminalLevel - 1;
            }
            if (TerrahyptianNetwork.TC5Nuisance > 2)
            {
                TerrahyptianNetwork.TC5CriminalLevel = 500;
            }
        }
        if (TerrahyptianNetwork.TC6CriminalLevel < 480)
        {
            if (TerrahyptianNetwork.TC6CriminalLevel > 0)
            {
                TerrahyptianNetwork.TC6CriminalLevel = TerrahyptianNetwork.TC6CriminalLevel - 1;
            }
            if (TerrahyptianNetwork.TC6Nuisance > 2)
            {
                TerrahyptianNetwork.TC6CriminalLevel = 500;
            }
        }
        if (TerrahyptianNetwork.TC7CriminalLevel < 480)
        {
            if (TerrahyptianNetwork.TC7CriminalLevel > 0)
            {
                TerrahyptianNetwork.TC7CriminalLevel = TerrahyptianNetwork.TC7CriminalLevel - 1;
            }
            if (TerrahyptianNetwork.TC7Nuisance > 2)
            {
                TerrahyptianNetwork.TC7CriminalLevel = 500;
            }
        }
        if (TerrahyptianNetwork.TC8CriminalLevel < 480)
        {
            if (TerrahyptianNetwork.TC8CriminalLevel > 0)
            {
                TerrahyptianNetwork.TC8CriminalLevel = TerrahyptianNetwork.TC8CriminalLevel - 1;
            }
            if (TerrahyptianNetwork.TC8Nuisance > 2)
            {
                TerrahyptianNetwork.TC8CriminalLevel = 500;
            }
        }
        if (TerrahyptianNetwork.TC9CriminalLevel < 480)
        {
            if (TerrahyptianNetwork.TC9CriminalLevel > 0)
            {
                TerrahyptianNetwork.TC9CriminalLevel = TerrahyptianNetwork.TC9CriminalLevel - 1;
            }
            if (TerrahyptianNetwork.TC9Nuisance > 2)
            {
                TerrahyptianNetwork.TC9CriminalLevel = 500;
            }
        }
    }

    public virtual void Tick2()
    {
        if (TerrahyptianNetwork.AnExtraBigTC1)
        {
            if (TerrahyptianNetwork.AnExtraBigTC1.name.Contains("rok"))
            {
                TerrahyptianNetwork.AnExtraBigTC1 = null;
            }
        }
        if (TerrahyptianNetwork.AnExtraBigTC4)
        {
            if (TerrahyptianNetwork.AnExtraBigTC4.name.Contains("rok"))
            {
                TerrahyptianNetwork.AnExtraBigTC4 = null;
            }
        }
        if (TerrahyptianNetwork.AnExtraBigTC5)
        {
            if (TerrahyptianNetwork.AnExtraBigTC5.name.Contains("rok"))
            {
                TerrahyptianNetwork.AnExtraBigTC5 = null;
            }
        }
        if (TerrahyptianNetwork.AnExtraBigTC6)
        {
            if (TerrahyptianNetwork.AnExtraBigTC6.name.Contains("rok"))
            {
                TerrahyptianNetwork.AnExtraBigTC6 = null;
            }
        }
        if (TerrahyptianNetwork.AnExtraBigTC7)
        {
            if (TerrahyptianNetwork.AnExtraBigTC7.name.Contains("rok"))
            {
                TerrahyptianNetwork.AnExtraBigTC7 = null;
            }
        }
        if (TerrahyptianNetwork.AnExtraBigTC8)
        {
            if (TerrahyptianNetwork.AnExtraBigTC8.name.Contains("rok"))
            {
                TerrahyptianNetwork.AnExtraBigTC8 = null;
            }
        }
        if (TerrahyptianNetwork.AnExtraBigTC9)
        {
            if (TerrahyptianNetwork.AnExtraBigTC9.name.Contains("rok"))
            {
                TerrahyptianNetwork.AnExtraBigTC9 = null;
            }
        }
        this.EnemyTarget2 = null;
        TerrahyptianNetwork.UnitsPresent = false;
    }

}