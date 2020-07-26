using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SubduerMissileAI : MonoBehaviour
{
    public Transform target;
    public Transform thisTransform;
    public Rigidbody thisRB;
    public Transform thrusterTransform;
    public Rigidbody thrusterRB;
    public Transform RayOrigin1;
    public Transform RayOrigin2;
    public Transform RayOrigin3;
    public Transform RayOrigin4;
    public AudioSource SFX;
    public AudioSource SFX2;
    public ParticleSystem FX1;
    public ParticleSystem FX2;
    public Transform Claw1;
    public Transform Claw2;
    public Transform Claw3;
    public SpringJoint thrusterAngJoint;
    public float Force;
    public float StartForce;
    public float AimForce;
    public float TAimForce;
    public Transform TargetTrace;
    public Transform TargetLead;
    public float LeadAmount;
    public int Lead1Time;
    public int Lead2Time;
    public float Dist1;
    public float Dist2;
    public bool isAttached;
    public bool turningOff;
    public bool turnedOff;
    public GameObject AttachNoise;
    public ConfigurableJoint theJoint;
    public Vector3 localHit;
    public Vector3 Normrot;
    public bool isRotting;
    public bool Normrotted;
    public LayerMask targetLayers;
    public LayerMask MtargetLayers;
    public virtual void Start()
    {
        this.InvokeRepeating("Ticker", 0.9f, 1.3f);
        if (AgrianNetwork.instance.SubdueTarget)
        {
            this.target = AgrianNetwork.instance.SubdueTarget;
        }
        else
        {
            this.target = PlayerInformation.instance.PiriTarget;
        }
        this.thisRB.AddForce(this.thisTransform.forward * this.StartForce);
        this.TargetTrace.parent = null;
        this.TargetLead.parent = null;
    }

    public virtual void FixedUpdate()
    {
        RaycastHit hit = default(RaycastHit);
        if (this.turnedOff)
        {
            if (this.SFX.volume > 0.1f)
            {
                this.SFX.volume = 0.1f;
            }
            else
            {
                this.SFX.volume = this.SFX.volume - 0.01f;
            }
            return;
        }
        if (this.isRotting)
        {
            this.thisTransform.rotation = Quaternion.LookRotation(-this.Normrot);
        }
        if (!this.isAttached)
        {
            this.thisRB.AddForce(this.thisTransform.forward * this.Force);
            this.thisRB.AddForceAtPosition((this.TargetLead.position - this.thisTransform.position).normalized * this.AimForce, this.thisTransform.forward * 1);
            this.thisRB.AddForceAtPosition((this.TargetLead.position - this.thisTransform.position).normalized * -this.AimForce, -this.thisTransform.forward * 1);
            if (Physics.Raycast(this.thisTransform.position, this.thisTransform.forward, out hit, 2, (int) this.targetLayers))
            {
                if (((!Physics.Raycast(this.RayOrigin1.position, this.RayOrigin1.forward, 1, (int) this.targetLayers) || !Physics.Raycast(this.RayOrigin2.position, this.RayOrigin2.forward, 1, (int) this.targetLayers)) || !Physics.Raycast(this.RayOrigin3.position, this.RayOrigin3.forward, 1, (int) this.targetLayers)) || !Physics.Raycast(this.RayOrigin4.position, this.RayOrigin4.forward, 1, (int) this.targetLayers))
                {
                    return;
                }
                this.localHit = hit.point;
                this.thisTransform.position = this.localHit;
                this.thisRB.constraints = (RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY) | RigidbodyConstraints.FreezeRotationZ;

                {
                    int _3558 = -55;
                    Vector3 _3559 = this.Claw1.localEulerAngles;
                    _3559.x = _3558;
                    this.Claw1.localEulerAngles = _3559;
                }

                {
                    int _3560 = -55;
                    Vector3 _3561 = this.Claw2.localEulerAngles;
                    _3561.x = _3560;
                    this.Claw2.localEulerAngles = _3561;
                }

                {
                    int _3562 = -55;
                    Vector3 _3563 = this.Claw3.localEulerAngles;
                    _3563.x = _3562;
                    this.Claw3.localEulerAngles = _3563;
                }
                this.isRotting = true;
                this.isAttached = true;
                this.thrusterAngJoint.maxDistance = 0.9f;
                this.thisRB.angularDrag = 1;
                this.Normrot = hit.normal;
                this.Normrotted = true;
                this.Attach(hit.rigidbody, hit.distance);
            }
        }
        else
        {
            float VelClamp = Mathf.Clamp(this.thisRB.velocity.magnitude * 0.2f, 1, 12);
            if (Physics.Raycast(this.thisTransform.position, Vector3.down, 64, (int) this.MtargetLayers))
            {
                this.thisRB.AddForce((this.thrusterTransform.forward * this.Force) * VelClamp);
                this.thrusterRB.AddForceAtPosition(this.thisRB.velocity.normalized * this.TAimForce, -this.thrusterTransform.forward * 2);
                this.thrusterRB.AddForceAtPosition(this.thisRB.velocity.normalized * -this.TAimForce, this.thrusterTransform.forward * 2);
            }
            else
            {
                this.thisRB.AddForce((this.thrusterTransform.forward * this.Force) * 12);
                this.thrusterRB.AddForceAtPosition(Vector3.up * this.TAimForce, -this.thrusterTransform.forward * 2);
                this.thrusterRB.AddForceAtPosition(-Vector3.up * this.TAimForce, this.thrusterTransform.forward * 2);
            }
        }
        if (this.Lead1Time < 1)
        {
            this.Lead1Time = 8;
            this.Lead2Time = 4;
            this.Lead1();
        }
        else
        {
            this.Lead1Time = this.Lead1Time - 1;
        }
        if (this.Lead2Time < 1)
        {
            this.Lead2Time = 8;
            this.Lead2Time = 4;
            this.Lead2();
        }
        else
        {
            this.Lead2Time = this.Lead2Time - 1;
        }
    }

    public virtual void Attach(Rigidbody hitV, float hitVDist)
    {
        this.thisTransform.position = this.localHit;
        if (this.Normrotted)
        {
            this.thisTransform.rotation = Quaternion.LookRotation(-this.Normrot);
        }
        this.theJoint = this.thisTransform.gameObject.AddComponent<ConfigurableJoint>();
        this.theJoint.connectedBody = hitV.GetComponent<Rigidbody>();

        {
            JointDriveMode _3564 = JointDriveMode.Position;
            JointDrive _3565 = this.theJoint.xDrive;
            _3565.mode = _3564;
            this.theJoint.xDrive = _3565;
        }

        {
            JointDriveMode _3566 = JointDriveMode.Position;
            JointDrive _3567 = this.theJoint.yDrive;
            _3567.mode = _3566;
            this.theJoint.yDrive = _3567;
        }

        {
            JointDriveMode _3568 = JointDriveMode.Position;
            JointDrive _3569 = this.theJoint.zDrive;
            _3569.mode = _3568;
            this.theJoint.zDrive = _3569;
        }

        {
            JointDriveMode _3570 = JointDriveMode.Position;
            JointDrive _3571 = this.theJoint.angularXDrive;
            _3571.mode = _3570;
            this.theJoint.angularXDrive = _3571;
        }

        {
            JointDriveMode _3572 = JointDriveMode.Position;
            JointDrive _3573 = this.theJoint.angularYZDrive;
            _3573.mode = _3572;
            this.theJoint.angularYZDrive = _3573;
        }

        {
            int _3574 = 10000;
            JointDrive _3575 = this.theJoint.xDrive;
            _3575.positionSpring = _3574;
            this.theJoint.xDrive = _3575;
        }

        {
            int _3576 = 10000;
            JointDrive _3577 = this.theJoint.yDrive;
            _3577.positionSpring = _3576;
            this.theJoint.yDrive = _3577;
        }

        {
            int _3578 = 10000;
            JointDrive _3579 = this.theJoint.zDrive;
            _3579.positionSpring = _3578;
            this.theJoint.zDrive = _3579;
        }

        {
            int _3580 = 10000;
            JointDrive _3581 = this.theJoint.angularXDrive;
            _3581.positionSpring = _3580;
            this.theJoint.angularXDrive = _3581;
        }

        {
            int _3582 = 10000;
            JointDrive _3583 = this.theJoint.angularYZDrive;
            _3583.positionSpring = _3582;
            this.theJoint.angularYZDrive = _3583;
        }

        {
            int _3584 = 1;
            JointDrive _3585 = this.theJoint.xDrive;
            _3585.positionDamper = _3584;
            this.theJoint.xDrive = _3585;
        }

        {
            int _3586 = 1;
            JointDrive _3587 = this.theJoint.yDrive;
            _3587.positionDamper = _3586;
            this.theJoint.yDrive = _3587;
        }

        {
            int _3588 = 1;
            JointDrive _3589 = this.theJoint.zDrive;
            _3589.positionDamper = _3588;
            this.theJoint.zDrive = _3589;
        }

        {
            int _3590 = 1;
            JointDrive _3591 = this.theJoint.angularXDrive;
            _3591.positionDamper = _3590;
            this.theJoint.angularXDrive = _3591;
        }

        {
            int _3592 = 1;
            JointDrive _3593 = this.theJoint.angularYZDrive;
            _3593.positionDamper = _3592;
            this.theJoint.angularYZDrive = _3593;
        }
        this.theJoint.targetPosition = new Vector3(0, 0, 0.75f);
        this.gameObject.layer = 23;
        GameObject TheThing2 = UnityEngine.Object.Instantiate(this.AttachNoise, this.thisTransform.position, this.thisTransform.rotation);
        TheThing2.transform.parent = this.thisTransform;
        this.thisTransform.position = this.localHit;
        if (this.Normrotted)
        {
            this.thisTransform.rotation = Quaternion.LookRotation(-this.Normrot);
        }
        this.Rotting();
    }

    public virtual void Rotting()
    {
        this.thisRB.constraints = RigidbodyConstraints.None;
        this.thisRB.useGravity = true;
        this.isRotting = false;
        AgrianNetwork.TargetSubdual = AgrianNetwork.TargetSubdual + 1;
    }

    public virtual void Lead1()
    {
        if (this.target)
        {
            this.TargetTrace.position = this.target.position;
        }
    }

    public virtual void Lead2()
    {
        if (this.target)
        {
            this.Dist1 = Vector3.Distance(this.TargetTrace.position, this.target.position);
            this.TargetTrace.LookAt(this.target);
            this.TargetLead.position = this.TargetTrace.position;
            this.TargetLead.rotation = this.TargetTrace.rotation;
            this.TargetLead.position = this.TargetLead.position + ((this.TargetLead.forward * this.Dist1) * this.LeadAmount);
        }
    }

    public virtual void Ticker()
    {
        if (this.target)
        {
            if (this.target.name.Contains("rok"))
            {
                if (!this.turningOff)
                {
                    this.turningOff = true;
                    this.StartCoroutine(this.TurnOff());
                }
            }
        }
    }

    public virtual IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(5);
        //TargetSubdual = 0;
        AgrianNetwork.TargetSubdual = 0;
        this.turnedOff = true;
        this.FX1.Stop();
        this.FX2.Stop();
        this.SFX2.Play();
        this.thisRB.useGravity = true;
        this.thisRB.drag = 0.1f;
        this.thisRB.angularDrag = 0.1f;
    }

    public SubduerMissileAI()
    {
        this.LeadAmount = 0.08f;
    }

}