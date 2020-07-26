using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class Thruster : MonoBehaviour
{
    public float Force;
    public float ForwardForce;
    public virtual void FixedUpdate()
    {
        this.GetComponent<Rigidbody>().AddForce(this.transform.up * this.Force);
        this.GetComponent<Rigidbody>().AddForce(this.transform.forward * this.ForwardForce);
    }

}