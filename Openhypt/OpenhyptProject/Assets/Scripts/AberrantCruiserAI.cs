using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AberrantCruiserAI : MonoBehaviour
{
    public Transform target;
    public Transform Waypoint;
    public Transform Waypoint2;
    public GameObject AberrantThruster;
    public GameObject AberrantThruster2;
    public GameObject AberrantGyro;
    public BigVesselRotator AberrantRotator;
    public SphereCollider Trig;
    public GameObject Hoverer1;
    public GameObject Hoverer2;
    public NPCGun Turret1;
    public NPCGun Turret2;
    public NPCGun Turret3;
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
    public int T1Force;
    public int T2Force;
    public bool FoundBig;
    public bool FoundSmall;
    public bool TurnRight;
    public bool TurnLeft;
    public bool DangerSense;
    public Vector3 DangerDirection;
    public LayerMask MtargetLayers;
    public bool Tick;
    public float ShootFrequency;
    public bool Damaged;
    public virtual IEnumerator Start()
    {
        this.InvokeRepeating("Regenerator", 1, 1);
        this.InvokeRepeating("LeaveMarker", 1, 10);
        this.InvokeRepeating("Warning", 1, Random.Range(50, 60));
        this.InvokeRepeating("Targety", 300, 300);
        this.InvokeRepeating("Shooty", 1, this.ShootFrequency);
        yield return new WaitForSeconds(5);
        GameObject IssuedDrone = UnityEngine.Object.Instantiate(this.DronePrefab, this.DroneArea.position, this.DroneArea.rotation);
        IssuedDrone.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
        IssuedDrone.GetComponent<Rigidbody>().velocity = this.DroneArea.transform.up * -20;
        this.DroneAreaAudio.Play();
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        if ((this.target == null) && this.Attacking)
        {
            this.FoundBig = false;
            this.Attacking = false;
            this.Spot = false;
            this.Hunting = true;
            this.target = this.Waypoint;
            this.StopAllCoroutines();
        }
        if (this.Damaged)
        {
            return;
        }
        this.StartCoroutine(this.Notice());
        if (this.target != null)
        {
            if (this.target.name.Contains("Forward") && this.Attacking)
            {
                this.Attacking = false;
                this.Spot = false;
                this.Hunting = true;
                this.target = this.Waypoint;
                this.StopAllCoroutines();
            }
        }
        Vector3 newRot = (this.thisVTransform.up * 0.6f).normalized;
        Vector3 localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
        if (localV.y > 20)
        {
            newRot = ((this.thisVTransform.up * 0.6f) + (-this.thisVTransform.right * 0.1f)).normalized;
            Debug.DrawRay((this.thisVTransform.position + this.thisVTransform.up) + (-this.thisVTransform.right * 12), newRot * 150f, Color.black);
            if (Physics.Raycast((this.thisVTransform.position + this.thisVTransform.up) + (-this.thisVTransform.right * 12), newRot, 150))
            {
                this.TurnLeft = true;
            }
            else
            {
                this.TurnLeft = false;
            }
            newRot = ((this.thisVTransform.up * 0.6f) + (-this.thisVTransform.right * -0.1f)).normalized;
            Debug.DrawRay((this.thisVTransform.position + this.thisVTransform.up) + (this.thisVTransform.right * 12), newRot * 150f, Color.black);
            if (Physics.Raycast((this.thisVTransform.position + this.thisVTransform.up) + (this.thisVTransform.right * 12), newRot, 150))
            {
                this.TurnRight = true;
            }
            else
            {
                this.TurnRight = false;
            }
            Debug.DrawRay(this.thisVTransform.position + (this.thisVTransform.up * 45), this.thisVTransform.up * 100f, Color.green);
            if (Physics.Raycast(this.thisVTransform.position + (this.thisVTransform.up * 45), this.thisVTransform.up, 100))
            {
                this.Obstacle = true;
            }
            else
            {
                this.Obstacle = false;
            }
        }
        else
        {
            newRot = ((this.thisVTransform.up * 0.6f) + (-this.thisVTransform.right * 0.2f)).normalized;
            Debug.DrawRay((this.thisVTransform.position + this.thisVTransform.up) + (-this.thisVTransform.right * 12), newRot * 80f, Color.black);
            if (Physics.Raycast((this.thisVTransform.position + this.thisVTransform.up) + (-this.thisVTransform.right * 12), newRot, 80))
            {
                this.TurnLeft = true;
            }
            else
            {
                this.TurnLeft = false;
            }
            newRot = ((this.thisVTransform.up * 0.6f) + (-this.thisVTransform.right * -0.2f)).normalized;
            Debug.DrawRay((this.thisVTransform.position + this.thisVTransform.up) + (this.thisVTransform.right * 12), newRot * 80f, Color.black);
            if (Physics.Raycast((this.thisVTransform.position + this.thisVTransform.up) + (this.thisVTransform.right * 12), newRot, 80))
            {
                this.TurnRight = true;
            }
            else
            {
                this.TurnRight = false;
            }
            if (localV.y > 5)
            {
                Debug.DrawRay(this.thisVTransform.position + (this.thisVTransform.up * 45), this.thisVTransform.up * 50f, Color.green);
                if (Physics.Raycast(this.thisVTransform.position + (this.thisVTransform.up * 45), this.thisVTransform.up, 50))
                {
                    this.Obstacle = true;
                }
                else
                {
                    this.Obstacle = false;
                }
            }
            else
            {
                this.Obstacle = false;
            }
        }
        if (-localV.y > 5)
        {
            this.Stuck = false;
        }
        if (this.Obstacle)
        {
            this.T1Force = -200;
            this.T2Force = -200;
        }
        if (this.TurnLeft && !this.TurnRight)
        {
            this.T1Force = -200;
            this.T2Force = 200;
        }
        if (this.TurnRight && !this.TurnLeft)
        {
            this.T1Force = 200;
            this.T2Force = -200;
        }
        if (this.TurnRight && this.TurnLeft)
        {
            this.T1Force = -200;
            this.T1Force = 200;
        }
        if (this.Stuck)
        {
            this.T1Force = -200;
            this.T2Force = -200;
        }
        if (((!this.TurnLeft && !this.TurnRight) && !this.Obstacle) && !this.Stuck)
        {
            this.T1Force = 150;
            this.T2Force = 150;
        }
    }

    private Quaternion NewRotation;
    public virtual void FixedUpdate()
    {
        //----------------------------------------------------------------------------------------------------------------------
        this.AberrantThruster.GetComponent<Rigidbody>().AddForce(this.AberrantThruster.transform.up * this.T1Force);
        this.AberrantThruster2.GetComponent<Rigidbody>().AddForce(this.AberrantThruster2.transform.up * this.T2Force);
        //----------------------------------------------------------------------------------------------------------------------
        if (this.target && !this.DangerSense)
        {
            this.NewRotation = Quaternion.LookRotation(this.target.position - this.thisTransform.position);
            this.thisTransform.rotation = Quaternion.RotateTowards(this.thisTransform.rotation, this.NewRotation, Time.deltaTime * 50);
        }
        if (this.DangerSense && (this.DangerDirection != Vector3.zero))
        {
            this.NewRotation = Quaternion.LookRotation(this.DangerDirection);
            this.thisTransform.rotation = Quaternion.RotateTowards(this.thisTransform.rotation, this.NewRotation, Time.deltaTime * 50);
        }
        if (this.Damaged)
        {
            UnityEngine.Object.Destroy(this.AberrantRotator);
            UnityEngine.Object.Destroy(this.AberrantPresence);
            UnityEngine.Object.Destroy(this.AberrantGyro);
            UnityEngine.Object.Destroy(this.Hoverer1);
            UnityEngine.Object.Destroy(this.Hoverer2);
            UnityEngine.Object.Destroy(this);
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
        if ((((ON.Contains("TC") && !ON.Contains("TC4")) && !this.Attacking) && !this.Damaged) && this.Hunting)
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

    public virtual void OnTriggerStay(Collider other)
    {
        string ON = other.name;
        Transform OT = other.transform;
        if (Physics.Linecast(this.thisTransform.position, OT.position, (int) this.MtargetLayers))
        {
            return;
        }
        if (!this.Damaged)
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
            if (this.PissedAtTC0a && !this.FoundBig)
            {
                if (ON.Contains("TC0a"))
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
            if (this.PissedAtTC1 && !this.FoundBig)
            {
                if (ON.Contains("mTC1") || ON.Contains("bTC1"))
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
            if (ON.Contains("bTC6") && this.PissedAtTC6)
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
    }

    public virtual IEnumerator Looking()
    {
        yield return new WaitForSeconds(30);
        if ((this.Hunting == false) && (this.Attacking == false))
        {
            this.Spot = false;
            GameObject TheThing = UnityEngine.Object.Instantiate(this.RejectSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
            TheThing.transform.parent = this.thisTransform;
            this.Targety();
        }
    }

    public virtual IEnumerator Shoot()
    {
        if (this.Attacking == true)
        {
            if (this.Turret1 != null)
            {
                this.Turret1.Fire();
            }
            yield return new WaitForSeconds(0.4f);
            if (this.Turret2 != null)
            {
                this.Turret2.Fire();
            }
            yield return new WaitForSeconds(0.4f);
            if (this.Turret3 != null)
            {
                this.Turret3.Fire();
            }
        }
    }

    public virtual void Shooty()
    {
        if (this.Attacking == true)
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
        this.Spot = false;
        this.target = this.Waypoint2;
        yield return new WaitForSeconds(20);
        this.target = this.Waypoint;
        this.Spot = false;
        this.Hunting = true;
    }

    public virtual IEnumerator Suspicious()
    {
        yield return new WaitForSeconds(60);
        this.target = this.Waypoint;
        this.DangerSense = false;
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
            Vector3 lastPos = this.target.transform.position;
            yield return new WaitForSeconds(0.2f);
            if (this.target != null)
            {
                if (Vector3.Distance(this.target.transform.position, lastPos) > 0.2f)
                {
                    this.TargetIsMoving = true;
                }
            }
            yield return new WaitForSeconds(0.2f);
            this.TargetIsMoving = false;
        }
        this.Tick = false;
    }

    public virtual void Regenerator()
    {
        this.Tick = false;
        if (this.Attacking)
        {
            this.Trig.center = new Vector3(0, 0, 10);
            this.Trig.radius = 75;
        }
        else
        {
            this.Trig.center = new Vector3(0, 0, 100);
            this.Trig.radius = 150;
            this.FoundSmall = false;
        }
        if (this.DroneCounter > 0)
        {
            this.DroneCounter = this.DroneCounter - 1;
        }
        if ((this.DroneCounter < 1) && this.Attacking)
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
        if (this.target)
        {
            Vector3 TargetPos = this.target.position;
            if (Vector3.Distance(this.thisTransform.position, TargetPos) < 200)
            {
                if (!this.Attacking)
                {
                    if (this.TargetIsMoving)
                    {
                        this.DangerSense = false;
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
            if (Vector3.Distance(this.thisTransform.position, this.target.position) > 1000)
            {
                this.Attacking = false;
                this.Hunting = true;
                this.target = this.Waypoint;
            }
        }
    }

    public virtual void Warning()
    {
        if ((this.Hunting == true) && !this.Damaged)
        {
            GameObject TheThing = UnityEngine.Object.Instantiate(this.HuntingSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
            TheThing.transform.parent = this.thisTransform;
            this.Spot = false;
        }
    }

    public virtual void LeaveMarker()
    {
        if (this.Damaged)
        {
            return;
        }
        Vector3 lastPos = this.thisTransform.position;
        this.StartCoroutine(this.IsEscaping(lastPos));
    }

    public virtual IEnumerator IsEscaping(Vector3 lastPos)
    {
        yield return new WaitForSeconds(2);
        if (Vector3.Distance(this.thisTransform.position, lastPos) < 2)
        {
            this.Stuck = true;
        }
    }

    public virtual void Broken()
    {
        this.vRigidbody.angularDrag = 0.05f;
    }

    public AberrantCruiserAI()
    {
        this.Spot = true;
        this.ShootFrequency = 2;
    }

}