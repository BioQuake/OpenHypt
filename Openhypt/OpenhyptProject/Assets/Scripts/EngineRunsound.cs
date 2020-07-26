using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class EngineRunsound : MonoBehaviour
{
    public float maxVolume;
    public float incrementValue;
    public float decrementValue;
    public Transform MainVessel;
    public MainVehicleController VesselScript;
    public bool UseEngine;
    public bool IsOn;
    public bool MBControl;
    public bool OnlyReverse;
    public bool OnlyForward;
    public bool IncludeSideMovement;
    public bool RunningF;
    public bool RunningR;
    public bool RunningA;
    public bool RunningD;
    private string state;
    public virtual void Start()
    {
        this.InvokeRepeating("StopAudio", 1, 0.3f);
        if (!this.UseEngine)
        {
            this.IsOn = true;
        }
    }

    public virtual void Update()
    {
        if (WorldInformation.playerCar == this.MainVessel.name)
        {
            if (this.MBControl)
            {
                if ((CameraScript.InInterface == false) && this.IsOn)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0) && !this.OnlyReverse)
                    {
                        this.RunningF = true;
                    }
                    if (Input.GetKeyUp(KeyCode.Mouse0) && !this.OnlyReverse)
                    {
                        this.RunningF = false;
                    }
                    if (Input.GetKeyDown(KeyCode.Mouse1) && !this.OnlyForward)
                    {
                        this.RunningR = true;
                    }
                    if (Input.GetKeyUp(KeyCode.Mouse1) && !this.OnlyForward)
                    {
                        this.RunningR = false;
                    }
                }
            }
            else
            {
                if ((CameraScript.InInterface == false) && this.IsOn)
                {
                    if (Input.GetKeyDown("w") && !this.OnlyReverse)
                    {
                        this.RunningF = true;
                    }
                    if (Input.GetKeyUp("w") && !this.OnlyReverse)
                    {
                        this.RunningF = false;
                    }
                    if (Input.GetKeyDown("s") && !this.OnlyForward)
                    {
                        this.RunningR = true;
                    }
                    if (Input.GetKeyUp("s") && !this.OnlyForward)
                    {
                        this.RunningR = false;
                    }
                    if (Input.GetKeyDown("a") && this.IncludeSideMovement)
                    {
                        this.RunningA = true;
                    }
                    if (Input.GetKeyUp("a") && this.IncludeSideMovement)
                    {
                        this.RunningA = false;
                    }
                    if (Input.GetKeyDown("d") && this.IncludeSideMovement)
                    {
                        this.RunningD = true;
                    }
                    if (Input.GetKeyUp("d") && this.IncludeSideMovement)
                    {
                        this.RunningD = false;
                    }
                    if (this.VesselScript)
                    {
                        if (this.VesselScript.Civmode == true)
                        {
                            this.RunningF = false;
                        }
                    }
                }
            }
        }
        if (this.UseEngine)
        {
            if (this.VesselScript.EngineRunning == false)
            {
                if (this.IsOn)
                {
                    //RunningW = false;
                    this.RunningF = false;
                    this.IsOn = false;
                }
            }
            if (this.VesselScript.EngineRunning == true)
            {
                this.IsOn = true;
            }
        }
        if (this.VesselScript)
        {
            if (this.VesselScript.Broken)
            {
                this.IsOn = false;
            }
        }
    }

    public virtual void FixedUpdate()
    {
        if (((this.RunningF || this.RunningR) || this.RunningA) || this.RunningD)
        {
            this.state = "increment";
        }
        if (((!this.RunningF && !this.RunningR) && !this.RunningA) && !this.RunningD)
        {
            this.state = "decrement";
        }
        if (this.state == "increment")
        {
            this.increment();
        }
        else
        {
            if (this.state == "decrement")
            {
                this.decrement();
                this.stopcrement();
            }
        }
    }

    public virtual void decrement()
    {
        if (this.GetComponent<AudioSource>().volume > 0.11f)
        {
            this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume - this.decrementValue;
        }
    }

    public virtual void stopcrement()
    {
        if (this.GetComponent<AudioSource>().volume < 0.12f)
        {
            this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume - 0.01f;
        }
    }

    public virtual void increment()
    {
        if (!this.GetComponent<AudioSource>().isPlaying)
        {
            this.GetComponent<AudioSource>().Play();
        }
        if (this.GetComponent<AudioSource>().volume < this.maxVolume)
        {
            this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume + this.incrementValue;
        }
        else
        {
            this.state = "";
        }
    }

    public virtual void StopAudio()
    {
        if (this.GetComponent<AudioSource>().volume == 0)
        {
            this.GetComponent<AudioSource>().Stop();
            this.state = "";
        }
    }

    public EngineRunsound()
    {
        this.maxVolume = 1;
        this.incrementValue = 0.1f;
        this.decrementValue = 0.05f;
    }

}