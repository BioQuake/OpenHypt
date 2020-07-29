using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class DropPodScript : MonoBehaviour
{
    public Transform target;
    public Transform Waypoint;
    public Transform Forward;
    public Transform AIAnchor;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public bool TurnRight;
    public bool TurnLeft;
    public ParticleSystem ThrusterFX1;
    public ParticleSystem ThrusterFX2;
    public ParticleSystem BreakFX1;
    public ParticleSystem BreakFX2;
    public bool Braking;
    public bool Done;
    public FixedJoint Fjoint;
    public Rigidbody CoverRB;
    public Transform CoverTF;
    public MeshCollider CoverCol;
    public float CoverForceD;
    public AudioSource CoverSound;
    public AudioSource BreakSound;
    public AudioSource ThrusterSound;
    public float Dist;
    public float vel;
    public float dirForce;
    public Vector3 localV;
    public LayerMask targetLayers;
    public float RD;
    public float GyroForce;
    public float TurnForce;
    public virtual void Start()
    {
        this.InvokeRepeating("Regenerator", 1, 1);
        this.target = PlayerInformation.instance.PiriTarget;
        this.dirForce = 8;
    }

    public virtual void FixedUpdate()
    {
        RaycastHit hit = default(RaycastHit);
        if (this.Done)
        {
            return;
        }
        this.TurnForce = 0;
        float RPClamp = 0.0f;
        if (this.target)
        {
            this.Dist = Vector3.Distance(this.thisTransform.position, this.target.position);
            this.vel = Mathf.Clamp(this.vRigidbody.velocity.magnitude * 2.24f, 0.1f, 1024);
            if (Physics.Linecast(this.thisTransform.position, this.target.position, (int) this.targetLayers))
            {
                this.TurnForce = 6;
                RPClamp = Mathf.Clamp(this.Dist * 0.2f, 16, 256);
            }
            else
            {
                RPClamp = Mathf.Clamp(this.Dist * 0.2f, 64, 256);
            }
            if (this.Dist < 60)
            {
                if (!Physics.Linecast(this.thisTransform.position, this.target.position, (int) this.targetLayers))
                {
                    if (!this.Braking)
                    {
                        this.ThrusterFX1.enableEmission = false;
                        this.ThrusterFX2.enableEmission = false;
                        this.BreakFX1.Play();
                        this.BreakFX2.Play();
                        this.BreakSound.Play();
                        this.dirForce = 16;
                        this.Braking = true;
                    }
                }
                this.decrement();
                if (this.vel < 0.2f)
                {
                    this.StartCoroutine(this.Open());
                    this.Done = true;
                }
            }
        }
        this.thisTransform.rotation = this.AIAnchor.transform.rotation;
        this.thisTransform.position = this.AIAnchor.transform.position;
        Vector3 newRot = (this.thisTransform.forward * 5).normalized;
        this.TurnLeft = false;
        this.TurnRight = false;
        newRot = ((this.thisTransform.forward * 8) + (this.thisTransform.right * 1)).normalized;
        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.right * 2), (newRot * this.vel) * 0.8f, Color.black);
        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.right * 2), newRot, out hit, this.vel * 0.8f, (int) this.targetLayers))
        {
            this.TurnLeft = true;
        }
        newRot = ((this.thisTransform.forward * 8) + (this.thisTransform.right * -1)).normalized;
        Debug.DrawRay(this.thisTransform.position + (-this.thisTransform.right * 2), (newRot * this.vel) * 0.8f, Color.black);
        if (Physics.Raycast(this.thisTransform.position + (-this.thisTransform.right * 2), newRot, out hit, this.vel * 0.8f, (int) this.targetLayers))
        {
            this.TurnRight = true;
        }
        Vector3 localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
        if (localV.z < 0)
        {
            this.RD = Mathf.Abs(localV.z);
        }
        else
        {
            this.RD = 0;
        }
        if (this.TurnLeft)
        {
            this.TurnForce = -8;
        }
        if (this.TurnRight)
        {
            this.TurnForce = 8;
        }
        if (this.Braking)
        {
            if (this.dirForce > 0)
            {
                this.dirForce = this.dirForce - 0.1f;
            }
            if (-localV.y > 0)
            {
                this.vRigidbody.AddForce(this.thisVTransform.up * this.dirForce);
            }
        }
        else
        {
            this.vRigidbody.AddTorque(this.thisTransform.up * this.TurnForce);
            if (this.target)
            {
                this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * 2, this.thisTransform.forward * 2);
                this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * -2, -this.thisTransform.forward * 2);
            }
            if (this.Dist > 1000)
            {
                if (this.vel < 500)
                {
                    this.vRigidbody.AddForce(-this.thisVTransform.up * this.dirForce);
                }
            }
            else
            {
                if (this.vel < 250)
                {
                    this.vRigidbody.AddForce(-this.thisVTransform.up * this.dirForce);
                }
            }
            newRot = ((this.thisTransform.forward * 6) + (this.thisTransform.up * -2)).normalized;
            Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * 1)) + (-this.thisTransform.up * 1), newRot * RPClamp, Color.white);
            if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * 1)) + (-this.thisTransform.up * 1), newRot, out hit, RPClamp, (int) this.targetLayers))
            {
                this.vRigidbody.AddTorque(this.thisTransform.right * -4);
            }
            else
            {
                this.vRigidbody.AddForceAtPosition(Vector3.up * this.GyroForce, this.thisTransform.up * 1);
                this.vRigidbody.AddForceAtPosition(-Vector3.up * this.GyroForce, -this.thisTransform.up * 1);
            }
        }
    }

    public virtual void Regenerator()
    {
    }

    public virtual void decrement()
    {
        if (this.ThrusterSound.volume > 0.11f)
        {
            this.ThrusterSound.volume = this.ThrusterSound.volume - 0.05f;
        }
        if (this.ThrusterSound.volume < 0.12f)
        {
            this.ThrusterSound.volume = this.ThrusterSound.volume - 0.01f;
        }
    }

    public virtual IEnumerator Open()
    {
        yield return new WaitForSeconds(2);
        CallAssistance.IsKatovariying = false;
        this.CoverCol.enabled = false;
        UnityEngine.Object.Destroy(this.Fjoint);
        this.CoverSound.Play();
        this.CoverRB.AddForce(Vector3.up * this.CoverForceD);
        this.CoverRB.AddForce((Vector3.right * this.CoverForceD) * 0.5f);
        this.CoverRB.AddTorque((this.CoverTF.right * this.CoverForceD) * 0.3f);
        this.CoverRB.AddTorque((this.CoverTF.up * this.CoverForceD) * 0.05f);
        yield return new WaitForSeconds(0.1f);
        this.CoverCol.enabled = true;
    }

    public DropPodScript()
    {
        this.CoverForceD = 200;
        this.GyroForce = 0.2f;
    }

}