using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class EngineWhizzer2 : MonoBehaviour
{
    public bool Stopped;
    public bool IsPlaying;
    public GameObject Vessel;
    public float WhizzSpeed;
    public float audioClipSpeed;
    public AnimationCurve curve;
    public float VolumeAmount;
    public float VolumeMod;
    public float MinPitch;
    private int lastspeed;
    private string state;
    public bool RunningF;
    public bool RunningR;
    public virtual void Update()
    {
        if (WorldInformation.playerCar == this.transform.parent.name)
        {
            if (CameraScript.InInterface == false)
            {
                if (Input.GetKeyDown("w"))
                {
                    this.RunningF = true;
                }
                if (Input.GetKeyUp("w"))
                {
                    this.RunningF = false;
                }
                if (Input.GetKeyDown("s"))
                {
                    this.RunningR = true;
                }
                if (Input.GetKeyUp("s"))
                {
                    this.RunningR = false;
                }
            }
        }
    }

    public virtual void FixedUpdate()
    {
        if (this.GetComponent<Rigidbody>().angularVelocity.magnitude > 0.5f)
        {
            float p = this.GetComponent<Rigidbody>().angularVelocity.magnitude / this.audioClipSpeed;
            this.GetComponent<AudioSource>().pitch = Mathf.Clamp(p * 1, this.MinPitch, 3f);
            this.GetComponent<AudioSource>().volume = this.VolumeAmount;
            this.VolumeAmount = this.curve.Evaluate(p) * this.VolumeMod;
            this.lastspeed = (int) this.GetComponent<Rigidbody>().angularVelocity.magnitude;
            if (this.GetComponent<Rigidbody>().angularVelocity.magnitude < 0.6f)
            {
                this.GetComponent<AudioSource>().Stop();
                this.Stopped = true;
                this.IsPlaying = false;
            }
            else
            {
                if ((this.GetComponent<Rigidbody>().angularVelocity.magnitude > 0.6f) && (this.Stopped == true))
                {
                    this.GetComponent<AudioSource>().Play();
                    this.Stopped = false;
                    this.IsPlaying = true;
                }
            }
        }
        if (this.RunningF || this.RunningR)
        {
            this.GetComponent<Rigidbody>().AddTorque(this.transform.up * this.WhizzSpeed);
        }
    }

    public EngineWhizzer2()
    {
        this.WhizzSpeed = 100;
        this.audioClipSpeed = 20f;
        this.curve = new AnimationCurve();
        this.VolumeMod = 1f;
        this.lastspeed = 1;
    }

}