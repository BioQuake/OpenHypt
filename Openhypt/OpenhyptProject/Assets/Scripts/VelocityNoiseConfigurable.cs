using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class VelocityNoiseConfigurable : MonoBehaviour
{
    public GameObject Vessel;
    public float audioClipSpeed;
    public float MaxPitch;
    public float MinPitch;
    public virtual void Update()
    {
        float p = this.Vessel.GetComponent<Rigidbody>().velocity.magnitude / this.audioClipSpeed;
        this.GetComponent<AudioSource>().pitch = Mathf.Clamp(p, this.MinPitch, this.MaxPitch);
    }

    public VelocityNoiseConfigurable()
    {
        this.audioClipSpeed = 60f;
        this.MaxPitch = 5;
    }

}