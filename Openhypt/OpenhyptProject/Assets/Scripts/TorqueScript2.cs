using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class TorqueScript2 : MonoBehaviour
{
    public Transform MainVessel;
    public float YawSpeed;
    public float YawSpeedOriginal;
    public float YawSpeedAlternated;
    public bool SpeedAlternation;
    public bool StrongTorque;
    public virtual void FixedUpdate()
    {
        if (WorldInformation.playerCar == this.MainVessel.name)
        {
            if (Input.GetKey("a"))
            {
                this.GetComponent<Rigidbody>().AddTorque(this.transform.up * -this.YawSpeed);
                if (this.StrongTorque)
                {
                    this.GetComponent<Rigidbody>().AddForceAtPosition(this.transform.forward * this.YawSpeed, this.transform.right * 20);
                    this.GetComponent<Rigidbody>().AddForceAtPosition(-this.transform.forward * this.YawSpeed, -this.transform.right * 20);
                }
            }
            if (Input.GetKey("d"))
            {
                this.GetComponent<Rigidbody>().AddTorque(this.transform.up * this.YawSpeed);
                if (this.StrongTorque)
                {
                    this.GetComponent<Rigidbody>().AddForceAtPosition(this.transform.forward * this.YawSpeed, -this.transform.right * 20);
                    this.GetComponent<Rigidbody>().AddForceAtPosition(-this.transform.forward * this.YawSpeed, this.transform.right * 20);
                }
            }
            if (this.SpeedAlternation)
            {
                if (this.GetComponent<Rigidbody>().velocity.magnitude > 50)
                {
                    this.YawSpeed = this.YawSpeedAlternated;
                }
                if (this.GetComponent<Rigidbody>().velocity.magnitude < 50)
                {
                    this.YawSpeed = this.YawSpeedOriginal;
                }
            }
        }
    }

    public TorqueScript2()
    {
        this.YawSpeed = 100;
        this.YawSpeedOriginal = 100;
        this.YawSpeedAlternated = 100;
    }

}