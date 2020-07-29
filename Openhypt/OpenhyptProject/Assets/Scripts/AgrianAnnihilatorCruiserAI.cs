using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AgrianAnnihilatorCruiserAI : MonoBehaviour
{
    public Transform target;
    public Transform Waypoint;
    public Transform Forward;
    public Transform viewPoint;
    public Transform AIAnchor;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public HingeJoint TPivot1HJ;
    public HingeJoint TPivot2HJ;
    public HingeJoint TPivot3HJ;
    public HingeJoint TPivot4HJ;
    public int TPivot1HJTP;
    public int TPivot2HJTP;
    public int TPivot3HJTP;
    public int TPivot4HJTP;
    public Transform Turret1TF;
    public Transform Turret2TF;
    public Transform Turret3TF;
    public Transform Turret4TF;
    public HingeJoint T1ElevationJoint;
    public HingeJoint T2ElevationJoint;
    public HingeJoint T3ElevationJoint;
    public HingeJoint T4ElevationJoint;
    public HingeJoint T1TraverseJoint;
    public HingeJoint T2TraverseJoint;
    public HingeJoint T3TraverseJoint;
    public HingeJoint T4TraverseJoint;
    public Transform Muzzle1;
    public Transform Muzzle2;
    public Transform Muzzle3;
    public Transform Muzzle4;
    public Transform Gun1Model;
    public Transform Gun2Model;
    public Transform Gun3Model;
    public Transform Gun4Model;
    public bool Gun1Fire;
    public bool Gun2Fire;
    public bool Gun3Fire;
    public bool Gun4Fire;
    public int G1RN;
    public int G2RN;
    public int G3RN;
    public int G4RN;
    public AnimationCurve RecoilCurve;
    public GameObject Bomb;
    public Transform MuzzleB;
    public GameObject BombModel;
    public GameObject BombGateSFX;
    public Transform BombGateTF;
    public bool LaunchingBomb;
    public int BombLaunchTimer;
    public HingeJoint BombLauncherHJ;
    public int BombLauncherHJTP;
    public Transform VPoint;
    public int AimForce;
    public int TurnForce;
    public int DirForce;
    public int RayDist;
    public int TorqueForce;
    public GameObject PropelEffect;
    public GameObject RayBurst;
    public GameObject LastPos;
    public float Dist;
    public float velMag;
    public int Anger;
    public bool inView;
    public bool Attacking;
    public bool Obstacle;
    public bool Floorstacle;
    public bool Still;
    public bool TurnLeft;
    public bool TurnRight;
    public int SD;
    public int SDf;
    public int SDl;
    public int SDr;
    public int SDa;
    public int SD2;
    public int SD2f;
    public int SD2l;
    public int SD2r;
    public int SD2a;
    public float FAndB;
    public float LAndR;
    public float UAndD;
    public float RightDist;
    public float LeftDist;
    public bool StrafeLeft;
    public bool StrafeRight;
    public bool OnHull;
    public int StillOnHull;
    public int PissedAtTC0a;
    public int PissedAtTC1;
    public int PissedAtTC3;
    public int PissedAtTC4;
    public int PissedAtTC5;
    public int PissedAtTC6;
    public int PissedAtTC7;
    public int PissedAtTC8;
    public int PissedAtTC9;
    public bool FoundSmall;
    public bool FoundMedium;
    public bool FoundBig;
    public bool ExecuteTC1;
    public bool ExecuteTC4;
    public bool ExecuteTC6;
    public bool ExecuteTC7;
    public bool ExecuteTC8;
    public bool ExecuteTC9;
    public LayerMask targetLayers;
    public LayerMask targetLayers2;
    public LayerMask MtargetLayers;
    public Vector3 DangerDirection;
    public int DangerSense;
    public int Pursuit;
    public float RayBurstTime;
    public bool Damaged;
    public virtual void Start()
    {
        this.InvokeRepeating("Counter", 1, 1);
        this.InvokeRepeating("LeaveMarker", 3, 3);
        this.InvokeRepeating("Shooty", 1, 0.8f);
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        if (this.Damaged)
        {
            return;
        }
        Vector3 localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
        this.velMag = this.vRigidbody.velocity.magnitude;
        float Vel = -localV.y * 5;
        if (this.target)
        {
            this.Dist = Vector3.Distance(this.thisTransform.position, this.target.position);
        }
        else
        {
            this.Dist = 64;
        }
        float VelClamp = Mathf.Clamp(Vel, 100, 1000);
        float VelPlus = VelClamp + 100;
        Vector3 newRot = (this.VPoint.forward * 0.6f).normalized;
        Debug.DrawRay((this.VPoint.position + (this.VPoint.forward * 40)) + (this.VPoint.right * this.RayDist), this.VPoint.forward * VelClamp, Color.red);
        Debug.DrawRay((this.VPoint.position + (this.VPoint.forward * 40)) + (-this.VPoint.right * this.RayDist), this.VPoint.forward * VelClamp, Color.red);
        if (Physics.Raycast((this.VPoint.position + (this.VPoint.forward * 40)) + (this.VPoint.right * this.RayDist), this.VPoint.forward, VelClamp, (int) this.targetLayers) || Physics.Raycast((this.VPoint.position + (this.VPoint.forward * 40)) + (-this.VPoint.right * this.RayDist), this.VPoint.forward, VelClamp, (int) this.targetLayers))
        {
            this.Obstacle = true;
        }
        Debug.DrawRay(((this.VPoint.position + (this.VPoint.forward * 18)) + (-this.VPoint.up * 8)) + (this.VPoint.right * this.RayDist), this.VPoint.forward * VelPlus, Color.black);
        if (Physics.Raycast(((this.VPoint.position + (this.VPoint.forward * 18)) + (-this.VPoint.up * 8)) + (this.VPoint.right * this.RayDist), this.VPoint.forward, out hit, VelPlus, (int) this.targetLayers))
        {
            this.TurnLeft = true;
            this.RightDist = hit.distance;
        }
        else
        {
            this.RightDist = 512;
        }
        Debug.DrawRay(((this.VPoint.position + (this.VPoint.forward * 18)) + (-this.VPoint.up * 8)) + (-this.VPoint.right * this.RayDist), this.VPoint.forward * VelPlus, Color.black);
        if (Physics.Raycast(((this.VPoint.position + (this.VPoint.forward * 18)) + (-this.VPoint.up * 8)) + (-this.VPoint.right * this.RayDist), this.VPoint.forward, out hit, VelPlus, (int) this.targetLayers))
        {
            this.TurnRight = true;
            this.LeftDist = hit.distance;
        }
        else
        {
            this.LeftDist = 512;
        }
        if (this.RightDist > this.LeftDist)
        {
            this.TurnLeft = false;
            this.TurnRight = true;
        }
        if (this.LeftDist > this.RightDist)
        {
            this.TurnRight = false;
            this.TurnLeft = true;
        }
        newRot = (-this.VPoint.up * 0.6f).normalized;
        Debug.DrawRay(this.VPoint.position + (this.VPoint.forward * 70), newRot * 50, Color.blue);
        Debug.DrawRay(this.VPoint.position, newRot * 50f, Color.blue);
        if (Physics.Raycast(this.VPoint.position + (this.VPoint.forward * 70), newRot, 50, (int) this.targetLayers) || Physics.Raycast(this.VPoint.position, newRot, 50, (int) this.targetLayers))
        {
            if (this.velMag > 50)
            {
                this.Floorstacle = true;
            }
        }
        else
        {
            this.Floorstacle = false;
        }
    }

    private Quaternion NewRotation;
    public virtual void FixedUpdate()
    {
        if (this.Damaged)
        {
            this.vRigidbody.AddTorque(-this.thisVTransform.forward * 8000000);
            return;
        }
        this.thisTransform.rotation = this.AIAnchor.transform.rotation;
        this.thisTransform.position = this.AIAnchor.transform.position;
        if (this.target)
        {
            Vector3 relativePoint = this.thisVTransform.InverseTransformPoint(this.target.position);
        this.LAndR = relativePoint.x;
        this.FAndB = relativePoint.y;
        this.UAndD = relativePoint.z;
        }
        Vector3 localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
        if (this.RayDist < 50)
        {
            this.RayDist = this.RayDist + 2;
        }
        if (this.RayDist == 50)
        {
            this.RayDist = 2;
        }
        if (this.target)
        {
            if ((!this.TurnLeft && !this.TurnRight) && !this.Obstacle)
            {
                if (this.Dist > 500)
                {
                    if (this.vRigidbody.angularVelocity.magnitude < 0.5f)
                    {
                        this.vRigidbody.AddForceAtPosition((this.target.position - this.thisVTransform.position).normalized * this.TurnForce, -this.thisVTransform.up * 50);
                        this.vRigidbody.AddForceAtPosition((this.target.position - this.thisVTransform.position).normalized * -this.TurnForce, this.thisVTransform.up * 50);
                    }
                }
            }
            Vector3 RelPoint1 = this.Turret1TF.InverseTransformPoint(this.target.position);
            Vector3 RelPoint2 = this.Turret2TF.InverseTransformPoint(this.target.position);
            Vector3 RelPoint3 = this.Turret3TF.InverseTransformPoint(this.target.position);
            Vector3 RelPoint4 = this.Turret4TF.InverseTransformPoint(this.target.position);
            if (this.Attacking)
            {
                float Vert = Mathf.Clamp((-RelPoint1.z * this.AimForce) / this.Dist, -64, 64);
                float Hori = Mathf.Clamp((RelPoint1.x * this.AimForce) / this.Dist, -64, 64);

                {
                    float _488 = Vert;
                    JointMotor _489 = this.T1ElevationJoint.motor;
                    _489.targetVelocity = _488;
                    this.T1ElevationJoint.motor = _489;
                }

                {
                    float _490 = Hori;
                    JointMotor _491 = this.T1TraverseJoint.motor;
                    _491.targetVelocity = _490;
                    this.T1TraverseJoint.motor = _491;
                }
                Vert = Mathf.Clamp((-RelPoint2.z * this.AimForce) / this.Dist, -64, 64);
                Hori = Mathf.Clamp((RelPoint2.x * this.AimForce) / this.Dist, -64, 64);

                {
                    float _492 = Vert;
                    JointMotor _493 = this.T2ElevationJoint.motor;
                    _493.targetVelocity = _492;
                    this.T2ElevationJoint.motor = _493;
                }

                {
                    float _494 = Hori;
                    JointMotor _495 = this.T2TraverseJoint.motor;
                    _495.targetVelocity = _494;
                    this.T2TraverseJoint.motor = _495;
                }
                Vert = Mathf.Clamp((-RelPoint3.z * this.AimForce) / this.Dist, -64, 64);
                Hori = Mathf.Clamp((RelPoint3.x * this.AimForce) / this.Dist, -64, 64);

                {
                    float _496 = Vert;
                    JointMotor _497 = this.T3ElevationJoint.motor;
                    _497.targetVelocity = _496;
                    this.T3ElevationJoint.motor = _497;
                }

                {
                    float _498 = Hori;
                    JointMotor _499 = this.T3TraverseJoint.motor;
                    _499.targetVelocity = _498;
                    this.T3TraverseJoint.motor = _499;
                }
                Vert = Mathf.Clamp((-RelPoint4.z * this.AimForce) / this.Dist, -64, 64);
                Hori = Mathf.Clamp((RelPoint4.x * this.AimForce) / this.Dist, -64, 64);

                {
                    float _500 = Vert;
                    JointMotor _501 = this.T4ElevationJoint.motor;
                    _501.targetVelocity = _500;
                    this.T4ElevationJoint.motor = _501;
                }

                {
                    float _502 = Hori;
                    JointMotor _503 = this.T4TraverseJoint.motor;
                    _503.targetVelocity = _502;
                    this.T4TraverseJoint.motor = _503;
                }
            }
            else
            {
                RelPoint1 = this.Turret1TF.InverseTransformPoint(this.Forward.position);
                float Vert = Mathf.Clamp(-RelPoint1.z, -64, 64);
                float Hori = Mathf.Clamp(RelPoint1.x, -64, 64);

                {
                    float _504 = Vert;
                    JointMotor _505 = this.T1ElevationJoint.motor;
                    _505.targetVelocity = _504;
                    this.T1ElevationJoint.motor = _505;
                }

                {
                    float _506 = Hori;
                    JointMotor _507 = this.T1TraverseJoint.motor;
                    _507.targetVelocity = _506;
                    this.T1TraverseJoint.motor = _507;
                }
                RelPoint2 = this.Turret2TF.InverseTransformPoint(this.Forward.position);
                Vert = Mathf.Clamp(-RelPoint2.z, -64, 64);
                Hori = Mathf.Clamp(RelPoint2.x, -64, 64);

                {
                    float _508 = Vert;
                    JointMotor _509 = this.T2ElevationJoint.motor;
                    _509.targetVelocity = _508;
                    this.T2ElevationJoint.motor = _509;
                }

                {
                    float _510 = Hori;
                    JointMotor _511 = this.T2TraverseJoint.motor;
                    _511.targetVelocity = _510;
                    this.T2TraverseJoint.motor = _511;
                }
                RelPoint3 = this.Turret3TF.InverseTransformPoint(this.Forward.position);
                Vert = Mathf.Clamp(-RelPoint3.z, -64, 64);
                Hori = Mathf.Clamp(RelPoint3.x, -64, 64);

                {
                    float _512 = Vert;
                    JointMotor _513 = this.T3ElevationJoint.motor;
                    _513.targetVelocity = _512;
                    this.T3ElevationJoint.motor = _513;
                }

                {
                    float _514 = Hori;
                    JointMotor _515 = this.T3TraverseJoint.motor;
                    _515.targetVelocity = _514;
                    this.T3TraverseJoint.motor = _515;
                }
                RelPoint4 = this.Turret4TF.InverseTransformPoint(this.Forward.position);
                Vert = Mathf.Clamp(-RelPoint4.z, -64, 64);
                Hori = Mathf.Clamp(RelPoint4.x, -64, 64);

                {
                    float _516 = Vert;
                    JointMotor _517 = this.T4ElevationJoint.motor;
                    _517.targetVelocity = _516;
                    this.T4ElevationJoint.motor = _517;
                }

                {
                    float _518 = Hori;
                    JointMotor _519 = this.T4TraverseJoint.motor;
                    _519.targetVelocity = _518;
                    this.T4TraverseJoint.motor = _519;
                }
            }
        }
        if ((this.DangerSense < 1) && (this.target != null))
        {
            this.NewRotation = Quaternion.LookRotation(this.target.position - this.thisTransform.position);
            this.thisTransform.rotation = Quaternion.RotateTowards(this.thisTransform.rotation, this.NewRotation, Time.deltaTime * 200);
        }
        if ((this.DangerSense > 0) && (this.DangerDirection != Vector3.zero))
        {
            this.NewRotation = Quaternion.LookRotation(this.DangerDirection);
            this.thisTransform.rotation = Quaternion.RotateTowards(this.thisTransform.rotation, this.NewRotation, 1000000);
        }
        if (this.target)
        {
            if (!this.Obstacle && !this.Still)
            {
                if (this.Anger > 50)
                {
                    if (this.Pursuit < 4)
                    {
                        if (this.Dist < 400)
                        {
                            this.DirForce = 200000;
                            this.TurnForce = 2400000;
                            if (-this.FAndB > 300)
                            {
                                if (-localV.y < 80)
                                {
                                    this.vRigidbody.AddForce(-this.thisVTransform.up * this.DirForce);
                                }
                            }
                            else
                            {
                                if (this.inView)
                                {
                                    if (-this.FAndB < 100)
                                    {
                                        if (localV.y < 80)
                                        {
                                            this.vRigidbody.AddForce(this.thisVTransform.up * this.DirForce);
                                        }
                                    }
                                    else
                                    {
                                        this.vRigidbody.AddForce((this.thisVTransform.up * -localV.y) * 20000);
                                    }
                                }
                                else
                                {
                                    if (-localV.y < 80)
                                    {
                                        this.vRigidbody.AddForce(-this.thisVTransform.up * this.DirForce);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (this.vRigidbody.angularVelocity.magnitude < 0.02f)
                            {
                                if (-this.FAndB > 600)
                                {
                                    if (-localV.y < 2000)
                                    {
                                        if (this.DirForce < 16000000)
                                        {
                                            this.DirForce = this.DirForce + 100000;
                                        }
                                        this.vRigidbody.AddForce(-this.thisVTransform.up * this.DirForce);
                                    }
                                }
                            }
                            //Debug.Log(FAndB);
                            //Debug.Break();
                            this.TurnForce = 2400000;
                        }
                        if (-this.FAndB < 500)
                        {
                            if (-localV.y > 100)
                            {
                                this.vRigidbody.AddForce(-this.thisVTransform.up * -24000000);
                            }
                        }
                    }
                    else
                    {
                        if (this.Dist < 150)
                        {
                            this.vRigidbody.AddForce((this.thisVTransform.up * -localV.y) * 20000);
                        }
                        if (this.Dist > 100)
                        {
                            if (-localV.y < 360)
                            {
                                this.vRigidbody.AddForce(-this.thisVTransform.up * 800000);
                            }
                        }
                        if (this.Dist < 300)
                        {
                            if (this.FAndB > 0)
                            {
                                if (-localV.y > 160)
                                {
                                    this.vRigidbody.AddForce(-this.thisVTransform.up * -24000000);
                                }
                            }
                        }
                    }
                    if (this.UAndD > 0)
                    {
                        this.vRigidbody.AddForce(this.thisVTransform.forward * 400000);
                    }
                }
                else
                {
                    if (this.Dist < 100)
                    {
                        if (localV.y < 80)
                        {
                            this.vRigidbody.AddForce(-this.thisVTransform.up * -200000);
                        }
                    }
                    if (this.Dist > 150)
                    {
                        if (-localV.y < 80)
                        {
                            this.vRigidbody.AddForce(-this.thisVTransform.up * 200000);
                        }
                    }
                }
            }
        }
        if (this.Floorstacle)
        {
            if (this.Pursuit < 4)
            {
                this.vRigidbody.AddTorque(-this.thisVTransform.right * 16000000);
            }
            else
            {
                this.vRigidbody.AddTorque(-this.thisVTransform.right * 32000000);
            }
        }
        if (this.Obstacle)
        {
            if (-localV.y > 25)
            {
                this.vRigidbody.AddForce((-this.thisVTransform.up * 30000) * localV.y);
            }
            if (this.TurnLeft || this.TurnRight)
            {
                this.vRigidbody.AddForce(-this.thisVTransform.up * 80000);
            }
        }
        if (this.Still)
        {
            if (this.Attacking)
            {
                if (!this.inView)
                {
                    if (!this.LaunchingBomb && (this.BombLaunchTimer == 0))
                    {
                        if (this.target)
                        {
                            if ((this.target.name.Contains("TC") && (this.UAndD < 0)) && (this.velMag < 250))
                            {
                                this.BombModel.SetActive(true);
                                this.BombLaunchTimer = 7;
                                this.LaunchingBomb = true;
                                this.StartCoroutine(this.LaunchBomb());
                            }
                        }
                    }
                }
            }
        }
        else
        {
            Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * 150)) + (-this.thisTransform.up * 10), this.thisTransform.right * 150, Color.green);
            Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * 150)) + (-this.thisTransform.up * 10), -this.thisTransform.right * 150, Color.green);
            if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * 150)) + (-this.thisTransform.up * 10), this.thisTransform.right, 150, (int) this.MtargetLayers))
            {
                this.vRigidbody.AddTorque(this.thisVTransform.forward * -16000000);
                this.Obstacle = true;
            }
            if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * 150)) + (-this.thisTransform.up * 10), -this.thisTransform.right, 150, (int) this.MtargetLayers))
            {
                this.vRigidbody.AddTorque(this.thisVTransform.forward * 16000000);
                this.Obstacle = true;
            }
            if (this.TurnRight && !this.TurnLeft)
            {
                this.vRigidbody.AddTorque(-this.thisVTransform.forward * -16000000);
                this.vRigidbody.AddForce(this.thisVTransform.right * 160000);
            }
            if (this.TurnLeft && !this.TurnRight)
            {
                this.vRigidbody.AddTorque(-this.thisVTransform.forward * 16000000);
                this.vRigidbody.AddForce(this.thisVTransform.right * -160000);
            }
            if (this.TurnLeft && this.TurnRight)
            {
                this.vRigidbody.AddTorque(-this.thisVTransform.forward * -16000000);
                this.vRigidbody.AddForce(this.thisVTransform.right * 160000);
            }
            if (this.Attacking)
            {
                if (!this.LaunchingBomb && (this.BombLaunchTimer == 0))
                {
                    if (this.target)
                    {
                        if ((this.target.name.Contains("xb") && (this.UAndD < 0)) && (this.velMag < 250))
                        {
                            this.BombModel.SetActive(true);
                            this.BombLaunchTimer = 7;
                            this.LaunchingBomb = true;
                            this.StartCoroutine(this.LaunchBomb());
                        }
                    }
                }
            }
        }
        if (this.target)
        {
            if (this.OnHull && this.target.name.Contains("TC"))
            {
                this.vRigidbody.AddTorque(-this.thisVTransform.up * 16000000);
            }
        }
        if ((((!this.TurnLeft && !this.TurnRight) && !this.Obstacle) && !this.StrafeLeft) && !this.StrafeRight)
        {
            if (this.LAndR < -1)
            {
                this.vRigidbody.AddTorque(this.thisVTransform.forward * this.TorqueForce);
            }
            if (this.LAndR > 1)
            {
                this.vRigidbody.AddTorque(this.thisVTransform.forward * -this.TorqueForce);
            }
        }
        if (this.Anger > 100)
        {
            if (this.TPivot1HJTP < 90)
            {
                this.TPivot1HJTP = this.TPivot1HJTP + 1;
            }
            if (this.TPivot2HJTP < 90)
            {
                this.TPivot2HJTP = this.TPivot2HJTP + 1;
            }
            if (this.TPivot3HJTP < 90)
            {
                this.TPivot3HJTP = this.TPivot3HJTP + 1;
            }
            if (this.TPivot4HJTP < 90)
            {
                this.TPivot4HJTP = this.TPivot4HJTP + 1;
            }
            if (this.TPivot1HJTP > 89)
            {
                this.TPivot1HJTP = 90;
                this.Attacking = true;
            }
        }
        else
        {
            if (this.TPivot1HJTP > 0)
            {
                this.TPivot1HJTP = this.TPivot1HJTP - 1;
            }
            if (this.TPivot2HJTP > 0)
            {
                this.TPivot2HJTP = this.TPivot2HJTP - 1;
            }
            if (this.TPivot3HJTP > 0)
            {
                this.TPivot3HJTP = this.TPivot3HJTP - 1;
            }
            if (this.TPivot4HJTP > 0)
            {
                this.TPivot4HJTP = this.TPivot4HJTP - 1;
            }
            if (this.TPivot1HJTP < 89)
            {
                this.Attacking = false;
            }
        }
        if (this.LaunchingBomb)
        {
            if (this.BombLauncherHJTP < 22)
            {
                this.BombLauncherHJTP = this.BombLauncherHJTP + 1;
            }
        }
        else
        {
            if (this.BombLauncherHJTP > 0)
            {
                this.BombLauncherHJTP = this.BombLauncherHJTP - 1;
            }
        }

        {
            int _520 = -this.BombLauncherHJTP;
            JointSpring _521 = this.BombLauncherHJ.spring;
            _521.targetPosition = _520;
            this.BombLauncherHJ.spring = _521;
        }

        {
            int _522 = -this.TPivot1HJTP;
            JointSpring _523 = this.TPivot1HJ.spring;
            _523.targetPosition = _522;
            this.TPivot1HJ.spring = _523;
        }

        {
            int _524 = -this.TPivot2HJTP;
            JointSpring _525 = this.TPivot2HJ.spring;
            _525.targetPosition = _524;
            this.TPivot2HJ.spring = _525;
        }

        {
            int _526 = -this.TPivot3HJTP;
            JointSpring _527 = this.TPivot3HJ.spring;
            _527.targetPosition = _526;
            this.TPivot3HJ.spring = _527;
        }

        {
            int _528 = -this.TPivot4HJTP;
            JointSpring _529 = this.TPivot4HJ.spring;
            _529.targetPosition = _528;
            this.TPivot4HJ.spring = _529;
        }
        if (this.Gun1Fire)
        {
            this.G1RN = this.G1RN + 1;
            if (this.G1RN > 40)
            {
                this.G1RN = 0;
                this.Gun1Fire = false;
            }

            {
                float _530 = this.RecoilCurve.Evaluate(this.G1RN);
                Vector3 _531 = this.Gun1Model.localPosition;
                _531.y = _530;
                this.Gun1Model.localPosition = _531;
            }
        }
        if (this.Gun2Fire)
        {
            this.G2RN = this.G2RN + 1;
            if (this.G2RN > 40)
            {
                this.G2RN = 0;
                this.Gun2Fire = false;
            }

            {
                float _532 = this.RecoilCurve.Evaluate(this.G2RN);
                Vector3 _533 = this.Gun2Model.localPosition;
                _533.y = _532;
                this.Gun2Model.localPosition = _533;
            }
        }
        if (this.Gun3Fire)
        {
            this.G3RN = this.G3RN + 1;
            if (this.G3RN > 40)
            {
                this.G3RN = 0;
                this.Gun3Fire = false;
            }

            {
                float _534 = this.RecoilCurve.Evaluate(this.G3RN);
                Vector3 _535 = this.Gun3Model.localPosition;
                _535.y = _534;
                this.Gun3Model.localPosition = _535;
            }
        }
        if (this.Gun4Fire)
        {
            this.G4RN = this.G4RN + 1;
            if (this.G4RN > 40)
            {
                this.G4RN = 0;
                this.Gun4Fire = false;
            }

            {
                float _536 = this.RecoilCurve.Evaluate(this.G4RN);
                Vector3 _537 = this.Gun4Model.localPosition;
                _537.y = _536;
                this.Gun4Model.localPosition = _537;
            }
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        string ON = other.name;
        Transform OT = other.transform;
        if (Vector3.Distance(this.thisTransform.position, OT.position) < 512)
        {
            if (ON.Contains("TFC0a"))
            {
                if (this.PissedAtTC0a < 270)
                {
                    this.PissedAtTC0a = this.PissedAtTC0a + 100;
                }
            }
            if (ON.Contains("TFC1"))
            {
                if (this.PissedAtTC1 < 270)
                {
                    this.PissedAtTC1 = this.PissedAtTC1 + 100;
                }
                AgrianNetwork.TC1CriminalLevel = AgrianNetwork.TC1CriminalLevel + 10;
            }
            if (ON.Contains("TFC3"))
            {
                if (this.PissedAtTC3 < 270)
                {
                    this.PissedAtTC3 = this.PissedAtTC3 + 100;
                }
            }
            if (ON.Contains("TFC4"))
            {
                if (this.PissedAtTC4 < 270)
                {
                    this.PissedAtTC4 = this.PissedAtTC4 + 100;
                }
                AgrianNetwork.TC4CriminalLevel = AgrianNetwork.TC4CriminalLevel + 10;
            }
            if (ON.Contains("TFC5"))
            {
                if (this.PissedAtTC5 < 270)
                {
                    this.PissedAtTC5 = this.PissedAtTC5 + 100;
                }
                AgrianNetwork.TC5CriminalLevel = AgrianNetwork.TC5CriminalLevel + 10;
            }
            if (ON.Contains("TFC6"))
            {
                if (this.PissedAtTC6 < 270)
                {
                    this.PissedAtTC6 = this.PissedAtTC6 + 100;
                }
                AgrianNetwork.TC6CriminalLevel = AgrianNetwork.TC6CriminalLevel + 10;
            }
            if (ON.Contains("TFC7"))
            {
                if (this.PissedAtTC7 < 270)
                {
                    this.PissedAtTC7 = this.PissedAtTC7 + 100;
                }
                AgrianNetwork.TC7CriminalLevel = AgrianNetwork.TC7CriminalLevel + 10;
            }
            if (ON.Contains("TFC8"))
            {
                if (this.PissedAtTC8 < 270)
                {
                    this.PissedAtTC8 = this.PissedAtTC8 + 100;
                }
                AgrianNetwork.TC8CriminalLevel = AgrianNetwork.TC8CriminalLevel + 10;
            }
            if (ON.Contains("TFC9"))
            {
                if (this.PissedAtTC9 < 270)
                {
                    this.PissedAtTC9 = this.PissedAtTC9 + 100;
                }
                AgrianNetwork.TC9CriminalLevel = AgrianNetwork.TC9CriminalLevel + 10;
            }
        }
        if (other.GetComponent<Rigidbody>())
        {
            if (!ON.Contains("TFC2"))
            {
                if (ON.Contains("TFC"))
                {
                    if (this.target)
                    {
                        if (this.target.name.Contains("TC"))
                        {
                            if (this.Anger < 270)
                            {
                                this.Anger = this.Anger + 10;
                            }
                        }
                        else
                        {
                            if (this.Anger < 1)
                            {
                                if (this.DangerSense < 1)
                                {
                                    this.Anger = 60;
                                    this.DangerSense = 60;
                                    this.DangerDirection = -other.GetComponent<Rigidbody>().velocity.normalized;
                                }
                            }
                            else
                            {
                                if (this.target)
                                {
                                    if (!this.target.name.Contains("TC"))
                                    {
                                        this.Anger = 1;
                                    }
                                }
                            }
                            if (this.DangerSense > 0)
                            {
                                this.DangerSense = 60;
                                this.DangerDirection = -other.GetComponent<Rigidbody>().velocity.normalized;
                            }
                        }
                    }
                }
            }
        }
    }

    // --------------------------------------------------------------------------------------------------
    public virtual void VicinityCheck()
    {
        GameObject[] gos = null;
        gos = GameObject.FindGameObjectsWithTag("TC");
        //var Blip = Resources.Load("Prefabs/RadarBlip", GameObject) as GameObject;
        foreach (GameObject go in gos)
        {
            string ON = go.name;
            Transform OT = go.transform;
            if (ON.Contains("tTC"))
            {
                return;
            }
            if (Vector3.Distance(this.thisTransform.position, OT.position) < 6000)
            {
                if (this.target != null)
                {
                    if (ON.Contains("TC0a") && (this.PissedAtTC0a > 100))
                    {
                        if ((((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || (ON.Contains("bT") && !this.FoundBig)) || !ON.Contains("csT"))
                        {
                            this.target = OT;
                            if (this.Anger < 100)
                            {
                                this.Anger = 170;
                            }
                            this.DangerSense = 0;
                        }
                    }
                    if (ON.Contains("TC3") && (this.PissedAtTC3 > 100))
                    {
                        if ((((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || (ON.Contains("bT") && !this.FoundBig)) || !ON.Contains("csT"))
                        {
                            this.target = OT;
                            if (this.Anger < 100)
                            {
                                this.Anger = 170;
                            }
                            this.DangerSense = 0;
                        }
                    }
                    if (ON.Contains("TC6") && (this.PissedAtTC6 > 100))
                    {
                        if ((((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || (ON.Contains("bT") && !this.FoundBig)) || !ON.Contains("csT"))
                        {
                            this.target = OT;
                            if (this.Anger < 100)
                            {
                                this.Anger = 170;
                            }
                            this.DangerSense = 0;
                        }
                    }
                    if (!ON.Contains("sTC4"))
                    {
                        if (ON.Contains("TC4") && (this.PissedAtTC4 > 100))
                        {
                            if ((((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || (ON.Contains("bT") && !this.FoundBig)) || !ON.Contains("csT"))
                            {
                                this.target = OT;
                                if (this.Anger < 100)
                                {
                                    this.Anger = 170;
                                }
                                this.DangerSense = 0;
                            }
                        }
                    }
                    if (ON.Contains("TC7") && (this.PissedAtTC7 > 100))
                    {
                        if ((((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || (ON.Contains("bT") && !this.FoundBig)) || !ON.Contains("cT"))
                        {
                            this.target = OT;
                            if (this.Anger < 100)
                            {
                                this.Anger = 170;
                            }
                            this.DangerSense = 0;
                        }
                    }
                    if (ON.Contains("TC5") && (this.PissedAtTC5 > 100))
                    {
                        if ((((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || (ON.Contains("bT") && !this.FoundBig)) || !ON.Contains("csT"))
                        {
                            this.target = OT;
                            if (this.Anger < 100)
                            {
                                this.Anger = 170;
                            }
                            this.DangerSense = 0;
                        }
                    }
                    if (ON.Contains("TC1") && (this.PissedAtTC1 > 100))
                    {
                        if ((((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || (ON.Contains("bT") && !this.FoundBig)) || !ON.Contains("csT"))
                        {
                            this.target = OT;
                            if (this.Anger < 100)
                            {
                                this.Anger = 170;
                            }
                            this.DangerSense = 0;
                        }
                    }
                    if (ON.Contains("TC8") && (this.PissedAtTC8 > 100))
                    {
                        if ((((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || (ON.Contains("bT") && !this.FoundBig)) || !ON.Contains("cT"))
                        {
                            this.target = OT;
                            if (this.Anger < 100)
                            {
                                this.Anger = 170;
                            }
                            this.DangerSense = 0;
                        }
                    }
                    if (ON.Contains("TC9") && (this.PissedAtTC9 > 100))
                    {
                        if ((((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || (ON.Contains("bT") && !this.FoundBig)) || !ON.Contains("cT"))
                        {
                            this.target = OT;
                            if (this.Anger < 100)
                            {
                                this.Anger = 170;
                            }
                            this.DangerSense = 0;
                        }
                    }
                }
            }
        }
    }

    public virtual IEnumerator LaunchBomb()
    {
        UnityEngine.Object.Instantiate(this.BombGateSFX, this.BombGateTF.position, this.BombGateTF.rotation);
        yield return new WaitForSeconds(0.5f);
        this.BombModel.SetActive(false);
        GameObject _SpawnedObject = UnityEngine.Object.Instantiate(this.Bomb, this.MuzzleB.position, this.MuzzleB.rotation);
        _SpawnedObject.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
        ((MissileScript) _SpawnedObject.transform.GetComponent(typeof(MissileScript))).target = this.target;
        yield return new WaitForSeconds(0.2f);
        UnityEngine.Object.Instantiate(this.BombGateSFX, this.BombGateTF.position, this.BombGateTF.rotation);
        this.LaunchingBomb = false;
    }

    // (RAY)--------------------------------------------------------------------------------------------------
    public virtual IEnumerator FireRayBurst()
    {
        RaycastHit hit = default(RaycastHit);
        if (this.target != null)
        {
            if (this.target.name.Contains("TC") && (this.Dist < 1000))
            {
                if (Physics.Raycast(this.Muzzle1.position + (this.Muzzle1.forward * 8), this.Muzzle1.forward, out hit, 2000, (int) this.targetLayers2))
                {
                    if (hit.collider.name.Contains("TL"))
                    {
                        ((CapsuleCollider)hit.collider).radius = 0.1f;
                    }
                    /*if (hit.collider.name.Contains("TL"))
                    {
                        ((CapsuleCollider)hit.collider).radius = 0.1f;
                    }
                    if (hit.collider.name.Contains("TL"))
                    {
                        ((CapsuleCollider)hit.collider).radius = 0.1f;
                    }
                    if (hit.collider.name.Contains("TL"))
                    {
                        ((CapsuleCollider)hit.collider).radius = 0.1f;
                    }*/
                    if (!hit.collider.name.Contains("C2"))
                    {
                        if ((hit.collider.name.Contains("TC") && !hit.collider.name.Contains("csTC")) && (this.velMag < 400))
                        {
                            this.Gun1Fire = true;
                            UnityEngine.Object.Instantiate(this.RayBurst, this.Muzzle1.position, this.Muzzle1.rotation);
                        }
                    }
                }
            }
        }
        yield return new WaitForSeconds(0.2f);
        if (this.target != null)
        {
            if (this.target.name.Contains("TC") && (this.Dist < 2000))
            {
                if (Physics.Raycast(this.Muzzle2.position + (this.Muzzle2.forward * 8), this.Muzzle2.forward, out hit, 2000, (int) this.targetLayers2))
                {
                    if (hit.collider.name.Contains("TL"))
                    {
                        ((CapsuleCollider)hit.collider).radius = 0.1f;
                    }
                    /*if (hit.collider.name.Contains("TL"))
                    {
                        hit.collider.radius = 0.1f;
                    }
                    if (hit.collider.name.Contains("TL"))
                    {
                        hit.collider.radius = 0.1f;
                    }
                    if (hit.collider.name.Contains("TL"))
                    {
                        hit.collider.radius = 0.1f;
                    }*/
                    if (!hit.collider.name.Contains("C2"))
                    {
                        if ((hit.collider.name.Contains("TC") && !hit.collider.name.Contains("csTC")) && (this.velMag < 400))
                        {
                            this.Gun2Fire = true;
                            UnityEngine.Object.Instantiate(this.RayBurst, this.Muzzle2.position, this.Muzzle2.rotation);
                        }
                    }
                }
            }
        }
        yield return new WaitForSeconds(0.2f);
        if (this.target != null)
        {
            if (this.target.name.Contains("TC") && (this.Dist < 2000))
            {
                if (Physics.Raycast(this.Muzzle3.position + (this.Muzzle3.forward * 8), this.Muzzle3.forward, out hit, 2000, (int) this.targetLayers2))
                {
                    if (hit.collider.name.Contains("TL"))
                    {
                        ((CapsuleCollider)hit.collider).radius = 0.1f;
                    }
                    /*if (hit.collider.name.Contains("TL"))
                    {
                        hit.collider.radius = 0.1f;
                    }
                    if (hit.collider.name.Contains("TL"))
                    {
                        hit.collider.radius = 0.1f;
                    }
                    if (hit.collider.name.Contains("TL"))
                    {
                        hit.collider.radius = 0.1f;
                    }*/
                    if (!hit.collider.name.Contains("C2"))
                    {
                        if ((hit.collider.name.Contains("TC") && !hit.collider.name.Contains("csTC")) && (this.velMag < 400))
                        {
                            this.Gun3Fire = true;
                            UnityEngine.Object.Instantiate(this.RayBurst, this.Muzzle3.position, this.Muzzle3.rotation);
                        }
                    }
                }
            }
        }
        yield return new WaitForSeconds(0.2f);
        if (this.target != null)
        {
            if (this.target.name.Contains("TC") && (this.Dist < 2000))
            {
                if (Physics.Raycast(this.Muzzle4.position + (this.Muzzle4.forward * 8), this.Muzzle4.forward, out hit, 2000, (int) this.targetLayers2))
                {
                    if (hit.collider.name.Contains("TL"))
                    {
                        ((CapsuleCollider)hit.collider).radius = 0.1f;
                    }
                    /*if (hit.collider.name.Contains("TL"))
                    {
                        hit.collider.radius = 0.1f;
                    }
                    if (hit.collider.name.Contains("TL"))
                    {
                        hit.collider.radius = 0.1f;
                    }
                    if (hit.collider.name.Contains("TL"))
                    {
                        hit.collider.radius = 0.1f;
                    }*/
                    if (!hit.collider.name.Contains("C2"))
                    {
                        if ((hit.collider.name.Contains("TC") && !hit.collider.name.Contains("csTC")) && (this.velMag < 400))
                        {
                            this.Gun4Fire = true;
                            UnityEngine.Object.Instantiate(this.RayBurst, this.Muzzle4.position, this.Muzzle4.rotation);
                        }
                    }
                }
            }
        }
    }

    public virtual void Shooty()
    {
        if (this.Attacking)
        {
            this.StartCoroutine(this.FireRayBurst());
        }
    }

    public virtual IEnumerator Notice()
    {
        if (this.target != null)
        {
            Vector3 lastTPos = this.target.transform.position;
            yield return new WaitForSeconds(0.2f);
            if (this.target != null)
            {
                if (this.Anger > 100)
                {
                    if (((Vector3.Distance(this.target.transform.position, lastTPos) > 10) && this.target.name.Contains("TC")) && (this.Dist < 5000))
                    {
                        if (this.target.name.Contains("TC1"))
                        {
                            AgrianNetwork.TC1CriminalLevel = AgrianNetwork.TC1CriminalLevel + 10;
                        }
                        if (this.target.name.Contains("TC4"))
                        {
                            AgrianNetwork.TC4CriminalLevel = AgrianNetwork.TC4CriminalLevel + 10;
                        }
                        if (this.target.name.Contains("TC5"))
                        {
                            AgrianNetwork.TC5CriminalLevel = AgrianNetwork.TC5CriminalLevel + 10;
                        }
                        if (this.target.name.Contains("TC6"))
                        {
                            AgrianNetwork.TC6CriminalLevel = AgrianNetwork.TC6CriminalLevel + 10;
                        }
                        if (this.target.name.Contains("TC7"))
                        {
                            AgrianNetwork.TC7CriminalLevel = AgrianNetwork.TC7CriminalLevel + 10;
                        }
                        if (this.target.name.Contains("TC8"))
                        {
                            AgrianNetwork.TC8CriminalLevel = AgrianNetwork.TC8CriminalLevel + 10;
                        }
                        if (this.target.name.Contains("TC9"))
                        {
                            AgrianNetwork.TC9CriminalLevel = AgrianNetwork.TC9CriminalLevel + 10;
                        }
                        if (this.Pursuit < 8)
                        {
                            this.Pursuit = this.Pursuit + 1;
                        }
                    }
                    else
                    {
                        this.Pursuit = this.Pursuit - 1;
                    }
                }
            }
        }
    }

    public virtual void Counter()
    {
        RaycastHit hitV = default(RaycastHit);
        if (this.Damaged)
        {
            return;
        }
        if (this.target == null)
        {
            if (this.Anger > 100)
            {
                this.Anger = 20;
            }
            this.target = this.Forward;
            this.FoundSmall = false;
            this.FoundMedium = false;
            this.FoundBig = false;
        }
        if (this.target)
        {
            if (!this.target.name.Contains("TC"))
            {
                if (this.DangerSense < 1)
                {
                    this.TorqueForce = 0;
                }
                if (this.Anger > 50)
                {
                    this.Anger = this.Anger - 50;
                }
            }
            else
            {
                if (this.target.name.Contains("TC2_P"))
                {
                    WorldInformation.PiriExposed = 120;
                }
            }
            if ((AgrianNetwork.TC1CriminalLevel > 500) || (this.PissedAtTC1 > 200))
            {
                this.ExecuteTC1 = true;
            }
            if ((AgrianNetwork.TC4CriminalLevel > 500) || (this.PissedAtTC4 > 200))
            {
                this.ExecuteTC4 = true;
            }
            if ((AgrianNetwork.TC6CriminalLevel > 500) || (this.PissedAtTC6 > 200))
            {
                this.ExecuteTC6 = true;
            }
            if ((AgrianNetwork.TC7CriminalLevel > 500) || (this.PissedAtTC7 > 200))
            {
                this.ExecuteTC7 = true;
            }
            if ((AgrianNetwork.TC8CriminalLevel > 500) || (this.PissedAtTC8 > 200))
            {
                this.ExecuteTC8 = true;
            }
            if ((AgrianNetwork.TC9CriminalLevel > 500) || (this.PissedAtTC9 > 200))
            {
                this.ExecuteTC9 = true;
            }
            if (this.Attacking)
            {
                this.viewPoint.LookAt(this.target);
                Debug.DrawRay(this.viewPoint.position, this.viewPoint.forward * this.Dist, Color.red);
                if (Physics.Raycast(this.viewPoint.position, this.viewPoint.forward, this.Dist, (int) this.MtargetLayers))
                {
                    this.inView = false;
                }
                else
                {
                    this.inView = true;
                }
            }
        }
        if (this.target != null)
        {
            if (this.target.name.Contains("sT"))
            {
                this.FoundSmall = true;
            }
            if (this.target.name.Contains("mT"))
            {
                this.FoundMedium = true;
            }
            if (this.target.name.Contains("bT"))
            {
                this.FoundBig = true;
            }
        }
        if (this.ExecuteTC1)
        {
            this.PissedAtTC1 = 210;
            if ((this.Anger < 100) && this.target.name.Contains("TC1"))
            {
                this.Anger = 170;
            }
        }
        if (this.ExecuteTC4)
        {
            this.PissedAtTC4 = 210;
            if ((this.Anger < 100) && this.target.name.Contains("TC4"))
            {
                this.Anger = 170;
            }
        }
        if (this.ExecuteTC6)
        {
            this.PissedAtTC6 = 210;
            if ((this.Anger < 100) && this.target.name.Contains("TC6"))
            {
                this.Anger = 170;
            }
        }
        if (this.ExecuteTC7)
        {
            this.PissedAtTC7 = 210;
            if ((this.Anger < 100) && this.target.name.Contains("TC7"))
            {
                this.Anger = 170;
            }
        }
        if (this.ExecuteTC8)
        {
            this.PissedAtTC8 = 210;
            if ((this.Anger < 100) && this.target.name.Contains("TC8"))
            {
                this.Anger = 170;
            }
        }
        if (this.ExecuteTC9)
        {
            this.PissedAtTC9 = 210;
            if ((this.Anger < 100) && this.target.name.Contains("TC9"))
            {
                this.Anger = 170;
            }
        }
        if (Vector3.Distance(this.thisTransform.position, this.target.position) > 500)
        {
            this.TorqueForce = -20000000;
        }
        if (this.Anger == 1)
        {
            this.DangerSense = 0;
            this.Anger = 0;
            this.target = this.Forward;
            this.vRigidbody.angularDrag = 2;
        }
        if (AgrianNetwork.instance.RedAlertTime > 1)
        {
            this.Waypoint.position = AgrianNetwork.instance.FullPriorityWaypoint.position;
            if (this.Anger < 100)
            {
                this.Anger = 60;
                this.target = this.Waypoint;
            }
        }
        Debug.DrawRay((this.thisVTransform.position + (this.thisVTransform.up * 80)) + (-this.thisVTransform.forward * 20), Vector3.down * 400, Color.white);
        Debug.DrawRay((this.thisVTransform.position + (-this.thisVTransform.up * 80)) + (-this.thisVTransform.forward * 20), Vector3.down * 400, Color.white);
        if (Physics.Raycast((this.thisVTransform.position + (this.thisVTransform.up * 80)) + (-this.thisVTransform.forward * 20), Vector3.down, 400, (int) this.targetLayers) && Physics.Raycast((this.thisVTransform.position + (-this.thisVTransform.up * 80)) + (-this.thisVTransform.forward * 20), Vector3.down, 400, (int) this.targetLayers))
        {
            this.vRigidbody.useGravity = true;
        }
        if (!Physics.Raycast((this.thisVTransform.position + (this.thisVTransform.up * 80)) + (-this.thisVTransform.forward * 20), Vector3.down, 400, (int) this.targetLayers) || !Physics.Raycast((this.thisVTransform.position + (-this.thisVTransform.up * 80)) + (-this.thisVTransform.forward * 20), Vector3.down, 400, (int) this.targetLayers))
        {
            this.vRigidbody.useGravity = false;
        }
        if (this.velMag > 100)
        {
            this.vRigidbody.useGravity = false;
        }
        if (this.Pursuit > 0)
        {
            if (((this.ExecuteTC1 || this.ExecuteTC4) || this.ExecuteTC6) || this.ExecuteTC7)
            {
                if (this.Anger < 200)
                {
                    this.Anger = 210;
                }
            }
            this.Anger = this.Anger + 1;
        }
        if (this.DangerSense > 0)
        {
            this.DangerSense = this.DangerSense - 1;
            this.TorqueForce = -20000000;
        }
        if ((this.Anger > 0) && (this.Pursuit < 1))
        {
            this.Anger = this.Anger - 1;
        }
        if (this.BombLaunchTimer > 0)
        {
            this.BombLaunchTimer = this.BombLaunchTimer - 1;
        }
        if (this.StillOnHull < 5)
        {
            this.vRigidbody.angularDrag = 2;
        }
        else
        {
            this.vRigidbody.angularDrag = 0.05f;
        }
        if (this.OnHull)
        {
            if (this.StillOnHull < 6)
            {
                this.StillOnHull = this.StillOnHull + 1;
            }
        }
        else
        {
            if (this.StillOnHull > 0)
            {
                this.StillOnHull = this.StillOnHull - 1;
            }
        }
        this.Obstacle = false;
        this.TurnRight = false;
        this.TurnLeft = false;
        this.StrafeRight = false;
        this.StrafeLeft = false;
        this.OnHull = false;
        this.StartCoroutine(this.Notice());
        this.VicinityCheck();
    }

    public virtual void LeaveMarker()
    {
        Vector3 lastPos = this.thisTransform.position;
        this.StartCoroutine(this.IsStill(lastPos));
    }

    public virtual IEnumerator IsStill(Vector3 lastPos)
    {
        this.Still = false;
        yield return new WaitForSeconds(1);
        if (Vector3.Distance(this.thisTransform.position, lastPos) < 2)
        {
            this.Still = true;
            yield return new WaitForSeconds(2);
            this.Still = false;
        }
    }

    public virtual void Damage()
    {
        this.Damaged = true;
    }

    public AgrianAnnihilatorCruiserAI()
    {
        this.RecoilCurve = new AnimationCurve();
        this.AimForce = 300;
        this.TurnForce = 200;
        this.DirForce = 200;
        this.TorqueForce = 20000;
        this.Dist = 2;
        this.SDa = 2;
        this.SD2a = 2;
        this.RightDist = 32;
        this.LeftDist = 32;
        this.RayBurstTime = 1.5f;
    }

}