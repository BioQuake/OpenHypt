using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SlavuicMachineAI : MonoBehaviour
{
    public Transform target;
    public Transform ResetView;
    public Transform AssignedTarget;
    public Transform MemorizedTarget;
    public Transform Home;
    public SphereCollider Trig;
    public VehicleDamage Hull;
    public RemoveOverTime NpcController;
    public MeshCollider hullCol;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public Transform vPoint;
    public Transform TargetTrace;
    public Transform TargetLead;
    public SphereCollider TLCol;
    public bool Satnik;
    public bool Strelnik;
    public bool Smertnik;
    public bool Baseless;
    public Transform Muzzle;
    public GameObject Explosion;
    public GameObject Shot;
    public NPCGun Gun;
    public AudioSource AttackSound;
    public int PissedAtTC0a;
    public int PissedAtTC1;
    public int PissedAtTC3;
    public int PissedAtTC4;
    public int PissedAtTC6;
    public int PissedAtTC7;
    public int PissedAtTC8;
    public int PissedAtTC9;
    public float ObsStartY;
    public float ObsStartZ;
    public float RightDist;
    public float LeftDist;
    public float UpDist;
    public float DownDist;
    public int ObsDist;
    public float Dist;
    public float StabForce;
    public float Diff;
    public float RD;
    public float Vel;
    public Vector3 RelTarg;
    public bool TurnRight;
    public bool TurnLeft;
    public bool TurnUp;
    public bool TurnDown;
    public bool TurnAwayBlyat;
    public int Obstacle;
    public bool Hunting;
    public int Suspicious;
    public bool Approach;
    public bool Aim;
    public LayerMask targetLayers;
    public float UniqueShootTime;
    public virtual IEnumerator Start()
    {
        this.InvokeRepeating("Updater", 1, 1);
        this.InvokeRepeating("Shooty", this.UniqueShootTime, 0.1f);
        this.InvokeRepeating("CalcLead", 1, 0.15f);
        if (this.Strelnik)
        {
            this.Suspicious = 6;
            this.Approach = true;
        }
        this.vRigidbody.useGravity = false;
        this.UniqueShootTime = Random.Range(1, 2);
        yield return new WaitForSeconds(0.3f);
        if (!this.Smertnik)
        {
            this.vRigidbody.useGravity = true;
        }
        this.hullCol.enabled = true;
        this.Hunting = true;
        yield return new WaitForSeconds(0.2f);
        this.vRigidbody.centerOfMass = new Vector3(0, 0, 0);
    }

    public virtual void Update()
    {
        Vector3 newRot2 = default(Vector3);
        RaycastHit hit0 = default(RaycastHit);
        RaycastHit hit1 = default(RaycastHit);
        RaycastHit hit2 = default(RaycastHit);
        float VelClamp = Mathf.Clamp(this.Vel, 20, 80);
        if (!this.Smertnik)
        {
            //var newRot2 : Vector3 = (vRigidbody.velocity);
            //if(Vel < 25)
            newRot2 = -this.thisVTransform.up;
            this.vPoint.rotation = Quaternion.LookRotation(newRot2);
            Vector3 newRot = -this.thisVTransform.up.normalized;
            if (this.target)
            {
                this.Dist = Vector3.Distance(this.thisTransform.position, this.target.position);
            }
            newRot = ((-this.thisVTransform.up * 1f) + (-this.thisVTransform.forward * 1f)).normalized;
            if (this.Vel > 64)
            {
                Debug.DrawRay(this.thisVTransform.position, newRot * this.ObsDist, Color.white);
                if (Physics.Raycast(this.thisVTransform.position, newRot, out hit0, this.ObsDist, (int) this.targetLayers))
                {
                    if (this.ObsDist > 500)
                    {
                        if (hit0.distance < 800)
                        {
                            this.Obstacle = 4;
                        }
                        else
                        {
                            this.Obstacle = 2;
                        }
                    }
                    else
                    {
                        if (hit0.distance < 100)
                        {
                            if (hit0.distance < 20)
                            {
                                this.Obstacle = 8;
                            }
                            else
                            {
                                this.Obstacle = 4;
                            }
                        }
                        else
                        {
                            this.Obstacle = 2;
                        }
                    }
                }
                else
                {
                    this.Obstacle = 0;
                }
            }
            else
            {
                if (hit0.distance < 4)
                {
                    this.Obstacle = 16;
                }
                else
                {
                    this.Obstacle = 0;
                }
            }
            Debug.DrawRay(this.thisTransform.position, (this.vPoint.forward * VelClamp) * 0.5f, Color.green);
            if (Physics.Raycast(this.thisTransform.position, this.vPoint.forward, out hit0, VelClamp * 0.5f, (int) this.targetLayers))
            {
                this.TurnAwayBlyat = true;
            }
            else
            {
                this.TurnAwayBlyat = false;
            }
            newRot = ((this.thisTransform.forward * 0.8f) + (this.thisTransform.up * 0.1f)).normalized;
            Debug.DrawRay(this.thisVTransform.position + (this.thisVTransform.forward * 1), newRot * VelClamp, Color.blue);
            if (Physics.Raycast(this.thisVTransform.position + (this.thisVTransform.forward * 1), newRot, out hit2, VelClamp, (int) this.targetLayers))
            {
                this.UpDist = hit2.distance;
            }
            else
            {
                this.UpDist = 60;
            }
            newRot = ((this.thisTransform.forward * 0.8f) + (this.thisTransform.up * -0.1f)).normalized;
            Debug.DrawRay(this.thisVTransform.position + (-this.thisVTransform.forward * 1), newRot * VelClamp, Color.red);
            if (Physics.Raycast(this.thisVTransform.position + (-this.thisVTransform.forward * 1), newRot, out hit2, VelClamp, (int) this.targetLayers))
            {
                this.DownDist = hit2.distance;
            }
            else
            {
                this.DownDist = 60;
            }
            Debug.DrawRay(this.thisVTransform.position + (this.thisTransform.right * 2), this.vPoint.forward * VelClamp, Color.black);
            if (Physics.Raycast(this.thisVTransform.position + (this.thisTransform.right * 2), this.vPoint.forward, out hit1, VelClamp, (int) this.targetLayers))
            {
                this.RightDist = hit1.distance;
            }
            else
            {
                this.RightDist = 60;
            }
            Debug.DrawRay(this.thisVTransform.position + (-this.thisTransform.right * 2), this.vPoint.forward * VelClamp, Color.black);
            if (Physics.Raycast(this.thisVTransform.position + (-this.thisTransform.right * 2), this.vPoint.forward, out hit1, VelClamp, (int) this.targetLayers))
            {
                this.LeftDist = hit1.distance;
            }
            else
            {
                this.LeftDist = 60;
            }
        }
        else
        {
            //RelTarg = thisTransform.InverseTransformPoint(target.position);
            VelClamp = Mathf.Clamp(this.Vel, 6, 200);
            Vector3 newRot = ((this.thisTransform.forward * 0.4f) + (this.thisTransform.up * 0.1f)).normalized;
            Debug.DrawRay((this.thisVTransform.position + (this.thisVTransform.up * 1)) + (this.thisVTransform.forward * 0.5f), newRot * 6, Color.blue);
            if (Physics.Raycast((this.thisVTransform.position + (this.thisVTransform.up * 1)) + (this.thisVTransform.forward * 0.5f), newRot, out hit2, 6, (int) this.targetLayers))
            {
                this.UpDist = hit2.distance;
            }
            else
            {
                this.UpDist = 60;
            }
            newRot = ((this.thisTransform.forward * 0.4f) + (this.thisTransform.up * -0.1f)).normalized;
            Debug.DrawRay((this.thisVTransform.position + (this.thisVTransform.up * 1)) + (-this.thisVTransform.forward * 0.5f), newRot * 6, Color.red);
            if (Physics.Raycast((this.thisVTransform.position + (this.thisVTransform.up * 1)) + (-this.thisVTransform.forward * 0.5f), newRot, out hit2, 6, (int) this.targetLayers))
            {
                this.DownDist = hit2.distance;
            }
            else
            {
                this.DownDist = 60;
            }
            newRot = ((this.thisTransform.forward * 0.4f) + (this.thisTransform.right * 0.1f)).normalized;
            Debug.DrawRay((this.thisVTransform.position + (this.thisVTransform.up * 1)) + (this.thisTransform.right * 0.5f), newRot * 6, Color.black);
            if (Physics.Raycast((this.thisVTransform.position + (this.thisVTransform.up * 1)) + (this.thisTransform.right * 0.5f), newRot, out hit1, 6, (int) this.targetLayers))
            {
                this.RightDist = hit1.distance;
            }
            else
            {
                this.RightDist = 60;
            }
            newRot = ((this.thisTransform.forward * 0.4f) + (this.thisTransform.right * -0.1f)).normalized;
            Debug.DrawRay((this.thisVTransform.position + (this.thisVTransform.up * 1)) + (-this.thisTransform.right * 0.5f), newRot * 6, Color.black);
            if (Physics.Raycast((this.thisVTransform.position + (this.thisVTransform.up * 1)) + (-this.thisTransform.right * 0.5f), newRot, out hit1, 6, (int) this.targetLayers))
            {
                this.LeftDist = hit1.distance;
            }
            else
            {
                this.LeftDist = 60;
            }
        }
        if (this.RightDist != this.LeftDist)
        {
            if (this.TurnAwayBlyat)
            {
                this.LeftDist = 1;
            }
        }
        this.Diff = Mathf.Abs(this.UpDist - this.DownDist);
        if (this.DownDist > this.UpDist)
        {
            this.TurnDown = true;
            this.TurnUp = false;
        }
        if (this.UpDist > this.DownDist)
        {
            this.TurnUp = true;
            this.TurnDown = false;
        }
        if ((this.Diff > 20) && !this.Smertnik)
        {
            this.TurnDown = false;
            this.TurnUp = false;
        }
        if (this.RightDist > this.LeftDist)
        {
            this.TurnRight = true;
            this.TurnLeft = false;
            this.Obstacle = 8;
        }
        if (this.LeftDist > this.RightDist)
        {
            this.TurnLeft = true;
            this.TurnRight = false;
            this.Obstacle = 8;
        }
        if (this.DownDist == this.UpDist)
        {
            this.TurnDown = false;
            this.TurnUp = false;
        }
        if (this.RightDist == this.LeftDist)
        {
            this.TurnRight = false;
            this.TurnLeft = false;
        }
    }

    public virtual void FixedUpdate()
    {
        Vector3 localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
        Vector3 localAV = this.vPoint.InverseTransformDirection(this.vRigidbody.angularVelocity);
        float AVModX = localAV.x;
        float AVClampX = Mathf.Clamp(AVModX, -1, 1);
        float AVModY = localAV.y;
        float AVClampY = Mathf.Clamp(AVModY, -1, 1);
        this.Vel = -localV.y * 2.24f;
        this.vRigidbody.AddTorque(this.vPoint.right * -AVClampX);
        this.vRigidbody.AddTorque(this.vPoint.up * -AVClampY);
        if (!this.Smertnik)
        {
            float AVModZ = localAV.z;
            float AVClampZ = Mathf.Clamp(AVModZ, -1, 1);
            this.vRigidbody.AddTorque(this.vPoint.forward * -AVClampZ);
            if (!this.Strelnik)
            {
                this.ObsDist = 1000;
                if (this.Vel < 200)
                {
                    this.vRigidbody.AddForce(this.thisVTransform.up * -1);
                }
            }
            else
            {
                this.ObsDist = 300;
                if (!this.Approach)
                {
                    if (this.Vel < 200)
                    {
                        this.vRigidbody.AddForce(this.thisVTransform.up * -2);
                    }
                }
                else
                {
                    if (this.Vel < 150)
                    {
                        this.vRigidbody.AddForce(this.thisVTransform.up * -1);
                    }
                }
            }
            if (this.TurnUp)
            {
                this.vRigidbody.AddTorque(-this.thisVTransform.right * 4);
            }
            if (this.TurnDown)
            {
                this.vRigidbody.AddTorque(this.thisVTransform.right * 4);
            }
            if (!this.TurnUp && !this.TurnDown)
            {
                if (!this.Satnik)
                {
                    if (this.vRigidbody.angularVelocity.magnitude < 1)
                    {
                        if (!this.Aim)
                        {
                            if (this.Obstacle > 1)
                            {
                                if (this.Obstacle > 3)
                                {
                                    this.vRigidbody.AddTorque(-this.thisVTransform.right * 2);
                                }
                                else
                                {
                                    this.vRigidbody.AddTorque(-this.thisVTransform.right * 1);
                                }
                            }
                        }
                        else
                        {
                            if (this.Obstacle > 4)
                            {
                                if (this.Vel > 40)
                                {
                                    this.vRigidbody.AddTorque(-this.thisVTransform.right * 4);
                                }
                                else
                                {
                                    this.vRigidbody.AddTorque(-this.thisVTransform.right * 2);
                                }
                            }
                            if (this.Vel > 130)
                            {
                                this.vRigidbody.AddTorque((-this.thisVTransform.right * this.Dist) * 0.0007f);
                            }
                        }
                    }
                    else
                    {
                        if (this.Obstacle > 1)
                        {
                            this.vRigidbody.AddTorque(-this.thisVTransform.right * 1);
                        }
                    }
                }
                else
                {
                    if (this.Obstacle > 1)
                    {
                        if (this.vRigidbody.angularVelocity.magnitude < 1)
                        {
                            this.vRigidbody.AddTorque(-this.thisVTransform.right * 1);
                        }
                    }
                }
            }
            if (this.TurnLeft && !this.TurnRight)
            {
                this.vRigidbody.AddTorque(this.thisVTransform.forward * -2);
            }
            if (this.TurnRight && !this.TurnLeft)
            {
                this.vRigidbody.AddTorque(this.thisVTransform.forward * 2);
            }
            if (!this.Strelnik)
            {
                this.vRigidbody.AddForceAtPosition(Vector3.up * this.StabForce, this.thisTransform.up * 2);
                this.vRigidbody.AddForceAtPosition(-Vector3.up * this.StabForce, -this.thisTransform.up * 2);
            }
            else
            {
                if (this.Approach)
                {
                    if ((this.Dist < 100) || (this.Dist > 500))
                    {
                        this.vRigidbody.AddForceAtPosition(Vector3.up * this.StabForce, this.thisTransform.up * 2);
                        this.vRigidbody.AddForceAtPosition(-Vector3.up * this.StabForce, -this.thisTransform.up * 2);
                        if (this.Dist < 100)
                        {
                            this.Approach = false;
                        }
                    }
                    else
                    {
                        this.Aim = true;
                    }
                    if (this.Obstacle < 5)
                    {
                        this.vRigidbody.angularDrag = 16;
                    }
                    else
                    {
                        this.vRigidbody.angularDrag = 2;
                        this.Approach = false;
                    }
                }
                else
                {
                    this.vRigidbody.AddForceAtPosition(Vector3.up * this.StabForce, this.thisTransform.up * 2);
                    this.vRigidbody.AddForceAtPosition(-Vector3.up * this.StabForce, -this.thisTransform.up * 2);
                    if (this.Dist > 600)
                    {
                        this.Approach = true;
                    }
                    this.Aim = false;
                    this.vRigidbody.angularDrag = 2;
                }
            }
            if (this.target)
            {
                if (((!this.TurnLeft && !this.TurnRight) && !this.TurnUp) && !this.TurnDown)
                {
                    if (!this.Strelnik)
                    {
                        this.vRigidbody.AddForceAtPosition((this.target.position - this.thisTransform.position).normalized * -0.2f, this.thisVTransform.up * 2);
                        this.vRigidbody.AddForceAtPosition((this.target.position - this.thisTransform.position).normalized * 0.2f, -this.thisVTransform.up * 2);
                    }
                    else
                    {
                        if (this.vRigidbody.angularVelocity.magnitude < 1)
                        {
                            if (this.Obstacle > 6)
                            {
                                if (this.Vel > 40)
                                {
                                    this.vRigidbody.AddForceAtPosition((this.target.position - this.thisTransform.position).normalized * -0.2f, this.thisVTransform.up * 2);
                                    this.vRigidbody.AddForceAtPosition((this.target.position - this.thisTransform.position).normalized * 0.2f, -this.thisVTransform.up * 2);
                                }
                                else
                                {
                                    this.vRigidbody.AddForceAtPosition((this.TargetLead.position - this.thisTransform.position).normalized * -2, this.thisVTransform.up * 2);
                                    this.vRigidbody.AddForceAtPosition((this.TargetLead.position - this.thisTransform.position).normalized * 2, -this.thisVTransform.up * 2);
                                }
                            }
                            else
                            {
                                if (this.Approach)
                                {
                                    if (!this.Aim)
                                    {
                                        this.vRigidbody.AddForceAtPosition((this.TargetLead.position - this.thisTransform.position).normalized * -2, this.thisVTransform.up * 2);
                                        this.vRigidbody.AddForceAtPosition((this.TargetLead.position - this.thisTransform.position).normalized * 2, -this.thisVTransform.up * 2);
                                    }
                                    else
                                    {
                                        this.vRigidbody.AddForceAtPosition((this.TargetLead.position - this.thisTransform.position).normalized * -4, this.thisVTransform.up * 2);
                                        this.vRigidbody.AddForceAtPosition((this.TargetLead.position - this.thisTransform.position).normalized * 4, -this.thisVTransform.up * 2);
                                    }
                                }
                                else
                                {
                                    if (this.Suspicious < 4)
                                    {
                                        this.vRigidbody.AddForceAtPosition((this.target.position - this.thisTransform.position).normalized * -0.2f, this.thisVTransform.up * 2);
                                        this.vRigidbody.AddForceAtPosition((this.target.position - this.thisTransform.position).normalized * 0.2f, -this.thisVTransform.up * 2);
                                    }
                                }
                            }
                        }
                        else
                        {
                            this.vRigidbody.AddForceAtPosition((this.target.position - this.thisTransform.position).normalized * -0.2f, this.thisVTransform.up * 2);
                            this.vRigidbody.AddForceAtPosition((this.target.position - this.thisTransform.position).normalized * 0.2f, -this.thisVTransform.up * 2);
                        }
                    }
                }
            }
        }
        else
        {
            float VClamp = Mathf.Clamp(this.Vel, 2, 8);
            Debug.DrawRay(this.vPoint.position + (this.vPoint.right * 0.4f), this.vPoint.forward * VClamp, Color.red);
            Debug.DrawRay(this.vPoint.position + (-this.vPoint.right * 0.4f), this.vPoint.forward * VClamp, Color.red);
            if (Physics.Raycast(this.vPoint.position + (this.vPoint.right * 0.4f), this.vPoint.forward, VClamp, (int) this.targetLayers) || Physics.Raycast(this.vPoint.position + (-this.vPoint.right * 0.4f), this.vPoint.forward, VClamp, (int) this.targetLayers))
            {
                this.Obstacle = 1;
            }
            else
            {
                this.Obstacle = 0;
                this.vPoint.Rotate(0, 0, 10);
            }
            if (localV.z < 0)
            {
                this.RD = Mathf.Abs(localV.z);
            }
            else
            {
                this.RD = 0;
            }
            if (Physics.Raycast(this.thisTransform.position, Vector3.down, 2 + this.RD, (int) this.targetLayers))
            {
                this.vRigidbody.AddForce(Vector3.up * 0.2f);
            }
            else
            {
                if (!Physics.Raycast(this.thisTransform.position, Vector3.down, 10 + this.RD, (int) this.targetLayers))
                {
                    this.vRigidbody.AddForce(Vector3.up * -0.05f);
                }
            }
            this.vRigidbody.AddForceAtPosition(Vector3.up * this.StabForce, this.thisTransform.up * 1);
            this.vRigidbody.AddForceAtPosition(-Vector3.up * this.StabForce, -this.thisTransform.up * 1);
            if (this.target)
            {
                if (this.Obstacle == 0)
                {
                    if (((!this.TurnLeft && !this.TurnRight) && !this.TurnUp) && !this.TurnDown)
                    {
                        this.vRigidbody.AddForceAtPosition((this.target.position - this.thisTransform.position).normalized * -4, this.thisVTransform.up * 0.5f);
                        this.vRigidbody.AddForceAtPosition((this.target.position - this.thisTransform.position).normalized * 4, -this.thisVTransform.up * 0.5f);
                        if (this.Vel < 20)
                        {
                            if (Vector3.Distance(this.thisTransform.position, this.target.position) < 32)
                            {
                                this.vRigidbody.AddForce(this.thisVTransform.up * -0.15f);
                            }
                            else
                            {
                                this.vRigidbody.AddForce(this.thisVTransform.up * -0.1f);
                            }
                        }
                    }
                    else
                    {
                        if (this.Vel < 8)
                        {
                            this.vRigidbody.AddForce(this.thisVTransform.up * -0.15f);
                        }
                        else
                        {
                            this.vRigidbody.AddForce(this.thisVTransform.up * 0.3f);
                        }
                    }
                }
                else
                {
                    this.vRigidbody.AddForce(this.thisVTransform.up * 0.2f);
                }
            }
            if (this.TurnLeft && !this.TurnRight)
            {
                this.vRigidbody.AddTorque(this.thisVTransform.forward * -6);
            }
            if (this.TurnRight && !this.TurnLeft)
            {
                this.vRigidbody.AddTorque(this.thisVTransform.forward * 6);
            }
            if (this.TurnUp && !this.TurnDown)
            {
                this.vRigidbody.AddTorque(this.thisVTransform.right * -6);
            }
            if (this.TurnDown && !this.TurnUp)
            {
                this.vRigidbody.AddTorque(this.thisVTransform.right * 6);
            }
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            string ON = other.name;
            if (!this.Smertnik)
            {
                if (ON.Contains("TFC0a"))
                {
                    this.PissedAtTC0a = this.PissedAtTC0a + 1;
                }
                if (ON.Contains("TFC1"))
                {
                    this.PissedAtTC1 = this.PissedAtTC1 + 1;
                }
                if (ON.Contains("TFC4"))
                {
                    this.PissedAtTC4 = this.PissedAtTC4 + 1;
                }
                if (ON.Contains("TFC7"))
                {
                    this.PissedAtTC7 = this.PissedAtTC7 + 1;
                }
                if (ON.Contains("TFC8"))
                {
                    this.PissedAtTC8 = this.PissedAtTC8 + 1;
                }
                if (ON.Contains("TFC9"))
                {
                    this.PissedAtTC9 = this.PissedAtTC9 + 1;
                }
            }
            else
            {
                if (ON.Contains("TFC"))
                {
                    if (Vector3.Distance(this.thisTransform.position, this.target.position) < 16)
                    {
                        UnityEngine.Object.Instantiate(this.Explosion, this.thisTransform.position, this.thisTransform.rotation);
                        this.StartCoroutine(this.NpcController.Removal());
                    }
                }
            }
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        string ON = other.name;
        Transform OT = other.transform;
        if (((other != null) && !this.Strelnik) && !this.Smertnik)
        {
            if (this.PissedAtTC0a > 1)
            {
                if (ON.Contains("TC0a"))
                {
                    this.Hunting = false;
                    this.Suspicious = 6;
                    this.target = OT;
                }
            }
            if (this.PissedAtTC1 > 1)
            {
                if (ON.Contains("TC1"))
                {
                    this.Hunting = false;
                    this.Suspicious = 6;
                    this.target = OT;
                }
            }
            if (this.PissedAtTC3 > 1)
            {
                if (!ON.Contains("cT"))
                {
                    if (ON.Contains("TC3"))
                    {
                        this.Hunting = false;
                        this.Suspicious = 6;
                        this.target = OT;
                    }
                }
            }
            if (this.PissedAtTC4 > 1)
            {
                if (ON.Contains("TC4"))
                {
                    this.Hunting = false;
                    this.Suspicious = 6;
                    this.target = OT;
                }
            }
            if (this.PissedAtTC6 > 1)
            {
                if (!ON.Contains("cT"))
                {
                    if (ON.Contains("TC6"))
                    {
                        this.Hunting = false;
                        this.Suspicious = 6;
                        this.target = OT;
                    }
                }
            }
            if (this.PissedAtTC7 > 1)
            {
                if (!ON.Contains("cT"))
                {
                    if (ON.Contains("TC7"))
                    {
                        this.Hunting = false;
                        this.Suspicious = 6;
                        this.target = OT;
                    }
                }
            }
            if (this.PissedAtTC8 > 1)
            {
                if (!ON.Contains("cT"))
                {
                    if (ON.Contains("TC8"))
                    {
                        this.Hunting = false;
                        this.Suspicious = 6;
                        this.target = OT;
                    }
                }
            }
            if (this.PissedAtTC9 > 1)
            {
                if (!ON.Contains("cT"))
                {
                    if (ON.Contains("TC9"))
                    {
                        this.Hunting = false;
                        this.Suspicious = 6;
                        this.target = OT;
                    }
                }
            }
        }
    }

    public virtual void Shooty()
    {
        if (this.Strelnik)
        {
            this.StartCoroutine(this.Shoot());
        }
        if (this.Smertnik)
        {
            if (Vector3.Distance(this.thisTransform.position, this.target.position) < 6)
            {
                UnityEngine.Object.Instantiate(this.Explosion, this.thisTransform.position, this.thisTransform.rotation);
                this.StartCoroutine(this.NpcController.Removal());
            }
        }
    }

    public virtual IEnumerator Shoot()
    {
        if (this.Suspicious > 1)
        {
            yield return new WaitForSeconds(this.UniqueShootTime);
            this.Gun.Fire();
        }
    }

    public virtual void CalcLead()
    {
        if (this.Strelnik)
        {
            this.StartCoroutine(this.Lead());
        }
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
            float Dist2 = Vector3.Distance(this.TargetTrace.position, this.target.position);
            Vector3 TargetRelCalc = this.thisTransform.InverseTransformPoint(this.TargetLead.position);
            float RorL = Mathf.Abs(TargetRelCalc.x);
            float LeadAmount;
            if (RorL < 4)
            {
                //Debug.Log("Heading Straight");
                LeadAmount = 0.04f;
            }
            else
            {
                //Debug.Log("Heading Sideways");
                LeadAmount = 0.04f;
            }
            this.TargetTrace.LookAt(this.target);
            this.TargetLead.position = this.TargetTrace.position;
            this.TargetLead.rotation = this.TargetTrace.rotation;
            this.TargetLead.position = this.TargetLead.position + (((this.TargetLead.forward * this.Dist) * Dist2) * LeadAmount);
            if (this.Suspicious > 1)
            {
                this.TLCol.radius = Vector3.Distance(this.thisTransform.position, this.target.position) * 0.03f;
            }
            else
            {
                this.TLCol.radius = 0.1f;
            }
        }
    }

    public virtual void Updater()
    {
        if (!this.Smertnik)
        {
            if (this.PissedAtTC0a > 0)
            {
                this.PissedAtTC0a = this.PissedAtTC0a - 1;
            }
            if (this.PissedAtTC1 > 0)
            {
                this.PissedAtTC1 = this.PissedAtTC1 - 1;
            }
            if (this.PissedAtTC4 > 0)
            {
                this.PissedAtTC4 = this.PissedAtTC4 - 1;
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
            if (this.PissedAtTC1 > 2)
            {
                if (SlavuicNetwork.TC1DeathRow < 240)
                {
                    SlavuicNetwork.TC1DeathRow = 240;
                }
                this.PissedAtTC1 = 8;
            }
            if (this.PissedAtTC4 > 2)
            {
                SlavuicNetwork.TC4DeathRow = 240;
                this.PissedAtTC4 = 8;
            }
            if (this.PissedAtTC7 > 2)
            {
                SlavuicNetwork.TC7DeathRow = 240;
                this.PissedAtTC7 = 8;
            }
            if (this.PissedAtTC8 > 2)
            {
                SlavuicNetwork.TC8DeathRow = 240;
                this.PissedAtTC8 = 8;
            }
            if (this.PissedAtTC9 > 2)
            {
                SlavuicNetwork.TC9DeathRow = 240;
                this.PissedAtTC9 = 8;
            }
            if (!this.Strelnik)
            {
                if (SlavuicNetwork.TC0aDeathRow > 0)
                {
                    if (SlavuicNetwork.target)
                    {
                        if (this.AssignedTarget)
                        {
                            if (!this.AssignedTarget.name.Contains("TC0a"))
                            {
                                this.MemorizedTarget = this.AssignedTarget;
                            }
                        }
                        this.AssignedTarget = SlavuicNetwork.target;
                    }
                    if (this.AssignedTarget)
                    {
                        if (Vector3.Distance(this.thisTransform.position, this.AssignedTarget.position) < 3000)
                        {
                            if (this.AssignedTarget.name.Contains("TC0a"))
                            {
                                SlavuicNetwork.Confirmed = true;
                                this.MemorizedTarget = this.AssignedTarget;
                                this.target = this.AssignedTarget;
                            }
                        }
                    }
                    if (this.MemorizedTarget)
                    {
                        if (Vector3.Distance(this.thisTransform.position, this.MemorizedTarget.position) < 3000)
                        {
                            if (this.MemorizedTarget.name.Contains("TC0a"))
                            {
                                SlavuicNetwork.Confirmed = true;
                                this.target = this.MemorizedTarget;
                            }
                        }
                    }
                    if (this.target)
                    {
                        if (this.target.name.Contains("TC0a"))
                        {
                            SlavuicNetwork.instance.PriorityWaypoint.position = this.target.position;
                        }
                        else
                        {
                            this.target = SlavuicNetwork.instance.PriorityWaypoint;
                        }
                    }
                    else
                    {
                        this.target = SlavuicNetwork.instance.PriorityWaypoint;
                    }
                    this.Suspicious = 6;
                    this.PissedAtTC0a = 6;
                    this.Hunting = false;
                }
                if (SlavuicNetwork.TC1DeathRow > 0)
                {
                    if (SlavuicNetwork.target)
                    {
                        if (this.AssignedTarget)
                        {
                            if (!this.AssignedTarget.name.Contains("TC1"))
                            {
                                this.MemorizedTarget = this.AssignedTarget;
                            }
                        }
                        this.AssignedTarget = SlavuicNetwork.target;
                    }
                    if (this.AssignedTarget)
                    {
                        if (Vector3.Distance(this.thisTransform.position, this.AssignedTarget.position) < 3000)
                        {
                            if (this.AssignedTarget.name.Contains("TC1"))
                            {
                                SlavuicNetwork.Confirmed = true;
                                this.MemorizedTarget = this.AssignedTarget;
                                this.target = this.AssignedTarget;
                            }
                        }
                    }
                    if (this.MemorizedTarget)
                    {
                        if (Vector3.Distance(this.thisTransform.position, this.MemorizedTarget.position) < 3000)
                        {
                            if (this.MemorizedTarget.name.Contains("TC1"))
                            {
                                SlavuicNetwork.Confirmed = true;
                                this.target = this.MemorizedTarget;
                            }
                        }
                    }
                    if (this.target)
                    {
                        if (this.target.name.Contains("TC1"))
                        {
                            SlavuicNetwork.instance.PriorityWaypoint.position = this.target.position;
                        }
                        else
                        {
                            this.target = SlavuicNetwork.instance.PriorityWaypoint;
                        }
                        if (this.target.name.Contains("xb"))
                        {
                            SlavuicNetwork.FoundExtraBig = this.target;
                            SlavuicNetwork.instance.PriorityWaypoint.position = this.target.position;
                        }
                    }
                    else
                    {
                        this.target = SlavuicNetwork.instance.PriorityWaypoint;
                    }
                    this.Suspicious = 6;
                    this.PissedAtTC1 = 6;
                    this.Hunting = false;
                }
                if (SlavuicNetwork.TC7DeathRow > 0)
                {
                    if (SlavuicNetwork.target)
                    {
                        if (this.AssignedTarget)
                        {
                            if (!this.AssignedTarget.name.Contains("TC7"))
                            {
                                this.MemorizedTarget = this.AssignedTarget;
                            }
                        }
                        this.AssignedTarget = SlavuicNetwork.target;
                    }
                    if (this.AssignedTarget)
                    {
                        if (Vector3.Distance(this.thisTransform.position, this.AssignedTarget.position) < 3000)
                        {
                            if (this.AssignedTarget.name.Contains("TC7"))
                            {
                                SlavuicNetwork.Confirmed = true;
                                this.MemorizedTarget = this.AssignedTarget;
                                this.target = this.AssignedTarget;
                            }
                        }
                    }
                    if (this.MemorizedTarget)
                    {
                        if (Vector3.Distance(this.thisTransform.position, this.MemorizedTarget.position) < 3000)
                        {
                            if (this.MemorizedTarget.name.Contains("TC7"))
                            {
                                SlavuicNetwork.Confirmed = true;
                                this.target = this.MemorizedTarget;
                            }
                        }
                    }
                    if (this.target)
                    {
                        if (this.target.name.Contains("TC7"))
                        {
                            SlavuicNetwork.instance.PriorityWaypoint.position = this.target.position;
                        }
                        else
                        {
                            this.target = SlavuicNetwork.instance.PriorityWaypoint;
                        }
                    }
                    else
                    {
                        this.target = SlavuicNetwork.instance.PriorityWaypoint;
                    }
                    this.Suspicious = 6;
                    this.PissedAtTC7 = 6;
                    this.Hunting = false;
                }
                if (SlavuicNetwork.TC8DeathRow > 0)
                {
                    if (SlavuicNetwork.target)
                    {
                        if (this.AssignedTarget)
                        {
                            if (!this.AssignedTarget.name.Contains("TC8"))
                            {
                                this.MemorizedTarget = this.AssignedTarget;
                            }
                        }
                        this.AssignedTarget = SlavuicNetwork.target;
                    }
                    if (this.AssignedTarget)
                    {
                        if (Vector3.Distance(this.thisTransform.position, this.AssignedTarget.position) < 3000)
                        {
                            if (this.AssignedTarget.name.Contains("TC8"))
                            {
                                SlavuicNetwork.Confirmed = true;
                                this.MemorizedTarget = this.AssignedTarget;
                                this.target = this.AssignedTarget;
                            }
                        }
                    }
                    if (this.MemorizedTarget)
                    {
                        if (Vector3.Distance(this.thisTransform.position, this.MemorizedTarget.position) < 3000)
                        {
                            if (this.MemorizedTarget.name.Contains("TC8"))
                            {
                                SlavuicNetwork.Confirmed = true;
                                this.target = this.MemorizedTarget;
                            }
                        }
                    }
                    if (this.target)
                    {
                        if (this.target.name.Contains("TC8"))
                        {
                            SlavuicNetwork.instance.PriorityWaypoint.position = this.target.position;
                        }
                        else
                        {
                            this.target = SlavuicNetwork.instance.PriorityWaypoint;
                        }
                    }
                    else
                    {
                        this.target = SlavuicNetwork.instance.PriorityWaypoint;
                    }
                    this.Suspicious = 6;
                    this.PissedAtTC8 = 6;
                    this.Hunting = false;
                }
                if (SlavuicNetwork.TC9DeathRow > 0)
                {
                    if (SlavuicNetwork.target)
                    {
                        if (this.AssignedTarget)
                        {
                            if (!this.AssignedTarget.name.Contains("TC9"))
                            {
                                this.MemorizedTarget = this.AssignedTarget;
                            }
                        }
                        this.AssignedTarget = SlavuicNetwork.target;
                    }
                    if (this.AssignedTarget)
                    {
                        if (Vector3.Distance(this.thisTransform.position, this.AssignedTarget.position) < 3000)
                        {
                            if (this.AssignedTarget.name.Contains("TC9"))
                            {
                                SlavuicNetwork.Confirmed = true;
                                this.MemorizedTarget = this.AssignedTarget;
                                this.target = this.AssignedTarget;
                            }
                        }
                    }
                    if (this.MemorizedTarget)
                    {
                        if (Vector3.Distance(this.thisTransform.position, this.MemorizedTarget.position) < 3000)
                        {
                            if (this.MemorizedTarget.name.Contains("TC9"))
                            {
                                SlavuicNetwork.Confirmed = true;
                                this.target = this.MemorizedTarget;
                            }
                        }
                    }
                    if (this.target)
                    {
                        if (this.target.name.Contains("TC9"))
                        {
                            SlavuicNetwork.instance.PriorityWaypoint.position = this.target.position;
                        }
                        else
                        {
                            this.target = SlavuicNetwork.instance.PriorityWaypoint;
                        }
                    }
                    else
                    {
                        this.target = SlavuicNetwork.instance.PriorityWaypoint;
                    }
                    this.Suspicious = 6;
                    this.PissedAtTC9 = 6;
                    this.Hunting = false;
                }
                if (Vector3.Distance(this.thisTransform.position, SlavuicNetwork.instance.transform.position) > 6000)
                {
                    this.target = SlavuicNetwork.instance.transform;
                }
                else
                {
                    if (this.Suspicious > 0)
                    {
                        if (this.MemorizedTarget)
                        {
                            this.target = this.MemorizedTarget;
                        }
                        if (this.target)
                        {
                            this.Suspicious = this.Suspicious - 1;
                        }
                    }
                    else
                    {
                        this.target = this.ResetView;
                        this.Hunting = true;
                    }
                    if (this.MemorizedTarget)
                    {
                        if (Vector3.Distance(this.thisTransform.position, this.MemorizedTarget.position) > 1000)
                        {
                            this.target = this.MemorizedTarget;
                        }
                    }
                }
            }
            else
            {
                if (this.Suspicious > 0)
                {
                    if (this.target)
                    {
                        if (!this.target.name.Contains("TC"))
                        {
                            this.Suspicious = this.Suspicious - 1;
                        }
                    }
                    else
                    {
                        this.Suspicious = this.Suspicious - 1;
                    }
                }
                else
                {
                    this.target = this.ResetView;
                    this.Hunting = true;
                }
                if (!this.Home)
                {
                    this.Home = SlavuicNetwork.instance.transform;
                    this.Baseless = true;
                }
                if (this.target)
                {
                    if ((this.Suspicious < 1) || !this.target.name.Contains("TC"))
                    {
                        if (this.Baseless)
                        {
                            this.AssignedTarget = SlavuicNetwork.target;
                        }
                        if (this.AssignedTarget)
                        {
                            if (this.AssignedTarget.name.Contains("TC"))
                            {
                                if (Vector3.Distance(this.thisTransform.position, this.AssignedTarget.position) < 2000)
                                {
                                    this.Suspicious = 6;
                                    if (this.AssignedTarget)
                                    {
                                        this.target = this.AssignedTarget;
                                    }
                                }
                                else
                                {
                                    this.target = this.Home;
                                }
                            }
                            else
                            {
                                if (Vector3.Distance(this.thisTransform.position, this.Home.position) > 1000)
                                {
                                    this.target = this.Home;
                                }
                            }
                        }
                        else
                        {
                            if (Vector3.Distance(this.thisTransform.position, this.Home.position) > 1000)
                            {
                                this.target = this.Home;
                            }
                        }
                    }
                    if (this.AssignedTarget)
                    {
                        if (!this.AssignedTarget.name.Contains("sTC") && this.target.name.Contains("sTC"))
                        {
                            this.Suspicious = 6;
                            this.target = this.AssignedTarget;
                        }
                    }
                }
                else
                {
                    if (Vector3.Distance(this.thisTransform.position, this.Home.position) > 1000)
                    {
                        this.target = this.Home;
                    }
                }
            }
            this.TurnAwayBlyat = false;
        }
        else
        {
            if (SlavuicNetwork.TC1DeathRow > 0)
            {
                this.target = PlayerInformation.instance.PiriTarget;
            }
        }
        if (this.Satnik || this.Smertnik)
        {
            if (this.AttackSound)
            {
                if (this.AttackSound.enabled)
                {
                    if (!this.AttackSound.isPlaying)
                    {
                        this.AttackSound.Play();
                    }
                }
            }
        }
        this.Obstacle = 0;
    }

    public SlavuicMachineAI()
    {
        this.ObsStartY = 4;
        this.ObsStartZ = 0.1f;
        this.RightDist = 200;
        this.LeftDist = 200;
        this.UpDist = 200;
        this.DownDist = 200;
        this.ObsDist = 1000;
        this.Dist = 1000;
        this.StabForce = 2;
        this.Diff = 2;
        this.RD = 1;
        this.UniqueShootTime = 0.1f;
    }

}