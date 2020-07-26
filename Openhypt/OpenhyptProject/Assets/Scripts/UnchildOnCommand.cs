using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class UnchildOnCommand : MonoBehaviour
{
    public bool Unchild;
    public virtual void Update()
    {
        if (this.Unchild)
        {
            this.transform.parent = null;
            UnityEngine.Object.Destroy(this);
        }
    }

}