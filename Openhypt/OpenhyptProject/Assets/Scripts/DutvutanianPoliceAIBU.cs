using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class DutvutanianPoliceAIBU : MonoBehaviour
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
    public Transform Turret1TF;
    public Rigidbody Turret1RB;
    public NPCGun Gun1;
    public NPCGun Gun1Sec;
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
    public int PissedAtTC2;
    public int PissedAtTC3;
    public int PissedAtTC4;
    public int PissedAtTC5;
    public int PissedAtTC6;
    public int PissedAtTC7;
    public int PissedAtTC8;
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
    public bool inView;
    public bool TurnRight;
    public bool TurnLeft;
    public int TFClamp;
    public int TurnForce;
    public float TurretForce;
    public float RPClamp;
    public float RPMod;
    public float RightDist;
    public float LeftDist;
    public float RRUP;
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
    public Vector3 RelativeTarget;
    public float LeadMod2;
    public LayerMask targetLayers;
    public LayerMask TtargetLayers;
    public LayerMask MtargetLayers;
    public bool CanDangerSense;
    public bool DangerSense;
    public bool FarFromTarget;
    public int Ignorage;
    public int shotAssumption;
    public virtual void Start()
    {
        this.InvokeRepeating("Regenerator", 1, 1);
        this.InvokeRepeating("Shooty", Random.Range(2, 3), 0.05f);
        this.InvokeRepeating("CalcLead", 1, 0.15f);
        if (DutvutanianNetwork.instance.DutvutanianBase)
        {
            this.Base = DutvutanianNetwork.instance.DutvutanianBase;
        }
        if (DutvutanianNetwork.instance.DutvutanianGuardPost1)
        {
            this.guardPost1 = DutvutanianNetwork.instance.DutvutanianGuardPost1;
            if (Vector3.Distance(this.thisTransform.position, this.guardPost1.position) < 32)
            {
                this.onPost = true;
            }
        }
        if (DutvutanianNetwork.instance.DutvutanianGuardPost2)
        {
            this.guardPost2 = DutvutanianNetwork.instance.DutvutanianGuardPost2;
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
        this.Dist = 4;
        this.TurnForce = 600;
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
        this.TurnLeft = false;
        this.TurnRight = false;
        this.localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
        this.Vel = this.vRigidbody.velocity.magnitude;
        this.VelDir = this.vRigidbody.velocity;
        if (this.target)
        {
            this.RelativeTarget = this.thisVTransform.InverseTransformPoint(this.target.position);
        }
        if (this.Base)
        {
            Vector3 RelativeTargetB = this.thisVTransform.InverseTransformPoint(this.Base.position);
        }
        this.RPMod = this.RelativeTarget.x * 4;
        this.RPClamp = Mathf.Clamp(this.RPMod, -100, 100);
        if (this.RRUP < 8)
        {
            this.RRUP = this.RRUP + 1.5f;
        }
        else
        {
            this.RRUP = 1;
        }
        Vector3 newRot = ((-this.thisVTransform.up * 2) + (this.thisVTransform.right * -1)).normalized;
        float VelClamp = Mathf.Clamp(this.Vel * 2, 8, 200);
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * 4)) + (-this.thisTransform.up * 1), this.thisTransform.forward * VelClamp, Color.white);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * 4)) + (-this.thisTransform.up * 1), this.thisTransform.forward, out hit1, VelClamp, (int) this.targetLayers))
        {
            this.Pointu = hit1.point;
        }
        else
        {
            this.Pointu = new Vector3(2, 2, 2);
        }
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * 4)) + (-this.thisTransform.up * 1.7f), this.thisTransform.forward * VelClamp, Color.white);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * 4)) + (-this.thisTransform.up * 1.7f), this.thisTransform.forward, out hit2, VelClamp, (int) this.targetLayers))
        {
            this.Pointd = hit2.point;
        }
        else
        {
            this.Pointd = new Vector3(8, 8, 8);
        }
        if (Vector3.Distance(this.Pointu, this.Pointd) < 2)
        {
            this.Wall = true;
        }
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * 4)) + (this.thisTransform.up * 8), this.thisTransform.forward * VelClamp, Color.green);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * 4)) + (this.thisTransform.up * 8), this.thisTransform.forward, VelClamp, (int) this.targetLayers))
        {
            this.Obstacle = true;
        }
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.forward * 4)) + (this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 1), this.thisTransform.forward * VelClamp, Color.black);
        if (Physics.Raycast(((this.thisTransform.position + (this.thisTransform.forward * 4)) + (this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 1), this.thisTransform.forward, out hit1, VelClamp, (int) this.targetLayers))
        {
            this.RPointu = hit1.point;
        }
        else
        {
            this.RPointu = new Vector3(2, 2, 2);
        }
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.forward * 4)) + (this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 1.7f), this.thisTransform.forward * VelClamp, Color.black);
        if (Physics.Raycast(((this.thisTransform.position + (this.thisTransform.forward * 4)) + (this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 1.7f), this.thisTransform.forward, out hit2, VelClamp, (int) this.targetLayers))
        {
            this.RPointd = hit2.point;
            this.RightDist = hit2.distance;
        }
        else
        {
            this.RPointd = new Vector3(8, 8, 8);
            this.RightDist = 512;
        }
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.forward * 4)) + (-this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 1), this.thisTransform.forward * VelClamp, Color.black);
        if (Physics.Raycast(((this.thisTransform.position + (this.thisTransform.forward * 4)) + (-this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 1), this.thisTransform.forward, out hit1, VelClamp, (int) this.targetLayers))
        {
            this.LPointu = hit1.point;
        }
        else
        {
            this.LPointu = new Vector3(2, 2, 2);
        }
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.forward * 4)) + (-this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 1.7f), this.thisTransform.forward * VelClamp, Color.black);
        if (Physics.Raycast(((this.thisTransform.position + (this.thisTransform.forward * 4)) + (-this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 1.7f), this.thisTransform.forward, out hit2, VelClamp, (int) this.targetLayers))
        {
            this.LPointd = hit2.point;
            this.LeftDist = hit2.distance;
        }
        else
        {
            this.LPointd = new Vector3(8, 8, 8);
            this.LeftDist = 512;
        }
        Debug.DrawRay((this.thisTransform.position + (-Vector3.down * 10)) + (this.thisTransform.forward * VelClamp), Vector3.down * 30, Color.white);
        if (!Physics.Raycast((this.thisTransform.position + (-Vector3.down * 10)) + (this.thisTransform.forward * VelClamp), Vector3.down, 30))
        {
            this.Obstacle = true;
        }
        //---------------------------------------------------------------------------------------------
        Debug.DrawRay(((this.thisTransform.position + (-Vector3.down * 10)) + (this.thisTransform.right * 10)) + (this.thisTransform.forward * VelClamp), Vector3.down * 30, Color.white);
        if (!Physics.Raycast(((this.thisTransform.position + (-Vector3.down * 10)) + (this.thisTransform.right * 10)) + (this.thisTransform.forward * VelClamp), Vector3.down, 30))
        {
            this.TurnLeft = true;
        }
        Debug.DrawRay(((this.thisTransform.position + (-Vector3.down * 10)) + (-this.thisTransform.right * 10)) + (this.thisTransform.forward * VelClamp), Vector3.down * 30, Color.white);
        if (!Physics.Raycast(((this.thisTransform.position + (-Vector3.down * 10)) + (-this.thisTransform.right * 10)) + (this.thisTransform.forward * VelClamp), Vector3.down, 30))
        {
            this.TurnRight = true;
        }
        //---------------------------------------------------------------------------------------------
        if (this.RightDist > this.LeftDist)
        {
            if (Vector3.Distance(this.LPointu, this.LPointd) < 2)
            {
                this.TurnRight = true;
            }
        }
        if (this.LeftDist > this.RightDist)
        {
            if (Vector3.Distance(this.RPointu, this.RPointd) < 2)
            {
                this.TurnLeft = true;
            }
        }
    }

    public virtual void FixedUpdate()
    {
        if (this.TurretForce < 15)
        {
            this.TurretForce = this.TurretForce + 0.1f;
        }
        this.TFClamp = (int) Mathf.Clamp(this.Vel * 7, 200, 600);
        if (!this.Stuck)
        {
            Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * 10)) + (-this.thisTransform.up * 1.5f), this.thisTransform.right * 8, Color.green);
            Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * 10)) + (-this.thisTransform.up * 1.5f), -this.thisTransform.right * 8, Color.green);
            if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * 10)) + (-this.thisTransform.up * 1.5f), this.thisTransform.right, 8, (int) this.targetLayers))
            {
                this.vRigidbody.AddTorque(this.thisVTransform.forward * -100);
                this.Obstacle = true;
            }
            if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * 10)) + (-this.thisTransform.up * 1.5f), -this.thisTransform.right, 8, (int) this.targetLayers))
            {
                this.vRigidbody.AddTorque(this.thisVTransform.forward * 100);
                this.Obstacle = true;
            }
            if (this.TurnLeft)
            {
                this.TurnForce = -this.TFClamp;
            }
            if (this.TurnRight)
            {
                this.TurnForce = this.TFClamp;
            }
        }
        else
        {
            if (this.RelativeTarget.x > 0)
            {
                this.TurnForce = -this.TFClamp;
            }
            else
            {
                this.TurnForce = this.TFClamp;
            }
        }
        if (this.TurnRight && this.TurnLeft)
        {
            this.TurnForce = (int) (-this.TFClamp * 0.5f);
            this.Obstacle = true;
        }
        if ((this.Stuck || this.TurnLeft) || this.TurnRight)
        {
            this.vRigidbody.AddTorque(this.thisVTransform.forward * this.TurnForce);
        }
        else
        {
            if (this.Dist > 1000)
            {
                this.vRigidbody.AddTorque(this.thisVTransform.forward * this.RPClamp);
            }
            else
            {
                if (this.inView)
                {
                    this.vRigidbody.AddTorque(this.thisVTransform.forward * this.RPClamp);
                }
            }
        }
        if (this.Obstacle)
        {
            if (-this.localV.y > 0)
            {
                this.vRigidbody.AddForce(this.thisVTransform.up * 100);
            }
        }
        else
        {
            if (this.inView)
            {
                if (-this.localV.y > 0)
                {
                    this.vRigidbody.AddForce(this.thisVTransform.up * 50);
                }
            }
            else
            {
                if (!this.onPost)
                {
                    if (this.Stuck)
                    {
                        if (this.localV.y < 8)
                        {
                            this.vRigidbody.AddForce(this.thisVTransform.up * 50);
                        }
                    }
                    if ((!this.Stuck && !this.TurnLeft) && !this.TurnRight)
                    {
                        if (-this.localV.y < 150)
                        {
                            this.vRigidbody.AddForce(-this.thisVTransform.up * 50);
                        }
                    }
                }
            }
        }
        if (this.target)
        {
            if (this.Turret1RB.angularVelocity.magnitude < 2)
            {
                if (this.target == this.ResetAimpoint)
                {
                    this.Turret1RB.AddForceAtPosition((this.ResetAimpoint.position - this.Turret1TF.position).normalized * this.TurretForce, -this.Turret1TF.up * 8);
                    this.Turret1RB.AddForceAtPosition((this.ResetAimpoint.position - this.Turret1TF.position).normalized * -this.TurretForce, this.Turret1TF.up * 8);
                }
                else
                {
                    this.Turret1RB.AddForceAtPosition((this.TargetLead.position - this.Turret1TF.position).normalized * this.TurretForce, -this.Turret1TF.up * 8);
                    this.Turret1RB.AddForceAtPosition((this.TargetLead.position - this.Turret1TF.position).normalized * -this.TurretForce, this.Turret1TF.up * 8);
                }
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
            if (!ON.Contains("TFC9"))
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
                    if (ON.Contains("TFC2"))
                    {
                        this.PissedAtTC2 = this.PissedAtTC2 + 1;
                    }
                    if (ON.Contains("TFC3"))
                    {
                        this.PissedAtTC3 = this.PissedAtTC3 + 1;
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
                }
                else
                {
                    Debug.DrawRay(OT.position + (OT.forward * 8), OT.forward * 256, Color.red);
                    if (Physics.Raycast(OT.position, OT.forward * 8, out hitT, 256, (int) this.TtargetLayers))
                    {
                        if (!hitT.collider.name.Contains("TC9"))
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
                                if (ON.Contains("TFC2"))
                                {
                                    this.PissedAtTC2 = this.PissedAtTC2 + 1;
                                }
                                if (ON.Contains("TFC3"))
                                {
                                    this.PissedAtTC3 = this.PissedAtTC3 + 1;
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
                            }
                        }
                    }
                }
                if (this.CanDangerSense)
                {
                    if (other.GetComponent<Rigidbody>())
                    {
                        this.Waypoint.position = OT.position;
                        this.DangerSense = true;
                        this.CanDangerSense = false;
                        this.StartCoroutine(this.DSReset());
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
        if (!ON.Contains("TC9"))
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
                    DutvutanianNetwork.AnExtraBigTC1 = OT;
                }
                if (ON.Contains("C2"))
                {
                    DutvutanianNetwork.AnExtraBigTC4 = OT;
                }
                if (ON.Contains("C3"))
                {
                    DutvutanianNetwork.AnExtraBigTC4 = OT;
                }
                if (ON.Contains("C4"))
                {
                    DutvutanianNetwork.AnExtraBigTC4 = OT;
                }
                if (ON.Contains("C5"))
                {
                    DutvutanianNetwork.AnExtraBigTC5 = OT;
                }
                if (ON.Contains("C6"))
                {
                    DutvutanianNetwork.AnExtraBigTC6 = OT;
                }
                if (ON.Contains("C7"))
                {
                    DutvutanianNetwork.AnExtraBigTC7 = OT;
                }
                if (ON.Contains("C8"))
                {
                    DutvutanianNetwork.AnExtraBigTC4 = OT;
                }
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
            if (this.PissedAtTC2 > 1)
            {
                if (ON.Contains("TC2"))
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
            if (this.PissedAtTC3 > 1)
            {
                if (ON.Contains("TC3"))
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
                if (this.Dist > 330)
                {
                    if (this.Vel < 20)
                    {
                        this.Gun1.Fire();
                        this.Gun1.gunTarget = this.target;
                    }
                }
                else
                {
                    this.Gun1Sec.Fire();
                    this.Gun1Sec.gunTarget = this.target;
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
            this.Dist = Mathf.Clamp(Dist1, 4, 2048);
            this.TargetTrace.LookAt(this.target);
            this.TargetLead.position = this.TargetTrace.position;
            this.TargetLead.rotation = this.TargetTrace.rotation;
            if (this.Dist < 330)
            {
                this.TargetLead.position = this.TargetLead.position + (((this.TargetLead.forward * Dist1) * Dist2) * 0.02f);
            }
            this.TargetLead.position = this.TargetLead.position + (((this.TargetLead.forward * Dist1) * Dist2) * 0.005f);
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
        Vector3 closest = default(Vector3);
        this.inView = false;
        if (this.target)
        {
            this.targetDist = this.Dist;
            if (!this.Attacking)
            {
                if (DutvutanianNetwork.TC1CriminalLevel > 150)
                {
                    this.PissedAtTC1 = DutvutanianNetwork.TC1CriminalLevel;
                    if (DutvutanianNetwork.instance.EnemyTargetMin)
                    {
                        if (DutvutanianNetwork.instance.EnemyTargetMin.name.Contains("TC1"))
                        {
                            if (Vector3.Distance(DutvutanianNetwork.instance.EnemyTargetMin.position, this.thisTransform.position) < 1500)
                            {
                                this.target = DutvutanianNetwork.instance.EnemyTargetMin;
                                this.Attacking = true;
                                this.Hunting = false;
                            }
                        }
                    }
                }
                if (DutvutanianNetwork.TC2CriminalLevel > 150)
                {
                    this.PissedAtTC2 = DutvutanianNetwork.TC2CriminalLevel;
                    if (DutvutanianNetwork.instance.EnemyTargetMin)
                    {
                        if (DutvutanianNetwork.instance.EnemyTargetMin.name.Contains("TC2"))
                        {
                            if (Vector3.Distance(DutvutanianNetwork.instance.EnemyTargetMin.position, this.thisTransform.position) < 1500)
                            {
                                this.target = DutvutanianNetwork.instance.EnemyTargetMin;
                                this.Attacking = true;
                                this.Hunting = false;
                            }
                        }
                    }
                }
                if (DutvutanianNetwork.TC3CriminalLevel > 150)
                {
                    this.PissedAtTC3 = DutvutanianNetwork.TC3CriminalLevel;
                    if (DutvutanianNetwork.instance.EnemyTargetMin)
                    {
                        if (DutvutanianNetwork.instance.EnemyTargetMin.name.Contains("TC3"))
                        {
                            if (Vector3.Distance(DutvutanianNetwork.instance.EnemyTargetMin.position, this.thisTransform.position) < 1500)
                            {
                                this.target = DutvutanianNetwork.instance.EnemyTargetMin;
                                this.Attacking = true;
                                this.Hunting = false;
                            }
                        }
                    }
                }
                if (DutvutanianNetwork.TC4CriminalLevel > 150)
                {
                    this.PissedAtTC4 = DutvutanianNetwork.TC4CriminalLevel;
                    if (DutvutanianNetwork.instance.EnemyTargetMin)
                    {
                        if (DutvutanianNetwork.instance.EnemyTargetMin.name.Contains("TC4"))
                        {
                            if (Vector3.Distance(DutvutanianNetwork.instance.EnemyTargetMin.position, this.thisTransform.position) < 1500)
                            {
                                this.target = DutvutanianNetwork.instance.EnemyTargetMin;
                                this.Attacking = true;
                                this.Hunting = false;
                            }
                        }
                    }
                }
                if (DutvutanianNetwork.TC5CriminalLevel > 150)
                {
                    this.PissedAtTC5 = DutvutanianNetwork.TC5CriminalLevel;
                    if (DutvutanianNetwork.instance.EnemyTargetMin)
                    {
                        if (DutvutanianNetwork.instance.EnemyTargetMin.name.Contains("TC5"))
                        {
                            if (Vector3.Distance(DutvutanianNetwork.instance.EnemyTargetMin.position, this.thisTransform.position) < 1500)
                            {
                                this.target = DutvutanianNetwork.instance.EnemyTargetMin;
                                this.Attacking = true;
                                this.Hunting = false;
                            }
                        }
                    }
                }
                if (DutvutanianNetwork.TC6CriminalLevel > 150)
                {
                    this.PissedAtTC6 = DutvutanianNetwork.TC6CriminalLevel;
                    if (DutvutanianNetwork.instance.EnemyTargetMin)
                    {
                        if (DutvutanianNetwork.instance.EnemyTargetMin.name.Contains("TC6"))
                        {
                            if (Vector3.Distance(DutvutanianNetwork.instance.EnemyTargetMin.position, this.thisTransform.position) < 1500)
                            {
                                this.target = DutvutanianNetwork.instance.EnemyTargetMin;
                                this.Attacking = true;
                                this.Hunting = false;
                            }
                        }
                    }
                }
                if (DutvutanianNetwork.TC7CriminalLevel > 150)
                {
                    this.PissedAtTC7 = DutvutanianNetwork.TC7CriminalLevel;
                    if (DutvutanianNetwork.instance.EnemyTargetMin)
                    {
                        if (DutvutanianNetwork.instance.EnemyTargetMin.name.Contains("TC7"))
                        {
                            if (Vector3.Distance(DutvutanianNetwork.instance.EnemyTargetMin.position, this.thisTransform.position) < 1500)
                            {
                                this.target = DutvutanianNetwork.instance.EnemyTargetMin;
                                this.Attacking = true;
                                this.Hunting = false;
                            }
                        }
                    }
                }
                if (DutvutanianNetwork.TC8CriminalLevel > 150)
                {
                    this.PissedAtTC8 = DutvutanianNetwork.TC8CriminalLevel;
                    if (DutvutanianNetwork.instance.EnemyTargetMin)
                    {
                        if (DutvutanianNetwork.instance.EnemyTargetMin.name.Contains("TC8"))
                        {
                            if (Vector3.Distance(DutvutanianNetwork.instance.EnemyTargetMin.position, this.thisTransform.position) < 1500)
                            {
                                this.target = DutvutanianNetwork.instance.EnemyTargetMin;
                                this.Attacking = true;
                                this.Hunting = false;
                            }
                        }
                    }
                }
            }
            if (this.PissedAtTC1 > 0)
            {
                this.PissedAtTC1 = this.PissedAtTC1 - 1;
            }
            if (this.PissedAtTC2 > 0)
            {
                this.PissedAtTC2 = this.PissedAtTC2 - 1;
            }
            if (this.PissedAtTC3 > 0)
            {
                this.PissedAtTC3 = this.PissedAtTC3 - 1;
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
            if (!this.Watch)
            {
                this.Obstacle = false;
            }
            if (this.Attacking)
            {
                if (this.target.name.Contains("TC"))
                {
                    DutvutanianNetwork.instance.EnemyTargetMin = this.target;
                    DutvutanianNetwork.instance.PriorityWaypoint.position = this.target.position;
                }
            }
            this.viewPoint.LookAt(this.target);
            Debug.DrawRay(this.viewPoint.position, this.viewPoint.forward * this.Dist, Color.red);
            if (Physics.Raycast(this.viewPoint.position, this.viewPoint.forward, out hitV, this.Dist, (int) this.TtargetLayers))
            {
                if (hitV.collider.name.Contains("TL9") || hitV.collider.name.Contains("TC"))
                {
                    if (!Physics.Raycast(this.viewPoint.position, this.viewPoint.forward, this.Dist, (int) this.MtargetLayers))
                    {
                        if (this.Dist < 1000)
                        {
                            this.inView = true;
                        }
                    }
                }
            }
            if (this.target.name.Contains("sT"))
            {
                this.FoundSmall = true;
                if (this.Dist < 64)
                {
                    this.inView = false;
                }
            }
            if (this.target.name.Contains("mT"))
            {
                this.FoundMedium = true;
                if (this.Dist < 128)
                {
                    this.inView = false;
                }
            }
            if (this.target.name.Contains("bT"))
            {
                this.FoundBig = true;
                DutvutanianNetwork.instance.EnemyTargetMed = this.target;
                if (this.Dist < 128)
                {
                    this.inView = false;
                }
            }
            if (this.target.name.Contains("xbT"))
            {
                if (this.Dist < 330)
                {
                    this.inView = false;
                }
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

            {
                float _1974 = this.Trig.size.x + 200;
                Vector3 _1975 = this.Trig.size;
                _1975.x = _1974;
                this.Trig.size = _1975;
            }
            if (this.Trig.size.x > 1024)
            {
                this.Trig.size = new Vector3(300, 300, 3000);
            }
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
        ////////////////////////////////////////////////////////////////////////////
        ////////////////////////////[VICINITY_CHECKER]//////////////////////////////
        ////////////////////////////////////////////////////////////////////////////
        GameObject[] gos = null;
        gos = GameObject.FindGameObjectsWithTag("TC");
        float distance = Mathf.Infinity;
        Vector3 position = this.transform.position;
        closest = new Vector3(0, 0, 1000000);
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go.transform.position;
                distance = curDistance;
            }
        }
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
                if (!this.Wall && (this.Unsticking > 6))
                {
                    this.Unsticking = this.Unsticking - 1;
                }
                Debug.DrawRay(this.thisTransform.position + (-this.thisTransform.up * 10), -this.thisTransform.forward * 64, Color.white);
                if (Physics.Raycast(this.thisTransform.position + (-this.thisTransform.up * 10), -this.thisTransform.forward, 64, (int) this.targetLayers))
                {
                    this.Unsticking = 16;
                }
            }
            if (this.Unsticking > 3)
            {
                this.Stuck = false;
                this.TurnRight = false;
                this.TurnLeft = false;
                this.Unsticking = 0;
            }
            if (this.StuckTimer > 3)
            {
                this.Stuck = false;
                this.TurnRight = false;
                this.TurnLeft = false;
                if (Vector3.Distance(this.thisTransform.position, this.lastPos) < 4)
                {
                    this.Stuck = true;
                }
                this.lastPos = this.thisTransform.position;
                this.StuckTimer = 0;
            }
        }
    }

    public virtual IEnumerator DSReset()
    {
        yield return new WaitForSeconds(0.2f);
        this.DangerSense = false;
        yield return new WaitForSeconds(2);
        this.CanDangerSense = true;
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

    public DutvutanianPoliceAIBU()
    {
        this.RightDist = 200;
        this.LeftDist = 200;
        this.LeadMod2 = 0.005f;
    }

}