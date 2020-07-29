using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class HandheldThingPointAt : MonoBehaviour
{
    public Transform target;
    public bool entered;
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("FPCnose"))
        {
            this.entered = true;
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("FPCnose"))
        {
            this.entered = false;
        }
    }

    public virtual void Update()
    {
        if (Input.GetMouseButton(0) && (this.entered == true))
        {
            this.transform.LookAt(this.target);
        }
    }

}