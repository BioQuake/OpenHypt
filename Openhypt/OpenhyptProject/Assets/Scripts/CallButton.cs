using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class CallButton : MonoBehaviour
{
    public AudioClip CallOn;
    public AudioClip CallOff;
    public AudioClip CallError;
    public AudioClip CallLockedOn;
    public AudioClip CallLockedOff;
    public AudioSource CallSource;
    public GameObject CallMenu;
    public TextMesh targetTXT;
    public static string LockedName;
    public static bool CallingOther;
    public static bool CallingOther2;
    public static bool CallingOther0;
    public static bool CallingLock1;
    public static bool CallingLock0;
    private bool entered;
    public virtual void Update()
    {
        if (this.entered && Input.GetMouseButtonDown(0))
        {
            this.CallMenu.gameObject.SetActive(true);
        }
        if (!this.entered && Input.GetMouseButtonUp(0))
        {
            this.CallMenu.gameObject.SetActive(false);
        }
        if (CallButton.CallingOther)
        {
            CallButton.CallingOther = false;
            this.CallSound();
        }
        if (CallButton.CallingOther2)
        {
            CallButton.CallingOther2 = false;
            this.CallSound2();
        }
        if (CallButton.CallingOther0)
        {
            CallButton.CallingOther0 = false;
            this.CallSound0();
        }
        if (CallButton.CallingLock1)
        {
            CallButton.CallingLock1 = false;
            this.CallSound3();
        }
        if (CallButton.CallingLock0)
        {
            CallButton.CallingLock0 = false;
            this.CallSound4();
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

    public virtual void CallSound()
    {
        this.CallSource.clip = this.CallOn;
        this.CallSource.Play();
    }

    public virtual void CallSound2()
    {
        this.CallSource.clip = this.CallOff;
        this.CallSource.Play();
    }

    public virtual void CallSound0()
    {
        this.CallSource.clip = this.CallError;
        this.CallSource.Play();
    }

    public virtual void CallSound3()
    {
        this.CallSource.clip = this.CallLockedOn;
        this.CallSource.Play();
        FurtherActionScript.instance.LockedOn = true;
        FurtherActionScript.instance.ShowText();
        this.targetTXT.text = "You have targeted an entity that goes \n by the code: " + CallButton.LockedName;
    }

    public virtual void CallSound4()
    {
        this.CallSource.clip = this.CallLockedOff;
        this.CallSource.Play();
    }

    static CallButton()
    {
        CallButton.LockedName = "undefined";
    }

}