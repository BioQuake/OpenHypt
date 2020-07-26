using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PivotingHingeScript : MonoBehaviour
{
    public GameObject Vessel;
    public float LeftPivotAngle;
    public float RightPivotAngle;
    public float PivotSpeed;
    public float PivotAngle;
    public float AllPivotAngle;
    public bool UseDuck;
    public float Limit;
    public float LimitAngle;
    public bool FastTurnReset;
    public bool Reversed;
    public bool UseCurve;
    public AnimationCurve curve;
    public float PivotAmount;
    public virtual void FixedUpdate()
    {
        if (WorldInformation.playerCar == this.transform.parent.name)
        {
            if (this.UseCurve)
            {
                float p = this.Vessel.GetComponent<Rigidbody>().velocity.magnitude;
                this.PivotAmount = this.curve.Evaluate(p);
            }
            if (this.UseDuck)
            {
                if (Input.GetKey(KeyCode.LeftShift) && (this.PivotAngle < this.AllPivotAngle))
                {
                    this.PivotAngle = this.PivotAngle + this.PivotSpeed;
                }
                if (!Input.GetKey(KeyCode.LeftShift) && (this.PivotAngle > 0))
                {
                    this.PivotAngle = this.PivotAngle - this.PivotSpeed;
                }

                {
                    float _2728 = this.PivotAngle;
                    JointSpring _2729 = this.GetComponent<HingeJoint>().spring;
                    _2729.targetPosition = _2728;
                    this.GetComponent<HingeJoint>().spring = _2729;
                }
            }
            else
            {
                if (!this.Reversed)
                {
                    if (this.UseCurve)
                    {
                        if (Input.GetKey("a"))
                        {
                            if (this.PivotAngle > -this.PivotAmount)
                            {
                                this.PivotAngle = this.PivotAngle - this.PivotSpeed;
                            }
                            if (-this.PivotAmount > this.PivotAngle)
                            {
                                this.PivotAngle = this.PivotAngle + this.PivotSpeed;
                            }
                        }
                        if (Input.GetKey("d"))
                        {
                            if (this.PivotAngle < this.PivotAmount)
                            {
                                this.PivotAngle = this.PivotAngle + this.PivotSpeed;
                            }
                            if (this.PivotAmount < this.PivotAngle)
                            {
                                this.PivotAngle = this.PivotAngle - this.PivotSpeed;
                            }
                        }
                        if (!Input.GetKey("d"))
                        {
                            if (!Input.GetKey("a") && (this.PivotAngle > 0))
                            {
                                this.PivotAngle = this.PivotAngle - this.PivotSpeed;
                            }
                        }
                        if (!Input.GetKey("a"))
                        {
                            if (!Input.GetKey("d") && (this.PivotAngle < 0))
                            {
                                this.PivotAngle = this.PivotAngle + this.PivotSpeed;
                            }
                        }

                        {
                            float _2730 = this.PivotAngle;
                            JointSpring _2731 = this.GetComponent<HingeJoint>().spring;
                            _2731.targetPosition = _2730;
                            this.GetComponent<HingeJoint>().spring = _2731;
                        }
                    }
                    else
                    {
                        if (Input.GetKey("a") && (this.PivotAngle > -this.LeftPivotAngle))
                        {
                            this.PivotAngle = this.PivotAngle - this.PivotSpeed;
                        }
                        if (Input.GetKey("d") && (this.PivotAngle < this.RightPivotAngle))
                        {
                            this.PivotAngle = this.PivotAngle + this.PivotSpeed;
                        }
                        if (!Input.GetKey("d"))
                        {
                            if (!Input.GetKey("a") && (this.PivotAngle > 0))
                            {
                                if (this.FastTurnReset)
                                {
                                    this.PivotAngle = this.PivotAngle - (this.PivotSpeed * 2);
                                    if (this.PivotAngle < 1)
                                    {
                                        this.PivotAngle = 0;
                                    }
                                }
                                else
                                {
                                    this.PivotAngle = this.PivotAngle - this.PivotSpeed;
                                }
                            }
                        }
                        if (!Input.GetKey("a"))
                        {
                            if (!Input.GetKey("d") && (this.PivotAngle < 0))
                            {
                                if (this.FastTurnReset)
                                {
                                    this.PivotAngle = this.PivotAngle + (this.PivotSpeed * 2);
                                    if (this.PivotAngle > -1)
                                    {
                                        this.PivotAngle = 0;
                                    }
                                }
                                else
                                {
                                    this.PivotAngle = this.PivotAngle + this.PivotSpeed;
                                }
                            }
                        }

                        {
                            float _2732 = this.PivotAngle;
                            JointSpring _2733 = this.GetComponent<HingeJoint>().spring;
                            _2733.targetPosition = _2732;
                            this.GetComponent<HingeJoint>().spring = _2733;
                        }
                    }
                }
                else
                {
                    if (this.UseCurve)
                    {
                        if (Input.GetKey("d"))
                        {
                            if (this.PivotAngle > -this.PivotAmount)
                            {
                                this.PivotAngle = this.PivotAngle - this.PivotSpeed;
                            }
                            if (-this.PivotAmount > this.PivotAngle)
                            {
                                this.PivotAngle = this.PivotAngle + this.PivotSpeed;
                            }
                        }
                        if (Input.GetKey("a"))
                        {
                            if (this.PivotAngle < this.PivotAmount)
                            {
                                this.PivotAngle = this.PivotAngle + this.PivotSpeed;
                            }
                            if (this.PivotAmount < this.PivotAngle)
                            {
                                this.PivotAngle = this.PivotAngle - this.PivotSpeed;
                            }
                        }
                        if (!Input.GetKey("a"))
                        {
                            if (!Input.GetKey("d") && (this.PivotAngle > 0))
                            {
                                this.PivotAngle = this.PivotAngle - this.PivotSpeed;
                            }
                        }
                        if (!Input.GetKey("d"))
                        {
                            if (!Input.GetKey("a") && (this.PivotAngle < 0))
                            {
                                this.PivotAngle = this.PivotAngle + this.PivotSpeed;
                            }
                        }

                        {
                            float _2734 = this.PivotAngle;
                            JointSpring _2735 = this.GetComponent<HingeJoint>().spring;
                            _2735.targetPosition = _2734;
                            this.GetComponent<HingeJoint>().spring = _2735;
                        }
                    }
                    else
                    {
                        if (Input.GetKey("d") && (this.PivotAngle > -this.LeftPivotAngle))
                        {
                            this.PivotAngle = this.PivotAngle - this.PivotSpeed;
                        }
                        if (Input.GetKey("a") && (this.PivotAngle < this.RightPivotAngle))
                        {
                            this.PivotAngle = this.PivotAngle + this.PivotSpeed;
                        }
                        if (!Input.GetKey("a"))
                        {
                            if (!Input.GetKey("d") && (this.PivotAngle > 0))
                            {
                                this.PivotAngle = this.PivotAngle - this.PivotSpeed;
                            }
                        }
                        if (!Input.GetKey("d"))
                        {
                            if (!Input.GetKey("a") && (this.PivotAngle < 0))
                            {
                                this.PivotAngle = this.PivotAngle + this.PivotSpeed;
                            }
                        }

                        {
                            float _2736 = this.PivotAngle;
                            JointSpring _2737 = this.GetComponent<HingeJoint>().spring;
                            _2737.targetPosition = _2736;
                            this.GetComponent<HingeJoint>().spring = _2737;
                        }
                    }
                }
            }
        }
    }

    public PivotingHingeScript()
    {
        this.PivotSpeed = 0.5f;
        this.Limit = 5;
        this.LimitAngle = 10;
        this.curve = new AnimationCurve();
    }

}