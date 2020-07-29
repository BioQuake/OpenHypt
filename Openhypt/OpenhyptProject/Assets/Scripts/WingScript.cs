using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class WingScript : MonoBehaviour
{
    public Vector3 AxisDrag;
    public MainVehicleController VesselScript;
    public Transform thisTransform;
    public Rigidbody rBody;
    public bool UseEngine;
    public bool useStrafeCompliment;
    public bool unevenLift;
    public bool Broken;
    public virtual void Start()
    {
        this.rBody = this.GetComponent<Rigidbody>();
        this.thisTransform = this.transform;
        this.AxisDrag.x = this.AxisDrag.x * -0.017f;
        this.AxisDrag.y = this.AxisDrag.y * -0.017f;
        this.AxisDrag.z = this.AxisDrag.z * -0.017f;
    }

    public virtual void FixedUpdate()
    {
        if (this.UseEngine)
        {
            if (this.VesselScript.EngineRunning)
            {
                this.Broken = false;
            }
            else
            {
                this.Broken = true;
            }
        }
        if (this.useStrafeCompliment)
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                if (Input.GetKey("a") || Input.GetKey("d"))
                {
                    return;
                }
            }
        }
        if (!this.Broken)
        {
            Vector3 localV = this.thisTransform.InverseTransformDirection(this.rBody.velocity);
            float x = localV.x * this.AxisDrag.x;
            float y = localV.y * this.AxisDrag.y;
            float z = localV.z * this.AxisDrag.z;
            if (this.unevenLift)
            {
                this.rBody.AddTorque(this.thisTransform.right * Random.Range(-localV.x * this.rBody.mass, localV.x * this.rBody.mass));
                this.rBody.AddTorque(this.thisTransform.up * Random.Range(-localV.y * this.rBody.mass, localV.y * this.rBody.mass));
                this.rBody.AddTorque(this.thisTransform.forward * Random.Range(-localV.z * this.rBody.mass, localV.z * this.rBody.mass));
            }
            this.rBody.AddRelativeForce(x, y, z);
        }
    }

    public virtual void OnJointBreak(float breakForce)
    {
        this.Broken = true;
    }

}