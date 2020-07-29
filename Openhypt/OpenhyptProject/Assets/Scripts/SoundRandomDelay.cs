using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SoundRandomDelay : MonoBehaviour
{
    public float MaxTime;
    public bool AlterPitch;
    public float Alteration;
    public bool NoRandom;
    public virtual IEnumerator Start()
    {
        float delayTime = Random.Range(0.1f, this.MaxTime);
        if (this.AlterPitch)
        {
            this.GetComponent<AudioSource>().pitch = this.GetComponent<AudioSource>().pitch = this.GetComponent<AudioSource>().pitch + Random.Range(-this.Alteration, this.Alteration);
        }
        if (!this.NoRandom)
        {
            this.GetComponent<AudioSource>().playOnAwake = true;
            this.GetComponent<AudioSource>().PlayDelayed(delayTime);
            yield return new WaitForSeconds(this.MaxTime);
            if (this.GetComponent<AudioSource>())
            {
                this.GetComponent<AudioSource>().playOnAwake = true;
                this.GetComponent<AudioSource>().Play();
            }
        }
        if (this.NoRandom)
        {
            yield return new WaitForSeconds(this.MaxTime);
            if (this.GetComponent<AudioSource>())
            {
                this.GetComponent<AudioSource>().playOnAwake = true;
                this.GetComponent<AudioSource>().Play();
            }
        }
    }

    public SoundRandomDelay()
    {
        this.MaxTime = 0.3f;
        this.Alteration = 0.2f;
    }

}