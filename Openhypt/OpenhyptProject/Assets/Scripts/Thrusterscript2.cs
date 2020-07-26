using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class Thrusterscript2 : MonoBehaviour
{
    public float ForwardSpeed;
    public float ReverseSpeed;
    public float LeftSpeed;
    public float RightSpeed;
    public float TorqueForce;
    public float UpSpeed;
    public float DownSpeed;
    public Transform MainVessel;
    public MainVehicleController VesselScript;
    public bool UseEngine;
    public bool ShutOff;
    public bool useFCurve;
    public AnimationCurve forceCurve;
    public bool NoAimTorque;
    public bool UseTorque;
    public bool UseStrafeKeys;
    public bool UseDownforce;
    public bool BreakNoRev;
    public AnimationCurve curve;
    public float Distance;
    public float Downforce;
    public float DownforceMultiplier;
    public LayerMask targetLayers;
    public bool RunningF;
    public bool RunningR;
    public virtual void Update()
    {
        if (WorldInformation.playerCar == this.MainVessel.name)
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
        RaycastHit hit = default(RaycastHit);
        Vector3 localV = this.transform.InverseTransformDirection(this.GetComponent<Rigidbody>().velocity);
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
        if (!this.ShutOff)
        {
            if (this.useFCurve)
            {
                this.ForwardSpeed = this.forceCurve.Evaluate(localV.z);
            }
            if (this.RunningF)
            {
                this.GetComponent<Rigidbody>().AddForce(this.transform.forward * this.ForwardSpeed);
            }
            if (this.RunningR && !this.BreakNoRev)
            {
                this.GetComponent<Rigidbody>().AddForce(-this.transform.forward * this.ReverseSpeed);
            }
            if (this.RunningR && this.BreakNoRev)
            {
                if (localV.z > 0)
                {
                    this.GetComponent<Rigidbody>().AddForce(-this.transform.forward * this.ReverseSpeed);
                }
            }
            if (WorldInformation.playerCar == this.MainVessel.name)
            {
                if (!this.NoAimTorque)
                {
                    if (!this.UseStrafeKeys)
                    {
                        if (Input.GetKey("a"))
                        {
                            this.GetComponent<Rigidbody>().AddForce(-this.transform.right * this.LeftSpeed);
                        }
                        if (Input.GetKey("d"))
                        {
                            this.GetComponent<Rigidbody>().AddForce(this.transform.right * this.RightSpeed);
                        }
                    }
                    else
                    {
                        if (Input.GetKey("z"))
                        {
                            this.GetComponent<Rigidbody>().AddForce(-this.transform.right * this.LeftSpeed);
                        }
                        if (Input.GetKey("x"))
                        {
                            this.GetComponent<Rigidbody>().AddForce(this.transform.right * this.RightSpeed);
                        }
                    }
                    if (this.UseTorque)
                    {
                        if (Input.GetKey("a"))
                        {
                            this.GetComponent<Rigidbody>().AddTorque(-this.transform.up * this.TorqueForce);
                        }
                        if (Input.GetKey("d"))
                        {
                            this.GetComponent<Rigidbody>().AddTorque(this.transform.up * this.TorqueForce);
                        }
                    }
                }
                else
                {
                    if (!Input.GetMouseButton(1))
                    {
                        if (Input.GetKey("a"))
                        {
                            this.GetComponent<Rigidbody>().AddTorque(-this.transform.up * this.TorqueForce);
                        }
                        if (Input.GetKey("d"))
                        {
                            this.GetComponent<Rigidbody>().AddTorque(this.transform.up * this.TorqueForce);
                        }
                    }
                    else
                    {
                        if (Input.GetKey("a"))
                        {
                            this.GetComponent<Rigidbody>().AddForce(-this.transform.right * this.LeftSpeed);
                        }
                        if (Input.GetKey("d"))
                        {
                            this.GetComponent<Rigidbody>().AddForce(this.transform.right * this.RightSpeed);
                        }
                    }
                }
                if (Input.GetKey(KeyCode.Space))
                {
                    this.GetComponent<Rigidbody>().AddForce(this.transform.up * this.UpSpeed);
                }
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    this.GetComponent<Rigidbody>().AddForce(-this.transform.up * this.DownSpeed);
                }
            }
            if (this.UseDownforce)
            {
                if (Physics.Raycast(this.transform.position, Vector3.down, out hit, this.Distance, (int) this.targetLayers))
                {
                    this.Downforce = this.curve.Evaluate(hit.distance);
                }
                this.GetComponent<Rigidbody>().AddForce((Vector3.down * this.Downforce) * this.DownforceMultiplier);
            }
        }
    }

    public Thrusterscript2()
    {
        this.ForwardSpeed = 10;
        this.ReverseSpeed = 100;
        this.LeftSpeed = -30;
        this.RightSpeed = 30;
        this.TorqueForce = 40;
        this.forceCurve = new AnimationCurve();
        this.curve = new AnimationCurve();
        this.Distance = 10;
        this.Downforce = 10;
        this.DownforceMultiplier = 1;
    }

}