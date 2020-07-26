using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class TerbotekAI : MonoBehaviour
{
    public Transform target;
    public Transform Waypoint;
    public Transform Station;
    public Transform StationRAP;
    public Transform TargetTrace;
    public Transform TargetLead;
    public Transform TargetLead2;
    public SphereCollider TLCol;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public Transform ResetAimpoint;
    public Transform AIAnchor;
    public GameObject MissileAmmo;
    public Transform MissilePR1;
    public Transform MissilePR2;
    public Transform MissilePL1;
    public Transform MissilePL2;
    public Rigidbody Gun1RB;
    public Rigidbody Gun2RB;
    public Transform Gun1TF;
    public Transform Gun2TF;
    public NPCGun Gun1;
    public NPCGun Gun2;
    public BoxCollider Trig;
    public GameObject WarningSound;
    public GameObject EngageSound;
    public int PissedAtTC0a;
    public int PissedAtTC1;
    public int PissedAtTC2;
    public int PissedAtTC3;
    public int PissedAtTC4;
    public int PissedAtTC6;
    public int PissedAtTC7;
    public int PissedAtTC8;
    public int PissedAtTC9;
    public bool FoundSmall;
    public bool TargetInFront;
    public bool Emergency;
    public bool Patrolling;
    public bool Attacking;
    public bool Obstacle;
    public bool Stuck;
    public int Stuckage;
    public bool TurnRight;
    public bool TurnLeft;
    public float AimForce;
    public float TurnForce;
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
    public LayerMask MtargetLayers;
    public int DangerSense;
    public bool DangerTick;
    public int EngageTime;
    public int Warn;
    public int Spot;
    public int PatrolTime;
    public bool Returning;
    public int TargetDist;
    public bool CanLaunch;
    public int Launching;
    public int LaunchInt;
    public int StoredMissileBatches;
    public virtual void Start()
    {
        this.InvokeRepeating("Regenerator", 1, 1);
        this.InvokeRepeating("LeaveMarker", 1, 3);
        this.InvokeRepeating("Shooty", Random.Range(2, 3), 0.12f);
        this.InvokeRepeating("Launchy", Random.Range(2, 3), 0.3f);
        this.InvokeRepeating("CalcLead", 1, 0.15f);
    }

    public virtual void Update()
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
        if (this.Attacking)
        {
            if (this.target == null)
            {
                this.target = this.ResetAimpoint;
                this.Attacking = false;
                this.Spot = 0;
                this.FoundSmall = false;
            }
            else
            {
                if (this.target.name.Contains("bro"))
                {
                    this.target = this.ResetAimpoint;
                    //Cramped = 0;
                    this.Attacking = false;
                    this.Spot = 0;
                }
            }
        }
        if (this.TurnLeft)
        {
            this.AimForce = 0;
            this.TurnForce = -80;
        }
        if (this.TurnRight)
        {
            this.AimForce = 0;
            this.TurnForce = 80;
        }
        this.localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
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
        float Vel = this.vRigidbody.velocity.magnitude * 2;
        float VelClamp = Mathf.Clamp(Vel, 10, 80);
        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.up * this.RUP), newRot2 * VelClamp, Color.white);
        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.up * this.RUP), newRot2, out hit1, VelClamp, (int) this.targetLayers))
        {
            this.Point1u = hit1.point;
        }
        else
        {
            this.Point1u = new Vector3(2, 2, 2);
        }
        Debug.DrawRay((this.thisTransform.position + (-this.thisTransform.up * 1)) + (this.thisTransform.up * this.RUP), newRot2 * VelClamp, Color.white);
        if (Physics.Raycast((this.thisTransform.position + (-this.thisTransform.up * 1)) + (this.thisTransform.up * this.RUP), newRot2, out hit2, VelClamp, (int) this.targetLayers))
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
        Debug.DrawRay(this.thisTransform.position, this.thisTransform.forward * VelClamp, Color.green);
        if (Physics.Raycast(this.thisTransform.position, this.thisTransform.forward, out hit, VelClamp, (int) this.targetLayers))
        {
            if (this.Wall)
            {
                this.Obstacle = true;
            }
        }
        if (Vel > 2)
        {
            Debug.DrawRay(this.thisTransform.position + (this.thisTransform.right * 5), this.thisTransform.forward * VelClamp, Color.green);
            if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.right * 5), this.thisTransform.forward, out hit, VelClamp, (int) this.targetLayers))
            {
                if (this.RWall)
                {
                    this.Obstacle = true;
                }
            }
            Debug.DrawRay(this.thisTransform.position + (-this.thisTransform.right * 5), this.thisTransform.forward * VelClamp, Color.green);
            if (Physics.Raycast(this.thisTransform.position + (-this.thisTransform.right * 5), this.thisTransform.forward, out hit, VelClamp, (int) this.targetLayers))
            {
                if (this.LWall)
                {
                    this.Obstacle = true;
                }
            }
        }
        newRot2 = ((this.thisTransform.forward * 0.4f) + (this.thisTransform.right * 0.1f)).normalized;
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.right * 6)) + (this.thisTransform.up * this.RRUP), newRot2 * VelClamp, Color.black);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.right * 6)) + (this.thisTransform.up * this.RRUP), newRot2, out hit1, VelClamp, (int) this.targetLayers))
        {
            this.RPoint1u = hit1.point;
        }
        else
        {
            this.RPoint1u = new Vector3(2, 2, 2);
        }
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.right * 6)) + (-this.thisTransform.up * 1)) + (this.thisTransform.up * this.RRUP), newRot2 * VelClamp, Color.black);
        if (Physics.Raycast(((this.thisTransform.position + (this.thisTransform.right * 6)) + (-this.thisTransform.up * 1)) + (this.thisTransform.up * this.RRUP), newRot2, out hit2, VelClamp, (int) this.targetLayers))
        {
            this.RPoint1d = hit2.point;
            this.RightDist = hit2.distance;
        }
        else
        {
            this.RPoint1d = new Vector3(8, 8, 8);
            this.RightDist = 512;
        }
        if (Vector3.Distance(this.RPoint1u, this.RPoint1d) < 3)
        {
            this.RWall = true;
        }
        newRot2 = ((this.thisTransform.forward * 0.4f) + (-this.thisTransform.right * 0.1f)).normalized;
        Debug.DrawRay((this.thisTransform.position + (-this.thisTransform.right * 6)) + (this.thisTransform.up * this.LRUP), newRot2 * VelClamp, Color.black);
        if (Physics.Raycast((this.thisTransform.position + (-this.thisTransform.right * 6)) + (this.thisTransform.up * this.LRUP), newRot2, out hit1, VelClamp, (int) this.targetLayers))
        {
            this.LPoint1u = hit1.point;
        }
        else
        {
            this.LPoint1u = new Vector3(2, 2, 2);
        }
        Debug.DrawRay(((this.thisTransform.position + (-this.thisTransform.right * 6)) + (-this.thisTransform.up * 1)) + (this.thisTransform.up * this.LRUP), newRot2 * VelClamp, Color.black);
        if (Physics.Raycast(((this.thisTransform.position + (-this.thisTransform.right * 6)) + (-this.thisTransform.up * 1)) + (this.thisTransform.up * this.LRUP), newRot2, out hit2, VelClamp, (int) this.targetLayers))
        {
            this.LPoint1d = hit2.point;
            this.LeftDist = hit2.distance;
        }
        else
        {
            this.LPoint1d = new Vector3(8, 8, 8);
            this.LeftDist = 512;
        }
        if (Vector3.Distance(this.LPoint1u, this.LPoint1d) < 3)
        {
            this.LWall = true;
        }
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.up * 5)) + (this.thisTransform.forward * VelClamp), this.thisTransform.up * -20f, Color.white);
        if (!Physics.Raycast((this.thisTransform.position + (this.thisTransform.up * 5)) + (this.thisTransform.forward * VelClamp), -this.thisTransform.up, 20))
        {
            this.Obstacle = true;
        }
        //---------------------------------------------------------------------------------------------
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.up * 10)) + (this.thisTransform.right * 10)) + (this.thisTransform.forward * VelClamp), this.thisTransform.up * -20f, Color.white);
        if (!Physics.Raycast(((this.thisTransform.position + (this.thisTransform.up * 10)) + (this.thisTransform.right * 10)) + (this.thisTransform.forward * VelClamp), -this.thisTransform.up, 20))
        {
            this.TurnLeft = true;
        }
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.up * 10)) + (-this.thisTransform.right * 10)) + (this.thisTransform.forward * VelClamp), this.thisTransform.up * -20f, Color.white);
        if (!Physics.Raycast(((this.thisTransform.position + (this.thisTransform.up * 10)) + (-this.thisTransform.right * 10)) + (this.thisTransform.forward * VelClamp), -this.thisTransform.up, 20))
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
        if (this.Stuck)
        {
            this.TurnRight = true;
        }
    }

    public virtual void FixedUpdate()
    {
        Vector3 localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
        if (this.Obstacle)
        {
            if (-localV.y > 0)
            {
                this.vRigidbody.AddForce(this.thisVTransform.up * 40);
            }
        }
        if (this.target)
        {
            if (this.Attacking)
            {
                if (this.TargetInFront)
                {
                    if (this.TargetDist > 64)
                    {
                        if (-localV.y < 20)
                        {
                            if (!this.Obstacle && !this.Stuck)
                            {
                                this.vRigidbody.AddForce(-this.thisVTransform.up * 10);
                            }
                        }
                        this.vRigidbody.AddTorque(this.thisTransform.up * this.TurnForce);
                    }
                    else
                    {
                        if (!Physics.Linecast(this.thisTransform.position, this.target.position, (int) this.MtargetLayers))
                        {
                            if (this.TargetDist < 16)
                            {
                                if (localV.y < 20)
                                {
                                    if (!this.Stuck)
                                    {
                                        this.vRigidbody.AddForce(this.thisVTransform.up * 10);
                                    }
                                }
                            }
                            this.vRigidbody.AddTorque(this.thisTransform.up * this.TurnForce);
                        }
                        else
                        {
                            if (-localV.y < 10)
                            {
                                if (!this.Obstacle && !this.Stuck)
                                {
                                    this.vRigidbody.AddForce(-this.thisVTransform.up * 10);
                                }
                            }
                            this.vRigidbody.AddTorque(this.thisTransform.up * this.TurnForce);
                        }
                    }
                    if (!this.Stuck)
                    {
                        this.vRigidbody.AddForce((this.thisVTransform.right * this.TurnForce) * 0.15f);
                    }
                    this.vRigidbody.AddTorque((-this.thisVTransform.right * this.TargetDist) * 0.007f);
                }
                else
                {
                    if (this.TargetDist < 128)
                    {
                        if (localV.y < 20)
                        {
                            this.vRigidbody.AddForce(this.thisVTransform.up * 10);
                        }
                        this.vRigidbody.AddTorque(this.thisTransform.up * this.TurnForce);
                    }
                    else
                    {
                        if (-localV.y < 20)
                        {
                            if (!this.Obstacle && !this.Stuck)
                            {
                                this.vRigidbody.AddForce(-this.thisVTransform.up * 10);
                            }
                        }
                        this.vRigidbody.AddTorque(this.thisTransform.up * this.TurnForce);
                    }
                }
            }
        }
        if (((this.Spot > 0) && !this.Obstacle) && !this.Attacking)
        {
            if (-localV.y > 0)
            {
                this.vRigidbody.AddForce(this.thisVTransform.up * 10);
            }
        }
        if (this.Patrolling)
        {
            if (((((!this.Attacking && !this.Obstacle) && (this.Spot < 1)) && !this.Stuck) && !this.TurnLeft) && !this.TurnRight)
            {
                if (-localV.y < 10)
                {
                    this.vRigidbody.AddForce(-this.thisVTransform.up * 10);
                }
            }
            if (this.Stuck)
            {
                if (localV.y < 4)
                {
                    this.vRigidbody.AddForce(this.thisVTransform.up * 10);
                }
            }
            this.vRigidbody.AddTorque(this.thisTransform.up * this.TurnForce);
        }
        else
        {
            if (!this.Attacking && (this.Spot < 1))
            {
                if (!this.Returning)
                {
                    this.vRigidbody.AddForce((this.Station.position - this.thisTransform.position).normalized * 1);
                    if (-localV.y > 0)
                    {
                        this.vRigidbody.AddForce(this.thisVTransform.up * 10);
                    }
                }
                else
                {
                    this.vRigidbody.AddTorque(this.thisTransform.up * this.TurnForce);
                    if (((!this.Obstacle && !this.Stuck) && !this.TurnLeft) && !this.TurnRight)
                    {
                        if (-localV.y < 10)
                        {
                            this.vRigidbody.AddForce(-this.thisVTransform.up * 10);
                        }
                    }
                }
            }
        }
        if (this.target)
        {
            if (this.Attacking)
            {
                this.Gun1RB.AddForceAtPosition((this.TargetLead.position - this.Gun1TF.position).normalized * 0.05f, -this.Gun1TF.up * 2);
                this.Gun1RB.AddForceAtPosition((this.TargetLead.position - this.Gun1TF.position).normalized * -0.05f, this.Gun1TF.up * 2);
                this.Gun2RB.AddForceAtPosition((this.TargetLead.position - this.Gun2TF.position).normalized * 0.05f, -this.Gun2TF.up * 2);
                this.Gun2RB.AddForceAtPosition((this.TargetLead.position - this.Gun2TF.position).normalized * -0.05f, this.Gun2TF.up * 2);
                if (this.TargetDist > 64)
                {
                    this.vRigidbody.AddForceAtPosition((this.TargetLead2.position - this.thisTransform.position).normalized * this.AimForce, this.thisTransform.forward * 2);
                    this.vRigidbody.AddForceAtPosition((this.TargetLead2.position - this.thisTransform.position).normalized * -this.AimForce, -this.thisTransform.forward * 2);
                }
                else
                {
                    this.vRigidbody.AddForceAtPosition((this.target.position - this.thisTransform.position).normalized * this.AimForce, this.thisTransform.forward * 2);
                    this.vRigidbody.AddForceAtPosition((this.target.position - this.thisTransform.position).normalized * -this.AimForce, -this.thisTransform.forward * 2);
                }
            }
            else
            {
                this.Gun1RB.AddForceAtPosition((this.ResetAimpoint.position - this.Gun1TF.position).normalized * 0.05f, -this.Gun1TF.up * 2);
                this.Gun1RB.AddForceAtPosition((this.ResetAimpoint.position - this.Gun1TF.position).normalized * -0.05f, this.Gun1TF.up * 2);
                this.Gun2RB.AddForceAtPosition((this.ResetAimpoint.position - this.Gun2TF.position).normalized * 0.05f, -this.Gun2TF.up * 2);
                this.Gun2RB.AddForceAtPosition((this.ResetAimpoint.position - this.Gun2TF.position).normalized * -0.05f, this.Gun2TF.up * 2);
                this.vRigidbody.AddForceAtPosition((this.target.position - this.thisTransform.position).normalized * this.AimForce, this.thisTransform.forward * 2);
                this.vRigidbody.AddForceAtPosition((this.target.position - this.thisTransform.position).normalized * -this.AimForce, -this.thisTransform.forward * 2);
            }
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        Transform OTF1 = other.transform;
        string ON1 = other.name;
        if ((this.Warn < 1) && !this.Attacking)
        {
            if (!Physics.Linecast(this.thisTransform.position, OTF1.position, (int) this.MtargetLayers))
            {
                if (ON1.Contains("TC"))
                {
                    if (!ON1.Contains("TC5"))
                    {
                        this.Spot = 8;
                        this.target = OTF1;
                    }
                }
            }
        }
        if (ON1.Contains("TFC"))
        {
            if (!ON1.Contains("TFC5"))
            {
                if (ON1.Contains("TFC0a"))
                {
                    if (this.PissedAtTC0a < 8)
                    {
                        this.PissedAtTC0a = this.PissedAtTC0a + 4;
                    }
                    if (this.PissedAtTC1 > 0)
                    {
                        this.PissedAtTC1 = this.PissedAtTC1 - 4;
                    }
                    if (this.PissedAtTC3 > 0)
                    {
                        this.PissedAtTC3 = this.PissedAtTC3 - 4;
                    }
                    if (this.PissedAtTC4 > 0)
                    {
                        this.PissedAtTC4 = this.PissedAtTC4 - 4;
                    }
                    if (this.PissedAtTC7 > 0)
                    {
                        this.PissedAtTC7 = this.PissedAtTC7 - 4;
                    }
                    if (this.PissedAtTC8 > 0)
                    {
                        this.PissedAtTC8 = this.PissedAtTC8 - 4;
                    }
                    if (this.PissedAtTC9 > 0)
                    {
                        this.PissedAtTC9 = this.PissedAtTC9 - 4;
                    }
                }
                if (ON1.Contains("TFC1"))
                {
                    if (this.PissedAtTC1 < 8)
                    {
                        this.PissedAtTC1 = this.PissedAtTC1 + 4;
                    }
                    if (this.PissedAtTC0a > 0)
                    {
                        this.PissedAtTC0a = this.PissedAtTC0a - 4;
                    }
                    if (this.PissedAtTC3 > 0)
                    {
                        this.PissedAtTC3 = this.PissedAtTC3 - 4;
                    }
                    if (this.PissedAtTC4 > 0)
                    {
                        this.PissedAtTC4 = this.PissedAtTC4 - 4;
                    }
                    if (this.PissedAtTC7 > 0)
                    {
                        this.PissedAtTC7 = this.PissedAtTC7 - 4;
                    }
                    if (this.PissedAtTC8 > 0)
                    {
                        this.PissedAtTC8 = this.PissedAtTC8 - 4;
                    }
                    if (this.PissedAtTC9 > 0)
                    {
                        this.PissedAtTC9 = this.PissedAtTC9 - 4;
                    }
                }
                if (ON1.Contains("TFC3"))
                {
                    if (this.PissedAtTC3 < 8)
                    {
                        this.PissedAtTC3 = this.PissedAtTC3 + 4;
                    }
                    if (this.PissedAtTC0a > 0)
                    {
                        this.PissedAtTC0a = this.PissedAtTC0a - 4;
                    }
                    if (this.PissedAtTC1 > 0)
                    {
                        this.PissedAtTC1 = this.PissedAtTC1 - 4;
                    }
                    if (this.PissedAtTC4 > 0)
                    {
                        this.PissedAtTC4 = this.PissedAtTC4 - 4;
                    }
                    if (this.PissedAtTC7 > 0)
                    {
                        this.PissedAtTC7 = this.PissedAtTC7 - 4;
                    }
                    if (this.PissedAtTC8 > 0)
                    {
                        this.PissedAtTC8 = this.PissedAtTC8 - 4;
                    }
                    if (this.PissedAtTC9 > 0)
                    {
                        this.PissedAtTC9 = this.PissedAtTC9 - 4;
                    }
                }
                if (ON1.Contains("TFC4"))
                {
                    if (this.PissedAtTC4 < 8)
                    {
                        this.PissedAtTC4 = this.PissedAtTC4 + 4;
                    }
                    if (this.PissedAtTC0a > 0)
                    {
                        this.PissedAtTC0a = this.PissedAtTC0a - 4;
                    }
                    if (this.PissedAtTC1 > 0)
                    {
                        this.PissedAtTC1 = this.PissedAtTC1 - 4;
                    }
                    if (this.PissedAtTC3 > 0)
                    {
                        this.PissedAtTC3 = this.PissedAtTC3 - 4;
                    }
                    if (this.PissedAtTC7 > 0)
                    {
                        this.PissedAtTC7 = this.PissedAtTC7 - 4;
                    }
                    if (this.PissedAtTC8 > 0)
                    {
                        this.PissedAtTC8 = this.PissedAtTC8 - 4;
                    }
                    if (this.PissedAtTC9 > 0)
                    {
                        this.PissedAtTC9 = this.PissedAtTC9 - 4;
                    }
                }
                if (ON1.Contains("TFC7"))
                {
                    if (this.PissedAtTC7 < 8)
                    {
                        this.PissedAtTC7 = this.PissedAtTC7 + 4;
                    }
                    if (this.PissedAtTC0a > 0)
                    {
                        this.PissedAtTC0a = this.PissedAtTC0a - 4;
                    }
                    if (this.PissedAtTC1 > 0)
                    {
                        this.PissedAtTC1 = this.PissedAtTC1 - 4;
                    }
                    if (this.PissedAtTC3 > 0)
                    {
                        this.PissedAtTC3 = this.PissedAtTC3 - 4;
                    }
                    if (this.PissedAtTC4 > 0)
                    {
                        this.PissedAtTC4 = this.PissedAtTC4 - 4;
                    }
                    if (this.PissedAtTC8 > 0)
                    {
                        this.PissedAtTC8 = this.PissedAtTC8 - 4;
                    }
                    if (this.PissedAtTC9 > 0)
                    {
                        this.PissedAtTC9 = this.PissedAtTC9 - 4;
                    }
                }
                if (ON1.Contains("TFC8"))
                {
                    if (this.PissedAtTC8 < 8)
                    {
                        this.PissedAtTC8 = this.PissedAtTC8 + 4;
                    }
                    if (this.PissedAtTC0a > 0)
                    {
                        this.PissedAtTC0a = this.PissedAtTC0a - 4;
                    }
                    if (this.PissedAtTC1 > 0)
                    {
                        this.PissedAtTC1 = this.PissedAtTC1 - 4;
                    }
                    if (this.PissedAtTC3 > 0)
                    {
                        this.PissedAtTC3 = this.PissedAtTC3 - 4;
                    }
                    if (this.PissedAtTC4 > 0)
                    {
                        this.PissedAtTC4 = this.PissedAtTC4 - 4;
                    }
                    if (this.PissedAtTC7 > 0)
                    {
                        this.PissedAtTC7 = this.PissedAtTC7 - 4;
                    }
                    if (this.PissedAtTC9 > 0)
                    {
                        this.PissedAtTC9 = this.PissedAtTC9 - 4;
                    }
                }
                if (ON1.Contains("TFC9"))
                {
                    if (this.PissedAtTC9 < 8)
                    {
                        this.PissedAtTC9 = this.PissedAtTC9 + 4;
                    }
                    if (this.PissedAtTC0a > 0)
                    {
                        this.PissedAtTC0a = this.PissedAtTC0a - 4;
                    }
                    if (this.PissedAtTC1 > 0)
                    {
                        this.PissedAtTC1 = this.PissedAtTC1 - 4;
                    }
                    if (this.PissedAtTC3 > 0)
                    {
                        this.PissedAtTC3 = this.PissedAtTC3 - 4;
                    }
                    if (this.PissedAtTC4 > 0)
                    {
                        this.PissedAtTC4 = this.PissedAtTC4 - 4;
                    }
                    if (this.PissedAtTC7 > 0)
                    {
                        this.PissedAtTC7 = this.PissedAtTC7 - 4;
                    }
                    if (this.PissedAtTC8 > 0)
                    {
                        this.PissedAtTC8 = this.PissedAtTC8 - 4;
                    }
                }
                if (!this.Attacking)
                {
                    this.DangerSense = 10;
                    this.target = this.Waypoint;
                    if (OTF1.GetComponent<Rigidbody>())
                    {
                        this.Waypoint.position = OTF1.position;
                    }
                }
            }
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Collider>().name.Contains("TC"))
        {
            if (!other.GetComponent<Collider>().name.Contains("TC5"))
            {
                Transform OTF = other.transform;
                string ON = other.name;
                if (Vector3.Distance(this.thisTransform.position, OTF.position) < 48)
                {
                    if (!ON.Contains("TC2"))
                    {
                        if (!Physics.Linecast(this.thisTransform.position, OTF.position, (int) this.MtargetLayers))
                        {
                            if ((this.Warn < 1) && !this.Attacking)
                            {
                                this.Spot = 6;
                                this.Warn = 6;
                                this.target = OTF;
                                this.WarningNoise();
                                if (ON.Contains("TC0a"))
                                {
                                    this.PissedAtTC0a = this.PissedAtTC0a + 1;
                                }
                                if (ON.Contains("TC1"))
                                {
                                    this.PissedAtTC1 = this.PissedAtTC1 + 1;
                                }
                                if (ON.Contains("TC3"))
                                {
                                    this.PissedAtTC3 = this.PissedAtTC3 + 1;
                                }
                                if (ON.Contains("TC4"))
                                {
                                    this.PissedAtTC4 = this.PissedAtTC4 + 1;
                                }
                                if (ON.Contains("TC6"))
                                {
                                    this.PissedAtTC6 = this.PissedAtTC6 + 1;
                                }
                                if (ON.Contains("TC7"))
                                {
                                    this.PissedAtTC7 = this.PissedAtTC7 + 1;
                                }
                                if (ON.Contains("TC8"))
                                {
                                    this.PissedAtTC8 = this.PissedAtTC8 + 1;
                                }
                                if (ON.Contains("TC9"))
                                {
                                    this.PissedAtTC9 = this.PissedAtTC9 + 1;
                                }
                            }
                            if (Vector3.Distance(this.thisTransform.position, OTF.position) < 32)
                            {
                                if (this.Warn < 2)
                                {
                                    this.Spot = 0;
                                    this.target = OTF;
                                    if (!this.Attacking)
                                    {
                                        this.AttackNoise();
                                    }
                                    this.Patrolling = false;
                                    this.Attacking = true;
                                }
                            }
                        }
                    }
                }
                if (ON.Contains("TC0a"))
                {
                    if (this.PissedAtTC0a > 4)
                    {
                        if ((ON.Contains("sT") && !this.FoundSmall) || !ON.Contains("sT"))
                        {
                            this.Spot = 0;
                            this.target = OTF;
                            if (!this.Attacking)
                            {
                                this.AttackNoise();
                            }
                            this.Patrolling = false;
                            this.Attacking = true;
                        }
                    }
                }
                if (ON.Contains("TC1"))
                {
                    if (this.PissedAtTC1 > 4)
                    {
                        if ((ON.Contains("sT") && !this.FoundSmall) || !ON.Contains("sT"))
                        {
                            this.Spot = 0;
                            this.target = OTF;
                            if (!this.Attacking)
                            {
                                this.AttackNoise();
                            }
                            this.Patrolling = false;
                            this.Attacking = true;
                        }
                    }
                }
                if (!ON.Contains("cT"))
                {
                    if (ON.Contains("TC3"))
                    {
                        if (this.PissedAtTC3 > 4)
                        {
                            if ((ON.Contains("sT") && !this.FoundSmall) || !ON.Contains("sT"))
                            {
                                this.Spot = 0;
                                this.target = OTF;
                                if (!this.Attacking)
                                {
                                    this.AttackNoise();
                                }
                                this.Patrolling = false;
                                this.Attacking = true;
                            }
                        }
                    }
                }
                if (ON.Contains("TC4"))
                {
                    if (this.PissedAtTC4 > 4)
                    {
                        if ((ON.Contains("sT") && !this.FoundSmall) || !ON.Contains("sT"))
                        {
                            this.Spot = 0;
                            this.target = OTF;
                            if (!this.Attacking)
                            {
                                this.AttackNoise();
                            }
                            this.Patrolling = false;
                            this.Attacking = true;
                        }
                    }
                }
                if (!ON.Contains("cT"))
                {
                    if (ON.Contains("TC7"))
                    {
                        if (this.PissedAtTC7 > 4)
                        {
                            if ((ON.Contains("sT") && !this.FoundSmall) || !ON.Contains("sT"))
                            {
                                this.Spot = 0;
                                this.target = OTF;
                                if (!this.Attacking)
                                {
                                    this.AttackNoise();
                                }
                                this.Patrolling = false;
                                this.Attacking = true;
                            }
                        }
                    }
                }
                if (!ON.Contains("cT"))
                {
                    if (ON.Contains("TC8"))
                    {
                        if (this.PissedAtTC8 > 4)
                        {
                            if ((ON.Contains("sT") && !this.FoundSmall) || !ON.Contains("sT"))
                            {
                                this.Spot = 0;
                                this.target = OTF;
                                if (!this.Attacking)
                                {
                                    this.AttackNoise();
                                }
                                this.Patrolling = false;
                                this.Attacking = true;
                            }
                        }
                    }
                }
                if (!ON.Contains("cT"))
                {
                    if (ON.Contains("TC9"))
                    {
                        if (this.PissedAtTC9 > 4)
                        {
                            if ((ON.Contains("sT") && !this.FoundSmall) || !ON.Contains("sT"))
                            {
                                this.Spot = 0;
                                this.target = OTF;
                                if (!this.Attacking)
                                {
                                    this.AttackNoise();
                                }
                                this.Patrolling = false;
                                this.Attacking = true;
                            }
                        }
                    }
                }
                if (!ON.Contains("cT"))
                {
                    if (ON.Contains("TC6"))
                    {
                        if (this.PissedAtTC6 > 4)
                        {
                            if ((ON.Contains("sT") && !this.FoundSmall) || !ON.Contains("sT"))
                            {
                                this.Spot = 0;
                                this.target = OTF;
                                if (!this.Attacking)
                                {
                                    this.AttackNoise();
                                }
                                this.Patrolling = false;
                                this.Attacking = true;
                            }
                        }
                        else
                        {
                            if (!ON.Contains("csT"))
                            {
                                this.Spot = 0;
                                this.target = OTF;
                                if (!this.Attacking)
                                {
                                    this.AttackNoise();
                                }
                                this.Patrolling = false;
                                this.Attacking = true;
                            }
                        }
                    }
                }
            }
        }
    }

    public virtual void AttackNoise()
    {
        GameObject TheThing = UnityEngine.Object.Instantiate(this.EngageSound, this.thisTransform.position, this.thisTransform.rotation);
        TheThing.transform.parent = this.thisTransform;
    }

    public virtual void WarningNoise()
    {
        GameObject TheThing1 = UnityEngine.Object.Instantiate(this.WarningSound, this.thisTransform.position, this.thisTransform.rotation);
        TheThing1.transform.parent = this.thisTransform;
    }

    public virtual void Shooty()
    {
        if (this.Attacking && (this.EngageTime < 1))
        {
            this.StartCoroutine(this.Shoot());
        }
    }

    public virtual IEnumerator Shoot()
    {
        if (this.Gun1)
        {
            this.Gun1.Fire();
        }
        yield return new WaitForSeconds(0.06f);
        if (this.Gun2)
        {
            this.Gun2.Fire();
        }
    }

    public virtual void Launchy()
    {
        RaycastHit hitL = default(RaycastHit);
        Vector3 TargetRelCalc = this.thisTransform.InverseTransformPoint(this.TargetLead2.position);
        float RorL = Mathf.Abs(TargetRelCalc.x);
        float ForB = TargetRelCalc.z;
        if (ForB > 0)
        {
            this.TargetInFront = true;
        }
        else
        {
            this.TargetInFront = false;
        }
        if (this.target)
        {
            if (this.target.name.Contains("bTC") || this.Emergency)
            {
                if ((this.Attacking && this.CanLaunch) && (this.EngageTime < 1))
                {
                    float DistMod = RorL / Vector3.Distance(this.thisTransform.position, this.TargetLead2.position);
                    if ((DistMod < 0.2f) && this.TargetInFront)
                    {
                        Debug.DrawRay(this.thisTransform.position, this.thisTransform.forward * this.TargetDist, Color.yellow);
                        if (!Physics.Raycast(this.thisTransform.position, this.thisTransform.forward, out hitL, this.TargetDist, (int) this.targetLayers))
                        {
                            this.StartCoroutine(this.Launch());
                        }
                        else
                        {
                            if (hitL.collider.tag.Contains("Vehicle") || hitL.collider.tag.Contains("Metal"))
                            {
                                if (!hitL.collider.name.Contains("5"))
                                {
                                    this.StartCoroutine(this.Launch());
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public virtual IEnumerator Launch()
    {
        if (this.target != null)
        {
            if (this.Attacking && (this.StoredMissileBatches > 0))
            {
                GameObject _SpawnedObject1 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.MissilePR2.position, this.MissilePR2.rotation);
                _SpawnedObject1.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;

                {
                    float _3650 = this.MissilePR2.localPosition.x + 0.1f;
                    Vector3 _3651 = this.MissilePR2.localPosition;
                    _3651.x = _3650;
                    this.MissilePR2.localPosition = _3651;
                }
                yield return new WaitForSeconds(0.15f);
                GameObject _SpawnedObject2 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.MissilePL2.position, this.MissilePL2.rotation);
                _SpawnedObject2.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;

                {
                    float _3652 = this.MissilePL2.localPosition.x - 0.1f;
                    Vector3 _3653 = this.MissilePL2.localPosition;
                    _3653.x = _3652;
                    this.MissilePL2.localPosition = _3653;
                }
                this.LaunchInt = this.LaunchInt + 1;
                if (this.LaunchInt > 15)
                {

                    {
                        int _3654 = 0;
                        Vector3 _3655 = this.MissilePR2.localPosition;
                        _3655.x = _3654;
                        this.MissilePR2.localPosition = _3655;
                    }

                    {
                        int _3656 = 0;
                        Vector3 _3657 = this.MissilePL2.localPosition;
                        _3657.x = _3656;
                        this.MissilePL2.localPosition = _3657;
                    }
                    this.StoredMissileBatches = this.StoredMissileBatches - 1;
                    this.CanLaunch = false;
                    this.LaunchInt = 0;
                    this.Launching = 8;
                }
            }
        }
    }

    public virtual void LeaveMarker()
    {
        Vector3 lastPos = this.thisTransform.position;
        this.StartCoroutine(this.IsEscaping(lastPos));
    }

    public virtual IEnumerator IsEscaping(Vector3 lastPos)
    {
        yield return new WaitForSeconds(2);
        if (this.Stuckage > 1)
        {
            this.Stuckage = 0;
            this.Stuck = false;
        }
        if (this.Attacking)
        {
            if (Vector3.Distance(this.thisTransform.position, lastPos) < 3)
            {
                if (Physics.Linecast(this.thisTransform.position, this.target.position, (int) this.MtargetLayers))
                {
                    this.Stuckage = this.Stuckage + 1;
                    if (this.Stuckage > 1)
                    {
                        this.Stuck = true;
                    }
                    else
                    {
                        this.Stuck = false;
                    }
                }
                else
                {
                    this.Stuckage = 0;
                    this.Stuck = false;
                }
            }
            else
            {
                this.Stuckage = 0;
                this.Stuck = false;
            }
        }
        else
        {
            if (((this.Spot < 1) && this.Patrolling) && !this.Returning)
            {
                if (Vector3.Distance(this.thisTransform.position, lastPos) < 3)
                {
                    this.Stuckage = this.Stuckage + 1;
                    if (this.Stuckage > 1)
                    {
                        this.Stuck = true;
                    }
                    else
                    {
                        this.Stuck = false;
                    }
                }
                else
                {
                    this.Stuckage = 0;
                    this.Stuck = false;
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
            this.TargetTrace.LookAt(this.target);
            this.TargetLead.position = this.TargetTrace.position;
            this.TargetLead.rotation = this.TargetTrace.rotation;
            this.TargetLead2.position = this.TargetTrace.position;
            this.TargetLead2.rotation = this.TargetTrace.rotation;
            this.TargetLead.position = this.TargetLead.position + (((this.TargetLead.forward * Dist1) * Dist2) * 0.025f);
            this.TargetLead2.position = this.TargetLead2.position + (((this.TargetLead2.forward * Dist1) * Dist2) * 0.1f);
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
        if (this.Spot < 1)
        {
            if (this.PissedAtTC0a > 1)
            {
                this.PissedAtTC0a = this.PissedAtTC0a - 1;
            }
            if (this.PissedAtTC1 > 1)
            {
                this.PissedAtTC1 = this.PissedAtTC1 - 1;
            }
            if (this.PissedAtTC3 > 1)
            {
                this.PissedAtTC3 = this.PissedAtTC3 - 1;
            }
            if (this.PissedAtTC4 > 1)
            {
                this.PissedAtTC4 = this.PissedAtTC4 - 1;
            }
            if (this.PissedAtTC6 > 1)
            {
                this.PissedAtTC6 = this.PissedAtTC6 - 1;
            }
            if (this.PissedAtTC7 > 1)
            {
                this.PissedAtTC7 = this.PissedAtTC7 - 1;
            }
            if (this.PissedAtTC8 > 1)
            {
                this.PissedAtTC8 = this.PissedAtTC8 - 1;
            }
            if (this.PissedAtTC9 > 1)
            {
                this.PissedAtTC9 = this.PissedAtTC9 - 1;
            }
        }
        if (this.PissedAtTC0a < 1)
        {
            this.PissedAtTC0a = SlavuicNetwork.TC0aDeathRow;
        }
        if (this.PissedAtTC1 < 1)
        {
            this.PissedAtTC1 = SlavuicNetwork.TC1DeathRow;
        }
        if (this.PissedAtTC4 < 1)
        {
            this.PissedAtTC4 = SlavuicNetwork.TC4DeathRow;
        }
        if (this.PissedAtTC6 < 1)
        {
            this.PissedAtTC6 = SlavuicNetwork.TC6DeathRow;
        }
        if (this.PissedAtTC7 < 1)
        {
            this.PissedAtTC7 = SlavuicNetwork.TC7DeathRow;
        }
        if (this.PissedAtTC8 < 1)
        {
            this.PissedAtTC8 = SlavuicNetwork.TC8DeathRow;
        }
        if (this.PissedAtTC9 < 1)
        {
            this.PissedAtTC9 = SlavuicNetwork.TC9DeathRow;
        }
        if (this.target)
        {
            this.TargetDist = (int) Vector3.Distance(this.thisTransform.position, this.target.position);
            if (this.Attacking)
            {
                if (!this.target.name.Contains("TC"))
                {
                    this.target = this.ResetAimpoint;
                    this.Attacking = false;
                    this.Spot = 0;
                    this.FoundSmall = false;
                }
                if (this.target.name.Contains("sT"))
                {
                    this.FoundSmall = true;
                }
            }
            else
            {
                this.FoundSmall = false;
            }
        }
        if (this.Attacking)
        {
            this.Trig.size = new Vector3(128, 40, 128);
            if (this.EngageTime > 0)
            {
                this.EngageTime = this.EngageTime - 1;
            }
        }
        else
        {
            this.Trig.size = new Vector3(330, 40, 330);
            this.EngageTime = 2;
        }
        if (this.DangerSense > 0)
        {
            if ((this.DangerSense < 2) && !this.Attacking)
            {
                this.target = this.ResetAimpoint;
            }
            this.DangerSense = this.DangerSense - 1;
        }
        if (this.Warn > 0)
        {
            this.Warn = this.Warn - 1;
        }
        if (this.Spot > 0)
        {
            this.Spot = this.Spot - 1;
        }
        if (this.Launching < 9)
        {
            this.Launching = this.Launching - 1;
        }
        if (this.Launching < 1)
        {
            this.CanLaunch = true;
            this.Launching = 9;
        }
        if (!this.Attacking)
        {
            if (this.Patrolling)
            {
                if (this.PatrolTime < 1)
                {
                    this.PatrolTime = 160;
                    this.Patrolling = false;
                }
                this.Returning = false;
                if (this.Spot < 1)
                {
                    if (Vector3.Distance(this.thisTransform.position, this.Station.position) > 100)
                    {
                        this.target = this.StationRAP;
                    }
                    else
                    {
                        this.target = this.ResetAimpoint;
                    }
                    this.PatrolTime = this.PatrolTime - Random.Range(1, 3);
                }
            }
            else
            {
                if (this.Spot < 1)
                {
                    if (Vector3.Distance(this.thisTransform.position, this.Station.position) < 13)
                    {
                        this.Returning = false;
                        this.target = this.StationRAP;
                    }
                    else
                    {
                        this.Returning = true;
                        this.target = this.StationRAP;
                    }
                    this.PatrolTime = this.PatrolTime - Random.Range(1, 3);
                }
                if (this.PatrolTime < 1)
                {
                    this.PatrolTime = 160;
                    this.Patrolling = true;
                }
            }
        }
        else
        {
            this.Returning = false;
        }
        this.AimForce = 50;
        this.TurnForce = 0;
        this.Wall = false;
        this.RWall = false;
        this.LWall = false;
        this.TurnRight = false;
        this.TurnLeft = false;
        this.StartCoroutine(this.Notice());
    }

    public virtual IEnumerator Notice()
    {
        if ((this.target != null) && this.Attacking)
        {
            Vector3 lastTPos = this.target.transform.position;
        }
        if (this.DangerSense > 0)
        {
            this.DangerTick = true;
            this.thisTransform.LookAt(this.Waypoint);
            yield return new WaitForSeconds(0.1f);
            this.DangerTick = false;
        }
    }

    public TerbotekAI()
    {
        this.RightDist = 200;
        this.LeftDist = 200;
        this.StoredMissileBatches = 8;
    }

}