using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AgroidController : MonoBehaviour
{
    public Transform Target;
    public AgroidSensor Sensor;
    public GameObject ZapEffect;
    public GameObject Presence;
    public bool Rogue;
    public virtual void Start()
    {
        this.InvokeRepeating("Counter", 0.63f, 1);
        if (this.Rogue)
        {
            this.Sensor.Rogue = true;
        }
    }

    public virtual void FixedUpdate()
    {
        if (this.Target != null)
        {
            if (Vector3.Distance(this.transform.position, this.Target.position) > 3)
            {
                if (this.GetComponent<Rigidbody>().velocity.magnitude < 15)
                {
                    this.GetComponent<Rigidbody>().AddForce((this.Target.transform.position - this.transform.position).normalized * 0.05f);
                }
            }
            if (Vector3.Distance(this.transform.position, this.Target.position) < 3)
            {
                this.GetComponent<Rigidbody>().AddForce((this.Target.transform.position - this.transform.position) * 0);
            }
        }
    }

    public virtual void Zap()
    {
        if (this.Target != null)
        {
            GameObject TheThing = UnityEngine.Object.Instantiate(this.ZapEffect, this.gameObject.transform.position, this.gameObject.transform.rotation);
            TheThing.transform.parent = this.gameObject.transform;
        }
    }

    public virtual void Counter()
    {
        if (this.Rogue)
        {
            if (this.GetComponent<Rigidbody>().velocity.magnitude > 5)
            {
                this.Presence.name = "sTC4TFC4";
            }
            else
            {
                this.Presence.name = "sTC4";
            }
        }
        else
        {
            if (this.GetComponent<Rigidbody>().velocity.magnitude > 5)
            {
                this.Presence.name = "sTC4TFC4";
            }
            else
            {
                this.Presence.name = "sTC4";
            }
        }
    }

}