using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PhobosAI : MonoBehaviour
{
    public Transform target;
    public Transform Waypoint;
    public Transform Station;
    public Transform StationRAP;
    public Transform StationPath0;
    public Transform StationPath1;
    public Transform StationPath2;
    public Transform StationPath3;
    public Transform StationPath4;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public Transform ResetAimpoint;
    public Transform AIAnchor;
    public Transform Cap;
    public bool CapDown;
    public TurretAI Turret;
    public TurretAI SecondTurret;
    public BoxCollider Trig;
    public GameObject WarningSound;
    public GameObject EngageSound;
    public int PissedAtTC0a;
    public int PissedAtTC1;
    public int PissedAtTC2;
    public int PissedAtTC3;
    public int PissedAtTC4;
    public int PissedAtTC5;
    public int PissedAtTC7;
    public int PissedAtTC8;
    public int PissedAtTC9;
    public bool FoundBigger;
    public bool Emergency;
    public bool freeRoam;
    public bool Patrolling;
    public bool Attacking;
    public bool Obstacle;
    public bool Stuck;
    public int Stuckage;
    public int PathNum;
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
    public int PatrolTime;
    public bool Returning;
    public int TargetDist;
    public virtual void Start()
    {
        this.InvokeRepeating("Shooty", 0.3f, 0.3f);
        this.InvokeRepeating("Regenerator", 1, 1);
        this.InvokeRepeating("LeaveMarker", 1, 3);
        if (AbiaSyndicateNetwork.instance.BasePath0)
        {
            this.StationPath0 = AbiaSyndicateNetwork.instance.BasePath0;
            this.StationPath1 = AbiaSyndicateNetwork.instance.BasePath1;
            this.StationPath2 = AbiaSyndicateNetwork.instance.BasePath2;
            this.StationPath3 = AbiaSyndicateNetwork.instance.BasePath3;
            this.StationPath4 = AbiaSyndicateNetwork.instance.BasePath4;
        }
        else
        {
            this.freeRoam = true;
            this.PathNum = 8;
        }
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
                this.FoundBigger = false;
            }
            else
            {
                if (this.target.name.Contains("bro"))
                {
                    this.target = this.ResetAimpoint;
                    //Cramped = 0;
                    this.Attacking = false;
                }
            }
        }
        if (((this.Warn < 1) && (this.DangerSense < 1)) && !this.freeRoam)
        {
            if (this.Patrolling && !this.Attacking)
            {
                if (this.PathNum == 0)
                {
                    if (Vector3.Distance(this.thisTransform.position, this.StationPath0.position) > 16)
                    {
                        this.target = this.StationPath0;
                    }
                    else
                    {
                        this.PathNum = 1;
                    }
                }
                if (this.PathNum == 1)
                {
                    if (Vector3.Distance(this.thisTransform.position, this.StationPath1.position) > 16)
                    {
                        this.target = this.StationPath1;
                    }
                    else
                    {
                        this.PathNum = 2;
                    }
                }
                if (this.PathNum == 2)
                {
                    if (Vector3.Distance(this.thisTransform.position, this.StationPath2.position) > 16)
                    {
                        this.target = this.StationPath2;
                    }
                    else
                    {
                        this.PathNum = 3;
                    }
                }
                if (this.PathNum == 3)
                {
                    if (Vector3.Distance(this.thisTransform.position, this.StationPath3.position) > 16)
                    {
                        this.target = this.StationPath3;
                    }
                    else
                    {
                        this.PathNum = 4;
                    }
                }
                if (this.PathNum == 4)
                {
                    if (Vector3.Distance(this.thisTransform.position, this.StationPath4.position) > 16)
                    {
                        this.target = this.StationPath4;
                    }
                    else
                    {
                        this.PathNum = 0;
                        this.PatrolTime = 160;
                        this.Patrolling = false;
                    }
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
        float Vel = this.vRigidbody.velocity.magnitude * 4;
        float VelClamp = Mathf.Clamp(Vel, 40, 80);
        Debug.DrawRay((this.thisTransform.position + (-this.thisTransform.up * 22)) + (this.thisTransform.up * this.RUP), newRot2 * VelClamp, Color.white);
        if (Physics.Raycast((this.thisTransform.position + (-this.thisTransform.up * 22)) + (this.thisTransform.up * this.RUP), newRot2, out hit1, VelClamp, (int) this.targetLayers))
        {
            this.Point1u = hit1.point;
        }
        else
        {
            this.Point1u = new Vector3(2, 2, 2);
        }
        Debug.DrawRay((this.thisTransform.position + (-this.thisTransform.up * 23)) + (this.thisTransform.up * this.RUP), newRot2 * VelClamp, Color.white);
        if (Physics.Raycast((this.thisTransform.position + (-this.thisTransform.up * 23)) + (this.thisTransform.up * this.RUP), newRot2, out hit2, VelClamp, (int) this.targetLayers))
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
        if (Vel > 0)
        {
            Debug.DrawRay(this.thisTransform.position + (-this.thisTransform.up * 23), this.thisTransform.forward * VelClamp, Color.green);
            if (Physics.Raycast(this.thisTransform.position + (-this.thisTransform.up * 23), this.thisTransform.forward, out hit, VelClamp, (int) this.targetLayers))
            {
                if (this.Wall)
                {
                    this.Obstacle = true;
                }
            }
        }
        else
        {
            Debug.DrawRay(this.thisTransform.position + (-this.thisTransform.up * 23), -this.thisTransform.forward * VelClamp, Color.green);
            if (Physics.Raycast(this.thisTransform.position + (-this.thisTransform.up * 23), -this.thisTransform.forward, out hit, VelClamp, (int) this.targetLayers))
            {
                if (this.Wall)
                {
                    this.Obstacle = true;
                }
            }
        }
        if (Vel > 2)
        {
            Debug.DrawRay((this.thisTransform.position + (this.thisTransform.right * 5)) + (-this.thisTransform.up * 23), this.thisTransform.forward * VelClamp, Color.green);
            if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.right * 5)) + (-this.thisTransform.up * 23), this.thisTransform.forward, out hit, VelClamp, (int) this.targetLayers))
            {
                if (this.RWall)
                {
                    this.Obstacle = true;
                }
            }
            Debug.DrawRay((this.thisTransform.position + (-this.thisTransform.right * 5)) + (-this.thisTransform.up * 23), this.thisTransform.forward * VelClamp, Color.green);
            if (Physics.Raycast((this.thisTransform.position + (-this.thisTransform.right * 5)) + (-this.thisTransform.up * 23), this.thisTransform.forward, out hit, VelClamp, (int) this.targetLayers))
            {
                if (this.LWall)
                {
                    this.Obstacle = true;
                }
            }
        }
        newRot2 = ((this.thisTransform.forward * 0.4f) + (this.thisTransform.right * 0.1f)).normalized;
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.right * 6)) + (-this.thisTransform.up * 22)) + (this.thisTransform.up * this.RRUP), newRot2 * VelClamp, Color.black);
        if (Physics.Raycast(((this.thisTransform.position + (this.thisTransform.right * 6)) + (-this.thisTransform.up * 22)) + (this.thisTransform.up * this.RRUP), newRot2, out hit1, VelClamp, (int) this.targetLayers))
        {
            this.RPoint1u = hit1.point;
        }
        else
        {
            this.RPoint1u = new Vector3(2, 2, 2);
        }
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.right * 6)) + (-this.thisTransform.up * 23)) + (this.thisTransform.up * this.RRUP), newRot2 * VelClamp, Color.black);
        if (Physics.Raycast(((this.thisTransform.position + (this.thisTransform.right * 6)) + (-this.thisTransform.up * 23)) + (this.thisTransform.up * this.RRUP), newRot2, out hit2, VelClamp, (int) this.targetLayers))
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
        Debug.DrawRay(((this.thisTransform.position + (-this.thisTransform.right * 6)) + (-this.thisTransform.up * 22)) + (this.thisTransform.up * this.LRUP), newRot2 * VelClamp, Color.black);
        if (Physics.Raycast(((this.thisTransform.position + (-this.thisTransform.right * 6)) + (-this.thisTransform.up * 22)) + (this.thisTransform.up * this.LRUP), newRot2, out hit1, VelClamp, (int) this.targetLayers))
        {
            this.LPoint1u = hit1.point;
        }
        else
        {
            this.LPoint1u = new Vector3(2, 2, 2);
        }
        Debug.DrawRay(((this.thisTransform.position + (-this.thisTransform.right * 6)) + (-this.thisTransform.up * 23)) + (this.thisTransform.up * this.LRUP), newRot2 * VelClamp, Color.black);
        if (Physics.Raycast(((this.thisTransform.position + (-this.thisTransform.right * 6)) + (-this.thisTransform.up * 23)) + (this.thisTransform.up * this.LRUP), newRot2, out hit2, VelClamp, (int) this.targetLayers))
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
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.up * 4)) + (this.thisTransform.forward * VelClamp), Vector3.down * 32, Color.white);
        if (!Physics.Raycast((this.thisTransform.position + (this.thisTransform.up * 4)) + (this.thisTransform.forward * VelClamp), Vector3.down, 32))
        {
            this.Obstacle = true;
        }
        //---------------------------------------------------------------------------------------------
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.up * 4)) + (this.thisTransform.right * 16)) + (this.thisTransform.forward * VelClamp), Vector3.down * 32, Color.white);
        if (!Physics.Raycast(((this.thisTransform.position + (this.thisTransform.up * 4)) + (this.thisTransform.right * 16)) + (this.thisTransform.forward * VelClamp), Vector3.down, 32))
        {
            this.TurnLeft = true;
        }
        Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.up * 4)) + (-this.thisTransform.right * 16)) + (this.thisTransform.forward * VelClamp), Vector3.down * 32, Color.white);
        if (!Physics.Raycast(((this.thisTransform.position + (this.thisTransform.up * 4)) + (-this.thisTransform.right * 16)) + (this.thisTransform.forward * VelClamp), Vector3.down, 32))
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
            if (localV.y > 0)
            {
                this.vRigidbody.AddForce(-this.thisVTransform.up * 40);
            }
            else
            {
                this.vRigidbody.AddForce(this.thisVTransform.up * 40);
            }
        }
        if (this.target)
        {
            if (this.Attacking)
            {
                if (this.TargetDist > 64)
                {
                    if (-localV.y < 16)
                    {
                        if (!this.Obstacle && !this.Stuck)
                        {
                            this.vRigidbody.AddForce(-this.thisVTransform.up * 20);
                        }
                    }
                    this.vRigidbody.AddTorque(this.thisTransform.up * this.TurnForce);
                }
                else
                {
                    if (localV.y < 10)
                    {
                        if (!this.Obstacle && !this.Stuck)
                        {
                            this.vRigidbody.AddForce(this.thisVTransform.up * 40);
                        }
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
                if (this.Patrolling)
                {
                    if (!this.Obstacle && !this.Stuck)
                    {
                        if (-localV.y < 10)
                        {
                            this.vRigidbody.AddForce(-this.thisVTransform.up * 20);
                        }
                    }
                    if (this.Stuck)
                    {
                        if (localV.y < 4)
                        {
                            this.vRigidbody.AddForce(this.thisVTransform.up * 20);
                        }
                    }
                    this.vRigidbody.AddTorque(this.thisTransform.up * this.TurnForce);
                }
                else
                {
                    if (!this.Returning)
                    {
                        this.vRigidbody.AddForce((this.Station.position - this.thisTransform.position).normalized * 1);
                        if (-localV.y > 0)
                        {
                            this.vRigidbody.AddForce(this.thisVTransform.up * 20);
                        }
                    }
                    else
                    {
                        this.vRigidbody.AddTorque(this.thisTransform.up * this.TurnForce);
                        if (!this.Obstacle && !this.Stuck)
                        {
                            if (-localV.y < 10)
                            {
                                this.vRigidbody.AddForce(-this.thisVTransform.up * 20);
                            }
                        }
                    }
                }
            }
        }
        if (this.target)
        {
            if (this.vRigidbody.angularVelocity.magnitude < 0.5f)
            {
                this.vRigidbody.AddForceAtPosition((this.target.position - this.thisTransform.position).normalized * this.AimForce, this.thisTransform.forward * 2);
                this.vRigidbody.AddForceAtPosition((this.target.position - this.thisTransform.position).normalized * -this.AimForce, -this.thisTransform.forward * 2);
            }
        }
        if (this.CapDown)
        {
            if ((this.Cap.localEulerAngles.x < 10) || (this.Cap.localEulerAngles.x > 180))
            {
                this.Cap.Rotate(0.7f, 0, 0);
            }
        }
        else
        {
            if ((this.Cap.localEulerAngles.x > 0) && (this.Cap.localEulerAngles.x < 180))
            {
                this.Cap.Rotate(-0.1f, 0, 0);
            }
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        Transform OTF1 = other.transform;
        string OTN1 = other.name;
        if (OTN1.Contains("TFC"))
        {
            if (!OTN1.Contains("TFC6"))
            {
                if (OTN1.Contains("#3"))
                {
                    this.CapDown = true;
                }
                if (OTN1.Contains("TFC0a"))
                {
                    if (this.PissedAtTC0a < 8)
                    {
                        this.PissedAtTC0a = this.PissedAtTC0a + 4;
                    }
                    if (this.PissedAtTC1 > 0)
                    {
                        this.PissedAtTC1 = this.PissedAtTC1 - 4;
                    }
                    if (this.PissedAtTC2 > 0)
                    {
                        this.PissedAtTC2 = this.PissedAtTC2 - 4;
                    }
                    if (this.PissedAtTC3 > 0)
                    {
                        this.PissedAtTC3 = this.PissedAtTC3 - 4;
                    }
                    if (this.PissedAtTC4 > 0)
                    {
                        this.PissedAtTC4 = this.PissedAtTC4 - 4;
                    }
                    if (this.PissedAtTC5 > 0)
                    {
                        this.PissedAtTC5 = this.PissedAtTC5 - 4;
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
                if (OTN1.Contains("TFC1"))
                {
                    if (this.PissedAtTC1 < 8)
                    {
                        this.PissedAtTC1 = this.PissedAtTC1 + 4;
                    }
                    if (this.PissedAtTC0a > 0)
                    {
                        this.PissedAtTC0a = this.PissedAtTC0a - 4;
                    }
                    if (this.PissedAtTC2 > 0)
                    {
                        this.PissedAtTC3 = this.PissedAtTC3 - 4;
                    }
                    if (this.PissedAtTC2 > 0)
                    {
                        this.PissedAtTC3 = this.PissedAtTC3 - 4;
                    }
                    if (this.PissedAtTC4 > 0)
                    {
                        this.PissedAtTC4 = this.PissedAtTC4 - 4;
                    }
                    if (this.PissedAtTC5 > 0)
                    {
                        this.PissedAtTC5 = this.PissedAtTC5 - 4;
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
                if (OTN1.Contains("TFC2"))
                {
                    if (this.PissedAtTC2 < 8)
                    {
                        this.PissedAtTC2 = this.PissedAtTC2 + 4;
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
                    if (this.PissedAtTC5 > 0)
                    {
                        this.PissedAtTC5 = this.PissedAtTC5 - 4;
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
                if (OTN1.Contains("TFC3"))
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
                    if (this.PissedAtTC2 > 0)
                    {
                        this.PissedAtTC2 = this.PissedAtTC2 - 4;
                    }
                    if (this.PissedAtTC4 > 0)
                    {
                        this.PissedAtTC4 = this.PissedAtTC4 - 4;
                    }
                    if (this.PissedAtTC5 > 0)
                    {
                        this.PissedAtTC5 = this.PissedAtTC5 - 4;
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
                if (OTN1.Contains("TFC4"))
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
                    if (this.PissedAtTC2 > 0)
                    {
                        this.PissedAtTC2 = this.PissedAtTC2 - 4;
                    }
                    if (this.PissedAtTC3 > 0)
                    {
                        this.PissedAtTC3 = this.PissedAtTC3 - 4;
                    }
                    if (this.PissedAtTC5 > 0)
                    {
                        this.PissedAtTC5 = this.PissedAtTC5 - 4;
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
                if (OTN1.Contains("TFC5"))
                {
                    if (this.PissedAtTC5 < 8)
                    {
                        this.PissedAtTC5 = this.PissedAtTC5 + 4;
                    }
                    if (this.PissedAtTC0a > 0)
                    {
                        this.PissedAtTC0a = this.PissedAtTC0a - 4;
                    }
                    if (this.PissedAtTC1 > 0)
                    {
                        this.PissedAtTC1 = this.PissedAtTC1 - 4;
                    }
                    if (this.PissedAtTC2 > 0)
                    {
                        this.PissedAtTC2 = this.PissedAtTC2 - 4;
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
                if (OTN1.Contains("TFC7"))
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
                    if (this.PissedAtTC2 > 0)
                    {
                        this.PissedAtTC2 = this.PissedAtTC2 - 4;
                    }
                    if (this.PissedAtTC3 > 0)
                    {
                        this.PissedAtTC3 = this.PissedAtTC3 - 4;
                    }
                    if (this.PissedAtTC4 > 0)
                    {
                        this.PissedAtTC4 = this.PissedAtTC4 - 4;
                    }
                    if (this.PissedAtTC5 > 0)
                    {
                        this.PissedAtTC5 = this.PissedAtTC5 - 4;
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
                if (OTN1.Contains("TFC8"))
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
                    if (this.PissedAtTC2 > 0)
                    {
                        this.PissedAtTC2 = this.PissedAtTC2 - 4;
                    }
                    if (this.PissedAtTC3 > 0)
                    {
                        this.PissedAtTC3 = this.PissedAtTC3 - 4;
                    }
                    if (this.PissedAtTC4 > 0)
                    {
                        this.PissedAtTC4 = this.PissedAtTC4 - 4;
                    }
                    if (this.PissedAtTC5 > 0)
                    {
                        this.PissedAtTC5 = this.PissedAtTC5 - 4;
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
                if (OTN1.Contains("TFC9"))
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
                    if (this.PissedAtTC2 > 0)
                    {
                        this.PissedAtTC2 = this.PissedAtTC2 - 4;
                    }
                    if (this.PissedAtTC3 > 0)
                    {
                        this.PissedAtTC3 = this.PissedAtTC3 - 4;
                    }
                    if (this.PissedAtTC4 > 0)
                    {
                        this.PissedAtTC4 = this.PissedAtTC4 - 4;
                    }
                    if (this.PissedAtTC5 > 0)
                    {
                        this.PissedAtTC5 = this.PissedAtTC5 - 4;
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
                    this.DangerSense = 20;
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
            if (!other.GetComponent<Collider>().name.Contains("TC6"))
            {
                Transform OTF = other.transform;
                string OTN = other.name;
                if (Vector3.Distance(this.thisTransform.position, OTF.position) < 32)
                {
                    if (!OTN.Contains("tT"))
                    {
                        if (!Physics.Linecast(this.thisTransform.position, OTF.position, (int) this.MtargetLayers))
                        {
                            if ((this.Warn < 1) && !this.Attacking)
                            {
                                this.Warn = 6;
                                this.target = OTF;
                                this.WarningNoise();
                                if (OTN.Contains("TC0a"))
                                {
                                    this.PissedAtTC0a = this.PissedAtTC0a + 8;
                                }
                                if (OTN.Contains("TC1"))
                                {
                                    this.PissedAtTC1 = this.PissedAtTC1 + 8;
                                }
                                if (OTN.Contains("TC2"))
                                {
                                    this.PissedAtTC2 = this.PissedAtTC2 + 8;
                                }
                                if (OTN.Contains("TC3"))
                                {
                                    this.PissedAtTC3 = this.PissedAtTC3 + 8;
                                }
                                if (OTN.Contains("TC4"))
                                {
                                    this.PissedAtTC4 = this.PissedAtTC4 + 8;
                                }
                                if (OTN.Contains("TC5"))
                                {
                                    this.PissedAtTC5 = this.PissedAtTC5 + 8;
                                }
                                if (OTN.Contains("TC7"))
                                {
                                    this.PissedAtTC7 = this.PissedAtTC7 + 8;
                                }
                                if (OTN.Contains("TC8"))
                                {
                                    this.PissedAtTC8 = this.PissedAtTC8 + 8;
                                }
                                if (OTN.Contains("TC9"))
                                {
                                    this.PissedAtTC9 = this.PissedAtTC9 + 8;
                                }
                            }
                            if (Vector3.Distance(this.thisTransform.position, OTF.position) < 24)
                            {
                                if (this.Warn < 2)
                                {
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
                if (OTN.Contains("TC0a"))
                {
                    if (this.PissedAtTC0a > 8)
                    {
                        if (!OTN.Contains("tT"))
                        {
                            if ((OTN.Contains("sT") && !this.FoundBigger) || !OTN.Contains("sT"))
                            {
                                this.target = OTF;
                                if (!this.Attacking)
                                {
                                    this.AttackNoise();
                                }
                                this.Patrolling = false;
                                this.Attacking = true;
                                if (!OTN.Contains("sT"))
                                {
                                    this.FoundBigger = true;
                                }
                            }
                        }
                    }
                }
                if (OTN.Contains("TC1"))
                {
                    if (this.PissedAtTC1 > 8)
                    {
                        if (!OTN.Contains("tT"))
                        {
                            if ((OTN.Contains("sT") && !this.FoundBigger) || !OTN.Contains("sT"))
                            {
                                this.target = OTF;
                                if (!this.Attacking)
                                {
                                    this.AttackNoise();
                                }
                                this.Patrolling = false;
                                this.Attacking = true;
                                if (!OTN.Contains("sT"))
                                {
                                    this.FoundBigger = true;
                                }
                            }
                        }
                    }
                }
                if (OTN.Contains("TC2"))
                {
                    if (this.PissedAtTC2 > 8)
                    {
                        if (!OTN.Contains("tT"))
                        {
                            if ((OTN.Contains("sT") && !this.FoundBigger) || !OTN.Contains("sT"))
                            {
                                this.target = OTF;
                                if (!this.Attacking)
                                {
                                    this.AttackNoise();
                                }
                                this.Patrolling = false;
                                this.Attacking = true;
                                if (!OTN.Contains("sT"))
                                {
                                    this.FoundBigger = true;
                                }
                            }
                        }
                    }
                }
                if (OTN.Contains("TC3"))
                {
                    if (this.PissedAtTC3 > 8)
                    {
                        if (!OTN.Contains("tT"))
                        {
                            if ((OTN.Contains("sT") && !this.FoundBigger) || !OTN.Contains("sT"))
                            {
                                this.target = OTF;
                                if (!this.Attacking)
                                {
                                    this.AttackNoise();
                                }
                                this.Patrolling = false;
                                this.Attacking = true;
                                if (!OTN.Contains("sT"))
                                {
                                    this.FoundBigger = true;
                                }
                            }
                        }
                    }
                }
                if (OTN.Contains("TC4"))
                {
                    if (this.PissedAtTC4 > 8)
                    {
                        if (!OTN.Contains("tT"))
                        {
                            if ((OTN.Contains("sT") && !this.FoundBigger) || !OTN.Contains("sT"))
                            {
                                this.target = OTF;
                                if (!this.Attacking)
                                {
                                    this.AttackNoise();
                                }
                                this.Patrolling = false;
                                this.Attacking = true;
                                if (!OTN.Contains("sT"))
                                {
                                    this.FoundBigger = true;
                                }
                            }
                        }
                    }
                }
                if (OTN.Contains("TC5"))
                {
                    if (this.PissedAtTC5 > 8)
                    {
                        if (!OTN.Contains("tT"))
                        {
                            if ((OTN.Contains("sT") && !this.FoundBigger) || !OTN.Contains("sT"))
                            {
                                this.target = OTF;
                                if (!this.Attacking)
                                {
                                    this.AttackNoise();
                                }
                                this.Patrolling = false;
                                this.Attacking = true;
                                if (!OTN.Contains("sT"))
                                {
                                    this.FoundBigger = true;
                                }
                            }
                        }
                    }
                }
                if (OTN.Contains("TC7"))
                {
                    if (this.PissedAtTC7 > 8)
                    {
                        if (!OTN.Contains("tT"))
                        {
                            if ((OTN.Contains("sT") && !this.FoundBigger) || !OTN.Contains("sT"))
                            {
                                this.target = OTF;
                                if (!this.Attacking)
                                {
                                    this.AttackNoise();
                                }
                                this.Patrolling = false;
                                this.Attacking = true;
                                if (!OTN.Contains("sT"))
                                {
                                    this.FoundBigger = true;
                                }
                            }
                        }
                    }
                }
                if (OTN.Contains("TC8"))
                {
                    if (this.PissedAtTC8 > 8)
                    {
                        if (!OTN.Contains("tT"))
                        {
                            if ((OTN.Contains("sT") && !this.FoundBigger) || !OTN.Contains("sT"))
                            {
                                this.target = OTF;
                                if (!this.Attacking)
                                {
                                    this.AttackNoise();
                                }
                                this.Patrolling = false;
                                this.Attacking = true;
                                if (!OTN.Contains("sT"))
                                {
                                    this.FoundBigger = true;
                                }
                            }
                        }
                    }
                }
                if (OTN.Contains("TC9"))
                {
                    if (this.PissedAtTC9 > 8)
                    {
                        if (!OTN.Contains("tT"))
                        {
                            if ((OTN.Contains("sT") && !this.FoundBigger) || !OTN.Contains("sT"))
                            {
                                this.target = OTF;
                                if (!this.Attacking)
                                {
                                    this.AttackNoise();
                                }
                                this.Patrolling = false;
                                this.Attacking = true;
                                if (!OTN.Contains("sT"))
                                {
                                    this.FoundBigger = true;
                                }
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
        if (this.Attacking)
        {
            if (this.target)
            {
                this.Turret.NameOfTarget = this.target.name;
            }
            this.Turret.Attacking = true;
        }
        else
        {
            this.Turret.NameOfTarget = "null";
            this.Turret.Attacking = false;
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
            if (this.Patrolling && !this.Returning)
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

    public virtual void Regenerator()
    {
        if (this.PissedAtTC0a > 1)
        {
            this.PissedAtTC0a = this.PissedAtTC0a - 1;
        }
        if (this.PissedAtTC1 > 1)
        {
            this.PissedAtTC1 = this.PissedAtTC1 - 1;
        }
        if (this.PissedAtTC2 > 1)
        {
            this.PissedAtTC2 = this.PissedAtTC2 - 1;
        }
        if (this.PissedAtTC3 > 1)
        {
            this.PissedAtTC3 = this.PissedAtTC3 - 1;
        }
        if (this.PissedAtTC4 > 1)
        {
            this.PissedAtTC4 = this.PissedAtTC4 - 1;
        }
        if (this.PissedAtTC5 > 1)
        {
            this.PissedAtTC5 = this.PissedAtTC5 - 1;
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
        if (this.PissedAtTC1 < AbiaSyndicateNetwork.TC1CriminalLevel)
        {
            this.PissedAtTC1 = AbiaSyndicateNetwork.TC1CriminalLevel;
        }
        if (this.PissedAtTC2 < AbiaSyndicateNetwork.TC2CriminalLevel)
        {
            this.PissedAtTC2 = AbiaSyndicateNetwork.TC2CriminalLevel;
        }
        if (this.PissedAtTC3 < AbiaSyndicateNetwork.TC3CriminalLevel)
        {
            this.PissedAtTC3 = AbiaSyndicateNetwork.TC3CriminalLevel;
        }
        if (this.PissedAtTC4 < AbiaSyndicateNetwork.TC4CriminalLevel)
        {
            this.PissedAtTC4 = AbiaSyndicateNetwork.TC4CriminalLevel;
        }
        if (this.PissedAtTC5 < AbiaSyndicateNetwork.TC5CriminalLevel)
        {
            this.PissedAtTC5 = AbiaSyndicateNetwork.TC5CriminalLevel;
        }
        if (this.PissedAtTC7 < AbiaSyndicateNetwork.TC7CriminalLevel)
        {
            this.PissedAtTC7 = AbiaSyndicateNetwork.TC7CriminalLevel;
        }
        if (this.PissedAtTC8 < AbiaSyndicateNetwork.TC8CriminalLevel)
        {
            this.PissedAtTC8 = AbiaSyndicateNetwork.TC8CriminalLevel;
        }
        if (this.PissedAtTC9 < AbiaSyndicateNetwork.TC9CriminalLevel)
        {
            this.PissedAtTC9 = AbiaSyndicateNetwork.TC9CriminalLevel;
        }
        if (this.target)
        {
            this.TargetDist = (int) Vector3.Distance(this.thisTransform.position, this.target.position);
            if (this.Attacking)
            {
                if (this.Cap.localEulerAngles.x > 10)
                {
                    this.CapDown = false;
                }
                if (!this.target.name.Contains("TC"))
                {
                    this.target = this.ResetAimpoint;
                    this.Attacking = false;
                    this.FoundBigger = false;
                }
                if (this.target.name.Contains("sT") && this.FoundBigger)
                {
                    this.Attacking = false;
                    if (this.SecondTurret)
                    {
                        this.SecondTurret.target = this.target;
                        this.SecondTurret.NameOfTarget = this.target.name;
                        this.SecondTurret.Attacking = true;
                    }
                    this.target = this.ResetAimpoint;
                    if (this.PissedAtTC0a > 8)
                    {
                        this.SecondTurret.PissedAtTC0a = 64;
                    }
                    if (this.PissedAtTC1 > 8)
                    {
                        this.SecondTurret.PissedAtTC1 = 64;
                    }
                    if (this.PissedAtTC2 > 8)
                    {
                        this.SecondTurret.PissedAtTC2 = 64;
                    }
                    if (this.PissedAtTC3 > 8)
                    {
                        this.SecondTurret.PissedAtTC3 = 64;
                    }
                    if (this.PissedAtTC4 > 8)
                    {
                        this.SecondTurret.PissedAtTC4 = 64;
                    }
                    if (this.PissedAtTC5 > 8)
                    {
                        this.SecondTurret.PissedAtTC5 = 64;
                    }
                    if (this.PissedAtTC7 > 8)
                    {
                        this.SecondTurret.PissedAtTC7 = 64;
                    }
                    if (this.PissedAtTC8 > 8)
                    {
                        this.SecondTurret.PissedAtTC8 = 64;
                    }
                    if (this.PissedAtTC9 > 8)
                    {
                        this.SecondTurret.PissedAtTC9 = 64;
                    }
                }
            }
            else
            {
                this.FoundBigger = false;
            }
        }
        if (this.Attacking)
        {
            this.Trig.size = new Vector3(258, 64, 258);
            if (this.EngageTime > 0)
            {
                this.EngageTime = this.EngageTime - 1;
            }
        }
        else
        {
            this.Trig.size = new Vector3(512, 64, 512);
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
        else
        {
            if (this.Cap.localEulerAngles.x > 10)
            {
                this.CapDown = false;
            }
        }
        if (this.Warn > 0)
        {
            this.Warn = this.Warn - 1;
        }
        if (!this.freeRoam)
        {
            if (!this.Attacking && (this.DangerSense < 1))
            {
                if (this.Patrolling)
                {
                    if (this.PatrolTime < 1)
                    {
                        this.PatrolTime = 160;
                        this.Patrolling = false;
                    }
                    this.Returning = false;
                    if (Vector3.Distance(this.thisTransform.position, this.Station.position) > 512)
                    {
                        this.target = this.StationRAP;
                    }
                    this.PatrolTime = this.PatrolTime - Random.Range(1, 3);
                }
                else
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
        }
        this.AimForce = 200;
        this.TurnForce = 0;
        this.Wall = false;
        this.RWall = false;
        this.LWall = false;
        this.TurnRight = false;
        this.TurnLeft = false;
        this.Obstacle = false;
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

    public PhobosAI()
    {
        this.RightDist = 200;
        this.LeftDist = 200;
    }

}