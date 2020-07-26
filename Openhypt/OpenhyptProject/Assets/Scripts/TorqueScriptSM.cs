using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class TorqueScriptSM : MonoBehaviour
{
    public float Power;
    public float Modifier;
    public AnimationCurve curve;
    public virtual void FixedUpdate()
    {
        float p = this.GetComponent<Rigidbody>().velocity.magnitude;
        this.Modifier = this.curve.Evaluate(p);
        if (WorldInformation.playerCar == this.transform.parent.name)
        {
            if (Input.GetKey("a"))
            {
                this.GetComponent<Rigidbody>().AddTorque((this.transform.right * -this.Power) * this.Modifier);
            }
            if (Input.GetKey("d"))
            {
                this.GetComponent<Rigidbody>().AddTorque((this.transform.right * this.Power) * this.Modifier);
            }
        }
    }

    public TorqueScriptSM()
    {
        this.Power = 1;
        this.Modifier = 1;
        this.curve = new AnimationCurve();
    }

}