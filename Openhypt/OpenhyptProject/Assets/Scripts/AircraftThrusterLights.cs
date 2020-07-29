using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AircraftThrusterLights : MonoBehaviour
{
    public MainVehicleController VesselScript;
    public bool UseEngine;
    public bool Broken;
    public bool WorkInDark;
    public float LightIntensity;
    public virtual void Start()
    {
        if ((WorldInformation.instance.AreaDark == false) && this.WorkInDark)
        {
            this.Broken = true;
        }
    }

    public virtual void Update()
    {
        bool ShutOff = false;
        if (this.UseEngine)
        {
            if (this.VesselScript.EngineRunning == true)
            {
                ShutOff = false;
            }
            if (this.VesselScript.EngineRunning == false)
            {
                ShutOff = true;
            }
        }
        if (this.Broken)
        {
            this.GetComponent<Light>().intensity = 0;
            return;
        }
        if (!ShutOff)
        {
            if (WorldInformation.playerCar.Contains(this.transform.parent.name))
            {
                if (CameraScript.InInterface == false)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        this.GetComponent<Light>().intensity = this.LightIntensity;
                    }
                    else
                    {
                        if (Input.GetKeyUp(KeyCode.Mouse0))
                        {
                            this.GetComponent<Light>().intensity = 0;
                        }
                    }
                }
            }
            else
            {
                if (WorldInformation.playerCar == null)
                {
                    this.GetComponent<Light>().intensity = 0;
                }
            }
        }
    }

    public AircraftThrusterLights()
    {
        this.LightIntensity = 1f;
    }

}