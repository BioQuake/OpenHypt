using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MevNavGyro : MonoBehaviour
{
    public float force;
    public float AimForce;
    public Transform AimTarget;
    public float TurnForce;
    public bool Stabilize;
    public float offset;
    public virtual void FixedUpdate()
    {
        this.GetComponent<Rigidbody>().AddTorque(this.transform.up * this.TurnForce);
        if (this.AimTarget && this.Stabilize)
        {
            this.GetComponent<Rigidbody>().AddForceAtPosition((this.AimTarget.transform.position - this.transform.position).normalized * this.AimForce, this.transform.forward * this.offset);
            this.GetComponent<Rigidbody>().AddForceAtPosition((this.AimTarget.transform.position - this.transform.position).normalized * -this.AimForce, -this.transform.forward * this.offset);
        }
        if (this.Stabilize)
        {
            this.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.up * this.force, this.transform.up * this.offset);
            this.GetComponent<Rigidbody>().AddForceAtPosition(-Vector3.up * this.force, -this.transform.up * this.offset);
        }
    }

    public virtual void Reset()
    {
        this.Stabilize = true;
    }

    public virtual void Start()
    {
        this.InvokeRepeating("Reset", 1, 1);
    }

    public MevNavGyro()
    {
        this.force = 10f;
        this.AimForce = 10f;
        this.offset = 1f;
    }

}