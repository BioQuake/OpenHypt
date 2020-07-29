using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class BigVesselRotator : MonoBehaviour
{
    public Transform eye;
    public bool TurnedOff;
    public int TorqueForce;
    public float eyeOffset;
    public float RotateThreshold;
    public bool IsForceTurning;
    public virtual void FixedUpdate()
    {
        if (!this.eye)
        {
            return;
        }
        if (this.TurnedOff)
        {
            return;
        }
        Vector3 difference = ((this.eye.position + (this.eye.forward * this.eyeOffset)) - this.transform.position).normalized;
        float product = Vector3.Dot(this.transform.right, difference);
        if (product < -this.RotateThreshold)
        {
            this.GetComponent<Rigidbody>().AddTorque(this.transform.forward * this.TorqueForce);
        }
        else
        {
            if (product > this.RotateThreshold)
            {
                this.GetComponent<Rigidbody>().AddTorque(this.transform.forward * -this.TorqueForce);
            }
        }
        if (this.IsForceTurning && (this.GetComponent<Rigidbody>().angularVelocity.magnitude < 0.5f))
        {
            this.GetComponent<Rigidbody>().AddTorque((this.transform.forward * -this.TorqueForce) * 1.5f);
        }
    }

    public virtual IEnumerator ForceTurn()
    {
        this.IsForceTurning = true;
        yield return new WaitForSeconds(4);
        this.IsForceTurning = false;
    }

    public BigVesselRotator()
    {
        this.TorqueForce = 20000;
        this.eyeOffset = 20f;
        this.RotateThreshold = 0.5f;
    }

}