using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SlavuicCruiserAI : MonoBehaviour
{
    public Transform target;
    public Transform AimTarget;
    public Transform Comrade;
    public Transform bottomTarget;
    public Transform upperTarget;
    public Transform Waypoint;
    public Transform MapCenter;
    public Transform Base1;
    public Transform DockEnter;
    public Transform DockPoint;
    public Transform DockAim;
    public Transform FineTarget;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public Transform ResetAimpoint;
    public Transform AIAnchor;
    public Transform OverviewB;
    public Transform OverviewMR;
    public Transform OverviewML;
    public Transform RRP;
    public Transform LRP;
    public SlavuicGunController Turret1;
    public SlavuicGunController Turret2;
    public SlavuicGunController Turret3;
    public SlavuicGunController Turret4;
    public SlavuicGunController Turret5;
    public SlavuicGunController Turret6;
    public SlavuicProteusAI RayGun1;
    public SlavuicProteusAI RayGun2;
    public HingeJoint BM100Launcher;
    public Transform RocketModel;
    public MeshRenderer RocketModelR;
    public GameObject Rocket;
    public int LaunchTimerR;
    public int LaunchTimerL;
    public int LaunchTimerC;
    public int DecidingToLaunch;
    public bool LaunchingBM100;
    public Transform BombLauncherR;
    public Transform RBLModel1;
    public Transform RBLModel2;
    public Transform RBLModel3;
    public MeshRenderer RBLModel1R;
    public MeshRenderer RBLModel2R;
    public MeshRenderer RBLModel3R;
    public Transform BombLauncherL;
    public Transform LBLModel1;
    public Transform LBLModel2;
    public Transform LBLModel3;
    public MeshRenderer LBLModel1R;
    public MeshRenderer LBLModel2R;
    public MeshRenderer LBLModel3R;
    public GameObject Bomb;
    public Transform BomberTarget;
    public bool RBombLaunch;
    public bool RBReloading;
    public bool LBombLaunch;
    public bool LBReloading;
    public NPCGun Gun1;
    public NPCGun Gun2;
    public GameObject ThrusterEffect1;
    public GameObject ThrusterEffect2;
    public GameObject ThrusterEffect3;
    public GameObject ThrusterEffect4;
    public GameObject Presence;
    public GameObject AttackSound;
    public GameObject Crewman1;
    public GameObject Crewman2;
    public Transform CrewSpawn1;
    public Transform CrewSpawn2;
    public GameObject LiveCrewman1;
    public GameObject LiveCrewman2;
    public GameObject LiveCrewman3;
    public GameObject LiveCrewman4;
    public int PissedAtTC0a;
    public int PissedAtTC1;
    public int PissedAtTC3;
    public int PissedAtTC4;
    public int PissedAtTC6;
    public int PissedAtTC7;
    public int PissedAtTC8;
    public int PissedAtTC9;
    public bool FoundMedium;
    public bool FoundBig;
    public int DockTimer;
    public int DutyTimer;
    public bool OnDuty;
    public bool ReturningToDock;
    public bool Attacking;
    public bool Obstacle;
    public bool Stuck;
    public int StuckTimer;
    public int StuckCounter;
    public bool Docking;
    public int DockingPart;
    public bool Reversing;
    public bool OnHull;
    public bool Emergency;
    public bool RVO;
    public bool LVO;
    public float RVODist;
    public float LVODist;
    public bool TurnRight;
    public bool TurnLeft;
    public float RightDist;
    public float LeftDist;
    public float RUP;
    public float RRUP;
    public float LRUP;
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
    public Vector3 VelDir;
    public float AimForce;
    public float TurnForce;
    public float Vel;
    public float VelDiv;
    public LayerMask targetLayers;
    public LayerMask MtargetLayers;
    public bool EnemyApproaching;
    public int Distancing;
    public int TurnIn;
    public bool GOpen;
    public bool GClose;
    public int SpawnCounter;
    public int Spot;
    public int Ignorage;
    public int CanLaunch;
    public virtual void Start()
    {
        this.InvokeRepeating("Regenerator", 1, 1);
        this.MapCenter = SlavuicNetwork.instance.gameObject.transform;
        if (SlavuicNetwork.instance.SlavBaseHomePoint)
        {
            this.Base1 = SlavuicNetwork.instance.SlavBaseHomePoint;
        }
        if (this.Base1)
        {
            this.DockTimer = Random.Range(30, 480);
            this.DockEnter = SlavuicNetwork.instance.SlavBaseDock1E;
            this.DockPoint = SlavuicNetwork.instance.SlavBaseDock1P;
            this.DockAim = SlavuicNetwork.instance.SlavBaseDock1A;
        }
        else
        {
            this.DockTimer = 460;
            this.DutyTimer = 600;
            this.OnDuty = true;
        }
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        RaycastHit hit1 = default(RaycastHit);
        RaycastHit hit2 = default(RaycastHit);
        RaycastHit hit3 = default(RaycastHit);
        this.thisTransform.rotation = this.AIAnchor.transform.rotation;
        this.thisTransform.position = this.AIAnchor.transform.position;
        if (this.Attacking)
        {
            if (this.target == this.Waypoint)
            {
                this.target = this.ResetAimpoint;
                this.Attacking = false;
                this.Spot = 0;
            }
            if (this.target == null)
            {
                this.target = this.ResetAimpoint;
                this.Attacking = false;
                this.Spot = 0;
                this.FoundMedium = false;
                this.FoundBig = false;
            }
            else
            {
                if (this.target.name.Contains("broken"))
                {
                    this.target = this.ResetAimpoint;
                    this.Attacking = false;
                    this.Spot = 0;
                    this.FoundMedium = false;
                    this.FoundBig = false;
                }
            }
        }
        this.VelDir = this.vRigidbody.velocity;
        this.localV = this.thisVTransform.InverseTransformDirection(this.VelDir);
        this.Vel = this.vRigidbody.velocity.magnitude;
        if (this.RUP < 16)
        {
            this.RUP = this.RUP + 1;
        }
        else
        {
            this.RUP = 0;
        }
        if (this.RRUP < 24)
        {
            this.RRUP = this.RRUP + 2;
        }
        else
        {
            this.RRUP = 2;
        }
        float VelClamp = Mathf.Clamp(this.Vel * 4, 80, 400);
        this.AngClamp = (int) Mathf.Clamp(this.Vel * 0.15f, 2, 8);
        float DMod1 = 160 - this.Vel;
        float DMod = Mathf.Clamp(DMod1, 1, 160);
        //===========================================================================================================================
        if (this.OnDuty && !this.Docking)
        {
            Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.forward * 70)) + (-this.thisTransform.up * 10)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward * VelClamp, Color.white);
            if (Physics.Raycast(((this.thisTransform.position + (this.thisTransform.forward * 70)) + (-this.thisTransform.up * 10)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward, out hit1, VelClamp, (int) this.targetLayers))
            {
                this.Pointu = hit1.point;
            }
            else
            {
                this.Pointu = new Vector3(2, 2, 2);
            }
            Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.forward * 70)) + (-this.thisTransform.up * 12)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward * VelClamp, Color.white);
            if (Physics.Raycast(((this.thisTransform.position + (this.thisTransform.forward * 70)) + (-this.thisTransform.up * 12)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward, out hit2, VelClamp, (int) this.targetLayers))
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
            if (!this.OnHull)
            {
                this.Obstacle = false;
            }
            Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * 70)) + (this.thisTransform.right * 16), this.thisTransform.forward * VelClamp, Color.green);
            if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * 70)) + (this.thisTransform.right * 16), this.thisTransform.forward, out hit, VelClamp, (int) this.targetLayers))
            {
                if (this.Wall)
                {
                    this.Obstacle = true;
                }
            }
            Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * 70)) + (-this.thisTransform.right * 16), this.thisTransform.forward * VelClamp, Color.green);
            if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * 70)) + (-this.thisTransform.right * 16), this.thisTransform.forward, out hit, VelClamp, (int) this.targetLayers))
            {
                if (this.Wall)
                {
                    this.Obstacle = true;
                }
            }
            Debug.DrawRay((((this.thisTransform.position + (this.thisTransform.forward * 70)) + (this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 6)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward * VelClamp, Color.black);
            if (Physics.Raycast((((this.thisTransform.position + (this.thisTransform.forward * 70)) + (this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 6)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward, out hit1, VelClamp, (int) this.targetLayers))
            {
                this.RPointu = hit1.point;
            }
            else
            {
                this.RPointu = new Vector3(2, 2, 2);
            }
            Debug.DrawRay(((((this.thisTransform.position + (this.thisTransform.forward * 70)) + (this.thisTransform.right * this.RRUP)) + (this.thisTransform.right * 1)) + (-this.thisTransform.up * 6)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward * VelClamp, Color.blue);
            if (Physics.Raycast(((((this.thisTransform.position + (this.thisTransform.forward * 70)) + (this.thisTransform.right * this.RRUP)) + (this.thisTransform.right * 1)) + (-this.thisTransform.up * 6)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward, out hit3, VelClamp, (int) this.targetLayers))
            {
                this.RPointur = hit3.point;
            }
            else
            {
                this.RPointur = new Vector3(4, 4, 4);
            }
            Debug.DrawRay((((this.thisTransform.position + (this.thisTransform.forward * 70)) + (this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 7)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward * VelClamp, Color.black);
            if (Physics.Raycast((((this.thisTransform.position + (this.thisTransform.forward * 70)) + (this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 7)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward, out hit2, VelClamp, (int) this.targetLayers))
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
            Debug.DrawRay((((this.thisTransform.position + (this.thisTransform.forward * 70)) + (-this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 6)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward * VelClamp, Color.black);
            if (Physics.Raycast((((this.thisTransform.position + (this.thisTransform.forward * 70)) + (-this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 6)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward, out hit1, VelClamp, (int) this.targetLayers))
            {
                this.LPointu = hit1.point;
            }
            else
            {
                this.LPointu = new Vector3(2, 2, 2);
            }
            Debug.DrawRay(((((this.thisTransform.position + (this.thisTransform.forward * 70)) + (-this.thisTransform.right * this.RRUP)) + (-this.thisTransform.right * 1)) + (-this.thisTransform.up * 6)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward * VelClamp, Color.blue);
            if (Physics.Raycast(((((this.thisTransform.position + (this.thisTransform.forward * 70)) + (-this.thisTransform.right * this.RRUP)) + (-this.thisTransform.right * 1)) + (-this.thisTransform.up * 6)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward, out hit3, VelClamp, (int) this.targetLayers))
            {
                this.LPointul = hit3.point;
            }
            else
            {
                this.LPointul = new Vector3(4, 4, 4);
            }
            Debug.DrawRay((((this.thisTransform.position + (this.thisTransform.forward * 70)) + (-this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 7)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward * VelClamp, Color.black);
            if (Physics.Raycast((((this.thisTransform.position + (this.thisTransform.forward * 70)) + (-this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 7)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward, out hit2, VelClamp, (int) this.targetLayers))
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
            //===========================================================================================================================
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
            //===========================================================================================================================
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
    }

    public virtual void FixedUpdate()//[Launch]====================================================================================================
    {
        if (this.OnDuty)
        {
            if (!this.Docking)
            {
                if (this.Obstacle)
                {
                    if (-this.localV.y > 0)
                    {
                        this.vRigidbody.AddForce(this.thisVTransform.up * 10000);
                    }
                }
                if (this.Stuck)
                {
                    if (this.localV.y < 8)
                    {
                        this.vRigidbody.AddForce(this.thisVTransform.up * 10000);
                    }
                }
                if (((!this.Obstacle && !this.Stuck) && !this.TurnLeft) && !this.TurnRight)
                {
                    if (!this.Attacking)
                    {
                        if (-this.localV.y < 60)
                        {
                            this.vRigidbody.AddForce(-this.thisVTransform.up * 10000);
                        }
                    }
                    else
                    {
                        if (this.Distancing > 0)
                        {
                            if (-this.localV.y < 80)
                            {
                                this.vRigidbody.AddForce(-this.thisVTransform.up * 15000);
                            }
                        }
                        else
                        {
                            if (-this.localV.y > 2)
                            {
                                this.vRigidbody.AddForce(this.thisVTransform.up * 10000);
                            }
                        }
                    }
                }
                else
                {
                    if ((this.Attacking && !this.ReturningToDock) && this.OnDuty)
                    {
                        this.Reversing = true;
                    }
                }
                if (!this.Stuck)
                {
                    if (this.TurnLeft)
                    {
                        this.AimForce = 0;
                        this.TurnForce = -400000;
                    }
                    if (this.TurnRight)
                    {
                        this.AimForce = 0;
                        this.TurnForce = 400000;
                    }
                }
                else
                {
                    this.AimForce = 0;
                    this.TurnForce = 400000;
                }
                if ((this.TurnRight && this.TurnLeft) && this.Obstacle)
                {
                    this.TurnForce = -400000;
                }
                if (!this.ReturningToDock && this.OnDuty)
                {
                    if ((this.Attacking && !this.Obstacle) && (this.AimTarget != null))
                    {
                        if (!this.TurnRight && !this.TurnLeft)
                        {
                            if (((Vector3.Distance(this.thisTransform.position, this.AimTarget.position) > 300) && !this.TurnRight) && !this.TurnLeft)
                            {
                                this.AimForce = 20000;
                                this.TurnForce = -100000;
                            }
                        }
                    }
                }
            }
            else
            {
                if (!this.Obstacle)
                {
                    if (this.DockingPart == 0)
                    {
                        if (-this.localV.y < 10)
                        {
                            this.vRigidbody.AddForce(-this.thisVTransform.up * 3300);
                        }
                        else
                        {
                            this.vRigidbody.AddForce(this.thisVTransform.up * 5000);
                        }
                    }
                    if (this.DockingPart == 2)
                    {
                        if (-this.localV.y > 1)
                        {
                            this.vRigidbody.AddForce(this.thisVTransform.up * 5000);
                        }
                    }
                }
                else
                {
                    if (-this.localV.y > 0)
                    {
                        this.vRigidbody.AddForce(this.thisVTransform.up * 5000);
                    }
                }
            }
        }
        else
        {
            if (this.Reversing)
            {
                if (this.localV.y < 40)
                {
                    this.vRigidbody.AddForce(this.thisVTransform.up * 3300);
                }
                if (this.TurnRight)
                {
                    this.AimForce = 0;
                    this.TurnForce = 200000;
                }
            }
        }
        this.vRigidbody.AddTorque(this.thisTransform.up * this.TurnForce);
        if (this.AimTarget)
        {
            this.vRigidbody.AddForceAtPosition((this.AimTarget.position - this.thisTransform.position).normalized * this.AimForce, this.thisTransform.forward * 16);
            this.vRigidbody.AddForceAtPosition((this.AimTarget.position - this.thisTransform.position).normalized * -this.AimForce, -this.thisTransform.forward * 16);
        }
        if (this.FineTarget)
        {
            if (this.DockingPart < 4)
            {
                if (!this.Obstacle)
                {
                    if (-this.localV.y < 5)
                    {
                        this.vRigidbody.AddForce((this.FineTarget.position - this.thisTransform.position).normalized * 2000);
                    }
                }
                else
                {
                    if (-this.localV.y < 0.1f)
                    {
                        this.vRigidbody.AddForce((this.FineTarget.position - this.thisTransform.position).normalized * 2000);
                    }
                }
            }
            else
            {
                this.vRigidbody.AddForce((this.FineTarget.position - this.thisTransform.position).normalized * 1000);
            }
        }
        if (this.OnDuty)
        {
            if (this.BomberTarget)
            {
                Vector3 LocalRBLP = this.BombLauncherR.InverseTransformPoint(this.BomberTarget.position);
                Vector3 LocalLBLP = this.BombLauncherL.InverseTransformPoint(this.BomberTarget.position);
                float RPClampX = Mathf.Abs(LocalRBLP.x);
                float LPClampX = Mathf.Abs(LocalLBLP.x);
                if (!this.RBReloading)
                {
                    if (!this.RBombLaunch)
                    {
                        if (LocalRBLP.x < 0)
                        {
                            if ((this.BombLauncherR.localEulerAngles.y < 30) || (this.BombLauncherR.localEulerAngles.y > 180))
                            {

                                {
                                    float _2968 = this.BombLauncherR.localEulerAngles.y + 1;
                                    Vector3 _2969 = this.BombLauncherR.localEulerAngles;
                                    _2969.y = _2968;
                                    this.BombLauncherR.localEulerAngles = _2969;
                                }
                            }
                        }
                        if (LocalRBLP.x > 0)
                        {
                            if ((this.BombLauncherR.localEulerAngles.y > 315) || (this.BombLauncherR.localEulerAngles.y < 180))
                            {

                                {
                                    float _2970 = this.BombLauncherR.localEulerAngles.y - 1;
                                    Vector3 _2971 = this.BombLauncherR.localEulerAngles;
                                    _2971.y = _2970;
                                    this.BombLauncherR.localEulerAngles = _2971;
                                }
                            }
                        }
                    }
                    else
                    {
                        if ((this.BombLauncherR.localEulerAngles.y > 315) || (this.BombLauncherR.localEulerAngles.y < 180))
                        {

                            {
                                float _2972 = this.BombLauncherR.localEulerAngles.y - 1;
                                Vector3 _2973 = this.BombLauncherR.localEulerAngles;
                                _2973.y = _2972;
                                this.BombLauncherR.localEulerAngles = _2973;
                            }
                        }
                    }
                }
                else
                {
                    if ((this.BombLauncherR.localEulerAngles.y > 110) || (this.BombLauncherR.localEulerAngles.y < 0))
                    {

                        {
                            float _2974 = this.BombLauncherR.localEulerAngles.y - 1;
                            Vector3 _2975 = this.BombLauncherR.localEulerAngles;
                            _2975.y = _2974;
                            this.BombLauncherR.localEulerAngles = _2975;
                        }
                    }
                }
                if (!this.LBReloading)
                {
                    if (!this.LBombLaunch)
                    {
                        if (LocalLBLP.x < 0)
                        {
                            if ((this.BombLauncherL.localEulerAngles.y < 45) || (this.BombLauncherL.localEulerAngles.y > 180))
                            {

                                {
                                    float _2976 = this.BombLauncherL.localEulerAngles.y + 1;
                                    Vector3 _2977 = this.BombLauncherL.localEulerAngles;
                                    _2977.y = _2976;
                                    this.BombLauncherL.localEulerAngles = _2977;
                                }
                            }
                        }
                        if (LocalLBLP.x > 0)
                        {
                            if ((this.BombLauncherL.localEulerAngles.y > 330) || (this.BombLauncherL.localEulerAngles.y < 180))
                            {

                                {
                                    float _2978 = this.BombLauncherL.localEulerAngles.y - 1;
                                    Vector3 _2979 = this.BombLauncherL.localEulerAngles;
                                    _2979.y = _2978;
                                    this.BombLauncherL.localEulerAngles = _2979;
                                }
                            }
                        }
                    }
                    else
                    {
                        if ((this.BombLauncherL.localEulerAngles.y < 45) || (this.BombLauncherL.localEulerAngles.y > 180))
                        {

                            {
                                float _2980 = this.BombLauncherL.localEulerAngles.y + 1;
                                Vector3 _2981 = this.BombLauncherL.localEulerAngles;
                                _2981.y = _2980;
                                this.BombLauncherL.localEulerAngles = _2981;
                            }
                        }
                    }
                }
                else
                {
                    if ((this.BombLauncherL.localEulerAngles.y < 250) || (this.BombLauncherL.localEulerAngles.y < 0))
                    {

                        {
                            float _2982 = this.BombLauncherL.localEulerAngles.y + 1;
                            Vector3 _2983 = this.BombLauncherL.localEulerAngles;
                            _2983.y = _2982;
                            this.BombLauncherL.localEulerAngles = _2983;
                        }
                    }
                }
                if (((RPClampX < 16) && (LocalRBLP.y > 100)) && !this.RBombLaunch)
                {
                    this.RBombLaunch = true;
                    this.StartCoroutine(this.RBombing());
                }
                if (((LPClampX < 16) && (LocalLBLP.y > 100)) && !this.LBombLaunch)
                {
                    this.LBombLaunch = true;
                    this.StartCoroutine(this.LBombing());
                }
            }
            else
            {
                if ((this.BombLauncherR.localEulerAngles.y < 20) || (this.BombLauncherR.localEulerAngles.y > 180))
                {

                    {
                        float _2984 = this.BombLauncherR.localEulerAngles.y + 1;
                        Vector3 _2985 = this.BombLauncherR.localEulerAngles;
                        _2985.y = _2984;
                        this.BombLauncherR.localEulerAngles = _2985;
                    }
                }
                if ((this.BombLauncherL.localEulerAngles.y > 340) || (this.BombLauncherL.localEulerAngles.y < 180))
                {

                    {
                        float _2986 = this.BombLauncherL.localEulerAngles.y - 1;
                        Vector3 _2987 = this.BombLauncherL.localEulerAngles;
                        _2987.y = _2986;
                        this.BombLauncherL.localEulerAngles = _2987;
                    }
                }
            }
        }
        if (this.LaunchingBM100)
        {
            if (this.BM100Launcher.spring.targetPosition > -90)
            {

                {
                    float _2988 = this.BM100Launcher.spring.targetPosition - 0.5f;
                    JointSpring _2989 = this.BM100Launcher.spring;
                    _2989.targetPosition = _2988;
                    this.BM100Launcher.spring = _2989;
                }
            }
        }
        else
        {
            if (this.BM100Launcher.spring.targetPosition < 0)
            {

                {
                    float _2990 = this.BM100Launcher.spring.targetPosition + 0.5f;
                    JointSpring _2991 = this.BM100Launcher.spring;
                    _2991.targetPosition = _2990;
                    this.BM100Launcher.spring = _2991;
                }
            }
        }
        //[Launch]====================================================================================================
        if (this.target)
        {
            if ((this.Attacking && (this.CanLaunch < 1)) && this.OnDuty)
            {
                if (this.LaunchTimerC < 29)
                {
                    if (!Physics.Linecast(this.OverviewB.position, this.target.position, (int) this.MtargetLayers))
                    {
                        if (this.target.name.Contains("bTC"))
                        {
                            if (this.LaunchTimerC == 0)
                            {
                                this.Turret1.Firing = true;
                            }
                            if (this.LaunchTimerC == 14)
                            {
                                this.Turret2.Firing = true;
                            }
                        }
                    }
                    this.LaunchTimerC = this.LaunchTimerC + 1;
                }
                else
                {
                    this.LaunchTimerC = 0;
                }
                if (this.LaunchTimerR < 15)
                {
                    if (!Physics.Linecast(this.OverviewMR.position, this.target.position, (int) this.MtargetLayers))
                    {
                        if (this.LaunchTimerR == 0)
                        {
                            this.Turret3.Firing = true;
                        }
                        if (this.LaunchTimerR == 7)
                        {
                            this.Turret4.Firing = true;
                            this.RVO = false;
                        }
                    }
                    else
                    {
                        this.RVO = true;
                    }
                    this.LaunchTimerR = this.LaunchTimerR + 1;
                }
                else
                {
                    this.LaunchTimerR = 0;
                }
                if (this.LaunchTimerL < 15)
                {
                    if (!Physics.Linecast(this.OverviewML.position, this.target.position, (int) this.MtargetLayers))
                    {
                        if (this.LaunchTimerL == 0)
                        {
                            this.Turret5.Firing = true;
                        }
                        if (this.LaunchTimerL == 7)
                        {
                            this.Turret6.Firing = true;
                            this.LVO = false;
                        }
                    }
                    else
                    {
                        this.LVO = true;
                    }
                    this.LaunchTimerL = this.LaunchTimerL + 1;
                }
                else
                {
                    this.LaunchTimerL = 0;
                }
            }
        }
    }

    public virtual IEnumerator RBombing()
    {
        GameObject _SpawnedObject01 = UnityEngine.Object.Instantiate(this.Bomb, this.RBLModel1.position, this.RBLModel1.rotation);
        _SpawnedObject01.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
        this.RBLModel1R.enabled = false;
        yield return new WaitForSeconds(0.5f);
        GameObject _SpawnedObject02 = UnityEngine.Object.Instantiate(this.Bomb, this.RBLModel2.position, this.RBLModel2.rotation);
        _SpawnedObject02.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
        this.RBLModel2R.enabled = false;
        yield return new WaitForSeconds(0.5f);
        GameObject _SpawnedObject03 = UnityEngine.Object.Instantiate(this.Bomb, this.RBLModel3.position, this.RBLModel3.rotation);
        _SpawnedObject03.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
        this.RBLModel3R.enabled = false;
        yield return new WaitForSeconds(3);
        this.RBReloading = true;
        yield return new WaitForSeconds(15);
        this.RBLModel1R.enabled = true;
        this.RBLModel2R.enabled = true;
        this.RBLModel3R.enabled = true;
        this.RBReloading = false;
        yield return new WaitForSeconds(2);
        this.RBombLaunch = false;
    }

    public virtual IEnumerator LBombing()
    {
        GameObject _SpawnedObject04 = UnityEngine.Object.Instantiate(this.Bomb, this.LBLModel1.position, this.LBLModel1.rotation);
        _SpawnedObject04.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
        this.LBLModel1R.enabled = false;
        yield return new WaitForSeconds(0.5f);
        GameObject _SpawnedObject05 = UnityEngine.Object.Instantiate(this.Bomb, this.LBLModel2.position, this.LBLModel2.rotation);
        _SpawnedObject05.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
        this.LBLModel2R.enabled = false;
        yield return new WaitForSeconds(0.5f);
        GameObject _SpawnedObject06 = UnityEngine.Object.Instantiate(this.Bomb, this.LBLModel3.position, this.LBLModel3.rotation);
        _SpawnedObject06.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
        this.LBLModel3R.enabled = false;
        yield return new WaitForSeconds(3);
        this.LBReloading = true;
        yield return new WaitForSeconds(15);
        this.LBLModel1R.enabled = true;
        this.LBLModel2R.enabled = true;
        this.LBLModel3R.enabled = true;
        this.LBReloading = false;
        yield return new WaitForSeconds(2);
        this.LBombLaunch = false;
    }

    public virtual void TargetIn(Transform other)
    {
        string ON = other.name;
        if (!ON.Contains("TC5"))
        {
            if (this.PissedAtTC0a > 1)
            {
                if (ON.Contains("TC0a"))
                {
                    if (((ON.Contains("mT") && !this.FoundMedium) || (ON.Contains("bT") && !this.FoundBig)) || ON.Contains("xbT"))
                    {
                        this.Spot = 0;
                        this.target = other;
                        if (!this.Attacking)
                        {
                            this.AttackNoise();
                        }
                        this.Attacking = true;
                        this.PissedAtTC0a = this.PissedAtTC0a - 1;
                    }
                }
            }
            if (this.PissedAtTC1 > 1)
            {
                if (ON.Contains("TC1"))
                {
                    if (((ON.Contains("mT") && !this.FoundMedium) || (ON.Contains("bT") && !this.FoundBig)) || ON.Contains("xbT"))
                    {
                        this.Spot = 0;
                        this.target = other;
                        if (!this.Attacking)
                        {
                            this.AttackNoise();
                        }
                        this.Attacking = true;
                        this.PissedAtTC1 = this.PissedAtTC1 - 1;
                    }
                }
            }
            if (this.PissedAtTC3 > 1)
            {
                if (!ON.Contains("cT"))
                {
                    if (ON.Contains("TC3"))
                    {
                        if (((ON.Contains("mT") && !this.FoundMedium) || (ON.Contains("bT") && !this.FoundBig)) || ON.Contains("xbT"))
                        {
                            this.Spot = 0;
                            this.target = other;
                            if (!this.Attacking)
                            {
                                this.AttackNoise();
                            }
                            this.Attacking = true;
                            this.PissedAtTC3 = this.PissedAtTC3 - 1;
                        }
                    }
                }
            }
            if (this.PissedAtTC4 > 1)
            {
                if (ON.Contains("TC4"))
                {
                    if (((ON.Contains("mT") && !this.FoundMedium) || (ON.Contains("bT") && !this.FoundBig)) || ON.Contains("xbT"))
                    {
                        this.Spot = 0;
                        this.target = other;
                        if (!this.Attacking)
                        {
                            this.AttackNoise();
                        }
                        this.Attacking = true;
                        this.PissedAtTC4 = this.PissedAtTC4 - 1;
                    }
                }
            }
            if (this.PissedAtTC7 > 1)
            {
                if (!ON.Contains("cT"))
                {
                    if (ON.Contains("TC7"))
                    {
                        if (((ON.Contains("mT") && !this.FoundMedium) || (ON.Contains("bT") && !this.FoundBig)) || ON.Contains("xbT"))
                        {
                            this.Spot = 0;
                            this.target = other;
                            if (!this.Attacking)
                            {
                                this.AttackNoise();
                            }
                            this.Attacking = true;
                            this.PissedAtTC7 = this.PissedAtTC7 - 1;
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
                        if (((ON.Contains("mT") && !this.FoundMedium) || (ON.Contains("bT") && !this.FoundBig)) || ON.Contains("xbT"))
                        {
                            this.Spot = 0;
                            this.target = other;
                            if (!this.Attacking)
                            {
                                this.AttackNoise();
                            }
                            this.Attacking = true;
                            this.PissedAtTC6 = this.PissedAtTC6 - 1;
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
                        if (((ON.Contains("mT") && !this.FoundMedium) || (ON.Contains("bT") && !this.FoundBig)) || ON.Contains("xbT"))
                        {
                            this.Spot = 0;
                            this.target = other;
                            if (!this.Attacking)
                            {
                                this.AttackNoise();
                            }
                            this.Attacking = true;
                            this.PissedAtTC8 = this.PissedAtTC8 - 1;
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
                        if (((ON.Contains("mT") && !this.FoundMedium) || (ON.Contains("bT") && !this.FoundBig)) || ON.Contains("xbT"))
                        {
                            this.Spot = 0;
                            this.target = other;
                            if (!this.Attacking)
                            {
                                this.AttackNoise();
                            }
                            this.Attacking = true;
                            this.PissedAtTC9 = this.PissedAtTC9 - 1;
                        }
                    }
                }
            }
            if (this.Attacking)
            {
                if (ON.Contains("mT"))
                {
                    this.FoundMedium = true;
                }
                if (ON.Contains("bT"))
                {
                    this.FoundBig = true;
                }
            }
        }
    }

    public virtual void AttackNoise()
    {
        GameObject TheThing = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
        TheThing.transform.parent = this.thisTransform;
    }

    public virtual void Regenerator()
    {
        RaycastHit hitO = default(RaycastHit);
        this.Wall = false;
        this.RWall = false;
        this.LWall = false;
        this.TurnRight = false;
        this.TurnLeft = false;
        if (SlavuicNetwork.TC1DeathRow > 8)
        {
            this.PissedAtTC1 = SlavuicNetwork.TC1DeathRow;
        }
        if (SlavuicNetwork.TC3DeathRow > 8)
        {
            this.PissedAtTC3 = SlavuicNetwork.TC3DeathRow;
        }
        if (SlavuicNetwork.TC4DeathRow > 8)
        {
            this.PissedAtTC4 = SlavuicNetwork.TC4DeathRow;
        }
        if (SlavuicNetwork.TC6DeathRow > 8)
        {
            this.PissedAtTC6 = SlavuicNetwork.TC6DeathRow;
        }
        if (SlavuicNetwork.TC7DeathRow > 8)
        {
            this.PissedAtTC7 = SlavuicNetwork.TC7DeathRow;
        }
        if (SlavuicNetwork.TC8DeathRow > 8)
        {
            this.PissedAtTC8 = SlavuicNetwork.TC8DeathRow;
        }
        if (SlavuicNetwork.TC9DeathRow > 8)
        {
            this.PissedAtTC9 = SlavuicNetwork.TC9DeathRow;
        }
        if (this.upperTarget)
        {
            string ON = this.upperTarget.name;
            if (!ON.Contains("bM"))
            {
                if (this.PissedAtTC1 > 1)
                {
                    if (ON.Contains("TC1"))
                    {
                        if (this.RayGun1.target)
                        {
                            if (!this.RayGun1.target.name.Contains("TC"))
                            {
                                this.RayGun1.target = this.upperTarget;
                            }
                        }
                        if (this.RayGun2.target)
                        {
                            if (!this.RayGun2.target.name.Contains("TC"))
                            {
                                this.RayGun2.target = this.upperTarget;
                            }
                        }
                    }
                }
                if (this.PissedAtTC3 > 1)
                {
                    if (!ON.Contains("cT"))
                    {
                        if (ON.Contains("TC3"))
                        {
                            if (this.RayGun1.target)
                            {
                                if (!this.RayGun1.target.name.Contains("TC"))
                                {
                                    this.RayGun1.target = this.upperTarget;
                                }
                            }
                            if (this.RayGun2.target)
                            {
                                if (!this.RayGun2.target.name.Contains("TC"))
                                {
                                    this.RayGun2.target = this.upperTarget;
                                }
                            }
                        }
                    }
                }
                if (this.PissedAtTC4 > 1)
                {
                    if (ON.Contains("TC4"))
                    {
                        if (this.RayGun1.target)
                        {
                            if (!this.RayGun1.target.name.Contains("TC"))
                            {
                                this.RayGun1.target = this.upperTarget;
                            }
                        }
                        if (this.RayGun2.target)
                        {
                            if (!this.RayGun2.target.name.Contains("TC"))
                            {
                                this.RayGun2.target = this.upperTarget;
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
                            if (this.RayGun1.target)
                            {
                                if (!this.RayGun1.target.name.Contains("TC"))
                                {
                                    this.RayGun1.target = this.upperTarget;
                                }
                            }
                            if (this.RayGun2.target)
                            {
                                if (!this.RayGun2.target.name.Contains("TC"))
                                {
                                    this.RayGun2.target = this.upperTarget;
                                }
                            }
                        }
                    }
                }
                if (this.PissedAtTC7 > 1)
                {
                    if (ON.Contains("TC7"))
                    {
                        if (this.RayGun1.target)
                        {
                            if (!this.RayGun1.target.name.Contains("TC"))
                            {
                                this.RayGun1.target = this.upperTarget;
                            }
                        }
                        if (this.RayGun2.target)
                        {
                            if (!this.RayGun2.target.name.Contains("TC"))
                            {
                                this.RayGun2.target = this.upperTarget;
                            }
                        }
                    }
                }
                if (this.PissedAtTC8 > 1)
                {
                    if (ON.Contains("TC8"))
                    {
                        if (this.RayGun1.target)
                        {
                            if (!this.RayGun1.target.name.Contains("TC"))
                            {
                                this.RayGun1.target = this.upperTarget;
                            }
                        }
                        if (this.RayGun2.target)
                        {
                            if (!this.RayGun2.target.name.Contains("TC"))
                            {
                                this.RayGun2.target = this.upperTarget;
                            }
                        }
                    }
                }
                if (this.PissedAtTC9 > 1)
                {
                    if (ON.Contains("TC9"))
                    {
                        if (this.RayGun1.target)
                        {
                            if (!this.RayGun1.target.name.Contains("TC"))
                            {
                                this.RayGun1.target = this.upperTarget;
                            }
                        }
                        if (this.RayGun2.target)
                        {
                            if (!this.RayGun2.target.name.Contains("TC"))
                            {
                                this.RayGun2.target = this.upperTarget;
                            }
                        }
                    }
                }
            }
            else
            {
                this.RayGun1.target = this.upperTarget;
                this.RayGun2.target = this.upperTarget;
            }
        }
        if (this.bottomTarget)
        {
            string ON = this.bottomTarget.name;
            if (Vector3.Distance(this.thisTransform.position, this.bottomTarget.position) < 200)
            {
                if (!ON.Contains("sT"))
                {
                    if (this.PissedAtTC1 > 1)
                    {
                        if (ON.Contains("TC1"))
                        {
                            this.BomberTarget = this.bottomTarget;
                            this.Distancing = 10;
                            this.Stuck = false;
                        }
                    }
                    if (this.PissedAtTC3 > 1)
                    {
                        if (!ON.Contains("cT"))
                        {
                            if (ON.Contains("TC3"))
                            {
                                this.BomberTarget = this.bottomTarget;
                                this.Distancing = 10;
                                this.Stuck = false;
                            }
                        }
                    }
                    if (this.PissedAtTC4 > 1)
                    {
                        if (ON.Contains("TC4"))
                        {
                            this.BomberTarget = this.bottomTarget;
                            this.Distancing = 10;
                            this.Stuck = false;
                        }
                    }
                    if (this.PissedAtTC6 > 1)
                    {
                        if (!ON.Contains("cT"))
                        {
                            if (ON.Contains("TC6"))
                            {
                                this.BomberTarget = this.bottomTarget;
                                this.Distancing = 10;
                                this.Stuck = false;
                            }
                        }
                    }
                    if (this.PissedAtTC7 > 1)
                    {
                        if (!ON.Contains("cT"))
                        {
                            if (ON.Contains("TC7"))
                            {
                                this.BomberTarget = this.bottomTarget;
                                this.Distancing = 10;
                                this.Stuck = false;
                            }
                        }
                    }
                    if (this.PissedAtTC8 > 1)
                    {
                        if (!ON.Contains("cT"))
                        {
                            if (ON.Contains("TC8"))
                            {
                                this.BomberTarget = this.bottomTarget;
                                this.Distancing = 10;
                                this.Stuck = false;
                            }
                        }
                    }
                    if (this.PissedAtTC9 > 1)
                    {
                        if (!ON.Contains("cT"))
                        {
                            if (ON.Contains("TC9"))
                            {
                                this.BomberTarget = this.bottomTarget;
                                this.Distancing = 10;
                                this.Stuck = false;
                            }
                        }
                    }
                }
            }
        }
        if (this.target)
        {
            if (!this.Base1)
            {
                this.DutyTimer = 64;
            }
            else
            {
                if (Vector3.Distance(this.target.position, this.Base1.position) < 500)
                {
                    this.CanLaunch = 4;
                }
            }
            Vector3 lastTPos = this.target.position;
            this.StartCoroutine(this.Notice2(lastTPos));
            if (this.BomberTarget)
            {
                if (this.BomberTarget.name.Contains("broken"))
                {
                    this.BomberTarget = null;
                }
            }
            if (this.Attacking)
            {
                if (this.OnDuty)
                {
                    if (!this.ReturningToDock)
                    {
                        this.Reversing = false;
                    }
                    if (this.RVO && this.LVO)
                    {
                        this.RVODist = 1000;
                        this.LVODist = 1000;
                        Debug.DrawRay(this.OverviewMR.position, -this.RRP.up * 1000, Color.red);
                        if (Physics.Raycast(this.OverviewMR.position, -this.RRP.up, out hitO, 1000, (int) this.MtargetLayers))
                        {
                            this.RVODist = hitO.distance;
                        }
                        Debug.DrawRay(this.OverviewML.position, -this.LRP.up * 1000, Color.red);
                        if (Physics.Raycast(this.OverviewML.position, -this.LRP.up, out hitO, 1000, (int) this.MtargetLayers))
                        {
                            this.LVODist = hitO.distance;
                        }
                        if (this.RVODist > this.LVODist)
                        {
                            this.TurnLeft = true;
                            this.TurnRight = false;
                            if (!this.ReturningToDock && this.OnDuty)
                            {
                                this.Reversing = true;
                            }
                        }
                        if (this.LVODist > this.RVODist)
                        {
                            this.TurnRight = true;
                            this.TurnLeft = false;
                            if (!this.ReturningToDock && this.OnDuty)
                            {
                                this.Reversing = true;
                            }
                        }
                    }
                }
                if (this.target.name.Contains("bT"))
                {
                    if (SlavuicNetwork.Emergency)
                    {
                        this.Emergency = true;
                    }
                }
                if (this.Emergency)
                {
                    this.DecidingToLaunch = this.DecidingToLaunch + 1;
                    if ((this.DecidingToLaunch > 15) && !this.LaunchingBM100)
                    {
                        this.LaunchingBM100 = true;
                        this.StartCoroutine(this.LaunchBM100());
                    }
                    if (this.target.name.Contains("xbT"))
                    {
                        SlavuicNetwork.primaryTarget = this.target;
                    }
                }
            }
            else
            {
                if (this.DecidingToLaunch > 0)
                {
                    this.DecidingToLaunch = this.DecidingToLaunch - 1;
                }
            }
        }
        if (this.OnDuty)
        {
            if (this.Attacking)
            {
                this.Turret1.LeadDiv = this.Vel;
                this.Turret1.VelDir = this.VelDir;
                this.Turret2.LeadDiv = this.Vel;
                this.Turret2.VelDir = this.VelDir;
                this.Turret3.LeadDiv = this.Vel;
                this.Turret3.VelDir = this.VelDir;
                this.Turret4.LeadDiv = this.Vel;
                this.Turret4.VelDir = this.VelDir;
                this.Turret5.LeadDiv = this.Vel;
                this.Turret5.VelDir = this.VelDir;
                this.Turret6.LeadDiv = this.Vel;
                this.Turret6.VelDir = this.VelDir;
                if (this.AimTarget && !this.Docking)
                {
                    if (Vector3.Distance(this.thisTransform.position, this.AimTarget.position) < 330)
                    {
                        this.Distancing = 10;
                    }
                    else
                    {
                        if (this.Distancing > 0)
                        {
                            this.Distancing = this.Distancing - 1;
                        }
                    }
                }
                if (this.target)
                {
                    if (Vector3.Distance(this.thisTransform.position, this.target.position) > 2000)
                    {
                        this.target = this.ResetAimpoint;
                        this.Attacking = false;
                        this.Spot = 0;
                        this.FoundMedium = false;
                        this.FoundBig = false;
                    }
                    if (!this.target.name.Contains("TC"))
                    {
                        this.Attacking = false;
                    }
                }
                if (this.CanLaunch > 0)
                {
                    this.CanLaunch = this.CanLaunch - 1;
                }
            }
            else
            {
                if (SlavuicNetwork.Emergency)
                {
                    if (SlavuicNetwork.target)
                    {
                        if (Vector3.Distance(this.thisTransform.position, SlavuicNetwork.target.position) < 2000)
                        {
                            if (SlavuicNetwork.TC0aDeathRow > 100)
                            {
                                if (SlavuicNetwork.target.name.Contains("TC0a"))
                                {
                                    this.target = SlavuicNetwork.target;
                                    this.Attacking = true;
                                }
                            }
                            if (SlavuicNetwork.TC1DeathRow > 100)
                            {
                                if (SlavuicNetwork.target.name.Contains("TC1"))
                                {
                                    this.target = SlavuicNetwork.target;
                                    this.Attacking = true;
                                }
                            }
                            if (SlavuicNetwork.TC3DeathRow > 100)
                            {
                                if (SlavuicNetwork.target.name.Contains("TC3"))
                                {
                                    this.target = SlavuicNetwork.target;
                                    this.Attacking = true;
                                }
                            }
                            if (SlavuicNetwork.TC4DeathRow > 100)
                            {
                                if (SlavuicNetwork.target.name.Contains("TC4"))
                                {
                                    this.target = SlavuicNetwork.target;
                                    this.Attacking = true;
                                }
                            }
                            if (SlavuicNetwork.TC6DeathRow > 100)
                            {
                                if (SlavuicNetwork.target.name.Contains("TC6"))
                                {
                                    this.target = SlavuicNetwork.target;
                                    this.Attacking = true;
                                }
                            }
                            if (SlavuicNetwork.TC7DeathRow > 100)
                            {
                                if (SlavuicNetwork.target.name.Contains("TC7"))
                                {
                                    this.target = SlavuicNetwork.target;
                                    this.Attacking = true;
                                }
                            }
                            if (SlavuicNetwork.TC8DeathRow > 100)
                            {
                                if (SlavuicNetwork.target.name.Contains("TC8"))
                                {
                                    this.target = SlavuicNetwork.target;
                                    this.Attacking = true;
                                }
                            }
                            if (SlavuicNetwork.TC9DeathRow > 100)
                            {
                                if (SlavuicNetwork.target.name.Contains("TC9"))
                                {
                                    this.target = SlavuicNetwork.target;
                                    this.Attacking = true;
                                }
                            }
                        }
                    }
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
                    if (this.StuckCounter < 28)
                    {
                        this.Stuck = false;
                        this.StuckTimer = 0;
                    }
                }
                else
                {
                    if (this.TurnIn > 0)
                    {
                        if (Vector3.Distance(this.thisTransform.position, this.MapCenter.position) > 5000)
                        {
                            this.TurnIn = this.TurnIn - 1;
                        }
                    }
                    else
                    {
                        this.TurnIn = 60;
                    }
                    if (this.TurnIn < 8)
                    {
                        Vector3 relativePoint = this.thisVTransform.InverseTransformPoint(this.MapCenter.position);
                        if (relativePoint.y > 0)
                        {
                            this.TurnIn = 7;
                        }
                        this.target = this.MapCenter;
                        this.AimForce = 10000;
                    }
                    else
                    {
                        this.target = this.ResetAimpoint;
                    }
                    if (this.Comrade)
                    {
                        if (Vector3.Distance(this.thisTransform.position, this.Comrade.position) < 330)
                        {
                            Vector3 relativeCPoint = this.thisVTransform.InverseTransformPoint(this.Comrade.position);
                            if (relativeCPoint.y < 0)
                            {
                                this.Stuck = true;
                            }
                        }
                    }
                }
                this.StuckTimer = this.StuckTimer + 1;
                if (this.StuckTimer > 24)
                {
                    Vector3 lastPos = this.thisTransform.position;
                    this.StartCoroutine(this.IsEscaping(lastPos));
                    this.StuckTimer = 0;
                }
                if (SlavuicNetwork.FoundExtraBig)
                {
                    this.Waypoint.position = SlavuicNetwork.instance.PriorityWaypoint.position;
                    this.target = this.Waypoint;
                }
                this.CanLaunch = 3;
                if (this.DutyTimer > 0)
                {
                    this.DutyTimer = this.DutyTimer - 1;
                }
                else
                {
                    if (this.AimTarget)
                    {
                        Vector3 relativeDPoint = this.thisVTransform.InverseTransformPoint(this.AimTarget.position);

                        float RDP = Mathf.Abs(relativeDPoint.x);
                        if (this.Docking)
                        {
                            if (-relativeDPoint.y > 0)
                            {
                                if (RDP < 8)
                                {
                                    this.Obstacle = false;
                                }
                                else
                                {
                                    this.Obstacle = true;
                                }
                            }
                            else
                            {
                                this.Obstacle = true;
                            }
                        }
                    }
                    this.ReturningToDock = true;
                    if ((this.AimTarget != this.DockEnter) && (this.AimTarget != this.DockAim))
                    {
                        this.AimTarget = this.DockEnter;
                    }
                    if (this.AimTarget == this.DockEnter)
                    {
                        this.AimForce = 20000;
                        if (Vector3.Distance(this.thisTransform.position, this.DockEnter.position) < 330)
                        {
                            this.Docking = true;
                            if (Vector3.Distance(this.thisTransform.position, this.DockEnter.position) < 16)
                            {
                                this.DockingPart = 1;
                                this.FineTarget = this.DockEnter;
                            }
                            else
                            {
                                this.DockingPart = 0;
                            }
                        }
                        else
                        {
                            this.Docking = false;
                        }
                        if (Vector3.Distance(this.thisTransform.position, this.DockEnter.position) < 1)
                        {
                            this.AimTarget = this.DockAim;
                            this.Docking = true;
                        }
                    }
                    if (this.AimTarget == this.DockAim)
                    {
                        this.AimForce = 20000;
                        this.DockingPart = 1;
                        this.Docking = true;
                        this.FineTarget = this.DockPoint;
                        if (Vector3.Distance(this.thisTransform.position, this.DockPoint.position) < 16)
                        {
                            if (Vector3.Distance(this.thisTransform.position, this.DockPoint.position) < 1)
                            {
                                this.ReturningToDock = false;
                                this.Reversing = false;
                                this.Docking = false;
                                this.OnDuty = false;
                                this.DockingPart = 0;
                            }
                            else
                            {
                                this.DockingPart = 2;
                            }
                        }
                    }
                }
            }
            if (!this.ReturningToDock)
            {
                this.AimTarget = this.target;
            }
        }
        else
        {
            if (this.target)
            {
                if (!this.target.name.Contains("TC"))
                {
                    this.Attacking = false;
                }
            }
            if (this.DockingPart < 4)
            {
                this.DockingPart = this.DockingPart + 1;
            }
            this.DockTimer = this.DockTimer - 1;
            if (this.DockTimer < 20)
            {
                this.Reversing = true;
                if (this.DockTimer < 5)
                {
                    this.TurnRight = true;
                }
                if (this.DockTimer < 1)
                {
                    this.OnDuty = true;
                    this.Docking = false;
                    this.Reversing = false;
                    this.DockTimer = 480;
                    this.DutyTimer = 600;
                    //Reversionaise = 0;
                    this.FineTarget = null;
                }
                this.AimTarget = this.ResetAimpoint;
            }
            else
            {
                this.AimForce = 10000;
                this.AimTarget = this.DockAim;
                this.FineTarget = this.DockPoint;
            }
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
        if (this.AimTarget == this.Waypoint)
        {
            this.AimForce = 40000;
        }
        this.TurnForce = 0;
        if (this.OnHull)
        {
            if (this.SpawnCounter == 0)
            {
                this.StartCoroutine(this.DeployCrew());
            }
            this.OnHull = false;
        }
        this.StartCoroutine(this.SenseTargDir());
    }

    public virtual IEnumerator SenseTargDir()
    {
        if (this.target)
        {
            float targPos = Vector3.Distance(this.thisTransform.position, this.target.position);
            yield return new WaitForSeconds(0.5f);
            if (this.target)
            {
                if (Vector3.Distance(this.thisTransform.position, this.target.position) < targPos)
                {
                    this.EnemyApproaching = true;
                }
                else
                {
                    this.EnemyApproaching = false;
                }
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

    public virtual IEnumerator DeployCrew()
    {
        this.SpawnCounter = 16;
        if (!this.LiveCrewman1)
        {
            this.LiveCrewman1 = UnityEngine.Object.Instantiate(this.Crewman1, this.CrewSpawn1.position, this.CrewSpawn1.rotation);
            this.LiveCrewman1.transform.GetChild(0).GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
            this.LiveCrewman1.transform.GetChild(0).transform.GetChild(1).GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
            ((SlavuicPersonAI) this.LiveCrewman1.transform.GetChild(0).transform.GetChild(0).transform.GetComponent(typeof(SlavuicPersonAI))).FreeRoam = true;
        }
        if (!this.LiveCrewman2)
        {
            this.LiveCrewman2 = UnityEngine.Object.Instantiate(this.Crewman2, this.CrewSpawn2.position, this.CrewSpawn2.rotation);
            this.LiveCrewman2.transform.GetChild(0).GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
            this.LiveCrewman2.transform.GetChild(0).transform.GetChild(1).GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
            ((SlavuicPersonAI) this.LiveCrewman2.transform.GetChild(0).transform.GetChild(0).transform.GetComponent(typeof(SlavuicPersonAI))).FreeRoam = true;
        }
        yield return new WaitForSeconds(8);
        if (!this.LiveCrewman3)
        {
            this.LiveCrewman3 = UnityEngine.Object.Instantiate(this.Crewman1, this.CrewSpawn1.position, this.CrewSpawn1.rotation);
            this.LiveCrewman3.transform.GetChild(0).GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
            this.LiveCrewman3.transform.GetChild(0).transform.GetChild(1).GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
            ((SlavuicPersonAI) this.LiveCrewman3.transform.GetChild(0).transform.GetChild(0).transform.GetComponent(typeof(SlavuicPersonAI))).FreeRoam = true;
        }
        if (!this.LiveCrewman4)
        {
            this.LiveCrewman4 = UnityEngine.Object.Instantiate(this.Crewman2, this.CrewSpawn2.position, this.CrewSpawn2.rotation);
            this.LiveCrewman4.transform.GetChild(0).GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
            this.LiveCrewman4.transform.GetChild(0).transform.GetChild(1).GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
            ((SlavuicPersonAI) this.LiveCrewman4.transform.GetChild(0).transform.GetChild(0).transform.GetComponent(typeof(SlavuicPersonAI))).FreeRoam = true;
        }
    }

    public virtual IEnumerator LaunchBM100()
    {
        if (this.target)
        {
            this.LaunchingBM100 = true;
            this.RocketModelR.enabled = true;
            yield return new WaitForSeconds(4);
            GameObject _SpawnedObject100 = UnityEngine.Object.Instantiate(this.Rocket, this.RocketModel.position, this.RocketModel.rotation);
            _SpawnedObject100.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
            ((MissileScript) _SpawnedObject100.transform.GetComponent(typeof(MissileScript))).target = this.target;
            this.RocketModelR.enabled = false;
            yield return new WaitForSeconds(2);
            this.DecidingToLaunch = 0;
            this.LaunchingBM100 = false;
            this.Emergency = false;
        }
    }

    public virtual IEnumerator IsEscaping(Vector3 lastPos)
    {
        this.Stuck = false;
        this.TurnRight = false;
        this.TurnLeft = false;
        yield return new WaitForSeconds(1);
        if (Vector3.Distance(this.thisTransform.position, lastPos) < 32)
        {
            this.Stuck = true;
            this.StuckCounter = 32;
        }
    }

    public SlavuicCruiserAI()
    {
        this.RightDist = 200;
        this.LeftDist = 200;
        this.AngClamp = 2;
    }

}