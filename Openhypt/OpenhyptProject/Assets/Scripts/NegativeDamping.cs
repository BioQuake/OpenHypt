using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class NegativeDamping : MonoBehaviour
{
    public float speed;
    public virtual void FixedUpdate()
    {
        this.GetComponent<Rigidbody>().AddForce(this.GetComponent<Rigidbody>().velocity.normalized * this.speed);
    }

    public NegativeDamping()
    {
        this.speed = 0.1f;
    }

}