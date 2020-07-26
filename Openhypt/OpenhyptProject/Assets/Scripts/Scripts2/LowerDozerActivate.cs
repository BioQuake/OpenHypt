using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class LowerDozerActivate : MonoBehaviour
{
    public GameObject LowerDozerAnimationObject;
    public string LowerDozerAnimationName;
    public AudioClip LowerDozerActivateSoundClip;
    public bool LowerReachedEnd;
    public bool LowerCanPlay;
    public virtual void Update()
    {
        if (WorldInformation.playerCar.Contains(this.transform.parent.parent.name))
        {
            if (Input.GetKeyDown("4"))
            {
                this.LowerActivate();
            }
        }
    }

    public virtual void LowerActivate()
    {
        if ((this.LowerReachedEnd == false) && (this.LowerCanPlay == true))
        {
            this.LowerDozerAnimationObject.GetComponent<Animation>()[this.LowerDozerAnimationName + ""].speed = 1;
            this.LowerDozerAnimationObject.GetComponent<Animation>().Play(this.LowerDozerAnimationName + "");
        }
        if ((this.LowerReachedEnd == true) && (this.LowerCanPlay == true))
        {
            this.LowerDozerAnimationObject.GetComponent<Animation>()[this.LowerDozerAnimationName + ""].speed = -1;
            this.LowerDozerAnimationObject.GetComponent<Animation>()[this.LowerDozerAnimationName + ""].time = this.LowerDozerAnimationObject.GetComponent<Animation>()[this.LowerDozerAnimationName + ""].length;
            this.LowerDozerAnimationObject.GetComponent<Animation>().Play(this.LowerDozerAnimationName + "");
        }
    }

    public virtual void LowerStopZeAnimation()
    {
        this.LowerReachedEnd = true;
    }

    public virtual void LowerActivateSound()
    {
        this.LowerReachedEnd = false;
        this.GetComponent<AudioSource>().PlayOneShot(this.LowerDozerActivateSoundClip);
    }

    public virtual void LowerLockPlay()
    {
        this.LowerCanPlay = false;
    }

    public virtual void LowerUnLockPlay()
    {
        this.LowerCanPlay = true;
    }

    public LowerDozerActivate()
    {
        this.LowerDozerAnimationName = "Name";
        this.LowerCanPlay = true;
    }

}