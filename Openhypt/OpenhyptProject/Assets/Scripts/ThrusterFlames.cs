using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ThrusterFlames : MonoBehaviour
{
    public bool Broken;
    public Transform MainVessel;
    public MainVehicleController VesselScript;
    public bool UseEngine;
    public bool Reversable;
    public bool Strafable;
    public bool Aircraft;
    public bool ShutOff;
    public GameObject Poof;
    public virtual void Update()
    {
        if (this.MainVessel.name == "broken")
        {
            if (!this.Broken)
            {
                this.Broken = true;
                this.GetComponent<ParticleSystem>().enableEmission = false;
            }
        }
        if (this.Broken)
        {
            return;
        }
        if (WorldInformation.playerCar == this.MainVessel.name)
        {
            if (this.UseEngine)
            {
                if (this.VesselScript.EngineRunning == true)
                {
                    this.ShutOff = false;
                }
                if (this.VesselScript.EngineRunning == false)
                {
                    if (!this.ShutOff)
                    {
                        this.GetComponent<ParticleSystem>().enableEmission = false;
                        this.ShutOff = true;
                    }
                }
            }
            else
            {
                if (this.VesselScript)
                {
                    if (this.VesselScript.Civmode)
                    {
                        this.ShutOff = true;
                    }
                    else
                    {
                        this.ShutOff = false;
                    }
                }
            }
            if ((CameraScript.InInterface == false) && !this.ShutOff)
            {
                if (!this.Aircraft)
                {
                    if (Input.GetKeyDown("w"))
                    {
                        this.GetComponent<ParticleSystem>().enableEmission = true;
                        if (this.Poof)
                        {
                            UnityEngine.Object.Instantiate(this.Poof, this.transform.position, this.transform.rotation);
                        }
                    }
                    if (Input.GetKeyUp("w"))
                    {
                        this.GetComponent<ParticleSystem>().enableEmission = false;
                    }
                    if (this.Strafable)
                    {
                        if (Input.GetKey("a"))
                        {
                            this.GetComponent<ParticleSystem>().enableEmission = true;
                        }
                        if (Input.GetKeyUp("a"))
                        {
                            if (!Input.GetKey("w"))
                            {
                                this.GetComponent<ParticleSystem>().enableEmission = false;
                            }
                        }
                        if (Input.GetKey("d"))
                        {
                            this.GetComponent<ParticleSystem>().enableEmission = true;
                        }
                        if (Input.GetKeyUp("d"))
                        {
                            if (!Input.GetKey("w"))
                            {
                                this.GetComponent<ParticleSystem>().enableEmission = false;
                            }
                        }
                    }
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        this.GetComponent<ParticleSystem>().enableEmission = true;
                        if (this.Poof)
                        {
                            UnityEngine.Object.Instantiate(this.Poof, this.transform.position, this.transform.rotation);
                        }
                    }
                    if (Input.GetKeyUp(KeyCode.Mouse0))
                    {
                        this.GetComponent<ParticleSystem>().enableEmission = false;
                    }
                }
                if (this.Reversable)
                {
                    if (Input.GetKey("w"))
                    {
                        this.GetComponent<ParticleSystem>().enableEmission = true;
                    }
                    if (Input.GetKeyUp("a"))
                    {
                        if (!Input.GetKey("w"))
                        {
                            this.GetComponent<ParticleSystem>().enableEmission = false;
                        }
                    }
                    if (Input.GetKey("s"))
                    {
                        this.GetComponent<ParticleSystem>().enableEmission = true;
                    }
                    if (Input.GetKeyUp("s"))
                    {
                        if (!Input.GetKey("w"))
                        {
                            this.GetComponent<ParticleSystem>().enableEmission = false;
                        }
                    }
                }
            }
        }
    }

}