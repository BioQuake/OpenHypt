using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ObjectSpin : MonoBehaviour
{
    public bool UseStepping;
    public float StepAmount;
    public int StepSpeed;
    public int Step;
    public bool Broken;
    public float Ratex;
    public float Ratey;
    public float Ratez;
    public virtual void FixedUpdate()
    {
        if (!this.Broken)
        {
            if (this.UseStepping)
            {
                if (this.Step > this.StepSpeed)
                {
                    this.transform.Rotate(this.Ratex, this.Ratey, this.Ratez * this.StepAmount);
                    this.Step = 0;
                }
                else
                {
                    this.Step = this.Step + 1;
                }
            }
            else
            {
                this.transform.Rotate(this.Ratex, this.Ratey, this.Ratez * Time.deltaTime);
            }
        }
    }

    public ObjectSpin()
    {
        this.Ratex = 23.4f;
    }

}