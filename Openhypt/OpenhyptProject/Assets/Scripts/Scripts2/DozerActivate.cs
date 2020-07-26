using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class DozerActivate : MonoBehaviour
{
    public static bool Dozervub;
    public GameObject DozerAnimationObject;
    public string DozerAnimationName;
    public AudioClip DozerActivateSoundClip;
    public AudioClip DozerMidSoundClip;
    public AudioClip DozerLateSoundClip;
    public GameObject DozerGameobject;
    public GameObject Ship;
    public bool ReachedEnd;
    public bool CanPlay;
    public virtual void Update()
    {
        if (WorldInformation.playerCar.Contains(this.transform.parent.parent.name))
        {
            if (Input.GetKeyDown("4"))
            {
                this.Activate();
            }
        }
    }

    public virtual void Activate()
    {
        if ((this.ReachedEnd == false) && (this.CanPlay == true))
        {
            this.DozerAnimationObject.GetComponent<Animation>()[this.DozerAnimationName + ""].speed = 1;
            this.DozerAnimationObject.GetComponent<Animation>().Play(this.DozerAnimationName + "");
        }
        if ((this.ReachedEnd == true) && (this.CanPlay == true))
        {
            this.DozerAnimationObject.GetComponent<Animation>()[this.DozerAnimationName + ""].speed = -1;
            this.DozerAnimationObject.GetComponent<Animation>()[this.DozerAnimationName + ""].time = this.DozerAnimationObject.GetComponent<Animation>()[this.DozerAnimationName + ""].length;
            this.DozerAnimationObject.GetComponent<Animation>().Play(this.DozerAnimationName + "");
        }
    }

    public virtual void StopZeAnimation()
    {
        this.ReachedEnd = true;
    }

    public virtual void ActivateSound()
    {
        this.ReachedEnd = false;
        this.GetComponent<AudioSource>().PlayOneShot(this.DozerActivateSoundClip);
    }

    public virtual void MotorSound()
    {
        if (this.ReachedEnd == false)
        {
            this.GetComponent<AudioSource>().PlayOneShot(this.DozerMidSoundClip);
        }
    }

    public virtual void MotorEndSound()
    {
        if (this.ReachedEnd == true)
        {
            this.GetComponent<AudioSource>().PlayOneShot(this.DozerMidSoundClip);
        }
    }

    public virtual void LateSound()
    {
        this.GetComponent<AudioSource>().PlayOneShot(this.DozerLateSoundClip);
    }

    public virtual void LockPlay()
    {
        this.CanPlay = false;
    }

    public virtual void UnLockPlay()
    {
        this.CanPlay = true;
    }

    public virtual void DozerActive()
    {
        DozerActivate.Dozervub = true;
        this.DozerGameobject.gameObject.SetActive(true);
    }

    public virtual void DozerInActive()
    {
        DozerActivate.Dozervub = false;
        this.DozerGameobject.gameObject.SetActive(false);
    }

    public DozerActivate()
    {
        this.DozerAnimationName = "Name";
        this.CanPlay = true;
    }

}