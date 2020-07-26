using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class RaytraceCollisionExplosion : MonoBehaviour
{
    public GameObject explosion;
    public Vector3 Point;
    public virtual void Start()
    {
        RaycastHit hit = default(RaycastHit);
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, 2000))
        {
            this.Point = hit.point;
            Quaternion NormalAngle = Quaternion.LookRotation(hit.normal);
            UnityEngine.Object.Instantiate(this.explosion, this.Point, NormalAngle);
        }
    }

}