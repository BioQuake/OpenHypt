using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class DutvutanianNetwork : MonoBehaviour
{
    public Transform PriorityWaypoint;
    public Transform EnemyTargetMin;
    public Transform EnemyTargetMinStat;
    public int EnemyTargetMinNum;
    public Transform EnemyTargetMed;
    public Transform EnemyTargetMedStat;
    public int EnemyTargetMedNum;
    public static Transform AnExtraBigTC1;
    public static Transform AnExtraBigTC2;
    public static Transform AnExtraBigTC3;
    public static Transform AnExtraBigTC4;
    public static Transform AnExtraBigTC5;
    public static Transform AnExtraBigTC6;
    public static Transform AnExtraBigTC7;
    public static Transform AnExtraBigTC8;
    public Transform DutvutanianBase;
    public Transform DutvutanianGuardPost1;
    public Transform DutvutanianGuardPost2;
    public GameObject Elite1;
    public static bool UnitsPresent;
    public static int TC1Nuisance;
    public static int TC0aCriminalLevel;
    public int TC1CL;
    public int TC2CL;
    public int TC3CL;
    public int TC4CL;
    public int TC5CL;
    public int TC6CL;
    public int TC7CL;
    public int TC8CL;
    public static int TC1CriminalLevel;
    public static int TC2CriminalLevel;
    public static int TC3CriminalLevel;
    public static int TC4CriminalLevel;
    public static int TC5CriminalLevel;
    public static int TC6CriminalLevel;
    public static int TC7CriminalLevel;
    public static int TC8CriminalLevel;
    public static int TC1CriminalPoints;
    public static int TC2CriminalPoints;
    public static int TC3CriminalPoints;
    public static int TC4CriminalPoints;
    public static int TC5CriminalPoints;
    public static int TC6CriminalPoints;
    public static int TC7CriminalPoints;
    public static int TC8CriminalPoints;
    public static int AlertTime;
    public static DutvutanianNetwork instance;
    public static int CasualtyMeter;
    public static bool HasDropped;
    public virtual void Awake()
    {
        DutvutanianNetwork.instance = this;
    }

    public virtual void Start()
    {
        this.InvokeRepeating("Tick", 1, 1);
        this.InvokeRepeating("Tick2", 0.7f, 3.3f);
        DutvutanianNetwork.HasDropped = false;
    }

    public virtual void Tick()//Debug.Log(TC1CriminalLevel);
    {
        if (DutvutanianNetwork.TC1CriminalLevel < 480)
        {
            if (DutvutanianNetwork.TC1CriminalLevel > 0)
            {
                DutvutanianNetwork.TC1CriminalLevel = DutvutanianNetwork.TC1CriminalLevel - 1;
            }
            if (DutvutanianNetwork.TC1CriminalPoints > 3)
            {
                DutvutanianNetwork.TC1CriminalLevel = 500;
            }
        }
        else
        {
            if (DutvutanianNetwork.TC1CriminalLevel > 800)
            {
                DutvutanianNetwork.AlertTime = 240;
                if (DutvutanianNetwork.TC1CriminalLevel > 1400)
                {
                    if (this.Elite1)
                    {
                        this.Elite1.SetActive(true);
                    }
                }
            }
        }
        if (DutvutanianNetwork.TC2CriminalLevel < 480)
        {
            if (DutvutanianNetwork.TC2CriminalLevel > 0)
            {
                DutvutanianNetwork.TC2CriminalLevel = DutvutanianNetwork.TC2CriminalLevel - 1;
            }
            if (DutvutanianNetwork.TC2CriminalPoints > 3)
            {
                DutvutanianNetwork.TC2CriminalLevel = 500;
            }
        }
        else
        {
            if (DutvutanianNetwork.TC2CriminalLevel > 800)
            {
                DutvutanianNetwork.AlertTime = 240;
            }
            if (DutvutanianNetwork.TC2CriminalLevel > 1400)
            {
                if (this.Elite1)
                {
                    this.Elite1.SetActive(true);
                }
            }
        }
        if (DutvutanianNetwork.TC3CriminalLevel < 480)
        {
            if (DutvutanianNetwork.TC3CriminalLevel > 0)
            {
                DutvutanianNetwork.TC3CriminalLevel = DutvutanianNetwork.TC3CriminalLevel - 1;
            }
            if (DutvutanianNetwork.TC3CriminalPoints > 3)
            {
                DutvutanianNetwork.TC3CriminalLevel = 500;
            }
        }
        else
        {
            if (DutvutanianNetwork.TC3CriminalLevel > 800)
            {
                DutvutanianNetwork.AlertTime = 240;
            }
            if (DutvutanianNetwork.TC3CriminalLevel > 1400)
            {
                if (this.Elite1)
                {
                    this.Elite1.SetActive(true);
                }
            }
        }
        if (DutvutanianNetwork.TC4CriminalLevel < 480)
        {
            if (DutvutanianNetwork.TC4CriminalLevel > 0)
            {
                DutvutanianNetwork.TC4CriminalLevel = DutvutanianNetwork.TC4CriminalLevel - 1;
            }
            if (DutvutanianNetwork.TC4CriminalPoints > 3)
            {
                DutvutanianNetwork.TC4CriminalLevel = 500;
            }
        }
        else
        {
            if (DutvutanianNetwork.TC4CriminalLevel > 800)
            {
                DutvutanianNetwork.AlertTime = 240;
            }
            if (DutvutanianNetwork.TC4CriminalLevel > 1400)
            {
                if (this.Elite1)
                {
                    this.Elite1.SetActive(true);
                }
            }
        }
        if (DutvutanianNetwork.TC5CriminalLevel < 480)
        {
            if (DutvutanianNetwork.TC5CriminalLevel > 0)
            {
                DutvutanianNetwork.TC5CriminalLevel = DutvutanianNetwork.TC5CriminalLevel - 1;
            }
            if (DutvutanianNetwork.TC5CriminalPoints > 3)
            {
                DutvutanianNetwork.TC5CriminalLevel = 500;
            }
        }
        else
        {
            if (DutvutanianNetwork.TC5CriminalLevel > 800)
            {
                DutvutanianNetwork.AlertTime = 240;
            }
            if (DutvutanianNetwork.TC5CriminalLevel > 1400)
            {
                if (this.Elite1)
                {
                    this.Elite1.SetActive(true);
                }
            }
        }
        if (DutvutanianNetwork.TC6CriminalLevel < 480)
        {
            if (DutvutanianNetwork.TC6CriminalLevel > 0)
            {
                DutvutanianNetwork.TC6CriminalLevel = DutvutanianNetwork.TC6CriminalLevel - 1;
            }
            if (DutvutanianNetwork.TC6CriminalPoints > 3)
            {
                DutvutanianNetwork.TC6CriminalLevel = 500;
            }
        }
        else
        {
            if (DutvutanianNetwork.TC6CriminalLevel > 800)
            {
                DutvutanianNetwork.AlertTime = 240;
            }
            if (DutvutanianNetwork.TC6CriminalLevel > 1400)
            {
                if (this.Elite1)
                {
                    this.Elite1.SetActive(true);
                }
            }
        }
        if (DutvutanianNetwork.TC7CriminalLevel < 480)
        {
            if (DutvutanianNetwork.TC7CriminalLevel > 0)
            {
                DutvutanianNetwork.TC7CriminalLevel = DutvutanianNetwork.TC7CriminalLevel - 1;
            }
            if (DutvutanianNetwork.TC7CriminalPoints > 3)
            {
                DutvutanianNetwork.TC7CriminalLevel = 500;
            }
        }
        else
        {
            if (DutvutanianNetwork.TC7CriminalLevel > 800)
            {
                DutvutanianNetwork.AlertTime = 240;
            }
            if (DutvutanianNetwork.TC7CriminalLevel > 1400)
            {
                if (this.Elite1)
                {
                    this.Elite1.SetActive(true);
                }
            }
        }
        if (DutvutanianNetwork.TC8CriminalLevel < 480)
        {
            if (DutvutanianNetwork.TC8CriminalLevel > 0)
            {
                DutvutanianNetwork.TC8CriminalLevel = DutvutanianNetwork.TC8CriminalLevel - 1;
            }
            if (DutvutanianNetwork.TC8CriminalPoints > 3)
            {
                DutvutanianNetwork.TC8CriminalLevel = 500;
            }
        }
        else
        {
            if (DutvutanianNetwork.TC8CriminalLevel > 800)
            {
                DutvutanianNetwork.AlertTime = 240;
            }
            if (DutvutanianNetwork.TC8CriminalLevel > 1400)
            {
                if (this.Elite1)
                {
                    this.Elite1.SetActive(true);
                }
            }
        }
        this.TC1CL = DutvutanianNetwork.TC1CriminalLevel;
        this.TC2CL = DutvutanianNetwork.TC2CriminalLevel;
        this.TC3CL = DutvutanianNetwork.TC3CriminalLevel;
        this.TC4CL = DutvutanianNetwork.TC4CriminalLevel;
        this.TC5CL = DutvutanianNetwork.TC5CriminalLevel;
        this.TC6CL = DutvutanianNetwork.TC6CriminalLevel;
        this.TC7CL = DutvutanianNetwork.TC7CriminalLevel;
        this.TC8CL = DutvutanianNetwork.TC8CriminalLevel;
        if (this.EnemyTargetMin)
        {
            if (this.EnemyTargetMinStat != this.EnemyTargetMin)
            {
                this.EnemyTargetMinNum = 15;
            }
            this.EnemyTargetMinStat = this.EnemyTargetMin;
            if (this.EnemyTargetMinNum < 1)
            {
                this.EnemyTargetMin = null;
            }
        }
        else
        {
            this.EnemyTargetMinNum = 0;
        }
        if (this.EnemyTargetMinNum > 0)
        {
            this.EnemyTargetMinNum = this.EnemyTargetMinNum - 1;
        }
        if (DutvutanianNetwork.AlertTime > 0)
        {
            DutvutanianNetwork.AlertTime = DutvutanianNetwork.AlertTime - 1;
        }
    }

    public virtual void Tick2()
    {
        if (DutvutanianNetwork.AnExtraBigTC1)
        {
            if (DutvutanianNetwork.AnExtraBigTC1.name.Contains("rok"))
            {
                DutvutanianNetwork.AnExtraBigTC1 = null;
            }
        }
        if (DutvutanianNetwork.AnExtraBigTC2)
        {
            if (DutvutanianNetwork.AnExtraBigTC2.name.Contains("rok"))
            {
                DutvutanianNetwork.AnExtraBigTC2 = null;
            }
        }
        if (DutvutanianNetwork.AnExtraBigTC3)
        {
            if (DutvutanianNetwork.AnExtraBigTC3.name.Contains("rok"))
            {
                DutvutanianNetwork.AnExtraBigTC3 = null;
            }
        }
        if (DutvutanianNetwork.AnExtraBigTC4)
        {
            if (DutvutanianNetwork.AnExtraBigTC4.name.Contains("rok"))
            {
                DutvutanianNetwork.AnExtraBigTC4 = null;
            }
        }
        if (DutvutanianNetwork.AnExtraBigTC5)
        {
            if (DutvutanianNetwork.AnExtraBigTC5.name.Contains("rok"))
            {
                DutvutanianNetwork.AnExtraBigTC5 = null;
            }
        }
        if (DutvutanianNetwork.AnExtraBigTC6)
        {
            if (DutvutanianNetwork.AnExtraBigTC6.name.Contains("rok"))
            {
                DutvutanianNetwork.AnExtraBigTC6 = null;
            }
        }
        if (DutvutanianNetwork.AnExtraBigTC7)
        {
            if (DutvutanianNetwork.AnExtraBigTC7.name.Contains("rok"))
            {
                DutvutanianNetwork.AnExtraBigTC7 = null;
            }
        }
        if (DutvutanianNetwork.AnExtraBigTC8)
        {
            if (DutvutanianNetwork.AnExtraBigTC8.name.Contains("rok"))
            {
                DutvutanianNetwork.AnExtraBigTC8 = null;
            }
        }
        DutvutanianNetwork.UnitsPresent = false;
    }

}