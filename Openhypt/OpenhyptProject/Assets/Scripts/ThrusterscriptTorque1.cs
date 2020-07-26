using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ThrusterscriptTorque1 : MonoBehaviour
{
    public float YawLeftSpeed;
    public float YawRightSpeed;
    public float TiltUpSpeed;
    public float TiltDownSpeed;
    public virtual void FixedUpdate()
    {
        if (WorldInformation.playerCar == this.transform.parent.name)
        {
            if (Input.GetKey("a"))
            {
                this.GetComponent<Rigidbody>().AddTorque(this.transform.forward * -this.YawLeftSpeed);
            }
            if (Input.GetKey("d"))
            {
                this.GetComponent<Rigidbody>().AddTorque(this.transform.forward * this.YawRightSpeed);
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

    public ThrusterscriptTorque1()
    {
        this.YawLeftSpeed = 100;
        this.YawRightSpeed = 100;
        this.TiltUpSpeed = 100;
        this.TiltDownSpeed = 100;
    }

}