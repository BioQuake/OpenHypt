using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AgrianLoucuratAI : MonoBehaviour
{
    public Transform target;
    public Transform Waypoint;
    public Transform Waypoint2;
    public Transform Ignore;
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
    public GameObject SubduerPrefab;
    public GameObject SubduerSpawn1;
    public GameObject SubduerSpawn2;
    public bool HasFiredSubduers;
    public GameObject RearWing;
    public GameObject TopWing;
    public BigVesselRotator VesselRotator;
    public GameObject TurretLight;
    public GameObject WarningLight;
    public GameObject AttackSound;
    public bool GroundClear;
    public bool Pursuing;
    public int PursueTime;
    public bool FoundBig;
    public bool FoundMedium;
    public bool FoundSmall;
    public bool Warning;
    public bool WarningLightOn;
    public bool NeedsTurrets;
    public int PissedAtTC0a;
    public int PissedAtTC1;
    public int PissedAtTC3;
    public int PissedAtTC4;
    public int PissedAtTC5;
    public int PissedAtTC6;
    public int PissedAtTC7;
    public int PissedAtTC8;
    public int PissedAtTC9;
    public int DangerSense;
    public Vector3 DangerDirection;
    public string DangerName;
    public bool interrogating;
    public int InterrogateTimer;
    public int angerLevel;
    public int WatchTick;
    public int TrigTick;
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
        this.InvokeRepeating("LeaveMarker", 1, 5);
        this.InvokeRepeating("Regenerator", 1, 0.5f);
        this.InvokeRepeating("FireRay", 1, 3);
        this.InvokeRepeating("FireTurrets", 1, 1.2f);
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
            this.VPoint.transform.rotation = Quaternion.LookRotation(this.GetComponent<Rigidbody>().velocity);
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
                if (this.targDist > 256)
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
            if (this.angerLevel < 50)
            {
                this.Downtorque = false;
                this.GroundClear = true;
                this.vRigidbody.useGravity = false;
                this.VesselTip.GetComponent<Rigidbody>().useGravity = false;
            }
            else
            {
                this.GroundClear = false;
                this.vRigidbody.useGravity = true;
                this.VesselTip.GetComponent<Rigidbody>().useGravity = true;
            }
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
        //========================================================================================================================//
        //////////////////////////////////////////////////////[INTERACTION]/////////////////////////////////////////////////////////
        //========================================================================================================================//
        if (NotiScript.PiriNotis)
        {
            if (Vector3.Distance(this.thisTransform.position, PlayerInformation.instance.Pirizuka.position) < 256)
            {
                this.target = PlayerInformation.instance.PiriTarget;
                NotiScript.PiriNotis = false;
            }
        }
        if (WorldInformation.pSpeech)
        {
            if (Vector3.Distance(this.thisTransform.position, WorldInformation.pSpeech.position) < WorldInformation.pSpeechRange)
            {
                if (Vector3.Distance(this.thisTransform.position, WorldInformation.pSpeech.position) < 256)
                {
                    this.StartCoroutine(this.ProcessSpeech(TalkBubbleScript.myText));
                    WorldInformation.pSpeech = null;
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
            //----------------------------------------------------------------------------------------------------------------------------------------
            this.localAV = this.VesselTF.InverseTransformDirection(this.vRigidbody.angularVelocity);
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
            Debug.DrawRay(this.VPoint2.position + (this.VPoint2.forward * 24.5f), Vector3.down * 16, Color.yellow);
            Debug.DrawRay(this.VPoint2.position, Vector3.down * 24, Color.yellow);
            Debug.DrawRay(this.VPoint2.position + (-this.VPoint2.forward * 18), Vector3.down * 16, Color.yellow);
            if ((Physics.Raycast(this.VPoint2.position + (this.VPoint2.forward * 24.5f), Vector3.down, 16, (int) this.OtargetLayers) || Physics.Raycast(this.VPoint2.position + (-this.VPoint2.forward * 18), Vector3.down, 16, (int) this.OtargetLayers)) || Physics.Raycast(this.VPoint2.position, Vector3.down, 24, (int) this.OtargetLayers))
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
                            this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * 600, -this.thisVTransform.up * 20);
                            this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * -600, this.thisVTransform.up * 20);
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
                    if (this.localAV.x < 0.1f)
                    {
                        if ((-this.localV.y > 20) && (-this.localV.y < 300))
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
            this.vRigidbody.AddForce(-this.thisVTransform.up * this.DirForce);
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
                if (!this.interrogating)
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
                                }
                                //target = null;
                                this.Trig.center = new Vector3(0, 0, 450);
                                this.Trig.radius = 500;
                                this.Trig.height = 1000;
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
                    this.Trig.center = new Vector3(0, 0, 450);
                    this.Trig.radius = 500;
                    this.Trig.height = 1000;
                }
                if (this.angerLevel == 0)
                {
                    this.WarningLightOn = true;
                    this.WarningLight.gameObject.SetActive(true);
                    this.Trig.center = new Vector3(0, 0, 450);
                    this.Trig.radius = 500;
                    this.Trig.height = 1000;
                    this.angerLevel = 110;
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
            Vector3 relativePoint0 = other.transform.InverseTransformPoint(this.thisTransform.position);
            float FAndB = relativePoint0.z;
            this.DangerName = other.GetComponent<Collider>().name;
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
            this.DangerName = other.GetComponent<Collider>().name;
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
            this.DangerName = other.GetComponent<Collider>().name;
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
            this.DangerName = other.GetComponent<Collider>().name;
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
            this.DangerName = other.GetComponent<Collider>().name;
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
            this.DangerName = other.GetComponent<Collider>().name;
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
            this.DangerName = other.GetComponent<Collider>().name;
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
            this.DangerName = other.GetComponent<Collider>().name;
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
        float OTD = Vector3.Distance(this.thisTransform.position, OT.position);
        if (this.Ignore)
        {
            if (OT == this.Ignore)
            {
                return;
            }
        }
        if (this.interrogating)
        {
            return;
        }
        if (this.target)
        {
            if (AgrianNetwork.instance.SubdueTarget)
            {
                if (this.target == AgrianNetwork.instance.SubdueTarget)
                {
                    return;
                }
            }
            if (ON.Contains("TC0a"))
            {
                if (this.PissedAtTC0a > 0)
                {
                    if (((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || ON.Contains("bT"))
                    {
                        this.target = OT;
                        AgrianNetwork.instance.TurretsTarget = OT;
                        this.DangerSense = 0;
                        this.Trig.center = new Vector3(0, 0, 0);
                        this.Trig.radius = 32;
                        this.Trig.height = 32;
                        this.TrigTick = 6;
                        if (!this.WarningLightOn)
                        {
                            this.WarningLightOn = true;
                            this.WarningLight.gameObject.SetActive(true);
                            this.angerLevel = 130;
                            this.Warning = true;
                        }
                    }
                    if (this.PissedAtTC0a > 100)
                    {
                        if (this.targDist > OTD)
                        {
                            this.target = OT;
                        }
                    }
                }
            }
            if (ON.Contains("TC1"))
            {
                if (this.PissedAtTC1 > 0)
                {
                    if (((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || ON.Contains("bT"))
                    {
                        this.target = OT;
                        AgrianNetwork.instance.TurretsTarget = OT;
                        this.DangerSense = 0;
                        this.Trig.center = new Vector3(0, 0, 0);
                        this.Trig.radius = 32;
                        this.Trig.height = 32;
                        this.TrigTick = 0;
                        if (!this.WarningLightOn)
                        {
                            this.WarningLightOn = true;
                            this.WarningLight.gameObject.SetActive(true);
                            this.angerLevel = 130;
                            this.Warning = true;
                        }
                    }
                    if (this.PissedAtTC1 > 100)
                    {
                        if (this.targDist > OTD)
                        {
                            this.target = OT;
                        }
                    }
                }
            }
            if (ON.Contains("TC3"))
            {
                if (this.PissedAtTC3 > 0)
                {
                    if (((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || ON.Contains("bT"))
                    {
                        this.target = OT;
                        AgrianNetwork.instance.TurretsTarget = OT;
                        this.DangerSense = 0;
                        this.Trig.center = new Vector3(0, 0, 0);
                        this.Trig.radius = 32;
                        this.Trig.height = 32;
                        this.TrigTick = 6;
                        if (!this.WarningLightOn)
                        {
                            this.WarningLightOn = true;
                            this.WarningLight.gameObject.SetActive(true);
                            this.angerLevel = 130;
                            this.Warning = true;
                        }
                    }
                    if (this.PissedAtTC3 > 100)
                    {
                        if (this.targDist > OTD)
                        {
                            this.target = OT;
                        }
                    }
                }
            }
            if (ON.Contains("TC4"))
            {
                if (this.PissedAtTC4 > 0)
                {
                    if (((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || ON.Contains("bT"))
                    {
                        this.target = OT;
                        AgrianNetwork.instance.TurretsTarget = OT;
                        this.DangerSense = 0;
                        this.Trig.center = new Vector3(0, 0, 0);
                        this.Trig.radius = 32;
                        this.Trig.height = 32;
                        this.TrigTick = 6;
                        if (!this.WarningLightOn)
                        {
                            this.WarningLightOn = true;
                            this.WarningLight.gameObject.SetActive(true);
                            this.angerLevel = 130;
                            this.Warning = true;
                        }
                    }
                    if (this.PissedAtTC4 > 100)
                    {
                        if (this.targDist > OTD)
                        {
                            this.target = OT;
                        }
                    }
                }
            }
            if (ON.Contains("TC5"))
            {
                if (this.PissedAtTC5 > 0)
                {
                    if (((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || ON.Contains("bT"))
                    {
                        this.target = OT;
                        AgrianNetwork.instance.TurretsTarget = OT;
                        this.DangerSense = 0;
                        this.Trig.center = new Vector3(0, 0, 0);
                        this.Trig.radius = 32;
                        this.Trig.height = 32;
                        this.TrigTick = 6;
                        if (!this.WarningLightOn)
                        {
                            this.WarningLightOn = true;
                            this.WarningLight.gameObject.SetActive(true);
                            this.angerLevel = 130;
                            this.Warning = true;
                        }
                    }
                    if (this.PissedAtTC5 > 100)
                    {
                        if (this.targDist > OTD)
                        {
                            this.target = OT;
                        }
                    }
                }
            }
            if (ON.Contains("TC6"))
            {
                if (this.PissedAtTC6 > 0)
                {
                    if (((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || ON.Contains("bT"))
                    {
                        this.target = OT;
                        AgrianNetwork.instance.TurretsTarget = OT;
                        this.DangerSense = 0;
                        this.Trig.center = new Vector3(0, 0, 0);
                        this.Trig.radius = 32;
                        this.Trig.height = 32;
                        this.TrigTick = 6;
                        if (!this.WarningLightOn)
                        {
                            this.WarningLightOn = true;
                            this.WarningLight.gameObject.SetActive(true);
                            this.angerLevel = 130;
                            this.Warning = true;
                        }
                    }
                    if (this.PissedAtTC6 > 100)
                    {
                        if (this.targDist > OTD)
                        {
                            this.target = OT;
                        }
                    }
                }
            }
            if (ON.Contains("TC7"))
            {
                if (this.PissedAtTC7 > 0)
                {
                    if (((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || ON.Contains("bT"))
                    {
                        this.target = OT;
                        AgrianNetwork.instance.TurretsTarget = OT;
                        this.DangerSense = 0;
                        this.Trig.center = new Vector3(0, 0, 0);
                        this.Trig.radius = 32;
                        this.Trig.height = 32;
                        this.TrigTick = 6;
                        if (!this.WarningLightOn)
                        {
                            this.WarningLightOn = true;
                            this.WarningLight.gameObject.SetActive(true);
                            this.angerLevel = 130;
                            this.Warning = true;
                        }
                    }
                    if (this.PissedAtTC7 > 100)
                    {
                        if (this.targDist > OTD)
                        {
                            this.target = OT;
                        }
                    }
                }
            }
            if (ON.Contains("TC8"))
            {
                if (this.PissedAtTC8 > 0)
                {
                    if (((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || ON.Contains("bT"))
                    {
                        this.target = OT;
                        AgrianNetwork.instance.TurretsTarget = OT;
                        this.DangerSense = 0;
                        this.Trig.center = new Vector3(0, 0, 0);
                        this.Trig.radius = 32;
                        this.Trig.height = 32;
                        this.TrigTick = 6;
                        if (!this.WarningLightOn)
                        {
                            this.WarningLightOn = true;
                            this.WarningLight.gameObject.SetActive(true);
                            this.angerLevel = 130;
                            this.Warning = true;
                        }
                    }
                    if (this.PissedAtTC8 > 100)
                    {
                        if (this.targDist > OTD)
                        {
                            this.target = OT;
                        }
                    }
                }
            }
            if (ON.Contains("TC9"))
            {
                if (this.PissedAtTC9 > 0)
                {
                    if (((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || ON.Contains("bT"))
                    {
                        this.target = OT;
                        AgrianNetwork.instance.TurretsTarget = OT;
                        this.DangerSense = 0;
                        this.Trig.center = new Vector3(0, 0, 0);
                        this.Trig.radius = 32;
                        this.Trig.height = 32;
                        this.TrigTick = 6;
                        if (!this.WarningLightOn)
                        {
                            this.WarningLightOn = true;
                            this.WarningLight.gameObject.SetActive(true);
                            this.angerLevel = 130;
                            this.Warning = true;
                        }
                    }
                    if (this.PissedAtTC9 > 100)
                    {
                        if (this.targDist > OTD)
                        {
                            this.target = OT;
                        }
                    }
                }
            }
            if (ON.Contains("TC2_P"))
            {
                if (AgrianNetwork.instance.Curiosity > 1)
                {
                    if (AgrianNetwork.instance.AlertTime > 1)
                    {
                        this.target = OT;
                        this.interrogating = true;
                        this.StartCoroutine(this.ProcessSpeech(""));
                    }
                }
            }
        }
    }

    public virtual void FireRay()
    {
        RaycastHit hit = default(RaycastHit);
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
        if (!this.interrogating)
        {
            if (this.TargetStill > 10)
            {
                this.TargetStill = 0;
                this.Ignore = this.target;
                this.WarningLightOn = false;
                this.WarningLight.gameObject.SetActive(false);
                this.target = this.Waypoint;
                this.angerLevel = 7;
                this.Trig.center = new Vector3(0, 0, 450);
                this.Trig.radius = 500;
                this.Trig.height = 1000;
            }
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
            if ((Dist2 > 24) && (this.angerLevel > 100))
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

    public virtual void Regenerator()//}
    {
        this.LineOfFire = false;
        if (this.target != null)
        {
            if (!this.target.name.Contains("bTC"))
            {
                this.FoundBig = false;
            }
            if (AgrianNetwork.TC1CriminalLevel < 500)
            {
                if ((AgrianNetwork.TC1CriminalLevel > 240) && this.target.name.Contains("TC1"))
                {
                    AgrianNetwork.instance.PriorityWaypoint.position = this.target.position;
                    AgrianNetwork.TC1CriminalLevel = 360;
                    WorldInformation.PiriExposed = 60;
                }
            }
            else
            {
                if (this.target.name.Contains("TC1"))
                {
                    if (AgrianNetwork.instance.AlertTime < 300)
                    {
                        AgrianNetwork.instance.AlertTime = 300;
                    }
                    AgrianNetwork.instance.FullPriorityWaypoint.position = this.target.position;
                    AgrianNetwork.TC1CriminalLevel = 620;
                    WorldInformation.PiriExposed = 120;
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
                    if (AgrianNetwork.instance.AlertTime < 300)
                    {
                        AgrianNetwork.instance.AlertTime = 300;
                    }
                    AgrianNetwork.instance.FullPriorityWaypoint.position = this.target.position;
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
                    if (AgrianNetwork.instance.AlertTime < 300)
                    {
                        AgrianNetwork.instance.AlertTime = 300;
                    }
                    AgrianNetwork.instance.FullPriorityWaypoint.position = this.target.position;
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
                    if (AgrianNetwork.instance.AlertTime < 300)
                    {
                        AgrianNetwork.instance.AlertTime = 300;
                    }
                    AgrianNetwork.instance.FullPriorityWaypoint.position = this.target.position;
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
                    if (AgrianNetwork.instance.AlertTime < 300)
                    {
                        AgrianNetwork.instance.AlertTime = 300;
                    }
                    AgrianNetwork.instance.FullPriorityWaypoint.position = this.target.position;
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
                    if (AgrianNetwork.instance.AlertTime < 300)
                    {
                        AgrianNetwork.instance.AlertTime = 300;
                    }
                    AgrianNetwork.instance.FullPriorityWaypoint.position = this.target.position;
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
                    if (AgrianNetwork.instance.AlertTime < 300)
                    {
                        AgrianNetwork.instance.AlertTime = 300;
                    }
                    AgrianNetwork.instance.FullPriorityWaypoint.position = this.target.position;
                    AgrianNetwork.TC9CriminalLevel = 620;
                }
            }
            if (this.Pursuing)
            {
                if (this.angerLevel > 100)
                {
                    if (this.target.name.Contains("TC"))
                    {
                        this.PursueTime = this.PursueTime + 1;
                        if (this.PursueTime > 20)
                        {
                            if (this.target.name.Contains("bT"))
                            {
                                this.PursueTime = 0;
                                AgrianNetwork.instance.SubdueTarget = this.target;
                            }
                            else
                            {
                                this.PursueTime = 0;
                                if (!this.HasFiredSubduers)
                                {
                                    this.HasFiredSubduers = true;
                                    this.StartCoroutine(this.Subduing());
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                this.PursueTime = 0;
            }
        }
        else
        {
            this.Trig.center = new Vector3(0, 0, 450);
            this.Trig.radius = 500;
            this.Trig.height = 1000;
        }
        if (!this.interrogating)
        {
            if ((this.angerLevel == 0) && (this.WatchTick == 0))
            {
                this.WarningLightOn = false;
                this.WarningLight.gameObject.SetActive(false);
                this.target = this.Waypoint;
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
                this.Trig.center = new Vector3(0, 0, 450);
                this.Trig.radius = 500;
                this.Trig.height = 1000;
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
                if (this.target.name.Contains("TC0a"))
                {
                    if (this.PissedAtTC0a > 0)
                    {
                        this.PissedAtTC0a = this.PissedAtTC0a - 1;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(this.DangerName))
                        {
                            if (!this.DangerName.Contains("TC0a"))
                            {
                                this.angerLevel = 7;
                            }
                        }
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
                    else
                    {
                        if (!string.IsNullOrEmpty(this.DangerName))
                        {
                            if (!this.DangerName.Contains("TC1"))
                            {
                                this.angerLevel = 7;
                            }
                        }
                    }
                }
                if (this.target.name.Contains("TC3"))
                {
                    if (this.PissedAtTC3 > 0)
                    {
                        this.PissedAtTC3 = this.PissedAtTC3 - 1;
                        if (AgrianNetwork.TC3CriminalLevel > 320)
                        {
                            this.angerLevel = 110;
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(this.DangerName))
                        {
                            if (!this.DangerName.Contains("TC3"))
                            {
                                this.angerLevel = 7;
                            }
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
                    else
                    {
                        if (!string.IsNullOrEmpty(this.DangerName))
                        {
                            if (!this.DangerName.Contains("TC5"))
                            {
                                this.angerLevel = 7;
                            }
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
                    else
                    {
                        if (!string.IsNullOrEmpty(this.DangerName))
                        {
                            if (!this.DangerName.Contains("TC6"))
                            {
                                this.angerLevel = 7;
                            }
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
                    else
                    {
                        if (!string.IsNullOrEmpty(this.DangerName))
                        {
                            if (!this.DangerName.Contains("TC7"))
                            {
                                this.angerLevel = 7;
                            }
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
                    else
                    {
                        if (!string.IsNullOrEmpty(this.DangerName))
                        {
                            if (!this.DangerName.Contains("TC8"))
                            {
                                this.angerLevel = 7;
                            }
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
                    else
                    {
                        if (!string.IsNullOrEmpty(this.DangerName))
                        {
                            if (!this.DangerName.Contains("TC9"))
                            {
                                this.angerLevel = 7;
                            }
                        }
                    }
                }
                if ((this.PissedAtTC0a > 20) && this.target.name.Contains("TC0a"))
                {
                    this.WarningLightOn = true;
                    this.WarningLight.gameObject.SetActive(true);
                }
                if ((this.PissedAtTC1 > 20) && this.target.name.Contains("TC1"))
                {
                    this.WarningLightOn = true;
                    this.WarningLight.gameObject.SetActive(true);
                }
                if ((this.PissedAtTC3 > 20) && this.target.name.Contains("TC3"))
                {
                    this.WarningLightOn = true;
                    this.WarningLight.gameObject.SetActive(true);
                }
                if ((this.PissedAtTC5 > 20) && this.target.name.Contains("TC5"))
                {
                    this.WarningLightOn = true;
                    this.WarningLight.gameObject.SetActive(true);
                }
                if ((this.PissedAtTC6 > 20) && this.target.name.Contains("TC6"))
                {
                    this.WarningLightOn = true;
                    this.WarningLight.gameObject.SetActive(true);
                }
                if ((this.PissedAtTC7 > 20) && this.target.name.Contains("TC7"))
                {
                    this.WarningLightOn = true;
                    this.WarningLight.gameObject.SetActive(true);
                }
                if ((this.PissedAtTC8 > 20) && this.target.name.Contains("TC8"))
                {
                    this.WarningLightOn = true;
                    this.WarningLight.gameObject.SetActive(true);
                }
                if ((this.PissedAtTC9 > 20) && this.target.name.Contains("TC9"))
                {
                    this.WarningLightOn = true;
                    this.WarningLight.gameObject.SetActive(true);
                }
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
                            if (this.angerLevel < 75)
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
                        if (this.angerLevel < 76)
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
                if (this.angerLevel > 75)
                {
                    if (!Physics.Linecast(this.thisTransform.position, this.target.position, (int) this.MtargetLayers))
                    {
                        this.InView = true;
                    }
                }
            }
            else
            {
                this.target = this.Waypoint;
            }
        }
        else
        {
            if (this.target)
            {
                if (this.target.name.Contains("TC"))
                {
                    if (!this.target.name.Contains("C2") && !this.target.name.Contains("C1"))
                    {
                        this.interrogating = false;
                    }
                }
            }
        }
        this.InView = false;
        this.Upforce = false;
        this.OnHull = false;
        if (this.TrigTick > 0)
        {
            this.TrigTick = this.TrigTick - 1;
        }
        else
        {
            if (this.target)
            {
                if ((this.angerLevel > 75) && this.target.name.Contains("TC"))
                {
                    this.Trig.center = new Vector3(0, 0, 0);
                    this.Trig.radius = 250;
                    this.Trig.height = 250;
                }
            }
        }
        this.DangerName = null;
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
        if (this.interrogating)
        {
            if (this.InterrogateTimer == 1)
            {
                this.StartCoroutine(this.ProcessSpeech(""));
            }
            this.InterrogateTimer = this.InterrogateTimer - 1;
        }
    }

    public virtual IEnumerator Subduing()
    {
        GameObject TheSubduer1 = UnityEngine.Object.Instantiate(this.SubduerPrefab, this.SubduerSpawn1.transform.position, this.SubduerSpawn1.transform.rotation);
        TheSubduer1.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
        ((SubduerMissileAI) TheSubduer1.transform.GetComponent(typeof(SubduerMissileAI))).target = this.target;
        this.SubduerSpawn1.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        GameObject TheSubduer2 = UnityEngine.Object.Instantiate(this.SubduerPrefab, this.SubduerSpawn2.transform.position, this.SubduerSpawn2.transform.rotation);
        TheSubduer2.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
        ((SubduerMissileAI) TheSubduer2.transform.GetComponent(typeof(SubduerMissileAI))).target = this.target;
        this.SubduerSpawn1.SetActive(false);
    }

    //========================================================================================================================//
    //////////////////////////////////////////////////////[INTERACTION]/////////////////////////////////////////////////////////
    //========================================================================================================================//
    public int convNum;
    public virtual IEnumerator ProcessSpeech(string speech)//===============================================================================
    {
        yield return new WaitForSeconds(0.1f);
        if (this.interrogating)
        {
            if (this.convNum == 0)
            {
                //===============================================================================
                this.convNum = 1;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("User of the Kabrian vessel, \n identify yourself immediately!");
                this.InterrogateTimer = 28;
                yield break;
            }
            //===============================================================================
            if (this.convNum == 1)
            {
                //===============================================================================
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("You are not a registered user. \n Prepare to be subdued.");
                this.convNum = 2;
                WorldInformation.PiriExposed = 120;
                this.interrogating = false;
                if (AgrianNetwork.instance.AlertTime < 300)
                {
                    AgrianNetwork.instance.AlertTime = 300;
                }
                AgrianNetwork.TC1CriminalLevel = 620;
                AgrianNetwork.instance.FullPriorityWaypoint.transform.position = this.target.position;
                AgrianNetwork.instance.RedAlertTime = 300;
                if (!this.WarningLightOn)
                {
                    this.WarningLightOn = true;
                    this.WarningLight.gameObject.SetActive(true);
                    this.angerLevel = 240;
                    this.Warning = true;
                    GameObject TheThingS = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position, this.thisTransform.rotation);
                    TheThingS.transform.parent = this.thisTransform;
                }
                yield break;
            }
        }
    }

    public virtual void ReturnSpeech(string yourText)
    {
        GameObject Load = ((GameObject) Resources.Load("Prefabs/TalkBubble", typeof(GameObject))) as GameObject;
        GameObject TGO = UnityEngine.Object.Instantiate(Load, this.thisTransform.position, Load.transform.rotation);
        TGO.name = "CFC2";
        TalkBubbleScript.myText = yourText;
        ((TalkBubbleScript) TGO.GetComponent(typeof(TalkBubbleScript))).source = this.thisVTransform;
    }

    public AgrianLoucuratAI()
    {
        this.DirForce = 200;
        this.RayDist = 2;
        this.ObsDist = 100;
    }

}