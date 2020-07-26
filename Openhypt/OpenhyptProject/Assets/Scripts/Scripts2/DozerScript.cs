using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class DozerScript : MonoBehaviour
{
    public float maxVolume;
    private float incrementValue;
    private float decrementValue;
    private string state;
    public GameObject DozerGameobject;
    public bool UseAI;
    public bool IsOn;
    public virtual void Update()
    {
        if (!this.UseAI)
        {
            if (DozerActivate.Dozervub == true)
            {
                this.state = "increment";
            }
            if (DozerActivate.Dozervub == false)
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
        else
        {
            if (this.IsOn)
            {
                this.state = "increment";
                this.DozerGameobject.gameObject.SetActive(true);
            }
            if (!this.IsOn)
            {
                this.state = "decrement";
                this.DozerGameobject.gameObject.SetActive(false);
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

    public DozerScript()
    {
        this.maxVolume = 0.5f;
        this.incrementValue = 0.1f;
        this.decrementValue = 0.1f;
    }

}