using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class JammingScript : MonoBehaviour
{
    public Transform target;
    public virtual void Update()
    {
        if (this.target)
        {
            if (this.target.gameObject.GetComponent<MissileScript>() != null)
            {
                this.target.gameObject.GetComponent<MissileScript>().AimForce = 0;
            }
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Collider>().name.Contains("MT"))
        {
            this.target = other.gameObject.transform;
        }
        if (other.GetComponent<Collider>().name.Contains("sTC7"))
        {
            other.name = "sTC7j";
        }
        if (other.GetComponent<Collider>().name.Contains("sTC2"))
        {
            other.name = "sTC2j";
        }
        if (other.GetComponent<Collider>().name.Contains("sTC4"))
        {
            other.name = "sTC4j";
        }
    }

}