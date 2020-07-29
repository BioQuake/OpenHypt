using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class Thrusterscript : MonoBehaviour
{
    public float horizontalSpeed;
    public float reverseSpeed;
    public virtual void FixedUpdate()
    {
        if (WorldInformation.playerCar == this.transform.parent.name)
        {
            if (Input.GetKey("w"))
            {
                this.GetComponent<Rigidbody>().AddForce((this.transform.up * -100) * this.horizontalSpeed);
            }
            if (Input.GetKey("s"))
            {
                this.GetComponent<Rigidbody>().AddForce((this.transform.up * 100) * this.reverseSpeed);
            }
            if (Input.GetKey("a"))
            {
                this.GetComponent<Rigidbody>().AddForce((this.transform.right * 100) * this.horizontalSpeed);
            }
            if (Input.GetKey("d"))
            {
                this.GetComponent<Rigidbody>().AddForce((this.transform.right * -100) * this.horizontalSpeed);
            }
        }
    }

    public Thrusterscript()
    {
        this.horizontalSpeed = 10;
        this.reverseSpeed = 10;
    }

}