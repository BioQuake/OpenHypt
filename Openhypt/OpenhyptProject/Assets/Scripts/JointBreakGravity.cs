using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class JointBreakGravity : MonoBehaviour
{
    public GameObject HomePoint;
    public float MaxDistance;
    public virtual void Update()
    {
        if (this.HomePoint != null)
        {
            if (Vector3.Distance(this.transform.position, this.HomePoint.transform.position) > this.MaxDistance)
            {
                ConfigurableJoint bJoint = (ConfigurableJoint) this.gameObject.GetComponent(typeof(ConfigurableJoint));
                if (bJoint != null)
                {

                    {
                        JointDriveMode _2124 = JointDriveMode.None;
                        JointDrive _2125 = bJoint.angularXDrive;
                        _2125.mode = _2124;
                        bJoint.angularXDrive = _2125;
                    }

                    {
                        JointDriveMode _2126 = JointDriveMode.None;
                        JointDrive _2127 = bJoint.angularYZDrive;
                        _2127.mode = _2126;
                        bJoint.angularYZDrive = _2127;
                    }

                    {
                        JointDriveMode _2128 = JointDriveMode.None;
                        JointDrive _2129 = bJoint.xDrive;
                        _2129.mode = _2128;
                        bJoint.xDrive = _2129;
                    }

                    {
                        JointDriveMode _2130 = JointDriveMode.None;
                        JointDrive _2131 = bJoint.yDrive;
                        _2131.mode = _2130;
                        bJoint.yDrive = _2131;
                    }

                    {
                        JointDriveMode _2132 = JointDriveMode.None;
                        JointDrive _2133 = bJoint.zDrive;
                        _2133.mode = _2132;
                        bJoint.zDrive = _2133;
                    }
                }
                this.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }

    public JointBreakGravity()
    {
        this.MaxDistance = 0.2f;
    }

}