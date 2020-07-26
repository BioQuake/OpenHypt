using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MineralStorage : MonoBehaviour
{
    public bool isInside;
    public virtual void Update()
    {
        if (Input.GetKeyDown("r"))
        {
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().gameObject.name.Contains("ProspectorPresence"))
        {
            this.isInside = true;
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().gameObject.name.Contains("ProspectorPresence"))
        {
            this.isInside = false;
        }
    }

}