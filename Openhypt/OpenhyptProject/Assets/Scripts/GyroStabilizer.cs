using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class GyroStabilizer : MonoBehaviour
{
    public Transform MainVessel;
    public Rigidbody target;
    public GameObject AimTarget;
    public CapsuleCollider Col;
    public float force;
    public float offset;
    public int AimSpeed;
    public float AimForceDamp;
    public float AimForceOrginalDamp;
    public float AngDamp;
    public bool Deactivated;
    public bool DirectForce;
    public bool UseContact;
    public bool UseKey;
    public bool UseAim;
    public bool Aiming;
    public float ContactDistance;
    public bool Contact;
    public LayerMask targetLayers;
    public bool Up;
    public bool Forward;
    public bool Right;
    public virtual void Start()
    {
        this.AimTarget = GameObject.Find("PlayerCameraAim").gameObject;
    }

    public virtual void Update()
    {
        if (this.UseAim)
        {
            if (!this.Deactivated)
            {
                if (WorldInformation.playerCar.Contains(this.MainVessel.name))
                {
                    if (Input.GetMouseButtonDown(1))
                    {
                        if (!WorldInformation.IsNopass && (CameraScript.InInterface == false))
                        {
                            this.target.GetComponent<Rigidbody>().angularDrag = this.AimForceDamp;
                            this.Aiming = true;
                            this.GetComponent<Rigidbody>().constraints = (RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY) | RigidbodyConstraints.FreezeRotationZ;
                        }
                    }
                    if (Input.GetMouseButtonUp(1) || Input.GetKeyDown("e"))
                    {
                        if (!WorldInformation.IsNopass && (CameraScript.InInterface == false))
                        {
                            this.target.GetComponent<Rigidbody>().angularDrag = this.AimForceOrginalDamp;
                            this.Aiming = false;
                            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                        }
                    }
                }
            }
        }
    }

    public virtual void FixedUpdate()
    {
        if (this.AngDamp > 0)
        {
            if (this.Deactivated)
            {
                this.GetComponent<Rigidbody>().angularDrag = 0;
            }
            else
            {
                this.GetComponent<Rigidbody>().angularDrag = this.AngDamp;
            }
        }
        if (!this.Deactivated)
        {
            if (!this.Aiming)
            {
                if (Physics.Raycast(this.transform.position, -this.transform.up, this.ContactDistance, (int) this.targetLayers))
                {
                    this.Contact = true;
                }
                else
                {
                    this.Contact = false;
                }
                if (this.UseKey)
                {
                    if (Input.GetKey("g"))
                    {
                        if (!CameraScript.InInterface)
                        {
                            if (this.GetComponent<Rigidbody>().angularVelocity.magnitude < 2)
                            {
                                if (WorldInformation.playerCar == this.transform.parent.name)
                                {
                                    this.GetComponent<Rigidbody>().AddTorque(this.transform.forward * this.force);
                                }
                            }
                        }
                    }
                }
                if (!this.UseKey)
                {
                    if (!this.UseContact)
                    {
                        if (!this.DirectForce)
                        {
                            if (this.Up == true)
                            {
                                this.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.up * this.force, this.transform.up * this.offset);
                                this.GetComponent<Rigidbody>().AddForceAtPosition(-Vector3.up * this.force, -this.transform.up * this.offset);
                            }
                        }
                        else
                        {
                            if (this.Up == true)
                            {
                                this.target.AddForceAtPosition(Vector3.up * this.force, this.transform.up * this.offset);
                                this.target.AddForceAtPosition(-Vector3.up * this.force, -this.transform.up * this.offset);
                            }
                        }
                        if (this.Forward == true)
                        {
                            this.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.forward * this.force, this.transform.forward * this.offset);
                            this.GetComponent<Rigidbody>().AddForceAtPosition(-Vector3.forward * this.force, -this.transform.forward * this.offset);
                        }
                        if (this.Right == true)
                        {
                            this.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.right * this.force, this.transform.forward * this.offset);
                            this.GetComponent<Rigidbody>().AddForceAtPosition(-Vector3.right * this.force, -this.transform.forward * this.offset);
                        }
                    }
                    if (this.UseContact && !this.Contact)
                    {
                        if (this.Up == true)
                        {
                            this.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.up * this.force, this.transform.up * this.offset);
                            this.GetComponent<Rigidbody>().AddForceAtPosition(-Vector3.up * this.force, -this.transform.up * this.offset);
                        }
                        if (this.Forward == true)
                        {
                            this.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.forward * this.force, this.transform.forward * this.offset);
                            this.GetComponent<Rigidbody>().AddForceAtPosition(-Vector3.forward * this.force, -this.transform.forward * this.offset);
                        }
                        if (this.Right == true)
                        {
                            this.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.right * this.force, this.transform.forward * this.offset);
                            this.GetComponent<Rigidbody>().AddForceAtPosition(-Vector3.right * this.force, -this.transform.forward * this.offset);
                        }
                    }
                }
            }
            else
            {
                Quaternion NewRotation = Quaternion.LookRotation(this.AimTarget.transform.position - this.transform.position);
                this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, NewRotation, Time.deltaTime * this.AimSpeed);
            }
        }
    }

    public GyroStabilizer()
    {
        this.force = 10f;
        this.offset = 1f;
        this.AimSpeed = 50;
        this.AimForceDamp = 20f;
        this.AimForceOrginalDamp = 2f;
        this.ContactDistance = 1;
        this.Up = true;
    }

}