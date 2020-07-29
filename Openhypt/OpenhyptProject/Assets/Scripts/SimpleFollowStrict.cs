using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SimpleFollowStrict : MonoBehaviour
{
    public Transform Target;
    public float damping;
    public virtual void LateUpdate()
    {
        Quaternion rotation = Quaternion.LookRotation(this.Target.position - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, Time.deltaTime * this.damping);
    }

    public SimpleFollowStrict()
    {
        this.damping = 6f;
    }

}