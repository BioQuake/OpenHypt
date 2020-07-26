using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class FinScript : MonoBehaviour
{
    public Vector3 AxisDrag;
    public bool Broken;
    public float Frictiondistance;
    public bool Friction;
    public LayerMask targetLayers;
    public virtual void FixedUpdate()
    {
        if (this.Broken == false)
        {
            Vector3 localV = this.transform.InverseTransformDirection(this.GetComponent<Rigidbody>().velocity);
            float x = ((localV.x * this.AxisDrag.x) * -1) * Time.deltaTime;
            float y = ((localV.y * this.AxisDrag.y) * -1) * Time.deltaTime;
            float z = ((localV.z * this.AxisDrag.z) * -1) * Time.deltaTime;
            if (Physics.Raycast(this.transform.position, -this.transform.up, this.Frictiondistance, (int) this.targetLayers))
            {
                this.GetComponent<Rigidbody>().AddRelativeForce(x, y, z);
                this.Friction = true;
            }
            else
            {
                this.Friction = false;
            }
        }
    }

    public virtual void OnJointBreak(float breakForce)
    {
        this.Broken = true;
    }

    public FinScript()
    {
        this.Frictiondistance = 0.5f;
    }

}