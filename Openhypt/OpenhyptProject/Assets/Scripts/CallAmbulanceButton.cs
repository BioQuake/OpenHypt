using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class CallAmbulanceButton : MonoBehaviour
{
    public bool CallZerzek;
    private bool entered;
    public virtual void Update()
    {
        if (this.entered && Input.GetMouseButtonDown(0))
        {
            if (this.CallZerzek)
            {
                if (!WorldInformation.PiriZerzekPresent)
                {
                    WorldInformation.instance.Home();
                    CallButton.CallingOther = true;
                    this.entered = false;
                }
                else
                {
                    FurtherActionScript.instance.ZerzekAlreadyPresent = true;
                    FurtherActionScript.instance.ShowText();
                    CallButton.CallingOther0 = true;
                    this.entered = false;
                }
            }
            else
            {
                if ((AgrianNetwork.TC1CriminalLevel > 240) || (WorldInformation.PiriWanted > 240))
                {
                    FurtherActionScript.instance.Wanted = true;
                    FurtherActionScript.instance.ShowText();
                    CallButton.CallingOther0 = true;
                    this.entered = false;
                }
                else
                {
                    LoadPiriLocation.CallingAmbulance = true;
                    CallButton.CallingOther = true;
                    this.entered = false;
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