using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class CarJackScript : MonoBehaviour
{
    public float RayStart;
    public float RayEnd;
    public Transform Pad;
    public GameObject PadGO;
    public bool Attached;
    public ConfigurableJoint JackJoint;
    public HingeJoint JackArm;
    public LayerMask targetLayers;
    public virtual void Start()
    {
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        if (!this.Attached)
        {
            Debug.DrawRay(this.Pad.position + (this.Pad.forward * this.RayStart), this.Pad.forward * this.RayEnd, Color.white);
            if (Physics.Raycast(this.Pad.position + (this.Pad.forward * this.RayStart), this.Pad.forward, out hit, this.RayEnd, (int) this.targetLayers))
            {
                if (hit.rigidbody)
                {
                    this.Attached = true;
                    this.JackJoint = this.PadGO.AddComponent<ConfigurableJoint>();
                    this.JackJoint.connectedBody = hit.rigidbody;

                    {
                        JointDriveMode _1008 = JointDriveMode.Position;
                        JointDrive _1009 = this.JackJoint.xDrive;
                        _1009.mode = _1008;
                        this.JackJoint.xDrive = _1009;
                    }

                    {
                        JointDriveMode _1010 = JointDriveMode.Position;
                        JointDrive _1011 = this.JackJoint.yDrive;
                        _1011.mode = _1010;
                        this.JackJoint.yDrive = _1011;
                    }

                    {
                        JointDriveMode _1012 = JointDriveMode.Position;
                        JointDrive _1013 = this.JackJoint.zDrive;
                        _1013.mode = _1012;
                        this.JackJoint.zDrive = _1013;
                    }

                    {
                        JointDriveMode _1014 = JointDriveMode.Position;
                        JointDrive _1015 = this.JackJoint.angularXDrive;
                        _1015.mode = _1014;
                        this.JackJoint.angularXDrive = _1015;
                    }

                    {
                        JointDriveMode _1016 = JointDriveMode.Position;
                        JointDrive _1017 = this.JackJoint.angularYZDrive;
                        _1017.mode = _1016;
                        this.JackJoint.angularYZDrive = _1017;
                    }

                    {
                        int _1018 = 10000;
                        JointDrive _1019 = this.JackJoint.xDrive;
                        _1019.positionSpring = _1018;
                        this.JackJoint.xDrive = _1019;
                    }

                    {
                        int _1020 = 10000;
                        JointDrive _1021 = this.JackJoint.yDrive;
                        _1021.positionSpring = _1020;
                        this.JackJoint.yDrive = _1021;
                    }

                    {
                        float _1022 = 0.001f;
                        JointDrive _1023 = this.JackJoint.zDrive;
                        _1023.positionSpring = _1022;
                        this.JackJoint.zDrive = _1023;
                    }

                    {
                        int _1024 = 10000;
                        JointDrive _1025 = this.JackJoint.angularXDrive;
                        _1025.positionSpring = _1024;
                        this.JackJoint.angularXDrive = _1025;
                    }

                    {
                        int _1026 = 10000;
                        JointDrive _1027 = this.JackJoint.angularYZDrive;
                        _1027.positionSpring = _1026;
                        this.JackJoint.angularYZDrive = _1027;
                    }

                    {
                        int _1028 = 1;
                        JointDrive _1029 = this.JackJoint.xDrive;
                        _1029.positionDamper = _1028;
                        this.JackJoint.xDrive = _1029;
                    }

                    {
                        int _1030 = 1;
                        JointDrive _1031 = this.JackJoint.yDrive;
                        _1031.positionDamper = _1030;
                        this.JackJoint.yDrive = _1031;
                    }

                    {
                        int _1032 = 1;
                        JointDrive _1033 = this.JackJoint.zDrive;
                        _1033.positionDamper = _1032;
                        this.JackJoint.zDrive = _1033;
                    }

                    {
                        int _1034 = 1;
                        JointDrive _1035 = this.JackJoint.angularXDrive;
                        _1035.positionDamper = _1034;
                        this.JackJoint.angularXDrive = _1035;
                    }

                    {
                        int _1036 = 1;
                        JointDrive _1037 = this.JackJoint.angularYZDrive;
                        _1037.positionDamper = _1036;
                        this.JackJoint.angularYZDrive = _1037;
                    }
                    this.JackJoint.enableCollision = true;
                }
            }
            if (this.JackArm.spring.targetPosition > 0)
            {

                {
                    float _1038 = this.JackArm.spring.targetPosition - 0.1f;
                    JointSpring _1039 = this.JackArm.spring;
                    _1039.targetPosition = _1038;
                    this.JackArm.spring = _1039;
                }
            }
        }
        else
        {
            if (this.JackArm.spring.targetPosition < 15)
            {

                {
                    float _1040 = this.JackArm.spring.targetPosition + 0.1f;
                    JointSpring _1041 = this.JackArm.spring;
                    _1041.targetPosition = _1040;
                    this.JackArm.spring = _1041;
                }
            }
            Debug.DrawRay(this.Pad.position + (this.Pad.forward * this.RayStart), this.Pad.forward * this.RayEnd, Color.white);
            if (!Physics.Raycast(this.Pad.position + (this.Pad.forward * this.RayStart), this.Pad.forward, out hit, this.RayEnd, (int) this.targetLayers))
            {
                if (this.JackJoint)
                {
                    this.Attached = false;
                    UnityEngine.Object.Destroy(this.JackJoint);
                }
            }
        }
    }

    public CarJackScript()
    {
        this.RayStart = 0.2f;
        this.RayEnd = 0.2f;
    }

}