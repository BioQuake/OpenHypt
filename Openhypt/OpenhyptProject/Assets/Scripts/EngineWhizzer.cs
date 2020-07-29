using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class EngineWhizzer : MonoBehaviour
{
    public float WhizzSpeed;
    public float audioClipSpeed;
    public float MaxVolume;
    public float MinPitch;
    public float incrementValue;
    public float decrementValue;
    private int lastspeed;
    private string state;
    public bool RunningF;
    public bool RunningR;
    public virtual void Update()
    {
        if (WorldInformation.playerCar == this.transform.parent.name)
        {
            if (CameraScript.InInterface == false)
            {
                if (Input.GetKeyDown("w"))
                {
                    this.RunningF = true;
                }
                if (Input.GetKeyUp("w"))
                {
                    this.RunningF = false;
                }
                if (Input.GetKeyDown("s"))
                {
                    this.RunningR = true;
                }
                if (Input.GetKeyUp("s"))
                {
                    this.RunningR = false;
                }
            }
        }
    }

    public virtual void FixedUpdate()
    {
        float p = this.GetComponent<Rigidbody>().angularVelocity.magnitude / this.audioClipSpeed;
        this.GetComponent<AudioSource>().pitch = Mathf.Clamp(p * 1, this.MinPitch, 2f);
        this.lastspeed = (int) this.GetComponent<Rigidbody>().angularVelocity.magnitude;
        if (this.RunningF || this.RunningR)
        {
            this.GetComponent<Rigidbody>().AddTorque(this.transform.up * this.WhizzSpeed);
        }
        if (this.RunningF || this.RunningR)
        {
            this.state = "increment";
        }
        if (!this.RunningF && !this.RunningR)
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
        if (this.GetComponent<AudioSource>().volume < this.MaxVolume)
        {
            this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume + this.incrementValue;
        }
        else
        {
            this.state = "";
        }
    }

    public EngineWhizzer()
    {
        this.WhizzSpeed = 100;
        this.audioClipSpeed = 20f;
        this.MaxVolume = 0.2f;
        this.incrementValue = 0.05f;
        this.decrementValue = 0.02f;
        this.lastspeed = 1;
    }

}