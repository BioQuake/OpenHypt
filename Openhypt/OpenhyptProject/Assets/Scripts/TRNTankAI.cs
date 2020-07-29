using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class TRNTankAI : MonoBehaviour
{
    public Transform target;
    public Transform Waypoint;
    public Transform guardPost1;
    public Transform guardPost2;
    public Transform Base;
    public Transform Stranger;
    public Transform TargetTrace;
    public Transform TargetLead;
    public SphereCollider TLCol;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public Transform ResetAimpoint;
    public Transform topPoint;
    public Transform viewPoint;
    public Transform AIAnchor;
    public GameObject MissileAmmo;
    public Transform Missile1;
    public Transform Missile2;
    public Transform Turret1TF;
    public Rigidbody Turret1RB;
    public NPCGun Gun1;
    public BoxCollider Trig;
    public AdvancedHoverScript Hover1;
    public AdvancedHoverScript Hover2;
    public AdvancedHoverScript Hover3;
    public AdvancedHoverScript Hover4;
    public GameObject Presence;
    public GameObject AttackSound;
    public GameObject RejectSound;
    public int PissedAtTC0a;
    public int PissedAtTC1;
    public int PissedAtTC4;
    public int PissedAtTC5;
    public int PissedAtTC6;
    public int PissedAtTC7;
    public int PissedAtTC8;
    public int PissedAtTC9;
    public bool FoundSmall;
    public bool FoundMedium;
    public bool FoundBig;
    public bool Hunting;
    public bool onPost;
    public bool Watch;
    public bool Attacking;
    public bool Obstacle;
    public bool Stuck;
    public int StuckTimer;
    public int Unsticking;
    public Vector3 lastPos;
    public bool isClose;
    public bool inView;
    public bool TurnRight;
    public bool TurnLeft;
    public bool StrafeRight;
    public bool StrafeLeft;
    public int DirForce;
    public int TurnForce;
    public int TurretForce;
    public float RPClamp;
    public float RPMod;
    public float RightDist;
    public float LeftDist;
    public float RRUP;
    public int AngClamp;
    public bool Wall;
    public Vector3 Pointu;
    public Vector3 Pointd;
    public Vector3 RPointu;
    public Vector3 RPointd;
    public Vector3 LPointu;
    public Vector3 LPointd;
    public Vector3 localV;
    public Vector3 VelDir;
    public float Vel;
    public float Dist;
    public float targetDist;
    public float LeadMod2;
    public LayerMask targetLayers;
    public LayerMask MtargetLayers;
    public bool DangerSense;
    public bool FarFromTarget;
    public int Ignorage;
    public int shotAssumption;
    public bool canLaunch;
    public int StoredMissileBatches;
    public virtual void Start()
    {
        this.InvokeRepeating("Regenerator", 1, 1);
        this.InvokeRepeating("Shooty", Random.Range(2, 3), 0.2f);
        this.InvokeRepeating("Launchy", 1, 7);
        this.InvokeRepeating("CalcLead", 1, 0.15f);
        if (TerrahyptianNetwork.instance.AnodianBase)
        {
            this.Base = TerrahyptianNetwork.instance.AnodianBase;
        }
        if (TerrahyptianNetwork.instance.TerrahyptianBase)
        {
            this.Base = TerrahyptianNetwork.instance.TerrahyptianBase;
        }
        if (TerrahyptianNetwork.instance.TerrahyptianGuardPost1)
        {
            this.guardPost1 = TerrahyptianNetwork.instance.TerrahyptianGuardPost1;
            if (Vector3.Distance(this.thisTransform.position, this.guardPost1.position) < 32)
            {
                this.onPost = true;
            }
        }
        if (TerrahyptianNetwork.instance.TerrahyptianGuardPost2)
        {
            this.guardPost2 = TerrahyptianNetwork.instance.TerrahyptianGuardPost2;
            if (Vector3.Distance(this.thisTransform.position, this.guardPost2.position) < 32)
            {
                this.onPost = true;
            }
        }
        if (this.onPost)
        {
            this.Hover1.breaksOn = true;
            this.Hover2.breaksOn = true;
            this.Hover3.breaksOn = true;
            this.Hover4.breaksOn = true;
        }
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        RaycastHit hit1 = default(RaycastHit);
        RaycastHit hit2 = default(RaycastHit);
        RaycastHit hit3 = default(RaycastHit);
        if (!this.DangerSense)
        {
            this.thisTransform.rotation = this.AIAnchor.transform.rotation;
        }
        this.thisTransform.position = this.AIAnchor.transform.position;
        if (this.Attacking)
        {
            if (this.target == this.Waypoint)
            {
                this.target = this.ResetAimpoint;
                this.Attacking = false;
                this.Hunting = true;
                this.FoundSmall = false;
                this.FoundMedium = false;
                this.FoundBig = false;
            }
            if (this.target == null)
            {
                this.target = this.ResetAimpoint;
                this.Attacking = false;
                this.Hunting = true;
                this.FoundSmall = false;
                this.FoundMedium = false;
                this.FoundBig = false;
            }
        }
        else
        {
            if (this.target == null)
            {
                this.target = this.ResetAimpoint;
                this.Hunting = true;
                this.FoundSmall = false;
                this.FoundMedium = false;
                this.FoundBig = false;
            }
        }
        this.TurnForce = 0;
        if ((this.TurnRight && this.TurnLeft) && this.Obstacle)
        {
            this.TurnForce = -4000;
        }
        this.localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
        this.Vel = this.vRigidbody.velocity.magnitude;
        this.VelDir = this.vRigidbody.velocity;
        Vector3 RelativeTarget = new Vector3();
        Vector3 RelativeTargetB = new Vector3();
        if (this.target)
        {
            RelativeTarget = this.thisVTransform.InverseTransformPoint(this.target.position);
        }
        if (this.Base)
        {
            RelativeTargetB = this.thisVTransform.InverseTransformPoint(this.Base.position);
        }
        if (!this.Stuck)
        {
            if (this.TurnLeft)
            {
                this.TurnForce = -4000;
            }
            if (this.TurnRight)
            {
                this.TurnForce = 4000;
            }
        }
        else
        {
            if (RelativeTarget.x > 0)
            {
                this.TurnForce = -4000;
            }
            else
            {
                this.TurnForce = 4000;
            }
        }
        this.RPMod = RelativeTarget.x * 200;
        this.RPClamp = Mathf.Clamp(this.RPMod, -4000, 4000);
        if (this.RRUP < 15)
        {
            this.RRUP = this.RRUP + 1.5f;
        }
        else
        {
            this.RRUP = 1;
        }
        Vector3 newRot = ((-this.thisVTransform.up * 2) + (this.thisVTransform.right * -1)).normalized;
        float VelClamp = Mathf.Clamp(this.Vel * 6, 8, 300);
        this.AngClamp = (int) Mathf.Clamp(this.Vel * 0.1f, 4, 16);
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * 10)) + (-this.thisTransform.up * 0.7f), this.thisTransform.forward * VelClamp, Color.white);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * 10)) + (-this.thisTransform.up * 0.7f), this.thisTransform.forward, out hit1, VelClamp, (int) this.targetLayers))
        {
            this.Pointu = hit1.point;
        }
        else
        {
            this.Pointu = new Vector3(2, 2, 2);
        }
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * 10)) + (-this.thisTransform.up * 1.7f), this.thisTransform.forward * VelClamp, Color.white);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * 10)) + (-this.thisTransform.up * 1.7f), this.thisTransform.forward, out hit2, VelClamp, (int) this.targetLayers))
        {
            this.Pointd = hit2.point;
        }
        else
        {
            this.Pointd = new Vector3(8, 8, 8);
        }
        if (Vector3.Distance(this.Pointu, this.Pointd) < this.AngClamp)
        {
            this.Wall = true;
        }
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * 12)) + (this.thisTransform.up * 12), this.thisTransform.forward * VelClamp, Color.green);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * 12)) + (this.thisTransform.up * 12), this.thisTransform.forward, out hit, VelClamp, (int) this.targetLayers))
        {
            this.Wall = true;
        }
        newRot = ((-this.thisVTransform.up * 4) + (this.thisVTransform.right * 1)).normalized;
        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.right * 16), (newRot * VelClamp) * 0.7f, Color.green);
        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.right * 16), newRot, out hit, VelClamp * 0.7f, (int) this.targetLayers))
        {
            if (this.Wall)
            {
                this.Obstacle = true;
            }
            else
            {
                this.TurnLeft = true;
            }
        }
        newRot = ((-this.thisVTransform.up * 4) + (-this.thisVTransform.right * 1)).normalized;
        Debug.DrawRay(this.thisTransform.position + (-this.thisTransform.right * 16), (newRot * VelClamp) * 0.7f, Color.green);
        if (Physics.Raycast(this.thisTransform.position + (-this.thisTransform.right * 16), newRot, out hit, VelClamp * 0.7f, (int) this.targetLayers))
        {
            if (this.Wall)
            {
                this.Obstacle = true;
            }
            else
            {
                this.TurnRight = true;
            }
        }
        if (this.inView)
        {
            if (!this.isClose)
            {
                Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.forward * 10)) + (this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 0.7f), this.thisTransform.forward * VelClamp, Color.black);
                if (Physics.Raycast(((this.thisTransform.position + (this.thisTransform.forward * 10)) + (this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 0.7f), this.thisTransform.forward, out hit1, VelClamp, (int) this.targetLayers))
                {
                    this.RPointu = hit1.point;
                }
                else
                {
                    this.RPointu = new Vector3(2, 2, 2);
                }
                Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.forward * 10)) + (this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 1.7f), this.thisTransform.forward * VelClamp, Color.black);
                if (Physics.Raycast(((this.thisTransform.position + (this.thisTransform.forward * 10)) + (this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 1.7f), this.thisTransform.forward, out hit2, VelClamp, (int) this.targetLayers))
                {
                    this.RPointd = hit2.point;
                    this.RightDist = hit2.distance;
                }
                else
                {
                    this.RPointd = new Vector3(8, 8, 8);
                    this.RightDist = 512;
                }
                Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.forward * 10)) + (-this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 0.7f), this.thisTransform.forward * VelClamp, Color.black);
                if (Physics.Raycast(((this.thisTransform.position + (this.thisTransform.forward * 10)) + (-this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 0.7f), this.thisTransform.forward, out hit1, VelClamp, (int) this.targetLayers))
                {
                    this.LPointu = hit1.point;
                }
                else
                {
                    this.LPointu = new Vector3(2, 2, 2);
                }
                Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.forward * 10)) + (-this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 1.7f), this.thisTransform.forward * VelClamp, Color.black);
                if (Physics.Raycast(((this.thisTransform.position + (this.thisTransform.forward * 10)) + (-this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 1.7f), this.thisTransform.forward, out hit2, VelClamp, (int) this.targetLayers))
                {
                    this.LPointd = hit2.point;
                    this.LeftDist = hit2.distance;
                }
                else
                {
                    this.LPointd = new Vector3(8, 8, 8);
                    this.LeftDist = 512;
                }
            }
            else
            {
                Debug.DrawRay(((this.thisTransform.position + (-this.thisTransform.forward * 10)) + (this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 2), -this.thisTransform.forward * VelClamp, Color.black);
                if (Physics.Raycast(((this.thisTransform.position + (-this.thisTransform.forward * 10)) + (this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 2), -this.thisTransform.forward, out hit2, VelClamp, (int) this.targetLayers))
                {
                    this.RightDist = hit2.distance;
                }
                else
                {
                    this.RightDist = 512;
                }
                Debug.DrawRay(((this.thisTransform.position + (-this.thisTransform.forward * 10)) + (-this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 2), -this.thisTransform.forward * VelClamp, Color.black);
                if (Physics.Raycast(((this.thisTransform.position + (-this.thisTransform.forward * 10)) + (-this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 2), -this.thisTransform.forward, out hit2, VelClamp, (int) this.targetLayers))
                {
                    this.LeftDist = hit2.distance;
                }
                else
                {
                    this.LeftDist = 512;
                }
            }
        }
        else
        {
            Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.forward * 10)) + (this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 0.7f), this.thisTransform.forward * VelClamp, Color.black);
            if (Physics.Raycast(((this.thisTransform.position + (this.thisTransform.forward * 10)) + (this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 0.7f), this.thisTransform.forward, out hit1, VelClamp, (int) this.targetLayers))
            {
                this.RPointu = hit1.point;
            }
            else
            {
                this.RPointu = new Vector3(2, 2, 2);
            }
            Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.forward * 10)) + (this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 1.7f), this.thisTransform.forward * VelClamp, Color.black);
            if (Physics.Raycast(((this.thisTransform.position + (this.thisTransform.forward * 10)) + (this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 1.7f), this.thisTransform.forward, out hit2, VelClamp, (int) this.targetLayers))
            {
                this.RPointd = hit2.point;
                this.RightDist = hit2.distance;
            }
            else
            {
                this.RPointd = new Vector3(8, 8, 8);
                this.RightDist = 512;
            }
            Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.forward * 10)) + (-this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 0.7f), this.thisTransform.forward * VelClamp, Color.black);
            if (Physics.Raycast(((this.thisTransform.position + (this.thisTransform.forward * 10)) + (-this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 0.7f), this.thisTransform.forward, out hit1, VelClamp, (int) this.targetLayers))
            {
                this.LPointu = hit1.point;
            }
            else
            {
                this.LPointu = new Vector3(2, 2, 2);
            }
            Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.forward * 10)) + (-this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 1.7f), this.thisTransform.forward * VelClamp, Color.black);
            if (Physics.Raycast(((this.thisTransform.position + (this.thisTransform.forward * 10)) + (-this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 1.7f), this.thisTransform.forward, out hit2, VelClamp, (int) this.targetLayers))
            {
                this.LPointd = hit2.point;
                this.LeftDist = hit2.distance;
            }
            else
            {
                this.LPointd = new Vector3(8, 8, 8);
                this.LeftDist = 512;
            }
        }
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.up * 20)) + (this.thisTransform.forward * VelClamp), -this.thisTransform.up * 60, Color.white);
        if (!Physics.Raycast((this.thisTransform.position + (this.thisTransform.up * 20)) + (this.thisTransform.forward * VelClamp), -this.thisTransform.up, 60))
        {
            this.Obstacle = true;
        }
        //---------------------------------------------------------------------------------------------
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.up * 20)) + (this.thisTransform.right * 20)) + (this.thisTransform.forward * VelClamp), this.thisTransform.up * -60, Color.white);
        if (!Physics.Raycast(((this.thisTransform.position + (this.thisTransform.up * 20)) + (this.thisTransform.right * 20)) + (this.thisTransform.forward * VelClamp), -this.thisTransform.up, 60))
        {
            this.TurnLeft = true;
        }
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.up * 20)) + (-this.thisTransform.right * 20)) + (this.thisTransform.forward * VelClamp), this.thisTransform.up * -60, Color.white);
        if (!Physics.Raycast(((this.thisTransform.position + (this.thisTransform.up * 20)) + (-this.thisTransform.right * 20)) + (this.thisTransform.forward * VelClamp), -this.thisTransform.up, 60))
        {
            this.TurnRight = true;
        }
        //---------------------------------------------------------------------------------------------
        if (this.RightDist > this.LeftDist)
        {
            if (Vector3.Distance(this.LPointu, this.LPointd) < 4)
            {
                if (!this.isClose)
                {
                    this.TurnRight = true;
                }
            }
            if (this.isClose)
            {
                this.StrafeRight = true;
            }
        }
        if (this.LeftDist > this.RightDist)
        {
            if (Vector3.Distance(this.RPointu, this.RPointd) < 4)
            {
                if (!this.isClose)
                {
                    this.TurnLeft = true;
                }
            }
            if (this.isClose)
            {
                this.StrafeLeft = true;
            }
        }
        if (this.DangerSense)
        {
            this.TurnLeft = false;
            this.TurnRight = false;
        }
    }

    public virtual void FixedUpdate()
    {
        if (this.TurretForce < 150)
        {
            this.TurretForce = this.TurretForce + 2;
        }
        if ((this.Stuck || this.TurnLeft) || this.TurnRight)
        {
            this.vRigidbody.AddTorque(this.thisVTransform.forward * this.TurnForce);
        }
        else
        {
            this.vRigidbody.AddTorque(this.thisVTransform.forward * this.RPClamp);
        }
        if (this.Obstacle)
        {
            if (!this.isClose)
            {
                if (-this.localV.y > 0)
                {
                    this.vRigidbody.AddForce(this.thisVTransform.up * this.DirForce);
                }
            }
            else
            {
                if (!this.StrafeRight && !this.StrafeLeft)
                {
                    this.vRigidbody.AddForce(this.thisVTransform.up * this.DirForce);
                }
                if (this.StrafeRight)
                {
                    this.vRigidbody.AddForce(-this.thisVTransform.right * this.DirForce);
                }
                if (this.StrafeLeft)
                {
                    this.vRigidbody.AddForce(this.thisVTransform.right * this.DirForce);
                }
            }
        }
        if (this.Stuck)
        {
            if (this.localV.y < 8)
            {
                this.vRigidbody.AddForce(this.thisVTransform.up * this.DirForce);
            }
        }
        if (((!this.Obstacle && !this.Stuck) && !this.TurnLeft) && !this.TurnRight)
        {
            if (-this.localV.y < 60)
            {
                this.vRigidbody.AddForce(-this.thisVTransform.up * this.DirForce);
            }
        }
        if (this.target)
        {
            this.Turret1RB.AddTorque((-this.Turret1TF.right * this.Dist) * 0.015f);
            if (this.Turret1RB.angularVelocity.magnitude < 1)
            {
                this.Turret1RB.AddForceAtPosition((this.TargetLead.position - this.Turret1TF.position).normalized * this.TurretForce, -this.Turret1TF.up * 8);
                this.Turret1RB.AddForceAtPosition((this.TargetLead.position - this.Turret1TF.position).normalized * -this.TurretForce, this.Turret1TF.up * 8);
            }
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        RaycastHit hitT = default(RaycastHit);
        string ON = other.name;
        Transform OT = other.transform;
        if (ON.Contains("TFC"))
        {
            if (!ON.Contains("TFC3"))
            {
                Vector3 RTT = OT.InverseTransformPoint(this.thisVTransform.position);
                float RTPx = Mathf.Abs(RTT.x);
                float RTPy = Mathf.Abs(RTT.y);
                float RTP = RTPx + RTPy;
                if (Vector3.Distance(this.thisTransform.position, OT.position) < 100)
                {
                    if (ON.Contains("TFC0a"))
                    {
                        this.PissedAtTC0a = this.PissedAtTC0a + 1;
                    }
                    if (ON.Contains("TFC1"))
                    {
                        this.PissedAtTC1 = this.PissedAtTC1 + 1;
                    }
                    if (ON.Contains("TFC4"))
                    {
                        this.PissedAtTC4 = this.PissedAtTC4 + 1;
                    }
                    if (ON.Contains("TFC5"))
                    {
                        this.PissedAtTC5 = this.PissedAtTC5 + 1;
                    }
                    if (ON.Contains("TFC6"))
                    {
                        this.PissedAtTC6 = this.PissedAtTC6 + 1;
                    }
                    if (ON.Contains("TFC7"))
                    {
                        this.PissedAtTC7 = this.PissedAtTC7 + 1;
                    }
                    if (ON.Contains("TFC8"))
                    {
                        this.PissedAtTC8 = this.PissedAtTC8 + 1;
                    }
                    if (ON.Contains("TFC9"))
                    {
                        this.PissedAtTC9 = this.PissedAtTC9 + 1;
                    }
                }
                else
                {
                    Debug.DrawRay(OT.position + (OT.forward * 8), OT.forward * 256, Color.red);
                    if (Physics.Raycast(OT.position, OT.forward * 8, out hitT, 256, (int) this.targetLayers))
                    {
                        if (!hitT.collider.name.Contains("TC3"))
                        {
                            if (this.shotAssumption < 3)
                            {
                                this.shotAssumption = this.shotAssumption + 2;
                            }
                        }
                    }
                    if (this.shotAssumption < 0)
                    {
                        if (RTP < 100)
                        {
                            if (RTT.z > 0)
                            {
                                if (ON.Contains("TFC0a"))
                                {
                                    this.PissedAtTC0a = this.PissedAtTC0a + 1;
                                }
                                if (ON.Contains("TFC1"))
                                {
                                    this.PissedAtTC1 = this.PissedAtTC1 + 1;
                                }
                                if (ON.Contains("TFC4"))
                                {
                                    this.PissedAtTC4 = this.PissedAtTC4 + 1;
                                }
                                if (ON.Contains("TFC5"))
                                {
                                    this.PissedAtTC5 = this.PissedAtTC5 + 1;
                                }
                                if (ON.Contains("TFC6"))
                                {
                                    this.PissedAtTC6 = this.PissedAtTC6 + 1;
                                }
                                if (ON.Contains("TFC7"))
                                {
                                    this.PissedAtTC7 = this.PissedAtTC7 + 1;
                                }
                                if (ON.Contains("TFC8"))
                                {
                                    this.PissedAtTC8 = this.PissedAtTC8 + 1;
                                }
                                if (ON.Contains("TFC9"))
                                {
                                    this.PissedAtTC9 = this.PissedAtTC9 + 1;
                                }
                            }
                        }
                    }
                }
                if (other.GetComponent<Rigidbody>())
                {
                    this.Waypoint.position = OT.position;
                    this.DangerSense = true;
                    this.thisTransform.LookAt(this.Waypoint);
                }
            }
            else
            {
                if (ON.Contains("3_P"))
                {
                    if (other.GetComponent<Rigidbody>())
                    {
                        this.Waypoint.position = OT.position;
                        this.DangerSense = true;
                        this.thisTransform.LookAt(this.Waypoint);
                    }
                }
            }
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        string ON = other.name;
        Transform OT = other.transform;
        if (!ON.Contains("TC3"))
        {
            if (Vector3.Distance(this.thisTransform.position, OT.position) < 150)
            {
                if (ON.Contains("TC"))
                {
                    this.Stranger = OT;
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
            if (this.FoundBig)
            {
                return;
            }
            if (this.PissedAtTC0a > 1)
            {
                if (ON.Contains("TC0a"))
                {
                    if (((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || ON.Contains("bT"))
                    {
                        this.Hunting = false;
                        this.target = OT;
                        this.TurretForce = 0;
                        this.Trig.center = new Vector3(0, 0, 0);
                        this.Trig.size = new Vector3(1, 1, 1);
                        if (!this.Attacking)
                        {
                            this.AttackNoise();
                        }
                        this.Attacking = true;
                    }
                }
            }
            if (this.PissedAtTC1 > 1)
            {
                if (ON.Contains("TC1"))
                {
                    if (((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || ON.Contains("bT"))
                    {
                        this.Hunting = false;
                        this.target = OT;
                        this.TurretForce = 0;
                        this.Trig.center = new Vector3(0, 0, 0);
                        this.Trig.size = new Vector3(1, 1, 1);
                        if (!this.Attacking)
                        {
                            this.AttackNoise();
                        }
                        this.Attacking = true;
                    }
                }
            }
            if (this.PissedAtTC4 > 1)
            {
                if (ON.Contains("TC4"))
                {
                    if (((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || ON.Contains("bT"))
                    {
                        this.Hunting = false;
                        this.target = OT;
                        this.TurretForce = 0;
                        this.Trig.center = new Vector3(0, 0, 0);
                        this.Trig.size = new Vector3(1, 1, 1);
                        if (!this.Attacking)
                        {
                            this.AttackNoise();
                        }
                        this.Attacking = true;
                    }
                }
            }
            if (this.PissedAtTC5 > 1)
            {
                if (ON.Contains("TC5"))
                {
                    if (((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || ON.Contains("bT"))
                    {
                        this.Hunting = false;
                        this.target = OT;
                        this.TurretForce = 0;
                        this.Trig.center = new Vector3(0, 0, 0);
                        this.Trig.size = new Vector3(1, 1, 1);
                        if (!this.Attacking)
                        {
                            this.AttackNoise();
                        }
                        this.Attacking = true;
                    }
                }
            }
            if (this.PissedAtTC6 > 1)
            {
                if (ON.Contains("TC6"))
                {
                    if (((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || ON.Contains("bT"))
                    {
                        this.Hunting = false;
                        this.target = OT;
                        this.TurretForce = 0;
                        this.Trig.center = new Vector3(0, 0, 0);
                        this.Trig.size = new Vector3(1, 1, 1);
                        if (!this.Attacking)
                        {
                            this.AttackNoise();
                        }
                        this.Attacking = true;
                    }
                }
            }
            if (this.PissedAtTC7 > 1)
            {
                if (ON.Contains("TC7"))
                {
                    if (((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || ON.Contains("bT"))
                    {
                        this.Hunting = false;
                        this.target = OT;
                        this.TurretForce = 0;
                        this.Trig.center = new Vector3(0, 0, 0);
                        this.Trig.size = new Vector3(1, 1, 1);
                        if (!this.Attacking)
                        {
                            this.AttackNoise();
                        }
                        this.Attacking = true;
                    }
                }
            }
            if (this.PissedAtTC8 > 1)
            {
                if (ON.Contains("TC8"))
                {
                    if (((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || ON.Contains("bT"))
                    {
                        this.Hunting = false;
                        this.target = OT;
                        this.TurretForce = 0;
                        this.Trig.center = new Vector3(0, 0, 0);
                        this.Trig.size = new Vector3(1, 1, 1);
                        if (!this.Attacking)
                        {
                            this.AttackNoise();
                        }
                        this.Attacking = true;
                    }
                }
            }
            if (this.PissedAtTC9 > 1)
            {
                if (ON.Contains("TC9"))
                {
                    if (((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || ON.Contains("bT"))
                    {
                        this.Hunting = false;
                        this.target = OT;
                        this.TurretForce = 0;
                        this.Trig.center = new Vector3(0, 0, 0);
                        this.Trig.size = new Vector3(1, 1, 1);
                        if (!this.Attacking)
                        {
                            this.AttackNoise();
                        }
                        this.Attacking = true;
                    }
                }
            }
        }
    }

    public virtual void AttackNoise()
    {
        GameObject TheThing = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
        TheThing.transform.parent = this.thisTransform;
    }

    public virtual void Shooty()
    {
        if (this.Attacking)
        {
            if (this.target)
            {
                if (!this.target.name.Contains("sT"))
                {
                    if (this.Gun1)
                    {
                        this.Gun1.Fire();
                    }
                    this.Gun1.gunTarget = this.target;
                }
            }
        }
    }

    public virtual void Launchy()
    {
        RaycastHit hit8 = default(RaycastHit);
        if (this.Attacking && this.target)
        {
            this.topPoint.LookAt(this.target);
            if (Physics.Raycast(this.topPoint.position, this.topPoint.forward, out hit8, 2048, (int) this.targetLayers))
            {
                if ((hit8.collider.name.Contains("DV") || hit8.collider.name.Contains("TC")) || hit8.collider.name.Contains("TL"))
                {
                    this.StartCoroutine(this.LaunchSM());
                }
            }
        }
    }

    public virtual IEnumerator LaunchSM()
    {
        if (this.target != null)
        {
            if ((this.Attacking && (this.StoredMissileBatches > 0)) && this.canLaunch)
            {
                if ((Vector3.Distance(this.thisTransform.position, this.target.position) < 1000) && (Vector3.Distance(this.thisTransform.position, this.target.position) > 100))
                {
                    Vector3 Measure = this.thisVTransform.InverseTransformPoint(this.target.position);
                    if (((Measure.y < 0) && (-this.localV.y > 17)) && (Vector3.Distance(this.thisTransform.position, this.target.position) < 330))
                    {
                        yield break;
                    }
                    this.StoredMissileBatches = this.StoredMissileBatches - 1;
                    GameObject _SpawnedObject1 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile1.position, this.Missile1.rotation);
                    _SpawnedObject1.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                    ((MissileScript) _SpawnedObject1.transform.GetComponent(typeof(MissileScript))).target = this.target;
                    yield return new WaitForSeconds(0.3f);
                    GameObject _SpawnedObject2 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile2.position, this.Missile2.rotation);
                    _SpawnedObject2.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                    ((MissileScript) _SpawnedObject2.transform.GetComponent(typeof(MissileScript))).target = this.target;
                }
            }
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
            this.Dist = Dist1;
            this.TargetTrace.LookAt(this.target);
            this.TargetLead.position = this.TargetTrace.position;
            this.TargetLead.rotation = this.TargetTrace.rotation;
            this.TargetLead.position = this.TargetLead.position + (((this.TargetLead.forward * Dist1) * Dist2) * 0.02f);
            if (this.VelDir != Vector3.zero)
            {
                this.TargetLead.rotation = Quaternion.LookRotation(this.VelDir);
            }
            this.TargetLead.position = this.TargetLead.position - ((this.TargetLead.forward * this.Vel) * this.LeadMod2);
            if (this.Attacking)
            {
                this.TLCol.radius = Vector3.Distance(this.thisTransform.position, this.target.position) * 0.025f;
            }
            else
            {
                this.TLCol.radius = 0.1f;
            }
        }
    }

    public virtual void Regenerator()
    {
        RaycastHit hitV = default(RaycastHit);
        if (this.target)
        {
            this.targetDist = Vector3.Distance(this.transform.position, this.target.position);
            if (TerrahyptianNetwork.TC1CriminalLevel > 10)
            {
                this.PissedAtTC1 = TerrahyptianNetwork.TC1CriminalLevel;
                if (this.target.name.Contains("TC1"))
                {
                    this.Attacking = true;
                    this.Hunting = false;
                    if (TerrahyptianNetwork.TC1CriminalLevel > 480)
                    {
                        TerrahyptianNetwork.AlertLVL2 = 1;
                    }
                }
            }
            if (TerrahyptianNetwork.TC4CriminalLevel > 10)
            {
                this.PissedAtTC4 = TerrahyptianNetwork.TC4CriminalLevel;
                if (this.target.name.Contains("TC4"))
                {
                    this.Attacking = true;
                    this.Hunting = false;
                    if (TerrahyptianNetwork.TC4CriminalLevel > 480)
                    {
                        TerrahyptianNetwork.AlertLVL2 = 4;
                    }
                }
            }
            if (TerrahyptianNetwork.TC5CriminalLevel > 10)
            {
                this.PissedAtTC5 = TerrahyptianNetwork.TC5CriminalLevel;
                if (this.target.name.Contains("TC5"))
                {
                    this.Attacking = true;
                    this.Hunting = false;
                    if (TerrahyptianNetwork.TC5CriminalLevel > 480)
                    {
                        TerrahyptianNetwork.AlertLVL2 = 5;
                    }
                }
            }
            if (TerrahyptianNetwork.TC6CriminalLevel > 10)
            {
                this.PissedAtTC6 = TerrahyptianNetwork.TC6CriminalLevel;
                if (this.target.name.Contains("TC6"))
                {
                    this.Attacking = true;
                    this.Hunting = false;
                    if (TerrahyptianNetwork.TC6CriminalLevel > 480)
                    {
                        TerrahyptianNetwork.AlertLVL2 = 6;
                    }
                }
            }
            if (TerrahyptianNetwork.TC7CriminalLevel > 10)
            {
                this.PissedAtTC7 = TerrahyptianNetwork.TC7CriminalLevel;
                if (this.target.name.Contains("TC7"))
                {
                    this.Attacking = true;
                    this.Hunting = false;
                    if (TerrahyptianNetwork.TC7CriminalLevel > 480)
                    {
                        TerrahyptianNetwork.AlertLVL2 = 7;
                    }
                }
            }
            if (TerrahyptianNetwork.TC8CriminalLevel > 10)
            {
                this.PissedAtTC8 = TerrahyptianNetwork.TC8CriminalLevel;
                if (this.target.name.Contains("TC8"))
                {
                    this.Attacking = true;
                    this.Hunting = false;
                    if (TerrahyptianNetwork.TC8CriminalLevel > 480)
                    {
                        TerrahyptianNetwork.AlertLVL2 = 8;
                    }
                }
            }
            if (TerrahyptianNetwork.TC9CriminalLevel > 10)
            {
                this.PissedAtTC9 = TerrahyptianNetwork.TC9CriminalLevel;
                if (this.target.name.Contains("TC9"))
                {
                    this.Attacking = true;
                    this.Hunting = false;
                    if (TerrahyptianNetwork.TC9CriminalLevel > 480)
                    {
                        TerrahyptianNetwork.AlertLVL2 = 9;
                    }
                }
            }
            if (TerrahyptianNetwork.TC4CriminalLevel > 480)
            {
                if (this.target.name.Contains("C4"))
                {
                    TerrahyptianNetwork.AlertLVL2 = 4;
                }
            }
            if (TerrahyptianNetwork.TC5CriminalLevel > 480)
            {
                if (this.target.name.Contains("C5"))
                {
                    TerrahyptianNetwork.AlertLVL2 = 5;
                }
            }
            if (TerrahyptianNetwork.TC6CriminalLevel > 480)
            {
                if (this.target.name.Contains("C6"))
                {
                    TerrahyptianNetwork.AlertLVL2 = 6;
                }
            }
            if (TerrahyptianNetwork.TC7CriminalLevel > 480)
            {
                if (this.target.name.Contains("C7"))
                {
                    TerrahyptianNetwork.AlertLVL2 = 7;
                }
            }
            if (TerrahyptianNetwork.TC8CriminalLevel > 480)
            {
                if (this.target.name.Contains("C8"))
                {
                    TerrahyptianNetwork.AlertLVL2 = 8;
                }
            }
            if (TerrahyptianNetwork.TC9CriminalLevel > 480)
            {
                if (this.target.name.Contains("C9"))
                {
                    TerrahyptianNetwork.AlertLVL2 = 9;
                }
            }
            if (this.PissedAtTC1 > 0)
            {
                this.PissedAtTC1 = this.PissedAtTC1 - 1;
            }
            if (this.PissedAtTC4 > 0)
            {
                this.PissedAtTC4 = this.PissedAtTC4 - 1;
            }
            if (this.PissedAtTC5 > 0)
            {
                this.PissedAtTC5 = this.PissedAtTC5 - 1;
            }
            if (this.PissedAtTC6 > 0)
            {
                this.PissedAtTC6 = this.PissedAtTC6 - 1;
            }
            if (this.PissedAtTC7 > 0)
            {
                this.PissedAtTC7 = this.PissedAtTC7 - 1;
            }
            if (this.PissedAtTC8 > 0)
            {
                this.PissedAtTC8 = this.PissedAtTC8 - 1;
            }
            if (this.PissedAtTC9 > 0)
            {
                this.PissedAtTC9 = this.PissedAtTC9 - 1;
            }
            Vector3 lastTPos = this.target.position;
            this.StartCoroutine(this.Notice2(lastTPos));
            if (this.target.name.Contains("rok"))
            {
                this.Attacking = false;
                this.Watch = true;
                this.FoundSmall = false;
                this.FoundMedium = false;
            }
            else
            {
                this.Watch = false;
            }
            if (!Physics.Linecast(this.topPoint.position, this.target.position, (int) this.MtargetLayers))
            {
                this.canLaunch = true;
            }
            else
            {
                this.canLaunch = false;
            }
            if (!this.Watch)
            {
                this.Obstacle = false;
            }
            if (this.onPost)
            {
                this.DirForce = 0;
            }
            else
            {
                this.DirForce = 400;
            }
            if (!this.Attacking)
            {
                if (TerrahyptianNetwork.instance.EnemyTarget2)
                {
                    this.target = TerrahyptianNetwork.instance.EnemyTarget2;
                }
            }
            else
            {
                TerrahyptianNetwork.instance.EnemyTarget1 = this.target;
                if (this.targetDist < 150)
                {
                    this.isClose = true;
                }
                else
                {
                    this.isClose = false;
                    if (this.inView)
                    {
                        if (this.targetDist < 200)
                        {
                            this.Obstacle = true;
                        }
                    }
                    if (this.targetDist > 1000)
                    {
                        this.inView = false;
                    }
                }
            }
            this.viewPoint.LookAt(this.target);
            Debug.DrawRay(this.viewPoint.position, this.viewPoint.forward * this.targetDist, Color.red);
            if (Physics.Raycast(this.viewPoint.position, this.viewPoint.forward, out hitV, this.targetDist, (int) this.targetLayers))
            {
                if (hitV.collider.name.Contains("TL") || hitV.collider.name.Contains("TC"))
                {
                    if (this.Attacking)
                    {
                        if (Physics.Raycast(this.viewPoint.position, this.viewPoint.forward, this.targetDist, (int) this.MtargetLayers))
                        {
                            this.inView = false;
                        }
                        else
                        {
                            if (this.targetDist < 1000)
                            {
                                this.inView = true;
                            }
                        }
                    }
                    else
                    {
                        this.inView = false;
                    }
                }
                else
                {
                    this.inView = false;
                }
            }
            if (this.target.name.Contains("sT"))
            {
                this.FoundSmall = true;
            }
            if (this.target.name.Contains("mT"))
            {
                this.FoundMedium = true;
            }
            if (this.target.name.Contains("bT"))
            {
                this.FoundBig = true;
                TerrahyptianNetwork.instance.EnemyTarget2 = this.target;
                if (this.inView)
                {
                    this.FoundSmall = true;
                    this.FoundMedium = true;
                }
                this.Gun1.TargetRange = 3000;
            }
            else
            {
                this.Gun1.TargetRange = 1500;
            }
            if (!this.inView)
            {
                this.FoundSmall = false;
                this.FoundMedium = false;
                this.FoundBig = false;
            }
            else
            {
                this.StuckTimer = 0;
                this.Stuck = false;
            }
        }
        if (this.Attacking)
        {
            this.Trig.center = new Vector3(0, 0, 150);
            this.Trig.size = new Vector3(300, 300, 600);
        }
        else
        {
            this.Trig.center = new Vector3(0, 0, 1350);
            this.Trig.size = new Vector3(400, 300, 3000);
            if (this.onPost)
            {
                this.Hover1.breaksOn = true;
                this.Hover2.breaksOn = true;
                this.Hover3.breaksOn = true;
                this.Hover4.breaksOn = true;
            }
        }
        if (this.Ignorage > 4)
        {
            this.Ignorage = 0;
            this.target = null;
        }
        if (this.shotAssumption > 0)
        {
            this.shotAssumption = this.shotAssumption - 1;
        }
        this.DangerSense = false;
        this.Wall = false;
        if (!this.Obstacle)
        {
            this.TurnRight = false;
            this.TurnLeft = false;
        }
        if (this.Watch || this.onPost)
        {
            this.Obstacle = true;
            this.TurnRight = false;
            this.TurnLeft = false;
        }
        this.StrafeRight = false;
        this.StrafeLeft = false;
        ////////////////////////////////////////////////////////////////////////////
        //////////////////////////////[STUCKAROONIES]///////////////////////////////
        ////////////////////////////////////////////////////////////////////////////
        if (!this.onPost || this.inView)
        {
            if (!this.Stuck)
            {
                this.StuckTimer = this.StuckTimer + 1;
                if (this.TurnLeft && this.TurnRight)
                {
                    this.StuckTimer = this.StuckTimer + 2;
                }
            }
            else
            {
                this.Unsticking = this.Unsticking + 1;
                if (!this.Wall && (this.Unsticking > 8))
                {
                    this.Unsticking = this.Unsticking - 1;
                }
                Debug.DrawRay(this.thisTransform.position + (-this.thisTransform.up * 10), -this.thisTransform.forward * 64, Color.white);
                if (Physics.Raycast(this.thisTransform.position + (-this.thisTransform.up * 10), -this.thisTransform.forward, 64, (int) this.targetLayers))
                {
                    this.Unsticking = 16;
                }
            }
            if (this.Unsticking > 12)
            {
                this.Stuck = false;
                this.TurnRight = false;
                this.TurnLeft = false;
                this.Unsticking = 0;
            }
            if (this.StuckTimer > 12)
            {
                this.Stuck = false;
                this.TurnRight = false;
                this.TurnLeft = false;
                if (Vector3.Distance(this.thisTransform.position, this.lastPos) < 10)
                {
                    this.Stuck = true;
                }
                this.lastPos = this.thisTransform.position;
                this.StuckTimer = 0;
            }
        }
    }

    public virtual IEnumerator Notice2(Vector3 lastTPos)
    {
        yield return new WaitForSeconds(0.5f);
        if (this.target)
        {
            if (this.target.name.Contains("sTC"))
            {
                if (Vector3.Distance(this.target.position, lastTPos) < 0.5f)
                {
                    this.Ignorage = this.Ignorage + 1;
                }
                else
                {
                    this.Ignorage = 0;
                }
            }
        }
    }

    public TRNTankAI()
    {
        this.DirForce = 400;
        this.RightDist = 200;
        this.LeftDist = 200;
        this.AngClamp = 2;
        this.LeadMod2 = 0.005f;
        this.StoredMissileBatches = 32;
    }

}