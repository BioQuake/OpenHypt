using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class UpdateSceneScript : MonoBehaviour
{
    public Animation UpdateAni;
    public Camera UpdateCam;
    public GameObject Background1;
    public GameObject Background2;
    public AudioListener AL1;
    public AudioListener AL2;
    public bool ALFade;
    public AudioSource SFX1;
    public AudioSource SFX2;
    public bool SFX2VolDown;
    public AudioSource SFX3;
    public ParticleSystem FX1;
    public ParticleSystem FX2;
    public int uNum;
    public virtual void Start()
    {
        this.UpdateCam.enabled = false;
        this.SFX2VolDown = false;
        this.SFX2.volume = 1;
    }

    public virtual void Update()
    {
        if (this.uNum > 0)
        {
            this.uNum = this.uNum - 1;
        }
        if (Input.GetKeyDown("u"))
        {
            if (Input.GetKey("t"))
            {
                if (this.Background1.activeSelf)
                {
                    this.UpdateCam.enabled = true;
                    this.Background1.SetActive(false);
                    this.Background2.SetActive(true);
                }
                else
                {
                    this.UpdateCam.enabled = false;
                    this.Background1.SetActive(true);
                    this.Background2.SetActive(false);
                }
            }
            if (this.uNum > 1)
            {
                this.UpdateAni.Play();
                this.UpdateCam.enabled = true;
                this.AL1.enabled = false;
                this.AL2.enabled = true;
                this.SFX2VolDown = false;
                this.SFX2.volume = 1;
            }
            this.uNum = 10;
        }
        if (this.SFX2VolDown)
        {
            if (this.SFX2.volume > 0.1f)
            {
                this.SFX2.volume = this.SFX2.volume - 0.1f;
            }
            else
            {
                this.SFX2.volume = this.SFX2.volume - 0.01f;
            }
        }
    }

    public virtual void SFX1Start()
    {
        this.SFX1.Play();
    }

    public virtual void SFX2Start()
    {
        this.SFX2.Play();
    }

    public virtual void SFX2Cutoff()
    {
        this.SFX2VolDown = true;
    }

    public virtual void SFX3Start()
    {
        this.SFX3.Play();
    }

    public virtual void FX1Start()
    {
        this.FX1.Play();
    }

    public virtual void FX2Start()
    {
        this.FX2.Play();
    }

    public virtual void ALSwitch()
    {
        this.AL2.enabled = false;
        this.AL1.enabled = true;
    }

    public virtual void Camdisable()
    {
        this.UpdateCam.enabled = false;
        this.SFX2VolDown = false;
    }

}