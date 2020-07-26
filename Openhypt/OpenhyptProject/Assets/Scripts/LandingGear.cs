using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class LandingGear : MonoBehaviour
{
    public GameObject AnimationObject;
    public string AnimationName;
    public bool ReachedEnd;
    public bool CanPlay;
    public virtual void Update()
    {
        if (WorldInformation.playerCar == this.gameObject.name)
        {
            if (Input.GetKey("g"))
            {
                this.Activate();
            }
        }
    }

    public virtual void Activate()
    {
        if ((this.ReachedEnd == false) && (this.CanPlay == true))
        {
            this.AnimationObject.GetComponent<Animation>()[this.AnimationName + ""].speed = 1;
            this.AnimationObject.GetComponent<Animation>().Play(this.AnimationName + "");
        }
        if ((this.ReachedEnd == true) && (this.CanPlay == true))
        {
            this.AnimationObject.GetComponent<Animation>()[this.AnimationName + ""].speed = -1;
            this.AnimationObject.GetComponent<Animation>()[this.AnimationName + ""].time = this.AnimationObject.GetComponent<Animation>()[this.AnimationName + ""].length;
            this.AnimationObject.GetComponent<Animation>().Play(this.AnimationName + "");
        }
    }

    public virtual void StopZeAnimation()
    {
        this.ReachedEnd = true;
    }

    public virtual void StartZeAnimation()
    {
        this.ReachedEnd = false;
    }

    public virtual void LockPlay()
    {
        this.CanPlay = false;
    }

    public virtual void UnLockPlay()
    {
        this.CanPlay = true;
    }

    public LandingGear()
    {
        this.AnimationName = "Name";
        this.CanPlay = true;
    }

}