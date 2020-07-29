using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AgrianExecutorCruiserAI : MonoBehaviour
{
    public Transform target;
    public Transform Waypoint;
    public Transform Forward;
    public Transform RightAim;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public GameObject Turret;
    public Transform VPoint;
    public SphereCollider Trig;
    public bool SuperCruiser;
    public int AimForce;
    public int TurnForce;
    public int RayDist;
    public int TorqueForce;
    public bool Broadside;
    public Transform LaserMuzzle;
    public GameObject PropelEffect;
    public GameObject MegaRayStart;
    public GameObject MegaRayDot;
    public GameObject MegaRay;
    public GameObject RayBurst;
    public GameObject RayGlow;
    public GameObject StarShot;
    public GameObject LastPos;
    public GameObject WarningSoundPatrolling;
    public float Dist;
    public bool EngagingEntity;
    public int Anger;
    public bool Obstacle;
    public bool Floorstacle;
    public bool Stuck;
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
    public float RightDist;
    public float LeftDist;
    public bool StrafeLeft;
    public bool StrafeRight;
    public bool AimRight;
    public bool LookingToSide;
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
    public bool ExecuteTC3;
    public bool ExecuteTC4;
    public bool ExecuteTC6;
    public bool ExecuteTC7;
    public bool ExecuteTC8;
    public bool ExecuteTC9;
    public bool Executing;
    public bool Determined;
    public LayerMask targetLayers;
    public LayerMask targetLayers2;
    public bool LineOfFire;
    public Vector3 DangerDirection;
    public int DangerSense;
    public int Pursuit;
    public int BattleTime;
    public float Vel;
    public float RayBurstTime;
    public bool Damaged;
    public virtual void Start()
    {
        this.InvokeRepeating("Counter", 1, 1);
        this.InvokeRepeating("Warning", 10, 60);
        this.InvokeRepeating("LeaveMarker", 3, 3);
        this.InvokeRepeating("Shooty", 1, this.RayBurstTime);
        if (!this.SuperCruiser)
        {
            this.AimForce = 500;
        }
        else
        {
            this.AimForce = 5000;
        }
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        Vector3 newRot2 = default(Vector3);
        if (this.Damaged)
        {
            return;
        }
        Vector3 localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
        float LVel = -localV.y * 5;
        if (this.target)
        {
            this.Dist = Vector3.Distance(this.thisTransform.position, this.target.position);
        }
        else
        {
            this.Dist = 64;
        }
        float VelClamp = Mathf.Clamp(LVel, 100, 1000);
        float VelPlus = VelClamp + 100;
        Vector3 newRot = (this.VPoint.forward * 0.6f).normalized;
        if (!this.SuperCruiser)
        {
            Debug.DrawRay((this.VPoint.position + (this.VPoint.forward * 40)) + (this.VPoint.right * this.RayDist), this.VPoint.forward * VelClamp, Color.red);
            Debug.DrawRay((this.VPoint.position + (this.VPoint.forward * 40)) + (-this.VPoint.right * this.RayDist), this.VPoint.forward * VelClamp, Color.red);
            if (Physics.Raycast((this.VPoint.position + (this.VPoint.forward * 40)) + (this.VPoint.right * this.RayDist), this.VPoint.forward, VelClamp, (int) this.targetLayers) || Physics.Raycast((this.VPoint.position + (this.VPoint.forward * 40)) + (-this.VPoint.right * this.RayDist), this.VPoint.forward, VelClamp, (int) this.targetLayers))
            {
                this.Obstacle = true;
            }
            Debug.DrawRay(((this.VPoint.position + (-this.VPoint.forward * 40)) + (-this.VPoint.up * 4)) + (this.VPoint.right * this.RayDist), this.VPoint.forward * VelPlus, Color.black);
            if (Physics.Raycast(((this.VPoint.position + (-this.VPoint.forward * 40)) + (-this.VPoint.up * 4)) + (this.VPoint.right * this.RayDist), this.VPoint.forward, out hit, VelPlus, (int) this.targetLayers))
            {
                this.TurnLeft = true;
                this.RightDist = hit.distance;
            }
            else
            {
                this.RightDist = 512;
            }
            Debug.DrawRay(((this.VPoint.position + (-this.VPoint.forward * 40)) + (-this.VPoint.up * 4)) + (-this.VPoint.right * this.RayDist), this.VPoint.forward * VelPlus, Color.black);
            if (Physics.Raycast(((this.VPoint.position + (-this.VPoint.forward * 40)) + (-this.VPoint.up * 4)) + (-this.VPoint.right * this.RayDist), this.VPoint.forward, out hit, VelPlus, (int) this.targetLayers))
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
                if (this.Vel > 50)
                {
                    this.Floorstacle = true;
                }
            }
            else
            {
                this.Floorstacle = false;
            }
            if (Physics.Raycast(this.LaserMuzzle.transform.position + (this.LaserMuzzle.transform.forward * 4), this.LaserMuzzle.transform.forward, out hit, 1100, (int) this.targetLayers2))
            {
                if (hit.collider.name.Contains("2"))
                {
                    this.LineOfFire = false;
                }
                else
                {
                    this.LineOfFire = true;
                }
            }
        }
        else
        {
            Debug.DrawRay((this.VPoint.position + (this.VPoint.forward * 300)) + (this.VPoint.right * this.RayDist), this.VPoint.forward * VelClamp, Color.red);
            Debug.DrawRay((this.VPoint.position + (this.VPoint.forward * 300)) + (-this.VPoint.right * this.RayDist), this.VPoint.forward * VelClamp, Color.red);
            if (Physics.Raycast((this.VPoint.position + (this.VPoint.forward * 300)) + (this.VPoint.right * this.RayDist), this.VPoint.forward, VelClamp, (int) this.targetLayers) || Physics.Raycast((this.VPoint.position + (this.VPoint.forward * 300)) + (-this.VPoint.right * this.RayDist), this.VPoint.forward, VelClamp, (int) this.targetLayers))
            {
                this.Obstacle = true;
            }
            Debug.DrawRay(((this.VPoint.position + (this.VPoint.forward * 300)) + (-this.VPoint.up * 4)) + (this.VPoint.right * this.RayDist), this.VPoint.forward * VelClamp, Color.black);
            if (Physics.Raycast(((this.VPoint.position + (this.VPoint.forward * 300)) + (-this.VPoint.up * 4)) + (this.VPoint.right * this.RayDist), this.VPoint.forward, VelClamp, (int) this.targetLayers))
            {
                this.TurnLeft = true;
            }
            Debug.DrawRay(((this.VPoint.position + (this.VPoint.forward * 300)) + (-this.VPoint.up * 4)) + (-this.VPoint.right * this.RayDist), this.VPoint.forward * VelClamp, Color.black);
            if (Physics.Raycast(((this.VPoint.position + (this.VPoint.forward * 300)) + (-this.VPoint.up * 4)) + (-this.VPoint.right * this.RayDist), this.VPoint.forward, VelClamp, (int) this.targetLayers))
            {
                this.TurnRight = true;
            }
            newRot2 = ((this.VPoint.forward * 32) + (this.VPoint.right * -this.SDa)).normalized;
            Debug.DrawRay(((this.VPoint.position + (this.VPoint.forward * this.SDf)) + (-this.VPoint.up * 4)) + (this.VPoint.right * this.SDl), newRot2 * this.SD, Color.black);
            if (Physics.Raycast(((this.VPoint.position + (this.VPoint.forward * this.SDf)) + (-this.VPoint.up * 4)) + (this.VPoint.right * this.SDl), newRot2, out hit, this.SD, (int) this.targetLayers))
            {
                this.RightDist = hit.distance;
            }
            else
            {
                this.RightDist = 512;
            }
            newRot2 = ((this.VPoint.forward * 32) + (this.VPoint.right * this.SDa)).normalized;
            Debug.DrawRay(((this.VPoint.position + (this.VPoint.forward * this.SDf)) + (-this.VPoint.up * 4)) + (-this.VPoint.right * this.SDr), newRot2 * this.SD, Color.black);
            if (Physics.Raycast(((this.VPoint.position + (this.VPoint.forward * this.SDf)) + (-this.VPoint.up * 4)) + (-this.VPoint.right * this.SDr), newRot2, out hit, this.SD, (int) this.targetLayers))
            {
                this.LeftDist = hit.distance;
            }
            else
            {
                this.LeftDist = 512;
            }
            newRot2 = ((this.VPoint.forward * 32) + (this.VPoint.right * -this.SD2a)).normalized;
            Debug.DrawRay(((this.VPoint.position + (this.VPoint.forward * this.SD2f)) + (-this.VPoint.up * 4)) + (this.VPoint.right * this.SD2l), newRot2 * this.SD2, Color.black);
            if (Physics.Raycast(((this.VPoint.position + (this.VPoint.forward * this.SD2f)) + (-this.VPoint.up * 4)) + (this.VPoint.right * this.SD2l), newRot2, out hit, this.SD2, (int) this.targetLayers))
            {
                this.RightDist = 1;
            }
            newRot2 = ((this.VPoint.forward * 32) + (this.VPoint.right * this.SD2a)).normalized;
            Debug.DrawRay(((this.VPoint.position + (this.VPoint.forward * this.SD2f)) + (-this.VPoint.up * 4)) + (-this.VPoint.right * this.SD2r), newRot2 * this.SD2, Color.black);
            if (Physics.Raycast(((this.VPoint.position + (this.VPoint.forward * this.SD2f)) + (-this.VPoint.up * 4)) + (-this.VPoint.right * this.SD2r), newRot2, out hit, this.SD2, (int) this.targetLayers))
            {
                this.LeftDist = 1;
            }
            if (this.RightDist > this.LeftDist)
            {
                this.StrafeRight = true;
            }
            if (this.LeftDist > this.RightDist)
            {
                this.StrafeLeft = true;
            }
            newRot = (-this.VPoint.up * 0.6f).normalized;
            Debug.DrawRay(this.VPoint.position + (this.VPoint.forward * 150), newRot * 100, Color.blue);
            Debug.DrawRay(this.VPoint.position, newRot * 100, Color.blue);
            if (Physics.Raycast(this.VPoint.position + (this.VPoint.forward * 150), newRot, 100, (int) this.targetLayers) || Physics.Raycast(this.VPoint.position, newRot, 100, (int) this.targetLayers))
            {
                if (this.Vel > 50)
                {
                    this.Floorstacle = true;
                }
            }
            else
            {
                this.Floorstacle = false;
            }
            if (Physics.Raycast(this.LaserMuzzle.transform.position + (this.LaserMuzzle.transform.forward * 12), this.LaserMuzzle.transform.forward, out hit, 4000, (int) this.targetLayers2))
            {
                if (hit.collider.name.Contains("2"))
                {
                    this.LineOfFire = false;
                }
                else
                {
                    this.LineOfFire = true;
                }
            }
        }
        if (this.Determined && (this.target == null))
        {
            this.Determined = false;
            this.Anger = 100;
            this.StartCoroutine(this.FireStar());
        }
        if (this.Determined)
        {
            if (this.LineOfFire)
            {
                if (this.Vel < 100)
                {
                    if ((this.ExecuteTC1 && (this.Dist < 1000)) && this.Determined)
                    {
                        if (hit.collider)
                        {
                            if (hit.collider.name.Contains("bTC1"))
                            {
                                this.Determined = false;
                                this.Anger = 100;
                                this.Pursuit = 0;
                                this.StartCoroutine(this.FireMegaRay());
                            }
                        }
                        if (hit.collider)
                        {
                            if (hit.collider.name.Contains("mTC1") || hit.collider.name.Contains("sTC1"))
                            {
                                this.Determined = false;
                                this.Anger = 100;
                                this.Pursuit = 0;
                                this.StartCoroutine(this.FireStar());
                            }
                        }
                    }
                    if ((this.ExecuteTC3 && (this.Dist < 1000)) && this.Determined)
                    {
                        if (hit.collider)
                        {
                            if (hit.collider.name.Contains("bTC3"))
                            {
                                this.Determined = false;
                                this.Anger = 100;
                                this.Pursuit = 0;
                                this.StartCoroutine(this.FireMegaRay());
                            }
                        }
                    }
                    if ((this.ExecuteTC4 && (this.Dist < 1000)) && this.Determined)
                    {
                        if (hit.collider)
                        {
                            if (hit.collider.name.Contains("bTC4"))
                            {
                                this.Determined = false;
                                this.Anger = 100;
                                this.Pursuit = 0;
                                this.StartCoroutine(this.FireMegaRay());
                            }
                        }
                    }
                    if ((this.ExecuteTC6 && (this.Dist < 1000)) && this.Determined)
                    {
                        if (hit.collider)
                        {
                            if (hit.collider.name.Contains("bTC6"))
                            {
                                this.Determined = false;
                                this.Anger = 100;
                                this.Pursuit = 0;
                                this.StartCoroutine(this.FireMegaRay());
                            }
                        }
                    }
                    if ((this.ExecuteTC7 && (this.Dist < 1000)) && this.Determined)
                    {
                        if (hit.collider)
                        {
                            if (hit.collider.name.Contains("bTC7"))
                            {
                                this.Determined = false;
                                this.Anger = 100;
                                this.Pursuit = 0;
                                this.StartCoroutine(this.FireMegaRay());
                            }
                        }
                    }
                    if ((this.ExecuteTC8 && (this.Dist < 1000)) && this.Determined)
                    {
                        if (hit.collider)
                        {
                            if (hit.collider.name.Contains("bTC8"))
                            {
                                this.Determined = false;
                                this.Anger = 100;
                                this.Pursuit = 0;
                                this.StartCoroutine(this.FireMegaRay());
                            }
                        }
                    }
                    if ((this.ExecuteTC9 && (this.Dist < 1000)) && this.Determined)
                    {
                        if (hit.collider)
                        {
                            if (hit.collider.name.Contains("bTC9"))
                            {
                                this.Determined = false;
                                this.Anger = 100;
                                this.Pursuit = 0;
                                this.StartCoroutine(this.FireMegaRay());
                            }
                        }
                    }
                }
            }
            if ((this.ExecuteTC1 && (this.Dist > 1000)) && this.Determined)
            {
                this.Determined = false;
                this.Anger = 100;
                this.Pursuit = 0;
                this.StartCoroutine(this.FireStar());
            }
            if ((this.ExecuteTC3 && (this.Dist > 1000)) && this.Determined)
            {
                this.Determined = false;
                this.Anger = 100;
                this.Pursuit = 0;
                this.StartCoroutine(this.FireStar());
            }
            if ((this.ExecuteTC4 && (this.Dist > 1000)) && this.Determined)
            {
                this.Determined = false;
                this.Anger = 100;
                this.Pursuit = 0;
                this.StartCoroutine(this.FireStar());
            }
            if ((this.ExecuteTC6 && (this.Dist > 1000)) && this.Determined)
            {
                this.Determined = false;
                this.Anger = 100;
                this.Pursuit = 0;
                this.StartCoroutine(this.FireStar());
            }
            if ((this.ExecuteTC7 && (this.Dist > 1000)) && this.Determined)
            {
                this.Determined = false;
                this.Anger = 100;
                this.Pursuit = 0;
                this.StartCoroutine(this.FireStar());
            }
            if ((this.ExecuteTC8 && (this.Dist > 1000)) && this.Determined)
            {
                this.Determined = false;
                this.Anger = 100;
                this.Pursuit = 0;
                this.StartCoroutine(this.FireStar());
            }
            if ((this.ExecuteTC9 && (this.Dist > 1000)) && this.Determined)
            {
                this.Determined = false;
                this.Anger = 100;
                this.Pursuit = 0;
                this.StartCoroutine(this.FireStar());
            }
        }
    }

    private Quaternion NewRotation;
    public virtual void FixedUpdate()
    {
        if (this.Damaged)
        {
            if (!this.SuperCruiser)
            {
                this.vRigidbody.AddTorque(-this.thisVTransform.forward * 8000000);
            }
            else
            {
                this.vRigidbody.AddTorque(-this.thisVTransform.forward * 150000000);
            }
            return;
        }
        if (this.target)
        {
            Vector3 relativePoint = this.thisVTransform.InverseTransformPoint(this.target.position);
            this.LAndR = relativePoint.x;
            this.FAndB = relativePoint.y;
        }
        Vector3 localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
        this.Vel = this.vRigidbody.velocity.magnitude;
        if (!this.SuperCruiser)
        {
            if (this.RayDist < 50)
            {
                this.RayDist = this.RayDist + 2;
            }
            if (this.RayDist == 50)
            {
                this.RayDist = 2;
            }
        }
        else
        {
            if (this.RayDist < 150)
            {
                this.RayDist = this.RayDist + 2;
            }
            if (this.RayDist == 150)
            {
                this.RayDist = 2;
            }
        }
        if (this.target)
        {
            if (((!this.TurnLeft && !this.TurnRight) && !this.Obstacle) && !this.Executing)
            {
                if (this.Dist > 1000)
                {
                    if (this.Pursuit < 1)
                    {
                        if (this.vRigidbody.angularVelocity.magnitude < 0.2f)
                        {
                            if (!this.SuperCruiser)
                            {
                                this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * this.TurnForce, -this.thisVTransform.up * 50);
                                this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * -this.TurnForce, this.thisVTransform.up * 50);
                            }
                            else
                            {
                                this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * this.TurnForce, -this.thisVTransform.up * 100);
                                this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * -this.TurnForce, this.thisVTransform.up * 100);
                            }
                        }
                    }
                    else
                    {
                        if (this.vRigidbody.angularVelocity.magnitude < 1)
                        {
                            this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * this.TurnForce, -this.thisVTransform.up * 50);
                            this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * -this.TurnForce, this.thisVTransform.up * 50);
                        }
                    }
                }
            }
        }
        if (!this.SuperCruiser)
        {
            if (this.Turret.GetComponent<Rigidbody>().angularVelocity.magnitude < 2)
            {
                if (!this.AimRight)
                {
                    if (this.target)
                    {
                        this.Turret.GetComponent<Rigidbody>().AddForceAtPosition((this.target.transform.position - this.Turret.transform.position).normalized * this.AimForce, -this.Turret.transform.up * 2);
                        this.Turret.GetComponent<Rigidbody>().AddForceAtPosition((this.target.transform.position - this.Turret.transform.position).normalized * -this.AimForce, this.Turret.transform.up * 2);
                    }
                }
                else
                {
                    this.Turret.GetComponent<Rigidbody>().AddForceAtPosition((this.RightAim.transform.position - this.Turret.transform.position).normalized * this.AimForce, -this.Turret.transform.up * 2);
                    this.Turret.GetComponent<Rigidbody>().AddForceAtPosition((this.RightAim.transform.position - this.Turret.transform.position).normalized * -this.AimForce, this.Turret.transform.up * 2);
                }
            }
        }
        else
        {
            if (this.Turret.GetComponent<Rigidbody>().angularVelocity.magnitude < 1)
            {
                if (this.target)
                {
                    this.Turret.GetComponent<Rigidbody>().AddForceAtPosition((this.target.transform.position - this.Turret.transform.position).normalized * this.AimForce, -this.Turret.transform.up * 20);
                    this.Turret.GetComponent<Rigidbody>().AddForceAtPosition((this.target.transform.position - this.Turret.transform.position).normalized * -this.AimForce, this.Turret.transform.up * 20);
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
        if (!this.SuperCruiser)
        {
            if (this.target)
            {
                if (!this.Obstacle && !this.Stuck)
                {
                    if (this.Anger > 50)
                    {
                        if (this.Pursuit < 1)
                        {
                            if (this.Dist < 300)
                            {
                                this.TurnForce = 200000;
                                if (this.Dist < 100)
                                {
                                    if (localV.y < 25)
                                    {
                                        this.vRigidbody.AddForce(-this.thisVTransform.up * -40000);
                                    }
                                }
                                if (this.Dist > 150)
                                {
                                    if (-localV.y < 50)
                                    {
                                        this.vRigidbody.AddForce(-this.thisVTransform.up * 40000);
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
                                            this.vRigidbody.AddForce(-this.thisVTransform.up * 16000000);
                                        }
                                    }
                                }
                                this.TurnForce = 800000;
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
                            if (this.vRigidbody.angularVelocity.magnitude > 0.5f)
                            {
                                this.TurnForce = 800000;
                            }
                            else
                            {
                                this.TurnForce = 200000;
                            }
                            if (this.Dist < 150)
                            {
                                this.vRigidbody.AddForce((this.thisVTransform.up * -localV.y) * 20000);
                            }
                            if (this.Dist > 200)
                            {
                                if (-localV.y < 280)
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
                        if (!this.LineOfFire)
                        {
                            this.vRigidbody.AddTorque(-this.thisVTransform.forward * 4000000);
                        }
                    }
                    else
                    {
                        if (this.Dist < 100)
                        {
                            if (localV.y < 25)
                            {
                                this.vRigidbody.AddForce(-this.thisVTransform.up * -30000);
                            }
                        }
                        if (this.Dist > 150)
                        {
                            if (-localV.y < 25)
                            {
                                this.vRigidbody.AddForce(-this.thisVTransform.up * 30000);
                            }
                        }
                    }
                }
            }
            if (this.TurnRight && !this.TurnLeft)
            {
                if (!this.Executing)
                {
                    this.vRigidbody.AddTorque(-this.thisVTransform.forward * -8000000);
                    this.vRigidbody.AddForce(this.thisVTransform.right * 80000);
                }
            }
            if (this.TurnLeft && !this.TurnRight)
            {
                if (!this.Executing)
                {
                    this.vRigidbody.AddTorque(-this.thisVTransform.forward * 8000000);
                    this.vRigidbody.AddForce(this.thisVTransform.right * -80000);
                }
            }
            if (this.TurnLeft && this.TurnRight)
            {
                if (!this.Executing)
                {
                    this.vRigidbody.AddTorque(-this.thisVTransform.forward * -8000000);
                    this.vRigidbody.AddForce(this.thisVTransform.right * 80000);
                }
            }
            if (this.Floorstacle)
            {
                if (this.Pursuit < 2)
                {
                    this.vRigidbody.AddTorque(-this.thisVTransform.right * 8000000);
                }
                else
                {
                    this.vRigidbody.AddTorque(-this.thisVTransform.right * 16000000);
                }
            }
            if (this.Obstacle)
            {
                if (-localV.y > 25)
                {
                    this.vRigidbody.AddForce((-this.thisVTransform.up * 15000) * localV.y);
                }
                if (this.TurnLeft || this.TurnRight)
                {
                    if (!this.Executing)
                    {
                        this.vRigidbody.AddForce(-this.thisVTransform.up * 40000);
                    }
                }
            }
            if (this.Stuck && !this.Executing)
            {
                if (localV.y < 25)
                {
                    this.vRigidbody.AddForce(-this.thisVTransform.up * -100000);
                }
                this.vRigidbody.AddTorque(-this.thisVTransform.forward * 4000000);
            }
            if (this.target)
            {
                if (this.OnHull && this.EngagingEntity)
                {
                    this.vRigidbody.AddTorque(-this.thisVTransform.up * 16000000);
                }
            }
        }
        else
        {
            if (this.target)
            {
                if (!this.Obstacle)
                {
                    if (this.Anger > 50)
                    {
                        if (this.Dist > 600)
                        {
                            this.vRigidbody.AddTorque(-this.thisVTransform.right * 200000000);
                        }
                        if (this.Dist > 100)
                        {
                            if (-localV.y < 60)
                            {
                                if (this.Dist < 600)
                                {
                                    this.vRigidbody.AddForce(-this.thisVTransform.up * 500000);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (this.Dist > 100)
                        {
                            if (-localV.y < 60)
                            {
                                this.vRigidbody.AddForce(-this.thisVTransform.up * 500000);
                            }
                        }
                    }
                }
                else
                {
                    if (-localV.y > 30)
                    {
                        if (-localV.y > 100)
                        {
                            this.vRigidbody.AddForce(-this.thisVTransform.up * -10000000);
                        }
                        else
                        {
                            this.vRigidbody.AddForce(-this.thisVTransform.up * -1000000);
                        }
                    }
                }
            }
            if (this.TurnRight && !this.TurnLeft)
            {
                if (!this.Executing)
                {
                    this.vRigidbody.AddTorque(-this.thisVTransform.forward * -150000000);
                }
            }
            if (this.TurnLeft && !this.TurnRight)
            {
                this.vRigidbody.AddTorque(-this.thisVTransform.forward * 150000000);
            }
            if (this.TurnLeft && this.TurnRight)
            {
                this.vRigidbody.AddTorque(-this.thisVTransform.forward * -150000000);
            }
            if (this.StrafeRight && !this.StrafeLeft)
            {
                this.vRigidbody.AddForce(this.thisVTransform.right * 2000000);
            }
            if (this.StrafeLeft && !this.StrafeRight)
            {
                this.vRigidbody.AddForce(this.thisVTransform.right * -2000000);
            }
            if (this.Floorstacle)
            {
                this.vRigidbody.AddTorque(-this.thisVTransform.right * 100000000);
            }
        }
        if (this.Broadside)
        {
            if (this.FAndB < 0)
            {
                if (this.SuperCruiser)
                {
                    this.LookingToSide = true;
                }
                if (((!this.TurnLeft && !this.TurnRight) && !this.StrafeLeft) && !this.StrafeRight)
                {
                    this.vRigidbody.AddTorque(this.thisVTransform.forward * this.TorqueForce);
                }
            }
            else
            {
                if (this.SuperCruiser)
                {
                    this.LookingToSide = true;
                }
                if (((!this.TurnLeft && !this.TurnRight) && !this.StrafeLeft) && !this.StrafeRight)
                {
                    this.vRigidbody.AddTorque(this.thisVTransform.forward * -this.TorqueForce);
                }
            }
        }
        else
        {
            if (this.LAndR < -1)
            {
                if (this.SuperCruiser)
                {
                    this.LookingToSide = true;
                }
                if ((((!this.TurnLeft && !this.TurnRight) && !this.Obstacle) && !this.StrafeLeft) && !this.StrafeRight)
                {
                    this.vRigidbody.AddTorque(this.thisVTransform.forward * this.TorqueForce);
                }
            }
            if (this.LAndR > 1)
            {
                if (this.SuperCruiser)
                {
                    this.LookingToSide = true;
                }
                if ((((!this.TurnLeft && !this.TurnRight) && !this.Obstacle) && !this.StrafeLeft) && !this.StrafeRight)
                {
                    this.vRigidbody.AddTorque(this.thisVTransform.forward * -this.TorqueForce);
                }
            }
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        string ON = other.name;
        Transform OT = other.transform;
        int DNum = 0;
        if (ON.Contains("#1"))
        {
            DNum = 20;
        }
        if (ON.Contains("#2"))
        {
            DNum = 50;
        }
        if (ON.Contains("#3"))
        {
            DNum = 200;
        }
        if (!this.Determined && !this.Executing)
        {
            if (other.GetComponent<Rigidbody>())
            {
                if (!ON.Contains("TFC2"))
                {
                    if (ON.Contains("TFC"))
                    {
                        if (this.target)
                        {
                            if (this.EngagingEntity)
                            {
                                if (this.Anger < 120)
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
                                        this.Anger = 100;
                                        this.DangerSense = 60;
                                        this.DangerDirection = -other.GetComponent<Rigidbody>().velocity.normalized;
                                    }
                                }
                                else
                                {
                                    if (this.target)
                                    {
                                        if (!this.EngagingEntity)
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
                else
                {
                    if (ON.Contains("FC2_P"))
                    {
                        if (this.EngagingEntity)
                        {
                            if (this.Anger < 120)
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
                                    this.Anger = 100;
                                    this.DangerSense = 60;
                                    this.DangerDirection = -other.GetComponent<Rigidbody>().velocity.normalized;
                                }
                            }
                            else
                            {
                                if (!this.EngagingEntity)
                                {
                                    this.Anger = 1;
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
            if (OT == AgrianNetwork.doomstarTarget)
            {
                return;
            }
            if (Vector3.Distance(this.thisTransform.position, OT.position) < 3000)
            {
                if (this.Determined)
                {
                    if (ON.Contains("mTC1") && this.ExecuteTC1)
                    {
                        this.target = OT;
                    }
                    if (ON.Contains("bTC3") && this.ExecuteTC3)
                    {
                        this.target = OT;
                    }
                    if (ON.Contains("bTC4") && this.ExecuteTC4)
                    {
                        this.target = OT;
                    }
                    if (ON.Contains("bTC6") && this.ExecuteTC6)
                    {
                        this.target = OT;
                    }
                    if (ON.Contains("bTC7") && this.ExecuteTC7)
                    {
                        this.target = OT;
                    }
                    if (ON.Contains("bTC8") && this.ExecuteTC8)
                    {
                        this.target = OT;
                    }
                    if (ON.Contains("bTC9") && this.ExecuteTC9)
                    {
                        this.target = OT;
                    }
                }
                if (!this.Determined)
                {
                    if (this.target != null)
                    {
                        if (!this.Executing)
                        {
                            if (ON.Contains("TC0a") && (this.PissedAtTC0a > 100))
                            {
                                if ((((ON.Contains("sT") && !this.FoundSmall) || (ON.Contains("mT") && !this.FoundMedium)) || (ON.Contains("bT") && !this.FoundBig)) || !ON.Contains("csT"))
                                {
                                    this.target = OT;
                                    if (this.Anger < 100)
                                    {
                                        this.Anger = 110;
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
                                        this.Anger = 110;
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
                                        this.Anger = 110;
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
                                            this.Anger = 110;
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
                                        this.Anger = 110;
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
                                        this.Anger = 110;
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
                                        this.Anger = 110;
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
                                        this.Anger = 110;
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
                                        this.Anger = 110;
                                    }
                                    this.DangerSense = 0;
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    // (RAY)--------------------------------------------------------------------------------------------------
    public virtual IEnumerator FireRayBurst()
    {
        RaycastHit hit = default(RaycastHit);
        if (!this.SuperCruiser)
        {
            if (this.target != null)
            {
                if (this.EngagingEntity && (this.Dist < 1000))
                {
                    if (Physics.Raycast(this.Turret.transform.position + (-this.Turret.transform.up * 5), -this.Turret.transform.up, out hit, 1000, (int) this.targetLayers2))
                    {
                        if ((hit.collider.name.Contains("TC") && !hit.collider.name.Contains("csTC")) && (this.Vel < 200))
                        {
                            GameObject TheThing = UnityEngine.Object.Instantiate(this.RayGlow, this.LaserMuzzle.transform.position, this.LaserMuzzle.transform.rotation);
                            TheThing.transform.parent = this.LaserMuzzle.transform;
                            yield return new WaitForSeconds(1);
                            this.Anger = 100;
                            UnityEngine.Object.Instantiate(this.RayBurst, this.LaserMuzzle.transform.position, this.LaserMuzzle.transform.rotation);
                            if (this.target)
                            {
                                if (this.target.name.Contains("TC1"))
                                {
                                    this.PissedAtTC1 = 90;
                                }
                                if (this.target.name.Contains("TC3"))
                                {
                                    this.PissedAtTC3 = 90;
                                }
                                if (this.target.name.Contains("TC4"))
                                {
                                    this.PissedAtTC4 = 90;
                                }
                                if (this.target.name.Contains("TC5"))
                                {
                                    this.PissedAtTC5 = 90;
                                }
                                if (this.target.name.Contains("TC6"))
                                {
                                    this.PissedAtTC6 = 90;
                                }
                                if (this.target.name.Contains("TC7"))
                                {
                                    this.PissedAtTC7 = 90;
                                }
                                if (this.target.name.Contains("TC8"))
                                {
                                    this.PissedAtTC8 = 90;
                                }
                                if (this.target.name.Contains("TC9"))
                                {
                                    this.PissedAtTC9 = 90;
                                }
                            }
                        }
                    }
                }
            }
        }
        else
        {
            if (this.target != null)
            {
                if (this.EngagingEntity && (this.Dist < 1000))
                {
                    if (Physics.Raycast(this.Turret.transform.position + (-this.Turret.transform.up * 5), -this.Turret.transform.up, out hit, 1000, (int) this.targetLayers2))
                    {
                        if (hit.collider.name.Contains("TC") && (this.Vel < 200))
                        {
                            this.Anger = 100;
                            GameObject TheThing1 = UnityEngine.Object.Instantiate(this.RayBurst, this.LaserMuzzle.transform.position, this.LaserMuzzle.transform.rotation);
                            TheThing1.transform.parent = this.LaserMuzzle.transform;
                        }
                    }
                }
            }
        }
    }

    // (MEGARAY)--------------------------------------------------------------------------------------------------
    public virtual IEnumerator ReadyMegaRay()
    {
        this.Broadside = true;
        yield return new WaitForSeconds(2);
        GameObject TheThing = UnityEngine.Object.Instantiate(this.MegaRayStart, this.LaserMuzzle.transform.position, this.LaserMuzzle.transform.rotation);
        TheThing.transform.parent = this.LaserMuzzle.transform;
        this.AimForce = 1200;
        yield return new WaitForSeconds(2);
        this.AimForce = 1400;
        yield return new WaitForSeconds(2);
        this.AimForce = 1600;
        yield return new WaitForSeconds(2);
        this.AimForce = 1800;
        yield return new WaitForSeconds(1.3f);
        this.MegaRayDot.gameObject.SetActive(true);
        this.AimForce = 2000;
        yield return new WaitForSeconds(0.7f);
        this.Determined = true;
    }

    public virtual IEnumerator FireMegaRay()
    {
        if (this.target.name.Contains("TC1"))
        {
            this.ExecuteTC1 = false;
        }
        if (this.target.name.Contains("TC3"))
        {
            this.ExecuteTC3 = false;
        }
        if (this.target.name.Contains("TC4"))
        {
            this.ExecuteTC4 = false;
        }
        if (this.target.name.Contains("TC6"))
        {
            this.ExecuteTC6 = false;
        }
        if (this.target.name.Contains("TC7"))
        {
            this.ExecuteTC7 = false;
        }
        if (this.target.name.Contains("TC8"))
        {
            this.ExecuteTC8 = false;
        }
        if (this.target.name.Contains("TC9"))
        {
            this.ExecuteTC9 = false;
        }
        this.MegaRayDot.gameObject.SetActive(false);
        GameObject TheThing = UnityEngine.Object.Instantiate(this.MegaRay, this.LaserMuzzle.transform.position, this.LaserMuzzle.transform.rotation);
        TheThing.transform.parent = this.LaserMuzzle.transform;
        yield return new WaitForSeconds(5.2f);
        this.Executing = false;
        this.vRigidbody.drag = 0.1f;
        this.vRigidbody.angularDrag = 2;
        this.TorqueForce = -20000000;
        this.Anger = 100;
    }

    public virtual IEnumerator FireStar()
    {
        this.AimRight = true;
        yield return new WaitForSeconds(2);
        this.MegaRayDot.gameObject.SetActive(false);
        GameObject TheThing = UnityEngine.Object.Instantiate(this.StarShot, this.LaserMuzzle.transform.position, this.LaserMuzzle.transform.rotation);
        GameObject TheThing2 = UnityEngine.Object.Instantiate(this.PropelEffect, this.LaserMuzzle.transform.position, this.LaserMuzzle.transform.rotation);
        TheThing2.transform.parent = this.LaserMuzzle.transform;
        ((ArchocapacitorScript) TheThing.GetComponent(typeof(ArchocapacitorScript))).target = this.target;
        TheThing.GetComponent<Rigidbody>().velocity = this.vRigidbody.velocity * 1;
        TheThing.GetComponent<Rigidbody>().velocity = this.LaserMuzzle.transform.forward * 250;
        yield return new WaitForSeconds(1);
        if (this.target)
        {
            if (this.target.name.Contains("TC1"))
            {
                this.ExecuteTC1 = false;
                this.PissedAtTC1 = 0;
            }
            if (this.target.name.Contains("TC3"))
            {
                this.ExecuteTC3 = false;
                this.PissedAtTC3 = 0;
            }
            if (this.target.name.Contains("TC4"))
            {
                this.ExecuteTC4 = false;
                this.PissedAtTC4 = 0;
            }
            if (this.target.name.Contains("TC6"))
            {
                this.ExecuteTC6 = false;
                this.PissedAtTC6 = 0;
            }
            if (this.target.name.Contains("TC7"))
            {
                this.ExecuteTC7 = false;
                this.PissedAtTC7 = 0;
            }
            if (this.target.name.Contains("TC8"))
            {
                this.ExecuteTC8 = false;
                this.PissedAtTC8 = 0;
            }
            if (this.target.name.Contains("TC9"))
            {
                this.ExecuteTC9 = false;
                this.PissedAtTC9 = 0;
            }
        }
        this.AimRight = false;
        AgrianNetwork.instance.RedAlertTime = 0;
        this.PissedAtTC3 = 0;
        this.PissedAtTC5 = 0;
        this.Executing = false;
        this.vRigidbody.drag = 0.1f;
        if (!this.SuperCruiser)
        {
            this.vRigidbody.angularDrag = 2;
        }
        else
        {
            this.vRigidbody.angularDrag = 1;
        }
        this.target = this.Forward;
        this.Anger = 0;
        this.Pursuit = 0;
    }

    public virtual void Shooty()
    {
        if (!this.Executing)
        {
            if (this.Anger > 110)
            {
                if (this.LineOfFire)
                {
                    this.StartCoroutine(this.FireRayBurst());
                }
            }
        }
    }

    public virtual void Warning()
    {
        if (((this.Anger < 50) && !this.Executing) && !this.SuperCruiser)
        {
            GameObject TheThing = UnityEngine.Object.Instantiate(this.WarningSoundPatrolling, this.thisTransform.position + new Vector3(0, -2, 0), Quaternion.identity);
            TheThing.transform.parent = this.gameObject.transform;
        }
    }

    public virtual void LeaveMarker()
    {
        Vector3 lastPos = this.thisTransform.position;
        this.StartCoroutine(this.IsEscaping(lastPos));
    }

    public virtual IEnumerator IsEscaping(Vector3 lastPos)
    {
        this.Stuck = false;
        yield return new WaitForSeconds(1);
        if ((Vector3.Distance(this.thisTransform.position, lastPos) < 1) && (this.Anger < 50))
        {
            this.Stuck = true;
            yield return new WaitForSeconds(2);
            this.Stuck = false;
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
                        if (this.target.name.Contains("C1"))
                        {
                            if (AgrianNetwork.TC1CriminalLevel < 200)
                            {
                                AgrianNetwork.TC1CriminalLevel = 270;
                            }
                        }
                        if (this.target.name.Contains("C3"))
                        {
                            if (AgrianNetwork.TC3CriminalLevel < 200)
                            {
                                AgrianNetwork.TC3CriminalLevel = 270;
                            }
                        }
                        if (this.target.name.Contains("C4"))
                        {
                            if (AgrianNetwork.TC4CriminalLevel < 200)
                            {
                                AgrianNetwork.TC4CriminalLevel = 270;
                            }
                        }
                        if (this.target.name.Contains("C5"))
                        {
                            if (AgrianNetwork.TC5CriminalLevel < 200)
                            {
                                AgrianNetwork.TC5CriminalLevel = 270;
                            }
                        }
                        if (this.target.name.Contains("C6"))
                        {
                            if (AgrianNetwork.TC6CriminalLevel < 200)
                            {
                                AgrianNetwork.TC6CriminalLevel = 270;
                            }
                        }
                        if (this.target.name.Contains("C7"))
                        {
                            if (AgrianNetwork.TC7CriminalLevel < 200)
                            {
                                AgrianNetwork.TC7CriminalLevel = 270;
                            }
                        }
                        if (this.target.name.Contains("C8"))
                        {
                            if (AgrianNetwork.TC8CriminalLevel < 200)
                            {
                                AgrianNetwork.TC8CriminalLevel = 270;
                            }
                        }
                        if (this.target.name.Contains("C9"))
                        {
                            if (AgrianNetwork.TC9CriminalLevel < 200)
                            {
                                AgrianNetwork.TC9CriminalLevel = 270;
                            }
                        }
                        this.Pursuit = 4;
                    }
                }
            }
        }
    }

    public virtual void Counter()
    {
        if (this.Damaged)
        {
            return;
        }
        if (!this.target)
        {
            this.EngagingEntity = false;
            if (!this.Executing)
            {
                this.BattleTime = 0;
                this.target = this.Forward;
                this.FoundSmall = false;
                this.FoundMedium = false;
                this.FoundBig = false;
            }
        }
        else
        {
            if (this.target.name.Contains("TC"))
            {
                this.EngagingEntity = true;
            }
            else
            {
                this.EngagingEntity = false;
                if (this.DangerSense < 1)
                {
                    this.TorqueForce = 0;
                }
            }
        }
        if ((AgrianNetwork.TC1CriminalLevel > 240) || (this.PissedAtTC1 > 200))
        {
            this.ExecuteTC1 = true;
        }
        if ((AgrianNetwork.TC3CriminalLevel > 240) || (this.PissedAtTC3 > 200))
        {
            this.ExecuteTC3 = true;
        }
        if ((AgrianNetwork.TC4CriminalLevel > 240) || (this.PissedAtTC4 > 200))
        {
            this.ExecuteTC4 = true;
        }
        if ((AgrianNetwork.TC6CriminalLevel > 240) || (this.PissedAtTC6 > 200))
        {
            this.ExecuteTC6 = true;
        }
        if ((AgrianNetwork.TC7CriminalLevel > 240) || (this.PissedAtTC7 > 200))
        {
            this.ExecuteTC7 = true;
        }
        if ((AgrianNetwork.TC8CriminalLevel > 240) || (this.PissedAtTC8 > 200))
        {
            this.ExecuteTC8 = true;
        }
        if ((AgrianNetwork.TC9CriminalLevel > 240) || (this.PissedAtTC9 > 200))
        {
            this.ExecuteTC9 = true;
        }
        if (this.Anger > 96)
        {
            if (this.EngagingEntity)
            {
                this.Trig.radius = 10;
                if (this.BattleTime < 60)
                {
                    this.BattleTime = this.BattleTime + 1;
                }
                else
                {
                    if (this.target.name.Contains("TC2_P"))
                    {
                        WorldInformation.PiriExposed = 120;
                        if (AgrianNetwork.instance.AlertTime < 300)
                        {
                            AgrianNetwork.instance.AlertTime = 300;
                        }
                        AgrianNetwork.TC1CriminalLevel = 620;
                        if (this.target.name.Contains("bT"))
                        {
                            AgrianNetwork.instance.SubdueTarget = this.target;
                        }
                    }
                }
            }
            else
            {
                this.Trig.radius = 300;
                this.BattleTime = 0;
            }
        }
        else
        {
            this.Trig.radius = 300;
            this.BattleTime = 0;
        }
        if (this.DangerSense > 1)
        {
            this.Trig.radius = 300;
        }
        if (this.Vel > 1000)
        {
            this.Trig.radius = 300;
        }
        if (this.target != null)
        {
            if (this.target.name.Contains("Executor"))
            {
                this.Trig.radius = 300;
            }
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
            if ((((((this.ExecuteTC1 || this.ExecuteTC3) || this.ExecuteTC4) || this.ExecuteTC6) || this.ExecuteTC7) || this.ExecuteTC8) || this.ExecuteTC9)
            {
                if (AgrianNetwork.DoomstarActive == false)
                {
                    if (this.target == AgrianNetwork.instance.SubdueTarget)
                    {
                        if (!this.Executing && (AgrianNetwork.TargetSubdual > 8))
                        {
                            if (!this.SuperCruiser)
                            {
                                if ((this.Dist < 400) && (this.Vel < 150))
                                {
                                    if (this.target.name.Contains("bTC1"))
                                    {
                                        this.Executing = true;
                                        this.StopAllCoroutines();
                                        this.StartCoroutine(this.ReadyMegaRay());
                                    }
                                    if (this.target.name.Contains("bTC4"))
                                    {
                                        this.Executing = true;
                                        this.StopAllCoroutines();
                                        this.StartCoroutine(this.ReadyMegaRay());
                                    }
                                    if (this.target.name.Contains("bTC6"))
                                    {
                                        this.Executing = true;
                                        this.StopAllCoroutines();
                                        this.StartCoroutine(this.ReadyMegaRay());
                                    }
                                    if (this.target.name.Contains("bTC7"))
                                    {
                                        this.Executing = true;
                                        this.StopAllCoroutines();
                                        this.StartCoroutine(this.ReadyMegaRay());
                                    }
                                    if (this.target.name.Contains("bTC8"))
                                    {
                                        this.Executing = true;
                                        this.StopAllCoroutines();
                                        this.StartCoroutine(this.ReadyMegaRay());
                                    }
                                    if (this.target.name.Contains("bTC9"))
                                    {
                                        this.Executing = true;
                                        this.StopAllCoroutines();
                                        this.StartCoroutine(this.ReadyMegaRay());
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (!this.Executing)
                        {
                            if (!this.SuperCruiser)
                            {
                                if ((this.Dist < 400) && (this.Vel < 150))
                                {
                                    if (this.target.name.Contains("bTC1"))
                                    {
                                        this.Executing = true;
                                        this.StopAllCoroutines();
                                        this.StartCoroutine(this.ReadyMegaRay());
                                    }
                                    if (this.target.name.Contains("bTC4"))
                                    {
                                        this.Executing = true;
                                        this.StopAllCoroutines();
                                        this.StartCoroutine(this.ReadyMegaRay());
                                    }
                                    if (this.target.name.Contains("bTC6"))
                                    {
                                        this.Executing = true;
                                        this.StopAllCoroutines();
                                        this.StartCoroutine(this.ReadyMegaRay());
                                    }
                                    if (this.target.name.Contains("bTC7"))
                                    {
                                        this.Executing = true;
                                        this.StopAllCoroutines();
                                        this.StartCoroutine(this.ReadyMegaRay());
                                    }
                                    if (this.target.name.Contains("bTC8"))
                                    {
                                        this.Executing = true;
                                        this.StopAllCoroutines();
                                        this.StartCoroutine(this.ReadyMegaRay());
                                    }
                                    if (this.target.name.Contains("bTC9"))
                                    {
                                        this.Executing = true;
                                        this.StopAllCoroutines();
                                        this.StartCoroutine(this.ReadyMegaRay());
                                    }
                                }
                            }
                        }
                    }
                    if (this.target == AgrianNetwork.instance.SubdueTarget)
                    {
                        if (AgrianNetwork.TargetSubdual > 8)
                        {
                            this.Pursuit = 4;
                        }
                    }
                }
                else
                {
                    if (this.target.name.Contains("bTC"))
                    {
                        ArchocapacitorScript.newTarget = this.target;
                        if (this.target.name.Contains("TC1"))
                        {
                            this.ExecuteTC1 = false;
                            this.PissedAtTC1 = 0;
                        }
                        if (this.target.name.Contains("TC3"))
                        {
                            this.ExecuteTC3 = false;
                            this.PissedAtTC3 = 0;
                        }
                        if (this.target.name.Contains("TC4"))
                        {
                            this.ExecuteTC4 = false;
                            this.PissedAtTC4 = 0;
                        }
                        if (this.target.name.Contains("TC6"))
                        {
                            this.ExecuteTC6 = false;
                            this.PissedAtTC6 = 0;
                        }
                        if (this.target.name.Contains("TC7"))
                        {
                            this.ExecuteTC7 = false;
                            this.PissedAtTC7 = 0;
                        }
                        if (this.target.name.Contains("TC8"))
                        {
                            this.ExecuteTC8 = false;
                            this.PissedAtTC8 = 0;
                        }
                        if (this.target.name.Contains("TC9"))
                        {
                            this.ExecuteTC9 = false;
                            this.PissedAtTC9 = 0;
                        }
                    }
                    if (this.target == AgrianNetwork.instance.SubdueTarget)
                    {
                        if (AgrianNetwork.TargetSubdual > 8)
                        {
                            AgrianNetwork.DismissDoomstar = true;
                            AgrianNetwork.DoomstarActive = false;
                            this.Pursuit = 4;
                        }
                    }
                    else
                    {
                        if (Vector3.Distance(this.thisTransform.position, AgrianNetwork.doomstarTarget.position) < 1000)
                        {
                            AgrianNetwork.DismissDoomstar = true;
                            AgrianNetwork.DoomstarActive = false;
                        }
                    }
                }
            }
            if (this.ExecuteTC1)
            {
                this.PissedAtTC1 = 210;
                if (this.Anger < 120)
                {
                    if (this.target.name.Contains("TC1"))
                    {
                        WorldInformation.PiriExposed = 120;
                        this.Anger = 120;
                    }
                    if (this.target.name.Contains("2_P"))
                    {
                        WorldInformation.PiriExposed = 120;
                        this.Anger = 120;
                    }
                }
            }
            if (this.ExecuteTC3)
            {
                this.PissedAtTC3 = 210;
                if ((this.Anger < 120) && this.target.name.Contains("TC3"))
                {
                    this.Anger = 120;
                }
            }
            if (this.ExecuteTC4)
            {
                this.PissedAtTC4 = 210;
                if ((this.Anger < 120) && this.target.name.Contains("TC4"))
                {
                    this.Anger = 120;
                }
            }
            if (this.ExecuteTC6)
            {
                this.PissedAtTC6 = 210;
                if ((this.Anger < 120) && this.target.name.Contains("TC6"))
                {
                    this.Anger = 120;
                }
            }
            if (this.ExecuteTC7)
            {
                this.PissedAtTC7 = 210;
                if ((this.Anger < 120) && this.target.name.Contains("TC7"))
                {
                    this.Anger = 120;
                }
            }
            if (this.ExecuteTC8)
            {
                this.PissedAtTC8 = 210;
                if ((this.Anger < 120) && this.target.name.Contains("TC8"))
                {
                    this.Anger = 120;
                }
            }
            if (this.ExecuteTC9)
            {
                this.PissedAtTC9 = 210;
                if ((this.Anger < 120) && this.target.name.Contains("TC9"))
                {
                    this.Anger = 120;
                }
            }
            if (!this.Executing)
            {
                if (this.LineOfFire)
                {
                    if (!this.SuperCruiser)
                    {
                        this.TorqueForce = -20000000;
                    }
                    else
                    {
                        this.TorqueForce = -100000000;
                    }
                }
                if (this.Dist < 300)
                {
                    if (this.DangerSense < 1)
                    {
                        this.Broadside = true;
                    }
                }
                if (!this.SuperCruiser)
                {
                    if (this.Dist > 500)
                    {
                        this.Broadside = false;
                        this.TorqueForce = -20000000;
                    }
                }
                else
                {
                    if (this.target)
                    {
                        if (this.target.name.Contains("C1"))
                        {
                            if (AgrianNetwork.TC1CriminalLevel < 200)
                            {
                                AgrianNetwork.TC1CriminalLevel = 270;
                            }
                        }
                        if (this.target.name.Contains("C3"))
                        {
                            if (AgrianNetwork.TC3CriminalLevel < 200)
                            {
                                AgrianNetwork.TC3CriminalLevel = 270;
                            }
                        }
                        if (this.target.name.Contains("C4"))
                        {
                            if (AgrianNetwork.TC4CriminalLevel < 200)
                            {
                                AgrianNetwork.TC4CriminalLevel = 270;
                            }
                        }
                        if (this.target.name.Contains("C5"))
                        {
                            if (AgrianNetwork.TC5CriminalLevel < 200)
                            {
                                AgrianNetwork.TC5CriminalLevel = 270;
                            }
                        }
                        if (this.target.name.Contains("C6"))
                        {
                            if (AgrianNetwork.TC6CriminalLevel < 200)
                            {
                                AgrianNetwork.TC6CriminalLevel = 270;
                            }
                        }
                        if (this.target.name.Contains("C7"))
                        {
                            if (AgrianNetwork.TC7CriminalLevel < 200)
                            {
                                AgrianNetwork.TC7CriminalLevel = 270;
                            }
                        }
                        if (this.target.name.Contains("C8"))
                        {
                            if (AgrianNetwork.TC8CriminalLevel < 200)
                            {
                                AgrianNetwork.TC8CriminalLevel = 270;
                            }
                        }
                        if (this.target.name.Contains("C9"))
                        {
                            if (AgrianNetwork.TC9CriminalLevel < 200)
                            {
                                AgrianNetwork.TC9CriminalLevel = 270;
                            }
                        }
                    }
                    if (this.Dist > 1500)
                    {
                        if (this.Anger > 110)
                        {
                            AgrianNetwork.instance.PriorityWaypoint.position = this.target.position;
                            AgrianNetwork.instance.AlertTime = 120;
                            this.StartCoroutine(this.Dismiss());
                        }
                    }
                }
                if ((this.TurnLeft || this.TurnRight) || this.Obstacle)
                {
                    if (this.LookingToSide)
                    {
                        this.Stuck = true;
                    }
                }
            }
            else
            {
                this.TorqueForce = -20000000;
            }
        }
        if (!this.Determined)
        {
            if (this.DangerSense > 0)
            {
                this.Broadside = false;
            }
        }
        if ((this.Anger == 1) && !this.Executing)
        {
            this.DangerSense = 0;
            this.Anger = 0;
            this.target = this.Forward;
            if (!this.SuperCruiser)
            {
                this.vRigidbody.angularDrag = 2;
            }
            else
            {
                this.vRigidbody.angularDrag = 1;
            }
        }
        if (!this.SuperCruiser)
        {
            if (AgrianNetwork.instance.RedAlertTime > 1)
            {
                this.Waypoint.position = AgrianNetwork.instance.FullPriorityWaypoint.position;
                if (!this.EngagingEntity)
                {
                    if (this.Anger < 100)
                    {
                        this.Anger = 100;
                        this.target = this.Waypoint;
                    }
                }
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
        if (this.Vel > 100)
        {
            this.vRigidbody.useGravity = false;
        }
        if (this.Anger > 100)
        {
            if (!this.SuperCruiser)
            {
                this.AimForce = 1000;
            }
            else
            {
                this.AimForce = 10000;
            }
        }
        if (this.Pursuit > 0)
        {
            this.Pursuit = this.Pursuit - 1;
            if ((((((this.ExecuteTC1 || this.ExecuteTC3) || this.ExecuteTC4) || this.ExecuteTC6) || this.ExecuteTC7) || this.ExecuteTC8) || this.ExecuteTC9)
            {
                if (this.Anger < 120)
                {
                    this.Anger = 120;
                }
                if (this.target)
                {
                    if (this.target.name.Contains("TC"))
                    {
                        AgrianNetwork.instance.PriorityWaypoint.position = this.target.position;
                        AgrianNetwork.instance.AlertTime = 120;
                    }
                }
            }
            this.Anger = this.Anger + 1;
        }
        if (this.DangerSense > 0)
        {
            this.DangerSense = this.DangerSense - 1;
            this.TorqueForce = -20000000;
        }
        if (!this.EngagingEntity)
        {
            if (this.Anger > 0)
            {
                this.Anger = this.Anger - 1;
            }
        }
        if (this.StillOnHull < 5)
        {
            if (!this.SuperCruiser)
            {
                this.vRigidbody.angularDrag = 2;
            }
            else
            {
                this.vRigidbody.angularDrag = 1;
            }
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
        this.LookingToSide = false;
        if (!this.Executing)
        {
            this.StartCoroutine(this.Notice());
        }
        this.VicinityCheck();
    }

    public virtual IEnumerator Dismiss()
    {
        yield return new WaitForSeconds(15);
        this.Anger = 10;
        this.target = this.Forward;
    }

    public virtual void Damage()
    {
        this.Damaged = true;
    }

    public AgrianExecutorCruiserAI()
    {
        this.AimForce = 300;
        this.TurnForce = 200;
        this.TorqueForce = 20000;
        this.Dist = 2;
        this.SDa = 2;
        this.SD2a = 2;
        this.RightDist = 32;
        this.LeftDist = 32;
        this.RayBurstTime = 1.5f;
    }

}