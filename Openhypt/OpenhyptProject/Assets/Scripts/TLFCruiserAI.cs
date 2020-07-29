using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class TLFCruiserAI : MonoBehaviour
{
    public Transform target;
    public Transform Waypoint;
    public Transform Stranger;
    public Transform TargetTrace;
    public Transform TargetLead;
    public SphereCollider TLCol;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public Transform ResetAimpoint;
    public Transform topPoint;
    public Transform AIAnchor;
    public GameObject MissileAmmo;
    public GameObject MissileAmmo2;
    public Transform Missile1;
    public Transform Missile2;
    public Transform Missile3;
    public Transform Missile4;
    public Transform Missile5;
    public Transform Missile6;
    public Transform Missile7;
    public Transform Missile8;
    public GameObject Missile7GO;
    public GameObject Missile8GO;
    public Transform Turret1TF;
    public Rigidbody Turret1RB;
    public NPCGun Gun1;
    public BoxCollider Trig;
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
    public bool Hunting;
    public bool Watch;
    public bool Attacking;
    public bool Obstacle;
    public bool Stuck;
    public int StuckTimer;
    public int Unsticking;
    public Vector3 lastPos;
    public bool OnHull;
    public bool TurnRight;
    public bool TurnLeft;
    public int TurnForce;
    public float AimSpeed;
    public float AimForce;
    public float VarAimForce;
    public float RPClamp;
    public float RPMod;
    public Vector3 RelativeTarget;
    public Vector3 RelPoint;
    public float Vert;
    public float Hori;
    public HingeJoint TraverseJoint;
    public HingeJoint ElevationJoint;
    public float TurretAntiSpin;
    public AnimationCurve BallisticsCurve;
    public float RightDist;
    public float LeftDist;
    public float RRUP;
    public int AngClamp;
    public bool Wall;
    public bool RWall;
    public bool LWall;
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
    public bool Orbit;
    public bool FarFromTarget;
    public int Ignorage;
    public int shotAssumption;
    public bool canLaunch;
    public int StoredMissileBatches;
    public int StoredMissileBatches2;
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
            }
            if (this.target == null)
            {
                this.target = this.ResetAimpoint;
                this.Attacking = false;
                this.Hunting = true;
                this.FoundSmall = false;
                this.FoundMedium = false;
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
            }
        }
        this.TurnForce = 0;
        if (!this.Obstacle && !this.Stuck)
        {
            this.TurnRight = false;
            this.TurnLeft = false;
        }
        this.localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
        this.Vel = this.vRigidbody.velocity.magnitude;
        this.VelDir = this.vRigidbody.velocity;
        if (this.target)
        {
            this.RelativeTarget = this.thisTransform.InverseTransformPoint(this.target.position);
        }
        if (!this.Orbit)
        {
            this.RPMod = this.RelativeTarget.x * 500;
            this.RPClamp = Mathf.Clamp(this.RPMod, -100000, 100000);
        }
        else
        {
            if (this.Attacking)
            {
                this.RPMod = this.RelativeTarget.z * 500;
                this.RPClamp = Mathf.Clamp(this.RPMod, -100000, 100000);
            }
        }
        if (this.RRUP < 40)
        {
            this.RRUP = this.RRUP + 4;
        }
        else
        {
            this.RRUP = 2;
        }
        Vector3 newRot = ((-this.thisVTransform.up * 2) + (this.thisVTransform.right * -1)).normalized;
        float VelClamp = Mathf.Clamp(this.Vel * 8, 150, 600);
        float VelClamp2 = Mathf.Clamp(this.Vel * 4, 75, 300);
        this.AngClamp = (int) Mathf.Clamp(this.Vel * 0.1f, 4, 16);
        float DMod1 = 160 - this.Vel;
        float DMod = Mathf.Clamp(DMod1, 1, 160);
        Debug.DrawRay(this.thisTransform.position + (-this.thisTransform.up * 10), this.thisTransform.forward * VelClamp, Color.white);
        if (Physics.Raycast(this.thisTransform.position + (-this.thisTransform.up * 10), this.thisTransform.forward, out hit1, VelClamp, (int) this.targetLayers))
        {
            this.Pointu = hit1.point;
        }
        else
        {
            this.Pointu = new Vector3(2, 2, 2);
        }
        Debug.DrawRay(this.thisTransform.position + (-this.thisTransform.up * 11), this.thisTransform.forward * VelClamp, Color.white);
        if (Physics.Raycast(this.thisTransform.position + (-this.thisTransform.up * 11), this.thisTransform.forward, out hit2, VelClamp, (int) this.targetLayers))
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
        if (!this.OnHull && !this.Watch)
        {
            this.Obstacle = false;
        }
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * 35)) + (this.thisTransform.up * 16), this.thisTransform.forward * VelClamp, Color.green);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * 35)) + (this.thisTransform.up * 16), this.thisTransform.forward, out hit, VelClamp, (int) this.targetLayers))
        {
            this.Wall = true;
        }
        newRot = ((-this.thisVTransform.up * 2) + (this.thisVTransform.right * 1)).normalized;
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.right * 32)) + (-this.thisTransform.up * 8), newRot * VelClamp2, Color.green);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.right * 32)) + (-this.thisTransform.up * 8), newRot, out hit, VelClamp2, (int) this.targetLayers))
        {
            float UpDist = hit.distance;
            Debug.DrawRay((this.thisTransform.position + (this.thisTransform.right * 32)) + (-this.thisTransform.up * 7.5f), newRot * VelClamp2, Color.green);
            if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.right * 32)) + (-this.thisTransform.up * 7.5f), newRot, out hit, VelClamp2, (int) this.targetLayers))
            {
                if (this.Wall)
                {
                    this.Obstacle = true;
                }
                else
                {
                    float AngleR = Mathf.Abs(UpDist - hit.distance);
                    if (AngleR < 2)
                    {
                        this.TurnLeft = true;
                    }
                }
            }
        }
        newRot = ((-this.thisVTransform.up * 2) + (-this.thisVTransform.right * 1)).normalized;
        Debug.DrawRay((this.thisTransform.position + (-this.thisTransform.right * 32)) + (-this.thisTransform.up * 8), newRot * VelClamp2, Color.green);
        if (Physics.Raycast((this.thisTransform.position + (-this.thisTransform.right * 32)) + (-this.thisTransform.up * 8), newRot, out hit, VelClamp2, (int) this.targetLayers))
        {
            float UpDist = hit.distance;
            Debug.DrawRay((this.thisTransform.position + (-this.thisTransform.right * 32)) + (-this.thisTransform.up * 7.5f), newRot * VelClamp2, Color.green);
            if (Physics.Raycast((this.thisTransform.position + (-this.thisTransform.right * 32)) + (-this.thisTransform.up * 7.5f), newRot, out hit, VelClamp2, (int) this.targetLayers))
            {
                if (this.Wall)
                {
                    this.Obstacle = true;
                }
                else
                {
                    float AngleL = Mathf.Abs(UpDist - hit.distance);
                    if (AngleL < 2)
                    {
                        this.TurnRight = true;
                    }
                }
            }
        }
        Debug.DrawRay((this.thisTransform.position + (this.thisVTransform.right * this.RRUP)) + (-this.thisVTransform.up * 64), -this.thisVTransform.up * 256, Color.green);
        if (Physics.Raycast((this.thisTransform.position + (this.thisVTransform.right * this.RRUP)) + (-this.thisVTransform.up * 64), -this.thisVTransform.up, out hit, 256, (int) this.targetLayers))
        {
            this.Obstacle = true;
            this.TurnLeft = true;
        }
        Debug.DrawRay((this.thisTransform.position + (-this.thisVTransform.right * this.RRUP)) + (-this.thisVTransform.up * 64), -this.thisVTransform.up * 256, Color.green);
        if (Physics.Raycast((this.thisTransform.position + (-this.thisVTransform.right * this.RRUP)) + (-this.thisVTransform.up * 64), -this.thisVTransform.up, 256, (int) this.targetLayers))
        {
            this.Obstacle = true;
            this.TurnRight = true;
        }
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 10), this.thisTransform.forward * VelClamp, Color.black);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 10), this.thisTransform.forward, out hit1, VelClamp, (int) this.targetLayers))
        {
            this.RPointu = hit1.point;
        }
        else
        {
            this.RPointu = new Vector3(2, 2, 2);
        }
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 11), this.thisTransform.forward * VelClamp, Color.black);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 11), this.thisTransform.forward, out hit2, VelClamp, (int) this.targetLayers))
        {
            this.RPointd = hit2.point;
            this.RightDist = hit2.distance;
        }
        else
        {
            this.RPointd = new Vector3(8, 8, 8);
            this.RightDist = 512;
        }
        if (Vector3.Distance(this.RPointu, this.RPointd) < 2)
        {
            this.RWall = true;
        }
        Debug.DrawRay((this.thisTransform.position + (-this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 10), this.thisTransform.forward * VelClamp, Color.black);
        if (Physics.Raycast((this.thisTransform.position + (-this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 10), this.thisTransform.forward, out hit1, VelClamp, (int) this.targetLayers))
        {
            this.LPointu = hit1.point;
        }
        else
        {
            this.LPointu = new Vector3(2, 2, 2);
        }
        Debug.DrawRay((this.thisTransform.position + (-this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 11), this.thisTransform.forward * VelClamp, Color.black);
        if (Physics.Raycast((this.thisTransform.position + (-this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 11), this.thisTransform.forward, out hit2, VelClamp, (int) this.targetLayers))
        {
            this.LPointd = hit2.point;
            this.LeftDist = hit2.distance;
        }
        else
        {
            this.LPointd = new Vector3(8, 8, 8);
            this.LeftDist = 512;
        }
        if (Vector3.Distance(this.LPointu, this.LPointd) < 2)
        {
            this.LWall = true;
        }
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.up * 70)) + (this.thisTransform.forward * VelClamp), -this.thisTransform.up * DMod, Color.white);
        if (!Physics.Raycast((this.thisTransform.position + (this.thisTransform.up * 70)) + (this.thisTransform.forward * VelClamp), -this.thisTransform.up, DMod))
        {
            this.Obstacle = true;
        }
        //---------------------------------------------------------------------------------------------
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.up * 80)) + (this.thisTransform.right * 40)) + (this.thisTransform.forward * VelClamp), this.thisTransform.up * -160, Color.white);
        if (!Physics.Raycast(((this.thisTransform.position + (this.thisTransform.up * 80)) + (this.thisTransform.right * 40)) + (this.thisTransform.forward * VelClamp), -this.thisTransform.up, 160))
        {
            this.TurnLeft = true;
        }
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.up * 80)) + (-this.thisTransform.right * 40)) + (this.thisTransform.forward * VelClamp), this.thisTransform.up * -160, Color.white);
        if (!Physics.Raycast(((this.thisTransform.position + (this.thisTransform.up * 80)) + (-this.thisTransform.right * 40)) + (this.thisTransform.forward * VelClamp), -this.thisTransform.up, 160))
        {
            this.TurnRight = true;
        }
        //---------------------------------------------------------------------------------------------
        if (this.RightDist > this.LeftDist)
        {
            if (Vector3.Distance(this.LPointu, this.LPointd) < 4)
            {
                this.TurnRight = true;
            }
        }
        if (this.LeftDist > this.RightDist)
        {
            if (Vector3.Distance(this.RPointu, this.RPointd) < 4)
            {
                this.TurnLeft = true;
            }
        }
        if ((this.LeftDist < 80) && this.LWall)
        {
            this.Obstacle = true;
        }
        if ((this.RightDist < 80) && this.RWall)
        {
            this.Obstacle = true;
        }
        if ((this.TurnRight && this.TurnLeft) && this.Obstacle)
        {
            this.TurnForce = -80000;
        }
        if (!this.Stuck)
        {
            if (this.TurnLeft)
            {
                this.TurnForce = -200000;
            }
            if (this.TurnRight)
            {
                this.TurnForce = 200000;
            }
        }
        else
        {
            if (this.RelativeTarget.x > 0)
            {
                this.TurnForce = -200000;
            }
            else
            {
                this.TurnForce = 200000;
            }
        }
    }

    public virtual void FixedUpdate()//}
    {
        if (this.targetDist < 400)
        {
            this.Obstacle = true;
            this.TurnLeft = false;
            this.TurnRight = false;
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
            if (-this.localV.y > 0)
            {
                this.vRigidbody.AddForce(-this.thisVTransform.up * -24000);
            }
        }
        if (this.Stuck)
        {
            if (this.localV.y < 8)
            {
                this.vRigidbody.AddForce(this.thisVTransform.up * 16000);
            }
        }
        if (((!this.Obstacle && !this.Stuck) && !this.TurnLeft) && !this.TurnRight)
        {
            if (-this.localV.y < 120)
            {
                if (this.FarFromTarget)
                {
                    this.vRigidbody.AddForce(-this.thisVTransform.up * 24000);
                }
                else
                {
                    this.vRigidbody.AddForce(-this.thisVTransform.up * 16000);
                }
            }
        }
        Vector3 localAV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.angularVelocity);
        float AntiSpin = localAV.z * 60;
        if (this.target)
        {
            this.targetDist = Vector3.Distance(this.transform.position, this.target.position);
            if (this.Attacking)
            {
                this.RelPoint = this.Turret1TF.InverseTransformPoint(this.TargetLead.position);
            }
            else
            {
                this.RelPoint = this.Turret1TF.InverseTransformPoint(this.ResetAimpoint.position);
            }
            this.Vert = (-this.RelPoint.z * this.VarAimForce) / this.targetDist;
            this.Hori = (this.RelPoint.x * this.VarAimForce) / this.targetDist;

            {
                float _3658 = this.Vert;
                JointMotor _3659 = this.ElevationJoint.motor;
                _3659.targetVelocity = _3658;
                this.ElevationJoint.motor = _3659;
            }

            {
                float _3660 = this.Hori - AntiSpin;
                JointMotor _3661 = this.TraverseJoint.motor;
                _3661.targetVelocity = _3660;
                this.TraverseJoint.motor = _3661;
            }
            if (this.Turret1RB.angularVelocity.magnitude < 0.8f)
            {
                this.VarAimForce = this.AimForce;
            }
            else
            {
                this.VarAimForce = 0;

                {
                    int _3662 = 0;
                    JointMotor _3663 = this.ElevationJoint.motor;
                    _3663.targetVelocity = _3662;
                    this.ElevationJoint.motor = _3663;
                }

                {
                    int _3664 = 0;
                    JointMotor _3665 = this.TraverseJoint.motor;
                    _3665.targetVelocity = _3664;
                    this.TraverseJoint.motor = _3665;
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
                    if (this.shotAssumption > 0)
                    {
                        return;
                    }
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
                if (other.GetComponent<Rigidbody>())
                {
                    this.Waypoint.position = OT.position;
                    this.DangerSense = true;
                    this.thisTransform.LookAt(this.Waypoint);
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
            if (this.PissedAtTC0a > 1)
            {
                if (ON.Contains("TC0a"))
                {
                    if (((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || ON.Contains("bT"))
                    {
                        this.Hunting = false;
                        this.target = OT;
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
            if (!this.Gun1)
            {
                this.Gun1.Fire();
                this.Gun1.gunTarget = this.target;
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

    public virtual void Launchy2()
    {
        if (this.Attacking && this.target)
        {
            this.StartCoroutine(this.LaunchSM2());
        }
    }

    public virtual IEnumerator LaunchSM2()
    {
        if (this.target != null)
        {
            if ((this.Attacking && (this.StoredMissileBatches2 > 0)) && this.canLaunch)
            {
                if (this.targetDist < 150)
                {
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
                    this.StoredMissileBatches2 = this.StoredMissileBatches2 - 1;
                    this.Missile7GO = UnityEngine.Object.Instantiate(this.MissileAmmo2, this.Missile7.position, this.Missile7.rotation);
                    this.Missile7GO.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                    ((MissileScript) this.Missile7GO.transform.GetComponent(typeof(MissileScript))).target = this.target;
                    yield return new WaitForSeconds(0.5f);
                    this.Missile8GO = UnityEngine.Object.Instantiate(this.MissileAmmo2, this.Missile8.position, this.Missile8.rotation);
                    this.Missile8GO.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                    ((MissileScript) this.Missile8GO.transform.GetComponent(typeof(MissileScript))).target = this.target;
                }
            }
        }
    }

    public virtual IEnumerator LaunchSM()
    {
        if (this.target != null)
        {
            Vector3 Measure = this.thisVTransform.InverseTransformPoint(this.target.position);
            if ((this.Attacking && (this.StoredMissileBatches > 0)) && this.canLaunch)
            {
                if ((this.targetDist < 1200) && (this.targetDist > 150))
                {
                    if (((Measure.y < 0) && (-this.localV.y > 17)) && (this.targetDist < 300))
                    {
                        yield break;
                    }
                    if (this.Missile7GO)
                    {
                        if (!this.Missile7GO.name.Contains("br"))
                        {
                            yield break;
                        }
                    }
                    if (this.Missile8GO)
                    {
                        if (!this.Missile8GO.name.Contains("br"))
                        {
                            yield break;
                        }
                    }
                    this.StoredMissileBatches = this.StoredMissileBatches - 1;
                    GameObject _SpawnedObject1 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile1.position, this.Missile1.rotation);
                    _SpawnedObject1.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                    ((MissileScript) _SpawnedObject1.transform.GetComponent(typeof(MissileScript))).target = this.target;
                    yield return new WaitForSeconds(0.3f);
                    GameObject _SpawnedObject2 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile2.position, this.Missile2.rotation);
                    _SpawnedObject2.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                    ((MissileScript) _SpawnedObject2.transform.GetComponent(typeof(MissileScript))).target = this.target;
                    yield return new WaitForSeconds(0.3f);
                    GameObject _SpawnedObject3 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile3.position, this.Missile3.rotation);
                    _SpawnedObject3.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                    ((MissileScript) _SpawnedObject3.transform.GetComponent(typeof(MissileScript))).target = this.target;
                    yield return new WaitForSeconds(3);
                }
            }
        }
        if (this.target != null)
        {
            Vector3 Measure = this.thisVTransform.InverseTransformPoint(this.target.position);
            if ((this.Attacking && (this.StoredMissileBatches > 0)) && this.canLaunch)
            {
                if ((this.targetDist < 1200) && (this.targetDist > 150))
                {
                    if (((Measure.y < 0) && (-this.localV.y > 17)) && (this.targetDist < 300))
                    {
                        yield break;
                    }
                    if (this.Missile7GO)
                    {
                        if (!this.Missile7GO.name.Contains("br"))
                        {
                            yield break;
                        }
                    }
                    if (this.Missile8GO)
                    {
                        if (!this.Missile8GO.name.Contains("br"))
                        {
                            yield break;
                        }
                    }
                    this.StoredMissileBatches = this.StoredMissileBatches - 1;
                    GameObject _SpawnedObject4 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile4.position, this.Missile4.rotation);
                    _SpawnedObject4.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                    ((MissileScript) _SpawnedObject4.transform.GetComponent(typeof(MissileScript))).target = this.target;
                    yield return new WaitForSeconds(0.3f);
                    GameObject _SpawnedObject5 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile5.position, this.Missile5.rotation);
                    _SpawnedObject5.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                    ((MissileScript) _SpawnedObject5.transform.GetComponent(typeof(MissileScript))).target = this.target;
                    yield return new WaitForSeconds(0.3f);
                    GameObject _SpawnedObject6 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile6.position, this.Missile6.rotation);
                    _SpawnedObject6.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                    ((MissileScript) _SpawnedObject6.transform.GetComponent(typeof(MissileScript))).target = this.target;
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
            float Dist2 = Vector3.Distance(this.TargetTrace.position, this.target.position);
            this.TargetTrace.LookAt(this.target);
            this.TargetLead.position = this.TargetTrace.position;
            this.TargetLead.rotation = this.TargetTrace.rotation;
            this.TargetLead.position = this.TargetLead.position + (((this.TargetLead.forward * this.targetDist) * Dist2) * 0.015f);
            if (this.VelDir != Vector3.zero)
            {
                this.TargetLead.rotation = Quaternion.LookRotation(this.VelDir);
            }
            this.TargetLead.position = this.TargetLead.position - ((this.TargetLead.forward * this.Vel) * this.LeadMod2);
            float Elev = this.BallisticsCurve.Evaluate(this.targetDist);
            this.TargetLead.position = this.TargetLead.position + (this.TargetLead.up * Elev);
            //TargetLead.position += TargetLead.up * targetDist * 0.007;
            if (this.Attacking)
            {
                this.TLCol.radius = this.targetDist * 0.01f;
            }
            else
            {
                this.TLCol.radius = 0.1f;
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
        this.Waypoint.transform.position = TerrahyptianNetwork.instance.PriorityWaypoint.position;
        this.target = this.Waypoint;
        yield return new WaitForSeconds(5);
        if (!this.Attacking)
        {
            this.target = this.ResetAimpoint;
        }
    }

    public virtual void Regenerator()
    {
        if (this.target)
        {
            if (TerrahyptianNetwork.TC1CriminalLevel > 10)
            {
                this.PissedAtTC1 = TerrahyptianNetwork.TC1CriminalLevel;
                if (this.target.name.Contains("TC1"))
                {
                    this.Attacking = true;
                    this.Hunting = false;
                }
            }
            if (TerrahyptianNetwork.TC4CriminalLevel > 10)
            {
                this.PissedAtTC4 = TerrahyptianNetwork.TC4CriminalLevel;
                if (this.target.name.Contains("TC4"))
                {
                    this.Attacking = true;
                    this.Hunting = false;
                }
            }
            if (TerrahyptianNetwork.TC5CriminalLevel > 10)
            {
                this.PissedAtTC5 = TerrahyptianNetwork.TC5CriminalLevel;
                if (this.target.name.Contains("TC5"))
                {
                    this.Attacking = true;
                    this.Hunting = false;
                }
            }
            if (TerrahyptianNetwork.TC6CriminalLevel > 10)
            {
                this.PissedAtTC6 = TerrahyptianNetwork.TC6CriminalLevel;
                if (this.target.name.Contains("TC6"))
                {
                    this.Attacking = true;
                    this.Hunting = false;
                }
            }
            if (TerrahyptianNetwork.TC7CriminalLevel > 10)
            {
                this.PissedAtTC7 = TerrahyptianNetwork.TC7CriminalLevel;
                if (this.target.name.Contains("TC7"))
                {
                    this.Attacking = true;
                    this.Hunting = false;
                }
            }
            if (TerrahyptianNetwork.TC8CriminalLevel > 10)
            {
                this.PissedAtTC8 = TerrahyptianNetwork.TC8CriminalLevel;
                if (this.target.name.Contains("TC8"))
                {
                    this.Attacking = true;
                    this.Hunting = false;
                }
            }
            if (TerrahyptianNetwork.TC9CriminalLevel > 10)
            {
                this.PissedAtTC9 = TerrahyptianNetwork.TC9CriminalLevel;
                if (this.target.name.Contains("TC9"))
                {
                    this.Attacking = true;
                    this.Hunting = false;
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
            if (this.target.name.Contains("broken"))
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
                this.StuckTimer = 0;
                this.Stuck = false;
                this.canLaunch = true;
            }
            else
            {
                this.canLaunch = false;
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
                TerrahyptianNetwork.instance.EnemyTarget2 = this.target;
                this.FoundSmall = true;
                this.FoundMedium = true;
                this.Gun1.TargetRange = 3000;
            }
            else
            {
                this.Gun1.TargetRange = 1500;
            }
            if (this.targetDist > 750)
            {
                this.FarFromTarget = true;
            }
            else
            {
                if (!this.target.name.Contains("bT"))
                {
                    this.FarFromTarget = false;
                }
            }
            this.Orbit = false;
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
                if (this.targetDist < 500)
                {
                    this.Orbit = true;
                }
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
        }
        if (this.Ignorage > 4)
        {
            this.Ignorage = 0;
            this.target = null;
        }
        if (this.OnHull)
        {
            this.OnHull = false;
            this.Obstacle = true;
        }
        if (this.shotAssumption > 0)
        {
            this.shotAssumption = this.shotAssumption - 1;
        }
        this.DangerSense = false;
        this.Wall = false;
        this.RWall = false;
        this.LWall = false;
        if (this.Watch)
        {
            this.Obstacle = true;
            this.TurnRight = false;
            this.TurnLeft = false;
        }
        ////////////////////////////////////////////////////////////////////////////
        //////////////////////////////[STUCKAROONIES]///////////////////////////////
        ////////////////////////////////////////////////////////////////////////////
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
            if (!this.Wall && (this.Unsticking > 12))
            {
                this.Unsticking = this.Unsticking - 1;
            }
            Debug.DrawRay(this.thisTransform.position + (-this.thisTransform.up * 10), -this.thisTransform.forward * 64, Color.white);
            if (Physics.Raycast(this.thisTransform.position + (-this.thisTransform.up * 10), -this.thisTransform.forward, 64, (int) this.targetLayers))
            {
                this.Unsticking = 16;
            }
        }
        if (this.Unsticking > 15)
        {
            this.Stuck = false;
            this.TurnRight = false;
            this.TurnLeft = false;
            this.Unsticking = 0;
        }
        if (this.StuckTimer > 15)
        {
            this.Stuck = false;
            this.TurnRight = false;
            this.TurnLeft = false;
            if (Vector3.Distance(this.thisTransform.position, this.lastPos) < 100)
            {
                this.Stuck = true;
            }
            this.lastPos = this.thisTransform.position;
            this.StuckTimer = 0;
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

    public virtual void Start()
    {
        this.InvokeRepeating("Regenerator", 1, 1);
        this.InvokeRepeating("Shooty", Random.Range(2, 3), 0.2f);
        this.InvokeRepeating("Launchy", 1, 7);
        this.InvokeRepeating("Launchy2", 1, 1.5f);
        this.InvokeRepeating("CalcLead", 1, 0.15f);
        this.InvokeRepeating("Targety", 10, 15);
    }

    public TLFCruiserAI()
    {
        this.TurretAntiSpin = 2;
        this.BallisticsCurve = new AnimationCurve();
        this.RightDist = 200;
        this.LeftDist = 200;
        this.AngClamp = 2;
        this.LeadMod2 = 0.005f;
        this.StoredMissileBatches = 30;
        this.StoredMissileBatches2 = 60;
    }

}