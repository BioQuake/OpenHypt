using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SpeedLimiterNPC : MonoBehaviour
{
    public AnimationCurve curve;
    public float DragAmount;
    public float VelocityModifier;
    public virtual void Start()
    {
    }

    public virtual void Update()
    {
        float p = this.GetComponent<Rigidbody>().velocity.magnitude / this.VelocityModifier;
        this.DragAmount = this.curve.Evaluate(p) * 50;
        this.GetComponent<Rigidbody>().drag = this.DragAmount;
    }

    public SpeedLimiterNPC()
    {
        this.curve = new AnimationCurve();
        this.VelocityModifier = 10;
    }

}