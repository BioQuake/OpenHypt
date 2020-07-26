using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ForceFieldGenerator : MonoBehaviour
{
    public GameObject ForceField;
    public SphereCollider ForceCol;
    public bool IsRunning;
    public float maxVolume;
    public bool entered;
    private string state;
    public virtual void Start()
    {
        this.ForceCol.radius = 0.001f;
        this.ForceCol.center = new Vector3(0, 0, -0.5f);
        //this.ForceField.GetComponent<PlanetaryGravityWellFixed>().enabled = false;
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("FPCnose"))
        {
            this.entered = true;
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("FPCnose"))
        {
            this.entered = false;
        }
    }

    public virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if ((this.entered == true) && (this.IsRunning == false))
            {
                this.IsRunning = true;
                this.ForceCol.radius = 0.5f;
                this.ForceCol.center = new Vector3(0, 0, 0);
                //this.ForceField.GetComponent<PlanetaryGravityWellFixed>().enabled = true;
            }
            else
            {
                if ((this.entered == true) && (this.IsRunning == true))
                {
                    this.IsRunning = false;
                    this.ForceCol.radius = 0.001f;
                    this.ForceCol.center = new Vector3(0, 0, -0.5f);
                    //this.ForceField.GetComponent<PlanetaryGravityWellFixed>().enabled = false;
                }
            }
        }
        if (this.IsRunning == true)
        {
            this.state = "increment";
        }
        if (this.IsRunning == false)
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
            this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume - 0.05f;
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
            this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume + 0.05f;
        }
        else
        {
            this.state = "";
        }
    }

    public ForceFieldGenerator()
    {
        this.maxVolume = 0.3f;
    }

}