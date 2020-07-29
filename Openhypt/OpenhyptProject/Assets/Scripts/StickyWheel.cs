using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class StickyWheel : MonoBehaviour
{
    public Transform FPoint;
    public Rigidbody thisRigidbody;
    public Rigidbody thatRigidbody;
    public Transform thatTransform;
    public int Num;
    public float FNum;
    public virtual void Start()
    {
    }

    public virtual void FixedUpdate()
    {
    }

    public virtual void OnCollisionStay(Collision collision)
    {
        if (this.thisRigidbody.angularVelocity.magnitude > 0.5f)
        {
            ContactPoint contact = collision.contacts[0];
            if (Vector3.Distance(contact.point, this.FPoint.position) < 0.5f)
            {
                this.thatRigidbody.AddForce(this.thatTransform.up * 2);
                this.thatRigidbody.AddForce(this.thatTransform.forward * 1);
            }
        }
    }

}