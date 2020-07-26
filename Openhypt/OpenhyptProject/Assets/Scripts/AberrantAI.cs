using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AberrantAI : MonoBehaviour
{
    public Transform target;
    public Transform Waypoint;
    public Transform Waypoint2;
    public CapsuleCollider Trig;
    public NPCGun AberrantGun1;
    public NPCGun AberrantGun2;
    public GameObject AberrantPresence;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public GameObject HuntingSound;
    public GameObject SpotSound;
    public GameObject AttackSound;
    public GameObject RejectSound;
    public bool isGunnerAberrant;
    public bool DecrepitAberrant;
    public bool PissedAtTC0a;
    public bool PissedAtTC1;
    public bool PissedAtTC3;
    public bool PissedAtTC5;
    public bool PissedAtTC6;
    public bool PissedAtTC7;
    public bool PissedAtTC8;
    public bool PissedAtTC9;
    public bool Hunting;
    public bool Spot;
    public bool TargetIsMoving;
    public bool Attacking;
    public bool Obstacle;
    public bool Stuck;
    public bool TargetTooClose;
    public AnimationCurve AttackManeuverCurve;
    public bool TurnRight;
    public bool TurnLeft;
    public float TurnForce;
    public float GyroForce;
    public float HullMovage;
    public bool DangerSense;
    public Vector3 DangerDirection;
    public LayerMask targetLayers;
    public LayerMask MtargetLayers;
    public int JustNoticed;
    public int Suspicion;
    public int TargetStill;
    public float Dist;
    public float ShootFrequency;
    public float UniqueShootTime;
    public bool Tick;
    public virtual void Start()
    {
        this.InvokeRepeating("Regenerator", 1, 1);
        this.InvokeRepeating("LeaveMarker", 1, 10);
        this.InvokeRepeating("Warning", 5, Random.Range(19, 21));
        this.InvokeRepeating("Targety", 120, 120);
        this.InvokeRepeating("Shooty", this.UniqueShootTime, this.ShootFrequency);
        this.UniqueShootTime = Random.Range(1, 2);
    }

    public virtual void Update()
    {
        if (!this.DecrepitAberrant)
        {
            this.StartCoroutine(this.Notice());
            float Vel = this.vRigidbody.velocity.magnitude;
            if (this.target)
            {
                this.Dist = Vector3.Distance(this.thisTransform.position, this.target.position);
                if ((this.Dist < 20) && this.Attacking)
                {
                    this.TargetTooClose = true;
                }
                else
                {
                    this.TargetTooClose = false;
                }
            }
            if (!this.target && this.Attacking)
            {
                this.TargetStill = 0;
                this.Attacking = false;
                this.Spot = false;
                this.Hunting = true;
                this.target = this.Waypoint;
                this.StopAllCoroutines();
            }
            if (this.TurnLeft)
            {
                if (!this.Spot)
                {
                    this.TurnForce = -50;
                }
            }
            if (this.TurnRight)
            {
                if (!this.Spot)
                {
                    this.TurnForce = 50;
                }
            }
            if (this.TurnLeft && this.TurnRight)
            {
                this.TurnForce = -50;
            }
            if (!this.TurnLeft && !this.TurnRight)
            {
                this.TurnForce = 0;
            }
            Vector3 newRot = ((this.thisTransform.forward * 0.6f) + (this.thisTransform.up * 0.1f)).normalized;
            if (Vel > 20)
            {
                newRot = ((this.thisVTransform.up * 0.6f) + (this.thisVTransform.right * -0.4f)).normalized;
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
                if (Vel < 20)
                {
                    if (Vel > 5)
                    {
                        newRot = ((this.thisVTransform.up * 0.6f) + (this.thisVTransform.right * -0.4f)).normalized;
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
                        if (Vel < 5)
                        {
                            newRot = ((this.thisVTransform.up * 0.6f) + (this.thisVTransform.right * -0.4f)).normalized;
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
            if (Vel > 7)
            {
                if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 1), this.thisTransform.forward, Vel))
                {
                    this.Obstacle = true;
                }
                else
                {
                    this.Obstacle = false;
                }
            }
            if (Vel < 7)
            {
                this.Obstacle = false;
                if (this.target != null)
                {
                    if ((this.Dist < 10) && this.target.name.Contains("TC"))
                    {
                        this.Obstacle = true;
                    }
                }
            }
        }
    }

    private Quaternion NewRotation;
    public virtual void FixedUpdate()
    {
        if (!this.DecrepitAberrant)
        {
            //----------------------------------------------------------------------------------------------------------------------
            Vector3 localV = this.thisTransform.InverseTransformDirection(this.GetComponent<Rigidbody>().velocity);
            if (this.Obstacle && !this.Stuck)
            {
                if (localV.z > 0)
                {
                    this.vRigidbody.AddForce(this.thisVTransform.up * -20);
                }
            }
            if (this.TargetTooClose)
            {
                if (-localV.z < 5)
                {
                    this.vRigidbody.AddForce(this.thisVTransform.up * -20);
                }
            }
            if (this.Stuck)
            {
                if (-localV.z < 2)
                {
                    this.vRigidbody.AddForce(this.thisVTransform.up * -20);
                }
            }
            if (this.Attacking)
            {
                this.GyroForce = 0;
            }
            else
            {
                this.GyroForce = -20;
            }
            if ((((!this.Obstacle && !this.Stuck) && !this.TurnLeft) && !this.TurnRight) && !this.TargetTooClose)
            {
                this.vRigidbody.AddForce(this.thisVTransform.up * 5);
            }
            //----------------------------------------------------------------------------------------------------------------------
            this.TurnForce = this.TurnForce + this.HullMovage;
            this.vRigidbody.AddTorque((this.thisVTransform.forward * this.TurnForce) * 1);
            this.vRigidbody.AddForceAtPosition(Vector3.up * this.GyroForce, -this.thisVTransform.forward * 2);
            this.vRigidbody.AddForceAtPosition(-Vector3.up * this.GyroForce, this.thisVTransform.forward * 2);
            if (this.target && !this.DangerSense)
            {
                if (this.TurnLeft || this.TurnRight)
                {
                    this.GetComponent<Rigidbody>().freezeRotation = false;
                    this.GyroForce = -100;
                }
                if (!this.TurnLeft && !this.TurnRight)
                {
                    this.GetComponent<Rigidbody>().freezeRotation = true;
                    this.GyroForce = -20;
                }
                this.NewRotation = Quaternion.LookRotation(this.target.position - this.thisTransform.position);
                this.thisTransform.rotation = Quaternion.RotateTowards(this.thisTransform.rotation, this.NewRotation, Time.deltaTime * 100);
            }
            if (this.DangerSense && (this.DangerDirection != Vector3.zero))
            {
                this.GetComponent<Rigidbody>().freezeRotation = true;
                this.NewRotation = Quaternion.LookRotation(this.DangerDirection);
                this.thisTransform.rotation = Quaternion.RotateTowards(this.thisTransform.rotation, this.NewRotation, Time.deltaTime * 200);
            }
        }
        else
        {
            if (this.target != null)
            {
                this.NewRotation = Quaternion.LookRotation(this.target.position - this.thisTransform.position);
                this.thisTransform.rotation = Quaternion.RotateTowards(this.thisTransform.rotation, this.NewRotation, Time.deltaTime * 25);
            }
        }
    }

    public virtual IEnumerator OnTriggerEnter(Collider other)
    {
        string ON = other.name;
        Transform OT = other.transform;
        if (Physics.Linecast(this.thisTransform.position, OT.position, (int) this.MtargetLayers))
        {
            yield break;
        }
        if (!this.DecrepitAberrant)
        {
            if (ON.Contains("TFC"))
            {
                if (!ON.Contains("TFC4"))
                {
                    if (!this.Attacking)
                    {
                        this.DangerSense = true;
                        if (other.GetComponent<Rigidbody>())
                        {
                            this.DangerDirection = -other.GetComponent<Rigidbody>().velocity.normalized;
                        }
                        this.StartCoroutine(this.Suspicious());
                    }
                }
            }
            if (((ON.Contains("TC") && !ON.Contains("TC4")) && !this.Attacking) && this.Hunting)
            {
                this.Hunting = false;
                this.target = OT;
                this.Waypoint2.transform.position = OT.position;
                yield return new WaitForSeconds(0.1f);
                if (!this.Spot)
                {
                    this.Spot = true;
                    this.StartCoroutine(this.Looking());
                    GameObject TheThing = UnityEngine.Object.Instantiate(this.SpotSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                    TheThing.transform.parent = this.thisTransform;
                }
            }
        }
        else
        {
            if (ON.Contains("TC") && !ON.Contains("TC4"))
            {
                this.target = OT;
                yield return new WaitForSeconds(0.1f);
                if (!this.Spot)
                {
                    this.Spot = true;
                    this.StartCoroutine(this.Looking());
                    GameObject TheThing1 = UnityEngine.Object.Instantiate(this.SpotSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                    TheThing1.transform.parent = this.thisTransform;
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
        if (!this.DecrepitAberrant)
        {
            if (ON.Contains("TFC0a") && !this.PissedAtTC0a)
            {
                this.PissedAtTC0a = true;
            }
            if (ON.Contains("TFC1") && !this.PissedAtTC1)
            {
                this.PissedAtTC1 = true;
            }
            if (ON.Contains("TFC3") && !this.PissedAtTC3)
            {
                this.PissedAtTC3 = true;
            }
            if (ON.Contains("TFC5") && !this.PissedAtTC5)
            {
                this.PissedAtTC5 = true;
            }
            if (ON.Contains("TFC6") && !this.PissedAtTC6)
            {
                this.PissedAtTC6 = true;
            }
            if (ON.Contains("TFC7") && !this.PissedAtTC7)
            {
                this.PissedAtTC7 = true;
            }
            if (ON.Contains("TFC8") && !this.PissedAtTC8)
            {
                this.PissedAtTC8 = true;
            }
            if (ON.Contains("TFC9") && !this.PissedAtTC9)
            {
                this.PissedAtTC9 = true;
            }
            if (ON.Contains("TC2"))
            {
                this.Spot = false;
                this.Hunting = false;
                this.target = OT;
                this.DangerSense = false;
                if (!this.Attacking)
                {
                    GameObject TheThing2 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                    TheThing2.transform.parent = this.thisTransform;
                    this.Attacking = true;
                    this.StopAllCoroutines();
                }
            }
            if (ON.Contains("TC0a") && this.PissedAtTC0a)
            {
                this.Spot = false;
                this.Hunting = false;
                this.target = OT;
                this.DangerSense = false;
                if (!this.Attacking)
                {
                    this.Attacking = true;
                    this.StopAllCoroutines();
                }
            }
            if (ON.Contains("TC1") && this.PissedAtTC1)
            {
                this.Spot = false;
                this.Hunting = false;
                this.target = OT;
                this.DangerSense = false;
                if (!this.Attacking)
                {
                    this.Attacking = true;
                    this.StopAllCoroutines();
                }
            }
            if (ON.Contains("TC3") && this.PissedAtTC3)
            {
                this.Spot = false;
                this.Hunting = false;
                this.target = OT;
                this.DangerSense = false;
                if (!this.Attacking)
                {
                    this.Attacking = true;
                    this.StopAllCoroutines();
                }
            }
            if (ON.Contains("TC5") && this.PissedAtTC5)
            {
                this.Spot = false;
                this.Hunting = false;
                this.target = OT;
                this.DangerSense = false;
                if (!this.Attacking)
                {
                    this.Attacking = true;
                    this.StopAllCoroutines();
                }
            }
            if (ON.Contains("TC6") && this.PissedAtTC6)
            {
                this.Spot = false;
                this.Hunting = false;
                this.target = OT;
                this.DangerSense = false;
                if (!this.Attacking)
                {
                    this.Attacking = true;
                    this.StopAllCoroutines();
                }
            }
            if (ON.Contains("TC7") && this.PissedAtTC7)
            {
                this.Spot = false;
                this.Hunting = false;
                this.target = OT;
                this.DangerSense = false;
                if (!this.Attacking)
                {
                    this.Attacking = true;
                    this.StopAllCoroutines();
                }
            }
            if (ON.Contains("TC8") && this.PissedAtTC8)
            {
                this.Spot = false;
                this.Hunting = false;
                this.target = OT;
                this.DangerSense = false;
                if (!this.Attacking)
                {
                    this.Attacking = true;
                    this.StopAllCoroutines();
                }
            }
            if (ON.Contains("TC9") && this.PissedAtTC9)
            {
                this.Spot = false;
                this.Hunting = false;
                this.target = OT;
                this.DangerSense = false;
                if (!this.Attacking)
                {
                    this.Attacking = true;
                    this.StopAllCoroutines();
                }
            }
        }
    }

    public virtual IEnumerator Looking()
    {
        yield return new WaitForSeconds(30);
        if (this.Attacking == false)
        {
            this.Spot = false;
            GameObject TheThing = UnityEngine.Object.Instantiate(this.RejectSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
            TheThing.transform.parent = this.thisTransform;
            this.Targety();
        }
    }

    public virtual void Shooty()
    {
        if (!this.DecrepitAberrant)
        {
            if (this.Attacking && (this.JustNoticed > 0))
            {
                this.StartCoroutine(this.Shoot());
            }
        }
    }

    public virtual IEnumerator Shoot()
    {
        if (this.AberrantGun1 != null)
        {
            this.AberrantGun1.Fire();
        }
        yield return new WaitForSeconds(0.1f);
        if (this.AberrantGun2 != null)
        {
            this.AberrantGun2.Fire();
        }
    }

    public virtual void Targety()
    {
        if (!this.DecrepitAberrant)
        {
            if ((this.Spot == false) && (this.Attacking == false))
            {
                this.StartCoroutine(this.TargetArea());
            }
        }
    }

    public virtual IEnumerator TargetArea()
    {
        this.Hunting = false;
        this.target = this.Waypoint2;
        yield return new WaitForSeconds(5);
        this.target = this.Waypoint;
        this.Hunting = true;
    }

    public virtual IEnumerator Suspicious()
    {
        yield return new WaitForSeconds(60);
        this.target = this.Waypoint;
        this.DangerSense = false;
    }

    public virtual IEnumerator ManeuverHull()
    {
        this.HullMovage = -this.AttackManeuverCurve.Evaluate(this.Dist);
        if (this.isGunnerAberrant)
        {
            yield return new WaitForSeconds(0.5f);
            this.HullMovage = this.AttackManeuverCurve.Evaluate(this.Dist);
        }
    }

    public virtual IEnumerator Reset()
    {
        this.TargetIsMoving = false;
        if (this.target.name.Contains("TC0a"))
        {
            this.PissedAtTC0a = false;
        }
        if (this.target.name.Contains("TC1"))
        {
            this.PissedAtTC1 = false;
        }
        if (this.target.name.Contains("TC3"))
        {
            this.PissedAtTC3 = false;
        }
        if (this.target.name.Contains("TC5"))
        {
            this.PissedAtTC5 = false;
        }
        if (this.target.name.Contains("TC6"))
        {
            this.PissedAtTC6 = false;
        }
        if (this.target.name.Contains("TC7"))
        {
            this.PissedAtTC7 = false;
        }
        if (this.target.name.Contains("TC8"))
        {
            this.PissedAtTC8 = false;
        }
        if (this.target.name.Contains("TC9"))
        {
            this.PissedAtTC9 = false;
        }
        this.TargetStill = 0;
        this.Attacking = false;
        yield return new WaitForSeconds(10);
        this.Spot = false;
        this.Hunting = true;
        this.target = this.Waypoint;
        this.StopAllCoroutines();
    }

    public virtual void Warning()
    {
        if (this.Hunting == true)
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

    public virtual IEnumerator Notice()
    {
        if (this.Tick)
        {
            yield break;
        }
        this.Tick = true;
        if (this.target != null)
        {
            if (!this.TargetIsMoving && (this.Dist < 30))
            {
                this.TargetStill = this.TargetStill + 1;
                if (this.TargetStill > 20)
                {
                    this.StartCoroutine(this.Reset());
                }
            }
            Vector3 lastPos = this.target.transform.position;
            yield return new WaitForSeconds(0.2f);
            if (this.target != null)
            {
                if (Vector3.Distance(this.target.position, lastPos) > 0.2f)
                {
                    this.TargetIsMoving = true;
                    this.TargetStill = 0;
                }
            }
            yield return new WaitForSeconds(0.2f);
            this.TargetIsMoving = false;
        }
        this.Tick = false;
    }

    public virtual void Regenerator()
    {
        if (!this.DecrepitAberrant)
        {
            if (this.Attacking)
            {
                if (this.Trig.isTrigger)
                {
                    this.Trig.center = new Vector3(0, 0, 0);
                    this.Trig.radius = 20;
                    this.Trig.height = 20;
                }
                if (this.target != null)
                {
                    if (!Physics.Linecast(this.thisTransform.position, this.target.position, (int) this.targetLayers))
                    {
                        this.TurnRight = false;
                        this.TurnLeft = false;
                        this.JustNoticed = 3;
                    }
                }
                if (this.Dist > 320)
                {
                    this.Attacking = false;
                    this.Spot = false;
                }
                this.StartCoroutine(this.ManeuverHull());
            }
            else
            {
                if (this.Trig.isTrigger)
                {
                    this.Trig.center = new Vector3(0, 0, 100);
                    this.Trig.radius = 50;
                    this.Trig.height = 300;
                }
                if (this.target)
                {
                    Vector3 TargetPos = this.target.position;
                    if (Vector3.Distance(this.thisTransform.position, TargetPos) < 30)
                    {
                        if (!this.Attacking && this.Spot)
                        {
                            if (this.TargetIsMoving)
                            {
                                this.Attacking = true;
                                this.Spot = false;
                                this.Hunting = false;
                                GameObject TheThing3 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                                TheThing3.transform.parent = this.thisTransform;
                                this.StopAllCoroutines();
                            }
                        }
                    }
                }
                this.HullMovage = 0;
            }
            if (this.JustNoticed > 0)
            {
                this.JustNoticed = this.JustNoticed - 1;
            }
            this.Tick = false;
        }
    }

    public AberrantAI()
    {
        this.Spot = true;
        this.AttackManeuverCurve = new AnimationCurve();
        this.TurnForce = 1;
        this.GyroForce = 1;
        this.ShootFrequency = 5;
        this.UniqueShootTime = 0.1f;
    }

}