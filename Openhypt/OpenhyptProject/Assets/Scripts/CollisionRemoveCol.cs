using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class CollisionRemoveCol : MonoBehaviour
{
    public virtual IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        ((MeshRenderer) this.GetComponent(typeof(MeshRenderer))).enabled = true;
    }

    public virtual void OnCollisionEnter()
    {
        SphereCollider Colly = (SphereCollider) this.GetComponent(typeof(SphereCollider));
        MeshRenderer Meshy = (MeshRenderer) this.GetComponent(typeof(MeshRenderer));
        UnityEngine.Object.Destroy(Colly);
        UnityEngine.Object.Destroy(Meshy);
    }

}