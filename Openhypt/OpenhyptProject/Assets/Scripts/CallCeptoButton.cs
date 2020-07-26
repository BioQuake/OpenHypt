using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class CallCeptoButton : MonoBehaviour
{
    private bool entered;
    public bool IsDismiss;
    public virtual void Update()
    {
        if (this.entered && Input.GetMouseButtonDown(0))
        {
            if (!this.IsDismiss)
            {
                CallAssistance.CallingCepto = true;
            }
            else
            {
                CallAssistance.DismissCepto = true;
            }
            this.entered = false;
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