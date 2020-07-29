using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class LookAt : MonoBehaviour
{
    public Transform target;
    public bool useAimPoint;
    public Transform Point;
    public virtual void Start()
    {
        if (this.useAimPoint)
        {
            this.Point = GameObject.Find("AimPointTarget").gameObject.transform;
        }
    }

    public virtual void LateUpdate()
    {
        if (!this.useAimPoint)
        {
            this.transform.LookAt(this.target);
        }
        else
        {
            this.transform.LookAt(this.Point);
        }
    }

}