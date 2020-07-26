using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PivotingThrusterScript : MonoBehaviour
{
    public float ForwardForce;
    public float TurnForce;
    public float ReverseForce;
    public Vector3 LeftPivotAngle;
    public Vector3 RightPivotAngle;
    public Vector3 ReversePivotAngle;
    public virtual void FixedUpdate()
    {
        if (WorldInformation.playerCar == this.transform.parent.name)
        {
            if (Input.GetKey("a"))
            {
                this.GetComponent<Rigidbody>().AddForce(this.transform.right * this.TurnForce);
            }
            if (Input.GetKey("d"))
            {
                this.GetComponent<Rigidbody>().AddForce(this.transform.right * this.TurnForce);
            }
            if (Input.GetKey("s"))
            {
                this.GetComponent<Rigidbody>().AddForce(this.transform.right * this.ReverseForce);
            }
            if ((Input.GetKey("w") && !Input.GetKey("a")) && !Input.GetKey("d"))
            {
                this.GetComponent<Rigidbody>().AddForce(this.transform.right * this.ForwardForce);
            }
        }
    }

    public virtual void Update()
    {
        if (WorldInformation.playerCar.Contains("broken"))
        {
            UnityEngine.Object.Destroy(this);
        }
        if (WorldInformation.playerCar == this.transform.parent.name)
        {
            if (Input.GetKey("a"))
            {
                ((ConfigurableJoint) this.GetComponent(typeof(ConfigurableJoint))).targetRotation = Quaternion.Euler(this.LeftPivotAngle);
            }
            if (Input.GetKeyUp("a"))
            {
                ((ConfigurableJoint) this.GetComponent(typeof(ConfigurableJoint))).targetRotation = Quaternion.Euler(0, 0, 0);
                this.StartCoroutine(this.ForceDelay());
            }
            if (Input.GetKey("d"))
            {
                ((ConfigurableJoint) this.GetComponent(typeof(ConfigurableJoint))).targetRotation = Quaternion.Euler(this.RightPivotAngle);
            }
            if (Input.GetKeyUp("d"))
            {
                ((ConfigurableJoint) this.GetComponent(typeof(ConfigurableJoint))).targetRotation = Quaternion.Euler(0, 0, 0);
                this.StartCoroutine(this.ForceDelay());
            }
            if (Input.GetKey("s"))
            {
                ((ConfigurableJoint) this.GetComponent(typeof(ConfigurableJoint))).targetRotation = Quaternion.Euler(this.ReversePivotAngle);
            }
            if (Input.GetKeyUp("s"))
            {
                ((ConfigurableJoint) this.GetComponent(typeof(ConfigurableJoint))).targetRotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }

    public virtual IEnumerator ForceDelay()
    {
        this.ForwardForce = -20;
        yield return new WaitForSeconds(0.5f);
        this.ForwardForce = -70;
    }

    public PivotingThrusterScript()
    {
        this.ForwardForce = 30;
        this.TurnForce = 30;
        this.ReverseForce = 30;
    }

}