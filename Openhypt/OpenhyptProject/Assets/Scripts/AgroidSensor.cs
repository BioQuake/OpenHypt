using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AgroidSensor : MonoBehaviour
{
    public AgroidController Controller;
    public GameObject SensorTarget;
    public bool Rogue;
    public bool Tick;
    public virtual void Update()
    {
        this.StartCoroutine(this.Notice());
    }

    public virtual IEnumerator Notice()
    {
        if (this.Tick)
        {
            yield break;
        }
        this.Tick = true;
        if (this.SensorTarget != null)
        {
            Vector3 lastPos = this.SensorTarget.transform.position;
            yield return new WaitForSeconds(Random.Range(0.15f, 0.25f));
            if (this.SensorTarget)
            {
                if (Vector3.Distance(this.SensorTarget.transform.position, lastPos) > 0.2f)
                {
                    this.Controller.Target = this.SensorTarget.transform;
                    yield return new WaitForSeconds(Random.Range(0.95f, 1.05f));
                    if (this.SensorTarget)
                    {
                        if (Vector3.Distance(this.SensorTarget.transform.position, this.transform.position) < 4)
                        {
                            this.Controller.Zap();
                        }
                    }
                }
            }
        }
        this.Tick = false;
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().name.Contains("TFC"))
        {
            ((SphereCollider) this.gameObject.GetComponent(typeof(SphereCollider))).radius = 100;
            if (this.SensorTarget != null)
            {
                this.Controller.Target = this.SensorTarget.transform;
            }
        }
        if (other.GetComponent<Collider>().name.Contains("TC") && this.Rogue)
        {
            if (!other.gameObject.name.Contains("sTC4"))
            {
                this.SensorTarget = other.gameObject;
                ((SphereCollider) this.gameObject.GetComponent(typeof(SphereCollider))).radius = 15;
            }
        }
        if (other.GetComponent<Collider>().name.Contains("TC") && !this.Rogue)
        {
            if (!other.gameObject.name.Contains("sTC2"))
            {
                this.SensorTarget = other.gameObject;
                ((SphereCollider) this.gameObject.GetComponent(typeof(SphereCollider))).radius = 15;
            }
        }
    }

}