using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ThrusterscriptTorque : MonoBehaviour
{
    public float YawLeftSpeed;
    public float YawRightSpeed;
    public virtual void FixedUpdate()
    {
        if (WorldInformation.playerCar == this.transform.parent.name)
        {
            if (Input.GetKey("z"))
            {
                this.GetComponent<Rigidbody>().AddTorque(this.transform.right * this.YawLeftSpeed);
            }
            if (Input.GetKey("x"))
            {
                this.GetComponent<Rigidbody>().AddTorque(this.transform.right * this.YawRightSpeed);
            }
        }
    }

    public ThrusterscriptTorque()
    {
        this.YawLeftSpeed = -100;
        this.YawRightSpeed = 100;
    }

}