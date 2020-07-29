using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SlavuicNetwork : MonoBehaviour
{
    public Transform PriorityWaypoint;
    public Transform SlavBaseHomePoint;
    public Transform SlavBaseDock1E;
    public Transform SlavBaseDock1P;
    public Transform SlavBaseDock1A;
    public static Transform target;
    public static Transform primaryTarget;
    public GameObject Elite1;
    public GameObject Elite2;
    public SlavuicProteusAI BaseDroneLauncher;
    public SlavuicProteusAI BaseRayGun1;
    public SlavuicProteusAI BaseRayGun2;
    public SlavuicProteusAI BaseRadar1;
    public SlavuicProteusAI BaseRadar2;
    public static int TC0aDeathRow;
    public static int TC1DeathRow;
    public static int TC3DeathRow;
    public static int TC4DeathRow;
    public static int TC6DeathRow;
    public static int TC7DeathRow;
    public static int TC8DeathRow;
    public static int TC9DeathRow;
    public static int CasualtiesFromTC1;
    public static Transform FoundExtraBig;
    public static bool Emergency;
    public static bool Attention;
    public static bool Confirmed;
    public static SlavuicNetwork instance;
    public virtual void Awake()
    {
        SlavuicNetwork.instance = this;
    }

    public virtual void Tick()
    {
        SlavuicNetwork.Attention = false;
        //Debug.Log(FoundExtraBig.name);
        if (SlavuicNetwork.primaryTarget)
        {
            if (SlavuicNetwork.TC7DeathRow > 100)
            {
                if (SlavuicNetwork.primaryTarget.name.Contains("xb"))
                {
                    SlavuicNetwork.Emergency = true;
                }
            }
        }
        if (SlavuicNetwork.TC0aDeathRow > 0)
        {
            SlavuicNetwork.TC0aDeathRow = SlavuicNetwork.TC0aDeathRow - 1;
        }
        if (SlavuicNetwork.CasualtiesFromTC1 < 3)
        {
            if (SlavuicNetwork.TC1DeathRow > 0)
            {
                SlavuicNetwork.TC1DeathRow = SlavuicNetwork.TC1DeathRow - 1;
            }
        }
        else
        {
            SlavuicNetwork.TC1DeathRow = 700;
        }
        if (SlavuicNetwork.TC3DeathRow > 0)
        {
            SlavuicNetwork.TC3DeathRow = SlavuicNetwork.TC3DeathRow - 1;
            if (SlavuicNetwork.TC3DeathRow > 30)
            {
                SlavuicNetwork.TC3DeathRow = 30;
            }
        }
        if (SlavuicNetwork.TC4DeathRow > 0)
        {
            SlavuicNetwork.TC4DeathRow = SlavuicNetwork.TC4DeathRow - 1;
            if (SlavuicNetwork.TC4DeathRow > 30)
            {
                SlavuicNetwork.TC4DeathRow = 30;
            }
        }
        if (SlavuicNetwork.TC6DeathRow > 0)
        {
            SlavuicNetwork.TC6DeathRow = SlavuicNetwork.TC6DeathRow - 1;
        }
        if (SlavuicNetwork.TC7DeathRow > 0)
        {
            SlavuicNetwork.TC7DeathRow = SlavuicNetwork.TC7DeathRow - 1;
        }
        if (SlavuicNetwork.TC8DeathRow > 0)
        {
            SlavuicNetwork.TC8DeathRow = SlavuicNetwork.TC8DeathRow - 1;
        }
        if (SlavuicNetwork.TC9DeathRow > 0)
        {
            SlavuicNetwork.TC9DeathRow = SlavuicNetwork.TC9DeathRow - 1;
        }
    }

    public virtual void Start()
    {
        this.InvokeRepeating("Tick", 1, 1);
    }

}