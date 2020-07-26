using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class InnerWheelMotorController : MonoBehaviour
{
    public float Force;
    public float BreakForce;
    public float Tvelocity;
    public float RTvelocity;
    public float LeftTvelocity;
    public float RightTvelocity;
    public bool breaksOn;
    public virtual void Start()
    {

        {
            float _2076 = this.BreakForce;
            JointSpring _2077 = this.GetComponent<HingeJoint>().spring;
            _2077.damper = _2076;
            this.GetComponent<HingeJoint>().spring = _2077;
        }
    }

    public virtual void Update()
    {
        if (WorldInformation.playerCar == this.transform.parent.parent.name)
        {
            this.ParkBrake();
            this.SWBreak();
            if (this.breaksOn == false)
            {
                if (Input.GetKey("w"))
                {

                    {
                        float _2078 = this.Force;
                        JointMotor _2079 = this.GetComponent<HingeJoint>().motor;
                        _2079.force = _2078;
                        this.GetComponent<HingeJoint>().motor = _2079;
                    }

                    {
                        float _2080 = this.Tvelocity;
                        JointMotor _2081 = this.GetComponent<HingeJoint>().motor;
                        _2081.targetVelocity = _2080;
                        this.GetComponent<HingeJoint>().motor = _2081;
                    }
                }
                if (Input.GetKeyUp("w"))
                {

                    {
                        int _2082 = 0;
                        JointMotor _2083 = this.GetComponent<HingeJoint>().motor;
                        _2083.force = _2082;
                        this.GetComponent<HingeJoint>().motor = _2083;
                    }

                    {
                        float _2084 = this.Tvelocity;
                        JointMotor _2085 = this.GetComponent<HingeJoint>().motor;
                        _2085.targetVelocity = _2084;
                        this.GetComponent<HingeJoint>().motor = _2085;
                    }
                }
                if (Input.GetKey("s"))
                {

                    {
                        float _2086 = this.Force;
                        JointMotor _2087 = this.GetComponent<HingeJoint>().motor;
                        _2087.force = _2086;
                        this.GetComponent<HingeJoint>().motor = _2087;
                    }

                    {
                        float _2088 = this.RTvelocity;
                        JointMotor _2089 = this.GetComponent<HingeJoint>().motor;
                        _2089.targetVelocity = _2088;
                        this.GetComponent<HingeJoint>().motor = _2089;
                    }
                }
                if (Input.GetKeyUp("s"))
                {

                    {
                        int _2090 = 0;
                        JointMotor _2091 = this.GetComponent<HingeJoint>().motor;
                        _2091.force = _2090;
                        this.GetComponent<HingeJoint>().motor = _2091;
                    }

                    {
                        float _2092 = this.RTvelocity;
                        JointMotor _2093 = this.GetComponent<HingeJoint>().motor;
                        _2093.targetVelocity = _2092;
                        this.GetComponent<HingeJoint>().motor = _2093;
                    }
                }
                if (Input.GetKey("a"))
                {

                    {
                        float _2094 = this.Force;
                        JointMotor _2095 = this.GetComponent<HingeJoint>().motor;
                        _2095.force = _2094;
                        this.GetComponent<HingeJoint>().motor = _2095;
                    }

                    {
                        float _2096 = this.LeftTvelocity;
                        JointMotor _2097 = this.GetComponent<HingeJoint>().motor;
                        _2097.targetVelocity = _2096;
                        this.GetComponent<HingeJoint>().motor = _2097;
                    }
                }
                if (Input.GetKeyUp("a"))
                {

                    {
                        int _2098 = 0;
                        JointMotor _2099 = this.GetComponent<HingeJoint>().motor;
                        _2099.force = _2098;
                        this.GetComponent<HingeJoint>().motor = _2099;
                    }

                    {
                        float _2100 = this.LeftTvelocity;
                        JointMotor _2101 = this.GetComponent<HingeJoint>().motor;
                        _2101.targetVelocity = _2100;
                        this.GetComponent<HingeJoint>().motor = _2101;
                    }
                }
                if (Input.GetKey("d"))
                {

                    {
                        float _2102 = this.Force;
                        JointMotor _2103 = this.GetComponent<HingeJoint>().motor;
                        _2103.force = _2102;
                        this.GetComponent<HingeJoint>().motor = _2103;
                    }

                    {
                        float _2104 = this.RightTvelocity;
                        JointMotor _2105 = this.GetComponent<HingeJoint>().motor;
                        _2105.targetVelocity = _2104;
                        this.GetComponent<HingeJoint>().motor = _2105;
                    }
                }
                if (Input.GetKeyUp("d"))
                {

                    {
                        int _2106 = 0;
                        JointMotor _2107 = this.GetComponent<HingeJoint>().motor;
                        _2107.force = _2106;
                        this.GetComponent<HingeJoint>().motor = _2107;
                    }

                    {
                        float _2108 = this.RightTvelocity;
                        JointMotor _2109 = this.GetComponent<HingeJoint>().motor;
                        _2109.targetVelocity = _2108;
                        this.GetComponent<HingeJoint>().motor = _2109;
                    }
                }
            }
        }
    }

    public virtual void SWBreak()
    {
        if (Input.GetKey("s") && Input.GetKey("w"))
        {
            this.breaksOn = true;

            {
                int _2110 = 0;
                JointMotor _2111 = this.GetComponent<HingeJoint>().motor;
                _2111.force = _2110;
                this.GetComponent<HingeJoint>().motor = _2111;
            }

            {
                int _2112 = 0;
                JointMotor _2113 = this.GetComponent<HingeJoint>().motor;
                _2113.force = _2112;
                this.GetComponent<HingeJoint>().motor = _2113;
            }

            {
                float _2114 = this.BreakForce;
                JointSpring _2115 = this.GetComponent<HingeJoint>().spring;
                _2115.damper = _2114;
                this.GetComponent<HingeJoint>().spring = _2115;
            }
        }
    }

    public virtual void ParkBrake()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (this.breaksOn == true)
            {
                this.breaksOn = false;

                {
                    int _2116 = 0;
                    JointMotor _2117 = this.GetComponent<HingeJoint>().motor;
                    _2117.force = _2116;
                    this.GetComponent<HingeJoint>().motor = _2117;
                }

                {
                    int _2118 = 0;
                    JointSpring _2119 = this.GetComponent<HingeJoint>().spring;
                    _2119.damper = _2118;
                    this.GetComponent<HingeJoint>().spring = _2119;
                }
            }
            else
            {
                this.breaksOn = true;

                {
                    int _2120 = 0;
                    JointMotor _2121 = this.GetComponent<HingeJoint>().motor;
                    _2121.force = _2120;
                    this.GetComponent<HingeJoint>().motor = _2121;
                }

                {
                    float _2122 = this.BreakForce;
                    JointSpring _2123 = this.GetComponent<HingeJoint>().spring;
                    _2123.damper = _2122;
                    this.GetComponent<HingeJoint>().spring = _2123;
                }
            }
        }
    }

    public InnerWheelMotorController()
    {
        this.Force = 1;
        this.BreakForce = 1;
        this.Tvelocity = 1500;
        this.RTvelocity = 1500;
        this.LeftTvelocity = 1500;
        this.RightTvelocity = 1500;
    }

}