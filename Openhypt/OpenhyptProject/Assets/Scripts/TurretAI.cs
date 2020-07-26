using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class TurretAI : MonoBehaviour
{
    public Transform target;
    public Transform Suspect;
    public Transform ResetView;
    public NPCGun Gun;
    public Rigidbody GunRB;
    public Transform GunTF;
    public CapsuleCollider Trig;
    public int TrigRadius;
    public int TrigLength;
    public int TrigCenter;
    public GameObject TurretEnergySupply;
    public Transform theParent;
    public Transform thisTransform;
    public Transform TargetTrace;
    public Transform TargetLead;
    public SphereCollider TLCol;
    public AudioSource SoundAction;
    public AudioSource SoundWarning;
    public bool SimpleAimer;
    public bool LeadedAimer;
    public bool TandemAimer;
    public TurretAI Tandem;
    public bool IgnoreTiny;
    public bool CloseToBase;
    public bool BaseTurret;
    public bool VehicleTurret;
    public bool HostileTurret;
    public int TargetCode;
    public bool IsA;
    public bool IsB;
    public bool IsC;
    public AberrantCruiserAI AberrantAICruiser;
    public AberrantDestroyerAI AberrantAIDestroyer;
    public AkbarCorvetteAI AkbarCorvetteAI;
    public AkbarEzymusAI AkbarEzymusAI;
    public PhobosAI PhobosAI;
    public BothunterAI BothunterAI;
    public ValiantAI ValiantAI;
    public MainVehicleController VehicleScript;
    public bool activated;
    public int PissedAtTC0a;
    public int PissedAtTC1;
    public int PissedAtTC2;
    public int PissedAtTC3;
    public int PissedAtTC4;
    public int PissedAtTC5;
    public int PissedAtTC6;
    public int PissedAtTC7;
    public int PissedAtTC8;
    public int PissedAtTC9;
    public bool TargetIsMoving;
    public string NameOfTarget;
    public Transform Stranger;
    public bool Attacking;
    public bool Spot;
    public bool Tick;
    public int DangerSense;
    public int Suspicion;
    public int Ignorage;
    public Vector3 DangerDirection;
    public LayerMask MtargetLayers;
    public float ShootFrequency;
    public float UniqueShootTime;
    public bool RandomizeShootTime;
    public float AimSpeed;
    public AnimationCurve LeadCurve;
    public float LeadAmount;
    public float Dist;
    public string ThisCode;
    public virtual void Start()
    {
        this.InvokeRepeating("Counter", 1, 0.5f);
        this.InvokeRepeating("Shooty", this.UniqueShootTime, this.ShootFrequency);
        this.InvokeRepeating("CalcLead", 1, 0.15f);
        this.transform.parent = null;
        this.target = this.ResetView;
        if (!this.VehicleTurret)
        {
            this.activated = true;
        }
        if (this.TargetTrace)
        {
            this.TargetTrace.parent = null;
            this.TargetLead.parent = null;
        }
        else
        {
            if (this.LeadedAimer)
            {
                GameObject gO1 = new GameObject("TT");
                GameObject gO2 = new GameObject("TL" + this.TargetCode);
                this.TLCol = gO2.AddComponent<SphereCollider>();
                this.TargetTrace = gO1.transform;
                this.TargetLead = gO2.transform;
                this.TargetTrace.position = this.transform.position;
                this.TargetTrace.rotation = this.transform.rotation;
                this.TargetLead.position = this.transform.position;
                this.TargetLead.rotation = this.transform.rotation;
                this.TargetTrace.parent = this.theParent;
                this.TargetLead.parent = this.theParent;
                gO2.layer = 29;
            }
        }
        this.ThisCode = this.TargetCode.ToString();
        if (this.SimpleAimer || this.TandemAimer)
        {
            if (this.Trig)
            {
                this.Trig.center = new Vector3(0, 0, 0);
                this.Trig.radius = 2;
                this.Trig.height = 2;
            }
        }
        if (this.RandomizeShootTime)
        {
            this.UniqueShootTime = Random.Range(1, 2);
        }
    }

    public virtual void Update()
    {
        if (!this.SimpleAimer && !this.TandemAimer)
        {
            if (this.HostileTurret)
            {
                this.StartCoroutine(this.Notice());
            }
            if ((this.target == null) || (this.Ignorage > 16))
            {
                this.Ignorage = 0;
                this.Suspicion = 0;
                this.Attacking = false;
                this.Trig.radius = this.TrigRadius;
                this.target = this.ResetView;
            }
        }
        if ((this.TurretEnergySupply == null) || (this.Gun == null))
        {
            this.GetComponent<Rigidbody>().freezeRotation = false;
            UnityEngine.Object.Destroy(this.gameObject);
        }
    }

    private Quaternion NewRotation;
    public virtual void FixedUpdate()
    {
        if (this.activated)
        {
            if (this.target)
            {
                this.GetComponent<Rigidbody>().freezeRotation = true;
                if (this.DangerSense < 1)
                {
                    if (this.LeadedAimer)
                    {
                        if (this.TargetLead)
                        {
                            if (this.Attacking)
                            {
                                if (this.GunRB)
                                {
                                    this.GunRB.AddTorque((-this.GunTF.right * this.Dist) * 0.03f);
                                }
                                this.NewRotation = Quaternion.LookRotation(this.TargetLead.position - this.thisTransform.position);
                                this.thisTransform.rotation = Quaternion.RotateTowards(this.thisTransform.rotation, this.NewRotation, this.AimSpeed);
                            }
                            else
                            {
                                this.NewRotation = Quaternion.LookRotation(this.target.position - this.thisTransform.position);
                                this.thisTransform.rotation = Quaternion.RotateTowards(this.thisTransform.rotation, this.NewRotation, this.AimSpeed);
                            }
                        }
                    }
                    else
                    {
                        this.NewRotation = Quaternion.LookRotation(this.target.position - this.thisTransform.position);
                        this.thisTransform.rotation = Quaternion.RotateTowards(this.thisTransform.rotation, this.NewRotation, this.AimSpeed);
                    }
                }
                if (!this.SimpleAimer && !this.TandemAimer)
                {
                    if ((this.DangerSense > 0) && (this.DangerDirection != Vector3.zero))
                    {
                        this.NewRotation = Quaternion.LookRotation(this.DangerDirection);
                        this.thisTransform.rotation = Quaternion.RotateTowards(this.thisTransform.rotation, this.NewRotation, this.AimSpeed);
                    }
                }
            }
            else
            {
                this.GetComponent<Rigidbody>().freezeRotation = false;
            }
        }
        else
        {
            if (this.target)
            {
                this.GetComponent<Rigidbody>().freezeRotation = true;
                this.NewRotation = Quaternion.LookRotation(this.target.position - this.thisTransform.position);
                this.thisTransform.rotation = Quaternion.RotateTowards(this.thisTransform.rotation, this.NewRotation, this.AimSpeed);
            }
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (!this.activated)
        {
            return;
        }
        string ON = other.name;
        Transform OT = other.transform;
        if (Physics.Linecast(this.thisTransform.position, OT.position, (int) this.MtargetLayers))
        {
            return;
        }
        if (!this.SimpleAimer && !this.TandemAimer)
        {
            if (other.GetComponent<Rigidbody>())
            {
                this.DangerDirection = -other.GetComponent<Rigidbody>().velocity.normalized;
            }
            if (ON.Contains("TFC"))
            {
                if (this.target)
                {
                    if (!ON.Contains("TFC" + this.TargetCode))
                    {
                        if (!this.target.name.Contains("TC"))
                        {
                            if (Vector3.Distance(this.thisTransform.position, OT.position) > (this.TrigRadius * 0.5f))
                            {
                                this.DangerSense = 10;
                            }
                        }
                    }
                }
                Vector3 relativePoint = OT.InverseTransformPoint(this.thisTransform.position);
                if (relativePoint.z > 0)
                {
                    this.Trig.center = new Vector3(0, 0, this.TrigCenter);
                    this.Trig.radius = this.TrigRadius * 0.5f;
                    this.Trig.height = this.TrigLength;
                }
                if (this.TargetCode != 0)
                {
                    if (ON.Contains("TFC0a"))
                    {
                        if (this.PissedAtTC0a < 32)
                        {
                            this.PissedAtTC0a = this.PissedAtTC0a + 8;
                        }
                        if (this.Suspicion < 64)
                        {
                            this.Suspicion = this.Suspicion + 18;
                        }
                        this.Spot = false;
                    }
                }
                if (this.TargetCode != 1)
                {
                    if (ON.Contains("TFC1"))
                    {
                        if (this.PissedAtTC1 < 32)
                        {
                            this.PissedAtTC1 = this.PissedAtTC1 + 8;
                        }
                        if (this.Suspicion < 64)
                        {
                            this.Suspicion = this.Suspicion + 18;
                        }
                        this.Spot = false;
                    }
                }
                if ((this.TargetCode != 2) && (this.TargetCode != 3))
                {
                    if (ON.Contains("TFC2"))
                    {
                        if (this.PissedAtTC2 < 32)
                        {
                            this.PissedAtTC2 = this.PissedAtTC2 + 8;
                        }
                        if (this.Suspicion < 64)
                        {
                            this.Suspicion = this.Suspicion + 18;
                        }
                        this.Spot = false;
                    }
                }
                if (this.TargetCode != 3)
                {
                    if (ON.Contains("TFC3"))
                    {
                        if (this.PissedAtTC3 < 32)
                        {
                            this.PissedAtTC3 = this.PissedAtTC3 + 8;
                        }
                        if (this.Suspicion < 64)
                        {
                            this.Suspicion = this.Suspicion + 18;
                        }
                        this.Spot = false;
                    }
                }
                if (this.TargetCode != 4)
                {
                    if (ON.Contains("TFC4"))
                    {
                        if (this.PissedAtTC4 < 32)
                        {
                            this.PissedAtTC4 = this.PissedAtTC4 + 8;
                        }
                        if (this.Suspicion < 64)
                        {
                            this.Suspicion = this.Suspicion + 18;
                        }
                        this.Spot = false;
                    }
                }
                if (this.TargetCode != 5)
                {
                    if (ON.Contains("TFC5"))
                    {
                        if (this.PissedAtTC5 < 32)
                        {
                            this.PissedAtTC5 = this.PissedAtTC5 + 8;
                        }
                        if (this.Suspicion < 64)
                        {
                            this.Suspicion = this.Suspicion + 18;
                        }
                        this.Spot = false;
                    }
                }
                if (this.TargetCode != 6)
                {
                    if (ON.Contains("TFC6"))
                    {
                        if (this.PissedAtTC6 < 32)
                        {
                            this.PissedAtTC6 = this.PissedAtTC6 + 8;
                        }
                        if (this.Suspicion < 64)
                        {
                            this.Suspicion = this.Suspicion + 18;
                        }
                        this.Spot = false;
                    }
                }
                if (this.TargetCode != 7)
                {
                    if (ON.Contains("TFC7"))
                    {
                        if (this.PissedAtTC7 < 32)
                        {
                            this.PissedAtTC7 = this.PissedAtTC7 + 8;
                        }
                        if (this.Suspicion < 64)
                        {
                            this.Suspicion = this.Suspicion + 18;
                        }
                        this.Spot = false;
                    }
                }
                if (this.TargetCode != 8)
                {
                    if (ON.Contains("TFC8"))
                    {
                        if (this.PissedAtTC8 < 32)
                        {
                            this.PissedAtTC8 = this.PissedAtTC8 + 8;
                        }
                        if (this.Suspicion < 64)
                        {
                            this.Suspicion = this.Suspicion + 18;
                        }
                        this.Spot = false;
                    }
                }
                if (this.TargetCode != 9)
                {
                    if (ON.Contains("TFC9"))
                    {
                        if (this.PissedAtTC9 < 32)
                        {
                            this.PissedAtTC9 = this.PissedAtTC9 + 8;
                        }
                        if (this.Suspicion < 64)
                        {
                            this.Suspicion = this.Suspicion + 18;
                        }
                        this.Spot = false;
                    }
                }
            }
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if (!this.activated)
        {
            return;
        }
        string ON = other.name;
        Transform OT = other.transform;
        if (Physics.Linecast(this.thisTransform.position, OT.position, (int) this.MtargetLayers))
        {
            return;
        }
        if (!this.SimpleAimer && !this.TandemAimer)
        {
            if (ON.Contains("TC"))
            {
                if (this.CloseToBase)
                {
                    return;
                }
                if (this.IgnoreTiny)
                {
                    if (ON.Contains("tTC"))
                    {
                        return;
                    }
                }
                if (this.HostileTurret)
                {
                    if (!ON.Contains("TC" + this.TargetCode))
                    {
                        this.target = OT;
                    }
                }
                if (this.TargetCode != 0)
                {
                    if (this.PissedAtTC0a > 4)
                    {
                        if (ON.Contains("TC0a"))
                        {
                            if (!ON.Contains("cT"))
                            {
                                this.target = OT;
                                this.Trig.center = new Vector3(0, 0, 0);
                                this.Trig.radius = this.TrigRadius;
                                this.Trig.height = this.TrigRadius;
                                if (!this.Attacking && !this.Spot)
                                {
                                    this.StartCoroutine(this.Engage());
                                }
                            }
                        }
                    }
                }
                if (this.TargetCode != 1)
                {
                    if (this.PissedAtTC1 > 4)
                    {
                        if (ON.Contains("TC1"))
                        {
                            if (!ON.Contains("cT"))
                            {
                                this.target = OT;
                                this.Trig.center = new Vector3(0, 0, 0);
                                this.Trig.radius = this.TrigRadius;
                                this.Trig.height = this.TrigRadius;
                                if (!this.Attacking && !this.Spot)
                                {
                                    this.StartCoroutine(this.Engage());
                                }
                            }
                        }
                    }
                }
                if (this.TargetCode != 2)
                {
                    if (this.TargetCode != 7)
                    {
                        if (this.PissedAtTC2 > 4)
                        {
                            if (ON.Contains("TC2"))
                            {
                                this.target = OT;
                                this.Trig.center = new Vector3(0, 0, 0);
                                this.Trig.radius = this.TrigRadius;
                                this.Trig.height = this.TrigRadius;
                                if (!this.Attacking && !this.Spot)
                                {
                                    this.StartCoroutine(this.Engage());
                                }
                            }
                        }
                    }
                    else
                    {
                        if (this.PissedAtTC2 > 4)
                        {
                            if (ON.Contains("sTC2"))
                            {
                                this.target = OT;
                                this.Trig.center = new Vector3(0, 0, 0);
                                this.Trig.radius = this.TrigRadius;
                                this.Trig.height = this.TrigRadius;
                                if (!this.Attacking && !this.Spot)
                                {
                                    this.StartCoroutine(this.Engage());
                                }
                            }
                            if (ON.Contains("mTC2"))
                            {
                                this.target = OT;
                                this.Trig.center = new Vector3(0, 0, 0);
                                this.Trig.radius = this.TrigRadius;
                                this.Trig.height = this.TrigRadius;
                                if (!this.Attacking && !this.Spot)
                                {
                                    this.StartCoroutine(this.Engage());
                                }
                            }
                        }
                    }
                }
                if (this.TargetCode != 3)
                {
                    if (this.PissedAtTC3 > 4)
                    {
                        if (ON.Contains("TC3"))
                        {
                            if (!ON.Contains("cT"))
                            {
                                this.target = OT;
                                this.Trig.center = new Vector3(0, 0, 0);
                                this.Trig.radius = this.TrigRadius;
                                this.Trig.height = this.TrigRadius;
                                if (!this.Attacking && !this.Spot)
                                {
                                    this.StartCoroutine(this.Engage());
                                }
                            }
                        }
                    }
                }
                if (this.TargetCode != 4)
                {
                    if (this.PissedAtTC4 > 4)
                    {
                        if (ON.Contains("TC4"))
                        {
                            this.target = OT;
                            this.Trig.center = new Vector3(0, 0, 0);
                            this.Trig.radius = this.TrigRadius;
                            this.Trig.height = this.TrigRadius;
                            if (!this.Attacking && !this.Spot)
                            {
                                this.StartCoroutine(this.Engage());
                            }
                        }
                    }
                }
                if (this.TargetCode != 5)
                {
                    if (this.PissedAtTC5 > 4)
                    {
                        if (ON.Contains("TC5"))
                        {
                            if (!ON.Contains("cT"))
                            {
                                this.target = OT;
                                this.Trig.center = new Vector3(0, 0, 0);
                                this.Trig.radius = this.TrigRadius;
                                this.Trig.height = this.TrigRadius;
                                if (!this.Attacking && !this.Spot)
                                {
                                    this.StartCoroutine(this.Engage());
                                }
                            }
                        }
                    }
                }
                if (this.TargetCode != 6)
                {
                    if (this.PissedAtTC6 > 4)
                    {
                        if (ON.Contains("TC6"))
                        {
                            if (!ON.Contains("cT"))
                            {
                                this.target = OT;
                                this.Trig.center = new Vector3(0, 0, 0);
                                this.Trig.radius = this.TrigRadius;
                                this.Trig.height = this.TrigRadius;
                                if (!this.Attacking && !this.Spot)
                                {
                                    this.StartCoroutine(this.Engage());
                                }
                            }
                        }
                    }
                }
                if (this.TargetCode != 7)
                {
                    if (this.PissedAtTC7 > 4)
                    {
                        if (ON.Contains("TC7"))
                        {
                            if (!ON.Contains("cT"))
                            {
                                this.target = OT;
                                this.Trig.center = new Vector3(0, 0, 0);
                                this.Trig.radius = this.TrigRadius;
                                this.Trig.height = this.TrigRadius;
                                if (!this.Attacking && !this.Spot)
                                {
                                    this.StartCoroutine(this.Engage());
                                }
                            }
                        }
                    }
                }
                if (this.TargetCode != 8)
                {
                    if (this.PissedAtTC8 > 4)
                    {
                        if (ON.Contains("TC8"))
                        {
                            if (!ON.Contains("cT"))
                            {
                                this.target = OT;
                                this.Trig.center = new Vector3(0, 0, 0);
                                this.Trig.radius = this.TrigRadius;
                                this.Trig.height = this.TrigRadius;
                                if (!this.Attacking && !this.Spot)
                                {
                                    this.StartCoroutine(this.Engage());
                                }
                            }
                        }
                    }
                }
                if (this.TargetCode != 9)
                {
                    if (this.PissedAtTC9 > 4)
                    {
                        if (ON.Contains("TC9"))
                        {
                            if (!ON.Contains("cT"))
                            {
                                this.target = OT;
                                this.Trig.center = new Vector3(0, 0, 0);
                                this.Trig.radius = this.TrigRadius;
                                this.Trig.height = this.TrigRadius;
                                if (!this.Attacking && !this.Spot)
                                {
                                    this.StartCoroutine(this.Engage());
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public virtual IEnumerator Engage()
    {
        if (!this.activated)
        {
            yield break;
        }
        if (!this.Spot)
        {
            this.Spot = true;
            yield return new WaitForSeconds(0.5f);
            if (!this.target)
            {
                yield break;
            }
            if (!this.HostileTurret)
            {
                if (this.target.name.Contains("cT"))
                {
                    yield break;
                }
            }
            if (this.target == this.Suspect)
            {
                if (this.target.name.Contains("C0a"))
                {
                    this.PissedAtTC0a = 32;
                }
                if (this.target.name.Contains("C1"))
                {
                    this.PissedAtTC1 = 32;
                }
                if (this.target.name.Contains("C2"))
                {
                    this.PissedAtTC2 = 32;
                }
                if (this.target.name.Contains("C3"))
                {
                    this.PissedAtTC3 = 32;
                }
                if (this.target.name.Contains("C4"))
                {
                    this.PissedAtTC4 = 32;
                }
                if (this.target.name.Contains("C5"))
                {
                    this.PissedAtTC5 = 32;
                }
                if (this.target.name.Contains("C6"))
                {
                    this.PissedAtTC6 = 32;
                }
                if (this.target.name.Contains("C7"))
                {
                    this.PissedAtTC7 = 32;
                }
                if (this.target.name.Contains("C8"))
                {
                    this.PissedAtTC8 = 32;
                }
                if (this.target.name.Contains("C9"))
                {
                    this.PissedAtTC9 = 32;
                }
                this.Spot = false;
                this.Attacking = true;
                this.Suspicion = 31;
                if (this.SoundAction)
                {
                    if (!this.SoundAction.isPlaying)
                    {
                        this.SoundAction.Play();
                    }
                }
            }
            else
            {
                if ((this.Suspicion > 31) || this.HostileTurret)
                {
                    this.Attacking = true;
                    this.Suspicion = 31;
                    if (this.SoundAction)
                    {
                        if (!this.SoundAction.isPlaying)
                        {
                            this.SoundAction.Play();
                        }
                    }
                }
                else
                {
                    if (this.Suspicion > 15)
                    {
                        this.Suspicion = 15;
                        if (this.SoundAction)
                        {
                            this.SoundAction.Play();
                        }
                        yield return new WaitForSeconds(0.2f);
                        if (this.SoundWarning)
                        {
                            if (!this.SoundWarning.isPlaying)
                            {
                                this.SoundWarning.Play();
                            }
                        }
                        if (this.target)
                        {
                            if (this.target.name.Contains("TC"))
                            {
                                this.Suspect = this.target;
                            }
                        }
                        yield return new WaitForSeconds(2);
                        this.Spot = false;
                    }
                }
            }
        }
        else
        {
            if (this.Suspicion > 31)
            {
                this.Spot = false;
            }
        }
    }

    public virtual void Shooty()
    {
        if (this.Attacking && this.activated)
        {
            if (this.Gun)
            {
                this.Gun.Fire();
            }
        }
    }

    public virtual void CalcLead()
    {
        if (this.LeadedAimer && this.activated)
        {
            this.StartCoroutine(this.Lead());
        }
    }

    public virtual IEnumerator Lead()
    {
        if (this.target && this.TargetTrace)
        {
            this.TargetTrace.position = this.target.position;
        }
        yield return new WaitForSeconds(0.1f);
        if (this.target && this.TargetTrace)
        {
            float Dist0 = Vector3.Distance(this.thisTransform.position, this.target.position);
            float Dist1 = Vector3.Distance(this.TargetTrace.position, this.target.position);
            float Dist2 = this.LeadCurve.Evaluate(Dist0) * Dist1;
            this.TargetTrace.LookAt(this.target);
            this.TargetLead.position = this.TargetTrace.position;
            this.TargetLead.rotation = this.TargetTrace.rotation;
            this.TargetLead.position = this.TargetLead.position + ((this.TargetLead.forward * Dist2) * this.LeadAmount);
            if (this.Attacking)
            {
                this.TLCol.radius = Dist0 * 0.05f;
            }
            else
            {
                this.TLCol.radius = 0.1f;
            }
        }
    }

    public virtual void Counter()
    {
        if (this.activated)
        {
            if (!this.SimpleAimer && !this.TandemAimer)
            {
                if (this.DangerSense > 0)
                {
                    this.DangerSense = this.DangerSense - 1;
                }
                if (this.Suspicion > 0)
                {
                    this.Suspicion = this.Suspicion - 1;
                }
                if (!this.BaseTurret)
                {
                    if (this.TargetCode == 6)
                    {
                        if (AbiaSyndicateNetwork.instance.AbiaBaseHomePoint)
                        {
                            if (Vector3.Distance(this.thisTransform.position, AbiaSyndicateNetwork.instance.AbiaBaseHomePoint.position) < 1500)
                            {
                                this.CloseToBase = true;
                            }
                            else
                            {
                                this.CloseToBase = false;
                            }
                        }
                    }
                }
                if (this.target)
                {
                    Vector3 TargetPos = this.target.position;
                    this.Dist = Vector3.Distance(this.thisTransform.position, this.target.position);
                    if (this.target.name.Contains("MTF"))
                    {
                        this.Spot = false;
                        this.Attacking = true;
                        this.DangerSense = 0;
                        this.Trig.center = new Vector3(0, 0, 0);
                        this.Trig.radius = this.TrigRadius;
                        this.Trig.height = this.TrigRadius;
                        this.Suspicion = 31;
                    }
                    if (this.target.name.Contains("rok"))
                    {
                        this.Ignorage = 0;
                        this.Suspicion = 0;
                        this.Attacking = false;
                        this.Trig.radius = this.TrigRadius;
                        this.target = this.ResetView;
                    }
                    if (this.target.name.Contains("TC"))
                    {
                        if (this.TargetCode != 0)
                        {
                            if (this.target.name.Contains("0a") && (this.PissedAtTC0a > 4))
                            {
                                if (this.PissedAtTC0a > 16)
                                {
                                    this.Suspicion = 32;
                                    this.Gun.ConfirmedName = this.target.name;
                                    if (this.TargetCode == 3)
                                    {
                                        TerrahyptianNetwork.instance.EnemyTarget1 = this.target;
                                    }
                                }
                                this.Trig.center = new Vector3(0, 0, 0);
                                this.Trig.radius = this.TrigRadius;
                                this.Trig.height = this.TrigRadius;
                                if (!this.Attacking)
                                {
                                    this.StartCoroutine(this.Engage());
                                }
                            }
                        }
                        if (this.TargetCode != 1)
                        {
                            if (this.target.name.Contains("1") && (this.PissedAtTC1 > 4))
                            {
                                if (this.PissedAtTC1 > 16)
                                {
                                    this.Suspicion = 32;
                                    this.Gun.ConfirmedName = this.target.name;
                                    if (this.TargetCode == 3)
                                    {
                                        if (TerrahyptianNetwork.TC1CriminalLevel > 10)
                                        {
                                            TerrahyptianNetwork.instance.EnemyTarget2 = this.target;
                                        }
                                    }
                                }
                                this.Trig.center = new Vector3(0, 0, 0);
                                this.Trig.radius = this.TrigRadius;
                                this.Trig.height = this.TrigRadius;
                                if (!this.Attacking)
                                {
                                    this.StartCoroutine(this.Engage());
                                }
                            }
                        }
                        if ((this.TargetCode != 2) && (this.TargetCode != 7))
                        {
                            if (this.target.name.Contains("2") && (this.PissedAtTC2 > 4))
                            {
                                if (this.PissedAtTC2 > 16)
                                {
                                    this.Suspicion = 32;
                                    this.Gun.ConfirmedName = this.target.name;
                                }
                                this.Trig.center = new Vector3(0, 0, 0);
                                this.Trig.radius = this.TrigRadius;
                                this.Trig.height = this.TrigRadius;
                                if (!this.Attacking)
                                {
                                    this.StartCoroutine(this.Engage());
                                }
                            }
                        }
                        if (this.TargetCode != 3)
                        {
                            if (this.target.name.Contains("3") && (this.PissedAtTC3 > 4))
                            {
                                if (this.PissedAtTC3 > 16)
                                {
                                    this.Suspicion = 32;
                                    this.Gun.ConfirmedName = this.target.name;
                                }
                                this.Trig.center = new Vector3(0, 0, 0);
                                this.Trig.radius = this.TrigRadius;
                                this.Trig.height = this.TrigRadius;
                                if (!this.Attacking)
                                {
                                    this.StartCoroutine(this.Engage());
                                }
                            }
                        }
                        if (this.TargetCode != 4)
                        {
                            if (this.target.name.Contains("4") && (this.PissedAtTC4 > 4))
                            {
                                if (this.PissedAtTC4 > 16)
                                {
                                    this.Suspicion = 32;
                                    this.Gun.ConfirmedName = this.target.name;
                                    if (this.TargetCode == 3)
                                    {
                                        if (TerrahyptianNetwork.TC4CriminalLevel > 10)
                                        {
                                            TerrahyptianNetwork.instance.EnemyTarget2 = this.target;
                                        }
                                    }
                                }
                                this.Trig.center = new Vector3(0, 0, 0);
                                this.Trig.radius = this.TrigRadius;
                                this.Trig.height = this.TrigRadius;
                                if (!this.Attacking)
                                {
                                    this.StartCoroutine(this.Engage());
                                }
                            }
                        }
                        if (this.TargetCode != 5)
                        {
                            if (this.target.name.Contains("5") && (this.PissedAtTC5 > 4))
                            {
                                if (this.PissedAtTC5 > 16)
                                {
                                    this.Suspicion = 32;
                                    this.Gun.ConfirmedName = this.target.name;
                                    if (this.TargetCode == 3)
                                    {
                                        if (TerrahyptianNetwork.TC5CriminalLevel > 10)
                                        {
                                            TerrahyptianNetwork.instance.EnemyTarget2 = this.target;
                                        }
                                    }
                                }
                                this.Trig.center = new Vector3(0, 0, 0);
                                this.Trig.radius = this.TrigRadius;
                                this.Trig.height = this.TrigRadius;
                                if (!this.Attacking)
                                {
                                    this.StartCoroutine(this.Engage());
                                }
                            }
                        }
                        if (this.TargetCode != 6)
                        {
                            if (this.target.name.Contains("6") && (this.PissedAtTC6 > 4))
                            {
                                if (this.PissedAtTC6 > 16)
                                {
                                    this.Suspicion = 32;
                                    this.Gun.ConfirmedName = this.target.name;
                                    if (this.TargetCode == 3)
                                    {
                                        if (TerrahyptianNetwork.TC6CriminalLevel > 10)
                                        {
                                            TerrahyptianNetwork.instance.EnemyTarget2 = this.target;
                                        }
                                    }
                                }
                                this.Trig.center = new Vector3(0, 0, 0);
                                this.Trig.radius = this.TrigRadius;
                                this.Trig.height = this.TrigRadius;
                                if (!this.Attacking)
                                {
                                    this.StartCoroutine(this.Engage());
                                }
                            }
                        }
                        if (this.TargetCode != 7)
                        {
                            if (this.target.name.Contains("7") && (this.PissedAtTC7 > 4))
                            {
                                if (this.PissedAtTC7 > 16)
                                {
                                    this.Suspicion = 32;
                                    this.Gun.ConfirmedName = this.target.name;
                                    if (this.TargetCode == 3)
                                    {
                                        if (TerrahyptianNetwork.TC7CriminalLevel > 10)
                                        {
                                            TerrahyptianNetwork.instance.EnemyTarget2 = this.target;
                                        }
                                    }
                                }
                                this.Trig.center = new Vector3(0, 0, 0);
                                this.Trig.radius = this.TrigRadius;
                                this.Trig.height = this.TrigRadius;
                                if (!this.Attacking)
                                {
                                    this.StartCoroutine(this.Engage());
                                }
                            }
                        }
                        if (this.TargetCode != 8)
                        {
                            if (this.target.name.Contains("8") && (this.PissedAtTC8 > 4))
                            {
                                if (this.PissedAtTC8 > 16)
                                {
                                    this.Suspicion = 32;
                                    this.Gun.ConfirmedName = this.target.name;
                                    if (this.TargetCode == 3)
                                    {
                                        if (TerrahyptianNetwork.TC8CriminalLevel > 10)
                                        {
                                            TerrahyptianNetwork.instance.EnemyTarget2 = this.target;
                                        }
                                    }
                                }
                                this.Trig.center = new Vector3(0, 0, 0);
                                this.Trig.radius = this.TrigRadius;
                                this.Trig.height = this.TrigRadius;
                                if (!this.Attacking)
                                {
                                    this.StartCoroutine(this.Engage());
                                }
                            }
                        }
                        if (this.TargetCode != 9)
                        {
                            if (this.target.name.Contains("9") && (this.PissedAtTC9 > 4))
                            {
                                if (this.PissedAtTC9 > 16)
                                {
                                    this.Suspicion = 32;
                                    this.Gun.ConfirmedName = this.target.name;
                                    if (this.TargetCode == 3)
                                    {
                                        if (TerrahyptianNetwork.TC9CriminalLevel > 10)
                                        {
                                            TerrahyptianNetwork.instance.EnemyTarget2 = this.target;
                                        }
                                    }
                                }
                                this.Trig.center = new Vector3(0, 0, 0);
                                this.Trig.radius = this.TrigRadius;
                                this.Trig.height = this.TrigRadius;
                                if (!this.Attacking)
                                {
                                    this.StartCoroutine(this.Engage());
                                }
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
                    if (this.PissedAtTC8 > 0)
                    {
                        this.PissedAtTC8 = this.PissedAtTC8 - 1;
                    }
                    if (this.PissedAtTC9 > 0)
                    {
                        this.PissedAtTC9 = this.PissedAtTC9 - 1;
                    }
                }
                if (this.TargetCode == 0)
                {
                    if (this.IsB)
                    {
                        this.PissedAtTC4 = 32;
                        this.PissedAtTC6 = 32;
                        this.PissedAtTC7 = 32;
                    }
                }
                if (this.TargetCode == 1)
                {
                    this.PissedAtTC4 = 32;
                    this.PissedAtTC6 = 32;
                    this.PissedAtTC7 = 32;
                }
                if (this.TargetCode == 2)
                {
                    this.PissedAtTC4 = 32;
                }
                if (this.TargetCode == 3)
                {
                    if (TerrahyptianNetwork.TC1CriminalLevel > 10)
                    {
                        this.PissedAtTC1 = TerrahyptianNetwork.TC1CriminalLevel;
                    }
                    this.PissedAtTC4 = 20;
                    if (TerrahyptianNetwork.TC5CriminalLevel > 10)
                    {
                        this.PissedAtTC5 = TerrahyptianNetwork.TC5CriminalLevel;
                    }
                    this.PissedAtTC6 = 20;
                    this.PissedAtTC7 = 20;
                }
                if (this.TargetCode == 4)
                {
                    this.PissedAtTC2 = 32;
                }
                //if(TargetCode == 5)
                if (this.TargetCode == 6)
                {
                    if (AbiaSyndicateNetwork.TC0aCriminalLevel > 0)
                    {
                        this.PissedAtTC0a = 32;
                    }
                    if (AbiaSyndicateNetwork.TC1CriminalLevel > 0)
                    {
                        this.PissedAtTC1 = 32;
                    }
                    if (AbiaSyndicateNetwork.TC2CriminalLevel > 0)
                    {
                        this.PissedAtTC2 = 32;
                    }
                    if (AbiaSyndicateNetwork.TC3CriminalLevel > 0)
                    {
                        this.PissedAtTC3 = 32;
                    }
                    if (AbiaSyndicateNetwork.TC4CriminalLevel > 0)
                    {
                        this.PissedAtTC4 = 32;
                    }
                    if (AbiaSyndicateNetwork.TC5CriminalLevel > 0)
                    {
                        this.PissedAtTC5 = 32;
                    }
                    if (AbiaSyndicateNetwork.TC7CriminalLevel > 0)
                    {
                        this.PissedAtTC7 = 32;
                    }
                }
                if (this.TargetCode == 7)
                {
                    this.PissedAtTC6 = 32;
                }
                //if(TargetCode == 8)
                //if(TargetCode == 9)
                if (this.Suspicion == 0)
                {
                    this.Attacking = false;
                    this.Trig.center = new Vector3(0, 0, 0);
                    this.Trig.radius = this.TrigRadius;
                    this.Trig.height = this.TrigRadius;
                    this.target = this.ResetView;
                }
                if (this.HostileTurret)
                {
                    if (this.TargetIsMoving)
                    {
                        this.StartCoroutine(this.Engage());
                    }
                }
                this.TargetIsMoving = false;
                this.Tick = true;
            }
            else
            {
                if (this.Tandem)
                {
                    this.target = this.Tandem.target;
                    if (!this.LeadedAimer)
                    {
                        this.NameOfTarget = this.Tandem.NameOfTarget;
                    }
                    if (this.Tandem.Attacking)
                    {
                        this.Attacking = true;
                    }
                    else
                    {
                        this.Attacking = false;
                    }
                    if (this.Tandem.TargetIsMoving)
                    {
                        this.TargetIsMoving = true;
                    }
                    else
                    {
                        this.TargetIsMoving = false;
                    }
                }
                if (this.AberrantAICruiser)
                {
                    this.target = this.AberrantAICruiser.target;
                }
                if (this.AberrantAIDestroyer)
                {
                    this.target = this.AberrantAIDestroyer.target;
                }
                if (this.AkbarCorvetteAI)
                {
                    this.target = this.AkbarCorvetteAI.target;
                }
                if (this.AkbarEzymusAI)
                {
                    this.target = this.AkbarEzymusAI.target;
                }
                if (this.PhobosAI)
                {
                    this.target = this.PhobosAI.target;
                }
                if (this.BothunterAI)
                {
                    this.target = this.BothunterAI.target;
                    this.Gun.ConfirmedName = this.NameOfTarget;
                }
                if (this.ValiantAI)
                {
                    this.target = this.ValiantAI.target;
                    this.Gun.ConfirmedName = this.NameOfTarget;
                }
            }
            if (this.VehicleTurret)
            {
                if (!this.VehicleScript.Inside)
                {
                    this.activated = false;
                }
            }
        }
        else
        {
            this.target = this.ResetView;
            if (this.VehicleTurret)
            {
                if (this.VehicleScript.Inside)
                {
                    this.activated = true;
                }
            }
        }
    }

    public virtual IEnumerator Notice()
    {
        if (this.Tick)
        {
            this.Tick = false;
            if (this.target)
            {
                Vector3 lastPos = this.target.position;
                yield return new WaitForSeconds(0.2f);
                if (this.target)
                {
                    if (this.target.name.Contains("TC"))
                    {
                        if (Vector3.Distance(this.target.position, lastPos) > 0.2f)
                        {
                            this.TargetIsMoving = true;
                            this.Ignorage = 0;
                        }
                        else
                        {
                            this.Ignorage = this.Ignorage + 1;
                        }
                    }
                }
            }
        }
    }

    public TurretAI()
    {
        this.TrigRadius = 75;
        this.TrigLength = 700;
        this.TrigCenter = 275;
        this.IgnoreTiny = true;
        this.NameOfTarget = "TC";
        this.ShootFrequency = 0.2f;
        this.UniqueShootTime = 0.1f;
        this.AimSpeed = 100;
        this.LeadCurve = new AnimationCurve();
        this.LeadAmount = 0.017f;
    }

}