using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ThrusterLights : MonoBehaviour
{
    public GameObject Vehicle;
    public bool Broken;
    public virtual void Update()
    {
        if (this.Broken)
        {
            this.GetComponent<ParticleSystem>().enableEmission = false;
        }
        if (this.Broken)
        {
            return;
        }
        if (WorldInformation.playerCar.Contains(this.Vehicle.name))
        {
            if (Input.GetKeyDown("w"))
            {
                this.GetComponent<Light>().intensity = 0.3f;
            }
            else
            {
                if (Input.GetKeyUp("w"))
                {
                    this.GetComponent<Light>().intensity = 0;
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