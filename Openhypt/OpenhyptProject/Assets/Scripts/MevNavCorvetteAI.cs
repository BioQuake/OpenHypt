using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MevNavCorvetteAI : MonoBehaviour
{
    public Transform target;
    public Transform Waypoint;
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
    public Transform CMissile;
    public GameObject Turret1;
    public GameObject Turret2;
    public NPCGun Gun1;
    public NPCGun Gun2;
    public MevNavGyro Gyro;
    public CapsuleCollider Trig;
    public GameObject ThrusterEffect1;
    public GameObject ThrusterEffect2;
    public GameObject ThrusterEffect3;
    public GameObject ThrusterEffect4;
    public GameObject Presence;
    public GameObject SpotSound;
    public GameObject AttackSound;
    public GameObject RejectSound;
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
    public bool Attacking;
    public bool Obstacle;
    public bool Stuck;
    public bool Emergency;
    public bool Damaged;
    public bool TurnRight;
    public bool TurnLeft;
    public float RightDist;
    public float LeftDist;
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
    public int DangerSense;
    public bool DangerTick;
    public bool LaunchingCM;
    public int Spot;
    public int FarFromEnemy;
    public int StoredMissileBatches;
    public int StoredCMissiles;
    public int Dist3;
    public bool GyroOff;
    public virtual void Update()
    {
        Vector3 newRot2 = default(Vector3);
        RaycastHit hit = default(RaycastHit);
        RaycastHit hit1 = default(RaycastHit);
        RaycastHit hit2 = default(RaycastHit);
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
                this.target = this.ResetAimpoint;
                this.Gyro.AimTarget = this.ResetAimpoint;
                this.Attacking = false;
                this.Spot = 0;
                this.FoundSmall = false;
            }
            if (this.target == null)
            {
                this.target = this.ResetAimpoint;
                this.Gyro.AimTarget = this.ResetAimpoint;
                this.Attacking = false;
                this.Spot = 0;
                this.FoundSmall = false;
            }
            else
            {
                if (this.target.name.Contains("broken"))
                {
                    this.target = this.ResetAimpoint;
                    this.Gyro.AimTarget = this.ResetAimpoint;
                    //Cramped = 0;
                    this.Attacking = false;
                    this.Spot = 0;
                }
            }
        }
        if (this.TurnLeft)
        {
            this.Gyro.AimForce = 0;
            this.Gyro.TurnForce = -8000;
        }
        if (this.TurnRight)
        {
            this.Gyro.AimForce = 0;
            this.Gyro.TurnForce = 8000;
        }
        if ((this.TurnRight && this.TurnLeft) && this.Obstacle)
        {
            this.Gyro.TurnForce = -8000;
        }
        if ((this.Attacking && !this.Obstacle) && (this.target != null))
        {
            if (!this.TurnRight && !this.TurnLeft)
            {
                if (((Vector3.Distance(this.thisTransform.position, this.target.position) < 300) && !this.TurnRight) && !this.TurnLeft)
                {
                    //TurnertFar = false;
                    this.Gyro.AimForce = 1000;
                    this.Gyro.TurnForce = -3000;
                }
                if (((Vector3.Distance(this.thisTransform.position, this.target.position) > 300) && !this.TurnRight) && !this.TurnLeft)
                {
                    //TurnertFar = true;
                    this.Gyro.AimForce = 1000;
                    this.Gyro.TurnForce = -2000;
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
        if (this.RUP < 4)
        {
            this.RUP = this.RUP + 0.5f;
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
        float VelClamp = Mathf.Clamp(this.vRigidbody.velocity.magnitude * 2, 40, 200);
        Debug.DrawRay((this.thisTransform.position + (-this.thisTransform.up * 2)) + (this.thisTransform.up * this.RUP), newRot2 * VelClamp, Color.white);
        if (Physics.Raycast((this.thisTransform.position + (-this.thisTransform.up * 2)) + (this.thisTransform.up * this.RUP), newRot2, out hit1, VelClamp, (int) this.targetLayers))
        {
            this.Point1u = hit1.point;
        }
        else
        {
            this.Point1u = new Vector3(2, 2, 2);
        }
        Debug.DrawRay((this.thisTransform.position + (-this.thisTransform.up * 3)) + (this.thisTransform.up * this.RUP), newRot2 * VelClamp, Color.white);
        if (Physics.Raycast((this.thisTransform.position + (-this.thisTransform.up * 3)) + (this.thisTransform.up * this.RUP), newRot2, out hit2, VelClamp, (int) this.targetLayers))
        {
            this.Point1d = hit2.point;
        }
        else
        {
            this.Point1d = new Vector3(8, 8, 8);
        }
        if (Vector3.Distance(this.Point1u, this.Point1d) < 2)
        {
            this.Wall = true;
        }
        this.Obstacle = false;
        Debug.DrawRay(this.thisTransform.position, newRot2 * VelClamp, Color.green);
        if (Physics.Raycast(this.thisTransform.position, newRot2, out hit, VelClamp, (int) this.targetLayers))
        {
            if (this.Wall)
            {
                this.Obstacle = true;
            }
        }
        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.right * 4), newRot2 * VelClamp, Color.green);
        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.right * 4), newRot2, out hit, VelClamp, (int) this.targetLayers))
        {
            if (this.Wall)
            {
                this.Obstacle = true;
            }
        }
        Debug.DrawRay(this.thisTransform.position + (-this.thisTransform.right * 4), newRot2 * VelClamp, Color.green);
        if (Physics.Raycast(this.thisTransform.position + (-this.thisTransform.right * 4), newRot2, out hit, VelClamp, (int) this.targetLayers))
        {
            if (this.Wall)
            {
                this.Obstacle = true;
            }
        }
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.right * 10)) + (-this.thisTransform.up * 2)) + (this.thisTransform.up * this.RRUP), this.thisTransform.forward * VelClamp, Color.black);
        if (Physics.Raycast(((this.thisTransform.position + (this.thisTransform.right * 10)) + (-this.thisTransform.up * 2)) + (this.thisTransform.up * this.RRUP), this.thisTransform.forward, out hit1, VelClamp, (int) this.targetLayers))
        {
            this.RPoint1u = hit1.point;
        }
        else
        {
            this.RPoint1u = new Vector3(2, 2, 2);
        }
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.right * 10)) + (-this.thisTransform.up * 3)) + (this.thisTransform.up * this.RRUP), this.thisTransform.forward * VelClamp, Color.black);
        if (Physics.Raycast(((this.thisTransform.position + (this.thisTransform.right * 10)) + (-this.thisTransform.up * 3)) + (this.thisTransform.up * this.RRUP), this.thisTransform.forward, out hit2, VelClamp, (int) this.targetLayers))
        {
            this.RPoint1d = hit2.point;
            this.RightDist = hit2.distance;
        }
        else
        {
            this.RPoint1d = new Vector3(8, 8, 8);
            this.RightDist = 512;
        }
        if (Vector3.Distance(this.RPoint1u, this.RPoint1d) < 2)
        {
            this.RWall = true;
        }
        Debug.DrawRay(((this.thisTransform.position + (-this.thisTransform.right * 10)) + (-this.thisTransform.up * 2)) + (this.thisTransform.up * this.LRUP), this.thisTransform.forward * VelClamp, Color.black);
        if (Physics.Raycast(((this.thisTransform.position + (-this.thisTransform.right * 10)) + (-this.thisTransform.up * 2)) + (this.thisTransform.up * this.LRUP), this.thisTransform.forward, out hit1, VelClamp, (int) this.targetLayers))
        {
            this.LPoint1u = hit1.point;
        }
        else
        {
            this.LPoint1u = new Vector3(2, 2, 2);
        }
        Debug.DrawRay(((this.thisTransform.position + (-this.thisTransform.right * 10)) + (-this.thisTransform.up * 3)) + (this.thisTransform.up * this.LRUP), this.thisTransform.forward * VelClamp, Color.black);
        if (Physics.Raycast(((this.thisTransform.position + (-this.thisTransform.right * 10)) + (-this.thisTransform.up * 3)) + (this.thisTransform.up * this.LRUP), this.thisTransform.forward, out hit2, VelClamp, (int) this.targetLayers))
        {
            this.LPoint1d = hit2.point;
            this.LeftDist = hit2.distance;
        }
        else
        {
            this.LPoint1d = new Vector3(8, 8, 8);
            this.LeftDist = 512;
        }
        if (Vector3.Distance(this.LPoint1u, this.LPoint1d) < 2)
        {
            this.LWall = true;
        }
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.up * 10)) + (this.thisTransform.forward * VelClamp), this.thisTransform.up * -30f, Color.white);
        if (!Physics.Raycast((this.thisTransform.position + (this.thisTransform.up * 10)) + (this.thisTransform.forward * VelClamp), -this.thisTransform.up, 30))
        {
            this.Obstacle = true;
        }
        //---------------------------------------------------------------------------------------------
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.up * 10)) + (this.thisTransform.right * 20)) + (this.thisTransform.forward * VelClamp), this.thisTransform.up * -30f, Color.white);
        if (!Physics.Raycast(((this.thisTransform.position + (this.thisTransform.up * 10)) + (this.thisTransform.right * 20)) + (this.thisTransform.forward * VelClamp), -this.thisTransform.up, 30))
        {
            this.TurnLeft = true;
        }
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.up * 10)) + (-this.thisTransform.right * 20)) + (this.thisTransform.forward * VelClamp), this.thisTransform.up * -30f, Color.white);
        if (!Physics.Raycast(((this.thisTransform.position + (this.thisTransform.up * 10)) + (-this.thisTransform.right * 20)) + (this.thisTransform.forward * VelClamp), -this.thisTransform.up, 30))
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
            UnityEngine.Object.Destroy(this.Presence);
            UnityEngine.Object.Destroy(this);
        }
        Vector3 localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
        if (this.Obstacle)
        {
            if (-localV.y > 0)
            {
                this.vRigidbody.AddForce(-this.thisVTransform.up * -1000);
            }
        }
        if (this.Stuck)
        {
            if (-localV.y < 4)
            {
                this.vRigidbody.AddForce(this.thisVTransform.up * 500);
            }
        }
        if ((this.Attacking && !this.Obstacle) && !this.Stuck)
        {
            if (-localV.y < 70)
            {
                this.vRigidbody.AddForce(-this.thisVTransform.up * 500);
            }
        }
        if ((((this.Spot > 0) && !this.Obstacle) && !this.Attacking) && !this.Stuck)
        {
            if (-localV.y < 70)
            {
                this.vRigidbody.AddForce(-this.thisVTransform.up * 250);
            }
        }
        if (((((!this.Attacking && !this.Obstacle) && (this.Spot < 1)) && !this.Stuck) && !this.TurnLeft) && !this.TurnRight)
        {
            if (-localV.y < 70)
            {
                this.vRigidbody.AddForce(-this.thisVTransform.up * 250);
            }
        }
        if (this.target)
        {
            this.Turret1.GetComponent<Rigidbody>().AddForceAtPosition((this.TargetLead.transform.position - this.Turret1.transform.position).normalized * 10, -this.Turret1.transform.up * 2);
            this.Turret1.GetComponent<Rigidbody>().AddForceAtPosition((this.TargetLead.transform.position - this.Turret1.transform.position).normalized * -10, this.Turret1.transform.up * 2);
            this.Turret2.GetComponent<Rigidbody>().AddForceAtPosition((this.TargetLead.transform.position - this.Turret2.transform.position).normalized * 10, -this.Turret2.transform.up * 2);
            this.Turret2.GetComponent<Rigidbody>().AddForceAtPosition((this.TargetLead.transform.position - this.Turret2.transform.position).normalized * -10, this.Turret2.transform.up * 2);
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
                if (MevNavNetwork.instance.EnemyTarget1)
                {
                    if (ON.Contains("TFC0a"))
                    {
                        if (MevNavNetwork.instance.EnemyTarget1.name.Contains("TFC0"))
                        {
                            this.PissedAtTC0a = 2;
                        }
                    }
                    if (ON.Contains("TFC1"))
                    {
                        if (MevNavNetwork.instance.EnemyTarget1.name.Contains("TFC1"))
                        {
                            this.PissedAtTC1 = 2;
                        }
                    }
                    if (ON.Contains("TFC3"))
                    {
                        if (MevNavNetwork.instance.EnemyTarget1.name.Contains("TFC3"))
                        {
                            this.PissedAtTC3 = 2;
                        }
                    }
                    if (ON.Contains("TFC4"))
                    {
                        if (MevNavNetwork.instance.EnemyTarget1.name.Contains("TFC4"))
                        {
                            this.PissedAtTC4 = 2;
                        }
                    }
                    if (ON.Contains("TFC5"))
                    {
                        if (MevNavNetwork.instance.EnemyTarget1.name.Contains("TFC5"))
                        {
                            this.PissedAtTC5 = 2;
                        }
                    }
                    if (ON.Contains("TFC6"))
                    {
                        if (MevNavNetwork.instance.EnemyTarget1.name.Contains("TFC6"))
                        {
                            this.PissedAtTC6 = 2;
                        }
                    }
                    if (ON.Contains("TFC8"))
                    {
                        if (MevNavNetwork.instance.EnemyTarget1.name.Contains("TFC8"))
                        {
                            this.PissedAtTC8 = 2;
                        }
                    }
                    if (ON.Contains("TFC9"))
                    {
                        if (MevNavNetwork.instance.EnemyTarget1.name.Contains("TFC9"))
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
                }
                if (!this.Attacking)
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
        if (ON.Contains("TC"))
        {
            if (!ON.Contains("TC7"))
            {
                if (Vector3.Distance(this.thisTransform.position, OT.position) < 32)
                {
                    if (!ON.Contains("TC2"))
                    {
                        this.Spot = 0;
                        this.FarFromEnemy = 0;
                        this.target = OT;
                        if (this.Gyro != null)
                        {
                            this.Gyro.AimTarget = OT;
                        }
                        if (!this.Attacking)
                        {
                            this.AttackNoise();
                        }
                        this.Attacking = true;
                    }
                }
                if (this.PissedAtTC0a > 1)
                {
                    if (ON.Contains("TC0a"))
                    {
                        if ((ON.Contains("sT") && !this.FoundSmall) || !ON.Contains("sT"))
                        {
                            this.Spot = 0;
                            this.FarFromEnemy = 0;
                            this.target = OT;
                            if (this.Gyro != null)
                            {
                                this.Gyro.AimTarget = OT;
                            }
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
                        if (this.PissedAtTC1 > 300)
                        {
                            this.FoundSmall = false;
                        }
                        if ((ON.Contains("sT") && !this.FoundSmall) || !ON.Contains("sT"))
                        {
                            this.Spot = 0;
                            this.FarFromEnemy = 0;
                            this.target = OT;
                            if (this.Gyro != null)
                            {
                                this.Gyro.AimTarget = OT;
                            }
                            if (!this.Attacking)
                            {
                                this.AttackNoise();
                            }
                            this.Attacking = true;
                            this.PissedAtTC1 = this.PissedAtTC1 - 1;
                        }
                    }
                }
                if (this.PissedAtTC2 > 1)
                {
                    if (ON.Contains("mTC2"))
                    {
                        this.Spot = 0;
                        this.FarFromEnemy = 0;
                        this.target = OT;
                        if (this.Gyro != null)
                        {
                            this.Gyro.AimTarget = OT;
                        }
                        if (!this.Attacking)
                        {
                            this.AttackNoise();
                        }
                        this.Attacking = true;
                        this.PissedAtTC2 = this.PissedAtTC2 - 1;
                    }
                }
                if (this.PissedAtTC3 > 1)
                {
                    if (!ON.Contains("cT"))
                    {
                        if (ON.Contains("TC3"))
                        {
                            if (this.PissedAtTC3 > 300)
                            {
                                this.FoundSmall = false;
                            }
                            if ((ON.Contains("sT") && !this.FoundSmall) || !ON.Contains("sT"))
                            {
                                this.Spot = 0;
                                this.FarFromEnemy = 0;
                                this.target = OT;
                                if (this.Gyro != null)
                                {
                                    this.Gyro.AimTarget = OT;
                                }
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
                        if (this.PissedAtTC4 > 300)
                        {
                            this.FoundSmall = false;
                        }
                        if ((ON.Contains("sT") && !this.FoundSmall) || !ON.Contains("sT"))
                        {
                            this.Spot = 0;
                            this.FarFromEnemy = 0;
                            this.target = OT;
                            if (this.Gyro != null)
                            {
                                this.Gyro.AimTarget = OT;
                            }
                            if (!this.Attacking)
                            {
                                this.AttackNoise();
                            }
                            this.Attacking = true;
                            this.PissedAtTC4 = this.PissedAtTC4 - 1;
                        }
                    }
                }
                if (this.PissedAtTC5 > 1)
                {
                    if (!ON.Contains("cT"))
                    {
                        if (ON.Contains("TC5"))
                        {
                            if (this.PissedAtTC5 > 300)
                            {
                                this.FoundSmall = false;
                            }
                            if ((ON.Contains("sT") && !this.FoundSmall) || !ON.Contains("sT"))
                            {
                                this.Spot = 0;
                                this.FarFromEnemy = 0;
                                this.target = OT;
                                if (this.Gyro != null)
                                {
                                    this.Gyro.AimTarget = OT;
                                }
                                if (!this.Attacking)
                                {
                                    this.AttackNoise();
                                }
                                this.Attacking = true;
                                this.PissedAtTC5 = this.PissedAtTC5 - 1;
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
                            if (this.PissedAtTC6 > 300)
                            {
                                this.FoundSmall = false;
                            }
                            if ((ON.Contains("sT") && !this.FoundSmall) || !ON.Contains("sT"))
                            {
                                this.Spot = 0;
                                this.FarFromEnemy = 0;
                                this.target = OT;
                                if (this.Gyro != null)
                                {
                                    this.Gyro.AimTarget = OT;
                                }
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
                            if (this.PissedAtTC8 > 300)
                            {
                                this.FoundSmall = false;
                            }
                            if ((ON.Contains("sT") && !this.FoundSmall) || !ON.Contains("sT"))
                            {
                                this.Spot = 0;
                                this.FarFromEnemy = 0;
                                this.target = OT;
                                if (this.Gyro != null)
                                {
                                    this.Gyro.AimTarget = OT;
                                }
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
                            if (this.PissedAtTC9 > 300)
                            {
                                this.FoundSmall = false;
                            }
                            if ((ON.Contains("sT") && !this.FoundSmall) || !ON.Contains("sT"))
                            {
                                this.Spot = 0;
                                this.FarFromEnemy = 0;
                                this.target = OT;
                                if (this.Gyro != null)
                                {
                                    this.Gyro.AimTarget = OT;
                                }
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
            this.Spot = 0;
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
            yield return new WaitForSeconds(0.25f);
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

    public virtual IEnumerator LaunchSM()
    {
        if (this.target != null)
        {
            if ((this.Attacking && (this.StoredMissileBatches > 0)) && (Vector3.Distance(this.thisTransform.position, this.target.position) < 500))
            {
                if (this.Emergency)
                {
                    this.Dist3 = 3;
                }
                else
                {
                    this.Dist3 = 6;
                }
                this.StoredMissileBatches = this.StoredMissileBatches - 1;
                GameObject _SpawnedObject1 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile1.position, this.Missile1.rotation);
                _SpawnedObject1.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                ((MissileScript) _SpawnedObject1.transform.GetComponent(typeof(MissileScript))).target = this.TargetLead2;
                yield return new WaitForSeconds(0.3f);
                GameObject _SpawnedObject2 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile2.position, this.Missile2.rotation);
                _SpawnedObject2.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                ((MissileScript) _SpawnedObject2.transform.GetComponent(typeof(MissileScript))).target = this.TargetLead2;
                yield return new WaitForSeconds(0.3f);
                GameObject _SpawnedObject3 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile3.position, this.Missile3.rotation);
                _SpawnedObject3.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                ((MissileScript) _SpawnedObject3.transform.GetComponent(typeof(MissileScript))).target = this.TargetLead2;
                yield return new WaitForSeconds(0.3f);
                GameObject _SpawnedObject4 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile4.position, this.Missile4.rotation);
                _SpawnedObject4.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                ((MissileScript) _SpawnedObject4.transform.GetComponent(typeof(MissileScript))).target = this.TargetLead2;
            }
        }
        yield return new WaitForSeconds(2.4f);
        this.Dist3 = 3;
    }

    public virtual void LaunchCM()
    {
        if (this.target != null)
        {
            if ((this.Attacking && (this.StoredCMissiles > 0)) && (Vector3.Distance(this.thisTransform.position, this.target.position) < 2000))
            {
                this.StoredCMissiles = this.StoredCMissiles - 1;
                this.LaunchingCM = false;
                GameObject _SpawnedObject0 = UnityEngine.Object.Instantiate(this.CMissileAmmo, this.CMissile.position, this.CMissile.rotation);
                _SpawnedObject0.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                ((MissileScript) _SpawnedObject0.transform.GetComponent(typeof(MissileScript))).target = this.target;
            }
        }
    }

    public virtual void Targety()
    {
        if ((this.Spot < 1) && !this.Attacking)
        {
            this.StartCoroutine(this.TargetArea());
        }
    }

    public virtual IEnumerator TargetArea()
    {
        if ((MevNavNetwork.AlertTime > 0) && !this.Attacking)
        {
            this.Waypoint.transform.position = MevNavNetwork.instance.PriorityWaypoint.position;
            this.target = this.Waypoint;
            this.Gyro.AimTarget = this.Waypoint;
        }
        yield return new WaitForSeconds(10);
        if (!this.Attacking)
        {
            this.Gyro.AimTarget = this.ResetAimpoint;
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
            this.TargetLead2.position = this.TargetTrace.position;
            this.TargetLead2.rotation = this.TargetTrace.rotation;
            this.TargetLead.position = this.TargetLead.position + (((this.TargetLead.forward * Dist1) * Dist2) * 0.02f);
            this.TargetLead2.position = this.TargetLead2.position + ((this.TargetLead.forward * Dist2) * this.Dist3);
            if (this.Attacking)
            {
                this.TLCol.radius = Vector3.Distance(this.thisTransform.position, this.target.position) * 0.05f;
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
            this.StartCoroutine(this.TargetArea());
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
            if (MevNavNetwork.TC1DeathRow > 1)
            {
                this.PissedAtTC1 = 2;
                if (MevNavNetwork.TC1DeathRow > 600)
                {
                    if (this.target.name.Contains("C1"))
                    {
                        MevNavNetwork.instance.PriorityWaypoint.position = this.target.position;
                        MevNavNetwork.AlertLVL2 = 1;
                    }
                }
            }
            if (MevNavNetwork.TC2DeathRow > 200)
            {
                this.PissedAtTC2 = 2;
                if (MevNavNetwork.TC2DeathRow > 600)
                {
                    if (this.target.name.Contains("C2"))
                    {
                        MevNavNetwork.AlertLVL2 = 2;
                    }
                }
            }
            if (MevNavNetwork.TC3DeathRow > 1)
            {
                this.PissedAtTC3 = 2;
                if (MevNavNetwork.TC3DeathRow > 600)
                {
                    if (this.target.name.Contains("C3"))
                    {
                        MevNavNetwork.AlertLVL2 = 3;
                    }
                }
            }
            if (MevNavNetwork.TC4DeathRow > 1)
            {
                this.PissedAtTC4 = 2;
                if (MevNavNetwork.TC4DeathRow > 600)
                {
                    if (this.target.name.Contains("C4"))
                    {
                        MevNavNetwork.AlertLVL2 = 4;
                    }
                }
            }
            if (MevNavNetwork.TC5DeathRow > 1)
            {
                this.PissedAtTC5 = 2;
                if (MevNavNetwork.TC5DeathRow > 600)
                {
                    if (this.target.name.Contains("C5"))
                    {
                        MevNavNetwork.AlertLVL2 = 5;
                    }
                }
            }
            if (MevNavNetwork.TC6DeathRow > 1)
            {
                this.PissedAtTC6 = 2;
                if (MevNavNetwork.TC6DeathRow > 600)
                {
                    if (this.target.name.Contains("C6"))
                    {
                        MevNavNetwork.AlertLVL2 = 6;
                    }
                }
            }
            if (MevNavNetwork.TC8DeathRow > 1)
            {
                this.PissedAtTC8 = 2;
                if (MevNavNetwork.TC8DeathRow > 600)
                {
                    if (this.target.name.Contains("C8"))
                    {
                        MevNavNetwork.AlertLVL2 = 8;
                    }
                }
            }
            if (MevNavNetwork.TC9DeathRow > 1)
            {
                this.PissedAtTC9 = 2;
                if (MevNavNetwork.TC9DeathRow > 600)
                {
                    if (this.target.name.Contains("C9"))
                    {
                        MevNavNetwork.AlertLVL2 = 9;
                    }
                }
            }
            if (this.target.name.Contains("sT"))
            {
                this.FoundSmall = true;
            }
            if (this.Attacking)
            {
                if (Vector3.Distance(this.thisTransform.position, this.target.position) > 2000)
                {
                    this.FarFromEnemy = this.FarFromEnemy + 1;
                }
            }
            if (Vector3.Distance(this.thisTransform.position, this.target.position) < 1900)
            {
                this.FarFromEnemy = 0;
            }
        }
        if (this.Attacking)
        {
            this.Trig.center = new Vector3(0, 0, 0);
            this.Trig.radius = 50;
            this.Trig.height = 50;
        }
        else
        {
            this.Trig.center = new Vector3(0, 0, 200);
            this.Trig.radius = 200;
            this.Trig.height = 800;
        }
        if ((this.Spot == 1) && !this.Attacking)
        {
            this.Spot = 0;
            GameObject TheThing1 = UnityEngine.Object.Instantiate(this.RejectSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
            TheThing1.transform.parent = this.thisTransform;
            this.target = this.ResetAimpoint;
            this.Gyro.AimTarget = this.ResetAimpoint;
        }
        if (this.FarFromEnemy > 30)
        {
            this.Spot = 0;
            //Cramped = 0;
            //TurnertDist = 100;
            this.Attacking = false;
            GameObject TheThing2 = UnityEngine.Object.Instantiate(this.RejectSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
            TheThing2.transform.parent = this.thisTransform;
            this.target = this.ResetAimpoint;
            this.Gyro.AimTarget = this.ResetAimpoint;
        }
        if (this.DangerSense > 0)
        {
            if ((this.DangerSense < 2) && !this.Attacking)
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
        if (this.target)
        {
            if (this.target.name.Contains("sTC"))
            {
                this.FoundSmall = true;
            }
        }
        this.Gyro.AimForce = 1000;
        this.Gyro.TurnForce = 0;
        this.Wall = false;
        this.RWall = false;
        this.LWall = false;
        this.TurnRight = false;
        this.TurnLeft = false;
        this.StartCoroutine(this.Notice());
    }

    public virtual IEnumerator Notice()
    {
        if (((this.target != null) && (this.StoredCMissiles > 0)) && this.Attacking)
        {
            Vector3 lastTPos = this.target.transform.position;
            yield return new WaitForSeconds(0.2f);
            if (this.target != null)
            {
                if (Vector3.Distance(this.target.transform.position, lastTPos) > 20)
                {
                    this.LaunchingCM = true;
                }
            }
        }
        if (this.Attacking)
        {
            if (this.target != null)
            {
                if (this.Emergency)
                {
                    MevNavNetwork.instance.EnemyTarget1 = this.target;
                }
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

    public virtual void Start()
    {
        this.InvokeRepeating("Regenerator", 1, 1);
        this.InvokeRepeating("LeaveMarker", 1, 10);
        this.InvokeRepeating("Targety", 15, 15);
        this.InvokeRepeating("Shooty", Random.Range(2, 3), 0.2f);
        this.InvokeRepeating("Launchy", 1, 15);
        this.InvokeRepeating("EmergencyLaunchy", 1, 1.2f);
        this.InvokeRepeating("CalcLead", 1, 0.15f);
    }

    public MevNavCorvetteAI()
    {
        this.RightDist = 200;
        this.LeftDist = 200;
        this.StoredMissileBatches = 8;
        this.StoredCMissiles = 4;
        this.Dist3 = 6;
    }

}