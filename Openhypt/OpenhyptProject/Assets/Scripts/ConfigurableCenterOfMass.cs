using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ConfigurableCenterOfMass : MonoBehaviour
{
    public float X;
    public float Y;
    public float Z;
    public bool COMFix;
    public bool Configuring;
    public bool WeightFix;
    public virtual IEnumerator Start()
    {
        if (this.WeightFix)
        {
            this.GetComponent<Rigidbody>().useGravity = false;
        }
        if (this.COMFix)
        {
            this.Configuring = true;
            yield return new WaitForSeconds(2);
            if (!this.WeightFix)
            {
                UnityEngine.Object.Destroy(this);
            }
            else
            {
                this.Configuring = false;
            }
        }
    }

    public virtual void FixedUpdate()
    {
        if (this.WeightFix)
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0f, -0.2f, 0f), ForceMode.VelocityChange);
        }
        if (this.Configuring)
        {
            this.GetComponent<Rigidbody>().centerOfMass = new Vector3(this.X, this.Y, this.Z);
        }
    }

    public virtual void OnJointBreak(float breakForce)
    {
        UnityEngine.Object.Destroy(this);
    }

    public ConfigurableCenterOfMass()
    {
        this.COMFix = true;
    }

}