using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MevNavCruiserAI : MonoBehaviour
{
    public Transform target;
    public Transform Waypoint;
    public Transform Stranger;
    public Transform TargetTrace;
    public Transform TargetLead;
    public Transform TargetLead2;
    public SphereCollider TLCol;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public Transform ResetAimpoint;
    public Transform AIAnchor;
    public bool HasRequested;
    public GameObject MissileAmmo;
    public GameObject CMissileAmmo;
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
    public Transform CMissile;
    public GameObject Drone1;
    public GameObject Vult;
    public Transform DroneSpawn1;
    public Transform DroneSpawn2;
    public GameObject PresentDrone1;
    public GameObject PresentDrone2;
    public MevNavBattledroneAI Drone1AI;
    public MevNavBattledroneAI Drone2AI;
    public Transform Gate;
    public AudioSource GateSound;
    public Transform Turret1TF;
    public Transform Turret2TF;
    public Rigidbody Turret1RB;
    public Rigidbody Turret2RB;
    public NPCGun Gun1;
    public NPCGun Gun2;
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
    public int StoredMissileBatches;
    public int StoredCMissiles;
    public bool GyroOff;
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
                this.Gyro.TurnForce = -3200000;
            }
            if (this.TurnRight)
            {
                this.Gyro.AimForce = 0;
                this.Gyro.TurnForce = 3200000;
            }
        }
        else
        {
            this.Gyro.AimForce = 0;
            this.Gyro.TurnForce = 3200000;
        }
        if ((this.TurnRight && this.TurnLeft) && this.Obstacle)
        {
            this.Gyro.TurnForce = -3200000;
        }
        if ((this.Attacking && !this.Obstacle) && (this.target != null))
        {
            if (!this.TurnRight && !this.TurnLeft)
            {
                if (((Vector3.Distance(this.thisTransform.position, this.target.position) > 300) && !this.TurnRight) && !this.TurnLeft)
                {
                    this.Gyro.AimForce = 200000;
                    this.Gyro.TurnForce = -1600000;
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
        if (this.RRUP < 80)
        {
            this.RRUP = this.RRUP + 4;
            this.RRUPz = this.RRUPz - 2;
        }
        else
        {
            this.RRUP = 2;
            this.RRUPz = 70;
        }
        float VelClamp = Mathf.Clamp(this.Vel * 4, 80, 400);
        this.AngClamp = (int) Mathf.Clamp(this.Vel * 0.15f, 2, 8);
        float DMod1 = 160 - this.Vel;
        float DMod = Mathf.Clamp(DMod1, 1, 160);
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.forward * 70)) + (-this.thisTransform.up * 14)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward * VelClamp, Color.white);
        if (Physics.Raycast(((this.thisTransform.position + (this.thisTransform.forward * 70)) + (-this.thisTransform.up * 14)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward, out hit1, VelClamp, (int) this.targetLayers))
        {
            this.Pointu = hit1.point;
        }
        else
        {
            this.Pointu = new Vector3(2, 2, 2);
        }
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.forward * 70)) + (-this.thisTransform.up * 15)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward * VelClamp, Color.white);
        if (Physics.Raycast(((this.thisTransform.position + (this.thisTransform.forward * 70)) + (-this.thisTransform.up * 15)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward, out hit2, VelClamp, (int) this.targetLayers))
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
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * 70)) + (this.thisTransform.right * 40), this.thisTransform.forward * VelClamp, Color.green);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * 70)) + (this.thisTransform.right * 40), this.thisTransform.forward, out hit, VelClamp, (int) this.targetLayers))
        {
            if (this.Wall)
            {
                this.Obstacle = true;
            }
        }
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * 70)) + (-this.thisTransform.right * 40), this.thisTransform.forward * VelClamp, Color.green);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * 70)) + (-this.thisTransform.right * 40), this.thisTransform.forward, out hit, VelClamp, (int) this.targetLayers))
        {
            if (this.Wall)
            {
                this.Obstacle = true;
            }
        }
        Debug.DrawRay((((this.thisTransform.position + (this.thisTransform.forward * this.RRUPz)) + (this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 10)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward * VelClamp, Color.black);
        if (Physics.Raycast((((this.thisTransform.position + (this.thisTransform.forward * this.RRUPz)) + (this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 10)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward, out hit1, VelClamp, (int) this.targetLayers))
        {
            this.RPointu = hit1.point;
        }
        else
        {
            this.RPointu = new Vector3(2, 2, 2);
        }
        Debug.DrawRay(((((this.thisTransform.position + (this.thisTransform.forward * this.RRUPz)) + (this.thisTransform.right * this.RRUP)) + (this.thisTransform.right * 1)) + (-this.thisTransform.up * 10)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward * VelClamp, Color.blue);
        if (Physics.Raycast(((((this.thisTransform.position + (this.thisTransform.forward * this.RRUPz)) + (this.thisTransform.right * this.RRUP)) + (this.thisTransform.right * 1)) + (-this.thisTransform.up * 10)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward, out hit3, VelClamp, (int) this.targetLayers))
        {
            this.RPointur = hit3.point;
        }
        else
        {
            this.RPointur = new Vector3(4, 4, 4);
        }
        Debug.DrawRay((((this.thisTransform.position + (this.thisTransform.forward * this.RRUPz)) + (this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 11)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward * VelClamp, Color.black);
        if (Physics.Raycast((((this.thisTransform.position + (this.thisTransform.forward * this.RRUPz)) + (this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 11)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward, out hit2, VelClamp, (int) this.targetLayers))
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
        Debug.DrawRay((((this.thisTransform.position + (this.thisTransform.forward * this.RRUPz)) + (-this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 10)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward * VelClamp, Color.black);
        if (Physics.Raycast((((this.thisTransform.position + (this.thisTransform.forward * this.RRUPz)) + (-this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 10)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward, out hit1, VelClamp, (int) this.targetLayers))
        {
            this.LPointu = hit1.point;
        }
        else
        {
            this.LPointu = new Vector3(2, 2, 2);
        }
        Debug.DrawRay(((((this.thisTransform.position + (this.thisTransform.forward * this.RRUPz)) + (-this.thisTransform.right * this.RRUP)) + (-this.thisTransform.right * 1)) + (-this.thisTransform.up * 10)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward * VelClamp, Color.blue);
        if (Physics.Raycast(((((this.thisTransform.position + (this.thisTransform.forward * this.RRUPz)) + (-this.thisTransform.right * this.RRUP)) + (-this.thisTransform.right * 1)) + (-this.thisTransform.up * 10)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward, out hit3, VelClamp, (int) this.targetLayers))
        {
            this.LPointul = hit3.point;
        }
        else
        {
            this.LPointul = new Vector3(4, 4, 4);
        }
        Debug.DrawRay((((this.thisTransform.position + (this.thisTransform.forward * this.RRUPz)) + (-this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 11)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward * VelClamp, Color.black);
        if (Physics.Raycast((((this.thisTransform.position + (this.thisTransform.forward * this.RRUPz)) + (-this.thisTransform.right * this.RRUP)) + (-this.thisTransform.up * 11)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward, out hit2, VelClamp, (int) this.targetLayers))
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
        if (this.Damaged)
        {
            this.vRigidbody.angularDrag = 0.05f;
            this.ThrusterEffect1.GetComponent<VelocityEmissionConfigurable>().Broken = true;
            this.ThrusterEffect2.GetComponent<VelocityEmissionConfigurable>().Broken = true;
            this.ThrusterEffect3.GetComponent<VelocityEmissionConfigurable>().Broken = true;
            this.ThrusterEffect4.GetComponent<VelocityEmissionConfigurable>().Broken = true;
            this.ThrusterEffect5.GetComponent<VelocityEmissionConfigurable>().Broken = true;
            this.ThrusterEffect6.GetComponent<VelocityEmissionConfigurable>().Broken = true;
            this.ThrusterEffect7.GetComponent<VelocityEmissionConfigurable>().Broken = true;
            this.ThrusterEffect8.GetComponent<VelocityEmissionConfigurable>().Broken = true;
            UnityEngine.Object.Destroy(this.Presence);
            UnityEngine.Object.Destroy(this);
        }
        if (this.Obstacle)
        {
            if (-this.localV.y > 0)
            {
                this.vRigidbody.AddForce(-this.thisVTransform.up * -40000);
            }
        }
        if (this.Stuck)
        {
            if (this.localV.y < 8)
            {
                this.vRigidbody.AddForce(this.thisVTransform.up * 40000);
            }
        }
        if (((!this.Obstacle && !this.Stuck) && !this.TurnLeft) && !this.TurnRight)
        {
            if (-this.localV.y < 60)
            {
                this.vRigidbody.AddForce(-this.thisVTransform.up * 40000);
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
        }
        if (this.GOpen)
        {
            if (this.Gate.localPosition.z > -1.2f)
            {

                {
                    float _2332 = this.Gate.localPosition.z - 0.06f;
                    Vector3 _2333 = this.Gate.localPosition;
                    _2333.z = _2332;
                    this.Gate.localPosition = _2333;
                }
            }
        }
        if (this.GClose)
        {
            if (this.Gate.localPosition.z < 0)
            {

                {
                    float _2334 = this.Gate.localPosition.z + 0.06f;
                    Vector3 _2335 = this.Gate.localPosition;
                    _2335.z = _2334;
                    this.Gate.localPosition = _2335;
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
                if (ON.Contains("#3"))
                {
                    this.Attacking = false;
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
            if (Vector3.Distance(this.thisTransform.position, OT.position) < 150)
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
                    if (this.PissedAtTC1 > 600)
                    {
                        this.FoundSmall = false;
                    }
                    this.FoundMedium = false;
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
                        if (this.PissedAtTC3 > 600)
                        {
                            this.FoundSmall = false;
                        }
                        this.FoundMedium = false;
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
                    if (this.PissedAtTC4 > 600)
                    {
                        this.FoundSmall = false;
                    }
                    this.FoundMedium = false;
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
                        if (this.PissedAtTC5 > 600)
                        {
                            this.FoundSmall = false;
                        }
                        this.FoundMedium = false;
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
                        if (this.PissedAtTC6 > 600)
                        {
                            this.FoundSmall = false;
                        }
                        this.FoundMedium = false;
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
                        if (this.PissedAtTC8 > 600)
                        {
                            this.FoundSmall = false;
                        }
                        this.FoundMedium = false;
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
                        if (this.PissedAtTC9 > 600)
                        {
                            this.FoundSmall = false;
                        }
                        this.FoundMedium = false;
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

    public virtual IEnumerator Looking()
    {
        yield return new WaitForSeconds(15);
        if (!this.Attacking)
        {
            this.Spot = 0;
            if (this.Hunting)
            {
                yield break;
            }
            this.Hunting = true;
            this.Targety();
        }
    }

    public virtual void Shooty()
    {
        if (this.Attacking)
        {
            this.StartCoroutine(this.Shoot());
        }
    }

    public virtual IEnumerator Shoot()
    {
        if (this.Attacking)
        {
            if (this.Gun1)
            {
                this.Gun1.Fire();
            }
            yield return new WaitForSeconds(0.7f);
            if (this.Gun2)
            {
                this.Gun2.Fire();
            }
        }
    }

    public virtual void EmergencyLaunchy()
    {
        if (this.Emergency)
        {
            this.LaunchCM();
            this.StartCoroutine(this.LaunchSM());
        }
    }

    public virtual void Launchy()
    {
        if (this.Attacking && !this.Emergency)
        {
            if (!this.LaunchingCM)
            {
                this.StartCoroutine(this.LaunchSM());
            }
            if (this.LaunchingCM)
            {
                this.LaunchCM();
            }
        }
    }

    public virtual IEnumerator SpawnDrone()
    {
        this.GateSound.GetComponent<AudioSource>().Play();
        this.SpawnCounter = 15;
        this.GOpen = true;
        this.GClose = false;
        yield return new WaitForSeconds(0.3f);
        if (!this.DistantThreat)
        {
            if (!this.PresentDrone1)
            {
                this.PresentDrone1 = UnityEngine.Object.Instantiate(this.Drone1, this.DroneSpawn1.position, this.DroneSpawn1.rotation) as GameObject;
                this.PresentDrone1.transform.GetChild(1).GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                this.PresentDrone1.transform.GetChild(1).GetComponent<Rigidbody>().AddForce(this.DroneSpawn1.transform.right * 100);
                this.Drone1AI = (MevNavBattledroneAI) this.PresentDrone1.transform.GetChild(0).GetComponent(typeof(MevNavBattledroneAI));
                this.Drone1AI.target = this.Stranger;
                this.Drone1AI.Home = this.AIAnchor;
            }
            else
            {
                if (!this.PresentDrone2)
                {
                    this.PresentDrone2 = UnityEngine.Object.Instantiate(this.Drone1, this.DroneSpawn1.position, this.DroneSpawn1.rotation) as GameObject;
                    this.PresentDrone2.transform.GetChild(1).GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                    this.PresentDrone2.transform.GetChild(1).GetComponent<Rigidbody>().AddForce(this.DroneSpawn1.transform.right * 100);
                    this.Drone2AI = (MevNavBattledroneAI) this.PresentDrone2.transform.GetChild(0).GetComponent(typeof(MevNavBattledroneAI));
                    this.Drone2AI.target = this.Stranger;
                    this.Drone2AI.Home = this.AIAnchor;
                }
            }
        }
        else
        {
            GameObject _SpawnedObjectC = UnityEngine.Object.Instantiate(this.Vult, this.DroneSpawn2.position, this.DroneSpawn2.rotation);
            _SpawnedObjectC.transform.GetChild(1).GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
            ((MevNavBattledroneAI) _SpawnedObjectC.transform.GetChild(0).GetComponent(typeof(MevNavBattledroneAI))).target = this.target;
            _SpawnedObjectC.transform.GetChild(1).GetComponent<Rigidbody>().AddForce(this.DroneSpawn2.transform.right * 100);
        }
        yield return new WaitForSeconds(0.35f);
        this.GOpen = false;
        this.GClose = true;
    }

    public virtual IEnumerator LaunchSM()
    {
        if (this.target != null)
        {
            if (this.Attacking && (this.StoredMissileBatches > 0))
            {
                if ((Vector3.Distance(this.thisTransform.position, this.target.position) < 850) && (Vector3.Distance(this.thisTransform.position, this.target.position) > 150))
                {
                    Vector3 Measure = this.thisVTransform.InverseTransformPoint(this.target.position);
                    if (((Measure.y < 0) && (-this.localV.y > 17)) && (Vector3.Distance(this.thisTransform.position, this.target.position) < 330))
                    {
                        yield break;
                    }
                    this.StoredMissileBatches = this.StoredMissileBatches - 1;
                    GameObject _SpawnedObject1 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile1.position, this.Missile1.rotation);
                    _SpawnedObject1.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                    ((MissileScript) _SpawnedObject1.transform.GetComponent(typeof(MissileScript))).target = this.TargetLead2;
                    yield return new WaitForSeconds(0.2f);
                    GameObject _SpawnedObject2 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile2.position, this.Missile2.rotation);
                    _SpawnedObject2.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                    ((MissileScript) _SpawnedObject2.transform.GetComponent(typeof(MissileScript))).target = this.TargetLead2;
                    yield return new WaitForSeconds(0.2f);
                    GameObject _SpawnedObject3 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile3.position, this.Missile3.rotation);
                    _SpawnedObject3.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                    ((MissileScript) _SpawnedObject3.transform.GetComponent(typeof(MissileScript))).target = this.TargetLead2;
                    yield return new WaitForSeconds(0.2f);
                    GameObject _SpawnedObject4 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile4.position, this.Missile4.rotation);
                    _SpawnedObject4.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                    ((MissileScript) _SpawnedObject4.transform.GetComponent(typeof(MissileScript))).target = this.TargetLead2;
                    yield return new WaitForSeconds(0.2f);
                    GameObject _SpawnedObject5 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile5.position, this.Missile5.rotation);
                    _SpawnedObject5.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                    ((MissileScript) _SpawnedObject5.transform.GetComponent(typeof(MissileScript))).target = this.TargetLead2;
                    yield return new WaitForSeconds(0.2f);
                    GameObject _SpawnedObject6 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile6.position, this.Missile6.rotation);
                    _SpawnedObject6.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                    ((MissileScript) _SpawnedObject6.transform.GetComponent(typeof(MissileScript))).target = this.TargetLead2;
                    yield return new WaitForSeconds(0.2f);
                    GameObject _SpawnedObject7 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile7.position, this.Missile7.rotation);
                    _SpawnedObject7.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                    ((MissileScript) _SpawnedObject7.transform.GetComponent(typeof(MissileScript))).target = this.TargetLead2;
                    yield return new WaitForSeconds(0.2f);
                    GameObject _SpawnedObject8 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile8.position, this.Missile8.rotation);
                    _SpawnedObject8.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                    ((MissileScript) _SpawnedObject8.transform.GetComponent(typeof(MissileScript))).target = this.TargetLead2;
                    yield return new WaitForSeconds(5);
                    if (this.target)
                    {
                        if (((Measure.y < 0) && (-this.localV.y > 17)) && (Vector3.Distance(this.thisTransform.position, this.target.position) < 330))
                        {
                            yield break;
                        }
                    }
                    else
                    {
                        yield break;
                    }
                    if (this.Attacking && (this.StoredMissileBatches > 0))
                    {
                        this.StoredMissileBatches = this.StoredMissileBatches - 1;
                        GameObject _SpawnedObject9 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile9.position, this.Missile9.rotation);
                        _SpawnedObject9.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                        ((MissileScript) _SpawnedObject9.transform.GetComponent(typeof(MissileScript))).target = this.TargetLead2;
                        yield return new WaitForSeconds(0.2f);
                        GameObject _SpawnedObject10 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile10.position, this.Missile10.rotation);
                        _SpawnedObject10.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                        ((MissileScript) _SpawnedObject10.transform.GetComponent(typeof(MissileScript))).target = this.TargetLead2;
                        yield return new WaitForSeconds(0.2f);
                        GameObject _SpawnedObject11 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile11.position, this.Missile11.rotation);
                        _SpawnedObject11.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                        ((MissileScript) _SpawnedObject11.transform.GetComponent(typeof(MissileScript))).target = this.TargetLead2;
                        yield return new WaitForSeconds(0.2f);
                        GameObject _SpawnedObject12 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile12.position, this.Missile12.rotation);
                        _SpawnedObject12.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                        ((MissileScript) _SpawnedObject12.transform.GetComponent(typeof(MissileScript))).target = this.TargetLead2;
                        yield return new WaitForSeconds(0.2f);
                        GameObject _SpawnedObject13 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile13.position, this.Missile13.rotation);
                        _SpawnedObject13.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                        ((MissileScript) _SpawnedObject13.transform.GetComponent(typeof(MissileScript))).target = this.TargetLead2;
                        yield return new WaitForSeconds(0.2f);
                        GameObject _SpawnedObject14 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile14.position, this.Missile14.rotation);
                        _SpawnedObject14.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                        ((MissileScript) _SpawnedObject14.transform.GetComponent(typeof(MissileScript))).target = this.TargetLead2;
                        yield return new WaitForSeconds(0.2f);
                        GameObject _SpawnedObject15 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile15.position, this.Missile15.rotation);
                        _SpawnedObject15.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                        ((MissileScript) _SpawnedObject15.transform.GetComponent(typeof(MissileScript))).target = this.TargetLead2;
                        yield return new WaitForSeconds(0.2f);
                        GameObject _SpawnedObject16 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile16.position, this.Missile16.rotation);
                        _SpawnedObject16.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                        ((MissileScript) _SpawnedObject16.transform.GetComponent(typeof(MissileScript))).target = this.TargetLead2;
                    }
                }
            }
        }
    }

    public virtual void LaunchCM()
    {
        if (this.target != null)
        {
            if (this.Attacking && (this.StoredCMissiles > 0))
            {
                if ((Vector3.Distance(this.thisTransform.position, this.target.position) < 1700) && (Vector3.Distance(this.thisTransform.position, this.target.position) > 150))
                {
                    this.StoredCMissiles = this.StoredCMissiles - 1;
                    this.LaunchingCM = false;
                    GameObject _SpawnedObject0 = UnityEngine.Object.Instantiate(this.CMissileAmmo, this.CMissile.position, this.CMissile.rotation);
                    _SpawnedObject0.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                    ((MissileScript) _SpawnedObject0.transform.GetComponent(typeof(MissileScript))).target = this.target;
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
        if (((MevNavNetwork.AlertTime > 0) && (this.StuckCounter < 1)) && !this.Attacking)
        {
            this.Waypoint.transform.position = MevNavNetwork.instance.PriorityWaypoint.position;
            this.target = this.Waypoint;
            this.Gyro.AimTarget = this.Waypoint;
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
            this.TargetLead2.position = this.TargetTrace.position;
            this.TargetLead2.rotation = this.TargetTrace.rotation;
            this.TargetLead.position = this.TargetLead.position + (((this.TargetLead.forward * Dist1) * Dist2) * 0.017f);
            this.TargetLead2.position = this.TargetLead2.position + ((this.TargetLead.forward * Dist2) * 3);
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

    public virtual void Regenerator()
    {
        if (MevNavNetwork.AlertTime > 230)
        {
            this.TargetArea();
            MevNavNetwork.AlertTime = 230;
        }
        this.PissedAtTC1 = MevNavNetwork.TC1DeathRow;
        PissedAtTC2 = MevNavNetwork.TC2DeathRow;
        this.PissedAtTC3 = MevNavNetwork.TC3DeathRow;
        this.PissedAtTC4 = MevNavNetwork.TC4DeathRow;
        this.PissedAtTC5 = MevNavNetwork.TC5DeathRow;
        this.PissedAtTC6 = MevNavNetwork.TC6DeathRow;
        this.PissedAtTC8 = MevNavNetwork.TC8DeathRow;
        this.PissedAtTC9 = MevNavNetwork.TC9DeathRow;
        if (this.target && !this.Attacking)
        {
            if (Vector3.Distance(this.thisTransform.position, this.target.position) < 128)
            {
                if (this.target.name.Contains("TC0a") && (this.PissedAtTC0a < 300))
                {
                    this.PissedAtTC0a = 2;
                }
                if (this.target.name.Contains("TC1") && (this.PissedAtTC1 < 300))
                {
                    this.PissedAtTC1 = 2;
                }
                if (this.target.name.Contains("TC3") && (this.PissedAtTC3 < 300))
                {
                    this.PissedAtTC3 = 2;
                }
                if (this.target.name.Contains("TC4") && (this.PissedAtTC4 < 300))
                {
                    this.PissedAtTC4 = 2;
                }
                if (this.target.name.Contains("TC5") && (this.PissedAtTC5 < 300))
                {
                    this.PissedAtTC5 = 2;
                }
                if (this.target.name.Contains("TC6"))
                {
                    if (!this.target.name.Contains("csT"))
                    {
                        this.PissedAtTC6 = 2;
                    }
                }
                if (this.target.name.Contains("TC8") && (this.PissedAtTC8 < 300))
                {
                    this.PissedAtTC8 = 2;
                }
                if (this.target.name.Contains("TC9") && (this.PissedAtTC9 < 300))
                {
                    this.PissedAtTC9 = 2;
                }
            }
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
                if (Vector3.Distance(this.thisTransform.position, this.target.position) < 150)
                {
                    this.TargetClose = true;
                    if (this.Drone1AI && this.PresentDrone1)
                    {
                        if (Vector3.Distance(this.PresentDrone1.transform.position, this.target.position) > 300)
                        {
                            this.Drone1AI.target = this.target;
                        }
                    }
                    if (this.Drone2AI && this.PresentDrone2)
                    {
                        if (Vector3.Distance(this.PresentDrone2.transform.position, this.target.position) > 300)
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
            if (Vector3.Distance(this.thisTransform.position, this.target.position) > 6000)
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
                    if (Vector3.Distance(this.thisTransform.position, MevNavNetwork.xbTarget.position) < 6000)
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
            this.Trig.center = new Vector3(0, 0, 150);
            this.Trig.size = new Vector3(300, 300, 600);
        }
        else
        {
            this.Trig.center = new Vector3(0, 0, 1000);
            this.Trig.size = new Vector3(600, 300, 2500);
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
            this.Gyro.AimForce = 100000;
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
        yield return new WaitForSeconds(1);
        if (Vector3.Distance(this.thisTransform.position, lastPos) < 32)
        {
            this.Stuck = true;
            this.StuckCounter = 26;
        }
    }

    public virtual void Start()
    {
        this.InvokeRepeating("Regenerator", 1, 1);
        this.InvokeRepeating("Targety", 15, 15);
        this.InvokeRepeating("Shooty", Random.Range(2, 3), 0.2f);
        this.InvokeRepeating("Launchy", 1, 11);
        this.InvokeRepeating("EmergencyLaunchy", 1, 1.2f);
        this.InvokeRepeating("CalcLead", 1, 0.15f);
    }

    public MevNavCruiserAI()
    {
        this.RightDist = 200;
        this.LeftDist = 200;
        this.AngClamp = 2;
        this.StoredMissileBatches = 8;
        this.StoredCMissiles = 4;
    }

}