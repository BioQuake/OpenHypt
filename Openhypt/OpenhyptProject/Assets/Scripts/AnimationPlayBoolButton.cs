using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AnimationPlayBoolButton : MonoBehaviour
{
    public GameObject AniObject;
    public string AniName;
    public string AniName2;
    private bool entered;
    public bool OtherAni;
    public virtual void OnMouseDown()
    {
        if (this.entered)
        {
            if (this.OtherAni == false)
            {
                this.AniObject.GetComponent<Animation>().Play(this.AniName);
                this.OtherAni = true;
            }
            else
            {
                if (this.OtherAni == true)
                {
                    this.AniObject.GetComponent<Animation>().Play(this.AniName2);
                    this.OtherAni = false;
                }
            }
        }
    }

    public virtual void OnMouseEnter()
    {
        this.entered = true;
    }

    public virtual void OnMouseExit()
    {
        this.entered = false;
    }

    public virtual void Close()
    {
        this.AniObject.GetComponent<Animation>().Play(this.AniName2);
        this.OtherAni = false;
    }

}