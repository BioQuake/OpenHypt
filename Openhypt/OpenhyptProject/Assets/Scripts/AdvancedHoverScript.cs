using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AdvancedHoverScript : MonoBehaviour
{
    public float Multiplier;
    public GameObject MainBody;
    public float HoverForce;
    public float MaxHoverForce;
    public float HoverDistance;
    public float SpeedMultiplier;
    public float RightingForce;
    public float VSAscDescSpeed;
    public float VSAscDescSpeedTop;
    public float IncreaseSpeed;
    public float DecreaseSpeed;
    public float MinMultiplier;
    public float MaxMultiplier;
    public float RD;
    public float statInt;
    public float thisDist;
    public float virtualDistance;
    public bool GlobalOri;
    public bool breaksOn;
    public bool UseSpeed;
    public bool SkipStab;
    public bool SmoothStart;
    public bool hovering;
    public bool inside;
    public AnimationCurve curve;
    public LayerMask targetLayers;
    public virtual void Start()
    {
        this.RD = 1;
        if (this.breaksOn)
        {
            this.Multiplier = 0;
        }
    }

    public virtual void hBool()
    {
        RaycastHit hitHB = default(RaycastHit);
        if (this.hovering)
        {
            this.hovering = false;
        }
        else
        {
            this.hovering = true;
            if (Physics.Raycast(this.MainBody.transform.position, Vector3.down, out hitHB, this.HoverDistance, (int) this.targetLayers))
            {
                this.virtualDistance = this.MainBody.transform.position.y - hitHB.distance;
            }
            else
            {
                this.virtualDistance = this.MainBody.transform.position.y - this.HoverDistance;
            }
            this.Multiplier = this.MinMultiplier;
        }
    }

    public virtual void FixedUpdate()
    {
        RaycastHit hit = default(RaycastHit);
        Vector3 localV = this.MainBody.transform.InverseTransformDirection(this.MainBody.GetComponent<Rigidbody>().velocity);
        if (!this.SkipStab)
        {
            if (-localV.z > 0.1f)
            {
                float RDa = 1 + Mathf.Abs(localV.z);
                this.RD = Mathf.Clamp(RDa, 0, 2);
            }
            else
            {
                this.RD = 1;
            }
        }
        Vector3 fwd = this.transform.TransformDirection(Vector3.back);
        if (this.breaksOn)
        {
            if (this.Multiplier > 0)
            {
                this.Multiplier = this.Multiplier - this.DecreaseSpeed;
            }
            if (this.SmoothStart)
            {
                if (this.Multiplier > this.MaxMultiplier)
                {
                    this.Multiplier = this.MaxMultiplier;
                }
            }
        }
        if (!this.breaksOn)
        {
            if (this.Multiplier < 1)
            {
                this.Multiplier = this.Multiplier + this.IncreaseSpeed;
            }
            if (this.SmoothStart)
            {
                if (this.Multiplier < this.MinMultiplier)
                {
                    this.Multiplier = this.MinMultiplier;
                }
            }
        }
        float SpeedModifier;
        if (this.UseSpeed)
        {
            SpeedModifier = this.MainBody.GetComponent<Rigidbody>().velocity.magnitude * this.SpeedMultiplier;
            SpeedModifier = SpeedModifier + 1;
        }
        //if (!this.UseSpeed)
        else
        {
            SpeedModifier = 1;
        }
        if (!this.GlobalOri)
        {
            if (this.hovering)
            {
                this.thisDist = this.transform.position.y - this.virtualDistance;
                this.HoverForce = this.curve.Evaluate(this.thisDist);
                if (this.HoverForce > (this.MaxHoverForce * 0.5f))
                {
                    this.HoverForce = this.MaxHoverForce * 0.5f;
                }
                if (this.inside)
                {
                    if (Input.GetKey(KeyCode.LeftControl))
                    {
                        if (this.statInt < this.VSAscDescSpeedTop)
                        {
                            this.statInt = this.statInt + this.VSAscDescSpeed;
                        }
                        this.virtualDistance = this.virtualDistance - this.statInt;
                    }
                    else
                    {
                        if (!Input.GetKey(KeyCode.LeftShift))
                        {
                            this.statInt = 0;
                        }
                    }
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        if (this.statInt < this.VSAscDescSpeedTop)
                        {
                            this.statInt = this.statInt + this.VSAscDescSpeed;
                        }
                        this.virtualDistance = this.virtualDistance + this.statInt;
                    }
                    else
                    {
                        if (!Input.GetKey(KeyCode.LeftControl))
                        {
                            this.statInt = 0;
                        }
                    }
                }
                this.MainBody.GetComponent<Rigidbody>().AddForceAtPosition((((Vector3.up * this.HoverForce) * this.Multiplier) * SpeedModifier) * this.RD, this.transform.position, ForceMode.Impulse);
            }
            else
            {
                if (Physics.Raycast(this.transform.position, fwd, out hit, this.HoverDistance, (int) this.targetLayers))
                {
                    this.HoverForce = this.curve.Evaluate(hit.distance);
                    if (this.HoverForce > this.MaxHoverForce)
                    {
                        this.HoverForce = this.MaxHoverForce;
                    }
                    this.MainBody.GetComponent<Rigidbody>().AddForceAtPosition((((Vector3.up * this.HoverForce) * this.Multiplier) * SpeedModifier) * this.RD, this.transform.position, ForceMode.Impulse);
                }
                else
                {
                    this.HoverForce = 0;
                }
            }
        }
        else
        {
            if (this.hovering)
            {
                this.thisDist = this.transform.position.y - this.virtualDistance;
                this.HoverForce = this.curve.Evaluate(this.thisDist);
                if (this.HoverForce > (this.MaxHoverForce * 0.5f))
                {
                    this.HoverForce = this.MaxHoverForce * 0.5f;
                }
                if (this.inside)
                {
                    if (Input.GetKey(KeyCode.LeftControl))
                    {
                        if (this.statInt < this.VSAscDescSpeedTop)
                        {
                            this.statInt = this.statInt + this.VSAscDescSpeed;
                        }
                        this.virtualDistance = this.virtualDistance - this.statInt;
                    }
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        if (this.statInt < this.VSAscDescSpeedTop)
                        {
                            this.statInt = this.statInt + this.VSAscDescSpeed;
                        }
                        this.virtualDistance = this.virtualDistance + this.statInt;
                    }
                }
                this.MainBody.GetComponent<Rigidbody>().AddForceAtPosition((((Vector3.up * this.HoverForce) * this.Multiplier) * SpeedModifier) * this.RD, this.transform.position, ForceMode.Impulse);
            }
            else
            {
                if (Physics.Raycast(this.transform.position, Vector3.down, out hit, this.HoverDistance, (int) this.targetLayers))
                {
                    this.HoverForce = this.curve.Evaluate(hit.distance);
                    if (this.HoverForce > this.MaxHoverForce)
                    {
                        this.HoverForce = this.MaxHoverForce;
                    }
                    Vector3 RelativePoint = this.transform.InverseTransformPoint(hit.point);
                    if (RelativePoint.z < 0)
                    {
                        this.MainBody.GetComponent<Rigidbody>().AddForceAtPosition((((Vector3.up * this.HoverForce) * this.Multiplier) * SpeedModifier) * this.RD, this.transform.position, ForceMode.Impulse);
                    }
                    else
                    {
                        this.MainBody.GetComponent<Rigidbody>().AddTorque(this.MainBody.transform.up * this.RightingForce);
                    }
                }
                else
                {
                    this.HoverForce = 0;
                }
            }
        }
    }

    public AdvancedHoverScript()
    {
        this.Multiplier = 1;
        this.HoverForce = 1;
        this.MaxHoverForce = 90000;
        this.HoverDistance = 20;
        this.SpeedMultiplier = 1;
        this.RightingForce = 1;
        this.VSAscDescSpeed = 0.0005f;
        this.VSAscDescSpeedTop = 0.1f;
        this.IncreaseSpeed = 0.01f;
        this.DecreaseSpeed = 0.01f;
        this.RD = 1;
        this.curve = new AnimationCurve();
    }

}