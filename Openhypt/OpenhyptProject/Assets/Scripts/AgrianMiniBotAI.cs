using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AgrianMiniBotAI : MonoBehaviour
{
    public Transform target;
    public GameObject Waypoint;
    public Transform Home;
    public Transform AIAnchor;
    public VehicleDamage MainHealth;
    public GameObject Vessel;
    public NPCGun Gun;
    public CapsuleCollider Trig;
    public GameObject Presence;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public GameObject Wing;
    public AudioSource Sounds;
    public bool Dodging;
    public int Maneuver;
    public bool Attacking;
    public int Shots;
    public bool Obscurity;
    public int Stuck;
    public bool Damaged;
    public bool Jammed;
    public bool IsActive;
    public bool Aberrant;
    public bool AgrianVigil;
    public bool Obstacle;
    public bool TurnRight;
    public bool TurnLeft;
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
    public LayerMask targetLayers;
    public LayerMask MtargetLayers;
    public float GyroForce;
    public float TurnForce;
    public int Faultyness;
    public bool GyroOff;
    public virtual void Start()
    {
        this.InvokeRepeating("Regenerator", 0.5f, 1);
        this.InvokeRepeating("ManeuvTick", 0.5f, 0.2f);
        this.InvokeRepeating("Shooty", Random.Range(0.1f, 1.1f), Random.Range(0.4f, 0.5f));
        if (this.Aberrant)
        {
            this.Trig.center = new Vector3(0, 0, 25);
            this.Trig.radius = 10;
            this.Trig.height = 50;
        }
        else
        {
            this.Trig.center = new Vector3(0, 0, 50);
            this.Trig.radius = 100;
            this.Trig.height = 200;
            KabrianLaw.KabrianPolicePresent = true;
        }
        if (this.AgrianVigil)
        {
            this.IsActive = true;
            this.vRigidbody.drag = 2;
            this.vRigidbody.angularDrag = 20;
            this.Wing.gameObject.SetActive(true);
        }
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        if (this.Vessel == null)
        {
            UnityEngine.Object.Destroy(this.Waypoint);
            UnityEngine.Object.Destroy(this.gameObject);
        }
        if (this.Damaged)
        {
            this.Sounds.volume = 0;
            this.vRigidbody.drag = 0.1f;
            this.vRigidbody.angularDrag = 0.1f;
            UnityEngine.Object.Destroy(this.Presence);
            UnityEngine.Object.Destroy(this.Waypoint);
            UnityEngine.Object.Destroy(this.gameObject);
        }
        if (this.Damaged)
        {
            return;
        }
        if (!this.IsActive)
        {
            return;
        }
        if ((this.AIAnchor && this.thisVTransform) && this.vRigidbody)
        {
            this.thisTransform.rotation = this.AIAnchor.transform.rotation;
            this.thisTransform.position = this.AIAnchor.transform.position;
        }
        else
        {
            UnityEngine.Object.Destroy(this.Waypoint);
            UnityEngine.Object.Destroy(this.gameObject);
            return;
        }
        if ((this.target == null) && this.Attacking)
        {
            this.StopAllCoroutines();
            if (this.Aberrant)
            {
                this.Trig.center = new Vector3(0, 0, 25);
                this.Trig.radius = 10;
                this.Trig.height = 50;
            }
            else
            {
                this.Trig.center = new Vector3(0, 0, 50);
                this.Trig.radius = 100;
                this.Trig.height = 200;
            }
            this.Attacking = false;
            this.Dodging = false;
        }
        if (!this.AgrianVigil)
        {
            if (Physics.Raycast(this.thisVTransform.position + (-this.thisVTransform.up * 2), -this.thisVTransform.up, out hit, 100, (int) this.targetLayers))
            {
                if (this.target)
                {
                    if (hit.collider.name.Contains(this.target.name))
                    {
                        this.Gun.LineOfFire = true;
                    }
                    else
                    {
                        this.Gun.LineOfFire = false;
                    }
                }
            }
        }
        if (this.TurnLeft && !this.Attacking)
        {
            if (!this.AgrianVigil)
            {
                this.TurnForce = -0.05f;
            }
            else
            {
                this.TurnForce = -0.005f;
            }
        }
        if (this.TurnRight && !this.Attacking)
        {
            if (!this.AgrianVigil)
            {
                this.TurnForce = 0.05f;
            }
            else
            {
                this.TurnForce = 0.005f;
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
        if (!this.AgrianVigil)
        {
            newRot = ((this.thisTransform.forward * 0.6f) + (this.thisTransform.right * 0.4f)).normalized;
            Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 2), newRot * 15f, Color.black);
            if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 2), newRot, 15))
            {
                this.TurnLeft = true;
            }
            else
            {
                this.TurnLeft = false;
            }
            newRot = ((this.thisTransform.forward * 0.6f) + (this.thisTransform.right * -0.4f)).normalized;
            Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 2), newRot * 15f, Color.black);
            if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 2), newRot, 15))
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
            newRot = ((this.thisTransform.forward * 0.6f) + (this.thisTransform.right * 0.4f)).normalized;
            Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 2), newRot * 5f, Color.black);
            if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 2), newRot, 5))
            {
                this.TurnLeft = true;
            }
            else
            {
                this.TurnLeft = false;
            }
            newRot = ((this.thisTransform.forward * 0.6f) + (this.thisTransform.right * -0.4f)).normalized;
            Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 2), newRot * 5f, Color.black);
            if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 2), newRot, 5))
            {
                this.TurnRight = true;
            }
            else
            {
                this.TurnRight = false;
            }
        }
        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 2), this.thisTransform.forward * 20f, Color.black);
        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 2), this.thisTransform.forward, 20))
        {
            this.Obstacle = true;
        }
        else
        {
            this.Obstacle = false;
        }
        if (this.target)
        {
            if ((Vector3.Distance(this.thisTransform.position, this.target.position) < 10) && this.Attacking)
            {
                this.Obstacle = true;
            }
        }
        if (!this.Attacking)
        {
            this.Obscurity = false;
            if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 2), this.thisTransform.forward, out hit, 20) && hit.collider.tag.Contains("Te"))
            {
                this.Obscurity = true;
            }
        }
    }

    public virtual void FixedUpdate()
    {
        RaycastHit hit = default(RaycastHit);
        if (this.Vessel)
        {
            if (!this.IsActive)
            {
                if (this.Sounds.volume > 0)
                {
                    this.Sounds.volume = this.Sounds.volume - 0.05f;
                }
            }
            if (this.IsActive)
            {
                if (this.Sounds.volume < 0.5f)
                {
                    this.Sounds.volume = this.Sounds.volume + 0.05f;
                }
            }
        }
        if ((!this.AIAnchor || !this.thisVTransform) || !this.vRigidbody)
        {
            UnityEngine.Object.Destroy(this.Waypoint);
            UnityEngine.Object.Destroy(this.gameObject);
            return;
        }
        if (!this.IsActive)
        {
            return;
        }
        if (!this.Jammed)
        {
            this.vRigidbody.AddTorque(this.thisTransform.up * this.TurnForce);
            if (Physics.Raycast(this.thisTransform.position, Vector3.down, 2, (int) this.targetLayers))
            {
                if (!this.AgrianVigil)
                {
                    if (!this.Aberrant)
                    {
                        this.vRigidbody.AddForce(Vector3.up * 0.4f);
                    }
                    else
                    {
                        this.vRigidbody.AddForce(Vector3.up * 0.2f);
                    }
                }
                else
                {
                    this.vRigidbody.AddForce(Vector3.up * 0.05f);
                }
            }
            if (this.target)
            {
                if (this.Maneuver < 1)
                {
                    if (this.DangerSense < 1)
                    {
                        if (!this.AgrianVigil)
                        {
                            if (!this.Aberrant)
                            {
                                this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * 0.1f, this.thisTransform.forward * 0.8f);
                                this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * -0.1f, -this.thisTransform.forward * 0.8f);
                            }
                            else
                            {
                                this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * 0.05f, this.thisTransform.forward * 0.8f);
                                this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * -0.05f, -this.thisTransform.forward * 0.8f);
                            }
                        }
                        else
                        {
                            this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * 0.01f, this.thisTransform.forward * 0.8f);
                            this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * -0.01f, -this.thisTransform.forward * 0.8f);
                        }
                    }
                    else
                    {
                        if (!this.AgrianVigil)
                        {
                            if (!this.Aberrant)
                            {
                                this.vRigidbody.AddForceAtPosition(this.DangerDirection * 0.1f, this.thisTransform.forward * 0.8f);
                                this.vRigidbody.AddForceAtPosition(this.DangerDirection * -0.1f, -this.thisTransform.forward * 0.8f);
                            }
                            else
                            {
                                this.vRigidbody.AddForceAtPosition(this.DangerDirection * 0.05f, this.thisTransform.forward * 0.8f);
                                this.vRigidbody.AddForceAtPosition(this.DangerDirection * -0.05f, -this.thisTransform.forward * 0.8f);
                            }
                        }
                        else
                        {
                            this.vRigidbody.AddForceAtPosition(this.DangerDirection * 0.005f, this.thisTransform.forward * 0.8f);
                            this.vRigidbody.AddForceAtPosition(this.DangerDirection * -0.005f, -this.thisTransform.forward * 0.8f);
                        }
                    }
                }
            }
            if (!this.AgrianVigil)
            {
                if (!this.Aberrant)
                {
                    this.vRigidbody.AddForceAtPosition(Vector3.up * this.GyroForce, this.thisTransform.up * 0.4f);
                    this.vRigidbody.AddForceAtPosition(-Vector3.up * this.GyroForce, -this.thisTransform.up * 0.4f);
                }
                else
                {
                    this.vRigidbody.AddForceAtPosition(Vector3.up * this.GyroForce, this.thisTransform.up * 0.3f);
                    this.vRigidbody.AddForceAtPosition(-Vector3.up * this.GyroForce, -this.thisTransform.up * 0.3f);
                }
            }
            else
            {
                this.vRigidbody.AddForceAtPosition(Vector3.up * this.GyroForce, this.thisTransform.up * 0.1f);
                this.vRigidbody.AddForceAtPosition(-Vector3.up * this.GyroForce, -this.thisTransform.up * 0.1f);
            }
            if (this.Attacking)
            {
                if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 1), this.thisTransform.forward, out hit, 5))
                {
                    if (hit.collider.tag.Contains("Te"))
                    {
                        if (!this.AgrianVigil)
                        {
                            if (!this.Aberrant)
                            {
                                this.vRigidbody.AddForce(this.thisVTransform.forward * 0.4f);
                            }
                            else
                            {
                                this.vRigidbody.AddForce(this.thisVTransform.forward * 0.2f);
                            }
                        }
                        else
                        {
                            this.vRigidbody.AddForce(this.thisVTransform.forward * 0.05f);
                        }
                    }
                    if (hit.collider.tag.Contains("Structure"))
                    {
                        if (!this.AgrianVigil)
                        {
                            if (!this.Aberrant)
                            {
                                this.vRigidbody.AddForce(this.thisVTransform.forward * 0.4f);
                            }
                            else
                            {
                                this.vRigidbody.AddForce(this.thisVTransform.forward * 0.2f);
                            }
                        }
                        else
                        {
                            this.vRigidbody.AddForce(this.thisVTransform.forward * 0.05f);
                        }
                    }
                }
            }
            if (this.Obstacle)
            {
                if (this.vRigidbody.velocity.magnitude > 10)
                {
                    if (!this.AgrianVigil)
                    {
                        if (!this.Aberrant)
                        {
                            this.vRigidbody.AddForce(-this.thisVTransform.up * -0.2f);
                        }
                        else
                        {
                            this.vRigidbody.AddForce(-this.thisVTransform.up * -0.1f);
                        }
                    }
                    else
                    {
                        this.vRigidbody.AddForce(-this.thisVTransform.up * -0.1f);
                    }
                }
                if (this.vRigidbody.velocity.magnitude < 10)
                {
                    if (!this.AgrianVigil)
                    {
                        this.vRigidbody.AddForce(-this.thisVTransform.up * -0.1f);
                    }
                    else
                    {
                        this.vRigidbody.AddForce(-this.thisVTransform.up * -0.05f);
                    }
                }
            }
            if (this.Dodging && !this.Obscurity)
            {
                if (!this.AgrianVigil)
                {
                    if (!this.Aberrant)
                    {
                        this.vRigidbody.AddForce(this.thisVTransform.forward * 0.4f);
                    }
                    else
                    {
                        this.vRigidbody.AddForce(this.thisVTransform.forward * 0.2f);
                    }
                }
                else
                {
                    this.vRigidbody.AddForce(this.thisVTransform.forward * 0.05f);
                }
            }
            if (this.Stuck > 0)
            {
                if (!this.AgrianVigil)
                {
                    if (!this.Aberrant)
                    {
                        this.vRigidbody.AddForce(-this.thisVTransform.up * -0.4f);
                    }
                    else
                    {
                        this.vRigidbody.AddForce(-this.thisVTransform.up * -0.2f);
                    }
                }
                else
                {
                    this.vRigidbody.AddForce(-this.thisVTransform.up * -0.1f);
                }
            }
        }
        if (!this.Obstacle && (this.Stuck < 1))
        {
            if (!this.AgrianVigil)
            {
                if (!this.Aberrant)
                {
                    this.vRigidbody.AddForce(-this.thisVTransform.up * 0.4f);
                }
                else
                {
                    this.vRigidbody.AddForce(-this.thisVTransform.up * 0.2f);
                }
            }
            else
            {
                this.vRigidbody.AddForce(-this.thisVTransform.up * 0.075f);
            }
        }
        if (this.Obscurity)
        {
            if (!this.AgrianVigil)
            {
                if (!this.Aberrant)
                {
                    this.vRigidbody.AddForce(this.thisVTransform.forward * 0.4f);
                }
                else
                {
                    this.vRigidbody.AddForce(this.thisVTransform.forward * 0.2f);
                }
            }
            else
            {
                this.vRigidbody.AddForce(this.thisVTransform.forward * 0.05f);
            }
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
        if (!this.IsActive)
        {
            return;
        }
        if (!this.Aberrant)
        {
            if (ON.Contains("TFC"))
            {
                if (!ON.Contains("TFC2"))
                {
                    if (!this.Attacking)
                    {
                        this.DangerSense = 3;
                        this.target = this.Waypoint.transform;
                        if (other.GetComponent<Rigidbody>())
                        {
                            this.DangerDirection = -other.GetComponent<Rigidbody>().velocity.normalized;
                        }
                    }
                    this.StartCoroutine(this.Dodge());
                }
            }
        }
        else
        {
            if (ON.Contains("TFC"))
            {
                if (!ON.Contains("TFC4"))
                {
                    if (!this.Attacking)
                    {
                        this.DangerSense = 3;
                        this.target = this.Waypoint.transform;
                        if (other.GetComponent<Rigidbody>())
                        {
                            this.DangerDirection = -other.GetComponent<Rigidbody>().velocity.normalized;
                        }
                    }
                    this.StartCoroutine(this.Dodge());
                }
            }
        }
        if (ON.Contains("TFC0a"))
        {
            this.PissedAtTC0a = 10;
        }
        if (ON.Contains("TFC1"))
        {
            this.PissedAtTC1 = 10;
        }
        if (ON.Contains("TFC3"))
        {
            this.PissedAtTC3 = 10;
        }
        if (ON.Contains("TFC4"))
        {
            this.PissedAtTC4 = 10;
        }
        if (ON.Contains("TFC5"))
        {
            this.PissedAtTC5 = 10;
        }
        if (ON.Contains("TFC6"))
        {
            this.PissedAtTC6 = 10;
        }
        if (ON.Contains("TFC7"))
        {
            this.PissedAtTC7 = 10;
        }
        if (ON.Contains("TFC8"))
        {
            this.PissedAtTC8 = 10;
        }
        if (ON.Contains("TFC9"))
        {
            this.PissedAtTC9 = 10;
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
        if (!this.AgrianVigil)
        {
            if (!this.Aberrant)
            {
                if (ON.Contains("HC2"))
                {
                    this.GetComponent<Rigidbody>().isKinematic = true;
                    this.Home = OT;
                }
            }
            else
            {
                if (this.Home == null)
                {
                    if (ON.Contains("TC") && !ON.Contains("sTC4"))
                    {
                        this.GetComponent<Rigidbody>().isKinematic = true;
                        this.Home = OT;
                    }
                }
            }
        }
        else
        {
            if ((AgrianNetwork.TC1CriminalLevel > 240) && ON.Contains("TC1"))
            {
                this.target = OT;
            }
            if (AgrianNetwork.instance.Curiosity > 200)
            {
                if ((AgrianNetwork.TC1CriminalLevel > 500) && ON.Contains("2_P"))
                {
                    this.target = OT;
                }
            }
            if ((AgrianNetwork.TC3CriminalLevel > 240) && ON.Contains("TC3"))
            {
                this.target = OT;
            }
            if ((AgrianNetwork.TC4CriminalLevel > 240) && ON.Contains("TC4"))
            {
                this.target = OT;
            }
            if ((AgrianNetwork.TC5CriminalLevel > 240) && ON.Contains("TC5"))
            {
                this.target = OT;
            }
            if (((AgrianNetwork.TC6CriminalLevel > 240) && ON.Contains("TC6")) && !ON.Contains("csT"))
            {
                this.target = OT;
            }
            if ((AgrianNetwork.TC7CriminalLevel > 240) && ON.Contains("TC7"))
            {
                this.target = OT;
            }
            if ((AgrianNetwork.TC8CriminalLevel > 240) && ON.Contains("TC8"))
            {
                this.target = OT;
            }
            if ((AgrianNetwork.TC9CriminalLevel > 240) && ON.Contains("TC9"))
            {
                this.target = OT;
            }
        }
        if (!this.IsActive)
        {
            return;
        }
        if (this.Aberrant && this.Attacking)
        {
            return;
        }
        if (ON.Contains("TC0a") && (this.PissedAtTC0a > 0))
        {
            this.Attacking = true;
            this.target = OT;
        }
        if (ON.Contains("TC1") && (this.PissedAtTC1 > 0))
        {
            this.Attacking = true;
            this.target = OT;
        }
        if (ON.Contains("TC3") && (this.PissedAtTC3 > 0))
        {
            this.Attacking = true;
            this.target = OT;
        }
        if (!this.Aberrant)
        {
            if (ON.Contains("TC4"))
            {
                this.Attacking = true;
                this.target = OT;
            }
        }
        else
        {
            if (ON.Contains("TC2"))
            {
                this.Attacking = true;
                this.target = OT;
            }
        }
        if (ON.Contains("TC5") && (this.PissedAtTC5 > 0))
        {
            this.Attacking = true;
            this.target = OT;
        }
        if (ON.Contains("TC6") && (this.PissedAtTC6 > 0))
        {
            if (!ON.Contains("csT"))
            {
                this.Attacking = true;
                this.target = OT;
            }
        }
        if (ON.Contains("TC7") && (this.PissedAtTC7 > 0))
        {
            this.Attacking = true;
            this.target = OT;
        }
        if (ON.Contains("TC8") && (this.PissedAtTC8 > 0))
        {
            this.Attacking = true;
            this.target = OT;
        }
        if (ON.Contains("TC9") && (this.PissedAtTC9 > 0))
        {
            this.Attacking = true;
            this.target = OT;
        }
    }

    public virtual void Shoot()
    {
        if (this.Attacking && !this.AgrianVigil)
        {
            if (this.Gun.LineOfFire)
            {
                this.Maneuver = 5;
                if (this.Aberrant)
                {
                    this.Shots = this.Shots + 1;
                    if (this.Shots > 16)
                    {
                        this.MainHealth.DamageIn(32, 0, 0, false);
                    }
                }
                else
                {
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
                }
            }
            this.Gun.Fire();
        }
    }

    public virtual void Shooty()
    {
        if (this.IsActive)
        {
            this.Shoot();
        }
    }

    public virtual IEnumerator Dodge()
    {
        this.Dodging = true;
        yield return new WaitForSeconds(0.5f);
        this.Dodging = false;
    }

    public virtual void ManeuvTick()
    {
        int randomValue = Random.Range(1, 4);
        if (this.Maneuver > 0)
        {
            this.Maneuver = this.Maneuver - 1;
        }
        switch (randomValue)
        {
            case 1:
                if (this.Maneuver > 1)
                {
                    this.Maneuver = this.Maneuver - 2;
                }
                break;
            case 2:
                if (this.Maneuver > 3)
                {
                    this.Maneuver = this.Maneuver - 4;
                }
                break;
        }
    }

    public virtual void Regenerator()
    {
        if (this.Damaged)
        {
            return;
        }
        if (!this.AgrianVigil)
        {
            if (!this.Aberrant)
            {
                if (this.Home != null)
                {
                    this.IsActive = true;
                    this.vRigidbody.drag = 2;
                    this.vRigidbody.angularDrag = 20;
                    this.Wing.gameObject.SetActive(true);
                }
                else
                {
                    this.IsActive = false;
                    this.vRigidbody.drag = 0.1f;
                    this.vRigidbody.angularDrag = 0.1f;
                    this.Wing.gameObject.SetActive(false);
                }
            }
            else
            {
                if (this.Presence.name.Contains("j"))
                {
                    this.Jammed = true;
                }
                this.IsActive = true;
                this.vRigidbody.drag = 2;
                this.vRigidbody.angularDrag = 20;
                this.Wing.gameObject.SetActive(true);
                if (this.Jammed)
                {
                    this.Faultyness = this.Faultyness + 1;
                    if (this.Faultyness > 3)
                    {
                        this.MainHealth.DamageIn(32, 0, 0, false);
                    }
                }
            }
        }
        if (!this.IsActive)
        {
            return;
        }
        if (this.Home)
        {
            if (!this.Attacking && (this.DangerSense < 1))
            {
                if (Vector3.Distance(this.thisTransform.position, this.Home.position) > 50)
                {
                    this.target = this.Home;
                }
                else
                {
                    this.target = null;
                }
            }
        }
        if (this.Attacking)
        {
            this.Trig.center = new Vector3(0, 0, 0);
            this.Trig.radius = 10;
            this.Trig.height = 10;
            this.GyroForce = 0.01f;
        }
        else
        {
            if (this.Aberrant)
            {
                this.Trig.center = new Vector3(0, 0, 25);
                this.Trig.radius = 10;
                this.Trig.height = 50;
                this.GyroForce = 0.02f;
            }
            else
            {
                this.Trig.center = new Vector3(0, 0, 50);
                this.Trig.radius = 100;
                this.Trig.height = 200;
                this.GyroForce = 0.02f;
            }
        }
        if (this.DangerSense > 0)
        {
            this.DangerSense = this.DangerSense - 1;
        }
        if (this.target)
        {
            if (this.target.name.Contains("TC0a"))
            {
                if (this.PissedAtTC0a < 1)
                {
                    this.Attacking = false;
                }
            }
            if (this.target.name.Contains("TC1"))
            {
                if (this.PissedAtTC1 < 1)
                {
                    this.Attacking = false;
                }
            }
            if (this.target.name.Contains("TC3"))
            {
                if (this.PissedAtTC3 < 1)
                {
                    this.Attacking = false;
                }
            }
            if (this.target.name.Contains("TC5"))
            {
                if (this.PissedAtTC5 < 1)
                {
                    this.Attacking = false;
                }
            }
            if (this.target.name.Contains("TC6"))
            {
                if (this.PissedAtTC6 < 1)
                {
                    this.Attacking = false;
                }
            }
            if (this.target.name.Contains("TC7"))
            {
                if (this.PissedAtTC7 < 1)
                {
                    this.Attacking = false;
                }
            }
            if (this.target.name.Contains("TC8"))
            {
                if (this.PissedAtTC8 < 1)
                {
                    this.Attacking = false;
                }
            }
            if (this.target.name.Contains("TC9"))
            {
                if (this.PissedAtTC9 < 1)
                {
                    this.Attacking = false;
                }
            }
            if (this.AgrianVigil)
            {
                if ((this.DangerSense > 0) && (AgrianNetwork.Alert == false))
                {
                    AgrianNetwork.instance.PriorityWaypoint.transform.position = this.thisTransform.position;
                }
                if (AgrianNetwork.TC1CriminalLevel < 500)
                {
                    if ((AgrianNetwork.TC1CriminalLevel > 120) && this.target.name.Contains("TC1"))
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
                    if ((AgrianNetwork.TC3CriminalLevel > 120) && this.target.name.Contains("TC3"))
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
                    if ((AgrianNetwork.TC4CriminalLevel > 120) && this.target.name.Contains("TC4"))
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
                    if ((AgrianNetwork.TC5CriminalLevel > 120) && this.target.name.Contains("TC5"))
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
                    if ((AgrianNetwork.TC6CriminalLevel > 120) && this.target.name.Contains("TC6"))
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
                    if ((AgrianNetwork.TC7CriminalLevel > 120) && this.target.name.Contains("TC7"))
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
                    if ((AgrianNetwork.TC8CriminalLevel > 120) && this.target.name.Contains("TC8"))
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
                    if ((AgrianNetwork.TC9CriminalLevel > 120) && this.target.name.Contains("TC9"))
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
            if (Vector3.Distance(this.thisTransform.position, this.target.position) > 500)
            {
                this.target = null;
            }
        }
        Vector3 lastPos = this.thisTransform.position;
        this.StartCoroutine(this.IsEscaping(lastPos));
    }

    public virtual IEnumerator IsEscaping(Vector3 lastPos)
    {
        yield return new WaitForSeconds(0.5f);
        if (Vector3.Distance(this.thisTransform.position, lastPos) < 0.5f)
        {
            this.Stuck = this.Stuck + 1;
        }
        else
        {
            if (this.Stuck > 0)
            {
                this.Stuck = this.Stuck - 1;
            }
        }
        if (this.Stuck > 16)
        {
            if (this.MainHealth)
            {
                this.MainHealth.DamageIn(32, 0, 0, false);
            }
        }
    }

    public AgrianMiniBotAI()
    {
        this.GyroForce = 10f;
    }

}