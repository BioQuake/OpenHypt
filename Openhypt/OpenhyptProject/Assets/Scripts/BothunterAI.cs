using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class BothunterAI : MonoBehaviour
{
    public Transform target;
    public Transform ResetView;
    public Transform Waypoint2;
    public Transform Waypoint3;
    public GameObject BothunterGyro;
    public GameObject BothunterHoverer;
    public CapsuleCollider Trig;
    public BigVesselRotator Turner;
    public TurretAI Turret;
    public Transform TurretTF;
    public bool isFughunter;
    public Transform launcher1;
    public Transform launcher2;
    public GameObject MissileAmmo;
    public GameObject Missile1GO;
    public GameObject Missile2GO;
    public GameObject Supplies;
    public Blinker Blinker1;
    public Blinker Blinker2;
    public Blinker Blinker3;
    public GameObject BothunterPresence;
    public GameObject SpotSound;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public int PissedAtTC0a;
    public int PissedAtTC1;
    public int PissedAtTC4;
    public int PissedAtTC5;
    public int PissedAtTC6;
    public int PissedAtTC7;
    public int PissedAtTC8;
    public int PissedAtTC9;
    public Transform Fear;
    public bool Hunting;
    public bool Attacking;
    public bool Obstacle;
    public bool Stuck;
    public bool Cruising;
    public bool TurnRight;
    public bool TurnLeft;
    public float RPClamp;
    public float RPClamp2;
    public float RPMod;
    public bool Dropping;
    public int DropCounter;
    public int StoredMissileBatches;
    public bool Tactical;
    public bool IsClose;
    public bool Wall;
    public Vector3 lastPos;
    public float targetDist;
    public int DangerSense;
    public LayerMask targetLayers;
    public LayerMask MtargetLayers;
    public bool FoundExtraBig;
    public int LayingLow;
    public int JustNoticed;
    public int Watching;
    public int DirForce;
    public float Vel;
    public Vector3 newRot2;
    public float RotateThreshold;
    public float TorqueForce;
    public float RUP;
    public virtual void Start()
    {
        this.InvokeRepeating("LeaveMarker", 1, 1);
        this.InvokeRepeating("Targety", 10, 30);
        this.InvokeRepeating("Shooty", 1, 0.2f);
        this.InvokeRepeating("TacticChange", 1, 10);
        this.Hunting = true;
        if (!this.isFughunter)
        {
            this.Waypoint3 = PlayerInformation.instance.PiriTarget;
        }
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        RaycastHit hit1 = default(RaycastHit);
        RaycastHit hit2 = default(RaycastHit);
        Vector3 localV = this.thisTransform.InverseTransformDirection(this.vRigidbody.velocity);
        if (this.Watching > 1)
        {
            if (-localV.y > 0)
            {
                if (Vector3.Distance(this.thisTransform.position, this.Waypoint3.transform.position) < 15)
                {
                    this.IsClose = true;
                }
            }
            else
            {
                this.IsClose = false;
            }
            this.RotateThreshold = 0.1f;
        }
        if (!this.isFughunter)
        {
            if ((((CallAssistance.IsAssisting && !this.Attacking) && (this.Watching < 1)) && (this.PissedAtTC1 == 0)) && !this.Dropping)
            {
                if (localV.z > 10)
                {
                    if (Vector3.Distance(this.thisTransform.position, this.Waypoint3.transform.position) < 50)
                    {
                        this.IsClose = true;
                    }
                }
                else
                {
                    this.IsClose = false;
                    if (!TerrahyptianNetwork.HasDropped)
                    {
                        if (this.Waypoint3.name.Contains("sTC"))
                        {
                            if (Vector3.Distance(this.thisTransform.position, this.Waypoint3.transform.position) < 30)
                            {
                                if (this.DropCounter > 1)
                                {
                                    this.Dropping = true;
                                }
                            }
                        }
                    }
                }
                if (Vector3.Distance(this.thisTransform.position, this.Waypoint3.transform.position) < 30)
                {
                    this.target = this.ResetView;
                }
                if (Vector3.Distance(this.thisTransform.position, this.Waypoint3.transform.position) > 30)
                {
                    this.target = this.Waypoint3;
                    if (Vector3.Distance(this.thisTransform.position, this.Waypoint3.transform.position) < 50)
                    {
                        this.RotateThreshold = 0.8f;
                    }
                    if (Vector3.Distance(this.thisTransform.position, this.Waypoint3.transform.position) > 50)
                    {
                        this.RotateThreshold = 0.1f;
                    }
                }
            }
        }
        float Vel0 = this.vRigidbody.velocity.magnitude * 2.24f;
        this.Vel = Mathf.Clamp(Vel0, 0.1f, 512);
        if (this.RUP < 4)
        {
            this.RUP = this.RUP + 0.5f;
        }
        else
        {
            this.RUP = 0;
        }
        Vector3 Point1u = new Vector3();
        Vector3 Point1d = new Vector3();
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.up * 0.2f)) + (this.thisTransform.up * this.RUP), this.newRot2 * 150f, Color.white);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.up * 0.2f)) + (this.thisTransform.up * this.RUP), this.newRot2, out hit1, 150, (int) this.MtargetLayers))
        {
            Point1u = hit1.point;
        }
        else
        {
            Point1u = new Vector3(2, 2, 2);
        }
        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.up * this.RUP), this.newRot2 * 150f, Color.white);
        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.up * this.RUP), this.newRot2, out hit2, 150, (int) this.MtargetLayers))
        {
            Point1d = hit2.point;
        }
        else
        {
            Point1d = new Vector3(8, 8, 8);
        }
        if (Vector3.Distance(Point1u, Point1d) > 0.6f)
        {
            this.TurnRight = false;
            this.TurnLeft = false;
        }
        else
        {
            this.Wall = true;
        }
        Debug.DrawRay(this.thisTransform.position, this.newRot2 * this.Vel, Color.green);
        if (Physics.Raycast(this.thisTransform.position, this.newRot2, out hit, this.Vel, (int) this.targetLayers))
        {
            if (this.Wall)
            {
                this.Obstacle = true;
            }
        }
        else
        {
            this.Obstacle = false;
        }
        if (this.target != this.Waypoint3)
        {
            Vector3 newRot = (this.thisTransform.forward * 0.6f).normalized;
            if (this.Vel > 30)
            {
                newRot = ((this.thisTransform.forward * 0.6f) + (this.thisTransform.right * 0.1f)).normalized;
                Debug.DrawRay(this.thisTransform.position + (this.thisTransform.right * 5), newRot * 100f, Color.black);
                if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.right * 5), newRot, 100))
                {
                    this.TurnLeft = true;
                    this.TorqueForce = 0;
                }
                else
                {
                    this.TurnLeft = false;
                }
                newRot = ((this.thisTransform.forward * 0.6f) + (this.thisTransform.right * -0.1f)).normalized;
                Debug.DrawRay(this.thisTransform.position + (-this.thisTransform.right * 5), newRot * 100f, Color.black);
                if (Physics.Raycast(this.thisTransform.position + (-this.thisTransform.right * 5), newRot, 100))
                {
                    this.TurnRight = true;
                    this.TorqueForce = 0;
                }
                else
                {
                    this.TurnRight = false;
                }
            }
            else
            {
                newRot = ((this.thisTransform.forward * 0.6f) + (this.thisTransform.right * 0.1f)).normalized;
                Debug.DrawRay(this.thisTransform.position + (this.thisTransform.right * 5), newRot * 50f, Color.black);
                if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.right * 5), newRot, 50))
                {
                    if (this.JustNoticed < 1)
                    {
                        this.TurnLeft = true;
                    }
                    this.TorqueForce = 0;
                }
                else
                {
                    this.TurnLeft = false;
                }
                newRot = ((this.thisTransform.forward * 0.6f) + (this.thisTransform.right * -0.1f)).normalized;
                Debug.DrawRay(this.thisTransform.position + (-this.thisTransform.right * 5), newRot * 50f, Color.black);
                if (Physics.Raycast(this.thisTransform.position + (-this.thisTransform.right * 5), newRot, 50))
                {
                    if (this.JustNoticed < 1)
                    {
                        this.TurnRight = true;
                    }
                    this.TorqueForce = 0;
                }
                else
                {
                    this.TurnRight = false;
                }
            }
        }
    }

    private Quaternion NewRotation;
    public virtual void FixedUpdate()
    {
        Vector3 localV = this.thisTransform.InverseTransformDirection(this.vRigidbody.velocity);
        this.newRot2 = this.vRigidbody.velocity;
        if (this.Vel < 30)
        {
            this.newRot2 = -this.thisVTransform.up;
        }
        if (this.target)
        {
            this.targetDist = Vector3.Distance(this.transform.position, this.target.position);
            Vector3 RelativeTarget = this.thisTransform.InverseTransformPoint(this.target.position);
            if (this.JustNoticed > 0)
            {
                this.RPMod = RelativeTarget.z;
                this.RPClamp = Mathf.Clamp(this.RPMod, -40, 40);
            }
            else
            {
                this.RPMod = RelativeTarget.x;
                this.RPClamp = Mathf.Clamp(this.RPMod, -40, 40);
            }
        }
        if (!this.isFughunter)
        {
            Vector3 difference = ((this.TurretTF.position + (this.TurretTF.forward * 20)) - this.thisVTransform.position).normalized;
            float product = Vector3.Dot(this.thisVTransform.right, difference);
            if (product < -this.RotateThreshold)
            {
                this.vRigidbody.AddTorque(this.thisVTransform.forward * this.TorqueForce);
            }
            else
            {
                if (product > this.RotateThreshold)
                {
                    this.vRigidbody.AddTorque(this.thisVTransform.forward * -this.TorqueForce);
                }
            }
        }
        else
        {
            if ((this.Stuck || this.TurnLeft) || this.TurnRight)
            {
                this.vRigidbody.AddTorque(this.thisVTransform.forward * this.TorqueForce);
            }
            else
            {
                this.vRigidbody.AddTorque(this.thisVTransform.forward * this.RPClamp);
            }
        }
        if (this.IsClose)
        {
            this.vRigidbody.AddForce(this.thisVTransform.up * 20);
        }
        if (this.Obstacle || this.Dropping)
        {
            if (this.Vel > 30)
            {
                this.vRigidbody.AddForce(this.newRot2 * -2);
            }
            if ((this.Watching < 1) && !this.Dropping)
            {
                if (localV.z > 5)
                {
                    this.vRigidbody.AddForce(this.thisVTransform.up * 10);
                }
            }
            if ((this.Watching > 1) || this.Dropping)
            {
                if (localV.z > 0)
                {
                    this.vRigidbody.AddForce(this.thisVTransform.up * 10);
                }
            }
        }
        if (this.Stuck && !this.Dropping)
        {
            if (this.Watching < 1)
            {
                this.TurnRight = true;
                if (-localV.z < 20)
                {
                    this.vRigidbody.AddForce(this.thisVTransform.up * 20);
                }
            }
        }
        if (this.Attacking && !this.Obstacle)
        {
            if (!this.isFughunter)
            {
                if (this.Tactical)
                {
                    if (localV.z < 70)
                    {
                        this.vRigidbody.AddForce(this.thisVTransform.up * this.DirForce);
                    }
                }
                if (!this.Tactical)
                {
                    if (localV.z < 70)
                    {
                        this.vRigidbody.AddForce(this.thisVTransform.up * -20);
                    }
                }
            }
            else
            {
                if (localV.z < 100)
                {
                    this.vRigidbody.AddForce(this.thisVTransform.up * -20);
                }
            }
        }
        if ((((!this.Attacking && !this.Stuck) && !this.Obstacle) && !this.IsClose) && !this.Dropping)
        {
            if (!this.Obstacle)
            {
                if (localV.z < 50)
                {
                    this.vRigidbody.AddForce(this.thisVTransform.up * -20);
                }
            }
            if (this.Obstacle)
            {
                if (localV.z < 15)
                {
                    this.vRigidbody.AddForce(this.thisVTransform.up * -20);
                }
            }
        }
        if ((this.TurnLeft && !this.TurnRight) && !this.Dropping)
        {
            this.BothunterGyro.GetComponent<Rigidbody>().AddTorque(this.thisTransform.up * -50);
        }
        if ((this.TurnRight && !this.TurnLeft) && !this.Dropping)
        {
            this.BothunterGyro.GetComponent<Rigidbody>().AddTorque(this.thisTransform.up * 50);
        }
        if (((this.TurnRight && this.TurnLeft) && this.Obstacle) && !this.Dropping)
        {
            this.BothunterGyro.GetComponent<Rigidbody>().AddTorque(this.thisTransform.up * -50);
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
                if (this.target)
                {
                    if (this.target.name.Contains("TC"))
                    {
                        if (ON.Contains("TFC0a"))
                        {
                            if (this.target.name.Contains("TC0a"))
                            {
                                if (this.PissedAtTC0a < 4)
                                {
                                    this.PissedAtTC0a = this.PissedAtTC0a + 1;
                                }
                            }
                        }
                        if (ON.Contains("TFC1"))
                        {
                            if (this.target.name.Contains("TC1"))
                            {
                                if (this.PissedAtTC1 < 4)
                                {
                                    this.PissedAtTC1 = this.PissedAtTC1 + 1;
                                }
                            }
                        }
                        if (ON.Contains("TFC5"))
                        {
                            if (this.target.name.Contains("TC5"))
                            {
                                if (this.PissedAtTC5 < 4)
                                {
                                    this.PissedAtTC5 = this.PissedAtTC5 + 1;
                                }
                            }
                        }
                        if (ON.Contains("TFC6"))
                        {
                            if (this.target.name.Contains("TC6"))
                            {
                                if (this.PissedAtTC6 < 4)
                                {
                                    this.PissedAtTC6 = this.PissedAtTC6 + 1;
                                }
                            }
                        }
                        if (ON.Contains("TFC7"))
                        {
                            if (this.target.name.Contains("TC7"))
                            {
                                if (this.PissedAtTC7 < 4)
                                {
                                    this.PissedAtTC7 = this.PissedAtTC7 + 1;
                                }
                            }
                        }
                        if (ON.Contains("TFC8"))
                        {
                            if (this.target.name.Contains("TC8"))
                            {
                                if (this.PissedAtTC8 < 4)
                                {
                                    this.PissedAtTC8 = this.PissedAtTC8 + 1;
                                }
                            }
                        }
                        if (ON.Contains("TFC9"))
                        {
                            if (this.target.name.Contains("TC9"))
                            {
                                if (this.PissedAtTC9 < 4)
                                {
                                    this.PissedAtTC9 = this.PissedAtTC9 + 1;
                                }
                            }
                        }
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
            if (ON.Contains("C3"))
            {
                return;
            }
            if (this.isFughunter)
            {
                if (ON.Contains("xb"))
                {
                    if (ON.Contains("C1"))
                    {
                        TerrahyptianNetwork.AnExtraBigTC1 = OT;
                    }
                    if (ON.Contains("C4"))
                    {
                        TerrahyptianNetwork.AnExtraBigTC4 = OT;
                    }
                    if (ON.Contains("C5"))
                    {
                        TerrahyptianNetwork.AnExtraBigTC5 = OT;
                    }
                    if (ON.Contains("C6"))
                    {
                        TerrahyptianNetwork.AnExtraBigTC6 = OT;
                    }
                    if (ON.Contains("C7"))
                    {
                        TerrahyptianNetwork.AnExtraBigTC7 = OT;
                    }
                    if (ON.Contains("C8"))
                    {
                        TerrahyptianNetwork.AnExtraBigTC8 = OT;
                    }
                    if (ON.Contains("C9"))
                    {
                        TerrahyptianNetwork.AnExtraBigTC9 = OT;
                    }
                }
                if (this.FoundExtraBig)
                {
                    return;
                }
            }
            else
            {
                if (!ON.Contains("x"))
                {
                    if (Physics.Linecast(this.thisTransform.position, OT.position, (int) this.MtargetLayers))
                    {
                        return;
                    }
                }
            }
            if (this.target)
            {
                if (ON.Contains("TC2") && this.Attacking)
                {
                    if (Vector3.Distance(OT.position, this.target.position) < 300)
                    {
                        this.Fear = OT;
                    }
                }
            }
            bool FoundSomething = false;
            if (ON.Contains("TC0a") && (this.PissedAtTC0a > 0))
            {
                if (this.Attacking && (this.PissedAtTC0a > 1))
                {
                    this.target = OT;
                }
                FoundSomething = true;
                if (!this.Attacking)
                {
                    if (this.PissedAtTC0a > 1)
                    {
                        this.target = OT;
                        this.Attacking = true;
                        this.Hunting = false;
                        if (!this.isFughunter)
                        {
                            this.BlinkerOn();
                        }
                        this.Watching = 1;
                    }
                    if ((this.PissedAtTC0a < 2) && (this.Watching < 1))
                    {
                        this.Hunting = false;
                        GameObject TheThing0 = UnityEngine.Object.Instantiate(this.SpotSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                        TheThing0.transform.parent = this.thisTransform;
                        this.target = OT;
                        if (!this.isFughunter)
                        {
                            this.BlinkerOn();
                        }
                        this.Watching = 30;
                    }
                }
                if (ON.Contains("xb"))
                {
                    return;
                }
            }
            if (ON.Contains("TC1") && (this.PissedAtTC1 > 0))
            {
                if (this.Attacking && (this.PissedAtTC1 > 1))
                {
                    this.target = OT;
                }
                FoundSomething = true;
                if (!this.Attacking)
                {
                    if (this.PissedAtTC1 > 1)
                    {
                        this.target = OT;
                        this.Attacking = true;
                        this.Hunting = false;
                        if (!this.isFughunter)
                        {
                            this.BlinkerOn();
                        }
                        this.Watching = 1;
                    }
                    if ((this.PissedAtTC1 < 2) && (this.Watching < 1))
                    {
                        this.Hunting = false;
                        GameObject TheThing1 = UnityEngine.Object.Instantiate(this.SpotSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                        TheThing1.transform.parent = this.thisTransform;
                        this.target = OT;
                        if (!this.isFughunter)
                        {
                            this.BlinkerOn();
                        }
                        this.Watching = 30;
                    }
                }
                if (ON.Contains("xb"))
                {
                    this.FoundExtraBig = true;
                    return;
                }
            }
            if (ON.Contains("TC4") && (this.PissedAtTC4 > 0))
            {
                if (this.Attacking && (this.PissedAtTC4 > 1))
                {
                    this.target = OT;
                }
                FoundSomething = true;
                if (!this.Attacking)
                {
                    if (this.PissedAtTC4 > 1)
                    {
                        this.target = OT;
                        this.Attacking = true;
                        this.Hunting = false;
                        if (!this.isFughunter)
                        {
                            this.BlinkerOn();
                        }
                        this.Watching = 1;
                    }
                    if ((this.PissedAtTC4 < 2) && (this.Watching < 1))
                    {
                        this.Hunting = false;
                        GameObject TheThing2 = UnityEngine.Object.Instantiate(this.SpotSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                        TheThing2.transform.parent = this.thisTransform;
                        this.target = OT;
                        if (!this.isFughunter)
                        {
                            this.BlinkerOn();
                        }
                        this.Watching = 30;
                    }
                }
                if (ON.Contains("xb"))
                {
                    this.FoundExtraBig = true;
                    return;
                }
            }
            if (ON.Contains("TC5") && (this.PissedAtTC5 > 0))
            {
                if (this.Attacking && (this.PissedAtTC5 > 1))
                {
                    this.target = OT;
                }
                FoundSomething = true;
                if (!this.Attacking)
                {
                    if (this.PissedAtTC5 > 1)
                    {
                        this.target = OT;
                        this.Attacking = true;
                        this.Hunting = false;
                        if (!this.isFughunter)
                        {
                            this.BlinkerOn();
                        }
                        this.Watching = 1;
                    }
                    if ((this.PissedAtTC5 < 2) && (this.Watching < 1))
                    {
                        this.Hunting = false;
                        GameObject TheThing3 = UnityEngine.Object.Instantiate(this.SpotSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                        TheThing3.transform.parent = this.thisTransform;
                        this.target = OT;
                        if (!this.isFughunter)
                        {
                            this.BlinkerOn();
                        }
                        this.Watching = 30;
                    }
                }
                if (ON.Contains("xb"))
                {
                    this.FoundExtraBig = true;
                    return;
                }
            }
            if (ON.Contains("TC6") && (this.PissedAtTC6 > 0))
            {
                if (this.Attacking && (this.PissedAtTC6 > 1))
                {
                    this.target = OT;
                }
                FoundSomething = true;
                if (!this.Attacking)
                {
                    if (this.PissedAtTC6 > 1)
                    {
                        this.target = OT;
                        this.Attacking = true;
                        this.Hunting = false;
                        if (!this.isFughunter)
                        {
                            this.BlinkerOn();
                        }
                        this.Watching = 1;
                    }
                    if ((this.PissedAtTC6 < 2) && (this.Watching < 1))
                    {
                        this.Hunting = false;
                        GameObject TheThing4 = UnityEngine.Object.Instantiate(this.SpotSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                        TheThing4.transform.parent = this.thisTransform;
                        this.target = OT;
                        if (!this.isFughunter)
                        {
                            this.BlinkerOn();
                        }
                        this.Watching = 30;
                    }
                }
                if (ON.Contains("xb"))
                {
                    this.FoundExtraBig = true;
                    return;
                }
            }
            if (ON.Contains("TC7") && (this.PissedAtTC7 > 0))
            {
                if (this.Attacking && (this.PissedAtTC7 > 1))
                {
                    this.target = OT;
                }
                FoundSomething = true;
                if (!this.Attacking)
                {
                    if (this.PissedAtTC7 > 1)
                    {
                        this.target = OT;
                        this.Attacking = true;
                        this.Hunting = false;
                        if (!this.isFughunter)
                        {
                            this.BlinkerOn();
                        }
                        this.Watching = 1;
                    }
                    if ((this.PissedAtTC7 < 2) && (this.Watching < 1))
                    {
                        this.Hunting = false;
                        GameObject TheThing5 = UnityEngine.Object.Instantiate(this.SpotSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                        TheThing5.transform.parent = this.thisTransform;
                        this.target = OT;
                        if (!this.isFughunter)
                        {
                            this.BlinkerOn();
                        }
                        this.Watching = 30;
                    }
                }
                if (ON.Contains("xb"))
                {
                    this.FoundExtraBig = true;
                    return;
                }
            }
            if (ON.Contains("TC8") && (this.PissedAtTC8 > 0))
            {
                if (this.Attacking && (this.PissedAtTC8 > 1))
                {
                    this.target = OT;
                }
                FoundSomething = true;
                if (!this.Attacking)
                {
                    if (this.PissedAtTC8 > 1)
                    {
                        this.target = OT;
                        this.Attacking = true;
                        this.Hunting = false;
                        if (!this.isFughunter)
                        {
                            this.BlinkerOn();
                        }
                        this.Watching = 1;
                    }
                    if ((this.PissedAtTC8 < 2) && (this.Watching < 1))
                    {
                        this.Hunting = false;
                        GameObject TheThing6 = UnityEngine.Object.Instantiate(this.SpotSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                        TheThing6.transform.parent = this.thisTransform;
                        this.target = OT;
                        if (!this.isFughunter)
                        {
                            this.BlinkerOn();
                        }
                        this.Watching = 30;
                    }
                }
                if (ON.Contains("xb"))
                {
                    this.FoundExtraBig = true;
                    return;
                }
            }
            if (ON.Contains("TC9") && (this.PissedAtTC9 > 0))
            {
                if (this.Attacking && (this.PissedAtTC9 > 1))
                {
                    this.target = OT;
                }
                FoundSomething = true;
                if (!this.Attacking)
                {
                    if (this.PissedAtTC9 > 1)
                    {
                        this.target = OT;
                        this.Attacking = true;
                        this.Hunting = false;
                        if (!this.isFughunter)
                        {
                            this.BlinkerOn();
                        }
                        this.Watching = 1;
                    }
                    if ((this.PissedAtTC9 < 2) && (this.Watching < 1))
                    {
                        this.Hunting = false;
                        GameObject TheThing7 = UnityEngine.Object.Instantiate(this.SpotSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
                        TheThing7.transform.parent = this.thisTransform;
                        this.target = OT;
                        if (!this.isFughunter)
                        {
                            this.BlinkerOn();
                        }
                        this.Watching = 30;
                    }
                }
                if (ON.Contains("xb"))
                {
                    this.FoundExtraBig = true;
                    return;
                }
            }
            if (FoundSomething)
            {
                this.Trig.radius = 8;
                this.Trig.height = 8;
            }
        }
    }

    public virtual void BlinkerOn()
    {
        this.Blinker1.DeActivated = false;
        this.Blinker2.DeActivated = false;
        this.Blinker3.DeActivated = false;
    }

    public virtual void BlinkerOff()
    {
        this.Blinker1.DeActivated = true;
        this.Blinker2.DeActivated = true;
        this.Blinker3.DeActivated = true;
    }

    public virtual void TacticChange()
    {
        if (!this.isFughunter)
        {
            if (this.Attacking && this.target)
            {
                if (this.target.name.Contains("tTC") || this.target.name.Contains("sTC"))
                {
                    this.StartCoroutine(this.TacticChange1());
                }
                else
                {
                    this.StartCoroutine(this.TacticChange2());
                }
            }
        }
    }

    public virtual IEnumerator TacticChange1()
    {
        this.Tactical = true;
        this.DirForce = 0;
        yield return new WaitForSeconds(7);
        this.DirForce = -20;
        yield return new WaitForSeconds(1);
        this.Tactical = false;
    }

    public virtual IEnumerator TacticChange2()
    {
        this.Tactical = true;
        this.DirForce = 10;
        yield return new WaitForSeconds(1);
        this.DirForce = -20;
        yield return new WaitForSeconds(1);
        this.Tactical = false;
    }

    public virtual void Shooty()
    {
        if (!this.isFughunter)
        {
            if (this.Attacking && (this.LayingLow < 1))
            {
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
        else
        {
            this.StartCoroutine(this.Launchy());
        }
    }

    public virtual IEnumerator Launchy()
    {
        if (this.target)
        {
            if ((this.Attacking && (this.StoredMissileBatches > 0)) && (this.JustNoticed > 0))
            {
                if (this.target.name.Contains("xbT") && !TerrahyptianNetwork.instance.NukeMarker)
                {
                    if (this.targetDist < 512)
                    {
                        if (this.Missile1GO)
                        {
                            if (!this.Missile1GO.name.Contains("rok"))
                            {
                                yield break;
                            }
                        }
                        if (this.Missile2GO)
                        {
                            if (!this.Missile2GO.name.Contains("rok"))
                            {
                                yield break;
                            }
                        }
                        this.StoredMissileBatches = this.StoredMissileBatches - 1;
                        this.Missile1GO = UnityEngine.Object.Instantiate(this.MissileAmmo, this.launcher1.position, this.launcher1.rotation);
                        this.Missile1GO.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                        ((MissileScript) this.Missile1GO.transform.GetComponent(typeof(MissileScript))).target = this.target;
                        yield return new WaitForSeconds(0.7f);
                        this.Missile2GO = UnityEngine.Object.Instantiate(this.MissileAmmo, this.launcher2.position, this.launcher2.rotation);
                        this.Missile2GO.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
                        ((MissileScript) this.Missile2GO.transform.GetComponent(typeof(MissileScript))).target = this.target;
                    }
                }
            }
        }
    }

    public virtual void Targety()
    {
        this.StartCoroutine(this.TargetArea());
    }

    public virtual IEnumerator TargetArea()
    {
        this.Waypoint2.transform.position = TerrahyptianNetwork.instance.PriorityWaypoint.position;
        if (!this.Attacking && (this.Watching < 1))
        {
            this.target = this.Waypoint2;
            this.DangerSense = 13;
        }
        yield return new WaitForSeconds(15);
        if (!this.Attacking && (this.Watching < 1))
        {
            this.target = this.ResetView;
        }
    }

    public virtual void LeaveMarker()
    {
        float Y = this.BothunterGyro.transform.eulerAngles.y;
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
                if (this.targetDist > 100)
                {
                    this.RotateThreshold = 0.1f;
                }
                else
                {
                    this.RotateThreshold = 0.8f;
                }
            }
        }
        else
        {
            if (this.DangerSense > 0)
            {
                this.RotateThreshold = 0.1f;
            }
            else
            {
                this.RotateThreshold = 0.8f;
            }
        }
        if (TerrahyptianNetwork.TC1CriminalLevel > 480)
        {
            this.PissedAtTC1 = 60;
        }
        if (!this.isFughunter)
        {
            this.PissedAtTC4 = 60;
        }
        if (TerrahyptianNetwork.TC5CriminalLevel > 480)
        {
            this.PissedAtTC5 = 60;
        }
        if (TerrahyptianNetwork.TC6CriminalLevel > 480)
        {
            this.PissedAtTC6 = 60;
        }
        if (TerrahyptianNetwork.TC7CriminalLevel > 480)
        {
            this.PissedAtTC7 = 60;
        }
        if (TerrahyptianNetwork.TC8CriminalLevel > 480)
        {
            this.PissedAtTC8 = 60;
        }
        if (TerrahyptianNetwork.TC9CriminalLevel > 480)
        {
            this.PissedAtTC9 = 60;
        }
        if (this.PissedAtTC0a > 1)
        {
            this.PissedAtTC0a = this.PissedAtTC0a - 1;
        }
        if (this.PissedAtTC1 > 1)
        {
            this.PissedAtTC1 = this.PissedAtTC1 - 1;
        }
        if (this.PissedAtTC4 > 1)
        {
            this.PissedAtTC4 = this.PissedAtTC4 - 1;
        }
        if (this.PissedAtTC5 > 1)
        {
            this.PissedAtTC5 = this.PissedAtTC5 - 1;
        }
        if (this.PissedAtTC6 > 1)
        {
            this.PissedAtTC6 = this.PissedAtTC6 - 1;
        }
        if (this.PissedAtTC7 > 1)
        {
            this.PissedAtTC7 = this.PissedAtTC7 - 1;
        }
        if (this.PissedAtTC8 > 1)
        {
            this.PissedAtTC8 = this.PissedAtTC8 - 1;
        }
        if (this.PissedAtTC9 > 1)
        {
            this.PissedAtTC9 = this.PissedAtTC9 - 1;
        }
        if (this.LayingLow > 0)
        {
            this.LayingLow = this.LayingLow - 1;
        }
        if ((this.Fear && (this.LayingLow < 3)) && !this.isFughunter)
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
        if ((this.Watching == 0) && !this.Attacking)
        {
            if (!this.isFughunter)
            {
                this.BlinkerOff();
            }
        }
        if ((this.Watching == 1) && !this.Attacking)
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
            this.Hunting = true;
            if (!this.isFughunter)
            {
                this.BlinkerOff();
            }
        }
        if (this.LayingLow < 1)
        {
            this.TorqueForce = -40;
        }
        else
        {
            this.TorqueForce = 0;
        }
        this.TurnRight = false;
        this.TurnLeft = false;
        this.IsClose = false;
        this.Wall = false;
        if (this.Attacking)
        {
            if (!this.isFughunter)
            {
                this.Trig.center = new Vector3(0, 0, 0);
                this.Trig.radius = 50;
                this.Trig.height = 50;
            }
            if (this.target)
            {
                if (this.isFughunter)
                {
                    if (TerrahyptianNetwork.TC1CriminalLevel > 480)
                    {
                        if (this.target.name.Contains("C1"))
                        {
                            TerrahyptianNetwork.instance.EnemyTarget2 = this.target;
                            TerrahyptianNetwork.instance.PriorityWaypoint.position = this.target.position;
                            TerrahyptianNetwork.AlertTime = 240;
                        }
                        if (this.target.name.Contains("C3"))
                        {
                            TerrahyptianNetwork.instance.EnemyTarget2 = this.target;
                            TerrahyptianNetwork.instance.PriorityWaypoint.position = this.target.position;
                            WorldInformation.PiriExposed = 10;
                        }
                        if (this.target.name.Contains("C5"))
                        {
                            if (TerrahyptianNetwork.TC5CriminalLevel < 20)
                            {
                                TerrahyptianNetwork.instance.EnemyTarget2 = this.target;
                                TerrahyptianNetwork.instance.PriorityWaypoint.position = this.target.position;
                                if (TerrahyptianNetwork.UnitsPresent)
                                {
                                    TerrahyptianNetwork.TC5CriminalLevel = 15;
                                }
                            }
                            else
                            {
                                TerrahyptianNetwork.instance.EnemyTarget2 = this.target;
                                TerrahyptianNetwork.instance.PriorityWaypoint.position = this.target.position;
                            }
                        }
                        if (this.target.name.Contains("C6"))
                        {
                            if (TerrahyptianNetwork.TC6CriminalLevel < 20)
                            {
                                TerrahyptianNetwork.instance.EnemyTarget2 = this.target;
                                TerrahyptianNetwork.instance.PriorityWaypoint.position = this.target.position;
                                if (TerrahyptianNetwork.UnitsPresent)
                                {
                                    TerrahyptianNetwork.TC6CriminalLevel = 15;
                                }
                            }
                            else
                            {
                                TerrahyptianNetwork.instance.EnemyTarget2 = this.target;
                                TerrahyptianNetwork.instance.PriorityWaypoint.position = this.target.position;
                            }
                        }
                        if (this.target.name.Contains("C7"))
                        {
                            if (TerrahyptianNetwork.TC7CriminalLevel < 20)
                            {
                                TerrahyptianNetwork.instance.EnemyTarget2 = this.target;
                                TerrahyptianNetwork.instance.PriorityWaypoint.position = this.target.position;
                                if (TerrahyptianNetwork.UnitsPresent)
                                {
                                    TerrahyptianNetwork.TC7CriminalLevel = 15;
                                }
                            }
                            else
                            {
                                TerrahyptianNetwork.instance.EnemyTarget2 = this.target;
                                TerrahyptianNetwork.instance.PriorityWaypoint.position = this.target.position;
                            }
                        }
                        if (this.target.name.Contains("C8"))
                        {
                            if (TerrahyptianNetwork.TC8CriminalLevel < 20)
                            {
                                TerrahyptianNetwork.instance.EnemyTarget2 = this.target;
                                TerrahyptianNetwork.instance.PriorityWaypoint.position = this.target.position;
                                if (TerrahyptianNetwork.UnitsPresent)
                                {
                                    TerrahyptianNetwork.TC8CriminalLevel = 15;
                                }
                            }
                            else
                            {
                                TerrahyptianNetwork.instance.EnemyTarget2 = this.target;
                                TerrahyptianNetwork.instance.PriorityWaypoint.position = this.target.position;
                            }
                        }
                        if (this.target.name.Contains("C9"))
                        {
                            if (TerrahyptianNetwork.TC9CriminalLevel < 20)
                            {
                                TerrahyptianNetwork.instance.EnemyTarget2 = this.target;
                                TerrahyptianNetwork.instance.PriorityWaypoint.position = this.target.position;
                                if (TerrahyptianNetwork.UnitsPresent)
                                {
                                    TerrahyptianNetwork.TC9CriminalLevel = 15;
                                }
                            }
                            else
                            {
                                TerrahyptianNetwork.instance.EnemyTarget2 = this.target;
                                TerrahyptianNetwork.instance.PriorityWaypoint.position = this.target.position;
                            }
                        }
                    }
                    if (TerrahyptianNetwork.TC1CriminalLevel > 480)
                    {
                        if (TerrahyptianNetwork.AnExtraBigTC1)
                        {
                            this.target = TerrahyptianNetwork.AnExtraBigTC1;
                            TerrahyptianNetwork.AlertTime = 240;
                            this.FoundExtraBig = true;
                            this.Attacking = true;
                        }
                        if (this.target.name.Contains("C1"))
                        {
                            TerrahyptianNetwork.AlertLVL2 = 1;
                        }
                    }
                    if (TerrahyptianNetwork.TC4CriminalLevel > 480)
                    {
                        if (TerrahyptianNetwork.AnExtraBigTC4)
                        {
                            this.target = TerrahyptianNetwork.AnExtraBigTC4;
                            TerrahyptianNetwork.AlertTime = 240;
                            this.FoundExtraBig = true;
                            this.Attacking = true;
                        }
                        if (this.target.name.Contains("C4"))
                        {
                            TerrahyptianNetwork.AlertLVL2 = 4;
                        }
                    }
                    if (TerrahyptianNetwork.TC5CriminalLevel > 480)
                    {
                        if (TerrahyptianNetwork.AnExtraBigTC5)
                        {
                            this.target = TerrahyptianNetwork.AnExtraBigTC5;
                            TerrahyptianNetwork.AlertTime = 240;
                            this.FoundExtraBig = true;
                            this.Attacking = true;
                        }
                        if (this.target.name.Contains("C5"))
                        {
                            TerrahyptianNetwork.AlertLVL2 = 5;
                        }
                    }
                    if (TerrahyptianNetwork.TC6CriminalLevel > 480)
                    {
                        if (TerrahyptianNetwork.AnExtraBigTC6)
                        {
                            this.target = TerrahyptianNetwork.AnExtraBigTC6;
                            TerrahyptianNetwork.AlertTime = 240;
                            this.FoundExtraBig = true;
                            this.Attacking = true;
                        }
                        if (this.target.name.Contains("C6"))
                        {
                            TerrahyptianNetwork.AlertLVL2 = 6;
                        }
                    }
                    if (TerrahyptianNetwork.TC7CriminalLevel > 480)
                    {
                        if (TerrahyptianNetwork.AnExtraBigTC7)
                        {
                            this.target = TerrahyptianNetwork.AnExtraBigTC7;
                            TerrahyptianNetwork.AlertTime = 240;
                            this.FoundExtraBig = true;
                            this.Attacking = true;
                        }
                        if (this.target.name.Contains("C7"))
                        {
                            TerrahyptianNetwork.AlertLVL2 = 7;
                        }
                    }
                    if (TerrahyptianNetwork.TC8CriminalLevel > 480)
                    {
                        if (TerrahyptianNetwork.AnExtraBigTC8)
                        {
                            this.target = TerrahyptianNetwork.AnExtraBigTC8;
                            TerrahyptianNetwork.AlertTime = 240;
                            this.FoundExtraBig = true;
                            this.Attacking = true;
                        }
                        if (this.target.name.Contains("C8"))
                        {
                            TerrahyptianNetwork.AlertLVL2 = 8;
                        }
                    }
                    if (TerrahyptianNetwork.TC9CriminalLevel > 480)
                    {
                        if (TerrahyptianNetwork.AnExtraBigTC9)
                        {
                            this.target = TerrahyptianNetwork.AnExtraBigTC9;
                            TerrahyptianNetwork.AlertTime = 240;
                            this.FoundExtraBig = true;
                            this.Attacking = true;
                        }
                        if (this.target.name.Contains("C9"))
                        {
                            TerrahyptianNetwork.AlertLVL2 = 9;
                        }
                    }
                }
                if (!Physics.Linecast(this.thisTransform.position, this.target.position, (int) this.targetLayers))
                {
                    this.TurnRight = false;
                    this.TurnLeft = false;
                    this.JustNoticed = 2;
                }
            }
            else
            {
                this.Attacking = false;
                this.target = this.ResetView;
                this.FoundExtraBig = false;
            }
            if (this.target == this.ResetView)
            {
                this.Attacking = false;
                this.target = this.ResetView;
                this.FoundExtraBig = false;
            }
            if (this.target == this.Waypoint2)
            {
                this.Attacking = false;
                this.target = this.ResetView;
                this.FoundExtraBig = false;
            }
            if (this.target == this.Waypoint3)
            {
                if (this.target.name.Contains("rok"))
                {
                    this.Attacking = false;
                    this.target = this.ResetView;
                }
                if (this.PissedAtTC1 < 1)
                {
                    this.Attacking = false;
                    this.target = this.ResetView;
                }
            }
        }
        else
        {
            if (!this.isFughunter)
            {
                this.BlinkerOff();
                this.Trig.center = new Vector3(0, 0, 200);
                this.Trig.radius = 200;
                this.Trig.height = 800;
            }
            else
            {
                this.StartCoroutine(this.TrigSweep());
            }
            if (this.DangerSense > 0)
            {
                if (this.DangerSense < 2)
                {
                    this.target = this.ResetView;
                }
                this.DangerSense = this.DangerSense - 1;
            }
        }
        if (this.Dropping)
        {
            if (this.DropCounter > 0)
            {
                this.DropCounter = this.DropCounter - 1;
            }
            if (this.DropCounter == 1)
            {
                TerrahyptianNetwork.HasDropped = true;
                this.Supplies.GetComponent<Rigidbody>().isKinematic = false;
                this.Supplies.transform.parent = null;
                this.Supplies.GetComponent<AudioSource>().Play();
            }
            if (this.DropCounter < 1)
            {
                this.Dropping = false;
                CallAssistance.DismissAssistance = true;
            }
        }
        if (this.JustNoticed > 0)
        {
            this.JustNoticed = this.JustNoticed - 1;
            if (this.targetDist > 512)
            {
                this.JustNoticed = 0;
            }
        }
        if (this.Watching > 0)
        {
            this.Watching = this.Watching - 1;
        }
        if (!this.Stuck)
        {
            this.lastPos = this.thisTransform.position;
            this.StartCoroutine(this.IsEscaping());
        }
        if ((Vector3.Distance(this.thisTransform.position, this.lastPos) > 5) && this.Stuck)
        {
            this.Stuck = false;
            this.TurnRight = false;
        }
    }

    public virtual IEnumerator TrigSweep()
    {
        this.Trig.center = new Vector3(0, 0, 1000);
        this.Trig.radius = 1000;
        this.Trig.height = 1000;
        yield return new WaitForSeconds(0.12f);
        this.Trig.center = new Vector3(700, 0, 700);
        yield return new WaitForSeconds(0.12f);
        this.Trig.center = new Vector3(1000, 0, 0);
        yield return new WaitForSeconds(0.12f);
        this.Trig.center = new Vector3(700, 0, -700);
        yield return new WaitForSeconds(0.12f);
        this.Trig.center = new Vector3(0, 0, -1000);
        yield return new WaitForSeconds(0.12f);
        this.Trig.center = new Vector3(-700, 0, -700);
        yield return new WaitForSeconds(0.12f);
        this.Trig.center = new Vector3(-1000, 0, 0);
        yield return new WaitForSeconds(0.12f);
        this.Trig.center = new Vector3(-700, 0, 700);
    }

    public virtual IEnumerator IsEscaping()
    {
        yield return new WaitForSeconds(0.5f);
        if (Vector3.Distance(this.thisTransform.position, this.lastPos) < 0.1f)
        {
            this.Stuck = true;
        }
    }

    public BothunterAI()
    {
        this.DropCounter = 4;
        this.StoredMissileBatches = 6;
        this.DirForce = 6;
    }

}