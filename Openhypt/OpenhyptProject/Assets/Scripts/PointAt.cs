using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PointAt : MonoBehaviour
{
    public Transform target;
    public virtual void FixedUpdate()
    {
        this.transform.LookAt(this.target);
    }

}