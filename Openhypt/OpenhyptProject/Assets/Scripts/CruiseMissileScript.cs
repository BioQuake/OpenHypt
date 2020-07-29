using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class CruiseMissileScript : MonoBehaviour
{
    public Transform target;
    public Transform Waypoint;
    public Transform Forward;
    public Transform AIAnchor;
    public Transform tPoint;
    public Transform TargetTrace;
    public Transform TargetLead;
    public GameObject Explosion;
    public GameObject thisParent;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public AudioSource Siren;
    public bool targetImminent;
    public bool targetEngaged;
    public int targetCode;
    public bool TurnRight;
    public bool TurnLeft;
    public float Dist;
    public float vel;
    public float RPMod;
    public float RPClamp;
    public float RPClamp2;
    public Vector3 localV;
    public LayerMask targetLayers;
    public float RD;
    public float GyroForce;
    public float TurnForce;
    public virtual void Start()
    {
        this.InvokeRepeating("Regenerator", 1, 1);
        this.InvokeRepeating("CalcLead", 1, 0.15f);
        if (!WorldInformation.bigMissile1)
        {
            WorldInformation.bigMissile1 = this.thisVTransform;
        }
        else
        {
            WorldInformation.bigMissile2 = this.thisVTransform;
        }
    }

    public virtual void FixedUpdate()
    {
        RaycastHit hit = default(RaycastHit);
        Vector3 RelativeTarget = new Vector3();
        if (this.target)
        {
            this.Dist = Vector3.Distance(this.thisTransform.position, this.target.position);
            RelativeTarget = this.thisTransform.InverseTransformPoint(this.target.position);
        }
        this.vel = Mathf.Clamp(this.vRigidbody.velocity.magnitude * 2.24f, 8, 1024);
        this.thisTransform.rotation = this.AIAnchor.transform.rotation;
        this.thisTransform.position = this.AIAnchor.transform.position;
        Vector3 newRot = (this.thisTransform.forward * 5).normalized;
        this.TurnLeft = false;
        this.TurnRight = false;
        Vector3 newRot0 = ((this.tPoint.forward * 10) + (this.tPoint.right * 1)).normalized;
        this.tPoint.Rotate(0, 0, 60);
        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 4), newRot0 * this.vel, Color.yellow);
        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 4), newRot0, out hit, this.vel, (int) this.targetLayers))
        {
            string CN = hit.collider.name;
            if (((CN.Contains("TC" + this.targetCode) || CN.Contains("DV")) || CN.Contains("UV")) || CN.Contains("rok"))
            {
                this.targetImminent = true;
            }
        }
        newRot = ((this.thisTransform.forward * 8) + (this.thisTransform.right * 1)).normalized;
        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.right * 2), (newRot * this.vel) * 0.8f, Color.black);
        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.right * 2), newRot, out hit, this.vel * 0.8f, (int) this.targetLayers))
        {
            this.TurnLeft = true;
            if (this.targetImminent)
            {
                this.TurnLeft = false;
            }
        }
        newRot = ((this.thisTransform.forward * 8) + (this.thisTransform.right * -1)).normalized;
        Debug.DrawRay(this.thisTransform.position + (-this.thisTransform.right * 2), (newRot * this.vel) * 0.8f, Color.black);
        if (Physics.Raycast(this.thisTransform.position + (-this.thisTransform.right * 2), newRot, out hit, this.vel * 0.8f, (int) this.targetLayers))
        {
            this.TurnRight = true;
            if (this.targetImminent)
            {
                this.TurnRight = false;
            }
        }
        this.localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
        if (this.localV.z < 0)
        {
            this.RD = Mathf.Abs(this.localV.z);
        }
        else
        {
            this.RD = 0;
        }
        this.RPMod = RelativeTarget.x;
        this.RPClamp = Mathf.Abs(this.RPMod);
        if (this.targetEngaged)
        {
            this.RPClamp2 = Mathf.Clamp(this.RPClamp, 32, 256);
        }
        else
        {
            this.RPClamp2 = Mathf.Clamp(this.vel, 32, 256);
        }
        this.TurnForce = 0;
        if (this.TurnLeft)
        {
            this.TurnForce = -64;
        }
        if (this.TurnRight)
        {
            this.TurnForce = 64;
        }
        this.vRigidbody.AddTorque(this.thisTransform.up * this.TurnForce);
        if (this.target)
        {
            if (this.targetEngaged)
            {
                if (this.targetImminent)
                {
                    this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * 24, this.thisTransform.forward * 2);
                    this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * -24, -this.thisTransform.forward * 2);
                }
                else
                {
                    this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * 16, this.thisTransform.forward * 2);
                    this.vRigidbody.AddForceAtPosition((this.TargetLead.transform.position - this.thisVTransform.position).normalized * -16, -this.thisTransform.forward * 2);
                }
            }
            else
            {
                this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * 16, this.thisTransform.forward * 2);
                this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * -16, -this.thisTransform.forward * 2);
            }
        }
        this.vRigidbody.AddForceAtPosition(Vector3.up * this.GyroForce, this.thisTransform.up * 2);
        this.vRigidbody.AddForceAtPosition(-Vector3.up * this.GyroForce, -this.thisTransform.up * 2);
        if (this.vel < 500)
        {
            this.vRigidbody.AddForce(-this.thisVTransform.up * 18);
        }
        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 3), (this.thisTransform.forward * this.vel) * 0.15f, Color.red);
        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 3), this.thisTransform.forward, out hit, this.vel * 0.15f, (int) this.targetLayers))
        {
            if (this.targetImminent)
            {
                TerrahyptianNetwork.instance.NukeMarker = null;
                UnityEngine.Object.Instantiate(this.Explosion, this.transform.position, this.transform.rotation);
                UnityEngine.Object.Destroy(this.thisParent);
                UnityEngine.Object.Destroy(this.gameObject);
            }
        }
        newRot = ((this.thisTransform.forward * 6) + (this.thisTransform.up * -2)).normalized;
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * 1)) + (-this.thisTransform.up * 1), newRot * this.RPClamp2, Color.white);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * 1)) + (-this.thisTransform.up * 1), newRot, out hit, this.RPClamp2, (int) this.targetLayers))
        {
            if (this.targetImminent)
            {
                return;
            }
            this.vRigidbody.AddTorque(this.thisTransform.right * -64);
        }
    }

    public virtual void CalcLead()
    {
        this.targetImminent = false;
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
            float Dist2 = Vector3.Distance(this.TargetTrace.position, this.target.position);
            float Dist0 = Mathf.Clamp(this.Dist * 0.3f, 1, 200);
            this.TargetTrace.LookAt(this.target);
            this.TargetLead.position = this.TargetTrace.position;
            this.TargetLead.rotation = this.TargetTrace.rotation;
            this.TargetLead.position = this.TargetLead.position + ((this.TargetLead.forward * Dist2) * 2);
            this.TargetLead.position = this.TargetLead.position + (this.TargetLead.forward * Dist0);
        }
    }

    public virtual void Regenerator()
    {
        if (TerrahyptianNetwork.instance.NukeMarker)
        {
            this.target = TerrahyptianNetwork.instance.NukeMarker;
            this.targetEngaged = true;
            if (!this.Siren.isPlaying)
            {
                this.Siren.Play();
            }
            if (this.target.name.Contains("C1"))
            {
                this.targetCode = 1;
            }
            if (this.target.name.Contains("C2"))
            {
                this.targetCode = 2;
            }
            if (this.target.name.Contains("C3"))
            {
                this.targetCode = 3;
            }
            if (this.target.name.Contains("C4"))
            {
                this.targetCode = 4;
            }
            if (this.target.name.Contains("C5"))
            {
                this.targetCode = 5;
            }
            if (this.target.name.Contains("C6"))
            {
                this.targetCode = 6;
            }
            if (this.target.name.Contains("C7"))
            {
                this.targetCode = 7;
            }
            if (this.target.name.Contains("C8"))
            {
                this.targetCode = 8;
            }
            if (this.target.name.Contains("C9"))
            {
                this.targetCode = 9;
            }
        }
        else
        {
            if (this.target)
            {
                if (!this.target.name.Contains("TC"))
                {
                    this.target = this.Forward;
                    this.targetEngaged = false;
                }
                else
                {
                    this.targetEngaged = true;
                    if (!this.Siren.isPlaying)
                    {
                        this.Siren.Play();
                    }
                }
            }
        }
    }

    public CruiseMissileScript()
    {
        this.GyroForce = 0.2f;
    }

}