using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class NoClip : MonoBehaviour
{
    public bool NoClipping;
    public bool DoIt;
    public Transform target;
    public LayerMask targetLayers;
    public virtual void Start()
    {
        if (this.NoClipping)
        {
            this.target = PlayerInformation.instance.Pirizuka;
            this.InvokeRepeating("Tick", 0.05f, 0.5f);
        }
    }

    public virtual void FixedUpdate()
    {
        RaycastHit hit = default(RaycastHit);
        if (!this.DoIt)
        {
            return;
        }
        Vector3 dirRot = this.GetComponent<Rigidbody>().velocity;
        float RBV = (this.GetComponent<Rigidbody>().velocity.magnitude * 1.2f) * Time.deltaTime;
        Debug.DrawRay(this.transform.position, this.transform.right * RBV, Color.green);
        if (Physics.Raycast(this.transform.position, dirRot, out hit, RBV, (int) this.targetLayers))
        {
            this.GetComponent<Rigidbody>().velocity = (dirRot * RBV) * -1;
            if (hit.rigidbody)
            {
                this.GetComponent<Rigidbody>().velocity = hit.rigidbody.velocity;
            }
        }
    }

    public virtual void Tick()
    {
        if (Vector3.Distance(this.transform.position, this.target.position) < 300)
        {
            this.DoIt = true;
        }
        else
        {
            this.DoIt = false;
        }
    }

}