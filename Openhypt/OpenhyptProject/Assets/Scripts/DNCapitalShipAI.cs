using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class DNCapitalShipAI : MonoBehaviour
{
    public Transform target;
    public Transform Forward;
    public Transform Waypoint;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Transform thisParent;
    public Rigidbody vRigidbody;
    public Transform TargetTrace;
    public Transform TargetLead;
    public SphereCollider TLCol;
    public AnimationCurve LeadCurve;
    public float LeadAmount;
    public Transform PDTurretSpawnF;
    public int PDTurretSpawnFNum;
    public Transform PDTurretSpawn;
    public int PDTurretSpawnNum;
    public Transform PDTurretFR;
    public SurfaceTurretAI PDTurretFRAI;
    public bool PDTurretFRActive;
    public Transform PDTurretFL;
    public SurfaceTurretAI PDTurretFLAI;
    public bool PDTurretFLActive;
    public Transform PDTurretR1;
    public SurfaceTurretAI PDTurretR1AI;
    public bool PDTurretR1Active;
    public Transform PDTurretR2;
    public SurfaceTurretAI PDTurretR2AI;
    public bool PDTurretR2Active;
    public Transform PDTurretL1;
    public SurfaceTurretAI PDTurretL1AI;
    public bool PDTurretL1Active;
    public Transform PDTurretL2;
    public SurfaceTurretAI PDTurretL2AI;
    public bool PDTurretL2Active;
    public Transform PDTurretDR1;
    public SurfaceTurretAI PDTurretDR1AI;
    public bool PDTurretDR1Active;
    public Transform PDTurretDR2;
    public SurfaceTurretAI PDTurretDR2AI;
    public bool PDTurretDR2Active;
    public Transform PDTurretDL1;
    public SurfaceTurretAI PDTurretDL1AI;
    public bool PDTurretDL1Active;
    public Transform PDTurretDL2;
    public SurfaceTurretAI PDTurretDL2AI;
    public bool PDTurretDL2Active;
    public HingeJoint TPivot1HJ;
    public HingeJoint TPivot2HJ;
    public HingeJoint TPivot3HJ;
    public HingeJoint TPivot4HJ;
    public float TPivot1HJTP;
    public float TPivot2HJTP;
    public float TPivot3HJTP;
    public float TPivot4HJTP;
    public Transform Turret1TF;
    public Transform Turret2TF;
    public Transform Turret3TF;
    public Transform Turret4TF;
    public HingeJoint T1ElevationJoint;
    public HingeJoint T2ElevationJoint;
    public HingeJoint T3ElevationJoint;
    public HingeJoint T4ElevationJoint;
    public HingeJoint T1TraverseJoint;
    public HingeJoint T2TraverseJoint;
    public HingeJoint T3TraverseJoint;
    public HingeJoint T4TraverseJoint;
    public NPCGun Gun1;
    public NPCGun Gun2;
    public NPCGun Gun3;
    public NPCGun Gun4;
    public Transform Muzzle1;
    public Transform Muzzle2;
    public Transform Muzzle3;
    public Transform Muzzle4;
    public Transform Gun1Model;
    public Transform Gun2Model;
    public Transform Gun3Model;
    public Transform Gun4Model;
    public bool Gun1Fire;
    public bool Gun2Fire;
    public bool Gun3Fire;
    public bool Gun4Fire;
    public int G1RN;
    public int G2RN;
    public int G3RN;
    public int G4RN;
    public AnimationCurve RecoilCurve;
    public int AngerLevel;
    public int PissedAtTC0a;
    public int PissedAtTC1;
    public int PissedAtTC2;
    public int PissedAtTC3;
    public int PissedAtTC4;
    public int PissedAtTC5;
    public int PissedAtTC6;
    public int PissedAtTC7;
    public int PissedAtTC8;
    public int loops;
    public Transform VicinityPoint;
    public int VPRadius;
    public ParticleSystem VPFX;
    public bool FoundSmall;
    public bool FoundMedium;
    public bool FoundBig;
    public float Dist;
    public bool Attacking;
    public bool OffDuty;
    public bool Obstacle;
    public bool Parked;
    public bool useHullAim;
    public bool TurnRight;
    public bool TurnLeft;
    public bool StrafeRight;
    public bool StrafeLeft;
    public float RightDist;
    public float LeftDist;
    public float RaySpreadMod;
    public float RaySpreadWidth;
    private float RaySpread;
    public float RayLengthObstacle;
    public float RayLengthTurn;
    public int SD; //Front Shaped obstacle circumvent ray : Distance
    public int SDf; //Front Shaped obstacle circumvent ray : Forward Location
    public int SDl; //Front Shaped obstacle circumvent ray : Right Outwards Location
    public int SDr; //Front Shaped obstacle circumvent ray : Left Outwards Location
    public int SDa; //Front Shaped obstacle circumvent ray : Both Rotation Angle
    public int SD2; //Rear Shaped obstacle circumvent ray : Distance
    public int SD2f; //Rear Shaped obstacle circumvent ray : Forward Location
    public int SD2l; //Rear Shaped obstacle circumvent ray : Right Outwards Location
    public int SD2r; //Rear Shaped obstacle circumvent ray : Left Outwards Location
    public int SD2a; //Rear Shaped obstacle circumvent ray : Both Rotation Angle
    public float DirForce;
    public float BrakeForce;
    public float AngForce;
    public float Vel;
    public float VelClampMod;
    public float MaxVel;
    public float RPClamp;
    public float RPClamp2;
    public LayerMask targetLayers;
    public LayerMask targetLayers2;
    public LayerMask targetLayersD;
    public bool Damaged;
    public GameObject CollisionFX;
    public Transform DamageColRayFR;
    public GameObject DamageColRayFRGO;
    public bool FRCollide;
    public Transform DamageColRayFL;
    public GameObject DamageColRayFLGO;
    public bool FLCollide;
    public bool FrontCollide;
    public AudioSource FrontCollideSFX;
    public Transform DamageColRayRR;
    public GameObject DamageColRayRRGO;
    public bool RRCollide;
    public Transform DamageColRayRL;
    public GameObject DamageColRayRLGO;
    public bool RLCollide;
    public bool RearCollide;
    public AudioSource RearCollideSFX;
    public virtual void Start()
    {
        this.InvokeRepeating("Ticker", 1, 1);
        this.InvokeRepeating("CalcLead", 1, 0.15f);
        this.InvokeRepeating("Shooty", 1, 4);
        this.DamageColRayFRGO = this.DamageColRayFR.gameObject;
        this.DamageColRayFLGO = this.DamageColRayFL.gameObject;
        this.DamageColRayRRGO = this.DamageColRayRR.gameObject;
        this.DamageColRayRLGO = this.DamageColRayRL.gameObject;
        if (WorldInformation.instance.AreaSpace)
        {
            this.useHullAim = true;
        }
        else
        {
            this.useHullAim = false;
        }
    }

    public virtual void Update()
    {
        if (this.Damaged)
        {
            return;
        }
        if (this.Attacking)
        {
            if (this.target == this.Waypoint)
            {
                this.target = this.Forward;
                this.Attacking = false;
                //Hunting = true;
                this.FoundSmall = false;
                this.FoundMedium = false;
                this.FoundBig = false;
            }
            if (this.target == null)
            {
                this.target = this.Forward;
                this.Attacking = false;
                //Hunting = true;
                this.FoundSmall = false;
                this.FoundMedium = false;
                this.FoundBig = false;
            }
        }
        else
        {
            if (this.target == null)
            {
                this.target = this.Forward;
                //Hunting = true;
                this.FoundSmall = false;
                this.FoundMedium = false;
                this.FoundBig = false;
            }
        }
    }

    public virtual void FixedUpdate()
    {
        RaycastHit hitD = default(RaycastHit);
        RaycastHit hit = default(RaycastHit);
        Vector3 newRot2 = default(Vector3);
        Vector3 localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
        if (this.Damaged)
        {
            if (!this.FRCollide)
            {
                Debug.DrawRay(this.DamageColRayFR.position + (Vector3.up * 64), -Vector3.up * 64, Color.magenta);
                if (Physics.Raycast(this.DamageColRayFR.position + (Vector3.up * 64), -Vector3.up, out hitD, 64, (int) this.targetLayersD))
                {
                    this.FRCollide = true;
                    Rigidbody theRB1 = this.DamageColRayFRGO.AddComponent<Rigidbody>();
                    theRB1.mass = this.vRigidbody.mass * 0.05f;
                    theRB1.drag = 16;
                    theRB1.useGravity = false;
                    SpringJoint theSpringJoint1 = this.DamageColRayFRGO.AddComponent<SpringJoint>();
                    theSpringJoint1.spring = this.vRigidbody.mass * 0.2f;
                    theSpringJoint1.damper = this.vRigidbody.mass * 0.05f;
                    FixedJoint theFixedJoint1 = this.DamageColRayFRGO.AddComponent<FixedJoint>();
                    theFixedJoint1.connectedBody = this.vRigidbody;
                    SphereCollider theSphereCol1 = this.DamageColRayFRGO.AddComponent<SphereCollider>();
                    theSphereCol1.radius = this.vRigidbody.mass * 0.0005f;
                    Quaternion NormalAngle1 = Quaternion.LookRotation(hitD.normal);
                    UnityEngine.Object.Instantiate(this.CollisionFX, this.DamageColRayFR.position, NormalAngle1);
                }
            }
            if (!this.FLCollide)
            {
                Debug.DrawRay(this.DamageColRayFL.position + (Vector3.up * 64), -Vector3.up * 64, Color.magenta);
                if (Physics.Raycast(this.DamageColRayFL.position + (Vector3.up * 64), -Vector3.up, out hitD, 64, (int) this.targetLayersD))
                {
                    this.FLCollide = true;
                    Rigidbody theRB2 = this.DamageColRayFLGO.AddComponent<Rigidbody>();
                    theRB2.mass = this.vRigidbody.mass * 0.05f;
                    theRB2.drag = 16;
                    theRB2.useGravity = false;
                    SpringJoint theSpringJoint2 = this.DamageColRayFLGO.AddComponent<SpringJoint>();
                    theSpringJoint2.spring = this.vRigidbody.mass * 0.2f;
                    theSpringJoint2.damper = this.vRigidbody.mass * 0.05f;
                    FixedJoint theFixedJoint2 = this.DamageColRayFLGO.AddComponent<FixedJoint>();
                    theFixedJoint2.connectedBody = this.vRigidbody;
                    SphereCollider theSphereCol2 = this.DamageColRayFLGO.AddComponent<SphereCollider>();
                    theSphereCol2.radius = this.vRigidbody.mass * 0.0005f;
                    Quaternion NormalAngle2 = Quaternion.LookRotation(hitD.normal);
                    UnityEngine.Object.Instantiate(this.CollisionFX, this.DamageColRayFL.position, NormalAngle2);
                }
            }
            if (!this.RRCollide)
            {
                Debug.DrawRay(this.DamageColRayRR.position + (Vector3.up * 64), -Vector3.up * 64, Color.magenta);
                if (Physics.Raycast(this.DamageColRayRR.position + (Vector3.up * 64), -Vector3.up, out hitD, 64, (int) this.targetLayersD))
                {
                    this.RRCollide = true;
                    Rigidbody theRB3 = this.DamageColRayRRGO.AddComponent<Rigidbody>();
                    theRB3.mass = this.vRigidbody.mass * 0.05f;
                    theRB3.drag = 16;
                    theRB3.useGravity = false;
                    SpringJoint theSpringJoint3 = this.DamageColRayRRGO.AddComponent<SpringJoint>();
                    theSpringJoint3.spring = this.vRigidbody.mass * 0.2f;
                    theSpringJoint3.damper = this.vRigidbody.mass * 0.05f;
                    FixedJoint theFixedJoint3 = this.DamageColRayRRGO.AddComponent<FixedJoint>();
                    theFixedJoint3.connectedBody = this.vRigidbody;
                    SphereCollider theSphereCol3 = this.DamageColRayRRGO.AddComponent<SphereCollider>();
                    theSphereCol3.radius = this.vRigidbody.mass * 0.0005f;
                    Quaternion NormalAngle3 = Quaternion.LookRotation(hitD.normal);
                    UnityEngine.Object.Instantiate(this.CollisionFX, this.DamageColRayRR.position, NormalAngle3);
                }
            }
            if (!this.RLCollide)
            {
                Debug.DrawRay(this.DamageColRayRL.position + (Vector3.up * 64), -Vector3.up * 64, Color.magenta);
                if (Physics.Raycast(this.DamageColRayRL.position + (Vector3.up * 64), -Vector3.up, out hitD, 64, (int) this.targetLayersD))
                {
                    this.RLCollide = true;
                    Rigidbody theRB4 = this.DamageColRayRLGO.AddComponent<Rigidbody>();
                    theRB4.mass = this.vRigidbody.mass * 0.05f;
                    theRB4.drag = 16;
                    theRB4.useGravity = false;
                    SpringJoint theSpringJoint4 = this.DamageColRayRLGO.AddComponent<SpringJoint>();
                    theSpringJoint4.spring = this.vRigidbody.mass * 0.2f;
                    theSpringJoint4.damper = this.vRigidbody.mass * 0.05f;
                    FixedJoint theFixedJoint4 = this.DamageColRayRLGO.AddComponent<FixedJoint>();
                    theFixedJoint4.connectedBody = this.vRigidbody;
                    SphereCollider theSphereCol4 = this.DamageColRayRLGO.AddComponent<SphereCollider>();
                    theSphereCol4.radius = this.vRigidbody.mass * 0.0005f;
                    Quaternion NormalAngle4 = Quaternion.LookRotation(hitD.normal);
                    UnityEngine.Object.Instantiate(this.CollisionFX, this.DamageColRayRL.position, NormalAngle4);
                }
            }
            if (((!this.FRCollide && !this.FLCollide) && !this.RRCollide) && !this.RLCollide)
            {
                this.vRigidbody.AddTorque(((this.thisTransform.up * -this.AngForce) * this.vRigidbody.mass) * 0.5f);
                this.vRigidbody.AddTorque(((this.thisTransform.right * this.AngForce) * this.vRigidbody.mass) * 0.8f);
                float GravDiv = -Physics.gravity.y;
                this.vRigidbody.AddForce(((Vector3.up * this.vRigidbody.mass) * 0.5f) * GravDiv);
            }
            if (!this.FrontCollide)
            {
                if (this.FRCollide || this.FLCollide)
                {
                    this.FrontCollideSFX.Play();
                    this.FrontCollide = true;
                }
            }
            if (!this.RearCollide)
            {
                if (this.RRCollide || this.RLCollide)
                {
                    this.RearCollideSFX.Play();
                    this.RearCollide = true;
                }
            }
            return;
        }
        float VelClamp = Mathf.Clamp(this.Vel * this.VelClampMod, 16, 2048);
        if (this.target)
        {
            this.Dist = Vector3.Distance(this.thisTransform.position, this.target.position);
        }
        else
        {
            this.Dist = 64;
        }
        this.Vel = -localV.y * 2.24f;
        if (this.RaySpread < this.RaySpreadWidth)
        {
            this.RaySpread = this.RaySpread + this.RaySpreadMod;
        }
        else
        {
            this.RaySpread = this.RaySpreadMod;
            this.Obstacle = false;
        }
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * this.RayLengthObstacle)) + (this.thisTransform.right * this.RaySpread), this.thisTransform.forward * VelClamp, Color.red);
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * this.RayLengthObstacle)) + (-this.thisTransform.right * this.RaySpread), this.thisTransform.forward * VelClamp, Color.red);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * this.RayLengthObstacle)) + (this.thisTransform.right * this.RaySpread), this.thisTransform.forward, VelClamp, (int) this.targetLayers) || Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * this.RayLengthObstacle)) + (-this.thisTransform.right * this.RaySpread), this.thisTransform.forward, VelClamp, (int) this.targetLayers))
        {
            this.Obstacle = true;
        }
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * this.RayLengthTurn)) + (this.thisTransform.right * this.RaySpread), (this.thisTransform.forward * VelClamp) * 2, Color.black);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * this.RayLengthTurn)) + (this.thisTransform.right * this.RaySpread), this.thisTransform.forward, out hit, VelClamp * 2, (int) this.targetLayers))
        {
            this.RightDist = hit.distance;
        }
        else
        {
            this.RightDist = 200;
        }
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * this.RayLengthTurn)) + (-this.thisTransform.right * this.RaySpread), (this.thisTransform.forward * VelClamp) * 2, Color.black);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * this.RayLengthTurn)) + (-this.thisTransform.right * this.RaySpread), this.thisTransform.forward, out hit, VelClamp * 2, (int) this.targetLayers))
        {
            this.LeftDist = hit.distance;
        }
        else
        {
            this.LeftDist = 200;
        }
        if (this.RightDist > this.LeftDist)
        {
            this.TurnRight = true;
        }
        if (this.LeftDist > this.RightDist)
        {
            this.TurnLeft = true;
        }
        newRot2 = ((this.thisTransform.forward * 32) + (this.thisTransform.right * -this.SDa)).normalized;
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * this.SDf)) + (this.thisTransform.right * this.SDl), newRot2 * this.SD, Color.black);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * this.SDf)) + (this.thisTransform.right * this.SDl), newRot2, out hit, this.SD, (int) this.targetLayers))
        {
            this.RightDist = hit.distance;
        }
        else
        {
            this.RightDist = 512;
        }
        newRot2 = ((this.thisTransform.forward * 32) + (this.thisTransform.right * this.SDa)).normalized;
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * this.SDf)) + (-this.thisTransform.right * this.SDr), newRot2 * this.SD, Color.black);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * this.SDf)) + (-this.thisTransform.right * this.SDr), newRot2, out hit, this.SD, (int) this.targetLayers))
        {
            this.LeftDist = hit.distance;
        }
        else
        {
            this.LeftDist = 512;
        }
        newRot2 = ((this.thisTransform.forward * 32) + (this.thisTransform.right * -this.SD2a)).normalized;
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * this.SD2f)) + (this.thisTransform.right * this.SD2l), newRot2 * this.SD2, Color.black);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * this.SD2f)) + (this.thisTransform.right * this.SD2l), newRot2, out hit, this.SD2, (int) this.targetLayers))
        {
            this.RightDist = 1;
        }
        newRot2 = ((this.thisTransform.forward * 32) + (this.thisTransform.right * this.SD2a)).normalized;
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * this.SD2f)) + (-this.thisTransform.right * this.SD2r), newRot2 * this.SD2, Color.black);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * this.SD2f)) + (-this.thisTransform.right * this.SD2r), newRot2, out hit, this.SD2, (int) this.targetLayers))
        {
            this.LeftDist = 1;
        }
        if (this.RightDist > this.LeftDist)
        {
            this.StrafeRight = true;
        }
        if (this.LeftDist > this.RightDist)
        {
            this.StrafeLeft = true;
        }
        if (this.target)
        {
            Vector3 relativePoint = this.thisTransform.InverseTransformPoint(this.target.position);
            float LAndR = relativePoint.x * 8;
            this.RPClamp = Mathf.Clamp(LAndR / this.Dist, -1, 1);
            if (this.useHullAim)
            {
                float UAndD = relativePoint.y * 8;
                this.RPClamp2 = Mathf.Clamp(UAndD / this.Dist, -1, 1);
            }
        }
        if (this.TurnLeft && !this.TurnRight)
        {
            this.vRigidbody.AddTorque((this.thisTransform.up * -this.AngForce) * this.vRigidbody.mass);
        }
        if (this.TurnRight && !this.TurnLeft)
        {
            this.vRigidbody.AddTorque((this.thisTransform.up * this.AngForce) * this.vRigidbody.mass);
        }
        if (!this.TurnRight && !this.TurnLeft)
        {
            this.vRigidbody.AddTorque(((this.thisTransform.up * this.AngForce) * this.vRigidbody.mass) * this.RPClamp);
            if (this.useHullAim)
            {
                this.vRigidbody.AddTorque(((this.thisTransform.right * this.AngForce) * this.vRigidbody.mass) * -this.RPClamp2);
            }
        }
        if (this.StrafeRight && !this.StrafeLeft)
        {
            this.vRigidbody.AddForce((this.thisVTransform.right * this.DirForce) * this.vRigidbody.mass);
        }
        if (this.StrafeLeft && !this.StrafeRight)
        {
            this.vRigidbody.AddForce((-this.thisVTransform.right * this.DirForce) * this.vRigidbody.mass);
        }
        if (!this.Parked)
        {
            if (this.Obstacle)
            {
                if (this.Vel > 0)
                {
                    this.vRigidbody.AddForce((this.thisVTransform.up * this.BrakeForce) * this.vRigidbody.mass);
                }
            }
            else
            {
                if (this.Vel < this.MaxVel)
                {
                    this.vRigidbody.AddForce((-this.thisVTransform.up * this.DirForce) * this.vRigidbody.mass);
                }
            }
        }
        if (this.target)
        {
            Vector3 RelPoint1 = this.Turret1TF.InverseTransformPoint(this.TargetLead.position);
            Vector3 RelPoint2 = this.Turret2TF.InverseTransformPoint(this.TargetLead.position);
            Vector3 RelPoint3 = this.Turret3TF.InverseTransformPoint(this.TargetLead.position);
            Vector3 RelPoint4 = this.Turret4TF.InverseTransformPoint(this.TargetLead.position);
            float Vert, Hori;

            if (this.Attacking)
            {
                Vert = Mathf.Clamp((-RelPoint1.z * 800) / this.Dist, -64, 64);
                Hori = Mathf.Clamp((RelPoint1.x * 800) / this.Dist, -64, 64);

                {
                    float _1664 = Vert;
                    JointMotor _1665 = this.T1ElevationJoint.motor;
                    _1665.targetVelocity = _1664;
                    this.T1ElevationJoint.motor = _1665;
                }

                {
                    float _1666 = Hori;
                    JointMotor _1667 = this.T1TraverseJoint.motor;
                    _1667.targetVelocity = _1666;
                    this.T1TraverseJoint.motor = _1667;
                }
                Vert = Mathf.Clamp((-RelPoint2.z * 800) / this.Dist, -64, 64);
                Hori = Mathf.Clamp((RelPoint2.x * 800) / this.Dist, -64, 64);

                {
                    float _1668 = Vert;
                    JointMotor _1669 = this.T2ElevationJoint.motor;
                    _1669.targetVelocity = _1668;
                    this.T2ElevationJoint.motor = _1669;
                }

                {
                    float _1670 = Hori;
                    JointMotor _1671 = this.T2TraverseJoint.motor;
                    _1671.targetVelocity = _1670;
                    this.T2TraverseJoint.motor = _1671;
                }
                Vert = Mathf.Clamp((-RelPoint3.z * 800) / this.Dist, -64, 64);
                Hori = Mathf.Clamp((RelPoint3.x * 800) / this.Dist, -64, 64);

                {
                    float _1672 = Vert;
                    JointMotor _1673 = this.T3ElevationJoint.motor;
                    _1673.targetVelocity = _1672;
                    this.T3ElevationJoint.motor = _1673;
                }

                {
                    float _1674 = Hori;
                    JointMotor _1675 = this.T3TraverseJoint.motor;
                    _1675.targetVelocity = _1674;
                    this.T3TraverseJoint.motor = _1675;
                }
                Vert = Mathf.Clamp((-RelPoint4.z * 800) / this.Dist, -64, 64);
                Hori = Mathf.Clamp((RelPoint4.x * 800) / this.Dist, -64, 64);

                {
                    float _1676 = Vert;
                    JointMotor _1677 = this.T4ElevationJoint.motor;
                    _1677.targetVelocity = _1676;
                    this.T4ElevationJoint.motor = _1677;
                }

                {
                    float _1678 = Hori;
                    JointMotor _1679 = this.T4TraverseJoint.motor;
                    _1679.targetVelocity = _1678;
                    this.T4TraverseJoint.motor = _1679;
                }
            }
            else
            {
                RelPoint1 = this.Turret1TF.InverseTransformPoint(this.Forward.position);
                Vert = Mathf.Clamp(-RelPoint1.z, -64, 64);
                Hori = Mathf.Clamp(RelPoint1.x, -64, 64);

                {
                    float _1680 = Vert;
                    JointMotor _1681 = this.T1ElevationJoint.motor;
                    _1681.targetVelocity = _1680;
                    this.T1ElevationJoint.motor = _1681;
                }

                {
                    float _1682 = Hori;
                    JointMotor _1683 = this.T1TraverseJoint.motor;
                    _1683.targetVelocity = _1682;
                    this.T1TraverseJoint.motor = _1683;
                }
                RelPoint2 = this.Turret2TF.InverseTransformPoint(this.Forward.position);
                Vert = Mathf.Clamp(-RelPoint2.z, -64, 64);
                Hori = Mathf.Clamp(RelPoint2.x, -64, 64);

                {
                    float _1684 = Vert;
                    JointMotor _1685 = this.T2ElevationJoint.motor;
                    _1685.targetVelocity = _1684;
                    this.T2ElevationJoint.motor = _1685;
                }

                {
                    float _1686 = Hori;
                    JointMotor _1687 = this.T2TraverseJoint.motor;
                    _1687.targetVelocity = _1686;
                    this.T2TraverseJoint.motor = _1687;
                }
                RelPoint3 = this.Turret3TF.InverseTransformPoint(this.Forward.position);
                Vert = Mathf.Clamp(-RelPoint3.z, -64, 64);
                Hori = Mathf.Clamp(RelPoint3.x, -64, 64);

                {
                    float _1688 = Vert;
                    JointMotor _1689 = this.T3ElevationJoint.motor;
                    _1689.targetVelocity = _1688;
                    this.T3ElevationJoint.motor = _1689;
                }

                {
                    float _1690 = Hori;
                    JointMotor _1691 = this.T3TraverseJoint.motor;
                    _1691.targetVelocity = _1690;
                    this.T3TraverseJoint.motor = _1691;
                }
                RelPoint4 = this.Turret4TF.InverseTransformPoint(this.Forward.position);
                Vert = Mathf.Clamp(-RelPoint4.z, -64, 64);
                Hori = Mathf.Clamp(RelPoint4.x, -64, 64);

                {
                    float _1692 = Vert;
                    JointMotor _1693 = this.T4ElevationJoint.motor;
                    _1693.targetVelocity = _1692;
                    this.T4ElevationJoint.motor = _1693;
                }

                {
                    float _1694 = Hori;
                    JointMotor _1695 = this.T4TraverseJoint.motor;
                    _1695.targetVelocity = _1694;
                    this.T4TraverseJoint.motor = _1695;
                }
            }
        }
        if (this.AngerLevel > 100)
        {

            {
                int _1696 = -40;
                JointLimits _1697 = this.T1ElevationJoint.limits;
                _1697.min = _1696;
                this.T1ElevationJoint.limits = _1697;
            }

            {
                int _1698 = -40;
                JointLimits _1699 = this.T2ElevationJoint.limits;
                _1699.min = _1698;
                this.T2ElevationJoint.limits = _1699;
            }

            {
                int _1700 = -40;
                JointLimits _1701 = this.T3ElevationJoint.limits;
                _1701.min = _1700;
                this.T3ElevationJoint.limits = _1701;
            }

            {
                int _1702 = -40;
                JointLimits _1703 = this.T4ElevationJoint.limits;
                _1703.min = _1702;
                this.T4ElevationJoint.limits = _1703;
            }
            if (-this.TPivot1HJTP < 45)
            {
                this.TPivot1HJTP = this.TPivot1HJTP - 0.5f;
            }
            if (-this.TPivot2HJTP < 45)
            {
                this.TPivot2HJTP = this.TPivot2HJTP - 0.5f;
            }
            if (-this.TPivot3HJTP < 45)
            {
                this.TPivot3HJTP = this.TPivot3HJTP - 0.5f;
            }
            if (-this.TPivot4HJTP < 45)
            {
                this.TPivot4HJTP = this.TPivot4HJTP - 0.5f;
            }
            if (-this.TPivot1HJTP > 44)
            {
                this.TPivot1HJTP = -45;
                this.Attacking = true;
            }
        }
        else
        {

            {
                int _1704 = 0;
                JointLimits _1705 = this.T1ElevationJoint.limits;
                _1705.min = _1704;
                this.T1ElevationJoint.limits = _1705;
            }

            {
                int _1706 = 0;
                JointLimits _1707 = this.T2ElevationJoint.limits;
                _1707.min = _1706;
                this.T2ElevationJoint.limits = _1707;
            }

            {
                int _1708 = 0;
                JointLimits _1709 = this.T3ElevationJoint.limits;
                _1709.min = _1708;
                this.T3ElevationJoint.limits = _1709;
            }

            {
                int _1710 = 0;
                JointLimits _1711 = this.T4ElevationJoint.limits;
                _1711.min = _1710;
                this.T4ElevationJoint.limits = _1711;
            }
            if (-this.TPivot1HJTP > 0)
            {
                this.TPivot1HJTP = this.TPivot1HJTP + 0.5f;
            }
            if (-this.TPivot2HJTP > 0)
            {
                this.TPivot2HJTP = this.TPivot2HJTP + 0.5f;
            }
            if (-this.TPivot3HJTP > 0)
            {
                this.TPivot3HJTP = this.TPivot3HJTP + 0.5f;
            }
            if (-this.TPivot4HJTP > 0)
            {
                this.TPivot4HJTP = this.TPivot4HJTP + 0.5f;
            }
            if (-this.TPivot1HJTP < 44)
            {
                this.Attacking = false;
            }
        }

        {
            float _1712 = -this.TPivot1HJTP;
            JointSpring _1713 = this.TPivot1HJ.spring;
            _1713.targetPosition = _1712;
            this.TPivot1HJ.spring = _1713;
        }

        {
            float _1714 = -this.TPivot2HJTP;
            JointSpring _1715 = this.TPivot2HJ.spring;
            _1715.targetPosition = _1714;
            this.TPivot2HJ.spring = _1715;
        }

        {
            float _1716 = -this.TPivot3HJTP;
            JointSpring _1717 = this.TPivot3HJ.spring;
            _1717.targetPosition = _1716;
            this.TPivot3HJ.spring = _1717;
        }

        {
            float _1718 = -this.TPivot4HJTP;
            JointSpring _1719 = this.TPivot4HJ.spring;
            _1719.targetPosition = _1718;
            this.TPivot4HJ.spring = _1719;
        }
        if (this.Gun1Fire)
        {
            this.G1RN = this.G1RN + 1;
            if (this.G1RN > 40)
            {
                this.G1RN = 0;
                this.Gun1Fire = false;
            }

            {
                float _1720 = this.RecoilCurve.Evaluate(this.G1RN);
                Vector3 _1721 = this.Gun1Model.localPosition;
                _1721.y = _1720;
                this.Gun1Model.localPosition = _1721;
            }
        }
        if (this.Gun2Fire)
        {
            this.G2RN = this.G2RN + 1;
            if (this.G2RN > 40)
            {
                this.G2RN = 0;
                this.Gun2Fire = false;
            }

            {
                float _1722 = this.RecoilCurve.Evaluate(this.G2RN);
                Vector3 _1723 = this.Gun2Model.localPosition;
                _1723.y = _1722;
                this.Gun2Model.localPosition = _1723;
            }
        }
        if (this.Gun3Fire)
        {
            this.G3RN = this.G3RN + 1;
            if (this.G3RN > 40)
            {
                this.G3RN = 0;
                this.Gun3Fire = false;
            }

            {
                float _1724 = this.RecoilCurve.Evaluate(this.G3RN);
                Vector3 _1725 = this.Gun3Model.localPosition;
                _1725.y = _1724;
                this.Gun3Model.localPosition = _1725;
            }
        }
        if (this.Gun4Fire)
        {
            this.G4RN = this.G4RN + 1;
            if (this.G4RN > 40)
            {
                this.G4RN = 0;
                this.Gun4Fire = false;
            }

            {
                float _1726 = this.RecoilCurve.Evaluate(this.G4RN);
                Vector3 _1727 = this.Gun4Model.localPosition;
                _1727.y = _1726;
                this.Gun4Model.localPosition = _1727;
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
                if (this.AngerLevel < 200)
                {
                    this.AngerLevel = this.AngerLevel + 45;
                }
                Vector3 RTT = OT.InverseTransformPoint(this.thisVTransform.position);
                float RTPx = Mathf.Abs(RTT.x);
                float RTPy = Mathf.Abs(RTT.y);
                float RTP = RTPx + RTPy;
                this.VicinityPoint.position = OT.position;
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

    public virtual void Ticker()
    {
        if (this.Damaged)
        {
            return;
        }
        this.TurnLeft = false;
        this.TurnRight = false;
        this.StrafeRight = false;
        this.StrafeLeft = false;
        if (this.target)
        {
            if (this.PDTurretFRAI)
            {
                this.PDTurretFRAI.target = this.target;
            }
            if (this.PDTurretFLAI)
            {
                this.PDTurretFLAI.target = this.target;
            }
            if (this.PDTurretR1AI)
            {
                this.PDTurretR1AI.target = this.target;
            }
            if (this.PDTurretR2AI)
            {
                this.PDTurretR2AI.target = this.target;
            }
            if (this.PDTurretL1AI)
            {
                this.PDTurretL1AI.target = this.target;
            }
            if (this.PDTurretL2AI)
            {
                this.PDTurretL2AI.target = this.target;
            }
            if (this.PDTurretDR1AI)
            {
                this.PDTurretDR1AI.target = this.target;
            }
            if (this.PDTurretDR2AI)
            {
                this.PDTurretDR2AI.target = this.target;
            }
            if (this.PDTurretDL1AI)
            {
                this.PDTurretDL1AI.target = this.target;
            }
            if (this.PDTurretDL2AI)
            {
                this.PDTurretDL2AI.target = this.target;
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
            }
            DutvutanianNetwork.instance.EnemyTargetMed = this.target;
            if (!this.target.name.Contains("TC"))
            {
                if (DutvutanianNetwork.AlertTime > 200)
                {
                    this.Waypoint.position = DutvutanianNetwork.instance.PriorityWaypoint.position;
                    this.target = this.Waypoint;
                }
            }
        }
        if (this.AngerLevel > 0)
        {
            this.AngerLevel = this.AngerLevel - 1;
        }
        this.PissedAtTC1 = DutvutanianNetwork.TC1CriminalLevel;
        this.PissedAtTC2 = DutvutanianNetwork.TC2CriminalLevel;
        this.PissedAtTC3 = DutvutanianNetwork.TC3CriminalLevel;
        this.PissedAtTC4 = DutvutanianNetwork.TC4CriminalLevel;
        this.PissedAtTC5 = DutvutanianNetwork.TC5CriminalLevel;
        this.PissedAtTC6 = DutvutanianNetwork.TC6CriminalLevel;
        this.PissedAtTC7 = DutvutanianNetwork.TC7CriminalLevel;
        this.PissedAtTC8 = DutvutanianNetwork.TC8CriminalLevel;
        this.VicinityCheck();
    }

    public virtual void VicinityCheck()//loops = 0;
    {
        GameObject[] gos = null;
        gos = GameObject.FindGameObjectsWithTag("TC");
        //var Blip = Resources.Load("Prefabs/RadarBlip", GameObject) as GameObject;
        foreach (GameObject go in gos)
        {
            string ON = go.name;
            Transform OT = go.transform;
            if (!ON.Contains("9"))
            {
                if (this.VPRadius < 2000)
                {
                    this.VPRadius = this.VPRadius + 100;
                }
                if (this.target)
                {
                    if (!this.target.name.Contains("TC"))
                    {
                        this.Attacking = false;
                    }
                }
                if (Vector3.Distance(this.VicinityPoint.position, OT.position) < this.VPRadius)
                {
                    //Debug.Log(ON);
                    //Instantiate(Blip, OT.position, OT.rotation);
                    if (Vector3.Distance(this.thisTransform.position, OT.position) < 150)
                    {
                        if (ON.Contains("TC"))
                        {
                            //Stranger = OT;
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
                                //Hunting = false;
                                this.target = OT;
                                this.AngerLevel = 200;
                                this.VPRadius = 32;
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
                                //Hunting = false;
                                this.target = OT;
                                this.AngerLevel = 200;
                                this.VPRadius = 32;
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
                                //Hunting = false;
                                this.target = OT;
                                this.AngerLevel = 200;
                                this.VPRadius = 32;
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
                                //Hunting = false;
                                this.target = OT;
                                this.AngerLevel = 200;
                                this.VPRadius = 32;
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
                                //Hunting = false;
                                this.target = OT;
                                this.AngerLevel = 200;
                                this.VPRadius = 32;
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
                                //Hunting = false;
                                this.target = OT;
                                this.AngerLevel = 200;
                                this.VPRadius = 32;
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
                                //Hunting = false;
                                this.target = OT;
                                this.AngerLevel = 200;
                                this.VPRadius = 32;
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
                                //Hunting = false;
                                this.target = OT;
                                this.AngerLevel = 200;
                                this.VPRadius = 32;
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
                                //Hunting = false;
                                this.target = OT;
                                this.AngerLevel = 200;
                                this.VPRadius = 32;
                                this.Attacking = true;
                            }
                        }
                    }
                }
            }
        }
    }

    public virtual IEnumerator FireRay()
    {
        RaycastHit hit = default(RaycastHit);
        string HCN = null;
        if (this.Gun1)
        {
            if (this.target != null)
            {
                if (this.target.name.Contains("TC") && (this.Dist < 8000))
                {
                    if (Physics.Raycast(this.Muzzle1.position, this.Muzzle1.forward, out hit, 8000, (int) this.targetLayers2))
                    {
                        HCN = hit.collider.name;
                        if (!HCN.Contains("C9"))
                        {
                            if (HCN.Contains("TL"))
                            {
                                hit.transform.Translate(Vector3.down * -512);
                            }
                        }
                        if (!HCN.Contains("C9"))
                        {
                            if (HCN.Contains("TL"))
                            {
                                hit.transform.Translate(Vector3.down * -512);
                            }
                        }
                        if (!hit.collider.name.Contains("C9"))
                        {
                            if (hit.collider.name.Contains("TC") || hit.collider.name.Contains("TL9"))
                            {
                                this.Gun1Fire = true;
                                this.Gun1.Fire();
                            }
                        }
                    }
                }
            }
        }
        yield return new WaitForSeconds(0.3f);
        if (this.Gun2)
        {
            if (this.target != null)
            {
                if (this.target.name.Contains("TC") && (this.Dist < 8000))
                {
                    if (Physics.Raycast(this.Muzzle2.position, this.Muzzle2.forward, out hit, 8000, (int) this.targetLayers2))
                    {
                        HCN = hit.collider.name;
                        if (!HCN.Contains("C9"))
                        {
                            if (HCN.Contains("TL"))
                            {
                                hit.transform.Translate(Vector3.down * -512);
                            }
                        }
                        if (!HCN.Contains("C9"))
                        {
                            if (HCN.Contains("TL"))
                            {
                                hit.transform.Translate(Vector3.down * -512);
                            }
                        }
                        if (!hit.collider.name.Contains("C9"))
                        {
                            if (hit.collider.name.Contains("TC") || hit.collider.name.Contains("TL9"))
                            {
                                this.Gun2Fire = true;
                                this.Gun2.Fire();
                            }
                        }
                    }
                }
            }
        }
        yield return new WaitForSeconds(0.3f);
        if (this.Gun3)
        {
            if (this.target != null)
            {
                if (this.target.name.Contains("TC") && (this.Dist < 8000))
                {
                    if (Physics.Raycast(this.Muzzle3.position, this.Muzzle3.forward, out hit, 8000, (int) this.targetLayers2))
                    {
                        HCN = hit.collider.name;
                        if (!HCN.Contains("C9"))
                        {
                            if (HCN.Contains("TL"))
                            {
                                hit.transform.Translate(Vector3.down * -512);
                            }
                        }
                        if (!HCN.Contains("C9"))
                        {
                            if (HCN.Contains("TL"))
                            {
                                hit.transform.Translate(Vector3.down * -512);
                            }
                        }
                        if (!hit.collider.name.Contains("C9"))
                        {
                            if (hit.collider.name.Contains("TC") || hit.collider.name.Contains("TL9"))
                            {
                                this.Gun3Fire = true;
                                this.Gun3.Fire();
                            }
                        }
                    }
                }
            }
        }
        yield return new WaitForSeconds(0.3f);
        if (this.Gun4)
        {
            if (this.target != null)
            {
                if (this.target.name.Contains("TC") && (this.Dist < 8000))
                {
                    if (Physics.Raycast(this.Muzzle4.position, this.Muzzle4.forward, out hit, 8000, (int) this.targetLayers2))
                    {
                        HCN = hit.collider.name;
                        if (!HCN.Contains("C9"))
                        {
                            if (HCN.Contains("TL"))
                            {
                                hit.transform.Translate(Vector3.down * -512);
                            }
                        }
                        if (!HCN.Contains("C9"))
                        {
                            if (HCN.Contains("TL"))
                            {
                                hit.transform.Translate(Vector3.down * -512);
                            }
                        }
                        if (!HCN.Contains("C9"))
                        {
                            if (HCN.Contains("TC") || HCN.Contains("TL9"))
                            {
                                this.Gun4Fire = true;
                                this.Gun4.Fire();
                            }
                        }
                    }
                }
            }
        }
    }

    public virtual void Shooty()
    {
        if (this.Damaged)
        {
            return;
        }
        if (this.Attacking)
        {
            this.StartCoroutine(this.FireRay());
        }
        if (this.OffDuty)
        {
            return;
        }
        if (!this.PDTurretFRActive)
        {
            if (this.PDTurretSpawnFNum > 0)
            {
                this.PDTurretSpawnFNum = this.PDTurretSpawnFNum - 1;
                this.PDTurretFRActive = true;
                GameObject Spawnionaise1 = ((GameObject) Resources.Load("Machines/SurfaceTurret_DN", typeof(GameObject))) as GameObject;
                GameObject _SpawnedObject1 = UnityEngine.Object.Instantiate(Spawnionaise1, this.PDTurretSpawnF.position, this.PDTurretSpawnF.rotation);
                this.PDTurretFRAI = (SurfaceTurretAI) _SpawnedObject1.transform.GetChild(0).transform.GetComponent(typeof(SurfaceTurretAI));
                this.PDTurretFRAI.absoluteParent = this.thisVTransform;
                this.PDTurretFRAI.targetDestination = this.PDTurretFR;
                this.PDTurretFRAI.upperParent = this.thisParent;
                this.PDTurretFRAI.mainVesselRB = this.vRigidbody;
                _SpawnedObject1.transform.parent = this.thisVTransform;
                return;
            }
        }
        else
        {
            if (!this.PDTurretFRAI)
            {
                this.PDTurretFRActive = false;
            }
        }
        if (!this.PDTurretFLActive)
        {
            if (this.PDTurretSpawnFNum > 0)
            {
                this.PDTurretSpawnFNum = this.PDTurretSpawnFNum - 1;
                this.PDTurretFLActive = true;
                GameObject Spawnionaise2 = ((GameObject) Resources.Load("Machines/SurfaceTurret_DN", typeof(GameObject))) as GameObject;
                GameObject _SpawnedObject2 = UnityEngine.Object.Instantiate(Spawnionaise2, this.PDTurretSpawnF.position, this.PDTurretSpawnF.rotation);
                this.PDTurretFLAI = (SurfaceTurretAI) _SpawnedObject2.transform.GetChild(0).transform.GetComponent(typeof(SurfaceTurretAI));
                this.PDTurretFLAI.absoluteParent = this.thisVTransform;
                this.PDTurretFLAI.targetDestination = this.PDTurretFL;
                this.PDTurretFLAI.upperParent = this.thisParent;
                this.PDTurretFLAI.mainVesselRB = this.vRigidbody;
                _SpawnedObject2.transform.parent = this.thisVTransform;
                return;
            }
        }
        else
        {
            if (!this.PDTurretFLAI)
            {
                this.PDTurretFLActive = false;
            }
        }
        if (!this.PDTurretR1Active)
        {
            if (this.PDTurretSpawnNum > 0)
            {
                this.PDTurretSpawnNum = this.PDTurretSpawnNum - 1;
                this.PDTurretR1Active = true;
                GameObject Spawnionaise3 = ((GameObject) Resources.Load("Machines/SurfaceTurret_DN", typeof(GameObject))) as GameObject;
                GameObject _SpawnedObject3 = UnityEngine.Object.Instantiate(Spawnionaise3, this.PDTurretSpawn.position, this.PDTurretSpawn.rotation);
                this.PDTurretR1AI = (SurfaceTurretAI) _SpawnedObject3.transform.GetChild(0).transform.GetComponent(typeof(SurfaceTurretAI));
                this.PDTurretR1AI.absoluteParent = this.thisVTransform;
                this.PDTurretR1AI.targetDestination = this.PDTurretR1;
                this.PDTurretR1AI.upperParent = this.thisParent;
                this.PDTurretR1AI.mainVesselRB = this.vRigidbody;
                _SpawnedObject3.transform.parent = this.thisVTransform;
                return;
            }
        }
        else
        {
            if (!this.PDTurretR1AI)
            {
                this.PDTurretR1Active = false;
            }
        }
        if (!this.PDTurretR2Active)
        {
            if (this.PDTurretSpawnNum > 0)
            {
                this.PDTurretSpawnNum = this.PDTurretSpawnNum - 1;
                this.PDTurretR2Active = true;
                GameObject Spawnionaise4 = ((GameObject) Resources.Load("Machines/SurfaceTurret_DN", typeof(GameObject))) as GameObject;
                GameObject _SpawnedObject4 = UnityEngine.Object.Instantiate(Spawnionaise4, this.PDTurretSpawn.position, this.PDTurretSpawn.rotation);
                this.PDTurretR2AI = (SurfaceTurretAI) _SpawnedObject4.transform.GetChild(0).transform.GetComponent(typeof(SurfaceTurretAI));
                this.PDTurretR2AI.absoluteParent = this.thisVTransform;
                this.PDTurretR2AI.targetDestination = this.PDTurretR2;
                this.PDTurretR2AI.upperParent = this.thisParent;
                this.PDTurretR2AI.mainVesselRB = this.vRigidbody;
                _SpawnedObject4.transform.parent = this.thisVTransform;
                return;
            }
        }
        else
        {
            if (!this.PDTurretR2AI)
            {
                this.PDTurretR2Active = false;
            }
        }
        if (!this.PDTurretL1Active)
        {
            if (this.PDTurretSpawnNum > 0)
            {
                this.PDTurretSpawnNum = this.PDTurretSpawnNum - 1;
                this.PDTurretL1Active = true;
                GameObject Spawnionaise5 = ((GameObject) Resources.Load("Machines/SurfaceTurret_DN", typeof(GameObject))) as GameObject;
                GameObject _SpawnedObject5 = UnityEngine.Object.Instantiate(Spawnionaise5, this.PDTurretSpawn.position, this.PDTurretSpawn.rotation);
                this.PDTurretL1AI = (SurfaceTurretAI) _SpawnedObject5.transform.GetChild(0).transform.GetComponent(typeof(SurfaceTurretAI));
                this.PDTurretL1AI.absoluteParent = this.thisVTransform;
                this.PDTurretL1AI.targetDestination = this.PDTurretL1;
                this.PDTurretL1AI.upperParent = this.thisParent;
                this.PDTurretL1AI.mainVesselRB = this.vRigidbody;
                _SpawnedObject5.transform.parent = this.thisVTransform;
                return;
            }
        }
        else
        {
            if (!this.PDTurretL1AI)
            {
                this.PDTurretL1Active = false;
            }
        }
        if (!this.PDTurretL2Active)
        {
            if (this.PDTurretSpawnNum > 0)
            {
                this.PDTurretSpawnNum = this.PDTurretSpawnNum - 1;
                this.PDTurretL2Active = true;
                GameObject Spawnionaise6 = ((GameObject) Resources.Load("Machines/SurfaceTurret_DN", typeof(GameObject))) as GameObject;
                GameObject _SpawnedObject6 = UnityEngine.Object.Instantiate(Spawnionaise6, this.PDTurretSpawn.position, this.PDTurretSpawn.rotation);
                this.PDTurretL2AI = (SurfaceTurretAI) _SpawnedObject6.transform.GetChild(0).transform.GetComponent(typeof(SurfaceTurretAI));
                this.PDTurretL2AI.absoluteParent = this.thisVTransform;
                this.PDTurretL2AI.targetDestination = this.PDTurretL2;
                this.PDTurretL2AI.upperParent = this.thisParent;
                this.PDTurretL2AI.mainVesselRB = this.vRigidbody;
                _SpawnedObject6.transform.parent = this.thisVTransform;
                return;
            }
        }
        else
        {
            if (!this.PDTurretL2AI)
            {
                this.PDTurretL2Active = false;
            }
        }
        if (!this.PDTurretDR1Active)
        {
            if (this.PDTurretSpawnNum > 0)
            {
                this.PDTurretSpawnNum = this.PDTurretSpawnNum - 1;
                this.PDTurretDR1Active = true;
                GameObject Spawnionaise7 = ((GameObject) Resources.Load("Machines/SurfaceTurret_DN", typeof(GameObject))) as GameObject;
                GameObject _SpawnedObject7 = UnityEngine.Object.Instantiate(Spawnionaise7, this.PDTurretSpawn.position, this.PDTurretSpawn.rotation);
                this.PDTurretDR1AI = (SurfaceTurretAI) _SpawnedObject7.transform.GetChild(0).transform.GetComponent(typeof(SurfaceTurretAI));
                this.PDTurretDR1AI.absoluteParent = this.thisVTransform;
                this.PDTurretDR1AI.targetDestination = this.PDTurretDR2;
                this.PDTurretDR1AI.targetFinalDestination = this.PDTurretDR1;
                this.PDTurretDR1AI.upperParent = this.thisParent;
                this.PDTurretDR1AI.mainVesselRB = this.vRigidbody;
                _SpawnedObject7.transform.parent = this.thisVTransform;
                return;
            }
        }
        else
        {
            if (!this.PDTurretDR1AI)
            {
                this.PDTurretDR1Active = false;
            }
        }
        if (!this.PDTurretDR2Active)
        {
            if (this.PDTurretSpawnNum > 0)
            {
                this.PDTurretSpawnNum = this.PDTurretSpawnNum - 1;
                this.PDTurretDR2Active = true;
                GameObject Spawnionaise8 = ((GameObject) Resources.Load("Machines/SurfaceTurret_DN", typeof(GameObject))) as GameObject;
                GameObject _SpawnedObject8 = UnityEngine.Object.Instantiate(Spawnionaise8, this.PDTurretSpawn.position, this.PDTurretSpawn.rotation);
                this.PDTurretDR2AI = (SurfaceTurretAI) _SpawnedObject8.transform.GetChild(0).transform.GetComponent(typeof(SurfaceTurretAI));
                this.PDTurretDR2AI.absoluteParent = this.thisVTransform;
                this.PDTurretDR2AI.targetDestination = this.PDTurretDR2;
                this.PDTurretDR2AI.upperParent = this.thisParent;
                this.PDTurretDR2AI.mainVesselRB = this.vRigidbody;
                _SpawnedObject8.transform.parent = this.thisVTransform;
                return;
            }
        }
        else
        {
            if (!this.PDTurretDR2AI)
            {
                this.PDTurretDR2Active = false;
            }
        }
        if (!this.PDTurretDL1Active)
        {
            if (this.PDTurretSpawnNum > 0)
            {
                this.PDTurretSpawnNum = this.PDTurretSpawnNum - 1;
                this.PDTurretDL1Active = true;
                GameObject Spawnionaise9 = ((GameObject) Resources.Load("Machines/SurfaceTurret_DN", typeof(GameObject))) as GameObject;
                GameObject _SpawnedObject9 = UnityEngine.Object.Instantiate(Spawnionaise9, this.PDTurretSpawn.position, this.PDTurretSpawn.rotation);
                this.PDTurretDL1AI = (SurfaceTurretAI) _SpawnedObject9.transform.GetChild(0).transform.GetComponent(typeof(SurfaceTurretAI));
                this.PDTurretDL1AI.absoluteParent = this.thisVTransform;
                this.PDTurretDL1AI.targetDestination = this.PDTurretDL2;
                this.PDTurretDL1AI.targetFinalDestination = this.PDTurretDL1;
                this.PDTurretDL1AI.upperParent = this.thisParent;
                this.PDTurretDL1AI.mainVesselRB = this.vRigidbody;
                _SpawnedObject9.transform.parent = this.thisVTransform;
                return;
            }
        }
        else
        {
            if (!this.PDTurretDL1AI)
            {
                this.PDTurretDL1Active = false;
            }
        }
        if (!this.PDTurretDL2Active)
        {
            if (this.PDTurretSpawnNum > 0)
            {
                this.PDTurretSpawnNum = this.PDTurretSpawnNum - 1;
                this.PDTurretDL2Active = true;
                GameObject Spawnionaise10 = ((GameObject) Resources.Load("Machines/SurfaceTurret_DN", typeof(GameObject))) as GameObject;
                GameObject _SpawnedObject10 = UnityEngine.Object.Instantiate(Spawnionaise10, this.PDTurretSpawn.position, this.PDTurretSpawn.rotation);
                this.PDTurretDL2AI = (SurfaceTurretAI) _SpawnedObject10.transform.GetChild(0).transform.GetComponent(typeof(SurfaceTurretAI));
                this.PDTurretDL2AI.absoluteParent = this.thisVTransform;
                this.PDTurretDL2AI.targetDestination = this.PDTurretDL2;
                this.PDTurretDL2AI.upperParent = this.thisParent;
                this.PDTurretDL2AI.mainVesselRB = this.vRigidbody;
                _SpawnedObject10.transform.parent = this.thisVTransform;
                return;
            }
        }
        else
        {
            if (!this.PDTurretDL2AI)
            {
                this.PDTurretDL2Active = false;
            }
        }
    }

    public virtual void CalcLead()
    {
        this.StartCoroutine(this.Lead());
    }

    public virtual IEnumerator Lead()
    {
        if (this.target && this.TargetTrace)
        {
            this.TargetTrace.position = this.target.position;
        }
        yield return new WaitForSeconds(0.1f);
        if (this.target && this.TargetTrace)
        {
            float Dist1 = Vector3.Distance(this.TargetTrace.position, this.target.position);
            float Dist2 = this.LeadCurve.Evaluate(this.Dist) * Dist1;
            this.TargetTrace.LookAt(this.target);
            this.TargetLead.position = this.TargetTrace.position;
            this.TargetLead.rotation = this.TargetTrace.rotation;
            this.TargetLead.position = this.TargetLead.position + ((this.TargetLead.forward * Dist2) * this.LeadAmount);
            this.TLCol.radius = 8;
        }
    }

    public virtual void Damage()
    {
        this.Damaged = true;
        if (this.PDTurretFRAI)
        {
            this.StartCoroutine(this.PDTurretFRAI.Damage());
        }
        if (this.PDTurretFLAI)
        {
            this.StartCoroutine(this.PDTurretFRAI.Damage());
        }
        if (this.PDTurretR1AI)
        {
            this.StartCoroutine(this.PDTurretFRAI.Damage());
        }
        if (this.PDTurretR2AI)
        {
            this.StartCoroutine(this.PDTurretFRAI.Damage());
        }
        if (this.PDTurretL1AI)
        {
            this.StartCoroutine(this.PDTurretFRAI.Damage());
        }
        if (this.PDTurretL2AI)
        {
            this.StartCoroutine(this.PDTurretFRAI.Damage());
        }
        if (this.PDTurretDR1AI)
        {
            this.StartCoroutine(this.PDTurretFRAI.Damage());
        }
        if (this.PDTurretDR2AI)
        {
            this.StartCoroutine(this.PDTurretFRAI.Damage());
        }
        if (this.PDTurretDL1AI)
        {
            this.StartCoroutine(this.PDTurretFRAI.Damage());
        }
        if (this.PDTurretDL2AI)
        {
            this.StartCoroutine(this.PDTurretFRAI.Damage());
        }
    }

    public DNCapitalShipAI()
    {
        this.LeadCurve = new AnimationCurve();
        this.LeadAmount = 0.017f;
        this.PDTurretSpawnFNum = 6;
        this.PDTurretSpawnNum = 24;
        this.RecoilCurve = new AnimationCurve();
        this.SDa = 2;
        this.SD2a = 2;
    }

}