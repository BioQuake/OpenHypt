using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PeuknythAI : MonoBehaviour
{
    public GameObject Aimer;
    public Transform vTransform;
    public Rigidbody vRigidbody;
    public float maxVolume;
    public float incrementValue;
    public float decrementValue;
    public SoundObscure theSnoud;
    private string state;
    public float ForwardSpeed;
    public float fuel;
    public bool Eating;
    public bool Flying;
    public virtual void Start()
    {
        this.InvokeRepeating("Metabolize", 1, 0.2f);
        StuffSpawner.TheNPC003N = StuffSpawner.TheNPC003N + 1;
    }

    public virtual void FixedUpdate()
    {
        if (this.vTransform == null)
        {
            UnityEngine.Object.Destroy(this.gameObject);
        }
        else
        {
            this.transform.rotation = this.vTransform.rotation;
            this.transform.position = this.vTransform.position;
        }
        if (this.fuel > 5)
        {
            this.vRigidbody.AddForce(this.vTransform.forward * this.ForwardSpeed);
            this.Aimer.GetComponent<Rigidbody>().freezeRotation = true;
            this.Flying = true;
        }
        else
        {
            this.Flying = false;
        }
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
        if (this.fuel > 100)
        {
            this.fuel = 100;
        }
        if (this.fuel < 1)
        {
            this.Aimer.GetComponent<PeuknythAimer>().target = null;
            this.Aimer.GetComponent<Rigidbody>().freezeRotation = false;
        }
        this.Eating = false;
        this.VicinityCheck();
    }

    public virtual void VicinityCheck()
    {
        GameObject[] gos = null;
        gos = GameObject.FindGameObjectsWithTag("TC");
        foreach (GameObject go in gos)
        {
            string ON = go.name;
            Transform OT = go.transform;
            if (ON.Contains("vibra"))
            {
                if (ON.Contains("ig"))
                {
                    if (Vector3.Distance(this.vTransform.position, OT.position) < 40)
                    {
                        this.Eating = true;
                        this.Aimer.GetComponent<PeuknythAimer>().target = OT;
                    }
                }
                else
                {
                    if (ON.Contains("uge"))
                    {
                        if (Vector3.Distance(this.vTransform.position, OT.position) < 200)
                        {
                            this.Eating = true;
                            this.Aimer.GetComponent<PeuknythAimer>().target = OT;
                        }
                    }
                    else
                    {
                        if (Vector3.Distance(this.vTransform.position, OT.position) < 4)
                        {
                            this.Eating = true;
                            this.Aimer.GetComponent<PeuknythAimer>().target = OT;
                        }
                    }
                }
            }
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
        if (this.theSnoud.Obscured)
        {
            return;
        }
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

    public virtual void Damage()
    {
        StuffSpawner.TheNPC003N = StuffSpawner.TheNPC003N - 1;
    }

    public PeuknythAI()
    {
        this.maxVolume = 1;
        this.incrementValue = 0.05f;
        this.decrementValue = 0.1f;
        this.ForwardSpeed = 1;
    }

}