using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ControllableThruster : MonoBehaviour
{
    public float ForwardSpeed;
    public float UpSpeed;
    public virtual void FixedUpdate()
    {
        if (Input.GetKey("k"))
        {
            this.GetComponent<Rigidbody>().AddForce(this.transform.forward * -this.ForwardSpeed);
        }
        if (Input.GetKey("l"))
        {
            this.GetComponent<Rigidbody>().AddForce(this.transform.up * -this.UpSpeed);
        }
    }

    public ControllableThruster()
    {
        this.ForwardSpeed = 100;
        this.UpSpeed = 100;
    }

}