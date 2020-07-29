using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AgrianEnforcerAI : MonoBehaviour
{
    public Transform target;
    public Transform Waypoint;
    public Transform Waypoint2;
    public GameObject Thruster;
    public WingScript Wing;
    public WingScript Wing2;
    public CapsuleCollider Trig;
    public NPCGun Gun1;
    public NPCGun Gun2;
    public Rigidbody Gun1RB;
    public Rigidbody Gun2RB;
    public GameObject Presence;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public GameObject EyeShot;
    public Transform EyeMuzzle;
    public bool IsSentinel;
    public bool IsTurret;
    public GameObject HuntingSound;
    public GameObject SpotSound;
    public GameObject AttackSound;
    public GameObject RejectSound;
    public int PissedAtTC0a;
    public int PissedAtTC1;
    public int PissedAtTC3;
    public int PissedAtTC5;
    public int PissedAtTC6;
    public int PissedAtTC7;
    public int PissedAtTC8;
    public int PissedAtTC9;
    public Transform Stranger;
    public bool StrangerIsMoving;
    public bool Attacking;
    public bool Roofstacle;
    public bool Floorstacle;
    public bool Obstacle;
    public bool Stuck;
    public bool TargetTooClose;
    public bool TurnRight;
    public bool TurnLeft;
    public bool LineOfFire;
    public Vector3 DangerDirection;
    public LayerMask targetLayers;
    public LayerMask targetLayers2;
    public LayerMask MtargetLayers;
    public int Dodge;
    public int JustNoticed;
    public int Looking;
    public int DangerSense;
    public int AngerLevel;
    public int WatchTick;
    public float GyroForce;
    public float TurnForce;
    public float ShootFrequency;
    public float UniqueShootTime;
    public virtual void Start()
    {
        this.InvokeRepeating("Regenerator", 1, 1);
        this.InvokeRepeating("LeaveMarker", 1, 10);
        this.InvokeRepeating("Warning", 5, Random.Range(19, 21));
        this.InvokeRepeating("Shooty", 1, this.ShootFrequency);
        this.target = this.Waypoint;
        this.UniqueShootTime = Random.Range(0, 0.2f);
        KabrianLaw.KabrianPolicePresent = true;
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        float LookSpeed;
        if (this.AngerLevel > 100)
        {
            LookSpeed = 200;
        }
        else
        {
            LookSpeed = 100;
        }
        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 5), this.thisTransform.forward, out hit, 600, (int) this.targetLayers2))
        {
            if ((((((((hit.collider.name.Contains("TC0") || hit.collider.name.Contains("TC1")) || hit.collider.name.Contains("TC3")) || hit.collider.name.Contains("TC4")) || hit.collider.name.Contains("TC5")) || hit.collider.name.Contains("TC6")) || hit.collider.name.Contains("TC7")) || hit.collider.name.Contains("TC8")) || hit.collider.name.Contains("TC9"))
            {
                this.LineOfFire = true;
            }
            else
            {
                this.LineOfFire = false;
            }
        }
        if ((this.target == null) && this.Attacking)
        {
            this.AngerLevel = 4;
            this.Attacking = false;
            this.Looking = 0;
            this.target = this.Waypoint;
            this.StopAllCoroutines();
        }
        if (this.target)
        {
            if ((Vector3.Distance(this.thisTransform.position, this.target.position) < 10) && this.Attacking)
            {
                this.TargetTooClose = true;
                if (this.AngerLevel < 150)
                {
                    this.AngerLevel = this.AngerLevel + 1;
                }
            }
            else
            {
                this.TargetTooClose = false;
            }
        }
        if (!this.IsTurret)
        {
            if (this.TurnLeft)
            {
                if ((this.vRigidbody.velocity.magnitude > 40) && (this.Looking == 0))
                {
                    this.TurnForce = -40;
                }
                if ((this.vRigidbody.velocity.magnitude < 40) && (this.Looking == 0))
                {
                    this.TurnForce = -20;
                }
            }
            if (this.TurnRight)
            {
                if ((this.vRigidbody.velocity.magnitude > 40) && (this.Looking == 0))
                {
                    this.TurnForce = 40;
                }
                if ((this.vRigidbody.velocity.magnitude < 40) && (this.Looking == 0))
                {
                    this.TurnForce = 20;
                }
            }
            if (this.TurnLeft && this.TurnRight)
            {
                this.TurnForce = -40;
            }
            if (!this.TurnLeft && !this.TurnRight)
            {
                this.TurnForce = 0;
            }
            if (this.vRigidbody.velocity.magnitude > 20)
            {
                Vector3 newRot = ((this.thisVTransform.up * 0.6f) + (this.thisVTransform.right * -0.4f)).normalized;
                Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 2), newRot * 100f, Color.black);
                if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 2), newRot, 100))
                {
                    if (this.JustNoticed < 1)
                    {
                        this.TurnLeft = true;
                    }
                }
                else
                {
                    this.TurnLeft = false;
                }
                newRot = ((this.thisVTransform.up * 0.6f) + (this.thisVTransform.right * 0.4f)).normalized;
                Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 2), newRot * 100f, Color.black);
                if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 2), newRot, 100))
                {
                    if (this.JustNoticed < 1)
                    {
                        this.TurnRight = true;
                    }
                }
                else
                {
                    this.TurnRight = false;
                }
            }
            else
            {
                if (this.vRigidbody.velocity.magnitude < 20)
                {
                    if (this.vRigidbody.velocity.magnitude > 5)
                    {
                        Vector3 newRot = ((this.thisVTransform.up * 0.6f) + (this.thisVTransform.right * -0.4f)).normalized;
                        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 2), newRot * 10f, Color.black);
                        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 2), newRot, 10))
                        {
                            if (this.JustNoticed < 1)
                            {
                                this.TurnLeft = true;
                            }
                        }
                        else
                        {
                            this.TurnLeft = false;
                        }
                        newRot = ((this.thisVTransform.up * 0.6f) + (this.thisVTransform.right * 0.4f)).normalized;
                        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 2), newRot * 10f, Color.black);
                        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 2), newRot, 10))
                        {
                            if (this.JustNoticed < 1)
                            {
                                this.TurnRight = true;
                            }
                        }
                        else
                        {
                            this.TurnRight = false;
                        }
                    }
                    else
                    {
                        if (this.vRigidbody.velocity.magnitude < 5)
                        {
                            Vector3 newRot = ((this.thisVTransform.up * 0.6f) + (this.thisVTransform.right * -0.4f)).normalized;
                            Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 1), newRot * 5f, Color.black);
                            if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 1), newRot, 5))
                            {
                                if (this.JustNoticed < 1)
                                {
                                    this.TurnLeft = true;
                                }
                            }
                            else
                            {
                                this.TurnLeft = false;
                            }
                            newRot = ((this.thisVTransform.up * 0.6f) + (this.thisVTransform.right * 0.4f)).normalized;
                            Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 1), newRot * 5f, Color.black);
                            if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 1), newRot, 5))
                            {
                                if (this.JustNoticed < 1)
                                {
                                    this.TurnRight = true;
                                }
                            }
                            else
                            {
                                this.TurnRight = false;
                            }
                        }
                    }
                }
            }
            if (this.vRigidbody.velocity.magnitude > 20)
            {
                Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 1), this.thisTransform.forward * 100f, Color.white);
                if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 1), this.thisTransform.forward, 100))
                {
                    this.Obstacle = true;
                }
                else
                {
                    this.Obstacle = false;
                }
                Vector3 newRot = ((this.thisVTransform.up * 0.6f) + (this.thisVTransform.forward * 0.2f)).normalized;
                Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 1), newRot * 50f, Color.blue);
                if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 1), newRot, 50))
                {
                    this.Roofstacle = true;
                }
                else
                {
                    this.Roofstacle = false;
                }
                if (this.Attacking)
                {
                    newRot = ((this.thisVTransform.up * 0.6f) + (this.thisVTransform.forward * -0.2f)).normalized;
                    Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 1), newRot * 50f, Color.red);
                    if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 1), newRot, 50))
                    {
                        this.Floorstacle = true;
                    }
                    else
                    {
                        this.Floorstacle = false;
                    }
                }
            }
            else
            {
                if (this.vRigidbody.velocity.magnitude < 20)
                {
                    if (this.vRigidbody.velocity.magnitude < 7)
                    {
                        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 1), this.thisVTransform.up * 5f, Color.white);
                        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 1), this.thisVTransform.up, 5))
                        {
                            this.Obstacle = true;
                        }
                        else
                        {
                            this.Obstacle = false;
                        }
                        Vector3 newRot = ((this.thisVTransform.up * 0.6f) + (this.thisVTransform.forward * 0.2f)).normalized;
                        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 1), newRot * 5f, Color.blue);
                        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 1), newRot, 5))
                        {
                            this.Roofstacle = true;
                        }
                        else
                        {
                            this.Roofstacle = false;
                        }
                        if (this.Attacking)
                        {
                            newRot = ((this.thisVTransform.up * 0.6f) + (this.thisVTransform.forward * -0.2f)).normalized;
                            Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 1), newRot * 5f, Color.red);
                            if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 1), newRot, 5))
                            {
                                this.Floorstacle = true;
                            }
                            else
                            {
                                this.Floorstacle = false;
                            }
                        }
                    }
                    else
                    {
                        if (this.vRigidbody.velocity.magnitude > 7)
                        {
                            Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 1), this.thisVTransform.up * 20f, Color.white);
                            if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 1), this.thisVTransform.up, 20))
                            {
                                this.Obstacle = true;
                            }
                            else
                            {
                                this.Obstacle = false;
                            }
                            Vector3 newRot = ((this.thisVTransform.up * 0.6f) + (this.thisVTransform.forward * 0.2f)).normalized;
                            Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 1), newRot * 20f, Color.blue);
                            if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 1), newRot, 20))
                            {
                                this.Roofstacle = true;
                            }
                            else
                            {
                                this.Roofstacle = false;
                            }
                            if (this.Attacking)
                            {
                                newRot = ((this.thisVTransform.up * 0.6f) + (this.thisVTransform.forward * -0.2f)).normalized;
                                Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 1), newRot * 20f, Color.red);
                                if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 1), newRot, 20))
                                {
                                    this.Floorstacle = true;
                                }
                                else
                                {
                                    this.Floorstacle = false;
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    private Quaternion NewRotation;
    public virtual void FixedUpdate()
    {
        if (!this.IsTurret)
        {
            Vector3 localV = this.thisTransform.InverseTransformDirection(this.GetComponent<Rigidbody>().velocity);
            if (this.Roofstacle && !this.Stuck)
            {
                if (((this.JustNoticed < 1) && !this.Attacking) && (this.Looking == 0))
                {
                    this.vRigidbody.AddTorque(this.thisVTransform.right * -20);
                }
            }
            if (this.Floorstacle && !this.Stuck)
            {
                if (((this.JustNoticed < 1) && !this.Attacking) && (this.Looking == 0))
                {
                    this.vRigidbody.AddTorque(this.thisVTransform.right * 20);
                }
            }
            if (this.Obstacle && !this.Stuck)
            {
                if (localV.z > 5)
                {
                    this.vRigidbody.AddTorque(this.thisVTransform.right * 10);
                }
                if (localV.z > 0)
                {
                    if (localV.z < 40)
                    {
                        this.Thruster.GetComponent<Rigidbody>().AddForce(this.Thruster.transform.up * -40);
                    }
                    if (localV.z > 40)
                    {
                        this.Thruster.GetComponent<Rigidbody>().AddForce(this.Thruster.transform.up * -80);
                    }
                }
                if (((localV.z < 5) && (this.Looking == 0)) && !this.Attacking)
                {
                    this.vRigidbody.AddTorque(this.thisVTransform.forward * -20);
                }
            }
            if ((this.Dodge > 0) && !this.Roofstacle)
            {
                this.Thruster.GetComponent<Rigidbody>().AddForce(this.Thruster.transform.forward * 40);
            }
            if (this.TargetTooClose)
            {
                this.Thruster.GetComponent<Rigidbody>().AddForce(this.Thruster.transform.up * -20);
            }
            if (this.Stuck)
            {
                if (-localV.z < 2)
                {
                    this.Thruster.GetComponent<Rigidbody>().AddForce(this.Thruster.transform.up * -40);
                }
            }
            if (((this.Attacking && !this.Stuck) && !this.Obstacle) && !this.TargetTooClose)
            {
                if (localV.z < 60)
                {
                    this.Thruster.GetComponent<Rigidbody>().AddForce(this.Thruster.transform.up * 30);
                }
                this.GyroForce = -1;
            }
            if (!this.IsSentinel)
            {
                if (((!this.Obstacle && !this.Attacking) && (this.Looking == 0)) && !this.Stuck)
                {
                    if (localV.z < 40)
                    {
                        this.Thruster.GetComponent<Rigidbody>().AddForce(this.Thruster.transform.up * 15);
                    }
                    this.GyroForce = -2;
                }
            }
            else
            {
                if (((!this.Obstacle && !this.Attacking) && (this.Looking == 0)) && !this.Stuck)
                {
                    if (localV.z < 60)
                    {
                        this.Thruster.GetComponent<Rigidbody>().AddForce(this.Thruster.transform.up * 30);
                    }
                    this.GyroForce = -2;
                }
            }
            if ((((this.Looking > 0) && !this.Stuck) && !this.Obstacle) && !this.Attacking)
            {
                this.Thruster.GetComponent<Rigidbody>().AddForce(this.Thruster.transform.up * 5);
                this.GyroForce = -2;
            }
            //----------------------------------------------------------------------------------------------------------------------
            this.vRigidbody.AddForceAtPosition(Vector3.up * this.GyroForce, -this.thisVTransform.forward * 2);
            this.vRigidbody.AddForceAtPosition(-Vector3.up * this.GyroForce, this.thisVTransform.forward * 2);
            this.vRigidbody.AddTorque(this.thisVTransform.forward * this.TurnForce);
            if (Physics.Raycast(this.thisTransform.position, Vector3.down, 3, (int) this.targetLayers))
            {
                this.GetComponent<Rigidbody>().AddForce(Vector3.up * 50);
            }
            if (!this.Attacking)
            {
                if (Physics.Raycast(this.thisTransform.position, Vector3.down, 500, (int) this.targetLayers))
                {
                    this.GetComponent<Rigidbody>().AddForce(Vector3.down * 5);
                }
            }
        }
        if (this.target && (this.DangerSense < 1))
        {
            if (((this.TurnLeft || this.TurnRight) || this.Roofstacle) || this.Floorstacle)
            {
                this.GetComponent<Rigidbody>().freezeRotation = false;
            }
            if (((!this.TurnLeft && !this.TurnRight) && !this.Roofstacle) && !this.Floorstacle)
            {
                this.GetComponent<Rigidbody>().freezeRotation = true;
            }
            if (this.JustNoticed > 0)
            {
                this.GetComponent<Rigidbody>().freezeRotation = true;
            }
            this.NewRotation = Quaternion.LookRotation(this.target.position - this.thisTransform.position);
            this.thisTransform.rotation = Quaternion.RotateTowards(this.thisTransform.rotation, this.NewRotation, Time.deltaTime * 100);
        }
        if ((this.DangerSense > 0) && (this.DangerDirection != Vector3.zero))
        {
            this.NewRotation = Quaternion.LookRotation(this.DangerDirection);
            this.thisTransform.rotation = Quaternion.RotateTowards(this.thisTransform.rotation, this.NewRotation, Time.deltaTime * 200);
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
        if (((((((ON.Contains("TC0") || ON.Contains("TC1")) || ON.Contains("TC3")) || ON.Contains("TC5")) || ON.Contains("TC6")) || ON.Contains("TC7")) || ON.Contains("TC8")) || ON.Contains("TC9"))
        {
            this.Stranger = OT;
        }
        if (ON.Contains("TFC0a"))
        {
            this.PissedAtTC0a = 5;
        }
        if (ON.Contains("TFC1"))
        {
            Vector3 relativePoint = OT.InverseTransformPoint(this.thisVTransform.position);
            if (relativePoint.z > 0)
            {
                this.PissedAtTC1 = 5;
            }
        }
        if (ON.Contains("TFC3"))
        {
            this.PissedAtTC3 = 5;
        }
        if (ON.Contains("TFC5"))
        {
            this.PissedAtTC5 = 5;
        }
        if (ON.Contains("TFC6"))
        {
            this.PissedAtTC6 = 5;
        }
        if (ON.Contains("TFC7"))
        {
            this.PissedAtTC7 = 5;
        }
        if (ON.Contains("TFC8"))
        {
            this.PissedAtTC8 = 5;
        }
        if (ON.Contains("TFC9"))
        {
            this.PissedAtTC9 = 5;
        }
        if (((ON.Contains("TC") && !this.Attacking) && (this.Looking == 0)) && (this.AngerLevel < 5))
        {
            if (!ON.Contains("TC2"))
            {
                this.target = OT;
                if (!this.IsSentinel)
                {
                    this.Looking = 20;
                }
                else
                {
                    this.Looking = 40;
                }
                GameObject TheThing = UnityEngine.Object.Instantiate(this.SpotSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                TheThing.transform.parent = this.thisTransform;
            }
            else
            {
                if (AgrianNetwork.instance.Curiosity > 200)
                {
                    if (AgrianNetwork.TC1CriminalLevel > 500)
                    {
                        if (ON.Contains("2_P"))
                        {
                            this.target = OT;
                            if (!this.IsSentinel)
                            {
                                this.Looking = 20;
                            }
                            else
                            {
                                this.Looking = 40;
                            }
                            GameObject TheThing0 = UnityEngine.Object.Instantiate(this.SpotSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                            TheThing0.transform.parent = this.thisTransform;
                        }
                    }
                }
            }
        }
        if (!string.IsNullOrEmpty(ON))
        {
            if (ON.Contains("TFC"))
            {
                Vector3 relativePoint0 = OT.InverseTransformPoint(this.thisTransform.position);
                float FAndB = relativePoint0.z;
                if (this.Attacking)
                {
                    if (Vector3.Distance(this.thisTransform.position, OT.position) < 25)
                    {
                        if (this.AngerLevel < 150)
                        {
                            this.AngerLevel = this.AngerLevel + 15;
                        }
                    }
                }
                else
                {
                    if ((this.AngerLevel < 150) && (this.WatchTick < 1))
                    {
                        this.AngerLevel = this.AngerLevel + 15;
                    }
                }
                if (!ON.Contains("TFC2"))
                {
                    this.Dodge = 1;
                    if (((!this.Attacking && (this.Looking == 0)) && (this.DangerSense == 0)) && (this.AngerLevel == 0))
                    {
                        GameObject TheThing1 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                        TheThing1.transform.parent = this.thisTransform;
                        if (other.GetComponent<Rigidbody>())
                        {
                            if (FAndB > 0)
                            {
                                this.DangerDirection = -other.GetComponent<Rigidbody>().velocity.normalized;
                            }
                            else
                            {
                                this.DangerDirection = other.GetComponent<Rigidbody>().velocity.normalized;
                            }
                        }
                        this.DangerSense = 10;
                        this.AngerLevel = 10;
                        this.WatchTick = 2;
                    }
                }
            }
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        string ON = other.name;
        Transform OT = other.transform;
        if (Physics.Linecast(this.thisTransform.position, OT.position, (int) this.MtargetLayers))
        {
            return;
        }
        if (this.target)
        {
            if (ON.Contains("TC0a") && (this.PissedAtTC0a > 0))
            {
                this.DangerSense = 0;
                this.target = OT;
                if (!this.Attacking && (this.AngerLevel > 50))
                {
                    this.Looking = 0;
                    this.DangerSense = 0;
                    this.Attacking = true;
                    this.StopAllCoroutines();
                }
            }
            if (ON.Contains("TC4"))
            {
                this.DangerSense = 0;
                this.target = OT;
                if (!this.Attacking && (this.AngerLevel > 50))
                {
                    this.Looking = 0;
                    this.DangerSense = 0;
                    this.Attacking = true;
                    this.StopAllCoroutines();
                }
            }
            if (ON.Contains("TC1") && (this.PissedAtTC1 > 0))
            {
                this.DangerSense = 0;
                if ((AgrianNetwork.TC1CriminalLevel > 240) && (this.AngerLevel < 50))
                {
                    this.AngerLevel = 60;
                }
                this.target = OT;
                if (!this.Attacking && (this.AngerLevel > 50))
                {
                    this.Looking = 0;
                    this.DangerSense = 0;
                    this.Attacking = true;
                    this.StopAllCoroutines();
                }
            }
            if (ON.Contains("TC3") && (this.PissedAtTC3 > 0))
            {
                this.DangerSense = 0;
                if ((AgrianNetwork.TC3CriminalLevel > 240) && (this.AngerLevel < 50))
                {
                    this.AngerLevel = 60;
                }
                this.target = OT;
                if (!this.Attacking && (this.AngerLevel > 50))
                {
                    this.Looking = 0;
                    this.DangerSense = 0;
                    this.Attacking = true;
                    this.StopAllCoroutines();
                }
            }
            if (ON.Contains("TC4"))
            {
                this.DangerSense = 0;
                this.target = OT;
                if (!this.Attacking && (this.AngerLevel > 50))
                {
                    this.Looking = 0;
                    this.DangerSense = 0;
                    this.Attacking = true;
                    this.StopAllCoroutines();
                }
            }
            if (ON.Contains("TC5") && (this.PissedAtTC5 > 0))
            {
                this.DangerSense = 0;
                this.target = OT;
                if (!this.Attacking && (this.AngerLevel > 50))
                {
                    this.Looking = 0;
                    this.DangerSense = 0;
                    this.Attacking = true;
                    this.StopAllCoroutines();
                }
            }
            if (ON.Contains("TC6") && (this.PissedAtTC6 > 0))
            {
                if (!ON.Contains("csT"))
                {
                    this.DangerSense = 0;
                    if ((AgrianNetwork.TC6CriminalLevel > 240) && (this.AngerLevel < 50))
                    {
                        this.AngerLevel = 60;
                    }
                    this.target = OT;
                    if (!this.Attacking && (this.AngerLevel > 50))
                    {
                        this.Looking = 0;
                        this.DangerSense = 0;
                        this.Attacking = true;
                        this.StopAllCoroutines();
                    }
                }
            }
            if (ON.Contains("TC7") && (this.PissedAtTC7 > 0))
            {
                if (!ON.Contains("cT"))
                {
                    this.DangerSense = 0;
                    if ((AgrianNetwork.TC7CriminalLevel > 240) && (this.AngerLevel < 50))
                    {
                        this.AngerLevel = 60;
                    }
                    this.target = OT;
                    if (!this.Attacking && (this.AngerLevel > 50))
                    {
                        this.Looking = 0;
                        this.DangerSense = 0;
                        this.Attacking = true;
                        this.StopAllCoroutines();
                    }
                }
            }
            if (ON.Contains("TC8") && (this.PissedAtTC8 > 0))
            {
                if (!ON.Contains("cT"))
                {
                    this.DangerSense = 0;
                    if ((AgrianNetwork.TC8CriminalLevel > 240) && (this.AngerLevel < 50))
                    {
                        this.AngerLevel = 60;
                    }
                    this.target = OT;
                    if (!this.Attacking && (this.AngerLevel > 50))
                    {
                        this.Looking = 0;
                        this.DangerSense = 0;
                        this.Attacking = true;
                        this.StopAllCoroutines();
                    }
                }
            }
            if (ON.Contains("TC9") && (this.PissedAtTC9 > 0))
            {
                if (!ON.Contains("cT"))
                {
                    this.DangerSense = 0;
                    if ((AgrianNetwork.TC9CriminalLevel > 240) && (this.AngerLevel < 50))
                    {
                        this.AngerLevel = 60;
                    }
                    this.target = OT;
                    if (!this.Attacking && (this.AngerLevel > 50))
                    {
                        this.Looking = 0;
                        this.DangerSense = 0;
                        this.Attacking = true;
                        this.StopAllCoroutines();
                    }
                }
            }
        }
    }

    public virtual void Shooty()
    {
        if ((this.Attacking && this.LineOfFire) && (this.AngerLevel > 30))
        {
            this.StartCoroutine(this.Shoot());
        }
    }

    public virtual IEnumerator Shoot()
    {
        yield return new WaitForSeconds(this.UniqueShootTime);
        if (this.target)
        {
            if (Vector3.Distance(this.thisTransform.position, this.target.position) < 20)
            {
                GameObject TheThing = UnityEngine.Object.Instantiate(this.EyeShot, this.EyeMuzzle.position, this.EyeMuzzle.rotation);
                TheThing.transform.parent = this.thisTransform;
                yield break;
            }
        }
        if (this.Gun1 != null)
        {
            this.Gun1.Fire();
        }
        yield return new WaitForSeconds(0.14f);
        if (this.Gun2 != null)
        {
            this.Gun2.Fire();
        }
    }

    public virtual void Warning()
    {
        if (this.AngerLevel < 5)
        {
            GameObject TheThing = UnityEngine.Object.Instantiate(this.HuntingSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
            TheThing.transform.parent = this.thisTransform;
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
        if (Vector3.Distance(this.thisTransform.position, lastPos) < 1)
        {
            this.Stuck = true;
            yield return new WaitForSeconds(2);
            this.Stuck = false;
        }
    }

    public virtual void Regenerator()
    {
        this.GetComponent<Rigidbody>().centerOfMass = new Vector3(0, 0, 0);
        if (!this.IsTurret)
        {
            if (!this.Attacking)
            {
                if ((this.DangerSense < 2) && (this.Looking < 2))
                {
                    if (AgrianNetwork.instance.AlertTime > 1)
                    {
                        this.Waypoint2.position = AgrianNetwork.instance.PriorityWaypoint.transform.position;
                        this.target = this.Waypoint2;
                    }
                    if (AgrianNetwork.instance.RedAlertTime > 1)
                    {
                        this.Waypoint2.position = AgrianNetwork.instance.FullPriorityWaypoint.transform.position;
                        this.target = this.Waypoint2;
                    }
                }
            }
        }
        else
        {
            if (this.target)
            {
                if (this.target.name.Contains("TC4"))
                {
                    this.AngerLevel = 150;
                }
            }
        }
        if (this.Attacking || (this.Looking > 0))
        {
            if (this.target)
            {
                if (!Physics.Linecast(this.thisTransform.position, this.target.position, (int) this.targetLayers))
                {
                    this.TurnRight = false;
                    this.TurnLeft = false;
                    this.Roofstacle = false;
                    this.Floorstacle = false;
                    this.JustNoticed = 2;
                    if ((Vector3.Distance(this.thisTransform.position, this.target.position) < 80) && !this.IsTurret)
                    {
                        this.vRigidbody.drag = 1;
                    }
                }
            }
        }
        if (this.Attacking)
        {
            this.Trig.center = new Vector3(0, 0, 0);
            this.Trig.radius = 20;
            this.Trig.height = 20;
        }
        else
        {
            if (!this.IsTurret)
            {
                this.Trig.center = new Vector3(0, 0, 150);
                this.Trig.radius = 100;
                this.Trig.height = 600;
            }
            else
            {
                this.Trig.center = new Vector3(0, 0, 0);
                this.Trig.radius = 50;
                this.Trig.height = 50;
            }
        }
        if (!this.Attacking)
        {
            if (!this.IsTurret)
            {
                this.vRigidbody.drag = 0.2f;
            }
            if (this.Looking == 1)
            {
                this.Looking = 0;
                this.target = this.Waypoint;
                GameObject TheThing3 = UnityEngine.Object.Instantiate(this.RejectSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                TheThing3.transform.parent = this.thisTransform;
            }
        }
        if (this.DangerSense == 1)
        {
            if (!this.Attacking)
            {
                this.Looking = 0;
                this.target = this.Waypoint;
                if (!this.IsTurret)
                {
                    this.vRigidbody.drag = 0.2f;
                }
                GameObject TheThing4 = UnityEngine.Object.Instantiate(this.RejectSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                TheThing4.transform.parent = this.thisTransform;
            }
        }
        if (this.target)
        {
            if ((AgrianNetwork.instance.RedAlertTime < 1) && (AgrianNetwork.instance.AlertTime < 1))
            {
                if (!this.Attacking)
                {
                    if (this.target.name.Contains("Priority"))
                    {
                        this.target = this.Waypoint;
                    }
                }
                else
                {
                    if (this.AngerLevel < 5)
                    {
                        this.target = this.Waypoint;
                        this.Attacking = false;
                    }
                }
            }
            else
            {
                if (this.Looking > 5)
                {
                    this.Looking = 5;
                }
            }
        }
        if ((this.JustNoticed < 1) && !this.IsTurret)
        {
            this.Wing.Broken = false;
        }
        if (this.JustNoticed > 0)
        {
            this.JustNoticed = this.JustNoticed - 1;
            if (this.Attacking && !this.IsTurret)
            {
                this.Wing.Broken = true;
            }
        }
        if (this.WatchTick > 0)
        {
            this.WatchTick = this.WatchTick - 1;
        }
        if (this.Looking > 0)
        {
            this.Looking = this.Looking - 1;
        }
        if (this.DangerSense > 0)
        {
            this.DangerSense = this.DangerSense - 1;
        }
        if (this.AngerLevel > 1)
        {
            this.AngerLevel = this.AngerLevel - 1;
        }
        if (this.Dodge > 0)
        {
            this.Dodge = this.Dodge - 1;
        }
        if ((AgrianNetwork.TC1CriminalLevel > 240) && (this.PissedAtTC1 < 1))
        {
            this.PissedAtTC1 = 60;
        }
        if ((AgrianNetwork.TC3CriminalLevel > 240) && (this.PissedAtTC3 < 1))
        {
            this.PissedAtTC3 = 60;
        }
        if ((AgrianNetwork.TC5CriminalLevel > 240) && (this.PissedAtTC5 < 1))
        {
            this.PissedAtTC5 = 60;
        }
        if ((AgrianNetwork.TC6CriminalLevel > 240) && (this.PissedAtTC6 < 1))
        {
            this.PissedAtTC6 = 60;
        }
        if ((AgrianNetwork.TC7CriminalLevel > 240) && (this.PissedAtTC7 < 1))
        {
            this.PissedAtTC7 = 60;
        }
        if ((AgrianNetwork.TC8CriminalLevel > 240) && (this.PissedAtTC8 < 1))
        {
            this.PissedAtTC8 = 60;
        }
        if ((AgrianNetwork.TC9CriminalLevel > 240) && (this.PissedAtTC9 < 1))
        {
            this.PissedAtTC9 = 60;
        }
        if (this.target)
        {
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
                    if (AgrianNetwork.instance.RedAlertTime > 0)
                    {
                        AgrianNetwork.instance.FullPriorityWaypoint.position = this.target.position;
                    }
                    else
                    {
                        AgrianNetwork.instance.PriorityWaypoint.position = this.target.position;
                    }
                    if (AgrianNetwork.instance.AlertTime < 300)
                    {
                        AgrianNetwork.instance.AlertTime = 300;
                    }
                    AgrianNetwork.TC1CriminalLevel = 620;
                }
                else
                {
                    if (this.target.name.Contains("2_P"))
                    {
                        AgrianNetwork.instance.FullPriorityWaypoint.position = this.target.position;
                    }
                }
            }
            if (AgrianNetwork.TC3CriminalLevel < 500)
            {
                if ((AgrianNetwork.TC3CriminalLevel > 240) && this.target.name.Contains("TC3"))
                {
                    AgrianNetwork.instance.PriorityWaypoint.position = this.target.position;
                    AgrianNetwork.TC3CriminalLevel = 360;
                }
            }
            else
            {
                if (this.target.name.Contains("TC3"))
                {
                    if (AgrianNetwork.instance.RedAlertTime > 0)
                    {
                        AgrianNetwork.instance.FullPriorityWaypoint.position = this.target.position;
                    }
                    else
                    {
                        AgrianNetwork.instance.PriorityWaypoint.position = this.target.position;
                    }
                    if (AgrianNetwork.instance.AlertTime < 300)
                    {
                        AgrianNetwork.instance.AlertTime = 300;
                    }
                    AgrianNetwork.TC3CriminalLevel = 620;
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
                    if (AgrianNetwork.instance.RedAlertTime > 0)
                    {
                        AgrianNetwork.instance.FullPriorityWaypoint.position = this.target.position;
                    }
                    else
                    {
                        AgrianNetwork.instance.PriorityWaypoint.position = this.target.position;
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
                    if (AgrianNetwork.instance.RedAlertTime > 0)
                    {
                        AgrianNetwork.instance.FullPriorityWaypoint.position = this.target.position;
                    }
                    else
                    {
                        AgrianNetwork.instance.PriorityWaypoint.position = this.target.position;
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
                    if (AgrianNetwork.instance.RedAlertTime > 0)
                    {
                        AgrianNetwork.instance.FullPriorityWaypoint.position = this.target.position;
                    }
                    else
                    {
                        AgrianNetwork.instance.PriorityWaypoint.position = this.target.position;
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
                    if (AgrianNetwork.instance.RedAlertTime > 0)
                    {
                        AgrianNetwork.instance.FullPriorityWaypoint.position = this.target.position;
                    }
                    else
                    {
                        AgrianNetwork.instance.PriorityWaypoint.position = this.target.position;
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
                    if (AgrianNetwork.instance.RedAlertTime > 0)
                    {
                        AgrianNetwork.instance.FullPriorityWaypoint.position = this.target.position;
                    }
                    else
                    {
                        AgrianNetwork.instance.PriorityWaypoint.position = this.target.position;
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
                    if (AgrianNetwork.instance.RedAlertTime > 0)
                    {
                        AgrianNetwork.instance.FullPriorityWaypoint.position = this.target.position;
                    }
                    else
                    {
                        AgrianNetwork.instance.PriorityWaypoint.position = this.target.position;
                    }
                    if (AgrianNetwork.instance.AlertTime < 300)
                    {
                        AgrianNetwork.instance.AlertTime = 300;
                    }
                    AgrianNetwork.TC9CriminalLevel = 620;
                }
            }
        }
        if (this.PissedAtTC0a > 0)
        {
            this.PissedAtTC0a = this.PissedAtTC0a - 1;
        }
        if (this.PissedAtTC1 > 0)
        {
            this.PissedAtTC1 = this.PissedAtTC1 - 1;
        }
        if (this.PissedAtTC3 > 0)
        {
            this.PissedAtTC3 = this.PissedAtTC3 - 1;
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
        if (this.PissedAtTC8 > 0)
        {
            this.PissedAtTC8 = this.PissedAtTC8 - 1;
        }
        if (this.PissedAtTC9 > 0)
        {
            this.PissedAtTC9 = this.PissedAtTC9 - 1;
        }
        if (this.target)
        {
            if (((this.PissedAtTC0a < 1) && (this.Looking < 1)) && this.target.name.Contains("TC0a"))
            {
                this.target = null;
            }
        }
        if (this.target)
        {
            if (((this.PissedAtTC1 < 1) && (this.Looking < 1)) && this.target.name.Contains("TC1"))
            {
                this.target = null;
            }
        }
        if (this.target)
        {
            if (((this.PissedAtTC3 < 1) && (this.Looking < 1)) && this.target.name.Contains("TC3"))
            {
                this.target = null;
            }
        }
        if (this.target)
        {
            if (((this.PissedAtTC5 < 1) && (this.Looking < 1)) && this.target.name.Contains("TC5"))
            {
                this.target = null;
            }
        }
        if (this.target)
        {
            if (((this.PissedAtTC6 < 1) && (this.Looking < 1)) && this.target.name.Contains("TC6"))
            {
                this.target = null;
            }
        }
        if (this.target)
        {
            if (((this.PissedAtTC7 < 1) && (this.Looking < 1)) && this.target.name.Contains("TC7"))
            {
                this.target = null;
            }
        }
        if (this.target)
        {
            if (((this.PissedAtTC8 < 1) && (this.Looking < 1)) && this.target.name.Contains("TC8"))
            {
                this.target = null;
            }
        }
        if (this.target)
        {
            if (((this.PissedAtTC9 < 1) && (this.Looking < 1)) && this.target.name.Contains("TC9"))
            {
                this.target = null;
            }
        }
        this.Floorstacle = false;
        this.LineOfFire = false;
    }

    public AgrianEnforcerAI()
    {
        this.ShootFrequency = 5;
        this.UniqueShootTime = 0.1f;
    }

}