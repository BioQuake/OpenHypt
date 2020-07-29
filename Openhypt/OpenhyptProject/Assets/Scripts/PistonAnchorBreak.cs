using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PistonAnchorBreak : MonoBehaviour
{
    public bool breaksOn;
    public float AnchorLength;
    public virtual void Start()
    {
        if (this.breaksOn == true)
        {
            this.breaksOn = true;
            ((ConfigurableJoint) this.GetComponent(typeof(ConfigurableJoint))).targetPosition = new Vector3(0, 0, this.AnchorLength);
        }
    }

    public virtual void Update()
    {
        if (WorldInformation.playerCar == this.transform.parent.name)
        {
            if (this.breaksOn == false)
            {
                this.breaksOn = false;
                ((ConfigurableJoint) this.GetComponent(typeof(ConfigurableJoint))).targetPosition = new Vector3(0, 0, 0);
            }
            if (this.breaksOn == true)
            {
                this.breaksOn = true;
                ((ConfigurableJoint) this.GetComponent(typeof(ConfigurableJoint))).targetPosition = new Vector3(0, 0, this.AnchorLength);
            }
        }
    }

    public PistonAnchorBreak()
    {
        this.AnchorLength = 2;
    }

}