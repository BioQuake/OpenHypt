using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class VelocityNoiseConfigurable2WS : MonoBehaviour
{
    public bool Increased;
    public GameObject Vessel;
    public float audioClipSpeed;
    public float MaxVol;
    public float MaxPitch;
    public float MinPitch;
    public AnimationCurve curve;
    public float VolumeAmount;
    public float VolumeMod;
    public virtual void Update()
    {
        if (WorldInformation.playerCar != this.transform.parent.name)
        {
            return;
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (!this.Increased)
            {
                if (this.GetComponent<AudioSource>().volume < this.MaxVol)
                {
                    this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume + 0.075f;
                    this.VolumeAmount = this.VolumeAmount + 0.075f;
                }
            }
        }
        if (!Input.GetKey(KeyCode.W))
        {
            this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume - 0.02f;
            if (this.GetComponent<AudioSource>().volume == 0)
            {
                this.Increased = false;
            }
        }
        if (this.GetComponent<AudioSource>().volume > this.MaxVol)
        {
            this.Increased = true;
        }
        if (((this.Vessel.GetComponent<Rigidbody>().velocity.magnitude > 0.3f) && this.Increased) && Input.GetKey(KeyCode.W))
        {
            float p = this.Vessel.GetComponent<Rigidbody>().velocity.magnitude / this.audioClipSpeed;
            this.GetComponent<AudioSource>().pitch = Mathf.Clamp(p, this.MinPitch, this.MaxPitch); // p is clamped to sane values
            this.GetComponent<AudioSource>().volume = this.VolumeAmount;
            this.VolumeAmount = this.curve.Evaluate(p) * this.VolumeMod;
        }
    }

    public VelocityNoiseConfigurable2WS()
    {
        this.audioClipSpeed = 60f;
        this.MaxVol = 1;
        this.MaxPitch = 5;
        this.curve = new AnimationCurve();
        this.VolumeMod = 1f;
    }

}