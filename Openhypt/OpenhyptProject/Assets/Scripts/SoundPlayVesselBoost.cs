using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SoundPlayVesselBoost : MonoBehaviour
{
    public AudioClip SoundStart;
    public AudioClip SoundEnd;
    public GameObject BoomEffectStart;
    public GameObject BoomEffectEnd;
    public GameObject Vessel;
    public int SpeedThreshold;
    public bool Fast;
    public virtual void LateUpdate()
    {
        if (this.Vessel.GetComponent<Rigidbody>().velocity.magnitude > this.SpeedThreshold)
        {
            if (!this.Fast)
            {
                this.Fast = true;
                this.GetComponent<AudioSource>().PlayOneShot(this.SoundStart);
                UnityEngine.Object.Instantiate(this.BoomEffectStart, this.transform.position + new Vector3(0, 0, 0), this.transform.rotation);
            }
        }
        else
        {
            if (this.Fast)
            {
                this.Fast = false;
                this.GetComponent<AudioSource>().PlayOneShot(this.SoundEnd);
                UnityEngine.Object.Instantiate(this.BoomEffectEnd, this.transform.position + new Vector3(0, 0, 0), this.transform.rotation);
            }
        }
    }

    public SoundPlayVesselBoost()
    {
        this.SpeedThreshold = 300;
    }

}