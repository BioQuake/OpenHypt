using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class RayEffectLength : MonoBehaviour
{
    public LayerMask targetLayers;
    public virtual void FixedUpdate()
    {
        RaycastHit hit = default(RaycastHit);
        if (Physics.Raycast(this.transform.position, this.transform.up, out hit, 20000, (int) this.targetLayers))
        {
            this.transform.localScale = new Vector3(0.6f, hit.distance, 0.6f);
        }
        else
        {
            this.transform.localScale = new Vector3(0.6f, 20000, 0.6f);
        }
    }

}