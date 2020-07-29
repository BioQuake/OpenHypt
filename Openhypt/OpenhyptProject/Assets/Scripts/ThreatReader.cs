using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ThreatReader : MonoBehaviour
{
    public string IgnoreThis;
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().name.Contains("TC"))
        {
            if (!other.GetComponent<Collider>().name.Contains(this.IgnoreThis))
            {
                UnityEngine.Object.Destroy(this.gameObject);
            }
        }
    }

    public ThreatReader()
    {
        this.IgnoreThis = "PersonMcPersonface";
    }

}