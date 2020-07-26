using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MevNavShieldAI : MonoBehaviour
{
    public Transform target;
    public Transform Waypoint;
    public Transform Forward;
    public Transform AIAnchor;
    public Transform Spinner;
    public RemoveOverTime NpcController;
    public Transform Home;
    public CapsuleCollider Trig;
    public GameObject Presence;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public GameObject SpotSound;
    public GameObject AttackSound;
    public GameObject RejectSound;
    public bool Activated;
    public bool Engaging;
    public bool Shot;
    public bool Far;
    public bool Obstacle;
    public bool StrafeRight;
    public bool StrafeLeft;
    public int SpinRot;
    public int SpinF1;
    public int SpinF2;
    public int Vel;
    public float AngVel;
    public float VelClamp1;
    public AnimationCurve ClampCurve;
    public Vector3 localV;
    public Vector3 relativePoint;
    public LayerMask targetLayers;
    public float RD;
    public float GyroForce;
    public bool GyroOff;
    public virtual IEnumerator Start()
    {
        this.InvokeRepeating("Regenerator", 0.27f, 0.27f);
        this.GyroForce = 0.05f;
        yield return new WaitForSeconds(0.3f);
        this.Activated = true;
    }

    public virtual void Update()
    {
        if (!this.Activated)
        {
            return;
        }
        if (this.Home)
        {
            if (this.target)
            {
                if (this.Engaging)
                {
                    if (this.Home)
                    {
                        if ((Vector3.Distance(this.thisTransform.position, this.target.position) * 8) < Vector3.Distance(this.thisTransform.position, this.Home.position))
                        {
                            this.Far = true;
                        }
                        else
                        {
                            this.Far = false;
                        }
                    }
                    else
                    {
                        this.Engaging = false;
                    }
                }
                else
                {
                    if (Vector3.Distance(this.thisTransform.position, this.Home.position) > 50)
                    {
                        this.Far = true;
                    }
                    else
                    {
                        this.Far = false;
                    }
                }
            }
        }
        this.thisTransform.rotation = this.AIAnchor.transform.rotation;
        this.thisTransform.position = this.AIAnchor.transform.position;
        if (this.target == null)
        {
            this.StopAllCoroutines();
            this.target = this.Waypoint;
            this.Engaging = false;
            //Spot = 0;
        }
        else
        {
            if (this.target.name.Contains("broken"))
            {
                this.StopAllCoroutines();
                this.target = this.Waypoint;
                this.Engaging = false;
            }
        }
    }

    public virtual void FixedUpdate()
    {
        RaycastHit hit = default(RaycastHit);
        if (!this.Activated)
        {
            return;
        }
        this.Vel = (int) this.vRigidbody.velocity.magnitude;
        this.AngVel = this.vRigidbody.angularVelocity.magnitude;
        this.localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
        float VelClamp0 = Mathf.Abs(this.localV.y);
        float VelClamp2 = Mathf.Clamp(VelClamp0 * 0.5f, 4, 16);
        this.VelClamp1 = this.ClampCurve.Evaluate(VelClamp0);
        if (this.Home)
        {
            this.relativePoint = this.thisVTransform.InverseTransformPoint(this.Home.position);
            if (this.localV.z < 0)
            {
                this.RD = Mathf.Abs(this.localV.z);
            }
            else
            {
                this.RD = 0;
            }
            this.Spinner.Rotate(0, 0, 60);
            this.SpinRot = this.SpinRot + 1;
            if (this.SpinRot > 6)
            {
                this.SpinRot = 0;
                this.SpinF1 = 0;
                this.SpinF2 = 0;
                this.Obstacle = false;
            }
            this.StrafeLeft = false;
            this.StrafeRight = false;
            if (Physics.Raycast(this.thisTransform.position, this.thisTransform.forward, out hit, 16, (int) this.targetLayers))
            {
                if (hit.collider.name.Contains("C7"))
                {
                    this.Far = true;
                }
            }
            if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.right * 1.5f), this.thisTransform.forward, out hit, 16, (int) this.targetLayers))
            {
                if (hit.collider.name.Contains("C7"))
                {
                    this.StrafeLeft = true;
                    this.Far = true;
                }
            }
            if (Physics.Raycast(this.thisTransform.position + (-this.thisTransform.right * 1.5f), this.thisTransform.forward, out hit, 16, (int) this.targetLayers))
            {
                if (hit.collider.name.Contains("C7"))
                {
                    this.StrafeRight = true;
                    this.Far = true;
                }
            }
            Debug.DrawRay((this.thisTransform.position + (this.Spinner.forward * 0.5f)) + (this.Spinner.up * 2), this.thisTransform.forward * VelClamp2, Color.red);
            if (Physics.Raycast((this.thisTransform.position + (this.Spinner.forward * 0.5f)) + (this.Spinner.up * 2), this.thisTransform.forward, VelClamp2, (int) this.targetLayers))
            {
                this.SpinF1 = -4;
                this.Obstacle = true;
            }
            Debug.DrawRay((this.thisTransform.position + (-this.Spinner.forward * 0.5f)) + (this.Spinner.up * 2), -this.thisTransform.forward * VelClamp2, Color.red);
            if (Physics.Raycast((this.thisTransform.position + (-this.Spinner.forward * 0.5f)) + (this.Spinner.up * 2), -this.thisTransform.forward, VelClamp2, (int) this.targetLayers))
            {
                this.SpinF2 = 4;
            }
            if (this.SpinF1 < 0)
            {
                this.vRigidbody.AddForce(this.Spinner.forward * this.SpinF1);
            }
            if (this.SpinF2 > 0)
            {
                this.vRigidbody.AddForce(this.Spinner.forward * this.SpinF2);
            }
            if (this.target)
            {
                if (this.Engaging)
                {
                    if (this.Vel < 60)
                    {
                        this.vRigidbody.AddForce((this.target.position - this.thisVTransform.position).normalized * 16);
                        this.vRigidbody.AddForce((this.Home.position - this.thisVTransform.position).normalized * 16);
                    }
                }
                this.vRigidbody.AddForceAtPosition((this.Home.position - this.thisVTransform.position).normalized * -0.5f, this.thisTransform.forward * 2);
                this.vRigidbody.AddForceAtPosition((this.Home.position - this.thisVTransform.position).normalized * 0.5f, -this.thisTransform.forward * 2);
            }
            this.vRigidbody.AddForceAtPosition(Vector3.up * this.GyroForce, this.thisTransform.up * 2);
            this.vRigidbody.AddForceAtPosition(-Vector3.up * this.GyroForce, -this.thisTransform.up * 2);
            if (!Physics.Raycast(this.thisTransform.position, Vector3.up, 2 + this.RD, (int) this.targetLayers))
            {
                if (Physics.Raycast(this.thisTransform.position, Vector3.down, 2 + this.RD, (int) this.targetLayers))
                {
                    this.vRigidbody.AddForce(Vector3.up * 4);
                }
            }
            else
            {
                this.vRigidbody.AddForce(Vector3.down * 4);
            }
            if (this.Vel < 60)
            {
                if (this.relativePoint.x < 0)
                {
                    if (this.localV.x > 0)
                    {
                        this.vRigidbody.AddForce((this.thisVTransform.right * -this.localV.x) * 0.5f);
                    }
                }
                else
                {
                    if (this.localV.x < 0)
                    {
                        this.vRigidbody.AddForce((this.thisVTransform.right * -this.localV.x) * 0.5f);
                    }
                }
                this.vRigidbody.AddForce((this.thisVTransform.forward * -this.localV.z) * 0.5f);
                this.vRigidbody.AddForce((this.thisVTransform.up * -this.localV.y) * this.VelClamp1);
                if (!this.Obstacle)
                {
                    if (this.StrafeRight && !this.StrafeLeft)
                    {
                        this.vRigidbody.AddForce(this.thisVTransform.right * 2);
                    }
                    if (this.StrafeLeft && !this.StrafeRight)
                    {
                        this.vRigidbody.AddForce(this.thisVTransform.right * -2);
                    }
                    if (this.Far)
                    {
                        this.vRigidbody.AddForce(this.thisVTransform.up * 2);
                    }
                    else
                    {
                        this.vRigidbody.AddForce(-this.thisVTransform.up * 2);
                    }
                }
            }
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (!this.Activated)
        {
            return;
        }
        if (other.GetComponent<Collider>().name.Contains("HC") && !other.GetComponent<Collider>().name.Contains("HC7"))
        {
            this.target = other.gameObject.transform;
            this.Engaging = true;
            GameObject TheThing = UnityEngine.Object.Instantiate(this.SpotSound, this.thisTransform.position + new Vector3(0, 0, 0), Quaternion.identity);
            TheThing.transform.parent = this.thisTransform;
        }
        if ((other.tag == "Projectile") && !other.GetComponent<Collider>().name.Contains("TFC7"))
        {
            this.Shot = true;
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if (!this.Activated)
        {
            return;
        }
        if (other.GetComponent<Collider>().name.Contains("HC") && !other.GetComponent<Collider>().name.Contains("HC7"))
        {
            this.target = other.gameObject.transform;
            this.Engaging = true;
        }
    }

    public virtual void Regenerator()
    {
        if (!this.Activated)
        {
            return;
        }
        if (this.target)
        {
            if (!this.target.name.Contains("HC"))
            {
                if (MevNavNetwork.instance.Threat1)
                {
                    this.target = MevNavNetwork.instance.Threat1;
                    this.Engaging = true;
                }
            }
        }
        this.GyroForce = 0.1f;
        this.Trig.center = new Vector3(0, 0, 150);
        this.Trig.radius = 100;
        this.Trig.height = 500;
    }

    public MevNavShieldAI()
    {
        this.ClampCurve = new AnimationCurve();
        this.GyroForce = 0.2f;
    }

}