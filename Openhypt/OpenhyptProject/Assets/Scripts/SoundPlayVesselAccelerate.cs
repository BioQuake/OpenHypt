using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SoundPlayVesselAccelerate : MonoBehaviour
{
    public AudioClip audioC;
    public AudioClip audioC2;
    public bool UseStartSound;
    public bool UseFinishSound;
    public bool Aircraft;
    public bool Batubris;
    public Transform MainVessel;
    public MainVehicleController VesselScript;
    public bool UseEngine;
    public bool ShutOff;
    public bool Reversable;
    public virtual void Update()
    {
        if (this.UseEngine)
        {
            if (this.VesselScript.EngineRunning == true)
            {
                this.ShutOff = false;
            }
            if (this.VesselScript.EngineRunning == false)
            {
                this.ShutOff = true;
            }
        }
        else
        {
            if (this.VesselScript)
            {
                if (this.VesselScript.Civmode == true)
                {
                    this.ShutOff = true;
                }
                else
                {
                    this.ShutOff = false;
                }
            }
        }
        if (this.VesselScript)
        {
            if (this.VesselScript.Broken)
            {
                this.ShutOff = true;
            }
        }
        if (!this.ShutOff)
        {
            if (WorldInformation.playerCar == this.MainVessel.name)
            {
                if (CameraScript.InInterface == false)
                {
                    if (((Input.GetKeyDown(KeyCode.W) && this.UseStartSound) && !this.Aircraft) && !this.Batubris)
                    {
                        this.GetComponent<AudioSource>().PlayOneShot(this.audioC);
                    }
                    if ((Input.GetKeyDown(KeyCode.Q) && !this.Aircraft) && this.Batubris)
                    {
                        this.GetComponent<AudioSource>().PlayOneShot(this.audioC);
                    }
                    if (((Input.GetKeyDown(KeyCode.Mouse0) && this.UseStartSound) && this.Aircraft) && !this.Batubris)
                    {
                        this.GetComponent<AudioSource>().PlayOneShot(this.audioC);
                    }
                    if (((Input.GetKeyDown(KeyCode.Mouse1) && this.Aircraft) && this.Reversable) && !this.Batubris)
                    {
                        this.GetComponent<AudioSource>().PlayOneShot(this.audioC);
                    }
                    if (((Input.GetKeyDown(KeyCode.S) && this.Reversable) && !this.Aircraft) && !this.Batubris)
                    {
                        this.GetComponent<AudioSource>().PlayOneShot(this.audioC);
                    }
                    if (((Input.GetKeyUp(KeyCode.W) && this.UseFinishSound) && !this.Aircraft) && !this.Batubris)
                    {
                        this.GetComponent<AudioSource>().PlayOneShot(this.audioC2);
                    }
                    if ((Input.GetKeyUp(KeyCode.Mouse0) && this.Aircraft) && !this.Batubris)
                    {
                        this.GetComponent<AudioSource>().PlayOneShot(this.audioC2);
                    }
                }
            }
        }
    }

}