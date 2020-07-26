using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class KillOverTimeRapid : MonoBehaviour
{
    public float lifetime;
    public virtual void FixedUpdate()
    {
        UnityEngine.Object.Destroy(this.gameObject, this.lifetime);
    }

    public KillOverTimeRapid()
    {
        this.lifetime = 0.5f;
    }

}