using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SpaceTraceScript : MonoBehaviour
{
    public GameObject SpaceTrace;
    public Transform Target;
    public float Power;
    public int NoticeRadius;
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
        if (this.Target == null)
        {
            this.SpaceTrace.GetComponent<Rigidbody>().drag = 1;
            this.SpaceTrace.GetComponent<Rigidbody>().angularDrag = 0.1f;
        }
        this.Tick = true;
        yield return new WaitForSeconds(0.8f);
        this.Target = null;
        ((SphereCollider) this.gameObject.GetComponent(typeof(SphereCollider))).radius = this.NoticeRadius;
        yield return new WaitForSeconds(0.2f);
        ((SphereCollider) this.gameObject.GetComponent(typeof(SphereCollider))).radius = 0.01f;
        this.Tick = false;
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if (this.Target == null)
        {
            if (other.gameObject.name == "HeatSource")
            {
                this.Target = other.gameObject.transform;
            }
        }
    }

    public virtual void FixedUpdate()
    {
        if (this.Target != null)
        {
            this.SpaceTrace.GetComponent<Rigidbody>().drag = 0;
            this.SpaceTrace.GetComponent<Rigidbody>().angularDrag = 0;
            this.SpaceTrace.GetComponent<Rigidbody>().AddForce((this.Target.transform.position - this.transform.position).normalized * this.Power);
        }
    }

    public SpaceTraceScript()
    {
        this.Power = 0.01f;
        this.NoticeRadius = 100;
    }

}