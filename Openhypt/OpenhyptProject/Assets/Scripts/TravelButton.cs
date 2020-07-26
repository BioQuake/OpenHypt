using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class TravelButton : MonoBehaviour
{
    public bool Switching;
    public bool isPressed;
    public int Count;
    public virtual void OnMouseDown()
    {
        if (WorldInformation.PiriWanted > 240)
        {
            FurtherActionScript.instance.Wanted = true;
            FurtherActionScript.instance.ShowText();
            this.isPressed = false;
            return;
        }
        if (WorldInformation.playerCar == "null")
        {
            FurtherActionScript.instance.NoVessel = true;
            FurtherActionScript.instance.ShowText();
            this.isPressed = false;
            return;
        }
        if (IndicatorScript.VehicleIsDamaged)
        {
            FurtherActionScript.instance.VesselBroken = true;
            FurtherActionScript.instance.ShowText();
            this.isPressed = false;
            return;
        }
        if (TerrahyptianNetwork.instance.NukeMarker)
        {
            if (Vector3.Distance(TerrahyptianNetwork.instance.NukeMarker.position, PlayerInformation.instance.PiriTarget.position) < 256)
            {
                FurtherActionScript.instance.NoTravelCM = true;
                FurtherActionScript.instance.ShowText();
                this.isPressed = false;
                return;
            }
        }
        if (WorldInformation.instance.AreaClosed)
        {
            FurtherActionScript.instance.NoTravel = true;
            FurtherActionScript.instance.ShowText();
            this.isPressed = false;
            return;
        }
        if (WorldInformation.Hitching)
        {
            FurtherActionScript.instance.NoHitchTravel = true;
            FurtherActionScript.instance.ShowText();
            this.isPressed = false;
            return;
        }
        if (WorldInformation.playerCar != "null")
        {
            FurtherActionScript.instance.Travel = true;
            FurtherActionScript.instance.ShowText();
            this.isPressed = true;
            return;
        }
    }

    public virtual IEnumerator SwitchScene()
    {
        ScreenFadeScript.FadeOut = true;
        yield return new WaitForSeconds(3);
        if (!WorldInformation.PiriIsHurt)
        {
            WorldInformation.instance.Travel();
        }
    }

    public virtual void Counter()
    {
        if (this.isPressed)
        {
            if (Input.GetMouseButton(0))
            {
                this.Count = this.Count + 1;
            }
            if (!Input.GetMouseButton(0))
            {
                this.Count = 0;
                this.isPressed = false;
            }
            if (!this.Switching && (this.Count > 2))
            {
                this.Switching = true;
                this.StartCoroutine(this.SwitchScene());
            }
        }
    }

    public virtual void Start()
    {
        this.InvokeRepeating("Counter", 1, 1);
    }

}