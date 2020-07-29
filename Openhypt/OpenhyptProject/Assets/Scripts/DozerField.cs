using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class DozerField : MonoBehaviour
{
    public float Power;
    public bool ChangeDrag;
    public bool UseCurve;
    public AnimationCurve ForceCurve;
    public float ForceAmount;
    public virtual void OnTriggerEnter(Collider other)
    {
        if (this.ChangeDrag)
        {
            if (other.GetComponent<Rigidbody>())
            {
                other.GetComponent<Rigidbody>().drag = 0.5f;
                other.GetComponent<Rigidbody>().useGravity = false;
            }
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if (!other.GetComponent<Rigidbody>())
        {
            return;
        }
        if (!this.UseCurve)
        {
            other.GetComponent<Rigidbody>().AddForce((other.transform.position - this.transform.position).normalized * this.Power);
        }
        else
        {
            float p = Vector3.Distance(other.transform.position, this.transform.position);
            this.ForceAmount = this.ForceCurve.Evaluate(p);
            other.GetComponent<Rigidbody>().AddForce((other.transform.position - this.transform.position).normalized * -this.ForceAmount);
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (this.ChangeDrag)
        {
            if (other.GetComponent<Rigidbody>())
            {
                other.GetComponent<Rigidbody>().drag = 0.05f;
                other.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }

    public DozerField()
    {
        this.Power = 0.05f;
        this.ForceCurve = new AnimationCurve();
    }

}