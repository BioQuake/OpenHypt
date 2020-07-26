using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ShotLeader : MonoBehaviour
{
    public Transform target;
    public Transform TargetTrace;
    public Transform TargetLead;
    public GameObject Shot;
    public virtual void Update()
    {
        this.transform.LookAt(this.TargetLead);
    }

    public virtual void Shoot()
    {
        UnityEngine.Object.Instantiate(this.Shot, this.transform.position, this.transform.rotation);
    }

    public virtual void LeaveMarker()
    {
        this.StartCoroutine(this.Marker());
    }

    public virtual IEnumerator Marker()
    {
        this.TargetTrace.position = this.target.position;
        yield return new WaitForSeconds(0.08f);
        float Dist1 = Vector3.Distance(this.transform.position, this.target.position);
        float Dist2 = Vector3.Distance(this.TargetTrace.position, this.target.position);
        this.TargetTrace.LookAt(this.target);
        this.TargetLead.position = this.TargetTrace.position;
        this.TargetLead.rotation = this.TargetTrace.rotation;
        this.TargetLead.position = this.TargetLead.position + (((this.TargetLead.forward * Dist1) * Dist2) * 0.02f);
    }

    public virtual void Start()
    {
        this.InvokeRepeating("LeaveMarker", 1, 0.1f);
        this.InvokeRepeating("Shoot", 10, 1);
    }

}