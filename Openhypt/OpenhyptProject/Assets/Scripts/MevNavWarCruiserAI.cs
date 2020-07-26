using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MevNavWarCruiserAI : MonoBehaviour
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
    public Transform AIAnchor;
    public bool HasRequested;
    public GameObject CMissileAmmo;
    public Transform CMissile1;
    public Transform CMissile2;
    public Transform CMissile3;
    public Transform CMissile4;
    public GameObject Drone1;
    public GameObject Vult;
    public Transform DroneSpawn1;
    public Transform DroneSpawn2;
    public Transform DroneSpawn3;
    public Transform DroneSpawn4;
    public GameObject PresentDrone1;
    public GameObject PresentDrone2;
    public MevNavBattledroneAI Drone1AI;
    public MevNavBattledroneAI Drone2AI;
    public Transform Gate;
    public AudioSource GateSound;
    public Transform Turret1TF;
    public Transform Turret2TF;
    public Transform Turret3TF;
    public Transform Turret4TF;
    public Transform Turret5TF;
    public Transform Turret6TF;
    public Transform Turret7TF;
    public Transform Turret8TF;
    public Transform TurretB1TF;
    public Transform TurretB2TF;
    public Rigidbody Turret1RB;
    public Rigidbody Turret2RB;
    public Rigidbody Turret3RB;
    public Rigidbody Turret4RB;
    public Rigidbody Turret5RB;
    public Rigidbody Turret6RB;
    public Rigidbody Turret7RB;
    public Rigidbody Turret8RB;
    public Rigidbody TurretB1RB;
    public Rigidbody TurretB2RB;
    public NPCGun Gun1;
    public NPCGun Gun2;
    public NPCGun Gun3;
    public NPCGun Gun4;
    public NPCGun Gun5;
    public NPCGun Gun6;
    public NPCGun Gun7;
    public NPCGun Gun8;
    public NPCGun GunB1;
    public NPCGun GunB2;
    public MevNavGyro Gyro;
    public BoxCollider Trig;
    public GameObject ThrusterEffect1;
    public GameObject ThrusterEffect2;
    public GameObject ThrusterEffect3;
    public GameObject ThrusterEffect4;
    public GameObject ThrusterEffect5;
    public GameObject ThrusterEffect6;
    public GameObject ThrusterEffect7;
    public GameObject ThrusterEffect8;
    public GameObject Presence;
    public int PissedAtTC0a;
    public int PissedAtTC1;
    public int PissedAtTC2;
    public int PissedAtTC3;
    public int PissedAtTC4;
    public int PissedAtTC5;
    public int PissedAtTC6;
    public int PissedAtTC8;
    public int PissedAtTC9;
    public bool FoundSmall;
    public bool FoundMedium;
    public bool FoundBig;
    public bool Hunting;
    public bool Attacking;
    public bool Obstacle;
    public bool Stuck;
    public int StuckTimer;
    public int StuckCounter;
    public bool Emergency;
    public bool Damaged;
    public bool OnHull;
    public bool TurnRight;
    public bool TurnLeft;
    public bool FiringMainGuns;
    public int MainGunsCooldown;
    public float RightDist;
    public float LeftDist;
    public float RUP;
    public float RRUP;
    public float RRUPz;
    public int AngClamp;
    public bool Wall;
    public bool RWall;
    public bool LWall;
    public Vector3 Pointu;
    public Vector3 Pointd;
    public Vector3 RPointu;
    public Vector3 RPointur;
    public Vector3 RPointd;
    public Vector3 LPointu;
    public Vector3 LPointul;
    public Vector3 LPointd;
    public Vector3 localV;
    public float Vel;
    public Vector3 RelativeTarget;
    public LayerMask targetLayers;
    public int DangerSense;
    public bool DangerTick;
    public bool LaunchingCM;
    public bool DistantThreat;
    public bool TargetClose;
    public bool GOpen;
    public bool GClose;
    public int SpawnCounter;
    public int Spot;
    public int Ignorage;
    public int StoredCMissiles;
    public LayerMask targetLayersD;
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
        this.InvokeRepeating("Regenerator", 1, 1);
        this.InvokeRepeating("Targety", 15, 15);
        this.InvokeRepeating("Shooty", Random.Range(2, 3), 0.2f);
        this.InvokeRepeating("Launchy", 1, 11);
        this.InvokeRepeating("EmergencyLaunchy", 1, 1.2f);
        this.InvokeRepeating("CalcLead", 1, 0.15f);
        this.DamageColRayFRGO = this.DamageColRayFR.gameObject;
        this.DamageColRayFLGO = this.DamageColRayFL.gameObject;
        this.DamageColRayRRGO = this.DamageColRayRR.gameObject;
        this.DamageColRayRLGO = this.DamageColRayRL.gameObject;
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        RaycastHit hit1 = default(RaycastHit);
        RaycastHit hit2 = default(RaycastHit);
        RaycastHit hit3 = default(RaycastHit);
        if (this.Damaged)
        {
            return;
        }
        if (!this.DangerTick)
        {
            this.thisTransform.rotation = this.AIAnchor.transform.rotation;
        }
        this.thisTransform.position = this.AIAnchor.transform.position;
        if (this.Attacking)
        {
            if (this.target == this.ResetAimpoint)
            {
                this.Gyro.AimTarget = this.ResetAimpoint;
                this.Attacking = false;
                this.Spot = 0;
                this.Hunting = true;
                this.FoundSmall = false;
                this.FoundMedium = false;
            }
            if (this.target == this.Waypoint)
            {
                this.target = this.ResetAimpoint;
                this.Gyro.AimTarget = this.ResetAimpoint;
                this.Attacking = false;
                this.Spot = 0;
                this.Hunting = true;
                this.FoundSmall = false;
                this.FoundMedium = false;
            }
            if (this.target == null)
            {
                this.target = this.ResetAimpoint;
                this.Gyro.AimTarget = this.ResetAimpoint;
                this.Attacking = false;
                this.Spot = 0;
                this.Hunting = true;
                this.FoundSmall = false;
                this.FoundMedium = false;
            }
            else
            {
                if (this.target.name.Contains("broken"))
                {
                    this.target = this.ResetAimpoint;
                    this.Gyro.AimTarget = this.ResetAimpoint;
                    this.Attacking = false;
                    this.Spot = 0;
                    this.Hunting = true;
                    this.FoundSmall = false;
                    this.FoundMedium = false;
                }
            }
        }
        if (!this.Stuck)
        {
            if (this.TurnLeft)
            {
                this.Gyro.AimForce = 0;
                this.Gyro.TurnForce = -60000000;
            }
            if (this.TurnRight)
            {
                this.Gyro.AimForce = 0;
                this.Gyro.TurnForce = 60000000;
            }
        }
        else
        {
            this.Gyro.AimForce = 0;
            this.Gyro.TurnForce = 60000000;
        }
        if ((this.TurnRight && this.TurnLeft) && this.Obstacle)
        {
            this.Gyro.TurnForce = -60000000;
        }
        if ((this.Attacking && !this.Obstacle) && (this.target != null))
        {
            if (!this.TurnRight && !this.TurnLeft)
            {
                this.RelativeTarget = this.thisTransform.InverseTransformPoint(this.target.position);
                //Debug.Log(RelativeTarget.z + " Z Axis \n" + RelativeTarget.x + " X Axis");
                if (((Vector3.Distance(this.thisTransform.position, this.target.position) > 400) && !this.TurnRight) && !this.TurnLeft)
                {
                    if (this.RelativeTarget.z < 0)
                    {
                        if (this.RelativeTarget.x > 0)
                        {
                            this.Gyro.TurnForce = 60000000;
                        }
                        else
                        {
                            this.Gyro.TurnForce = -60000000;
                        }
                        this.Gyro.AimForce = 0;
                    }
                    else
                    {
                        this.Gyro.AimForce = 2000000;
                    }
                }
            }
        }
        this.localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
        this.Vel = this.vRigidbody.velocity.magnitude;
        if (this.RUP < 4)
        {
            this.RUP = this.RUP + 1;
        }
        else
        {
            this.RUP = 0;
        }
        if (this.RRUP < 150)
        {
            this.RRUP = this.RRUP + 4;
            this.RRUPz = this.RRUPz - 1;
        }
        else
        {
            this.RRUP = 2;
            this.RRUPz = 187;
            if (!this.OnHull)
            {
                this.Obstacle = false;
            }
        }
        float VelClamp = Mathf.Clamp(this.Vel * 6, 187, 600);
        this.AngClamp = (int) Mathf.Clamp(this.Vel * 0.15f, 2, 8);
        float DMod1 = 160 - this.Vel;
        float DMod = Mathf.Clamp(DMod1, 1, 160);
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.forward * 187)) + (-this.thisTransform.up * 24)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward * VelClamp, Color.white);
        if (Physics.Raycast(((this.thisTransform.position + (this.thisTransform.forward * 187)) + (-this.thisTransform.up * 24)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward, out hit1, VelClamp, (int) this.targetLayers))
        {
            this.Pointu = hit1.point;
        }
        else
        {
            this.Pointu = new Vector3(2, 2, 2);
        }
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.forward * 187)) + (-this.thisTransform.up * 25)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward * VelClamp, Color.white);
        if (Physics.Raycast(((this.thisTransform.position + (this.thisTransform.forward * 187)) + (-this.thisTransform.up * 25)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward, out hit2, VelClamp, (int) this.targetLayers))
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
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * 187)) + (this.thisTransform.right * 40), this.thisTransform.forward * VelClamp, Color.green);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * 187)) + (this.thisTransform.right * 40), this.thisTransform.forward, out hit, VelClamp, (int) this.targetLayers))
        {
            if (this.Wall)
            {
                this.Obstacle = true;
            }
        }
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * 187)) + (-this.thisTransform.right * 40), this.thisTransform.forward * VelClamp, Color.green);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * 187)) + (-this.thisTransform.right * 40), this.thisTransform.forward, out hit, VelClamp, (int) this.targetLayers))
        {
            if (this.Wall)
            {
                this.Obstacle = true;
            }
        }
        Debug.DrawRay((((this.thisTransform.position + (this.thisTransform.forward * this.RRUPz)) + (this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 20)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward * VelClamp, Color.black);
        if (Physics.Raycast((((this.thisTransform.position + (this.thisTransform.forward * this.RRUPz)) + (this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 20)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward, out hit1, VelClamp, (int) this.targetLayers))
        {
            this.RPointu = hit1.point;
        }
        else
        {
            this.RPointu = new Vector3(2, 2, 2);
        }
        Debug.DrawRay(((((this.thisTransform.position + (this.thisTransform.forward * this.RRUPz)) + (this.thisTransform.right * this.RRUP)) + (this.thisTransform.right * 1)) + (-this.thisTransform.up * 20)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward * VelClamp, Color.blue);
        if (Physics.Raycast(((((this.thisTransform.position + (this.thisTransform.forward * this.RRUPz)) + (this.thisTransform.right * this.RRUP)) + (this.thisTransform.right * 1)) + (-this.thisTransform.up * 20)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward, out hit3, VelClamp, (int) this.targetLayers))
        {
            this.RPointur = hit3.point;
        }
        else
        {
            this.RPointur = new Vector3(4, 4, 4);
        }
        Debug.DrawRay((((this.thisTransform.position + (this.thisTransform.forward * this.RRUPz)) + (this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 21)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward * VelClamp, Color.black);
        if (Physics.Raycast((((this.thisTransform.position + (this.thisTransform.forward * this.RRUPz)) + (this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 21)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward, out hit2, VelClamp, (int) this.targetLayers))
        {
            this.RPointd = hit2.point;
            this.RightDist = hit2.distance;
        }
        else
        {
            this.RPointd = new Vector3(8, 8, 8);
            this.RightDist = 512;
        }
        if (Vector3.Distance(this.RPointu, this.RPointd) < this.AngClamp)
        {
            this.RWall = true;
        }
        Debug.DrawRay((((this.thisTransform.position + (this.thisTransform.forward * this.RRUPz)) + (-this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 20)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward * VelClamp, Color.black);
        if (Physics.Raycast((((this.thisTransform.position + (this.thisTransform.forward * this.RRUPz)) + (-this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 20)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward, out hit1, VelClamp, (int) this.targetLayers))
        {
            this.LPointu = hit1.point;
        }
        else
        {
            this.LPointu = new Vector3(2, 2, 2);
        }
        Debug.DrawRay(((((this.thisTransform.position + (this.thisTransform.forward * this.RRUPz)) + (-this.thisTransform.right * this.RRUP)) + (-this.thisTransform.right * 1)) + (-this.thisTransform.up * 20)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward * VelClamp, Color.blue);
        if (Physics.Raycast(((((this.thisTransform.position + (this.thisTransform.forward * this.RRUPz)) + (-this.thisTransform.right * this.RRUP)) + (-this.thisTransform.right * 1)) + (-this.thisTransform.up * 20)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward, out hit3, VelClamp, (int) this.targetLayers))
        {
            this.LPointul = hit3.point;
        }
        else
        {
            this.LPointul = new Vector3(4, 4, 4);
        }
        Debug.DrawRay((((this.thisTransform.position + (this.thisTransform.forward * this.RRUPz)) + (-this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 21)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward * VelClamp, Color.black);
        if (Physics.Raycast((((this.thisTransform.position + (this.thisTransform.forward * this.RRUPz)) + (-this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 21)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward, out hit2, VelClamp, (int) this.targetLayers))
        {
            this.LPointd = hit2.point;
            this.LeftDist = hit2.distance;
        }
        else
        {
            this.LPointd = new Vector3(8, 8, 8);
            this.LeftDist = 512;
        }
        if (Vector3.Distance(this.LPointu, this.LPointd) < this.AngClamp)
        {
            this.LWall = true;
        }
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.up * 70)) + (this.thisTransform.forward * VelClamp), -this.thisTransform.up * DMod, Color.white);
        if (!Physics.Raycast((this.thisTransform.position + (this.thisTransform.up * 70)) + (this.thisTransform.forward * VelClamp), -this.thisTransform.up, DMod))
        {
            this.Obstacle = true;
        }
        //---------------------------------------------------------------------------------------------
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.up * 80)) + (this.thisTransform.right * 80)) + (this.thisTransform.forward * VelClamp), this.thisTransform.up * -160, Color.white);
        if (!Physics.Raycast(((this.thisTransform.position + (this.thisTransform.up * 80)) + (this.thisTransform.right * 80)) + (this.thisTransform.forward * VelClamp), -this.thisTransform.up, 160))
        {
            this.TurnLeft = true;
        }
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.up * 80)) + (-this.thisTransform.right * 80)) + (this.thisTransform.forward * VelClamp), this.thisTransform.up * -160, Color.white);
        if (!Physics.Raycast(((this.thisTransform.position + (this.thisTransform.up * 80)) + (-this.thisTransform.right * 80)) + (this.thisTransform.forward * VelClamp), -this.thisTransform.up, 160))
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
        if ((this.LeftDist < 160) && this.LWall)
        {
            this.Obstacle = true;
        }
        if ((this.RightDist < 160) && this.RWall)
        {
            this.Obstacle = true;
        }
    }

    public virtual void FixedUpdate()
    {
        RaycastHit hitD = default(RaycastHit);
        if (this.Damaged)
        {
            this.vRigidbody.angularDrag = 0.05f;
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
                this.vRigidbody.AddTorque(((this.thisTransform.right * 400) * this.vRigidbody.mass) * 0.8f);
                float GravDiv = -Physics.gravity.y;
                this.vRigidbody.AddForce(((Vector3.up * this.vRigidbody.mass) * 0.8f) * GravDiv);
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
        if (this.Obstacle)
        {
            if (-this.localV.y > 0)
            {
                this.vRigidbody.AddForce(-this.thisVTransform.up * -600000);
            }
        }
        if (this.Stuck)
        {
            if (this.localV.y < 8)
            {
                this.vRigidbody.AddForce(this.thisVTransform.up * 600000);
            }
        }
        if (((!this.Obstacle && !this.Stuck) && !this.TurnLeft) && !this.TurnRight)
        {
            if (-this.localV.y < 60)
            {
                this.vRigidbody.AddForce(-this.thisVTransform.up * 600000);
            }
        }
        if (this.target)
        {
            if (this.Turret1RB.angularVelocity.magnitude < 1)
            {
                this.Turret1RB.AddForceAtPosition((this.TargetLead.position - this.Turret1TF.position).normalized * 20, -this.Turret1TF.up * 4);
                this.Turret1RB.AddForceAtPosition((this.TargetLead.position - this.Turret1TF.position).normalized * -20, this.Turret1TF.up * 4);
            }
            if (this.Turret2RB.angularVelocity.magnitude < 1)
            {
                this.Turret2RB.AddForceAtPosition((this.TargetLead.position - this.Turret2TF.position).normalized * 20, -this.Turret2TF.up * 4);
                this.Turret2RB.AddForceAtPosition((this.TargetLead.position - this.Turret2TF.position).normalized * -20, this.Turret2TF.up * 4);
            }
            if (this.Turret3RB.angularVelocity.magnitude < 1)
            {
                this.Turret3RB.AddForceAtPosition((this.TargetLead.position - this.Turret3TF.position).normalized * 20, -this.Turret3TF.up * 4);
                this.Turret3RB.AddForceAtPosition((this.TargetLead.position - this.Turret3TF.position).normalized * -20, this.Turret3TF.up * 4);
            }
            if (this.Turret4RB.angularVelocity.magnitude < 1)
            {
                this.Turret4RB.AddForceAtPosition((this.TargetLead.position - this.Turret4TF.position).normalized * 20, -this.Turret4TF.up * 4);
                this.Turret4RB.AddForceAtPosition((this.TargetLead.position - this.Turret4TF.position).normalized * -20, this.Turret4TF.up * 4);
            }
            if (this.Turret5RB.angularVelocity.magnitude < 1)
            {
                this.Turret5RB.AddForceAtPosition((this.TargetLead.position - this.Turret5TF.position).normalized * 20, -this.Turret5TF.up * 4);
                this.Turret5RB.AddForceAtPosition((this.TargetLead.position - this.Turret5TF.position).normalized * -20, this.Turret5TF.up * 4);
            }
            if (this.Turret6RB.angularVelocity.magnitude < 1)
            {
                this.Turret6RB.AddForceAtPosition((this.TargetLead.position - this.Turret6TF.position).normalized * 20, -this.Turret6TF.up * 4);
                this.Turret6RB.AddForceAtPosition((this.TargetLead.position - this.Turret6TF.position).normalized * -20, this.Turret6TF.up * 4);
            }
            if (this.Turret7RB.angularVelocity.magnitude < 1)
            {
                this.Turret7RB.AddForceAtPosition((this.TargetLead.position - this.Turret7TF.position).normalized * 20, -this.Turret7TF.up * 4);
                this.Turret7RB.AddForceAtPosition((this.TargetLead.position - this.Turret7TF.position).normalized * -20, this.Turret7TF.up * 4);
            }
            if (this.Turret8RB.angularVelocity.magnitude < 1)
            {
                this.Turret8RB.AddForceAtPosition((this.TargetLead.position - this.Turret8TF.position).normalized * 20, -this.Turret8TF.up * 4);
                this.Turret8RB.AddForceAtPosition((this.TargetLead.position - this.Turret8TF.position).normalized * -20, this.Turret8TF.up * 4);
            }
            if (this.TurretB1RB.angularVelocity.magnitude < 0.5f)
            {
                this.TurretB1RB.AddForceAtPosition((this.TargetLead.position - this.TurretB1TF.position).normalized * 500, -this.TurretB1TF.up * 8);
                this.TurretB1RB.AddForceAtPosition((this.TargetLead.position - this.TurretB1TF.position).normalized * -500, this.TurretB1TF.up * 8);
            }
            if (this.TurretB2RB.angularVelocity.magnitude < 0.5f)
            {
                this.TurretB2RB.AddForceAtPosition((this.TargetLead.position - this.TurretB2TF.position).normalized * 500, -this.TurretB2TF.up * 8);
                this.TurretB2RB.AddForceAtPosition((this.TargetLead.position - this.TurretB2TF.position).normalized * -500, this.TurretB2TF.up * 8);
            }
        }
        if (this.GOpen)
        {
            if (this.Gate.localPosition.z > -1.2f)
            {

                {
                    float _2336 = this.Gate.localPosition.z - 0.06f;
                    Vector3 _2337 = this.Gate.localPosition;
                    _2337.z = _2336;
                    this.Gate.localPosition = _2337;
                }
            }
        }
        if (this.GClose)
        {
            if (this.Gate.localPosition.z < 0)
            {

                {
                    float _2338 = this.Gate.localPosition.z + 0.06f;
                    Vector3 _2339 = this.Gate.localPosition;
                    _2339.z = _2338;
                    this.Gate.localPosition = _2339;
                }
            }
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        string ON = other.name;
        Transform OT = other.transform;
        if (ON.Contains("TFC"))
        {
            if (!ON.Contains("TFC7"))
            {
                if (ON.Contains("TFC0a"))
                {
                    this.PissedAtTC0a = 2;
                }
                if (ON.Contains("TFC1"))
                {
                    this.PissedAtTC1 = 2;
                }
                if (ON.Contains("TFC3"))
                {
                    this.PissedAtTC3 = 2;
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
                if (ON.Contains("TFC8"))
                {
                    this.PissedAtTC8 = 2;
                }
                if (ON.Contains("TFC9"))
                {
                    this.PissedAtTC9 = 2;
                }
                if (!this.Attacking && (this.StuckCounter < 1))
                {
                    this.DangerSense = 10;
                    this.target = this.Waypoint;
                    this.Gyro.AimTarget = this.Waypoint;
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
        if (!ON.Contains("TC7"))
        {
            if (Vector3.Distance(this.thisTransform.position, OT.position) < 400)
            {
                if (ON.Contains("TC"))
                {
                    this.Stranger = OT;
                }
            }
            if (this.PissedAtTC0a > 1)
            {
                if (ON.Contains("TC0a"))
                {
                    if ((((ON.Contains("sT") && !this.FoundSmall) && !this.FoundMedium) || ((ON.Contains("mT") && this.FoundSmall) && !this.FoundMedium)) || ON.Contains("bT"))
                    {
                        this.Spot = 0;
                        this.Hunting = false;
                        this.target = OT;
                        if (this.Gyro != null)
                        {
                            this.Gyro.AimTarget = OT;
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
                        this.Spot = 0;
                        this.Hunting = false;
                        this.target = OT;
                        if (this.Gyro != null)
                        {
                            this.Gyro.AimTarget = OT;
                        }
                        this.Attacking = true;
                    }
                }
            }
            if (this.PissedAtTC3 > 1)
            {
                if (!ON.Contains("cT"))
                {
                    if (ON.Contains("TC3"))
                    {
                        if (((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || ON.Contains("bT"))
                        {
                            this.Spot = 0;
                            this.Hunting = false;
                            this.target = OT;
                            if (this.Gyro != null)
                            {
                                this.Gyro.AimTarget = OT;
                            }
                            this.Attacking = true;
                        }
                    }
                }
            }
            if (this.PissedAtTC4 > 1)
            {
                if (ON.Contains("TC4"))
                {
                    if (((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || ON.Contains("bT"))
                    {
                        this.Spot = 0;
                        this.Hunting = false;
                        this.target = OT;
                        if (this.Gyro != null)
                        {
                            this.Gyro.AimTarget = OT;
                        }
                        this.Attacking = true;
                    }
                }
            }
            if (this.PissedAtTC5 > 1)
            {
                if (!ON.Contains("cT"))
                {
                    if (ON.Contains("TC5"))
                    {
                        if (((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || ON.Contains("bT"))
                        {
                            this.Spot = 0;
                            this.Hunting = false;
                            this.target = OT;
                            if (this.Gyro != null)
                            {
                                this.Gyro.AimTarget = OT;
                            }
                            this.Attacking = true;
                        }
                    }
                }
            }
            if (this.PissedAtTC6 > 1)
            {
                if (!ON.Contains("cT"))
                {
                    if (ON.Contains("TC6"))
                    {
                        if (((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || ON.Contains("bT"))
                        {
                            this.Spot = 0;
                            this.Hunting = false;
                            this.target = OT;
                            if (this.Gyro != null)
                            {
                                this.Gyro.AimTarget = OT;
                            }
                            this.Attacking = true;
                        }
                    }
                }
            }
            if (this.PissedAtTC8 > 1)
            {
                if (!ON.Contains("cT"))
                {
                    if (ON.Contains("TC8"))
                    {
                        if (((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || ON.Contains("bT"))
                        {
                            this.Spot = 0;
                            this.Hunting = false;
                            this.target = OT;
                            if (this.Gyro != null)
                            {
                                this.Gyro.AimTarget = OT;
                            }
                            this.Attacking = true;
                        }
                    }
                }
            }
            if (this.PissedAtTC9 > 1)
            {
                if (!ON.Contains("cT"))
                {
                    if (ON.Contains("TC9"))
                    {
                        if (((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || ON.Contains("bT"))
                        {
                            this.Spot = 0;
                            this.Hunting = false;
                            this.target = OT;
                            if (this.Gyro != null)
                            {
                                this.Gyro.AimTarget = OT;
                            }
                            this.Attacking = true;
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
            if (this.MainGunsCooldown < 1)
            {
                this.StartCoroutine(this.ShootB());
            }
            if (!this.FiringMainGuns)
            {
                this.StartCoroutine(this.Shoot());
            }
        }
    }

    public virtual IEnumerator Shoot()
    {
        if (!this.FiringMainGuns)
        {
            if (this.Gun1)
            {
                this.Gun1.Fire();
            }
        }
        yield return new WaitForSeconds(0.5f);
        if (!this.FiringMainGuns)
        {
            if (this.Gun2)
            {
                this.Gun2.Fire();
            }
        }
        yield return new WaitForSeconds(0.5f);
        if (!this.FiringMainGuns)
        {
            if (this.Gun3)
            {
                this.Gun3.Fire();
            }
        }
        yield return new WaitForSeconds(0.5f);
        if (!this.FiringMainGuns)
        {
            if (this.Gun4)
            {
                this.Gun4.Fire();
            }
        }
        yield return new WaitForSeconds(0.5f);
        if (!this.FiringMainGuns)
        {
            if (this.Gun5)
            {
                this.Gun5.Fire();
            }
        }
        yield return new WaitForSeconds(0.5f);
        if (!this.FiringMainGuns)
        {
            if (this.Gun6)
            {
                this.Gun6.Fire();
            }
        }
        yield return new WaitForSeconds(0.5f);
        if (!this.FiringMainGuns)
        {
            if (this.Gun7)
            {
                this.Gun7.Fire();
            }
        }
        yield return new WaitForSeconds(0.5f);
        if (!this.FiringMainGuns)
        {
            if (this.Gun8)
            {
                this.Gun8.Fire();
            }
        }
    }

    public virtual IEnumerator ShootB()
    {
        yield return new WaitForSeconds(1);
        this.ShootingB(true);
        yield return new WaitForSeconds(1.5f);
        this.ShootingB(false);
        yield return new WaitForSeconds(1.5f);
        this.FiringMainGuns = false;
    }

    public virtual void ShootingB(bool FiringRight)
    {
        if (FiringRight)
        {
            if (this.GunB1)
            {
                this.GunB1.Fire();
            }
        }
        else
        {
            if (this.GunB2)
            {
                this.GunB2.Fire();
            }
        }
    }

    public virtual void EmergencyLaunchy()
    {
        if (this.Damaged)
        {
            return;
        }
        if (this.Emergency)
        {
            this.StartCoroutine(this.LaunchCM());
        }
    }

    public virtual void Launchy()
    {
        if (this.Damaged)
        {
            return;
        }
        if (this.Attacking && !this.Emergency)
        {
            if (this.LaunchingCM)
            {
                this.StartCoroutine(this.LaunchCM());
            }
        }
    }

    public virtual IEnumerator SpawnDrone()
    {
        if (this.Damaged)
        {
            yield break;
        }
        this.GateSound.GetComponent<AudioSource>().Play();
        this.SpawnCounter = 15;
        this.GOpen = true;
        this.GClose = false;
        yield return new WaitForSeconds(0.3f);
        if (!this.DistantThreat)
        {
            if (!this.PresentDrone1)
            {
                this.PresentDrone1 = UnityEngine.Object.Instantiate(this.Drone1, this.DroneSpawn2.position, this.DroneSpawn2.rotation) as GameObject;
                this.PresentDrone1.transform.GetChild(1).GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                this.PresentDrone1.transform.GetChild(1).GetComponent<Rigidbody>().AddForce(this.DroneSpawn2.transform.right * 100);
                this.Drone1AI = (MevNavBattledroneAI) this.PresentDrone1.transform.GetChild(0).GetComponent(typeof(MevNavBattledroneAI));
                this.Drone1AI.target = this.Stranger;
                this.Drone1AI.Home = this.AIAnchor;
            }
            else
            {
                if (!this.PresentDrone2)
                {
                    this.PresentDrone2 = UnityEngine.Object.Instantiate(this.Drone1, this.DroneSpawn4.position, this.DroneSpawn4.rotation) as GameObject;
                    this.PresentDrone2.transform.GetChild(1).GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                    this.PresentDrone2.transform.GetChild(1).GetComponent<Rigidbody>().AddForce(this.DroneSpawn4.transform.right * 100);
                    this.Drone2AI = (MevNavBattledroneAI) this.PresentDrone2.transform.GetChild(0).GetComponent(typeof(MevNavBattledroneAI));
                    this.Drone2AI.target = this.Stranger;
                    this.Drone2AI.Home = this.AIAnchor;
                }
            }
        }
        else
        {
            GameObject _SpawnedObjectC1 = UnityEngine.Object.Instantiate(this.Vult, this.DroneSpawn1.position, this.DroneSpawn1.rotation);
            _SpawnedObjectC1.transform.GetChild(1).GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
            ((MevNavBattledroneAI) _SpawnedObjectC1.transform.GetChild(0).GetComponent(typeof(MevNavBattledroneAI))).target = this.target;
            _SpawnedObjectC1.transform.GetChild(1).GetComponent<Rigidbody>().AddForce(this.DroneSpawn1.transform.right * 100);
            GameObject _SpawnedObjectC2 = UnityEngine.Object.Instantiate(this.Vult, this.DroneSpawn3.position, this.DroneSpawn3.rotation);
            _SpawnedObjectC2.transform.GetChild(1).GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
            ((MevNavBattledroneAI) _SpawnedObjectC2.transform.GetChild(0).GetComponent(typeof(MevNavBattledroneAI))).target = this.target;
            ((MevNavBattledroneAI) _SpawnedObjectC2.transform.GetChild(0).GetComponent(typeof(MevNavBattledroneAI))).Pause = true;
            _SpawnedObjectC2.transform.GetChild(1).GetComponent<Rigidbody>().AddForce(this.DroneSpawn3.transform.right * 100);
        }
        yield return new WaitForSeconds(0.35f);
        this.GOpen = false;
        this.GClose = true;
    }

    public virtual IEnumerator LaunchCM()
    {
        if (this.target != null)
        {
            if (this.Attacking && (this.StoredCMissiles > 0))
            {
                if ((Vector3.Distance(this.thisTransform.position, this.target.position) < 3000) && (Vector3.Distance(this.thisTransform.position, this.target.position) > 150))
                {
                    this.StoredCMissiles = this.StoredCMissiles - 1;
                    this.LaunchingCM = false;
                    GameObject _SpawnedObject0 = UnityEngine.Object.Instantiate(this.CMissileAmmo, this.CMissile1.position, this.CMissile1.rotation);
                    _SpawnedObject0.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                    ((MissileScript) _SpawnedObject0.transform.GetComponent(typeof(MissileScript))).target = this.target;
                    yield return new WaitForSeconds(0.5f);
                    GameObject _SpawnedObject1 = UnityEngine.Object.Instantiate(this.CMissileAmmo, this.CMissile2.position, this.CMissile2.rotation);
                    _SpawnedObject1.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                    ((MissileScript) _SpawnedObject1.transform.GetComponent(typeof(MissileScript))).target = this.target;
                    yield return new WaitForSeconds(0.5f);
                    GameObject _SpawnedObject2 = UnityEngine.Object.Instantiate(this.CMissileAmmo, this.CMissile3.position, this.CMissile3.rotation);
                    _SpawnedObject2.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                    ((MissileScript) _SpawnedObject2.transform.GetComponent(typeof(MissileScript))).target = this.target;
                    yield return new WaitForSeconds(0.5f);
                    GameObject _SpawnedObject3 = UnityEngine.Object.Instantiate(this.CMissileAmmo, this.CMissile4.position, this.CMissile4.rotation);
                    _SpawnedObject3.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                    ((MissileScript) _SpawnedObject3.transform.GetComponent(typeof(MissileScript))).target = this.target;
                }
            }
        }
    }

    public virtual void Targety()
    {
        if ((this.Spot < 1) && !this.Attacking)
        {
            this.TargetArea();
        }
    }

    public virtual void TargetArea()
    {
        if ((this.StuckCounter < 1) && !this.Attacking)
        {
            this.Waypoint.transform.position = MevNavNetwork.instance.PriorityWaypoint.position;
            this.target = this.Waypoint;
            this.Gyro.AimTarget = this.Waypoint;
        }
    }

    public virtual void CalcLead()
    {
        if (!this.Damaged)
        {
            this.StartCoroutine(this.Lead());
        }
    }

    public virtual IEnumerator Lead()
    {
        if (this.target)
        {
            this.TargetTrace.position = this.target.position;
        }
        yield return new WaitForSeconds(0.1f);
        if (!this.Damaged)
        {
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
                    this.TLCol.radius = Vector3.Distance(this.thisTransform.position, this.target.position) * 0.1f;
                }
                else
                {
                    this.TLCol.radius = 0.1f;
                }
            }
        }
    }

    public virtual void Regenerator()
    {
        if (this.Damaged)
        {
            MevNavNetwork.AlertTime = 240;
            MevNavNetwork.instance.PriorityWaypoint.position = this.thisTransform.position;
            return;
        }
        if (MevNavNetwork.AlertTime > 230)
        {
            this.TargetArea();
            MevNavNetwork.AlertTime = 230;
        }
        this.PissedAtTC1 = MevNavNetwork.TC1DeathRow;
        this.PissedAtTC2 = MevNavNetwork.TC2DeathRow;
        this.PissedAtTC3 = MevNavNetwork.TC3DeathRow;
        this.PissedAtTC4 = MevNavNetwork.TC4DeathRow;
        this.PissedAtTC5 = MevNavNetwork.TC5DeathRow;
        this.PissedAtTC6 = MevNavNetwork.TC6DeathRow;
        this.PissedAtTC8 = MevNavNetwork.TC8DeathRow;
        this.PissedAtTC9 = MevNavNetwork.TC9DeathRow;
        if (this.MainGunsCooldown > 0)
        {
            this.MainGunsCooldown = this.MainGunsCooldown - 1;
        }
        if (this.target)
        {
            Vector3 lastTPos = this.target.position;
            if (this.target.name.Contains("sT"))
            {
                this.FoundSmall = true;
            }
            if (this.target.name.Contains("mT"))
            {
                this.FoundMedium = true;
            }
            if (this.target.name.Contains("xbT"))
            {
                if (this.SpawnCounter > 15)
                {
                    this.SpawnCounter = 15;
                }
            }
            if (this.Attacking)
            {
                MevNavNetwork.instance.EnemyTarget1 = this.target;
                if (Vector3.Distance(this.thisTransform.position, this.target.position) < 300)
                {
                    this.TargetClose = true;
                    if (this.Drone1AI && this.PresentDrone1)
                    {
                        if (Vector3.Distance(this.PresentDrone1.transform.position, this.target.position) > 500)
                        {
                            this.Drone1AI.target = this.target;
                        }
                    }
                    if (this.Drone2AI && this.PresentDrone2)
                    {
                        if (Vector3.Distance(this.PresentDrone2.transform.position, this.target.position) > 500)
                        {
                            this.Drone2AI.target = this.target;
                        }
                    }
                    if (this.SpawnCounter == 0)
                    {
                        this.StartCoroutine(this.SpawnDrone());
                    }
                }
                if (!this.Emergency)
                {
                    if (Vector3.Distance(this.thisTransform.position, this.target.position) > 850)
                    {
                        if (this.target.name.Contains("bT"))
                        {
                            this.DistantThreat = true;
                            if (this.SpawnCounter == 0)
                            {
                                this.StartCoroutine(this.SpawnDrone());
                            }
                        }
                        else
                        {
                            this.DistantThreat = false;
                            this.LaunchingCM = true;
                        }
                    }
                }
                else
                {
                    if (Vector3.Distance(this.thisTransform.position, this.target.position) > 256)
                    {
                        if (this.target.name.Contains("bT"))
                        {
                            this.DistantThreat = true;
                            if (this.SpawnCounter == 0)
                            {
                                this.StartCoroutine(this.SpawnDrone());
                            }
                        }
                        else
                        {
                            this.DistantThreat = false;
                            this.LaunchingCM = true;
                        }
                    }
                }
            }
            else
            {
                if (this.PissedAtTC0a > 1)
                {
                    if (this.target.name.Contains("TC0a"))
                    {
                        if (!this.target.name.Contains("csT"))
                        {
                            this.Attacking = true;
                        }
                    }
                }
                if (this.PissedAtTC1 > 1)
                {
                    if (this.target.name.Contains("TC1"))
                    {
                        if (!this.target.name.Contains("csT"))
                        {
                            this.Attacking = true;
                        }
                    }
                }
                if (this.PissedAtTC3 > 1)
                {
                    if (this.target.name.Contains("TC3"))
                    {
                        if (!this.target.name.Contains("csT"))
                        {
                            this.Attacking = true;
                        }
                    }
                }
                if (this.PissedAtTC4 > 1)
                {
                    if (this.target.name.Contains("TC4"))
                    {
                        if (!this.target.name.Contains("csT"))
                        {
                            this.Attacking = true;
                        }
                    }
                }
                if (this.PissedAtTC5 > 1)
                {
                    if (this.target.name.Contains("TC5"))
                    {
                        if (!this.target.name.Contains("csT"))
                        {
                            this.Attacking = true;
                        }
                    }
                }
                if (this.PissedAtTC6 > 1)
                {
                    if (this.target.name.Contains("TC6"))
                    {
                        if (!this.target.name.Contains("csT"))
                        {
                            this.Attacking = true;
                        }
                    }
                }
                if (this.PissedAtTC8 > 1)
                {
                    if (this.target.name.Contains("TC8"))
                    {
                        if (!this.target.name.Contains("csT"))
                        {
                            this.Attacking = true;
                        }
                    }
                }
                if (this.PissedAtTC9 > 1)
                {
                    if (this.target.name.Contains("TC9"))
                    {
                        if (!this.target.name.Contains("csT"))
                        {
                            this.Attacking = true;
                        }
                    }
                }
            }
            if (Vector3.Distance(this.thisTransform.position, this.target.position) > 8000)
            {
                if (this.target.name.Contains("TC"))
                {
                    this.target = this.ResetAimpoint;
                    this.Attacking = false;
                }
            }
            if (!this.target.name.Contains("xbT"))
            {
                if (MevNavNetwork.xbTarget)
                {
                    if (Vector3.Distance(this.thisTransform.position, MevNavNetwork.xbTarget.position) < 8000)
                    {
                        if (MevNavNetwork.xbTarget.name.Contains("TC1") && (this.PissedAtTC1 > 400))
                        {
                            this.Spot = 0;
                            this.Hunting = false;
                            this.target = MevNavNetwork.xbTarget;
                            if (this.Gyro != null)
                            {
                                this.Gyro.AimTarget = MevNavNetwork.xbTarget;
                            }
                            this.Attacking = true;
                        }
                        if (MevNavNetwork.xbTarget.name.Contains("TC3") && (this.PissedAtTC3 > 400))
                        {
                            this.Spot = 0;
                            this.Hunting = false;
                            this.target = MevNavNetwork.xbTarget;
                            if (this.Gyro != null)
                            {
                                this.Gyro.AimTarget = MevNavNetwork.xbTarget;
                            }
                            this.Attacking = true;
                        }
                        if (MevNavNetwork.xbTarget.name.Contains("TC5") && (this.PissedAtTC5 > 400))
                        {
                            this.Spot = 0;
                            this.Hunting = false;
                            this.target = MevNavNetwork.xbTarget;
                            if (this.Gyro != null)
                            {
                                this.Gyro.AimTarget = MevNavNetwork.xbTarget;
                            }
                            this.Attacking = true;
                        }
                        if (MevNavNetwork.xbTarget.name.Contains("TC6") && (this.PissedAtTC6 > 400))
                        {
                            this.Spot = 0;
                            this.Hunting = false;
                            this.target = MevNavNetwork.xbTarget;
                            if (this.Gyro != null)
                            {
                                this.Gyro.AimTarget = MevNavNetwork.xbTarget;
                            }
                            this.Attacking = true;
                        }
                        if (MevNavNetwork.xbTarget.name.Contains("TC8") && (this.PissedAtTC8 > 400))
                        {
                            this.Spot = 0;
                            this.Hunting = false;
                            this.target = MevNavNetwork.xbTarget;
                            if (this.Gyro != null)
                            {
                                this.Gyro.AimTarget = MevNavNetwork.xbTarget;
                            }
                            this.Attacking = true;
                        }
                        if (MevNavNetwork.xbTarget.name.Contains("TC9") && (this.PissedAtTC9 > 400))
                        {
                            this.Spot = 0;
                            this.Hunting = false;
                            this.target = MevNavNetwork.xbTarget;
                            if (this.Gyro != null)
                            {
                                this.Gyro.AimTarget = MevNavNetwork.xbTarget;
                            }
                            this.Attacking = true;
                        }
                    }
                }
            }
            this.StartCoroutine(this.Notice2(lastTPos));
        }
        if (this.Attacking)
        {
            this.Trig.center = new Vector3(0, 0, 0);
            this.Trig.size = new Vector3(600, 300, 600);
        }
        else
        {
            this.Trig.center = new Vector3(0, 0, 1700);
            this.Trig.size = new Vector3(600, 300, 4000);
        }
        if ((this.Spot == 1) && !this.Attacking)
        {
            this.Spot = 0;
            this.Hunting = true;
            this.target = this.ResetAimpoint;
            this.Gyro.AimTarget = this.ResetAimpoint;
        }
        if (this.DangerSense > 0)
        {
            if ((this.DangerSense == 1) && !this.Attacking)
            {
                this.target = this.ResetAimpoint;
                this.Gyro.AimTarget = this.ResetAimpoint;
            }
            this.DangerSense = this.DangerSense - 1;
        }
        if (this.Spot > 0)
        {
            this.Spot = this.Spot - 1;
        }
        if (this.SpawnCounter > 0)
        {
            this.SpawnCounter = this.SpawnCounter - 1;
        }
        if (this.Ignorage > 4)
        {
            this.Ignorage = 0;
            this.target = null;
        }
        if (this.StuckCounter > 0)
        {
            if (!this.TurnLeft)
            {
                this.StuckCounter = this.StuckCounter - 1;
            }
        }
        if (this.Stuck)
        {
            if (this.StuckCounter < 18)
            {
                this.Stuck = false;
                this.StuckTimer = 0;
            }
        }
        this.StuckTimer = this.StuckTimer + 1;
        if (this.StuckTimer > 16)
        {
            Vector3 lastPos = this.thisTransform.position;
            this.StartCoroutine(this.IsEscaping(lastPos));
            this.StuckTimer = 0;
        }
        if (this.target == this.Waypoint)
        {
            this.Gyro.AimForce = 1000000;
        }
        else
        {
            this.Gyro.AimForce = 0;
        }
        this.Gyro.TurnForce = 0;
        if (this.OnHull)
        {
            if (this.SpawnCounter == 0)
            {
                this.StartCoroutine(this.SpawnDrone());
            }
            this.OnHull = false;
            this.Obstacle = true;
        }
        this.Wall = false;
        this.RWall = false;
        this.LWall = false;
        this.TurnRight = false;
        this.TurnLeft = false;
        this.StartCoroutine(this.Notice());
    }

    public virtual IEnumerator Notice()
    {
        if (this.Attacking)
        {
            if (this.Emergency)
            {
                MevNavNetwork.instance.EnemyTarget1 = this.target;
            }
            if (this.target != null)
            {
                if ((this.target.name.Contains("bTC") && !this.HasRequested) && (this.StoredCMissiles < 1))
                {
                    this.HasRequested = true;
                    MevNavNetwork.RequestCruiseMissile = true;
                    MevNavNetwork.instance.EnemyTarget2 = this.target;
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

    public virtual IEnumerator IsEscaping(Vector3 lastPos)
    {
        this.Stuck = false;
        this.TurnRight = false;
        this.TurnLeft = false;
        yield return new WaitForSeconds(2);
        if (Vector3.Distance(this.thisTransform.position, lastPos) < 32)
        {
            this.Stuck = true;
            this.StuckCounter = 26;
        }
    }

    public virtual void Damage()
    {
        this.Trig.center = new Vector3(0, 0, 0);
        this.Trig.size = new Vector3(1, 1, 1);
        this.Damaged = true;
    }

    public MevNavWarCruiserAI()
    {
        this.RightDist = 200;
        this.LeftDist = 200;
        this.AngClamp = 2;
        this.StoredCMissiles = 128;
    }

}