using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PeuknyilAI : MonoBehaviour
{
    public GameObject Aimer;
    public GameObject Hoverer;
    public GameObject Thruster;
    public GameObject Nudger;
    public GameObject Blasteffect1;
    public GameObject Blasteffect2;
    public GameObject Blasteffect3;
    public GameObject Blasteffect4;
    public GameObject Blasteffect5;
    public GameObject Blasteffect6;
    public GameObject HowlSound;
    public GameObject HowlSoundFar;
    public GameObject AirSound;
    public GameObject BlasterSound;
    public GameObject Presence;
    public float maxVolume;
    private float AirincrementValue;
    private float HowlfarincrementValue;
    private float incrementValue;
    private float AirdecrementValue;
    private float HowlfardecrementValue;
    private float decrementValue;
    public string state;
    public string state2;
    public float ForwardSpeed;
    public float fuel;
    public bool Eating;
    public bool Flying;
    public virtual void Start()
    {
        this.InvokeRepeating("Metabolize", 1, 0.2f);
        StuffSpawner.TheNPC004N = StuffSpawner.TheNPC004N + 1;
    }

    public virtual void Metabolize()
    {
        if (this.Eating)
        {
            this.fuel = this.fuel + 2;
        }
        if (this.Flying)
        {
            this.fuel = this.fuel - 1;
        }
        if (this.fuel > 0)
        {
            this.fuel = this.fuel - 0.4f;
        }
        if (this.fuel > 200)
        {
            this.fuel = 200;
        }
        if (this.fuel < 1)
        {
            this.Presence.SetActive(false);
            this.Aimer.GetComponent<PeuknythAimer>().target = null;
            this.Aimer.GetComponent<Rigidbody>().freezeRotation = false;
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("svibra"))
        {
            this.Eating = true;
            this.Aimer.GetComponent<PeuknythAimer>().target = other.gameObject.transform;
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("svibra"))
        {
            this.Eating = false;
        }
    }

    public virtual void Update()
    {
        if (this.Flying == true)
        {
            this.state = "increment";
        }
        if (this.Flying == false)
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
        if (this.Eating == true)
        {
            this.state2 = "increment2";
        }
        if (this.Eating == false)
        {
            this.state2 = "decrement2";
        }
        if (this.state2 == "increment2")
        {
            this.increment2();
        }
        else
        {
            if (this.state2 == "decrement2")
            {
                this.decrement2();
            }
        }
    }

    public virtual void FixedUpdate()
    {
        if (this.fuel > 30)
        {
            this.Hoverer.SetActive(true);
            this.Nudger.SetActive(true);
            this.Thruster.SetActive(true);
            this.Blasteffect1.GetComponent<ParticleSystem>().enableEmission = true;
            this.Blasteffect2.GetComponent<ParticleSystem>().enableEmission = true;
            this.Blasteffect3.GetComponent<ParticleSystem>().enableEmission = true;
            this.Blasteffect4.GetComponent<ParticleSystem>().enableEmission = true;
            this.Blasteffect5.GetComponent<ParticleSystem>().enableEmission = true;
            this.Blasteffect6.GetComponent<ParticleSystem>().enableEmission = true;
            this.Aimer.GetComponent<Rigidbody>().freezeRotation = true;
            this.Flying = true;
        }
        else
        {
            this.Flying = false;
            this.Hoverer.SetActive(false);
            this.Nudger.SetActive(false);
            this.Thruster.SetActive(false);
            this.Blasteffect1.GetComponent<ParticleSystem>().enableEmission = false;
            this.Blasteffect2.GetComponent<ParticleSystem>().enableEmission = false;
            this.Blasteffect3.GetComponent<ParticleSystem>().enableEmission = false;
            this.Blasteffect4.GetComponent<ParticleSystem>().enableEmission = false;
            this.Blasteffect5.GetComponent<ParticleSystem>().enableEmission = false;
            this.Blasteffect6.GetComponent<ParticleSystem>().enableEmission = false;
        }
    }

    public virtual void decrement()
    {
        if (this.HowlSoundFar.GetComponent<AudioSource>().volume > 0)
        {
            this.HowlSound.GetComponent<AudioSource>().volume = this.HowlSound.GetComponent<AudioSource>().volume - this.decrementValue;
            this.HowlSoundFar.GetComponent<AudioSource>().volume = this.HowlSoundFar.GetComponent<AudioSource>().volume - this.HowlfardecrementValue;
            this.BlasterSound.GetComponent<AudioSource>().volume = this.BlasterSound.GetComponent<AudioSource>().volume - this.decrementValue;
        }
        else
        {
            this.state = "";
        }
    }

    public virtual void increment()
    {
        if (this.HowlSoundFar.GetComponent<AudioSource>().volume < this.maxVolume)
        {
            this.HowlSound.GetComponent<AudioSource>().volume = this.HowlSound.GetComponent<AudioSource>().volume + this.incrementValue;
            this.HowlSoundFar.GetComponent<AudioSource>().volume = this.HowlSoundFar.GetComponent<AudioSource>().volume + this.HowlfarincrementValue;
            this.BlasterSound.GetComponent<AudioSource>().volume = this.BlasterSound.GetComponent<AudioSource>().volume + this.incrementValue;
        }
        else
        {
            this.state = "";
        }
    }

    public virtual void decrement2()
    {
        if (this.AirSound.GetComponent<AudioSource>().volume > 0)
        {
            this.AirSound.GetComponent<AudioSource>().volume = this.AirSound.GetComponent<AudioSource>().volume - this.AirdecrementValue;
        }
        else
        {
            this.state2 = "";
        }
    }

    public virtual void increment2()
    {
        if (this.AirSound.GetComponent<AudioSource>().volume < this.maxVolume)
        {
            this.AirSound.GetComponent<AudioSource>().volume = this.AirSound.GetComponent<AudioSource>().volume + this.AirincrementValue;
        }
        else
        {
            this.state2 = "";
        }
    }

    public virtual void Damage()
    {
        StuffSpawner.TheNPC004N = StuffSpawner.TheNPC004N + 1;
    }

    public PeuknyilAI()
    {
        this.maxVolume = 1;
        this.AirincrementValue = 0.005f;
        this.HowlfarincrementValue = 0.005f;
        this.incrementValue = 0.05f;
        this.AirdecrementValue = 0.008f;
        this.HowlfardecrementValue = 0.005f;
        this.decrementValue = 0.05f;
        this.ForwardSpeed = 1;
    }

}