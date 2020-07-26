using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class OotkinSicknessController : MonoBehaviour
{
    public GameObject Blotches1;
    public GameObject Blotches2;
    public bool Ending;
    public virtual IEnumerator Start()
    {
        yield return new WaitForSeconds(120);
        this.Ending = true;
        yield return new WaitForSeconds(60);
        WorldInformation.IsOotkinSick = false;
        UnityEngine.Object.Destroy(this.gameObject);
    }

    public virtual void FixedUpdate()
    {
        if (this.Ending)
        {
            this.Blotches1.GetComponent<ParticleSystem>().emissionRate = this.Blotches1.GetComponent<ParticleSystem>().emissionRate - 0.01f;
            this.Blotches2.GetComponent<ParticleSystem>().emissionRate = this.Blotches2.GetComponent<ParticleSystem>().emissionRate - 0.01f;
        }
    }

}