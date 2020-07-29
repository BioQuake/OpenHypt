using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class VelocityEmissionConfigurable : MonoBehaviour
{
    // speed at which audio clip plays at its original pitch:
    public Transform TargetVelocity;
    public float EmitSpeed;
    public float MaxEmissionaise;
    public float MinEmissionaise;
    public bool CanFade;
    public float FadeSpeed;
    public bool TwoDirectional;
    public bool Reversed;
    public bool YAxis;
    public bool Broken;
    private ParticleSystem pSystem;
    private Transform thisTransform;
    private Rigidbody thisRB;
    public virtual void Start()
    {
        this.thisTransform = this.transform;
        this.thisRB = this.TargetVelocity.GetComponent<Rigidbody>();
        this.pSystem = this.GetComponent<ParticleSystem>();
    }

    public virtual void FixedUpdate()
    {
        if (!this.Broken && (this.TargetVelocity != null))
        {
            if (!this.YAxis)
            {
                if (!this.Reversed)
                {
                    Vector3 localV = this.thisTransform.InverseTransformDirection(this.thisRB.velocity);
                    float p = -localV.z / this.EmitSpeed;
                    float r = localV.z / this.EmitSpeed;
                    if (!this.TwoDirectional)
                    {
                        if (this.CanFade)
                        {

                            {
                                float _3720 = p * this.FadeSpeed;
                                Color _3721 = this.pSystem.startColor;
                                _3721.a = _3720;
                                this.pSystem.startColor = _3721;
                            }
                        }
                        this.pSystem.emissionRate = Mathf.Clamp(p, this.MinEmissionaise, this.MaxEmissionaise);
                    }
                    else
                    {
                        if (this.CanFade)
                        {

                            {
                                float _3722 = p * this.FadeSpeed;
                                Color _3723 = this.pSystem.startColor;
                                _3723.a = _3722;
                                this.pSystem.startColor = _3723;
                            }
                        }
                        this.pSystem.emissionRate = Mathf.Clamp(p, this.MinEmissionaise, this.MaxEmissionaise) + Mathf.Clamp(r, this.MinEmissionaise, this.MaxEmissionaise);
                    }
                }
                else
                {
                    Vector3 localV1 = this.thisTransform.InverseTransformDirection(this.thisRB.velocity);
                    float p1 = localV1.z / this.EmitSpeed;
                    float r1 = -localV1.z / this.EmitSpeed;
                    if (!this.TwoDirectional)
                    {
                        if (this.CanFade)
                        {

                            {
                                float _3724 = p1 * this.FadeSpeed;
                                Color _3725 = this.pSystem.startColor;
                                _3725.a = _3724;
                                this.pSystem.startColor = _3725;
                            }
                        }
                        this.pSystem.emissionRate = Mathf.Clamp(p1, this.MinEmissionaise, this.MaxEmissionaise);
                    }
                    else
                    {
                        if (this.CanFade)
                        {

                            {
                                float _3726 = p1 * this.FadeSpeed;
                                Color _3727 = this.pSystem.startColor;
                                _3727.a = _3726;
                                this.pSystem.startColor = _3727;
                            }
                        }
                        this.pSystem.emissionRate = Mathf.Clamp(p1, this.MinEmissionaise, this.MaxEmissionaise) + Mathf.Clamp(r1, this.MinEmissionaise, this.MaxEmissionaise);
                    }
                }
            }
            else
            {
                Vector3 localV2 = this.thisTransform.InverseTransformDirection(this.thisRB.velocity);
                float p2 = -localV2.y / this.EmitSpeed;
                float r2 = localV2.y / this.EmitSpeed;
                if (!this.TwoDirectional)
                {
                    if (this.CanFade)
                    {

                        {
                            float _3728 = p2 * this.FadeSpeed;
                            Color _3729 = this.pSystem.startColor;
                            _3729.a = _3728;
                            this.pSystem.startColor = _3729;
                        }
                    }
                    this.pSystem.emissionRate = Mathf.Clamp(p2, this.MinEmissionaise, this.MaxEmissionaise);
                }
                else
                {
                    if (this.CanFade)
                    {

                        {
                            float _3730 = p2 * this.FadeSpeed;
                            Color _3731 = this.pSystem.startColor;
                            _3731.a = _3730;
                            this.pSystem.startColor = _3731;
                        }
                    }
                    this.pSystem.emissionRate = Mathf.Clamp(p2, this.MinEmissionaise, this.MaxEmissionaise) + Mathf.Clamp(r2, this.MinEmissionaise, this.MaxEmissionaise);
                }
            }
        }
        if (this.Broken || (this.TargetVelocity == null))
        {
            this.pSystem.emissionRate = this.pSystem.emissionRate - 1;
        }
    }

    public VelocityEmissionConfigurable()
    {
        this.EmitSpeed = 60f;
        this.MaxEmissionaise = 200;
        this.FadeSpeed = 2;
    }

}