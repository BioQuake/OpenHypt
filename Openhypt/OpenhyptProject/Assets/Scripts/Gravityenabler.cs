using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class Gravityenabler : MonoBehaviour
{
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            other.GetComponent<Rigidbody>().useGravity = true;
        }
    }

}