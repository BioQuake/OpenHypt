using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AbiaSyndicateNetwork : MonoBehaviour
{
    public Transform PriorityWaypoint;
    public Transform AbiaBaseHomePoint;
    public Transform AbiaBaseDock1E;
    public Transform AbiaBaseDock1P;
    public Transform AbiaBaseDock1A;
    public Transform BasePath0;
    public Transform BasePath1;
    public Transform BasePath2;
    public Transform BasePath3;
    public Transform BasePath4;
    public static Transform target;
    public GameObject Elite1;
    public GameObject Elite2;
    public static int TC0aCriminalLevel;
    public static int TC1CriminalLevel;
    public static int TC2CriminalLevel;
    public static int TC3CriminalLevel;
    public static int TC4CriminalLevel;
    public static int TC5CriminalLevel;
    public static int TC7CriminalLevel;
    public static int TC8CriminalLevel;
    public static int TC9CriminalLevel;
    public static bool Alert;
    public static bool Emergency;
    public static bool Confirmed;
    public static AbiaSyndicateNetwork instance;
    public virtual void Awake()
    {
        AbiaSyndicateNetwork.instance = this;
    }

    public virtual void Tick()
    {
        if (!AbiaSyndicateNetwork.Alert)
        {
            if (AbiaSyndicateNetwork.TC0aCriminalLevel > 0)
            {
                AbiaSyndicateNetwork.TC0aCriminalLevel = AbiaSyndicateNetwork.TC0aCriminalLevel - 1;
            }
            if (AbiaSyndicateNetwork.TC1CriminalLevel > 0)
            {
                AbiaSyndicateNetwork.TC1CriminalLevel = AbiaSyndicateNetwork.TC1CriminalLevel - 1;
            }
            if (AbiaSyndicateNetwork.TC2CriminalLevel > 0)
            {
                AbiaSyndicateNetwork.TC2CriminalLevel = AbiaSyndicateNetwork.TC2CriminalLevel - 1;
            }
            if (AbiaSyndicateNetwork.TC3CriminalLevel > 0)
            {
                AbiaSyndicateNetwork.TC3CriminalLevel = AbiaSyndicateNetwork.TC3CriminalLevel - 1;
            }
            if (AbiaSyndicateNetwork.TC4CriminalLevel > 0)
            {
                AbiaSyndicateNetwork.TC4CriminalLevel = AbiaSyndicateNetwork.TC4CriminalLevel - 1;
            }
            if (AbiaSyndicateNetwork.TC5CriminalLevel > 0)
            {
                AbiaSyndicateNetwork.TC5CriminalLevel = AbiaSyndicateNetwork.TC5CriminalLevel - 1;
            }
            if (AbiaSyndicateNetwork.TC7CriminalLevel > 0)
            {
                AbiaSyndicateNetwork.TC7CriminalLevel = AbiaSyndicateNetwork.TC7CriminalLevel - 1;
            }
            if (AbiaSyndicateNetwork.TC8CriminalLevel > 0)
            {
                AbiaSyndicateNetwork.TC8CriminalLevel = AbiaSyndicateNetwork.TC8CriminalLevel - 1;
            }
            if (AbiaSyndicateNetwork.TC9CriminalLevel > 0)
            {
                AbiaSyndicateNetwork.TC9CriminalLevel = AbiaSyndicateNetwork.TC9CriminalLevel - 1;
            }
        }
    }

    public virtual void Start()
    {
        this.InvokeRepeating("Tick", 1, 1);
    }

}