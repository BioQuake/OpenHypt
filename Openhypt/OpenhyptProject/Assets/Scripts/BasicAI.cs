using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class BasicAI : MonoBehaviour
{
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public bool Obstacle;
    public bool TurnRight;
    public bool TurnLeft;
    public bool StrafeRight;
    public bool StrafeLeft;
    public bool useRaySpread;
    public float RaySpreadMod;
    public float RaySpreadWidth;
    private float RaySpread;
    public float RayLengthObstacle;
    public float RayLengthTurn;
    public int SD; //Front Shaped obstacle circumvent ray : Distance
    public int SDf; //Front Shaped obstacle circumvent ray : Forward Location
    public int SDl; //Front Shaped obstacle circumvent ray : Right Outwards Location
    public int SDr; //Front Shaped obstacle circumvent ray : Left Outwards Location
    public int SDa; //Front Shaped obstacle circumvent ray : Both Rotation Angle
    public int SD2; //Rear Shaped obstacle circumvent ray : Distance
    public int SD2f; //Rear Shaped obstacle circumvent ray : Forward Location
    public int SD2l; //Rear Shaped obstacle circumvent ray : Right Outwards Location
    public int SD2r; //Rear Shaped obstacle circumvent ray : Left Outwards Location
    public int SD2a; //Rear Shaped obstacle circumvent ray : Both Rotation Angle
    public bool Parked;
    public float DirForce;
    public float BrakeForce;
    public float AngForce;
    public float Vel;
    public float VelClampMod;
    public float MaxVel;
    public LayerMask targetLayers;
    public virtual void Start()
    {
    }

    public virtual void Update()
    {
    }

    public virtual void FixedUpdate()
    {
        RaycastHit hit = default(RaycastHit);
        Vector3 newRot2 = default(Vector3);
        float VelClamp = Mathf.Clamp(this.Vel * this.VelClampMod, 16, 2048);
        Vector3 localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
        this.Vel = -localV.y * 2.24f;
        if (this.useRaySpread)
        {
            if (this.RaySpread < this.RaySpreadWidth)
            {
                this.RaySpread = this.RaySpread + this.RaySpreadMod;
            }
            else
            {
                this.RaySpread = this.RaySpreadMod;
            }
        }
        this.Obstacle = false;
        this.TurnLeft = false;
        this.TurnRight = false;
        this.StrafeRight = false;
        this.StrafeLeft = false;
        float RightDist;
        float LeftDist;
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * this.RayLengthObstacle)) + (this.thisTransform.right * this.RaySpread), this.thisTransform.forward * VelClamp, Color.red);
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * this.RayLengthObstacle)) + (-this.thisTransform.right * this.RaySpread), this.thisTransform.forward * VelClamp, Color.red);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * this.RayLengthObstacle)) + (this.thisTransform.right * this.RaySpread), this.thisTransform.forward, VelClamp, (int) this.targetLayers) || Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * this.RayLengthObstacle)) + (-this.thisTransform.right * this.RaySpread), this.thisTransform.forward, VelClamp, (int) this.targetLayers))
        {
            this.Obstacle = true;
        }
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * this.RayLengthTurn)) + (this.thisTransform.right * this.RaySpread), this.thisTransform.forward * VelClamp, Color.black);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * this.RayLengthTurn)) + (this.thisTransform.right * this.RaySpread), this.thisTransform.forward, VelClamp, (int) this.targetLayers))
        {
            this.TurnLeft = true;
        }
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * this.RayLengthTurn)) + (-this.thisTransform.right * this.RaySpread), this.thisTransform.forward * VelClamp, Color.black);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * this.RayLengthTurn)) + (-this.thisTransform.right * this.RaySpread), this.thisTransform.forward, VelClamp, (int) this.targetLayers))
        {
            this.TurnRight = true;
        }
        newRot2 = ((this.thisTransform.forward * 32) + (this.thisTransform.right * -this.SDa)).normalized;
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * this.SDf)) + (this.thisTransform.right * this.SDl), newRot2 * this.SD, Color.black);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * this.SDf)) + (this.thisTransform.right * this.SDl), newRot2, out hit, this.SD, (int) this.targetLayers))
        {
            RightDist = hit.distance;
        }
        else
        {
            RightDist = 512;
        }
        newRot2 = ((this.thisTransform.forward * 32) + (this.thisTransform.right * this.SDa)).normalized;
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * this.SDf)) + (-this.thisTransform.right * this.SDr), newRot2 * this.SD, Color.black);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * this.SDf)) + (-this.thisTransform.right * this.SDr), newRot2, out hit, this.SD, (int) this.targetLayers))
        {
            LeftDist = hit.distance;
        }
        else
        {
            LeftDist = 512;
        }
        newRot2 = ((this.thisTransform.forward * 32) + (this.thisTransform.right * -this.SD2a)).normalized;
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * this.SD2f)) + (this.thisTransform.right * this.SD2l), newRot2 * this.SD2, Color.black);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * this.SD2f)) + (this.thisTransform.right * this.SD2l), newRot2, out hit, this.SD2, (int) this.targetLayers))
        {
            RightDist = 1;
        }
        newRot2 = ((this.thisTransform.forward * 32) + (this.thisTransform.right * this.SD2a)).normalized;
        Debug.DrawRay((this.thisTransform.position + (this.thisTransform.forward * this.SD2f)) + (-this.thisTransform.right * this.SD2r), newRot2 * this.SD2, Color.black);
        if (Physics.Raycast((this.thisTransform.position + (this.thisTransform.forward * this.SD2f)) + (-this.thisTransform.right * this.SD2r), newRot2, out hit, this.SD2, (int) this.targetLayers))
        {
            LeftDist = 1;
        }
        if (RightDist > LeftDist)
        {
            this.StrafeRight = true;
        }
        if (LeftDist > RightDist)
        {
            this.StrafeLeft = true;
        }
        if (this.TurnLeft && !this.TurnRight)
        {
            this.vRigidbody.AddTorque((this.thisTransform.up * -this.AngForce) * this.vRigidbody.mass);
        }
        if (this.TurnRight && !this.TurnLeft)
        {
            this.vRigidbody.AddTorque((this.thisTransform.up * this.AngForce) * this.vRigidbody.mass);
        }
        if (this.StrafeRight && !this.StrafeLeft)
        {
            this.vRigidbody.AddForce((this.thisVTransform.right * this.DirForce) * this.vRigidbody.mass);
        }
        if (this.StrafeLeft && !this.StrafeRight)
        {
            this.vRigidbody.AddForce((-this.thisVTransform.right * this.DirForce) * this.vRigidbody.mass);
        }
        if (!this.Parked)
        {
            if (this.Obstacle)
            {
                if (this.Vel > 0)
                {
                    this.vRigidbody.AddForce((this.thisVTransform.up * this.BrakeForce) * this.vRigidbody.mass);
                }
            }
            else
            {
                if (this.Vel < this.MaxVel)
                {
                    this.vRigidbody.AddForce((-this.thisVTransform.up * this.DirForce) * this.vRigidbody.mass);
                }
            }
        }
    }

    public BasicAI()
    {
        this.SDa = 2;
        this.SD2a = 2;
    }

}