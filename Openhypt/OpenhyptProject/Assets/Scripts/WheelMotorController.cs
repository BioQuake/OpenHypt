using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class WheelMotorController : MonoBehaviour
{
    public Transform MainVessel;
    public GameObject Gyro;
    public float Force;
    public float StaticForce;
    public float BreakForce;
    public float DampOrigi;
    public float RevVel;
    public float Tvelocity;
    public float TurnMod;
    public bool TorqueCompensation;
    public float TorqueComp;
    public bool SpinCompensation;
    public float SpinComp;
    public float CompMax;
    public bool breaksOn;
    public bool breaking;
    public bool MirroredWheel;
    public bool IsCenterWheel;
    public bool IsTrailerHauler;
    public bool HingeBroken;
    public bool Once;
    public bool UseCurve;
    public AnimationCurve curve;
    public float VolumeAmount;
    public float VolumeMod;
    public float ForceMod;
    public float ForcePlusMod;
    public float RevPlusMod;
    public GameObject WheelObjectIntact;
    public GameObject WheelObjectBroken;
    public FixedJoint BrakeJoint;
    public bool RunningF;
    public bool RunningR;
    public bool RunningLeft;
    public bool RunningRight;
    public bool Broken;
    public virtual void Start()
    {
        this.StaticForce = this.Force;

        {
            float _3734 = this.BreakForce;
            JointSpring _3735 = this.GetComponent<HingeJoint>().spring;
            _3735.damper = _3734;
            this.GetComponent<HingeJoint>().spring = _3735;
        }
        if (!this.BrakeJoint)
        {
            this.BrakeJoint = this.gameObject.AddComponent<FixedJoint>();
        }
        this.BrakeJoint.connectedBody = this.GetComponent<HingeJoint>().connectedBody;
    }

    public virtual void Update()
    {
        if (this.MainVessel == null)
        {
            UnityEngine.Object.Destroy(this);
        }
        if (this.Broken)
        {
            if (!this.HingeBroken)
            {

                {
                    int _3736 = 0;
                    JointMotor _3737 = this.GetComponent<HingeJoint>().motor;
                    _3737.force = _3736;
                    this.GetComponent<HingeJoint>().motor = _3737;
                }
            }
        }
        if (this.Broken)
        {
            return;
        }
        if (WorldInformation.playerCar.Contains(this.MainVessel.name))
        {
            if (this.SpinCompensation)
            {
                Vector3 VesselAngVel = this.MainVessel.InverseTransformDirection(this.MainVessel.gameObject.GetComponent<Rigidbody>().angularVelocity);
                float AV1 = VesselAngVel.z * this.SpinComp;
                float AV2 = Mathf.Clamp(AV1, -this.CompMax, this.CompMax);
                if ((Input.GetKey("w") && !Input.GetKey("a")) && !Input.GetKey("d"))
                {
                    if (this.MirroredWheel)
                    {
                        this.Force = this.StaticForce - AV2;
                    }
                    else
                    {
                        this.Force = this.StaticForce + AV2;
                    }
                }
                if ((Input.GetKey("s") && !Input.GetKey("a")) && !Input.GetKey("d"))
                {
                    if (this.MirroredWheel)
                    {
                        this.Force = this.StaticForce + AV2;
                    }
                    else
                    {
                        this.Force = this.StaticForce - AV2;
                    }
                }
                if (!Input.GetKey("w") && !Input.GetKey("s"))
                {
                    this.Force = this.StaticForce;
                }
            }
            else
            {
                this.Force = this.StaticForce;
            }
            if (CameraScript.InInterface == false)
            {
                if (this.RunningLeft && this.RunningRight)
                {
                    this.RunningLeft = false;
                    this.RunningRight = false;
                }
                if (Input.GetKeyUp("d"))
                {
                    if (Input.GetKey("a"))
                    {
                        this.RunningLeft = true;
                    }
                }
                if (Input.GetKeyUp("a"))
                {
                    if (Input.GetKey("d"))
                    {
                        this.RunningRight = true;
                    }
                }
                if (Input.GetKeyDown("w"))
                {
                    this.RunningF = true;
                }
                if (Input.GetKeyUp("w"))
                {
                    this.RunningF = false;

                    {
                        int _3738 = 0;
                        JointMotor _3739 = this.GetComponent<HingeJoint>().motor;
                        _3739.force = _3738;
                        this.GetComponent<HingeJoint>().motor = _3739;
                    }

                    {
                        float _3740 = this.Tvelocity;
                        JointMotor _3741 = this.GetComponent<HingeJoint>().motor;
                        _3741.targetVelocity = _3740;
                        this.GetComponent<HingeJoint>().motor = _3741;
                    }
                }
                if (Input.GetKeyDown("s"))
                {
                    this.RunningR = true;
                    this.Force = this.StaticForce;
                }
                if (Input.GetKeyUp("s"))
                {
                    this.RunningR = false;

                    {
                        int _3742 = 0;
                        JointMotor _3743 = this.GetComponent<HingeJoint>().motor;
                        _3743.force = _3742;
                        this.GetComponent<HingeJoint>().motor = _3743;
                    }

                    {
                        float _3744 = -this.Tvelocity;
                        JointMotor _3745 = this.GetComponent<HingeJoint>().motor;
                        _3745.targetVelocity = _3744;
                        this.GetComponent<HingeJoint>().motor = _3745;
                    }
                }
                if (Input.GetKeyDown("a"))
                {
                    this.RunningLeft = true;
                    this.Force = this.StaticForce;
                }
                if (Input.GetKeyUp("a") && !this.IsCenterWheel)
                {
                    this.RunningLeft = false;

                    {
                        int _3746 = 0;
                        JointMotor _3747 = this.GetComponent<HingeJoint>().motor;
                        _3747.force = _3746;
                        this.GetComponent<HingeJoint>().motor = _3747;
                    }

                    {
                        float _3748 = -this.Tvelocity;
                        JointMotor _3749 = this.GetComponent<HingeJoint>().motor;
                        _3749.targetVelocity = _3748;
                        this.GetComponent<HingeJoint>().motor = _3749;
                    }
                }
                if (Input.GetKeyDown("d"))
                {
                    this.RunningRight = true;
                    this.Force = this.StaticForce;
                }
                if (Input.GetKeyUp("d") && !this.IsCenterWheel)
                {
                    this.RunningRight = false;

                    {
                        int _3750 = 0;
                        JointMotor _3751 = this.GetComponent<HingeJoint>().motor;
                        _3751.force = _3750;
                        this.GetComponent<HingeJoint>().motor = _3751;
                    }

                    {
                        float _3752 = this.Tvelocity;
                        JointMotor _3753 = this.GetComponent<HingeJoint>().motor;
                        _3753.targetVelocity = _3752;
                        this.GetComponent<HingeJoint>().motor = _3753;
                    }
                }
            }
        }
        if (WorldInformation.playerCar.Contains(this.MainVessel.name))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                {
                    float _3754 = this.BreakForce;
                    JointSpring _3755 = this.GetComponent<HingeJoint>().spring;
                    _3755.damper = _3754;
                    this.GetComponent<HingeJoint>().spring = _3755;
                }

                {
                    int _3756 = 0;
                    JointMotor _3757 = this.GetComponent<HingeJoint>().motor;
                    _3757.force = _3756;
                    this.GetComponent<HingeJoint>().motor = _3757;
                }
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {

                {
                    float _3758 = this.DampOrigi;
                    JointSpring _3759 = this.GetComponent<HingeJoint>().spring;
                    _3759.damper = _3758;
                    this.GetComponent<HingeJoint>().spring = _3759;
                }
            }
            if (!Input.GetKey(KeyCode.Space))
            {
                this.breaking = false;
            }
            else
            {
                this.breaking = true;
            }
            this.ParkBrake();
        }
    }

    public virtual void FixedUpdate()
    {
        if (this.Broken)
        {
            return;
        }
        if (!this.breaksOn)
        {
            Vector3 WAngVel = this.transform.InverseTransformDirection(this.GetComponent<Rigidbody>().angularVelocity);
            Vector3 AngVel = this.transform.InverseTransformDirection(this.GetComponent<Rigidbody>().angularVelocity);
            if (this.UseCurve)
            {
                float p = this.GetComponent<Rigidbody>().angularVelocity.magnitude;
                this.VolumeAmount = this.curve.Evaluate(p) * this.VolumeMod;
                this.ForceMod = this.VolumeAmount;

                if (this.RunningF)
                {

                    {
                        float _3760 = this.Tvelocity;
                        JointMotor _3761 = this.GetComponent<HingeJoint>().motor;
                        _3761.targetVelocity = _3760;
                        this.GetComponent<HingeJoint>().motor = _3761;
                    }

                    {
                        float _3762 = (this.Force * this.ForceMod) * this.ForcePlusMod;
                        JointMotor _3763 = this.GetComponent<HingeJoint>().motor;
                        _3763.force = _3762;
                        this.GetComponent<HingeJoint>().motor = _3763;
                    }
                }
                if (this.RunningR)
                {
                    if (!Input.GetKey(KeyCode.Space))
                    {
                        if (-AngVel.x < this.RevVel)
                        {

                            {
                                float _3764 = -this.Tvelocity;
                                JointMotor _3765 = this.GetComponent<HingeJoint>().motor;
                                _3765.targetVelocity = _3764;
                                this.GetComponent<HingeJoint>().motor = _3765;
                            }
                            if (AngVel.x > 0)
                            {

                                {
                                    float _3766 = this.Force * this.RevPlusMod;
                                    JointMotor _3767 = this.GetComponent<HingeJoint>().motor;
                                    _3767.force = _3766;
                                    this.GetComponent<HingeJoint>().motor = _3767;
                                }
                            }
                            else
                            {

                                {
                                    float _3768 = (this.Force * this.ForceMod) * this.RevPlusMod;
                                    JointMotor _3769 = this.GetComponent<HingeJoint>().motor;
                                    _3769.force = _3768;
                                    this.GetComponent<HingeJoint>().motor = _3769;
                                }
                            }
                        }
                    }
                }
                if (this.RunningLeft && !this.IsCenterWheel)
                {
                    if (!this.UseCurve)
                    {
                        if (this.ForceMod < this.TurnMod)
                        {
                            this.ForceMod = this.TurnMod;
                        }
                    }
                    else
                    {
                        if (this.ForceMod < this.TurnMod)
                        {
                            if (!this.MirroredWheel)
                            {
                                if (WAngVel.x > 0)
                                {
                                    this.ForceMod = this.curve.Evaluate(p) * this.TurnMod;
                                }
                                else
                                {
                                    this.ForceMod = this.TurnMod;
                                }
                            }
                            else
                            {
                                if (WAngVel.x < 0)
                                {
                                    this.ForceMod = this.curve.Evaluate(p) * this.TurnMod;
                                }
                                else
                                {
                                    this.ForceMod = this.TurnMod;
                                }
                            }
                        }
                    }
                    if (!this.IsTrailerHauler)
                    {

                        {
                            float _3770 = this.Force * this.ForceMod;
                            JointMotor _3771 = this.GetComponent<HingeJoint>().motor;
                            _3771.force = _3770;
                            this.GetComponent<HingeJoint>().motor = _3771;
                        }
                    }
                    else
                    {
                        if (this.RunningF)
                        {
                            if (this.MirroredWheel)
                            {

                                {
                                    int _3772 = 0;
                                    JointMotor _3773 = this.GetComponent<HingeJoint>().motor;
                                    _3773.force = _3772;
                                    this.GetComponent<HingeJoint>().motor = _3773;
                                }
                            }
                        }
                        else
                        {

                            {
                                float _3774 = this.Force * this.ForceMod;
                                JointMotor _3775 = this.GetComponent<HingeJoint>().motor;
                                _3775.force = _3774;
                                this.GetComponent<HingeJoint>().motor = _3775;
                            }
                        }
                    }
                    if (!this.MirroredWheel)
                    {

                        {
                            float _3776 = this.Tvelocity;
                            JointMotor _3777 = this.GetComponent<HingeJoint>().motor;
                            _3777.targetVelocity = _3776;
                            this.GetComponent<HingeJoint>().motor = _3777;
                        }
                    }
                    if (this.MirroredWheel)
                    {

                        {
                            float _3778 = -this.Tvelocity;
                            JointMotor _3779 = this.GetComponent<HingeJoint>().motor;
                            _3779.targetVelocity = _3778;
                            this.GetComponent<HingeJoint>().motor = _3779;
                        }
                    }
                }
                if (this.RunningRight && !this.IsCenterWheel)
                {
                    if (!this.UseCurve)
                    {
                        if (this.ForceMod < this.TurnMod)
                        {
                            this.ForceMod = this.TurnMod;
                        }
                    }
                    else
                    {
                        if (this.ForceMod < this.TurnMod)
                        {
                            if (!this.MirroredWheel)
                            {
                                if (WAngVel.x < 0)
                                {
                                    this.ForceMod = this.curve.Evaluate(p) * this.TurnMod;
                                }
                                else
                                {
                                    this.ForceMod = this.TurnMod;
                                }
                            }
                            else
                            {
                                if (WAngVel.x > 0)
                                {
                                    this.ForceMod = this.curve.Evaluate(p) * this.TurnMod;
                                }
                                else
                                {
                                    this.ForceMod = this.TurnMod;
                                }
                            }
                        }
                    }
                    if (!this.IsTrailerHauler)
                    {

                        {
                            float _3780 = this.Force * this.ForceMod;
                            JointMotor _3781 = this.GetComponent<HingeJoint>().motor;
                            _3781.force = _3780;
                            this.GetComponent<HingeJoint>().motor = _3781;
                        }
                    }
                    else
                    {
                        if (this.RunningF)
                        {
                            if (!this.MirroredWheel)
                            {

                                {
                                    int _3782 = 0;
                                    JointMotor _3783 = this.GetComponent<HingeJoint>().motor;
                                    _3783.force = _3782;
                                    this.GetComponent<HingeJoint>().motor = _3783;
                                }
                            }
                        }
                        else
                        {

                            {
                                float _3784 = this.Force * this.ForceMod;
                                JointMotor _3785 = this.GetComponent<HingeJoint>().motor;
                                _3785.force = _3784;
                                this.GetComponent<HingeJoint>().motor = _3785;
                            }
                        }
                    }
                    if (!this.MirroredWheel)
                    {

                        {
                            float _3786 = -this.Tvelocity;
                            JointMotor _3787 = this.GetComponent<HingeJoint>().motor;
                            _3787.targetVelocity = _3786;
                            this.GetComponent<HingeJoint>().motor = _3787;
                        }
                    }
                    if (this.MirroredWheel)
                    {

                        {
                            float _3788 = this.Tvelocity;
                            JointMotor _3789 = this.GetComponent<HingeJoint>().motor;
                            _3789.targetVelocity = _3788;
                            this.GetComponent<HingeJoint>().motor = _3789;
                        }
                    }
                }
                if (this.TorqueCompensation)
                {
                    if ((this.RunningR && !this.RunningLeft) && !this.RunningRight)
                    {
                        if (-AngVel.x < this.RevVel)
                        {
                            this.Gyro.GetComponent<Rigidbody>().AddTorque(this.Gyro.transform.right * -this.TorqueComp);
                        }
                    }
                    if ((this.RunningF && !this.RunningLeft) && !this.RunningRight)
                    {
                        this.Gyro.GetComponent<Rigidbody>().AddTorque((this.Gyro.transform.right * this.TorqueComp) * this.ForceMod);
                    }
                }
            }
        }
    }

    public virtual void ParkBrake()
    {
        if (!this.breaking)
        {
            if (!this.breaksOn)
            {

                {
                    int _3790 = 0;
                    JointMotor _3791 = this.GetComponent<HingeJoint>().motor;
                    _3791.force = _3790;
                    this.GetComponent<HingeJoint>().motor = _3791;
                }

                {
                    float _3792 = this.DampOrigi;
                    JointSpring _3793 = this.GetComponent<HingeJoint>().spring;
                    _3793.damper = _3792;
                    this.GetComponent<HingeJoint>().spring = _3793;
                }
                if (this.BrakeJoint)
                {
                    UnityEngine.Object.Destroy(this.BrakeJoint);
                }
                this.Once = false;
            }
            else
            {

                {
                    int _3794 = 0;
                    JointMotor _3795 = this.GetComponent<HingeJoint>().motor;
                    _3795.force = _3794;
                    this.GetComponent<HingeJoint>().motor = _3795;
                }
                if (this.GetComponent<Rigidbody>().angularVelocity.magnitude > 1)
                {

                    {
                        float _3796 = this.BreakForce;
                        JointSpring _3797 = this.GetComponent<HingeJoint>().spring;
                        _3797.damper = _3796;
                        this.GetComponent<HingeJoint>().spring = _3797;
                    }
                    if (this.BrakeJoint)
                    {
                        UnityEngine.Object.Destroy(this.BrakeJoint);
                    }
                }
                else
                {
                    if (!this.Once)
                    {
                        if (!this.BrakeJoint)
                        {
                            this.BrakeJoint = this.gameObject.AddComponent<FixedJoint>();
                        }
                        this.BrakeJoint.connectedBody = this.GetComponent<HingeJoint>().connectedBody;
                        this.Once = true;
                    }
                }
            }
        }
        else
        {

            {
                int _3798 = 0;
                JointMotor _3799 = this.GetComponent<HingeJoint>().motor;
                _3799.force = _3798;
                this.GetComponent<HingeJoint>().motor = _3799;
            }
            if (this.GetComponent<Rigidbody>().angularVelocity.magnitude > 1)
            {

                {
                    float _3800 = this.BreakForce;
                    JointSpring _3801 = this.GetComponent<HingeJoint>().spring;
                    _3801.damper = _3800;
                    this.GetComponent<HingeJoint>().spring = _3801;
                }
                if (this.BrakeJoint)
                {
                    UnityEngine.Object.Destroy(this.BrakeJoint);
                }
            }
            else
            {
                if (!this.Once)
                {
                    if (!this.BrakeJoint)
                    {
                        this.BrakeJoint = this.gameObject.AddComponent<FixedJoint>();
                    }
                    this.BrakeJoint.connectedBody = this.GetComponent<HingeJoint>().connectedBody;
                    this.Once = true;
                }
            }
        }
    }

    public virtual void OnJointBreak(float breakForce)
    {
        if (this.BrakeJoint)
        {
            UnityEngine.Object.Destroy(this.BrakeJoint);
        }
        this.HingeBroken = true;
        this.transform.parent = null;
        this.WheelObjectBroken.gameObject.SetActive(true);
        UnityEngine.Object.Destroy(this.WheelObjectIntact);
        this.Broken = true;
    }

    public WheelMotorController()//BrakeJoint.angularYZDrive.positionDamper = 1;
    {
        this.Force = 1;
        this.BreakForce = 1;
        this.RevVel = 10;
        this.Tvelocity = 1500;
        this.TurnMod = 0.3f;
        this.TorqueComp = 100;
        this.SpinComp = 4;
        this.CompMax = 0.1f;
        this.curve = new AnimationCurve();
        this.VolumeMod = 1f;
        this.ForceMod = 1f;
        this.ForcePlusMod = 1f;
        this.RevPlusMod = 1f;
    }

}