using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PiriDefenseDroneAI : MonoBehaviour
{
    public Transform target;
    public Transform ForwardAim;
    public Transform Waypoint;
    public Transform Waypoint2;
    public Transform Homepoint;
    public Transform Settlepoint;
    public Transform otherObject;
    public Transform thisTransform;
    public GameObject thisGameObject;
    public Rigidbody thisRigidbody;
    public Transform thisVTransform;
    public GameObject Vessel;
    public CapsuleCollider Trig;
    public Transform Muzzle0;
    public Transform Muzzle1;
    public Transform Muzzle2;
    public AudioSource EngineAudio;
    public SoundObscure EngineObscurer;
    public WingScript Wing1;
    public WingScript Wing2;
    public TCInfo Presence;
    public Transform TargetTrace;
    public Transform TargetLead;
    public SphereCollider TLCol;
    public ConfigurableJoint ConfJ;
    public GameObject Shot;
    public GameObject Diverter;
    public GameObject SpotSound;
    public GameObject AttackSound;
    public int PissedAtTC0a;
    public int PissedAtTC2;
    public int PissedAtTC3;
    public int PissedAtTC4;
    public int PissedAtTC5;
    public int PissedAtTC6;
    public int PissedAtTC7;
    public int PissedAtTC8;
    public int PissedAtTC9;
    public int Runtime;
    public bool Settling;
    public bool Activated;
    public bool OnStartup;
    public bool EngineOn;
    public bool Spot;
    public bool Patrolling;
    public bool Attacking;
    public bool Farstacle;
    public bool Roofstacle;
    public bool Floorstacle;
    public bool Obstacle;
    public bool Stuck;
    public bool TargetTooClose;
    public bool Circle;
    public bool Far;
    public int Stuckage;
    public bool HomeIsMoving;
    public static bool Assisting;
    public Transform IncomingMissile;
    public Transform EnteredMissile;
    public bool CanDivert;
    public float RightDist;
    public float LeftDist;
    public bool Proceed;
    public bool TurnRight;
    public bool TurnLeft;
    public bool LineOfFire;
    public bool DangerSense;
    public Vector3 DangerDirection;
    public LayerMask targetLayers;
    public LayerMask targetLayers2;
    public LayerMask targetLayers3;
    public int Dodge;
    public int JustNoticed;
    public int AngerLevel;
    public float GyroForce;
    public float TurnForce;
    public float TurnMod;
    private float VelC;
    private float TFSideNum;
    public float UniqueShootTime;
    public virtual void Start()
    {
        this.InvokeRepeating("Counter", 1.9f, 1);
        this.InvokeRepeating("Regenerator", 1, 0.43f);
        this.InvokeRepeating("LeaveMarker", 1, 3);
        this.InvokeRepeating("Shooty", this.UniqueShootTime, 0.32f);
        this.InvokeRepeating("CalcLead", 1, 0.15f);
        this.thisTransform = this.transform;
        GameObject thisGameobject = this.gameObject;
        this.thisRigidbody = this.GetComponent<Rigidbody>();
        this.thisVTransform = this.Vessel.transform;
        if (this.OnStartup)
        {
            this.Runtime = 60;
        }
        this.target = this.Waypoint;
        this.UniqueShootTime = Random.Range(0, 0.2f);
        this.GetComponent<Rigidbody>().centerOfMass = new Vector3(0, 0, 0);
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        RaycastHit hit2 = default(RaycastHit);
        RaycastHit hit3 = default(RaycastHit);
        if (this.Activated)
        {
            Vector3 localV = this.thisVTransform.InverseTransformDirection(this.Vessel.GetComponent<Rigidbody>().velocity);
            float totalV = this.Vessel.GetComponent<Rigidbody>().velocity.magnitude;
            Vector3 mainRot = -this.thisVTransform.up.normalized;
            this.VelC = Mathf.Clamp(totalV, 6, 400);
            this.LineOfFire = false;
            if (Physics.Raycast(this.thisVTransform.position + (-this.thisVTransform.up * 1), -this.thisVTransform.up, out hit, 600, (int) this.targetLayers3))
            {
                if (hit.collider.name.Contains("TC") || hit.collider.name.Contains("TLead"))
                {
                    if (!hit.collider.name.Contains("TC1"))
                    {
                        this.LineOfFire = true;
                    }
                }
            }
            if (this.IncomingMissile)
            {
                this.target = this.IncomingMissile;

                {
                    float _2650 = 0.4f;
                    JointDrive _2651 = this.ConfJ.angularYZDrive;
                    _2651.maximumForce = _2650;
                    this.ConfJ.angularYZDrive = _2651;
                }

                {
                    float _2652 = 0.4f;
                    JointDrive _2653 = this.ConfJ.angularXDrive;
                    _2653.maximumForce = _2652;
                    this.ConfJ.angularXDrive = _2653;
                }
                this.GyroForce = 2;
            }
            if (this.target)
            {
                if (((this.target == this.EnteredMissile) && this.target.name.Contains("MT")) && this.CanDivert)
                {
                    GameObject TheThing0 = UnityEngine.Object.Instantiate(this.Diverter, this.Muzzle0.position, this.Muzzle0.rotation);
                    TheThing0.transform.parent = this.Muzzle0;
                    if (this.target.gameObject.GetComponent<MissileScript>() != null)
                    {
                        this.target.gameObject.GetComponent<MissileScript>().AimForce = 0;
                    }
                    this.CanDivert = false;
                }
                if (this.Attacking)
                {
                    if (Vector3.Distance(this.thisTransform.position, this.target.position) < 30)
                    {
                        this.TargetTooClose = true;
                    }
                    this.Patrolling = false;
                }
            }
            if ((this.target == null) || !this.target.name.Contains("TC"))
            {
                if (this.Spot || this.Attacking)
                {
                    this.AngerLevel = 2;
                    this.Spot = false;
                    this.Attacking = false;
                    this.target = this.ForwardAim;
                }
            }
            if (this.TurnLeft)
            {
                if (!this.Spot)
                {
                    this.TurnForce = -14;
                }
            }
            if (this.TurnRight)
            {
                if (!this.Spot)
                {
                    this.TurnForce = 14;
                }
            }
            if (this.TurnLeft && this.TurnRight)
            {
                this.TurnForce = -14;
            }
            if (!this.TurnLeft && !this.TurnRight)
            {
                this.TurnForce = 0;
            }
            if (!this.Settling)
            {
                if (this.Patrolling)
                {
                    if (this.TFSideNum < 1.7f)
                    {
                        this.TFSideNum = this.TFSideNum + 0.3f;
                    }
                    else
                    {
                        this.TFSideNum = 0.5f;
                    }
                    Debug.DrawRay(((this.thisVTransform.position + (-this.thisVTransform.up * 1)) + (this.thisVTransform.forward * -0.4f)) + (this.thisVTransform.right * this.TFSideNum), mainRot * this.VelC, Color.black);
                    if (Physics.Raycast(((this.thisVTransform.position + (-this.thisVTransform.up * 1)) + (this.thisVTransform.forward * -0.4f)) + (this.thisVTransform.right * this.TFSideNum), mainRot, out hit, this.VelC, (int) this.targetLayers))
                    {
                        this.RightDist = hit.distance;
                    }
                    else
                    {
                        this.RightDist = 200;
                    }
                    Debug.DrawRay(((this.thisVTransform.position + (-this.thisVTransform.up * 1)) + (this.thisVTransform.forward * -0.4f)) + (-this.thisVTransform.right * this.TFSideNum), mainRot * this.VelC, Color.black);
                    if (Physics.Raycast(((this.thisVTransform.position + (-this.thisVTransform.up * 1)) + (this.thisVTransform.forward * -0.4f)) + (-this.thisVTransform.right * this.TFSideNum), mainRot, out hit, this.VelC, (int) this.targetLayers))
                    {
                        this.LeftDist = hit.distance;
                    }
                    else
                    {
                        this.LeftDist = 200;
                    }
                    if (this.RightDist > this.LeftDist)
                    {
                        TurnLeft = false;
                        this.TurnRight = true;
                    }
                    if (this.LeftDist > this.RightDist)
                    {
                        this.TurnRight = false;
                        this.TurnLeft = true;
                    }
                    if (this.RightDist == this.LeftDist)
                    {
                        this.TurnRight = false;
                        this.TurnLeft = false;
                    }
                    Debug.DrawRay(((this.thisTransform.position + (this.thisVTransform.forward * 3)) + (this.thisVTransform.right * 4)) + (-this.thisVTransform.up * this.VelC), -this.thisVTransform.forward * 10, Color.white);
                    if (!Physics.Raycast(((this.thisTransform.position + (this.thisVTransform.forward * 3)) + (this.thisVTransform.right * 4)) + (-this.thisVTransform.up * this.VelC), -this.thisVTransform.forward, 10, (int) this.targetLayers))
                    {
                        this.TurnLeft = true;
                    }
                    Debug.DrawRay(((this.thisTransform.position + (this.thisVTransform.forward * 3)) + (-this.thisVTransform.right * 4)) + (-this.thisVTransform.up * this.VelC), -this.thisVTransform.forward * 10, Color.white);
                    if (!Physics.Raycast(((this.thisTransform.position + (this.thisVTransform.forward * 3)) + (-this.thisVTransform.right * 4)) + (-this.thisVTransform.up * this.VelC), -this.thisVTransform.forward, 10, (int) this.targetLayers))
                    {
                        this.TurnRight = true;
                    }
                    Debug.DrawRay((this.thisTransform.position + (this.thisVTransform.forward * 3)) + (-this.thisVTransform.up * this.VelC), -this.thisVTransform.forward * 10, Color.white);
                    if (!Physics.Raycast((this.thisTransform.position + (this.thisVTransform.forward * 3)) + (-this.thisVTransform.up * this.VelC), -this.thisVTransform.forward, 10, (int) this.targetLayers))
                    {
                        Debug.DrawRay(this.thisTransform.position + (-this.thisVTransform.forward * 0.5f), -this.thisVTransform.forward * 10, Color.white);
                        if (Physics.Raycast(this.thisTransform.position + (-this.thisVTransform.forward * 0.5f), -this.thisVTransform.forward, 10, (int) this.targetLayers))
                        {
                            this.Obstacle = true;
                            this.TurnLeft = true;
                        }
                    }
                    Debug.DrawRay((this.transform.position + (-this.thisVTransform.up * 1)) + (this.thisVTransform.forward * -0.4f), -this.thisVTransform.up * this.VelC, Color.white);
                    if (Physics.Raycast((this.transform.position + (-this.thisVTransform.up * 1)) + (this.thisVTransform.forward * -0.4f), -this.thisVTransform.up, out hit2, this.VelC, (int) this.targetLayers))
                    {
                        this.Obstacle = true;
                        if (!this.TurnLeft && !this.TurnRight)
                        {
                            this.TurnLeft = true;
                        }
                        Debug.DrawRay((this.transform.position + (-this.thisVTransform.up * 1)) + (-this.thisVTransform.forward * 0.3f), -this.thisVTransform.up * 8, Color.green);
                        if (Physics.Raycast((this.transform.position + (-this.thisVTransform.up * 1)) + (-this.thisVTransform.forward * 0.3f), -this.thisVTransform.up, out hit3, 8, (int) this.targetLayers))
                        {
                            float Spacing = Mathf.Abs(hit2.distance - hit3.distance);
                            if ((Spacing > 0.2f) && (totalV < 5))
                            {
                                this.Obstacle = false;
                                this.TurnForce = 0;
                            }
                        }
                    }
                    if (this.otherObject)
                    {
                        Vector3 relativePoint1 = this.thisVTransform.InverseTransformPoint(this.otherObject.position);
                        if (-relativePoint1.y > 0)
                        {
                            if (Vector3.Distance(this.otherObject.position, this.thisTransform.position) < 7)
                            {
                                if ((relativePoint1.x > 0) && !this.Proceed)
                                {
                                    this.Obstacle = true;
                                }
                            }
                        }
                    }
                }
                else
                {
                    Vector3 newRot = ((-this.thisVTransform.up * 0.6f) + (this.thisVTransform.right * 0.2f)).normalized;
                    Debug.DrawRay((this.transform.position + (-this.thisVTransform.up * 1.5f)) + (this.thisVTransform.forward * -0.4f), newRot * 6, Color.black);
                    if (Physics.Raycast((this.transform.position + (-this.thisVTransform.up * 1.5f)) + (this.thisVTransform.forward * -0.4f), newRot, 6, (int) this.targetLayers))
                    {
                        if (this.JustNoticed < 1)
                        {
                            this.TurnLeft = true;
                        }
                    }
                    else
                    {
                        if (!this.Obstacle && !this.TurnRight)
                        {
                            this.TurnLeft = false;
                        }
                    }
                    newRot = ((-this.thisVTransform.up * 0.6f) + (this.thisVTransform.right * -0.2f)).normalized;
                    Debug.DrawRay((this.transform.position + (-this.thisVTransform.up * 1.5f)) + (this.thisVTransform.forward * -0.4f), newRot * 6, Color.black);
                    if (Physics.Raycast((this.transform.position + (-this.thisVTransform.up * 1.5f)) + (this.thisVTransform.forward * -0.4f), newRot, 6, (int) this.targetLayers))
                    {
                        if (this.JustNoticed < 1)
                        {
                            this.TurnRight = true;
                        }
                    }
                    else
                    {
                        if (!this.Obstacle && !this.TurnLeft)
                        {
                            this.TurnRight = false;
                        }
                    }
                    Debug.DrawRay((this.transform.position + (-this.thisVTransform.up * 1.5f)) + (this.thisVTransform.forward * -0.4f), -this.thisVTransform.up * this.VelC, Color.white);
                    if (Physics.Raycast((this.transform.position + (-this.thisVTransform.up * 1.5f)) + (this.thisVTransform.forward * -0.4f), -this.thisVTransform.up, this.VelC, (int) this.targetLayers))
                    {
                        this.Obstacle = true;
                        if (!this.TurnLeft && !this.TurnRight)
                        {
                            this.TurnLeft = true;
                        }
                    }
                    newRot = ((-this.thisVTransform.up * 0.6f) + (this.thisVTransform.forward * -0.2f)).normalized;
                    Debug.DrawRay(this.transform.position + (-this.thisVTransform.up * 1.5f), newRot * this.VelC, Color.blue);
                    if (Physics.Raycast(this.transform.position + (-this.thisVTransform.up * 1.5f), newRot, this.VelC, (int) this.targetLayers))
                    {
                        this.Floorstacle = true;
                    }
                }
                Debug.DrawRay(this.transform.position + (-this.thisVTransform.up * 1.5f), this.thisVTransform.forward * 20, Color.red);
                if (Physics.Raycast(this.transform.position + (-this.thisVTransform.up * 1.5f), this.thisVTransform.forward, 20, (int) this.targetLayers))
                {
                    if (!this.Patrolling)
                    {
                        this.Roofstacle = true;
                    }
                }
                if (this.Stuckage > 3)
                {
                    this.Patrolling = false;
                }
            }
        }
    }

    private Quaternion NewRotation;
    public virtual void FixedUpdate()
    {
        RaycastHit hit = default(RaycastHit);
        if (this.Activated)
        {
            Vector3 localV = this.thisVTransform.InverseTransformDirection(this.Vessel.GetComponent<Rigidbody>().velocity);
            if (this.Roofstacle)
            {
                if (((this.JustNoticed < 1) && !this.Attacking) && !this.Spot)
                {
                    this.Vessel.GetComponent<Rigidbody>().AddTorque(this.thisVTransform.right * 14);
                }
            }
            if (this.Floorstacle)
            {
                if (((this.JustNoticed < 1) && !this.Attacking) && !this.Spot)
                {
                    this.Vessel.GetComponent<Rigidbody>().AddTorque(this.thisVTransform.right * -14);
                }
            }
            if (this.Farstacle)
            {
                if (-localV.y > 0)
                {
                    this.Vessel.GetComponent<Rigidbody>().AddForce(this.thisVTransform.up * 6);
                }
            }
            if (this.TargetTooClose)
            {
                if (localV.y < 20)
                {
                    this.Vessel.GetComponent<Rigidbody>().AddForce(this.thisVTransform.up * 6);
                }
                if (!this.IncomingMissile)
                {
                    this.Vessel.GetComponent<Rigidbody>().AddForce(this.thisVTransform.right * 10);
                }
                else
                {
                    this.Vessel.GetComponent<Rigidbody>().AddForce(this.thisVTransform.right * 20);
                }
            }
            else
            {
                if (this.IncomingMissile)
                {
                    this.Vessel.GetComponent<Rigidbody>().AddForce(this.thisVTransform.right * 20);
                }
                if (this.Obstacle)
                {
                    if (this.Attacking)
                    {
                        if (-localV.y > 5)
                        {
                            this.Vessel.GetComponent<Rigidbody>().AddForce(this.thisVTransform.up * 6);
                        }
                        else
                        {
                            this.Vessel.GetComponent<Rigidbody>().AddForce(this.thisVTransform.up * -2);
                        }
                    }
                    else
                    {
                        if (!this.Patrolling)
                        {
                            if (-localV.y > 0)
                            {
                                this.Vessel.GetComponent<Rigidbody>().AddForce(this.thisVTransform.up * 6);
                            }
                        }
                        else
                        {
                            if (-localV.y > 0)
                            {
                                this.Vessel.GetComponent<Rigidbody>().AddForce(this.thisVTransform.up * 2);
                            }
                            if (-localV.y > 5)
                            {
                                this.Vessel.GetComponent<Rigidbody>().AddForce(this.thisVTransform.up * 6);
                            }
                        }
                    }
                }
                else
                {
                    if (!this.Obstacle && !this.Stuck)
                    {
                        if (!this.Patrolling)
                        {
                            if (!this.Far)
                            {
                                if (-localV.y < 30)
                                {
                                    this.Vessel.GetComponent<Rigidbody>().AddForce(this.thisVTransform.up * -1);
                                }
                            }
                            else
                            {
                                if (-localV.y < 60)
                                {
                                    this.Vessel.GetComponent<Rigidbody>().AddForce(this.thisVTransform.up * -2);
                                }
                            }
                        }
                        else
                        {
                            if (!this.HomeIsMoving)
                            {
                                if (-localV.y < 5)
                                {
                                    this.Vessel.GetComponent<Rigidbody>().AddForce(this.thisVTransform.up * -1);
                                }
                            }
                            else
                            {
                                if (-localV.y < 50)
                                {
                                    this.Vessel.GetComponent<Rigidbody>().AddForce(this.thisVTransform.up * -1);
                                }
                            }
                        }
                    }
                }
            }
            if (this.Stuck)
            {
                if (localV.y < 2)
                {
                    this.Vessel.GetComponent<Rigidbody>().AddForce(this.thisVTransform.up * 7);
                }
            }
            //----------------------------------------------------------------------------------------------------------------------
            this.Vessel.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.up * -this.GyroForce, -this.thisVTransform.forward * 2);
            this.Vessel.GetComponent<Rigidbody>().AddForceAtPosition(-Vector3.up * -this.GyroForce, this.thisVTransform.forward * 2);
            this.Vessel.GetComponent<Rigidbody>().AddTorque((this.thisVTransform.forward * this.TurnForce) * this.TurnMod);
            if (Physics.Raycast(this.thisTransform.position, Vector3.down, out hit, this.VelC * 0.5f, (int) this.targetLayers))
            {
                float Minus;
                if (this.VelC < 7)
                {
                    Minus = 4 - hit.distance;
                }
                else
                {
                    Minus = 7;
                }
                if (!this.TargetTooClose)
                {
                    this.thisRigidbody.AddForce(Vector3.up * Minus);
                }
                else
                {
                    this.thisRigidbody.AddForce(Vector3.up * 14);
                }
            }
            if (this.target)
            {
                if (!this.IncomingMissile)
                {
                    if (!this.Attacking)
                    {
                        if (!this.Circle)
                        {
                            this.NewRotation = Quaternion.LookRotation(this.target.position - this.thisTransform.position);
                        }
                        else
                        {
                            this.NewRotation = Quaternion.LookRotation(this.thisTransform.position - this.target.position);
                        }
                        if (this.DangerSense && (this.DangerDirection != Vector3.zero))
                        {
                            this.NewRotation = Quaternion.LookRotation(this.DangerDirection);
                        }
                    }
                    else
                    {
                        this.NewRotation = Quaternion.LookRotation(this.TargetLead.position - this.thisTransform.position);
                    }
                }
                else
                {
                    this.NewRotation = Quaternion.LookRotation(this.target.position - this.thisTransform.position);
                }
                if (!this.Settling)
                {
                    this.thisTransform.rotation = Quaternion.RotateTowards(this.thisTransform.rotation, this.NewRotation, Time.deltaTime * 400);
                }
                else
                {
                    this.thisTransform.rotation = Quaternion.RotateTowards(this.thisTransform.rotation, this.Settlepoint.rotation, Time.deltaTime * 400);
                    this.Vessel.GetComponent<Rigidbody>().AddForce((this.Settlepoint.position - this.thisTransform.position).normalized * 2);
                }
            }
            if (!this.EngineOn)
            {
                if (!this.EngineObscurer.Obscured)
                {
                    if (this.EngineAudio.volume < 0.5f)
                    {
                        this.EngineAudio.volume = this.EngineAudio.volume + 0.03f;
                    }
                    else
                    {
                        this.EngineOn = true;
                    }
                }
                else
                {
                    this.EngineOn = true;
                }
            }
        }
        else
        {
            if (this.EngineAudio.volume > 0)
            {
                this.EngineAudio.volume = this.EngineAudio.volume - 0.03f;
            }
            this.EngineOn = false;
        }
    }

    public virtual IEnumerator OnTriggerEnter(Collider other)
    {
        string ON = other.name;
        Transform OT = other.transform;
        if (ON.Contains("TC1p"))
        {
            this.Waypoint = OT;
        }
        if (ON.Contains("TC1z"))
        {
            this.Homepoint = OT;
            if ((!this.Attacking && (this.AngerLevel < 8)) && !PiriDefenseDroneAI.Assisting)
            {
                this.Waypoint2 = OT;
                this.Patrolling = true;
            }
        }
        if (this.Activated)
        {
            if (((ON.Contains("TC") && !ON.Contains("TC1")) && !this.Attacking) && (this.AngerLevel < 1))
            {
                if (this.target == this.ForwardAim)
                {
                    this.target = OT;
                }
                yield return new WaitForSeconds(0.1f);
                if (!this.Spot)
                {
                    this.Spot = true;
                    this.AngerLevel = 7;
                    if (this.EngineOn)
                    {
                        GameObject TheThing = UnityEngine.Object.Instantiate(this.SpotSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                        TheThing.transform.parent = this.thisTransform;
                    }
                }
            }
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        string ON = other.name;
        Transform OT = other.transform;
        if (ON.Contains("TC0"))
        {
            if (Vector3.Distance(OT.position, this.thisTransform.position) > 1)
            {
                if (Vector3.Distance(OT.position, this.thisTransform.position) < 10)
                {
                    this.otherObject = OT;
                }
            }
        }
        if (!this.IncomingMissile)
        {
            if (ON.Contains("MT"))
            {
                if (!ON.Contains("C1"))
                {
                    this.IncomingMissile = OT;
                    this.Activated = true;
                    this.Runtime = 60;
                    this.Trig.center = new Vector3(0, 0, 0);
                    this.Trig.radius = 100;
                    this.Trig.height = 100;
                }
            }
        }
        if (ON.Contains("TFC"))
        {
            if (this.AngerLevel < 20)
            {
                this.AngerLevel = this.AngerLevel + 1;
            }
            if (!ON.Contains("TFC1"))
            {
                if (!this.DangerSense)
                {
                    this.Trig.center = new Vector3(0, 0, 200);
                    this.Trig.radius = 100;
                    this.Trig.height = 400;
                    if (other.GetComponent<Rigidbody>())
                    {
                        this.DangerDirection = -other.GetComponent<Rigidbody>().velocity.normalized;
                    }
                    this.DangerSense = true;
                }
                if (this.EngineOn)
                {
                    if (!this.Attacking && (this.AngerLevel < 3))
                    {
                        GameObject TheThing1 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                        TheThing1.transform.parent = this.thisTransform;
                        this.AngerLevel = 20;
                    }
                }
            }
            this.Activated = true;
            this.Runtime = 60;
        }
        if (this.Activated)
        {
            if (!this.Settling && (this.Runtime > 0))
            {
                if (ON.Contains("TFC0a"))
                {
                    if (this.PissedAtTC0a < 201)
                    {
                        if (Vector3.Distance(OT.position, this.thisTransform.position) < 128)
                        {
                            Vector3 rPoint0 = this.thisVTransform.InverseTransformPoint(this.Waypoint.transform.position);
                            if (rPoint0.z > 0)
                            {
                                if (Vector3.Distance(OT.position, this.Waypoint.position) > 25)
                                {
                                    this.PissedAtTC0a = this.PissedAtTC0a + 50;
                                }
                                else
                                {
                                    this.PissedAtTC0a = 200;
                                }
                            }
                        }
                    }
                }
                if (ON.Contains("TFC2"))
                {
                    if (this.PissedAtTC2 < 201)
                    {
                        if (Vector3.Distance(OT.position, this.thisTransform.position) < 50)
                        {
                            Vector3 rPoint2 = this.thisVTransform.InverseTransformPoint(this.Waypoint.transform.position);
                            if (rPoint2.z > 0)
                            {
                                if (Vector3.Distance(OT.position, this.Waypoint.position) > 25)
                                {
                                    this.PissedAtTC2 = this.PissedAtTC2 + 50;
                                }
                                else
                                {
                                    this.PissedAtTC2 = 200;
                                }
                            }
                        }
                    }
                }
                if (ON.Contains("TFC3"))
                {
                    if (this.PissedAtTC3 < 201)
                    {
                        if (Vector3.Distance(OT.position, this.thisTransform.position) < 128)
                        {
                            Vector3 rPoint3 = this.thisVTransform.InverseTransformPoint(this.Waypoint.transform.position);
                            if (rPoint3.z > 0)
                            {
                                if (Vector3.Distance(OT.position, this.Waypoint.position) > 25)
                                {
                                    this.PissedAtTC3 = this.PissedAtTC3 + 50;
                                }
                                else
                                {
                                    this.PissedAtTC3 = 200;
                                }
                            }
                        }
                    }
                }
                if (ON.Contains("TFC4"))
                {
                    this.PissedAtTC4 = 200;
                }
                if (ON.Contains("TFC5"))
                {
                    if (this.PissedAtTC5 < 201)
                    {
                        if (Vector3.Distance(OT.position, this.thisTransform.position) < 128)
                        {
                            Vector3 rPoint5 = this.thisVTransform.InverseTransformPoint(this.Waypoint.transform.position);
                            if (rPoint5.z > 0)
                            {
                                if (Vector3.Distance(OT.position, this.Waypoint.position) > 25)
                                {
                                    this.PissedAtTC5 = this.PissedAtTC5 + 50;
                                }
                                else
                                {
                                    this.PissedAtTC5 = 200;
                                }
                            }
                        }
                    }
                }
                if (ON.Contains("TFC6"))
                {
                    this.PissedAtTC6 = 200;
                }
                if (ON.Contains("TFC7"))
                {
                    this.PissedAtTC7 = 200;
                }
                if (ON.Contains("TFC8"))
                {
                    this.PissedAtTC8 = 200;
                }
                if (ON.Contains("TFC9"))
                {
                    this.PissedAtTC9 = 200;
                }
                if (!this.IncomingMissile)
                {
                    if (ON.Contains("TC0a") && (this.PissedAtTC0a > 0))
                    {
                        float Dist0;
                        if (this.target)
                        {
                            if (this.target != this.Waypoint)
                            {
                                Dist0 = Vector3.Distance(this.target.position, this.Waypoint.position);
                            }
                            else
                            {
                                Dist0 = 200;
                            }
                        }
                        else
                        {
                            Dist0 = 200;
                        }
                        if (Vector3.Distance(OT.position, this.Waypoint.position) < Dist0)
                        {
                            this.target = OT;
                            this.Spot = false;
                            this.Attacking = true;
                        }
                        this.Trig.center = new Vector3(0, 0, 0);
                        this.Trig.radius = 100;
                        this.Trig.height = 100;
                    }
                    if (ON.Contains("TC2") && (this.PissedAtTC2 > 180))
                    {
                        if (ON.Contains("2_P"))
                        {
                            float Dist1;
                            if (this.target)
                            {
                                if (this.target != this.Waypoint)
                                {
                                    Dist1 = Vector3.Distance(this.target.position, this.Waypoint.position);
                                }
                                else
                                {
                                    Dist1 = 200;
                                }
                            }
                            else
                            {
                                Dist1 = 200;
                            }
                            if (Vector3.Distance(OT.position, this.Waypoint.position) < Dist1)
                            {
                                this.target = OT;
                                this.Spot = false;
                                this.Attacking = true;
                            }
                            this.Trig.center = new Vector3(0, 0, 0);
                            this.Trig.radius = 100;
                            this.Trig.height = 100;
                        }
                    }
                    if (ON.Contains("TC3") && (this.PissedAtTC3 > 180))
                    {
                        float Dist2;
                        if (this.target)
                        {
                            if (this.target != this.Waypoint)
                            {
                                Dist2 = Vector3.Distance(this.target.position, this.Waypoint.position);
                            }
                            else
                            {
                                Dist2 = 200;
                            }
                        }
                        else
                        {
                            Dist2 = 200;
                        }
                        if (Vector3.Distance(OT.position, this.Waypoint.position) < Dist2)
                        {
                            this.target = OT;
                            this.Spot = false;
                            this.Attacking = true;
                        }
                        this.Trig.center = new Vector3(0, 0, 0);
                        this.Trig.radius = 100;
                        this.Trig.height = 100;
                    }
                    if (ON.Contains("TC4") && (this.PissedAtTC4 > 0))
                    {
                        float Dist3;
                        if (this.target)
                        {
                            if (this.target != this.Waypoint)
                            {
                                Dist3 = Vector3.Distance(this.target.position, this.Waypoint.position);
                            }
                            else
                            {
                                Dist3 = 200;
                            }
                        }
                        else
                        {
                            Dist3 = 200;
                        }
                        if (Vector3.Distance(OT.position, this.Waypoint.position) < Dist3)
                        {
                            this.target = OT;
                            this.Spot = false;
                            this.Attacking = true;
                        }
                        this.Trig.center = new Vector3(0, 0, 0);
                        this.Trig.radius = 100;
                        this.Trig.height = 100;
                    }
                    if (ON.Contains("TC5") && (this.PissedAtTC5 > 180))
                    {
                        float Dist4;
                        if (this.target)
                        {
                            if (this.target != this.Waypoint)
                            {
                                Dist4 = Vector3.Distance(this.target.position, this.Waypoint.position);
                            }
                            else
                            {
                                Dist4 = 200;
                            }
                        }
                        else
                        {
                            Dist4 = 200;
                        }
                        if (Vector3.Distance(OT.position, this.Waypoint.position) < Dist4)
                        {
                            this.target = OT;
                            this.Spot = false;
                            this.Attacking = true;
                        }
                        this.Trig.center = new Vector3(0, 0, 0);
                        this.Trig.radius = 100;
                        this.Trig.height = 100;
                    }
                    if (ON.Contains("TC6"))
                    {
                        if (!ON.Contains("cT"))
                        {
                            float Dist5;
                            if (this.target)
                            {
                                if (this.target != this.Waypoint)
                                {
                                    Dist5 = Vector3.Distance(this.target.position, this.Waypoint.position);
                                }
                                else
                                {
                                    Dist5 = 200;
                                }
                            }
                            else
                            {
                                Dist5 = 200;
                            }
                            if (Vector3.Distance(OT.position, this.Waypoint.position) < Dist5)
                            {
                                this.target = OT;
                                this.Spot = false;
                                this.Attacking = true;
                            }
                            this.Trig.center = new Vector3(0, 0, 0);
                            this.Trig.radius = 100;
                            this.Trig.height = 100;
                        }
                    }
                    if (ON.Contains("TC7"))
                    {
                        if (ON.Contains("sTC7"))
                        {
                            this.PissedAtTC7 = 20;
                        }
                        if (this.PissedAtTC7 > 0)
                        {
                            float Dist6;
                            if (this.target)
                            {
                                if (this.target != this.Waypoint)
                                {
                                    Dist6 = Vector3.Distance(this.target.position, this.Waypoint.position);
                                }
                                else
                                {
                                    Dist6 = 200;
                                }
                            }
                            else
                            {
                                Dist6 = 200;
                            }
                            if (Vector3.Distance(OT.position, this.Waypoint.position) < Dist6)
                            {
                                this.target = OT;
                                this.Spot = false;
                                this.Attacking = true;
                            }
                        }
                        this.Trig.center = new Vector3(0, 0, 0);
                        this.Trig.radius = 100;
                        this.Trig.height = 100;
                    }
                    if (ON.Contains("TC8"))
                    {
                        if (ON.Contains("sTC8"))
                        {
                            this.PissedAtTC8 = 20;
                        }
                        if (this.PissedAtTC8 > 0)
                        {
                            float Dist7;
                            if (this.target)
                            {
                                if (this.target != this.Waypoint)
                                {
                                    Dist7 = Vector3.Distance(this.target.position, this.Waypoint.position);
                                }
                                else
                                {
                                    Dist7 = 200;
                                }
                            }
                            else
                            {
                                Dist7 = 200;
                            }
                            if (Vector3.Distance(OT.position, this.Waypoint.position) < Dist7)
                            {
                                this.target = OT;
                                this.Spot = false;
                                this.Attacking = true;
                            }
                        }
                        this.Trig.center = new Vector3(0, 0, 0);
                        this.Trig.radius = 100;
                        this.Trig.height = 100;
                    }
                    if (ON.Contains("TC9"))
                    {
                        if (ON.Contains("sTC9"))
                        {
                            this.PissedAtTC9 = 20;
                        }
                        if (this.PissedAtTC9 > 0)
                        {
                            float Dist8;
                            if (this.target)
                            {
                                if (this.target != this.Waypoint)
                                {
                                    Dist8 = Vector3.Distance(this.target.position, this.Waypoint.position);
                                }
                                else
                                {
                                    Dist8 = 200;
                                }
                            }
                            else
                            {
                                Dist8 = 200;
                            }
                            if (Vector3.Distance(OT.position, this.Waypoint.position) < Dist8)
                            {
                                this.target = OT;
                                this.Spot = false;
                                this.Attacking = true;
                            }
                        }
                        this.Trig.center = new Vector3(0, 0, 0);
                        this.Trig.radius = 100;
                        this.Trig.height = 100;
                    }
                }
            }
        }
    }

    public virtual IEnumerator Shoot()
    {
        if (this.Attacking)
        {
            if (this.LineOfFire)
            {
                GameObject TheThing1 = UnityEngine.Object.Instantiate(this.Shot, this.Muzzle1.position, this.Muzzle1.rotation);
                TheThing1.transform.parent = this.Muzzle1;
            }
            yield return new WaitForSeconds(0.16f);
            if (this.LineOfFire)
            {
                GameObject TheThing2 = UnityEngine.Object.Instantiate(this.Shot, this.Muzzle2.position, this.Muzzle2.rotation);
                TheThing2.transform.parent = this.Muzzle2;
            }
        }
    }

    public virtual void Shooty()
    {
        if (this.Activated)
        {
            this.StartCoroutine(this.Shoot());
        }
    }

    public virtual void CalcLead()
    {
        if (this.Activated)
        {
            this.StartCoroutine(this.Lead());
            if (this.IncomingMissile)
            {
                if (this.IncomingMissile.name.Contains("Br"))
                {
                    this.IncomingMissile = null;
                }
            }
            if (this.IncomingMissile)
            {
                if (Vector3.Distance(this.IncomingMissile.position, this.Waypoint.position) > 100)
                {
                    this.IncomingMissile = null;
                }
            }
            this.CanDivert = true;
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
            float Dist11 = Mathf.Clamp(Dist1, 110, 2000);
            float Dist2 = Vector3.Distance(this.TargetTrace.position, this.target.position);
            this.TargetTrace.LookAt(this.target);
            this.TargetLead.position = this.TargetTrace.position;
            this.TargetLead.rotation = this.TargetTrace.rotation;
            this.TargetLead.position = this.TargetLead.position + (((this.TargetLead.forward * Dist11) * Dist2) * 0.025f);
            if (this.Attacking)
            {
                this.TLCol.radius = Dist1 * 0.05f;
            }
            else
            {
                this.TLCol.radius = 0.1f;
            }
        }
    }

    public virtual void LeaveMarker()
    {
        if (this.Activated)
        {
            Vector3 lastPos = this.thisTransform.position;
            if (this.Waypoint2)
            {
                Vector3 lastHPos = this.Waypoint2.position;
            
                if (!this.Settling)
                {
                    this.StartCoroutine(this.IsEscaping(lastPos, lastHPos));
                }
            }
            this.Proceed = false;
            if (this.Obstacle)
            {
                if (!this.TurnLeft && !this.TurnRight)
                {
                    if (this.otherObject)
                    {
                        if (Vector3.Distance(this.otherObject.position, this.thisTransform.position) < 8)
                        {
                            this.Presence.IAmNumber = Random.Range(0, 9);
                            if (this.otherObject.gameObject.GetComponent<TCInfo>() != null)
                            {
                                if ((this.otherObject.gameObject.GetComponent<TCInfo>().IAmNumber < this.Presence.IAmNumber) && (this.otherObject.gameObject.GetComponent<TCInfo>().IAmStopping != null))
                                {
                                    otherObject = null;
                                    this.Proceed = true;
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public virtual IEnumerator IsEscaping(Vector3 lastPos, Vector3 lastHPos)
    {
        this.Stuck = false;
        yield return new WaitForSeconds(1);
        if (Vector3.Distance(this.thisTransform.position, lastPos) < 0.5f)
        {
            if (this.Stuckage < 4)
            {
                this.Stuckage = this.Stuckage + 1;
            }
            this.Stuck = true;
            yield return new WaitForSeconds(2);
            this.Stuck = false;
        }
        else
        {
            if (this.Stuckage > 0)
            {
                this.Stuckage = this.Stuckage - 1;
            }
        }
        if (this.Waypoint2)
        {
            if (Vector3.Distance(this.Waypoint2.position, lastHPos) > 3)
            {
                this.HomeIsMoving = true;
            }
            else
            {
                this.HomeIsMoving = false;
            }
        }
        else
        {
            this.HomeIsMoving = false;
        }
    }

    public virtual void Counter()
    {
        if (this.Activated)
        {
            if (this.Runtime > 0)
            {
                this.Runtime = this.Runtime - 1;
            }
            if (this.Settling)
            {
                this.Runtime = this.Runtime - 1;
                if (this.Runtime < -5)
                {
                    this.Activated = false;
                    this.Settling = false;
                }
            }
        }
        else
        {
            if (this.Runtime < 60)
            {
                this.Runtime = this.Runtime + 1;
            }
            if (this.Runtime == 60)
            {
                this.Activated = true;
            }
        }
        this.DangerSense = false;
        this.Trig.center = new Vector3(0, 0, 0);
        this.Trig.radius = 100;
        this.Trig.height = 100;
    }

    public virtual void Regenerator()
    {
        if (this.Activated)
        {
            this.GetComponent<Rigidbody>().freezeRotation = true;
            this.Wing1.Broken = false;
            this.Wing2.Broken = false;
            if (!this.IncomingMissile)
            {
                if (((!this.Floorstacle && !this.Roofstacle) && !this.TurnRight) && !this.TurnLeft)
                {
                    if (this.Attacking)
                    {
                        this.Runtime = 120;
                        this.Settling = false;
                        this.GyroForce = 4;
                        this.TurnMod = 1;
                        this.Vessel.GetComponent<Rigidbody>().angularDrag = 24;

                        {
                            float _2654 = 0.2f;
                            JointDrive _2655 = this.ConfJ.angularYZDrive;
                            _2655.maximumForce = _2654;
                            this.ConfJ.angularYZDrive = _2655;
                        }

                        {
                            float _2656 = 0.1f;
                            JointDrive _2657 = this.ConfJ.angularXDrive;
                            _2657.maximumForce = _2656;
                            this.ConfJ.angularXDrive = _2657;
                        }
                    }
                    else
                    {
                        if (!this.Patrolling)
                        {
                            this.GyroForce = 4;
                            this.TurnMod = 1;
                            this.Vessel.GetComponent<Rigidbody>().angularDrag = 24;

                            {
                                float _2658 = 0.1f;
                                JointDrive _2659 = this.ConfJ.angularYZDrive;
                                _2659.maximumForce = _2658;
                                this.ConfJ.angularYZDrive = _2659;
                            }

                            {
                                float _2660 = 0.05f;
                                JointDrive _2661 = this.ConfJ.angularXDrive;
                                _2661.maximumForce = _2660;
                                this.ConfJ.angularXDrive = _2661;
                            }
                            if (this.Circle)
                            {
                                this.GyroForce = 8;
                            }
                        }
                        else
                        {
                            this.GyroForce = 4;
                            this.TurnMod = 0.3f;
                            this.Vessel.GetComponent<Rigidbody>().angularDrag = 8;

                            {
                                float _2662 = 0.03f;
                                JointDrive _2663 = this.ConfJ.angularYZDrive;
                                _2663.maximumForce = _2662;
                                this.ConfJ.angularYZDrive = _2663;
                            }

                            {
                                float _2664 = 0.001f;
                                JointDrive _2665 = this.ConfJ.angularXDrive;
                                _2665.maximumForce = _2664;
                                this.ConfJ.angularXDrive = _2665;
                            }
                        }
                    }
                }
                else
                {

                    {
                        float _2666 = 0.01f;
                        JointDrive _2667 = this.ConfJ.angularYZDrive;
                        _2667.maximumForce = _2666;
                        this.ConfJ.angularYZDrive = _2667;
                    }

                    {
                        float _2668 = 0.05f;
                        JointDrive _2669 = this.ConfJ.angularXDrive;
                        _2669.maximumForce = _2668;
                        this.ConfJ.angularXDrive = _2669;
                    }
                }
            }
            if (this.Obstacle)
            {
                this.Presence.IAmStopping = true;
            }
            else
            {
                this.Presence.IAmStopping = false;
            }
            this.Obstacle = false;
            this.Farstacle = false;
            this.Roofstacle = false;
            this.Floorstacle = false;
            this.Circle = false;
            if (PiriDefenseDroneAI.Assisting)
            {
                this.Waypoint2 = null;
                this.Waypoint = PlayerInformation.instance.Pirizuka;
                this.Runtime = 120;
                this.Settling = false;
                this.Patrolling = false;
            }
            else
            {
                if (this.Homepoint)
                {
                    if (Vector3.Distance(this.thisTransform.position, this.Homepoint.position) > 128)
                    {
                        this.Waypoint = this.Homepoint;
                        this.Waypoint2 = this.Homepoint;
                    }
                }
            }
            if (this.Attacking || this.Spot)
            {
                Vector3 relativePoint = this.thisVTransform.InverseTransformPoint(this.Waypoint.transform.position);
                if (relativePoint.y > 50)
                {
                    this.Farstacle = true;
                }
                if (this.target != null)
                {
                    if (!Physics.Linecast(this.thisTransform.position, this.target.position, (int) this.targetLayers2))
                    {
                        this.TurnRight = false;
                        this.TurnLeft = false;
                        this.Roofstacle = false;
                        this.Floorstacle = false;
                        this.JustNoticed = 2;
                    }
                }
            }
            if (!this.Attacking)
            {
                if (this.Runtime == 0)
                {
                    if (this.Settlepoint)
                    {
                        if (Vector3.Distance(this.thisTransform.position, this.Settlepoint.position) > 2)
                        {
                            this.target = this.Settlepoint;
                            this.Settling = false;
                        }
                        else
                        {
                            if (this.Settlepoint != null)
                            {
                                this.Settling = true;
                            }
                        }
                    }
                }
                if (!this.Settling)
                {
                    if (this.Runtime > 0)
                    {
                        if (Vector3.Distance(this.thisTransform.position, this.Waypoint.position) > 50)
                        {
                            this.target = this.Waypoint;
                        }
                        else
                        {
                            this.target = this.ForwardAim;
                        }
                        if (Vector3.Distance(this.thisTransform.position, this.Waypoint.position) > 100)
                        {
                            this.Far = true;
                        }
                        else
                        {
                            this.Far = false;
                        }
                    }
                    if (this.Waypoint2)
                    {
                        Vector3 relativePoint2 = this.Waypoint2.InverseTransformPoint(this.thisVTransform.position);
                        if (Vector3.Distance(this.thisTransform.position, this.Waypoint2.position) > 50)
                        {
                            this.Patrolling = false;
                            if (this.HomeIsMoving)
                            {
                                if (relativePoint2.z < 0)
                                {
                                    this.Floorstacle = true;
                                }
                            }
                        }
                        else
                        {
                            if (this.HomeIsMoving)
                            {
                                this.Floorstacle = true;
                            }
                            this.Patrolling = true;
                        }
                        if (Vector3.Distance(this.thisTransform.position, this.Waypoint2.position) > 100)
                        {
                            this.target = this.Waypoint2;
                            this.Circle = false;
                            if (-relativePoint2.z > 5)
                            {
                                this.Floorstacle = true;
                            }
                            else
                            {
                                this.Floorstacle = false;
                            }
                        }
                        else
                        {
                            if (-relativePoint2.z > 5)
                            {
                                this.Floorstacle = true;
                                this.Patrolling = false;
                                this.Circle = true;
                            }
                            else
                            {
                                this.Circle = false;
                            }
                        }
                    }
                    this.Vessel.GetComponent<Rigidbody>().drag = 0.05f;
                }
                else
                {
                    this.Vessel.GetComponent<Rigidbody>().drag = 8;
                }
                if (this.AngerLevel == 1)
                {
                    this.Spot = false;
                    this.target = this.ForwardAim;
                    this.AngerLevel = 0;
                }
            }
            if (this.JustNoticed > 0)
            {
                this.JustNoticed = this.JustNoticed - 1;
            }
            if (this.AngerLevel > 1)
            {
                this.AngerLevel = this.AngerLevel - 1;
            }
            if (this.Dodge > 0)
            {
                this.Dodge = this.Dodge - 1;
            }
            if (this.PissedAtTC0a > 0)
            {
                this.PissedAtTC0a = this.PissedAtTC0a - 1;
            }
            if (this.PissedAtTC2 > 0)
            {
                this.PissedAtTC2 = this.PissedAtTC2 - 1;
            }
            if (this.PissedAtTC3 > 0)
            {
                this.PissedAtTC3 = this.PissedAtTC3 - 1;
            }
            if (this.PissedAtTC4 > 0)
            {
                this.PissedAtTC4 = this.PissedAtTC4 - 1;
            }
            if (this.PissedAtTC5 > 0)
            {
                this.PissedAtTC5 = this.PissedAtTC5 - 1;
            }
            if (this.PissedAtTC6 > 0)
            {
                this.PissedAtTC6 = this.PissedAtTC6 - 1;
            }
            if (this.PissedAtTC7 > 0)
            {
                this.PissedAtTC7 = this.PissedAtTC7 - 1;
            }
            this.TurnRight = false;
            this.TurnLeft = false;
            this.TargetTooClose = false;
        }
        else
        {

            {
                int _2670 = 0;
                JointDrive _2671 = this.ConfJ.angularYZDrive;
                _2671.maximumForce = _2670;
                this.ConfJ.angularYZDrive = _2671;
            }

            {
                int _2672 = 0;
                JointDrive _2673 = this.ConfJ.angularXDrive;
                _2673.maximumForce = _2672;
                this.ConfJ.angularXDrive = _2673;
            }
            this.Wing1.Broken = true;
            this.Wing2.Broken = true;
            this.Vessel.GetComponent<Rigidbody>().drag = 0.05f;
            this.Vessel.GetComponent<Rigidbody>().angularDrag = 0.2f;
            this.GetComponent<Rigidbody>().freezeRotation = false;
            this.Presence.IAmNumber = 0.0001f;
            this.Presence.IAmStopping = true;
        }
    }

    public PiriDefenseDroneAI()
    {
        this.RightDist = 200;
        this.LeftDist = 200;
        this.TurnMod = 1f;
        this.VelC = 1;
        this.TFSideNum = 0.3f;
        this.UniqueShootTime = 0.1f;
    }

}