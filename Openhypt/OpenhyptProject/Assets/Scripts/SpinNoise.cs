using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SpinNoise : MonoBehaviour
{
    public bool Stopped;
    public GameObject Vessel;
    public bool UseOtherV;
    public bool UseOtherV2;
    public bool AccurateVolume;
    public bool UseSpecificAxis;
    public bool UseX;
    public GameObject OtherV2;
    public GameObject OtherV3;
    public GameObject OtherV4;
    public float audioClipSpeed;
    public float MaxPitch;
    public float MinPitch;
    public AnimationCurve curve;
    public float VolumeAmount;
    public float VolumeMod;
    public float AngVel;
    public float AngVel1;
    public float AngVel2;
    public virtual void Start()
    {
        this.Stopped = true;
    }

    public virtual void FixedUpdate()
    {
        if (this.Vessel)
        {
            if ((!this.UseOtherV && !this.UseOtherV2) && this.UseSpecificAxis)
            {
                if (this.Vessel.GetComponent<Rigidbody>().angularVelocity.magnitude > 0.1f)
                {
                    Vector3 localV = this.Vessel.transform.InverseTransformDirection(this.Vessel.GetComponent<Rigidbody>().angularVelocity);
                    if (!this.UseX)
                    {
                        this.AngVel = Mathf.Abs(localV.y);
                    }
                    else
                    {
                        this.AngVel = Mathf.Abs(localV.x);
                    }
                    float p = this.AngVel / this.audioClipSpeed;
                    this.GetComponent<AudioSource>().pitch = Mathf.Clamp(p * 1, this.MinPitch, this.MaxPitch);
                    this.VolumeAmount = this.curve.Evaluate(p) * this.VolumeMod;
                    this.GetComponent<AudioSource>().volume = this.VolumeAmount;
                    if ((this.GetComponent<AudioSource>().volume < 0.05f) && !this.AccurateVolume)
                    {
                        this.GetComponent<AudioSource>().volume = 0.04f;
                    }
                }
                if (!this.Stopped)
                {
                    if (this.GetComponent<AudioSource>().volume < 0.05f)
                    {
                        this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume - 0.005f;
                    }
                }
                if (this.Stopped)
                {
                    if (this.GetComponent<AudioSource>().volume > 0.001f)
                    {
                        this.GetComponent<AudioSource>().Play();
                        this.Stopped = false;
                    }
                }
                if (!this.Stopped)
                {
                    if (this.GetComponent<AudioSource>().volume == 0)
                    {
                        this.GetComponent<AudioSource>().Stop();
                        this.Stopped = true;
                    }
                }
            }
            if (this.UseOtherV2 && this.UseSpecificAxis)
            {
                if ((this.Vessel.GetComponent<Rigidbody>().angularVelocity.magnitude > 0.1f) || (this.OtherV2.GetComponent<Rigidbody>().angularVelocity.magnitude > 0.1f))
                {
                    Vector3 localV1 = this.Vessel.transform.InverseTransformDirection(this.Vessel.GetComponent<Rigidbody>().angularVelocity);
                    Vector3 localV2 = this.OtherV2.transform.InverseTransformDirection(this.OtherV2.GetComponent<Rigidbody>().angularVelocity);
                    if (!this.UseX)
                    {
                        this.AngVel1 = Mathf.Abs(localV1.y);
                        this.AngVel2 = Mathf.Abs(localV2.y);
                    }
                    else
                    {
                        this.AngVel1 = Mathf.Abs(localV1.x);
                        this.AngVel2 = Mathf.Abs(localV2.x);
                    }
                    float AngVel3 = Mathf.Abs(this.AngVel1 + this.AngVel2);
                    float p4 = AngVel3 / this.audioClipSpeed;
                    this.GetComponent<AudioSource>().pitch = Mathf.Clamp(p4 * 1, this.MinPitch, this.MaxPitch);
                    this.VolumeAmount = this.curve.Evaluate(p4) * this.VolumeMod;
                    this.GetComponent<AudioSource>().volume = this.VolumeAmount;
                    if ((this.GetComponent<AudioSource>().volume < 0.05f) && !this.AccurateVolume)
                    {
                        this.GetComponent<AudioSource>().volume = 0.04f;
                    }
                }
                if (!this.Stopped)
                {
                    if (this.GetComponent<AudioSource>().volume < 0.05f)
                    {
                        this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume - 0.005f;
                    }
                }
                if (this.Stopped)
                {
                    if (this.GetComponent<AudioSource>().volume > 0.001f)
                    {
                        this.GetComponent<AudioSource>().Play();
                        this.Stopped = false;
                    }
                }
                if (!this.Stopped)
                {
                    if (this.GetComponent<AudioSource>().volume == 0)
                    {
                        this.GetComponent<AudioSource>().Stop();
                        this.Stopped = true;
                    }
                }
            }
            if ((!this.UseOtherV && !this.UseOtherV2) && !this.UseSpecificAxis)
            {
                if (this.Vessel.GetComponent<Rigidbody>().angularVelocity.magnitude > 0.1f)
                {
                    float p1 = this.Vessel.GetComponent<Rigidbody>().angularVelocity.magnitude / this.audioClipSpeed;
                    this.GetComponent<AudioSource>().pitch = Mathf.Clamp(p1 * 1, this.MinPitch, this.MaxPitch);
                    this.VolumeAmount = this.curve.Evaluate(p1) * this.VolumeMod;
                    this.GetComponent<AudioSource>().volume = this.VolumeAmount;
                    if ((this.GetComponent<AudioSource>().volume < 0.05f) && !this.AccurateVolume)
                    {
                        this.GetComponent<AudioSource>().volume = 0.04f;
                    }
                }
                if (!this.Stopped)
                {
                    if (this.GetComponent<AudioSource>().volume < 0.05f)
                    {
                        this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume - 0.005f;
                    }
                }
                if (this.Stopped)
                {
                    if (this.GetComponent<AudioSource>().volume > 0.001f)
                    {
                        this.GetComponent<AudioSource>().Play();
                        this.Stopped = false;
                    }
                }
                if (!this.Stopped)
                {
                    if (this.GetComponent<AudioSource>().volume == 0)
                    {
                        this.GetComponent<AudioSource>().Stop();
                        this.Stopped = true;
                    }
                }
            }
            if (this.UseOtherV)
            {
                if ((this.OtherV2 && this.OtherV3) && this.OtherV4)
                {
                    if (this.Vessel.GetComponent<Rigidbody>().angularVelocity.magnitude > 0.1f)
                    {
                        float OV = ((this.Vessel.GetComponent<Rigidbody>().angularVelocity.magnitude + this.OtherV2.GetComponent<Rigidbody>().angularVelocity.magnitude) + this.OtherV3.GetComponent<Rigidbody>().angularVelocity.magnitude) + this.OtherV4.GetComponent<Rigidbody>().angularVelocity.magnitude;
                        float p2 = OV / this.audioClipSpeed;
                        this.GetComponent<AudioSource>().pitch = Mathf.Clamp(p2 * 1, this.MinPitch, this.MaxPitch);
                        this.VolumeAmount = this.curve.Evaluate(p2) * this.VolumeMod;
                        this.GetComponent<AudioSource>().volume = this.VolumeAmount;
                    }
                    if (!this.Stopped)
                    {
                        if (this.GetComponent<AudioSource>().volume < 0.05f)
                        {
                            this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume - 0.005f;
                        }
                    }
                    if (this.Stopped)
                    {
                        if (this.GetComponent<AudioSource>().volume > 0.001f)
                        {
                            this.GetComponent<AudioSource>().Play();
                            this.Stopped = false;
                        }
                    }
                    if (!this.Stopped)
                    {
                        if (this.GetComponent<AudioSource>().volume == 0)
                        {
                            this.GetComponent<AudioSource>().Stop();
                            this.Stopped = true;
                        }
                    }
                }
            }
            if (this.UseOtherV2 && !this.UseSpecificAxis)
            {
                if (this.Vessel.GetComponent<Rigidbody>().angularVelocity.magnitude > 0.1f)
                {
                    float OV2 = this.Vessel.GetComponent<Rigidbody>().angularVelocity.magnitude + this.OtherV2.GetComponent<Rigidbody>().angularVelocity.magnitude;
                    float p3 = OV2 / this.audioClipSpeed;
                    this.GetComponent<AudioSource>().pitch = Mathf.Clamp(p3 * 1, this.MinPitch, this.MaxPitch);
                    this.VolumeAmount = this.curve.Evaluate(p3) * this.VolumeMod;
                    this.GetComponent<AudioSource>().volume = this.VolumeAmount;
                }
                if (!this.Stopped)
                {
                    if (this.GetComponent<AudioSource>().volume < 0.05f)
                    {
                        this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume - 0.005f;
                    }
                }
                if (this.Stopped)
                {
                    if (this.GetComponent<AudioSource>().volume > 0.001f)
                    {
                        this.GetComponent<AudioSource>().Play();
                        this.Stopped = false;
                    }
                }
                if (!this.Stopped)
                {
                    if (this.GetComponent<AudioSource>().volume == 0)
                    {
                        this.GetComponent<AudioSource>().Stop();
                        this.Stopped = true;
                    }
                }
            }
        }
    }

    public SpinNoise()
    {
        this.audioClipSpeed = 20f;
        this.MaxPitch = 1f;
        this.curve = new AnimationCurve();
        this.VolumeMod = 1f;
    }

}