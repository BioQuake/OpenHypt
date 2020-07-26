using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class WheelSpinNoise : MonoBehaviour
{
    public GameObject Vessel;
    public float audioClipSpeed;
    public float MaxVol;
    public float MaxPitch;
    public float MinPitch;
    public virtual void Start()
    {
    }

    public virtual void FixedUpdate()
    {
        float p = this.Vessel.GetComponent<Rigidbody>().angularVelocity.magnitude / this.audioClipSpeed;
        this.GetComponent<AudioSource>().pitch = Mathf.Clamp(p * 1, this.MinPitch, this.MaxPitch);
        if (this.Vessel.GetComponent<Rigidbody>().angularVelocity.magnitude < 1)
        {
            this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume - 0.02f;
        }
        else
        {
            if (this.Vessel.GetComponent<Rigidbody>().angularVelocity.magnitude > 1)
            {
                if (this.GetComponent<AudioSource>().volume < this.MaxVol)
                {
                    this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume + 0.02f;
                }
            }
        }
    }

    public WheelSpinNoise()
    {
        this.audioClipSpeed = 20f;
        this.MaxVol = 1f;
        this.MaxPitch = 1f;
    }

}