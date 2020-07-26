using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PoturgFAxelTorquer : MonoBehaviour
{
    public virtual void FixedUpdate()
    {
        if (this.GetComponent<Rigidbody>().velocity.magnitude > 30)
        {
            if (this.gameObject.GetComponent<HingeJoint>().spring.targetPosition < 20)
            {

                {
                    float _2902 = this.gameObject.GetComponent<HingeJoint>().spring.targetPosition + 0.2f;
                    JointSpring _2903 = this.gameObject.GetComponent<HingeJoint>().spring;
                    _2903.targetPosition = _2902;
                    this.gameObject.GetComponent<HingeJoint>().spring = _2903;
                }
            }
        }
        else
        {
            if (this.gameObject.GetComponent<HingeJoint>().spring.targetPosition > 0)
            {

                {
                    float _2904 = this.gameObject.GetComponent<HingeJoint>().spring.targetPosition - 0.2f;
                    JointSpring _2905 = this.gameObject.GetComponent<HingeJoint>().spring;
                    _2905.targetPosition = _2904;
                    this.gameObject.GetComponent<HingeJoint>().spring = _2905;
                }
            }
        }
    }

}