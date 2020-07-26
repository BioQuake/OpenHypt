using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AberrantHovererScript : MonoBehaviour
{
    public float HoverForce;
    public float HovDist;
    public AnimationCurve curve;
    public LayerMask targetLayers;
    public virtual void FixedUpdate()
    {
        RaycastHit hit = default(RaycastHit);
        if (Physics.Raycast(this.transform.position, Vector3.down, out hit, this.HovDist, (int) this.targetLayers))
        {
            this.HoverForce = this.curve.Evaluate(hit.distance);
            this.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.up * this.HoverForce, this.transform.position, ForceMode.Impulse);
        }
    }

    public AberrantHovererScript()
    {
        this.HoverForce = 1;
        this.HovDist = 1;
        this.curve = new AnimationCurve();
    }

}