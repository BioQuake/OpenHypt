using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class NPCMover : MonoBehaviour
{
    public Transform Ally;
    public float AllyFollowDist;
    public float Power;
    public float LookForce;
    public virtual void Start()
    {
    }

    public virtual void FixedUpdate()
    {
        if (this.Ally != null)
        {
            this.GetComponent<Rigidbody>().AddForceAtPosition((this.Ally.transform.position - this.transform.position).normalized * this.LookForce, this.transform.forward * 1);
            this.GetComponent<Rigidbody>().AddForceAtPosition((this.Ally.transform.position - this.transform.position).normalized * -this.LookForce, -this.transform.forward * 1);
            if (Vector3.Distance(this.transform.position, this.Ally.position) > this.AllyFollowDist)
            {
                this.GetComponent<Rigidbody>().AddForce((this.Ally.transform.position - this.transform.position).normalized * this.Power);
            }
            if (Vector3.Distance(this.transform.position, this.Ally.position) < this.AllyFollowDist)
            {
                this.GetComponent<Rigidbody>().AddForce((this.Ally.transform.position - this.transform.position) * 0);
            }
        }
    }

    public NPCMover()
    {
        this.AllyFollowDist = 2;
        this.Power = 0.05f;
        this.LookForce = 0.1f;
    }

}