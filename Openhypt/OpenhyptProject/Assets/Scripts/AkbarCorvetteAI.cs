using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AkbarCorvetteAI : MonoBehaviour
{
    public Transform target;
    public Transform ResetView;
    public Transform Waypoint;
    public BigVesselRotator Rotator;
    public CapsuleCollider Trig;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public bool PissedAtTC0a;
    public bool PissedAtTC1;
    public bool PissedAtTC2;
    public bool PissedAtTC3;
    public bool PissedAtTC4;
    public bool PissedAtTC5;
    public bool PissedAtTC7;
    public bool PissedAtTC8;
    public bool PissedAtTC9;
    public bool Hunting;
    public bool Spot;
    public bool Attacking;
    public bool Obstacle;
    public bool CloseToBase;
    public bool Pathfind;
    public bool FoundSmall;
    public bool TurnRight;
    public bool TurnLeft;
    public int DangerSense;
    public Vector3 DangerDirection;
    public LayerMask targetLayers;
    public LayerMask MtargetLayers;
    public int Stuck;
    public int JustNoticed;
    public int Slope;
    public bool Tick;
    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        if ((this.target == null) && this.Attacking)
        {
            bool FoundBig = false;
            this.Attacking = false;
            this.Spot = false;
            this.Hunting = true;
            this.target = this.ResetView;
            this.StopAllCoroutines();
        }
        if (this.target != null)
        {
            if (this.target.name.Contains("Forward") && this.Attacking)
            {
                this.Attacking = false;
                this.Spot = false;
                this.Hunting = true;
                this.target = this.ResetView;
                this.StopAllCoroutines();
            }
        }
        Vector3 newRot = (-this.thisVTransform.up * 0.6f).normalized;
        Vector3 localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
        if (-localV.y > 15)
        {
            newRot = ((-this.thisVTransform.up * 0.6f) + (-this.thisVTransform.right * 0.1f)).normalized;
            Debug.DrawRay((this.thisVTransform.position + -this.thisVTransform.up) + (-this.thisVTransform.right * 10), newRot * 100f, Color.black);
            if (Physics.Raycast((this.thisVTransform.position + -this.thisVTransform.up) + (-this.thisVTransform.right * 10), newRot, 100))
            {
                this.TurnLeft = true;
            }
            else
            {
                this.TurnLeft = false;
            }
            newRot = ((-this.thisVTransform.up * 0.6f) + (-this.thisVTransform.right * -0.1f)).normalized;
            Debug.DrawRay((this.thisVTransform.position + -this.thisVTransform.up) + (this.thisVTransform.right * 10), newRot * 100f, Color.black);
            if (Physics.Raycast((this.thisVTransform.position + -this.thisVTransform.up) + (this.thisVTransform.right * 10), newRot, 100))
            {
                this.TurnRight = true;
            }
            else
            {
                this.TurnRight = false;
            }
            Debug.DrawRay(this.thisVTransform.position + (-this.thisVTransform.up * 20), -this.thisVTransform.up * 80f, Color.green);
            if (Physics.Raycast(this.thisVTransform.position + (-this.thisVTransform.up * 20), -this.thisVTransform.up, 80))
            {
                if ((this.Slope < 1) && (-localV.y > 0))
                {
                    this.Obstacle = true;
                }
            }
            else
            {
                this.Obstacle = false;
            }
        }
        else
        {
            newRot = ((-this.thisVTransform.up * 0.6f) + (-this.thisVTransform.right * 0.3f)).normalized;
            Debug.DrawRay(this.thisVTransform.position + (-this.thisVTransform.up * 20), newRot * 25f, Color.black);
            if (Physics.Raycast(this.thisVTransform.position + (-this.thisVTransform.up * 20), newRot, 25))
            {
                this.TurnLeft = true;
            }
            else
            {
                this.TurnLeft = false;
            }
            newRot = ((-this.thisVTransform.up * 0.6f) + (-this.thisVTransform.right * -0.3f)).normalized;
            Debug.DrawRay(this.thisVTransform.position + (-this.thisVTransform.up * 20), newRot * 25f, Color.black);
            if (Physics.Raycast(this.thisVTransform.position + (-this.thisVTransform.up * 20), newRot, 25))
            {
                this.TurnRight = true;
            }
            else
            {
                this.TurnRight = false;
            }
            Debug.DrawRay(this.thisVTransform.position + (-this.thisVTransform.up * 20), -this.thisVTransform.up * 22f, Color.green);
            if (Physics.Raycast(this.thisVTransform.position + (-this.thisVTransform.up * 20), -this.thisVTransform.up, 22))
            {
                this.Obstacle = false;
                if ((this.Slope < 1) && (-localV.y > 1))
                {
                    this.Obstacle = true;
                }
            }
            else
            {
                this.Obstacle = false;
            }
            if (this.TurnRight && this.TurnLeft)
            {
                newRot = ((-this.thisVTransform.up * 0.6f) + (-this.thisVTransform.right * 0.8f)).normalized;
                Debug.DrawRay(this.thisVTransform.position + (-this.thisVTransform.up * 10), newRot * 20f, Color.black);
                if (Physics.Raycast(this.thisVTransform.position + (-this.thisVTransform.up * 10), newRot, 20))
                {
                    this.Pathfind = false;
                }
                newRot = ((-this.thisVTransform.up * 0.6f) + (-this.thisVTransform.right * -0.8f)).normalized;
                Debug.DrawRay(this.thisVTransform.position + (-this.thisVTransform.up * 10), newRot * 20f, Color.black);
                if (Physics.Raycast(this.thisVTransform.position + (-this.thisVTransform.up * 10), newRot, 20))
                {
                    this.Pathfind = true;
                }
            }
        }
    }

    private Quaternion NewRotation;
    public virtual void FixedUpdate()
    {
        //----------------------------------------------------------------------------------------------------------------------
        if (this.TurnLeft && !this.TurnRight)
        {
            this.vRigidbody.AddTorque(this.thisVTransform.forward * 10000);
        }
        if (this.TurnRight && !this.TurnLeft)
        {
            this.vRigidbody.AddTorque(this.thisVTransform.forward * -10000);
        }
        if (this.TurnRight && this.TurnLeft)
        {
            if (this.Pathfind)
            {
                this.vRigidbody.AddTorque(this.thisVTransform.forward * -10000);
            }
            else
            {
                this.vRigidbody.AddTorque(this.thisVTransform.forward * 10000);
            }
        }
        if (this.Obstacle)
        {
            this.vRigidbody.AddForce(this.thisVTransform.up * 1600);
        }
        if (this.Stuck > 0)
        {
            this.vRigidbody.AddForce(this.thisVTransform.up * 800);
        }
        if ((!this.Spot && (this.Stuck < 1)) && !this.Obstacle)
        {
            this.vRigidbody.AddForce(this.thisVTransform.up * -400);
        }
        //----------------------------------------------------------------------------------------------------------------------
        if (this.target && (this.DangerSense < 1))
        {
            this.NewRotation = Quaternion.LookRotation(this.target.position - this.thisTransform.position);
            this.thisTransform.rotation = Quaternion.RotateTowards(this.thisTransform.rotation, this.NewRotation, Time.deltaTime * 100);
        }
        if ((this.DangerSense > 0) && (this.DangerDirection != Vector3.zero))
        {
            this.NewRotation = Quaternion.LookRotation(this.DangerDirection);
            this.thisTransform.rotation = Quaternion.RotateTowards(this.thisTransform.rotation, this.NewRotation, Time.deltaTime * 100);
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
        if (ON.Contains("TFC"))
        {
            if (!ON.Contains("TFC6"))
            {
                if (!this.Attacking)
                {
                    this.DangerSense = 8;
                    if (other.GetComponent<Rigidbody>())
                    {
                        this.DangerDirection = -other.GetComponent<Rigidbody>().velocity.normalized;
                    }
                }
                if (ON.Contains("TFC0a") && !this.PissedAtTC0a)
                {
                    this.PissedAtTC0a = true;
                }
                if (ON.Contains("TFC1") && !this.PissedAtTC1)
                {
                    this.PissedAtTC1 = true;
                }
                if (ON.Contains("TFC2") && !this.PissedAtTC2)
                {
                    this.PissedAtTC2 = true;
                }
                if (ON.Contains("TFC4") && !this.PissedAtTC4)
                {
                    this.PissedAtTC4 = true;
                }
                if (ON.Contains("TFC5") && !this.PissedAtTC5)
                {
                    this.PissedAtTC5 = true;
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
        if (this.CloseToBase)
        {
            return;
        }
        if (this.PissedAtTC0a)
        {
            if (ON.Contains("TC0a"))
            {
                this.Spot = false;
                this.Hunting = false;
                this.target = OT;
                if (!this.Attacking)
                {
                    this.Attacking = true;
                    this.StopAllCoroutines();
                }
            }
        }
        if (this.PissedAtTC1)
        {
            if (ON.Contains("sTC1") && !this.FoundSmall)
            {
                this.FoundSmall = true;
                this.Spot = false;
                this.Hunting = false;
                this.target = OT;
                if (!this.Attacking)
                {
                    this.Attacking = true;
                    this.StopAllCoroutines();
                }
            }
            if (ON.Contains("mTC1"))
            {
                this.Spot = false;
                this.Hunting = false;
                this.target = OT;
                if (!this.Attacking)
                {
                    this.Attacking = true;
                    this.StopAllCoroutines();
                }
            }
        }
        if (this.PissedAtTC2)
        {
            if (ON.Contains("TC2"))
            {
                this.Spot = false;
                this.Hunting = false;
                this.target = OT;
                if (!this.Attacking)
                {
                    this.Attacking = true;
                    this.StopAllCoroutines();
                }
            }
        }
        if (this.PissedAtTC3)
        {
            if (ON.Contains("TC3"))
            {
                this.Spot = false;
                this.Hunting = false;
                this.target = OT;
                if (!this.Attacking)
                {
                    this.Attacking = true;
                    this.StopAllCoroutines();
                }
            }
        }
        if (this.PissedAtTC4)
        {
            if (ON.Contains("TC4"))
            {
                this.Spot = false;
                this.Hunting = false;
                this.target = OT;
                if (!this.Attacking)
                {
                    this.Attacking = true;
                    this.StopAllCoroutines();
                }
            }
        }
        if (ON.Contains("TC5"))
        {
            this.Spot = false;
            this.Hunting = false;
            this.target = OT;
            if (!this.Attacking)
            {
                this.Attacking = true;
                this.StopAllCoroutines();
            }
        }
        if (this.PissedAtTC7)
        {
            if (ON.Contains("TC7"))
            {
                this.Spot = false;
                this.Hunting = false;
                this.target = OT;
                if (!this.Attacking)
                {
                    this.Attacking = true;
                    this.StopAllCoroutines();
                }
            }
        }
        if (this.PissedAtTC8)
        {
            if (ON.Contains("TC8"))
            {
                this.Spot = false;
                this.Hunting = false;
                this.target = OT;
                if (!this.Attacking)
                {
                    this.Attacking = true;
                    this.StopAllCoroutines();
                }
            }
        }
        if (this.PissedAtTC9)
        {
            if (ON.Contains("TC9"))
            {
                this.Spot = false;
                this.Hunting = false;
                this.target = OT;
                if (!this.Attacking)
                {
                    this.Attacking = true;
                    this.StopAllCoroutines();
                }
            }
        }
    }

    public virtual void Targety()
    {
        if (!this.Spot && !this.Attacking)
        {
            this.StartCoroutine(this.TargetArea());
        }
    }

    public virtual IEnumerator TargetArea()
    {
        this.Hunting = false;
        this.Spot = false;
        this.target = this.Waypoint;
        yield return new WaitForSeconds(20);
        this.target = this.ResetView;
        this.Spot = false;
        this.Hunting = true;
    }

    public virtual void Regenerator()
    {
        RaycastHit hit1 = default(RaycastHit);
        RaycastHit hit2 = default(RaycastHit);
        this.Tick = false;
        Vector3 Point1u = new Vector3();
        Vector3 Point1d = new Vector3();
        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.up * 0.5f), -this.thisVTransform.up * 200f, Color.white);
        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.up * 0.5f), -this.thisVTransform.up, out hit1, 200, (int) this.targetLayers))
        {
            Point1u = hit1.point;
        }
        Debug.DrawRay(this.thisTransform.position + (-this.thisTransform.up * 0.5f), -this.thisVTransform.up * 200f, Color.white);
        if (Physics.Raycast(this.thisTransform.position + (-this.thisTransform.up * 0.5f), -this.thisVTransform.up, out hit2, 200, (int) this.targetLayers))
        {
            Point1d = hit2.point;
        }
        if (Vector3.Distance(Point1u, Point1d) > 3)
        {
            this.Slope = 2;
            this.Obstacle = false;
            this.TurnRight = false;
            this.TurnLeft = false;
            Point1d = new Vector3(0.1f, 0.1f, 0.1f);
            Point1u = new Vector3(0.1f, 0.1f, 0.1f);
        }
        if (this.TurnRight || this.TurnLeft)
        {
            this.Rotator.TurnedOff = true;
        }
        if (!this.TurnRight && !this.TurnLeft)
        {
            this.Rotator.TurnedOff = false;
        }
        if (this.JustNoticed > 0)
        {
            this.Rotator.TurnedOff = false;
        }
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
        if (AbiaSyndicateNetwork.TC1CriminalLevel > 0)
        {
            this.PissedAtTC1 = true;
        }
        if (AbiaSyndicateNetwork.TC2CriminalLevel > 0)
        {
            this.PissedAtTC2 = true;
        }
        if (AbiaSyndicateNetwork.TC4CriminalLevel > 0)
        {
            this.PissedAtTC4 = true;
        }
        if (AbiaSyndicateNetwork.TC5CriminalLevel > 0)
        {
            this.PissedAtTC5 = true;
        }
        if (AbiaSyndicateNetwork.TC7CriminalLevel > 0)
        {
            this.PissedAtTC7 = true;
        }
        if (AbiaSyndicateNetwork.TC8CriminalLevel > 0)
        {
            this.PissedAtTC8 = true;
        }
        if (AbiaSyndicateNetwork.TC9CriminalLevel > 0)
        {
            this.PissedAtTC9 = true;
        }
        if (this.target)
        {
            if (Vector3.Distance(this.thisTransform.position, this.target.transform.position) > 100)
            {
                this.Rotator.RotateThreshold = 0.1f;
            }
            else
            {
                this.Rotator.RotateThreshold = 0.5f;
            }
        }
        if (this.Attacking)
        {
            this.Trig.center = new Vector3(0, 0, 0);
            this.Trig.radius = 100;
            this.Trig.height = 100;
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
            this.Trig.center = new Vector3(0, 0, 200);
            this.Trig.radius = 200;
            this.Trig.height = 800;
        }
        if (this.DangerSense > 0)
        {
            if (this.DangerSense < 2)
            {
                this.target = this.ResetView;
            }
            this.DangerSense = this.DangerSense - 1;
        }
        if (this.Stuck > 0)
        {
            this.Stuck = this.Stuck - 1;
        }
        if (this.JustNoticed > 0)
        {
            this.JustNoticed = this.JustNoticed - 1;
        }
        if (this.Slope > 0)
        {
            this.Slope = this.Slope - 1;
        }
        if (!this.Attacking)
        {
            this.FoundSmall = false;
        }
        if (this.target)
        {
            if (Vector3.Distance(this.thisTransform.position, this.target.transform.position) > 1000)
            {
                this.Attacking = false;
                this.Hunting = true;
                this.target = this.ResetView;
            }
        }
        this.Obstacle = false;
    }

    public virtual void LeaveMarker()
    {
        Vector3 lastPos = this.thisTransform.position;
        this.StartCoroutine(this.IsEscaping(lastPos));
    }

    public virtual IEnumerator IsEscaping(Vector3 lastPos)
    {
        yield return new WaitForSeconds(2);
        if (Vector3.Distance(this.thisTransform.position, lastPos) < 1)
        {
            this.Stuck = 2;
        }
    }

    public virtual void Start()
    {
        this.InvokeRepeating("Regenerator", 5, 1);
        this.InvokeRepeating("LeaveMarker", 5, 10);
        this.InvokeRepeating("Targety", 300, 300);
    }

    public AkbarCorvetteAI()
    {
        this.Spot = true;
    }

}