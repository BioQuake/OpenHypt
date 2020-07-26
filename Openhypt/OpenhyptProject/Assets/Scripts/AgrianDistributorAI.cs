using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AgrianDistributorAI : MonoBehaviour
{
    public Transform target;
    public Transform Waypoint;
    public Transform Waypoint2;
    public Transform Ignore;
    public Transform AIAnchor;
    public Transform VantagePoint;
    public Transform TargetTrace;
    public Transform TargetLead;
    public SphereCollider TLCol;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Transform thisCTransform;
    public Rigidbody vRigidbody;
    public Transform VPoint;
    public Transform VPoint2;
    public Transform SPoint;
    public CapsuleCollider Trig;
    public StrongGyroStabilizer Gyro;
    public GameObject RearWing;
    public GameObject TopWing;
    public BigVesselRotator VesselRotator;
    public GameObject AttackSound;
    public Rigidbody CapRB;
    public AudioSource CapSFX;
    public ConfigurableJoint CapJoint;
    public GameObject DistributorRack;
    public GameObject DistributorRackPF;
    public bool isDistributing;
    public bool GroundClear;
    public bool Pursuing;
    public bool FoundBig;
    public bool FoundMedium;
    public bool FoundSmall;
    public int PissedAtTC0a;
    public int PissedAtTC1;
    public int PissedAtTC3;
    public int PissedAtTC4;
    public int PissedAtTC5;
    public int PissedAtTC6;
    public int PissedAtTC7;
    public int PissedAtTC8;
    public int PissedAtTC9;
    public int angerLevel;
    public int WatchTick;
    public int TrigTick;
    public int Orbit;
    public bool Stabilize;
    public bool InView;
    public bool OnHull;
    public bool Stop;
    public bool Obstacle;
    public bool Reverse;
    public bool TurnLeft;
    public bool TurnRight;
    public bool StrafeLeft;
    public bool StrafeRight;
    public bool Downtorque;
    public bool Uptorque;
    public bool Upforce;
    public bool LiftForce;
    public float UDist;
    public float DDist;
    public float RightDist;
    public float LeftDist;
    public float VelClamp;
    public float VelClamp2;
    public float velMag;
    public float angVelMag;
    public Vector3 localV;
    public int SlowSpeed;
    public float VarLength;
    public LayerMask targetLayers;
    public LayerMask OtargetLayers;
    public LayerMask MtargetLayers;
    public int DirForce;
    public int RayDist;
    public int ObsDist;
    public float targDist;
    public GameObject AccelSound;
    public GameObject DecelSound;
    public bool DecelOnce;
    public bool AccelOnce;
    public bool Tick;
    public virtual void Start()
    {
        this.InvokeRepeating("LeaveMarker", 1, 5);
        this.InvokeRepeating("Regenerator", 1, 0.5f);
        this.InvokeRepeating("CalcLead", 1, 0.15f);
        this.GetComponent<Rigidbody>().freezeRotation = true;
        this.target = this.Waypoint;
        this.velMag = 0.1f;
        this.UDist = 2048;
        this.DDist = 2048;
        this.Trig.center = new Vector3(0, 0, 450);
        this.Trig.radius = 500;
        this.Trig.height = 1000;
        KabrianLaw.KabrianPolicePresent = true;
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        if (this.target)
        {
            Vector3 relativePoint = this.thisVTransform.InverseTransformPoint(this.target.position);
            float FAndB = relativePoint.y;
            this.thisCTransform.position = this.thisVTransform.position;
            Vector3 WrelativePoint = this.thisCTransform.InverseTransformPoint(this.target.position);
            float UAndD = WrelativePoint.y;
        }
        Vector3 newRot = (this.VPoint2.forward * 0.6f).normalized;
        this.VelClamp = Mathf.Clamp(this.velMag * 0.01f, 1, 4);
        if (this.velMag > 20)
        {
            this.VPoint.transform.rotation = Quaternion.LookRotation(this.vRigidbody.velocity);
        }
        else
        {
            this.VPoint.transform.rotation = this.VPoint2.transform.rotation;
        }
        this.Obstacle = false;
        this.TurnRight = false;
        this.TurnLeft = false;
        this.StrafeRight = false;
        this.StrafeLeft = false;
        this.Reverse = false;
        Debug.DrawRay(this.VPoint.position + ((this.VPoint.right * this.RayDist) * 0.5f), this.VPoint.forward * this.ObsDist, Color.red);
        Debug.DrawRay(this.VPoint.position + ((-this.VPoint.right * this.RayDist) * 0.5f), this.VPoint.forward * this.ObsDist, Color.red);
        if (Physics.Raycast(this.VPoint.position + ((this.VPoint.right * this.RayDist) * 0.5f), this.VPoint.forward, this.ObsDist, (int) this.MtargetLayers) || Physics.Raycast(this.VPoint.position + ((-this.VPoint.right * this.RayDist) * 0.5f), this.VPoint.forward, this.ObsDist, (int) this.MtargetLayers))
        {
            this.Obstacle = true;
        }
        Debug.DrawRay(this.VPoint2.position, this.VPoint2.forward * 40, Color.red);
        if (Physics.Raycast(this.VPoint2.position, this.VPoint2.forward, out hit, 40, (int) this.MtargetLayers))
        {
            this.Reverse = true;
        }
        if (this.velMag > 64)
        {
            this.ObsDist = (int) this.velMag;
        }
        else
        {
            this.ObsDist = 64;
        }
        if (this.velMag > 16)
        {
            Debug.DrawRay(((this.VPoint2.position + (-this.VPoint2.forward * 10)) + (-this.VPoint2.up * 4)) + (this.VPoint2.right * this.RayDist), this.VPoint2.forward * this.velMag, Color.black);
            if (Physics.Raycast(((this.VPoint2.position + (-this.VPoint2.forward * 10)) + (-this.VPoint2.up * 4)) + (this.VPoint2.right * this.RayDist), this.VPoint2.forward, out hit, this.velMag, (int) this.MtargetLayers))
            {
                this.RightDist = hit.distance;
            }
            else
            {
                this.RightDist = 200;
            }
            Debug.DrawRay(((this.VPoint2.position + (-this.VPoint2.forward * 10)) + (-this.VPoint2.up * 4)) + (-this.VPoint2.right * this.RayDist), this.VPoint2.forward * this.velMag, Color.black);
            if (Physics.Raycast(((this.VPoint2.position + (-this.VPoint2.forward * 10)) + (-this.VPoint2.up * 4)) + (-this.VPoint2.right * this.RayDist), this.VPoint2.forward, out hit, this.velMag, (int) this.MtargetLayers))
            {
                this.LeftDist = hit.distance;
            }
            else
            {
                this.LeftDist = 200;
            }
        }
        else
        {
            Vector3 newRot2 = ((this.thisVTransform.up * -0.6f) + (this.thisTransform.right * 0.1f)).normalized;
            newRot2 = ((this.thisVTransform.up * -0.6f) + (this.thisVTransform.right * 0.2f)).normalized;
            Debug.DrawRay(((this.VPoint2.position + (-this.VPoint2.forward * 10)) + (-this.VPoint2.up * 4)) + (this.VPoint2.right * 15), newRot2 * 64, Color.black);
            if (Physics.Raycast(((this.VPoint2.position + (-this.VPoint2.forward * 10)) + (-this.VPoint2.up * 4)) + (this.VPoint2.right * 15), newRot2, out hit, 64, (int) this.MtargetLayers))
            {
                this.RightDist = hit.distance;
            }
            else
            {
                this.RightDist = 200;
            }
            newRot2 = ((this.thisVTransform.up * -0.6f) + (this.thisVTransform.right * -0.1f)).normalized;
            Debug.DrawRay(((this.VPoint2.position + (-this.VPoint2.forward * 10)) + (-this.VPoint2.up * 4)) + (-this.VPoint2.right * 15), newRot2 * 64, Color.black);
            if (Physics.Raycast(((this.VPoint2.position + (-this.VPoint2.forward * 10)) + (-this.VPoint2.up * 4)) + (-this.VPoint2.right * 15), newRot2, out hit, 64, (int) this.MtargetLayers))
            {
                this.LeftDist = hit.distance;
            }
            else
            {
                this.LeftDist = 200;
            }
        }
        if (this.RightDist > this.LeftDist)
        {
            this.TurnRight = true;
            this.StrafeRight = true;
        }
        if (this.LeftDist > this.RightDist)
        {
            this.TurnLeft = true;
            this.StrafeLeft = true;
        }
        float UpDist = 2f;
        Debug.DrawRay(this.VPoint2.position + (this.VPoint.up * 0.5f), this.VPoint.forward * this.velMag, Color.black);
        if (Physics.Raycast(this.VPoint2.position + (this.VPoint.up * 0.5f), this.VPoint.forward, out hit, this.velMag, (int) this.MtargetLayers))
        {
            UpDist = hit.distance;
        }
        Debug.DrawRay(this.VPoint2.position + (-this.VPoint.up * 0.5f), this.VPoint.forward * this.velMag, Color.black);
        if (Physics.Raycast(this.VPoint2.position + (-this.VPoint.up * 0.5f), this.VPoint.forward, out hit, this.velMag, (int) this.MtargetLayers))
        {
            float Angle = Mathf.Abs(UpDist - hit.distance);
            this.SlowSpeed = 200;
            if (Angle < 4)
            {
                this.SlowSpeed = 150;
            }
            if (Angle < 3.5f)
            {
                this.SlowSpeed = 100;
            }
            if (Angle < 3)
            {
                this.SlowSpeed = 50;
            }
            if (Angle < 2.5f)
            {
                this.SlowSpeed = 25;
            }
        }
        newRot = (-this.VPoint2.up * 0.6f).normalized;
        this.VarLength = 100;
        this.VarLength = this.VarLength + (-this.localV.y * 0.5f);
        this.VarLength = 100;
        Debug.DrawRay(this.VPoint2.position + (this.VPoint2.forward * this.VarLength), newRot * 40f, Color.blue);
        if (Physics.Raycast(this.VPoint2.position + (this.VPoint2.forward * this.VarLength), newRot, 40, (int) this.MtargetLayers))
        {
            this.Downtorque = false;
        }
        else
        {
            if (!this.GroundClear)
            {
                this.Downtorque = true;
            }
        }
        if (this.target)
        {
            if (this.target.name.Contains("TC"))
            {
                if (this.targDist < 48)
                {
                    this.Reverse = true;
                    this.Obstacle = true;
                }
                if (this.targDist > 1000)
                {
                    Debug.DrawRay(this.VPoint2.position + (this.VPoint2.forward * this.VarLength), newRot * 20f, Color.blue);
                    if (Physics.Raycast(this.VPoint2.position + (this.VPoint2.forward * this.VarLength), newRot, 20, (int) this.MtargetLayers))
                    {
                        this.Uptorque = true;
                        this.Upforce = true;
                    }
                    else
                    {
                        this.Uptorque = false;
                    }
                }
                else
                {
                    Debug.DrawRay(this.VPoint2.position + (this.VPoint2.forward * this.VarLength), newRot * 128, Color.blue);
                    if (Physics.Raycast(this.VPoint2.position + (this.VPoint2.forward * this.VarLength), newRot, 128, (int) this.MtargetLayers))
                    {
                        this.Uptorque = true;
                        this.Upforce = true;
                    }
                    else
                    {
                        this.Uptorque = false;
                    }
                }
            }
            else
            {
                Debug.DrawRay(this.VPoint2.position + (this.VPoint2.forward * this.VarLength), newRot * 20f, Color.blue);
                if (Physics.Raycast(this.VPoint2.position + (this.VPoint2.forward * this.VarLength), newRot, 20, (int) this.MtargetLayers))
                {
                    this.Uptorque = true;
                    this.Upforce = true;
                }
                else
                {
                    this.Uptorque = false;
                }
            }
            if (this.targDist < 100)
            {
                this.VesselRotator.RotateThreshold = 0.3f;
            }
            else
            {
                this.VesselRotator.RotateThreshold = 0.1f;
            }
        }
        if ((!this.TurnLeft && !this.TurnRight) && !this.Obstacle)
        {
            this.VesselRotator.TorqueForce = -80000;
        }
        if ((this.TurnLeft || this.TurnRight) || this.Obstacle)
        {
            this.VesselRotator.TorqueForce = 0;
        }
        if (Physics.Raycast(this.thisTransform.position, Vector3.down, 1000, (int) this.MtargetLayers))
        {
            this.GroundClear = false;
            this.vRigidbody.useGravity = true;
        }
        else
        {
            this.Downtorque = false;
            this.GroundClear = true;
            this.vRigidbody.useGravity = false;
        }
        if (this.localV.y > 1)
        {
            this.RearWing.gameObject.SetActive(false);
            this.TopWing.gameObject.SetActive(false);
        }
        else
        {
            this.RearWing.gameObject.SetActive(true);
            this.TopWing.gameObject.SetActive(true);
        }
        if (this.target)
        {
            if (this.target.name.Contains("xbT"))
            {
                if (this.targDist < 100)
                {
                    this.Upforce = true;
                }
            }
            if (this.target.name.Contains("bT"))
            {
                if (this.targDist < 50)
                {
                    this.Upforce = true;
                }
            }
        }
    }

    private Quaternion NewRotation;
    public virtual void FixedUpdate()
    {
        RaycastHit hit = default(RaycastHit);
        this.thisTransform.position = this.AIAnchor.position;
        this.thisTransform.rotation = this.AIAnchor.rotation;
        if (this.target)
        {
            this.targDist = Vector3.Distance(this.thisTransform.position, this.target.position);
            this.NewRotation = Quaternion.LookRotation(this.target.position - this.thisTransform.position);
            //----------------------------------------------------------------------------------------------------------------------------------------
            this.localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
            this.velMag = Mathf.Clamp(this.vRigidbody.velocity.magnitude, 8, 2048);
            this.angVelMag = this.vRigidbody.angularVelocity.magnitude;
            this.VelClamp2 = Mathf.Clamp(this.velMag, 125, 250);
            Debug.DrawRay((this.VPoint.position + (this.VPoint.forward * 10)) + (-this.VPoint.up * 3.5f), this.VPoint.forward * this.velMag, Color.white);
            if (Physics.Raycast((this.VPoint.position + (this.VPoint.forward * 10)) + (-this.VPoint.up * 3.5f), this.VPoint.forward, out hit, this.velMag, (int) this.OtargetLayers))
            {
                this.UDist = hit.distance;
            }
            else
            {
                this.UDist = 2048;
            }
            Debug.DrawRay((this.VPoint.position + (this.VPoint.forward * 10)) + (-this.VPoint.up * 4.5f), this.VPoint.forward * this.velMag, Color.white);
            if (Physics.Raycast((this.VPoint.position + (this.VPoint.forward * 10)) + (-this.VPoint.up * 4.5f), this.VPoint.forward, out hit, this.velMag, (int) this.OtargetLayers))
            {
                this.DDist = hit.distance;
            }
            else
            {
                this.DDist = 1024;
            }
            float DAngle = Mathf.Abs(this.UDist - this.DDist);
            if (DAngle < 2)
            {
                this.Obstacle = true;
            }
            Debug.DrawRay(this.VPoint.position + (this.SPoint.right * 10), (this.VPoint.forward * this.ObsDist) * 2, Color.red);
            Debug.DrawRay(this.VPoint.position + (-this.SPoint.right * 10), (this.VPoint.forward * this.ObsDist) * 2, Color.red);
            if (Physics.Raycast(this.VPoint.position + (this.SPoint.right * 10), this.VPoint.forward, this.ObsDist * 2, (int) this.OtargetLayers) || Physics.Raycast(this.VPoint.position + (-this.SPoint.right * 10), this.VPoint.forward, this.ObsDist * 2, (int) this.OtargetLayers))
            {
                this.Obstacle = true;
            }
            else
            {
                this.SPoint.Rotate(0, 0, 10);
            }
            if (this.RayDist < 40)
            {
                this.RayDist = this.RayDist + 2;
            }
            if (this.RayDist == 40)
            {
                this.RayDist = 2;
            }
            if (this.targDist > 1000)
            {
                Debug.DrawRay(this.VPoint2.position + (this.VPoint2.forward * 24.5f), Vector3.down * 16, Color.yellow);
                Debug.DrawRay(this.VPoint2.position + (-this.VPoint2.forward * 18), Vector3.down * 16, Color.yellow);
                Debug.DrawRay(this.VPoint2.position + (-this.VPoint2.up * 4), Vector3.down * 24, Color.yellow);
                if ((Physics.Raycast(this.VPoint2.position + (this.VPoint2.forward * 24.5f), Vector3.down, 16, (int) this.OtargetLayers) || Physics.Raycast(this.VPoint2.position + (-this.VPoint2.forward * 18), Vector3.down, 16, (int) this.OtargetLayers)) || Physics.Raycast(this.VPoint2.position + (-this.VPoint2.up * 4), Vector3.down, 24, (int) this.OtargetLayers))
                {
                    this.LiftForce = true;
                }
                else
                {
                    this.LiftForce = false;
                }
            }
            else
            {
                Debug.DrawRay(this.VPoint2.position + (this.VPoint2.forward * 24.5f), Vector3.down * 128, Color.yellow);
                Debug.DrawRay(this.VPoint2.position + (-this.VPoint2.forward * 18), Vector3.down * 128, Color.yellow);
                Debug.DrawRay(this.VPoint2.position + (-this.VPoint2.up * 4), Vector3.down * 120, Color.yellow);
                if ((Physics.Raycast(this.VPoint2.position + (this.VPoint2.forward * 24.5f), Vector3.down, 128, (int) this.OtargetLayers) || Physics.Raycast(this.VPoint2.position + (-this.VPoint2.forward * 18), Vector3.down, 128, (int) this.OtargetLayers)) || Physics.Raycast(this.VPoint2.position + (-this.VPoint2.up * 4), Vector3.down, 120, (int) this.OtargetLayers))
                {
                    this.LiftForce = true;
                }
                else
                {
                    this.LiftForce = false;
                }
            }
            if (!this.isDistributing)
            {
                if (-this.localV.y > 0)
                {
                    if (((!this.TurnLeft && !this.TurnRight) && !this.Obstacle) || this.InView)
                    {
                        if (this.targDist > 1000)
                        {
                            if (this.angVelMag < 1)
                            {
                                if (this.Upforce)
                                {
                                    if (this.velMag > 50)
                                    {
                                        this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * 10000, -this.thisVTransform.up * 20);
                                        this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * -10000, this.thisVTransform.up * 20);
                                    }
                                    else
                                    {
                                        this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * 1500, -this.thisVTransform.up * 20);
                                        this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * -1500, this.thisVTransform.up * 20);
                                    }
                                }
                                else
                                {
                                    if (this.velMag > 50)
                                    {
                                        this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * 3000, -this.thisVTransform.up * 20);
                                        this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * -3000, this.thisVTransform.up * 20);
                                    }
                                    else
                                    {
                                        this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * 1500, -this.thisVTransform.up * 20);
                                        this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * -1500, this.thisVTransform.up * 20);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (this.Upforce)
                            {
                                this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * 3000, -this.thisVTransform.up * 20);
                                this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * -3000, this.thisVTransform.up * 20);
                            }
                            else
                            {
                                this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * 1000, -this.thisVTransform.up * 20);
                                this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * -1000, this.thisVTransform.up * 20);
                            }
                        }
                    }
                }
                if (this.OnHull)
                {
                    this.Gyro.force = 4;
                }
                else
                {
                    if (-this.localV.y > 0)
                    {
                        this.Gyro.force = 400;
                    }
                    else
                    {
                        this.Gyro.force = 2000;
                    }
                }
            }
            else
            {
                this.Gyro.force = 1600;
            }
            if (this.localV.y > 0)
            {
                this.DirForce = 0;
            }
            if (!this.Reverse)
            {
                if (this.targDist < 64)
                {
                    this.vRigidbody.drag = 10;
                    if (!this.Obstacle)
                    {
                        this.DirForce = -1000;
                    }
                }
                else
                {
                    this.vRigidbody.drag = 0.1f;
                    if (!this.Obstacle)
                    {
                        this.DirForce = 1000;
                    }
                }
                if (!this.Obstacle)
                {
                    if ((-this.localV.y > 20) && (-this.localV.y < 350))
                    {
                        if (!this.Pursuing)
                        {
                            if (this.targDist > 64)
                            {
                                this.vRigidbody.drag = 0.1f;
                                if (!this.Stop)
                                {
                                    this.DirForce = 32000;
                                }
                                else
                                {
                                    this.DirForce = 8000;
                                }
                            }
                        }
                        else
                        {
                            if (this.targDist < 200)
                            {
                                this.vRigidbody.drag = 0.2f;
                                this.DirForce = 2000;
                            }
                            else
                            {
                                this.vRigidbody.drag = 0.1f;
                                this.DirForce = 16000;
                            }
                        }
                    }
                    if (this.localV.y > 1)
                    {
                        this.DirForce = 16000;
                    }
                }
                if (this.Obstacle)
                {
                    if (-this.localV.y > this.SlowSpeed)
                    {
                        if (-this.localV.y < 100)
                        {
                            if (-this.localV.y > 0)
                            {
                                this.DirForce = -8000;
                            }
                        }
                        else
                        {
                            this.DirForce = -32000;
                        }
                    }
                }
            }
            else
            {
                if (this.localV.y < 20)
                {
                    if (-this.localV.y > 20)
                    {
                        this.DirForce = -8000;
                    }
                    else
                    {
                        this.DirForce = -2000;
                    }
                    if (this.Obstacle)
                    {
                        if (-this.localV.y > 0)
                        {
                            this.DirForce = -32000;
                        }
                    }
                }
                this.vRigidbody.drag = 1;
            }
            this.thisTransform.rotation = Quaternion.RotateTowards(this.thisTransform.rotation, this.NewRotation, Time.deltaTime * 100);
            if ((-this.localV.y > 120) && !this.AccelOnce)
            {
                this.DecelOnce = false;
                this.AccelOnce = true;
                GameObject TheThing1 = UnityEngine.Object.Instantiate(this.AccelSound, this.thisTransform.position, this.thisTransform.rotation);
                TheThing1.transform.parent = this.thisTransform;
            }
            if ((-this.localV.y < 60) && !this.DecelOnce)
            {
                this.AccelOnce = false;
                this.DecelOnce = true;
                GameObject TheThing2 = UnityEngine.Object.Instantiate(this.DecelSound, this.thisTransform.position, this.thisTransform.rotation);
                TheThing2.transform.parent = this.thisTransform;
            }
            if (this.Stabilize)
            {
                this.vRigidbody.drag = 0.2f;
                this.vRigidbody.angularDrag = 8;
            }
            else
            {
                this.vRigidbody.angularDrag = 4;
                if (this.TurnRight)
                {
                    this.vRigidbody.AddTorque(-this.thisVTransform.forward * -64000);
                }
                if (this.TurnLeft)
                {
                    this.vRigidbody.AddTorque(-this.thisVTransform.forward * 64000);
                }
                if (this.StrafeRight)
                {
                    this.vRigidbody.AddForce(this.thisVTransform.right * 8000);
                }
                if (this.StrafeLeft)
                {
                    this.vRigidbody.AddForce(this.thisVTransform.right * -8000);
                }
                if (this.Uptorque)
                {
                    this.vRigidbody.AddTorque((-this.thisVTransform.right * 8000) * this.VelClamp);
                }
                if (this.Downtorque)
                {
                    this.vRigidbody.AddTorque(-this.thisVTransform.right * -8000);
                }
                if (this.Upforce && !this.LiftForce)
                {
                    this.vRigidbody.AddForce((this.thisVTransform.forward * this.VelClamp2) * 60);
                }
                if (this.LiftForce)
                {
                    this.vRigidbody.AddForce(Vector3.up * 8000);
                }
                if (this.target)
                {
                    if (this.OnHull)
                    {
                        this.Upforce = false;
                        bool UpTorque = false;
                        if (this.target.name.Contains("TC"))
                        {
                            this.vRigidbody.AddTorque(-this.thisVTransform.up * 16000);
                        }
                    }
                }
                if (!this.isDistributing)
                {
                    this.vRigidbody.AddForce(-this.thisVTransform.up * this.DirForce);
                }
                else
                {
                    if (this.Obstacle)
                    {
                        this.vRigidbody.AddForce(-this.thisVTransform.up * this.DirForce);
                    }
                }
            }
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().name.Contains("TFC1"))
        {
            Vector3 relativePoint0 = other.transform.InverseTransformPoint(this.thisTransform.position);
            float FAndB = relativePoint0.z;
            if (FAndB > 0)
            {
                this.PissedAtTC1 = this.PissedAtTC1 + 1;
            }
            if (this.TrigTick < 1)
            {
                this.Trig.center = new Vector3(0, 0, 0);
                this.Trig.radius = 250;
                this.Trig.height = 250;
            }
        }
        if (other.GetComponent<Collider>().name.Contains("TFC3"))
        {
            this.PissedAtTC3 = this.PissedAtTC3 + 1;
            if (this.TrigTick < 1)
            {
                this.Trig.center = new Vector3(0, 0, 0);
                this.Trig.radius = 250;
                this.Trig.height = 250;
            }
        }
        if (other.GetComponent<Collider>().name.Contains("TFC4"))
        {
            this.PissedAtTC4 = this.PissedAtTC4 + 1;
            if (this.TrigTick < 1)
            {
                this.Trig.center = new Vector3(0, 0, 0);
                this.Trig.radius = 250;
                this.Trig.height = 250;
            }
        }
        if (other.GetComponent<Collider>().name.Contains("TFC5"))
        {
            this.PissedAtTC5 = this.PissedAtTC5 + 1;
            if (this.TrigTick < 1)
            {
                this.Trig.center = new Vector3(0, 0, 0);
                this.Trig.radius = 250;
                this.Trig.height = 250;
            }
        }
        if (other.GetComponent<Collider>().name.Contains("TFC6"))
        {
            this.PissedAtTC6 = this.PissedAtTC6 + 1;
            if (this.TrigTick < 1)
            {
                this.Trig.center = new Vector3(0, 0, 0);
                this.Trig.radius = 250;
                this.Trig.height = 250;
            }
        }
        if (other.GetComponent<Collider>().name.Contains("TFC7"))
        {
            this.PissedAtTC7 = this.PissedAtTC7 + 1;
            if (this.TrigTick < 1)
            {
                this.Trig.center = new Vector3(0, 0, 0);
                this.Trig.radius = 250;
                this.Trig.height = 250;
            }
        }
        if (other.GetComponent<Collider>().name.Contains("TFC8"))
        {
            this.PissedAtTC8 = this.PissedAtTC8 + 1;
            if (this.TrigTick < 1)
            {
                this.Trig.center = new Vector3(0, 0, 0);
                this.Trig.radius = 250;
                this.Trig.height = 250;
            }
        }
        if (other.GetComponent<Collider>().name.Contains("TFC9"))
        {
            this.PissedAtTC9 = this.PissedAtTC9 + 1;
            if (this.TrigTick < 1)
            {
                this.Trig.center = new Vector3(0, 0, 0);
                this.Trig.radius = 250;
                this.Trig.height = 250;
            }
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        string ON = other.name;
        Transform OT = other.transform;
        if (this.Ignore)
        {
            if (OT == this.Ignore)
            {
                return;
            }
        }
        if (ON.Contains("TC"))
        {
            if (OT == AgrianNetwork.instance.SubdueTarget)
            {
                this.target = OT;
                this.Trig.center = new Vector3(0, 0, 0);
                this.Trig.radius = 32;
                this.Trig.height = 32;
                this.TrigTick = 0;
            }
        }
    }

    public virtual void LeaveMarker()
    {
        if (this.target)
        {
            Vector3 TlastPos = this.target.position;
        }
        if (this.Ignore)
        {
            Vector3 IlastPos = this.Ignore.position;
        }
        this.FoundSmall = false;
        this.FoundMedium = false;
        this.FoundBig = false;
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
            this.TargetLead.position = this.TargetLead.position + (((this.TargetLead.forward * Dist1) * Dist2) * 0.025f);
            if ((Vector3.Distance(this.TargetTrace.position, this.target.position) > 4) && (this.angerLevel > 100))
            {
                this.TLCol.radius = this.targDist * 0.03f;
                this.Pursuing = true;
            }
            else
            {
                this.TLCol.radius = this.targDist * 0.03f;
                this.Pursuing = false;
            }
        }
    }

    public virtual void Regenerator()
    {
        if (!this.target)
        {
            this.Trig.center = new Vector3(0, 0, 450);
            this.Trig.radius = 500;
            this.Trig.height = 1000;
        }
        if (AgrianNetwork.TC1CriminalLevel > 240)
        {
            this.PissedAtTC1 = 100;
        }
        if (AgrianNetwork.TC4CriminalLevel > 240)
        {
            this.PissedAtTC4 = 100;
        }
        if (AgrianNetwork.TC5CriminalLevel > 240)
        {
            this.PissedAtTC5 = 100;
        }
        if (AgrianNetwork.TC6CriminalLevel > 240)
        {
            this.PissedAtTC6 = 100;
        }
        if (AgrianNetwork.TC7CriminalLevel > 240)
        {
            this.PissedAtTC7 = 100;
        }
        if (AgrianNetwork.TC8CriminalLevel > 240)
        {
            this.PissedAtTC8 = 100;
        }
        if (AgrianNetwork.TC9CriminalLevel > 240)
        {
            this.PissedAtTC9 = 100;
        }
        if (this.WatchTick > 0)
        {
            this.WatchTick = this.WatchTick - 1;
        }
        if (this.angerLevel > 0)
        {
            this.angerLevel = this.angerLevel - 1;
        }
        if (this.target)
        {
            if (this.target.name.Contains("TC0a"))
            {
                if (this.PissedAtTC0a > 0)
                {
                    this.PissedAtTC0a = this.PissedAtTC0a - 1;
                }
            }
            if (this.target.name.Contains("TC1"))
            {
                if (this.PissedAtTC1 > 0)
                {
                    this.PissedAtTC1 = this.PissedAtTC1 - 1;
                    if (AgrianNetwork.TC1CriminalLevel > 320)
                    {
                        this.angerLevel = 110;
                    }
                }
            }
            if (this.target.name.Contains("TC3"))
            {
                if (this.PissedAtTC3 > 0)
                {
                    this.PissedAtTC3 = this.PissedAtTC3 - 1;
                    if (AgrianNetwork.TC5CriminalLevel > 320)
                    {
                        this.angerLevel = 110;
                    }
                }
            }
            if (this.target.name.Contains("TC4"))
            {
                if (this.PissedAtTC4 > 0)
                {
                    this.PissedAtTC4 = this.PissedAtTC4 - 1;
                    if (AgrianNetwork.TC4CriminalLevel > 320)
                    {
                        this.angerLevel = 110;
                    }
                }
            }
            if (this.target.name.Contains("TC5"))
            {
                if (this.PissedAtTC5 > 0)
                {
                    this.PissedAtTC5 = this.PissedAtTC5 - 1;
                    if (AgrianNetwork.TC5CriminalLevel > 320)
                    {
                        this.angerLevel = 110;
                    }
                }
            }
            if (this.target.name.Contains("TC6"))
            {
                if (this.PissedAtTC6 > 0)
                {
                    this.PissedAtTC6 = this.PissedAtTC6 - 1;
                    if (AgrianNetwork.TC6CriminalLevel > 320)
                    {
                        this.angerLevel = 110;
                    }
                }
            }
            if (this.target.name.Contains("TC7"))
            {
                if (this.PissedAtTC7 > 0)
                {
                    this.PissedAtTC7 = this.PissedAtTC7 - 1;
                    if (AgrianNetwork.TC7CriminalLevel > 320)
                    {
                        this.angerLevel = 110;
                    }
                }
            }
            if (this.target.name.Contains("TC8"))
            {
                if (this.PissedAtTC8 > 0)
                {
                    this.PissedAtTC8 = this.PissedAtTC8 - 1;
                    if (AgrianNetwork.TC8CriminalLevel > 320)
                    {
                        this.angerLevel = 110;
                    }
                }
            }
            if (this.target.name.Contains("TC9"))
            {
                if (this.PissedAtTC9 > 0)
                {
                    this.PissedAtTC9 = this.PissedAtTC9 - 1;
                    if (AgrianNetwork.TC9CriminalLevel > 320)
                    {
                        this.angerLevel = 110;
                    }
                }
            }
            if (this.target.name.Contains("mT"))
            {
                this.FoundMedium = true;
            }
            if (this.target.name.Contains("bT"))
            {
                this.FoundBig = true;
            }
            if (this.angerLevel > 75)
            {
                if (!Physics.Linecast(this.thisTransform.position, this.target.position, (int) this.MtargetLayers))
                {
                    this.InView = true;
                }
            }
            if (this.TrigTick > 0)
            {
                this.TrigTick = this.TrigTick - 1;
            }
            else
            {
                if ((this.angerLevel > 75) && this.target.name.Contains("TC"))
                {
                    this.Trig.center = new Vector3(0, 0, 0);
                    this.Trig.radius = 250;
                    this.Trig.height = 250;
                }
            }
            if (AgrianNetwork.TC1CriminalLevel > 500)
            {
                if (this.target.name.Contains("TC1"))
                {
                    if (this.targDist < 500)
                    {
                        if (!this.isDistributing)
                        {
                            this.isDistributing = true;
                            this.StartCoroutine(this.Distribute());
                        }
                    }
                }
                else
                {
                    this.Waypoint2.position = AgrianNetwork.instance.FullPriorityWaypoint.position;
                    this.target = this.Waypoint2;
                }
            }
        }
        if (this.angVelMag > 0.5f)
        {
            if (this.Orbit < 8)
            {
                this.Orbit = this.Orbit + 1;
            }
        }
        else
        {
            if (this.Orbit > 0)
            {
                this.Orbit = this.Orbit - 1;
            }
        }
        if (this.Orbit == 8)
        {
            this.Stop = true;
        }
        if (this.Orbit == 0)
        {
            this.Stop = false;
        }
        this.InView = false;
        this.Upforce = false;
        this.OnHull = false;
    }

    public virtual IEnumerator Distribute()
    {
        UnityEngine.Object.Destroy(this.CapJoint);
        this.CapRB.useGravity = true;
        this.CapRB.AddForce(-this.thisVTransform.up * 5000);
        this.CapSFX.Play();
        yield return new WaitForSeconds(0.7f);
        this.Stabilize = true;
        yield return new WaitForSeconds(0.7f);
        GameObject TheRack = UnityEngine.Object.Instantiate(this.DistributorRackPF, this.DistributorRack.transform.position, this.DistributorRack.transform.rotation);
        TheRack.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
        TheRack.GetComponent<Rigidbody>().AddForce(-this.DistributorRack.transform.up * 5000);
        this.DistributorRack.SetActive(false);
    }

    public AgrianDistributorAI()
    {
        this.DirForce = 200;
        this.RayDist = 2;
        this.ObsDist = 100;
    }

}