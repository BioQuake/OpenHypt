using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class VelocityNoiseConfigurable2 : MonoBehaviour
{
    public bool Stopped;
    public bool IsPlaying;
    public GameObject Vessel;
    public MainVehicleController VesselScript;
    public bool UseEngine;
    public bool ShutOff;
    public SoundObscure ObscureScript;
    public bool SkipVol;
    public float audioClipSpeed;
    public float MaxPitch;
    public float MinPitch;
    public AnimationCurve curve;
    public float VolumeAmount;
    public float VolumeMod;
    public virtual IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        this.GetComponent<AudioSource>().volume = 0;
        this.GetComponent<AudioSource>().Stop();
        this.Stopped = true;
        this.IsPlaying = false;
    }

    public virtual void Update()
    {
        if (this.UseEngine)
        {
            if (this.VesselScript.EngineRunning == true)
            {
                this.ShutOff = false;
            }
            if (this.VesselScript.EngineRunning == false)
            {
                this.ShutOff = true;
                this.Stopped = true;
            }
        }
        if (this.VesselScript)
        {
            if (this.VesselScript.Broken)
            {
                this.ShutOff = true;
            }
        }
        if (this.ObscureScript)
        {
            this.SkipVol = this.ObscureScript.Obscured;
        }
        if (!this.ShutOff)
        {
            if (this.Vessel.GetComponent<Rigidbody>().velocity.magnitude > 0.3f)
            {
                float p = this.Vessel.GetComponent<Rigidbody>().velocity.magnitude / this.audioClipSpeed;
                this.GetComponent<AudioSource>().pitch = Mathf.Clamp(p, this.MinPitch, this.MaxPitch); // p is clamped to sane values
                if (this.ObscureScript)
                {
                    if (!this.SkipVol)
                    {
                        if (this.GetComponent<AudioSource>().volume < this.VolumeAmount)
                        {
                            this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume + 0.05f;
                        }
                        else
                        {
                            this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume - 0.05f;
                        }
                    }
                    else
                    {
                        this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume - 0.05f;
                    }
                }
                else
                {
                    this.GetComponent<AudioSource>().volume = this.VolumeAmount;
                }
                this.VolumeAmount = this.curve.Evaluate(p) * this.VolumeMod;
                if (this.Vessel.GetComponent<Rigidbody>().velocity.magnitude < 0.3f)
                {
                    this.GetComponent<AudioSource>().Stop();
                    this.Stopped = true;
                    this.IsPlaying = false;
                }
                else
                {
                    if ((this.Vessel.GetComponent<Rigidbody>().velocity.magnitude > 0.3f) && (this.Stopped == true))
                    {
                        this.GetComponent<AudioSource>().Play();
                        this.Stopped = false;
                        this.IsPlaying = true;
                    }
                }
            }
            if (this.SkipVol)
            {
                if (this.GetComponent<AudioSource>().volume > 0)
                {
                    this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume - 0.05f;
                }
            }
        }
        else
        {
            if (this.GetComponent<AudioSource>().volume > 0)
            {
                this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume - 0.05f;
            }
            else
            {
                this.GetComponent<AudioSource>().Stop();
            }
        }
    }

    public VelocityNoiseConfigurable2()
    {
        this.audioClipSpeed = 60f;
        this.MaxPitch = 5;
        this.curve = new AnimationCurve();
        this.VolumeMod = 1f;
    }

}