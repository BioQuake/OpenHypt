using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class StrongGyroStabilizer : MonoBehaviour
{
    public GameObject target;
    public Rigidbody targetRB;
    public float force;
    public float offset;
    public bool Up;
    public bool Forward;
    public bool Right;
    public bool UseAxialDamper;
    public float AxialDamperMod;
    public virtual void Start()
    {
        this.targetRB = this.target.GetComponent<Rigidbody>();
    }

    public virtual void FixedUpdate()
    {
        if (this.Up == true)
        {
            this.targetRB.AddForceAtPosition(Vector3.up * this.force, this.transform.up * this.offset);
            this.targetRB.AddForceAtPosition(-Vector3.up * this.force, -this.transform.up * this.offset);
        }
        if (this.Forward == true)
        {
            this.targetRB.AddForceAtPosition(Vector3.forward * this.force, this.transform.forward * this.offset);
            this.targetRB.AddForceAtPosition(-Vector3.forward * this.force, -this.transform.forward * this.offset);
        }
        if (this.Right == true)
        {
            this.targetRB.AddForceAtPosition(Vector3.right * this.force, this.transform.forward * this.offset);
            this.targetRB.AddForceAtPosition(-Vector3.right * this.force, -this.transform.forward * this.offset);
        }
        if (this.UseAxialDamper)
        {
            Vector3 LAV = this.transform.InverseTransformDirection(this.targetRB.angularVelocity);
            this.targetRB.AddTorque((this.transform.forward * -LAV.z) * this.AxialDamperMod);
            this.targetRB.AddTorque((this.transform.right * -LAV.x) * this.AxialDamperMod);
        }
    }

    public StrongGyroStabilizer()
    {
        this.force = 10f;
        this.offset = 1f;
        this.Up = true;
        this.AxialDamperMod = 1f;
    }

}