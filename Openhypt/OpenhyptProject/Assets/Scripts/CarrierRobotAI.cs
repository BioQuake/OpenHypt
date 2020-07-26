using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class CarrierRobotAI : MonoBehaviour
{
    public Transform target;
    public Transform Waypoint;
    public Transform Waypoint2;
    public Transform RE;
    public Transform Sensor;
    public GameObject Vessel;
    public GyroStabilizer Gyro;
    public GameObject Presence;
    public GameObject Translator;
    public GameObject Hook1;
    public GameObject Hook2;
    public bool TranslatorMovingOut;
    public bool TranslatorMovingIn;
    public bool HookMovingOut;
    public bool HookMovingIn;
    public bool HookOut;
    public bool TranslatorOut;
    public bool BackBoost;
    public float TranslatorEnd;
    public float Hook1End;
    public float Hook2End;
    public int AimSpeed;
    public bool InService;
    public bool Grab;
    public bool Bring;
    public bool PutIn;
    public bool PutDown;
    public bool ReverseOut;
    public bool Repositioning;
    public bool TurnRight;
    public bool TurnLeft;
    public bool Obstacle;
    public bool CargObstacle;
    public bool CargObstacleAble;
    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        if (this.target == null)
        {
            this.InService = false;
            ((SphereCollider) this.gameObject.GetComponent(typeof(SphereCollider))).radius = 20;
            this.target = this.Waypoint;
            this.StopAllCoroutines();
        }
        Vector3 newRot = ((this.transform.forward * 0.6f) + (this.transform.up * 0.1f)).normalized;
        newRot = ((this.transform.forward * 0.4f) + (this.transform.right * 0.4f)).normalized;
        Debug.DrawRay(this.transform.position + (this.transform.forward * 1), newRot * 2.5f, Color.black);
        if (Physics.Raycast(this.transform.position + (this.transform.forward * 1), newRot, out hit, 2.5f))
        {
            if (!(hit.collider.tag == "ElementMaterials"))
            {
                this.TurnLeft = true;
            }
            if (((hit.collider.tag == "Metal") || (hit.collider.tag == "Terrain")) || (hit.collider.tag == "MetalStructure"))
            {
                this.TurnLeft = true;
            }
        }
        else
        {
            this.TurnLeft = false;
        }
        newRot = ((this.transform.forward * 0.4f) + (this.transform.right * -0.4f)).normalized;
        Debug.DrawRay(this.transform.position + (this.transform.forward * 1), newRot * 2.5f, Color.black);
        if (Physics.Raycast(this.transform.position + (this.transform.forward * 1), newRot, out hit, 2.5f))
        {
            if (!(hit.collider.tag == "ElementMaterials"))
            {
                this.TurnRight = true;
            }
        }
        else
        {
            this.TurnRight = false;
        }
        if (this.InService)
        {
            Debug.DrawRay(this.Sensor.position, this.Sensor.up * 1f, Color.green);
            if (Physics.Raycast(this.Sensor.position, this.Sensor.up, 1))
            {
                this.TranslatorOut = true;
                this.TranslatorMovingOut = false;
            }
        }
        if (!this.Grab)
        {
            Debug.DrawRay(this.transform.position, this.transform.forward * 4f, Color.green);
            if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, 4))
            {
                if (hit.collider.tag == "TargetCol")
                {
                    this.Obstacle = false;
                }
                else
                {
                    this.Obstacle = true;
                }
            }
            else
            {
                this.Obstacle = false;
            }
        }
        if (this.Grab)
        {
            Debug.DrawRay(this.transform.position + (this.transform.forward * 1.9f), this.transform.forward * 1f, Color.green);
            if (Physics.Raycast(this.transform.position + (this.transform.forward * 1.9f), this.transform.forward, out hit, 1f))
            {
                if (!(hit.collider.tag == "ElementMaterials"))
                {
                    this.Obstacle = true;
                }
                if (((hit.collider.tag == "ElementMaterials") && this.PutIn) && this.CargObstacleAble)
                {
                    this.CargObstacle = true;
                }
                if (((hit.collider.tag == "Metal") || (hit.collider.tag == "Terrain")) || (hit.collider.tag == "MetalStructure"))
                {
                    this.Obstacle = true;
                }
            }
            else
            {
                this.Obstacle = false;
            }
        }
    }

    private Quaternion NewRotation;
    public virtual void FixedUpdate()
    {
        if (!this.TurnLeft || !this.TurnRight)
        {
            this.NewRotation = Quaternion.LookRotation(this.target.position - this.transform.position);
            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, this.NewRotation, Time.deltaTime * this.AimSpeed);
        }

        {
            int _1042 = 0;
            Vector3 _1043 = this.Translator.transform.localPosition;
            _1043.x = _1042;
            this.Translator.transform.localPosition = _1043;
        }

        {
            int _1044 = 0;
            Vector3 _1045 = this.Translator.transform.localPosition;
            _1045.y = _1044;
            this.Translator.transform.localPosition = _1045;
        }
        this.Translator.transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (this.TranslatorMovingIn || this.TranslatorMovingOut)
        {
            if (((ConfigurableJoint) this.Translator.GetComponent(typeof(ConfigurableJoint))).targetPosition.z < -this.TranslatorEnd)
            {
                this.TranslatorOut = true;
                this.TranslatorMovingOut = false;
            }
            if (((ConfigurableJoint) this.Translator.GetComponent(typeof(ConfigurableJoint))).targetPosition.z > 0)
            {
                this.TranslatorOut = false;
                this.TranslatorMovingIn = false;
            }
        }
        if (this.HookMovingIn || this.HookMovingOut)
        {
            if (this.Hook1.GetComponent<HingeJoint>().spring.targetPosition == this.Hook1End)
            {
                this.HookOut = true;
                this.HookMovingOut = false;
            }
            if (this.Hook1.GetComponent<HingeJoint>().spring.targetPosition == 0)
            {
                this.HookOut = false;
                this.HookMovingIn = false;
            }
        }
        if (this.TranslatorMovingOut)
        {
            if (((ConfigurableJoint) this.Translator.GetComponent(typeof(ConfigurableJoint))).targetPosition.z < this.TranslatorEnd)
            {
                ((ConfigurableJoint) this.Translator.GetComponent(typeof(ConfigurableJoint))).targetPosition = ((ConfigurableJoint) this.Translator.GetComponent(typeof(ConfigurableJoint))).targetPosition - new Vector3(0, 0, 0.01f);
            }
        }
        if (this.TranslatorMovingIn)
        {
            if (((ConfigurableJoint) this.Translator.GetComponent(typeof(ConfigurableJoint))).targetPosition.z < 0)
            {
                ((ConfigurableJoint) this.Translator.GetComponent(typeof(ConfigurableJoint))).targetPosition = ((ConfigurableJoint) this.Translator.GetComponent(typeof(ConfigurableJoint))).targetPosition + new Vector3(0, 0, 0.01f);
            }
        }
        if (this.HookMovingOut)
        {
            if (this.Hook1.GetComponent<HingeJoint>().spring.targetPosition < this.Hook1End)
            {

                {
                    float _1046 = this.Hook1.GetComponent<HingeJoint>().spring.targetPosition + 1;
                    JointSpring _1047 = this.Hook1.GetComponent<HingeJoint>().spring;
                    _1047.targetPosition = _1046;
                    this.Hook1.GetComponent<HingeJoint>().spring = _1047;
                }
            }
            if (this.Hook2.GetComponent<HingeJoint>().spring.targetPosition > this.Hook2End)
            {

                {
                    float _1048 = this.Hook2.GetComponent<HingeJoint>().spring.targetPosition - 1;
                    JointSpring _1049 = this.Hook2.GetComponent<HingeJoint>().spring;
                    _1049.targetPosition = _1048;
                    this.Hook2.GetComponent<HingeJoint>().spring = _1049;
                }
            }
        }
        if (this.HookMovingIn)
        {
            if (this.Hook1.GetComponent<HingeJoint>().spring.targetPosition > 0)
            {

                {
                    float _1050 = this.Hook1.GetComponent<HingeJoint>().spring.targetPosition - 1;
                    JointSpring _1051 = this.Hook1.GetComponent<HingeJoint>().spring;
                    _1051.targetPosition = _1050;
                    this.Hook1.GetComponent<HingeJoint>().spring = _1051;
                }
            }
            if (this.Hook2.GetComponent<HingeJoint>().spring.targetPosition < 0)
            {

                {
                    float _1052 = this.Hook2.GetComponent<HingeJoint>().spring.targetPosition + 1;
                    JointSpring _1053 = this.Hook2.GetComponent<HingeJoint>().spring;
                    _1053.targetPosition = _1052;
                    this.Hook2.GetComponent<HingeJoint>().spring = _1053;
                }
            }
        }
        Vector3 localV = this.Vessel.transform.InverseTransformDirection(this.Vessel.GetComponent<Rigidbody>().velocity);
        if (this.TurnLeft && !this.PutDown)
        {
            this.Gyro.GetComponent<Rigidbody>().AddTorque(this.transform.up * -80);
        }
        if (this.TurnRight && !this.PutDown)
        {
            this.Gyro.GetComponent<Rigidbody>().AddTorque(this.transform.up * 80);
        }
        if (this.BackBoost)
        {
            if (localV.y > 2)
            {
                this.Vessel.GetComponent<Rigidbody>().AddForce(this.Vessel.transform.up * 20);
            }
        }
        if (this.Obstacle)
        {
            if (-localV.y > 0.5f)
            {
                this.Vessel.GetComponent<Rigidbody>().AddForce(this.Vessel.transform.up * 4);
            }
            if (this.InService && (-localV.y < 0.4f))
            {
                this.Vessel.GetComponent<Rigidbody>().AddForce(this.Vessel.transform.up * -1);
            }
            if (this.Grab)
            {
                this.Vessel.GetComponent<Rigidbody>().AddForce(this.Vessel.transform.up * 1);
            }
        }
        if (((!this.Obstacle && this.InService) && !this.Grab) && !this.ReverseOut)
        {
            if (-localV.y < 2)
            {
                this.Vessel.GetComponent<Rigidbody>().AddForce(this.Vessel.transform.up * -5);
            }
        }
        if (((!this.Obstacle && this.InService) && this.Bring) && !this.ReverseOut)
        {
            if (-localV.y < 2)
            {
                this.Vessel.GetComponent<Rigidbody>().AddForce(this.Vessel.transform.up * -4);
            }
        }
        if (this.InService && this.ReverseOut)
        {
            if (localV.y > 2)
            {
                this.Vessel.GetComponent<Rigidbody>().AddForce(this.Vessel.transform.up * 4);
            }
        }
        if ((!this.Obstacle && this.InService) && this.Repositioning)
        {
            if (-localV.y < 2)
            {
                this.Vessel.GetComponent<Rigidbody>().AddForce(this.Vessel.transform.up * -5);
            }
        }
        //-----------------------------------------------------------------------------------------------------------------
        if (this.target)
        {
            if ((Vector3.Distance(this.transform.position, this.target.position) < 2) && (this.target.name == "RecieveStart"))
            {
                if (localV.y > -0.1f)
                {
                    this.Vessel.GetComponent<Rigidbody>().AddForce(this.Vessel.transform.up * 20);
                }
            }
            if ((Vector3.Distance(this.transform.position, this.target.position) < 2) && (this.target.name == "RecieveEnd"))
            {
                if (localV.y > -0.1f)
                {
                    this.Vessel.GetComponent<Rigidbody>().AddForce(this.Vessel.transform.up * 20);
                }
            }
            if ((Vector3.Distance(this.transform.position, this.target.position) < 2) && (this.target.name == "CRPosition"))
            {
                if (localV.y > -0.1f)
                {
                    this.Vessel.GetComponent<Rigidbody>().AddForce(this.Vessel.transform.up * 20);
                }
            }
        }
        if (this.CargObstacle)
        {
            if (localV.y > -0.1f)
            {
                this.Vessel.GetComponent<Rigidbody>().AddForce(this.Vessel.transform.up * 20);
            }
        }
        if (this.target)
        {
            if ((((((((Vector3.Distance(this.transform.position, this.target.position) < 3) && this.InService) && !this.HookOut) && !this.Grab) && !this.Bring) && !this.PutIn) && !this.HookMovingOut) && !this.Repositioning)
            {
                this.HookControl();
            }
            if (((((((Vector3.Distance(this.transform.position, this.target.position) < 1.6f) && this.InService) && this.HookOut) && !this.Grab) && !this.Bring) && !this.PutIn) && !this.Repositioning)
            {
                this.HookControl();
                this.Grab = true;
            }
            if ((((((((Vector3.Distance(this.transform.position, this.target.position) < 1.6f) && this.InService) && !this.TranslatorMovingOut) && this.Grab) && !this.Bring) && !this.PutIn) && !this.HookOut) && !this.Repositioning)
            {
                this.TranslatorControl();
                this.Vessel.GetComponent<Rigidbody>().centerOfMass = new Vector3(0, 2, 0);
                this.Gyro.force = 100;
                ((SphereCollider) this.gameObject.GetComponent(typeof(SphereCollider))).radius = 30;
            }
            if ((((((Vector3.Distance(this.transform.position, this.target.position) < 1.5f) && (this.target.name == "RecieveStart")) && this.InService) && this.Grab) && this.Bring) && !this.Repositioning)
            {
                if (localV.y < 0.1f)
                {
                    ((SphereCollider) this.gameObject.GetComponent(typeof(SphereCollider))).radius = 30;
                }
            }
            if ((((((((Vector3.Distance(this.transform.position, this.target.position) < 1.8f) && (this.target.name == "RecieveEnd")) && this.InService) && this.Grab) && this.Bring) && this.PutIn) && !this.CargObstacle) && !this.Repositioning)
            {
                this.TranslatorControl();
                this.PutDown = true;
                this.target = this.Waypoint;
            }
            if (((((((this.target.name == "RecieveEnd") && this.InService) && this.Grab) && this.Bring) && this.PutIn) && this.CargObstacle) && !this.Repositioning)
            {
                this.TranslatorControl();
                this.PutDown = true;
                this.target = this.Waypoint;
            }
            if ((((((((this.target.name == "DirectionForward") && this.InService) && this.Grab) && this.Bring) && this.PutIn) && !this.TranslatorOut) && !this.HookOut) && !this.ReverseOut)
            {
                this.HookControl();
                this.Grab = false;
                this.AimSpeed = 100;
                this.Vessel.GetComponent<Rigidbody>().centerOfMass = new Vector3(0, 0, 0);
                this.Gyro.force = 10;
                this.CargObstacle = false;
                this.ReverseOut = true;
            }
            if (this.RE)
            {
                if (((((Vector3.Distance(this.transform.position, this.RE.position) > 20) && (this.target.name == "DirectionForward")) && this.InService) && this.ReverseOut) && !this.Repositioning)
                {
                    this.Repositioning = true;
                    this.Bring = false;
                    this.PutIn = false;
                    this.PutDown = false;
                    this.ReverseOut = false;
                    this.CargObstacleAble = false;
                    this.HookControl();
                    this.RE = null;
                    ((SphereCollider) this.gameObject.GetComponent(typeof(SphereCollider))).radius = 30;
                }
            }
            if ((((Vector3.Distance(this.transform.position, this.target.position) < 1.5f) && (this.target.name == "CRPosition")) && this.Repositioning) && this.InService)
            {
                this.InService = false;
                this.Repositioning = false;
                this.target = this.Waypoint;
                ((SphereCollider) this.gameObject.GetComponent(typeof(SphereCollider))).radius = 30;
            }
        }
    }

    //-----------------------------------------------------------------------------------------------------------------
    public virtual void OnTriggerStay(Collider other)
    {
        if (((!this.Grab && !this.InService) && !this.ReverseOut) && !this.Repositioning)
        {
            if (((other.tag == "ElementMaterials") && !other.name.Contains("SM")) && other.name.Contains("CM8"))
            {
                this.InService = true;
                ((SphereCollider) this.gameObject.GetComponent(typeof(SphereCollider))).radius = 0.1f;
                this.target = other.gameObject.transform;
                other.gameObject.name = "SM";
            }
        }
        if ((((this.Grab && !this.Bring) && !this.PutIn) && !this.ReverseOut) && !this.Repositioning)
        {
            if (other.name == "RecieveStart")
            {
                this.Bring = true;
                ((SphereCollider) this.gameObject.GetComponent(typeof(SphereCollider))).radius = 0.1f;
                this.AimSpeed = 0;
                this.StartCoroutine(this.AimAgain());
                this.target = other.gameObject.transform;
            }
        }
        if (((((this.Grab && this.Bring) && !this.PutIn) && !this.ReverseOut) && !this.TranslatorMovingOut) && !this.Repositioning)
        {
            if (other.name == "RecieveEnd")
            {
                this.PutIn = true;
                ((SphereCollider) this.gameObject.GetComponent(typeof(SphereCollider))).radius = 0.1f;
                this.target = other.gameObject.transform;
                this.RE = other.gameObject.transform;
                this.StartCoroutine(this.CargObstacleAbler());
            }
        }
        if (this.Repositioning)
        {
            if (other.name == "CRPosition")
            {
                ((SphereCollider) this.gameObject.GetComponent(typeof(SphereCollider))).radius = 0.1f;
                this.target = other.gameObject.transform;
            }
        }
    }

    public virtual void HookControl()
    {
        if (!this.HookOut)
        {

            {
                float _1054 = this.Hook1.GetComponent<HingeJoint>().spring.targetPosition - 1;
                JointSpring _1055 = this.Hook1.GetComponent<HingeJoint>().spring;
                _1055.targetPosition = _1054;
                this.Hook1.GetComponent<HingeJoint>().spring = _1055;
            }

            {
                float _1056 = this.Hook2.GetComponent<HingeJoint>().spring.targetPosition + 1;
                JointSpring _1057 = this.Hook2.GetComponent<HingeJoint>().spring;
                _1057.targetPosition = _1056;
                this.Hook2.GetComponent<HingeJoint>().spring = _1057;
            }
            this.HookMovingOut = true;
            this.HookMovingIn = false;
        }
        if (this.HookOut)
        {

            {
                float _1058 = this.Hook1.GetComponent<HingeJoint>().spring.targetPosition + 1;
                JointSpring _1059 = this.Hook1.GetComponent<HingeJoint>().spring;
                _1059.targetPosition = _1058;
                this.Hook1.GetComponent<HingeJoint>().spring = _1059;
            }

            {
                float _1060 = this.Hook2.GetComponent<HingeJoint>().spring.targetPosition - 1;
                JointSpring _1061 = this.Hook2.GetComponent<HingeJoint>().spring;
                _1061.targetPosition = _1060;
                this.Hook2.GetComponent<HingeJoint>().spring = _1061;
            }
            this.HookMovingOut = false;
            this.HookMovingIn = true;
        }
    }

    public virtual void TranslatorControl()
    {
        if (!this.TranslatorOut)
        {
            ((ConfigurableJoint) this.Translator.GetComponent(typeof(ConfigurableJoint))).targetPosition = ((ConfigurableJoint) this.Translator.GetComponent(typeof(ConfigurableJoint))).targetPosition - new Vector3(0, 0, 0.01f);
            this.TranslatorMovingOut = true;
            this.TranslatorMovingIn = false;
        }
        if (this.TranslatorOut)
        {
            ((ConfigurableJoint) this.Translator.GetComponent(typeof(ConfigurableJoint))).targetPosition = ((ConfigurableJoint) this.Translator.GetComponent(typeof(ConfigurableJoint))).targetPosition + new Vector3(0, 0, 0.01f);
            this.TranslatorMovingOut = false;
            this.TranslatorMovingIn = true;
        }
    }

    public virtual IEnumerator AimAgain()
    {
        yield return new WaitForSeconds(1.3f);
        this.AimSpeed = 50;
        this.BackBoost = true;
        yield return new WaitForSeconds(1);
        this.BackBoost = false;
    }

    public virtual IEnumerator CargObstacleAbler()
    {
        yield return new WaitForSeconds(1);
        this.CargObstacleAble = true;
    }

    public CarrierRobotAI()
    {
        this.TranslatorEnd = 2.4f;
        this.Hook1End = 120;
        this.Hook2End = -120;
        this.AimSpeed = 100;
    }

}