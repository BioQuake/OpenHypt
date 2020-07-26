using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ContactDuster : MonoBehaviour
{
    public LayerMask targetLayers;
    public GameObject VelSource;
    public bool Beige;
    public bool Pale;
    public bool Contact;
    public float ContactDist;
    public float MagnitudeValue;
    public float EmissionRate;
    public float xValue;
    public float speed;
    public bool Stop;
    public virtual void Start()
    {
        if (this.Pale && (WorldInformation.instance.AreaBeige == true))
        {
            UnityEngine.Object.Destroy(this.gameObject);
        }
        if (this.Beige && (WorldInformation.instance.AreaGray == true))
        {
            UnityEngine.Object.Destroy(this.gameObject);
        }
        if (WorldInformation.instance.AreaDark == true)
        {
            UnityEngine.Object.Destroy(this.gameObject);
        }
        this.GetComponent<ParticleSystem>().emissionRate = 0;
    }

    public virtual void Update()
    {
        if (!this.Stop)
        {
            if (this.VelSource)
            {
                this.xValue = this.VelSource.GetComponent<Rigidbody>().velocity.magnitude / this.MagnitudeValue;
            }
            else
            {
                this.xValue = 0;
            }
            this.speed = this.xValue;
            if (Physics.Raycast(this.transform.position + new Vector3(0, 1, 0), this.transform.up, this.ContactDist, (int) this.targetLayers))
            {
                this.Contact = true;
            }
            else
            {
                this.Contact = false;
            }
            if (this.speed > 0.3f)
            {
                if ((this.GetComponent<ParticleSystem>().emissionRate < this.EmissionRate) && (this.Contact == true))
                {
                    this.GetComponent<ParticleSystem>().emissionRate = this.GetComponent<ParticleSystem>().emissionRate + 5;
                }
            }
            if (this.speed > 0.1f)
            {
                if ((this.GetComponent<ParticleSystem>().emissionRate < this.EmissionRate) && (this.Contact == true))
                {
                    this.GetComponent<ParticleSystem>().emissionRate = this.GetComponent<ParticleSystem>().emissionRate + 1;
                }
            }
            if (this.speed < 0.1f)
            {
                this.GetComponent<ParticleSystem>().emissionRate = this.GetComponent<ParticleSystem>().emissionRate - 5;
            }
            if (this.Contact == false)
            {
                this.GetComponent<ParticleSystem>().emissionRate = this.GetComponent<ParticleSystem>().emissionRate - 20;
            }
            if (this.GetComponent<ParticleSystem>().emissionRate < 0)
            {
                this.GetComponent<ParticleSystem>().emissionRate = 0;
            }
        }
        else
        {
            this.GetComponent<ParticleSystem>().emissionRate = 0;
        }
    }

    public ContactDuster()
    {
        this.ContactDist = 2;
        this.MagnitudeValue = 30;
        this.EmissionRate = 100;
    }

}