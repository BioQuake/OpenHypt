using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PeuknythAimer : MonoBehaviour
{
    public Transform target;
    private Quaternion NewRotation;
    public virtual void Update()
    {
        if (this.target)
        {
            this.NewRotation = Quaternion.LookRotation(this.target.position - this.transform.position);
            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, this.NewRotation, Time.deltaTime * 400);
        }
    }

}