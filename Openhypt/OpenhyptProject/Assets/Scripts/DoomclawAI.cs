using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class DoomclawAI : MonoBehaviour
{
    public Transform target;
    public Transform AIAnchor;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public bool TurnRight;
    public bool TurnLeft;
    public bool TurnUp;
    public bool TurnDown;
    public bool Engaging;
    public ParticleSystem ThrusterFX1;
    public ParticleSystem ThrusterFX2;
    public AudioSource ThrusterSound;
    public float Dist;
    public float vel;
    public float dirForce;
    public Vector3 localV;
    public LayerMask targetLayers;
    public float GyroForce;
    public float TurnForce;
    public float PitchForce;
    public virtual void Start()
    {
        this.InvokeRepeating("Regenerator", 1, 0.2f);
        AgrianNetwork.DoomclawActive = true;
        AgrianNetwork.theDoomclaw = this.thisTransform;
    }

    public virtual void FixedUpdate()
    {
        RaycastHit hit = default(RaycastHit);
        if (this.target)
        {
            this.Dist = Vector3.Distance(this.thisTransform.position, this.target.position);
        }
        this.vel = Mathf.Clamp(this.vRigidbody.velocity.magnitude * 2.24f, 32, 1024);
        this.thisTransform.rotation = this.AIAnchor.transform.rotation;
        this.thisTransform.position = this.AIAnchor.transform.position;
        Vector3 newRot = (this.thisTransform.forward * 5).normalized;
        this.TurnLeft = false;
        this.TurnRight = false;
        this.TurnUp = false;
        this.TurnDown = false;
        newRot = ((this.thisTransform.forward * 8) + (this.thisTransform.right * 1)).normalized;
        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.right * 6), (newRot * this.vel) * 0.8f, Color.black);
        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.right * 6), newRot, out hit, this.vel * 0.8f, (int) this.targetLayers))
        {
            this.TurnLeft = true;
        }
        newRot = ((this.thisTransform.forward * 8) + (this.thisTransform.right * -1)).normalized;
        Debug.DrawRay(this.thisTransform.position + (-this.thisTransform.right * 6), (newRot * this.vel) * 0.8f, Color.black);
        if (Physics.Raycast(this.thisTransform.position + (-this.thisTransform.right * 6), newRot, out hit, this.vel * 0.8f, (int) this.targetLayers))
        {
            this.TurnRight = true;
        }
        newRot = ((this.thisTransform.forward * 8) + (this.thisTransform.up * -1)).normalized;
        Debug.DrawRay(this.thisTransform.position + (-this.thisTransform.up * 6), (newRot * this.vel) * 0.8f, Color.red);
        if (Physics.Raycast(this.thisTransform.position + (-this.thisTransform.up * 6), newRot, out hit, this.vel * 0.8f, (int) this.targetLayers))
        {
            this.TurnUp = true;
        }
        newRot = ((this.thisTransform.forward * 8) + (this.thisTransform.up * 1)).normalized;
        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.up * 6), (newRot * this.vel) * 0.8f, Color.blue);
        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.up * 6), newRot, out hit, this.vel * 0.8f, (int) this.targetLayers))
        {
            this.TurnDown = true;
        }
        if (this.TurnLeft)
        {
            this.TurnForce = -Mathf.Clamp(this.vRigidbody.velocity.magnitude * 0.5f, 32, 128);
        }
        if (this.TurnRight)
        {
            this.TurnForce = Mathf.Clamp(this.vRigidbody.velocity.magnitude * 0.5f, 32, 128);
        }
        if (this.TurnUp)
        {
            this.PitchForce = -Mathf.Clamp(this.vRigidbody.velocity.magnitude * 0.5f, 32, 128);
        }
        if (this.TurnDown)
        {
            this.PitchForce = Mathf.Clamp(this.vRigidbody.velocity.magnitude * 0.5f, 32, 128);
        }
        if (!this.Engaging)
        {
            this.dirForce = 16;
        }
        else
        {
            this.dirForce = 64;
        }
        if (this.Dist > 256)
        {
            if (this.vel < 1024)
            {
                this.vRigidbody.AddForce(-this.thisVTransform.up * this.dirForce);
            }
        }
        else
        {
            if (this.vel < 830)
            {
                this.vRigidbody.AddForce(-this.thisVTransform.up * this.dirForce);
            }
        }
        this.vRigidbody.AddTorque(this.thisTransform.up * this.TurnForce);
        this.vRigidbody.AddTorque(this.thisTransform.right * this.PitchForce);
        if (this.target)
        {
            this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * 32, this.thisTransform.forward * 4);
            this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * -32, -this.thisTransform.forward * 4);
        }
        this.vRigidbody.AddForceAtPosition(Vector3.up * this.GyroForce, this.thisTransform.up * 1);
        this.vRigidbody.AddForceAtPosition(-Vector3.up * this.GyroForce, -this.thisTransform.up * 1);
    }

    public virtual void Regenerator()
    {
        this.TurnForce = 0;
        this.PitchForce = 0;
        if (AgrianNetwork.DoomstarActive)
        {
            this.target = AgrianNetwork.theDoomstar;
        }
    }

    public DoomclawAI()
    {
        this.Dist = 512;
        this.GyroForce = 0.2f;
        this.TurnForce = 8;
        this.PitchForce = 8;
    }

}