using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AgrianTurretAI : MonoBehaviour
{
    public Transform target;
    public Transform Waypoint;
    public Transform Waypoint2;
    public Transform Ignore;
    public Transform Hidden;
    public Transform VantagePoint;
    public Transform TargetTrace;
    public Transform TargetLead;
    public SphereCollider TLCol;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Transform thisCTransform;
    public Rigidbody vRigidbody;
    public Transform VesselTF;
    public GameObject VesselTip;
    public Transform VPoint;
    public Transform VPoint2;
    public Transform SPoint;
    public GameObject RayBurst;
    public Transform RaySpawn;
    public Transform RaySpawn2;
    public CapsuleCollider Trig;
    public StrongGyroStabilizer Gyro;
    public GameObject LTurret;
    public GameObject RTurret;
    public Transform LTMuzzle;
    public Transform RTMuzzle;
    public Transform LTPivot;
    public Transform RTPivot;
    public Transform LTBase;
    public Transform RTBase;
    public GameObject TurretShot;
    public GameObject RearWing;
    public GameObject TopWing;
    public BigVesselRotator VesselRotator;
    public bool PartOfCorvette;
    public GameObject TurretLight;
    public GameObject WarningLight;
    public GameObject AttackSound;
    public bool GroundClear;
    public bool Pursuing;
    public bool FoundBig;
    public bool FoundMedium;
    public bool FoundSmall;
    public bool Warning;
    public bool WarningLightOn;
    public bool NeedsTurrets;
    public int PissedAtTC0a;
    public int PissedAtTC1;
    public int PissedAtTC3;
    public int PissedAtTC5;
    public int PissedAtTC6;
    public int PissedAtTC7;
    public int PissedAtTC8;
    public int PissedAtTC9;
    public int DangerSense;
    public Vector3 DangerDirection;
    public int angerLevel;
    public int WatchTick;
    public int TargetStill;
    public int Orbit;
    public bool LTLineOfFire;
    public bool RTLineOfFire;
    public bool LineOfFire;
    public bool InView;
    public bool OnHull;
    public bool Stop;
    public bool Obstacle;
    public bool Reverse;
    public bool TurnLeft;
    public bool TurnRight;
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
    public Vector3 localAV;
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
        this.InvokeRepeating("Retreat", 60, 120);
        this.InvokeRepeating("LeaveMarker", 1, 5);
        this.InvokeRepeating("Regenerator", 1, 0.5f);
        this.InvokeRepeating("FireRay", 1, 3);
        this.InvokeRepeating("FireTurrets", 1, 1.2f);
        this.InvokeRepeating("CalcLead", 1, 0.15f);
        this.GetComponent<Rigidbody>().freezeRotation = true;
        this.target = this.Waypoint;
        if (this.PartOfCorvette)
        {
            this.Trig.center = new Vector3(0, 0, 450);
            this.Trig.radius = 500;
            this.Trig.height = 1000;
        }
        else
        {
            this.Trig.center = new Vector3(0, 0, 0);
            this.Trig.radius = 4000;
            this.Trig.height = 4000;
        }
        KabrianLaw.KabrianPolicePresent = true;
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        if (this.PartOfCorvette)
        {
            float FAndB = 0.0f;
            float UAndD = 0.0f;
            if (this.target)
            {
                Vector3 relativePoint = this.thisVTransform.InverseTransformPoint(this.target.position);
                FAndB = relativePoint.y;
                this.thisCTransform.position = this.thisVTransform.position;
                Vector3 WrelativePoint = this.thisCTransform.InverseTransformPoint(this.target.position);
                UAndD = WrelativePoint.y;
            }
            Vector3 newRot = (this.VPoint2.forward * 0.6f).normalized;
            this.VelClamp = Mathf.Clamp(this.velMag * 0.01f, 1, 4);
            if (this.velMag > 20)
            {
                this.VPoint.transform.rotation = Quaternion.LookRotation(this.GetComponent<Rigidbody>().velocity);
            }
            else
            {
                this.VPoint.transform.rotation = this.VPoint2.transform.rotation;
            }
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
            if (this.velMag > 16)
            {
                this.ObsDist = (int) this.velMag;
            }
            else
            {
                this.ObsDist = 16;
            }
            if (this.velMag > 5)
            {
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
                    Debug.DrawRay(((this.VPoint2.position + (-this.VPoint2.forward * 10)) + (-this.VPoint2.up * 4)) + (this.VPoint2.right * 15), this.VPoint2.forward * 16, Color.black);
                    if (Physics.Raycast(((this.VPoint2.position + (-this.VPoint2.forward * 10)) + (-this.VPoint2.up * 4)) + (this.VPoint2.right * 15), this.VPoint2.forward, out hit, 16, (int) this.MtargetLayers))
                    {
                        this.RightDist = hit.distance;
                    }
                    else
                    {
                        this.RightDist = 200;
                    }
                    Debug.DrawRay(((this.VPoint2.position + (-this.VPoint2.forward * 10)) + (-this.VPoint2.up * 4)) + (-this.VPoint2.right * 15), this.VPoint2.forward * 16, Color.black);
                    if (Physics.Raycast(((this.VPoint2.position + (-this.VPoint2.forward * 10)) + (-this.VPoint2.up * 4)) + (-this.VPoint2.right * 15), this.VPoint2.forward, out hit, 16, (int) this.MtargetLayers))
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
                }
                if (this.LeftDist > this.RightDist)
                {
                    this.TurnLeft = true;
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
                this.VarLength = 100;
            }
            if (this.target)
            {
                if (this.target.name.Contains("TC"))
                {
                    if (FAndB > -15)
                    {
                        this.Reverse = true;
                    }
                }
                if (Physics.Raycast(this.RaySpawn2.position, this.RaySpawn2.transform.forward, out hit, 10000, (int) this.targetLayers))
                {
                    if (hit.collider.name.Contains(this.target.name) || hit.collider.name.Contains("TL2"))
                    {
                        this.LineOfFire = true;
                    }
                }
                if ((this.VesselTF.localEulerAngles.x < 15) || (this.VesselTF.localEulerAngles.x > 335))
                {
                    this.LineOfFire = false;
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
                this.VesselTip.GetComponent<Rigidbody>().useGravity = true;
            }
            else
            {
                this.Downtorque = false;
                this.GroundClear = true;
                this.vRigidbody.useGravity = false;
                this.VesselTip.GetComponent<Rigidbody>().useGravity = false;
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
        else
        {
            if (this.target)
            {
                Debug.DrawRay(this.RaySpawn2.position, this.RaySpawn2.transform.forward * 10000f, Color.red);
                if (Physics.Raycast(this.RaySpawn2.position, this.RaySpawn2.transform.forward, out hit, 10000, (int) this.targetLayers))
                {
                    if (hit.collider.name.Contains(this.target.name))
                    {
                        this.LineOfFire = true;
                    }
                }
            }
        }
    }

    private Quaternion NewRotation;
    public virtual void FixedUpdate()
    {
        RaycastHit hit = default(RaycastHit);
        if (this.Warning)
        {
            this.Warning = false;
            this.WarningLightOn = true;
            this.WarningLight.gameObject.SetActive(true);
        }
        if (this.target)
        {
            this.targDist = Vector3.Distance(this.thisTransform.position, this.target.position);
            if (this.DangerSense < 1)
            {
                this.NewRotation = Quaternion.LookRotation(this.target.position - this.thisTransform.position);
            }
            if ((this.DangerSense > 0) && (this.DangerDirection != Vector3.zero))
            {
                this.NewRotation = Quaternion.LookRotation(this.DangerDirection);
            }
            if (!this.PartOfCorvette)
            {
                if (!this.LineOfFire)
                {
                    this.thisTransform.rotation = Quaternion.RotateTowards(this.thisTransform.rotation, this.NewRotation, Time.deltaTime * 50);
                }
                else
                {
                    if (Vector3.Distance(this.RaySpawn2.position, this.RaySpawn.position) < 0.1f)
                    {
                        this.thisTransform.forward = this.target.position - this.thisTransform.position;
                    }
                }
            }
            else
            {
                //----------------------------------------------------------------------------------------------------------------------------------------
                this.localAV = this.VesselTF.InverseTransformDirection(this.vRigidbody.angularVelocity);
                this.localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
                this.velMag = this.vRigidbody.velocity.magnitude;
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
                Debug.DrawRay(this.VPoint2.position + (this.VPoint2.forward * 24.5f), Vector3.down * 16, Color.yellow);
                Debug.DrawRay(this.VPoint2.position + (-this.VPoint2.forward * 18), Vector3.down * 16, Color.yellow);
                if (Physics.Raycast(this.VPoint2.position + (this.VPoint2.forward * 24.5f), Vector3.down, 16, (int) this.OtargetLayers) || Physics.Raycast(this.VPoint2.position + (-this.VPoint2.forward * 18), Vector3.down, 16, (int) this.OtargetLayers))
                {
                    this.LiftForce = true;
                }
                else
                {
                    this.LiftForce = false;
                }
                if (-this.localV.y > 0)
                {
                    if (((!this.TurnLeft && !this.TurnRight) && !this.Obstacle) || this.InView)
                    {
                        if (this.targDist > 200)
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
                                this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * 1000, -this.thisVTransform.up * 20);
                                this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * -1000, this.thisVTransform.up * 20);
                            }
                            else
                            {
                                this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * 300, -this.thisVTransform.up * 20);
                                this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * -300, this.thisVTransform.up * 20);
                            }
                        }
                    }
                }
                if (this.LTMuzzle)
                {
                    if (this.LTurret.GetComponent<Rigidbody>().angularVelocity.magnitude < 1)
                    {
                        this.LTurret.GetComponent<Rigidbody>().AddForceAtPosition((this.TargetLead.transform.position - this.LTBase.transform.position).normalized * 10, -this.LTBase.transform.up * 4);
                        this.LTurret.GetComponent<Rigidbody>().AddForceAtPosition((this.TargetLead.transform.position - this.LTBase.transform.position).normalized * -10, this.LTBase.transform.up * 4);
                    }
                }
                if (this.RTMuzzle)
                {
                    if (this.RTurret.GetComponent<Rigidbody>().angularVelocity.magnitude < 1)
                    {
                        this.RTurret.GetComponent<Rigidbody>().AddForceAtPosition((this.TargetLead.transform.position - this.RTBase.transform.position).normalized * 10, -this.RTBase.transform.up * 4);
                        this.RTurret.GetComponent<Rigidbody>().AddForceAtPosition((this.TargetLead.transform.position - this.RTBase.transform.position).normalized * -10, this.RTBase.transform.up * 4);
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
                if (this.localV.y > 0)
                {
                    this.DirForce = 0;
                }
                if (!this.Reverse)
                {
                    if (this.targDist < 50)
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
                        if (this.localAV.x < 0.1f)
                        {
                            if ((-this.localV.y > 20) && (-this.localV.y < 300))
                            {
                                if (!this.Pursuing)
                                {
                                    if (this.targDist > 50)
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
                if (this.TurnRight)
                {
                    this.vRigidbody.AddTorque(-this.thisVTransform.forward * -64000);
                }
                if (this.TurnLeft)
                {
                    this.vRigidbody.AddTorque(-this.thisVTransform.forward * 64000);
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
                this.vRigidbody.AddForce(-this.thisVTransform.up * this.DirForce);
            }
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().name.Contains("TFC"))
        {
            if (Vector3.Distance(other.transform.position, this.thisTransform.position) > 100)
            {
                if (Physics.Linecast(this.VantagePoint.position, other.transform.position, (int) this.MtargetLayers))
                {
                    return;
                }
            }
        }
        if (other.GetComponent<Rigidbody>())
        {
            if (this.target)
            {
                if (!this.target.name.Contains("TC"))
                {
                    if (other.GetComponent<Collider>().name.Contains("TFC") && (this.DangerSense < 1))
                    {
                        if (!other.GetComponent<Collider>().name.Contains("TFC2"))
                        {
                            this.DangerSense = 40;
                            if (other.GetComponent<Rigidbody>())
                            {
                                this.DangerDirection = -other.GetComponent<Rigidbody>().velocity.normalized;
                                this.target = null;
                            }
                            if (this.PartOfCorvette)
                            {
                                this.Trig.center = new Vector3(0, 0, 450);
                                this.Trig.radius = 500;
                                this.Trig.height = 1000;
                            }
                            else
                            {
                                this.Trig.center = new Vector3(0, 0, 0);
                                this.Trig.radius = 4000;
                                this.Trig.height = 4000;
                            }
                        }
                    }
                }
            }
        }
        if (other.GetComponent<Collider>().name.Contains("TFC"))
        {
            if (!other.GetComponent<Collider>().name.Contains("TFC2"))
            {
                if (this.angerLevel > 100)
                {
                    if (this.PartOfCorvette)
                    {
                        this.Trig.center = new Vector3(0, 0, 450);
                        this.Trig.radius = 500;
                        this.Trig.height = 1000;
                    }
                    else
                    {
                        this.Trig.center = new Vector3(0, 0, 0);
                        this.Trig.radius = 4000;
                        this.Trig.height = 4000;
                    }
                }
                if (this.angerLevel == 0)
                {
                    this.WarningLightOn = true;
                    this.WarningLight.gameObject.SetActive(true);
                    AgrianNetwork.instance.RedAlertTime = 60;
                    this.Trig.center = new Vector3(0, 0, 0);
                    this.Trig.radius = 4000;
                    this.Trig.height = 4000;
                    this.angerLevel = 100;
                    this.WatchTick = 5;
                    GameObject TheThing0 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                    TheThing0.transform.parent = this.thisTransform;
                }
                if ((this.angerLevel < 200) && (this.WatchTick < 1))
                {
                    this.angerLevel = this.angerLevel + 100;
                }
                this.Warning = true;
            }
        }
        if (other.GetComponent<Collider>().name.Contains("TFC1"))
        {
            Vector3 relativePoint1 = other.transform.InverseTransformPoint(this.thisTransform.position);
            float FAndB = relativePoint1.z;
            if (FAndB > 0)
            {
                this.PissedAtTC1 = this.PissedAtTC1 + 4;
                AgrianNetwork.TC1CriminalLevel = AgrianNetwork.TC1CriminalLevel + 10;
            }
            else
            {
                AgrianNetwork.TC1CriminalLevel = AgrianNetwork.TC1CriminalLevel + 2;
            }
        }
        if (other.GetComponent<Collider>().name.Contains("TFC3"))
        {
            this.PissedAtTC3 = this.PissedAtTC3 + 4;
        }
        if (other.GetComponent<Collider>().name.Contains("TFC5"))
        {
            this.PissedAtTC5 = this.PissedAtTC5 + 4;
            AgrianNetwork.TC5CriminalLevel = AgrianNetwork.TC5CriminalLevel + 10;
        }
        if (other.GetComponent<Collider>().name.Contains("TFC6"))
        {
            this.PissedAtTC6 = this.PissedAtTC6 + 4;
            AgrianNetwork.TC6CriminalLevel = AgrianNetwork.TC6CriminalLevel + 10;
        }
        if (other.GetComponent<Collider>().name.Contains("TFC7"))
        {
            this.PissedAtTC7 = this.PissedAtTC7 + 4;
            AgrianNetwork.TC7CriminalLevel = AgrianNetwork.TC7CriminalLevel + 10;
        }
        if (other.GetComponent<Collider>().name.Contains("TFC8"))
        {
            this.PissedAtTC8 = this.PissedAtTC8 + 4;
            AgrianNetwork.TC8CriminalLevel = AgrianNetwork.TC8CriminalLevel + 10;
        }
        if (other.GetComponent<Collider>().name.Contains("TFC9"))
        {
            this.PissedAtTC9 = this.PissedAtTC9 + 4;
            AgrianNetwork.TC9CriminalLevel = AgrianNetwork.TC9CriminalLevel + 10;
        }
        if (other.GetComponent<Collider>().name.Contains("TC1") && (this.PissedAtTC1 > 0))
        {
            this.WarningLightOn = true;
            this.WarningLight.gameObject.SetActive(true);
            AgrianNetwork.instance.RedAlertTime = 60;
            this.Trig.center = new Vector3(0, 0, 0);
            this.Trig.radius = 4000;
            this.Trig.height = 4000;
            this.angerLevel = 100;
            this.WatchTick = 5;
            GameObject TheThing01 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
            TheThing01.transform.parent = this.thisTransform;
        }
        if (other.GetComponent<Collider>().name.Contains("TC3") && (this.PissedAtTC3 > 0))
        {
            this.WarningLightOn = true;
            this.WarningLight.gameObject.SetActive(true);
            AgrianNetwork.instance.RedAlertTime = 60;
            this.Trig.center = new Vector3(0, 0, 0);
            this.Trig.radius = 4000;
            this.Trig.height = 4000;
            this.angerLevel = 100;
            this.WatchTick = 5;
            GameObject TheThing03 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
            TheThing03.transform.parent = this.thisTransform;
        }
        if (other.GetComponent<Collider>().name.Contains("TC4"))
        {
            this.WarningLightOn = true;
            this.WarningLight.gameObject.SetActive(true);
            AgrianNetwork.instance.RedAlertTime = 60;
            this.Trig.center = new Vector3(0, 0, 0);
            this.Trig.radius = 4000;
            this.Trig.height = 4000;
            this.angerLevel = 100;
            this.WatchTick = 5;
            GameObject TheThing04 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
            TheThing04.transform.parent = this.thisTransform;
        }
        if (other.GetComponent<Collider>().name.Contains("TC5") && (this.PissedAtTC5 > 0))
        {
            this.WarningLightOn = true;
            this.WarningLight.gameObject.SetActive(true);
            AgrianNetwork.instance.RedAlertTime = 60;
            this.Trig.center = new Vector3(0, 0, 0);
            this.Trig.radius = 4000;
            this.Trig.height = 4000;
            this.angerLevel = 100;
            this.WatchTick = 5;
            GameObject TheThing05 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
            TheThing05.transform.parent = this.thisTransform;
        }
        if (other.GetComponent<Collider>().name.Contains("TC6") && (this.PissedAtTC6 > 0))
        {
            this.WarningLightOn = true;
            this.WarningLight.gameObject.SetActive(true);
            AgrianNetwork.instance.RedAlertTime = 60;
            this.Trig.center = new Vector3(0, 0, 0);
            this.Trig.radius = 4000;
            this.Trig.height = 4000;
            this.angerLevel = 100;
            this.WatchTick = 5;
            GameObject TheThing06 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
            TheThing06.transform.parent = this.thisTransform;
        }
        if (other.GetComponent<Collider>().name.Contains("TC7") && (this.PissedAtTC7 > 0))
        {
            this.WarningLightOn = true;
            this.WarningLight.gameObject.SetActive(true);
            AgrianNetwork.instance.RedAlertTime = 60;
            this.Trig.center = new Vector3(0, 0, 0);
            this.Trig.radius = 4000;
            this.Trig.height = 4000;
            this.angerLevel = 100;
            this.WatchTick = 5;
            GameObject TheThing07 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
            TheThing07.transform.parent = this.thisTransform;
        }
        if (other.GetComponent<Collider>().name.Contains("TC8") && (this.PissedAtTC8 > 0))
        {
            this.WarningLightOn = true;
            this.WarningLight.gameObject.SetActive(true);
            AgrianNetwork.instance.RedAlertTime = 60;
            this.Trig.center = new Vector3(0, 0, 0);
            this.Trig.radius = 4000;
            this.Trig.height = 4000;
            this.angerLevel = 100;
            this.WatchTick = 5;
            GameObject TheThing08 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
            TheThing08.transform.parent = this.thisTransform;
        }
        if (other.GetComponent<Collider>().name.Contains("TC9") && (this.PissedAtTC9 > 0))
        {
            this.WarningLightOn = true;
            this.WarningLight.gameObject.SetActive(true);
            AgrianNetwork.instance.RedAlertTime = 60;
            this.Trig.center = new Vector3(0, 0, 0);
            this.Trig.radius = 4000;
            this.Trig.height = 4000;
            this.angerLevel = 100;
            this.WatchTick = 5;
            GameObject TheThing09 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
            TheThing09.transform.parent = this.thisTransform;
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if (this.Ignore)
        {
            if (other.transform == this.Ignore)
            {
                return;
            }
        }
        if (this.Hidden)
        {
            if (other.transform == this.Hidden)
            {
                return;
            }
        }
        if (this.target)
        {
            if (!this.target.name.Contains("TC"))
            {
                if (other.GetComponent<Collider>().name.Contains("TC4"))
                {
                    if (((other.GetComponent<Collider>().name.Contains("sT") && !this.FoundSmall) || (other.GetComponent<Collider>().name.Contains("mT") && !this.FoundMedium)) || other.GetComponent<Collider>().name.Contains("bT"))
                    {
                        this.target = other.gameObject.transform;
                        AgrianNetwork.instance.TurretsTarget = other.gameObject.transform;
                        this.DangerSense = 0;
                        if (this.PartOfCorvette)
                        {
                            this.Trig.center = new Vector3(0, 0, 0);
                            this.Trig.radius = 250;
                            this.Trig.height = 250;
                        }
                        if (!this.WarningLightOn)
                        {
                            this.WarningLightOn = true;
                            this.WarningLight.gameObject.SetActive(true);
                            if (!this.PartOfCorvette)
                            {
                                AgrianNetwork.instance.RedAlertTime = 120;
                            }
                            this.angerLevel = 200;
                            this.Warning = true;
                            this.StopAllCoroutines();
                        }
                    }
                }
                if (other.GetComponent<Collider>().name.Contains("TC0a") && (this.PissedAtTC0a > 0))
                {
                    if (((other.GetComponent<Collider>().name.Contains("sT") && !this.FoundSmall) || (other.GetComponent<Collider>().name.Contains("mT") && !this.FoundMedium)) || other.GetComponent<Collider>().name.Contains("bT"))
                    {
                        this.target = other.gameObject.transform;
                        AgrianNetwork.instance.TurretsTarget = other.gameObject.transform;
                        this.DangerSense = 0;
                        if (this.PartOfCorvette)
                        {
                            this.Trig.center = new Vector3(0, 0, 0);
                            this.Trig.radius = 250;
                            this.Trig.height = 250;
                        }
                        if ((this.angerLevel > 150) && !this.WarningLightOn)
                        {
                            this.WarningLightOn = true;
                            this.WarningLight.gameObject.SetActive(true);
                            if (!this.PartOfCorvette)
                            {
                                AgrianNetwork.instance.RedAlertTime = 120;
                            }
                            this.angerLevel = 200;
                            this.Warning = true;
                            this.StopAllCoroutines();
                        }
                    }
                }
                if (other.GetComponent<Collider>().name.Contains("TC1") && (this.PissedAtTC1 > 0))
                {
                    if (((other.GetComponent<Collider>().name.Contains("sT") && !this.FoundSmall) || (other.GetComponent<Collider>().name.Contains("mT") && !this.FoundMedium)) || other.GetComponent<Collider>().name.Contains("bT"))
                    {
                        this.target = other.gameObject.transform;
                        AgrianNetwork.instance.TurretsTarget = other.gameObject.transform;
                        this.DangerSense = 0;
                        if (this.PartOfCorvette)
                        {
                            this.Trig.center = new Vector3(0, 0, 0);
                            this.Trig.radius = 250;
                            this.Trig.height = 250;
                        }
                        if ((this.angerLevel > 150) && !this.WarningLightOn)
                        {
                            this.WarningLightOn = true;
                            this.WarningLight.gameObject.SetActive(true);
                            if (!this.PartOfCorvette)
                            {
                                AgrianNetwork.instance.RedAlertTime = 120;
                            }
                            this.angerLevel = 200;
                            this.Warning = true;
                            this.StopAllCoroutines();
                        }
                    }
                }
                if (other.GetComponent<Collider>().name.Contains("TC3") && (this.PissedAtTC3 > 0))
                {
                    if (((other.GetComponent<Collider>().name.Contains("sT") && !this.FoundSmall) || (other.GetComponent<Collider>().name.Contains("mT") && !this.FoundMedium)) || other.GetComponent<Collider>().name.Contains("bT"))
                    {
                        this.target = other.gameObject.transform;
                        AgrianNetwork.instance.TurretsTarget = other.gameObject.transform;
                        this.DangerSense = 0;
                        if (this.PartOfCorvette)
                        {
                            this.Trig.center = new Vector3(0, 0, 0);
                            this.Trig.radius = 250;
                            this.Trig.height = 250;
                        }
                        if ((this.angerLevel > 150) && !this.WarningLightOn)
                        {
                            this.WarningLightOn = true;
                            this.WarningLight.gameObject.SetActive(true);
                            this.angerLevel = 200;
                            this.Warning = true;
                            this.StopAllCoroutines();
                        }
                    }
                }
                if (other.GetComponent<Collider>().name.Contains("TC5") && (this.PissedAtTC5 > 0))
                {
                    if (((other.GetComponent<Collider>().name.Contains("sT") && !this.FoundSmall) || (other.GetComponent<Collider>().name.Contains("mT") && !this.FoundMedium)) || other.GetComponent<Collider>().name.Contains("bT"))
                    {
                        this.target = other.gameObject.transform;
                        AgrianNetwork.instance.TurretsTarget = other.gameObject.transform;
                        this.DangerSense = 0;
                        if (this.PartOfCorvette)
                        {
                            this.Trig.center = new Vector3(0, 0, 0);
                            this.Trig.radius = 250;
                            this.Trig.height = 250;
                        }
                        if ((this.angerLevel > 150) && !this.WarningLightOn)
                        {
                            this.WarningLightOn = true;
                            this.WarningLight.gameObject.SetActive(true);
                            this.angerLevel = 200;
                            this.Warning = true;
                            this.StopAllCoroutines();
                        }
                    }
                }
                if (other.GetComponent<Collider>().name.Contains("TC6") && (this.PissedAtTC6 > 0))
                {
                    if (((other.GetComponent<Collider>().name.Contains("sT") && !this.FoundSmall) || (other.GetComponent<Collider>().name.Contains("mT") && !this.FoundMedium)) || other.GetComponent<Collider>().name.Contains("bT"))
                    {
                        this.target = other.gameObject.transform;
                        AgrianNetwork.instance.TurretsTarget = other.gameObject.transform;
                        this.DangerSense = 0;
                        if (this.PartOfCorvette)
                        {
                            this.Trig.center = new Vector3(0, 0, 0);
                            this.Trig.radius = 250;
                            this.Trig.height = 250;
                        }
                        if ((this.angerLevel > 150) && !this.WarningLightOn)
                        {
                            this.WarningLightOn = true;
                            this.WarningLight.gameObject.SetActive(true);
                            this.angerLevel = 200;
                            this.Warning = true;
                            this.StopAllCoroutines();
                        }
                    }
                }
                if (other.GetComponent<Collider>().name.Contains("TC7") && (this.PissedAtTC7 > 0))
                {
                    if (((other.GetComponent<Collider>().name.Contains("sT") && !this.FoundSmall) || (other.GetComponent<Collider>().name.Contains("mT") && !this.FoundMedium)) || other.GetComponent<Collider>().name.Contains("bT"))
                    {
                        this.target = other.gameObject.transform;
                        AgrianNetwork.instance.TurretsTarget = other.gameObject.transform;
                        this.DangerSense = 0;
                        if (this.PartOfCorvette)
                        {
                            this.Trig.center = new Vector3(0, 0, 0);
                            this.Trig.radius = 250;
                            this.Trig.height = 250;
                        }
                        if ((this.angerLevel > 150) && !this.WarningLightOn)
                        {
                            this.WarningLightOn = true;
                            this.WarningLight.gameObject.SetActive(true);
                            this.angerLevel = 200;
                            this.Warning = true;
                            this.StopAllCoroutines();
                        }
                    }
                }
                if (other.GetComponent<Collider>().name.Contains("TC8") && (this.PissedAtTC8 > 0))
                {
                    if (((other.GetComponent<Collider>().name.Contains("sT") && !this.FoundSmall) || (other.GetComponent<Collider>().name.Contains("mT") && !this.FoundMedium)) || other.GetComponent<Collider>().name.Contains("bT"))
                    {
                        this.target = other.gameObject.transform;
                        AgrianNetwork.instance.TurretsTarget = other.gameObject.transform;
                        this.DangerSense = 0;
                        if (this.PartOfCorvette)
                        {
                            this.Trig.center = new Vector3(0, 0, 0);
                            this.Trig.radius = 250;
                            this.Trig.height = 250;
                        }
                        if ((this.angerLevel > 150) && !this.WarningLightOn)
                        {
                            this.WarningLightOn = true;
                            this.WarningLight.gameObject.SetActive(true);
                            this.angerLevel = 200;
                            this.Warning = true;
                            this.StopAllCoroutines();
                        }
                    }
                }
                if (other.GetComponent<Collider>().name.Contains("TC9") && (this.PissedAtTC9 > 0))
                {
                    if (((other.GetComponent<Collider>().name.Contains("sT") && !this.FoundSmall) || (other.GetComponent<Collider>().name.Contains("mT") && !this.FoundMedium)) || other.GetComponent<Collider>().name.Contains("bT"))
                    {
                        this.target = other.gameObject.transform;
                        AgrianNetwork.instance.TurretsTarget = other.gameObject.transform;
                        this.DangerSense = 0;
                        if (this.PartOfCorvette)
                        {
                            this.Trig.center = new Vector3(0, 0, 0);
                            this.Trig.radius = 250;
                            this.Trig.height = 250;
                        }
                        if ((this.angerLevel > 150) && !this.WarningLightOn)
                        {
                            this.WarningLightOn = true;
                            this.WarningLight.gameObject.SetActive(true);
                            this.angerLevel = 200;
                            this.Warning = true;
                            this.StopAllCoroutines();
                        }
                    }
                }
            }
        }
    }

    public virtual void FireRay()
    {
        RaycastHit hit = default(RaycastHit);
        this.Hidden = null;
        if (this.angerLevel > 100)
        {
            this.NeedsTurrets = true;
            if (this.LineOfFire)
            {
                if (Vector3.Distance(this.RaySpawn2.position, this.RaySpawn.position) < 0.1f)
                {
                    if (Physics.Raycast(this.RaySpawn2.position, this.RaySpawn2.transform.forward, out hit, 10000, (int) this.targetLayers))
                    {
                        this.NeedsTurrets = false;
                        if (this.target)
                        {
                            if (this.target.name.Contains("TC0a") && (this.PissedAtTC0a > 90))
                            {
                                if (hit.collider.name.Contains("TC0a"))
                                {
                                    this.WarningLightOn = false;
                                    this.WarningLight.gameObject.SetActive(false);
                                    GameObject TheRay0 = UnityEngine.Object.Instantiate(this.RayBurst, this.RaySpawn2.position, this.RaySpawn2.rotation);
                                    TheRay0.transform.parent = this.RaySpawn2;
                                    this.angerLevel = this.angerLevel - 50;
                                }
                            }
                            if (this.target.name.Contains("TC1") && (this.PissedAtTC1 > 90))
                            {
                                if (hit.collider.name.Contains("TC1"))
                                {
                                    this.WarningLightOn = false;
                                    this.WarningLight.gameObject.SetActive(false);
                                    GameObject TheRay1 = UnityEngine.Object.Instantiate(this.RayBurst, this.RaySpawn2.position, this.RaySpawn2.rotation);
                                    TheRay1.transform.parent = this.RaySpawn2;
                                    this.angerLevel = this.angerLevel - 50;
                                }
                            }
                            if (this.target.name.Contains("TC3") && (this.PissedAtTC3 > 5))
                            {
                                if (hit.collider.name.Contains("TC3"))
                                {
                                    this.WarningLightOn = false;
                                    this.WarningLight.gameObject.SetActive(false);
                                    GameObject TheRay2 = UnityEngine.Object.Instantiate(this.RayBurst, this.RaySpawn2.position, this.RaySpawn2.rotation);
                                    TheRay2.transform.parent = this.RaySpawn2;
                                    this.angerLevel = this.angerLevel - 50;
                                }
                            }
                            if (this.target.name.Contains("TC4"))
                            {
                                if (hit.collider.name.Contains("TC4"))
                                {
                                    this.WarningLightOn = false;
                                    this.WarningLight.gameObject.SetActive(false);
                                    GameObject TheRay3 = UnityEngine.Object.Instantiate(this.RayBurst, this.RaySpawn2.position, this.RaySpawn2.rotation);
                                    TheRay3.transform.parent = this.RaySpawn2;
                                    this.angerLevel = this.angerLevel - 50;
                                }
                            }
                            if (this.target.name.Contains("TC5") && (this.PissedAtTC5 > 5))
                            {
                                if (hit.collider.name.Contains("TC5"))
                                {
                                    this.WarningLightOn = false;
                                    this.WarningLight.gameObject.SetActive(false);
                                    GameObject TheRay4 = UnityEngine.Object.Instantiate(this.RayBurst, this.RaySpawn2.position, this.RaySpawn2.rotation);
                                    TheRay4.transform.parent = this.RaySpawn2;
                                    this.angerLevel = this.angerLevel - 50;
                                }
                            }
                            if (this.target.name.Contains("TC6") && (this.PissedAtTC6 > 5))
                            {
                                if (hit.collider.name.Contains("TC6"))
                                {
                                    this.WarningLightOn = false;
                                    this.WarningLight.gameObject.SetActive(false);
                                    GameObject TheRay5 = UnityEngine.Object.Instantiate(this.RayBurst, this.RaySpawn2.position, this.RaySpawn2.rotation);
                                    TheRay5.transform.parent = this.RaySpawn2;
                                    this.angerLevel = this.angerLevel - 50;
                                }
                            }
                            if (this.target.name.Contains("TC7") && (this.PissedAtTC7 > 5))
                            {
                                if (hit.collider.name.Contains("TC7"))
                                {
                                    this.WarningLightOn = false;
                                    this.WarningLight.gameObject.SetActive(false);
                                    GameObject TheRay6 = UnityEngine.Object.Instantiate(this.RayBurst, this.RaySpawn2.position, this.RaySpawn2.rotation);
                                    TheRay6.transform.parent = this.RaySpawn2;
                                    this.angerLevel = this.angerLevel - 50;
                                }
                            }
                            if (this.target.name.Contains("TC8") && (this.PissedAtTC8 > 5))
                            {
                                if (hit.collider.name.Contains("TC8"))
                                {
                                    this.WarningLightOn = false;
                                    this.WarningLight.gameObject.SetActive(false);
                                    GameObject TheRay7 = UnityEngine.Object.Instantiate(this.RayBurst, this.RaySpawn2.position, this.RaySpawn2.rotation);
                                    TheRay7.transform.parent = this.RaySpawn2;
                                    this.angerLevel = this.angerLevel - 50;
                                }
                            }
                            if (this.target.name.Contains("TC9") && (this.PissedAtTC9 > 5))
                            {
                                if (hit.collider.name.Contains("TC9"))
                                {
                                    this.WarningLightOn = false;
                                    this.WarningLight.gameObject.SetActive(false);
                                    GameObject TheRay8 = UnityEngine.Object.Instantiate(this.RayBurst, this.RaySpawn2.position, this.RaySpawn2.rotation);
                                    TheRay8.transform.parent = this.RaySpawn2;
                                    this.angerLevel = this.angerLevel - 50;
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public virtual void FireTurrets()
    {
        this.StartCoroutine(this.Fire());
    }

    public virtual IEnumerator Fire()
    {
        RaycastHit hit = default(RaycastHit);
        if (this.RTMuzzle)
        {
            this.RTLineOfFire = false;
            if (this.target)
            {
                if (Physics.Raycast(this.RTMuzzle.position, this.RTMuzzle.forward, out hit, 5000, (int) this.targetLayers))
                {
                    if (hit.collider.name.Contains(this.target.name) || hit.collider.name.Contains("TL2"))
                    {
                        this.RTLineOfFire = true;
                    }
                }
            }
            if ((this.RTPivot.localEulerAngles.z < 10) || (this.RTPivot.localEulerAngles.z > 350))
            {
                this.RTLineOfFire = false;
            }
            if (this.RTLineOfFire && (this.angerLevel > 100))
            {
                GameObject TheThing6 = UnityEngine.Object.Instantiate(this.TurretShot, this.RTMuzzle.position, this.RTMuzzle.rotation);
                TheThing6.transform.parent = this.RTMuzzle;
                this.angerLevel = this.angerLevel - 10;
            }
        }
        yield return new WaitForSeconds(0.6f);
        if (this.LTMuzzle)
        {
            this.LTLineOfFire = false;
            if (this.target)
            {
                if (Physics.Raycast(this.LTMuzzle.position, this.LTMuzzle.forward, out hit, 5000, (int) this.targetLayers))
                {
                    if (hit.collider.name.Contains(this.target.name) || hit.collider.name.Contains("TL2"))
                    {
                        this.LTLineOfFire = true;
                    }
                }
            }
            if ((this.RTPivot.localEulerAngles.z < 10) || (this.RTPivot.localEulerAngles.z > 350))
            {
                this.LTLineOfFire = false;
            }
            if (this.LTLineOfFire && (this.angerLevel > 100))
            {
                GameObject TheThing7 = UnityEngine.Object.Instantiate(this.TurretShot, this.LTMuzzle.position, this.LTMuzzle.rotation);
                TheThing7.transform.parent = this.LTMuzzle;
                this.angerLevel = this.angerLevel - 10;
            }
        }
    }

    public virtual void LeaveMarker()
    {
        Vector3 TlastPos = new Vector3();
        Vector3 IlastPos = new Vector3();
        if (this.target)
        {
            TlastPos = this.target.position;
        }
        if (this.Ignore)
        {
            IlastPos = this.Ignore.position;
        }
        this.StartCoroutine(this.IsReading(TlastPos, IlastPos));
        if (this.TargetStill > 10)
        {
            this.TargetStill = 0;
            this.Ignore = this.target;
            this.WarningLightOn = false;
            this.WarningLight.gameObject.SetActive(false);
            this.target = this.Waypoint;
            this.angerLevel = 0;
            this.Trig.center = new Vector3(0, 0, 450);
            this.Trig.radius = 500;
            this.Trig.height = 1000;
        }
        this.FoundSmall = false;
        this.FoundMedium = false;
        this.FoundBig = false;
    }

    public virtual IEnumerator IsReading(Vector3 TlastPos, Vector3 IlastPos)
    {
        yield return new WaitForSeconds(2);
        if (this.target)
        {
            if (Vector3.Distance(this.target.transform.position, TlastPos) < 1)
            {
                this.TargetStill = this.TargetStill + 1;
            }
            else
            {
                this.TargetStill = 0;
            }
        }
        if (this.Ignore)
        {
            if (Vector3.Distance(this.Ignore.position, IlastPos) > 1)
            {
                this.Ignore = null;
            }
        }
    }

    public virtual void Retreat()
    {
        this.StartCoroutine(this.Retreat2());
    }

    public virtual IEnumerator Retreat2()
    {
        if (this.angerLevel < 1)
        {
            this.target = this.Waypoint2;
        }
        yield return new WaitForSeconds(10);
        if (this.angerLevel < 1)
        {
            this.target = this.Waypoint;
        }
    }

    public virtual void CalcLead()
    {
        if (this.PartOfCorvette)
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
            this.TargetLead.position = this.TargetLead.position + (((this.TargetLead.forward * Dist1) * Dist2) * 0.03f);
            if ((Vector3.Distance(this.TargetTrace.position, this.target.position) > 4) && (this.angerLevel > 100))
            {
                if (this.angerLevel > 100)
                {
                    this.TLCol.radius = this.targDist * 0.025f;
                }
                else
                {
                    this.TLCol.radius = 0.1f;
                }
                this.Pursuing = true;
            }
            else
            {
                if (this.angerLevel > 100)
                {
                    this.TLCol.radius = this.targDist * 0.025f;
                }
                else
                {
                    this.TLCol.radius = 0.1f;
                }
                this.Pursuing = false;
            }
        }
    }

    public virtual void Regenerator()
    {
        this.LineOfFire = false;
        if (this.target != null)
        {
            if (!this.target.name.Contains("bTC"))
            {
                this.FoundBig = false;
            }
            if (!this.PartOfCorvette)
            {
                if (AgrianNetwork.instance.TurretsTarget != null)
                {
                    if ((AgrianNetwork.RedAlert == true) && !this.target.name.Contains("TC"))
                    {
                        this.target = AgrianNetwork.instance.TurretsTarget;
                        this.Warning = true;
                        this.angerLevel = 60;
                        this.Trig.center = new Vector3(0, 0, 1900);
                        this.Trig.radius = 4000;
                        this.Trig.height = 4000;
                    }
                }
            }
            if (AgrianNetwork.TC1CriminalLevel < 500)
            {
                if ((AgrianNetwork.TC1CriminalLevel > 240) && this.target.name.Contains("TC1"))
                {
                    AgrianNetwork.instance.PriorityWaypoint.position = this.target.position;
                    AgrianNetwork.TC1CriminalLevel = 360;
                }
            }
            else
            {
                if (this.target.name.Contains("TC1"))
                {
                    if ((AgrianNetwork.instance.RedAlertTime > 0) && !this.PartOfCorvette)
                    {
                        AgrianNetwork.instance.FullPriorityWaypoint.transform.position = this.target.position;
                    }
                    if (AgrianNetwork.instance.AlertTime < 300)
                    {
                        AgrianNetwork.instance.AlertTime = 300;
                    }
                    AgrianNetwork.TC1CriminalLevel = 620;
                }
            }
            if (AgrianNetwork.TC4CriminalLevel < 500)
            {
                if ((AgrianNetwork.TC4CriminalLevel > 240) && this.target.name.Contains("TC4"))
                {
                    AgrianNetwork.instance.PriorityWaypoint.position = this.target.position;
                    AgrianNetwork.TC4CriminalLevel = 360;
                }
            }
            else
            {
                if (this.target.name.Contains("TC4"))
                {
                    if ((AgrianNetwork.instance.RedAlertTime > 0) && !this.PartOfCorvette)
                    {
                        AgrianNetwork.instance.FullPriorityWaypoint.transform.position = this.target.position;
                    }
                    if (AgrianNetwork.instance.AlertTime < 300)
                    {
                        AgrianNetwork.instance.AlertTime = 300;
                    }
                    AgrianNetwork.TC4CriminalLevel = 620;
                }
            }
            if (AgrianNetwork.TC5CriminalLevel < 500)
            {
                if ((AgrianNetwork.TC5CriminalLevel > 240) && this.target.name.Contains("TC5"))
                {
                    AgrianNetwork.instance.PriorityWaypoint.position = this.target.position;
                    AgrianNetwork.TC5CriminalLevel = 360;
                }
            }
            else
            {
                if (this.target.name.Contains("TC5"))
                {
                    if ((AgrianNetwork.instance.RedAlertTime > 0) && !this.PartOfCorvette)
                    {
                        AgrianNetwork.instance.FullPriorityWaypoint.transform.position = this.target.position;
                    }
                    if (AgrianNetwork.instance.AlertTime < 300)
                    {
                        AgrianNetwork.instance.AlertTime = 300;
                    }
                    AgrianNetwork.TC5CriminalLevel = 620;
                }
            }
            if (AgrianNetwork.TC6CriminalLevel < 500)
            {
                if ((AgrianNetwork.TC6CriminalLevel > 240) && this.target.name.Contains("TC6"))
                {
                    AgrianNetwork.instance.PriorityWaypoint.position = this.target.position;
                    AgrianNetwork.TC6CriminalLevel = 360;
                }
            }
            else
            {
                if (this.target.name.Contains("TC6"))
                {
                    if ((AgrianNetwork.instance.RedAlertTime > 0) && !this.PartOfCorvette)
                    {
                        AgrianNetwork.instance.FullPriorityWaypoint.transform.position = this.target.position;
                    }
                    if (AgrianNetwork.instance.AlertTime < 300)
                    {
                        AgrianNetwork.instance.AlertTime = 300;
                    }
                    AgrianNetwork.TC6CriminalLevel = 620;
                }
            }
            if (AgrianNetwork.TC7CriminalLevel < 500)
            {
                if ((AgrianNetwork.TC7CriminalLevel > 240) && this.target.name.Contains("TC7"))
                {
                    AgrianNetwork.instance.PriorityWaypoint.position = this.target.position;
                    AgrianNetwork.TC7CriminalLevel = 360;
                }
            }
            else
            {
                if (this.target.name.Contains("TC7"))
                {
                    if ((AgrianNetwork.instance.RedAlertTime > 0) && !this.PartOfCorvette)
                    {
                        AgrianNetwork.instance.FullPriorityWaypoint.transform.position = this.target.position;
                    }
                    if (AgrianNetwork.instance.AlertTime < 300)
                    {
                        AgrianNetwork.instance.AlertTime = 300;
                    }
                    AgrianNetwork.TC7CriminalLevel = 620;
                }
            }
            if (AgrianNetwork.TC8CriminalLevel < 500)
            {
                if ((AgrianNetwork.TC8CriminalLevel > 240) && this.target.name.Contains("TC8"))
                {
                    AgrianNetwork.instance.PriorityWaypoint.position = this.target.position;
                    AgrianNetwork.TC8CriminalLevel = 360;
                }
            }
            else
            {
                if (this.target.name.Contains("TC8"))
                {
                    if ((AgrianNetwork.instance.RedAlertTime > 0) && !this.PartOfCorvette)
                    {
                        AgrianNetwork.instance.FullPriorityWaypoint.transform.position = this.target.position;
                    }
                    if (AgrianNetwork.instance.AlertTime < 300)
                    {
                        AgrianNetwork.instance.AlertTime = 300;
                    }
                    AgrianNetwork.TC8CriminalLevel = 620;
                }
            }
            if (AgrianNetwork.TC9CriminalLevel < 500)
            {
                if ((AgrianNetwork.TC9CriminalLevel > 240) && this.target.name.Contains("TC9"))
                {
                    AgrianNetwork.instance.PriorityWaypoint.position = this.target.position;
                    AgrianNetwork.TC9CriminalLevel = 360;
                }
            }
            else
            {
                if (this.target.name.Contains("TC9"))
                {
                    if ((AgrianNetwork.instance.RedAlertTime > 0) && !this.PartOfCorvette)
                    {
                        AgrianNetwork.instance.FullPriorityWaypoint.transform.position = this.target.position;
                    }
                    if (AgrianNetwork.instance.AlertTime < 300)
                    {
                        AgrianNetwork.instance.AlertTime = 300;
                    }
                    AgrianNetwork.TC9CriminalLevel = 620;
                }
            }
        }
        else
        {
            if (this.PartOfCorvette)
            {
                this.Trig.center = new Vector3(0, 0, 450);
                this.Trig.radius = 500;
                this.Trig.height = 1000;
            }
            else
            {
                this.Trig.center = new Vector3(0, 0, 0);
                this.Trig.radius = 4000;
                this.Trig.height = 4000;
            }
        }
        if ((this.angerLevel == 0) && (this.WatchTick == 0))
        {
            this.WarningLightOn = false;
            this.WarningLight.gameObject.SetActive(false);
            this.target = this.Waypoint;
            if (this.PartOfCorvette)
            {
                this.Trig.center = new Vector3(0, 0, 450);
                this.Trig.radius = 500;
                this.Trig.height = 1000;
            }
            else
            {
                this.Trig.center = new Vector3(0, 0, 0);
                this.Trig.radius = 4000;
                this.Trig.height = 4000;
            }
        }
        if (AgrianNetwork.TC1CriminalLevel > 240)
        {
            this.PissedAtTC1 = 100;
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
        if (this.angerLevel == 1)
        {
            this.WarningLightOn = false;
            this.WarningLight.gameObject.SetActive(false);
            this.target = this.Waypoint;
            this.angerLevel = 0;
            this.PissedAtTC1 = 0;
            this.PissedAtTC3 = 0;
            this.PissedAtTC5 = 0;
            this.PissedAtTC6 = 0;
            this.PissedAtTC7 = 0;
            this.PissedAtTC8 = 0;
            this.PissedAtTC9 = 0;
            if (this.PartOfCorvette)
            {
                this.Trig.center = new Vector3(0, 0, 450);
                this.Trig.radius = 500;
                this.Trig.height = 1000;
            }
            else
            {
                this.Trig.center = new Vector3(0, 0, 0);
                this.Trig.radius = 4000;
                this.Trig.height = 4000;
            }
        }
        if (this.WatchTick > 0)
        {
            this.WatchTick = this.WatchTick - 1;
        }
        if (this.angerLevel > 0)
        {
            this.angerLevel = this.angerLevel - 1;
        }
        if (this.DangerSense > 0)
        {
            this.DangerSense = this.DangerSense - 1;
        }
        if (this.target)
        {
            if ((this.PissedAtTC0a > 0) && this.target.name.Contains("TC0a"))
            {
                this.PissedAtTC0a = this.PissedAtTC0a - 1;
            }
            if ((this.PissedAtTC1 > 0) && this.target.name.Contains("TC1"))
            {
                this.PissedAtTC1 = this.PissedAtTC1 - 1;
            }
            if ((this.PissedAtTC3 > 0) && this.target.name.Contains("TC3"))
            {
                this.PissedAtTC3 = this.PissedAtTC3 - 1;
            }
            if ((this.PissedAtTC5 > 0) && this.target.name.Contains("TC5"))
            {
                this.PissedAtTC5 = this.PissedAtTC5 - 1;
            }
            if ((this.PissedAtTC6 > 0) && this.target.name.Contains("TC6"))
            {
                this.PissedAtTC6 = this.PissedAtTC6 - 1;
            }
            if ((this.PissedAtTC7 > 0) && this.target.name.Contains("TC7"))
            {
                this.PissedAtTC7 = this.PissedAtTC7 - 1;
            }
            if ((this.PissedAtTC8 > 0) && this.target.name.Contains("TC8"))
            {
                this.PissedAtTC8 = this.PissedAtTC8 - 1;
            }
            if ((this.PissedAtTC9 > 0) && this.target.name.Contains("TC9"))
            {
                this.PissedAtTC9 = this.PissedAtTC9 - 1;
            }
            if ((this.PissedAtTC0a > 20) && this.target.name.Contains("TC0a"))
            {
                this.angerLevel = 130;
                this.WarningLightOn = true;
                this.WarningLight.gameObject.SetActive(true);
            }
            if ((this.PissedAtTC1 > 20) && this.target.name.Contains("TC1"))
            {
                this.angerLevel = 130;
                this.WarningLightOn = true;
                this.WarningLight.gameObject.SetActive(true);
            }
            if ((this.PissedAtTC3 > 20) && this.target.name.Contains("TC3"))
            {
                this.angerLevel = 130;
                this.WarningLightOn = true;
                this.WarningLight.gameObject.SetActive(true);
            }
            if ((this.PissedAtTC5 > 20) && this.target.name.Contains("TC5"))
            {
                this.angerLevel = 130;
                this.WarningLightOn = true;
                this.WarningLight.gameObject.SetActive(true);
            }
            if ((this.PissedAtTC6 > 20) && this.target.name.Contains("TC6"))
            {
                this.angerLevel = 130;
                this.WarningLightOn = true;
                this.WarningLight.gameObject.SetActive(true);
            }
            if ((this.PissedAtTC7 > 20) && this.target.name.Contains("TC7"))
            {
                this.angerLevel = 130;
                this.WarningLightOn = true;
                this.WarningLight.gameObject.SetActive(true);
            }
            if ((this.PissedAtTC8 > 20) && this.target.name.Contains("TC8"))
            {
                this.angerLevel = 130;
                this.WarningLightOn = true;
                this.WarningLight.gameObject.SetActive(true);
            }
            if ((this.PissedAtTC9 > 20) && this.target.name.Contains("TC9"))
            {
                this.angerLevel = 130;
                this.WarningLightOn = true;
                this.WarningLight.gameObject.SetActive(true);
            }
        }
        if (this.target == null)
        {
            this.target = this.Waypoint;
        }
        if (this.PartOfCorvette)
        {
            if (this.target)
            {
                this.InView = false;
                if (this.target.name.Contains("sT"))
                {
                    this.FoundSmall = true;
                    if (this.angerLevel < 10)
                    {
                        if (this.targDist > 32)
                        {
                            this.target = this.Waypoint;
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
                if (this.DangerSense < 1)
                {
                    if (AgrianNetwork.instance.AlertTime > 1)
                    {
                        if (!this.target.name.Contains("TC"))
                        {
                            if (this.angerLevel < 50)
                            {
                                this.Waypoint2.position = AgrianNetwork.instance.PriorityWaypoint.position;
                                this.target = this.Waypoint2;
                            }
                            else
                            {
                                if (this.target.name.Contains("Reset"))
                                {
                                    this.angerLevel = 50;
                                }
                            }
                        }
                    }
                }
                if (AgrianNetwork.instance.RedAlertTime > 1)
                {
                    if (!this.target.name.Contains("TC"))
                    {
                        if (this.angerLevel < 50)
                        {
                            this.Waypoint2.position = AgrianNetwork.instance.FullPriorityWaypoint.position;
                            this.target = this.Waypoint2;
                        }
                        else
                        {
                            if (this.target.name.Contains("Reset"))
                            {
                                this.angerLevel = 50;
                            }
                        }
                    }
                }
                if (this.angerLevel > 50)
                {
                    if (!Physics.Linecast(this.thisTransform.position, this.target.position, (int) this.MtargetLayers))
                    {
                        this.InView = true;
                    }
                }
                this.Upforce = false;
                this.Reverse = false;
                this.Obstacle = false;
                this.TurnRight = false;
                this.TurnLeft = false;
                this.OnHull = false;
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
        }
        else
        {
            if (this.target)
            {
                if (!this.InView && this.target.name.Contains("TC"))
                {
                    this.Hidden = this.target.transform;
                    this.target = null;
                }
            }
            this.InView = true;
            if (this.target)
            {
                if (this.target.name.Contains("TC"))
                {
                    if (Vector3.Distance(this.RaySpawn2.position, this.RaySpawn.position) < 0.1f)
                    {
                        if (Physics.Linecast(this.VantagePoint.position, this.target.position, (int) this.MtargetLayers))
                        {
                            this.InView = false;
                        }
                    }
                }
            }
        }
    }

    public AgrianTurretAI()
    {
        this.DirForce = 200;
        this.RayDist = 2;
        this.ObsDist = 100;
    }

}