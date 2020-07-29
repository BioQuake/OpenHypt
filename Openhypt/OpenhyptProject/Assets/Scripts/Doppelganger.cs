using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class Doppelganger : MonoBehaviour
{
    public Transform Target;
    public virtual void LateUpdate()
    {
        if (this.Target == null)
        {
            return;
        }
        this.transform.rotation = this.Target.transform.rotation;
        this.transform.position = this.Target.transform.position;
    }

}