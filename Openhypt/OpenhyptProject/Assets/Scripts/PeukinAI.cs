using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PeukinAI : MonoBehaviour
{
    public GameObject Creature;
    public bool IsPeuktato;
    public bool IsPeuktorb;
    public Transform Target;
    public float Power;
    public float Torque;
    public float Spin;
    public Upnudge upnudge;
    public string AttractedTo;
    public int NoticeRadius;
    public bool UseOutOfBounds;
    public int OutOfBounds;
    public Transform FromWhat;
    public bool Tick;
    public virtual void Start()
    {
        this.InvokeRepeating("Regenerator", 1, 0.2f);
        if (this.IsPeuktato)
        {
            StuffSpawner.TheNPC000N = StuffSpawner.TheNPC000N + 1;
        }
        if (this.IsPeuktorb)
        {
            StuffSpawner.TheNPC001N = StuffSpawner.TheNPC001N + 1;
        }
    }

    public virtual void FixedUpdate()
    {
        this.StartCoroutine(this.Notice());
        if (this.Spin > 0)
        {
            this.Creature.GetComponent<Rigidbody>().AddTorque(this.transform.up * this.Spin);
        }
        else
        {
            this.Creature.GetComponent<Rigidbody>().AddTorque(this.transform.up * Random.Range(-this.Torque, this.Torque));
        }
        this.Creature.GetComponent<Rigidbody>().AddTorque(this.transform.right * Random.Range(-this.Torque, this.Torque));
        this.Creature.GetComponent<Rigidbody>().AddTorque(this.transform.forward * Random.Range(-this.Torque, this.Torque));
        if (this.Target != null)
        {
            this.Creature.GetComponent<Rigidbody>().AddForce((this.Target.transform.position - this.Creature.transform.position).normalized * this.Power);
        }
        else
        {
            this.Creature.GetComponent<Rigidbody>().AddForce(this.transform.up * this.Power);
        }
        if (this.UseOutOfBounds)
        {
            if (this.FromWhat)
            {
                if (Vector3.Distance(this.transform.position, WorldInformation.instance.transform.position) > this.OutOfBounds)
                {
                    this.Creature.GetComponent<Rigidbody>().AddForce((this.FromWhat.position - this.Creature.transform.position).normalized * this.Power);
                }
            }
        }
    }

    public virtual IEnumerator Notice()
    {
        if (this.Tick)
        {
            yield break;
        }
        this.Tick = true;
        yield return new WaitForSeconds(0.8f);
        this.Target = null;
        ((SphereCollider) this.gameObject.GetComponent(typeof(SphereCollider))).radius = this.NoticeRadius;
        yield return new WaitForSeconds(0.2f);
        ((SphereCollider) this.gameObject.GetComponent(typeof(SphereCollider))).radius = 0.01f;
        this.Tick = false;
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Collider>().name.Contains(this.AttractedTo))
        {
            this.Target = other.gameObject.transform;
        }
    }

    public virtual void Regenerator()
    {
        if (this.IsPeuktato)
        {
            if (this.upnudge.isTouching)
            {
                this.upnudge.nudge = true;
            }
        }
    }

    public virtual void decrement()
    {
        if (this.GetComponent<AudioSource>().volume > 0.2f)
        {
            this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume - 0.004f;
        }
        if (this.GetComponent<AudioSource>().pitch > 0.6f)
        {
            this.GetComponent<AudioSource>().pitch = this.GetComponent<AudioSource>().pitch - 0.002f;
        }
    }

    public virtual void increment()
    {
        if (this.GetComponent<AudioSource>().volume < 0.5f)
        {
            this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume + 0.01f;
        }
        if (this.GetComponent<AudioSource>().pitch < 0.8f)
        {
            this.GetComponent<AudioSource>().pitch = this.GetComponent<AudioSource>().pitch + 0.01f;
        }
    }

    public virtual void Damage()
    {
        if (this.IsPeuktato)
        {
            StuffSpawner.TheNPC000N = StuffSpawner.TheNPC000N - 1;
        }
        if (this.IsPeuktorb)
        {
            StuffSpawner.TheNPC001N = StuffSpawner.TheNPC001N - 1;
        }
    }

    public PeukinAI()
    {
        this.Power = 0.01f;
        this.Torque = 0.01f;
        this.AttractedTo = "HeatSource";
        this.NoticeRadius = 200;
        this.OutOfBounds = 5000;
    }

}