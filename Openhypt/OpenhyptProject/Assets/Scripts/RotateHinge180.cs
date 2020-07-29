using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class RotateHinge180 : MonoBehaviour
{
    public Transform MainVessel;
    public bool Rotated;
    public bool Mirrored;
    public bool OneHundredDeg;
    public virtual void Start()
    {
    }

    public virtual void Update()
    {
        if (WorldInformation.playerCar.Contains(this.MainVessel.name))
        {
            if (Input.GetKeyDown("x") && !this.Rotated)
            {
                this.Rotated = true;
            }
            else
            {
                if (Input.GetKeyDown("x") && this.Rotated)
                {
                    this.Rotated = false;
                }
            }
        }
    }

    public virtual void FixedUpdate()
    {
        if (!this.OneHundredDeg)
        {
            if (this.Rotated && (this.gameObject.GetComponent<HingeJoint>().spring.targetPosition < 180))
            {

                {
                    float _2924 = this.gameObject.GetComponent<HingeJoint>().spring.targetPosition + 4;
                    JointSpring _2925 = this.gameObject.GetComponent<HingeJoint>().spring;
                    _2925.targetPosition = _2924;
                    this.gameObject.GetComponent<HingeJoint>().spring = _2925;
                }
            }
            if (!this.Rotated && (this.gameObject.GetComponent<HingeJoint>().spring.targetPosition > 0))
            {

                {
                    float _2926 = this.gameObject.GetComponent<HingeJoint>().spring.targetPosition - 4;
                    JointSpring _2927 = this.gameObject.GetComponent<HingeJoint>().spring;
                    _2927.targetPosition = _2926;
                    this.gameObject.GetComponent<HingeJoint>().spring = _2927;
                }
            }
        }
        else
        {
            if (!this.Mirrored)
            {
                if (this.Rotated && (this.gameObject.GetComponent<HingeJoint>().spring.targetPosition < 100))
                {

                    {
                        float _2928 = this.gameObject.GetComponent<HingeJoint>().spring.targetPosition + 1;
                        JointSpring _2929 = this.gameObject.GetComponent<HingeJoint>().spring;
                        _2929.targetPosition = _2928;
                        this.gameObject.GetComponent<HingeJoint>().spring = _2929;
                    }
                }
                if (!this.Rotated && (this.gameObject.GetComponent<HingeJoint>().spring.targetPosition > 0))
                {

                    {
                        float _2930 = this.gameObject.GetComponent<HingeJoint>().spring.targetPosition - 1;
                        JointSpring _2931 = this.gameObject.GetComponent<HingeJoint>().spring;
                        _2931.targetPosition = _2930;
                        this.gameObject.GetComponent<HingeJoint>().spring = _2931;
                    }
                }
            }
            else
            {
                if (this.Rotated && (this.gameObject.GetComponent<HingeJoint>().spring.targetPosition > -100))
                {

                    {
                        float _2932 = this.gameObject.GetComponent<HingeJoint>().spring.targetPosition - 1;
                        JointSpring _2933 = this.gameObject.GetComponent<HingeJoint>().spring;
                        _2933.targetPosition = _2932;
                        this.gameObject.GetComponent<HingeJoint>().spring = _2933;
                    }
                }
                if (!this.Rotated && (this.gameObject.GetComponent<HingeJoint>().spring.targetPosition < 0))
                {

                    {
                        float _2934 = this.gameObject.GetComponent<HingeJoint>().spring.targetPosition + 1;
                        JointSpring _2935 = this.gameObject.GetComponent<HingeJoint>().spring;
                        _2935.targetPosition = _2934;
                        this.gameObject.GetComponent<HingeJoint>().spring = _2935;
                    }
                }
            }
        }
    }

}