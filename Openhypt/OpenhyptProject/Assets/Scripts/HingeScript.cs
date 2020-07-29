using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class HingeScript : MonoBehaviour
{
    public GameObject ConnectedDoor;
    public GameObject RecieveNode;
    public bool LockTF;
    public bool Open;
    public bool Out;
    public bool MovingOut;
    public bool MovingIn;
    public float PosX;
    public float PosY;
    public float PosZ;
    public virtual void Start()
    {
        if (this.LockTF)
        {
            this.PosX = this.transform.localPosition.x;
            this.PosY = this.transform.localPosition.y;
            this.PosZ = this.transform.localPosition.z;
        }
        if (this.Open)
        {
            this.Move();
        }
    }

    public virtual void FixedUpdate()
    {
        if (this.LockTF)
        {

            {
                float _2020 = this.PosX;
                Vector3 _2021 = this.transform.localPosition;
                _2021.x = _2020;
                this.transform.localPosition = _2021;
            }

            {
                float _2022 = this.PosY;
                Vector3 _2023 = this.transform.localPosition;
                _2023.y = _2022;
                this.transform.localPosition = _2023;
            }

            {
                float _2024 = this.PosZ;
                Vector3 _2025 = this.transform.localPosition;
                _2025.z = _2024;
                this.transform.localPosition = _2025;
            }

            {
                int _2026 = 0;
                Quaternion _2027 = this.transform.localRotation;
                _2027.y = _2026;
                this.transform.localRotation = _2027;
            }

            {
                int _2028 = 0;
                Quaternion _2029 = this.transform.localRotation;
                _2029.z = _2028;
                this.transform.localRotation = _2029;
            }
        }
        if (this.MovingIn || this.MovingOut)
        {
            if (this.GetComponent<HingeJoint>().spring.targetPosition == -90)
            {
                this.Out = true;
                this.MovingOut = false;
            }
            if (this.GetComponent<HingeJoint>().spring.targetPosition == 0)
            {
                this.Out = false;
                this.MovingIn = false;
            }
        }
        if (this.MovingOut)
        {
            if (this.GetComponent<HingeJoint>().spring.targetPosition > -90)
            {

                {
                    float _2030 = this.GetComponent<HingeJoint>().spring.targetPosition - 1;
                    JointSpring _2031 = this.GetComponent<HingeJoint>().spring;
                    _2031.targetPosition = _2030;
                    this.GetComponent<HingeJoint>().spring = _2031;
                }
            }
        }
        if (this.MovingIn)
        {
            if (this.GetComponent<HingeJoint>().spring.targetPosition < 0)
            {

                {
                    float _2032 = this.GetComponent<HingeJoint>().spring.targetPosition + 1;
                    JointSpring _2033 = this.GetComponent<HingeJoint>().spring;
                    _2033.targetPosition = _2032;
                    this.GetComponent<HingeJoint>().spring = _2033;
                }
            }
        }
    }

    public virtual void Move()
    {
        if (this.ConnectedDoor)
        {
            ((HingeScript) this.ConnectedDoor.GetComponent(typeof(HingeScript))).Move2();
        }
        if (!this.Out)
        {
            if (this.RecieveNode)
            {
                this.RecieveNode.gameObject.SetActive(true);
            }

            {
                float _2034 = this.GetComponent<HingeJoint>().spring.targetPosition + 1;
                JointSpring _2035 = this.GetComponent<HingeJoint>().spring;
                _2035.targetPosition = _2034;
                this.GetComponent<HingeJoint>().spring = _2035;
            }
            this.MovingOut = true;
            this.MovingIn = false;
        }
        if (this.Out)
        {
            if (this.RecieveNode)
            {
                this.RecieveNode.gameObject.SetActive(false);
            }

            {
                float _2036 = this.GetComponent<HingeJoint>().spring.targetPosition - 1;
                JointSpring _2037 = this.GetComponent<HingeJoint>().spring;
                _2037.targetPosition = _2036;
                this.GetComponent<HingeJoint>().spring = _2037;
            }
            this.MovingOut = false;
            this.MovingIn = true;
        }
    }

    public virtual void Move2()
    {
        if (!this.Out)
        {

            {
                float _2038 = this.GetComponent<HingeJoint>().spring.targetPosition + 1;
                JointSpring _2039 = this.GetComponent<HingeJoint>().spring;
                _2039.targetPosition = _2038;
                this.GetComponent<HingeJoint>().spring = _2039;
            }
            this.MovingOut = true;
            this.MovingIn = false;
        }
        if (this.Out)
        {

            {
                float _2040 = this.GetComponent<HingeJoint>().spring.targetPosition - 1;
                JointSpring _2041 = this.GetComponent<HingeJoint>().spring;
                _2041.targetPosition = _2040;
                this.GetComponent<HingeJoint>().spring = _2041;
            }
            this.MovingOut = false;
            this.MovingIn = true;
        }
    }

}