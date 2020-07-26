using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class NotifyDoorScript : MonoBehaviour
{
    public Transform target;
    public bool IsNear;
    public ReactiveObject MainScript;
    public bool Persist;
    public bool EnterSymbol;
    public bool InteractSymbol;
    public bool TalkSymbol;
    public bool OpenSymbol;
    public bool AmmoSymbol;
    public virtual void Start()
    {
        if (this.EnterSymbol)
        {
            this.target = Symbols.instance.Enter;
        }
        if (this.InteractSymbol)
        {
            this.target = Symbols.instance.Interact;
        }
        if (this.TalkSymbol)
        {
            this.target = Symbols.instance.Talk;
        }
        if (this.OpenSymbol)
        {
            this.target = Symbols.instance.Open;
        }
        if (this.AmmoSymbol)
        {
            this.target = Symbols.instance.Ammo;
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("TC1p") && (WorldInformation.playerCar == "null"))
        {
            if (this.target)
            {
                this.target.gameObject.SetActive(true);
            }
            this.IsNear = true;
            if (this.MainScript)
            {
                this.MainScript.Entered = true;
            }
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("TC1p") && (WorldInformation.playerCar == "null"))
        {
            if (this.target)
            {
                this.target.gameObject.SetActive(false);
            }
            this.IsNear = false;
            if (this.MainScript)
            {
                this.MainScript.Entered = false;
            }
        }
    }

    public virtual void Update()
    {
        if (this.IsNear)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!this.Persist)
                {
                    this.target.gameObject.SetActive(false);
                    this.IsNear = false;
                }
            }
        }
    }

}