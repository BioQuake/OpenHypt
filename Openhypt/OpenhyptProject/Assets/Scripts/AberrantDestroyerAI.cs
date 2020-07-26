using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AberrantDestroyerAI : MonoBehaviour
{
    public Transform target;
    public Transform Waypoint;
    public Transform Waypoint2;
    public NPCGun AberrantGun1;
    public NPCGun AberrantTurretGun1;
    public BigVesselRotator Rotator;
    public CapsuleCollider Trig;
    public bool IsMercenary;
    public int DroneCounter;
    public GameObject DronePrefab;
    public Transform DroneArea;
    public AudioSource DroneAreaAudio;
    public GameObject AberrantPresence;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public GameObject HuntingSound;
    public GameObject SpotSound;
    public GameObject AttackSound;
    public GameObject RejectSound;
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
    public bool FoundBig;
    public bool FoundSmall;
    public bool SlowingDown;
    public bool TurnRight;
    public bool TurnLeft;
    public float TurnForce;
    public bool DangerSense;
    public Vector3 DangerDirection;
    public LayerMask targetLayers;
    public LayerMask MtargetLayers;
    public int JustNoticed;
    public int Suspicion;
    public int TargetStill;
    public float ShootFrequency;
    public bool Tick;
    public virtual IEnumerator Start()
    {
        this.InvokeRepeating("Regenerator", 1, 1);
        this.InvokeRepeating("Bothered", 1, 0.3f);
        this.InvokeRepeating("LeaveMarker", 1, 3);
        this.InvokeRepeating("Warning", 1, Random.Range(29, 31));
        this.InvokeRepeating("Targety", 300, 300);
        this.InvokeRepeating("Shooty", 1, this.ShootFrequency);
        if (!this.IsMercenary)
        {
            yield return new WaitForSeconds(5);
            GameObject IssuedDrone = UnityEngine.Object.Instantiate(this.DronePrefab, this.DroneArea.position, this.DroneArea.rotation);
            IssuedDrone.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
            IssuedDrone.GetComponent<Rigidbody>().velocity = this.DroneArea.transform.up * -40;
            this.DroneAreaAudio.Play();
        }
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        this.StartCoroutine(this.Notice());
        if (this.target)
        {
            if ((Vector3.Distance(this.thisTransform.position, this.target.position) > 210) && this.Attacking)
            {
                this.StartCoroutine(this.FarFromEnemy());
            }
        }
        if ((this.target == null) && (this.Attacking == true))
        {
            this.TargetStill = 0;
            this.FoundBig = false;
            this.Attacking = false;
            this.Spot = false;
            this.Hunting = true;
            this.target = this.Waypoint;
            this.StopAllCoroutines();
        }
        if (this.target != null)
        {
            if (this.target.name.Contains("Forward") && (this.Attacking == true))
            {
                this.Attacking = false;
                this.Spot = false;
                this.Hunting = true;
                this.target = this.Waypoint;
                this.StopAllCoroutines();
            }
        }
        if (this.TurnLeft)
        {
            if (this.target != null)
            {
                this.TurnForce = -400;
            }
        }
        if (this.TurnRight)
        {
            if (this.target != null)
            {
                this.TurnForce = 400;
            }
        }
        if (!this.TurnRight && !this.TurnLeft)
        {
            this.TurnForce = 0;
        }
        if (this.TurnRight && this.TurnLeft)
        {
            this.TurnForce = 0;
        }
        Vector3 newRot = (this.thisTransform.forward * 0.6f).normalized;
        //-------------------------------------------------------------------------------------------------------------
        if (this.vRigidbody.velocity.magnitude > 20)
        {
            newRot = ((this.thisVTransform.up * 0.6f) + (this.thisVTransform.right * -0.4f)).normalized;
            Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 15), newRot * 100f, Color.black);
            if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 15), newRot, 100))
            {
                this.TurnLeft = true;
            }
            else
            {
                this.TurnLeft = false;
            }
            newRot = ((this.thisVTransform.up * 0.6f) + (this.thisVTransform.right * 0.4f)).normalized;
            Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 15), newRot * 100f, Color.black);
            if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 15), newRot, 100))
            {
                this.TurnRight = true;
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
                    newRot = ((this.thisVTransform.up * 0.6f) + (this.thisVTransform.right * -0.4f)).normalized;
                    Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 15), newRot * 30f, Color.black);
                    if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 15), newRot, 30))
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
                    Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 15), newRot * 30f, Color.black);
                    if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 15), newRot, 30))
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
                        newRot = ((this.thisVTransform.up * 0.6f) + (this.thisVTransform.right * -0.4f)).normalized;
                        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 15), newRot * 15f, Color.black);
                        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 15), newRot, 15))
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
                        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 15), newRot * 15f, Color.black);
                        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 15), newRot, 15))
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
        //-------------------------------------------------------------------------------------------------------------
        if (this.vRigidbody.velocity.magnitude > 10)
        {
            if (this.vRigidbody.velocity.magnitude < 50)
            {
                Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 15), this.thisTransform.forward * 50f, Color.green);
                if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 15), this.thisTransform.forward, 50))
                {
                    this.Obstacle = true;
                }
                else
                {
                    this.Obstacle = false;
                }
            }
            if (this.vRigidbody.velocity.magnitude > 50)
            {
                Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 15), this.thisTransform.forward * 80f, Color.green);
                if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 15), this.thisTransform.forward, 80))
                {
                    this.Obstacle = true;
                }
                else
                {
                    this.Obstacle = false;
                }
            }
        }
    }

    private Quaternion NewRotation;
    public virtual void FixedUpdate()
    {
        //----------------------------------------------------------------------------------------------------------------------
        Vector3 localV = this.thisTransform.InverseTransformDirection(this.GetComponent<Rigidbody>().velocity);
        if (this.SlowingDown && !this.Attacking)
        {
            this.vRigidbody.AddForce(this.thisVTransform.up * 0);
        }
        if (this.Obstacle)
        {
            if (localV.z > 10)
            {
                this.vRigidbody.AddForce(this.thisVTransform.up * -60);
            }
        }
        if (this.Stuck)
        {
            if (-localV.z < 4)
            {
                this.vRigidbody.AddForce(this.thisVTransform.up * -60);
            }
        }
        if ((((!this.Obstacle && !this.Stuck) && !this.SlowingDown) && !this.TurnLeft) && !this.TurnRight)
        {
            this.vRigidbody.AddForce(this.thisVTransform.up * 20);
        }
        //----------------------------------------------------------------------------------------------------------------------
        this.vRigidbody.AddTorque((this.thisVTransform.forward * this.TurnForce) * 5);
        this.vRigidbody.AddForceAtPosition(Vector3.up * -32, -this.thisVTransform.forward * 16);
        this.vRigidbody.AddForceAtPosition(-Vector3.up * -32, this.thisVTransform.forward * 16);
        if (this.target && !this.DangerSense)
        {
            this.NewRotation = Quaternion.LookRotation(this.target.position - this.thisTransform.position);
            this.thisTransform.rotation = Quaternion.RotateTowards(this.thisTransform.rotation, this.NewRotation, Time.deltaTime * 60);
        }
        if (this.DangerSense && (this.DangerDirection != Vector3.zero))
        {
            this.NewRotation = Quaternion.LookRotation(this.DangerDirection);
            this.thisTransform.rotation = Quaternion.RotateTowards(this.thisTransform.rotation, this.NewRotation, Time.deltaTime * 60);
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
        if (!this.Attacking && this.Hunting)
        {
            if (ON.Contains("TC") && !ON.Contains("TC4"))
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
    }

    public virtual void OnTriggerStay(Collider other)
    {
        string ON = other.name;
        Transform OT = other.transform;
        if (Physics.Linecast(this.thisTransform.position, OT.position, (int) this.MtargetLayers))
        {
            return;
        }
        if (ON.Contains("TFC0a"))
        {
            this.PissedAtTC0a = true;
        }
        if (ON.Contains("TFC1"))
        {
            this.PissedAtTC1 = true;
        }
        if (ON.Contains("TFC3"))
        {
            this.PissedAtTC3 = true;
        }
        if (ON.Contains("TFC5"))
        {
            this.PissedAtTC5 = true;
        }
        if (ON.Contains("TFC6"))
        {
            this.PissedAtTC6 = true;
        }
        if (ON.Contains("TFC7"))
        {
            this.PissedAtTC7 = true;
        }
        if (ON.Contains("TFC8"))
        {
            this.PissedAtTC8 = true;
        }
        if (ON.Contains("TFC9"))
        {
            this.PissedAtTC9 = true;
        }
        if ((ON.Contains("TC0a") && this.PissedAtTC0a) && !this.FoundBig)
        {
            this.Spot = false;
            this.Hunting = false;
            this.target = OT;
            if (!this.Attacking)
            {
                this.DangerSense = false;
                this.Attacking = true;
                this.StopAllCoroutines();
            }
        }
        if (ON.Contains("TC2"))
        {
            this.Spot = false;
            this.Hunting = false;
            this.target = OT;
            if (!this.Attacking)
            {
                this.DangerSense = false;
                GameObject TheThing2 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                TheThing2.transform.parent = this.thisTransform;
                this.Attacking = true;
                this.StopAllCoroutines();
            }
        }
        if ((ON.Contains("mTC1") && this.PissedAtTC1) && !this.FoundBig)
        {
            this.Spot = false;
            this.Hunting = false;
            this.target = OT;
            if (!this.Attacking)
            {
                this.DangerSense = false;
                this.Attacking = true;
                this.StopAllCoroutines();
            }
        }
        if (((ON.Contains("sTC1") && this.PissedAtTC1) && !this.FoundBig) && !this.FoundSmall)
        {
            this.FoundSmall = true;
            this.Spot = false;
            this.Hunting = false;
            this.target = OT;
            if (!this.Attacking)
            {
                this.DangerSense = false;
                this.Attacking = true;
                this.StopAllCoroutines();
            }
        }
        if ((ON.Contains("TC3") && this.PissedAtTC3) && !this.FoundBig)
        {
            this.Spot = false;
            this.Hunting = false;
            this.target = OT;
            if (!this.Attacking)
            {
                this.DangerSense = false;
                this.Attacking = true;
                this.StopAllCoroutines();
            }
        }
        if ((ON.Contains("mTC5") && this.PissedAtTC5) && !this.FoundBig)
        {
            this.Spot = false;
            this.Hunting = false;
            this.target = OT;
            if (!this.Attacking)
            {
                this.DangerSense = false;
                this.Attacking = true;
                this.StopAllCoroutines();
            }
        }
        if (((ON.Contains("sTC5") && this.PissedAtTC5) && !this.FoundBig) && !this.FoundSmall)
        {
            this.FoundSmall = true;
            this.Spot = false;
            this.Hunting = false;
            this.target = OT;
            if (!this.Attacking)
            {
                this.DangerSense = false;
                this.Attacking = true;
                this.StopAllCoroutines();
            }
        }
        if ((ON.Contains("mTC6") && this.PissedAtTC6) && !this.FoundBig)
        {
            this.Spot = false;
            this.Hunting = false;
            this.target = OT;
            if (!this.Attacking)
            {
                this.DangerSense = false;
                this.Attacking = true;
                this.StopAllCoroutines();
            }
        }
        if (((ON.Contains("sTC6") && this.PissedAtTC6) && !this.FoundBig) && !this.FoundSmall)
        {
            this.FoundSmall = true;
            this.Spot = false;
            this.Hunting = false;
            this.target = OT;
            if (!this.Attacking)
            {
                this.DangerSense = false;
                this.Attacking = true;
                this.StopAllCoroutines();
            }
        }
        if (((ON.Contains("sTC7") && this.PissedAtTC7) && !this.FoundBig) && !this.FoundSmall)
        {
            this.FoundSmall = true;
            this.Spot = false;
            this.Hunting = false;
            this.target = OT;
            if (!this.Attacking)
            {
                this.DangerSense = false;
                this.Attacking = true;
                this.StopAllCoroutines();
            }
        }
        if ((ON.Contains("mTC7") && this.PissedAtTC7) && !this.FoundBig)
        {
            this.Spot = false;
            this.Hunting = false;
            this.target = OT;
            if (!this.Attacking)
            {
                this.DangerSense = false;
                this.Attacking = true;
                this.StopAllCoroutines();
            }
        }
        if (ON.Contains("bTC7") && this.PissedAtTC7)
        {
            this.FoundBig = true;
            this.Spot = false;
            this.Hunting = false;
            this.target = OT;
            if (!this.Attacking)
            {
                this.DangerSense = false;
                this.Attacking = true;
                this.StopAllCoroutines();
            }
        }
        if (((ON.Contains("sTC8") && this.PissedAtTC8) && !this.FoundBig) && !this.FoundSmall)
        {
            this.FoundSmall = true;
            this.Spot = false;
            this.Hunting = false;
            this.target = OT;
            if (!this.Attacking)
            {
                this.DangerSense = false;
                this.Attacking = true;
                this.StopAllCoroutines();
            }
        }
        if ((ON.Contains("mTC8") && this.PissedAtTC8) && !this.FoundBig)
        {
            this.Spot = false;
            this.Hunting = false;
            this.target = OT;
            if (!this.Attacking)
            {
                this.DangerSense = false;
                this.Attacking = true;
                this.StopAllCoroutines();
            }
        }
        if (ON.Contains("bTC8") && this.PissedAtTC8)
        {
            this.FoundBig = true;
            this.Spot = false;
            this.Hunting = false;
            this.target = OT;
            if (!this.Attacking)
            {
                this.DangerSense = false;
                this.Attacking = true;
                this.StopAllCoroutines();
            }
        }
        if (((ON.Contains("sTC9") && this.PissedAtTC9) && !this.FoundBig) && !this.FoundSmall)
        {
            this.FoundSmall = true;
            this.Spot = false;
            this.Hunting = false;
            this.target = OT;
            if (!this.Attacking)
            {
                this.DangerSense = false;
                this.Attacking = true;
                this.StopAllCoroutines();
            }
        }
        if ((ON.Contains("mTC9") && this.PissedAtTC9) && !this.FoundBig)
        {
            this.Spot = false;
            this.Hunting = false;
            this.target = OT;
            if (!this.Attacking)
            {
                this.DangerSense = false;
                this.Attacking = true;
                this.StopAllCoroutines();
            }
        }
        if (ON.Contains("bTC9") && this.PissedAtTC9)
        {
            this.FoundBig = true;
            this.Spot = false;
            this.Hunting = false;
            this.target = OT;
            if (!this.Attacking)
            {
                this.DangerSense = false;
                this.Attacking = true;
                this.StopAllCoroutines();
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

    public virtual IEnumerator FarFromEnemy()
    {
        yield return new WaitForSeconds(60);
        this.Attacking = false;
        this.Spot = false;
        this.target = this.Waypoint;
        yield return new WaitForSeconds(2);
        this.Hunting = true;
    }

    public virtual IEnumerator Shoot()
    {
        float Interval = Random.Range(0.1f, 0.3f);
        yield return new WaitForSeconds(Interval);
        if (this.AberrantGun1 != null)
        {
            this.AberrantGun1.Fire();
        }
        if (this.AberrantTurretGun1 != null)
        {
            this.AberrantTurretGun1.Fire();
        }
    }

    public virtual void Shooty()
    {
        if (this.Attacking)
        {
            this.StartCoroutine(this.Shoot());
        }
    }

    public virtual void Targety()
    {
        if ((this.Spot == false) && (this.Attacking == false))
        {
            this.StartCoroutine(this.TargetArea());
        }
    }

    public virtual IEnumerator TargetArea()
    {
        this.Hunting = false;
        this.target = this.Waypoint2;
        yield return new WaitForSeconds(10);
        this.target = this.Waypoint;
        this.Hunting = true;
    }

    public virtual IEnumerator Suspicious()
    {
        yield return new WaitForSeconds(60);
        this.target = this.Waypoint;
        this.DangerSense = false;
    }

    public virtual void Bothered()
    {
        if (this.target)
        {
            Vector3 TargetPos = this.target.position;

            if (Vector3.Distance(this.thisTransform.position, TargetPos) < 50)
            {
                if (!this.Attacking)
                {
                    if (this.TargetIsMoving)
                    {
                        this.Attacking = true;
                        this.Spot = false;
                        this.Hunting = false;
                        if (this.target.name.Contains("TC0a"))
                        {
                            this.PissedAtTC0a = true;
                        }
                        if (this.target.name.Contains("TC1"))
                        {
                            this.PissedAtTC1 = true;
                        }
                        if (this.target.name.Contains("TC3"))
                        {
                            this.PissedAtTC3 = true;
                        }
                        if (this.target.name.Contains("TC5"))
                        {
                            this.PissedAtTC5 = true;
                        }
                        if (this.target.name.Contains("TC6"))
                        {
                            this.PissedAtTC6 = true;
                        }
                        if (this.target.name.Contains("TC7"))
                        {
                            this.PissedAtTC7 = true;
                        }
                        if (this.target.name.Contains("TC8"))
                        {
                            this.PissedAtTC8 = true;
                        }
                        if (this.target.name.Contains("TC9"))
                        {
                            this.PissedAtTC9 = true;
                        }
                        this.StopAllCoroutines();
                    }
                }
            }
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
        this.FoundBig = false;
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
        yield return new WaitForSeconds(1);
        if (Vector3.Distance(this.thisTransform.position, lastPos) < 0.5f)
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
            if (!this.TargetIsMoving && (Vector3.Distance(this.thisTransform.position, this.target.position) < 50))
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
                if (Vector3.Distance(this.target.transform.position, lastPos) > 0.2f)
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
        this.Obstacle = false;
        if (this.Attacking)
        {
            this.Trig.center = new Vector3(0, 0, 0);
            this.Trig.radius = 40;
            this.Trig.height = 40;
            if (this.target != null)
            {
                if (!Physics.Linecast(this.thisTransform.position, this.target.position, (int) this.targetLayers))
                {
                    this.TurnRight = false;
                    this.TurnLeft = false;
                    this.JustNoticed = 2;
                }
            }
        }
        else
        {
            this.Trig.center = new Vector3(0, 0, 100);
            this.Trig.radius = 100;
            this.Trig.height = 300;
        }
        if (this.JustNoticed > 0)
        {
            this.JustNoticed = this.JustNoticed - 1;
        }
        this.Tick = false;
        if (!this.Attacking)
        {
            this.FoundSmall = false;
        }
        if (this.DroneCounter > 0)
        {
            this.DroneCounter = this.DroneCounter - 1;
        }
        if (((this.DroneCounter < 1) && this.Attacking) && !this.IsMercenary)
        {
            this.DroneCounter = 10;
            GameObject IssuedDrone = UnityEngine.Object.Instantiate(this.DronePrefab, this.DroneArea.position, this.DroneArea.rotation);
            IssuedDrone.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
            IssuedDrone.GetComponent<Rigidbody>().velocity = this.DroneArea.transform.up * -20;
            ((AgrianMiniBotAI) IssuedDrone.transform.GetChild(0).GetComponent(typeof(AgrianMiniBotAI))).target = this.target;
            ((AgrianMiniBotAI) IssuedDrone.transform.GetChild(0).GetComponent(typeof(AgrianMiniBotAI))).Attacking = true;
            if (this.PissedAtTC0a)
            {
                ((AgrianMiniBotAI) IssuedDrone.transform.GetChild(0).GetComponent(typeof(AgrianMiniBotAI))).PissedAtTC0a = 8;
            }
            if (this.PissedAtTC1)
            {
                ((AgrianMiniBotAI) IssuedDrone.transform.GetChild(0).GetComponent(typeof(AgrianMiniBotAI))).PissedAtTC1 = 8;
            }
            if (this.PissedAtTC3)
            {
                ((AgrianMiniBotAI) IssuedDrone.transform.GetChild(0).GetComponent(typeof(AgrianMiniBotAI))).PissedAtTC3 = 8;
            }
            if (this.PissedAtTC5)
            {
                ((AgrianMiniBotAI) IssuedDrone.transform.GetChild(0).GetComponent(typeof(AgrianMiniBotAI))).PissedAtTC5 = 8;
            }
            if (this.PissedAtTC6)
            {
                ((AgrianMiniBotAI) IssuedDrone.transform.GetChild(0).GetComponent(typeof(AgrianMiniBotAI))).PissedAtTC6 = 8;
            }
            if (this.PissedAtTC7)
            {
                ((AgrianMiniBotAI) IssuedDrone.transform.GetChild(0).GetComponent(typeof(AgrianMiniBotAI))).PissedAtTC7 = 8;
            }
            if (this.PissedAtTC8)
            {
                ((AgrianMiniBotAI) IssuedDrone.transform.GetChild(0).GetComponent(typeof(AgrianMiniBotAI))).PissedAtTC8 = 8;
            }
            if (this.PissedAtTC9)
            {
                ((AgrianMiniBotAI) IssuedDrone.transform.GetChild(0).GetComponent(typeof(AgrianMiniBotAI))).PissedAtTC9 = 8;
            }
            this.DroneAreaAudio.Play();
        }
    }

    public AberrantDestroyerAI()
    {
        this.Spot = true;
        this.TurnForce = 1;
        this.ShootFrequency = 5;
    }

}