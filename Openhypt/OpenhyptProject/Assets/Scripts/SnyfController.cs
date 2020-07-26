using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SnyfController : MonoBehaviour
{
    public Transform Target;
    public int Lost;
    public float forwardSpeed;
    public bool Handheld;
    public bool Snyfped;
    public float StabForce;
    public float AimForce;
    public float ContactDistance;
    public float LeastTime;
    public float MostTime;
    public float Lengthrandomizer;
    public float lastTime;
    public AudioClip[] soundsies;
    public virtual void PlayClipAndChange()
    {
        this.GetComponent<AudioSource>().clip = this.soundsies[Random.Range(0, this.soundsies.Length)];
        this.GetComponent<AudioSource>().pitch = Random.Range(1, 1.3f);
        this.GetComponent<AudioSource>().Play();
    }

    public virtual void Update()
    {
        if (!this.Handheld)
        {
            if (this.Lost == 50)
            {
                UnityEngine.Object.Destroy(this.gameObject);
            }
            if (this.Snyfped)
            {
                Vector3 relative = this.transform.InverseTransformDirection(this.GetComponent<Rigidbody>().velocity);
                this.GetComponent<Animation>()["SnyfpedWalk"].speed = relative.z * this.forwardSpeed;
            }
        }
        if ((Time.time - this.lastTime) > this.Lengthrandomizer)
        {
            if (!this.Handheld)
            {
                if (!this.Snyfped)
                {
                    this.GetComponent<Rigidbody>().AddForce(this.transform.up * Random.Range(-0.02f, 0.02f));
                    this.GetComponent<Rigidbody>().AddForce(this.transform.right * Random.Range(-0.02f, 0.02f));
                    this.GetComponent<Rigidbody>().AddForce(this.transform.forward * Random.Range(-0.02f, 0.02f));
                    if (this.Target == null)
                    {
                        this.Lost = this.Lost + 1;
                    }
                    if (this.Target != null)
                    {
                        this.Lost = 0;
                        if (Vector3.Distance(this.transform.position, this.Target.position) < 60)
                        {
                            this.GetComponent<Rigidbody>().AddForce((this.Target.transform.position - this.transform.position).normalized * 0.04f);
                        }
                        else
                        {
                            this.Target = null;
                        }
                    }
                }
            }
            this.Lengthrandomizer = this.LeastTime + (Random.value * (this.MostTime - 0.2f));
            this.PlayClipAndChange();
            this.lastTime = Time.time;
        }
    }

    public virtual void FixedUpdate()
    {
        if (this.Handheld)
        {
            return;
        }
        if (this.Snyfped)
        {
            if (Physics.Raycast(this.transform.position, Vector3.down, this.ContactDistance))
            {
                this.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.up * this.StabForce, this.transform.up * 1);
                this.GetComponent<Rigidbody>().AddForceAtPosition(-Vector3.up * this.StabForce, -this.transform.up * 1);
                if (this.Target != null)
                {
                    this.GetComponent<Rigidbody>().AddForceAtPosition((this.Target.transform.position - this.transform.position).normalized * this.AimForce, this.transform.forward * 0.2f);
                    this.GetComponent<Rigidbody>().AddForceAtPosition((this.Target.transform.position - this.transform.position).normalized * -this.AimForce, -this.transform.forward * 0.2f);
                }
                this.GetComponent<Rigidbody>().AddTorque(this.transform.up * Random.Range(-0.0002f, 0.0002f));
                if (this.GetComponent<Rigidbody>().velocity.magnitude < 0.5f)
                {
                    this.GetComponent<Rigidbody>().AddForce(this.transform.forward * 0.002f);
                }
            }
        }
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            UnityEngine.Object.Destroy(this.gameObject);
        }
    }

    public SnyfController()
    {
        this.forwardSpeed = 1;
        this.StabForce = 10f;
        this.AimForce = 0.0005f;
        this.ContactDistance = 1;
        this.LeastTime = 0.2f;
        this.MostTime = 1;
        this.Lengthrandomizer = 6f;
    }

}