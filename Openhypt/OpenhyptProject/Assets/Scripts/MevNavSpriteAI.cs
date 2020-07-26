using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MevNavSpriteAI : MonoBehaviour
{
    public Transform target;
    public Transform Waypoint;
    public Transform Forward;
    public Transform AIAnchor;
    public RemoveOverTime NpcController;
    public Transform Home;
    public SphereCollider Trig;
    public GameObject Presence;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public GameObject SpotSound;
    public GameObject AttackSound;
    public GameObject RejectSound;
    public GameObject PriorityWaypoint;
    public bool Attacking;
    public bool Obstacle;
    public bool Stuck;
    public bool Damaged;
    public bool Jammed;
    public bool Activated;
    public bool Far;
    public bool SlowingDown;
    public bool TurnRight;
    public bool TurnLeft;
    public bool Ignore;
    public int Spot;
    public int DangerSense;
    public int Vel;
    public float AngVel;
    public Vector3 localV;
    public Vector3 relativePoint;
    public LayerMask targetLayers;
    public float RD;
    public float GyroForce;
    public float TurnForce;
    public bool GyroOff;
    public virtual IEnumerator Start()
    {
        this.InvokeRepeating("Regenerator", 0.43f, 1);
        this.Spot = 1;
        this.GyroForce = 0.05f;
        yield return new WaitForSeconds(0.3f);
        if (this.target.name.Contains("TC"))
        {
            this.Attacking = true;
        }
        this.Activated = true;
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        if (!this.Activated)
        {
            return;
        }
        this.Vel = (int) this.vRigidbody.velocity.magnitude;
        this.thisTransform.rotation = this.AIAnchor.transform.rotation;
        this.thisTransform.position = this.AIAnchor.transform.position;
        if (this.Attacking)
        {
            if (this.target == null)
            {
                this.StopAllCoroutines();
                this.target = this.Waypoint;
                this.Attacking = false;
                this.Spot = 1;
            }
        }
        if (this.TurnLeft)
        {
            this.TurnForce = -1;
        }
        if (this.TurnRight)
        {
            this.TurnForce = 1;
        }
        if (!this.TurnRight && !this.TurnLeft)
        {
            this.TurnForce = 0;
        }
        if (this.TurnRight && this.TurnLeft)
        {
            this.TurnForce = 1;
        }
        Vector3 newRot = (this.thisTransform.forward * 0.5f).normalized;
        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 1), newRot * 200f, Color.green);
        this.Obstacle = false;
        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 1), this.thisTransform.forward, out hit, 200, (int) this.targetLayers) && (-this.localV.y > 30))
        {
            this.SlowingDown = true;
        }
        else
        {
            this.SlowingDown = false;
        }
        newRot = ((this.thisTransform.forward * 0.9f) + (this.thisTransform.right * 0.1f)).normalized;
        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.right * 1.2f), newRot * 100, Color.black);
        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.right * 1.2f), newRot, 100))
        {
            this.TurnLeft = true;
        }
        else
        {
            this.TurnLeft = false;
        }
        newRot = ((this.thisTransform.forward * 0.9f) + (this.thisTransform.right * -0.1f)).normalized;
        Debug.DrawRay(this.thisTransform.position + (-this.thisTransform.right * 1.2f), newRot * 100, Color.black);
        if (Physics.Raycast(this.thisTransform.position + (-this.thisTransform.right * 1.2f), newRot, 100))
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
            if (!this.Obstacle)
            {
                if (this.Far)
                {
                    this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * 0.2f, this.thisTransform.forward * 2);
                    this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * -0.2f, -this.thisTransform.forward * 2);
                    this.GyroForce = 0.4f;
                }
                else
                {
                    this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * 0.05f, this.thisTransform.forward * 2);
                    this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * -0.05f, -this.thisTransform.forward * 2);
                    this.GyroForce = 0.2f;
                }
            }
        }
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * 1)) + (this.thisTransform.up * 1), this.thisTransform.forward, 30, (int) this.targetLayers))
        {
            this.Obstacle = true;
        }
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
        }
        this.vRigidbody.AddForceAtPosition(Vector3.up * this.GyroForce, this.thisTransform.up * 2);
        this.vRigidbody.AddForceAtPosition(-Vector3.up * this.GyroForce, -this.thisTransform.up * 2);
        if (!Physics.Raycast(this.thisTransform.position, this.thisTransform.up, 2, (int) this.targetLayers))
        {
            if (Physics.Raycast(this.thisTransform.position, Vector3.down, 100 + this.RD, (int) this.targetLayers))
            {
                this.vRigidbody.AddForce(Vector3.up * 3);
                this.GyroForce = 1;
            }
        }
        else
        {
            this.vRigidbody.AddForce(this.thisVTransform.forward * -4);
        }
        if (!Physics.Raycast(this.thisTransform.position, Vector3.down, 150, (int) this.targetLayers))
        {
            this.vRigidbody.AddForce(Vector3.up * -1.5f);
        }
        if (this.Obstacle)
        {
            if (-this.localV.y > 0)
            {
                if (-this.localV.y > 15)
                {
                    this.vRigidbody.AddForce(-this.thisVTransform.up * -3);
                }
                else
                {
                    this.vRigidbody.AddForce(-this.thisVTransform.up * -1);
                }
            }
        }
        if (this.Stuck)
        {
            this.vRigidbody.AddForce(-this.thisVTransform.up * -1.5f);
        }
        if (this.Vel < 80)
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

    public virtual void OnTriggerEnter(Collider other)
    {
        if (!this.Activated)
        {
            return;
        }
        string ON = other.name;
        Transform OT = other.transform;
        if ((other.tag == "Projectile") && !ON.Contains("TFC7"))
        {
            if (!this.Attacking)
            {
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
        if (!this.Attacking)
        {
            if (ON.Contains("TC") && !ON.Contains("TC7"))
            {
                if (ON.Contains("TC0"))
                {
                    this.Ignore = true;
                }
                if (ON.Contains("TC1"))
                {
                    if (!this.Attacking)
                    {
                        if (MevNavNetwork.TC1DeathRow > 300)
                        {
                            this.target = OT;
                            MevNavNetwork.instance.PriorityWaypoint.position = this.target.position;
                            if (MevNavNetwork.TC1DeathRow < 600)
                            {
                                MevNavNetwork.TC1DeathRow = 600;
                            }
                            this.Attacking = true;
                        }
                        else
                        {
                            this.Ignore = true;
                        }
                    }
                }
                if (ON.Contains("TC2"))
                {
                    this.Ignore = true;
                }
                if (ON.Contains("TC3"))
                {
                    if (!this.Attacking)
                    {
                        if ((MevNavNetwork.TC3DeathRow > 300) && (MevNavNetwork.TC1DeathRow < 300))
                        {
                            this.target = OT;
                            MevNavNetwork.instance.PriorityWaypoint.position = this.target.position;
                            if (MevNavNetwork.TC3DeathRow < 600)
                            {
                                MevNavNetwork.TC3DeathRow = 600;
                            }
                            this.Attacking = true;
                        }
                        else
                        {
                            this.Ignore = true;
                        }
                    }
                }
                if (ON.Contains("TC4"))
                {
                    if (!this.Attacking)
                    {
                        if ((MevNavNetwork.TC4DeathRow > 300) && (MevNavNetwork.TC1DeathRow < 300))
                        {
                            this.target = OT;
                            MevNavNetwork.instance.PriorityWaypoint.position = this.target.position;
                            if (MevNavNetwork.TC4DeathRow < 600)
                            {
                                MevNavNetwork.TC4DeathRow = 600;
                            }
                            this.Attacking = true;
                        }
                        else
                        {
                            this.Ignore = true;
                        }
                    }
                }
                if (ON.Contains("TC5"))
                {
                    if (!this.Attacking)
                    {
                        if ((MevNavNetwork.TC5DeathRow > 300) && (MevNavNetwork.TC1DeathRow < 300))
                        {
                            this.target = OT;
                            MevNavNetwork.instance.PriorityWaypoint.position = this.target.position;
                            if (MevNavNetwork.TC5DeathRow < 600)
                            {
                                MevNavNetwork.TC5DeathRow = 600;
                            }
                            this.Attacking = true;
                        }
                        else
                        {
                            this.Ignore = true;
                        }
                    }
                }
                if (ON.Contains("TC6"))
                {
                    if (!this.Attacking)
                    {
                        if ((MevNavNetwork.TC6DeathRow > 300) && (MevNavNetwork.TC1DeathRow < 300))
                        {
                            this.target = OT;
                            MevNavNetwork.instance.PriorityWaypoint.position = this.target.position;
                            if (MevNavNetwork.TC6DeathRow < 600)
                            {
                                MevNavNetwork.TC6DeathRow = 600;
                            }
                            this.Attacking = true;
                        }
                        else
                        {
                            this.Ignore = true;
                        }
                    }
                }
                if (ON.Contains("TC8"))
                {
                    if (!this.Attacking)
                    {
                        if ((MevNavNetwork.TC8DeathRow > 300) && (MevNavNetwork.TC1DeathRow < 300))
                        {
                            this.target = OT;
                            MevNavNetwork.instance.PriorityWaypoint.position = this.target.position;
                            if (MevNavNetwork.TC8DeathRow < 600)
                            {
                                MevNavNetwork.TC8DeathRow = 600;
                            }
                            this.Attacking = true;
                        }
                        else
                        {
                            this.Ignore = true;
                        }
                    }
                }
                if (ON.Contains("TC9"))
                {
                    if (!this.Attacking)
                    {
                        if ((MevNavNetwork.TC9DeathRow > 300) && (MevNavNetwork.TC1DeathRow < 300))
                        {
                            this.target = OT;
                            MevNavNetwork.instance.PriorityWaypoint.position = this.target.position;
                            if (MevNavNetwork.TC9DeathRow < 600)
                            {
                                MevNavNetwork.TC9DeathRow = 600;
                            }
                            this.Attacking = true;
                        }
                        else
                        {
                            this.Ignore = true;
                        }
                    }
                }
            }
        }
    }

    public virtual IEnumerator TargetArea()
    {
        if (this.Waypoint)
        {
            if (!this.Attacking)
            {
                if (MevNavNetwork.AlertTime > 0)
                {
                    this.Waypoint.transform.position = MevNavNetwork.instance.PriorityWaypoint.position;
                    this.target = this.Waypoint;
                }
            }
        }
        yield return new WaitForSeconds(8);
        if (!this.Attacking)
        {
            this.target = this.Forward;
        }
    }

    public virtual void Regenerator()
    {
        if (!this.Activated)
        {
            return;
        }
        if (!this.Attacking)
        {
            if (this.Ignore)
            {
                this.Ignore = false;
                GameObject TheThing0 = UnityEngine.Object.Instantiate(this.RejectSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                TheThing0.transform.parent = this.thisTransform;
            }
            else
            {
                GameObject TheThing1 = UnityEngine.Object.Instantiate(this.SpotSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                TheThing1.transform.parent = this.thisTransform;
            }
            if (this.Spot > 1)
            {
                this.Spot = this.Spot - 1;
            }
            if (this.Spot == 1)
            {
                this.Spot = 16;
                this.StartCoroutine(this.TargetArea());
            }
        }
        else
        {
            if (this.Spot == 1)
            {
                this.Spot = 0;
                GameObject TheThing2 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                TheThing2.transform.parent = this.thisTransform;
            }
        }
        if (this.target)
        {
            if (this.Attacking)
            {
                if (Vector3.Distance(this.thisTransform.position, this.target.position) > 600)
                {
                    this.Far = true;
                }
                else
                {
                    if (Vector3.Distance(this.thisTransform.position, this.target.position) < 500)
                    {
                        this.Far = false;
                    }
                }
                if (this.target.name.Contains("C1"))
                {
                    if (MevNavNetwork.TC1DeathRow > 300)
                    {
                        MevNavNetwork.instance.PriorityWaypoint.position = this.target.position;
                        MevNavNetwork.AlertTime = 60;
                        if (MevNavNetwork.TC1DeathRow < 600)
                        {
                            MevNavNetwork.TC1DeathRow = 600;
                        }
                        else
                        {
                            MevNavNetwork.AlertLVL2 = 1;
                        }
                        if (this.target.name.Contains("xbT"))
                        {
                            MevNavNetwork.xbTarget = this.target;
                        }
                    }
                }
                if (this.target.name.Contains("C3"))
                {
                    if (MevNavNetwork.TC3DeathRow > 300)
                    {
                        MevNavNetwork.instance.PriorityWaypoint.position = this.target.position;
                        MevNavNetwork.AlertTime = 60;
                        if (MevNavNetwork.TC3DeathRow < 600)
                        {
                            MevNavNetwork.TC3DeathRow = 600;
                        }
                        else
                        {
                            MevNavNetwork.AlertLVL2 = 3;
                        }
                    }
                }
                if (this.target.name.Contains("C4"))
                {
                    if (MevNavNetwork.TC4DeathRow > 300)
                    {
                        MevNavNetwork.instance.PriorityWaypoint.position = this.target.position;
                        MevNavNetwork.AlertTime = 60;
                        if (MevNavNetwork.TC4DeathRow < 600)
                        {
                            MevNavNetwork.TC4DeathRow = 600;
                        }
                        else
                        {
                            MevNavNetwork.AlertLVL2 = 4;
                        }
                    }
                }
                if (this.target.name.Contains("C5"))
                {
                    if (MevNavNetwork.TC5DeathRow > 300)
                    {
                        MevNavNetwork.instance.PriorityWaypoint.position = this.target.position;
                        MevNavNetwork.AlertTime = 60;
                        if (MevNavNetwork.TC5DeathRow < 600)
                        {
                            MevNavNetwork.TC5DeathRow = 600;
                        }
                        else
                        {
                            MevNavNetwork.AlertLVL2 = 5;
                        }
                    }
                }
                if (this.target.name.Contains("C6"))
                {
                    if (MevNavNetwork.TC6DeathRow > 300)
                    {
                        MevNavNetwork.instance.PriorityWaypoint.position = this.target.position;
                        MevNavNetwork.AlertTime = 60;
                        if (MevNavNetwork.TC6DeathRow < 600)
                        {
                            MevNavNetwork.TC6DeathRow = 600;
                        }
                        else
                        {
                            MevNavNetwork.AlertLVL2 = 6;
                        }
                    }
                }
                if (this.target.name.Contains("C8"))
                {
                    if (MevNavNetwork.TC8DeathRow > 300)
                    {
                        MevNavNetwork.instance.PriorityWaypoint.position = this.target.position;
                        MevNavNetwork.AlertTime = 60;
                        if (MevNavNetwork.TC8DeathRow < 600)
                        {
                            MevNavNetwork.TC8DeathRow = 600;
                        }
                        else
                        {
                            MevNavNetwork.AlertLVL2 = 8;
                        }
                    }
                }
                if (this.target.name.Contains("C9"))
                {
                    if (MevNavNetwork.TC9DeathRow > 300)
                    {
                        MevNavNetwork.instance.PriorityWaypoint.position = this.target.position;
                        MevNavNetwork.AlertTime = 60;
                        if (MevNavNetwork.TC9DeathRow < 600)
                        {
                            MevNavNetwork.TC9DeathRow = 600;
                        }
                        else
                        {
                            MevNavNetwork.AlertLVL2 = 9;
                        }
                    }
                }
            }
        }
        this.GyroForce = 0.2f;
        if (this.Attacking)
        {
            this.Trig.center = new Vector3(0, 0, 0);
            this.Trig.radius = 50;
        }
        else
        {
            this.Trig.center = new Vector3(0, 0, 350);
            this.Trig.radius = 400;
            if (this.DangerSense > 0)
            {
                this.DangerSense = this.DangerSense - 1;
            }
            if (this.Home)
            {
                if (Vector3.Distance(this.thisTransform.position, this.Home.position) > 500)
                {
                    this.target = this.Home;
                }
                else
                {
                    this.target = this.Forward;
                }
            }
        }
        Vector3 lastPos = this.thisTransform.position;
        this.StartCoroutine(this.IsEscaping(lastPos));
    }

    public virtual IEnumerator IsEscaping(Vector3 lastPos)
    {
        this.Stuck = false;
        yield return new WaitForSeconds(0.5f);
        if (Vector3.Distance(this.thisTransform.position, lastPos) < 1)
        {
            this.Stuck = true;
            yield return new WaitForSeconds(1);
            this.Stuck = false;
        }
    }

    public MevNavSpriteAI()
    {
        this.GyroForce = 0.2f;
    }

}