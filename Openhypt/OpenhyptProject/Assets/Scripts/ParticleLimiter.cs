using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ParticleLimiter : MonoBehaviour
{
    public Transform CamTarget;
    public Transform thisTransform;
    public int DistThreshold;
    public ParticleSystem Particle1;
    public ParticleSystem Particle2;
    public float OriginalRate1;
    public float OriginalRate2;
    public bool StartFromZero;
    public virtual void Start()
    {
        this.InvokeRepeating("Ticker", 0, 0.16f);
        this.thisTransform = this.transform;
        this.CamTarget = PlayerInformation.instance.PhysCam;
        if (this.Particle1)
        {
            this.OriginalRate1 = this.Particle1.startColor.a;
        }
        if (this.Particle2)
        {
            this.OriginalRate2 = this.Particle2.startColor.a;
        }
        if (Vector3.Distance(this.thisTransform.position, this.CamTarget.position) > this.DistThreshold)
        {
            if (this.Particle1)
            {

                {
                    int _2586 = 0;
                    Color _2587 = this.Particle1.startColor;
                    _2587.a = _2586;
                    this.Particle1.startColor = _2587;
                }
            }
            if (this.Particle2)
            {

                {
                    int _2588 = 0;
                    Color _2589 = this.Particle2.startColor;
                    _2589.a = _2588;
                    this.Particle2.startColor = _2589;
                }
            }
        }
        if (this.StartFromZero)
        {
            if (this.Particle1)
            {

                {
                    int _2590 = 0;
                    Color _2591 = this.Particle1.startColor;
                    _2591.a = _2590;
                    this.Particle1.startColor = _2591;
                }
            }
            if (this.Particle2)
            {

                {
                    int _2592 = 0;
                    Color _2593 = this.Particle2.startColor;
                    _2593.a = _2592;
                    this.Particle2.startColor = _2593;
                }
            }
        }
    }

    public virtual void Ticker()
    {
        if (Vector3.Distance(this.thisTransform.position, this.CamTarget.position) > this.DistThreshold)
        {
            if (this.Particle1)
            {

                {
                    float _2594 = this.Particle1.startColor.a - 0.01f;
                    Color _2595 = this.Particle1.startColor;
                    _2595.a = _2594;
                    this.Particle1.startColor = _2595;
                }
            }
            if (this.Particle2)
            {

                {
                    float _2596 = this.Particle2.startColor.a - 0.01f;
                    Color _2597 = this.Particle2.startColor;
                    _2597.a = _2596;
                    this.Particle2.startColor = _2597;
                }
            }
        }
        else
        {
            if (this.Particle1)
            {
                if (this.Particle1.startColor.a < this.OriginalRate1)
                {

                    {
                        float _2598 = this.Particle1.startColor.a + 0.01f;
                        Color _2599 = this.Particle1.startColor;
                        _2599.a = _2598;
                        this.Particle1.startColor = _2599;
                    }
                }
            }
            if (this.Particle2)
            {
                if (this.Particle2.startColor.a < this.OriginalRate2)
                {

                    {
                        float _2600 = this.Particle2.startColor.a + 0.01f;
                        Color _2601 = this.Particle2.startColor;
                        _2601.a = _2600;
                        this.Particle2.startColor = _2601;
                    }
                }
            }
        }
    }

    public ParticleLimiter()
    {
        this.DistThreshold = 100;
    }

}