using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class LevNavCruiser : MonoBehaviour
{
    public Transform target;
    public Transform Waypoint;
    public Transform TargetTrace;
    public Transform TargetLead;
    public SphereCollider TLCol;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public Transform ResetAimpoint;
    public Transform AIAnchor;
    public AnimationCurve orbitCurve;
    public bool HasRequested;
    public bool SLPlusFiring;
    public int SMCooldown;
    public int CMCooldown;
    public GameObject MissileAmmo;
    public GameObject Missile2Ammo;
    public GameObject Missile3Ammo;
    public Transform Missile1;
    public Transform Missile2;
    public Transform Missile3;
    public Transform Missile4;
    public Transform Missile5;
    public Transform Missile6;
    public Transform Missile7;
    public Transform Missile8;
    public Transform Missile9;
    public Transform Missile10;
    public Transform Missile11;
    public Transform Missile12;
    public Transform Missile13;
    public Transform Missile14;
    public Transform Missile15;
    public Transform Missile16;
    public Transform Missile17;
    public Transform Missile18;
    public GameObject Missile1GO;
    public GameObject Missile2GO;
    public GameObject Missile3GO;
    public GameObject Missile4GO;
    public GameObject Missile5GO;
    public GameObject Missile6GO;
    public GameObject Missile7GO;
    public GameObject Missile8GO;
    public GameObject Missile9GO;
    public GameObject Missile10GO;
    public GameObject Missile11GO;
    public GameObject Missile12GO;
    public GameObject Missile13GO;
    public GameObject Missile14GO;
    public GameObject Missile15GO;
    public GameObject Missile16GO;
    public GameObject Missile17GO;
    public GameObject Missile18GO;
    public Transform topPoint;
    public Transform frontPoint;
    public GameObject Turret1;
    public GameObject Turret2;
    public NPCGun Gun1;
    public NPCGun Gun2;
    public SphereCollider Trig;
    public GameObject Presence;
    public GameObject SpotSound;
    public GameObject AttackSound;
    public GameObject RejectSound;
    public float Dist;
    public int PissedAtTC0a;
    public int PissedAtTC1;
    public int PissedAtTC4;
    public int PissedAtTC5;
    public int PissedAtTC6;
    public int PissedAtTC7;
    public int PissedAtTC8;
    public int PissedAtTC9;
    public bool SkipTiny;
    public bool FoundSmall;
    public bool FoundMedium;
    public bool FoundBig;
    public bool FoundExtraBig;
    public bool FS;
    public bool FM;
    public bool FB;
    public bool Attacking;
    public bool Obstacle;
    public bool Stuck;
    public bool Emergency;
    public float DirStrength;
    public float TAimStrength;
    public float TurnStrength;
    public int TForce;
    public int TurnForce;
    public bool TurnRight;
    public bool TurnLeft;
    public float RightDist;
    public float LeftDist;
    public float AngleTH;
    public int forwardPoint;
    public float sidePoint;
    public float sidePointStat;
    public Vector3 RelativeTarget;
    public int RPAbs;
    public int RPClamp;
    public int RPMod;
    public float RUP;
    public float RRUP;
    public float LRUP;
    public bool Wall;
    public bool RWall;
    public bool LWall;
    public Vector3 Point1u;
    public Vector3 Point1d;
    public Vector3 RPoint1u;
    public Vector3 RPoint1d;
    public Vector3 LPoint1u;
    public Vector3 LPoint1d;
    public Vector3 localV;
    public LayerMask targetLayers;
    public LayerMask MtargetLayers;
    public int DangerSense;
    public bool DangerTick;
    public int StoredMissileBatches;
    public int StoredMissile2Batches;
    public int StoredMissile3Batches;
    public virtual void Start()
    {
        this.InvokeRepeating("Regenerator", 1, 1);
        this.InvokeRepeating("LeaveMarker", 1, 10);
        this.InvokeRepeating("Targety", 15, 15);
        this.InvokeRepeating("Shooty", Random.Range(2, 3), 0.3f);
        this.InvokeRepeating("CalcLead", 1, 0.15f);
        this.sidePointStat = this.sidePoint;
    }

    public virtual void FixedUpdate()
    {
        Vector3 newRot2 = default(Vector3);
        RaycastHit hit = default(RaycastHit);
        RaycastHit hit1 = default(RaycastHit);
        RaycastHit hit2 = default(RaycastHit);
        if (!this.DangerTick)
        {
            this.thisTransform.rotation = this.AIAnchor.transform.rotation;
        }
        this.thisTransform.position = this.AIAnchor.transform.position;
        if (this.target)
        {
            this.RelativeTarget = this.thisTransform.InverseTransformPoint(this.target.position);
            float RPModX = this.RelativeTarget.x * 10;
            this.RPAbs = (int) Mathf.Abs(RPModX);
            this.Dist = Vector3.Distance(this.thisTransform.position, this.target.position);
        }
        if (this.Attacking)
        {
            if (this.target == this.ResetAimpoint)
            {
                this.target = this.ResetAimpoint;
                this.Attacking = false;
                this.FoundSmall = false;
            }
            if (this.target == null)
            {
                this.target = this.ResetAimpoint;
                this.Attacking = false;
                this.FoundSmall = false;
            }
            else
            {
                if (this.target.name.Contains("broken"))
                {
                    this.target = this.ResetAimpoint;
                    this.Attacking = false;
                }
            }
        }
        if (this.TurnLeft)
        {
            this.TurnForce = -1500000;
        }
        if (this.TurnRight)
        {
            this.TurnForce = 1500000;
        }
        if ((this.TurnRight && this.TurnLeft) && this.Obstacle)
        {
            this.TurnForce = -1500000;
        }
        if (this.target)
        {
            if (!this.TurnRight && !this.TurnLeft)
            {
                if (this.Dist < 850)
                {
                    this.RPMod = (int) this.RelativeTarget.z;
                    this.TForce = (int) this.orbitCurve.Evaluate(this.RPMod);
                    this.TForce = (int) ((this.TForce * 4) * this.Dist);
                    this.TurnForce = Mathf.Clamp(this.TForce, -800000, 800000);
                }
                else
                {
                    this.TForce = (int) (this.RelativeTarget.x * 1024);
                    this.TurnForce = Mathf.Clamp(this.TForce, -800000, 800000);
                }
            }
        }
        this.localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
        if (-this.localV.y > 10)
        {
            newRot2 = this.vRigidbody.velocity;
        }
        else
        {
            newRot2 = this.thisTransform.forward;
        }
        float VelClamp = Mathf.Clamp(this.vRigidbody.velocity.magnitude * 8, 192, 512);
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint)) + (-this.thisTransform.up * 2)) + (this.thisTransform.up * this.RUP), newRot2 * VelClamp, Color.white);
        if (Physics.Raycast(((this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint)) + (-this.thisTransform.up * 2)) + (this.thisTransform.up * this.RUP), newRot2, out hit1, VelClamp, (int) this.targetLayers))
        {
            this.Point1u = hit1.point;
        }
        else
        {
            this.Point1u = new Vector3(2, 2, 2);
        }
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint)) + (-this.thisTransform.up * 3)) + (this.thisTransform.up * this.RUP), newRot2 * VelClamp, Color.white);
        if (Physics.Raycast(((this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint)) + (-this.thisTransform.up * 3)) + (this.thisTransform.up * this.RUP), newRot2, out hit2, VelClamp, (int) this.targetLayers))
        {
            this.Point1d = hit2.point;
        }
        else
        {
            this.Point1d = new Vector3(8, 8, 8);
        }
        if (Vector3.Distance(this.Point1u, this.Point1d) < this.AngleTH)
        {
            this.Wall = true;
        }
        this.Obstacle = false;
        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint), newRot2 * VelClamp, Color.green);
        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint), newRot2, out hit, VelClamp, (int) this.targetLayers))
        {
            if (this.Wall)
            {
                this.Obstacle = true;
            }
        }
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint)) + (this.thisTransform.right * 4), newRot2 * VelClamp, Color.green);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint)) + (this.thisTransform.right * 4), newRot2, out hit, VelClamp, (int) this.targetLayers))
        {
            if (this.Wall)
            {
                this.Obstacle = true;
            }
        }
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint)) + (-this.thisTransform.right * 4), newRot2 * VelClamp, Color.green);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint)) + (-this.thisTransform.right * 4), newRot2, out hit, VelClamp, (int) this.targetLayers))
        {
            if (this.Wall)
            {
                this.Obstacle = true;
            }
        }
        Debug.DrawRay((((this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint)) + (this.thisTransform.right * this.sidePoint)) + (-this.thisTransform.up * 2)) + (this.thisTransform.up * this.RRUP), this.thisTransform.forward * VelClamp, Color.black);
        if (Physics.Raycast((((this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint)) + (this.thisTransform.right * this.sidePoint)) + (-this.thisTransform.up * 2)) + (this.thisTransform.up * this.RRUP), this.thisTransform.forward, out hit1, VelClamp, (int) this.targetLayers))
        {
            this.RPoint1u = hit1.point;
        }
        else
        {
            this.RPoint1u = new Vector3(2, 2, 2);
        }
        Debug.DrawRay((((this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint)) + (this.thisTransform.right * this.sidePoint)) + (-this.thisTransform.up * 3)) + (this.thisTransform.up * this.RRUP), this.thisTransform.forward * VelClamp, Color.black);
        if (Physics.Raycast((((this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint)) + (this.thisTransform.right * this.sidePoint)) + (-this.thisTransform.up * 3)) + (this.thisTransform.up * this.RRUP), this.thisTransform.forward, out hit2, VelClamp, (int) this.targetLayers))
        {
            this.RPoint1d = hit2.point;
            this.RightDist = hit2.distance;
        }
        else
        {
            this.RPoint1d = new Vector3(8, 8, 8);
            this.RightDist = 512;
        }
        if (Vector3.Distance(this.RPoint1u, this.RPoint1d) < this.AngleTH)
        {
            this.RWall = true;
        }
        Debug.DrawRay((((this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint)) + (-this.thisTransform.right * this.sidePoint)) + (-this.thisTransform.up * 2)) + (this.thisTransform.up * this.LRUP), this.thisTransform.forward * VelClamp, Color.black);
        if (Physics.Raycast((((this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint)) + (-this.thisTransform.right * this.sidePoint)) + (-this.thisTransform.up * 2)) + (this.thisTransform.up * this.LRUP), this.thisTransform.forward, out hit1, VelClamp, (int) this.targetLayers))
        {
            this.LPoint1u = hit1.point;
        }
        else
        {
            this.LPoint1u = new Vector3(2, 2, 2);
        }
        Debug.DrawRay((((this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint)) + (-this.thisTransform.right * this.sidePoint)) + (-this.thisTransform.up * 3)) + (this.thisTransform.up * this.LRUP), this.thisTransform.forward * VelClamp, Color.black);
        if (Physics.Raycast((((this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint)) + (-this.thisTransform.right * this.sidePoint)) + (-this.thisTransform.up * 3)) + (this.thisTransform.up * this.LRUP), this.thisTransform.forward, out hit2, VelClamp, (int) this.targetLayers))
        {
            this.LPoint1d = hit2.point;
            this.LeftDist = hit2.distance;
        }
        else
        {
            this.LPoint1d = new Vector3(8, 8, 8);
            this.LeftDist = 512;
        }
        if (Vector3.Distance(this.LPoint1u, this.LPoint1d) < this.AngleTH)
        {
            this.LWall = true;
        }
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint)) + (this.thisTransform.up * 10)) + (this.thisTransform.forward * VelClamp), this.thisTransform.up * -64, Color.white);
        if (!Physics.Raycast(((this.thisTransform.position + (this.thisTransform.forward * this.forwardPoint)) + (this.thisTransform.up * 10)) + (this.thisTransform.forward * VelClamp), -this.thisTransform.up, 64))
        {
            this.Obstacle = true;
        }
        //---------------------------------------------------------------------------------------------
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.up * 10)) + (this.thisTransform.right * 20)) + (this.thisTransform.forward * VelClamp), this.thisTransform.up * -64, Color.white);
        if (!Physics.Raycast(((this.thisTransform.position + (this.thisTransform.up * 10)) + (this.thisTransform.right * 20)) + (this.thisTransform.forward * VelClamp), -this.thisTransform.up, 64))
        {
            this.TurnLeft = true;
        }
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.up * 10)) + (-this.thisTransform.right * 20)) + (this.thisTransform.forward * VelClamp), this.thisTransform.up * -64, Color.white);
        if (!Physics.Raycast(((this.thisTransform.position + (this.thisTransform.up * 10)) + (-this.thisTransform.right * 20)) + (this.thisTransform.forward * VelClamp), -this.thisTransform.up, 64))
        {
            this.TurnRight = true;
        }
        //---------------------------------------------------------------------------------------------
        if ((this.RightDist > this.LeftDist) && this.LWall)
        {
            this.TurnRight = true;
        }
        if ((this.LeftDist > this.RightDist) && this.RWall)
        {
            this.TurnLeft = true;
        }
        if ((this.LeftDist < 20) && this.LWall)
        {
            this.Obstacle = true;
        }
        if ((this.RightDist < 20) && this.RWall)
        {
            this.Obstacle = true;
        }
        if (this.Stuck)
        {
            this.TurnRight = true;
            this.TurnLeft = false;
        }
        Vector3 localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
        if (this.RUP < 8)
        {
            this.RUP = this.RUP + 1;
        }
        else
        {
            this.RUP = 0;
        }
        if (this.RRUP < 4)
        {
            this.RRUP = this.RRUP + 0.5f;
        }
        else
        {
            this.RRUP = 0;
        }
        if (this.LRUP < 4)
        {
            this.LRUP = this.LRUP + 0.5f;
        }
        else
        {
            this.LRUP = 0;
        }
        if (this.sidePoint < this.sidePointStat)
        {
            this.sidePoint = this.sidePoint + 1;
        }
        else
        {
            this.sidePoint = 8;
        }
        if (this.Obstacle)
        {
            if (-localV.y > 0)
            {
                this.vRigidbody.AddForce((-this.thisVTransform.up * -24000) * this.DirStrength);
            }
        }
        if (this.Stuck)
        {
            if (-localV.y < 4)
            {
                this.vRigidbody.AddForce((this.thisVTransform.up * 12000) * this.DirStrength);
            }
        }
        if ((this.Attacking && !this.Obstacle) && !this.Stuck)
        {
            if (-localV.y < 70)
            {
                this.vRigidbody.AddForce((-this.thisVTransform.up * 24000) * this.DirStrength);
            }
        }
        if ((((!this.Attacking && !this.Obstacle) && !this.Stuck) && !this.TurnLeft) && !this.TurnRight)
        {
            if (-localV.y < 70)
            {
                this.vRigidbody.AddForce((-this.thisVTransform.up * 24000) * this.DirStrength);
            }
        }
        this.vRigidbody.AddTorque((this.thisVTransform.forward * this.TurnForce) * this.TurnStrength);
        if (this.target)
        {
            if (this.Turret1)
            {
                this.Turret1.GetComponent<Rigidbody>().AddForceAtPosition((this.TargetLead.transform.position - this.Turret1.transform.position).normalized * 10, -this.Turret1.transform.up * this.TAimStrength);
                this.Turret1.GetComponent<Rigidbody>().AddForceAtPosition((this.TargetLead.transform.position - this.Turret1.transform.position).normalized * -10, this.Turret1.transform.up * this.TAimStrength);
            }
            if (this.Turret2)
            {
                this.Turret2.GetComponent<Rigidbody>().AddForceAtPosition((this.TargetLead.transform.position - this.Turret2.transform.position).normalized * 10, -this.Turret2.transform.up * this.TAimStrength);
                this.Turret2.GetComponent<Rigidbody>().AddForceAtPosition((this.TargetLead.transform.position - this.Turret2.transform.position).normalized * -10, this.Turret2.transform.up * this.TAimStrength);
            }
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        string ON = other.name;
        Transform OT = other.transform;
        if (ON.Contains("TFC"))
        {
            if (!ON.Contains("TFC3"))
            {
                if (TerrahyptianNetwork.instance.EnemyTarget1)
                {
                    if (ON.Contains("TFC0a"))
                    {
                        if (TerrahyptianNetwork.instance.EnemyTarget1.name.Contains("TFC0"))
                        {
                            this.PissedAtTC0a = 2;
                        }
                    }
                    if (ON.Contains("TFC1"))
                    {
                        if (TerrahyptianNetwork.instance.EnemyTarget1.name.Contains("TFC1"))
                        {
                            this.PissedAtTC1 = 2;
                        }
                    }
                    if (ON.Contains("TFC4"))
                    {
                        if (TerrahyptianNetwork.instance.EnemyTarget1.name.Contains("TFC4"))
                        {
                            this.PissedAtTC4 = 2;
                        }
                    }
                    if (ON.Contains("TFC5"))
                    {
                        if (TerrahyptianNetwork.instance.EnemyTarget1.name.Contains("TFC5"))
                        {
                            this.PissedAtTC5 = 2;
                        }
                    }
                    if (ON.Contains("TFC6"))
                    {
                        if (TerrahyptianNetwork.instance.EnemyTarget1.name.Contains("TFC6"))
                        {
                            this.PissedAtTC6 = 2;
                        }
                    }
                    if (ON.Contains("TFC7"))
                    {
                        if (TerrahyptianNetwork.instance.EnemyTarget1.name.Contains("TFC7"))
                        {
                            this.PissedAtTC7 = 2;
                        }
                    }
                    if (ON.Contains("TFC8"))
                    {
                        if (TerrahyptianNetwork.instance.EnemyTarget1.name.Contains("TFC7"))
                        {
                            this.PissedAtTC8 = 2;
                        }
                    }
                    if (ON.Contains("TFC9"))
                    {
                        if (TerrahyptianNetwork.instance.EnemyTarget1.name.Contains("TFC7"))
                        {
                            this.PissedAtTC9 = 2;
                        }
                    }
                }
                else
                {
                    if (ON.Contains("TFC0a"))
                    {
                        this.PissedAtTC0a = 2;
                    }
                    if (ON.Contains("TFC1"))
                    {
                        this.PissedAtTC1 = 2;
                    }
                    if (ON.Contains("TFC4"))
                    {
                        this.PissedAtTC4 = 2;
                    }
                    if (ON.Contains("TFC5"))
                    {
                        this.PissedAtTC5 = 2;
                    }
                    if (ON.Contains("TFC6"))
                    {
                        this.PissedAtTC6 = 2;
                    }
                    if (ON.Contains("TFC7"))
                    {
                        this.PissedAtTC7 = 2;
                    }
                    if (ON.Contains("TFC8"))
                    {
                        this.PissedAtTC8 = 2;
                    }
                    if (ON.Contains("TFC9"))
                    {
                        this.PissedAtTC9 = 2;
                    }
                }
                if (!this.Attacking)
                {
                    this.DangerSense = 10;
                    this.target = this.Waypoint;
                    if (other.GetComponent<Rigidbody>())
                    {
                        this.Waypoint.position = OT.position;
                    }
                }
            }
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        string ON = other.name;
        Transform OT = other.transform;
        if (ON.Contains("TC"))
        {
            if (!ON.Contains("TC3"))
            {
                if (this.SkipTiny)
                {
                    if (ON.Contains("tT"))
                    {
                        return;
                    }
                }
                if (ON.Contains("xb"))
                {
                    if (ON.Contains("C1"))
                    {
                        TerrahyptianNetwork.AnExtraBigTC1 = OT;
                    }
                    if (ON.Contains("C4"))
                    {
                        TerrahyptianNetwork.AnExtraBigTC4 = OT;
                    }
                    if (ON.Contains("C5"))
                    {
                        TerrahyptianNetwork.AnExtraBigTC5 = OT;
                    }
                    if (ON.Contains("C6"))
                    {
                        TerrahyptianNetwork.AnExtraBigTC6 = OT;
                    }
                    if (ON.Contains("C7"))
                    {
                        TerrahyptianNetwork.AnExtraBigTC7 = OT;
                    }
                    if (ON.Contains("C8"))
                    {
                        TerrahyptianNetwork.AnExtraBigTC8 = OT;
                    }
                    if (ON.Contains("C9"))
                    {
                        TerrahyptianNetwork.AnExtraBigTC9 = OT;
                    }
                }
                if (ON.Contains("sT"))
                {
                    this.FS = true;
                }
                if (ON.Contains("mT"))
                {
                    this.FM = true;
                }
                if (ON.Contains("bT"))
                {
                    this.FB = true;
                }
                if (this.FoundBig)
                {
                    return;
                }
                if (this.PissedAtTC0a > 1)
                {
                    if (ON.Contains("TC0a"))
                    {
                        if (((this.FS && !this.FoundSmall) || (this.FM && !this.FoundMedium)) || this.FB)
                        {
                            this.target = OT;
                            if (!this.Attacking)
                            {
                                this.AttackNoise();
                            }
                            this.Attacking = true;
                            if (this.FS)
                            {
                                this.FoundSmall = true;
                            }
                            if (this.FM)
                            {
                                this.FoundMedium = true;
                            }
                            if (this.FB)
                            {
                                this.FoundBig = true;
                            }
                        }
                    }
                }
                if (this.PissedAtTC1 > 1)
                {
                    if (ON.Contains("TC1"))
                    {
                        if (((this.FS && !this.FoundSmall) || (this.FM && !this.FoundMedium)) || this.FB)
                        {
                            this.target = OT;
                            if (!this.Attacking)
                            {
                                this.AttackNoise();
                            }
                            this.Attacking = true;
                            if (this.FS)
                            {
                                this.FoundSmall = true;
                            }
                            if (this.FM)
                            {
                                this.FoundMedium = true;
                            }
                            if (this.FB)
                            {
                                this.FoundBig = true;
                            }
                        }
                    }
                }
                if (this.PissedAtTC4 > 1)
                {
                    if (ON.Contains("TC4"))
                    {
                        if (((this.FS && !this.FoundSmall) || (this.FM && !this.FoundMedium)) || this.FB)
                        {
                            this.target = OT;
                            if (!this.Attacking)
                            {
                                this.AttackNoise();
                            }
                            this.Attacking = true;
                            if (this.FS)
                            {
                                this.FoundSmall = true;
                            }
                            if (this.FM)
                            {
                                this.FoundMedium = true;
                            }
                            if (this.FB)
                            {
                                this.FoundBig = true;
                            }
                        }
                    }
                }
                if (this.PissedAtTC5 > 1)
                {
                    if (ON.Contains("TC5"))
                    {
                        if (((this.FS && !this.FoundSmall) || (this.FM && !this.FoundMedium)) || this.FB)
                        {
                            this.target = OT;
                            if (!this.Attacking)
                            {
                                this.AttackNoise();
                            }
                            this.Attacking = true;
                            if (this.FS)
                            {
                                this.FoundSmall = true;
                            }
                            if (this.FM)
                            {
                                this.FoundMedium = true;
                            }
                            if (this.FB)
                            {
                                this.FoundBig = true;
                            }
                        }
                    }
                }
                if (this.PissedAtTC6 > 1)
                {
                    if (ON.Contains("TC6"))
                    {
                        if (((this.FS && !this.FoundSmall) || (this.FM && !this.FoundMedium)) || this.FB)
                        {
                            this.target = OT;
                            if (!this.Attacking)
                            {
                                this.AttackNoise();
                            }
                            this.Attacking = true;
                            if (this.FS)
                            {
                                this.FoundSmall = true;
                            }
                            if (this.FM)
                            {
                                this.FoundMedium = true;
                            }
                            if (this.FB)
                            {
                                this.FoundBig = true;
                            }
                        }
                    }
                }
                if (this.PissedAtTC7 > 1)
                {
                    if (ON.Contains("TC7"))
                    {
                        if (((this.FS && !this.FoundSmall) || (this.FM && !this.FoundMedium)) || this.FB)
                        {
                            this.target = OT;
                            if (!this.Attacking)
                            {
                                this.AttackNoise();
                            }
                            this.Attacking = true;
                            if (this.FS)
                            {
                                this.FoundSmall = true;
                            }
                            if (this.FM)
                            {
                                this.FoundMedium = true;
                            }
                            if (this.FB)
                            {
                                this.FoundBig = true;
                            }
                        }
                    }
                }
                if (this.PissedAtTC8 > 1)
                {
                    if (ON.Contains("TC8"))
                    {
                        if (((this.FS && !this.FoundSmall) || (this.FM && !this.FoundMedium)) || this.FB)
                        {
                            this.target = OT;
                            if (!this.Attacking)
                            {
                                this.AttackNoise();
                            }
                            this.Attacking = true;
                            if (this.FS)
                            {
                                this.FoundSmall = true;
                            }
                            if (this.FM)
                            {
                                this.FoundMedium = true;
                            }
                            if (this.FB)
                            {
                                this.FoundBig = true;
                            }
                        }
                    }
                }
                if (this.PissedAtTC9 > 1)
                {
                    if (ON.Contains("TC9"))
                    {
                        if (((this.FS && !this.FoundSmall) || (this.FM && !this.FoundMedium)) || this.FB)
                        {
                            this.target = OT;
                            if (!this.Attacking)
                            {
                                this.AttackNoise();
                            }
                            this.Attacking = true;
                            if (this.FS)
                            {
                                this.FoundSmall = true;
                            }
                            if (this.FM)
                            {
                                this.FoundMedium = true;
                            }
                            if (this.FB)
                            {
                                this.FoundBig = true;
                            }
                        }
                    }
                }
                this.FS = false;
                this.FM = false;
                this.FB = false;
            }
        }
    }

    public virtual void AttackNoise()
    {
        GameObject TheThing = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
        TheThing.transform.parent = this.thisTransform;
    }

    public virtual IEnumerator Looking()
    {
        yield return new WaitForSeconds(15);
        if (!this.Attacking)
        {
            GameObject TheThing = UnityEngine.Object.Instantiate(this.RejectSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
            TheThing.transform.parent = this.thisTransform;
            this.Targety();
        }
    }

    public virtual void Shooty()
    {
        if (this.Attacking)
        {
            this.StartCoroutine(this.Shoot());
            if (this.SMCooldown < 1)
            {
                this.StartCoroutine(this.LaunchSM());
            }
            if (this.FoundBig)
            {
                if (this.CMCooldown < 1)
                {
                    this.StartCoroutine(this.LaunchCM());
                }
            }
        }
    }

    public virtual IEnumerator Shoot()
    {
        if (this.Attacking)
        {
            if (this.Turret1)
            {
                this.Gun1.Fire();
            }
            yield return new WaitForSeconds(0.4f);
            if (this.Turret2)
            {
                this.Gun2.Fire();
            }
        }
    }

    public virtual IEnumerator LaunchSM()
    {
        RaycastHit hitM = default(RaycastHit);
        if (!this.MissileAmmo)
        {
            yield break;
        }
        if (this.target)
        {
            if (Physics.Linecast(this.topPoint.position, this.target.position, (int) this.MtargetLayers))
            {
                yield break;
            }
            else
            {
                this.topPoint.LookAt(this.target);
                Debug.DrawRay(this.topPoint.position, this.topPoint.forward * 5000, Color.yellow);
                if (Physics.Raycast(this.topPoint.position, this.topPoint.forward, out hitM, 5000, (int) this.targetLayers))
                {
                    if (hitM.collider.name.Contains("C3"))
                    {
                        yield break;
                    }
                }
            }
        }
        if (this.target)
        {
            if (((this.Attacking && (this.StoredMissileBatches > 0)) && (this.Dist > 256)) && (this.Dist < 1000))
            {
                this.SMCooldown = 3;
                if (this.Missile3GO)
                {
                    if (!this.Missile3GO.name.Contains("rok"))
                    {
                        yield break;
                    }
                }
                if (this.Missile4GO)
                {
                    if (!this.Missile4GO.name.Contains("rok"))
                    {
                        yield break;
                    }
                }
                if (this.Missile7GO)
                {
                    if (!this.Missile7GO.name.Contains("rok"))
                    {
                        yield break;
                    }
                }
                if (this.Missile8GO)
                {
                    if (!this.Missile8GO.name.Contains("rok"))
                    {
                        yield break;
                    }
                }
                this.StoredMissileBatches = this.StoredMissileBatches - 1;
                this.Missile1GO = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile1.position, this.Missile1.rotation);
                this.Missile1GO.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                ((MissileScript) this.Missile1GO.transform.GetComponent(typeof(MissileScript))).target = this.target;
                yield return new WaitForSeconds(0.3f);
                this.Missile2GO = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile2.position, this.Missile2.rotation);
                this.Missile2GO.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                ((MissileScript) this.Missile2GO.transform.GetComponent(typeof(MissileScript))).target = this.target;
                yield return new WaitForSeconds(0.3f);
                this.Missile3GO = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile3.position, this.Missile3.rotation);
                this.Missile3GO.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                ((MissileScript) this.Missile3GO.transform.GetComponent(typeof(MissileScript))).target = this.target;
                yield return new WaitForSeconds(0.3f);
                this.Missile4GO = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile4.position, this.Missile4.rotation);
                this.Missile4GO.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                ((MissileScript) this.Missile4GO.transform.GetComponent(typeof(MissileScript))).target = this.target;
                yield return new WaitForSeconds(0.3f);
                this.Missile5GO = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile5.position, this.Missile5.rotation);
                this.Missile5GO.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                ((MissileScript) this.Missile5GO.transform.GetComponent(typeof(MissileScript))).target = this.target;
                yield return new WaitForSeconds(0.3f);
                this.Missile6GO = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile6.position, this.Missile6.rotation);
                this.Missile6GO.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                ((MissileScript) this.Missile6GO.transform.GetComponent(typeof(MissileScript))).target = this.target;
                yield return new WaitForSeconds(0.3f);
                this.Missile7GO = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile7.position, this.Missile7.rotation);
                this.Missile7GO.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                ((MissileScript) this.Missile7GO.transform.GetComponent(typeof(MissileScript))).target = this.target;
                yield return new WaitForSeconds(0.3f);
                this.Missile8GO = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile8.position, this.Missile8.rotation);
                this.Missile8GO.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                ((MissileScript) this.Missile8GO.transform.GetComponent(typeof(MissileScript))).target = this.target;
            }
        }
        if (!this.Missile2Ammo)
        {
            yield break;
        }
        if (this.target)
        {
            if ((this.Attacking && (this.StoredMissile2Batches > 0)) && (this.Dist < 512))
            {
                this.SMCooldown = 3;
                if (this.Missile9GO)
                {
                    if (!this.Missile9GO.name.Contains("rok"))
                    {
                        yield break;
                    }
                }
                if (this.Missile10GO)
                {
                    if (!this.Missile10GO.name.Contains("rok"))
                    {
                        yield break;
                    }
                }
                this.StoredMissile2Batches = this.StoredMissile2Batches - 1;
                if (!this.SLPlusFiring)
                {
                    this.Missile9GO = UnityEngine.Object.Instantiate(this.Missile2Ammo, this.Missile9.position, this.Missile9.rotation);
                    this.Missile9GO.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                    ((MissileScript) this.Missile9GO.transform.GetComponent(typeof(MissileScript))).target = this.target;
                    yield return new WaitForSeconds(0.3f);
                    this.Missile10GO = UnityEngine.Object.Instantiate(this.Missile2Ammo, this.Missile10.position, this.Missile10.rotation);
                    this.Missile10GO.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                    ((MissileScript) this.Missile10GO.transform.GetComponent(typeof(MissileScript))).target = this.target;
                    this.SLPlusFiring = true;
                }
                else
                {
                    yield return new WaitForSeconds(0.3f);
                    this.Missile11GO = UnityEngine.Object.Instantiate(this.Missile2Ammo, this.Missile11.position, this.Missile11.rotation);
                    this.Missile11GO.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                    ((MissileScript) this.Missile11GO.transform.GetComponent(typeof(MissileScript))).target = this.target;
                    yield return new WaitForSeconds(0.3f);
                    this.Missile12GO = UnityEngine.Object.Instantiate(this.Missile2Ammo, this.Missile12.position, this.Missile12.rotation);
                    this.Missile12GO.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                    ((MissileScript) this.Missile12GO.transform.GetComponent(typeof(MissileScript))).target = this.target;
                    this.SLPlusFiring = false;
                }
            }
        }
    }

    public virtual IEnumerator LaunchCM()
    {
        RaycastHit hitM = default(RaycastHit);
        if (!this.Missile3Ammo)
        {
            yield break;
        }
        if (this.target)
        {
            if (Physics.Linecast(this.topPoint.position, this.target.position, (int) this.MtargetLayers))
            {
                yield break;
            }
            else
            {
                this.topPoint.LookAt(this.target);
                Debug.DrawRay(this.topPoint.position, this.topPoint.forward * 5000, Color.yellow);
                if (Physics.Raycast(this.topPoint.position, this.topPoint.forward, out hitM, 5000, (int) this.targetLayers))
                {
                    if (hitM.collider.name.Contains("C3"))
                    {
                        yield break;
                    }
                }
            }
        }
        if (this.target != null)
        {
            if ((((this.Attacking && this.FoundBig) && this.FoundExtraBig) && (this.StoredMissile3Batches > 0)) && (this.Dist < 3000))
            {
                this.CMCooldown = 4;
                if (this.Missile13GO)
                {
                    if (!this.Missile13GO.name.Contains("rok"))
                    {
                        yield break;
                    }
                }
                if (this.Missile14GO)
                {
                    if (!this.Missile14GO.name.Contains("rok"))
                    {
                        yield break;
                    }
                }
                if (this.Missile15GO)
                {
                    if (!this.Missile15GO.name.Contains("rok"))
                    {
                        yield break;
                    }
                }
                if (this.Missile16GO)
                {
                    if (!this.Missile16GO.name.Contains("rok"))
                    {
                        yield break;
                    }
                }
                this.StoredMissile3Batches = this.StoredMissile3Batches - 1;
                this.Missile13GO = UnityEngine.Object.Instantiate(this.Missile3Ammo, this.Missile13.position, this.Missile13.rotation);
                this.Missile13GO.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                ((MissileScript) this.Missile13GO.transform.GetComponent(typeof(MissileScript))).target = this.target;
                yield return new WaitForSeconds(0.4f);
                this.Missile14GO = UnityEngine.Object.Instantiate(this.Missile3Ammo, this.Missile14.position, this.Missile14.rotation);
                this.Missile14GO.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                ((MissileScript) this.Missile14GO.transform.GetComponent(typeof(MissileScript))).target = this.target;
                yield return new WaitForSeconds(0.4f);
                this.Missile15GO = UnityEngine.Object.Instantiate(this.Missile3Ammo, this.Missile15.position, this.Missile15.rotation);
                this.Missile15GO.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                ((MissileScript) this.Missile15GO.transform.GetComponent(typeof(MissileScript))).target = this.target;
                yield return new WaitForSeconds(0.4f);
                this.Missile16GO = UnityEngine.Object.Instantiate(this.Missile3Ammo, this.Missile16.position, this.Missile16.rotation);
                this.Missile16GO.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                ((MissileScript) this.Missile16GO.transform.GetComponent(typeof(MissileScript))).target = this.target;
                yield return new WaitForSeconds(0.4f);
                GameObject Missile170GO = UnityEngine.Object.Instantiate(this.Missile3Ammo, this.Missile17.position, this.Missile17.rotation);
                Missile170GO.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                ((MissileScript) Missile170GO.transform.GetComponent(typeof(MissileScript))).target = this.target;
                yield return new WaitForSeconds(0.4f);
                GameObject Missile180GO = UnityEngine.Object.Instantiate(this.Missile3Ammo, this.Missile18.position, this.Missile18.rotation);
                Missile180GO.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                ((MissileScript) Missile180GO.transform.GetComponent(typeof(MissileScript))).target = this.target;
            }
        }
    }

    public virtual void Targety()
    {
        if (!this.Attacking)
        {
            this.StartCoroutine(this.TargetArea());
        }
    }

    public virtual IEnumerator TargetArea()
    {
        if ((TerrahyptianNetwork.AlertTime > 0) && !this.Attacking)
        {
            this.Waypoint.transform.position = TerrahyptianNetwork.instance.PriorityWaypoint.position;
            this.target = this.Waypoint;
        }
        yield return new WaitForSeconds(10);
        if (!this.Attacking)
        {
            this.target = this.ResetAimpoint;
        }
    }

    public virtual void LeaveMarker()
    {
        Vector3 lastPos = this.thisTransform.position;
        this.StartCoroutine(this.IsEscaping(lastPos));
    }

    public virtual IEnumerator IsEscaping(Vector3 lastPos)
    {
        this.Stuck = false;
        yield return new WaitForSeconds(2);
        if (Vector3.Distance(this.thisTransform.position, lastPos) < 3)
        {
            this.Stuck = true;
            yield return new WaitForSeconds(3);
            this.Stuck = false;
        }
    }

    public virtual void CalcLead()
    {
        this.StartCoroutine(this.Lead());
    }

    public virtual IEnumerator Lead()
    {
        if (this.target)
        {
            this.TargetTrace.position = this.target.position;
        }
        yield return new WaitForSeconds(0.1f);
        if (this.target)
        {
            float Dist1 = Vector3.Distance(this.thisTransform.position, this.target.position);
            float Dist2 = Vector3.Distance(this.TargetTrace.position, this.target.position);
            this.TargetTrace.LookAt(this.target);
            this.TargetLead.position = this.TargetTrace.position;
            this.TargetLead.rotation = this.TargetTrace.rotation;
            this.TargetLead.position = this.TargetLead.position + (((this.TargetLead.forward * Dist1) * Dist2) * 0.02f);
            if (this.Attacking)
            {
                this.TLCol.radius = this.Dist * 0.05f;
            }
            else
            {
                this.TLCol.radius = 0.1f;
            }
        }
    }

    public virtual void Regenerator()
    {
        this.PissedAtTC1 = TerrahyptianNetwork.TC1CriminalLevel;
        this.PissedAtTC4 = TerrahyptianNetwork.TC4CriminalLevel;
        this.PissedAtTC5 = TerrahyptianNetwork.TC5CriminalLevel;
        this.PissedAtTC6 = TerrahyptianNetwork.TC6CriminalLevel;
        this.PissedAtTC7 = TerrahyptianNetwork.TC7CriminalLevel;
        this.PissedAtTC8 = TerrahyptianNetwork.TC8CriminalLevel;
        this.PissedAtTC9 = TerrahyptianNetwork.TC9CriminalLevel;
        if (this.target)
        {
            if (this.target.name.Contains("xbT"))
            {
                this.FoundExtraBig = true;
            }
            else
            {
                this.FoundExtraBig = false;
            }
            if (this.target.name.Contains("bT"))
            {
                this.FoundBig = true;
            }
            else
            {
                this.FoundBig = false;
            }
            if (!this.target.name.Contains("mT"))
            {
                this.FoundMedium = false;
            }
            if (!this.target.name.Contains("sT"))
            {
                this.FoundSmall = false;
            }
            if (!this.Attacking)
            {
                if (TerrahyptianNetwork.TC1CriminalLevel > 480)
                {
                    if (this.target.name.Contains("C1"))
                    {
                        TerrahyptianNetwork.instance.EnemyTarget2 = this.target;
                        TerrahyptianNetwork.instance.PriorityWaypoint.position = this.target.position;
                    }
                    else
                    {
                        if (TerrahyptianNetwork.instance.EnemyTarget2)
                        {
                            if (Vector3.Distance(this.thisTransform.position, TerrahyptianNetwork.instance.EnemyTarget2.position) < 3000)
                            {
                                this.target = TerrahyptianNetwork.instance.EnemyTarget2;
                                if (!this.Attacking)
                                {
                                    this.AttackNoise();
                                }
                                this.Attacking = true;
                            }
                        }
                    }
                }
                if (TerrahyptianNetwork.TC1CriminalLevel > 480)
                {
                    if (TerrahyptianNetwork.AnExtraBigTC1)
                    {
                        this.target = TerrahyptianNetwork.AnExtraBigTC1;
                        TerrahyptianNetwork.AlertTime = 240;
                        this.FoundExtraBig = true;
                        this.Attacking = true;
                    }
                }
                if (TerrahyptianNetwork.TC4CriminalLevel > 480)
                {
                    if (TerrahyptianNetwork.AnExtraBigTC4)
                    {
                        this.target = TerrahyptianNetwork.AnExtraBigTC4;
                        TerrahyptianNetwork.AlertTime = 240;
                        this.FoundExtraBig = true;
                        this.Attacking = true;
                    }
                }
                if (TerrahyptianNetwork.TC5CriminalLevel > 480)
                {
                    if (TerrahyptianNetwork.AnExtraBigTC5)
                    {
                        this.target = TerrahyptianNetwork.AnExtraBigTC5;
                        TerrahyptianNetwork.AlertTime = 240;
                        this.FoundExtraBig = true;
                        this.Attacking = true;
                    }
                }
                if (TerrahyptianNetwork.TC6CriminalLevel > 480)
                {
                    if (TerrahyptianNetwork.AnExtraBigTC6)
                    {
                        this.target = TerrahyptianNetwork.AnExtraBigTC6;
                        TerrahyptianNetwork.AlertTime = 240;
                        this.FoundExtraBig = true;
                        this.Attacking = true;
                    }
                }
                if (TerrahyptianNetwork.TC7CriminalLevel > 480)
                {
                    if (TerrahyptianNetwork.AnExtraBigTC7)
                    {
                        this.target = TerrahyptianNetwork.AnExtraBigTC7;
                        TerrahyptianNetwork.AlertTime = 240;
                        this.FoundExtraBig = true;
                        this.Attacking = true;
                    }
                }
                if (TerrahyptianNetwork.TC8CriminalLevel > 480)
                {
                    if (TerrahyptianNetwork.AnExtraBigTC8)
                    {
                        this.target = TerrahyptianNetwork.AnExtraBigTC8;
                        TerrahyptianNetwork.AlertTime = 240;
                        this.FoundExtraBig = true;
                        this.Attacking = true;
                    }
                }
                if (TerrahyptianNetwork.TC9CriminalLevel > 480)
                {
                    if (TerrahyptianNetwork.AnExtraBigTC9)
                    {
                        this.target = TerrahyptianNetwork.AnExtraBigTC9;
                        TerrahyptianNetwork.AlertTime = 240;
                        this.FoundExtraBig = true;
                        this.Attacking = true;
                    }
                }
            }
        }
        if (this.Attacking)
        {
            this.StartCoroutine(this.TrigSweepAT());
        }
        else
        {
            this.StartCoroutine(this.TrigSweep());
        }
        if (this.DangerSense > 0)
        {
            if ((this.DangerSense < 2) && !this.Attacking)
            {
                this.target = this.ResetAimpoint;
            }
            this.DangerSense = this.DangerSense - 1;
        }
        if (this.SMCooldown > 0)
        {
            this.SMCooldown = this.SMCooldown - 1;
        }
        if (this.CMCooldown > 0)
        {
            this.CMCooldown = this.CMCooldown - 1;
        }
        this.TurnForce = 0;
        this.Wall = false;
        this.RWall = false;
        this.LWall = false;
        this.TurnRight = false;
        this.TurnLeft = false;
        this.StartCoroutine(this.Notice());
    }

    public virtual IEnumerator TrigSweep()
    {
        this.Trig.center = new Vector3(0, 0, 512);
        this.Trig.radius = 512;
        yield return new WaitForSeconds(0.12f);
        this.Trig.center = new Vector3(370, 0, 370);
        yield return new WaitForSeconds(0.12f);
        this.Trig.center = new Vector3(512, 0, 0);
        yield return new WaitForSeconds(0.12f);
        this.Trig.center = new Vector3(370, 0, -370);
        yield return new WaitForSeconds(0.12f);
        this.Trig.center = new Vector3(0, 0, -512);
        yield return new WaitForSeconds(0.12f);
        this.Trig.center = new Vector3(-370, 0, -370);
        yield return new WaitForSeconds(0.12f);
        this.Trig.center = new Vector3(-512, 0, 0);
        yield return new WaitForSeconds(0.12f);
        this.Trig.center = new Vector3(-370, 0, 370);
    }

    public virtual IEnumerator TrigSweepAT()
    {
        this.Trig.center = new Vector3(0, 0, 256);
        this.Trig.radius = 256;
        yield return new WaitForSeconds(0.12f);
        this.Trig.center = new Vector3(185, 0, 185);
        yield return new WaitForSeconds(0.12f);
        this.Trig.center = new Vector3(256, 0, 0);
        yield return new WaitForSeconds(0.12f);
        this.Trig.center = new Vector3(185, 0, -185);
        yield return new WaitForSeconds(0.12f);
        this.Trig.center = new Vector3(0, 0, -256);
        yield return new WaitForSeconds(0.12f);
        this.Trig.center = new Vector3(-185, 0, -185);
        yield return new WaitForSeconds(0.12f);
        this.Trig.center = new Vector3(-256, 0, 0);
        yield return new WaitForSeconds(0.12f);
        this.Trig.center = new Vector3(-185, 0, 185);
    }

    public virtual IEnumerator Notice()
    {
        if (this.Attacking)
        {
            if (this.target)
            {
                if (this.Emergency)
                {
                    TerrahyptianNetwork.instance.EnemyTarget1 = this.target;
                }
            }
        }
        if (this.DangerSense > 0)
        {
            this.DangerTick = true;
            this.thisTransform.LookAt(this.Waypoint);
            yield return new WaitForSeconds(0.1f);
            this.DangerTick = false;
        }
    }

    public LevNavCruiser()
    {
        this.orbitCurve = new AnimationCurve();
        this.Dist = 1;
        this.DirStrength = 2;
        this.TAimStrength = 2;
        this.TurnStrength = 2;
        this.RightDist = 200;
        this.LeftDist = 200;
        this.AngleTH = 2;
        this.forwardPoint = 2;
        this.sidePoint = 10;
        this.sidePointStat = 10;
        this.RPAbs = 1;
        this.RPClamp = 1;
        this.StoredMissileBatches = 32;
        this.StoredMissile2Batches = 64;
        this.StoredMissile3Batches = 8;
    }

}