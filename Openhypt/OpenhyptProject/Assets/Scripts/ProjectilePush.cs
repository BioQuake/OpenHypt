using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ProjectilePush : MonoBehaviour
{
    public float PushVelocity;
    public bool PushForward;
    public bool PushUp;
    public bool unevenTraj;
    public float unevenness;
    public bool EnableCol;
    public SphereCollider Col;
    public bool KillOverTime;
    public float KOTNum;
    public virtual IEnumerator Start()
    {
        if (this.unevenTraj)
        {
            this.transform.Rotate(Vector3.right * Random.Range(-this.unevenness, this.unevenness));
            this.transform.Rotate(Vector3.up * Random.Range(-this.unevenness, this.unevenness));
        }
        if (this.PushForward)
        {
            this.GetComponent<Rigidbody>().velocity = (this.transform.forward * this.PushVelocity) * 0.45f;
        }
        if (this.PushUp)
        {
            this.GetComponent<Rigidbody>().velocity = (this.transform.up * this.PushVelocity) * 0.45f;
        }
        if (this.PushVelocity > 1400)
        {
            if (DutvutanianNetwork.AlertTime > 10)
            {
                if (Vector3.Distance(DutvutanianNetwork.instance.PriorityWaypoint.position, this.transform.position) < 1500)
                {
                    DutvutanianNetwork.instance.PriorityWaypoint.position = this.transform.position;
                }
            }
        }
        if (this.EnableCol)
        {
            yield return new WaitForSeconds(0.1f);
            this.Col.enabled = true;
        }
        if (this.KillOverTime)
        {
            yield return new WaitForSeconds(this.KOTNum);
            UnityEngine.Object.Destroy(this.gameObject);
        }
    }

    public ProjectilePush()
    {
        this.PushForward = true;
        this.KOTNum = 0.5f;
    }

}