using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class HelirotorAI : MonoBehaviour
{
    public Transform target;
    public Transform Waypoint;
    public Transform Forward;
    public Transform TargetTrace;
    public Transform TargetLead;
    public SphereCollider TLCol;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public Transform EyeOrigin;
    public Transform Eye;
    public ConfigurableJoint LArm;
    public ConfigurableJoint RArm;
    public CapsuleCollider Trig;
    public LayerMask LookTargetLayers;
    public LayerMask MTargetLayers;
    public int LookSpeed;
    public int MoveForce;
    public int TurnForce;
    public int StrafeForce;
    public GameObject WarningSoundPatrolling;
    public GameObject WarningSoundNotice;
    public GameObject WarningSoundDismiss;
    public GameObject WarningSoundThreat;
    public GameObject Fire1;
    public GameObject RayBurst;
    public GameObject RayGlow;
    public GameObject LastPos;
    public int RayCooldown;
    public int AngerLevel;
    public int Looking;
    public int Shots;
    public bool FiringRay;
    public bool Obstacle;
    public int PissedAtTC0a;
    public int PissedAtTC1;
    public int PissedAtTC3;
    public int PissedAtTC5;
    public int PissedAtTC6;
    public int PissedAtTC7;
    public int PissedAtTC8;
    public int PissedAtTC9;
    public int DangerSense;
    public Vector3 DangerDirection;
    public virtual void Start()
    {
        this.InvokeRepeating("Tick", 3, 100);
        this.InvokeRepeating("Warning", 10, 33);
        this.InvokeRepeating("Shooty", 1, 0.3f);
        this.InvokeRepeating("Regenerator", 1, 1);
        this.InvokeRepeating("CalcLead", 1, 0.15f);
        KabrianLaw.KabrianPolicePresent = true;
    }

    public virtual void Update()
    {
        if (this.target == null)
        {
            this.target = this.Forward;
        }
        Debug.DrawRay(((this.thisTransform.position + (-this.thisVTransform.forward * 10)) + (-this.thisVTransform.up * 7)) + (this.thisVTransform.right * 8), -this.thisVTransform.up * 13f, Color.white);
        if (Physics.Raycast(((this.thisTransform.position + (-this.thisVTransform.forward * 10)) + (-this.thisVTransform.up * 7)) + (this.thisVTransform.right * 8), -this.thisVTransform.up, 13, (int) this.MTargetLayers))
        {
            this.StrafeForce = -50;
            this.Obstacle = true;
        }
        Debug.DrawRay(((this.thisTransform.position + (-this.thisVTransform.forward * 10)) + (-this.thisVTransform.up * 7)) + (-this.thisVTransform.right * 8), -this.thisVTransform.up * 13f, Color.white);
        if (Physics.Raycast(((this.thisTransform.position + (-this.thisVTransform.forward * 10)) + (-this.thisVTransform.up * 7)) + (-this.thisVTransform.right * 8), -this.thisVTransform.up, 13, (int) this.MTargetLayers))
        {
            this.StrafeForce = 50;
            this.Obstacle = true;
        }
        //-----------------------------------------------------------------------------------
        Debug.DrawRay(((this.thisTransform.position + (this.thisVTransform.forward * 5)) + (-this.thisVTransform.up * 5)) + (this.thisVTransform.right * 5), -this.thisVTransform.forward * 15f, Color.white);
        if (Physics.Raycast(((this.thisTransform.position + (this.thisVTransform.forward * 5)) + (-this.thisVTransform.up * 5)) + (this.thisVTransform.right * 5), -this.thisVTransform.forward, 15, (int) this.MTargetLayers))
        {
            this.StrafeForce = -100;
            this.Obstacle = true;
        }
        Debug.DrawRay(((this.thisTransform.position + (this.thisVTransform.forward * 5)) + (-this.thisVTransform.up * 5)) + (-this.thisVTransform.right * 5), -this.thisVTransform.forward * 15f, Color.white);
        if (Physics.Raycast(((this.thisTransform.position + (this.thisVTransform.forward * 5)) + (-this.thisVTransform.up * 5)) + (-this.thisVTransform.right * 5), -this.thisVTransform.forward, 15, (int) this.MTargetLayers))
        {
            this.StrafeForce = 100;
            this.Obstacle = true;
        }
        //-----------------------------------------------------------------------------------
        Debug.DrawRay(((this.thisTransform.position + (this.thisVTransform.forward * 5)) + (-this.thisVTransform.up * 20)) + (this.thisVTransform.right * 10), -this.thisVTransform.forward * 30f, Color.green);
        if (!Physics.Raycast(((this.thisTransform.position + (this.thisVTransform.forward * 5)) + (-this.thisVTransform.up * 20)) + (this.thisVTransform.right * 10), -this.thisVTransform.forward, 30, (int) this.MTargetLayers))
        {
            if (this.AngerLevel < 1)
            {
                this.TurnForce = -200;
                this.target = this.Forward;
            }
            else
            {
                this.TurnForce = -200;
            }
        }
        Debug.DrawRay(((this.thisTransform.position + (this.thisVTransform.forward * 5)) + (-this.thisVTransform.up * 20)) + (-this.thisVTransform.right * 10), -this.thisVTransform.forward * 30f, Color.green);
        if (!Physics.Raycast(((this.thisTransform.position + (this.thisVTransform.forward * 5)) + (-this.thisVTransform.up * 20)) + (-this.thisVTransform.right * 10), -this.thisVTransform.forward, 30, (int) this.MTargetLayers))
        {
            if (this.AngerLevel < 1)
            {
                this.TurnForce = 200;
                this.target = this.Forward;
            }
            else
            {
                this.TurnForce = 200;
            }
        }
        //-----------------------------------------------------------------------------------
        if (!Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 0.5f), this.thisTransform.forward, 300))
        {
            Debug.DrawRay(this.thisTransform.position + (-this.thisVTransform.forward * 10), this.thisVTransform.right * 15f, Color.white);
            if (Physics.Raycast(this.thisTransform.position + (-this.thisVTransform.forward * 10), this.thisVTransform.right, 15, (int) this.MTargetLayers))
            {
                this.StrafeForce = -100;
            }
            Debug.DrawRay(this.thisTransform.position + (-this.thisVTransform.forward * 10), -this.thisVTransform.right * 15f, Color.white);
            if (Physics.Raycast(this.thisTransform.position + (-this.thisVTransform.forward * 10), -this.thisVTransform.right, 15, (int) this.MTargetLayers))
            {
                this.StrafeForce = 100;
            }
        }
        else
        {
            Vector3 newRot = ((this.EyeOrigin.up * -0.6f) + (this.EyeOrigin.right * 0.4f)).normalized;
            Debug.DrawRay(this.thisTransform.position + (-this.EyeOrigin.forward * 10), newRot * 30f, Color.white);
            if (Physics.Raycast(this.thisTransform.position + (-this.EyeOrigin.forward * 10), newRot, 30, (int) this.MTargetLayers))
            {
                this.StrafeForce = -100;
            }
            newRot = ((this.EyeOrigin.up * -0.6f) + (this.EyeOrigin.right * -0.4f)).normalized;
            Debug.DrawRay(this.thisTransform.position + (-this.EyeOrigin.forward * 10), newRot * 30f, Color.white);
            if (Physics.Raycast(this.thisTransform.position + (-this.EyeOrigin.forward * 10), newRot, 30, (int) this.MTargetLayers))
            {
                this.StrafeForce = 100;
            }
        }
        if (this.target)
        {
            if (this.AngerLevel > 1)
            {
                if (Vector3.Distance(this.thisTransform.position, this.target.position) < 20)
                {
                    this.Obstacle = true;
                }
            }
        }
        if ((this.Looking > 0) && !this.Obstacle)
        {
            this.MoveForce = 0;
        }
        if ((this.DangerSense > 0) && !this.Obstacle)
        {
            this.MoveForce = 100;
        }
        if ((this.Looking < 1) && !this.Obstacle)
        {
            this.MoveForce = 80;
        }
        if (!this.Obstacle && (this.AngerLevel > 1))
        {
            this.MoveForce = 100;
        }
        if (this.Obstacle && (this.AngerLevel < 1))
        {
            this.MoveForce = -100;
        }
        if (this.Obstacle && (this.AngerLevel > 1))
        {
            this.MoveForce = -120;
            this.StrafeForce = 50;
        }
    }

    private Quaternion NewRotation;
    public virtual void FixedUpdate()
    {
        if (this.Looking < 1)
        {
            this.vRigidbody.AddForce(this.EyeOrigin.right * this.StrafeForce);
            this.vRigidbody.AddTorque(this.thisVTransform.forward * this.TurnForce);
        }
        this.vRigidbody.AddForce(-this.thisVTransform.up * this.MoveForce);
        this.GetComponent<Rigidbody>().freezeRotation = true;
        if (this.target)
        {
            if (this.DangerSense < 1)
            {
                if (this.AngerLevel > 10)
                {
                    if (!this.FiringRay)
                    {
                        this.NewRotation = Quaternion.LookRotation(this.TargetLead.position - this.thisTransform.position);
                    }
                    else
                    {
                        this.NewRotation = Quaternion.LookRotation(this.target.position - this.thisTransform.position);
                    }
                }
                else
                {
                    this.NewRotation = Quaternion.LookRotation(this.target.position - this.thisTransform.position);
                }
            }
            if ((this.DangerSense > 0) && (this.DangerDirection != Vector3.zero))
            {
                this.NewRotation = Quaternion.LookRotation(this.DangerDirection);
            }
            this.thisTransform.rotation = Quaternion.RotateTowards(this.thisTransform.rotation, this.NewRotation, Time.deltaTime * this.LookSpeed);
        }
        if (this.AngerLevel > 30)
        {
            this.LookSpeed = 300;
        }
        else
        {
            this.LookSpeed = 150;
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (!this.FiringRay)
        {
            if (other.GetComponent<Collider>().name.Contains("TFC"))
            {
                if (!other.GetComponent<Collider>().name.Contains("TFC2"))
                {
                    if (this.target)
                    {
                        if (other.GetComponent<Rigidbody>())
                        {
                            Vector3 relativePoint0 = other.transform.InverseTransformPoint(this.thisTransform.position);
                            float FAndB = relativePoint0.z;
                            if (FAndB > 0)
                            {
                                this.DangerDirection = -other.GetComponent<Rigidbody>().velocity.normalized;
                            }
                            else
                            {
                                this.DangerDirection = other.GetComponent<Rigidbody>().velocity.normalized;
                            }
                            this.target = null;
                        }
                        if ((this.DangerSense < 1) && (this.AngerLevel < 1))
                        {
                            GameObject TheThing0 = UnityEngine.Object.Instantiate(this.WarningSoundThreat, this.thisTransform.position + new Vector3(0, -2, 0), Quaternion.identity);
                            TheThing0.transform.parent = this.thisTransform;
                        }
                        this.DangerSense = 30;
                        this.Looking = 0;
                    }
                    if (other.GetComponent<Collider>().name.Contains("TFC0a"))
                    {
                        if (this.AngerLevel < 5)
                        {
                            this.PissedAtTC0a = 5;
                        }
                        else
                        {
                            this.PissedAtTC0a = 10;
                        }
                        if (this.target)
                        {
                            if (!this.target.name.Contains("C0a") && (this.AngerLevel < 5))
                            {
                                this.target = null;
                            }
                        }
                    }
                    if (other.GetComponent<Collider>().name.Contains("TFC1"))
                    {
                        Vector3 relativePoint = other.transform.InverseTransformPoint(this.thisTransform.position);
                        float FAndB = relativePoint.z;
                        if (FAndB > 0)
                        {
                            if (this.AngerLevel < 5)
                            {
                                this.PissedAtTC1 = 5;
                            }
                            else
                            {
                                this.PissedAtTC1 = 10;
                            }
                        }
                        if (this.target)
                        {
                            if (!this.target.name.Contains("C1") && (this.AngerLevel < 50))
                            {
                                this.target = null;
                            }
                        }
                    }
                    if (other.GetComponent<Collider>().name.Contains("TFC3"))
                    {
                        if (this.AngerLevel < 5)
                        {
                            this.PissedAtTC3 = 5;
                        }
                        else
                        {
                            this.PissedAtTC3 = 10;
                        }
                        if (this.target)
                        {
                            if (!this.target.name.Contains("C3") && (this.AngerLevel < 50))
                            {
                                this.target = null;
                            }
                        }
                    }
                    if (other.GetComponent<Collider>().name.Contains("TFC5"))
                    {
                        if (this.AngerLevel < 5)
                        {
                            this.PissedAtTC5 = 5;
                        }
                        else
                        {
                            this.PissedAtTC5 = 10;
                        }
                        if (this.target)
                        {
                            if (!this.target.name.Contains("C5") && (this.AngerLevel < 50))
                            {
                                this.target = null;
                            }
                        }
                    }
                    if (other.GetComponent<Collider>().name.Contains("TFC6"))
                    {
                        if (this.AngerLevel < 5)
                        {
                            this.PissedAtTC6 = 5;
                        }
                        else
                        {
                            this.PissedAtTC6 = 10;
                        }
                        if (this.target)
                        {
                            if (!this.target.name.Contains("C6") && (this.AngerLevel < 50))
                            {
                                this.target = null;
                            }
                        }
                    }
                    if (other.GetComponent<Collider>().name.Contains("TFC7"))
                    {
                        if (this.AngerLevel < 5)
                        {
                            this.PissedAtTC7 = 5;
                        }
                        else
                        {
                            this.PissedAtTC7 = 10;
                        }
                        if (this.target)
                        {
                            if (!this.target.name.Contains("C7") && (this.AngerLevel < 50))
                            {
                                this.target = null;
                            }
                        }
                    }
                    if (other.GetComponent<Collider>().name.Contains("TFC8"))
                    {
                        if (this.AngerLevel < 5)
                        {
                            this.PissedAtTC8 = 5;
                        }
                        else
                        {
                            this.PissedAtTC8 = 10;
                        }
                        if (this.target)
                        {
                            if (!this.target.name.Contains("C8") && (this.AngerLevel < 50))
                            {
                                this.target = null;
                            }
                        }
                    }
                    if (other.GetComponent<Collider>().name.Contains("TFC9"))
                    {
                        if (this.AngerLevel < 5)
                        {
                            this.PissedAtTC9 = 5;
                        }
                        else
                        {
                            this.PissedAtTC9 = 10;
                        }
                        if (this.target)
                        {
                            if (!this.target.name.Contains("C9") && (this.AngerLevel < 50))
                            {
                                this.target = null;
                            }
                        }
                    }
                    //---------------------------------------------------------------
                    if (this.AngerLevel < 200)
                    {
                        if (other.GetComponent<Collider>().name.Contains("#1"))
                        {
                            this.AngerLevel = this.AngerLevel + 1;
                        }
                        if (other.GetComponent<Collider>().name.Contains("#2"))
                        {
                            this.AngerLevel = this.AngerLevel + 10;
                        }
                        if (other.GetComponent<Collider>().name.Contains("#3"))
                        {
                            this.AngerLevel = this.AngerLevel + 60;
                        }
                    }
                }
            }
            if ((this.AngerLevel < 1) && (this.Looking < 1))
            {
                if (other.GetComponent<Collider>().name.Contains("TC"))
                {
                    this.target = other.gameObject.transform;
                    this.Looking = 20;
                    GameObject TheThing2 = UnityEngine.Object.Instantiate(this.WarningSoundNotice, this.thisTransform.position + new Vector3(0, -2, 0), Quaternion.identity);
                    TheThing2.transform.parent = this.thisTransform;
                }
            }
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if (!this.FiringRay)
        {
            if (other.GetComponent<Collider>().name.Contains("TC0a") && (this.PissedAtTC0a > 0))
            {
                this.DangerSense = 0;
                this.Looking = 0;
                this.target = other.gameObject.transform;
                this.LArm.targetRotation = Quaternion.Euler(180, 45, 0);
                this.RArm.targetRotation = Quaternion.Euler(180, 45, 0);
                if (Vector3.Distance(other.transform.position, this.thisTransform.position) < Vector3.Distance(this.thisTransform.position, this.target.position))
                {
                    this.target = other.gameObject.transform;
                }
            }
            if (other.GetComponent<Collider>().name.Contains("TC1") && (this.PissedAtTC1 > 0))
            {
                this.DangerSense = 0;
                this.Looking = 0;
                if ((AgrianNetwork.TC1CriminalLevel > 240) && (this.AngerLevel < 10))
                {
                    this.AngerLevel = 20;
                }
                this.target = other.gameObject.transform;
                this.LArm.targetRotation = Quaternion.Euler(180, 45, 0);
                this.RArm.targetRotation = Quaternion.Euler(180, 45, 0);
                if (Vector3.Distance(other.transform.position, this.thisTransform.position) < Vector3.Distance(this.thisTransform.position, this.target.position))
                {
                    this.target = other.gameObject.transform;
                }
            }
            if (other.GetComponent<Collider>().name.Contains("TC3") && (this.PissedAtTC3 > 0))
            {
                this.DangerSense = 0;
                this.Looking = 0;
                this.target = other.gameObject.transform;
                this.LArm.targetRotation = Quaternion.Euler(180, 45, 0);
                this.RArm.targetRotation = Quaternion.Euler(180, 45, 0);
            }
            if (other.GetComponent<Collider>().name.Contains("TC4"))
            {
                this.DangerSense = 0;
                this.Looking = 0;
                this.AngerLevel = 20;
                this.target = other.gameObject.transform;
                this.LArm.targetRotation = Quaternion.Euler(180, 45, 0);
                this.RArm.targetRotation = Quaternion.Euler(180, 45, 0);
                if (Vector3.Distance(other.transform.position, this.thisTransform.position) < Vector3.Distance(this.thisTransform.position, this.target.position))
                {
                    this.target = other.gameObject.transform;
                }
            }
            if (other.GetComponent<Collider>().name.Contains("TC5") && (this.PissedAtTC5 > 0))
            {
                this.DangerSense = 0;
                this.Looking = 0;
                if ((AgrianNetwork.TC5CriminalLevel > 240) && (this.AngerLevel < 10))
                {
                    this.AngerLevel = 20;
                }
                this.target = other.gameObject.transform;
                this.LArm.targetRotation = Quaternion.Euler(180, 45, 0);
                this.RArm.targetRotation = Quaternion.Euler(180, 45, 0);
                if (Vector3.Distance(other.transform.position, this.thisTransform.position) < Vector3.Distance(this.thisTransform.position, this.target.position))
                {
                    this.target = other.gameObject.transform;
                }
            }
            if (other.GetComponent<Collider>().name.Contains("TC6") && (this.PissedAtTC6 > 0))
            {
                this.DangerSense = 0;
                this.Looking = 0;
                if ((AgrianNetwork.TC6CriminalLevel > 240) && (this.AngerLevel < 10))
                {
                    this.AngerLevel = 20;
                }
                this.target = other.gameObject.transform;
                this.LArm.targetRotation = Quaternion.Euler(180, 45, 0);
                this.RArm.targetRotation = Quaternion.Euler(180, 45, 0);
                if (Vector3.Distance(other.transform.position, this.thisTransform.position) < Vector3.Distance(this.thisTransform.position, this.target.position))
                {
                    this.target = other.gameObject.transform;
                }
            }
            if (other.GetComponent<Collider>().name.Contains("TC7") && (this.PissedAtTC7 > 0))
            {
                this.DangerSense = 0;
                this.Looking = 0;
                if ((AgrianNetwork.TC7CriminalLevel > 240) && (this.AngerLevel < 10))
                {
                    this.AngerLevel = 20;
                }
                this.target = other.gameObject.transform;
                this.LArm.targetRotation = Quaternion.Euler(180, 45, 0);
                this.RArm.targetRotation = Quaternion.Euler(180, 45, 0);
                if (Vector3.Distance(other.transform.position, this.thisTransform.position) < Vector3.Distance(this.thisTransform.position, this.target.position))
                {
                    this.target = other.gameObject.transform;
                }
            }
            if (other.GetComponent<Collider>().name.Contains("TC8") && (this.PissedAtTC8 > 0))
            {
                this.DangerSense = 0;
                this.Looking = 0;
                if ((AgrianNetwork.TC8CriminalLevel > 240) && (this.AngerLevel < 10))
                {
                    this.AngerLevel = 20;
                }
                this.target = other.gameObject.transform;
                this.LArm.targetRotation = Quaternion.Euler(180, 45, 0);
                this.RArm.targetRotation = Quaternion.Euler(180, 45, 0);
                if (Vector3.Distance(other.transform.position, this.thisTransform.position) < Vector3.Distance(this.thisTransform.position, this.target.position))
                {
                    this.target = other.gameObject.transform;
                }
            }
            if (other.GetComponent<Collider>().name.Contains("TC9") && (this.PissedAtTC9 > 0))
            {
                this.DangerSense = 0;
                this.Looking = 0;
                if ((AgrianNetwork.TC9CriminalLevel > 240) && (this.AngerLevel < 10))
                {
                    this.AngerLevel = 20;
                }
                this.target = other.gameObject.transform;
                this.LArm.targetRotation = Quaternion.Euler(180, 45, 0);
                this.RArm.targetRotation = Quaternion.Euler(180, 45, 0);
                if (Vector3.Distance(other.transform.position, this.thisTransform.position) < Vector3.Distance(this.thisTransform.position, this.target.position))
                {
                    this.target = other.gameObject.transform;
                }
            }
            if (other.GetComponent<Collider>().name.Contains("TFC") && (this.AngerLevel > 60))
            {
                this.LArm.targetRotation = Quaternion.Euler(180, 45, 0);
                this.RArm.targetRotation = Quaternion.Euler(180, 45, 0);
                this.StartCoroutine(this.ReadyRay());
            }
            if ((other.GetComponent<Collider>().name.Contains("TC0a") && (this.PissedAtTC0a > 9)) && (this.AngerLevel > 60))
            {
                this.target = other.gameObject.transform;
                if (this.Eye)
                {
                    this.StartCoroutine(this.RayControl());
                }
            }
            if ((other.GetComponent<Collider>().name.Contains("TC1") && (this.PissedAtTC1 > 9)) && (this.AngerLevel > 60))
            {
                this.target = other.gameObject.transform;
                if (this.Eye)
                {
                    this.StartCoroutine(this.RayControl());
                }
            }
            if ((other.GetComponent<Collider>().name.Contains("TC3") && (this.PissedAtTC3 > 0)) && (this.AngerLevel > 60))
            {
                this.target = other.gameObject.transform;
                if (this.Eye)
                {
                    this.StartCoroutine(this.RayControl());
                }
            }
            if (other.GetComponent<Collider>().name.Contains("TC4") && (this.AngerLevel > 60))
            {
                this.target = other.gameObject.transform;
                if (this.Eye)
                {
                    this.StartCoroutine(this.RayControl());
                }
            }
            if ((other.GetComponent<Collider>().name.Contains("TC5") && (this.PissedAtTC5 > 0)) && (this.AngerLevel > 60))
            {
                this.target = other.gameObject.transform;
                if (this.Eye)
                {
                    this.StartCoroutine(this.RayControl());
                }
            }
            if ((other.GetComponent<Collider>().name.Contains("TC6") && (this.PissedAtTC6 > 0)) && (this.AngerLevel > 60))
            {
                this.target = other.gameObject.transform;
                if (this.Eye)
                {
                    this.StartCoroutine(this.RayControl());
                }
            }
            if ((other.GetComponent<Collider>().name.Contains("TC7") && (this.PissedAtTC7 > 0)) && (this.AngerLevel > 60))
            {
                this.target = other.gameObject.transform;
                if (this.Eye)
                {
                    this.StartCoroutine(this.RayControl());
                }
            }
            if ((other.GetComponent<Collider>().name.Contains("TC8") && (this.PissedAtTC8 > 0)) && (this.AngerLevel > 60))
            {
                this.target = other.gameObject.transform;
                if (this.Eye)
                {
                    this.StartCoroutine(this.RayControl());
                }
            }
            if ((other.GetComponent<Collider>().name.Contains("TC9") && (this.PissedAtTC9 > 0)) && (this.AngerLevel > 60))
            {
                this.target = other.gameObject.transform;
                if (this.Eye)
                {
                    this.StartCoroutine(this.RayControl());
                }
            }
        }
    }

    // FIRINGS -------------------------------------------------------------------------------------------------------------
    public virtual void Shooty()
    {
        if (this.Eye)
        {
            if ((!this.FiringRay && (this.Shots > 1)) && (this.AngerLevel > 15))
            {
                this.Shoot();
            }
        }
    }

    public virtual void Shoot()
    {
        RaycastHit hit = default(RaycastHit);
        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 0.5f), this.thisTransform.forward, out hit, 500, (int) this.LookTargetLayers))
        {
            if (!hit.collider.name.Contains("T2Obscure"))
            {
                if (hit.collider.name.Contains("TC"))
                {
                    this.AngerLevel = this.AngerLevel - 5;
                }
                if (this.target)
                {
                    if (this.target.name.Contains("TC0a") && (this.PissedAtTC0a > 5))
                    {
                        if (hit.collider.name.Contains("TL2") || hit.collider.name.Contains("TC0a"))
                        {
                            UnityEngine.Object.Instantiate(this.Fire1, this.thisTransform.position + (this.thisTransform.forward * 0.8f), this.thisTransform.rotation);
                        }
                    }
                    if (this.target.name.Contains("TC1") && (this.PissedAtTC1 > 5))
                    {
                        if (hit.collider.name.Contains("TL2") || hit.collider.name.Contains("TC1"))
                        {
                            UnityEngine.Object.Instantiate(this.Fire1, this.thisTransform.position + (this.thisTransform.forward * 0.8f), this.thisTransform.rotation);
                        }
                    }
                    if (this.target.name.Contains("TC3") && (this.PissedAtTC3 > 5))
                    {
                        if (hit.collider.name.Contains("TL2") || hit.collider.name.Contains("TC3"))
                        {
                            UnityEngine.Object.Instantiate(this.Fire1, this.thisTransform.position + (this.thisTransform.forward * 0.8f), this.thisTransform.rotation);
                        }
                    }
                    if (this.target.name.Contains("TC4"))
                    {
                        if (hit.collider.name.Contains("TL2") || hit.collider.name.Contains("TC4"))
                        {
                            UnityEngine.Object.Instantiate(this.Fire1, this.thisTransform.position + (this.thisTransform.forward * 0.8f), this.thisTransform.rotation);
                        }
                    }
                    if (this.target.name.Contains("TC5") && (this.PissedAtTC5 > 5))
                    {
                        if (hit.collider.name.Contains("TL2") || hit.collider.name.Contains("TC5"))
                        {
                            UnityEngine.Object.Instantiate(this.Fire1, this.thisTransform.position + (this.thisTransform.forward * 0.8f), this.thisTransform.rotation);
                        }
                    }
                    if (this.target.name.Contains("TC6") && (this.PissedAtTC6 > 5))
                    {
                        if (hit.collider.name.Contains("TL2") || hit.collider.name.Contains("TC6"))
                        {
                            UnityEngine.Object.Instantiate(this.Fire1, this.thisTransform.position + (this.thisTransform.forward * 0.8f), this.thisTransform.rotation);
                        }
                    }
                    if (this.target.name.Contains("TC7") && (this.PissedAtTC7 > 5))
                    {
                        if (hit.collider.name.Contains("TL2") || hit.collider.name.Contains("TC7"))
                        {
                            UnityEngine.Object.Instantiate(this.Fire1, this.thisTransform.position + (this.thisTransform.forward * 0.8f), this.thisTransform.rotation);
                        }
                    }
                    if (this.target.name.Contains("TC8") && (this.PissedAtTC8 > 5))
                    {
                        if (hit.collider.name.Contains("TL2") || hit.collider.name.Contains("TC8"))
                        {
                            UnityEngine.Object.Instantiate(this.Fire1, this.thisTransform.position + (this.thisTransform.forward * 0.8f), this.thisTransform.rotation);
                        }
                    }
                    if (this.target.name.Contains("TC9") && (this.PissedAtTC9 > 5))
                    {
                        if (hit.collider.name.Contains("TL2") || hit.collider.name.Contains("TC9"))
                        {
                            UnityEngine.Object.Instantiate(this.Fire1, this.thisTransform.position + (this.thisTransform.forward * 0.8f), this.thisTransform.rotation);
                        }
                    }
                    this.Shots = this.Shots - 2;
                }
            }
        }
    }

    public virtual IEnumerator ReadyRay()
    {
        yield return new WaitForSeconds(0.5f);
        this.Trig.center = new Vector3(0, 0, 1000);
        this.Trig.radius = 70;
        this.Trig.height = 2000;
    }

    public virtual IEnumerator RayControl()
    {
        RaycastHit hit = default(RaycastHit);
        if (this.target != null)
        {
            if (this.RayCooldown == 0)
            {
                if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 0.5f), this.thisTransform.forward, out hit, 5000, (int) this.LookTargetLayers))
                {
                    if (Vector3.Distance(this.thisTransform.position, this.target.position) > 50)
                    {
                        if (hit.collider.name.Contains(this.target.name))
                        {
                            this.FiringRay = true;
                            GameObject TheThing3 = UnityEngine.Object.Instantiate(this.RayGlow, this.thisTransform.position, Quaternion.Euler(this.thisTransform.eulerAngles.x, this.thisTransform.eulerAngles.y, this.thisTransform.eulerAngles.z));
                            TheThing3.transform.parent = this.thisTransform;
                            yield return new WaitForSeconds(1);
                            UnityEngine.Object.Instantiate(this.RayBurst, this.thisTransform.position, Quaternion.Euler(this.thisTransform.eulerAngles.x, this.thisTransform.eulerAngles.y, this.thisTransform.eulerAngles.z));
                            this.Trig.center = new Vector3(0, 0, 0);
                            this.Trig.radius = 50;
                            this.Trig.height = 50;
                            this.AngerLevel = 10;
                            this.RayCooldown = 10;
                            this.FiringRay = false;
                        }
                    }
                }
            }
        }
    }

    public virtual void CalcLead()
    {
        this.StartCoroutine(this.Lead());
    }

    public virtual IEnumerator Lead()
    {
        if (this.target)
        {
            this.TargetTrace.position = this.target.position;
        }
        yield return new WaitForSeconds(0.1f);
        if (this.target)
        {
            float Dist1 = Vector3.Distance(this.thisTransform.position, this.target.position);
            float Dist2 = Vector3.Distance(this.TargetTrace.position, this.target.position);
            this.TargetTrace.LookAt(this.target);
            this.TargetLead.position = this.TargetTrace.position;
            this.TargetLead.rotation = this.TargetTrace.rotation;
            this.TargetLead.position = this.TargetLead.position + (((this.TargetLead.forward * Dist1) * Dist2) * 0.02f);
            if (this.AngerLevel > 10)
            {
                this.TLCol.radius = 20;
            }
            else
            {
                this.TLCol.radius = 0.1f;
            }
        }
    }

    // FIRINGS -------------------------------------------------------------------------------------------------------------
    public virtual void Regenerator()
    {
        if (this.target)
        {
            if (this.target.name.Contains("TC") && (this.DangerSense > 0))
            {
                this.DangerSense = 0;
            }
            if (AgrianNetwork.TC1CriminalLevel < 500)
            {
                if ((AgrianNetwork.TC1CriminalLevel > 240) && this.target.name.Contains("TC1"))
                {
                    AgrianNetwork.TC1CriminalLevel = 360;
                }
            }
            else
            {
                if (this.target.name.Contains("TC1"))
                {
                    if (AgrianNetwork.instance.RedAlertTime > 0)
                    {
                        AgrianNetwork.instance.FullPriorityWaypoint.transform.position = this.target.position;
                    }
                    if (AgrianNetwork.instance.AlertTime < 300)
                    {
                        AgrianNetwork.instance.AlertTime = 300;
                    }
                    AgrianNetwork.TC1CriminalLevel = 620;
                }
            }
            if (AgrianNetwork.TC4CriminalLevel < 500)
            {
                if ((AgrianNetwork.TC4CriminalLevel > 240) && this.target.name.Contains("TC4"))
                {
                    AgrianNetwork.TC4CriminalLevel = 360;
                }
            }
            else
            {
                if (this.target.name.Contains("TC4"))
                {
                    if (AgrianNetwork.instance.RedAlertTime > 0)
                    {
                        AgrianNetwork.instance.FullPriorityWaypoint.transform.position = this.target.position;
                    }
                    if (AgrianNetwork.instance.AlertTime < 300)
                    {
                        AgrianNetwork.instance.AlertTime = 300;
                    }
                    AgrianNetwork.TC4CriminalLevel = 620;
                }
            }
            if (AgrianNetwork.TC5CriminalLevel < 500)
            {
                if ((AgrianNetwork.TC5CriminalLevel > 240) && this.target.name.Contains("TC5"))
                {
                    AgrianNetwork.TC5CriminalLevel = 360;
                }
            }
            else
            {
                if (this.target.name.Contains("TC5"))
                {
                    if (AgrianNetwork.instance.RedAlertTime > 0)
                    {
                        AgrianNetwork.instance.FullPriorityWaypoint.transform.position = this.target.position;
                    }
                    if (AgrianNetwork.instance.AlertTime < 300)
                    {
                        AgrianNetwork.instance.AlertTime = 300;
                    }
                    AgrianNetwork.TC5CriminalLevel = 620;
                }
            }
            if (AgrianNetwork.TC6CriminalLevel < 500)
            {
                if ((AgrianNetwork.TC6CriminalLevel > 240) && this.target.name.Contains("TC6"))
                {
                    AgrianNetwork.TC6CriminalLevel = 360;
                }
            }
            else
            {
                if (this.target.name.Contains("TC6"))
                {
                    if (AgrianNetwork.instance.RedAlertTime > 0)
                    {
                        AgrianNetwork.instance.FullPriorityWaypoint.transform.position = this.target.position;
                    }
                    if (AgrianNetwork.instance.AlertTime < 300)
                    {
                        AgrianNetwork.instance.AlertTime = 300;
                    }
                    AgrianNetwork.TC6CriminalLevel = 620;
                }
            }
            if (AgrianNetwork.TC7CriminalLevel < 500)
            {
                if ((AgrianNetwork.TC7CriminalLevel > 240) && this.target.name.Contains("TC7"))
                {
                    AgrianNetwork.TC7CriminalLevel = 360;
                }
            }
            else
            {
                if (this.target.name.Contains("TC7"))
                {
                    if (AgrianNetwork.instance.RedAlertTime > 0)
                    {
                        AgrianNetwork.instance.FullPriorityWaypoint.transform.position = this.target.position;
                    }
                    if (AgrianNetwork.instance.AlertTime < 300)
                    {
                        AgrianNetwork.instance.AlertTime = 300;
                    }
                    AgrianNetwork.TC7CriminalLevel = 620;
                }
            }
            if (AgrianNetwork.TC8CriminalLevel < 500)
            {
                if ((AgrianNetwork.TC8CriminalLevel > 240) && this.target.name.Contains("TC8"))
                {
                    AgrianNetwork.TC8CriminalLevel = 360;
                }
            }
            else
            {
                if (this.target.name.Contains("TC8"))
                {
                    if (AgrianNetwork.instance.RedAlertTime > 0)
                    {
                        AgrianNetwork.instance.FullPriorityWaypoint.transform.position = this.target.position;
                    }
                    if (AgrianNetwork.instance.AlertTime < 300)
                    {
                        AgrianNetwork.instance.AlertTime = 300;
                    }
                    AgrianNetwork.TC8CriminalLevel = 620;
                }
            }
            if (AgrianNetwork.TC9CriminalLevel < 500)
            {
                if ((AgrianNetwork.TC9CriminalLevel > 240) && this.target.name.Contains("TC9"))
                {
                    AgrianNetwork.TC9CriminalLevel = 360;
                }
            }
            else
            {
                if (this.target.name.Contains("TC9"))
                {
                    if (AgrianNetwork.instance.RedAlertTime > 0)
                    {
                        AgrianNetwork.instance.FullPriorityWaypoint.transform.position = this.target.position;
                    }
                    if (AgrianNetwork.instance.AlertTime < 300)
                    {
                        AgrianNetwork.instance.AlertTime = 300;
                    }
                    AgrianNetwork.TC9CriminalLevel = 620;
                }
            }
        }
        if ((AgrianNetwork.TC1CriminalLevel > 240) && (this.PissedAtTC1 < 1))
        {
            this.PissedAtTC1 = 10;
        }
        if ((AgrianNetwork.TC5CriminalLevel > 240) && (this.PissedAtTC5 < 1))
        {
            this.PissedAtTC5 = 10;
        }
        if ((AgrianNetwork.TC6CriminalLevel > 240) && (this.PissedAtTC6 < 1))
        {
            this.PissedAtTC6 = 10;
        }
        if ((AgrianNetwork.TC7CriminalLevel > 240) && (this.PissedAtTC7 < 1))
        {
            this.PissedAtTC7 = 10;
        }
        if ((AgrianNetwork.TC8CriminalLevel > 240) && (this.PissedAtTC8 < 1))
        {
            this.PissedAtTC8 = 10;
        }
        if ((AgrianNetwork.TC9CriminalLevel > 240) && (this.PissedAtTC9 < 1))
        {
            this.PissedAtTC9 = 10;
        }
        if (this.target)
        {
            if (this.AngerLevel < 60)
            {
                if (this.target.name.Contains("TC"))
                {
                    this.Trig.center = new Vector3(0, 0, 0);
                    this.Trig.radius = 50;
                    this.Trig.height = 50;
                }
                else
                {
                    this.Trig.center = new Vector3(0, 0, 100);
                    this.Trig.radius = 100;
                    this.Trig.height = 400;
                }
            }
        }
        if (this.DangerSense < 1)
        {
            if (AgrianNetwork.instance.AlertTime > 1)
            {
                if (this.AngerLevel < 10)
                {
                    this.Waypoint.position = AgrianNetwork.instance.PriorityWaypoint.position;
                    this.target = this.Waypoint;
                }
            }
        }
        if (AgrianNetwork.instance.RedAlertTime > 1)
        {
            if (this.AngerLevel < 10)
            {
                this.Waypoint.position = AgrianNetwork.instance.FullPriorityWaypoint.position;
                this.target = this.Waypoint;
            }
        }
        if (this.DangerSense > 0)
        {
            this.DangerSense = this.DangerSense - 1;
        }
        this.TurnForce = 0;
        this.StrafeForce = 0;
        if (this.Shots < 6)
        {
            this.Shots = this.Shots + 1;
        }
        if (this.RayCooldown > 0)
        {
            this.RayCooldown = this.RayCooldown - 1;
            if (this.AngerLevel > 60)
            {
                this.AngerLevel = 60;
            }
        }
        if (this.AngerLevel > 0)
        {
            this.AngerLevel = this.AngerLevel - 1;
        }
        if (this.Looking > 0)
        {
            this.Looking = this.Looking - 1;
        }
        if (this.PissedAtTC1 > 0)
        {
            this.PissedAtTC1 = this.PissedAtTC1 - 1;
        }
        if (this.PissedAtTC3 > 0)
        {
            this.PissedAtTC3 = this.PissedAtTC3 - 1;
        }
        if (this.PissedAtTC5 > 0)
        {
            this.PissedAtTC5 = this.PissedAtTC5 - 1;
        }
        if (this.PissedAtTC6 > 0)
        {
            this.PissedAtTC6 = this.PissedAtTC6 - 1;
        }
        if (this.PissedAtTC7 > 0)
        {
            this.PissedAtTC7 = this.PissedAtTC7 - 1;
        }
        if (this.PissedAtTC8 > 0)
        {
            this.PissedAtTC8 = this.PissedAtTC8 - 1;
        }
        if (this.PissedAtTC9 > 0)
        {
            this.PissedAtTC9 = this.PissedAtTC9 - 1;
        }
        if (this.AngerLevel < 5)
        {
            this.LArm.targetRotation = Quaternion.Euler(0, 0, 0);
            this.RArm.targetRotation = Quaternion.Euler(0, 0, 0);
        }
        if (this.target)
        {
            if (this.DangerSense == 1)
            {
                if ((this.AngerLevel > 5) && !this.target.name.Contains("TC"))
                {
                    this.AngerLevel = 0;
                    this.target = this.Waypoint;
                }
            }
        }
        if (this.Looking == 1)
        {
            if (this.AngerLevel < 5)
            {
                this.target = this.Waypoint;
                GameObject TheThing5 = UnityEngine.Object.Instantiate(this.WarningSoundDismiss, this.thisTransform.position + new Vector3(0, -2, 0), Quaternion.identity);
                TheThing5.transform.parent = this.thisTransform;
                this.Trig.center = new Vector3(0, 0, 100);
                this.Trig.radius = 100;
                this.Trig.height = 400;
            }
        }
        this.Obstacle = false;
    }

    public virtual IEnumerator Tick()
    {
        this.target = this.Waypoint;
        yield return new WaitForSeconds(2);
        this.target = this.Forward;
    }

    public virtual void Warning()
    {
        if (this.AngerLevel < 1)
        {
            GameObject TheThing6 = UnityEngine.Object.Instantiate(this.WarningSoundPatrolling, this.thisTransform.position + new Vector3(0, -2, 0), Quaternion.identity);
            TheThing6.transform.parent = this.thisTransform;
            this.Waypoint.position = this.transform.parent.parent.transform.position;
        }
    }

    public HelirotorAI()
    {
        this.LookSpeed = 5;
    }

}