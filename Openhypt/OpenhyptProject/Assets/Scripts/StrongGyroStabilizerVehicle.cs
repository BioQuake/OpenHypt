using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class StrongGyroStabilizerVehicle : MonoBehaviour
{
    public GameObject target;
    public GameObject AimTarget;
    public MainVehicleController VesselScript;
    public HingeJoint HJoint;
    public float force;
    public int AimAngleCalibration;
    public float AimGyroForce;
    public float AimForce;
    public int AimSpeed;
    public float AimForceDamp;
    public float AimForceOrginalDamp;
    public float offset;
    public bool Up;
    public bool Forward;
    public bool Right;
    public Transform MainVessel;
    public bool CanRotFreely;
    public bool Aiming;
    public bool StopIfAim;
    public bool UseLookRotation;
    public bool UseEngine;
    public bool ShutOff;
    public virtual void Start()
    {
        if (this.UseLookRotation)
        {
            this.AimTarget = GameObject.Find("PlayerCameraAim").gameObject;
        }
        else
        {
            this.AimTarget = PlayerInformation.instance.PiriTurretAim.gameObject;
        }
    }

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
        if (!this.ShutOff)
        {
            if (this.Aiming)
            {
                if (!WorldInformation.playerCar.Contains(this.MainVessel.name))
                {
                    this.target.GetComponent<Rigidbody>().angularDrag = this.AimForceOrginalDamp;
                    this.Aiming = false;
                }
            }
            if (WorldInformation.playerCar.Contains(this.MainVessel.name))
            {
                if (Input.GetMouseButtonDown(1) && (CameraScript.InInterface == false))
                {
                    if (!this.UseLookRotation)
                    {
                        this.target.GetComponent<Rigidbody>().angularDrag = this.AimForceDamp;
                    }
                    this.Aiming = true;
                    if (this.UseLookRotation)
                    {
                        this.GetComponent<Rigidbody>().constraints = (RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY) | RigidbodyConstraints.FreezeRotationZ;
                    }
                    if (this.CanRotFreely)
                    {
                        this.HJoint.useSpring = false;
                    }
                }
                if ((Input.GetMouseButtonUp(1) && (CameraScript.InInterface == false)) || Input.GetKeyDown("e"))
                {
                    if (!this.UseLookRotation)
                    {
                        this.target.GetComponent<Rigidbody>().angularDrag = this.AimForceOrginalDamp;
                    }
                    this.Aiming = false;
                    if (this.UseLookRotation)
                    {
                        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    }
                    if (this.CanRotFreely)
                    {
                        this.HJoint.useSpring = true;
                    }
                }
            }
        }
    }

    public virtual void FixedUpdate()
    {
        if (!this.ShutOff)
        {
            if (this.Aiming)
            {
                this.target.GetComponent<Rigidbody>().AddTorque(this.transform.right * -this.AimAngleCalibration);
                if (this.StopIfAim)
                {
                    this.target.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.up * this.AimGyroForce, this.transform.up * this.offset);
                    this.target.GetComponent<Rigidbody>().AddForceAtPosition(-Vector3.up * this.AimGyroForce, -this.transform.up * this.offset);
                }
                if (this.UseLookRotation)
                {
                    Quaternion NewRotation = Quaternion.LookRotation(this.AimTarget.transform.position - this.transform.position);
                    this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, NewRotation, Time.deltaTime * this.AimSpeed);
                }
                else
                {
                    this.target.GetComponent<Rigidbody>().AddForceAtPosition((this.AimTarget.transform.position - this.transform.position).normalized * this.AimForce, this.transform.forward * this.offset);
                    this.target.GetComponent<Rigidbody>().AddForceAtPosition((this.AimTarget.transform.position - this.transform.position).normalized * -this.AimForce, -this.transform.forward * this.offset);
                }
            }
            if (this.StopIfAim)
            {
                if (this.Aiming)
                {
                    return;
                }
            }
            if (this.Up == true)
            {
                this.target.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.up * this.force, this.transform.up * this.offset);
                this.target.GetComponent<Rigidbody>().AddForceAtPosition(-Vector3.up * this.force, -this.transform.up * this.offset);
            }
        }
    }

    public StrongGyroStabilizerVehicle()
    {
        this.force = 10f;
        this.AimGyroForce = 10f;
        this.AimForce = 10f;
        this.AimSpeed = 50;
        this.AimForceDamp = 20f;
        this.AimForceOrginalDamp = 2f;
        this.offset = 1f;
        this.Up = true;
    }

}