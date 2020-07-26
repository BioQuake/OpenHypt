using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class Simplehover : MonoBehaviour
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
    }

    public Simplehover()
    {
        this.HoverDistance = 5f;
    }

}