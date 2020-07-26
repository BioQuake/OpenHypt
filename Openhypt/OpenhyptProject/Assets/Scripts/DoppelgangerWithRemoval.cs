using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class DoppelgangerWithRemoval : MonoBehaviour
{
    public Transform Target;
    public virtual void FixedUpdate()
    {
        if (this.Target == null)
        {
            UnityEngine.Object.Destroy(this.gameObject);
        }
        else
        {
            this.transform.rotation = this.Target.rotation;
            this.transform.position = this.Target.position;
        }
    }

}