using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MissileExplosionScript : MonoBehaviour
{
    public virtual IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f);
        UnityEngine.Object.Destroy((SphereCollider) this.GetComponent(typeof(SphereCollider)));
    }

}