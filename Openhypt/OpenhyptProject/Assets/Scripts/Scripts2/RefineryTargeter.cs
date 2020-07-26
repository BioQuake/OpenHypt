using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class RefineryTargeter : MonoBehaviour
{
    public Transform target;
    public virtual void Look()
    {
        this.CheckVessel();
        if (this.target != null)
        {
            this.transform.position = this.target.transform.position;
        }
    }

    public virtual void CheckVessel()
    {
        this.target = GameObject.Find("ProspectorPresence").transform;
    }

    public virtual void Start()
    {
        this.InvokeRepeating("Look", 3, 0.5f);
    }

}