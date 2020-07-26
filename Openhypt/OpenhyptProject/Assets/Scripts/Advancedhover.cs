using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class Advancedhover : MonoBehaviour
{
    public LayerMask targetLayers;
    public float Multiplier;
    public float HoverDistance;
    public virtual void FixedUpdate()
    {
        Vector3 fwd = this.transform.TransformDirection(Vector3.down);
        if (Physics.Raycast(this.transform.position, fwd, this.HoverDistance, (int) this.targetLayers))
        {
            this.GetComponent<Rigidbody>().AddForce(Vector3.up * this.Multiplier, ForceMode.Impulse);
        }
        if (Physics.Raycast(this.transform.position, fwd, this.HoverDistance - 0.1f, (int) this.targetLayers))
        {
            this.GetComponent<Rigidbody>().AddForce((Vector3.up * this.Multiplier) * 1, ForceMode.Impulse);
        }
        if (Physics.Raycast(this.transform.position, fwd, this.HoverDistance - 0.2f, (int) this.targetLayers))
        {
            this.GetComponent<Rigidbody>().AddForce((Vector3.up * this.Multiplier) * 2, ForceMode.Impulse);
        }
        if (Physics.Raycast(this.transform.position, fwd, this.HoverDistance - 0.3f, (int) this.targetLayers))
        {
            this.GetComponent<Rigidbody>().AddForce((Vector3.up * this.Multiplier) * 3, ForceMode.Impulse);
        }
    }

    public Advancedhover()
    {
        this.HoverDistance = 5f;
    }

}