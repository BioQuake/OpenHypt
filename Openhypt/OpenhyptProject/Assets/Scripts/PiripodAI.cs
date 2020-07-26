using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PiripodAI : MonoBehaviour
{
    public Transform target;
    public Transform Waypoint;
    public GameObject Presence;
    public SphereCollider Trig;
    public StrongGyroStabilizerVehicle Gyro;
    public NewgunController Gun;
    public CarDoorController Door;
    public MainVehicleController VesselScript;
    public PivotingHingeThrusterScript RWingScript;
    public PivotingHingeThrusterScript LWingScript;
    public Transform thisTransform;
    public Rigidbody thisRigidbody;
    public Transform thisVTransform;
    public Rigidbody thisVRigidbody;
    public Transform readerTF;
    public int PissedAtTC2;
    public int PissedAtTC3;
    public int PissedAtTC4;
    public int PissedAtTC5;
    public int PissedAtTC6;
    public int PissedAtTC7;
    public static bool IsActive;
    public bool IsRunning;
    public bool Following;
    public bool Obstacle;
    public bool Stuck;
    public bool TargetTooClose;
    public bool TurnRight;
    public bool TurnLeft;
    public LayerMask targetLayers;
    public LayerMask TtargetLayers;
    public float ShotTimer;
    public Vector3 Point1u;
    public Vector3 Point1d;
    public int JustNoticed;
    public int OverPit;
    public virtual void Start()
    {
        this.InvokeRepeating("Reader", 1, 0.15f);
        this.InvokeRepeating("Regenerator", 1, 0.5f);
        this.InvokeRepeating("LeaveMarker", 1, 10);
        this.InvokeRepeating("Targety", 120, 120);
        this.transform.parent = null;
        PiripodAI.IsActive = false;
        this.IsRunning = false;
        this.Following = true;
        this.Waypoint = PlayerInformation.instance.Pirizuka;
        this.target = this.Waypoint;
        WorldInformation.PiriPodPresent = true;
    }

    public virtual void Update()
    {
        if (PiripodAI.IsActive)
        {
            if (this.target)
            {
                Debug.DrawRay(this.readerTF.position, Vector3.down * 48, Color.white);
                if (!Physics.Raycast(this.readerTF.position, Vector3.down, 48, (int) this.TtargetLayers))
                {
                    this.OverPit = 1;
                }
                if (this.OverPit > 0)
                {
                    this.OverPit = this.OverPit - 1;
                    this.thisVRigidbody.useGravity = false;
                }
                else
                {
                    this.thisVRigidbody.useGravity = true;
                }
                Vector3 relativePoint = this.target.InverseTransformPoint(this.thisTransform.position);
                if (-relativePoint.y > 0.5f)
                {
                    this.OverPit = 1;
                }
            }
            if (!this.VesselScript.EngineOn)
            {
                this.VesselScript.Starting = true;
            }
            else
            {
                this.IsRunning = true;
                this.VesselScript.Starting = false;
            }
            if (this.IsRunning)
            {
                Vector3 newRot2 = this.thisRigidbody.velocity;
                if (this.thisVRigidbody.velocity.magnitude > 20)
                {
                    Vector3 newRot = ((-this.thisVTransform.up * 0.6f) + (-this.thisVTransform.right * -0.4f)).normalized;
                    Debug.DrawRay(this.thisVTransform.position + (-this.thisVTransform.up * 2.5f), newRot * 50f, Color.black);
                    if (Physics.Raycast(this.thisVTransform.position + (-this.thisVTransform.up * 2.5f), newRot, 50, (int) this.targetLayers))
                    {
                        if (this.target != null)
                        {
                            if ((Vector3.Distance(this.transform.position, this.target.position) > 5) && (this.JustNoticed < 1))
                            {
                                this.TurnLeft = true;
                            }
                        }
                    }
                    else
                    {
                        this.TurnLeft = false;
                    }
                    newRot = ((-this.thisVTransform.up * 0.6f) + (-this.thisVTransform.right * 0.4f)).normalized;
                    Debug.DrawRay(this.thisVTransform.position + (-this.thisVTransform.up * 2.5f), newRot * 50f, Color.black);
                    if (Physics.Raycast(this.thisVTransform.position + (-this.thisVTransform.up * 2.5f), newRot, 50, (int) this.targetLayers))
                    {
                        if (this.target != null)
                        {
                            if ((Vector3.Distance(this.thisTransform.position, this.target.position) > 5) && (this.JustNoticed < 1))
                            {
                                this.TurnRight = true;
                            }
                        }
                    }
                    else
                    {
                        this.TurnRight = false;
                    }
                    if (this.target)
                    {
                        if (Vector3.Distance(this.thisTransform.position, this.target.position) < 32)
                        {
                            this.TargetTooClose = true;
                        }
                        else
                        {
                            this.TargetTooClose = false;
                        }
                    }
                    if (Physics.Raycast(this.thisVTransform.position + (-this.thisVTransform.up * 2.5f), newRot2, 30, (int) this.targetLayers))
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
                    Vector3 newRot = ((-this.thisVTransform.up * 0.6f) + (-this.thisVTransform.right * -0.4f)).normalized;
                    Debug.DrawRay(this.thisVTransform.position + (-this.thisVTransform.up * 2.5f), newRot * 10f, Color.black);
                    if (Physics.Raycast(this.thisVTransform.position + (-this.thisVTransform.up * 2.5f), newRot, 10, (int) this.targetLayers))
                    {
                        if (this.target != null)
                        {
                            if ((Vector3.Distance(this.thisTransform.position, this.target.position) > 5) && (this.JustNoticed < 1))
                            {
                                this.TurnLeft = true;
                            }
                        }
                    }
                    else
                    {
                        this.TurnLeft = false;
                    }
                    newRot = ((-this.thisVTransform.up * 0.6f) + (-this.thisVTransform.right * 0.4f)).normalized;
                    Debug.DrawRay(this.thisVTransform.position + (-this.thisVTransform.up * 2.5f), newRot * 10f, Color.black);
                    if (Physics.Raycast(this.thisVTransform.position + (-this.thisVTransform.up * 2.5f), newRot, 10, (int) this.targetLayers))
                    {
                        if (this.target != null)
                        {
                            if ((Vector3.Distance(this.thisTransform.position, this.target.position) > 5) && (this.JustNoticed < 1))
                            {
                                this.TurnRight = true;
                            }
                        }
                    }
                    else
                    {
                        this.TurnRight = false;
                    }
                    if (this.target)
                    {
                        if (Vector3.Distance(this.thisTransform.position, this.target.position) < 8)
                        {
                            this.TargetTooClose = true;
                        }
                        else
                        {
                            this.TargetTooClose = false;
                        }
                    }
                    if (Physics.Raycast(this.thisVTransform.position + (-this.thisVTransform.up * 2.5f), newRot2, 15, (int) this.targetLayers))
                    {
                        if (this.JustNoticed < 1)
                        {
                            this.Obstacle = true;
                        }
                        if (this.JustNoticed > 0)
                        {
                            this.Obstacle = false;
                        }
                    }
                    else
                    {
                        this.Obstacle = false;
                    }
                }
                this.RWingScript.RunningW = !this.Obstacle;
                this.LWingScript.RunningW = !this.Obstacle;
                this.RWingScript.RunningA = this.TurnLeft;
                this.LWingScript.RunningA = this.TurnLeft;
                this.RWingScript.RunningD = this.TurnRight;
                this.LWingScript.RunningD = this.TurnRight;
                this.RWingScript.RunningS = this.Obstacle;
                this.LWingScript.RunningS = this.Obstacle;
            }
        }
        else
        {
            this.IsRunning = false;
        }
    }

    private Quaternion NewRotation;
    public virtual void FixedUpdate()
    {
        if (this.IsRunning)
        {
            Vector3 newRot2 = this.thisRigidbody.velocity;
            Vector3 localV = this.thisTransform.InverseTransformDirection(this.thisRigidbody.velocity);
            if (this.OverPit > 0)
            {
                this.thisVRigidbody.AddForce(this.thisVTransform.forward * 14);
            }
            if (this.Obstacle && !this.Stuck)
            {
                if (localV.z > 0)
                {
                    if (localV.z > 20)
                    {
                        this.thisVRigidbody.AddForce(newRot2 * -8);
                    }
                    if (localV.z < 20)
                    {
                        this.thisVRigidbody.AddForce(newRot2 * -4);
                    }
                }
            }
            if (this.TargetTooClose)
            {
                if (localV.z > 0)
                {
                    this.thisVRigidbody.AddForce(this.thisVTransform.up * 40);
                }
            }
            if (this.Stuck)
            {
                if (-localV.z < 5)
                {
                    this.thisVRigidbody.AddForce(this.thisVTransform.up * 40);
                }
            }
            if ((((!this.Obstacle && !this.Stuck) && !this.TurnLeft) && !this.TurnRight) && !this.TargetTooClose)
            {
                if (Vector3.Distance(this.thisTransform.position, this.target.position) > 50)
                {
                    this.thisVRigidbody.AddForce(this.thisVTransform.up * -60);
                }
                else
                {
                    this.thisVRigidbody.AddForce(this.thisVTransform.up * -20);
                }
                this.Gyro.force = 10;
            }
            if (this.TurnLeft)
            {
                this.thisVRigidbody.AddTorque(this.thisVTransform.forward * -50);
                if (localV.z > 8)
                {
                    this.thisVRigidbody.AddForce(this.thisVTransform.up * 20);
                }
            }
            if (this.TurnRight)
            {
                this.thisVRigidbody.AddTorque(this.thisVTransform.forward * 50);
                if (localV.z > 8)
                {
                    this.thisVRigidbody.AddForce(this.thisVTransform.up * 20);
                }
            }
            if (this.TurnLeft && this.TurnRight)
            {
                this.thisVRigidbody.AddTorque(this.thisVTransform.forward * -50);
            }
            //----------------------------------------------------------------------------------------------------------------------
            if (this.target)
            {
                if (this.TurnLeft || this.TurnRight)
                {
                    this.thisRigidbody.freezeRotation = false;
                }
                if (!this.TurnLeft && !this.TurnRight)
                {
                    this.thisRigidbody.freezeRotation = true;
                }
                this.NewRotation = Quaternion.LookRotation(this.target.position - this.thisTransform.position);
                if (!this.TargetTooClose)
                {
                    this.thisTransform.rotation = Quaternion.RotateTowards(this.thisTransform.rotation, this.NewRotation, Time.deltaTime * 200);
                }
            }
        }
    }

    public virtual void Targety()
    {
        this.TargetArea();
    }

    public virtual void TargetArea()
    {
        if (this.IsRunning)
        {
            this.target = this.Waypoint;
            this.Following = true;
        }
    }

    public virtual void LeaveMarker()
    {
        if (this.IsRunning)
        {
            this.Trig.radius = 200;
            Vector3 lastPos = this.thisTransform.position;
            this.StartCoroutine(this.IsEscaping(lastPos));
        }
    }

    public virtual IEnumerator IsEscaping(Vector3 lastPos)
    {
        if (this.IsRunning && !this.TargetTooClose)
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
    }

    public virtual void Regenerator()
    {
        if (CallAssistance.IsSnynsing)
        {
            PiripodAI.IsActive = true;
        }
        if (!this.Presence)
        {
            UnityEngine.Object.Destroy(this.gameObject);
        }
        if (!this.IsRunning)
        {
            this.thisRigidbody.freezeRotation = false;
            if (this.Presence)
            {
                this.Presence.SetActive(false);
            }
        }
        if (this.IsRunning)
        {
            if (this.target)
            {
                if (!Physics.Linecast(this.thisTransform.position, this.target.position, (int) this.TtargetLayers))
                {
                    this.TurnRight = false;
                    this.TurnLeft = false;
                    this.JustNoticed = 1;
                }
            }
            if (this.JustNoticed > 0)
            {
                this.JustNoticed = this.JustNoticed - 1;
            }
            this.Presence.SetActive(true);
        }
    }

    public virtual void Reader()
    {
        RaycastHit hit1 = default(RaycastHit);
        RaycastHit hit2 = default(RaycastHit);
        if (this.target)
        {
            this.readerTF.LookAt(this.target);
        }
        Debug.DrawRay(this.readerTF.position + (this.readerTF.up * 0.5f), this.readerTF.forward * 50f, Color.white);
        if (Physics.Raycast(this.readerTF.position + (this.readerTF.up * 0.5f), this.readerTF.forward, out hit1, 50, (int) this.TtargetLayers))
        {
            this.Point1u = hit1.point;
        }
        Debug.DrawRay(this.readerTF.position + (-this.readerTF.up * 0.5f), this.readerTF.forward * 50f, Color.white);
        if (Physics.Raycast(this.readerTF.position + (-this.readerTF.up * 0.5f), this.readerTF.forward, out hit2, 50, (int) this.TtargetLayers))
        {
            this.Point1d = hit2.point;
        }
        if (Vector3.Distance(this.Point1u, this.Point1d) > 2)
        {
            this.JustNoticed = 1;
        }
    }

    public PiripodAI()
    {
        this.ShotTimer = 0.25f;
    }

}