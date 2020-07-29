using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PropSpin : MonoBehaviour
{
    public MainVehicleController VesselScript;
    public HingeJoint HJoint;
    public Rigidbody rBody;
    public bool UseEngine;
    public float CCWSpeed;
    public float CWSpeed;
    public bool UseForce;
    public float ForceModifier;
    public bool UseFeedbackForce;
    public float FeedbackModifier;
    public float AngDrag;
    public GameObject PropFastSpinMesh;
    public GameObject PropSpinMesh;
    public GameObject PropIdleMesh;
    public bool UsePropMeshes;
    public bool UseWS;
    public bool UseToggle;
    public bool RunningCW;
    public bool RunningCCW;
    public bool KeyLShift;
    public bool KeyLCtrl;
    public bool Boost;
    public bool CanReset;
    public bool AxisUp;
    public bool AxisForward;
    public bool Broken;
    public virtual void Start()
    {
        this.rBody = this.GetComponent<Rigidbody>();
    }

    public virtual void Update()
    {
        if (this.RunningCCW || this.RunningCW)
        {
            if (this.AngDrag > 0)
            {
                this.rBody.angularDrag = this.AngDrag;
            }
        }
        if (this.UseEngine)
        {
            if (!this.VesselScript.EngineRunning)
            {
                this.RunningCW = false;
                this.RunningCCW = false;
                this.Broken = true;
            }
            else
            {
                this.Broken = false;
            }
        }
        if (this.VesselScript)
        {
            if (this.VesselScript.Broken)
            {
                this.Broken = true;
            }
            else
            {
                this.Broken = false;
            }
        }
        if (!this.Broken)
        {
            if (this.CanReset)
            {
                if (!this.RunningCCW && !this.RunningCW)
                {
                    this.HJoint.useSpring = true;
                }
                if (this.RunningCCW || this.RunningCW)
                {
                    this.HJoint.useSpring = false;
                }
            }
        }
        if (WorldInformation.playerCar == this.transform.parent.name)
        {
            if (CameraScript.InInterface == false)
            {
                if (!this.UseToggle)
                {
                    if (this.UseWS)
                    {
                        if (Input.GetKeyDown("w"))
                        {
                            this.RunningCCW = true;
                        }
                        if (Input.GetKeyUp("w"))
                        {
                            this.RunningCCW = false;
                        }
                        if (Input.GetKeyDown("s"))
                        {
                            this.RunningCW = true;
                        }
                        if (Input.GetKeyUp("s"))
                        {
                            this.RunningCW = false;
                        }
                    }
                    else
                    {
                        if (Input.GetKeyDown(KeyCode.Mouse0))
                        {
                            this.RunningCCW = true;
                        }
                        if (Input.GetKeyUp(KeyCode.Mouse0))
                        {
                            this.RunningCCW = false;
                        }
                        if (Input.GetKeyDown(KeyCode.Mouse1))
                        {
                            this.RunningCW = true;
                        }
                        if (Input.GetKeyUp(KeyCode.Mouse1))
                        {
                            this.RunningCW = false;
                        }
                    }
                }
                else
                {
                    if (Input.GetKeyDown("q"))
                    {
                        if (!this.RunningCCW)
                        {
                            this.RunningCCW = true;
                        }
                        else
                        {
                            if (this.RunningCCW)
                            {
                                this.RunningCCW = false;
                            }
                        }
                    }
                }
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    this.KeyLShift = true;
                }
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    this.KeyLShift = false;
                }
                if (Input.GetKeyDown(KeyCode.LeftControl))
                {
                    this.KeyLCtrl = true;
                }
                if (Input.GetKeyUp(KeyCode.LeftControl))
                {
                    this.KeyLCtrl = false;
                }
            }
        }
    }

    public virtual void FixedUpdate()
    {
        if (!this.Broken)
        {
            if (this.AxisUp)
            {
                if (this.RunningCCW)
                {
                    this.rBody.AddTorque(this.transform.up * this.CCWSpeed);
                }
                if (this.RunningCW)
                {
                    this.rBody.AddTorque(this.transform.up * this.CWSpeed);
                }
            }
            if (this.AxisForward)
            {
                if (this.RunningCCW)
                {
                    this.rBody.AddTorque(this.transform.forward * this.CCWSpeed);
                }
                if (this.RunningCW)
                {
                    this.rBody.AddTorque(this.transform.forward * this.CWSpeed);
                }
            }
        }
        if (this.UseForce)
        {
            if (this.AxisUp)
            {
                float p = Vector3.Dot(this.transform.up, this.rBody.angularVelocity) * this.ForceModifier;
                this.rBody.AddForce(this.transform.up * p);
            }
            if (this.AxisForward)
            {
                float n = Vector3.Dot(this.transform.forward, this.rBody.angularVelocity) * this.ForceModifier;
                this.rBody.AddForce(this.transform.forward * n);
                if (this.KeyLShift && this.Boost)
                {
                    this.rBody.AddForce((this.transform.forward * n) * 0.5f);
                }
                if (this.KeyLCtrl && this.Boost)
                {
                    this.rBody.AddForce((this.transform.forward * n) * -0.5f);
                }
            }
        }
        if (this.UseFeedbackForce)
        {
            Vector3 localV = this.transform.InverseTransformDirection(this.rBody.velocity);
            float Fp = localV.y * this.FeedbackModifier;
            this.rBody.AddTorque(this.transform.up * Fp);
        }
        if (!this.UsePropMeshes)
        {
            return;
        }
        if (this.rBody.angularVelocity.magnitude > 30)
        {
            this.PropFastSpinMesh.gameObject.SetActive(true);
            this.PropIdleMesh.gameObject.SetActive(false);
            this.PropSpinMesh.gameObject.SetActive(false);
            return;
        }
        if (this.rBody.angularVelocity.magnitude > 15)
        {
            this.PropSpinMesh.gameObject.SetActive(true);
            this.PropFastSpinMesh.gameObject.SetActive(false);
            this.PropIdleMesh.gameObject.SetActive(false);
            return;
        }
        if (this.rBody.angularVelocity.magnitude < 15)
        {
            this.PropFastSpinMesh.gameObject.SetActive(false);
            this.PropSpinMesh.gameObject.SetActive(false);
            this.PropIdleMesh.gameObject.SetActive(true);
        }
    }

    public virtual void OnJointBreak(float breakForce)
    {
        this.transform.parent = null;
        this.PropFastSpinMesh.gameObject.SetActive(false);
        this.PropSpinMesh.gameObject.SetActive(false);
        this.PropIdleMesh.gameObject.SetActive(true);
        UnityEngine.Object.Destroy(this);
    }

    public PropSpin()
    {
        this.CCWSpeed = -100;
        this.CWSpeed = 100;
        this.ForceModifier = 60f;
        this.FeedbackModifier = 1;
    }

}