using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class Lifter : MonoBehaviour
{
    public float Lift;
    public float CruiseLift;
    public bool CruiseHover;
    public bool CanLiftFurther;
    public virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.PageDown))
        {
            if (this.CruiseHover == true)
            {
                this.CruiseHover = false;
            }
            else
            {
                this.CruiseHover = true;
            }
        }
    }

    public virtual void FixedUpdate()
    {
        if (WorldInformation.playerCar == this.transform.parent.name)
        {
            if (Input.GetKey(KeyCode.PageUp) && this.CanLiftFurther)
            {
                this.GetComponent<Rigidbody>().AddForce(this.transform.forward * this.Lift);
            }
            if (this.CruiseHover == true)
            {
                this.GetComponent<Rigidbody>().AddForce(this.transform.forward * this.CruiseLift);
            }
        }
    }

    public Lifter()
    {
        this.Lift = 100;
        this.CruiseLift = 100;
        this.CanLiftFurther = true;
    }

}