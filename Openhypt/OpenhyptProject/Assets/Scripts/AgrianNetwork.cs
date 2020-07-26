using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AgrianNetwork : MonoBehaviour
{
    public bool Deactivated;
    public Transform PriorityWaypoint;
    public Transform FullPriorityWaypoint;
    public Transform TurretsTarget;
    public Transform SubdueTarget;
    public static int TargetSubdual;
    public static bool DoomstarActive;
    public static bool DismissDoomstar;
    public static Transform theDoomstar;
    public static Transform doomstarTarget;
    public static bool DoomclawActive;
    public static Transform theDoomclaw;
    public static bool RedAlert;
    public static bool Alert;
    public static int TC1CriminalLevel;
    public static int TC3CriminalLevel;
    public static int TC4CriminalLevel;
    public static int TC5CriminalLevel;
    public static int TC6CriminalLevel;
    public static int TC7CriminalLevel;
    public static int TC8CriminalLevel;
    public static int TC9CriminalLevel;
    public int RedAlertTime;
    public int AlertTime;
    public int Curiosity;
    public static int Spawn;
    public static AgrianNetwork instance;
    public virtual void Awake()
    {
        AgrianNetwork.instance = this;
    }

    public virtual void Start()
    {
        this.InvokeRepeating("Tick", 1, 1);
        if (!this.FullPriorityWaypoint)
        {
            GameObject gO = new GameObject("FullPriorityWaypoint");
            gO.transform.position = this.transform.position;
            gO.transform.rotation = this.transform.rotation;
            this.FullPriorityWaypoint = gO.transform;
        }
        AgrianNetwork.Spawn = 0;
        AgrianNetwork.TargetSubdual = 0;
        this.SubdueTarget = null;
        AgrianNetwork.DismissDoomstar = false;
    }

    public virtual void Tick()
    {
        if (this.Deactivated)
        {
            return;
        }
        if (this.Curiosity > 1)
        {
            this.Curiosity = this.Curiosity - 1;
            if (this.Curiosity > 200)
            {
                this.AlertTime = 120;
                if (this.Curiosity > 1000)
                {
                    this.PriorityWaypoint.position = PlayerInformation.instance.PiriTarget.position;
                }
            }
        }
        if (this.RedAlertTime == 1)
        {
            this.RedAlertTime = 0;
            this.AlertTime = 300;
            AgrianNetwork.RedAlert = false;
        }
        if (this.RedAlertTime > 1)
        {
            this.RedAlertTime = this.RedAlertTime - 1;
            AgrianNetwork.RedAlert = true;
        }
        if (this.AlertTime == 1)
        {
            this.AlertTime = 0;
            AgrianNetwork.Alert = false;
        }
        if (this.AlertTime > 1)
        {
            this.AlertTime = this.AlertTime - 1;
            AgrianNetwork.Alert = true;
        }
        if (this.SubdueTarget)
        {
            //Debug.Log("Needs Subduing with " + TargetSubdual + " Target Subdual");
            if (AgrianNetwork.TargetSubdual > 6)
            {
                this.PriorityWaypoint.position = PlayerInformation.instance.PiriTarget.position;
                this.FullPriorityWaypoint.position = PlayerInformation.instance.PiriTarget.position;
                this.AlertTime = 120;
                this.RedAlertTime = 120;
            }
        }
        if (AgrianNetwork.Spawn > 0)
        {
            if (AgrianNetwork.TC1CriminalLevel < 200)
            {
                AgrianNetwork.TC1CriminalLevel = 270;
            }
            if (this.AlertTime < 150)
            {
                this.AlertTime = 150;
            }
            this.PriorityWaypoint.position = PlayerInformation.instance.PiriTarget.position;
            this.FullPriorityWaypoint.position = PlayerInformation.instance.PiriTarget.position;
            AgrianNetwork.Spawn = AgrianNetwork.Spawn - 1;
        }
        if (AgrianNetwork.TC1CriminalLevel > 0)
        {
            if (AgrianNetwork.TC1CriminalLevel > 500)
            {
                if (WorldInformation.PiriFree == true)
                {
                    this.PriorityWaypoint.position = PlayerInformation.instance.PiriTarget.position;
                    this.FullPriorityWaypoint.position = PlayerInformation.instance.PiriTarget.position;
                }
                if (WorldInformation.instance.AreaKabrian == true)
                {
                    if (WorldInformation.PiriTopFree == true)
                    {
                        this.PriorityWaypoint.position = PlayerInformation.instance.PiriTarget.position;
                        this.FullPriorityWaypoint.position = PlayerInformation.instance.PiriTarget.position;
                    }
                }
                if (WorldInformation.instance.AreaKabrian == true)
                {
                    if (WorldInformation.PiriBottomFree == true)
                    {
                        this.PriorityWaypoint.position = PlayerInformation.instance.PiriTarget.position;
                        this.FullPriorityWaypoint.position = PlayerInformation.instance.PiriTarget.position;
                    }
                }
            }
            else
            {
                AgrianNetwork.TC1CriminalLevel = AgrianNetwork.TC1CriminalLevel - 1;
            }
        }
        //Debug.Log(Curiosity);
        //Debug.Log(TC1CriminalLevel);
        if (AgrianNetwork.TC3CriminalLevel > 0)
        {
            AgrianNetwork.TC3CriminalLevel = AgrianNetwork.TC3CriminalLevel - 1;
            if (AgrianNetwork.TC3CriminalLevel > 300)
            {
                AgrianNetwork.TC3CriminalLevel = 300;
            }
        }
        if (AgrianNetwork.TC4CriminalLevel > 0)
        {
            AgrianNetwork.TC4CriminalLevel = AgrianNetwork.TC4CriminalLevel - 1;
        }
        if (AgrianNetwork.TC5CriminalLevel > 0)
        {
            AgrianNetwork.TC5CriminalLevel = AgrianNetwork.TC5CriminalLevel - 1;
        }
        if (AgrianNetwork.TC6CriminalLevel > 0)
        {
            AgrianNetwork.TC6CriminalLevel = AgrianNetwork.TC6CriminalLevel - 1;
        }
        if (AgrianNetwork.TC7CriminalLevel > 0)
        {
            AgrianNetwork.TC7CriminalLevel = AgrianNetwork.TC7CriminalLevel - 1;
        }
        if (AgrianNetwork.TC8CriminalLevel > 0)
        {
            AgrianNetwork.TC8CriminalLevel = AgrianNetwork.TC8CriminalLevel - 1;
        }
        if (AgrianNetwork.TC9CriminalLevel > 0)
        {
            AgrianNetwork.TC9CriminalLevel = AgrianNetwork.TC9CriminalLevel - 1;
        }
    }

}