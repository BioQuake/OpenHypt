using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class DoorTeriorScript : MonoBehaviour
{
    public bool ControlLight;
    public bool ActivateLight;
    public bool ActivateFP;
    public virtual void OnTriggerStay(Collider other)
    {
        string ON = other.name;
        if (WorldInformation.UsingVessel && WorldInformation.UsingClosedVessel)
        {
            return;
        }
        if (WorldInformation.IsNopass)
        {
            return;
        }
        if (!this.ControlLight)
        {
            if (ON.Contains("sTC1p"))
            {
                if (this.ActivateFP)
                {
                    WorldInformation.FPMode = true;
                }
                else
                {
                    WorldInformation.FPMode = false;
                }
            }
        }
        else
        {
            if (ON.Contains("sTC1p"))
            {
                if (this.ActivateLight)
                {
                    PlayerStronglight.Activated = true;
                    WorldInformation.AmbOn = true;
                }
                else
                {
                    PlayerStronglight.Activated = false;
                    WorldInformation.AmbOff = true;
                }
            }
        }
    }

}