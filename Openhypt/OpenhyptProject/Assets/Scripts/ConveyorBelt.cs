using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ConveyorBelt : MonoBehaviour
{
    public virtual void OnCollisionStay(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        if (collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude < 0.5f)
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(this.transform.forward * 0.2f, contact.point);
        }
    }

}