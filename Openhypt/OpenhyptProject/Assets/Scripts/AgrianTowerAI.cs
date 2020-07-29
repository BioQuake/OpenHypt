using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AgrianTowerAI : MonoBehaviour
{
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public Transform target;
    public Transform Waypoint;
    public Transform ResetPoint;
    public Transform AligningPoint;
    public Transform Spinner;
    public SphereCollider Sensor;
    public bool SensorIncrease;
    public Transform Magnet1;
    public Transform Magnet2;
    public Transform EmptyContainer;
    public Transform FullContainer;
    public bool isCarrier;
    public bool isFleetVessel1;
    public bool isFleetVessel2;
    public bool isFleetVessel3;
    public Transform ContainerBPoint1;
    public Transform ContainerBPoint2;
    public Rigidbody ContainerBPoint1RB;
    public Rigidbody ContainerBPoint2RB;
    public GameObject Vessel;
    public GameObject Clamp;
    public GameObject Presence;
    public AgrianContainerController ContainerScript;
    public GameObject FrontCol;
    public GameObject Gyro;
    public WingScript Stabilizer1;
    public WingScript Stabilizer2;
    public bool GyroOn;
    public int APDist;
    public bool Gonnatow;
    public bool HasEmpty;
    public bool Gonnaput;
    public bool HasFull;
    public bool UpperObstacle;
    public bool Obstacle;
    public bool Brake;
    public bool TargetTooClose;
    public bool TotalObstacle;
    public bool SlowingDown;
    public bool Switch0;
    public bool Switch180;
    public bool Switch;
    public int Rotate;
    public LayerMask targetLayers;
    public int TouchCount;
    public int Reverse;
    public int Still;
    public int CarryingOn;
    public Transform virtualPoint;
    public float UAndD1;
    public float UAndD2;
    private Quaternion NewRotation;
    public virtual void Start()
    {
        this.InvokeRepeating("Reader", 1, 0.5f);
        if (this.isCarrier)
        {
            this.virtualPoint.parent = null;
            this.target = PlayerInformation.instance.PiriTarget;
        }
        else
        {
            this.target = this.ResetPoint;
        }
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        if (this.target != null)
        {
            if (this.target.name.Contains("nerFull"))
            {
                this.target.name = "ContainerOFull";
            }
            if (this.target.name.Contains("TowerDispatchArea"))
            {
                this.target.name = "TowerDispatchOArea";
            }
            if (this.target.name.Contains("TowerDispatchOArea"))
            {
                if (Vector3.Distance(this.thisTransform.position, this.target.position) > 100)
                {
                    this.target = this.ResetPoint;
                }
            }
        }
        if (this.target)
        {
            if (this.Gonnatow)
            {
                if (Vector3.Distance(this.thisTransform.position, this.target.position) < 80)
                {
                    if (this.TouchCount == 0)
                    {
                        this.TargetTooClose = true;
                    }
                }
                else
                {
                    this.TargetTooClose = false;
                }
            }
        }
        if ((this.target == null) && this.Gonnatow)
        {
            this.StopAllCoroutines();
            this.Gonnatow = false;
            ((SphereCollider) this.gameObject.GetComponent(typeof(SphereCollider))).radius = 2000;
        }
        Vector3 newRot = (this.thisTransform.forward * 0.6f).normalized;
        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 30), newRot * 1000f, Color.green);
        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 30), newRot, out hit, 1000) && (this.vRigidbody.velocity.magnitude > 50))
        {
            this.SlowingDown = true;
        }
        else
        {
            if (!this.TotalObstacle)
            {
                this.SlowingDown = false;
            }
        }
        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 20), this.thisTransform.forward * 80f, Color.white);
        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 20), this.thisTransform.forward, 80))
        {
            this.Obstacle = true;
        }
        else
        {
            this.Obstacle = false;
        }
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * 10)) + (this.thisTransform.up * 60), this.thisTransform.forward * 40f, Color.white);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * 10)) + (this.thisTransform.up * 60), this.thisTransform.forward, 40))
        {
            this.UpperObstacle = true;
        }
        else
        {
            this.UpperObstacle = false;
        }
        //========================================================================================================================//
        //////////////////////////////////////////////////////[INTERACTION]/////////////////////////////////////////////////////////
        //========================================================================================================================//
        if (NotiScript.PiriNotis)
        {
            if (Vector3.Distance(this.thisTransform.position, PlayerInformation.instance.Pirizuka.position) < 512)
            {
                this.target = PlayerInformation.instance.PiriTarget;
                NotiScript.PiriNotis = false;
            }
        }
        if (WorldInformation.pSpeech)
        {
            if (Vector3.Distance(this.thisTransform.position, WorldInformation.pSpeech.position) < WorldInformation.pSpeechRange)
            {
                if (Vector3.Distance(this.thisTransform.position, WorldInformation.pSpeech.position) < 512)
                {
                    this.StartCoroutine(this.ProcessSpeech(TalkBubbleScript.myText));
                    WorldInformation.pSpeech = null;
                }
            }
        }
    }

    public virtual void FixedUpdate()
    {
        Vector3 localV = this.thisTransform.InverseTransformDirection(this.GetComponent<Rigidbody>().velocity);
        if (!this.TotalObstacle)
        {
            this.Spinner.Rotate(0, 0, 800 * Time.deltaTime);
        }
        if (!this.Gonnaput && !this.Gonnatow)
        {
            if (this.Sensor.radius > 1999)
            {
                this.SensorIncrease = false;
            }
            if (this.Sensor.radius < 2)
            {
                this.SensorIncrease = true;
            }
            if (!this.SensorIncrease)
            {
                this.Sensor.radius = this.Sensor.radius - 1;
            }
            if (this.SensorIncrease)
            {
                this.Sensor.radius = this.Sensor.radius + 1;
            }
        }
        if (!this.isCarrier)
        {
            if (this.target)
            {
                this.NewRotation = Quaternion.LookRotation(this.target.position - this.thisTransform.position);
                this.thisTransform.rotation = Quaternion.RotateTowards(this.thisTransform.rotation, this.NewRotation, Time.deltaTime * 20);
            }
            if (((this.Reverse < 1) && !this.Gonnatow) && !this.Gonnaput)
            {
                Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * 20)) + (this.Spinner.transform.up * 120), this.thisTransform.forward * 1000f, Color.red);
                if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * 20)) + (this.Spinner.transform.up * 120), this.thisTransform.forward, 1000))
                {
                    this.vRigidbody.AddTorque(this.Spinner.transform.right * 200000);
                    this.TotalObstacle = true;
                    this.SlowingDown = true;
                }
                else
                {
                    this.TotalObstacle = false;
                    this.SlowingDown = false;
                }
            }
            if (this.SlowingDown)
            {
                if (localV.z > 50)
                {
                    this.vRigidbody.AddForce(-this.thisVTransform.up * -100000);
                }
            }
            if (this.Obstacle && !this.Gonnaput)
            {
                if (localV.z > 0)
                {
                    if (this.APDist < 128)
                    {
                        if (this.Clamp.GetComponent<Rigidbody>().angularVelocity.magnitude > 0.04f)
                        {
                            this.vRigidbody.AddForce(-this.thisVTransform.up * -100000);
                        }
                    }
                    else
                    {
                        this.vRigidbody.AddForce(-this.thisVTransform.up * -100000);
                    }
                }
            }
            if (this.UpperObstacle)
            {
                if (localV.z > 0)
                {
                    this.vRigidbody.AddForce(-this.thisVTransform.up * -100000);
                }
                this.vRigidbody.AddForce(this.thisVTransform.forward * -30000);
                this.vRigidbody.AddTorque(this.thisTransform.right * 400000);
            }
            if (this.Brake && !this.Gonnaput)
            {
                if (localV.z > 0)
                {
                    this.vRigidbody.AddForce(-this.thisVTransform.up * -30000);
                }
                this.Stabilizer1.AxisDrag.x = -1360;
                this.Stabilizer1.AxisDrag.y = -1360;
                this.Stabilizer1.AxisDrag.z = -1360;
            }
            if (this.Gonnatow && !this.TargetTooClose)
            {
                this.vRigidbody.AddForce(-this.thisVTransform.up * 20000);
            }
            if (this.Gonnaput && !this.TargetTooClose)
            {
                this.vRigidbody.AddForce(-this.thisVTransform.up * 20000);
            }
            if (this.Reverse > 0)
            {
                this.vRigidbody.AddForce(-this.thisVTransform.up * -50000);
            }
            if ((((!this.Gonnatow && !this.Obstacle) && !this.SlowingDown) && !this.Brake) && !this.TotalObstacle)
            {
                if (this.Reverse < 1)
                {
                    this.vRigidbody.AddForce(-this.thisVTransform.up * 20000);
                }
            }
        }
        else
        {
            Vector3 CBP1localV = this.ContainerBPoint1.InverseTransformDirection(this.ContainerBPoint1RB.velocity);
            Vector3 CBP2localV = this.ContainerBPoint2.InverseTransformDirection(this.ContainerBPoint2RB.velocity);
            float LAndR = 0.0f;
            float FAndB = 0.0f;
            if (this.target)
            {
                Vector3 relativePoint = this.thisVTransform.InverseTransformPoint(this.target.position);
                LAndR = relativePoint.x;
                FAndB = relativePoint.y;
            }
            float Vel1 = -CBP1localV.y * 4;
            float  Vel2 = -CBP2localV.y * 4;
            float velMag1 = Mathf.Clamp(Vel1 * 2, 4, 32);
            float velMag2 = Mathf.Clamp(Vel2 * 2, 4, 32);
            Debug.DrawRay(this.ContainerBPoint1.position + (-this.ContainerBPoint1.up * 50), Vector3.down * 1024, Color.magenta);
            if (Physics.Raycast(this.ContainerBPoint1.position + (-this.ContainerBPoint1.up * 50), Vector3.down, 1024))
            {
                Debug.DrawRay(this.ContainerBPoint1.position + (-this.ContainerBPoint1.up * 50), Vector3.down * velMag1, Color.red);
                if (Physics.Raycast(this.ContainerBPoint1.position + (-this.ContainerBPoint1.up * 50), Vector3.down, velMag1))
                {
                    this.vRigidbody.AddForceAtPosition(-Vector3.down * 40000, this.ContainerBPoint1.position);
                }
                else
                {
                    this.vRigidbody.AddForceAtPosition(Vector3.down * 5000, this.ContainerBPoint1.position);
                }
                Debug.DrawRay(this.ContainerBPoint2.position + (-this.ContainerBPoint2.up * 50), Vector3.down * velMag2, Color.red);
                if (Physics.Raycast(this.ContainerBPoint2.position + (-this.ContainerBPoint2.up * 50), Vector3.down, velMag2))
                {
                    this.vRigidbody.AddForceAtPosition(-Vector3.down * 40000, this.ContainerBPoint2.position);
                }
                else
                {
                    this.vRigidbody.AddForceAtPosition(Vector3.down * 5000, this.ContainerBPoint2.position);
                }
            }
            else
            {
                Vector3 relativePoint1 = this.virtualPoint.InverseTransformPoint(this.ContainerBPoint1.position);
                Vector3 relativePoint2 = this.virtualPoint.InverseTransformPoint(this.ContainerBPoint2.position);
                this.UAndD1 = relativePoint1.y;
                this.UAndD2 = relativePoint2.y;
                float HoverForce1 = Mathf.Clamp(this.UAndD1 * 400, -40000, 5000);
                float HoverForce2 = Mathf.Clamp(this.UAndD2 * 400, -40000, 5000);
                this.vRigidbody.AddForceAtPosition(Vector3.down * HoverForce1, this.ContainerBPoint1.position);
                this.vRigidbody.AddForceAtPosition(Vector3.down * HoverForce2, this.ContainerBPoint2.position);
            }
            if (this.Rotate > 1)
            {
                if (LAndR < -1)
                {
                    this.vRigidbody.AddTorque(this.thisVTransform.forward * 400000);
                }
                if (LAndR > 1)
                {
                    this.vRigidbody.AddTorque(this.thisVTransform.forward * -400000);
                }
                if ((-LAndR < 1) && (LAndR < 1))
                {
                    this.Rotate = this.Rotate - 1;
                }
            }
        }
        if (this.GyroOn)
        {
            if (this.Clamp.GetComponent<Rigidbody>().angularVelocity.magnitude < 0.5f)
            {
                this.Gyro.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.up * 30000, this.Gyro.transform.up * 50);
                this.Gyro.GetComponent<Rigidbody>().AddForceAtPosition(-Vector3.up * 30000, -this.Gyro.transform.up * 50);
            }
        }
        if (this.Gonnatow)
        {
            if (this.target != this.ResetPoint)
            {
                this.APDist = (int) Vector3.Distance(this.thisTransform.position, this.AligningPoint.transform.position);
                if (this.Clamp.GetComponent<Rigidbody>().angularVelocity.magnitude > 0.05f)
                {
                    this.GetComponent<Rigidbody>().AddForce((this.AligningPoint.transform.position - this.thisTransform.position).normalized * 60000);
                }
                else
                {
                    this.GetComponent<Rigidbody>().AddForce((this.AligningPoint.transform.position - this.thisTransform.position).normalized * 15000);
                }
            }
        }
        if (this.Gonnaput)
        {
            if (this.target != this.ResetPoint)
            {
                if (this.Clamp.GetComponent<Rigidbody>().angularVelocity.magnitude > 0.05f)
                {
                    if (Vector3.Distance(this.thisTransform.position, this.AligningPoint.transform.position) > 60)
                    {
                        this.GetComponent<Rigidbody>().AddForce((this.AligningPoint.transform.position - this.thisTransform.position).normalized * 30000);
                    }
                }
                else
                {
                    this.GetComponent<Rigidbody>().AddForce((this.AligningPoint.transform.position - this.thisTransform.position).normalized * 15000);
                }
            }
        }
        if (this.Switch180)
        {
            if (this.Vessel.GetComponent<HingeJoint>().spring.targetPosition < 180)
            {

                {
                    float _604 = this.Vessel.GetComponent<HingeJoint>().spring.targetPosition + 0.4f;
                    JointSpring _605 = this.Vessel.GetComponent<HingeJoint>().spring;
                    _605.targetPosition = _604;
                    this.Vessel.GetComponent<HingeJoint>().spring = _605;
                }
            }
            if (this.Vessel.GetComponent<HingeJoint>().spring.targetPosition > 180)
            {

                {
                    int _606 = 180;
                    JointSpring _607 = this.Vessel.GetComponent<HingeJoint>().spring;
                    _607.targetPosition = _606;
                    this.Vessel.GetComponent<HingeJoint>().spring = _607;
                }
                this.TouchCount = 0;
                this.Brake = false;
                this.Switch = false;
            }
        }
        if (this.Switch0)
        {
            if (this.Vessel.GetComponent<HingeJoint>().spring.targetPosition > 0)
            {

                {
                    float _608 = this.Vessel.GetComponent<HingeJoint>().spring.targetPosition - 0.4f;
                    JointSpring _609 = this.Vessel.GetComponent<HingeJoint>().spring;
                    _609.targetPosition = _608;
                    this.Vessel.GetComponent<HingeJoint>().spring = _609;
                }
            }
            if (this.Vessel.GetComponent<HingeJoint>().spring.targetPosition < 0)
            {

                {
                    int _610 = 0;
                    JointSpring _611 = this.Vessel.GetComponent<HingeJoint>().spring;
                    _611.targetPosition = _610;
                    this.Vessel.GetComponent<HingeJoint>().spring = _611;
                }
                this.TouchCount = 0;
                this.Brake = false;
                this.Switch = false;
            }
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if (this.isCarrier)
        {
            return;
        }
        if (other.GetComponent<Collider>().name.Contains("nerFull") && !this.HasFull)
        {
            if (Vector3.Distance(this.thisTransform.position, other.transform.position) > 72)
            {
                this.Gonnatow = true;
                this.GyroOn = false;
                this.target = other.gameObject.transform;
                this.Clamp.GetComponent<Rigidbody>().angularDrag = 10;
                ((SphereCollider) this.gameObject.GetComponent(typeof(SphereCollider))).radius = 75;
                this.FrontCol.gameObject.SetActive(false);
                this.AligningPoint = other.gameObject.GetComponent<AgrianContainerPoint>().AlignPoint;
            }
        }
        if (other.GetComponent<Collider>().name.Contains("nerEmpty") && !this.HasEmpty)
        {
            if (Vector3.Distance(this.thisTransform.position, other.transform.position) < 72)
            {
                other.gameObject.name = "ContainerOEmpty";
                this.EmptyContainer = other.gameObject.transform;
                this.HasEmpty = true;
            }
        }
        if (other.GetComponent<Collider>().name.Contains("nerOFull") && !this.HasFull)
        {
            if ((Vector3.Distance(this.thisTransform.position, other.transform.position) < 80) && (Vector3.Distance(this.thisTransform.position, this.AligningPoint.transform.position) < 100))
            {
                this.FullContainer = other.gameObject.transform;
                this.HasFull = true;
                this.Brake = true;
                ((SphereCollider) this.gameObject.GetComponent(typeof(SphereCollider))).radius = 1;
            }
        }
        if (other.GetComponent<Collider>().name.Contains("TowerDispatchArea"))
        {
            if (this.HasEmpty)
            {
                this.Gonnaput = true;
                this.GyroOn = false;
                this.TouchCount = 0;
                this.target = other.gameObject.transform;
                this.Clamp.GetComponent<Rigidbody>().angularDrag = 40;
                ((SphereCollider) this.gameObject.GetComponent(typeof(SphereCollider))).radius = 75;
                this.FrontCol.gameObject.SetActive(false);
                this.AligningPoint = other.gameObject.GetComponent<AgrianContainerPoint>().AlignPoint;
            }
        }
        if ((other.GetComponent<Collider>().name.Contains("nerEmpty") && !this.Gonnaput) && !this.Gonnatow)
        {
            if (Vector3.Distance(this.thisTransform.position, other.transform.position) > 72)
            {
                this.SensorIncrease = true;
                this.Sensor.radius = 1;
            }
        }
    }

    public virtual void Reader()
    {
        RaycastHit hit = default(RaycastHit);
        if (this.isCarrier)
        {

            {
                float _612 = this.thisVTransform.position.x;
                Vector3 _613 = this.virtualPoint.position;
                _613.x = _612;
                this.virtualPoint.position = _613;
            }

            {
                float _614 = this.thisVTransform.position.z;
                Vector3 _615 = this.virtualPoint.position;
                _615.z = _614;
                this.virtualPoint.position = _615;
            }
        }
        this.vRigidbody.centerOfMass = new Vector3(0, 0, 0);
        this.Clamp.GetComponent<Rigidbody>().centerOfMass = new Vector3(0, 0, 0);
        this.GetComponent<Rigidbody>().freezeRotation = true;
        if (this.Gonnatow)
        {
            if (Vector3.Distance(this.thisTransform.position, this.target.position) < 300)
            {
                this.Stabilizer1.AxisDrag.x = -1360;
                this.Stabilizer1.AxisDrag.y = -1360;
                this.Stabilizer1.AxisDrag.z = -1360;
                if (this.Clamp.GetComponent<Rigidbody>().angularVelocity.magnitude < 0.1f)
                {
                    this.Stabilizer2.AxisDrag.x = 0;
                    this.Stabilizer2.AxisDrag.y = -1360;
                    this.Stabilizer2.AxisDrag.z = 0;
                }
                else
                {
                    this.Stabilizer2.AxisDrag.x = -1360;
                    this.Stabilizer2.AxisDrag.y = 0;
                    this.Stabilizer2.AxisDrag.z = -1360;
                }
            }
            if (Vector3.Distance(this.thisTransform.position, this.target.position) > 300)
            {
                this.Stabilizer1.AxisDrag.x = -1360;
                this.Stabilizer1.AxisDrag.y = 0;
                this.Stabilizer1.AxisDrag.z = -1360;
                this.Stabilizer2.AxisDrag.x = -1360;
                this.Stabilizer2.AxisDrag.y = 0;
                this.Stabilizer2.AxisDrag.z = -1360;
            }
        }
        if (this.Gonnaput)
        {
            if (Vector3.Distance(this.thisTransform.position, this.target.position) < 300)
            {
                this.Stabilizer1.AxisDrag.x = -1360;
                this.Stabilizer1.AxisDrag.y = -1360;
                this.Stabilizer1.AxisDrag.z = -1360;
                if (this.Switch)
                {
                    this.Stabilizer2.AxisDrag.x = 0;
                    this.Stabilizer2.AxisDrag.y = 0;
                    this.Stabilizer2.AxisDrag.z = 0;
                }
                else
                {
                    this.Stabilizer2.AxisDrag.x = -680;
                    this.Stabilizer2.AxisDrag.y = -680;
                    this.Stabilizer2.AxisDrag.z = -680;
                }
            }
            if (Vector3.Distance(this.thisTransform.position, this.target.position) > 300)
            {
                this.Stabilizer1.AxisDrag.x = -1360;
                this.Stabilizer1.AxisDrag.y = 0;
                this.Stabilizer1.AxisDrag.z = -1360;
                this.Stabilizer2.AxisDrag.x = -1360;
                this.Stabilizer2.AxisDrag.y = 0;
                this.Stabilizer2.AxisDrag.z = -1360;
            }
        }
        if (this.Reverse > 0)
        {
            this.Reverse = this.Reverse - 1;
            this.Stabilizer1.AxisDrag.x = 0;
            this.Stabilizer1.AxisDrag.y = 0;
            this.Stabilizer1.AxisDrag.z = 0;
        }
        if (!this.Gonnaput && !this.Gonnatow)
        {
            if (this.vRigidbody.velocity.magnitude < 1)
            {
                this.Still = this.Still + 1;
            }
            else
            {
                this.Still = 0;
            }
            this.Stabilizer1.AxisDrag.x = 0;
            this.Stabilizer1.AxisDrag.y = 0;
            this.Stabilizer1.AxisDrag.z = 0;
            this.Stabilizer2.AxisDrag.x = -1360;
            this.Stabilizer2.AxisDrag.y = 0;
            this.Stabilizer2.AxisDrag.z = -1360;
        }
        if (this.Gonnaput || this.Gonnatow)
        {
            if ((this.target == this.ResetPoint) && (this.CarryingOn < 20))
            {
                this.CarryingOn = this.CarryingOn + 1;
            }
        }
        if (this.CarryingOn == 20)
        {
            this.CarryingOn = 0;
            this.Gonnaput = false;
            this.Gonnatow = false;
        }
        if (this.Still == 20)
        {
            this.Still = 0;
            this.Brake = false;
            this.Stabilizer1.AxisDrag.x = 0;
            this.Stabilizer1.AxisDrag.y = 0;
            this.Stabilizer1.AxisDrag.z = 0;
        }
        if (this.target)
        {
            if (this.target.name.Contains("Front"))
            {
                this.GetComponent<Rigidbody>().freezeRotation = false;
            }
        }
        if (this.TouchCount == 16)
        {
            if (this.Switch180 && !this.Switch)
            {
                this.Switch = true;
                this.Switch180 = false;
                this.Switch0 = true;
            }
            if (this.Switch0 && !this.Switch)
            {
                this.Switch = true;
                this.Switch0 = false;
                this.Switch180 = true;
            }
            this.Obstacle = false;
            this.Gonnatow = false;
            this.TargetTooClose = false;
            this.GetComponent<Rigidbody>().freezeRotation = false;
            this.GyroOn = true;
            this.TouchCount = 0;
            this.Clamp.GetComponent<Rigidbody>().angularDrag = 10;
            ((SphereCollider) this.gameObject.GetComponent(typeof(SphereCollider))).radius = 2000;
        }
        if (this.Gonnaput)
        {
            if (Vector3.Distance(this.thisTransform.position, this.EmptyContainer.position) > 72)
            {
                this.EmptyContainer = null;
                this.HasEmpty = false;
                this.Gonnaput = false;
                this.TargetTooClose = false;
                this.GetComponent<Rigidbody>().freezeRotation = false;
                this.target = this.ResetPoint;
                this.Reverse = 4;
                this.GyroOn = true;
                this.TouchCount = 0;
                this.Clamp.GetComponent<Rigidbody>().angularDrag = 10;
                ((SphereCollider) this.gameObject.GetComponent(typeof(SphereCollider))).radius = 2000;
                this.FrontCol.gameObject.SetActive(true);
            }
        }
        Debug.DrawRay(this.thisTransform.position, this.thisTransform.forward * 30f, Color.red);
        if (this.Gonnatow)
        {
            if (Physics.Raycast(this.thisTransform.position, this.thisTransform.forward, out hit, 30, (int) this.targetLayers))
            {
                this.TargetTooClose = false;
                this.TouchCount = this.TouchCount + 1;
            }
            else
            {
                this.TouchCount = 0;
            }
        }
    }

    //========================================================================================================================//
    //////////////////////////////////////////////////////[INTERACTION]/////////////////////////////////////////////////////////
    //========================================================================================================================//
    public int convNum;
    public virtual IEnumerator ProcessSpeech(string speech)//===============================================================================
    {
        yield return new WaitForSeconds(0.1f);
        if (!!string.IsNullOrEmpty(speech))
        {
            yield break;
        }
        if (this.isCarrier)
        {
            if (this.convNum == 0)
            {
                //===============================================================================
                if (speech.Contains("carrier") || speech.Contains("tower"))
                {
                    this.convNum = 1;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("What is your request?");
                    yield break;
                }
            }
            //===============================================================================
            if (this.convNum == 1)
            {
                //===============================================================================
                if (speech.Contains("pen"))
                {
                    this.convNum = 0;
                    yield return new WaitForSeconds(2);
                    this.ContainerScript.Open();
                    yield break;
                }
                if (speech.Contains("lose"))
                {
                    this.convNum = 0;
                    yield return new WaitForSeconds(2);
                    this.ContainerScript.Close();
                    yield break;
                }
                if (speech.Contains("otate") || speech.Contains("urn"))
                {
                    this.convNum = 0;
                    yield return new WaitForSeconds(2);
                    this.ReturnSpeech("I will turn facing away from you.");
                    this.Rotate = 300;
                    yield break;
                }
                yield return new WaitForSeconds(3);
                this.ReturnSpeech("I can not understand your request. \n Do you want me to rotate, close or open?");
                this.convNum = 1;
                yield break;
            }
        }
    }

    public virtual void ReturnSpeech(string yourText)
    {
        GameObject Load = ((GameObject) Resources.Load("Prefabs/TalkBubble", typeof(GameObject))) as GameObject;
        GameObject TGO = UnityEngine.Object.Instantiate(Load, this.thisTransform.position, Load.transform.rotation);
        TGO.name = "CFC2";
        TalkBubbleScript.myText = yourText;
        ((TalkBubbleScript) TGO.GetComponent(typeof(TalkBubbleScript))).source = this.thisVTransform;
    }

}