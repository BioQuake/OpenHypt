using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SpeedLimiter : MonoBehaviour
{
    public bool UseStopper;
    public bool CanBoost;
    public AnimationCurve curve;
    public AnimationCurve BoostCurve;
    public float DragAmount;
    public float StopperDragAmount;
    public float VelocityModifier;
    public virtual void Start()
    {
    }

    public virtual void Update()
    {
        float p = this.GetComponent<Rigidbody>().velocity.magnitude / this.VelocityModifier;
        if (!this.CanBoost)
        {
            this.DragAmount = this.curve.Evaluate(p) * 50;
            this.GetComponent<Rigidbody>().drag = this.DragAmount;
        }
        if (Input.GetKey("w") && this.CanBoost)
        {
            if (!Input.GetKey(KeyCode.B))
            {
                this.DragAmount = this.curve.Evaluate(p) * 50;
            }
            if (Input.GetKey(KeyCode.B))
            {
                this.DragAmount = this.BoostCurve.Evaluate(p) * 50;
            }
            this.GetComponent<Rigidbody>().drag = this.DragAmount;
        }
        if (this.UseStopper)
        {
            if (!Input.GetKey("w"))
            {
                this.GetComponent<Rigidbody>().drag = this.StopperDragAmount;
            }
        }
    }

    public SpeedLimiter()
    {
        this.curve = new AnimationCurve();
        this.BoostCurve = new AnimationCurve();
        this.StopperDragAmount = 1;
        this.VelocityModifier = 10;
    }

}