using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class GroundNoise : MonoBehaviour
{
    public GameObject Vessel;
    public bool Stopped;
    public bool IsPlaying;
    public bool UsePitch;
    public bool Contact;
    public float ContactRange;
    public float audioClipSpeed;
    public float PitchMod;
    public float MaxVolume;
    public float MaxPitch;
    public float Vol;
    private float incrementValue;
    private float decrementValue;
    private string state;
    public virtual IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<AudioSource>().volume = 0;
    }

    public virtual void Update()
    {
        float v = this.Vessel.GetComponent<Rigidbody>().velocity.magnitude / this.audioClipSpeed;
        float p = this.Vessel.GetComponent<Rigidbody>().velocity.magnitude / this.PitchMod;
        if (Physics.Raycast(this.transform.position, this.transform.up, this.ContactRange))
        {
            this.Contact = true;
        }
        else
        {
            this.Contact = false;
        }
        if (this.UsePitch)
        {
            this.GetComponent<AudioSource>().pitch = Mathf.Clamp(p, 0f, this.MaxPitch);
        }
        if (this.Contact == true)
        {
            this.Vol = Mathf.Clamp(v, 0, this.MaxVolume);
        }
        if (this.Contact == true)
        {
            this.state = "increment";
        }
        if (this.Contact == false)
        {
            this.state = "decrement";
        }
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
        if (this.Vessel.GetComponent<Rigidbody>().velocity.magnitude < 0.5f)
        {
            this.GetComponent<AudioSource>().Stop();
            this.Stopped = true;
            this.IsPlaying = false;
        }
        else
        {
            if ((this.Vessel.GetComponent<Rigidbody>().velocity.magnitude > 0.5f) && (this.Stopped == true))
            {
                this.GetComponent<AudioSource>().Play();
                this.Stopped = false;
                this.IsPlaying = true;
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
            this.GetComponent<AudioSource>().volume = 0;
            this.state = "";
        }
    }

    public virtual void increment()
    {
        if (this.GetComponent<AudioSource>().volume < this.Vol)
        {
            this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume + this.incrementValue;
        }
        else
        {
            this.GetComponent<AudioSource>().volume = this.Vol;
            this.state = "";
        }
    }

    public GroundNoise()
    {
        this.ContactRange = 1;
        this.audioClipSpeed = 20f;
        this.PitchMod = 60f;
        this.MaxVolume = 0.2f;
        this.MaxPitch = 1;
        this.incrementValue = 0.05f;
        this.decrementValue = 0.05f;
    }

}