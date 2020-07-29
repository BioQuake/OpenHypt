using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ObjectTrigger : MonoBehaviour
{
    public AgrianCarrierAI AI1;
    public AgrianTowerAI AI2;
    public AudioSource audio1;
    public Transform SoundPoint;
    public bool SoundTrigger;
    public bool SoundTriggerBrake;
    public bool STOnce;
    public bool STBOnce;
    public virtual void Start()
    {
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (!this.SoundTrigger && this.AI1)
        {
            if (other.gameObject.GetComponent<Rigidbody>())
            {
                if (other.gameObject.GetComponent<Rigidbody>().mass > 0.1f)
                {
                    this.AI1.Brake = true;
                }
            }
        }
        if (!this.SoundTrigger && this.AI2)
        {
            if (other.gameObject.GetComponent<Rigidbody>())
            {
                if (other.gameObject.GetComponent<Rigidbody>().mass > 0.1f)
                {
                    if (!this.AI2.Gonnatow && !this.AI2.Gonnaput)
                    {
                        this.AI2.Brake = true;
                    }
                }
            }
        }
        if (this.SoundTriggerBrake && !this.STBOnce)
        {
            this.STBOnce = true;
            this.audio1.Play();
        }
        if (this.SoundTrigger && !this.STOnce)
        {
            if (other.name.Contains("TC1"))
            {
                this.STOnce = true;
                this.audio1.Play();
                if (Vector3.Distance(other.transform.position, this.SoundPoint.position) > 50)
                {
                    this.audio1.volume = 1;
                }
                if (Vector3.Distance(other.transform.position, this.SoundPoint.position) > 100)
                {
                    this.audio1.volume = 0.8f;
                }
                if (Vector3.Distance(other.transform.position, this.SoundPoint.position) > 150)
                {
                    this.audio1.volume = 0.6f;
                }
                if (Vector3.Distance(other.transform.position, this.SoundPoint.position) > 200)
                {
                    this.audio1.volume = 0.4f;
                }
                if (Vector3.Distance(other.transform.position, this.SoundPoint.position) > 300)
                {
                    this.audio1.volume = 0.3f;
                }
                if (Vector3.Distance(other.transform.position, this.SoundPoint.position) > 400)
                {
                    this.audio1.volume = 0.2f;
                }
                if (Vector3.Distance(other.transform.position, this.SoundPoint.position) > 600)
                {
                    this.audio1.volume = 0.1f;
                }
            }
        }
    }

}