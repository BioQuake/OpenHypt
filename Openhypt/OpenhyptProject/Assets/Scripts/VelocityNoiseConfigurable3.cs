using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class VelocityNoiseConfigurable3 : MonoBehaviour
{
    public bool Stopped;
    public bool IsPlaying;
    public GameObject Vessel;
    public MainVehicleController VesselScript;
    public bool UseVolCurve;
    public bool UsePitchCurve;
    public bool UseEngine;
    public bool EngineOn;
    public float Modifier;
    public AnimationCurve PitchCurve;
    public float PitchAmount;
    public float PitchMod;
    public AnimationCurve curve;
    public float VolumeAmount;
    public float VolumeMod;
    public bool UseBoost;
    public float maxVolume;
    public float incrementValue;
    public float decrementValue;
    private string state;
    public virtual IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        if (this.UseVolCurve)
        {
            this.GetComponent<AudioSource>().volume = 0;
            this.GetComponent<AudioSource>().Stop();
            this.Stopped = true;
            this.IsPlaying = false;
        }
    }

    public virtual void Update()
    {
        if (this.UseBoost)
        {
            if (this.VesselScript.Boosting == true)
            {
                this.state = "increment";
            }
            else
            {
                this.state = "decrement";
            }
        }
    }

    public virtual void FixedUpdate()
    {
        if (!this.Vessel)
        {
            return;
        }
        if (this.GetComponent<AudioSource>() == null)
        {
            UnityEngine.Object.Destroy(this);
        }
        else
        {
            float p = this.Vessel.GetComponent<Rigidbody>().velocity.magnitude / this.Modifier;
            if (this.UseBoost)
            {
                if (this.state == "increment")
                {
                    this.increment();
                }
                else
                {
                    if (this.state == "decrement")
                    {
                        this.decrement();
                    }
                }
            }
            if (!this.UseEngine)
            {
                if (this.Vessel.GetComponent<Rigidbody>().velocity.magnitude > 0.3f)
                {
                    if (this.UsePitchCurve)
                    {
                        this.GetComponent<AudioSource>().pitch = this.PitchAmount;
                        this.PitchAmount = this.PitchCurve.Evaluate(p) * this.PitchMod;
                    }
                    if (this.UseVolCurve)
                    {
                        this.GetComponent<AudioSource>().volume = this.VolumeAmount;
                        this.VolumeAmount = this.curve.Evaluate(p) * this.VolumeMod;
                    }
                    if (this.UseVolCurve)
                    {
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
                }
            }
            if (this.UseEngine)
            {
                if (this.VesselScript.EngineRunning == true)
                {
                    this.EngineOn = true;
                }
                if (this.VesselScript.EngineRunning == false)
                {
                    this.EngineOn = false;
                }
                if ((this.Vessel.GetComponent<Rigidbody>().velocity.magnitude > 0.3f) && this.EngineOn)
                {
                    if (this.UsePitchCurve)
                    {
                        this.GetComponent<AudioSource>().pitch = this.PitchAmount;
                        this.PitchAmount = this.PitchCurve.Evaluate(p) * this.PitchMod;
                    }
                    if (this.UseVolCurve)
                    {
                        this.GetComponent<AudioSource>().volume = this.VolumeAmount;
                        this.VolumeAmount = this.curve.Evaluate(p) * this.VolumeMod;
                    }
                    if (this.UseVolCurve)
                    {
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
                }
                if (!this.EngineOn)
                {
                    this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume - 0.05f;
                }
            }
        }
    }

    public virtual void decrement()
    {
        if (this.GetComponent<AudioSource>().volume > 0)
        {
            this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume - this.decrementValue;
        }
        else
        {
            this.GetComponent<AudioSource>().Stop();
            this.state = "";
        }
    }

    public virtual void increment()
    {
        if (!this.GetComponent<AudioSource>().isPlaying)
        {
            this.GetComponent<AudioSource>().Play();
        }
        if (this.GetComponent<AudioSource>().volume < this.maxVolume)
        {
            this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume + this.incrementValue;
        }
        else
        {
            this.state = "";
        }
    }

    public VelocityNoiseConfigurable3()
    {
        this.Modifier = 60f;
        this.PitchCurve = new AnimationCurve();
        this.PitchMod = 1f;
        this.curve = new AnimationCurve();
        this.VolumeMod = 1f;
        this.maxVolume = 0.5f;
        this.incrementValue = 0.05f;
        this.decrementValue = 0.05f;
    }

}