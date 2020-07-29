using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class StickyNPC : MonoBehaviour
{
    public Transform Ally;
    public GameObject Sensor;
    public GameObject DeathEffect;
    public float AllyFollowDist;
    public float Power;
    public virtual void FixedUpdate()
    {
        if (this.Ally != null)
        {
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

    public virtual void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == "NPCProjectile") || (collision.gameObject.tag == "PlayerThreat"))
        {
            UnityEngine.Object.Instantiate(this.DeathEffect, this.transform.position, this.transform.rotation);
            UnityEngine.Object.Destroy(this.gameObject);
        }
    }

    public StickyNPC()
    {
        this.AllyFollowDist = 2;
        this.Power = 0.05f;
    }

}