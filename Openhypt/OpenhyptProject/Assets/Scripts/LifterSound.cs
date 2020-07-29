using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class LifterSound : MonoBehaviour
{
    public float maxVolume;
    public float HoverMaxVolume;
    public float incrementValue;
    public float decrementValue;
    public bool Hover;
    public string state;
    public virtual void FixedUpdate()
    {
        if (WorldInformation.playerCar != this.transform.parent.name)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.PageUp))
        {
            this.state = "increment";
        }
        if (Input.GetKeyUp(KeyCode.PageUp))
        {
            this.state = "decrement";
        }
        if (Input.GetKeyDown(KeyCode.PageDown))
        {
            if (this.Hover == false)
            {
                this.Hover = true;
                this.state = "Hovincrement";
            }
            else
            {
                this.Hover = false;
                this.state = "decrement";
            }
        }
        if (this.state == "Hovincrement")
        {
            this.Hovincrement();
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
        if (this.Hover == true)
        {
            this.GetComponent<AudioSource>().volume = this.HoverMaxVolume;
        }
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

    public virtual void Hovincrement()
    {
        if (!this.GetComponent<AudioSource>().isPlaying)
        {
            this.GetComponent<AudioSource>().Play();
        }
        if (this.GetComponent<AudioSource>().volume < this.HoverMaxVolume)
        {
            this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume + this.incrementValue;
        }
        else
        {
            this.state = "";
        }
    }

    public LifterSound()
    {
        this.maxVolume = 1;
        this.HoverMaxVolume = 1;
        this.incrementValue = 0.05f;
        this.decrementValue = 0.1f;
    }

}