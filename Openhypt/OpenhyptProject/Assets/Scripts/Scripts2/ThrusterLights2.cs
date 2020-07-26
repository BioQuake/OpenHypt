using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ThrusterLights2 : MonoBehaviour
{
    public virtual void Update()
    {
        if (WorldInformation.playerCar.Contains(this.transform.parent.name))
        {
            if (CameraScript.InInterface == false)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    this.GetComponent<Light>().intensity = 0.6f;
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
    }

}