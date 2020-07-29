using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class HingeJointDampLimit : MonoBehaviour
{
    public virtual void Start()
    {
    }

    public virtual void Update()
    {
        if (this.GetComponent<Rigidbody>().angularVelocity.magnitude > 0.1f)
        {

            {
                float _2012 = 0.8f;
                JointSpring _2013 = this.GetComponent<HingeJoint>().spring;
                _2013.damper = _2012;
                this.GetComponent<HingeJoint>().spring = _2013;
            }
        }
        if (this.GetComponent<Rigidbody>().angularVelocity.magnitude > 0.2f)
        {

            {
                float _2014 = 0.6f;
                JointSpring _2015 = this.GetComponent<HingeJoint>().spring;
                _2015.damper = _2014;
                this.GetComponent<HingeJoint>().spring = _2015;
            }
        }
        if (this.GetComponent<Rigidbody>().angularVelocity.magnitude > 0.4f)
        {

            {
                float _2016 = 0.5f;
                JointSpring _2017 = this.GetComponent<HingeJoint>().spring;
                _2017.damper = _2016;
                this.GetComponent<HingeJoint>().spring = _2017;
            }
        }
        if (this.GetComponent<Rigidbody>().angularVelocity.magnitude > 0.6f)
        {

            {
                float _2018 = 0.4f;
                JointSpring _2019 = this.GetComponent<HingeJoint>().spring;
                _2019.damper = _2018;
                this.GetComponent<HingeJoint>().spring = _2019;
            }
        }
    }

}