using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class BosomCalm : MonoBehaviour
{
    public virtual void Update()
    {
        if (this.GetComponent<Rigidbody>().velocity.magnitude < 15)
        {

            {
                int _986 = 0;
                JointDrive _987 = ((ConfigurableJoint) this.GetComponent(typeof(ConfigurableJoint))).angularXDrive;
                _987.positionDamper = _986;
                ((ConfigurableJoint) this.GetComponent(typeof(ConfigurableJoint))).angularXDrive = _987;
            }

            {
                int _988 = 0;
                JointDrive _989 = ((ConfigurableJoint) this.GetComponent(typeof(ConfigurableJoint))).angularYZDrive;
                _989.positionDamper = _988;
                ((ConfigurableJoint) this.GetComponent(typeof(ConfigurableJoint))).angularYZDrive = _989;
            }
        }
        if (this.GetComponent<Rigidbody>().velocity.magnitude > 15)
        {

            {
                float _990 = 0.0002f;
                JointDrive _991 = ((ConfigurableJoint) this.GetComponent(typeof(ConfigurableJoint))).angularXDrive;
                _991.positionDamper = _990;
                ((ConfigurableJoint) this.GetComponent(typeof(ConfigurableJoint))).angularXDrive = _991;
            }

            {
                float _992 = 0.0002f;
                JointDrive _993 = ((ConfigurableJoint) this.GetComponent(typeof(ConfigurableJoint))).angularYZDrive;
                _993.positionDamper = _992;
                ((ConfigurableJoint) this.GetComponent(typeof(ConfigurableJoint))).angularYZDrive = _993;
            }
        }
        if (this.GetComponent<Rigidbody>().velocity.magnitude > 50)
        {

            {
                float _994 = 0.0005f;
                JointDrive _995 = ((ConfigurableJoint) this.GetComponent(typeof(ConfigurableJoint))).angularXDrive;
                _995.positionDamper = _994;
                ((ConfigurableJoint) this.GetComponent(typeof(ConfigurableJoint))).angularXDrive = _995;
            }

            {
                float _996 = 0.0005f;
                JointDrive _997 = ((ConfigurableJoint) this.GetComponent(typeof(ConfigurableJoint))).angularYZDrive;
                _997.positionDamper = _996;
                ((ConfigurableJoint) this.GetComponent(typeof(ConfigurableJoint))).angularYZDrive = _997;
            }
        }
    }

}