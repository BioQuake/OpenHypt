using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class RayHitDamage : MonoBehaviour
{
    public GameObject collision;
    public float startPoint;
    public float range;
    public LayerMask targetLayers;
    public virtual void Start()
    {
        RaycastHit hit = default(RaycastHit);
        if (Physics.Raycast(this.transform.position + (this.transform.forward * this.startPoint), this.transform.forward, out hit, this.range, (int) this.targetLayers))
        {
            UnityEngine.Object.Instantiate(this.collision, hit.point, Quaternion.identity);
        }
    }

    public RayHitDamage()
    {
        this.startPoint = 0.1f;
        this.range = 20000;
    }

}