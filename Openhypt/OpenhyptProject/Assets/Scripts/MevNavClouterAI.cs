using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MevNavClouterAI : MonoBehaviour
{
    public Transform target;
    public Transform Waypoint;
    public Transform Threat;
    public Transform TargetTrace;
    public Transform TargetLead;
    public SphereCollider TLCol;
    public Transform ResetAimpoint;
    public VehicleDamage DeusDamage;
    public Transform AIAnchor;
    public bool LightClouter;
    public bool Belfry;
    public bool Archer;
    public bool Scabbard;
    public bool HasRequested;
    public GameObject MissileAmmo;
    public Transform Missile1;
    public Transform Missile2;
    public GameObject ActiveMissile;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public GameObject Turret;
    public NPCGun Gun;
    public MevNavGyro Gyro;
    public CapsuleCollider Trig;
    public GameObject ThrusterEffect1;
    public GameObject ThrusterEffect2;
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
    public bool LeftThreat;
    public bool Hunting;
    public bool Attacking;
    public bool Obstacle;
    public bool Stuck;
    public bool Emergency;
    public bool Standby;
    public bool Parked;
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
    public int DangerSense;
    public bool DangerTick;
    public LayerMask targetLayers;
    public LayerMask MtargetLayers;
    public Vector3 Point1u;
    public Vector3 Point1d;
    public Vector3 RPoint1u;
    public Vector3 RPoint1d;
    public Vector3 LPoint1u;
    public Vector3 LPoint1d;
    public Vector3 localV;
    public float AngleThreshold;
    public int Spot;
    public int Ogle;
    public int JustNoticed;
    public float ShootFrequency;
    public int ScabbardCounter;
    public int MissedShots;
    public int Dist3;
    public int TAimForce;
    public int StoredMissileBatches;
    public int Cramped;
    public int TurnertDist;
    public bool GyroOff;
    public virtual IEnumerator Start()
    {
        this.InvokeRepeating("Regenerator", 1, 1);
        this.InvokeRepeating("LeaveMarker", 8, 4);
        this.InvokeRepeating("Targety", 15, 15);
        this.InvokeRepeating("Shooty", Random.Range(2, 3), this.ShootFrequency);
        this.InvokeRepeating("EmergencyLaunchy", 1, 1.2f);
        this.InvokeRepeating("CalcLead", 1, 0.15f);
        if (this.Belfry)
        {
            this.Standby = true;
            this.vRigidbody.useGravity = false;
            yield return new WaitForSeconds(4);
            this.vRigidbody.useGravity = true;
            yield return new WaitForSeconds(0.5f);
            this.Standby = false;
            this.StartCoroutine(this.Reverse());
        }
    }

    public virtual void Update()
    {
        Vector3 newRot2 = default(Vector3);
        RaycastHit hit = default(RaycastHit);
        RaycastHit hit1 = default(RaycastHit);
        RaycastHit hit2 = default(RaycastHit);
        if (this.Standby)
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
                this.Cramped = 0;
                this.Attacking = false;
                this.Spot = 0;
                this.Hunting = true;
            }
            if (this.target == null)
            {
                this.target = this.ResetAimpoint;
                this.Gyro.AimTarget = this.ResetAimpoint;
                this.Cramped = 0;
                this.Attacking = false;
                this.Spot = 0;
                this.Hunting = true;
                this.FoundSmall = false;
            }
            else
            {
                if (this.target.name.Contains("broken"))
                {
                    this.target = this.ResetAimpoint;
                    this.Gyro.AimTarget = this.ResetAimpoint;
                    this.Cramped = 0;
                    this.Attacking = false;
                    this.Spot = 0;
                    this.Hunting = true;
                }
            }
        }
        if (this.TurnLeft)
        {
            this.Gyro.AimForce = 0;
            if (!this.LightClouter)
            {
                this.Gyro.TurnForce = -1000;
            }
            if (this.LightClouter)
            {
                this.Gyro.TurnForce = -80;
            }
        }
        if (this.TurnRight)
        {
            this.Gyro.AimForce = 0;
            if (!this.LightClouter)
            {
                this.Gyro.TurnForce = 1000;
            }
            if (this.LightClouter)
            {
                this.Gyro.TurnForce = 80;
            }
        }
        if (!this.Stuck)
        {
            if ((this.TurnRight && this.TurnLeft) && this.Obstacle)
            {
                if (!this.LightClouter)
                {
                    this.Gyro.TurnForce = -1000;
                }
                if (this.LightClouter)
                {
                    this.Gyro.TurnForce = -80;
                }
            }
        }
        if (this.Attacking || (this.Spot > 1))
        {
            if (!this.Obstacle && (this.target != null))
            {
                if (!this.TurnRight && !this.TurnLeft)
                {
                    if (((Vector3.Distance(this.thisTransform.position, this.target.position) < this.TurnertDist) && !this.TurnRight) && !this.TurnLeft)
                    {
                        if (!this.LightClouter)
                        {
                            this.Gyro.AimForce = 300;
                            this.Gyro.TurnForce = -500;
                        }
                        else
                        {
                            if (!this.Archer)
                            {
                                this.Gyro.AimForce = 30;
                                this.Gyro.TurnForce = -60;
                            }
                            else
                            {
                                this.Gyro.AimForce = -30;
                                this.Gyro.TurnForce = -60;
                            }
                        }
                    }
                    if (((Vector3.Distance(this.thisTransform.position, this.target.position) > this.TurnertDist) && !this.TurnRight) && !this.TurnLeft)
                    {
                        if (!this.LightClouter)
                        {
                            this.Gyro.AimForce = 300;
                            this.Gyro.TurnForce = -400;
                        }
                        else
                        {
                            this.Gyro.AimForce = 30;
                            this.Gyro.TurnForce = -50;
                        }
                    }
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
        if (this.RUP < 3)
        {
            this.RUP = this.RUP + 0.5f;
        }
        else
        {
            this.RUP = 0;
        }
        if (this.RRUP < 3)
        {
            this.RRUP = this.RRUP + 0.5f;
        }
        else
        {
            this.RRUP = 0;
        }
        if (this.LRUP < 3)
        {
            this.LRUP = this.LRUP + 0.5f;
        }
        else
        {
            this.LRUP = 0;
        }
        float VelClamp = Mathf.Clamp(this.vRigidbody.velocity.magnitude * 2, 20, 200);
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
        if (this.LightClouter)
        {
            Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.right * 6)) + (-this.thisTransform.up * 2)) + (this.thisTransform.up * this.RRUP), this.thisTransform.forward * VelClamp, Color.black);
            if (Physics.Raycast(((this.thisTransform.position + (this.thisTransform.right * 6)) + (-this.thisTransform.up * 2)) + (this.thisTransform.up * this.RRUP), this.thisTransform.forward, out hit1, VelClamp, (int) this.targetLayers))
            {
                this.RPoint1u = hit1.point;
            }
            else
            {
                this.RPoint1u = new Vector3(2, 2, 2);
            }
            Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.right * 6)) + (-this.thisTransform.up * 3)) + (this.thisTransform.up * this.RRUP), this.thisTransform.forward * VelClamp, Color.black);
            if (Physics.Raycast(((this.thisTransform.position + (this.thisTransform.right * 6)) + (-this.thisTransform.up * 3)) + (this.thisTransform.up * this.RRUP), this.thisTransform.forward, out hit2, VelClamp, (int) this.targetLayers))
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
            Debug.DrawRay(((this.thisTransform.position + (-this.thisTransform.right * 6)) + (-this.thisTransform.up * 2)) + (this.thisTransform.up * this.LRUP), this.thisTransform.forward * VelClamp, Color.black);
            if (Physics.Raycast(((this.thisTransform.position + (-this.thisTransform.right * 6)) + (-this.thisTransform.up * 2)) + (this.thisTransform.up * this.LRUP), this.thisTransform.forward, out hit1, VelClamp, (int) this.targetLayers))
            {
                this.LPoint1u = hit1.point;
            }
            else
            {
                this.LPoint1u = new Vector3(2, 2, 2);
            }
            Debug.DrawRay(((this.thisTransform.position + (-this.thisTransform.right * 6)) + (-this.thisTransform.up * 3)) + (this.thisTransform.up * this.LRUP), this.thisTransform.forward * VelClamp, Color.black);
            if (Physics.Raycast(((this.thisTransform.position + (-this.thisTransform.right * 6)) + (-this.thisTransform.up * 3)) + (this.thisTransform.up * this.LRUP), this.thisTransform.forward, out hit2, VelClamp, (int) this.targetLayers))
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
            if ((this.LeftDist < 8) && this.LWall)
            {
                this.Obstacle = true;
            }
            if ((this.RightDist < 8) && this.RWall)
            {
                this.Obstacle = true;
            }
        }
        else
        {
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
            if ((this.LeftDist < 10) && this.LWall)
            {
                this.Obstacle = true;
            }
            if ((this.RightDist < 10) && this.RWall)
            {
                this.Obstacle = true;
            }
        }
        if (this.Stuck)
        {
            if (!this.Belfry)
            {
                this.TurnRight = true;
            }
            else
            {
                if (this.Threat)
                {
                    if (this.LeftThreat)
                    {
                        this.TurnRight = true;
                    }
                    else
                    {
                        this.TurnLeft = true;
                    }
                }
                else
                {
                    this.TurnLeft = true;
                }
            }
        }
        else
        {
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
            if (((this.RightDist > this.LeftDist) && (this.JustNoticed < 1)) && this.LWall)
            {
                this.TurnRight = true;
            }
            if (((this.LeftDist > this.RightDist) && (this.JustNoticed < 1)) && this.RWall)
            {
                this.TurnLeft = true;
            }
        }
    }

    public virtual void FixedUpdate()
    {
        if (this.Standby)
        {
            return;
        }
        if (!this.Parked)
        {
            if (this.Stuck)
            {
                if (!this.Belfry)
                {
                    if (this.localV.y < 4)
                    {
                        if (!this.LightClouter)
                        {
                            this.vRigidbody.AddForce(this.thisVTransform.up * 250);
                        }
                        else
                        {
                            this.vRigidbody.AddForce(this.thisVTransform.up * 30);
                        }
                    }
                }
                else
                {
                    if (this.localV.y < 1)
                    {
                        this.vRigidbody.AddForce(this.thisVTransform.up * 250);
                    }
                }
            }
            else
            {
                if (this.Obstacle)
                {
                    if (-this.localV.y > 0)
                    {
                        if (!this.LightClouter)
                        {
                            this.vRigidbody.AddForce(-this.thisVTransform.up * -500);
                        }
                        else
                        {
                            this.vRigidbody.AddForce(-this.thisVTransform.up * -30);
                        }
                    }
                }
                if (!this.Belfry)
                {
                    if (this.Attacking && !this.Obstacle)
                    {
                        if (-this.localV.y < 70)
                        {
                            if (!this.LightClouter)
                            {
                                this.vRigidbody.AddForce(-this.thisVTransform.up * 250);
                            }
                            else
                            {
                                this.vRigidbody.AddForce(-this.thisVTransform.up * 30);
                            }
                        }
                    }
                }
                if (((!this.Attacking && !this.Obstacle) && !this.TurnLeft) && !this.TurnRight)
                {
                    if (!this.Belfry)
                    {
                        if (-this.localV.y < 70)
                        {
                            if (!this.LightClouter)
                            {
                                this.vRigidbody.AddForce(-this.thisVTransform.up * 100);
                            }
                            if (this.LightClouter && !this.Scabbard)
                            {
                                this.vRigidbody.AddForce(-this.thisVTransform.up * 20);
                            }
                            if (this.Scabbard)
                            {
                                this.vRigidbody.AddForce(-this.thisVTransform.up * 10);
                            }
                        }
                    }
                    else
                    {
                        if (-this.localV.y < 120)
                        {
                            this.vRigidbody.AddForce(-this.thisVTransform.up * 250);
                        }
                    }
                }
            }
        }
        if ((this.target && !this.Scabbard) && !this.Belfry)
        {
            this.Turret.GetComponent<Rigidbody>().AddForceAtPosition((this.TargetLead.position - this.Turret.transform.position).normalized * this.TAimForce, -this.Turret.transform.up * 2);
            this.Turret.GetComponent<Rigidbody>().AddForceAtPosition((this.TargetLead.position - this.Turret.transform.position).normalized * -this.TAimForce, this.Turret.transform.up * 2);
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        string ON = other.name;
        Transform OT = other.transform;
        if (Physics.Linecast(this.thisTransform.position, OT.position, (int) this.MtargetLayers))
        {
            return;
        }
        if (!this.Belfry)
        {
            if (!this.Attacking && (this.Ogle < 1))
            {
                if (ON.Contains("TC"))
                {
                    if (!ON.Contains("TC7"))
                    {
                        this.Hunting = false;
                        this.target = OT;
                        this.Gyro.AimTarget = OT;
                        if (!this.Attacking && (this.Spot < 1))
                        {
                            this.Spot = 30;
                            GameObject TheThing = UnityEngine.Object.Instantiate(this.SpotSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                            TheThing.transform.parent = this.thisTransform;
                        }
                    }
                }
            }
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
                    if (!this.Attacking)
                    {
                        this.DangerSense = 8;
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
    }

    public virtual void OnTriggerStay(Collider other)
    {
        string ON = other.name;
        Transform OT = other.transform;
        if (!ON.Contains("x"))
        {
            if (Physics.Linecast(this.thisTransform.position, OT.position, (int) this.MtargetLayers))
            {
                return;
            }
        }
        if (!this.Belfry)
        {
            if (this.PissedAtTC0a > 1)
            {
                if (ON.Contains("TC0a"))
                {
                    if (!this.Attacking)
                    {
                        GameObject TheThing21 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                        TheThing21.transform.parent = this.thisTransform;
                    }
                    this.Spot = 0;
                    this.Hunting = false;
                    this.Attacking = true;
                    this.target = OT;
                    if (this.Gyro != null)
                    {
                        this.Gyro.AimTarget = OT;
                    }
                    this.PissedAtTC0a = this.PissedAtTC0a - 1;
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
                        if (!this.Attacking)
                        {
                            GameObject TheThing2 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                            TheThing2.transform.parent = this.thisTransform;
                        }
                        this.Spot = 0;
                        this.Hunting = false;
                        this.Attacking = true;
                        this.target = OT;
                        if (this.Gyro != null)
                        {
                            this.Gyro.AimTarget = OT;
                        }
                        this.PissedAtTC1 = this.PissedAtTC1 - 1;
                    }
                }
            }
            if (this.PissedAtTC2 > 1)
            {
                if (ON.Contains("TC2"))
                {
                    if (ON.Contains("bTC2"))
                    {
                        return;
                    }
                    if (!this.Attacking)
                    {
                        GameObject TheThing3 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                        TheThing3.transform.parent = this.thisTransform;
                    }
                    this.Spot = 0;
                    this.Hunting = false;
                    this.Attacking = true;
                    this.target = OT;
                    if (this.Gyro != null)
                    {
                        this.Gyro.AimTarget = OT;
                    }
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
                            if (!this.Attacking)
                            {
                                GameObject TheThing4 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                                TheThing4.transform.parent = this.thisTransform;
                            }
                            this.Spot = 0;
                            this.Hunting = false;
                            this.Attacking = true;
                            this.target = OT;
                            if (this.Gyro != null)
                            {
                                this.Gyro.AimTarget = OT;
                            }
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
                        if (!this.Attacking)
                        {
                            GameObject TheThing5 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                            TheThing5.transform.parent = this.thisTransform;
                        }
                        this.Spot = 0;
                        this.Hunting = false;
                        this.Attacking = true;
                        this.target = OT;
                        if (this.Gyro != null)
                        {
                            this.Gyro.AimTarget = OT;
                        }
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
                            if (!this.Attacking)
                            {
                                GameObject TheThing6 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                                TheThing6.transform.parent = this.thisTransform;
                            }
                            this.Spot = 0;
                            this.Hunting = false;
                            this.Attacking = true;
                            this.target = OT;
                            if (this.Gyro != null)
                            {
                                this.Gyro.AimTarget = OT;
                            }
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
                            if (!this.Attacking)
                            {
                                GameObject TheThing7 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                                TheThing7.transform.parent = this.thisTransform;
                            }
                            this.Spot = 0;
                            this.Hunting = false;
                            this.Attacking = true;
                            this.target = OT;
                            if (this.Gyro != null)
                            {
                                this.Gyro.AimTarget = OT;
                            }
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
                            if (!this.Attacking)
                            {
                                GameObject TheThing8 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                                TheThing8.transform.parent = this.thisTransform;
                            }
                            this.Spot = 0;
                            this.Hunting = false;
                            this.Attacking = true;
                            this.target = OT;
                            if (this.Gyro != null)
                            {
                                this.Gyro.AimTarget = OT;
                            }
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
                            if (!this.Attacking)
                            {
                                GameObject TheThing9 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                                TheThing9.transform.parent = this.thisTransform;
                            }
                            this.Spot = 0;
                            this.Hunting = false;
                            this.Attacking = true;
                            this.target = OT;
                            if (this.Gyro != null)
                            {
                                this.Gyro.AimTarget = OT;
                            }
                            this.PissedAtTC9 = this.PissedAtTC9 - 1;
                        }
                    }
                }
            }
        }
        else
        {
            if (!ON.Contains("C7"))
            {
                if (ON.Contains("bTC"))
                {
                    this.Threat = OT;
                    MevNavNetwork.instance.Threat1 = this.Threat;
                }
            }
        }
    }

    public virtual void Shoot()
    {
        this.Gun.Fire();
    }

    public virtual IEnumerator Launch()
    {
        if (!this.Scabbard)
        {
            if (this.Attacking && (this.StoredMissileBatches > 0))
            {
                this.MissedShots = 0;
                this.StoredMissileBatches = this.StoredMissileBatches - 1;
                if (!this.Archer)
                {
                    if (this.Missile1 != null)
                    {
                        GameObject _SpawnedObject1 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile1.position, this.Missile1.rotation);
                        _SpawnedObject1.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                        ((MissileScript) _SpawnedObject1.transform.GetComponent(typeof(MissileScript))).target = this.target;
                    }
                    yield return new WaitForSeconds(0.3f);
                    if (this.Missile2 != null)
                    {
                        GameObject _SpawnedObject2 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile2.position, this.Missile2.rotation);
                        _SpawnedObject2.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                        ((MissileScript) _SpawnedObject2.transform.GetComponent(typeof(MissileScript))).target = this.target;
                    }
                }
                else
                {
                    this.Dist3 = 6;
                    if (this.Missile1 != null)
                    {
                        GameObject _SpawnedObject3 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile1.position, this.Missile1.rotation);
                        _SpawnedObject3.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                        ((MissileScript) _SpawnedObject3.transform.GetComponent(typeof(MissileScript))).target = this.TargetLead;
                    }
                    yield return new WaitForSeconds(0.3f);
                    if (this.Missile2 != null)
                    {
                        GameObject _SpawnedObject4 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile2.position, this.Missile2.rotation);
                        _SpawnedObject4.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                        ((MissileScript) _SpawnedObject4.transform.GetComponent(typeof(MissileScript))).target = this.TargetLead;
                    }
                    yield return new WaitForSeconds(3);
                    this.Dist3 = 3;
                }
            }
        }
        else
        {
            if ((this.StoredMissileBatches > 0) && (this.ScabbardCounter < 1))
            {
                this.StoredMissileBatches = this.StoredMissileBatches - 1;
                GameObject _SpawnedObject5 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile1.position, this.Missile1.rotation);
                _SpawnedObject5.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                ((MissileScript) _SpawnedObject5.transform.GetComponent(typeof(MissileScript))).target = this.target;
                this.ScabbardCounter = 24;
            }
            yield return new WaitForSeconds(1);
            if (this.StoredMissileBatches > 0)
            {
                if (MevNavNetwork.RequestCruiseMissile)
                {
                    this.StoredMissileBatches = this.StoredMissileBatches - 1;
                    GameObject _SpawnedObject6 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile1.position, this.Missile1.rotation);
                    _SpawnedObject6.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                    this.ActiveMissile = _SpawnedObject6;
                    MevNavNetwork.RequestCruiseMissile = false;
                }
            }
        }
    }

    public virtual void Shooty()
    {
        if ((this.Attacking && this.target) && !this.Belfry)
        {
            if (!this.Archer)
            {
                this.Shoot();
                if (((!this.Gun.LineOfFire && !this.TurnLeft) && !this.TurnRight) && (Vector3.Distance(this.thisTransform.position, this.target.position) < 200))
                {
                    this.MissedShots = this.MissedShots + 1;
                }
                if (!this.LightClouter && (this.MissedShots > 16))
                {
                    this.StartCoroutine(this.Launch());
                }
            }
            else
            {
                this.StartCoroutine(this.Launch());
            }
        }
    }

    public virtual void EmergencyLaunchy()
    {
        if (!this.Emergency || this.Belfry)
        {
            return;
        }
        if (!this.LightClouter)
        {
            this.StartCoroutine(this.Launch());
        }
        else
        {
            if (this.Archer && !this.Scabbard)
            {
                this.StartCoroutine(this.Launch());
            }
        }
    }

    public virtual void Targety()
    {
        if (((this.Spot < 1) && !this.Attacking) && !this.Belfry)
        {
            this.StartCoroutine(this.TargetArea());
        }
    }

    public virtual IEnumerator TargetArea()
    {
        if (!this.Attacking && (MevNavNetwork.AlertTime > 0))
        {
            this.Waypoint.transform.position = MevNavNetwork.instance.PriorityWaypoint.position;
            this.target = this.Waypoint;
            this.Gyro.AimTarget = this.Waypoint;
        }
        yield return new WaitForSeconds(10);
        if (this.Ogle < 1)
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
        if ((Vector3.Distance(this.thisTransform.position, lastPos) < 1) && !this.Parked)
        {
            this.Stuck = true;
            yield return new WaitForSeconds(3);
            this.Stuck = false;
        }
    }

    public virtual IEnumerator Reverse()
    {
        if (!this.Threat && this.Parked)
        {
            yield break;
        }
        if (this.Threat)
        {
            Vector3 relativePoint = this.thisVTransform.InverseTransformPoint(this.Threat.position);
        
            if (relativePoint.x < 0)
            {
                this.LeftThreat = true;
            }
            else
            {
                this.LeftThreat = false;
            }
        }
        this.Stuck = true;
        this.TurnRight = false;
        this.TurnLeft = false;
        yield return new WaitForSeconds(1.5f);
        this.Stuck = false;
    }

    public virtual void CalcLead()
    {
        if (!this.Scabbard && !this.Belfry)
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
        if (this.target)
        {
            float Dist1 = Vector3.Distance(this.thisTransform.position, this.target.position);
            float Dist2 = Vector3.Distance(this.TargetTrace.position, this.target.position);
            this.TargetTrace.LookAt(this.target);
            this.TargetLead.position = this.TargetTrace.position;
            this.TargetLead.rotation = this.TargetTrace.rotation;
            if (!this.Archer)
            {
                this.TargetLead.position = this.TargetLead.position + (((this.TargetLead.forward * Dist1) * Dist2) * 0.02f);
            }
            else
            {
                this.TargetLead.position = this.TargetLead.position + ((this.TargetLead.forward * Dist2) * this.Dist3);
            }
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

    public virtual IEnumerator Notice()
    {
        if ((this.target != null) && this.Attacking)
        {
            Vector3 lastTPos = this.thisTransform.position;
            yield return new WaitForSeconds(0.2f);
            if (this.target != null)
            {
                if (Vector3.Distance(this.thisTransform.position, lastTPos) > 20)
                {
                    MevNavNetwork.instance.EnemyTarget2 = this.target;
                }
            }
        }
        if (this.Attacking)
        {
            if (!this.Scabbard)
            {
                if (this.Emergency)
                {
                    if (!MevNavNetwork.instance.EnemyTarget1)
                    {
                        MevNavNetwork.instance.EnemyTarget1 = this.target;
                    }
                }
                if (this.target != null)
                {
                    if (this.target.name.Contains("bTC") && !this.HasRequested)
                    {
                        this.HasRequested = true;
                        MevNavNetwork.RequestCruiseMissile = true;
                        MevNavNetwork.instance.EnemyTarget2 = this.target;
                    }
                }
            }
            else
            {
                if ((this.target != null) && (this.ActiveMissile != null))
                {
                    if (this.target.name.Contains("bTC"))
                    {
                        if (this.ActiveMissile.name == "Broken")
                        {
                            this.ActiveMissile = null;
                            this.ScabbardCounter = 0;
                        }
                    }
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

    public virtual void Regenerator()
    {
        if (!this.Belfry)
        {
            if (MevNavNetwork.AlertTime > 230)
            {
                this.StartCoroutine(this.TargetArea());
                MevNavNetwork.AlertTime = 230;
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
                if (!this.Attacking)
                {
                    if (this.LightClouter)
                    {
                        if (Vector3.Distance(this.thisTransform.position, this.target.position) < 32)
                        {
                            if (this.target.name.Contains("TC0") && (this.PissedAtTC0a < 300))
                            {
                                this.PissedAtTC0a = this.PissedAtTC0a + 1;
                            }
                            if (this.target.name.Contains("TC1") && (this.PissedAtTC1 < 300))
                            {
                                this.PissedAtTC1 = this.PissedAtTC1 + 1;
                            }
                            if (this.target.name.Contains("TC3") && (this.PissedAtTC3 < 300))
                            {
                                this.PissedAtTC3 = this.PissedAtTC3 + 1;
                            }
                            if (this.target.name.Contains("TC4") && (this.PissedAtTC4 < 300))
                            {
                                this.PissedAtTC4 = this.PissedAtTC4 + 1;
                            }
                            if (this.target.name.Contains("TC5") && (this.PissedAtTC5 < 300))
                            {
                                this.PissedAtTC5 = this.PissedAtTC5 + 1;
                            }
                            if (this.target.name.Contains("TC6"))
                            {
                                this.PissedAtTC6 = this.PissedAtTC6 + 1;
                            }
                            if (this.target.name.Contains("TC8") && (this.PissedAtTC8 < 300))
                            {
                                this.PissedAtTC8 = this.PissedAtTC8 + 1;
                            }
                            if (this.target.name.Contains("TC9") && (this.PissedAtTC9 < 300))
                            {
                                this.PissedAtTC9 = this.PissedAtTC9 + 1;
                            }
                        }
                    }
                    if (!this.LightClouter)
                    {
                        if (Vector3.Distance(this.thisTransform.position, this.target.position) < 32)
                        {
                            if (this.target.name.Contains("TC0") && (this.PissedAtTC0a < 300))
                            {
                                this.PissedAtTC0a = this.PissedAtTC0a + 1;
                            }
                            if (this.target.name.Contains("TC1") && (this.PissedAtTC1 < 300))
                            {
                                this.PissedAtTC1 = this.PissedAtTC1 + 1;
                            }
                            if (this.target.name.Contains("TC3") && (this.PissedAtTC3 < 300))
                            {
                                this.PissedAtTC3 = this.PissedAtTC3 + 1;
                            }
                            if (this.target.name.Contains("TC4") && (this.PissedAtTC4 < 300))
                            {
                                this.PissedAtTC4 = this.PissedAtTC4 + 1;
                            }
                            if (this.target.name.Contains("TC5") && (this.PissedAtTC5 < 300))
                            {
                                this.PissedAtTC5 = this.PissedAtTC5 + 1;
                            }
                            if (this.target.name.Contains("TC6"))
                            {
                                this.PissedAtTC6 = this.PissedAtTC6 + 1;
                            }
                            if (this.target.name.Contains("TC8") && (this.PissedAtTC8 < 300))
                            {
                                this.PissedAtTC8 = this.PissedAtTC8 + 1;
                            }
                            if (this.target.name.Contains("TC9") && (this.PissedAtTC9 < 300))
                            {
                                this.PissedAtTC9 = this.PissedAtTC9 + 1;
                            }
                        }
                    }
                    if (this.target.name.Contains("TC6"))
                    {
                        if (!this.target.name.Contains("csT"))
                        {
                            this.PissedAtTC6 = 2;
                        }
                    }
                    if (this.Ogle > 0)
                    {
                        if (Vector3.Distance(this.thisTransform.position, this.target.position) < 64)
                        {
                            this.Parked = true;
                            this.Ogle = this.Ogle - 1;
                        }
                        else
                        {
                            this.Parked = false;
                        }
                        if (this.Ogle == 1)
                        {
                            this.Parked = false;
                            this.target = this.Waypoint;
                            this.Gyro.AimTarget = this.Waypoint;
                        }
                    }
                }
                else
                {
                    if (this.target.name.Contains("sT"))
                    {
                        this.FoundSmall = true;
                    }
                }
            }
            if (((this.Spot == 1) && (this.Ogle < 1)) && !this.Attacking)
            {
                this.Spot = 0;
                this.Hunting = true;
                GameObject TheThing1 = UnityEngine.Object.Instantiate(this.RejectSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                TheThing1.transform.parent = this.thisTransform;
                this.target = this.ResetAimpoint;
                this.Gyro.AimTarget = this.ResetAimpoint;
                this.Targety();
            }
            if (this.Attacking)
            {
                this.Trig.center = new Vector3(0, 0, 0);
                this.Trig.radius = 50;
                this.Trig.height = 50;
                if (this.target != null)
                {
                    if (!Physics.Linecast(this.thisTransform.position, this.target.position, (int) this.targetLayers))
                    {
                        this.TurnRight = false;
                        this.TurnLeft = false;
                        this.JustNoticed = 2;
                    }
                }
                this.DangerSense = 0;
            }
            else
            {
                this.Trig.center = new Vector3(0, 0, 200);
                this.Trig.radius = 200;
                this.Trig.height = 800;
                if (this.DangerSense > 0)
                {
                    if (this.DangerSense < 2)
                    {
                        this.target = this.ResetAimpoint;
                        this.Gyro.AimTarget = this.ResetAimpoint;
                    }
                    this.DangerSense = this.DangerSense - 1;
                }
            }
        }
        else
        {
            this.Trig.center = new Vector3(0, 0, 0);
            this.Trig.radius = 500;
            this.Trig.height = 500;
            if (this.DeusDamage)
            {
                if (Vector3.Distance(this.thisTransform.position, this.Waypoint.position) > 150)
                {
                    this.DeusDamage.RemoteDet();
                }
            }
        }
        if (this.Spot > 0)
        {
            this.Spot = this.Spot - 1;
        }
        if (this.JustNoticed > 0)
        {
            this.JustNoticed = this.JustNoticed - 1;
        }
        if (this.ScabbardCounter > 0)
        {
            this.ScabbardCounter = this.ScabbardCounter - 1;
        }
        if (!this.LightClouter)
        {
            this.Gyro.AimForce = 300;
        }
        else
        {
            this.Gyro.AimForce = 30;
        }
        this.Gyro.TurnForce = 0;
        this.Wall = false;
        this.RWall = false;
        this.LWall = false;
        this.TurnRight = false;
        this.TurnLeft = false;
        if (!this.Belfry)
        {
            this.StartCoroutine(this.Notice());
        }
        //========================================================================================================================//
        //////////////////////////////////////////////////////[INTERACTION]/////////////////////////////////////////////////////////
        //========================================================================================================================//
        if (NotiScript.PiriNotis)
        {
            if (Vector3.Distance(this.thisTransform.position, PlayerInformation.instance.Pirizuka.position) < 128)
            {
                if (this.convNum < 4)
                {
                    if (!this.Attacking)
                    {
                        this.target = PlayerInformation.instance.PiriTarget;
                        this.Gyro.AimTarget = PlayerInformation.instance.PiriTarget;
                        this.Ogle = 20;
                    }
                    else
                    {
                        if (this.target)
                        {
                            if (this.target.name.Contains("TC1"))
                            {
                                this.target = PlayerInformation.instance.PiriTarget;
                                this.Gyro.AimTarget = PlayerInformation.instance.PiriTarget;
                                this.Ogle = 20;
                            }
                        }
                    }
                }
                NotiScript.PiriNotis = false;
            }
        }
        if (this.Ogle > 0)
        {
            if (WorldInformation.pSpeech)
            {
                if (WorldInformation.pSpeech.name.Contains("a1"))
                {
                    if (Vector3.Distance(this.thisTransform.position, WorldInformation.pSpeech.position) < 32)
                    {
                        if (this.target.name.Contains("TC7"))
                        {
                            this.StartCoroutine(this.ProcessSpeech(TalkBubbleScript.myText, 0, 1));
                        }
                        else
                        {
                            this.StartCoroutine(this.ProcessSpeech(TalkBubbleScript.myText, 0, 0));
                        }
                    }
                }
                if (WorldInformation.pSpeech.name.Contains("b1"))
                {
                    if (Vector3.Distance(this.thisTransform.position, WorldInformation.pSpeech.position) < 128)
                    {
                        if (this.target.name.Contains("TC7"))
                        {
                            this.StartCoroutine(this.ProcessSpeech(TalkBubbleScript.myText, 1, 1));
                        }
                        else
                        {
                            this.StartCoroutine(this.ProcessSpeech(TalkBubbleScript.myText, 1, 0));
                        }
                    }
                }
                if (WorldInformation.pSpeech.name.Contains("c1"))
                {
                    if (Vector3.Distance(this.thisTransform.position, WorldInformation.pSpeech.position) < 256)
                    {
                        if (this.target.name.Contains("TC7"))
                        {
                            this.StartCoroutine(this.ProcessSpeech(TalkBubbleScript.myText, 2, 1));
                        }
                        else
                        {
                            this.StartCoroutine(this.ProcessSpeech(TalkBubbleScript.myText, 2, 0));
                        }
                    }
                }
                WorldInformation.pSpeech = null;
            }
        }
    }

    //========================================================================================================================//
    //////////////////////////////////////////////////////[INTERACTION]/////////////////////////////////////////////////////////
    //========================================================================================================================//
    public int convNum;
    public int boredom;
    public virtual IEnumerator ProcessSpeech(string speech, int mode, int code)
    {
        yield return new WaitForSeconds(0.1f);
        if (!!string.IsNullOrEmpty(speech))
        {
            yield break;
        }
        if (code == 0)
        {
            if (mode == 0)
            {
                if (this.convNum == 0)
                {
                    //===============================================================================
                    if ((speech.Contains("hi") || speech.Contains("hey")) || speech.Contains("yo"))
                    {
                        this.convNum = 1;
                        this.Ogle = 2;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Jet off, stranger.");
                        yield break;
                    }
                    if (speech.Contains("hello") || speech.Contains("greet"))
                    {
                        this.convNum = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("I don't know you. \n State your business!");
                        yield break;
                    }
                    if (speech.Contains("stop"))
                    {
                        this.convNum = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("What is it?");
                        yield break;
                    }
                }
                //===============================================================================
                if (this.convNum == 1)
                {
                    //===============================================================================
                    if (speech.Contains("go"))
                    {
                        this.convNum = 4;
                        this.Ogle = 2;
                        yield return new WaitForSeconds(4);
                        this.ReturnSpeech("You better bug off, now.");
                        yield break;
                    }
                    if (speech.Contains("drive"))
                    {
                        this.convNum = 4;
                        this.Ogle = 2;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Don't tell me what to do.");
                        yield break;
                    }
                    if (speech.Contains("stop"))
                    {
                        this.convNum = 2;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("You need to start talking.");
                        yield break;
                    }
                }
                //===============================================================================
                if (this.convNum == 2)
                {
                    //===============================================================================
                    if (speech.Contains("go"))
                    {
                        this.convNum = 4;
                        this.Ogle = 1;
                        yield return new WaitForSeconds(2);
                        this.PissedAtTC1 = 4;
                        this.FoundSmall = false;
                        yield break;
                    }
                    if (speech.Contains("drive"))
                    {
                        this.convNum = 4;
                        this.Ogle = 1;
                        yield return new WaitForSeconds(2);
                        this.PissedAtTC1 = 4;
                        this.FoundSmall = false;
                        yield break;
                    }
                    if (speech.Contains("stop"))
                    {
                        this.convNum = 4;
                        this.Ogle = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Alright. We're done here.");
                        yield break;
                    }
                }
            }
            //===============================================================================
            //======================================================================================================================================
            //======================================================================================================================================
            if (mode == 0)
            {
                if (this.convNum == 0)
                {
                    //===============================================================================
                    if ((speech.Contains("hi") || speech.Contains("hey")) || speech.Contains("yo"))
                    {
                        this.convNum = 1;
                        this.Ogle = 2;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Jet off, stranger.");
                        yield break;
                    }
                    if (speech.Contains("hello") || speech.Contains("greet"))
                    {
                        this.convNum = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("I don't know you. \n State your business!");
                        yield break;
                    }
                    if (speech.Contains("stop"))
                    {
                        this.convNum = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("What is it?");
                        yield break;
                    }
                }
                //===============================================================================
                if (this.convNum == 1)
                {
                    //===============================================================================
                    if (speech.Contains("go"))
                    {
                        this.convNum = 4;
                        this.Ogle = 2;
                        yield return new WaitForSeconds(4);
                        this.ReturnSpeech("You better bug off, now.");
                        yield break;
                    }
                    if (speech.Contains("drive"))
                    {
                        this.convNum = 4;
                        this.Ogle = 2;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Don't tell me what to do.");
                        yield break;
                    }
                    if (speech.Contains("stop"))
                    {
                        this.convNum = 2;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("You need to start talking.");
                        yield break;
                    }
                }
                //===============================================================================
                if (this.convNum == 2)
                {
                    //===============================================================================
                    if (speech.Contains("go"))
                    {
                        this.convNum = 4;
                        this.Ogle = 1;
                        yield return new WaitForSeconds(2);
                        this.PissedAtTC1 = 4;
                        this.FoundSmall = false;
                        yield break;
                    }
                    if (speech.Contains("drive"))
                    {
                        this.convNum = 4;
                        this.Ogle = 1;
                        yield return new WaitForSeconds(2);
                        this.PissedAtTC1 = 4;
                        this.FoundSmall = false;
                        yield break;
                    }
                    if (speech.Contains("stop"))
                    {
                        this.convNum = 4;
                        this.Ogle = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Alright. We're done here.");
                        yield break;
                    }
                }
            }
            //===============================================================================
            //======================================================================================================================================
            //======================================================================================================================================
            if (mode == 2)
            {
                if (this.convNum == 0)
                {
                    //===============================================================================
                    if ((speech.Contains("hi") || speech.Contains("hey")) || speech.Contains("yo"))
                    {
                        this.convNum = 1;
                        this.Ogle = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Whatever you want \n I don't want to be part of it.");
                        yield break;
                    }
                    if (speech.Contains("hello") || speech.Contains("greet"))
                    {
                        this.convNum = 1;
                        this.Ogle = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("I don't know you. \n Keep your distance!");
                        yield break;
                    }
                    if (speech.Contains("stop"))
                    {
                        this.convNum = 1;
                        this.Ogle = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("What are you going to do?");
                        yield break;
                    }
                }
            }
        }
        else
        {
            //===============================================================================
            //=================================================================================================================================
            //=================================================================================================================================
            //=================================================================================================================================
            //=================================================================================================================================
            if (mode == 0)
            {
                if (this.convNum == 0)
                {
                    //===============================================================================
                    if (speech.Contains("deus") || speech.Contains("vult"))
                    {
                        this.convNum = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Deus vult, brother.");
                        yield break;
                    }
                    if ((speech.Contains("hi") || speech.Contains("hey")) || speech.Contains("yo"))
                    {
                        this.convNum = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Hello. Is there anything you want?");
                        yield break;
                    }
                    if (speech.Contains("hello") || speech.Contains("greet"))
                    {
                        this.convNum = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Hello, citizen. \n What is on your mind?");
                        yield break;
                    }
                    if (speech.Contains("stop"))
                    {
                        this.convNum = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("What is it?");
                        yield break;
                    }
                }
                //===============================================================================
                if (this.convNum == 1)
                {
                    //===============================================================================
                    if (speech.Contains("deus") || speech.Contains("vult"))
                    {
                        this.convNum = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Deus vult!");
                        yield break;
                    }
                    if (speech.Contains("yes"))
                    {
                        this.convNum = 2;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("I don't have much time to talk.");
                        yield break;
                    }
                    if (speech.Contains("no"))
                    {
                        this.convNum = 2;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Well then.");
                        yield break;
                    }
                    if (speech.Contains("go"))
                    {
                        this.convNum = 2;
                        this.Ogle = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech(". . .");
                        yield break;
                    }
                    if (speech.Contains("drive"))
                    {
                        this.convNum = 2;
                        this.Ogle = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Don't tell me what to do.");
                        yield break;
                    }
                    if (speech.Contains("stop"))
                    {
                        this.convNum = 2;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("You need to start talking.");
                        yield break;
                    }
                }
                //===============================================================================
                if (this.convNum == 2)
                {
                    //===============================================================================
                    if (speech.Contains("deus") || speech.Contains("vult"))
                    {
                        this.convNum = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Deus \n VULT");
                        yield break;
                    }
                    if (speech.Contains("yes"))
                    {
                        this.convNum = 3;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Bye!");
                        yield break;
                    }
                    if (speech.Contains("no"))
                    {
                        this.convNum = 3;
                        this.Ogle = 1;
                        yield return new WaitForSeconds(2);
                        yield break;
                    }
                    if (speech.Contains("go"))
                    {
                        this.convNum = 3;
                        this.Ogle = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Don't be pushy now.");
                        yield break;
                    }
                    if (speech.Contains("drive"))
                    {
                        this.convNum = 3;
                        this.Ogle = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech(". . .");
                        yield break;
                    }
                    if (speech.Contains("stop"))
                    {
                        this.convNum = 3;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Alright. We're done here.");
                        yield break;
                    }
                }
            }
            //===============================================================================
            //======================================================================================================================================
            //======================================================================================================================================
            if (mode == 1)
            {
                if (this.convNum == 0)
                {
                    //===============================================================================
                    if (speech.Contains("deus") || speech.Contains("vult"))
                    {
                        this.convNum = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Deus vult, brother.");
                        this.Ogle = 4;
                        yield break;
                    }
                    if ((speech.Contains("hi") || speech.Contains("hey")) || speech.Contains("yo"))
                    {
                        this.convNum = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Hello. Is there anything you want?");
                        yield break;
                    }
                    if (speech.Contains("hello") || speech.Contains("greet"))
                    {
                        this.convNum = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Hello, citizen. \n What is on your mind?");
                        yield break;
                    }
                    if (speech.Contains("stop"))
                    {
                        this.convNum = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("What is it?");
                        yield break;
                    }
                }
                //===============================================================================
                if (this.convNum == 1)
                {
                    //===============================================================================
                    if (speech.Contains("deus") || speech.Contains("vult"))
                    {
                        this.convNum = 2;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Deus vult!");
                        this.Ogle = 4;
                        yield break;
                    }
                    if (speech.Contains("yes"))
                    {
                        this.convNum = 2;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("I don't have much time to talk.");
                        yield break;
                    }
                    if (speech.Contains("no"))
                    {
                        this.convNum = 2;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Well then.");
                        yield break;
                    }
                    if (speech.Contains("go"))
                    {
                        this.convNum = 2;
                        this.Ogle = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech(". . .");
                        yield break;
                    }
                    if (speech.Contains("drive"))
                    {
                        this.convNum = 2;
                        this.Ogle = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Don't tell me what to do.");
                        yield break;
                    }
                    if (speech.Contains("stop"))
                    {
                        this.convNum = 2;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("You need to start talking.");
                        yield break;
                    }
                }
                //===============================================================================
                if (this.convNum == 2)
                {
                    //===============================================================================
                    if (speech.Contains("deus") || speech.Contains("vult"))
                    {
                        this.convNum = 3;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Deus \n VULT");
                        this.Ogle = 4;
                        yield break;
                    }
                    if (speech.Contains("yes"))
                    {
                        this.convNum = 3;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Bye!");
                        yield break;
                    }
                    if (speech.Contains("no"))
                    {
                        this.convNum = 3;
                        this.Ogle = 1;
                        yield return new WaitForSeconds(2);
                        yield break;
                    }
                    if (speech.Contains("go"))
                    {
                        this.convNum = 3;
                        this.Ogle = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Don't be pushy now.");
                        yield break;
                    }
                    if (speech.Contains("drive"))
                    {
                        this.convNum = 3;
                        this.Ogle = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech(". . .");
                        yield break;
                    }
                    if (speech.Contains("stop"))
                    {
                        this.convNum = 3;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Alright. We're done here.");
                        yield break;
                    }
                }
            }
            //===============================================================================
            //======================================================================================================================================
            //======================================================================================================================================
            if (mode == 2)
            {
                if (this.convNum == 0)
                {
                    //===============================================================================
                    if ((speech.Contains("hi") || speech.Contains("hey")) || speech.Contains("yo"))
                    {
                        this.convNum = 1;
                        this.Ogle = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Whatever you want \n I don't want to be part of it.");
                        yield break;
                    }
                    if (speech.Contains("hello") || speech.Contains("greet"))
                    {
                        this.convNum = 1;
                        this.Ogle = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("I don't know you. \n Keep your distance!");
                        yield break;
                    }
                    if (speech.Contains("stop"))
                    {
                        this.convNum = 1;
                        this.Ogle = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("What are you going to do?");
                        yield break;
                    }
                }
            }
        }
        //===============================================================================
        //=================================================================================================================================
        //============================================////[Conflict Reactions]////=========================================================
        //=================================================================================================================================
        if (this.convNum == 4)
        {
            if (MevNavNetwork.TC1DeathRow > 0)
            {
                if (mode < 2)
                {
                    //===============================================================================
                    if (speech.Contains("ok"))
                    {
                        this.convNum = 99;
                        this.Ogle = 1;
                        yield return new WaitForSeconds(1);
                        this.ReturnSpeech("Poke your face out, \n and I'll shoot it off!");
                        yield break;
                    }
                    if (speech.Contains("sorry"))
                    {
                        this.convNum = 99;
                        this.Ogle = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Just get fucked!");
                        yield break;
                    }
                    if (speech.Contains("please"))
                    {
                        this.convNum = 99;
                        this.Ogle = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Cry more, idiot!");
                        yield break;
                    }
                    if (speech.Contains("stop"))
                    {
                        this.convNum = 99;
                        this.Ogle = 1;
                        yield return new WaitForSeconds(1);
                        this.ReturnSpeech("Stop whining and just \n accept your death.");
                        yield break;
                    }
                    if (speech.Contains("excuse"))
                    {
                        this.convNum = 99;
                        this.Ogle = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("How nice of you to tell us \n to stop retaliating, asshole!");
                        yield break;
                    }
                }
                else
                {
                    //===============================================================================
                    //===============================================================================
                    if (speech.Contains("ok"))
                    {
                        this.convNum = 99;
                        yield return new WaitForSeconds(4);
                        this.ReturnSpeech("Try and hit me, punk!");
                        this.Ogle = 1;
                        yield break;
                    }
                    if (speech.Contains("sorry"))
                    {
                        this.convNum = 99;
                        yield return new WaitForSeconds(4);
                        this.ReturnSpeech("Hah! You and your \n big-ass vehicle... Fuck you!");
                        this.Ogle = 1;
                        yield break;
                    }
                    if (speech.Contains("please"))
                    {
                        this.convNum = 99;
                        yield return new WaitForSeconds(4);
                        this.ReturnSpeech("I'll trade your virginity \n with that mean machine of yours.");
                        this.Ogle = 1;
                        yield break;
                    }
                    if (speech.Contains("stop"))
                    {
                        this.convNum = 99;
                        yield return new WaitForSeconds(4);
                        this.ReturnSpeech("Just let me put some more \n shots into you...");
                        this.Ogle = 1;
                        yield break;
                    }
                    if (speech.Contains("excuse"))
                    {
                        this.convNum = 99;
                        yield return new WaitForSeconds(4);
                        this.ReturnSpeech("Stop being a bitch!");
                        this.Ogle = 1;
                        yield break;
                    }
                }
            }
        }
        //===============================================================================
        if (this.convNum > 0)
        {
            if (this.boredom < 3)
            {
                if (((speech.Contains("bye") || speech.Contains("see")) || speech.Contains("fare")) || speech.Contains("later"))
                {
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Goodbye.");
                    this.Ogle = 2;
                    yield break;
                }
                if ((speech.Contains("thank") || speech.Contains("good")) || speech.Contains("like"))
                {
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech(". . .Sure, bye.");
                    this.Ogle = 2;
                    yield break;
                }
            }
            //===============================================================================
            if (speech.Contains("cunt"))
            {
                this.boredom = 3;
                this.convNum = 4;
                this.Ogle = 1;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Nice to know, now fuck off.");
                yield break;
            }
            if (speech.Contains("ass"))
            {
                this.boredom = 4;
                this.convNum = 4;
                this.Ogle = 1;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("You want a smoldering hole \n in your face?");
                yield break;
            }
            if (speech.Contains("fuck you"))
            {
                this.boredom = 3;
                this.convNum = 4;
                this.Ogle = 1;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Oh, is that a threat?");
                yield break;
            }
            if (speech.Contains("fuck off"))
            {
                this.boredom = 4;
                this.convNum = 4;
                this.Ogle = 1;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Say that again, motherfucker...");
                yield break;
            }
            if (speech.Contains("go away"))
            {
                this.boredom = 3;
                this.convNum = 4;
                this.Ogle = 1;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Go ahead and push your luck \n one more time.");
                yield break;
            }
        }
        //===============================================================================
        yield return new WaitForSeconds(2);
        if (code == 0)
        {
            if (this.boredom == 0)
            {
                this.ReturnSpeech("What?");
            }
            if (this.boredom == 1)
            {
                this.ReturnSpeech("You need to start making sense \n right about now.");
                this.convNum = 1;
            }
            if (this.boredom == 2)
            {
                this.ReturnSpeech("Get to the point. \n Or I will chase you away!");
                this.convNum = 1;
            }
            if (this.boredom == 3)
            {
                this.ReturnSpeech("I will seriously put a \n hole in your body...");
                this.convNum = 4;
                this.Ogle = 1;
            }
            if (this.boredom == 4)
            {
                this.ReturnSpeech("Is that your last words?");
                this.convNum = 4;
                this.Ogle = 1;
            }
            if (this.boredom == 5)
            {
                this.convNum = 4;
                this.PissedAtTC1 = 4;
                this.FoundSmall = false;
                this.Ogle = 1;
            }
            this.boredom = this.boredom + 1;
        }
        else
        {
            if (this.boredom == 0)
            {
                this.ReturnSpeech("What is it, citizen?");
            }
            if (this.boredom == 1)
            {
                this.ReturnSpeech("I'm not sure if I can \n help you with that.");
                this.convNum = 1;
            }
            if (this.boredom == 2)
            {
                this.ReturnSpeech("Ok, we're done here.");
                this.convNum = 1;
            }
            if (this.boredom == 3)
            {
                this.ReturnSpeech("Can you go away?");
                this.convNum = 4;
                this.Ogle = 1;
            }
            if (this.boredom == 4)
            {
                this.ReturnSpeech("I'm just going to \n ignore you from now on...");
                this.convNum = 99;
                this.Ogle = 1;
            }
            this.boredom = this.boredom + 1;
        }
    }

    public virtual void ReturnSpeech(string yourText)
    {
        GameObject Load = ((GameObject) Resources.Load("Prefabs/TalkBubble", typeof(GameObject))) as GameObject;
        GameObject TGO = UnityEngine.Object.Instantiate(Load, this.thisTransform.position, Load.transform.rotation);
        TGO.name = "CFC7";
        TalkBubbleScript.myText = yourText;
        ((TalkBubbleScript) TGO.GetComponent(typeof(TalkBubbleScript))).source = this.thisVTransform;
    }

    public MevNavClouterAI()
    {
        this.RightDist = 200;
        this.LeftDist = 200;
        this.AngleThreshold = 2;
        this.ShootFrequency = 3;
        this.Dist3 = 6;
        this.TAimForce = 40;
        this.StoredMissileBatches = 8;
        this.TurnertDist = 100;
    }

}