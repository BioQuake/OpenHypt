using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class GhostColFollow : MonoBehaviour
{
    public Transform Target;
    public virtual void Start()
    {
        this.transform.parent = null;
    }

    public virtual void LateUpdate()
    {
        if (this.Target == null)
        {
            UnityEngine.Object.Destroy(this.gameObject);
            return;
        }
        this.transform.rotation = this.Target.transform.rotation;
        this.transform.position = this.Target.transform.position;
    }

}