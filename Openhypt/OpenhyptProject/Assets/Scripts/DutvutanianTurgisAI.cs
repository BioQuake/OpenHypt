using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class DutvutanianTurgisAI : MonoBehaviour
{
    public Transform target;
    public Transform Waypoint;
    public Transform Forward;
    public Transform AIAnchor;
    public RemoveOverTime NpcController;
    public Transform TargetTrace;
    public Transform TargetLead;
    public Transform TargetLead2;
    public SphereCollider TLCol;
    public NPCGun Gun;
    public SphereCollider Trig;
    public GameObject Presence;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public GameObject AttackSound;
    public GameObject PriorityWaypoint;
    public int PissedAtTC0a;
    public int PissedAtTC1;
    public int PissedAtTC2;
    public int PissedAtTC3;
    public int PissedAtTC4;
    public int PissedAtTC5;
    public int PissedAtTC6;
    public int PissedAtTC7;
    public int PissedAtTC8;
    public bool Attacking;
    public bool Monitoring;
    public bool Obstacle;
    public bool Stuck;
    public bool TargetClose;
    public bool Stopping;
    public bool Damaged;
    public bool TurnRight;
    public bool TurnLeft;
    public int Spot;
    public int Ignorage;
    public int DangerSense;
    public bool FoundBig;
    public bool FoundExtraBig;
    public float Dist;
    public float Clamp;
    public float Vel;
    public float Vel2;
    public float AngVel;
    public Vector3 localV;
    public Vector3 relativePoint;
    public LayerMask targetLayers;
    public LayerMask MtargetLayers;
    public float RD;
    public float GyroForce;
    public float TurnForce;
    public float ShootFrequency;
    public float UniqueShootTime;
    public bool GyroOff;
    public virtual IEnumerator Start()
    {
        this.InvokeRepeating("Regenerator", 1, 1);
        this.InvokeRepeating("Targety", 30, 30);
        this.InvokeRepeating("Shooty", 1, this.ShootFrequency);
        this.InvokeRepeating("CalcLead", 1, 0.15f);
        this.GyroForce = 0.05f;
        this.Vel = 2;
        this.Vel2 = 2;
        this.UniqueShootTime = Random.Range(0, 0.2f);
        yield return new WaitForSeconds(0.3f);
        if (this.target)
        {
            if (this.target.name.Contains("TC"))
            {
                this.Attacking = true;
            }
        }
    }

    public virtual void Update()//Debug.Log(hit.transform.name);
    {
        RaycastHit hit = default(RaycastHit);
        if (this.target)
        {
            this.Dist = Vector3.Distance(this.thisTransform.position, this.target.position);
        }
        this.Clamp = Mathf.Clamp(this.Dist, 30, 90);
        this.Vel = Mathf.Clamp(this.vRigidbody.velocity.magnitude, 16, 128);
        this.Vel2 = Mathf.Clamp(this.Vel * 2, 16, 128);
        if (this.Attacking)
        {
            if (!this.target)
            {
                this.StopAllCoroutines();
                this.target = this.Waypoint;
                this.Attacking = false;
                this.Monitoring = false;
                this.Spot = 0;
            }
            else
            {
                if (this.target == this.Forward)
                {
                    this.target = this.Waypoint;
                    this.Attacking = false;
                    this.Monitoring = false;
                    this.Spot = 0;
                }
                if (this.target.name.Contains("bro"))
                {
                    this.StopAllCoroutines();
                    this.target = this.Waypoint;
                    this.Attacking = false;
                    this.Monitoring = false;
                    this.Spot = 0;
                }
            }
        }
        else
        {
            if (!this.target)
            {
                this.target = this.Forward;
                this.Monitoring = false;
            }
        }
        if (this.TurnLeft)
        {
            this.TurnForce = -6;
        }
        if (this.TurnRight)
        {
            this.TurnForce = 6;
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
        if (this.target)
        {
            this.relativePoint = this.thisVTransform.InverseTransformPoint(this.target.position);
            if (!this.FoundBig)
            {
                if (this.Dist < 16)
                {
                    this.TargetClose = true;
                }
                else
                {
                    this.TargetClose = false;
                }
            }
            else
            {
                if (!this.FoundExtraBig)
                {
                    if (this.Dist < 64)
                    {
                        this.TargetClose = true;
                    }
                    else
                    {
                        this.TargetClose = false;
                    }
                }
                else
                {
                    if (this.Dist < 128)
                    {
                        this.TargetClose = true;
                    }
                    else
                    {
                        this.TargetClose = false;
                    }
                }
            }
        }
        this.TurnRight = false;
        this.TurnLeft = false;
        newRot = ((this.thisTransform.forward * 0.8f) + (this.thisTransform.right * 0.1f)).normalized;
        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.right * 1.2f), newRot * this.Vel, Color.black);
        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.right * 1.2f), newRot, out hit, this.Vel, (int) this.targetLayers))
        {
            if (Vector3.Distance(hit.point, this.target.position) > 16)
            {
                this.TurnLeft = true;
            }
        }
        //Debug.Log(hit.transform.name);
        newRot = ((this.thisTransform.forward * 0.8f) + (this.thisTransform.right * -0.1f)).normalized;
        Debug.DrawRay(this.thisTransform.position + (-this.thisTransform.right * 1.2f), newRot * this.Vel, Color.black);
        if (Physics.Raycast(this.thisTransform.position + (-this.thisTransform.right * 1.2f), newRot, out hit, this.Vel, (int) this.targetLayers))
        {
            if (Vector3.Distance(hit.point, this.target.position) > 16)
            {
                this.TurnRight = true;
            }
        }
    }

    public virtual void FixedUpdate()
    {
        RaycastHit hit = default(RaycastHit);
        RaycastHit hit2 = default(RaycastHit);
        this.AngVel = this.vRigidbody.angularVelocity.magnitude;
        this.thisTransform.rotation = this.AIAnchor.transform.rotation;
        this.thisTransform.position = this.AIAnchor.transform.position;
        this.thisTransform.Translate(Vector3.down * 0.1f, Space.World);
        this.localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
        Vector3 RelativeTarget = this.thisVTransform.InverseTransformPoint(this.thisTransform.position);
        if (RelativeTarget.z > 0)
        {
            if (RelativeTarget.x > 0)
            {
                this.vRigidbody.AddTorque(this.thisVTransform.up * -8);
            }
            else
            {
                this.vRigidbody.AddTorque(this.thisVTransform.up * 8);
            }
        }
        else
        {
            this.GyroForce = 0.5f;
        }
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
        if (this.target)
        {
            if (this.Attacking)
            {
                if (!this.Obstacle)
                {
                    if (this.AngVel > 1)
                    {
                        this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * 0.2f, this.thisTransform.forward * 2);
                        this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * -0.2f, -this.thisTransform.forward * 2);
                    }
                    else
                    {
                        if (RelativeTarget.z < 0)
                        {
                            this.GyroForce = 0;
                        }
                        this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * 4, this.thisTransform.forward * 2);
                        this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * -4, -this.thisTransform.forward * 2);
                    }
                }
            }
            else
            {
                this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * 1, this.thisTransform.forward * 2);
                this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * -1, -this.thisTransform.forward * 2);
            }
        }
        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 1), this.thisTransform.forward * this.Vel, Color.white);
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * 1)) + (-this.thisTransform.up * 1), this.thisTransform.forward * this.Vel, Color.white);
        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 1), this.thisTransform.forward, out hit2, this.Vel, (int) this.targetLayers) || Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * 1)) + (-this.thisTransform.up * 1), this.thisTransform.forward, out hit2, this.Vel, (int) this.targetLayers))
        {
            this.Obstacle = true;
            if ((hit2.distance + 24) < this.Dist)
            {
                this.vRigidbody.AddTorque(this.thisTransform.right * -2);
            }
            if (this.Attacking)
            {
                this.vRigidbody.AddForce(this.thisVTransform.forward * 6);
            }
            else
            {
                this.vRigidbody.AddForce(this.thisVTransform.forward * 3);
            }
        }
        this.vRigidbody.AddForceAtPosition(Vector3.up * this.GyroForce, this.thisTransform.up * 2);
        this.vRigidbody.AddForceAtPosition(-Vector3.up * this.GyroForce, -this.thisTransform.up * 2);
        if (!Physics.Raycast(this.thisTransform.position, this.thisTransform.up, 2, (int) this.targetLayers))
        {
            if (Physics.Raycast(this.thisTransform.position, Vector3.down, 5 + this.RD, (int) this.targetLayers))
            {
                this.vRigidbody.AddForce(Vector3.up * 6);
                this.GyroForce = 2;
            }
        }
        else
        {
            this.vRigidbody.AddForce(this.thisVTransform.forward * -4);
        }
        if (!Physics.Raycast(this.thisTransform.position, Vector3.down, 50, (int) this.targetLayers))
        {
            this.vRigidbody.AddForce(Vector3.up * -1.5f);
        }
        if (this.Obstacle || this.TargetClose)
        {
            if (-this.localV.y > 0)
            {
                if (-this.localV.y > 10)
                {
                    this.vRigidbody.AddForce(-this.thisVTransform.up * -6);
                }
                else
                {
                    this.vRigidbody.AddForce(-this.thisVTransform.up * -3);
                }
            }
        }
        if (this.Stuck)
        {
            this.vRigidbody.AddForce(-this.thisVTransform.up * -1.5f);
        }
        if ((this.Vel < 120) && !this.TargetClose)
        {
            if (this.Attacking)
            {
                if (((!this.Obstacle && !this.Stuck) && !this.TurnLeft) && !this.TurnRight)
                {
                    this.vRigidbody.AddForce(-this.thisVTransform.up * 3);
                }
            }
            else
            {
                if (((!this.Obstacle && !this.Stuck) && !this.TurnLeft) && !this.TurnRight)
                {
                    this.vRigidbody.AddForce(-this.thisVTransform.up * 2);
                }
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
        if (!this.Attacking && (this.Spot < 2))
        {
            if (ON.Contains("TC") && !ON.Contains("TC9"))
            {
                this.target = OT;
                this.Spot = 4;
                this.StopAllCoroutines();
            }
        }
        if (ON.Contains("TFC") && !ON.Contains("TFC9"))
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
            if (ON.Contains("TFC7"))
            {
                this.PissedAtTC7 = this.PissedAtTC7 + 1;
            }
            if (ON.Contains("TFC8"))
            {
                this.PissedAtTC8 = this.PissedAtTC8 + 1;
            }
            if (!this.Attacking)
            {
                if (this.DangerSense == 0)
                {
                    this.Trig.radius = 64;
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
        if (this.Waypoint)
        {
            if (this.DangerSense > 0)
            {
                if (ON.Contains("TC") && !ON.Contains("TC9"))
                {
                    if (Vector3.Distance(OT.position, this.Waypoint.transform.position) < 64)
                    {
                        this.target = OT;
                        this.DangerSense = 0;
                        this.Spot = 0;
                    }
                }
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

    public virtual void Shooty()
    {
        if (this.Attacking)
        {
            this.StartCoroutine(this.Shoot());
        }
    }

    public virtual void Engagey()
    {
        this.Attacking = true;
        this.Monitoring = false;
        GameObject TheThing3 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
        TheThing3.transform.parent = this.thisTransform;
        if (this.target)
        {
            if (this.PissedAtTC1 > 3)
            {
                if (this.target.name.Contains("C1"))
                {
                    DutvutanianNetwork.instance.EnemyTargetMin = this.target;
                }
            }
            if (this.PissedAtTC2 > 3)
            {
                if (this.target.name.Contains("C2"))
                {
                    DutvutanianNetwork.instance.EnemyTargetMin = this.target;
                }
            }
            if (this.PissedAtTC3 > 3)
            {
                if (this.target.name.Contains("C3"))
                {
                    DutvutanianNetwork.instance.EnemyTargetMin = this.target;
                }
            }
            if (this.PissedAtTC4 > 3)
            {
                if (this.target.name.Contains("C4"))
                {
                    DutvutanianNetwork.instance.EnemyTargetMin = this.target;
                }
            }
            if (this.PissedAtTC5 > 3)
            {
                if (this.target.name.Contains("C5"))
                {
                    DutvutanianNetwork.instance.EnemyTargetMin = this.target;
                }
            }
            if (this.PissedAtTC6 > 3)
            {
                if (this.target.name.Contains("C6"))
                {
                    DutvutanianNetwork.instance.EnemyTargetMin = this.target;
                }
            }
            if (this.PissedAtTC7 > 3)
            {
                if (this.target.name.Contains("C7"))
                {
                    DutvutanianNetwork.instance.EnemyTargetMin = this.target;
                }
            }
            if (this.PissedAtTC8 > 3)
            {
                if (this.target.name.Contains("C8"))
                {
                    DutvutanianNetwork.instance.EnemyTargetMin = this.target;
                }
            }
        }
        this.StopAllCoroutines();
    }

    public virtual void Targety()
    {
        if (((this.Spot < 1) && !this.Attacking) && !this.Monitoring)
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
        if (this.Waypoint)
        {
            this.Waypoint.transform.position = DutvutanianNetwork.instance.PriorityWaypoint.position;
            this.target = this.Waypoint;
        }
        yield return new WaitForSeconds(4);
        this.target = this.Forward;
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
        this.Stopping = false;
        if (this.target)
        {
            if (this.Ignorage > 5)
            {
                this.Ignorage = 0;
                this.Attacking = false;
                this.target = this.Forward;
            }
            if (this.Attacking)
            {
                if (this.Dist > 1000)
                {
                    this.Attacking = false;
                    this.Spot = 0;
                    this.Waypoint.transform.position = this.target.transform.position;
                    this.target = this.Waypoint;
                }
            }
            else
            {
                if (DutvutanianNetwork.AlertTime > 1)
                {
                    if (!this.target.name.Contains("TC"))
                    {
                        if (this.Waypoint)
                        {
                            this.Waypoint.transform.position = DutvutanianNetwork.instance.PriorityWaypoint.position;
                            if (Vector3.Distance(this.thisTransform.position, this.Waypoint.position) > 128)
                            {
                                this.target = this.Waypoint;
                            }
                            else
                            {
                                this.target = this.Forward;
                            }
                        }
                    }
                }
            }
            if (this.Spot < 4)
            {
                if (this.target.name.Contains("TC0"))
                {
                    this.Gun.ConfirmedName = this.target.name;
                    if (!this.Attacking)
                    {
                        if (this.DangerSense > 0)
                        {
                            this.Engagey();
                        }
                    }
                }
                if (this.target.name.Contains("TC1"))
                {
                    this.Gun.ConfirmedName = this.target.name;
                    if (DutvutanianNetwork.TC1CriminalLevel > 150)
                    {
                        DutvutanianNetwork.instance.PriorityWaypoint.position = this.target.position;
                        DutvutanianNetwork.AlertTime = 120;
                        this.Monitoring = true;
                        if (DutvutanianNetwork.TC1CriminalLevel < 240)
                        {
                            DutvutanianNetwork.TC1CriminalLevel = 240;
                        }
                    }
                    if (!this.Attacking)
                    {
                        if (this.PissedAtTC1 > 1)
                        {
                            this.Engagey();
                        }
                    }
                }
                if (this.target.name.Contains("TC2"))
                {
                    this.Gun.ConfirmedName = this.target.name;
                    if (DutvutanianNetwork.TC2CriminalLevel > 150)
                    {
                        DutvutanianNetwork.instance.PriorityWaypoint.position = this.target.position;
                        DutvutanianNetwork.AlertTime = 120;
                        this.Monitoring = true;
                        if (DutvutanianNetwork.TC2CriminalLevel < 240)
                        {
                            DutvutanianNetwork.TC2CriminalLevel = 240;
                        }
                    }
                    //Debug.Log("ItDidIt");
                    if (!this.Attacking)
                    {
                        if (this.PissedAtTC2 > 1)
                        {
                            this.Engagey();
                        }
                    }
                }
                if (this.target.name.Contains("TC3"))
                {
                    this.Gun.ConfirmedName = this.target.name;
                    if (DutvutanianNetwork.TC3CriminalLevel > 150)
                    {
                        DutvutanianNetwork.instance.PriorityWaypoint.position = this.target.position;
                        DutvutanianNetwork.AlertTime = 120;
                        this.Monitoring = true;
                        if (DutvutanianNetwork.TC3CriminalLevel < 240)
                        {
                            DutvutanianNetwork.TC3CriminalLevel = 240;
                        }
                    }
                    if (!this.Attacking)
                    {
                        if (this.PissedAtTC3 > 1)
                        {
                            this.Engagey();
                        }
                    }
                }
                if (this.target.name.Contains("TC4"))
                {
                    this.Gun.ConfirmedName = this.target.name;
                    if (DutvutanianNetwork.TC4CriminalLevel > 150)
                    {
                        DutvutanianNetwork.instance.PriorityWaypoint.position = this.target.position;
                        DutvutanianNetwork.AlertTime = 120;
                        this.Monitoring = true;
                        if (DutvutanianNetwork.TC4CriminalLevel < 240)
                        {
                            DutvutanianNetwork.TC4CriminalLevel = 240;
                        }
                    }
                    if (!this.Attacking)
                    {
                        if (this.PissedAtTC4 > 1)
                        {
                            this.Engagey();
                        }
                    }
                }
                if (this.target.name.Contains("TC5"))
                {
                    this.Gun.ConfirmedName = this.target.name;
                    if (DutvutanianNetwork.TC5CriminalLevel > 150)
                    {
                        DutvutanianNetwork.instance.PriorityWaypoint.position = this.target.position;
                        DutvutanianNetwork.AlertTime = 120;
                        this.Monitoring = true;
                        if (DutvutanianNetwork.TC5CriminalLevel < 240)
                        {
                            DutvutanianNetwork.TC5CriminalLevel = 240;
                        }
                    }
                    if (!this.Attacking)
                    {
                        if (this.PissedAtTC5 > 1)
                        {
                            this.Engagey();
                        }
                    }
                }
                if (this.target.name.Contains("TC6"))
                {
                    this.Gun.ConfirmedName = this.target.name;
                    if (DutvutanianNetwork.TC6CriminalLevel > 150)
                    {
                        DutvutanianNetwork.instance.PriorityWaypoint.position = this.target.position;
                        DutvutanianNetwork.AlertTime = 120;
                        this.Monitoring = true;
                        if (DutvutanianNetwork.TC6CriminalLevel < 240)
                        {
                            DutvutanianNetwork.TC6CriminalLevel = 240;
                        }
                    }
                    if (!this.Attacking)
                    {
                        if (this.PissedAtTC6 > 1)
                        {
                            this.Engagey();
                        }
                    }
                }
                if (this.target.name.Contains("TC7"))
                {
                    this.Gun.ConfirmedName = this.target.name;
                    if (DutvutanianNetwork.TC7CriminalLevel > 150)
                    {
                        DutvutanianNetwork.instance.PriorityWaypoint.position = this.target.position;
                        DutvutanianNetwork.AlertTime = 120;
                        this.Monitoring = true;
                        if (DutvutanianNetwork.TC7CriminalLevel < 240)
                        {
                            DutvutanianNetwork.TC7CriminalLevel = 240;
                        }
                    }
                    if (!this.Attacking)
                    {
                        if (this.PissedAtTC7 > 1)
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
            if (this.target.name.Contains("bT"))
            {
                if (this.target.name.Contains("xbT"))
                {
                    this.FoundExtraBig = true;
                    this.FoundBig = false;
                }
                else
                {
                    this.FoundExtraBig = false;
                    this.FoundBig = true;
                }
            }
            else
            {
                this.FoundBig = false;
                this.FoundExtraBig = false;
            }
            this.TargetClose = false;
            if (this.Ignorage > 24)
            {
                this.Targety();
            }
            Vector3 lastPos = this.thisTransform.position;
            Vector3 lastTPos = this.target.position;
            this.StartCoroutine(this.IsEscaping(lastPos, lastTPos, this.relativePoint.y));
        }
        if (this.Attacking)
        {
            this.Trig.radius = 64;
        }
        else
        {
            this.Trig.radius = this.Trig.radius + 100;
            if (this.Trig.radius > 550)
            {
                this.Trig.radius = 200;
            }
        }
        if (this.Spot > 0)
        {
            this.Spot = this.Spot - 1;
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
        }
        if ((Vector3.Distance(this.thisTransform.position, lastPos) < 1) && !this.Stopping)
        {
            this.Stuck = true;
            yield return new WaitForSeconds(1);
            this.Stuck = false;
        }
    }

    public DutvutanianTurgisAI()
    {
        this.GyroForce = 0.2f;
        this.ShootFrequency = 5;
        this.UniqueShootTime = 0.1f;
    }

}