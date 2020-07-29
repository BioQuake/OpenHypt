using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class CollisionExplosion : MonoBehaviour
{
    public GameObject explosion; // drag your explosion prefab here
    public bool DirectedExplosion;
    public Transform UnchildFX1;
    public Transform UnchildFX2;
    public bool C;
    public virtual void OnCollisionEnter(Collision collision)
    {
        if (this.C || (collision.gameObject.tag == "Explosions"))
        {
            return;
        }
        this.C = true;
        if (this.UnchildFX1 != null)
        {
            this.UnchildFX1.parent = null;
            ((ParticleSystem) this.UnchildFX1.gameObject.GetComponent(typeof(ParticleSystem))).emissionRate = 0;
        }
        if (this.UnchildFX2 != null)
        {
            this.UnchildFX2.parent = null;
            ((ParticleSystem) this.UnchildFX2.gameObject.GetComponent(typeof(ParticleSystem))).emissionRate = 0;
        }
        if (this.DirectedExplosion)
        {
            UnityEngine.Object.Instantiate(this.explosion, this.transform.position, this.transform.rotation);
        }
        if (!this.DirectedExplosion)
        {
            UnityEngine.Object.Instantiate(this.explosion, this.transform.position, this.explosion.transform.rotation);
        }
        UnityEngine.Object.Destroy(this.gameObject);
    }

}