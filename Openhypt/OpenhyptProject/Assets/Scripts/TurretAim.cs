using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class TurretAim : MonoBehaviour
{
    public GameObject AimTarget;
    public GameObject AimForward;
    public Transform MainVessel;
    public bool UseAimPoint;
    public Transform AimPoint;
    public Vector3 AimPos;
    public Vector3 RelPoint;
    public MainVehicleController VesselScript;
    public float AimForce;
    public float VarAimForce;
    public float AimSpeed;
    public float AimForceDamp;
    public float AimForceOriginalDamp;
    public float offset;
    public float Dist;
    public bool UseEngine;
    public bool Activated;
    public bool Aiming;
    public bool CanResetAim;
    public bool CanLockAim;
    public bool Reset;
    public bool AimLocked;
    public bool StabilizePivot;
    public GameObject Pivot;
    public float StabForce;
    public bool HingeAim;
    public HingeJoint TraverseJoint;
    public HingeJoint ElevationJoint;
    public bool YAxis;
    public bool ZAxis;
    public float Vert;
    public float Hori;
    public LayerMask targetLayers;
    public virtual void Start()
    {
        this.InvokeRepeating("Tick", 1, 0.3f);
        this.Reset = true;
        this.AimTarget = PlayerInformation.instance.PiriTurretAim.gameObject;
        this.AimPoint = GameObject.Find("AimPointTarget").gameObject.transform;
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        if (WorldInformation.playerCar.Contains(this.MainVessel.name))
        {
            if (this.CanLockAim)
            {
                if (Input.GetMouseButton(1))
                {
                    if (Physics.Raycast(this.transform.position + (-this.transform.up * 2), -this.transform.up, out hit, Mathf.Infinity, (int) this.targetLayers))
                    {
                        this.AimPos = hit.point;
                    }
                }
                if (Input.GetKeyDown("2"))
                {
                    this.AimLocked = false;
                    this.Aiming = false;
                }
                if (Input.GetKeyDown("3"))
                {
                    this.AimLocked = true;
                    this.Aiming = true;
                }
            }
            if (Input.GetMouseButtonDown(1) && (CameraScript.InInterface == false))
            {
                if (!this.HingeAim)
                {
                    this.GetComponent<Rigidbody>().angularDrag = this.AimForceDamp;
                }
                this.Aiming = true;
                this.Reset = false;
            }
            if (Input.GetMouseButtonUp(1) && (CameraScript.InInterface == false))
            {
                this.Aiming = false;
                if (!this.HingeAim)
                {
                    this.GetComponent<Rigidbody>().angularDrag = this.AimForceOriginalDamp;
                }
            }
        }
    }

    public virtual void FixedUpdate()
    {
        if (this.AimPoint)
        {
            this.Dist = Vector3.Distance(this.transform.position, this.AimPoint.position);
        }
        else
        {
            this.Dist = 16;
        }
        if (this.UseEngine)
        {
            if (this.VesselScript.EngineRunning == true)
            {
                this.Activated = true;
            }
            if (this.VesselScript.EngineRunning == false)
            {
                this.Activated = false;
            }
        }
        if (this.Activated)
        {
            if (this.StabilizePivot)
            {
                this.Pivot.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.up * this.StabForce, this.Pivot.transform.up * 2);
                this.Pivot.GetComponent<Rigidbody>().AddForceAtPosition(-Vector3.up * this.StabForce, -this.Pivot.transform.up * 2);
            }
            if (this.GetComponent<Rigidbody>().angularVelocity.magnitude < this.AimSpeed)
            {
                this.VarAimForce = this.AimForce;
            }
            else
            {
                this.VarAimForce = 0;
                if (this.HingeAim)
                {

                    {
                        int _3680 = 0;
                        JointMotor _3681 = this.ElevationJoint.motor;
                        _3681.targetVelocity = _3680;
                        this.ElevationJoint.motor = _3681;
                    }

                    {
                        int _3682 = 0;
                        JointMotor _3683 = this.TraverseJoint.motor;
                        _3683.targetVelocity = _3682;
                        this.TraverseJoint.motor = _3683;
                    }
                }
            }
            if (((!this.Aiming && this.YAxis) && this.CanResetAim) && this.Reset)
            {
                if (!this.HingeAim)
                {
                    this.GetComponent<Rigidbody>().AddForceAtPosition((this.AimForward.transform.position - this.transform.position).normalized * this.VarAimForce, this.transform.up * this.offset);
                    this.GetComponent<Rigidbody>().AddForceAtPosition((this.AimForward.transform.position - this.transform.position).normalized * -this.VarAimForce, -this.transform.up * this.offset);
                }
                else
                {
                    if (this.UseAimPoint)
                    {
                        this.Dist = Vector3.Distance(this.transform.position, this.AimForward.transform.position);
                        this.RelPoint = this.transform.InverseTransformPoint(this.AimForward.transform.position);
                        this.Vert = Mathf.Clamp((-this.RelPoint.z * this.VarAimForce) / this.Dist, -128, 128);
                        this.Hori = Mathf.Clamp((this.RelPoint.x * this.VarAimForce) / this.Dist, -128, 128);
                    }
                    else
                    {
                        this.RelPoint = this.transform.InverseTransformPoint(this.AimForward.transform.position);
                        this.Vert = -this.RelPoint.z * this.VarAimForce;
                        this.Hori = this.RelPoint.x * this.VarAimForce;
                    }

                    {
                        float _3684 = this.Vert;
                        JointMotor _3685 = this.ElevationJoint.motor;
                        _3685.targetVelocity = _3684;
                        this.ElevationJoint.motor = _3685;
                    }

                    {
                        float _3686 = this.Hori;
                        JointMotor _3687 = this.TraverseJoint.motor;
                        _3687.targetVelocity = _3686;
                        this.TraverseJoint.motor = _3687;
                    }
                }
            }
            if (this.Aiming && this.YAxis)
            {
                if (!this.AimLocked)
                {
                    if (!this.HingeAim)
                    {
                        if (!this.UseAimPoint)
                        {
                            this.GetComponent<Rigidbody>().AddForceAtPosition((this.AimTarget.transform.position - this.transform.position).normalized * this.VarAimForce, this.transform.up * this.offset);
                            this.GetComponent<Rigidbody>().AddForceAtPosition((this.AimTarget.transform.position - this.transform.position).normalized * -this.VarAimForce, -this.transform.up * this.offset);
                        }
                        else
                        {
                            this.GetComponent<Rigidbody>().AddForceAtPosition((this.AimPoint.transform.position - this.transform.position).normalized * this.VarAimForce, this.transform.up * this.offset);
                            this.GetComponent<Rigidbody>().AddForceAtPosition((this.AimPoint.transform.position - this.transform.position).normalized * -this.VarAimForce, -this.transform.up * this.offset);
                        }
                    }
                    else
                    {
                        if (this.UseAimPoint)
                        {
                            this.RelPoint = this.transform.InverseTransformPoint(this.AimPoint.transform.position);
                            this.Vert = Mathf.Clamp((-this.RelPoint.z * this.VarAimForce) / this.Dist, -128, 128);
                            this.Hori = Mathf.Clamp((this.RelPoint.x * this.VarAimForce) / this.Dist, -128, 128);
                        }
                        else
                        {
                            this.RelPoint = this.transform.InverseTransformPoint(this.AimTarget.transform.position);
                            this.Vert = -this.RelPoint.z * this.VarAimForce;
                            this.Hori = this.RelPoint.x * this.VarAimForce;
                        }

                        {
                            float _3688 = this.Vert;
                            JointMotor _3689 = this.ElevationJoint.motor;
                            _3689.targetVelocity = _3688;
                            this.ElevationJoint.motor = _3689;
                        }

                        {
                            float _3690 = this.Hori;
                            JointMotor _3691 = this.TraverseJoint.motor;
                            _3691.targetVelocity = _3690;
                            this.TraverseJoint.motor = _3691;
                        }
                    }
                }
                else
                {
                    if (!this.HingeAim)
                    {
                        this.GetComponent<Rigidbody>().AddForceAtPosition((this.AimPos - this.transform.position).normalized * this.VarAimForce, this.transform.up * this.offset);
                        this.GetComponent<Rigidbody>().AddForceAtPosition((this.AimPos - this.transform.position).normalized * -this.VarAimForce, -this.transform.up * this.offset);
                    }
                    else
                    {
                        this.RelPoint = this.transform.InverseTransformPoint(this.AimPos);
                        this.Vert = -this.RelPoint.z * this.VarAimForce;
                        this.Hori = this.RelPoint.x * this.VarAimForce;

                        {
                            float _3692 = this.Vert;
                            JointMotor _3693 = this.ElevationJoint.motor;
                            _3693.targetVelocity = _3692;
                            this.ElevationJoint.motor = _3693;
                        }

                        {
                            float _3694 = this.Hori;
                            JointMotor _3695 = this.TraverseJoint.motor;
                            _3695.targetVelocity = _3694;
                            this.TraverseJoint.motor = _3695;
                        }
                    }
                }
            }
            if (this.Aiming && this.ZAxis)
            {
                if (!this.HingeAim)
                {
                    if (!this.UseAimPoint)
                    {
                        this.GetComponent<Rigidbody>().AddForceAtPosition((this.AimTarget.transform.position - this.transform.position).normalized * this.VarAimForce, this.transform.up * this.offset);
                        this.GetComponent<Rigidbody>().AddForceAtPosition((this.AimTarget.transform.position - this.transform.position).normalized * -this.VarAimForce, -this.transform.up * this.offset);
                    }
                    else
                    {
                        this.GetComponent<Rigidbody>().AddForceAtPosition((this.AimPoint.transform.position - this.transform.position).normalized * this.VarAimForce, this.transform.up * this.offset);
                        this.GetComponent<Rigidbody>().AddForceAtPosition((this.AimPoint.transform.position - this.transform.position).normalized * -this.VarAimForce, -this.transform.up * this.offset);
                    }
                }
                else
                {
                    if (this.UseAimPoint)
                    {
                        this.RelPoint = this.transform.InverseTransformPoint(this.AimPoint.transform.position);
                        this.Vert = Mathf.Clamp((-this.RelPoint.z * this.VarAimForce) / this.Dist, -128, 128);
                        this.Hori = Mathf.Clamp((this.RelPoint.x * this.VarAimForce) / this.Dist, -128, 128);
                    }
                    else
                    {
                        this.RelPoint = this.transform.InverseTransformPoint(this.AimTarget.transform.position);
                        this.Vert = -this.RelPoint.z * this.VarAimForce;
                        this.Hori = this.RelPoint.x * this.VarAimForce;
                    }

                    {
                        float _3696 = this.Vert;
                        JointMotor _3697 = this.ElevationJoint.motor;
                        _3697.targetVelocity = _3696;
                        this.ElevationJoint.motor = _3697;
                    }

                    {
                        float _3698 = this.Hori;
                        JointMotor _3699 = this.TraverseJoint.motor;
                        _3699.targetVelocity = _3698;
                        this.TraverseJoint.motor = _3699;
                    }
                }
            }
        }
        else
        {
            if (this.UseAimPoint)
            {
                this.Dist = Vector3.Distance(this.transform.position, this.AimForward.transform.position);
                this.RelPoint = this.transform.InverseTransformPoint(this.AimForward.transform.position);
                this.Vert = Mathf.Clamp((-this.RelPoint.z * this.VarAimForce) / this.Dist, -128, 128);
                this.Hori = Mathf.Clamp((this.RelPoint.x * this.VarAimForce) / this.Dist, -128, 128);
            }
            else
            {
                this.RelPoint = this.transform.InverseTransformPoint(this.AimForward.transform.position);
                this.Vert = -this.RelPoint.z * this.VarAimForce;
                this.Hori = this.RelPoint.x * this.VarAimForce;
            }
            if (this.GetComponent<Rigidbody>().angularVelocity.magnitude < this.AimSpeed)
            {
                this.VarAimForce = this.AimForce;
            }
            else
            {
                this.VarAimForce = 0;
                if (this.HingeAim)
                {

                    {
                        int _3700 = 0;
                        JointMotor _3701 = this.ElevationJoint.motor;
                        _3701.targetVelocity = _3700;
                        this.ElevationJoint.motor = _3701;
                    }

                    {
                        int _3702 = 0;
                        JointMotor _3703 = this.TraverseJoint.motor;
                        _3703.targetVelocity = _3702;
                        this.TraverseJoint.motor = _3703;
                    }
                }
            }
            if (!this.HingeAim)
            {
                this.GetComponent<Rigidbody>().AddForceAtPosition((this.AimForward.transform.position - this.transform.position).normalized * this.VarAimForce, this.transform.up * this.offset);
                this.GetComponent<Rigidbody>().AddForceAtPosition((this.AimForward.transform.position - this.transform.position).normalized * -this.VarAimForce, -this.transform.up * this.offset);
            }
            else
            {
                this.RelPoint = this.transform.InverseTransformPoint(this.AimForward.transform.position);
                this.Vert = Mathf.Clamp((-this.RelPoint.z * this.VarAimForce) / this.Dist, -128, 128);
                this.Hori = Mathf.Clamp((this.RelPoint.x * this.VarAimForce) / this.Dist, -128, 128);

                {
                    float _3704 = this.Vert;
                    JointMotor _3705 = this.ElevationJoint.motor;
                    _3705.targetVelocity = _3704;
                    this.ElevationJoint.motor = _3705;
                }

                {
                    float _3706 = this.Hori;
                    JointMotor _3707 = this.TraverseJoint.motor;
                    _3707.targetVelocity = _3706;
                    this.TraverseJoint.motor = _3707;
                }
            }
        }
    }

    public virtual void Tick()
    {
        if (this.Activated)
        {
            if (WorldInformation.playerCar.Contains(this.MainVessel.name))
            {
                this.GetComponent<Rigidbody>().centerOfMass = new Vector3(0, 0, 0);
                if ((this.GetComponent<Rigidbody>().velocity.magnitude > 3) && !this.AimLocked)
                {
                    this.Reset = true;
                }
            }
        }
        else
        {
            this.Reset = true;
        }
    }

    public TurretAim()
    {
        this.AimForce = 10f;
        this.AimSpeed = 2f;
        this.AimForceOriginalDamp = 0.05f;
        this.offset = 1f;
        this.Dist = 2;
        this.Activated = true;
        this.StabForce = 1f;
    }

}