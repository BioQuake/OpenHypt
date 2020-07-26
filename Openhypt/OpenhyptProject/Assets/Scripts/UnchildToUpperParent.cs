using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class UnchildToUpperParent : MonoBehaviour
{
    public virtual void Start()
    {
        this.transform.parent = this.transform.parent.parent;
    }

}