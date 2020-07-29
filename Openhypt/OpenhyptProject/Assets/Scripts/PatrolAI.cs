using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PatrolAI : MonoBehaviour
{
    public Transform target;
    public Transform alignTarget;
    public Transform Waypoint1;
    public Transform Waypoint2;
    public bool Turning;
    public bool Aligning;
    public float TurnTime;
    public float AlignTime;
    public float TrigDist;
    public float AlignForce;
    public float DirForce;
    public float TurnForce;
    public float AimForce;
    public float AimForceOffset;
    public virtual void Start()
    {
        this.InvokeRepeating("Regenerator", 1, 1.3f);
    }

    public virtual void FixedUpdate()
    {
        if (this.target)
        {
            this.GetComponent<Rigidbody>().AddForceAtPosition((this.target.transform.position - this.transform.position).normalized * this.AimForce, -this.transform.up * this.AimForceOffset);
            this.GetComponent<Rigidbody>().AddForceAtPosition((this.target.transform.position - this.transform.position).normalized * -this.AimForce, this.transform.up * this.AimForceOffset);
        }
        if (this.Turning)
        {
            this.GetComponent<Rigidbody>().AddTorque(-this.transform.forward * this.TurnForce);
        }
        if (this.Aligning)
        {
            this.GetComponent<Rigidbody>().AddForce((this.alignTarget.position - this.transform.position).normalized * this.AlignForce);
        }
        else
        {
            this.GetComponent<Rigidbody>().AddForce(-this.transform.up * this.DirForce);
        }
    }

    public virtual IEnumerator Align()
    {
        yield return new WaitForSeconds(this.TurnTime);
        this.Turning = false;
        yield return new WaitForSeconds(this.AlignTime);
        this.Aligning = false;
    }

    public virtual void Regenerator()
    {
        if (Vector3.Distance(this.transform.position, this.target.position) < this.TrigDist)
        {
            if (this.target == this.Waypoint1)
            {
                this.target = this.Waypoint2;
                this.alignTarget = this.Waypoint1;
            }
            else
            {
                if (this.target == this.Waypoint2)
                {
                    this.target = this.Waypoint1;
                    this.alignTarget = this.Waypoint2;
                }
            }
            this.Turning = true;
            this.Aligning = true;
            this.StartCoroutine(this.Align());
        }
    }

    public PatrolAI()
    {
        this.TurnTime = 10;
        this.AlignTime = 10;
        this.TrigDist = 10;
        this.AlignForce = 1;
        this.DirForce = 1;
        this.TurnForce = 1;
        this.AimForce = 10;
        this.AimForceOffset = 10;
    }

}