using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AngleGetter : MonoBehaviour
{
    public PiripodAI AI;
    public LayerMask targetLayers;
    public Vector3 Point1u;
    public Vector3 Point1d;
    public virtual void Reader()
    {
        RaycastHit hit1 = default(RaycastHit);
        RaycastHit hit2 = default(RaycastHit);
        this.transform.LookAt(this.AI.target);
        Debug.DrawRay(this.transform.position + (this.transform.up * 0.5f), this.transform.forward * 50f, Color.white);
        if (Physics.Raycast(this.transform.position + (this.transform.up * 0.5f), this.transform.forward, out hit1, 50, (int) this.targetLayers))
        {
            this.Point1u = hit1.point;
        }
        Debug.DrawRay(this.transform.position + (-this.transform.up * 0.5f), this.transform.forward * 50f, Color.white);
        if (Physics.Raycast(this.transform.position + (-this.transform.up * 0.5f), this.transform.forward, out hit2, 50, (int) this.targetLayers))
        {
            this.Point1d = hit2.point;
        }
        Debug.DrawRay(this.transform.position, Vector3.down * 48, Color.white);
        if (!Physics.Raycast(this.transform.position, Vector3.down, 48, (int) this.targetLayers))
        {
            this.AI.OverPit = 1;
        }
        if (Vector3.Distance(this.Point1u, this.Point1d) > 2)
        {
            this.AI.JustNoticed = 1;
        }
    }

    public virtual void Start()
    {
        this.InvokeRepeating("Reader", 1, 0.15f);
    }

}