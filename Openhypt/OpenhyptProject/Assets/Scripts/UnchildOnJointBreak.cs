using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class UnchildOnJointBreak : MonoBehaviour
{
    public bool EnableGravity;
    public virtual void OnJointBreak(float breakForce)
    {
        if (this.EnableGravity)
        {
            this.GetComponent<Rigidbody>().useGravity = true;
        }
        this.transform.parent = null;
    }

}