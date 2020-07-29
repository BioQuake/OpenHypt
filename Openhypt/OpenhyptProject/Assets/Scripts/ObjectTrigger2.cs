using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ObjectTrigger2 : MonoBehaviour
{
    public bool Triggered;
    public virtual void OnTriggerStay(Collider other)
    {
        this.Triggered = true;
    }

    public virtual void Reader()
    {
        this.Triggered = false;
    }

    public virtual void Start()
    {
        this.InvokeRepeating("Reader", 1, 0.5f);
    }

}