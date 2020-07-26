using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class BeamFireScript : MonoBehaviour
{
    public GameObject Chunk;
    public float TimeSpan;
    public virtual IEnumerator Start()
    {
        this.InvokeRepeating("BeamSequence", 0.05f, 0.05f);
        yield return new WaitForSeconds(this.TimeSpan);
        this.StopAllCoroutines();
        UnityEngine.Object.Destroy(this);
    }

    public virtual void BeamSequence()
    {
        UnityEngine.Object.Instantiate(this.Chunk, this.transform.position, this.transform.rotation);
    }

    public BeamFireScript()
    {
        this.TimeSpan = 2.7f;
    }

}