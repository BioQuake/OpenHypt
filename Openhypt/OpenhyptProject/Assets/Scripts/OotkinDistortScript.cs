using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class OotkinDistortScript : MonoBehaviour
{
    public Rigidbody PhysCam;
    public GameObject Distort1;
    public GameObject Distort2;
    public GameObject Distort3;
    public GameObject Distort4;
    public GameObject DistortPoint;
    public AudioSource StaticAudio;
    public AudioSource ShockAudio;
    public AudioSource SicknessAudio;
    public GameObject OotkinBlotches;
    public GameObject OotkinSickness;
    public static bool ContactingOotkin;
    public static bool TouchingOotkin;
    public bool CanShock;
    public float CamDistortPower;
    public bool Ending;
    public virtual void Start()
    {
        this.InvokeRepeating("ResetTouch", 0.1f, 0.7f);
        WorldInformation.IsOotkinSick = false;
        OotkinDistortScript.ContactingOotkin = false;
        OotkinDistortScript.TouchingOotkin = false;
    }

    public virtual void FixedUpdate()
    {
        if ((OotkinDistortScript.TouchingOotkin && (this.Distort1.GetComponent<ParticleSystem>().emissionRate > 500)) && this.CanShock)
        {
            GameObject TheThing = UnityEngine.Object.Instantiate(this.OotkinBlotches, this.DistortPoint.transform.position, this.DistortPoint.transform.rotation);
            TheThing.transform.parent = this.DistortPoint.transform;
            if (WorldInformation.IsOotkinSick)
            {
                LoadPiriLocation.CallingAmbulance = true;
            }
            if (!WorldInformation.IsOotkinSick)
            {
                WorldInformation.IsOotkinSick = true;
                GameObject TheThing2 = UnityEngine.Object.Instantiate(this.OotkinSickness, this.DistortPoint.transform.position, this.DistortPoint.transform.rotation);
                TheThing2.transform.parent = this.DistortPoint.transform;
                this.SicknessAudio.Play();
                this.StartCoroutine(this.OotkinSick());
            }
            this.DistortPoint.GetComponent<ParticleSystem>().emissionRate = 200;
            this.CamDistortPower = 100;
            this.ShockAudio.Play();
            OotkinDistortScript.TouchingOotkin = false;
            this.CanShock = false;
            this.StartCoroutine(this.ResetShock());
        }
        if (this.CamDistortPower > 0)
        {
            this.PhysCam.AddTorque(this.transform.up * Random.Range(-this.CamDistortPower, this.CamDistortPower));
            this.PhysCam.AddTorque(this.transform.right * Random.Range(-this.CamDistortPower, this.CamDistortPower));
            this.PhysCam.AddTorque(this.transform.forward * Random.Range(-this.CamDistortPower, this.CamDistortPower));
            this.PhysCam.freezeRotation = false;
        }
        else
        {
            this.PhysCam.freezeRotation = true;
        }
        this.DistortPoint.GetComponent<ParticleSystem>().emissionRate = this.DistortPoint.GetComponent<ParticleSystem>().emissionRate - 10;
        if (OotkinDistortScript.ContactingOotkin)
        {
            if (this.StaticAudio.volume == 0)
            {
                this.StaticAudio.Play();
            }
            this.StaticAudio.volume = this.StaticAudio.volume + 0.005f;
            if (this.CamDistortPower < 0.005f)
            {
                this.CamDistortPower = this.CamDistortPower + 2E-06f;
            }
            if (this.Distort1.GetComponent<ParticleSystem>().emissionRate < 1000)
            {
                this.Distort1.GetComponent<ParticleSystem>().emissionRate = this.Distort1.GetComponent<ParticleSystem>().emissionRate + 1;
            }
            if (this.Distort2.GetComponent<ParticleSystem>().emissionRate < 40)
            {
                this.Distort2.GetComponent<ParticleSystem>().emissionRate = this.Distort2.GetComponent<ParticleSystem>().emissionRate + 0.5f;
                this.Distort3.GetComponent<ParticleSystem>().emissionRate = this.Distort3.GetComponent<ParticleSystem>().emissionRate + 0.5f;
                this.Distort4.GetComponent<ParticleSystem>().emissionRate = this.Distort4.GetComponent<ParticleSystem>().emissionRate + 0.5f;
            }
        }
        if (!OotkinDistortScript.ContactingOotkin)
        {
            this.StaticAudio.volume = this.StaticAudio.volume - 0.005f;
            if (this.StaticAudio.volume == 0)
            {
                this.StaticAudio.Stop();
            }
            if (this.CamDistortPower > 0)
            {
                this.CamDistortPower = this.CamDistortPower - 3E-06f;
            }
            if (this.Distort1.GetComponent<ParticleSystem>().emissionRate > 0)
            {
                this.Distort1.GetComponent<ParticleSystem>().emissionRate = this.Distort1.GetComponent<ParticleSystem>().emissionRate - 0.5f;
            }
            if (this.Distort2.GetComponent<ParticleSystem>().emissionRate > 0)
            {
                this.Distort2.GetComponent<ParticleSystem>().emissionRate = this.Distort2.GetComponent<ParticleSystem>().emissionRate - 1;
                this.Distort3.GetComponent<ParticleSystem>().emissionRate = this.Distort3.GetComponent<ParticleSystem>().emissionRate - 1;
                this.Distort4.GetComponent<ParticleSystem>().emissionRate = this.Distort4.GetComponent<ParticleSystem>().emissionRate - 1;
            }
        }
        if (WorldInformation.IsOotkinSick)
        {
            if (!this.Ending)
            {
                if (this.SicknessAudio.volume < 0.5f)
                {
                    this.SicknessAudio.volume = this.SicknessAudio.volume + 0.001f;
                }
            }
            else
            {
                this.SicknessAudio.volume = this.SicknessAudio.volume - 0.0002f;
                if (this.SicknessAudio.volume == 0)
                {
                    this.SicknessAudio.Stop();
                }
            }
        }
    }

    public virtual void ResetTouch()
    {
        OotkinDistortScript.TouchingOotkin = false;
    }

    public virtual IEnumerator ResetShock()
    {
        yield return new WaitForSeconds(0.3f);
        this.CamDistortPower = 0.004f;
        yield return new WaitForSeconds(3);
        this.CanShock = true;
    }

    public virtual IEnumerator OotkinSick()
    {
        this.Ending = false;
        yield return new WaitForSeconds(120);
        this.Ending = true;
    }

    public OotkinDistortScript()
    {
        this.CanShock = true;
    }

}