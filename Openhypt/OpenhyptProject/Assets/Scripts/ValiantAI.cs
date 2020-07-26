using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ValiantAI : MonoBehaviour
{
    public Transform target;
    public Transform ResetView;
    public Transform Waypoint2;
    public Transform Waypoint3;
    public GameObject Gyro;
    public GameObject Hoverer;
    public CapsuleCollider Trig;
    public BigVesselRotator Turner;
    public TurretAI Turret;
    public DozerScript Dozer;
    public CarDoorController vEntrance;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public Blinker Blinker1;
    public Blinker Blinker2;
    public Blinker Blinker3;
    public Blinker Blinker4;
    public Blinker Blinker5;
    public GameObject Presence;
    public GameObject SpotSound;
    public GameObject AttackSound;
    public GameObject Buzzer1Sound;
    public GameObject Buzzer2Sound;
    public int PissedAtTC0a;
    public int PissedAtTC1;
    public int PissedAtTC4;
    public int PissedAtTC5;
    public int PissedAtTC6;
    public int PissedAtTC7;
    public int PissedAtTC8;
    public int PissedAtTC9;
    public Transform Fear;
    public bool TargetIsMoving;
    public bool SlowDown;
    public bool Parked;
    public bool Hunting;
    public bool Attacking;
    public bool Obstacle;
    public bool Stuck;
    public bool Cruising;
    public bool TurnRight;
    public bool TurnLeft;
    public float RightDist;
    public float LeftDist;
    public bool IsClose;
    public bool Wall;
    public Vector3 lastPos;
    public int DangerSense;
    public LayerMask targetLayers;
    public LayerMask MtargetLayers;
    public int LayingLow;
    public int JustNoticed;
    public int Ogle;
    public int Shots;
    public int TForce;
    public float RUP;
    public virtual void Start()
    {
        this.InvokeRepeating("Tick", 1, 1);
        this.InvokeRepeating("Buzzer", 1, 2);
        this.InvokeRepeating("Targety", 10, 15);
        this.InvokeRepeating("Shooty", 5, 0.3f);
        this.Hunting = true;
        this.Waypoint3 = PlayerInformation.instance.Pirizuka;
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        RaycastHit hit1 = default(RaycastHit);
        RaycastHit hit2 = default(RaycastHit);
        Vector3 localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
        if (this.Attacking)
        {
            if (this.target)
            {
                if ((Vector3.Distance(this.thisTransform.position, this.target.transform.position) < 64) && !this.target.name.Contains("TC4"))
                {
                    if (-localV.y > 0)
                    {
                        this.IsClose = true;
                    }
                    this.Stuck = false;
                }
                else
                {
                    this.IsClose = false;
                }
            }
        }
        if ((this.target == this.ResetView) && this.Attacking)
        {
            this.Attacking = false;
            this.target = this.ResetView;
        }
        if ((this.target == this.Waypoint2) && this.Attacking)
        {
            this.Attacking = false;
            this.target = this.ResetView;
        }
        if ((this.target == this.Waypoint3) && this.Attacking)
        {
            this.Attacking = false;
            this.target = this.ResetView;
        }
        if ((this.target == null) && this.Attacking)
        {
            this.Attacking = false;
            this.Hunting = true;
            this.BlinkerOff();
            this.target = this.ResetView;
        }
        Vector3 newRot2 = this.vRigidbody.velocity;
        if (this.RUP < 4)
        {
            this.RUP = this.RUP + 0.5f;
        }
        else
        {
            this.RUP = 0;
        }
        Vector3 Point1u, Point1d;
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.up * 0.5f)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward * 150f, Color.white);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.up * 0.5f)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward, out hit1, 150, (int) this.MtargetLayers))
        {
            Point1u = hit1.point;
        }
        else
        {
            Point1u = new Vector3(2, 2, 2);
        }
        Debug.DrawRay((this.thisTransform.position + (-this.thisTransform.up * 0.5f)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward * 150f, Color.white);
        if (Physics.Raycast((this.thisTransform.position + (-this.thisTransform.up * 0.5f)) + (this.thisTransform.up * this.RUP), this.thisTransform.forward, out hit2, 150, (int) this.MtargetLayers))
        {
            Point1d = hit2.point;
        }
        else
        {
            Point1d = new Vector3(8, 8, 8);
        }
        if (Vector3.Distance(Point1u, Point1d) > 2)
        {
            this.TurnRight = false;
            this.TurnLeft = false;
        }
        else
        {
            this.Wall = true;
        }
        this.Obstacle = false;
        if (this.vRigidbody.velocity.magnitude > 10)
        {
            Debug.DrawRay(this.thisTransform.position, newRot2 * 80f, Color.green);
            if (Physics.Raycast(this.thisTransform.position, newRot2, out hit, 80, (int) this.targetLayers))
            {
                if (this.Wall)
                {
                    this.Obstacle = true;
                }
            }
            Debug.DrawRay(this.thisTransform.position + (this.thisTransform.right * 4), newRot2 * 80f, Color.green);
            if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.right * 4), newRot2, out hit, 80, (int) this.targetLayers))
            {
                if (this.Wall)
                {
                    this.Obstacle = true;
                }
            }
            Debug.DrawRay(this.thisTransform.position + (-this.thisTransform.right * 4), newRot2 * 80f, Color.green);
            if (Physics.Raycast(this.thisTransform.position + (-this.thisTransform.right * 4), newRot2, out hit, 80, (int) this.targetLayers))
            {
                if (this.Wall)
                {
                    this.Obstacle = true;
                }
            }
        }
        else
        {
            Debug.DrawRay(this.thisTransform.position, this.thisTransform.forward * 30f, Color.white);
            if (Physics.Raycast(this.thisTransform.position, this.thisTransform.forward, 30, (int) this.targetLayers))
            {
                if (this.Wall)
                {
                    this.Obstacle = true;
                }
            }
            Debug.DrawRay(this.thisTransform.position + (this.thisTransform.right * 4), this.thisTransform.forward * 30f, Color.white);
            if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.right * 4), this.thisTransform.forward, 30, (int) this.targetLayers))
            {
                if (this.Wall)
                {
                    this.Obstacle = true;
                }
            }
            Debug.DrawRay(this.thisTransform.position + (-this.thisTransform.right * 4), this.thisTransform.forward * 30f, Color.white);
            if (Physics.Raycast(this.thisTransform.position + (-this.thisTransform.right * 4), this.thisTransform.forward, 30, (int) this.targetLayers))
            {
                if (this.Wall)
                {
                    this.Obstacle = true;
                }
            }
        }
        if (this.vRigidbody.velocity.magnitude > 30)
        {
            Debug.DrawRay(this.thisTransform.position + (this.thisTransform.right * 7), this.thisTransform.forward * 80f, Color.black);
            if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.right * 7), this.thisTransform.forward, out hit, 80))
            {
                this.RightDist = hit.distance;
            }
            else
            {
                this.RightDist = 512;
            }
            Debug.DrawRay(this.thisTransform.position + (-this.thisTransform.right * 7), this.thisTransform.forward * 80f, Color.black);
            if (Physics.Raycast(this.thisTransform.position + (-this.thisTransform.right * 7), this.thisTransform.forward, out hit, 80))
            {
                this.LeftDist = hit.distance;
            }
            else
            {
                this.LeftDist = 512;
            }
            Debug.DrawRay((this.thisTransform.position + (this.thisTransform.up * 10)) + (this.thisTransform.forward * 85), this.thisTransform.up * -30f, Color.white);
            if (!Physics.Raycast((this.thisTransform.position + (this.thisTransform.up * 10)) + (this.thisTransform.forward * 85), -this.thisTransform.up, 30))
            {
                this.Obstacle = true;
            }
            //---------------------------------------------------------------------------------------------
            Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.up * 10)) + (this.thisTransform.right * 20)) + (this.thisTransform.forward * 60), this.thisTransform.up * -30f, Color.white);
            if (!Physics.Raycast(((this.thisTransform.position + (this.thisTransform.up * 10)) + (this.thisTransform.right * 20)) + (this.thisTransform.forward * 60), -this.thisTransform.up, out hit, 30))
            {
                this.TurnLeft = true;
            }
            Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.up * 10)) + (-this.thisTransform.right * 20)) + (this.thisTransform.forward * 60), this.thisTransform.up * -30f, Color.white);
            if (!Physics.Raycast(((this.thisTransform.position + (this.thisTransform.up * 10)) + (-this.thisTransform.right * 20)) + (this.thisTransform.forward * 60), -this.thisTransform.up, out hit, 30))
            {
                this.TurnRight = true;
            }
        }
        else
        {
            //---------------------------------------------------------------------------------------------
            Debug.DrawRay(this.thisTransform.position + (this.thisTransform.right * 7), this.thisTransform.forward * 40f, Color.black);
            if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.right * 7), this.thisTransform.forward, out hit, 40))
            {
                this.RightDist = hit.distance;
            }
            else
            {
                this.RightDist = 512;
            }
            Debug.DrawRay(this.thisTransform.position + (-this.thisTransform.right * 7), this.thisTransform.forward * 40f, Color.black);
            if (Physics.Raycast(this.thisTransform.position + (-this.thisTransform.right * 7), this.thisTransform.forward, out hit, 40))
            {
                this.LeftDist = hit.distance;
            }
            else
            {
                this.LeftDist = 512;
            }
            Debug.DrawRay((this.thisTransform.position + (this.thisTransform.up * 10)) + (this.thisTransform.forward * 45), this.thisTransform.up * -30f, Color.white);
            if (!Physics.Raycast((this.thisTransform.position + (this.thisTransform.up * 10)) + (this.thisTransform.forward * 45), -this.thisTransform.up, 30))
            {
                this.Obstacle = true;
            }
            //---------------------------------------------------------------------------------------------
            Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.up * 10)) + (this.thisTransform.right * 20)) + (this.thisTransform.forward * 30), this.thisTransform.up * -30f, Color.white);
            if (!Physics.Raycast(((this.thisTransform.position + (this.thisTransform.up * 10)) + (this.thisTransform.right * 20)) + (this.thisTransform.forward * 30), -this.thisTransform.up, 30))
            {
                this.TurnLeft = true;
            }
            Debug.DrawRay(((this.thisTransform.position + (this.thisTransform.up * 10)) + (-this.thisTransform.right * 20)) + (this.thisTransform.forward * 30), this.thisTransform.up * -30f, Color.white);
            if (!Physics.Raycast(((this.thisTransform.position + (this.thisTransform.up * 10)) + (-this.thisTransform.right * 20)) + (this.thisTransform.forward * 30), -this.thisTransform.up, 30))
            {
                this.TurnRight = true;
            }
        }
        //---------------------------------------------------------------------------------------------
        if ((this.RightDist > this.LeftDist) && (this.JustNoticed < 1))
        {
            this.Turner.TorqueForce = 0;
            this.TurnRight = true;
        }
        if ((this.LeftDist > this.RightDist) && (this.JustNoticed < 1))
        {
            this.Turner.TorqueForce = 0;
            this.TurnLeft = true;
        }
        if (this.Stuck)
        {
            this.TurnRight = true;
        }
        if (((CallAssistance.IsAssisting && !this.Attacking) && (this.Ogle < 1)) && (this.PissedAtTC1 == 0))
        {
            if (Vector3.Distance(this.thisTransform.position, this.Waypoint3.transform.position) > 70)
            {
                this.target = this.Waypoint3;
                if (Vector3.Distance(this.thisTransform.position, this.Waypoint3.transform.position) < 100)
                {
                    this.Turner.RotateThreshold = 0.8f;
                }
                if (Vector3.Distance(this.thisTransform.position, this.Waypoint3.transform.position) > 100)
                {
                    this.Turner.RotateThreshold = 0.1f;
                }
            }
            else
            {
                this.target = this.ResetView;
                this.Obstacle = true;
            }
        }
    }

    private Quaternion NewRotation;
    public virtual void FixedUpdate()
    {
        Vector3 newRot2 = this.vRigidbody.velocity;
        Vector3 localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
        if (this.IsClose)
        {
            this.vRigidbody.AddForce(this.thisVTransform.up * 100);
        }
        if (this.Obstacle || this.Parked)
        {
            if (this.Ogle < 1)
            {
                if (-localV.y > 5)
                {
                    this.vRigidbody.AddForce(this.thisVTransform.up * 100);
                    if (this.SlowDown)
                    {
                        this.vRigidbody.AddForce(newRot2 * -5);
                    }
                    else
                    {
                        this.vRigidbody.AddForce(newRot2 * -10);
                    }
                }
            }
            if (this.Ogle > 1)
            {
                if (-localV.y > 0)
                {
                    this.vRigidbody.AddForce(this.thisVTransform.up * 100);
                    if (this.SlowDown)
                    {
                        this.vRigidbody.AddForce(newRot2 * -5);
                    }
                    else
                    {
                        this.vRigidbody.AddForce(newRot2 * -10);
                    }
                }
            }
        }
        if (this.SlowDown)
        {
            if (-localV.y > 10)
            {
                this.vRigidbody.AddForce(newRot2 * -5);
            }
        }
        else
        {
            if (this.Stuck)
            {
                if (localV.y < 20)
                {
                    this.vRigidbody.AddForce(this.thisVTransform.up * 100);
                }
            }
            else
            {
                if (this.Attacking && !this.Obstacle)
                {
                    if (-localV.y < 100)
                    {
                        this.vRigidbody.AddForce(this.thisVTransform.up * -100);
                    }
                }
            }
            if (((!this.Attacking && !this.Stuck) && !this.Obstacle) && !this.IsClose)
            {
                if (!this.Obstacle)
                {
                    if (-localV.y < 50)
                    {
                        this.vRigidbody.AddForce(this.thisVTransform.up * -100);
                    }
                }
                if (this.Obstacle)
                {
                    if (-localV.y < 10)
                    {
                        this.vRigidbody.AddForce(this.thisVTransform.up * -100);
                    }
                }
            }
        }
        if (this.TurnLeft && !this.TurnRight)
        {
            this.Gyro.GetComponent<Rigidbody>().AddTorque(this.thisTransform.up * -500);
        }
        if (this.TurnRight && !this.TurnLeft)
        {
            this.Gyro.GetComponent<Rigidbody>().AddTorque(this.thisTransform.up * 500);
        }
        if ((this.TurnRight && this.TurnLeft) && this.Obstacle)
        {
            this.Gyro.GetComponent<Rigidbody>().AddTorque(this.thisTransform.up * -500);
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        string ON = other.name;
        Transform OT = other.transform;
        if (ON.Contains("TFC"))
        {
            if (!ON.Contains("TFC3"))
            {
                if (ON.Contains("TFC0a"))
                {
                    if (this.target)
                    {
                        if (this.target.name.Contains("TC0a"))
                        {
                            this.Shots = 4;
                        }
                    }
                    this.PissedAtTC0a = 1;
                }
                if (ON.Contains("TFC1"))
                {
                    if (this.target)
                    {
                        if (this.target.name.Contains("TC1"))
                        {
                            this.Shots = 4;
                            this.Ogle = 0;
                        }
                    }
                    if (this.PissedAtTC1 < 3)
                    {
                        this.PissedAtTC1 = 1;
                    }
                    if (TerrahyptianNetwork.TC1CriminalLevel == 10)
                    {
                        this.PissedAtTC1 = 2;
                    }
                }
                if (ON.Contains("TFC4"))
                {
                    if (this.target)
                    {
                        if (this.target.name.Contains("TC4"))
                        {
                            this.Shots = 4;
                        }
                    }
                    if (this.PissedAtTC4 < 3)
                    {
                        this.PissedAtTC4 = 1;
                    }
                    if (TerrahyptianNetwork.TC4CriminalLevel == 10)
                    {
                        this.PissedAtTC4 = 2;
                    }
                }
                if (ON.Contains("TFC5"))
                {
                    if (this.target)
                    {
                        if (this.target.name.Contains("TC5"))
                        {
                            this.Shots = 4;
                        }
                    }
                    if (this.PissedAtTC5 < 3)
                    {
                        this.PissedAtTC5 = 1;
                    }
                    if (TerrahyptianNetwork.TC5CriminalLevel == 10)
                    {
                        this.PissedAtTC5 = 2;
                    }
                }
                if (ON.Contains("TFC6"))
                {
                    if (this.target)
                    {
                        if (this.target.name.Contains("TC6"))
                        {
                            this.Shots = 4;
                        }
                    }
                    if (this.PissedAtTC6 < 3)
                    {
                        this.PissedAtTC6 = 1;
                    }
                    if (TerrahyptianNetwork.TC6CriminalLevel == 10)
                    {
                        this.PissedAtTC6 = 2;
                    }
                }
                if (ON.Contains("TFC7"))
                {
                    if (this.target)
                    {
                        if (this.target.name.Contains("TC7"))
                        {
                            this.Shots = 4;
                        }
                    }
                    if (this.PissedAtTC7 < 3)
                    {
                        this.PissedAtTC7 = 1;
                    }
                    if (TerrahyptianNetwork.TC7CriminalLevel == 10)
                    {
                        this.PissedAtTC7 = 2;
                    }
                }
                if (ON.Contains("TFC8"))
                {
                    if (this.target)
                    {
                        if (this.target.name.Contains("TC8"))
                        {
                            this.Shots = 4;
                        }
                    }
                    if (this.PissedAtTC8 < 3)
                    {
                        this.PissedAtTC8 = 1;
                    }
                    if (TerrahyptianNetwork.TC8CriminalLevel == 10)
                    {
                        this.PissedAtTC8 = 2;
                    }
                }
                if (ON.Contains("TFC9"))
                {
                    if (this.target)
                    {
                        if (this.target.name.Contains("TC9"))
                        {
                            this.Shots = 4;
                        }
                    }
                    if (this.PissedAtTC9 < 3)
                    {
                        this.PissedAtTC9 = 1;
                    }
                    if (TerrahyptianNetwork.TC9CriminalLevel == 10)
                    {
                        this.PissedAtTC9 = 2;
                    }
                }
                if (!this.Attacking)
                {
                    this.DangerSense = 8;
                    this.target = this.Waypoint2;
                    if (other.GetComponent<Rigidbody>())
                    {
                        this.Waypoint2.transform.position = OT.position;
                    }
                    if (this.Ogle > 3)
                    {
                        this.Ogle = 3;
                        this.StartCoroutine(this.Excuse());
                    }
                }
            }
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        string ON = other.name;
        Transform OT = other.transform;
        if (other != null)
        {
            if (!ON.Contains("x"))
            {
                if (Physics.Linecast(this.thisTransform.position, OT.position, (int) this.MtargetLayers))
                {
                    return;
                }
            }
            if (this.target)
            {
                if (ON.Contains("TC2") && this.Attacking)
                {
                    if (!ON.Contains("tTC"))
                    {
                        if (Vector3.Distance(OT.position, this.target.position) < 256)
                        {
                            this.Fear = OT;
                        }
                    }
                }
            }
            if (ON.Contains("TC0a") && (this.PissedAtTC0a > 0))
            {
                if (this.Attacking && (this.PissedAtTC0a > 1))
                {
                    this.target = OT;
                }
                if (!this.Attacking)
                {
                    if (this.PissedAtTC0a > 1)
                    {
                        if (this.PissedAtTC0a == 2)
                        {
                            GameObject TheThing1 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                            TheThing1.transform.parent = this.thisTransform;
                        }
                        this.target = OT;
                        this.Attacking = true;
                        this.Hunting = false;
                        this.BlinkerOn();
                        this.Ogle = 0;
                        this.Shots = 0;
                        this.PissedAtTC0a = 1;
                    }
                    if ((this.PissedAtTC0a == 1) && (this.Ogle < 1))
                    {
                        this.Hunting = false;
                        GameObject TheThing2 = UnityEngine.Object.Instantiate(this.SpotSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                        TheThing2.transform.parent = this.thisTransform;
                        this.target = OT;
                        this.BlinkerOn();
                        this.StartCoroutine(this.Excuse());
                        this.Ogle = 3;
                    }
                }
            }
            if (ON.Contains("TC1") && (this.PissedAtTC1 > 0))
            {
                if (this.Attacking && (this.PissedAtTC1 > 1))
                {
                    this.target = OT;
                }
                if (!this.Attacking)
                {
                    if (this.PissedAtTC1 > 1)
                    {
                        if (this.PissedAtTC1 == 2)
                        {
                            GameObject TheThing3 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                            TheThing3.transform.parent = this.thisTransform;
                        }
                        this.target = OT;
                        this.Attacking = true;
                        this.Hunting = false;
                        this.BlinkerOn();
                        this.Ogle = 0;
                        this.Shots = 0;
                        this.PissedAtTC1 = 1;
                    }
                    if ((this.PissedAtTC1 == 1) && (this.Ogle < 1))
                    {
                        this.Hunting = false;
                        GameObject TheThing4 = UnityEngine.Object.Instantiate(this.SpotSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                        TheThing4.transform.parent = this.thisTransform;
                        this.target = OT;
                        this.BlinkerOn();
                        this.StartCoroutine(this.Excuse());
                        this.Ogle = 3;
                    }
                }
            }
            if (ON.Contains("TC4") && (this.PissedAtTC4 > 0))
            {
                if (this.Attacking && (this.PissedAtTC4 > 1))
                {
                    this.target = OT;
                }
                if (!this.Attacking)
                {
                    if (this.PissedAtTC4 > 1)
                    {
                        if (this.PissedAtTC4 == 2)
                        {
                            GameObject TheThing5 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                            TheThing5.transform.parent = this.thisTransform;
                        }
                        this.target = OT;
                        this.Attacking = true;
                        this.Hunting = false;
                        this.BlinkerOn();
                        this.Ogle = 0;
                        this.Shots = 0;
                        this.PissedAtTC4 = 1;
                    }
                    if ((this.PissedAtTC4 == 1) && (this.Ogle < 1))
                    {
                        this.Hunting = false;
                        GameObject TheThing6 = UnityEngine.Object.Instantiate(this.SpotSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                        TheThing6.transform.parent = this.thisTransform;
                        this.target = OT;
                        this.BlinkerOn();
                        this.StartCoroutine(this.Excuse());
                        this.Ogle = 3;
                    }
                }
            }
            if (ON.Contains("TC5") && (this.PissedAtTC5 > 0))
            {
                if (this.Attacking && (this.PissedAtTC5 > 1))
                {
                    this.target = OT;
                }
                if (!this.Attacking)
                {
                    if (this.PissedAtTC5 > 1)
                    {
                        if (this.PissedAtTC5 == 2)
                        {
                            GameObject TheThing7 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                            TheThing7.transform.parent = this.thisTransform;
                        }
                        this.target = OT;
                        this.Attacking = true;
                        this.Hunting = false;
                        this.BlinkerOn();
                        this.Ogle = 0;
                        this.Shots = 0;
                        this.PissedAtTC5 = 1;
                    }
                    if ((this.PissedAtTC5 == 1) && (this.Ogle < 1))
                    {
                        this.Hunting = false;
                        GameObject TheThing8 = UnityEngine.Object.Instantiate(this.SpotSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                        TheThing8.transform.parent = this.thisTransform;
                        this.target = OT;
                        this.BlinkerOn();
                        this.StartCoroutine(this.Excuse());
                        this.Ogle = 3;
                    }
                }
            }
            if (ON.Contains("TC6") && (this.PissedAtTC6 > 0))
            {
                if (this.Attacking && (this.PissedAtTC6 > 1))
                {
                    this.target = OT;
                }
                if (!this.Attacking)
                {
                    if (this.PissedAtTC6 > 1)
                    {
                        if (this.PissedAtTC6 == 2)
                        {
                            GameObject TheThing9 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                            TheThing9.transform.parent = this.thisTransform;
                        }
                        this.target = OT;
                        this.Attacking = true;
                        this.Hunting = false;
                        this.BlinkerOn();
                        this.Ogle = 0;
                        this.Shots = 0;
                        this.PissedAtTC6 = 1;
                    }
                    if ((this.PissedAtTC6 == 1) && (this.Ogle < 1))
                    {
                        this.Hunting = false;
                        GameObject TheThing10 = UnityEngine.Object.Instantiate(this.SpotSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                        TheThing10.transform.parent = this.thisTransform;
                        this.target = OT;
                        this.BlinkerOn();
                        this.StartCoroutine(this.Excuse());
                        this.Ogle = 3;
                    }
                }
            }
            if (ON.Contains("TC7") && (this.PissedAtTC7 > 0))
            {
                if (this.Attacking && (this.PissedAtTC7 > 1))
                {
                    this.target = OT;
                }
                if (!this.Attacking)
                {
                    if (this.PissedAtTC7 > 1)
                    {
                        if (this.PissedAtTC7 == 2)
                        {
                            GameObject TheThing11 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                            TheThing11.transform.parent = this.thisTransform;
                        }
                        this.target = OT;
                        this.Attacking = true;
                        this.Hunting = false;
                        this.BlinkerOn();
                        this.Ogle = 0;
                        this.Shots = 0;
                        this.PissedAtTC7 = 1;
                    }
                    if ((this.PissedAtTC7 == 1) && (this.Ogle < 1))
                    {
                        this.Hunting = false;
                        GameObject TheThing12 = UnityEngine.Object.Instantiate(this.SpotSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                        TheThing12.transform.parent = this.thisTransform;
                        this.target = OT;
                        this.BlinkerOn();
                        this.StartCoroutine(this.Excuse());
                        this.Ogle = 3;
                    }
                }
            }
            if (ON.Contains("TC8") && (this.PissedAtTC8 > 0))
            {
                if (this.Attacking && (this.PissedAtTC8 > 1))
                {
                    this.target = OT;
                }
                if (!this.Attacking)
                {
                    if (this.PissedAtTC8 > 1)
                    {
                        if (this.PissedAtTC8 == 2)
                        {
                            GameObject TheThing13 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                            TheThing13.transform.parent = this.thisTransform;
                        }
                        this.target = OT;
                        this.Attacking = true;
                        this.Hunting = false;
                        this.BlinkerOn();
                        this.Ogle = 0;
                        this.Shots = 0;
                        this.PissedAtTC8 = 1;
                    }
                    if ((this.PissedAtTC8 == 1) && (this.Ogle < 1))
                    {
                        this.Hunting = false;
                        GameObject TheThing14 = UnityEngine.Object.Instantiate(this.SpotSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                        TheThing14.transform.parent = this.thisTransform;
                        this.target = OT;
                        this.BlinkerOn();
                        this.StartCoroutine(this.Excuse());
                        this.Ogle = 3;
                    }
                }
            }
            if (ON.Contains("TC9") && (this.PissedAtTC9 > 0))
            {
                if (this.Attacking && (this.PissedAtTC9 > 1))
                {
                    this.target = OT;
                }
                if (!this.Attacking)
                {
                    if (this.PissedAtTC9 > 1)
                    {
                        if (this.PissedAtTC9 == 2)
                        {
                            GameObject TheThing15 = UnityEngine.Object.Instantiate(this.AttackSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                            TheThing15.transform.parent = this.thisTransform;
                        }
                        this.target = OT;
                        this.Attacking = true;
                        this.Hunting = false;
                        this.BlinkerOn();
                        this.Ogle = 0;
                        this.Shots = 0;
                        this.PissedAtTC9 = 1;
                    }
                    if ((this.PissedAtTC9 == 1) && (this.Ogle < 1))
                    {
                        this.Hunting = false;
                        GameObject TheThing16 = UnityEngine.Object.Instantiate(this.SpotSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                        TheThing16.transform.parent = this.thisTransform;
                        this.target = OT;
                        this.BlinkerOn();
                        this.StartCoroutine(this.Excuse());
                        this.Ogle = 3;
                    }
                }
            }
        }
    }

    public virtual void BlinkerOn()
    {
        this.Blinker1.DeActivated = false;
        this.Blinker2.DeActivated = false;
        this.Blinker3.DeActivated = false;
        this.Blinker4.DeActivated = false;
        this.Blinker5.DeActivated = false;
    }

    public virtual void BlinkerOff()
    {
        this.Blinker1.DeActivated = true;
        this.Blinker2.DeActivated = true;
        this.Blinker3.DeActivated = true;
        this.Blinker4.DeActivated = true;
        this.Blinker5.DeActivated = true;
    }

    public virtual void Buzzer()
    {
        if (((this.Attacking && this.TargetIsMoving) && (this.LayingLow < 1)) && (this.Shots < 1))
        {
            int randomValue = Random.Range(1, 4);
            switch (randomValue)
            {
                case 1:
                    GameObject TheThingB1 = UnityEngine.Object.Instantiate(this.Buzzer1Sound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                    TheThingB1.transform.parent = this.thisTransform;
                    break;
                case 2:
                    GameObject TheThingB2 = UnityEngine.Object.Instantiate(this.Buzzer2Sound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                    TheThingB2.transform.parent = this.thisTransform;
                    break;
            }
        }
    }

    public virtual void Shooty()
    {
        if ((this.Attacking && (this.Shots > 0)) && (this.LayingLow < 1))
        {
            this.Shots = this.Shots - 1;
            if (this.target)
            {
                this.Turret.NameOfTarget = this.target.name;
            }
            this.Turret.Attacking = true;
        }
        else
        {
            this.Turret.NameOfTarget = "null";
            this.Turret.Attacking = false;
        }
    }

    public virtual void Targety()
    {
        if (!this.Attacking && (this.Ogle < 1))
        {
            this.StartCoroutine(this.TargetArea());
        }
    }

    public virtual IEnumerator TargetArea()
    {
        this.Waypoint2.transform.position = TerrahyptianNetwork.instance.PriorityWaypoint.position;
        this.target = this.Waypoint2;
        yield return new WaitForSeconds(5);
        if (!this.Attacking && (this.Ogle < 1))
        {
            this.target = this.ResetView;
        }
    }

    public virtual void Tick()
    {
        if (this.Attacking)
        {
            if (this.target != null)
            {
                if (!Physics.Linecast(this.thisTransform.position, this.target.position, (int) this.MtargetLayers))
                {
                    this.TurnRight = false;
                    this.TurnLeft = false;
                    this.JustNoticed = 2;
                }
                if (Vector3.Distance(this.thisTransform.position, this.target.position) > 100)
                {
                    this.Turner.RotateThreshold = 0.1f;
                }
                else
                {
                    this.Turner.RotateThreshold = 0.8f;
                }
            }
        }
        else
        {
            if (this.DangerSense > 0)
            {
                this.Turner.RotateThreshold = 0.1f;
            }
            else
            {
                this.Turner.RotateThreshold = 0.8f;
            }
        }
        if (this.target)
        {
            if (this.target.name.Contains("TC0a") && (TerrahyptianNetwork.TC0aCriminalLevel > 10))
            {
                this.Shots = 4;
            }
            if (this.target.name.Contains("TC1") && (TerrahyptianNetwork.TC1CriminalLevel > 10))
            {
                this.Shots = 4;
            }
            if (this.target.name.Contains("TC4") && (TerrahyptianNetwork.TC4CriminalLevel > 10))
            {
                this.Shots = 4;
            }
            if (this.target.name.Contains("TC5") && (TerrahyptianNetwork.TC5CriminalLevel > 10))
            {
                this.Shots = 4;
            }
            if (this.target.name.Contains("TC6") && (TerrahyptianNetwork.TC6CriminalLevel > 10))
            {
                this.Shots = 4;
            }
            if (this.target.name.Contains("TC7") && (TerrahyptianNetwork.TC7CriminalLevel > 10))
            {
                this.Shots = 4;
            }
            if (this.target.name.Contains("TC8") && (TerrahyptianNetwork.TC8CriminalLevel > 10))
            {
                this.Shots = 4;
            }
            if (this.target.name.Contains("TC9") && (TerrahyptianNetwork.TC9CriminalLevel > 10))
            {
                this.Shots = 4;
            }
            if (this.target.name.Contains("sTC"))
            {
                if (Vector3.Distance(this.thisTransform.position, this.target.position) < 100)
                {
                    this.SlowDown = true;
                }
                if (Vector3.Distance(this.thisTransform.position, this.target.position) > 100)
                {
                    this.SlowDown = false;
                }
            }
            else
            {
                this.SlowDown = false;
            }
            if (this.target.name.Contains("sTC4"))
            {
                if (Vector3.Distance(this.thisTransform.position, this.target.position) < 100)
                {
                    this.Dozer.IsOn = true;
                }
                if (Vector3.Distance(this.thisTransform.position, this.target.position) > 100)
                {
                    this.Dozer.IsOn = false;
                }
            }
            if (!this.target.name.Contains("sTC4"))
            {
                this.Dozer.IsOn = false;
            }
            if (this.Ogle > 0)
            {
                if (Vector3.Distance(this.thisTransform.position, this.target.position) < 64)
                {
                    this.Parked = true;
                    this.Ogle = this.Ogle - 1;
                }
                else
                {
                    this.Parked = false;
                }
            }
            else
            {
                this.Parked = false;
            }
            if (TerrahyptianNetwork.TC1CriminalLevel > 480)
            {
                if (this.target.name.Contains("C1"))
                {
                    TerrahyptianNetwork.AlertLVL2 = 1;
                }
            }
            if (TerrahyptianNetwork.TC4CriminalLevel > 480)
            {
                if (this.target.name.Contains("C4"))
                {
                    TerrahyptianNetwork.AlertLVL2 = 4;
                }
            }
            if (TerrahyptianNetwork.TC5CriminalLevel > 480)
            {
                if (this.target.name.Contains("C5"))
                {
                    TerrahyptianNetwork.AlertLVL2 = 5;
                }
            }
            if (TerrahyptianNetwork.TC6CriminalLevel > 480)
            {
                if (this.target.name.Contains("C6"))
                {
                    TerrahyptianNetwork.AlertLVL2 = 6;
                }
            }
            if (TerrahyptianNetwork.TC7CriminalLevel > 480)
            {
                if (this.target.name.Contains("C7"))
                {
                    TerrahyptianNetwork.AlertLVL2 = 7;
                }
            }
            if (TerrahyptianNetwork.TC8CriminalLevel > 480)
            {
                if (this.target.name.Contains("C8"))
                {
                    TerrahyptianNetwork.AlertLVL2 = 8;
                }
            }
            if (TerrahyptianNetwork.TC9CriminalLevel > 480)
            {
                if (this.target.name.Contains("C9"))
                {
                    TerrahyptianNetwork.AlertLVL2 = 9;
                }
            }
        }
        if (TerrahyptianNetwork.instance.EnemyTarget2)
        {
            if (Vector3.Distance(TerrahyptianNetwork.instance.EnemyTarget2.position, this.thisTransform.position) < 350)
            {
                TerrahyptianNetwork.UnitsPresent = true;
            }
        }
        if (this.PissedAtTC0a == 1)
        {
            if (TerrahyptianNetwork.TC0aCriminalLevel < 10)
            {
                TerrahyptianNetwork.TC0aCriminalLevel = 10;
            }
        }
        if (this.PissedAtTC1 == 1)
        {
            if (TerrahyptianNetwork.TC1CriminalLevel < 10)
            {
                TerrahyptianNetwork.TC1CriminalLevel = 10;
            }
        }
        if (this.PissedAtTC4 == 1)
        {
            if (TerrahyptianNetwork.TC4CriminalLevel < 10)
            {
                TerrahyptianNetwork.TC4CriminalLevel = 10;
            }
        }
        if (this.PissedAtTC5 == 1)
        {
            if (TerrahyptianNetwork.TC5CriminalLevel < 10)
            {
                TerrahyptianNetwork.TC5CriminalLevel = 10;
            }
        }
        if (this.PissedAtTC6 == 1)
        {
            if (TerrahyptianNetwork.TC6CriminalLevel < 10)
            {
                TerrahyptianNetwork.TC6CriminalLevel = 10;
            }
        }
        if (this.PissedAtTC7 == 1)
        {
            if (TerrahyptianNetwork.TC7CriminalLevel < 10)
            {
                TerrahyptianNetwork.TC7CriminalLevel = 10;
            }
        }
        if (this.PissedAtTC8 == 1)
        {
            if (TerrahyptianNetwork.TC8CriminalLevel < 10)
            {
                TerrahyptianNetwork.TC8CriminalLevel = 10;
            }
        }
        if (this.PissedAtTC9 == 1)
        {
            if (TerrahyptianNetwork.TC9CriminalLevel < 10)
            {
                TerrahyptianNetwork.TC9CriminalLevel = 10;
            }
        }
        if (TerrahyptianNetwork.TC0aCriminalLevel > 10)
        {
            this.PissedAtTC0a = 60;
        }
        if (TerrahyptianNetwork.TC1CriminalLevel > 10)
        {
            this.PissedAtTC1 = 60;
        }
        if (TerrahyptianNetwork.TC4CriminalLevel > 10)
        {
            this.PissedAtTC4 = 60;
        }
        if (TerrahyptianNetwork.TC5CriminalLevel > 10)
        {
            this.PissedAtTC5 = 60;
        }
        if (TerrahyptianNetwork.TC6CriminalLevel > 10)
        {
            this.PissedAtTC6 = 60;
        }
        if (TerrahyptianNetwork.TC7CriminalLevel > 10)
        {
            this.PissedAtTC7 = 60;
        }
        if (TerrahyptianNetwork.TC8CriminalLevel > 10)
        {
            this.PissedAtTC8 = 60;
        }
        if (TerrahyptianNetwork.TC9CriminalLevel > 10)
        {
            this.PissedAtTC9 = 60;
        }
        if (this.LayingLow > 0)
        {
            this.LayingLow = this.LayingLow - 1;
        }
        if (this.Fear && (this.LayingLow < 3))
        {
            if (Vector3.Distance(this.Fear.position, this.thisTransform.position) < 300)
            {
                this.LayingLow = this.LayingLow + 1;
            }
            if (this.target)
            {
                if (Vector3.Distance(this.Fear.position, this.target.position) < 300)
                {
                    this.LayingLow = this.LayingLow + 1;
                }
            }
        }
        if ((this.Ogle == 0) && !this.Attacking)
        {
            this.BlinkerOff();
        }
        if ((this.Ogle == 1) && !this.Attacking)
        {
            this.PissedAtTC0a = 0;
            this.PissedAtTC1 = 0;
            this.PissedAtTC4 = 0;
            this.PissedAtTC5 = 0;
            this.PissedAtTC6 = 0;
            this.PissedAtTC7 = 0;
            this.PissedAtTC8 = 0;
            this.PissedAtTC9 = 0;
            this.target = this.ResetView;
            this.Parked = false;
            this.Hunting = true;
            this.BlinkerOff();
        }
        if (this.LayingLow < 1)
        {
            this.Turner.TorqueForce = -200;
        }
        else
        {
            this.Turner.TorqueForce = 0;
        }
        this.TurnRight = false;
        this.TurnLeft = false;
        this.IsClose = false;
        this.Wall = false;
        if (this.Attacking)
        {
            this.Trig.center = new Vector3(0, 0, 0);
            this.Trig.radius = 50;
            this.Trig.height = 50;
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
            if (this.DangerSense > 0)
            {
                if (this.DangerSense < 2)
                {
                    this.target = this.ResetView;
                }
                this.DangerSense = this.DangerSense - 1;
            }
        }
        if (this.JustNoticed > 0)
        {
            this.JustNoticed = this.JustNoticed - 1;
        }
        if ((!this.Stuck && !this.Parked) && !this.IsClose)
        {
            this.lastPos = this.thisTransform.position;
            this.StartCoroutine(this.IsEscaping());
        }
        if ((Vector3.Distance(this.thisTransform.position, this.lastPos) > 5) && this.Stuck)
        {
            this.Stuck = false;
            this.TurnRight = false;
        }
        if (this.target != null)
        {
            Vector3 lastTPos = this.target.transform.position;
            this.StartCoroutine(this.IsNoticing(lastTPos));
        }
        //========================================================================================================================//
        //////////////////////////////////////////////////////[INTERACTION]/////////////////////////////////////////////////////////
        //========================================================================================================================//
        if (NotiScript.PiriNotis)
        {
            if (Vector3.Distance(this.thisTransform.position, PlayerInformation.instance.Pirizuka.position) < 128)
            {
                if (this.convNum < 99)
                {
                    if (!this.Attacking)
                    {
                        this.target = PlayerInformation.instance.PiriTarget;
                        this.Ogle = 20;
                    }
                    else
                    {
                        if (this.target)
                        {
                            if (this.target.name.Contains("TC1"))
                            {
                                this.target = PlayerInformation.instance.PiriTarget;
                                this.Ogle = 20;
                            }
                        }
                    }
                }
                NotiScript.PiriNotis = false;
            }
        }
        if (this.Ogle > 0)
        {
            if (WorldInformation.pSpeech)
            {
                if (WorldInformation.pSpeech.name.Contains("a1"))
                {
                    if (Vector3.Distance(this.thisTransform.position, WorldInformation.pSpeech.position) < 64)
                    {
                        this.StartCoroutine(this.ProcessSpeech(TalkBubbleScript.myText, 0, 0));
                    }
                }
                if (WorldInformation.pSpeech.name.Contains("b1"))
                {
                    if (Vector3.Distance(this.thisTransform.position, WorldInformation.pSpeech.position) < 128)
                    {
                        this.StartCoroutine(this.ProcessSpeech(TalkBubbleScript.myText, 1, 0));
                    }
                }
                if (WorldInformation.pSpeech.name.Contains("c1"))
                {
                    if (Vector3.Distance(this.thisTransform.position, WorldInformation.pSpeech.position) < 256)
                    {
                        this.StartCoroutine(this.ProcessSpeech(TalkBubbleScript.myText, 2, 0));
                    }
                }
                WorldInformation.pSpeech = null;
            }
        }
    }

    public virtual IEnumerator IsNoticing(Vector3 lastTPos)
    {
        yield return new WaitForSeconds(0.5f);
        if (this.target != null)
        {
            if (Vector3.Distance(this.target.transform.position, lastTPos) > 1)
            {
                this.TargetIsMoving = true;
            }
            else
            {
                this.TargetIsMoving = false;
            }
        }
    }

    public virtual IEnumerator IsEscaping()
    {
        yield return new WaitForSeconds(0.5f);
        if (Vector3.Distance(this.thisTransform.position, this.lastPos) < 0.1f)
        {
            this.Stuck = true;
        }
    }

    public virtual IEnumerator Dismiss()
    {
        yield return new WaitForSeconds(2);
        CallAssistance.DismissAssistance = true;
    }

    public virtual IEnumerator Excuse()
    {
        yield return new WaitForSeconds(0.2f);
        if (this.PissedAtTC1 > 0)
        {
            if (this.convNum < 4)
            {
                if (this.target)
                {
                    if (this.target.name.Contains("TC1"))
                    {
                        this.ReturnSpeech("Cease your weapon, now!");
                        this.convNum = 4;
                        this.Ogle = 20;
                    }
                }
            }
        }
        else
        {
            if (this.target.name.Contains("TC1"))
            {
                this.ReturnSpeech("Excuse me, there is something \n that I need to attend to.");
                this.convNum = 0;
            }
        }
    }

    //========================================================================================================================//
    //////////////////////////////////////////////////////[INTERACTION]/////////////////////////////////////////////////////////
    //========================================================================================================================//
    public int convNum;
    public int boredom;
    public virtual IEnumerator ProcessSpeech(string speech, int mode, int code)
    {
        yield return new WaitForSeconds(0.1f);
        if (!!string.IsNullOrEmpty(speech))
        {
            yield break;
        }
        if (mode < 2)
        {
            if (this.convNum == 0)
            {
                //===============================================================================
                if ((speech.Contains("hi") || speech.Contains("hey")) || speech.Contains("yo"))
                {
                    this.convNum = 1;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Hello, citizen. \n Is there anything you desire?");
                    yield break;
                }
                if (speech.Contains("hello") || speech.Contains("greet"))
                {
                    this.convNum = 1;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Greetings traveler. \n Do you need help with something?");
                    yield break;
                }
                if (speech.Contains("stop"))
                {
                    this.convNum = 1;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("What is it?");
                    yield break;
                }
            }
            //===============================================================================
            if (this.convNum == 1)
            {
                //===============================================================================
                if (speech.Contains("yes"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("I don't have much time to talk.");
                    yield break;
                }
                if (speech.Contains("no"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Well then.");
                    yield break;
                }
                if (speech.Contains("in") || speech.Contains("on"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Sure.");
                    this.vEntrance.DenyEntrance = false;
                    yield break;
                }
                if (speech.Contains("ride") || speech.Contains("lift"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Yes, I can offer you escort.");
                    this.vEntrance.DenyEntrance = false;
                    yield break;
                }
                if (speech.Contains("go"))
                {
                    this.convNum = 2;
                    this.Ogle = 1;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("You be careful now.");
                    this.StartCoroutine(this.Dismiss());
                    yield break;
                }
                if ((speech.Contains("leave") && !speech.Contains("i")) || (speech.Contains("u") && speech.Contains("leave")))
                {
                    this.convNum = 2;
                    this.Ogle = 1;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("You be careful now.");
                    this.StartCoroutine(this.Dismiss());
                    yield break;
                }
                if (speech.Contains("i") && speech.Contains("leave"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("I can offer you an escort.");
                    this.vEntrance.DenyEntrance = false;
                    yield break;
                }
                if (speech.Contains("stop"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("You need to start talking.");
                    yield break;
                }
            }
            //===============================================================================
            if (this.convNum == 2)
            {
                //===============================================================================
                if (speech.Contains("yes"))
                {
                    this.convNum = 3;
                    this.Ogle = 1;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Bye!");
                    this.StartCoroutine(this.Dismiss());
                    yield break;
                }
                if (speech.Contains("no"))
                {
                    this.convNum = 3;
                    this.Ogle = 1;
                    yield return new WaitForSeconds(2);
                    this.StartCoroutine(this.Dismiss());
                    yield break;
                }
                if (speech.Contains("in") || speech.Contains("on"))
                {
                    this.convNum = 3;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Fine.");
                    this.vEntrance.DenyEntrance = false;
                    yield break;
                }
                if (speech.Contains("ride") || speech.Contains("lift"))
                {
                    this.convNum = 3;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Yes, just jump on in");
                    this.vEntrance.DenyEntrance = false;
                    yield break;
                }
                if (speech.Contains("go"))
                {
                    this.convNum = 3;
                    this.Ogle = 1;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Alright then.");
                    this.StartCoroutine(this.Dismiss());
                    yield break;
                }
                if (speech.Contains("drive"))
                {
                    this.convNum = 3;
                    this.Ogle = 1;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Will do.");
                    this.StartCoroutine(this.Dismiss());
                    yield break;
                }
                if ((speech.Contains("leave") && !speech.Contains("i")) || (speech.Contains("u") && speech.Contains("leave")))
                {
                    this.convNum = 2;
                    this.Ogle = 1;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Yes, yes.");
                    this.StartCoroutine(this.Dismiss());
                    yield break;
                }
                if (speech.Contains("i") && speech.Contains("leave"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Alright.");
                    this.vEntrance.DenyEntrance = false;
                    yield break;
                }
                if (speech.Contains("stop"))
                {
                    this.convNum = 3;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Alright. We're done here.");
                    yield break;
                }
            }
        }
        //===============================================================================
        //======================================================================================================================================
        //======================================================================================================================================
        if (mode == 2)
        {
            if (this.convNum == 0)
            {
                //===============================================================================
                if ((speech.Contains("hi") || speech.Contains("hey")) || speech.Contains("yo"))
                {
                    this.convNum = 1;
                    this.Ogle = 1;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Hello. \n You sure look well-armed!");
                    yield break;
                }
                if (speech.Contains("hello") || speech.Contains("greet"))
                {
                    this.convNum = 1;
                    this.Ogle = 1;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Greetings. \n Are you a mercenary?");
                    yield break;
                }
                if (speech.Contains("stop"))
                {
                    this.convNum = 1;
                    this.Ogle = 1;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("What is it that you want?");
                    yield break;
                }
            }
            //===============================================================================
            if (this.convNum == 1)
            {
                //===============================================================================
                if ((speech.Contains("yes") || speech.Contains("yep")) || speech.Contains("sure"))
                {
                    this.convNum = 2;
                    this.Ogle = 1;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Well, I don't think you need my help.");
                    this.StartCoroutine(this.Dismiss());
                    yield break;
                }
                if (speech.Contains("hello") || speech.Contains("greet"))
                {
                    this.convNum = 2;
                    this.Ogle = 1;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("I am not really tasked to help militants. \n Farewell for now.");
                    this.StartCoroutine(this.Dismiss());
                    yield break;
                }
                if (speech.Contains("stop"))
                {
                    this.convNum = 2;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("What is it?");
                    yield break;
                }
            }
        }
        //===============================================================================
        //=================================================================================================================================
        //============================================////[Conflict Reactions]////=========================================================
        //=================================================================================================================================
        if (this.convNum == 4)
        {
            if (TerrahyptianNetwork.TC1CriminalLevel < 16)
            {
                //===============================================================================
                if (speech.Contains("sorry"))
                {
                    this.convNum = 99;
                    yield return new WaitForSeconds(8);
                    this.ReturnSpeech("Apology accepted, \n now leave!");
                    this.Ogle = 1;
                    this.Attacking = false;
                    this.PissedAtTC1 = 0;
                    this.StartCoroutine(this.Dismiss());
                    yield break;
                }
                if (speech.Contains("please"))
                {
                    this.convNum = 99;
                    yield return new WaitForSeconds(8);
                    this.ReturnSpeech("Stop breaking the law!");
                    this.Ogle = 1;
                    this.Attacking = false;
                    this.PissedAtTC1 = 0;
                    yield break;
                }
                if (speech.Contains("stop"))
                {
                    this.convNum = 99;
                    yield return new WaitForSeconds(8);
                    this.ReturnSpeech("Try again and you'll \n be paying a hefty fine.");
                    this.Ogle = 1;
                    this.Attacking = false;
                    this.PissedAtTC1 = 0;
                    yield break;
                }
                if (speech.Contains("excuse"))
                {
                    this.convNum = 99;
                    yield return new WaitForSeconds(8);
                    this.ReturnSpeech("I'll excuse you once you \n stop breaking our laws.");
                    this.Ogle = 1;
                    this.Attacking = false;
                    this.PissedAtTC1 = 0;
                    yield break;
                }
            }
        }
        //===============================================================================
        if (this.convNum > 0)
        {
            if (this.boredom < 3)
            {
                if (((speech.Contains("bye") || speech.Contains("see")) || speech.Contains("fare")) || speech.Contains("later"))
                {
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Goodbye.");
                    this.Ogle = 2;
                    this.StartCoroutine(this.Dismiss());
                    yield break;
                }
                if ((speech.Contains("thank") || speech.Contains("good")) || speech.Contains("like"))
                {
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("Don't fret it.");
                    this.Ogle = 2;
                    yield break;
                }
            }
            //===============================================================================
            if (speech.Contains("fuck you"))
            {
                this.boredom = 3;
                this.convNum = 5;
                this.Ogle = 1;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Watch your mouth.");
                yield break;
            }
            if (speech.Contains("fuck off"))
            {
                this.boredom = 3;
                this.convNum = 4;
                this.Ogle = 1;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("It is my job to keep watch \n if there is any problems.");
                yield break;
            }
            if (speech.Contains("go away"))
            {
                this.boredom = 3;
                this.convNum = 5;
                this.Ogle = 1;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("I can't do that.");
                yield break;
            }
            if (speech.Contains("get out"))
            {
                this.boredom = 3;
                this.convNum = 5;
                this.Ogle = 1;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Thanks for your concern, \n but I am going to stay.");
                yield break;
            }
        }
        //===============================================================================
        yield return new WaitForSeconds(2);
        if (this.boredom == 0)
        {
            this.ReturnSpeech("What exactly do you need help with?");
        }
        if (this.boredom == 1)
        {
            this.ReturnSpeech("I'm not sure, buddy.");
            this.convNum = 1;
        }
        if (this.boredom == 2)
        {
            this.ReturnSpeech("Ok, we're done here.");
            this.StartCoroutine(this.Dismiss());
            this.convNum = 1;
        }
        if (this.boredom == 3)
        {
            this.ReturnSpeech("Calm down.");
            this.convNum = 99;
            this.StartCoroutine(this.Dismiss());
            this.Ogle = 1;
        }
        this.boredom = this.boredom + 1;
    }

    public virtual void ReturnSpeech(string yourText)
    {
        GameObject Load = ((GameObject) Resources.Load("Prefabs/TalkBubble", typeof(GameObject))) as GameObject;
        GameObject TGO = UnityEngine.Object.Instantiate(Load, this.thisTransform.position, Load.transform.rotation);
        TGO.name = "CFC3";
        TalkBubbleScript.myText = yourText;
        ((TalkBubbleScript) TGO.GetComponent(typeof(TalkBubbleScript))).source = this.thisVTransform;
    }

    public ValiantAI()
    {
        this.RightDist = 200;
        this.LeftDist = 200;
        this.TForce = 6;
    }

}