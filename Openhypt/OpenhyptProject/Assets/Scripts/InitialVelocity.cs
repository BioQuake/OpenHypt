using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class InitialVelocity : MonoBehaviour
{
    public bool DisplayVelocity;
    public int Velocity;
    public float Force;
    public virtual void Start()
    {
        this.GetComponent<Rigidbody>().AddForce(this.transform.up * this.Force, ForceMode.Impulse);
    }

    public virtual void Update()
    {
        if (this.DisplayVelocity)
        {
            this.Velocity = (int) this.GetComponent<Rigidbody>().velocity.magnitude;
        }
    }

    public InitialVelocity()
    {
        this.Force = 0.1f;
    }

}