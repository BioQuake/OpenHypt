using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class CeptoBargeController : MonoBehaviour
{
    public Transform target;
    public Transform Waypoint1;
    public Transform Waypoint2;
    public Transform Vessel;
    public Transform VesselModel;
    public Transform ParentArea;
    public Transform LandArea;
    public GameObject Arm11;
    public GameObject Arm12;
    public GameObject Arm21;
    public GameObject Arm22;
    public GameObject Arm31;
    public GameObject Arm32;
    public GameObject Gyro;
    public GameObject AudioDistant;
    public GameObject AudioAppear;
    public GameObject AudioAway;
    public Vector3 DropPos;
    public bool CanPlayDistant;
    public bool CanPlayAppear;
    public bool CanPlayAway;
    public bool CanManeuver;
    public bool HasVessel;
    public bool GoingDownToFetch;
    public bool GoingDownToDrop;
    public bool GoingUpFromFetch;
    public bool GoingUpFromDrop;
    public bool ReachedWaypoint;
    public float StabForce;
    public float ThrustForce;
    public float ThrustForce2;
    public float Multiplier;
    public AnimationCurve curveDown;
    public AnimationCurve curveUp;
    public LayerMask targetLayers;
    public virtual void Start()
    {
        this.target = GameObject.Find("CeptobargeTopWaypoint").transform;
        this.Waypoint1 = GameObject.Find("CeptobargeTopWaypoint").transform;
        this.LandArea = GameObject.Find("CeptobargeWaypoint").transform;
        this.Grasp();
    }

    public virtual void FixedUpdate()
    {
        RaycastHit hit = default(RaycastHit);
        Vector3 fwd = this.transform.TransformDirection(Vector3.back);
        if ((this.ThrustForce > 390) && this.CanPlayDistant)
        {
            this.CanPlayDistant = false;
            this.CanPlayAppear = true;
            this.AudioDistant.GetComponent<AudioSource>().Play();
        }
        if ((this.ThrustForce2 > 390) && this.CanPlayAway)
        {
            this.CanPlayAway = false;
            this.AudioAway.GetComponent<AudioSource>().Play();
        }
        if ((this.ThrustForce < 100) && this.CanPlayAppear)
        {
            this.CanPlayAppear = false;
            this.AudioAppear.GetComponent<AudioSource>().Play();
        }
        if (this.GoingDownToFetch && !this.ReachedWaypoint)
        {
            this.GetComponent<Rigidbody>().AddForce((this.transform.forward * -this.ThrustForce) * this.Multiplier, ForceMode.Impulse);
            this.GetComponent<Rigidbody>().angularDrag = 3;
            this.GetComponent<Rigidbody>().drag = 6;
            this.StabForce = 800;
            this.target = this.Waypoint2;
        }
        if (this.GoingDownToDrop && !this.ReachedWaypoint)
        {
            this.GetComponent<Rigidbody>().AddForce((this.transform.forward * -this.ThrustForce) * this.Multiplier, ForceMode.Impulse);
            this.GetComponent<Rigidbody>().angularDrag = 3;
            this.GetComponent<Rigidbody>().drag = 6;
            this.StabForce = 800;
            this.target = this.Waypoint1;
        }
        this.ThrustForce = this.curveDown.Evaluate((this.transform.position - this.target.position).magnitude);
        if (this.GoingUpFromDrop)
        {
            this.ThrustForce2 = this.curveUp.Evaluate((this.transform.position - this.DropPos).magnitude);
        }
        if (this.GoingUpFromFetch)
        {
            this.ThrustForce2 = this.curveUp.Evaluate((this.transform.position - this.DropPos).magnitude);
        }
        if (Physics.Raycast(this.transform.position, fwd, out hit, 1000, (int) this.targetLayers))
        {
            this.CanManeuver = false;
        }
        else
        {
            this.CanManeuver = true;
        }
        //------------------------------------------------------------------------------------------
        if (this.GoingDownToFetch && !this.ReachedWaypoint)
        {
            if (Vector3.Distance(this.ParentArea.transform.position, this.Waypoint2.transform.position) < 50)
            {
                this.ReachedWaypoint = true;
                this.CanPlayDistant = true;
                this.target = this.Vessel;
            }
        }
        if (this.GoingDownToFetch && this.ReachedWaypoint)
        {
            this.GetComponent<Rigidbody>().AddForce((this.transform.forward * -this.ThrustForce) * this.Multiplier, ForceMode.Impulse);
            this.GetComponent<Rigidbody>().drag = 4;
            this.StabForce = 600;
            if (Vector3.Distance(this.ParentArea.transform.position, this.target.transform.position) < 10)
            {
                this.Grasp();
            }
            if (Vector3.Distance(this.ParentArea.transform.position, this.target.transform.position) < 2)
            {
                this.GoingDownToFetch = false;
                this.Parent();
                this.GoingUpFromFetch = true;
            }
        }
        //------------------------------------------------------------------------------------------
        if (this.GoingDownToDrop && !this.ReachedWaypoint)
        {
            if (Vector3.Distance(this.ParentArea.transform.position, this.Waypoint1.transform.position) < 50)
            {
                this.ReachedWaypoint = true;
                this.CanPlayDistant = true;
                this.target = this.LandArea;
            }
        }
        if (this.GoingDownToDrop && this.ReachedWaypoint)
        {
            this.GetComponent<Rigidbody>().AddForce((this.transform.forward * -this.ThrustForce) * this.Multiplier, ForceMode.Impulse);
            this.GetComponent<Rigidbody>().drag = 4;
            this.StabForce = 600;
            if (Vector3.Distance(this.ParentArea.transform.position, this.target.transform.position) < 2)
            {
                this.GoingDownToDrop = false;
                this.Unparent();
                this.Release();
                this.GoingUpFromDrop = true;
            }
        }
        //------------------------------------------------------------------------------------------
        if (!this.GoingUpFromFetch || !this.GoingUpFromDrop)
        {
            this.Gyro.GetComponent<StrongGyroStabilizer>().force = 1;
        }
        if (this.GoingUpFromFetch)
        {
            this.Gyro.GetComponent<StrongGyroStabilizer>().force = 1000;
            this.GetComponent<Rigidbody>().AddForce((this.transform.forward * this.ThrustForce2) * this.Multiplier, ForceMode.Impulse);
        }
        if (this.GoingUpFromDrop)
        {
            this.Gyro.GetComponent<StrongGyroStabilizer>().force = 1000;
            this.GetComponent<Rigidbody>().AddForce((this.transform.forward * this.ThrustForce2) * this.Multiplier, ForceMode.Impulse);
        }
        if (this.target != null)
        {
            this.GetComponent<Rigidbody>().AddForceAtPosition((this.target.transform.position - this.transform.position).normalized * this.StabForce, -this.transform.forward * 5);
            this.GetComponent<Rigidbody>().AddForceAtPosition((this.target.transform.position - this.transform.position).normalized * -this.StabForce, this.transform.forward * 5);
        }
    }

    public virtual void Grasp()
    {

        {
            int _1062 = 60;
            JointSpring _1063 = this.Arm11.GetComponent<HingeJoint>().spring;
            _1063.targetPosition = _1062;
            this.Arm11.GetComponent<HingeJoint>().spring = _1063;
        }

        {
            int _1064 = -110;
            JointSpring _1065 = this.Arm12.GetComponent<HingeJoint>().spring;
            _1065.targetPosition = _1064;
            this.Arm12.GetComponent<HingeJoint>().spring = _1065;
        }

        {
            int _1066 = 60;
            JointSpring _1067 = this.Arm21.GetComponent<HingeJoint>().spring;
            _1067.targetPosition = _1066;
            this.Arm21.GetComponent<HingeJoint>().spring = _1067;
        }

        {
            int _1068 = -110;
            JointSpring _1069 = this.Arm22.GetComponent<HingeJoint>().spring;
            _1069.targetPosition = _1068;
            this.Arm22.GetComponent<HingeJoint>().spring = _1069;
        }

        {
            int _1070 = 60;
            JointSpring _1071 = this.Arm31.GetComponent<HingeJoint>().spring;
            _1071.targetPosition = _1070;
            this.Arm31.GetComponent<HingeJoint>().spring = _1071;
        }

        {
            int _1072 = -110;
            JointSpring _1073 = this.Arm32.GetComponent<HingeJoint>().spring;
            _1073.targetPosition = _1072;
            this.Arm32.GetComponent<HingeJoint>().spring = _1073;
        }
    }

    public virtual void Release()
    {

        {
            int _1074 = 0;
            JointSpring _1075 = this.Arm11.GetComponent<HingeJoint>().spring;
            _1075.targetPosition = _1074;
            this.Arm11.GetComponent<HingeJoint>().spring = _1075;
        }

        {
            int _1076 = 0;
            JointSpring _1077 = this.Arm12.GetComponent<HingeJoint>().spring;
            _1077.targetPosition = _1076;
            this.Arm12.GetComponent<HingeJoint>().spring = _1077;
        }

        {
            int _1078 = 0;
            JointSpring _1079 = this.Arm21.GetComponent<HingeJoint>().spring;
            _1079.targetPosition = _1078;
            this.Arm21.GetComponent<HingeJoint>().spring = _1079;
        }

        {
            int _1080 = 0;
            JointSpring _1081 = this.Arm22.GetComponent<HingeJoint>().spring;
            _1081.targetPosition = _1080;
            this.Arm22.GetComponent<HingeJoint>().spring = _1081;
        }

        {
            int _1082 = 0;
            JointSpring _1083 = this.Arm31.GetComponent<HingeJoint>().spring;
            _1083.targetPosition = _1082;
            this.Arm31.GetComponent<HingeJoint>().spring = _1083;
        }

        {
            int _1084 = 0;
            JointSpring _1085 = this.Arm32.GetComponent<HingeJoint>().spring;
            _1085.targetPosition = _1084;
            this.Arm32.GetComponent<HingeJoint>().spring = _1085;
        }
    }

    public virtual void DoStuff()
    {
        if (this.HasVessel && this.CanManeuver)
        {
            this.ReachedWaypoint = false;
            this.GoingDownToDrop = true;
            this.GoingUpFromFetch = false;
            this.GoingUpFromDrop = false;
        }
        if (!this.HasVessel && this.CanManeuver)
        {
            this.ReachedWaypoint = false;
            this.GoingDownToFetch = true;
            this.GoingUpFromFetch = false;
            this.GoingUpFromDrop = false;
        }
    }

    public virtual void Parent()
    {
        this.Vessel.gameObject.SetActive(false);
        this.VesselModel.gameObject.SetActive(true);
        this.Vessel.transform.parent = this.ParentArea;
        this.HasVessel = true;
        this.CanPlayAway = true;
        this.GetComponent<Rigidbody>().angularDrag = 10;
        this.DropPos = this.transform.position;
    }

    public virtual void Unparent()
    {
        this.VesselModel.gameObject.SetActive(false);
        this.Vessel.gameObject.SetActive(true);
        this.Vessel.transform.parent = null;
        this.HasVessel = false;
        this.CanPlayAway = true;
        this.GetComponent<Rigidbody>().angularDrag = 10;
        this.DropPos = this.transform.position;
    }

    public CeptoBargeController()
    {
        this.StabForce = 10f;
        this.ThrustForce = 10f;
        this.ThrustForce2 = 10f;
        this.Multiplier = 1;
        this.curveDown = new AnimationCurve();
        this.curveUp = new AnimationCurve();
    }

}