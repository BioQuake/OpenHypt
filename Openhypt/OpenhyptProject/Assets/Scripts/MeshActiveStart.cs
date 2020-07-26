using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MeshActiveStart : MonoBehaviour
{
    public virtual void Start()
    {
        this.GetComponent<Renderer>().enabled = true;
        UnityEngine.Object.Destroy(this);
    }

}