using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MevNavNetwork : MonoBehaviour
{
    public Transform PriorityWaypoint;
    public Transform EnemyTarget1;
    public Transform EnemyTarget2;
    public static Transform xbTarget;
    public static int xbTargetTick;
    public Transform Threat1;
    public GameObject Elite1;
    public GameObject Elite2;
    public GameObject Elite3;
    public GameObject Elite4;
    public static int AlertLVL1;
    public static int AlertLVL2;
    public static int AlertLVL3;
    public static int TC1Nuisance;
    public static int TC2Nuisance;
    public static int TC3Nuisance;
    public static int TC4Nuisance;
    public static int TC5Nuisance;
    public static int TC6Nuisance;
    public static int TC8Nuisance;
    public static int TC9Nuisance;
    public static int TC0aDeathRow;
    public static int TC1DeathRow;
    public static int TC2DeathRow;
    public static int TC3DeathRow;
    public static int TC4DeathRow;
    public static int TC5DeathRow;
    public static int TC6DeathRow;
    public static int TC8DeathRow;
    public static int TC9DeathRow;
    public static int AlertTime;
    public static bool RequestCruiseMissile;
    public static MevNavNetwork instance;
    public virtual void Awake()
    {
        MevNavNetwork.instance = this;
    }

    public virtual void Start()
    {
        this.InvokeRepeating("Tick", 0.3f, 1);
        MevNavNetwork.AlertLVL1 = 0;
        MevNavNetwork.AlertLVL2 = 0;
    }

    public virtual void Tick()//Debug.Log("Piri " + TC1DeathRow);
    {
        if (MevNavNetwork.xbTargetTick > 0)
        {
            MevNavNetwork.xbTargetTick = MevNavNetwork.xbTargetTick - 1;
        }
        else
        {
            MevNavNetwork.xbTargetTick = 8;
            MevNavNetwork.xbTarget = null;
        }
        if (MevNavNetwork.TC1Nuisance > 2)
        {
            if (MevNavNetwork.TC1DeathRow < 600)
            {
                MevNavNetwork.TC1DeathRow = 630;
            }
            MevNavNetwork.TC1Nuisance = 0;
        }
        if (MevNavNetwork.TC2Nuisance > 2)
        {
            if (MevNavNetwork.TC2DeathRow < 600)
            {
                MevNavNetwork.TC2DeathRow = 630;
            }
            MevNavNetwork.TC2Nuisance = 0;
        }
        if (MevNavNetwork.TC3Nuisance > 2)
        {
            if (MevNavNetwork.TC3DeathRow < 600)
            {
                MevNavNetwork.TC3DeathRow = 630;
            }
            MevNavNetwork.TC3Nuisance = 0;
        }
        if (MevNavNetwork.TC4Nuisance > 2)
        {
            if (MevNavNetwork.TC4DeathRow < 600)
            {
                MevNavNetwork.TC4DeathRow = 630;
            }
            MevNavNetwork.TC4Nuisance = 0;
        }
        if (MevNavNetwork.TC5Nuisance > 2)
        {
            if (MevNavNetwork.TC5DeathRow < 600)
            {
                MevNavNetwork.TC5DeathRow = 630;
            }
            MevNavNetwork.TC5Nuisance = 0;
        }
        if (MevNavNetwork.TC6Nuisance > 2)
        {
            if (MevNavNetwork.TC6DeathRow < 600)
            {
                MevNavNetwork.TC6DeathRow = 630;
            }
            MevNavNetwork.TC6Nuisance = 0;
        }
        if (MevNavNetwork.TC8Nuisance > 2)
        {
            if (MevNavNetwork.TC8DeathRow < 600)
            {
                MevNavNetwork.TC8DeathRow = 630;
            }
            MevNavNetwork.TC8Nuisance = 0;
        }
        if (MevNavNetwork.TC9Nuisance > 2)
        {
            if (MevNavNetwork.TC9DeathRow < 600)
            {
                MevNavNetwork.TC9DeathRow = 630;
            }
            MevNavNetwork.TC9Nuisance = 0;
        }
        if (MevNavNetwork.TC0aDeathRow > 0)
        {
            MevNavNetwork.TC0aDeathRow = MevNavNetwork.TC0aDeathRow - 1;
        }
        if (MevNavNetwork.TC1DeathRow < 600)
        {
            if (MevNavNetwork.TC1DeathRow > 0)
            {
                MevNavNetwork.TC1DeathRow = MevNavNetwork.TC1DeathRow - 1;
            }
        }
        if (MevNavNetwork.TC2DeathRow < 600)
        {
            if (MevNavNetwork.TC2DeathRow > 0)
            {
                MevNavNetwork.TC2DeathRow = MevNavNetwork.TC2DeathRow - 1;
            }
        }
        if (MevNavNetwork.TC3DeathRow < 600)
        {
            if (MevNavNetwork.TC3DeathRow > 0)
            {
                MevNavNetwork.TC3DeathRow = MevNavNetwork.TC3DeathRow - 1;
            }
        }
        if (MevNavNetwork.TC4DeathRow < 600)
        {
            if (MevNavNetwork.TC4DeathRow > 0)
            {
                MevNavNetwork.TC4DeathRow = MevNavNetwork.TC4DeathRow - 1;
            }
        }
        if (MevNavNetwork.TC5DeathRow < 600)
        {
            if (MevNavNetwork.TC5DeathRow > 0)
            {
                MevNavNetwork.TC5DeathRow = MevNavNetwork.TC5DeathRow - 1;
            }
        }
        if (MevNavNetwork.TC6DeathRow < 600)
        {
            if (MevNavNetwork.TC6DeathRow > 0)
            {
                MevNavNetwork.TC6DeathRow = MevNavNetwork.TC6DeathRow - 1;
            }
        }
        if (MevNavNetwork.TC8DeathRow < 600)
        {
            if (MevNavNetwork.TC8DeathRow > 0)
            {
                MevNavNetwork.TC8DeathRow = MevNavNetwork.TC8DeathRow - 1;
            }
        }
        if (MevNavNetwork.TC9DeathRow < 600)
        {
            if (MevNavNetwork.TC9DeathRow > 0)
            {
                MevNavNetwork.TC9DeathRow = MevNavNetwork.TC9DeathRow - 1;
            }
        }
        if (MevNavNetwork.AlertTime > 0)
        {
            MevNavNetwork.AlertTime = MevNavNetwork.AlertTime - 1;
        }
    }

}