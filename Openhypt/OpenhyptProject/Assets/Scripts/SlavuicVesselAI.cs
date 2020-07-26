using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SlavuicVesselAI : MonoBehaviour
{
    public Transform target;
    public Transform Waypoint;
    public Transform Waypoint2;
    public Transform Leader;
    public Transform Comrade;
    public GameObject Gyro;
    public CapsuleCollider Trig;
    public SlavuicGunController Turret;
    public VehicleDamage Hull;
    public DoppelgangerWithRemoval DWR;
    public CarDoorController vEntrance;
    public GameObject Mine;
    public Transform MineLayer;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public float slavAim;
    public Transform slavTarget;
    public GameObject Slavuic1Head;
    public GameObject Slavuic1Body;
    public SpringJoint Slavuic1BodyJ;
    public GameObject Slavuic1Gun;
    public PersonGunScript Slavuic1GunS;
    public Animation Slavuic1Ani;
    public bool Slav1Up;
    public Transform Slavuic1Pos1;
    public Transform Slavuic1Pos2;
    public Transform Slavuic1Pos3;
    public GameObject Slavuic2Head;
    public Transform TurnPoint;
    public Transform Overview;
    public GameObject HuntingSound;
    public GameObject AttackSound;
    public int PissedAtTC0a;
    public int PissedAtTC1;
    public int PissedAtTC3;
    public int PissedAtTC4;
    public int PissedAtTC6;
    public int PissedAtTC7;
    public int PissedAtTC8;
    public int PissedAtTC9;
    public Transform Stranger;
    public Transform Fear;
    public bool DedIfGunnerDed;
    public bool DedIfDriverDed;
    public bool Parked;
    public bool HasSpace;
    public bool Mistitor;
    public bool Watchmen;
    public bool Vanguard;
    public bool Divertor;
    public bool Hunting;
    public bool Attacking;
    public bool Obstacle;
    public bool TurnRight;
    public bool TurnLeft;
    public bool CanTurn;
    public bool Escape;
    public bool Threatened;
    public bool Grounded;
    public float gRayLength;
    public float ObsStartY;
    public float ObsStartZ;
    public float RightDist;
    public float LeftDist;
    public int TurnForce;
    public int StatTurnForce;
    public float TurnStabForce;
    public int DirForce;
    public int StatDirForce;
    public float Catchup;
    public float RPClamp;
    public float Vel;
    public Vector3 VelDir;
    public float RDFMod;
    public bool IsClose;
    public int CanLaunch;
    public bool Reposition;
    public bool Approach;
    public bool Follow;
    public LayerMask targetLayers;
    public LayerMask MtargetLayers;
    public int Stuck;
    public int LayingLow;
    public int Ogle;
    public float UniqueShootTime;
    public virtual void Start()
    {
        this.InvokeRepeating("Updater", 1, 1);
        this.InvokeRepeating("Refresher", 0.5f, 0.2f);
        this.InvokeRepeating("Targety", 3, 3);
        this.InvokeRepeating("Shoot", this.UniqueShootTime, 0.2f);
        this.target = this.Waypoint;
        this.UniqueShootTime = Random.Range(1, 2);
        this.StatDirForce = this.DirForce;
        this.StatTurnForce = this.TurnForce;
        this.slavAim = 0.1f;
        this.Hunting = true;
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        RaycastHit hit2 = default(RaycastHit);
        if (!this.vRigidbody || !this.Gyro)
        {
            return;
        }
        if (!this.IsClose)
        {
            if ((!this.TurnLeft && !this.TurnRight) && !this.Obstacle)
            {
                this.CanTurn = true;
            }
            if ((this.CanLaunch > 0) && this.Attacking)
            {
                this.CanTurn = true;
            }
            if (this.Follow)
            {
                this.CanTurn = true;
            }
            if ((this.TurnLeft || this.TurnRight) || this.Obstacle)
            {
                this.CanTurn = false;
            }
        }
        if (this.Vel < 6)
        {
            if (!this.Mistitor)
            {
                this.gRayLength = 1;
            }
        }
        else
        {
            if (!this.Mistitor)
            {
                this.gRayLength = 0.6f;
            }
        }
        Debug.DrawRay(this.thisTransform.position, -this.thisVTransform.forward * this.gRayLength, Color.white);
        if (Physics.Raycast(this.thisTransform.position, -this.thisVTransform.forward, this.gRayLength))
        {
            this.Grounded = true;
        }
        else
        {
            this.Grounded = false;
        }
        Vector3 newRot = -this.thisVTransform.up.normalized;
        float VelClamp = Mathf.Clamp(this.Vel, 10, 100);
        if (this.vRigidbody)
        {
            Vector3 VesselAngVel = this.thisVTransform.InverseTransformDirection(this.vRigidbody.angularVelocity);
            this.VelDir = this.vRigidbody.velocity;
            float AV1 = (VesselAngVel.z * this.vRigidbody.mass) * 20;
            float AV2 = Mathf.Clamp(AV1, -100, 100);
            this.TurnStabForce = -AV2;
        }
        Debug.DrawRay((this.thisTransform.position + (-this.thisVTransform.up * 5)) + (this.thisVTransform.right * 2), newRot * VelClamp, Color.black);
        if (Physics.Raycast((this.thisTransform.position + (-this.thisVTransform.up * 5)) + (this.thisVTransform.right * 2), newRot, out hit, VelClamp))
        {
            this.RightDist = hit.distance;
        }
        else
        {
            this.RightDist = VelClamp;
        }
        Debug.DrawRay((this.thisTransform.position + (-this.thisVTransform.up * 5)) + (-this.thisVTransform.right * 2), newRot * VelClamp, Color.black);
        if (Physics.Raycast((this.thisTransform.position + (-this.thisVTransform.up * 5)) + (-this.thisVTransform.right * 2), newRot, out hit, VelClamp))
        {
            this.LeftDist = hit.distance;
        }
        else
        {
            this.LeftDist = VelClamp;
        }
        if (this.RightDist > this.LeftDist)
        {
            this.TurnRight = true;
        }
        if (this.LeftDist > this.RightDist)
        {
            this.TurnLeft = true;
        }
        if (this.RightDist == this.LeftDist)
        {
            this.TurnRight = false;
            this.TurnLeft = false;
        }
        Debug.DrawRay(this.thisTransform.position + (-this.thisVTransform.up * 5), -this.thisVTransform.up * VelClamp, Color.white);
        if (Physics.Raycast(this.thisTransform.position + (-this.thisVTransform.up * 5), -this.thisVTransform.up, VelClamp))
        {
            this.Obstacle = true;
        }
        else
        {
            this.Obstacle = false;
            Debug.DrawRay((this.thisTransform.position + (-this.thisVTransform.up * VelClamp)) + (this.thisVTransform.forward * 10), -this.thisVTransform.forward * 20, Color.white);
            if (!Physics.Raycast((this.thisTransform.position + (-this.thisVTransform.up * VelClamp)) + (this.thisVTransform.forward * 10), -this.thisVTransform.forward, out hit, 20))
            {
                this.Obstacle = true;
            }
            else
            {
                if (hit.collider.name.Contains("Wa"))
                {
                    this.Obstacle = true;
                }
            }
        }
        float UpDist, DownDist;
        Debug.DrawRay((this.thisTransform.position + (-this.thisVTransform.up * 5)) + (this.thisVTransform.forward * 0.4f), -this.thisVTransform.up * VelClamp, Color.green);
        if (Physics.Raycast((this.thisTransform.position + (-this.thisVTransform.up * 5)) + (this.thisVTransform.forward * 0.4f), -this.thisVTransform.up, out hit2, VelClamp))
        {
            UpDist = hit2.distance;
        }
        else
        {
            UpDist = 8;
        }
        Debug.DrawRay(this.thisTransform.position + (-this.thisVTransform.up * 5), -this.thisVTransform.up * VelClamp, Color.green);
        if (Physics.Raycast(this.thisTransform.position + (-this.thisVTransform.up * 5), -this.thisVTransform.up, out hit2, VelClamp))
        {
            DownDist = hit2.distance;
        }
        else
        {
            DownDist = 8;
        }
        float Angle = Mathf.Abs(UpDist - DownDist);
        if (!Physics.Raycast((this.thisTransform.position + (-this.thisVTransform.up * 5)) + (this.thisVTransform.forward * 1.5f), -this.thisVTransform.up, VelClamp))
        {
            if (Angle > 1.5f)
            {
                this.TurnRight = false;
                this.TurnLeft = false;
                this.Obstacle = false;
            }
        }
        else
        {
            this.Obstacle = true;
        }
        //---------------------------------------------------------------------------------------------
        Debug.DrawRay(((this.thisTransform.position + (Vector3.up * 10)) + (this.thisVTransform.right * 10)) + (-this.thisVTransform.up * VelClamp), Vector3.down * 20, Color.white);
        if (!Physics.Raycast(((this.thisTransform.position + (Vector3.up * 10)) + (this.thisVTransform.right * 10)) + (-this.thisVTransform.up * VelClamp), Vector3.down, out hit, 20))
        {
            this.TurnLeft = true;
        }
        else
        {
            if (hit.collider.name.Contains("Wa"))
            {
                this.TurnLeft = true;
            }
        }
        Debug.DrawRay(((this.thisTransform.position + (Vector3.up * 10)) + (-this.thisVTransform.right * 10)) + (-this.thisVTransform.up * VelClamp), Vector3.down * 20, Color.white);
        if (!Physics.Raycast(((this.thisTransform.position + (Vector3.up * 10)) + (-this.thisVTransform.right * 10)) + (-this.thisVTransform.up * VelClamp), Vector3.down, out hit, 20))
        {
            this.TurnRight = true;
        }
        else
        {
            if (hit.collider.name.Contains("Wa"))
            {
                this.TurnRight = true;
            }
        }
        //---------------------------------------------------------------------------------------------
        Debug.DrawRay(this.thisTransform.position + (-this.thisVTransform.up * 5), this.thisVTransform.right * 7, Color.black);
        if (Physics.Raycast(this.thisTransform.position + (-this.thisVTransform.up * 5), this.thisVTransform.right, 7))
        {
            this.RightDist = hit.distance;
        }
        else
        {
            this.RightDist = 60;
        }
        Debug.DrawRay(this.thisTransform.position + (-this.thisVTransform.up * 5), -this.thisVTransform.right * 7, Color.black);
        if (Physics.Raycast(this.thisTransform.position + (-this.thisVTransform.up * 5), -this.thisVTransform.right, 7))
        {
            this.LeftDist = hit.distance;
        }
        else
        {
            this.LeftDist = 60;
        }
        if (this.RightDist > this.LeftDist)
        {
            this.TurnRight = true;
            this.TurnLeft = false;
        }
        if (this.LeftDist > this.RightDist)
        {
            this.TurnLeft = true;
            this.TurnRight = false;
        }
        if (this.Watchmen && !this.Vanguard)
        {
            if (this.Slavuic1Body)
            {
                this.StartCoroutine(this.SlavSquat());
            }
            else
            {
                this.StopAllCoroutines();
            }
        }
    }

    private Vector3 RP;
    public virtual void FixedUpdate()
    {
        if (!this.vRigidbody || !this.Gyro)
        {
            return;
        }
        Vector3 localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
        this.Vel = -localV.y * 2.24f;
        float RPMod = this.RP.x;
        float RPMAbs = Mathf.Abs(RPMod);
        if (this.target)
        {
            Vector3 RelativeTarget = this.thisTransform.InverseTransformPoint(this.target.position);
            float RTMod = (RelativeTarget.z * 0.2f) - 5;
            float RelativeDirForce = Mathf.Clamp(RTMod, -this.DirForce, this.DirForce);
            this.RDFMod = RelativeDirForce * this.Catchup;

            int TForceMod;
            if (this.Vel > 8)
            {
                TForceMod = this.TurnForce;
            }
            else
            {
                TForceMod = this.TurnForce * 2;
            }
            if (this.CanTurn)
            {
                this.RPClamp = Mathf.Clamp(RPMod, -TForceMod, TForceMod);
            }
            else
            {
                this.RPClamp = 0;
            }
            if (!this.Grounded)
            {
                this.RPClamp = 0;
                this.RDFMod = 0;
                this.TurnForce = 0;
                this.DirForce = 0;
            }
            else
            {
                this.TurnForce = this.StatTurnForce;
                this.DirForce = this.StatDirForce;
            }
            if (!this.TurnLeft && !this.TurnRight)
            {
                if (this.target)
                {
                    if (this.Watchmen || this.Mistitor)
                    {
                        if (!this.Attacking)
                        {
                            this.RP = RelativeTarget;
                            if (!this.Threatened)
                            {
                                this.Gyro.GetComponent<Rigidbody>().AddTorque(this.thisVTransform.forward * this.RPClamp);
                            }
                            else
                            {
                                this.Gyro.GetComponent<Rigidbody>().AddTorque(this.thisVTransform.forward * -this.RPClamp);
                            }
                        }
                        else
                        {
                            if (!this.Escape)
                            {
                                if (!this.Approach)
                                {
                                    this.RP = this.thisTransform.InverseTransformPoint(this.TurnPoint.position);
                                    this.Gyro.GetComponent<Rigidbody>().AddTorque(this.thisVTransform.forward * this.RPClamp);
                                }
                                else
                                {
                                    this.RP = RelativeTarget;
                                    this.Gyro.GetComponent<Rigidbody>().AddTorque(this.thisVTransform.forward * this.RPClamp);
                                }
                            }
                            else
                            {
                                this.RP = RelativeTarget;
                                this.Gyro.GetComponent<Rigidbody>().AddTorque(this.thisVTransform.forward * -this.RPClamp);
                            }
                        }
                    }
                    else
                    {
                        this.RP = RelativeTarget;
                        if (!this.Threatened)
                        {
                            this.Gyro.GetComponent<Rigidbody>().AddTorque(this.thisVTransform.forward * this.RPClamp);
                        }
                        else
                        {
                            this.Gyro.GetComponent<Rigidbody>().AddTorque(this.thisVTransform.forward * -this.RPClamp);
                        }
                    }
                }
                if (RPMAbs > 32)
                {
                    if (this.vRigidbody.angularVelocity.magnitude > 1)
                    {
                        this.Gyro.GetComponent<Rigidbody>().AddTorque(this.thisVTransform.forward * this.TurnStabForce);
                    }
                }
                else
                {
                    this.Gyro.GetComponent<Rigidbody>().AddTorque(this.thisVTransform.forward * this.TurnStabForce);
                }
            }
		}
        if (this.Obstacle)
        {
            if (this.Vel > 0)
            {
                this.vRigidbody.AddForce(this.thisVTransform.up * this.DirForce);
            }
        }
        if (!this.Attacking)
        {
            if (this.Stuck > 0)
            {
                if (!this.IsClose)
                {
                    if (this.vRigidbody.angularVelocity.magnitude < 0.5f)
                    {
                        if (!this.Mistitor)
                        {
                            this.Gyro.GetComponent<Rigidbody>().AddTorque((this.thisVTransform.forward * -this.TurnForce) * 2);
                        }
                        else
                        {
                            this.Gyro.GetComponent<Rigidbody>().AddTorque((this.thisVTransform.forward * -this.TurnForce) * 2);
                        }
                    }
                    if (-this.Vel < 8)
                    {
                        this.vRigidbody.AddForce(this.thisVTransform.up * this.DirForce);
                    }
                }
            }
            if ((this.Stuck < 1) && !this.IsClose)
            {
                if (!this.Obstacle)
                {
                    if (!this.Follow)
                    {
                        if (this.Vel < 75)
                        {
                            if (this.Vel < 40)
                            {
                                this.vRigidbody.AddForce(this.thisVTransform.up * -this.DirForce);
                            }
                            else
                            {
                                this.vRigidbody.AddForce(this.thisVTransform.up * -this.RDFMod);
                            }
                        }
                    }
                    else
                    {
                        if (this.Vel < 95)
                        {
                            if (this.Vel < 40)
                            {
                                this.vRigidbody.AddForce(this.thisVTransform.up * -this.DirForce);
                            }
                            else
                            {
                                this.vRigidbody.AddForce(this.thisVTransform.up * -this.RDFMod);
                            }
                        }
                    }
                }
            }
            if (this.IsClose && !this.Attacking)
            {
                if (this.Vel > 0)
                {
                    this.vRigidbody.AddForce(this.thisVTransform.up * this.DirForce);
                }
                if (-this.Vel > 0)
                {
                    this.vRigidbody.AddForce(this.thisVTransform.up * -this.DirForce);
                }
            }
        }
        else
        {
            if (this.Reposition)
            {
                if (!this.Obstacle)
                {
                    if (!this.Escape)
                    {
                        if (!this.Approach)
                        {
                            if (this.Vel < 30)
                            {
                                this.vRigidbody.AddForce(this.thisVTransform.up * -this.DirForce);
                            }
                        }
                        else
                        {
                            if (this.Vel < 75)
                            {
                                this.vRigidbody.AddForce(this.thisVTransform.up * -this.DirForce);
                            }
                        }
                    }
                    else
                    {
                        if (this.Vel < 95)
                        {
                            this.vRigidbody.AddForce(this.thisVTransform.up * -this.DirForce);
                        }
                    }
                }
                this.Parked = false;
            }
            else
            {
                if (this.Vel > 0)
                {
                    this.vRigidbody.AddForce(this.thisVTransform.up * this.DirForce);
                }
                if (-this.Vel > 0)
                {
                    this.vRigidbody.AddForce(this.thisVTransform.up * -this.DirForce);
                }
            }
        }
        if (((this.TurnLeft && !this.TurnRight) && (this.Stuck < 1)) && !this.Parked)
        {
            if (this.Vel < 20)
            {
                this.Gyro.GetComponent<Rigidbody>().AddTorque((this.thisVTransform.forward * -this.TurnForce) * 2);
            }
            else
            {
                this.Gyro.GetComponent<Rigidbody>().AddTorque(this.thisVTransform.forward * -this.TurnForce);
            }
        }
        if (((this.TurnRight && !this.TurnLeft) && (this.Stuck < 1)) && !this.Parked)
        {
            if (this.Vel < 20)
            {
                this.Gyro.GetComponent<Rigidbody>().AddTorque((this.thisVTransform.forward * this.TurnForce) * 2);
            }
            else
            {
                this.Gyro.GetComponent<Rigidbody>().AddTorque(this.thisVTransform.forward * this.TurnForce);
            }
        }
        if (this.Stranger)
        {
            if (this.Slavuic1Head)
            {
                this.Slavuic1Head.GetComponent<Rigidbody>().AddForceAtPosition((this.Stranger.position - this.Slavuic1Head.transform.position).normalized * 0.01f, this.Slavuic1Head.transform.forward * 2);
                this.Slavuic1Head.GetComponent<Rigidbody>().AddForceAtPosition((this.Stranger.position - this.Slavuic1Head.transform.position).normalized * -0.01f, -this.Slavuic1Head.transform.forward * 2);
            }
            if (this.Slavuic2Head)
            {
                this.Slavuic2Head.GetComponent<Rigidbody>().AddForceAtPosition((this.Stranger.position - this.Slavuic2Head.transform.position).normalized * 0.01f, this.Slavuic2Head.transform.forward * 2);
                this.Slavuic2Head.GetComponent<Rigidbody>().AddForceAtPosition((this.Stranger.position - this.Slavuic2Head.transform.position).normalized * -0.01f, -this.Slavuic2Head.transform.forward * 2);
            }
        }
        if (this.Slavuic1Body)
        {
            if (this.slavTarget)
            {
                this.Slavuic1Body.GetComponent<Rigidbody>().AddForceAtPosition((this.slavTarget.position - this.Slavuic1Body.transform.position).normalized * this.slavAim, this.Slavuic1Body.transform.forward * 2);
                this.Slavuic1Body.GetComponent<Rigidbody>().AddForceAtPosition((this.slavTarget.position - this.Slavuic1Body.transform.position).normalized * -this.slavAim, -this.Slavuic1Body.transform.forward * 2);
            }
            if (!this.Slav1Up)
            {
                this.Slavuic1Body.GetComponent<Rigidbody>().AddForceAtPosition(-Vector3.up * 0.1f, this.Slavuic1Body.transform.right * 2);
                this.Slavuic1Body.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.up * 0.1f, -this.Slavuic1Body.transform.right * 2);
            }
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            string ON = other.name;
            Transform OT = other.transform;
            if (ON.Contains("TFC"))
            {
                if (!ON.Contains("TFC5"))
                {
                    if (this.DWR)
                    {
                        this.thisTransform.LookAt(OT);
                        this.DWR.enabled = false;
                        this.StartCoroutine(this.ResetTF());
                    }
                    if (Vector3.Distance(this.thisTransform.position, OT.position) < 50)
                    {
                        if (ON.Contains("TFC0a"))
                        {
                            this.PissedAtTC0a = this.PissedAtTC0a + 1;
                        }
                    }
                    if (Vector3.Distance(this.thisTransform.position, OT.position) < 50)
                    {
                        if (ON.Contains("TFC1"))
                        {
                            this.PissedAtTC1 = this.PissedAtTC1 + 1;
                        }
                    }
                    if (Vector3.Distance(this.thisTransform.position, OT.position) < 50)
                    {
                        if (ON.Contains("TFC4"))
                        {
                            this.PissedAtTC4 = this.PissedAtTC4 + 1;
                        }
                    }
                    if (Vector3.Distance(this.thisTransform.position, OT.position) < 50)
                    {
                        if (ON.Contains("TFC7"))
                        {
                            this.PissedAtTC7 = this.PissedAtTC7 + 1;
                        }
                    }
                    if (Vector3.Distance(this.thisTransform.position, OT.position) < 50)
                    {
                        if (ON.Contains("TFC8"))
                        {
                            this.PissedAtTC8 = this.PissedAtTC8 + 1;
                        }
                    }
                    if (Vector3.Distance(this.thisTransform.position, OT.position) < 50)
                    {
                        if (ON.Contains("TFC9"))
                        {
                            this.PissedAtTC9 = this.PissedAtTC9 + 1;
                        }
                    }
                }
            }
        }
    }

    public virtual IEnumerator ResetTF()
    {
        yield return new WaitForSeconds(0.3f);
        this.DWR.enabled = true;
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if (other != null)
        {
            string ON = other.name;
            Transform OT = other.transform;
            if (!ON.Contains("x"))
            {
                if (Physics.Linecast(this.thisTransform.position, OT.position, (int)this.MtargetLayers))
                {
                    return;
                }
            }
            if (ON.Contains("TC"))
            {
                if (Vector3.Distance(this.thisTransform.position, OT.position) < 200)
                {
                    if (this.Divertor)
                    {
                        Vector3 relativePoint = this.thisVTransform.InverseTransformPoint(OT.position);
                        if (relativePoint.y < 0)
                        {
                            if ((relativePoint.x < 50) && (relativePoint.x > -50))
                            {
                                return;
                            }
                        }
                    }
                    this.Stranger = OT;
                    if (ON.Contains("TC0a") && (this.PissedAtTC0a > 3))
                    {
                        this.Stranger = OT;
                    }
                    if (ON.Contains("TC1") && (this.PissedAtTC1 > 3))
                    {
                        this.Stranger = OT;
                    }
                    if (ON.Contains("TC3") && (this.PissedAtTC3 > 3))
                    {
                        this.Stranger = OT;
                    }
                    if (ON.Contains("TC4") && (this.PissedAtTC4 > 3))
                    {
                        this.Stranger = OT;
                    }
                    if (ON.Contains("TC7") && (this.PissedAtTC7 > 3))
                    {
                        this.Stranger = OT;
                    }
                    if (ON.Contains("TC8") && (this.PissedAtTC8 > 3))
                    {
                        this.Stranger = OT;
                    }
                    if (ON.Contains("TC9") && (this.PissedAtTC9 > 3))
                    {
                        this.Stranger = OT;
                    }
                    if (ON.Contains("mTC6"))
                    {
                        this.Stranger = OT;
                        this.PissedAtTC6 = 4;
                    }
                }
                else
                {
                    this.Stranger = null;
                    if (this.target)
                    {
                        if (ON.Contains("xb"))
                        {
                            SlavuicNetwork.FoundExtraBig = this.target;
                            SlavuicNetwork.instance.PriorityWaypoint.position = this.target.position;
                        }
                    }
                }
            }
            if (this.Watchmen || this.Mistitor)
            {
                if (ON.Contains("TC2"))
                {
                    if (Vector3.Distance(this.thisTransform.position, OT.position) < 500)
                    {
                        this.Fear = OT;
                        this.LayingLow = 3;
                    }
                }
                if ((ON.Contains("TC0a") && (this.PissedAtTC0a > 1)) && (this.LayingLow < 1))
                {
                    this.Hunting = false;
                    if (this.AttackSound)
                    {
                        GameObject TheThing0 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                        TheThing0.transform.parent = this.thisTransform;
                    }
                    this.target = OT;
                    if (!this.Attacking && (this.PissedAtTC0a > 3))
                    {
                        this.target = OT;
                        this.Attacking = true;
                    }
                }
                if ((ON.Contains("TC1") && (this.PissedAtTC1 > 1)) && (this.LayingLow < 1))
                {
                    this.Hunting = false;
                    if (this.AttackSound)
                    {
                        GameObject TheThing1 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                        TheThing1.transform.parent = this.thisTransform;
                    }
                    this.target = OT;
                    if (!this.Attacking && (this.PissedAtTC1 > 3))
                    {
                        this.target = OT;
                        this.Attacking = true;
                    }
                }
                if (this.PissedAtTC3 > 1)
                {
                    if (!ON.Contains("cT"))
                    {
                        if (ON.Contains("TC3") && (this.LayingLow < 1))
                        {
                            this.Hunting = false;
                            if (this.AttackSound)
                            {
                                GameObject TheThing2 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                                TheThing2.transform.parent = this.thisTransform;
                            }
                            this.target = OT;
                            if (this.PissedAtTC3 > 3)
                            {
                                this.target = OT;
                                this.Attacking = true;
                            }
                        }
                    }
                }
                if (this.PissedAtTC4 > 1)
                {
                    if (ON.Contains("TC4") && (this.LayingLow < 1))
                    {
                        this.Hunting = false;
                        if (this.AttackSound)
                        {
                            GameObject TheThing3 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                            TheThing3.transform.parent = this.thisTransform;
                        }
                        this.target = OT;
                        if (this.PissedAtTC4 > 3)
                        {
                            this.target = OT;
                            this.Attacking = true;
                        }
                    }
                }
                if (this.PissedAtTC6 > 1)
                {
                    if (!ON.Contains("cT"))
                    {
                        if (ON.Contains("TC6") && (this.LayingLow < 1))
                        {
                            this.Hunting = false;
                            if (this.AttackSound)
                            {
                                GameObject TheThing4 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                                TheThing4.transform.parent = this.thisTransform;
                            }
                            this.target = OT;
                            if (this.PissedAtTC6 > 3)
                            {
                                this.target = OT;
                                this.Attacking = true;
                            }
                        }
                    }
                }
                if (this.PissedAtTC7 > 1)
                {
                    if (!ON.Contains("cT"))
                    {
                        if (ON.Contains("TC7") && (this.LayingLow < 1))
                        {
                            this.Hunting = false;
                            if (this.AttackSound)
                            {
                                GameObject TheThing5 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                                TheThing5.transform.parent = this.thisTransform;
                            }
                            this.target = OT;
                            if (this.PissedAtTC7 > 3)
                            {
                                this.target = OT;
                                this.Attacking = true;
                            }
                        }
                    }
                }
                if (this.PissedAtTC8 > 1)
                {
                    if (!ON.Contains("cT"))
                    {
                        if (ON.Contains("TC8") && (this.LayingLow < 1))
                        {
                            this.Hunting = false;
                            if (this.AttackSound)
                            {
                                GameObject TheThing6 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                                TheThing6.transform.parent = this.thisTransform;
                            }
                            this.target = OT;
                            if (this.PissedAtTC8 > 3)
                            {
                                this.target = OT;
                                this.Attacking = true;
                            }
                        }
                    }
                }
                if (this.PissedAtTC9 > 1)
                {
                    if (!ON.Contains("cT"))
                    {
                        if (ON.Contains("TC9") && (this.LayingLow < 1))
                        {
                            this.Hunting = false;
                            if (this.AttackSound)
                            {
                                GameObject TheThing7 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                                TheThing7.transform.parent = this.thisTransform;
                            }
                            this.target = OT;
                            if (this.PissedAtTC9 > 3)
                            {
                                this.target = OT;
                                this.Attacking = true;
                            }
                        }
                    }
                }
                if (this.Mistitor)
                {
                    if (!this.Leader)
                    {
                        if (ON.Contains("TC5l"))
                        {
                            this.Leader = OT;
                        }
                    }
                }
            }
            else
            {
                if (this.Divertor)
                {
                    if (!this.Comrade)
                    {
                        if (ON.Contains("TC5"))
                        {
                            this.Comrade = OT;
                        }
                    }
                }
                if (this.Divertor)
                {
                    if (!this.Leader)
                    {
                        if (ON.Contains("TC5l"))
                        {
                            this.Leader = OT;
                        }
                    }
                }
            }
            if (this.Attacking)
            {
                this.Stranger = this.target;
            }

            if (this.Ogle > 0)
            {
                if (this.target)
                {
                    if (this.target.name.Contains("FC1"))
                    {
                        if (ON.Contains("TC1"))
                        {
                            this.target = OT;
                        }
                    }
                }
            }
        }
    }

    public virtual void Shoot()
    {
        if (this.Watchmen || this.Mistitor)
        {
            if ((this.Attacking && (this.LayingLow < 1)) && (this.CanLaunch > 0))
            {
                this.Turret.Firing = true;
            }
        }
        if (this.Divertor)
        {
            if (this.Stranger)
            {
                if ((this.LayingLow < 1) && (this.CanLaunch > 3))
                {
                    Vector3 relativePoint = this.thisVTransform.InverseTransformPoint(this.Stranger.position);
                    if (relativePoint.y > 0)
                    {
                        if ((relativePoint.x < 50) && (relativePoint.x > -50))
                        {
                            if ((((((((this.Stranger.name.Contains("TC0a") && (this.PissedAtTC0a > 3)) || (this.Stranger.name.Contains("TC1") && (this.PissedAtTC1 > 3))) || (this.Stranger.name.Contains("TC3") && (this.PissedAtTC3 > 3))) || (this.Stranger.name.Contains("TC4") && (this.PissedAtTC4 > 3))) || (this.Stranger.name.Contains("TC6") && (this.PissedAtTC6 > 3))) || (this.Stranger.name.Contains("TC7") && (this.PissedAtTC7 > 3))) || (this.Stranger.name.Contains("TC8") && (this.PissedAtTC8 > 3))) || (this.Stranger.name.Contains("TC9") && (this.PissedAtTC9 > 3)))
                            {
                                if (this.Vel > 20)
                                {
                                    GameObject _SpawnedObject1 = UnityEngine.Object.Instantiate(this.Mine, this.MineLayer.position, this.MineLayer.rotation);
                                    _SpawnedObject1.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                                    this.CanLaunch = 0;
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public virtual void Targety()
    {
        Vector3 lastPos = this.thisTransform.position;
        this.StartCoroutine(this.IsEscaping(lastPos));
        if (this.Watchmen || this.Mistitor)
        {
            if (this.Hunting)
            {
                if (Vector3.Distance(this.thisTransform.position, this.Waypoint2.position) > 5000)
                {
                    this.target = this.Waypoint2;
                }
                if (this.target == this.Waypoint2)
                {
                    if (Vector3.Distance(this.thisTransform.position, this.Waypoint2.position) < 5000)
                    {
                        this.target = this.Waypoint;
                    }
                }
            }
            if (this.Mistitor)
            {
                if (this.Leader && !this.Attacking)
                {
                    this.target = this.Leader;
                    this.Follow = true;
                }
            }
        }
        else
        {
            if (this.Leader)
            {
                this.target = this.Leader;
                this.Follow = true;
            }
            if (this.Comrade)
            {
                this.target = this.Comrade;
                this.Follow = true;
            }
        }
    }

    public virtual void Refresher()
    {
        if (this.Watchmen && !this.Vanguard)
        {
            if ((this.Slavuic1Head == null) || (this.Slavuic2Head == null))
            {
                this.Hull.DamageIn(128, 0, 0, false);
            }
        }
        if (this.Turret)
        {
            this.Turret.LeadDiv = this.Vel;
            this.Turret.VelDir = this.VelDir;
        }
        this.TurnRight = false;
        this.TurnLeft = false;
    }

    public virtual void Updater()
    {
        if (this.Follow)
        {
            this.Catchup = 1;
        }
        else
        {
            this.Catchup = 0.5f;
        }
        this.Parked = false;
        if (this.Attacking)
        {
            if (this.target)
            {
                if (this.target.name.Contains("TC"))
                {
                    SlavuicNetwork.target = this.target;
                }
            }
            if ((this.target == this.Waypoint) || (this.target == this.Waypoint2))
            {
                this.StopAllCoroutines();
                this.Attacking = false;
                this.Hunting = true;
                this.Reposition = false;
                this.target = this.Waypoint;
            }
        }
        if (this.target == null)
        {
            this.StopAllCoroutines();
            this.Attacking = false;
            this.Hunting = true;
            this.Reposition = false;
            this.target = this.Waypoint;
        }
        if (WorldInformation.instance.RestrictedArea)
        {
            if (Vector3.Distance(this.thisTransform.position, WorldInformation.instance.RestrictedArea.position) < 1000)
            {
                this.target = WorldInformation.instance.RestrictedArea;
                this.Threatened = true;
            }
        }
        if (this.target)
        {
            float Clamp = Mathf.Clamp(this.Vel, 10, 100);
            if (Vector3.Distance(this.thisTransform.position, this.target.position) < Clamp)
            {
                this.IsClose = true;
            }
            else
            {
                this.IsClose = false;
            }
            if (this.Threatened)
            {
                if (Vector3.Distance(this.thisTransform.position, this.target.position) > 1000)
                {
                    this.target = this.Waypoint;
                    this.Threatened = false;
                }
            }
        }
        if (this.Watchmen || this.Mistitor)
        {
            if (this.target)
            {
                if (this.Attacking)
                {
                    if (Vector3.Distance(this.thisTransform.position, this.target.position) > 1200)
                    {
                        this.Reposition = true;
                        this.Parked = false;
                        this.Approach = true;
                        this.CanLaunch = 0;
                    }
                    else
                    {
                        if (!this.Escape)
                        {
                            this.Reposition = false;
                        }
                        else
                        {
                            this.Reposition = true;
                        }
                        this.Parked = true;
                        this.Approach = false;
                        this.CanLaunch = 1;
                        if (Vector3.Distance(this.thisTransform.position, this.target.position) < 700)
                        {
                            this.StartCoroutine(this.SenseTargDir());
                        }
                        else
                        {
                            this.Escape = false;
                        }
                    }
                    if (Vector3.Distance(this.thisTransform.position, this.target.position) > 1500)
                    {
                        if (this.target.name.Contains("TC0a") && (this.PissedAtTC0a < 3))
                        {
                            this.target = this.Waypoint;
                            this.Attacking = false;
                            this.Hunting = true;
                            this.Reposition = false;
                        }
                        if (this.target.name.Contains("TC1") && (this.PissedAtTC1 < 3))
                        {
                            this.target = this.Waypoint;
                            this.Attacking = false;
                            this.Hunting = true;
                            this.Reposition = false;
                        }
                        if (this.target.name.Contains("TC3") && (this.PissedAtTC3 < 3))
                        {
                            this.target = this.Waypoint;
                            this.Attacking = false;
                            this.Hunting = true;
                            this.Reposition = false;
                        }
                        if (this.target.name.Contains("TC4") && (this.PissedAtTC4 < 3))
                        {
                            this.target = this.Waypoint;
                            this.Attacking = false;
                            this.Hunting = true;
                            this.Reposition = false;
                        }
                        if (this.target.name.Contains("TC7") && (this.PissedAtTC7 < 3))
                        {
                            this.target = this.Waypoint;
                            this.Attacking = false;
                            this.Hunting = true;
                            this.Reposition = false;
                        }
                        if (this.target.name.Contains("TC8") && (this.PissedAtTC8 < 3))
                        {
                            this.target = this.Waypoint;
                            this.Attacking = false;
                            this.Hunting = true;
                            this.Reposition = false;
                        }
                        if (this.target.name.Contains("TC9") && (this.PissedAtTC9 < 3))
                        {
                            this.target = this.Waypoint;
                            this.Attacking = false;
                            this.Hunting = true;
                            this.Reposition = false;
                        }
                    }
                    if (Physics.Linecast(this.Overview.position, this.target.position, (int) this.targetLayers))
                    {
                        this.Reposition = true;
                        this.CanLaunch = 0;
                    }
                    this.Stranger = this.target;
                }
                else
                {
                    if (SlavuicNetwork.TC0aDeathRow > 0)
                    {
                        this.PissedAtTC0a = 4;
                        if (SlavuicNetwork.target)
                        {
                            if (SlavuicNetwork.target.name.Contains("TC0a") && SlavuicNetwork.Confirmed)
                            {
                                if (this.Watchmen || this.Mistitor)
                                {
                                    this.target = SlavuicNetwork.target;
                                    this.Hunting = false;
                                    this.Attacking = true;
                                }
                            }
                        }
                    }
                    if (SlavuicNetwork.TC1DeathRow > 0)
                    {
                        if (SlavuicNetwork.TC1DeathRow < 600)
                        {
                            this.PissedAtTC1 = 4;
                            if (SlavuicNetwork.target)
                            {
                                if (SlavuicNetwork.target.name.Contains("TC1") && SlavuicNetwork.Confirmed)
                                {
                                    if (this.Watchmen || this.Mistitor)
                                    {
                                        this.target = SlavuicNetwork.target;
                                        this.Hunting = false;
                                        this.Attacking = true;
                                    }
                                }
                            }
                        }
                    }
                    if (SlavuicNetwork.TC3DeathRow > 0)
                    {
                        this.PissedAtTC3 = 4;
                        if (SlavuicNetwork.target)
                        {
                            if (SlavuicNetwork.target.name.Contains("TC3") && SlavuicNetwork.Confirmed)
                            {
                                if (this.Watchmen || this.Mistitor)
                                {
                                    this.target = SlavuicNetwork.target;
                                    this.Hunting = false;
                                    this.Attacking = true;
                                }
                            }
                        }
                    }
                    if (SlavuicNetwork.TC4DeathRow > 0)
                    {
                        this.PissedAtTC4 = 4;
                        if (SlavuicNetwork.target)
                        {
                            if (SlavuicNetwork.target.name.Contains("TC4") && SlavuicNetwork.Confirmed)
                            {
                                if (this.Watchmen || this.Mistitor)
                                {
                                    this.target = SlavuicNetwork.target;
                                    this.Hunting = false;
                                    this.Attacking = true;
                                }
                            }
                        }
                    }
                    if (SlavuicNetwork.TC6DeathRow > 0)
                    {
                        this.PissedAtTC6 = 4;
                        if (SlavuicNetwork.target)
                        {
                            if (SlavuicNetwork.target.name.Contains("TC6") && SlavuicNetwork.Confirmed)
                            {
                                if (this.Watchmen || this.Mistitor)
                                {
                                    this.target = SlavuicNetwork.target;
                                    this.Hunting = false;
                                    this.Attacking = true;
                                }
                            }
                        }
                    }
                    if (SlavuicNetwork.TC7DeathRow > 0)
                    {
                        this.PissedAtTC7 = 4;
                        if (SlavuicNetwork.target)
                        {
                            if (SlavuicNetwork.target.name.Contains("TC7") && SlavuicNetwork.Confirmed)
                            {
                                if (this.Watchmen || this.Mistitor)
                                {
                                    this.target = SlavuicNetwork.target;
                                    this.Hunting = false;
                                    this.Attacking = true;
                                }
                            }
                        }
                    }
                    if (SlavuicNetwork.TC8DeathRow > 0)
                    {
                        this.PissedAtTC8 = 4;
                        if (SlavuicNetwork.target)
                        {
                            if (SlavuicNetwork.target.name.Contains("TC8") && SlavuicNetwork.Confirmed)
                            {
                                if (this.Watchmen || this.Mistitor)
                                {
                                    this.target = SlavuicNetwork.target;
                                    this.Hunting = false;
                                    this.Attacking = true;
                                }
                            }
                        }
                    }
                    if (SlavuicNetwork.TC9DeathRow > 0)
                    {
                        this.PissedAtTC9 = 4;
                        if (SlavuicNetwork.target)
                        {
                            if (SlavuicNetwork.target.name.Contains("TC9") && SlavuicNetwork.Confirmed)
                            {
                                if (this.Watchmen || this.Mistitor)
                                {
                                    this.target = SlavuicNetwork.target;
                                    this.Hunting = false;
                                    this.Attacking = true;
                                }
                            }
                        }
                    }
                }
            }
        }
        else
        {
            if (this.CanLaunch < 4)
            {
                this.CanLaunch = this.CanLaunch + 1;
            }
        }
        if (this.Attacking)
        {
            this.Trig.center = new Vector3(0, 0, 0);
            this.Trig.radius = 64;
            this.Trig.height = 64;
        }
        else
        {
            this.Trig.center = new Vector3(0, 0, 100);
            this.Trig.radius = 150;
            this.Trig.height = 500;
        }
        if (this.Stuck > 0)
        {
            this.Stuck = this.Stuck - 1;
        }
        if (this.Ogle > 0)
        {
            if ((Vector3.Distance(this.thisTransform.position, this.target.position) < 32) || (this.target == this.Waypoint))
            {
                this.Parked = true;
                this.Ogle = this.Ogle - 1;
            }
            if (this.Ogle == 1)
            {
                this.Parked = false;
                this.Reposition = false;
                this.target = this.Waypoint;
            }
        }
        if (this.LayingLow > 0)
        {
            this.LayingLow = this.LayingLow - 1;
            if (this.Fear)
            {
                if (this.target)
                {
                    if (Vector3.Distance(this.Fear.position, this.target.position) < 300)
                    {
                        this.LayingLow = this.LayingLow + 1;
                    }
                }
            }
        }
        if (this.PissedAtTC0a > 4)
        {
            this.PissedAtTC0a = 4;
        }
        if (this.PissedAtTC1 > 4)
        {
            if (SlavuicNetwork.TC1DeathRow < 240)
            {
                SlavuicNetwork.TC1DeathRow = 240;
            }
            this.PissedAtTC1 = 4;
        }
        if (this.PissedAtTC3 > 4)
        {
            SlavuicNetwork.TC3DeathRow = 240;
            this.PissedAtTC3 = 4;
        }
        if (this.PissedAtTC4 > 4)
        {
            SlavuicNetwork.TC4DeathRow = 240;
            this.PissedAtTC4 = 4;
        }
        if (this.PissedAtTC6 > 4)
        {
            this.PissedAtTC6 = 4;
        }
        if (this.PissedAtTC7 > 4)
        {
            SlavuicNetwork.TC7DeathRow = 240;
            this.PissedAtTC7 = 4;
        }
        if (this.PissedAtTC8 > 4)
        {
            SlavuicNetwork.TC8DeathRow = 240;
            this.PissedAtTC8 = 4;
        }
        if (this.PissedAtTC9 > 4)
        {
            SlavuicNetwork.TC9DeathRow = 240;
            this.PissedAtTC9 = 4;
        }
        this.Obstacle = false;
        //========================================================================================================================//
        //////////////////////////////////////////////////////[INTERACTION]/////////////////////////////////////////////////////////
        //========================================================================================================================//
        if (NotiScript.PiriNotis)
        {
            if (Vector3.Distance(this.thisTransform.position, PlayerInformation.instance.Pirizuka.position) < 128)
            {
                if (this.convNum < 99)
                {
                    if (!this.Attacking)
                    {
                        this.target = PlayerInformation.instance.PiriTarget;
                        this.Ogle = 20;
                    }
                    else
                    {
                        if (this.target)
                        {
                            if (this.target.name.Contains("TC1"))
                            {
                                this.target = PlayerInformation.instance.PiriTarget;
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
                        this.StartCoroutine(this.ProcessSpeech(TalkBubbleScript.myText, 0));
                    }
                }
                if (WorldInformation.pSpeech.name.Contains("b1"))
                {
                    if (Vector3.Distance(this.thisTransform.position, WorldInformation.pSpeech.position) < 64)
                    {
                        this.StartCoroutine(this.ProcessSpeech(TalkBubbleScript.myText, 1));
                    }
                }
                if (WorldInformation.pSpeech.name.Contains("c1"))
                {
                    if (Vector3.Distance(this.thisTransform.position, WorldInformation.pSpeech.position) < 128)
                    {
                        this.StartCoroutine(this.ProcessSpeech(TalkBubbleScript.myText, 2));
                    }
                }
                WorldInformation.pSpeech = null;
            }
        }
    }

    public virtual IEnumerator SlavSquat()
    {
        if (this.target)
        {
            if (this.Slavuic1Body)
            {
                Vector3 relativePoint = this.thisVTransform.InverseTransformPoint(this.target.position);
                float LAndR = relativePoint.x;
                float FAndB = relativePoint.y;
                if (this.Attacking)
                {
                    if (Vector3.Distance(this.thisTransform.position, this.target.position) < 100)
                    {
                        this.CanLaunch = 0;
                        this.slavTarget = this.target;
                        if (this.slavAim < 0.12f)
                        {
                            this.slavAim = this.slavAim + 0.001f;
                        }
                        else
                        {
                            if (this.slavAim < 1)
                            {
                                this.slavAim = this.slavAim + 0.05f;
                            }
                        }
                        if (!this.Slav1Up)
                        {
                            this.Slavuic1Gun.SetActive(true);
                            this.Slavuic1GunS.Firing = true;
                            this.Slavuic1Ani.CrossFade("Slav1Situp", 0.3f);
                            this.Slavuic1BodyJ.connectedAnchor = this.Slavuic1Pos2.localPosition;
                            yield return new WaitForSeconds(0.3f);
                            this.Slav1Up = true;
                        }
                        if (this.Slav1Up)
                        {
                            if ((FAndB < 0) && (FAndB > -16))
                            {
                                if (LAndR > 0)
                                {
                                    this.Slavuic1Ani.CrossFade("Slav1SitupR", 0.5f);
                                    this.Slavuic1BodyJ.connectedAnchor = this.Slavuic1Pos3.localPosition;
                                }
                                else
                                {
                                    this.Slavuic1Ani.CrossFade("Slav1SitupL", 0.5f);
                                    this.Slavuic1BodyJ.connectedAnchor = this.Slavuic1Pos3.localPosition;
                                }
                            }
                            if (FAndB > 0)
                            {
                                this.Slavuic1Ani.CrossFade("Slav1SitupB", 0.5f);
                                this.Slavuic1BodyJ.connectedAnchor = this.Slavuic1Pos3.localPosition;
                            }
                            if (FAndB < -16)
                            {
                                this.Slavuic1Ani.CrossFade("Slav1Situp", 0.5f);
                                this.Slavuic1BodyJ.connectedAnchor = this.Slavuic1Pos2.localPosition;
                            }
                        }
                    }
                    else
                    {
                        this.slavTarget = this.Waypoint;
                        this.slavAim = 0.1f;
                        if (this.Slav1Up)
                        {
                            if (FAndB > 0)
                            {
                                this.Slavuic1Ani.CrossFade("Slav1SitupR", 0.3f);
                                yield return new WaitForSeconds(0.3f);
                                this.Slavuic1Gun.SetActive(false);
                                this.Slavuic1GunS.Firing = false;
                                this.Slavuic1BodyJ.connectedAnchor = this.Slavuic1Pos1.localPosition;
                                this.Slavuic1Ani.CrossFade("Slav1Sitdown", 0.3f);
                                this.Slav1Up = false;
                            }
                            else
                            {
                                this.Slavuic1Gun.SetActive(false);
                                this.Slavuic1GunS.Firing = false;
                                this.Slavuic1BodyJ.connectedAnchor = this.Slavuic1Pos1.localPosition;
                                this.Slavuic1Ani.CrossFade("Slav1Sitdown", 0.5f);
                                this.Slav1Up = false;
                            }
                        }
                    }
                }
                if (!this.Attacking)
                {
                    this.slavTarget = this.Waypoint;
                    this.slavAim = 0.1f;
                    if (this.Slav1Up)
                    {
                        if (FAndB > 0)
                        {
                            this.Slavuic1Ani.CrossFade("Slav1SitupR", 0.3f);
                            yield return new WaitForSeconds(0.25f);
                            this.Slavuic1Gun.SetActive(false);
                            this.Slavuic1GunS.Firing = false;
                            this.Slavuic1BodyJ.connectedAnchor = this.Slavuic1Pos1.localPosition;
                            this.Slavuic1Ani.CrossFade("Slav1Sitdown", 0.3f);
                            this.Slav1Up = false;
                        }
                        else
                        {
                            this.Slavuic1Gun.SetActive(false);
                            this.Slavuic1GunS.Firing = false;
                            this.Slavuic1BodyJ.connectedAnchor = this.Slavuic1Pos1.localPosition;
                            this.Slavuic1Ani.CrossFade("Slav1Sitdown", 0.5f);
                            this.Slav1Up = false;
                        }
                    }
                }
            }
        }
    }

    public virtual IEnumerator SenseTargDir()
    {
        float targPos = Vector3.Distance(this.thisTransform.position, this.target.position);
        yield return new WaitForSeconds(0.5f);
        float Towards = targPos - 8;
        if (this.target)
        {
            if (Vector3.Distance(this.thisTransform.position, this.target.position) < Towards)
            {
                this.Escape = true;
            }
            else
            {
                if (Vector3.Distance(this.thisTransform.position, this.target.position) > 700)
                {
                    this.Escape = false;
                }
            }
        }
    }

    public virtual IEnumerator IsEscaping(Vector3 lastPos)
    {
        yield return new WaitForSeconds(1);
        if (((Vector3.Distance(this.thisTransform.position, lastPos) < 0.2f) && !this.IsClose) && !this.Parked)
        {
            this.Stuck = 5;
        }
    }

    //========================================================================================================================//
    //////////////////////////////////////////////////////[INTERACTION]/////////////////////////////////////////////////////////
    //========================================================================================================================//
    public int convNum;
    public int boredom;
    public virtual IEnumerator ProcessSpeech(string speech, int mode)
    {
        yield return new WaitForSeconds(0.1f);
        if (!!string.IsNullOrEmpty(speech))
        {
            yield break;
        }
        if (mode == 0)
        {
            if (this.convNum == 0)
            {
                //===============================================================================
                if (this.HasSpace)
                {
                    if ((speech.Contains("hi") || speech.Contains("hey")) || speech.Contains("yo"))
                    {
                        this.convNum = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Hello stranger! You need a lift?");
                        yield break;
                    }
                    if (speech.Contains("hello") || speech.Contains("greet"))
                    {
                        this.convNum = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Privet! You look lost. \n You need a ride?");
                        yield break;
                    }
                    if (speech.Contains("in") || speech.Contains("on"))
                    {
                        this.convNum = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("You want a ride?");
                        yield break;
                    }
                    if (speech.Contains("ride") || speech.Contains("lift"))
                    {
                        this.convNum = 11;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Alright tovarishch! \n There is space for you.");
                        this.vEntrance.DenyEntrance = false;
                        yield break;
                    }
                }
                else
                {
                    if ((speech.Contains("hi") || speech.Contains("hey")) || speech.Contains("yo"))
                    {
                        this.convNum = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Hello stranger! You want something?");
                        yield break;
                    }
                    if (speech.Contains("hello") || speech.Contains("greet"))
                    {
                        this.convNum = 1;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Privet! You look lost.");
                        yield break;
                    }
                }
                if (speech.Contains("blyat"))
                {
                    this.convNum = 12;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Oh, a Thilian with basic slav skills! \n Now, do you need something?");
                    yield break;
                }
                if (speech.Contains("cyka"))
                {
                    this.convNum = 11;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Blyat!");
                    yield break;
                }
                if (speech.Contains("stop"))
                {
                    this.convNum = 11;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Yes, we are stopping.");
                    yield break;
                }
            }
            //===============================================================================
            if (this.convNum == 1)
            {
                //===============================================================================
                if (speech.Contains("yes"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Ok, There's room for you.");
                    yield break;
                }
                if (speech.Contains("no"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Okey. Was there something else?");
                    yield break;
                }
                if (this.HasSpace)
                {
                    if (speech.Contains("in") || speech.Contains("on"))
                    {
                        this.convNum = 2;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Blin!");
                        this.vEntrance.DenyEntrance = false;
                        yield break;
                    }
                    if (speech.Contains("ride") || speech.Contains("lift"))
                    {
                        this.convNum = 2;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Yes, just jump in.");
                        this.vEntrance.DenyEntrance = false;
                        yield break;
                    }
                    if (speech.Contains("blyat"))
                    {
                        this.convNum = 2;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Yes, yes. \n Now do you want a lift or not?");
                        yield break;
                    }
                }
                if (speech.Contains("cyka"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Ok, so you know basic slav language. \n Now what do you want?");
                    yield break;
                }
                if (speech.Contains("go"))
                {
                    this.convNum = 2;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Well then.");
                    yield break;
                }
                if (speech.Contains("drive"))
                {
                    this.convNum = 2;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Ok.");
                    yield break;
                }
                if (speech.Contains("stop"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Ok, friend.");
                    yield break;
                }
            }
            //===============================================================================
            if (this.convNum == 11)
            {
                //===============================================================================
                if (speech.Contains("yes"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("What is it?");
                    yield break;
                }
                if (speech.Contains("no"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Wait, what?");
                    yield break;
                }
                if (this.HasSpace)
                {
                    if (speech.Contains("in") || speech.Contains("on"))
                    {
                        this.convNum = 2;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Blin!");
                        this.vEntrance.DenyEntrance = false;
                        yield break;
                    }
                    if (speech.Contains("ride") || speech.Contains("lift"))
                    {
                        this.convNum = 2;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Yes, just jump in.");
                        this.vEntrance.DenyEntrance = false;
                        yield break;
                    }
                    if (speech.Contains("blyat"))
                    {
                        this.convNum = 2;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Yes, yes. \n Now do you want a lift or not?");
                        yield break;
                    }
                }
                if (speech.Contains("cyka"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Ok, so you know basic slav language. \n Now what do you want?");
                    yield break;
                }
                if (speech.Contains("stop"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Ok, friend.");
                    yield break;
                }
            }
            //===============================================================================
            if (this.convNum == 12)
            {
                //===============================================================================
                if (speech.Contains("yes"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("What is it?");
                    yield break;
                }
                if (speech.Contains("no"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Okey. Was there something else?");
                    yield break;
                }
                if (this.HasSpace)
                {
                    if (speech.Contains("in") || speech.Contains("on"))
                    {
                        this.convNum = 2;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Blin!");
                        yield break;
                    }
                    if (speech.Contains("ride") || speech.Contains("lift"))
                    {
                        this.convNum = 2;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Yes, just jump in.");
                        this.vEntrance.DenyEntrance = false;
                        yield break;
                    }
                    if (speech.Contains("blyat"))
                    {
                        this.convNum = 2;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Yes, yes. \n Now do you want a lift or not?");
                        yield break;
                    }
                }
                if (speech.Contains("cyka"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Ok, so you know basic slav language. \n Now what do you want?");
                    yield break;
                }
                if (speech.Contains("stop"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Ok, friend.");
                    yield break;
                }
            }
            //===============================================================================
            if (this.convNum == 13)
            {
                //===============================================================================
                if (speech.Contains("yes"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech(". . .");
                    yield break;
                }
                if (speech.Contains("no"))
                {
                    this.convNum = 3;
                    yield return new WaitForSeconds(4);
                    this.ReturnSpeech("What is wrong with you?");
                    yield break;
                }
                if (speech.Contains("in") || speech.Contains("on"))
                {
                    this.convNum = 3;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Do it, you cyka!");
                    this.vEntrance.DenyEntrance = false;
                    yield break;
                }
                if (speech.Contains("ride") || speech.Contains("lift"))
                {
                    this.convNum = 3;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Just do it already!");
                    this.vEntrance.DenyEntrance = false;
                    yield break;
                }
                if (speech.Contains("blyat"))
                {
                    this.convNum = 3;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Haha... Very funny cyka nahui.");
                    yield break;
                }
                if (speech.Contains("cyka"))
                {
                    this.convNum = 4;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Oh, so you know basic slav language. \n That's great...");
                    yield break;
                }
                if (speech.Contains("stop"))
                {
                    this.convNum = 3;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Alright. We'll stop here.");
                    yield break;
                }
            }
            //===============================================================================
            if (this.convNum == 14)
            {
                //===============================================================================
                if (speech.Contains("yes"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech(". . .");
                    yield break;
                }
                if (speech.Contains("no"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(4);
                    this.ReturnSpeech(". . .");
                    yield break;
                }
                if (speech.Contains("in") || speech.Contains("lift"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("You already got your chance!");
                    yield break;
                }
                if (speech.Contains("ride") || speech.Contains("on"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("I think I'll pass on that now.");
                    yield break;
                }
                if (speech.Contains("blyat"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Piss off, idi nahui!");
                    yield break;
                }
                if (speech.Contains("cyka"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("You too.");
                    yield break;
                }
                if (speech.Contains("stop"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Go bug somebody else.");
                    yield break;
                }
            }
            //===============================================================================
            if (this.convNum == 2)
            {
                //===============================================================================
                if (speech.Contains("yes"))
                {
                    this.convNum = 13;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Ok, what is it?");
                    yield break;
                }
                if (speech.Contains("no"))
                {
                    this.convNum = 3;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Ok.");
                    yield break;
                }
                if (speech.Contains("in") || speech.Contains("on"))
                {
                    this.convNum = 3;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("I do not have all day.");
                    this.vEntrance.DenyEntrance = false;
                    yield break;
                }
                if (speech.Contains("ride") || speech.Contains("lift"))
                {
                    this.convNum = 3;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Ok, I do not have all day.");
                    this.vEntrance.DenyEntrance = false;
                    yield break;
                }
                if (speech.Contains("blyat"))
                {
                    this.convNum = 3;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Well, I'll be off now.");
                    yield break;
                }
                if (speech.Contains("cyka"))
                {
                    this.convNum = 3;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech(". . .");
                    yield break;
                }
                if (speech.Contains("go"))
                {
                    this.convNum = 3;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Yes, yes.");
                    yield break;
                }
                if (speech.Contains("drive"))
                {
                    this.convNum = 3;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Yes, yes.");
                    yield break;
                }
                if (speech.Contains("stop"))
                {
                    this.convNum = 3;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Alright. We'll stop here.");
                    yield break;
                }
            }
            //===============================================================================
            if (this.convNum == 21)
            {
                //===============================================================================
                if (speech.Contains("hi"))
                {
                    this.convNum = 4;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech(". . .");
                    yield break;
                }
                if (speech.Contains("hello"))
                {
                    this.convNum = 4;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech(". . .");
                    yield break;
                }
                if (speech.Contains("in") || speech.Contains("on"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Proshchay, idi nahui!");
                    yield break;
                }
                if (speech.Contains("ride") || speech.Contains("lift"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("You know what? Yob tvoyu mat!");
                    yield break;
                }
                if (speech.Contains("blyat"))
                {
                    this.convNum = 4;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Shut up, Thili cyka!");
                    yield break;
                }
                if (speech.Contains("cyka"))
                {
                    this.convNum = 4;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Stop embarrassing yourself.");
                    yield break;
                }
                if (speech.Contains("stop"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Leave!");
                    yield break;
                }
            }
            //===============================================================================
            if (this.convNum == 3)
            {
                //===============================================================================
                if ((speech.Contains("hi") || speech.Contains("hey")) || speech.Contains("yo"))
                {
                    this.convNum = 14;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("State your business! \n I do not have all day.");
                    yield break;
                }
                if (speech.Contains("hello") || speech.Contains("greet"))
                {
                    this.convNum = 14;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Just state what you want already!");
                    yield break;
                }
                if (speech.Contains("in") || speech.Contains("on"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("How about no.");
                    yield break;
                }
                if (speech.Contains("ride") || speech.Contains("lift"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Pick another ride. \n You already got one chance.");
                    yield break;
                }
                if (speech.Contains("stop"))
                {
                    this.convNum = 21;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Alright! \n Now get on with it, blyat!");
                    yield break;
                }
                this.convNum = 4;
                this.boredom = 4;
                this.Ogle = 2;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Goodbye!");
                yield break;
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
                if ((speech.Contains("hi") || speech.Contains("hey")) || speech.Contains("yo"))
                {
                    this.convNum = 1;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Hello stranger! You need something?");
                    yield break;
                }
                if (speech.Contains("hello") || speech.Contains("greet"))
                {
                    this.convNum = 1;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Privet! You look lost. \n You want directions?");
                    yield break;
                }
                if (speech.Contains("in") || speech.Contains("on"))
                {
                    this.convNum = 1;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Wait, what?");
                    yield break;
                }
                if (speech.Contains("ride") || speech.Contains("lift"))
                {
                    this.convNum = 11;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("What, yours is broken?");
                    yield break;
                }
                if (speech.Contains("blyat"))
                {
                    this.convNum = 12;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Oh, a Thilian with basic slav skills! \n Now, do you need something?");
                    yield break;
                }
                if (speech.Contains("cyka"))
                {
                    this.convNum = 11;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Blyat!");
                    yield break;
                }
                if (speech.Contains("stop"))
                {
                    this.convNum = 11;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Yes, we are stopping.");
                    yield break;
                }
            }
            //===============================================================================
            if (this.convNum == 1)
            {
                //===============================================================================
                if (speech.Contains("yes"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Ok, What is it?");
                    yield break;
                }
                if (speech.Contains("no"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Okey. Was there something else?");
                    yield break;
                }
                if (speech.Contains("in") || speech.Contains("on"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Blin!");
                    this.vEntrance.DenyEntrance = false;
                    yield break;
                }
                if (speech.Contains("ride") || speech.Contains("lift"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Well then, go ahead.");
                    this.vEntrance.DenyEntrance = false;
                    yield break;
                }
                if (speech.Contains("blyat"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Yes, yes. \n Now what do want?");
                    yield break;
                }
                if (speech.Contains("cyka"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Ok, so you know basic slav language. \n Now what do you want?");
                    yield break;
                }
                if (speech.Contains("go"))
                {
                    this.convNum = 2;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Well then.");
                    yield break;
                }
                if (speech.Contains("drive"))
                {
                    this.convNum = 2;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Ok.");
                    yield break;
                }
            }
            //===============================================================================
            if (this.convNum == 11)
            {
                //===============================================================================
                if (speech.Contains("yes"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("What is it?");
                    yield break;
                }
                if (speech.Contains("no"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Wait, what?");
                    yield break;
                }
                if (speech.Contains("in") || speech.Contains("on"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Blin!");
                    this.vEntrance.DenyEntrance = false;
                    yield break;
                }
                if (this.HasSpace)
                {
                    if (speech.Contains("ride") || speech.Contains("lift"))
                    {
                        this.convNum = 2;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Well, jump out and get in!");
                        this.vEntrance.DenyEntrance = false;
                        yield break;
                    }
                }
                if (speech.Contains("blyat"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Is that all you wanted to say?");
                    yield break;
                }
                if (speech.Contains("cyka"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Ok, so you know basic slav language. \n Now what do you want?");
                    yield break;
                }
            }
            //===============================================================================
            if (this.convNum == 12)
            {
                //===============================================================================
                if (speech.Contains("yes"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("What is it?");
                    yield break;
                }
                if (speech.Contains("no"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Okey. Was there something else?");
                    yield break;
                }
                if (speech.Contains("in") || speech.Contains("on"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Blin!");
                    this.vEntrance.DenyEntrance = false;
                    yield break;
                }
                if (this.HasSpace)
                {
                    if (speech.Contains("ride") || speech.Contains("lift"))
                    {
                        this.convNum = 2;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Yes, just jump in.");
                        this.vEntrance.DenyEntrance = false;
                        yield break;
                    }
                }
                if (speech.Contains("blyat"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Is that all you wanted to say?");
                    yield break;
                }
                if (speech.Contains("cyka"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Ok, so you know basic slav language. \n Now what do you want?");
                    yield break;
                }
            }
            //===============================================================================
            if (this.convNum == 13)
            {
                //===============================================================================
                if (speech.Contains("yes"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech(". . .");
                    yield break;
                }
                if (speech.Contains("no"))
                {
                    this.convNum = 3;
                    yield return new WaitForSeconds(4);
                    this.ReturnSpeech("What is wrong with you?");
                    yield break;
                }
                if (this.HasSpace)
                {
                    if (speech.Contains("in") || speech.Contains("on"))
                    {
                        this.convNum = 3;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Do it, you cyka!");
                        this.vEntrance.DenyEntrance = false;
                        yield break;
                    }
                    if (speech.Contains("ride") || speech.Contains("lift"))
                    {
                        this.convNum = 3;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Just do it already!");
                        this.vEntrance.DenyEntrance = false;
                        yield break;
                    }
                }
                if (speech.Contains("blyat"))
                {
                    this.convNum = 3;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Haha... Very funny cyka nahui.");
                    yield break;
                }
                if (speech.Contains("cyka"))
                {
                    this.convNum = 4;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Oh, so you know basic slav language. \n That's great...");
                    yield break;
                }
            }
            //===============================================================================
            if (this.convNum == 14)
            {
                //===============================================================================
                if (speech.Contains("yes"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech(". . .");
                    yield break;
                }
                if (speech.Contains("no"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(4);
                    this.ReturnSpeech(". . .");
                    yield break;
                }
                if (this.HasSpace)
                {
                    if (speech.Contains("in") || speech.Contains("lift"))
                    {
                        this.convNum = 4;
                        this.Ogle = 2;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("You already got your chance!");
                        yield break;
                    }
                }
                if (speech.Contains("ride") || speech.Contains("on"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("I think I'll pass on that now.");
                    yield break;
                }
                if (speech.Contains("blyat"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Piss off, idi nahui!");
                    yield break;
                }
                if (speech.Contains("cyka"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("You too.");
                    yield break;
                }
                if (speech.Contains("stop"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Go bug somebody else.");
                    yield break;
                }
            }
            //===============================================================================
            if (this.convNum == 2)
            {
                //===============================================================================
                if (speech.Contains("yes"))
                {
                    this.convNum = 13;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Ok, what is it?");
                    yield break;
                }
                if (speech.Contains("no"))
                {
                    this.convNum = 3;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Ok.");
                    yield break;
                }
                if (speech.Contains("in") || speech.Contains("on"))
                {
                    this.convNum = 3;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("I do not have all day.");
                    this.vEntrance.DenyEntrance = false;
                    yield break;
                }
                if (speech.Contains("ride") || speech.Contains("lift"))
                {
                    this.convNum = 3;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Ok, I do not have all day.");
                    this.vEntrance.DenyEntrance = false;
                    yield break;
                }
                if (speech.Contains("blyat"))
                {
                    this.convNum = 3;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Well, I'll be off now.");
                    yield break;
                }
                if (speech.Contains("cyka"))
                {
                    this.convNum = 3;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech(". . .");
                    yield break;
                }
                if (speech.Contains("go"))
                {
                    this.convNum = 3;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Yes, yes.");
                    yield break;
                }
                if (speech.Contains("drive"))
                {
                    this.convNum = 3;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Yes, yes.");
                    yield break;
                }
            }
            //===============================================================================
            if (this.convNum == 21)
            {
                //===============================================================================
                if (speech.Contains("hi"))
                {
                    this.convNum = 4;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech(". . .");
                    yield break;
                }
                if (speech.Contains("hello"))
                {
                    this.convNum = 4;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech(". . .");
                    yield break;
                }
                if (speech.Contains("in") || speech.Contains("on"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Proshchay, idi nahui!");
                    yield break;
                }
                if (speech.Contains("ride") || speech.Contains("lift"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("You know what? Yob tvoyu mat!");
                    yield break;
                }
                if (speech.Contains("blyat"))
                {
                    this.convNum = 4;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Shut up, Thili cyka!");
                    yield break;
                }
                if (speech.Contains("cyka"))
                {
                    this.convNum = 4;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Stop embarrassing yourself.");
                    yield break;
                }
                if (speech.Contains("stop"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Leave!");
                    yield break;
                }
            }
            //===============================================================================
            if (this.convNum == 3)
            {
                //===============================================================================
                if ((speech.Contains("hi") || speech.Contains("hey")) || speech.Contains("yo"))
                {
                    this.convNum = 14;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("State your business! \n I do not have all day.");
                    yield break;
                }
                if (speech.Contains("hello") || speech.Contains("greet"))
                {
                    this.convNum = 14;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Just state what you want already!");
                    yield break;
                }
                if (speech.Contains("in") || speech.Contains("on"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("How about no.");
                    yield break;
                }
                if (this.HasSpace)
                {
                    if (speech.Contains("ride") || speech.Contains("lift"))
                    {
                        this.convNum = 4;
                        this.Ogle = 2;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Pick another ride. \n You already got one chance.");
                        yield break;
                    }
                }
                if (speech.Contains("stop"))
                {
                    this.convNum = 21;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Alright! \n Now get on with it, blyat!");
                    yield break;
                }
                this.convNum = 4;
                this.boredom = 4;
                this.Ogle = 2;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Goodbye!");
                yield break;
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
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Opa!");
                    yield break;
                }
                if (speech.Contains("hello") || speech.Contains("greet"))
                {
                    this.convNum = 1;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Privet! \n You want something?");
                    yield break;
                }
                if (speech.Contains("in") || speech.Contains("on"))
                {
                    this.convNum = 1;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Wait, what?");
                    yield break;
                }
                if (speech.Contains("ride") || speech.Contains("lift"))
                {
                    this.convNum = 11;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("What, your vessel is kaput?");
                    yield break;
                }
                if (speech.Contains("blyat"))
                {
                    this.convNum = 12;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Oh, a Thilian with basic slav skills! \n Now, do you need something?");
                    yield break;
                }
                if (speech.Contains("cyka"))
                {
                    this.convNum = 11;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Blyat!");
                    yield break;
                }
                if (speech.Contains("stop"))
                {
                    this.convNum = 11;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Oy blyat. What now?");
                    yield break;
                }
            }
            //===============================================================================
            if (this.convNum == 1)
            {
                //===============================================================================
                if (speech.Contains("yes"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Ok, What is it?");
                    yield break;
                }
                if (speech.Contains("no"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Okey. Was there something else?");
                    yield break;
                }
                if (speech.Contains("in") || speech.Contains("on"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Blin!");
                    yield break;
                }
                if (this.HasSpace)
                {
                    if (speech.Contains("ride") || speech.Contains("lift"))
                    {
                        this.convNum = 2;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("What, you want a ride?");
                        yield break;
                    }
                }
                if (speech.Contains("blyat"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Yes, yes. \n Now what do you want?");
                    yield break;
                }
                if (speech.Contains("cyka"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Ok, so you know basic slav language. \n Now what do you want?");
                    yield break;
                }
                if (speech.Contains("go"))
                {
                    this.convNum = 2;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Well then.");
                    yield break;
                }
                if (speech.Contains("drive"))
                {
                    this.convNum = 2;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Ok.");
                    yield break;
                }
            }
            //===============================================================================
            if (this.convNum == 11)
            {
                //===============================================================================
                if (speech.Contains("yes"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("What is it?");
                    yield break;
                }
                if (speech.Contains("no"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Wait, what?");
                    yield break;
                }
                if (speech.Contains("in") || speech.Contains("on"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Blin!");
                    this.vEntrance.DenyEntrance = false;
                    yield break;
                }
                if (this.HasSpace)
                {
                    if (speech.Contains("ride") || speech.Contains("lift"))
                    {
                        this.convNum = 2;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Well, jump out and get in!");
                        this.vEntrance.DenyEntrance = false;
                        yield break;
                    }
                }
                if (speech.Contains("blyat"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Is that all you wanted to say?");
                    yield break;
                }
                if (speech.Contains("cyka"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Ok, so you know basic slav language. \n Now what do you want?");
                    yield break;
                }
            }
            //===============================================================================
            if (this.convNum == 12)
            {
                //===============================================================================
                if (speech.Contains("yes"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("What is it?");
                    yield break;
                }
                if (speech.Contains("no"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Okey. Was there something else?");
                    yield break;
                }
                if (speech.Contains("in") || speech.Contains("on"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Blin!");
                    this.vEntrance.DenyEntrance = false;
                    yield break;
                }
                if (this.HasSpace)
                {
                    if (speech.Contains("ride") || speech.Contains("lift"))
                    {
                        this.convNum = 2;
                        yield return new WaitForSeconds(2);
                        this.ReturnSpeech("Yes, just jump in.");
                        this.vEntrance.DenyEntrance = false;
                        yield break;
                    }
                }
                if (speech.Contains("blyat"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Is that all?");
                    yield break;
                }
                if (speech.Contains("cyka"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Ok, so you know basic slav language. \n Now what do you want?");
                    yield break;
                }
            }
            //===============================================================================
            if (this.convNum == 13)
            {
                //===============================================================================
                if (speech.Contains("yes"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech(". . .");
                    yield break;
                }
                if (speech.Contains("no"))
                {
                    this.convNum = 3;
                    yield return new WaitForSeconds(4);
                    this.ReturnSpeech("What is wrong with you?");
                    yield break;
                }
                if (speech.Contains("in") || speech.Contains("on"))
                {
                    this.convNum = 3;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Stop!");
                    yield break;
                }
                if (speech.Contains("ride") || speech.Contains("lift"))
                {
                    this.convNum = 3;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("I think we need to go.");
                    yield break;
                }
                if (speech.Contains("blyat"))
                {
                    this.convNum = 3;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Haha... Very funny cyka nahui.");
                    yield break;
                }
                if (speech.Contains("cyka"))
                {
                    this.convNum = 4;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Oh, so you know basic slav language. \n That's great...");
                    yield break;
                }
            }
            //===============================================================================
            if (this.convNum == 14)
            {
                //===============================================================================
                if (speech.Contains("yes"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech(". . .");
                    yield break;
                }
                if (speech.Contains("no"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(4);
                    this.ReturnSpeech(". . .");
                    yield break;
                }
                if (speech.Contains("in") || speech.Contains("lift"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("I think you can use yours \n as a bunker for now.");
                    yield break;
                }
                if (speech.Contains("ride") || speech.Contains("on"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("I think I'll pass on that now.");
                    yield break;
                }
                if (speech.Contains("blyat"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Piss off, idi nahui!");
                    yield break;
                }
                if (speech.Contains("cyka"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("You too.");
                    yield break;
                }
                if (speech.Contains("stop"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Go bug somebody else.");
                    yield break;
                }
            }
            //===============================================================================
            if (this.convNum == 2)
            {
                //===============================================================================
                if (speech.Contains("yes"))
                {
                    this.convNum = 13;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Ok, what is it?");
                    yield break;
                }
                if (speech.Contains("no"))
                {
                    this.convNum = 3;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Ok.");
                    yield break;
                }
                if (speech.Contains("in") || speech.Contains("on"))
                {
                    this.convNum = 3;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("I do not have all day.");
                    this.vEntrance.DenyEntrance = false;
                    yield break;
                }
                if (speech.Contains("ride") || speech.Contains("lift"))
                {
                    this.convNum = 3;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Ok, I do not have all day.");
                    this.vEntrance.DenyEntrance = false;
                    yield break;
                }
                if (speech.Contains("blyat"))
                {
                    this.convNum = 3;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Well, I'll be off now.");
                    yield break;
                }
                if (speech.Contains("cyka"))
                {
                    this.convNum = 3;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech(". . .");
                    yield break;
                }
                if (speech.Contains("go"))
                {
                    this.convNum = 3;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Yes, yes.");
                    yield break;
                }
                if (speech.Contains("drive"))
                {
                    this.convNum = 3;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Yes, yes.");
                    yield break;
                }
            }
            //===============================================================================
            if (this.convNum == 21)
            {
                //===============================================================================
                if (speech.Contains("hi"))
                {
                    this.convNum = 4;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech(". . .");
                    yield break;
                }
                if (speech.Contains("hello"))
                {
                    this.convNum = 4;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech(". . .");
                    yield break;
                }
                if (speech.Contains("in") || speech.Contains("on"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Proshchay, idi nahui!");
                    yield break;
                }
                if (speech.Contains("ride") || speech.Contains("lift"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("You know what? Yob tvoyu mat!");
                    yield break;
                }
                if (speech.Contains("blyat"))
                {
                    this.convNum = 4;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Shut up, Thili cyka!");
                    yield break;
                }
                if (speech.Contains("cyka"))
                {
                    this.convNum = 4;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Stop embarrassing yourself.");
                    yield break;
                }
                if (speech.Contains("stop"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Leave!");
                    yield break;
                }
            }
            //===============================================================================
            if (this.convNum == 3)
            {
                //===============================================================================
                if ((speech.Contains("hi") || speech.Contains("hey")) || speech.Contains("yo"))
                {
                    this.convNum = 14;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("State your business! \n I do not have all day.");
                    yield break;
                }
                if (speech.Contains("hello") || speech.Contains("greet"))
                {
                    this.convNum = 14;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Just state what you want already!");
                    yield break;
                }
                if (speech.Contains("in") || speech.Contains("on"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("How about no.");
                    yield break;
                }
                if (speech.Contains("ride") || speech.Contains("lift"))
                {
                    this.convNum = 4;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Pick another ride!");
                    yield break;
                }
                if (speech.Contains("stop"))
                {
                    this.convNum = 21;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Alright! \n Now get on with it, blyat!");
                    yield break;
                }
                this.convNum = 4;
                this.boredom = 4;
                this.Ogle = 2;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Goodbye!");
                yield break;
            }
        }
        //===============================================================================
        if (this.convNum == 5)
        {
            if (SlavuicNetwork.TC1DeathRow < 10)
            {
                if (mode < 2)
                {
                    //===============================================================================
                    if (speech.Contains("ok"))
                    {
                        this.convNum = 99;
                        yield return new WaitForSeconds(8);
                        this.ReturnSpeech("Provalivay!");
                        this.Ogle = 2;
                        this.Attacking = false;
                        this.PissedAtTC1 = 0;
                        yield break;
                    }
                    if (speech.Contains("sorry"))
                    {
                        this.convNum = 99;
                        yield return new WaitForSeconds(8);
                        this.ReturnSpeech("Ok, bug off cyka!");
                        this.Ogle = 2;
                        this.Attacking = false;
                        this.PissedAtTC1 = 0;
                        yield break;
                    }
                    if (speech.Contains("please"))
                    {
                        this.convNum = 99;
                        yield return new WaitForSeconds(8);
                        this.ReturnSpeech("Now stop bothering!");
                        this.Ogle = 2;
                        this.Attacking = false;
                        this.PissedAtTC1 = 0;
                        yield break;
                    }
                    if (speech.Contains("stop"))
                    {
                        this.convNum = 99;
                        yield return new WaitForSeconds(8);
                        this.ReturnSpeech("Try again and you'll be \n the one stopping, period!");
                        this.Ogle = 2;
                        this.Attacking = false;
                        this.PissedAtTC1 = 0;
                        yield break;
                    }
                    if (speech.Contains("excuse"))
                    {
                        this.convNum = 99;
                        yield return new WaitForSeconds(8);
                        this.ReturnSpeech("Ok, now fuck off pidor!");
                        this.Ogle = 2;
                        this.Attacking = false;
                        this.PissedAtTC1 = 0;
                        yield break;
                    }
                }
                else
                {
                    //===============================================================================
                    //===============================================================================
                    if (speech.Contains("ok"))
                    {
                        this.convNum = 6;
                        yield return new WaitForSeconds(4);
                        this.ReturnSpeech("Ok, what? \n You want a fair fight?");
                        this.Ogle = 2;
                        yield break;
                    }
                    if (speech.Contains("sorry"))
                    {
                        this.convNum = 6;
                        yield return new WaitForSeconds(4);
                        this.ReturnSpeech("Hahaha! Why don't you \n shoot us again, urod!");
                        this.Ogle = 2;
                        yield break;
                    }
                    if (speech.Contains("please"))
                    {
                        this.convNum = 6;
                        yield return new WaitForSeconds(4);
                        this.ReturnSpeech("Not buying it!");
                        this.Ogle = 2;
                        yield break;
                    }
                    if (speech.Contains("stop"))
                    {
                        this.convNum = 6;
                        yield return new WaitForSeconds(4);
                        this.ReturnSpeech("We'll stop once you stop!");
                        this.Ogle = 2;
                        yield break;
                    }
                    if (speech.Contains("excuse"))
                    {
                        this.convNum = 6;
                        yield return new WaitForSeconds(4);
                        this.ReturnSpeech("Yeah, once you \n fuck off blyat!");
                        this.Ogle = 2;
                        yield break;
                    }
                }
            }
            else
            {
                //===============================================================================
                //===============================================================================
                if (speech.Contains("ok"))
                {
                    this.convNum = 99;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(1);
                    this.ReturnSpeech("Poshel nahui!");
                    yield break;
                }
                if (speech.Contains("sorry"))
                {
                    this.convNum = 99;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Idi k chertu!");
                    yield break;
                }
                if (speech.Contains("please"))
                {
                    this.convNum = 99;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Zatkni cyka!");
                    yield break;
                }
                if (speech.Contains("stop"))
                {
                    this.convNum = 99;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(1);
                    this.ReturnSpeech("Eat blins urod!");
                    yield break;
                }
                if (speech.Contains("excuse"))
                {
                    this.convNum = 99;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Wanting us to excuse you now? \n Fuck off, idi nahui!");
                    yield break;
                }
            }
        }
        //===============================================================================
        if (this.convNum == 6)
        {
            if (SlavuicNetwork.TC1DeathRow < 10)
            {
                //===============================================================================
                if (speech.Contains("ok"))
                {
                    this.convNum = 99;
                    yield return new WaitForSeconds(4);
                    this.ReturnSpeech("I'll let you go, \n for now.");
                    this.Ogle = 2;
                    this.Attacking = false;
                    this.PissedAtTC1 = 0;
                    yield break;
                }
                if (speech.Contains("sorry"))
                {
                    this.convNum = 99;
                    yield return new WaitForSeconds(4);
                    this.ReturnSpeech("Don't do it again \n or you'll be sorry.");
                    this.Ogle = 2;
                    this.Attacking = false;
                    this.PissedAtTC1 = 0;
                    yield break;
                }
                if (speech.Contains("please"))
                {
                    this.convNum = 99;
                    yield return new WaitForSeconds(4);
                    this.ReturnSpeech("Ok, now stay away from us!");
                    this.Ogle = 2;
                    this.Attacking = false;
                    this.PissedAtTC1 = 0;
                    yield break;
                }
                if (speech.Contains("stop"))
                {
                    this.convNum = 99;
                    yield return new WaitForSeconds(4);
                    this.Ogle = 2;
                    this.Attacking = false;
                    this.PissedAtTC1 = 0;
                    yield break;
                }
                if (speech.Contains("excuse"))
                {
                    this.convNum = 99;
                    yield return new WaitForSeconds(4);
                    this.Ogle = 2;
                    this.Attacking = false;
                    this.PissedAtTC1 = 0;
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
                    this.Ogle = 2;
                    yield return new WaitForSeconds(1);
                    this.ReturnSpeech("Poshel nahui!");
                    yield break;
                }
                if (speech.Contains("sorry"))
                {
                    this.convNum = 99;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Idi k chertu!");
                    yield break;
                }
                if (speech.Contains("please"))
                {
                    this.convNum = 99;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Zatkni cyka!");
                    yield break;
                }
                if (speech.Contains("stop"))
                {
                    this.convNum = 99;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(1);
                    this.ReturnSpeech("Eat blins cyka!");
                    yield break;
                }
                if (speech.Contains("excuse"))
                {
                    this.convNum = 99;
                    this.Ogle = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Wanting us to excuse you now? \n Fuck off, idi nahui!");
                    yield break;
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
                    this.ReturnSpeech("Later, tovarishch!");
                    this.Ogle = 2;
                    yield break;
                }
            }
            //===============================================================================
            if (speech.Contains("fuck you"))
            {
                this.convNum = 99;
                this.Ogle = 2;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Well fuck you too idi nahui!");
                yield break;
            }
            if (speech.Contains("fuck off"))
            {
                this.convNum = 99;
                this.Ogle = 2;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Ok. Thili nahui");
                yield break;
            }
            if (speech.Contains("go away"))
            {
                this.convNum = 99;
                this.Ogle = 2;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Well then.");
                yield break;
            }
        }
        else
        {
            //===============================================================================
            if (this.boredom < 3)
            {
                if (((speech.Contains("bye") || speech.Contains("cya")) || speech.Contains("fare")) || speech.Contains("later"))
                {
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Ok.");
                    this.Ogle = 2;
                    yield break;
                }
            }
        }
        yield return new WaitForSeconds(2);
        if (this.boredom == 0)
        {
            this.ReturnSpeech("What?");
        }
        if (this.boredom == 1)
        {
            this.ReturnSpeech("What exactly do you want?");
            this.convNum = 1;
        }
        if (this.boredom == 2)
        {
            this.ReturnSpeech("Just get to the point. \n We can't stay here forever.");
            this.convNum = 1;
        }
        if (this.boredom == 3)
        {
            this.ReturnSpeech("Well, good luck out there.");
            this.convNum = 4;
            this.Ogle = 2;
        }
        if (this.boredom == 4)
        {
            this.ReturnSpeech("Just go away.");
            this.convNum = 4;
            this.Ogle = 2;
        }
        if (this.boredom == 5)
        {
            this.ReturnSpeech("I told you. Go away!");
            this.convNum = 4;
            this.Ogle = 2;
        }
        if (this.boredom == 6)
        {
            this.ReturnSpeech("If you don't leave now, \n I'll force you to!");
            this.convNum = 4;
            this.Ogle = 2;
        }
        if (this.boredom == 7)
        {
            this.ReturnSpeech("Pizdets!");
            this.convNum = 5;
            this.PissedAtTC1 = 4;
            this.Ogle = 2;
        }
        this.boredom = this.boredom + 1;
    }

    public virtual void ReturnSpeech(string yourText)
    {
        GameObject Load = ((GameObject) Resources.Load("Prefabs/TalkBubble", typeof(GameObject))) as GameObject;
        GameObject TGO = UnityEngine.Object.Instantiate(Load, this.thisTransform.position, Load.transform.rotation);
        TGO.name = "CFC5";
        TalkBubbleScript.myText = yourText;
        ((TalkBubbleScript) TGO.GetComponent(typeof(TalkBubbleScript))).source = this.thisVTransform;
    }

    public SlavuicVesselAI()
    {
        this.slavAim = 0.01f;
        this.gRayLength = 2;
        this.ObsStartY = 4;
        this.ObsStartZ = 0.1f;
        this.RightDist = 200;
        this.LeftDist = 200;
        this.TurnForce = 50;
        this.DirForce = 15;
        this.Catchup = 1;
        this.UniqueShootTime = 0.1f;
    }

}