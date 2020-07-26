using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class TerbotekDroneAI : MonoBehaviour
{
    public Transform target;
    public float tDist;
    public Transform Waypoint;
    public Transform Home;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public Transform AIAnchor;
    public Transform TargetTrace;
    public Transform TargetLead;
    public float leadAmount;
    public float Dist1;
    public float Dist2;
    public GameObject Vessel;
    public SphereCollider Trig;
    public GameObject Presence;
    public Transform thisTC;
    public bool PlayerSpawn;
    public bool isTC1;
    public bool isTC5;
    public bool isSingleShot;
    public GameObject ShotTC1;
    public GameObject ShotTC5;
    public Transform Muzzle1;
    public GameObject Wing;
    public AudioSource Sounds;
    public GameObject AlarmSound;
    public bool Obscurity;
    public bool Damaged;
    public VehicleDamage vDamage;
    public bool IsActive;
    public bool Obstacle;
    public bool TurnRight;
    public bool TurnLeft;
    public bool TurnUp;
    public int PissedAtTC0a;
    public int PissedAtTC1;
    public int PissedAtTC2;
    public int PissedAtTC3;
    public int PissedAtTC4;
    public int PissedAtTC5;
    public int PissedAtTC6;
    public int PissedAtTC7;
    public int PissedAtTC8;
    public int PissedAtTC9;
    public bool NeutralizeAll;
    public bool Attacking;
    public bool Armed;
    public bool LineOfFire;
    public bool HomeIsMoving;
    public LayerMask targetLayers;
    public float GyroForce;
    public float TurnForce;
    public float Force;
    public float ManeuvForce;
    public float Vel;
    public float DAngle;
    public Vector3 relativePoint;
    public bool uTurn;
    public bool strafeLeft;
    public bool strafeRight;
    public float Dist1D;
    public float HTDist;
    public float RHitD;
    public float LHitD;
    public int LeadNum;
    public virtual IEnumerator Start()
    {
        this.InvokeRepeating("Regenerator", 0.5f, 0.5f);
        if (this.isTC1)
        {
            GameObject gO1 = new GameObject("TL1");
            this.TargetLead = gO1.transform;
            gO1.layer = 29;
        }
        if (this.isTC5)
        {
            GameObject gO5 = new GameObject("TL5");
            this.TargetLead = gO5.transform;
            gO5.layer = 29;
        }
        GameObject gO = new GameObject("TT");
        this.TargetTrace = gO.transform;
        this.TargetTrace.position = this.transform.position;
        this.TargetTrace.rotation = this.transform.rotation;
        this.TargetLead.position = this.transform.position;
        this.TargetLead.rotation = this.transform.rotation;
        this.Force = 0.1f;
        yield return new WaitForSeconds(0.2f);
        this.vRigidbody.centerOfMass = new Vector3(0, 0, 0);
        this.Trig.radius = 400;
        //PersonalDroneSet==============================
        yield return new WaitForSeconds(0.8f);
        if (!this.PlayerSpawn)
        {
            yield break;
        }
        if (this.Home.name.Contains("TC1"))
        {
        }
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        if (this.Vessel == null)
        {
            UnityEngine.Object.Destroy(this.Waypoint.gameObject);
            UnityEngine.Object.Destroy(this.gameObject);
        }
        if (this.Damaged)
        {
            this.Sounds.volume = 0;
            this.vRigidbody.drag = 0.1f;
            this.vRigidbody.angularDrag = 0.1f;
            UnityEngine.Object.Destroy(this.Presence);
            UnityEngine.Object.Destroy(this.Waypoint.gameObject);
            UnityEngine.Object.Destroy(this.gameObject);
        }
        if (this.Damaged)
        {
            return;
        }
        if (!this.IsActive || (this.Vessel == null))
        {
            return;
        }
        this.thisTransform.rotation = this.AIAnchor.transform.rotation;
        this.thisTransform.position = this.AIAnchor.transform.position;
        this.TurnForce = 0;
        if (this.TurnLeft)
        {
            this.TurnForce = -0.005f;
        }
        if (this.TurnRight)
        {
            this.TurnForce = 0.005f;
        }
        if (this.TurnRight && this.TurnLeft)
        {
            this.TurnForce = 0;
        }
        Vector3 newRot = (this.thisTransform.forward * 0.6f).normalized;
        newRot = ((this.thisTransform.forward * 0.6f) + (this.thisTransform.right * 0.4f)).normalized;
        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 1), newRot * 10f, Color.black);
        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 1), newRot, 10, (int) this.targetLayers))
        {
            this.TurnLeft = true;
        }
        else
        {
            this.TurnLeft = false;
        }
        newRot = ((this.thisTransform.forward * 0.6f) + (this.thisTransform.right * -0.4f)).normalized;
        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 1), newRot * 10f, Color.black);
        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 1), newRot, 10, (int) this.targetLayers))
        {
            this.TurnRight = true;
        }
        else
        {
            this.TurnRight = false;
        }
        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 1), this.thisTransform.forward, out hit, 12) && hit.collider.tag.Contains("Te"))
        {
            this.Obscurity = true;
            if (!this.Attacking)
            {
                this.target = null;
            }
        }
        else
        {
            this.Obscurity = false;
        }
    }

    public virtual void FixedUpdate()
    {
        RaycastHit hit = default(RaycastHit);
        RaycastHit hitT = default(RaycastHit);
        if (this.Vessel)
        {
            if (!this.IsActive)
            {
                if (this.Sounds.volume > 0)
                {
                    this.Sounds.volume = this.Sounds.volume - 0.05f;
                }
            }
            if (this.IsActive)
            {
                if (this.Sounds.volume < 0.5f)
                {
                    this.Sounds.volume = this.Sounds.volume + 0.05f;
                }
            }
        }
        if (!this.IsActive || (this.Vessel == null))
        {
            return;
        }
        this.Vel = Mathf.Clamp(this.vRigidbody.velocity.magnitude, 8, 1024);
        Vector3 localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
        this.Obstacle = false;
        this.TurnUp = false;
        float UDist, DDist;
        Debug.DrawRay(this.thisVTransform.position + (-this.thisVTransform.up * 1.5f), -this.thisVTransform.up * this.Vel, Color.black);
        if (Physics.Raycast(this.thisVTransform.position + (-this.thisVTransform.up * 1.5f), -this.thisVTransform.up, out hit, this.Vel, (int) this.targetLayers))
        {
            UDist = hit.distance;
        }
        else
        {
            UDist = 2048;
        }
        Debug.DrawRay((this.thisVTransform.position + (-this.thisVTransform.forward * 0.5f)) + (-this.thisVTransform.up * 1.5f), -this.thisVTransform.up * this.Vel, Color.black);
        if (Physics.Raycast((this.thisVTransform.position + (-this.thisVTransform.forward * 0.5f)) + (-this.thisVTransform.up * 1.5f), -this.thisVTransform.up, out hit, this.Vel, (int) this.targetLayers))
        {
            DDist = hit.distance;
            this.TurnUp = true;
        }
        else
        {
            DDist = 1024;
        }
        this.DAngle = Mathf.Abs(UDist - DDist);
        if (this.DAngle < 1)
        {
            this.Obstacle = true;
            this.TurnUp = false;
        }
        if (-localV.y > 2)
        {
            this.vRigidbody.AddTorque(this.thisTransform.up * this.TurnForce);
            if (this.TurnUp)
            {
                this.vRigidbody.AddTorque(this.thisTransform.right * -0.005f);
            }
            if (Physics.Raycast(this.thisTransform.position, Vector3.down, 2, (int) this.targetLayers))
            {
                this.vRigidbody.AddForce(Vector3.up * 0.1f);
            }
        }
        else
        {
            if (!this.Attacking)
            {
                if (this.tDist > 32)
                {
                    this.vRigidbody.AddTorque(this.thisTransform.up * this.TurnForce);
                    if (this.TurnUp)
                    {
                        this.vRigidbody.AddTorque(this.thisTransform.right * -0.005f);
                    }
                }
            }
            if (Physics.Raycast(this.thisTransform.position, Vector3.down, 2, (int) this.targetLayers))
            {
                this.vRigidbody.AddForce(Vector3.up * 0.07f);
            }
        }
        if (this.ManeuvForce != 0)
        {
            this.vRigidbody.AddForce(this.thisTransform.up * this.ManeuvForce);
        }
        if (this.target)
        {
            if (!this.Attacking)
            {
                if (!this.TurnUp)
                {
                    this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * 0.04f, this.thisTransform.forward * 0.8f);
                    this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * -0.04f, -this.thisTransform.forward * 0.8f);
                }
            }
            else
            {
                if (!this.uTurn)
                {
                    if (this.Dist1 > 256)
                    {
                        if (this.vRigidbody.angularVelocity.magnitude > 1)
                        {
                            this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * 0.06f, this.thisTransform.forward * 1);
                            this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * -0.06f, -this.thisTransform.forward * 1);
                        }
                        else
                        {
                            this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * 0.1f, this.thisTransform.forward * 1);
                            this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * -0.1f, -this.thisTransform.forward * 1);
                        }
                    }
                    else
                    {
                        this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * 0.4f, this.thisTransform.forward * 1);
                        this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * -0.4f, -this.thisTransform.forward * 1);
                    }
                }
                else
                {
                    this.vRigidbody.AddTorque(this.thisTransform.up * 0.15f);
                }
                if (this.strafeLeft)
                {
                    this.vRigidbody.AddForce(this.thisVTransform.right * -0.4f);
                }
                if (this.strafeRight)
                {
                    this.vRigidbody.AddForce(this.thisVTransform.right * 0.4f);
                }
            }
        }
        if (this.Attacking)
        {
            this.vRigidbody.AddForceAtPosition(Vector3.up * this.GyroForce, this.thisTransform.up * 0.1f);
            this.vRigidbody.AddForceAtPosition(-Vector3.up * this.GyroForce, -this.thisTransform.up * 0.1f);
        }
        else
        {
            this.vRigidbody.AddForceAtPosition(Vector3.up * this.GyroForce, this.thisTransform.up * 0.2f);
            this.vRigidbody.AddForceAtPosition(-Vector3.up * this.GyroForce, -this.thisTransform.up * 0.2f);
        }
        if (!this.Attacking)
        {
            Debug.DrawRay(this.thisVTransform.position + (-this.thisVTransform.up * 1.5f), -this.thisVTransform.up * 5, Color.blue);
            if (Physics.Raycast(this.thisVTransform.position + (-this.thisVTransform.up * 1.5f), -this.thisVTransform.up, out hit, 5))
            {
                if (hit.collider.tag.Contains("err"))
                {
                    this.Obstacle = true;
                }
                if (hit.collider.tag.Contains("tru"))
                {
                    this.Obstacle = true;
                }
            }
            Debug.DrawRay((this.thisVTransform.position + (this.thisVTransform.forward * 0.2f)) + (-this.thisVTransform.up * 0.4f), -this.thisVTransform.up * 1.1f, Color.cyan);
            Debug.DrawRay((this.thisVTransform.position + (-this.thisVTransform.forward * 0.2f)) + (-this.thisVTransform.up * 0.4f), -this.thisVTransform.up * 1.1f, Color.cyan);
            if (Physics.Raycast((this.thisVTransform.position + (this.thisVTransform.forward * 0.2f)) + (-this.thisVTransform.up * 0.4f), -this.thisVTransform.up, 1.1f) || Physics.Raycast((this.thisVTransform.position + (-this.thisVTransform.forward * 0.2f)) + (-this.thisVTransform.up * 0.4f), -this.thisVTransform.up, 1.1f))
            {
                this.vRigidbody.AddForce(Vector3.up * 0.2f);
            }
        }
        else
        {
            if (Physics.Raycast(this.thisTransform.position, Vector3.down, 32, (int) this.targetLayers))
            {
                this.vRigidbody.AddForce(Vector3.up * 0.2f);
            }
        }
        if (this.Obstacle)
        {
            if (-localV.y > 1)
            {
                if (-localV.y > 10)
                {
                    this.vRigidbody.AddForce(-this.thisVTransform.up * -0.8f);
                }
                else
                {
                    this.vRigidbody.AddForce(-this.thisVTransform.up * -0.2f);
                }
                this.vRigidbody.AddForce(Vector3.up * 0.1f);
            }
        }
        else
        {
            this.vRigidbody.AddForce(-this.thisVTransform.up * this.Force);
        }
        if (this.Obscurity)
        {
            this.vRigidbody.AddForce(this.thisTransform.up * 0.1f);
        }
        if (this.Attacking)
        {
            if (this.LeadNum == 1)
            {
                if (this.target)
                {
                    this.TargetTrace.position = this.target.position;
                }
            }
            if (this.LeadNum == 2)
            {
                this.CalcLead();
                this.LeadNum = 0;
            }
            this.LeadNum = this.LeadNum + 1;
            Vector3 RelativeG = this.thisTransform.InverseTransformPoint(this.TargetLead.position);
            float Vert = RelativeG.y;
            float Hori = RelativeG.x;
            float VertAbs = Mathf.Abs(Vert);
            float HoriAbs = Mathf.Abs(Hori);
            float FuckingRead = HoriAbs + VertAbs;
            if (FuckingRead < 0.5f)
            {
                this.LineOfFire = true;
                Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 1), this.thisTransform.forward * this.Dist1, Color.yellow);
                if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 1), this.thisTransform.forward, out hitT, this.Dist1))
                {
                    this.Dist1D = this.Dist1 - 16;
                    this.HTDist = hitT.distance;
                    if (this.HTDist < this.Dist1D)
                    {
                        this.LineOfFire = false;
                    }
                }
            }
            else
            {
                this.LineOfFire = false;
            }
            if (this.isTC1)
            {
                if (this.LineOfFire)
                {
                    if (this.Armed)
                    {
                        GameObject TheThing1 = UnityEngine.Object.Instantiate(this.ShotTC1, this.Muzzle1.position, this.Muzzle1.rotation);
                        this.thisTC.name = "TC0a";
                        if (this.isSingleShot)
                        {
                            this.vDamage.DamageIn(2048, 0, 0, false);
                        }
                    }
                }
            }
            if (this.isTC5)
            {
                if (this.LineOfFire)
                {
                    if (this.Armed)
                    {
                        GameObject TheThing5 = UnityEngine.Object.Instantiate(this.ShotTC5, this.Muzzle1.position, this.Muzzle1.rotation);
                        this.thisTC.name = "sTC5";
                        if (this.isSingleShot)
                        {
                            this.vDamage.DamageIn(2048, 0, 0, false);
                        }
                    }
                }
            }
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().name.Contains("TFC5"))
        {
            this.PissedAtTC5 = 1;
        }
        if (other.GetComponent<Collider>().name.Contains("TC1"))
        {
            if (!other.GetComponent<Collider>().name.Contains("TC1d"))
            {
                this.GetComponent<Rigidbody>().isKinematic = true;
                this.Home = other.gameObject.transform;
            }
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if (!this.IsActive)
        {
            return;
        }
        string ON = other.name;
        Transform OT = other.transform;
        if (this.NeutralizeAll)
        {
            if (ON.Contains("TC0a") && (this.PissedAtTC0a > 0))
            {
                if (!this.Attacking)
                {
                    this.StartCoroutine(this.Warning());
                }
                this.Attacking = true;
                this.target = OT;
                this.Trig.radius = 30;
                this.relativePoint = this.thisVTransform.InverseTransformPoint(OT.position);
                if (this.relativePoint.y > 0)
                {
                    this.uTurn = true;
                }
            }
            if (ON.Contains("TC4"))
            {
                if (!this.Attacking)
                {
                    this.StartCoroutine(this.Warning());
                }
                this.Attacking = true;
                this.target = OT;
                this.Trig.radius = 30;
                this.relativePoint = this.thisVTransform.InverseTransformPoint(OT.position);
                if (this.relativePoint.y > 0)
                {
                    this.uTurn = true;
                }
            }
            if (ON.Contains("TC5") && (this.PissedAtTC5 > 0))
            {
                if (!this.Attacking)
                {
                    this.StartCoroutine(this.Warning());
                }
                this.Attacking = true;
                this.target = OT;
                this.Trig.radius = 30;
                this.relativePoint = this.thisVTransform.InverseTransformPoint(OT.position);
                if (this.relativePoint.y > 0)
                {
                    this.uTurn = true;
                }
            }
            if (ON.Contains("TC6"))
            {
                if (!this.Attacking)
                {
                    this.StartCoroutine(this.Warning());
                }
                this.Attacking = true;
                this.target = OT;
                this.Trig.radius = 30;
                this.relativePoint = this.thisVTransform.InverseTransformPoint(OT.position);
                if (this.relativePoint.y > 0)
                {
                    this.uTurn = true;
                }
            }
            if (ON.Contains("TC7"))
            {
                if (!this.Attacking)
                {
                    this.StartCoroutine(this.Warning());
                }
                this.Attacking = true;
                this.target = OT;
                this.Trig.radius = 30;
                this.relativePoint = this.thisVTransform.InverseTransformPoint(OT.position);
                if (this.relativePoint.y > 0)
                {
                    this.uTurn = true;
                }
            }
            if (ON.Contains("TC8"))
            {
                if (!this.Attacking)
                {
                    this.StartCoroutine(this.Warning());
                }
                this.Attacking = true;
                this.target = OT;
                this.Trig.radius = 30;
                this.relativePoint = this.thisVTransform.InverseTransformPoint(OT.position);
                if (this.relativePoint.y > 0)
                {
                    this.uTurn = true;
                }
            }
            if (ON.Contains("TC9"))
            {
                if (!this.Attacking)
                {
                    this.StartCoroutine(this.Warning());
                }
                this.Attacking = true;
                this.target = OT;
                this.Trig.radius = 30;
                this.relativePoint = this.thisVTransform.InverseTransformPoint(OT.position);
                if (this.relativePoint.y > 0)
                {
                    this.uTurn = true;
                }
            }
        }
        else
        {
            if (ON.Contains("bMTFC"))
            {
                if (!this.Attacking)
                {
                    this.StartCoroutine(this.Warning());
                }
                this.Attacking = true;
                this.target = OT;
                this.Trig.radius = 30;
                this.relativePoint = this.thisVTransform.InverseTransformPoint(OT.position);
                if (this.relativePoint.y > 0)
                {
                    this.uTurn = true;
                }
            }
        }
    }

    public virtual void CalcLead()
    {
        if (this.target)
        {
            this.Dist1 = Vector3.Distance(this.thisTransform.position, this.target.position);
            this.Dist2 = Vector3.Distance(this.TargetTrace.position, this.target.position);
            this.TargetTrace.LookAt(this.target);
            this.TargetLead.position = this.TargetTrace.position;
            this.TargetLead.rotation = this.TargetTrace.rotation;
            this.TargetLead.position = this.TargetLead.position + (((this.TargetLead.forward * this.Dist1) * this.Dist2) * this.leadAmount);
        }
    }

    public virtual IEnumerator Unstick()
    {
        this.ManeuvForce = -0.2f;
        yield return new WaitForSeconds(0.5f);
        this.ManeuvForce = 0.2f;
        yield return new WaitForSeconds(0.5f);
        this.ManeuvForce = 0;
    }

    public virtual IEnumerator Warning()
    {
        RaycastHit hitS = default(RaycastHit);
        GameObject TheThing3 = UnityEngine.Object.Instantiate(this.AlarmSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
        TheThing3.transform.parent = this.gameObject.transform;
        this.vRigidbody.angularDrag = 22;
        yield return new WaitForSeconds(0.2f);
        this.uTurn = false;
        yield return new WaitForSeconds(0.2f);
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.up * 3)) + (this.thisTransform.right * 1.5f), this.thisTransform.forward * this.Dist1, Color.blue);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.up * 3)) + (this.thisTransform.right * 1.5f), this.thisTransform.forward, out hitS, this.Dist1))
        {
            this.RHitD = hitS.distance;
        }
        else
        {
            this.RHitD = this.Dist1;
        }
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.up * 3)) + (-this.thisTransform.right * 1.5f), this.thisTransform.forward * this.Dist1, Color.blue);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.up * 3)) + (-this.thisTransform.right * 1.5f), this.thisTransform.forward, out hitS, this.Dist1))
        {
            this.LHitD = hitS.distance;
        }
        else
        {
            this.LHitD = this.Dist1;
        }
        if (this.RHitD < this.LHitD)
        {
            if (hitS.collider.tag.Contains("Te"))
            {
                this.strafeLeft = true;
            }
            if (hitS.collider.tag.Contains("Str"))
            {
                this.strafeLeft = true;
            }
        }
        if (this.LHitD < this.RHitD)
        {
            if (hitS.collider.tag.Contains("Te"))
            {
                this.strafeRight = true;
            }
            if (hitS.collider.tag.Contains("Str"))
            {
                this.strafeRight = true;
            }
        }
        yield return new WaitForSeconds(0.4f);
        this.strafeLeft = false;
        this.strafeRight = false;
        this.Armed = true;
    }

    public virtual void Regenerator()
    {
        if (this.Damaged)
        {
            return;
        }
        this.vRigidbody.centerOfMass = new Vector3(0, 0, 0);
        if (this.Home)
        {
            this.IsActive = true;
            this.Wing.gameObject.SetActive(true);
            this.vRigidbody.drag = 0.4f;
            if (!this.Attacking)
            {
                if (this.target)
                {
                    this.tDist = Vector3.Distance(this.thisTransform.position, this.target.position);
                }
                if (WorldInformation.bigMissile1 || WorldInformation.bigMissile2)
                {
                    this.TargetTrace.position = this.Home.position;
                    this.StartCoroutine(this.MoveWaypoint());
                }
                else
                {
                    if (Vector3.Distance(this.thisTransform.position, this.Home.position) > 15)
                    {
                        this.target = this.Home;
                    }
                    else
                    {
                        this.target = null;
                    }
                }
                if (Vector3.Distance(this.thisTransform.position, this.Home.position) > 15)
                {
                    this.Force = 0.1f;
                }
                else
                {
                    this.Force = 0;
                }
                this.vRigidbody.angularDrag = 16;
            }
            else
            {
                this.Force = 0.1f;
                if (this.Dist1 < 128)
                {
                    this.vRigidbody.angularDrag = 32;
                }
                else
                {
                    this.vRigidbody.angularDrag = 22;
                }
            }
        }
        if (this.target == null)
        {
            this.Trig.radius = 400;
        }
        Vector3 lastPos = this.thisTransform.position;
        this.StartCoroutine(this.HomeMoving(lastPos));
        if (this.target == null)
        {
            this.Attacking = false;
            this.Armed = false;
        }
    }

    public virtual IEnumerator MoveWaypoint()
    {
        yield return new WaitForSeconds(0.25f);
        if (!this.Attacking)
        {
            float hDist = Vector3.Distance(this.TargetTrace.position, this.Home.position);
            this.TargetTrace.LookAt(this.Home);
            if (WorldInformation.bigMissile1)
            {
                if (WorldInformation.bigMissile1.name.Contains("TC3"))
                {
                    this.TargetTrace.position = this.TargetTrace.position + ((this.TargetTrace.forward * hDist) * 15);
                }
                else
                {
                    this.TargetTrace.position = this.TargetTrace.position + ((this.TargetTrace.forward * hDist) * 5);
                }
                this.TargetTrace.LookAt(WorldInformation.bigMissile1);
            }
            if (WorldInformation.bigMissile2)
            {
                if (WorldInformation.bigMissile2.name.Contains("TC3"))
                {
                    this.TargetTrace.position = this.TargetTrace.position + ((this.TargetTrace.forward * hDist) * 15);
                }
                else
                {
                    this.TargetTrace.position = this.TargetTrace.position + ((this.TargetTrace.forward * hDist) * 5);
                }
                this.TargetTrace.LookAt(WorldInformation.bigMissile2);
            }
            this.TargetTrace.position = this.TargetTrace.position + ((this.TargetTrace.forward * 16) * hDist);
            this.Waypoint.position = this.TargetTrace.position;
            this.target = this.Waypoint;
        }
    }

    public virtual IEnumerator HomeMoving(Vector3 lastPos)
    {
        yield return new WaitForSeconds(0.25f);
        if (Vector3.Distance(this.thisTransform.position, lastPos) > 0.5f)
        {
            this.HomeIsMoving = true;
        }
        else
        {
            this.HomeIsMoving = false;
        }
    }

    public TerbotekDroneAI()
    {
        this.leadAmount = 0.02f;
        this.GyroForce = 10f;
        this.Force = 0.2f;
    }

}