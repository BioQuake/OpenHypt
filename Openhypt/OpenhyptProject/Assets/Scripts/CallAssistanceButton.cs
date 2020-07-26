using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class CallAssistanceButton : MonoBehaviour
{
    private bool entered;
    public bool CallCeptopod;
    public bool CallPiriDrone;
    public bool CallPolice;
    public bool CallAmmo;
    public bool CallKatovari;
    public bool CallCargo;
    public bool CallCargoAgrian;
    public bool IsDismiss;
    public virtual void Update()
    {
        if (this.entered && Input.GetMouseButtonDown(0))
        {
            if (this.CallPolice)
            {
                if (!this.IsDismiss)
                {
                    CallAssistance.CallingAssistance = true;
                    this.IsDismiss = true;
                }
                else
                {
                    CallAssistance.DismissAssistance = true;
                    this.IsDismiss = false;
                }
            }
            if (this.CallAmmo)
            {
                if (!this.IsDismiss)
                {
                    CallAssistance.CallingAmmo = true;
                    this.IsDismiss = true;
                }
                else
                {
                    CallAssistance.DismissAmmo = true;
                    this.IsDismiss = false;
                }
            }
            if (this.CallCargo)
            {
                CallAssistance.CallingCargo = true;
            }
            if (this.CallKatovari)
            {
                CallAssistance.CallingKatovari = true;
            }
            if (this.CallCargoAgrian)
            {
                CallAssistance.CallingCargoAgrian = true;
            }
            if (this.CallCeptopod)
            {
                if (!this.IsDismiss)
                {
                    CallAssistance.CallingCepto = true;
                    this.IsDismiss = true;
                }
                else
                {
                    CallAssistance.DismissCepto = true;
                    this.IsDismiss = false;
                }
            }
            if (this.CallPiriDrone)
            {
                if (!this.IsDismiss)
                {
                    CallAssistance.CallingPiriDrone = true;
                    this.IsDismiss = true;
                }
                else
                {
                    CallAssistance.DismissPiriDrone = true;
                    this.IsDismiss = false;
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

}