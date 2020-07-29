using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ThrusterscriptTorque2 : MonoBehaviour
{
    public float YawLeftSpeed;
    public float YawRightSpeed;
    public float TiltLeftSpeed;
    public float TiltRightSpeed;
    public float TiltUpSpeed;
    public float TiltDownSpeed;
    public bool SwitchWhenS;
    public virtual void FixedUpdate()
    {
        if (WorldInformation.playerCar == this.transform.parent.name)
        {
            if (Input.GetKey("z"))
            {
                this.GetComponent<Rigidbody>().AddTorque(this.transform.up * -this.YawLeftSpeed);
            }
            if (Input.GetKey("x"))
            {
                this.GetComponent<Rigidbody>().AddTorque(this.transform.up * this.YawRightSpeed);
            }
            if (Input.GetKey("a"))
            {
                if (!this.SwitchWhenS)
                {
                    this.GetComponent<Rigidbody>().AddTorque(this.transform.forward * this.TiltLeftSpeed);
                }
                if (this.SwitchWhenS && !Input.GetKey("s"))
                {
                    this.GetComponent<Rigidbody>().AddTorque(this.transform.forward * this.TiltLeftSpeed);
                }
            }
            if (Input.GetKey("d"))
            {
                if (!this.SwitchWhenS)
                {
                    this.GetComponent<Rigidbody>().AddTorque(this.transform.forward * -this.TiltRightSpeed);
                }
                if (this.SwitchWhenS && !Input.GetKey("s"))
                {
                    this.GetComponent<Rigidbody>().AddTorque(this.transform.forward * -this.TiltRightSpeed);
                }
            }
            if (Input.GetKey("s"))
            {
                this.GetComponent<Rigidbody>().AddTorque(this.transform.right * -this.TiltUpSpeed);
            }
            if (Input.GetKey("w"))
            {
                this.GetComponent<Rigidbody>().AddTorque(this.transform.right * this.TiltDownSpeed);
            }
        }
    }

    public ThrusterscriptTorque2()
    {
        this.YawLeftSpeed = 100;
        this.YawRightSpeed = 100;
        this.TiltLeftSpeed = 100;
        this.TiltRightSpeed = 100;
        this.TiltUpSpeed = 100;
        this.TiltDownSpeed = 100;
    }

}