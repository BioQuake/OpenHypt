using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MevNavBattledroneAI : MonoBehaviour
{
    public Transform target;
    public Transform Waypoint;
    public Transform Forward;
    public Transform AIAnchor;
    public RemoveOverTime NpcController;
    public Transform Home;
    public Transform TargetTrace;
    public Transform TargetLead;
    public Transform TargetLead2;
    public SphereCollider TLCol;
    public GameObject Explosion;
    public GameObject MissileAmmo;
    public Transform Missile1;
    public Transform Missile2;
    public Transform Missile3;
    public Transform Missile4;
    public bool Sequence1;
    public bool Sequence2;
    public bool Boost;
    public NPCGun Gun;
    public SphereCollider Trig;
    public GameObject Presence;
    public ParticleSystem TFX1;
    public ParticleSystem TFX2;
    public ParticleSystem TFX3;
    public AudioSource BoostSound;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public GameObject SpotSound;
    public GameObject AttackSound;
    public GameObject RejectSound;
    public GameObject DispenseSound;
    public GameObject PriorityWaypoint;
    public bool Battledrone;
    public bool Cannondrone;
    public bool Wardrone;
    public bool Vult;
    public int PissedAtTC0a;
    public int PissedAtTC1;
    public int PissedAtTC2;
    public int PissedAtTC3;
    public int PissedAtTC4;
    public int PissedAtTC5;
    public int PissedAtTC6;
    public int PissedAtTC8;
    public int PissedAtTC9;
    public Transform Dodge;
    public bool Attacking;
    public bool Obstacle;
    public bool Stuck;
    public bool TargetTooClose;
    public bool Steady;
    public bool Stopping;
    public bool Damaged;
    public bool Jammed;
    public bool Activated;
    public bool Pause;
    public bool GotHit;
    public bool IsBehind;
    public bool Far;
    public int CloseN;
    public bool SlowingDown;
    public bool TurnRight;
    public bool TurnLeft;
    public int Spot;
    public int Ignorage;
    public int FedUp;
    public int DangerSense;
    public float Dist;
    public float Clamp;
    public float Vel;
    public float AngVel;
    public Vector3 localV;
    public Vector3 relativePoint;
    public LayerMask targetLayers;
    public LayerMask MtargetLayers;
    public float RD;
    public float GyroForce;
    public float TurnForce;
    public float ShootFrequency;
    public float LaunchFrequency;
    public float UniqueShootTime;
    public bool GyroOff;
    public virtual IEnumerator Start()
    {
        this.InvokeRepeating("Regenerator", 1, 1);
        this.InvokeRepeating("Targety", 15, 15);
        this.InvokeRepeating("Shooty", 1, this.ShootFrequency);
        this.InvokeRepeating("CalcLead", 1, 0.15f);
        if (this.Vult)
        {
            if (!WorldInformation.bigMissile1)
            {
                WorldInformation.bigMissile1 = this.thisVTransform;
            }
            else
            {
                WorldInformation.bigMissile2 = this.thisVTransform;
            }
        }
        this.GyroForce = 0.05f;
        this.UniqueShootTime = Random.Range(0, 0.2f);
        yield return new WaitForSeconds(0.3f);
        if (this.target)
        {
            if (this.target.name.Contains("TC"))
            {
                this.Attacking = true;
            }
        }
        this.Activated = true;
        yield return new WaitForSeconds(3);
        this.Pause = false;
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        if (!this.Activated)
        {
            return;
        }
        if (this.target)
        {
            this.Dist = Vector3.Distance(this.thisTransform.position, this.target.position);
        }
        this.Clamp = Mathf.Clamp(this.Dist, 30, 90);
        this.Vel = this.vRigidbody.velocity.magnitude;
        this.thisTransform.rotation = this.AIAnchor.transform.rotation;
        this.thisTransform.position = this.AIAnchor.transform.position;
        if (this.Battledrone)
        {
            if (((this.AngVel < 0.3f) && this.GotHit) && !this.IsBehind)
            {
                this.Steady = true;
            }
            else
            {
                this.Steady = false;
            }
        }
        if (this.Attacking)
        {
            if (this.target == null)
            {
                this.StopAllCoroutines();
                this.target = this.Waypoint;
                this.Dodge = null;
                this.Attacking = false;
                this.Spot = 0;
            }
            else
            {
                if (this.target == this.Forward)
                {
                    this.target = this.Waypoint;
                    this.Dodge = null;
                    this.Attacking = false;
                    this.Spot = 0;
                }
                if (this.target.name.Contains("bro"))
                {
                    this.StopAllCoroutines();
                    this.target = this.Waypoint;
                    this.Dodge = null;
                    this.Attacking = false;
                    this.Spot = 0;
                }
            }
        }
        if (this.TurnLeft)
        {
            this.TurnForce = -2;
        }
        if (this.TurnRight)
        {
            this.TurnForce = 2;
        }
        if (!this.TurnRight && !this.TurnLeft)
        {
            this.TurnForce = 0;
        }
        if (this.TurnRight && this.TurnLeft)
        {
            this.TurnForce = 0;
        }
        Vector3 newRot = (this.thisTransform.forward * 0.5f).normalized;
        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 1), newRot * 50f, Color.green);
        if (this.Vult)
        {
            if (this.target)
            {
                this.relativePoint = this.thisVTransform.InverseTransformPoint(this.target.position);
                if (((this.Dist < 40) && this.Attacking) && !this.GotHit)
                {
                    this.TargetTooClose = true;
                }
                else
                {
                    this.TargetTooClose = false;
                }
            }
            if (this.Dist < 50)
            {
                return;
            }
        }
        else
        {
            if (this.target)
            {
                this.relativePoint = this.thisVTransform.InverseTransformPoint(this.target.position);
                if (((this.Dist < 20) && this.Attacking) && !this.GotHit)
                {
                    this.TargetTooClose = true;
                }
                else
                {
                    this.TargetTooClose = false;
                }
            }
        }
        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 1), this.thisTransform.forward, out hit, 50, (int) this.targetLayers) && (-this.localV.y > 30))
        {
            this.SlowingDown = true;
        }
        else
        {
            this.SlowingDown = false;
        }
        newRot = ((this.thisTransform.forward * 0.8f) + (this.thisTransform.right * 0.1f)).normalized;
        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.right * 1.2f), newRot * 30, Color.black);
        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.right * 1.2f), newRot, 30))
        {
            this.TurnLeft = true;
        }
        else
        {
            this.TurnLeft = false;
        }
        newRot = ((this.thisTransform.forward * 0.8f) + (this.thisTransform.right * -0.1f)).normalized;
        Debug.DrawRay(this.thisTransform.position + (-this.thisTransform.right * 1.2f), newRot * 30, Color.black);
        if (Physics.Raycast(this.thisTransform.position + (-this.thisTransform.right * 1.2f), newRot, 30))
        {
            this.TurnRight = true;
        }
        else
        {
            this.TurnRight = false;
        }
    }

    public virtual void FixedUpdate()
    {
        RaycastHit hit = default(RaycastHit);
        RaycastHit hit2 = default(RaycastHit);
        if (!this.Activated || this.Jammed)
        {
            return;
        }
        this.AngVel = this.vRigidbody.angularVelocity.magnitude;
        this.localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
        if (!this.Stopping)
        {
            this.Obstacle = false;
        }
        else
        {
            this.Obstacle = true;
        }
        if (this.localV.z < 0)
        {
            this.RD = Mathf.Abs(this.localV.z);
        }
        else
        {
            this.RD = 0;
        }
        this.vRigidbody.AddTorque(this.thisTransform.up * this.TurnForce);
        if (this.target && !this.Pause)
        {
            if (!this.Wardrone)
            {
                if (this.AngVel < 1)
                {
                    if (this.Attacking)
                    {
                        this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * 2, this.thisTransform.forward * 2);
                        this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * -2, -this.thisTransform.forward * 2);
                        this.GyroForce = 0;
                    }
                    else
                    {
                        this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * 1, this.thisTransform.forward * 2);
                        this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * -1, -this.thisTransform.forward * 2);
                    }
                }
                else
                {
                    this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * 0.5f, this.thisTransform.forward * 2);
                    this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * -0.5f, -this.thisTransform.forward * 2);
                    this.GyroForce = 0.5f;
                }
            }
            else
            {
                if (this.Attacking)
                {
                    if (this.FedUp < 5)
                    {
                        if (!this.Obstacle)
                        {
                            if (this.Steady)
                            {
                                if (this.Far)
                                {
                                    this.GyroForce = 1;
                                    this.vRigidbody.AddForce(this.thisVTransform.forward * 4);
                                    this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * 0.5f, this.thisTransform.forward * 2);
                                    this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * -0.5f, -this.thisTransform.forward * 2);
                                }
                                else
                                {
                                    this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * 0.2f, this.thisTransform.forward * 2);
                                    this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * -0.2f, -this.thisTransform.forward * 2);
                                }
                            }
                            else
                            {
                                if (this.Far)
                                {
                                    this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * 1, this.thisTransform.forward * 2);
                                    this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * -1, -this.thisTransform.forward * 2);
                                    if (this.AngVel > 1)
                                    {
                                        this.GyroForce = 0.5f;
                                    }
                                    else
                                    {
                                        this.GyroForce = 0;
                                    }
                                }
                                else
                                {
                                    if (this.AngVel > 1)
                                    {
                                        this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * 0.2f, this.thisTransform.forward * 2);
                                        this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * -0.2f, -this.thisTransform.forward * 2);
                                    }
                                    else
                                    {
                                        this.GyroForce = 0;
                                        if (!this.IsBehind)
                                        {
                                            this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * 4, this.thisTransform.forward * 2);
                                            this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * -4, -this.thisTransform.forward * 2);
                                        }
                                        else
                                        {
                                            this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * 0.1f, this.thisTransform.forward * 2);
                                            this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * -0.1f, -this.thisTransform.forward * 2);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * 2, this.thisTransform.forward * 2);
                        this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * -2, -this.thisTransform.forward * 2);
                        this.GyroForce = 0;
                        this.Steady = false;
                        this.GotHit = false;
                    }
                }
                else
                {
                    this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * 1, this.thisTransform.forward * 2);
                    this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * -1, -this.thisTransform.forward * 2);
                }
            }
        }
        if (!this.Vult)
        {
            if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * 1)) + (this.thisTransform.up * 1), this.thisTransform.forward, 30, (int) this.targetLayers))
            {
                this.Obstacle = true;
            }
        }
        if (!this.Wardrone)
        {
            Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * 1)) + (-this.thisTransform.up * 1), this.thisTransform.forward * 30, Color.white);
            if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * 1)) + (-this.thisTransform.up * 1), this.thisTransform.forward, out hit, 30, (int) this.targetLayers))
            {
                this.Obstacle = true;
                if (hit.collider.tag.Contains("Te"))
                {
                    this.vRigidbody.AddTorque(this.thisTransform.right * -1);
                    if (this.Attacking)
                    {
                        this.vRigidbody.AddForce(this.thisVTransform.forward * 6);
                    }
                    else
                    {
                        this.vRigidbody.AddForce(this.thisVTransform.forward * 3);
                    }
                }
                if (hit.collider.tag.Contains("Str"))
                {
                    this.vRigidbody.AddTorque(this.thisTransform.right * -1);
                    if (this.Attacking)
                    {
                        this.vRigidbody.AddForce(this.thisVTransform.forward * 6);
                    }
                    else
                    {
                        this.vRigidbody.AddForce(this.thisVTransform.forward * 3);
                    }
                }
            }
        }
        else
        {
            Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * 1)) + (-this.thisTransform.up * 1), this.thisTransform.forward * 30, Color.white);
            if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * 1)) + (-this.thisTransform.up * 1), this.thisTransform.forward, out hit2, 30, (int) this.targetLayers))
            {
                this.Obstacle = true;
                this.vRigidbody.AddTorque(this.thisTransform.right * -1);
                if (this.Attacking)
                {
                    this.vRigidbody.AddForce(this.thisVTransform.forward * 6);
                }
                else
                {
                    this.vRigidbody.AddForce(this.thisVTransform.forward * 3);
                }
                this.IsBehind = true;
            }
        }
        this.vRigidbody.AddForceAtPosition(Vector3.up * this.GyroForce, this.thisTransform.up * 2);
        this.vRigidbody.AddForceAtPosition(-Vector3.up * this.GyroForce, -this.thisTransform.up * 2);
        if (!Physics.Raycast(this.thisTransform.position, this.thisTransform.up, 2, (int) this.targetLayers))
        {
            if (Physics.Raycast(this.thisTransform.position, Vector3.down, 5 + this.RD, (int) this.targetLayers))
            {
                this.vRigidbody.AddForce(Vector3.up * 4);
                this.GyroForce = 1;
            }
        }
        else
        {
            this.vRigidbody.AddForce(this.thisVTransform.forward * -4);
        }
        if (!Physics.Raycast(this.thisTransform.position, Vector3.down, 50, (int) this.targetLayers))
        {
            if (!this.Steady)
            {
                this.vRigidbody.AddForce(Vector3.up * -1.5f);
            }
        }
        if (this.Obstacle)
        {
            if (-this.localV.y > 0)
            {
                if (-this.localV.y > 10)
                {
                    this.vRigidbody.AddForce(-this.thisVTransform.up * -2);
                }
                else
                {
                    this.vRigidbody.AddForce(-this.thisVTransform.up * -1);
                }
            }
        }
        if (this.TargetTooClose)
        {
            this.vRigidbody.AddForce(this.thisVTransform.up * 1);
        }
        if (!this.Wardrone)
        {
            if (!this.Vult)
            {
                if (this.Dodge)
                {
                    this.vRigidbody.AddForce(this.thisVTransform.right * 1.5f);
                }
                if (this.Stuck)
                {
                    this.vRigidbody.AddForce(-this.thisVTransform.up * -1.5f);
                }
                if (this.Vel < 60)
                {
                    if (this.Attacking)
                    {
                        if ((((!this.Obstacle && !this.Stuck) && !this.SlowingDown) && !this.TurnLeft) && !this.TurnRight)
                        {
                            this.vRigidbody.AddForce(-this.thisVTransform.up * 2);
                        }
                    }
                    else
                    {
                        if ((((!this.Obstacle && !this.Stuck) && !this.SlowingDown) && !this.TurnLeft) && !this.TurnRight)
                        {
                            this.vRigidbody.AddForce(-this.thisVTransform.up * 1);
                        }
                    }
                }
            }
            else
            {
                if (this.Dodge)
                {
                    this.vRigidbody.AddForce(Vector3.up * 4);
                }
                if (this.Stuck)
                {
                    this.vRigidbody.AddForce(-this.thisVTransform.up * -0.5f);
                }
                if (this.Boost)
                {
                    if (this.Vel < 160)
                    {
                        if ((((!this.Obstacle && !this.Stuck) && !this.SlowingDown) && !this.TurnLeft) && !this.TurnRight)
                        {
                            this.vRigidbody.AddForce((-this.thisVTransform.up * this.Clamp) * 0.1f);
                        }
                    }
                }
                else
                {
                    if (this.BoostSound.GetComponent<AudioSource>().isPlaying)
                    {
                        if (this.BoostSound.GetComponent<AudioSource>().volume > 0.05f)
                        {
                            this.BoostSound.GetComponent<AudioSource>().volume = this.BoostSound.GetComponent<AudioSource>().volume - 0.05f;
                        }
                        else
                        {
                            this.BoostSound.GetComponent<AudioSource>().Stop();
                        }
                    }
                    if (this.Vel < 30)
                    {
                        if ((((!this.Obstacle && !this.Stuck) && !this.SlowingDown) && !this.TurnLeft) && !this.TurnRight)
                        {
                            this.vRigidbody.AddForce(-this.thisVTransform.up * 0.2f);
                        }
                    }
                }
                if ((this.Obstacle && this.TargetTooClose) && this.Boost)
                {
                    UnityEngine.Object.Instantiate(this.Explosion, this.transform.position, this.transform.rotation);
                    this.StartCoroutine(this.NpcController.Removal());
                }
            }
        }
        else
        {
            if (this.Dodge)
            {
                this.vRigidbody.AddForce(Vector3.up * 4);
            }
            if (this.Stuck)
            {
                this.vRigidbody.AddForce(-this.thisVTransform.up * -1.5f);
            }
            if (this.Vel < 60)
            {
                if (this.Attacking)
                {
                    if ((((!this.Obstacle && !this.Stuck) && !this.SlowingDown) && !this.TurnLeft) && !this.TurnRight)
                    {
                        this.vRigidbody.AddForce(-this.thisVTransform.up * 3);
                    }
                }
                else
                {
                    if ((((!this.Obstacle && !this.Stuck) && !this.SlowingDown) && !this.TurnLeft) && !this.TurnRight)
                    {
                        this.vRigidbody.AddForce(-this.thisVTransform.up * 2);
                    }
                }
            }
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (this.Vult || !this.Activated)
        {
            return;
        }
        string ON = other.name;
        Transform OT = other.transform;
        if (Physics.Linecast(this.thisTransform.position, OT.position, (int) this.MtargetLayers))
        {
            return;
        }
        if (!this.Attacking && (this.Spot < 2))
        {
            if (ON.Contains("TC") && !ON.Contains("TC7"))
            {
                this.target = OT;
                this.Spot = 4;
                GameObject TheThing0 = UnityEngine.Object.Instantiate(this.SpotSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                TheThing0.transform.parent = this.thisTransform;
                this.StopAllCoroutines();
            }
        }
        if (ON.Contains("TFC") && !ON.Contains("TFC7"))
        {
            if (ON.Contains("TFC0a"))
            {
                this.PissedAtTC0a = this.PissedAtTC0a + 1;
            }
            if (ON.Contains("TFC1"))
            {
                this.PissedAtTC1 = this.PissedAtTC1 + 1;
            }
            if (ON.Contains("TFC2"))
            {
                this.PissedAtTC2 = this.PissedAtTC2 + 1;
            }
            if (ON.Contains("TFC3"))
            {
                this.PissedAtTC3 = this.PissedAtTC3 + 1;
            }
            if (ON.Contains("TFC4"))
            {
                this.PissedAtTC4 = this.PissedAtTC4 + 1;
            }
            if (ON.Contains("TFC5"))
            {
                this.PissedAtTC5 = this.PissedAtTC5 + 1;
            }
            if (ON.Contains("TFC6"))
            {
                this.PissedAtTC6 = this.PissedAtTC6 + 1;
            }
            if (ON.Contains("TFC8"))
            {
                this.PissedAtTC8 = this.PissedAtTC8 + 1;
            }
            if (ON.Contains("TFC9"))
            {
                this.PissedAtTC9 = this.PissedAtTC9 + 1;
            }
            if (!this.Attacking)
            {
                this.Trig.radius = 20;
                this.DangerSense = 4;
                this.target = this.Waypoint;
                if (other.GetComponent<Rigidbody>())
                {
                    if (this.Waypoint)
                    {
                        this.Waypoint.transform.position = OT.position;
                    }
                }
            }
            this.Dodge = OT;
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if (!this.Activated)
        {
            return;
        }
        string ON = other.name;
        Transform OT = other.transform;
        if (!ON.Contains("x"))
        {
            if (Physics.Linecast(this.thisTransform.position, OT.position, (int) this.MtargetLayers))
            {
                return;
            }
        }
        if (!this.Vult)
        {
            if (this.Waypoint)
            {
                if (this.DangerSense > 0)
                {
                    if (ON.Contains("TC") && !ON.Contains("TC7"))
                    {
                        if (Vector3.Distance(OT.position, this.Waypoint.transform.position) < 40)
                        {
                            this.target = OT;
                            this.DangerSense = 0;
                            this.Spot = 0;
                        }
                    }
                }
            }
        }
        else
        {
            if (other.GetComponent<Collider>().name.Contains("TC7"))
            {
                this.Spot = 2;
            }
        }
    }

    public virtual IEnumerator Shoot()
    {
        if (this.Attacking)
        {
            yield return new WaitForSeconds(this.UniqueShootTime);
            this.Gun.Fire();
        }
    }

    public virtual IEnumerator Launch()
    {
        if (this.Attacking)
        {
            if (!this.Wardrone)
            {
                if (this.Steady)
                {
                    if (this.Sequence1)
                    {
                        this.Sequence1 = false;
                        if (this.Missile1 != null)
                        {
                            GameObject _SpawnedObject1 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile1.position, this.Missile1.rotation);
                            _SpawnedObject1.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1.35f;
                        }
                        yield return new WaitForSeconds(0.5f);
                        if (this.Missile2 != null)
                        {
                            GameObject _SpawnedObject2 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile2.position, this.Missile2.rotation);
                            _SpawnedObject2.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1.35f;
                        }
                        this.GotHit = false;
                        yield return new WaitForSeconds(5);
                        this.Sequence2 = true;
                        yield break;
                    }
                    if (this.Sequence2)
                    {
                        this.Sequence2 = false;
                        if (this.Missile3 != null)
                        {
                            GameObject _SpawnedObject3 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile3.position, this.Missile3.rotation);
                            _SpawnedObject3.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1.35f;
                        }
                        yield return new WaitForSeconds(0.5f);
                        if (this.Missile4 != null)
                        {
                            GameObject _SpawnedObject4 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile4.position, this.Missile4.rotation);
                            _SpawnedObject4.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1.35f;
                        }
                        this.GotHit = false;
                    }
                }
            }
            else
            {
                if (this.GotHit)
                {
                    GameObject TheThing1 = UnityEngine.Object.Instantiate(this.DispenseSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                    TheThing1.transform.parent = this.thisTransform;
                    GameObject _SpawnedObject5 = UnityEngine.Object.Instantiate(this.MissileAmmo, this.Missile1.position, this.Missile1.rotation);
                    _SpawnedObject5.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity;
                    _SpawnedObject5.GetComponent<Rigidbody>().AddForce(this.Missile1.transform.up * -1);
                    ((MissileScript) _SpawnedObject5.transform.GetComponent(typeof(MissileScript))).target = this.TargetLead2;
                    this.CloseN = 0;
                    this.Far = false;
                    this.GotHit = false;
                    this.Steady = true;
                    yield return new WaitForSeconds(1);
                    this.Steady = false;
                }
            }
        }
    }

    public virtual void Shooty()
    {
        if (!this.Vult)
        {
            if (this.Attacking)
            {
                this.StartCoroutine(this.Shoot());
                if (!this.Cannondrone && !this.Wardrone)
                {
                    this.StartCoroutine(this.Launch());
                }
            }
        }
    }

    public virtual void Engagey()
    {
        this.Attacking = true;
        GameObject TheThing3 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
        TheThing3.transform.parent = this.thisTransform;
        this.Dodge = null;
        this.StopAllCoroutines();
    }

    public virtual void Targety()
    {
        if (this.Ignorage > 5)
        {
            this.Ignorage = 0;
            this.Attacking = false;
            this.target = this.Forward;
            GameObject TheThing2 = UnityEngine.Object.Instantiate(this.RejectSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
            TheThing2.transform.parent = this.thisTransform;
        }
        if (((this.Spot < 1) && !this.Attacking) && !this.Vult)
        {
            this.StartCoroutine(this.TargetArea());
        }
    }

    public virtual IEnumerator IsMoving()
    {
        this.Stuck = true;
        yield return new WaitForSeconds(1);
        this.Stuck = false;
    }

    public virtual IEnumerator TargetArea()
    {
        if (this.Vult)
        {
            yield break;
        }
        if (this.Waypoint)
        {
            if (MevNavNetwork.AlertTime > 0)
            {
                this.Waypoint.transform.position = MevNavNetwork.instance.PriorityWaypoint.position;
                this.target = this.Waypoint;
            }
        }
        yield return new WaitForSeconds(8);
        this.target = this.Forward;
    }

    public virtual void CalcLead()
    {
        if (this.Wardrone)
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
            float Dist2 = Vector3.Distance(this.TargetTrace.position, this.target.position);
            this.TargetTrace.LookAt(this.target);
            this.TargetLead.position = this.TargetTrace.position;
            this.TargetLead.rotation = this.TargetTrace.rotation;
            this.TargetLead2.position = this.TargetTrace.position;
            this.TargetLead2.rotation = this.TargetTrace.rotation;
            this.TargetLead.position = this.TargetLead.position + (((this.TargetLead.forward * this.Dist) * Dist2) * 0.03f);
            this.TargetLead2.position = this.TargetLead2.position + ((this.TargetLead.forward * Dist2) * 2);
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
        if (!this.Activated)
        {
            return;
        }
        if (!this.Vult)
        {
            this.Stopping = false;
            if (this.target)
            {
                if (this.Attacking)
                {
                    if (this.Dist > 500)
                    {
                        this.Attacking = false;
                        this.Spot = 0;
                        this.Waypoint.transform.position = this.target.transform.position;
                        this.target = this.Waypoint;
                    }
                }
                if (this.Spot < 4)
                {
                    if (this.target.name.Contains("TC0"))
                    {
                        this.Gun.ConfirmedName = this.target.name;
                        if (this.Dodge)
                        {
                            if (!this.Dodge.name.Contains("C0"))
                            {
                                this.Ignorage = this.Ignorage + 1;
                            }
                            else
                            {
                                this.Ignorage = 0;
                            }
                        }
                        else
                        {
                            this.Ignorage = this.Ignorage + 1;
                        }
                        if (!this.Attacking)
                        {
                            if (this.DangerSense > 0)
                            {
                                this.Engagey();
                            }
                        }
                    }
                    if (this.target.name.Contains("C1"))
                    {
                        this.Gun.ConfirmedName = this.target.name;
                        if (this.Dodge)
                        {
                            if (!this.Dodge.name.Contains("C1"))
                            {
                                this.Ignorage = this.Ignorage + 1;
                            }
                            else
                            {
                                this.Ignorage = 0;
                            }
                        }
                        else
                        {
                            this.Ignorage = this.Ignorage + 1;
                        }
                        if (!this.Attacking)
                        {
                            if (MevNavNetwork.TC1DeathRow > 300)
                            {
                                MevNavNetwork.instance.PriorityWaypoint.position = this.target.position;
                                if (MevNavNetwork.TC1DeathRow < 600)
                                {
                                    MevNavNetwork.TC1DeathRow = 600;
                                }
                                else
                                {
                                    MevNavNetwork.AlertLVL2 = 1;
                                }
                            }
                            if ((this.PissedAtTC1 > 1) || (MevNavNetwork.TC1DeathRow > 0))
                            {
                                this.Engagey();
                            }
                        }
                    }
                    if (this.target.name.Contains("C2"))
                    {
                        this.Gun.ConfirmedName = this.target.name;
                        if (this.Dodge)
                        {
                            if (!this.Dodge.name.Contains("C2"))
                            {
                                this.Ignorage = this.Ignorage + 1;
                            }
                            else
                            {
                                this.Ignorage = 0;
                            }
                        }
                        else
                        {
                            this.Ignorage = this.Ignorage + 1;
                        }
                        if (!this.Attacking)
                        {
                            if (this.PissedAtTC2 > 1)
                            {
                                this.Engagey();
                            }
                        }
                    }
                    if (this.target.name.Contains("C3"))
                    {
                        this.Gun.ConfirmedName = this.target.name;
                        if (this.Dodge)
                        {
                            if (!this.Dodge.name.Contains("C3"))
                            {
                                this.Ignorage = this.Ignorage + 1;
                            }
                            else
                            {
                                this.Ignorage = 0;
                            }
                        }
                        else
                        {
                            this.Ignorage = this.Ignorage + 1;
                        }
                        if (!this.Attacking)
                        {
                            if ((MevNavNetwork.TC3DeathRow > 300) && (MevNavNetwork.TC1DeathRow < 300))
                            {
                                MevNavNetwork.instance.PriorityWaypoint.position = this.target.position;
                                if (MevNavNetwork.TC3DeathRow < 600)
                                {
                                    MevNavNetwork.TC3DeathRow = 600;
                                }
                                else
                                {
                                    MevNavNetwork.AlertLVL2 = 3;
                                }
                            }
                            if ((this.PissedAtTC3 > 1) || (MevNavNetwork.TC3DeathRow > 0))
                            {
                                this.Engagey();
                            }
                        }
                    }
                    if (this.target.name.Contains("C4"))
                    {
                        this.Gun.ConfirmedName = this.target.name;
                        if (this.Dodge)
                        {
                            if (!this.Dodge.name.Contains("C4"))
                            {
                                this.Ignorage = this.Ignorage + 1;
                            }
                            else
                            {
                                this.Ignorage = 0;
                            }
                        }
                        else
                        {
                            this.Ignorage = this.Ignorage + 1;
                        }
                        if (!this.Attacking)
                        {
                            if ((MevNavNetwork.TC4DeathRow > 300) && (MevNavNetwork.TC1DeathRow < 300))
                            {
                                MevNavNetwork.instance.PriorityWaypoint.position = this.target.position;
                                if (MevNavNetwork.TC4DeathRow < 600)
                                {
                                    MevNavNetwork.TC4DeathRow = 600;
                                }
                                else
                                {
                                    MevNavNetwork.AlertLVL2 = 4;
                                }
                            }
                            if ((this.PissedAtTC4 > 1) || (MevNavNetwork.TC4DeathRow > 0))
                            {
                                this.Engagey();
                            }
                        }
                    }
                    if (this.target.name.Contains("C5"))
                    {
                        this.Gun.ConfirmedName = this.target.name;
                        if (this.Dodge)
                        {
                            if (!this.Dodge.name.Contains("C5"))
                            {
                                this.Ignorage = this.Ignorage + 1;
                            }
                            else
                            {
                                this.Ignorage = 0;
                            }
                        }
                        else
                        {
                            this.Ignorage = this.Ignorage + 1;
                        }
                        if (!this.Attacking)
                        {
                            if ((MevNavNetwork.TC5DeathRow > 300) && (MevNavNetwork.TC1DeathRow < 300))
                            {
                                MevNavNetwork.instance.PriorityWaypoint.position = this.target.position;
                                if (MevNavNetwork.TC5DeathRow < 600)
                                {
                                    MevNavNetwork.TC5DeathRow = 600;
                                }
                                else
                                {
                                    MevNavNetwork.AlertLVL2 = 5;
                                }
                            }
                            if ((this.PissedAtTC5 > 1) || (MevNavNetwork.TC5DeathRow > 0))
                            {
                                this.Engagey();
                            }
                        }
                    }
                    if (this.target.name.Contains("C6"))
                    {
                        this.Gun.ConfirmedName = this.target.name;
                        if (this.Dodge)
                        {
                            if (!this.Dodge.name.Contains("C6"))
                            {
                                this.Ignorage = this.Ignorage + 1;
                            }
                            else
                            {
                                this.Ignorage = 0;
                            }
                        }
                        else
                        {
                            this.Ignorage = this.Ignorage + 1;
                        }
                        if (!this.Attacking)
                        {
                            if ((MevNavNetwork.TC6DeathRow > 300) && (MevNavNetwork.TC1DeathRow < 300))
                            {
                                MevNavNetwork.instance.PriorityWaypoint.position = this.target.position;
                                if (MevNavNetwork.TC6DeathRow < 600)
                                {
                                    MevNavNetwork.TC6DeathRow = 600;
                                }
                                else
                                {
                                    MevNavNetwork.AlertLVL2 = 6;
                                }
                            }
                            if ((this.PissedAtTC6 > 1) || (MevNavNetwork.TC6DeathRow > 0))
                            {
                                this.Engagey();
                            }
                        }
                    }
                    if (this.target.name.Contains("C8"))
                    {
                        this.Gun.ConfirmedName = this.target.name;
                        if (this.Dodge)
                        {
                            if (!this.Dodge.name.Contains("C8"))
                            {
                                this.Ignorage = this.Ignorage + 1;
                            }
                            else
                            {
                                this.Ignorage = 0;
                            }
                        }
                        else
                        {
                            this.Ignorage = this.Ignorage + 1;
                        }
                        if (!this.Attacking)
                        {
                            if ((MevNavNetwork.TC8DeathRow > 300) && (MevNavNetwork.TC1DeathRow < 300))
                            {
                                MevNavNetwork.instance.PriorityWaypoint.position = this.target.position;
                                if (MevNavNetwork.TC8DeathRow < 600)
                                {
                                    MevNavNetwork.TC8DeathRow = 600;
                                }
                                else
                                {
                                    MevNavNetwork.AlertLVL2 = 8;
                                }
                            }
                            if ((this.PissedAtTC8 > 1) || (MevNavNetwork.TC8DeathRow > 0))
                            {
                                this.Engagey();
                            }
                        }
                    }
                    if (this.target.name.Contains("C9"))
                    {
                        this.Gun.ConfirmedName = this.target.name;
                        if (this.Dodge)
                        {
                            if (!this.Dodge.name.Contains("C9"))
                            {
                                this.Ignorage = this.Ignorage + 1;
                            }
                            else
                            {
                                this.Ignorage = 0;
                            }
                        }
                        else
                        {
                            this.Ignorage = this.Ignorage + 1;
                        }
                        if (!this.Attacking)
                        {
                            if ((MevNavNetwork.TC9DeathRow > 300) && (MevNavNetwork.TC1DeathRow < 300))
                            {
                                MevNavNetwork.instance.PriorityWaypoint.position = this.target.position;
                                if (MevNavNetwork.TC9DeathRow < 600)
                                {
                                    MevNavNetwork.TC9DeathRow = 600;
                                }
                                else
                                {
                                    MevNavNetwork.AlertLVL2 = 9;
                                }
                            }
                            if ((this.PissedAtTC9 > 1) || (MevNavNetwork.TC9DeathRow > 0))
                            {
                                this.Engagey();
                            }
                        }
                    }
                    if (this.DangerSense > 0)
                    {
                        if (this.DangerSense < 2)
                        {
                            this.target = this.Forward;
                            this.Attacking = false;
                        }
                        this.DangerSense = this.DangerSense - 1;
                    }
                }
                else
                {
                    if (this.Spot > 2)
                    {
                        this.Spot = this.Spot - 1;
                    }
                    else
                    {
                        if (this.Dist < 70)
                        {
                            this.Spot = this.Spot - 1;
                        }
                    }
                }
                this.Dodge = null;
                this.TargetTooClose = false;
                if (this.relativePoint.y > 0)
                {
                    this.IsBehind = true;
                }
                else
                {
                    this.IsBehind = false;
                }
                if (this.Wardrone)
                {
                    if (this.Ignorage > 24)
                    {
                        this.Targety();
                    }
                    if (this.GotHit)
                    {
                        this.Far = false;
                        this.CloseN = 0;
                    }
                    if (this.Dist > 130)
                    {
                        this.Far = true;
                    }
                    else
                    {
                        this.Far = false;
                    }
                    if (!this.Far)
                    {
                        if (this.CloseN < 13)
                        {
                            this.CloseN = this.CloseN + 1;
                        }
                        if (this.CloseN > 12)
                        {
                            this.Far = true;
                        }
                    }
                    else
                    {
                        if (this.CloseN > 0)
                        {
                            this.CloseN = this.CloseN - 3;
                        }
                    }
                    this.GyroForce = 0.2f;
                    if (this.Vel < 20)
                    {
                        if (-this.relativePoint.y > 15)
                        {
                            this.StartCoroutine(this.Launch());
                        }
                    }
                    else
                    {
                        if (-this.relativePoint.y > 30)
                        {
                            this.StartCoroutine(this.Launch());
                        }
                    }
                    if (!this.IsBehind)
                    {
                        this.CloseN = 0;
                        this.Far = false;
                    }
                }
                else
                {
                    if (this.Ignorage > 6)
                    {
                        this.Targety();
                    }
                    this.GyroForce = 0.2f;
                    if (this.Presence.name.Contains("j"))
                    {
                        this.Jammed = true;
                    }
                }
                Vector3 lastPos = this.thisTransform.position;
                Vector3 lastTPos = this.target.position;
                this.StartCoroutine(this.IsEscaping(lastPos, lastTPos, this.relativePoint.y));
            }
            if (this.Attacking)
            {
                this.Trig.radius = 50;
            }
            else
            {
                this.Trig.radius = 100;
                if (this.Home)
                {
                    if (Vector3.Distance(this.thisTransform.position, this.Home.position) > 200)
                    {
                        this.target = this.Home;
                    }
                    else
                    {
                        this.target = this.Forward;
                    }
                }
            }
            if (this.Spot > 0)
            {
                this.Spot = this.Spot - 1;
            }
        }
        else
        {
            if (this.target)
            {
                if (this.target.name.Contains("TC") || this.target.name.Contains("bro"))
                {
                    if (this.target.name.Contains("bTC"))
                    {
                        if (!this.Boost)
                        {
                            this.Boost = true;
                            this.Attacking = true;
                            this.BoostSound.GetComponent<AudioSource>().volume = 1;
                            this.BoostSound.Play();
                            this.TFX1.emissionRate = 200;
                            this.TFX2.emissionRate = 200;
                            this.TFX3.emissionRate = 100;
                        }
                        this.Stopping = false;
                    }
                    else
                    {
                        if (this.Boost)
                        {
                            this.Boost = false;
                            this.Attacking = false;
                            this.TFX1.emissionRate = 0;
                            this.TFX2.emissionRate = 0;
                            this.TFX3.emissionRate = 0;
                        }
                        if (this.Dist < 600)
                        {
                            this.Stopping = true;
                        }
                        else
                        {
                            this.Stopping = false;
                        }
                    }
                }
                else
                {
                    if (this.Boost)
                    {
                        this.Boost = false;
                        this.Attacking = false;
                        this.TFX1.emissionRate = 0;
                        this.TFX2.emissionRate = 0;
                        this.TFX3.emissionRate = 0;
                    }
                    if (this.Dist < 600)
                    {
                        this.Stopping = true;
                    }
                    else
                    {
                        this.Stopping = false;
                    }
                    this.target = MevNavNetwork.instance.EnemyTarget1;
                }
            }
            else
            {
                this.target = MevNavNetwork.instance.EnemyTarget1;
            }
        }
    }

    public virtual IEnumerator IsEscaping(Vector3 lastPos, Vector3 lastTPos, float Measure1)
    {
        this.Stuck = false;
        float AngMeasure = this.AngVel;
        yield return new WaitForSeconds(0.5f);
        if (this.target)
        {
            Vector3 Measure2 = this.relativePoint;
            if (this.target)
            {
                if ((this.Spot < 1) && (this.target != this.Waypoint))
                {
                    if (Vector3.Distance(this.target.position, lastTPos) < 0.5f)
                    {
                        this.Ignorage = this.Ignorage + 1;
                    }
                }
            }
        
            if (Mathf.Abs(AngMeasure - this.AngVel) < 1)
            {
                this.FedUp = this.FedUp + 1;
            }
            if (Mathf.Abs(Measure1 - Measure2.y) < 2)
            {
                this.FedUp = this.FedUp + 1;
            }
            else
            {
                if (this.FedUp > 0)
                {
                    this.FedUp = this.FedUp - 1;
                }
            }
            if (this.FedUp > 8)
            {
                this.FedUp = 0;
            }
            if ((Vector3.Distance(this.thisTransform.position, lastPos) < 1) && !this.Stopping)
            {
                this.Stuck = true;
                yield return new WaitForSeconds(1);
                this.Stuck = false;
            }
        }
    }

    public MevNavBattledroneAI()
    {
        this.Sequence1 = true;
        this.GyroForce = 0.2f;
        this.ShootFrequency = 5;
        this.LaunchFrequency = 10;
        this.UniqueShootTime = 0.1f;
    }

}