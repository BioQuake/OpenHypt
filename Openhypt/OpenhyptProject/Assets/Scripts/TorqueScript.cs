using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class TorqueScript : MonoBehaviour
{
    public float Force;
    public float Torque;
    public float TorqueX;
    public float TorqueY;
    public float TorqueZ;
    public bool SkipY;
    public bool UseRandom;
    public bool UseUpdate;
    public bool UseTorque;
    public bool UseForce;
    public virtual void Start()
    {
        if ((!this.UseUpdate && this.UseTorque) && !this.UseRandom)
        {
            this.GetComponent<Rigidbody>().AddTorque(this.transform.up * this.TorqueY);
            this.GetComponent<Rigidbody>().AddTorque(this.transform.right * this.TorqueX);
            this.GetComponent<Rigidbody>().AddTorque(this.transform.forward * this.TorqueZ);
        }
        if ((!this.UseUpdate && this.UseTorque) && this.UseRandom)
        {
            if (!this.SkipY)
            {
                this.GetComponent<Rigidbody>().AddTorque(this.transform.up * Random.Range(-this.Torque, this.Torque));
            }
            this.GetComponent<Rigidbody>().AddTorque(this.transform.right * Random.Range(-this.Torque, this.Torque));
            this.GetComponent<Rigidbody>().AddTorque(this.transform.forward * Random.Range(-this.Torque, this.Torque));
        }
        if (!this.UseUpdate && this.UseForce)
        {
            this.GetComponent<Rigidbody>().AddForce(this.transform.up * Random.Range(-this.Force, this.Force));
            this.GetComponent<Rigidbody>().AddForce(this.transform.right * Random.Range(-this.Force, this.Force));
            this.GetComponent<Rigidbody>().AddForce(this.transform.forward * Random.Range(-this.Force, this.Force));
        }
    }

    public virtual void FixedUpdate()
    {
        if (this.UseUpdate && this.UseTorque)
        {
            this.GetComponent<Rigidbody>().AddTorque(this.transform.up * Random.Range(-this.TorqueY, this.TorqueY));
            this.GetComponent<Rigidbody>().AddTorque(this.transform.right * Random.Range(-this.TorqueX, this.TorqueX));
            this.GetComponent<Rigidbody>().AddTorque(this.transform.forward * Random.Range(-this.TorqueZ, this.TorqueZ));
        }
        if (this.UseUpdate && this.UseForce)
        {
            this.GetComponent<Rigidbody>().AddForce(this.transform.up * Random.Range(-this.Force, this.Force));
            this.GetComponent<Rigidbody>().AddForce(this.transform.right * Random.Range(-this.Force, this.Force));
            this.GetComponent<Rigidbody>().AddForce(this.transform.forward * Random.Range(-this.Force, this.Force));
        }
    }

    public TorqueScript()
    {
        this.Force = 1;
        this.Torque = 1;
        this.UseRandom = true;
        this.UseTorque = true;
    }

}