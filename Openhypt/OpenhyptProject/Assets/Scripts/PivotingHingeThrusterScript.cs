using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PivotingHingeThrusterScript : MonoBehaviour
{
    public Transform VesselTF;
    public Rigidbody VesselRB;
    public float ForwardForce;
    public float TurnForce;
    public float ReverseForce;
    public float statForce;
    public float statTurnForce;
    public float statReverseForce;
    public float ForwardPivotAngle;
    public float LeftPivotAngle;
    public float RightPivotAngle;
    public float ReversePivotAngle;
    public bool OnlyMove;
    public bool OnlyDirVelRot;
    public bool UseDirVelRot;
    public float ZDirVelRot;
    public bool ForceDelay;
    public float DelaySpeed;
    public bool RunningW;
    public bool RunningA;
    public bool RunningD;
    public bool RunningS;
    public virtual void Start()
    {
        this.statForce = this.ForwardForce;
        this.statTurnForce = this.TurnForce;
        this.statReverseForce = this.ReverseForce;
    }

    public virtual void Update()
    {
        if (WorldInformation.playerCar == this.transform.parent.name)
        {
            if (CameraScript.InInterface == false)
            {
                if (WorldInformation.playerCar.Contains("broken"))
                {
                    UnityEngine.Object.Destroy(this);
                }
                if (Input.GetKeyDown("w"))
                {
                    this.RunningW = true;
                    if (this.ForceDelay)
                    {
                        this.ForwardForce = 0;
                    }
                }
                if (Input.GetKeyUp("w"))
                {
                    this.RunningW = false;
                }
                if (Input.GetKeyDown("a"))
                {
                    this.RunningA = true;
                    if (this.ForceDelay && (this.LeftPivotAngle > 0))
                    {
                        this.TurnForce = 0;
                        this.ForwardForce = 0;
                    }
                }
                if (Input.GetKeyUp("a"))
                {
                    this.RunningA = false;
                    if (this.ForceDelay)
                    {
                        this.ForwardForce = 0;
                    }
                }
                if (Input.GetKeyDown("d"))
                {
                    this.RunningD = true;
                    if (this.ForceDelay && (this.RightPivotAngle > 0))
                    {
                        this.TurnForce = 0;
                        this.ForwardForce = 0;
                    }
                }
                if (Input.GetKeyUp("d"))
                {
                    this.RunningD = false;
                    if (this.ForceDelay)
                    {
                        this.ForwardForce = 0;
                    }
                }
                if (Input.GetKeyDown("s"))
                {
                    this.RunningS = true;
                    if (this.ForceDelay)
                    {
                        this.ReverseForce = 0;
                    }
                }
                if (Input.GetKeyUp("s"))
                {
                    this.RunningS = false;
                }
            }
        }
        if (!this.OnlyDirVelRot)
        {

            {
                int _2738 = 0;
                JointSpring _2739 = this.GetComponent<HingeJoint>().spring;
                _2739.targetPosition = _2738;
                this.GetComponent<HingeJoint>().spring = _2739;
            }
            if (this.RunningW)
            {

                {
                    float _2740 = this.ForwardPivotAngle;
                    JointSpring _2741 = this.GetComponent<HingeJoint>().spring;
                    _2741.targetPosition = _2740;
                    this.GetComponent<HingeJoint>().spring = _2741;
                }
            }
            if (this.RunningA)
            {

                {
                    float _2742 = this.LeftPivotAngle;
                    JointSpring _2743 = this.GetComponent<HingeJoint>().spring;
                    _2743.targetPosition = _2742;
                    this.GetComponent<HingeJoint>().spring = _2743;
                }
            }
            if (this.RunningD)
            {

                {
                    float _2744 = this.RightPivotAngle;
                    JointSpring _2745 = this.GetComponent<HingeJoint>().spring;
                    _2745.targetPosition = _2744;
                    this.GetComponent<HingeJoint>().spring = _2745;
                }
            }
            if (this.RunningS)
            {

                {
                    float _2746 = this.ReversePivotAngle;
                    JointSpring _2747 = this.GetComponent<HingeJoint>().spring;
                    _2747.targetPosition = _2746;
                    this.GetComponent<HingeJoint>().spring = _2747;
                }
            }
        }
    }

    public virtual void FixedUpdate()
    {
        if (this.ForceDelay)
        {
            if (this.ForwardForce < this.statForce)
            {
                this.ForwardForce = this.ForwardForce + this.DelaySpeed;
            }
            if (this.TurnForce < this.statTurnForce)
            {
                this.TurnForce = this.TurnForce + this.DelaySpeed;
            }
            if (this.ReverseForce < this.statReverseForce)
            {
                this.ReverseForce = this.ReverseForce + this.DelaySpeed;
            }
        }
        if (!this.OnlyMove && !this.OnlyDirVelRot)
        {
            if (this.RunningA)
            {
                this.GetComponent<Rigidbody>().AddForce(this.transform.right * -this.TurnForce);
            }
            if (this.RunningD)
            {
                this.GetComponent<Rigidbody>().AddForce(this.transform.right * -this.TurnForce);
            }
            if (this.RunningS)
            {
                this.GetComponent<Rigidbody>().AddForce(this.transform.right * -this.ReverseForce);
            }
            if ((this.RunningW && !this.RunningA) && !this.RunningD)
            {
                this.GetComponent<Rigidbody>().AddForce(this.transform.right * -this.ForwardForce);
            }
        }
        if (this.UseDirVelRot)
        {
            Vector3 localV = this.VesselTF.InverseTransformDirection(this.VesselRB.velocity);
            if ((localV.z < 10) && (-localV.z < 10))
            {

                {
                    float _2748 = localV.z * this.ZDirVelRot;
                    JointSpring _2749 = this.GetComponent<HingeJoint>().spring;
                    _2749.targetPosition = _2748;
                    this.GetComponent<HingeJoint>().spring = _2749;
                }
            }
        }
    }

    public PivotingHingeThrusterScript()
    {
        this.ForwardForce = 70;
        this.TurnForce = 40;
        this.ReverseForce = 40;
        this.statForce = 70;
        this.statTurnForce = 70;
        this.statReverseForce = 70;
        this.ZDirVelRot = 0.5f;
        this.DelaySpeed = 0.5f;
    }

}