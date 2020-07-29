using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class UnchildInstantly : MonoBehaviour
{
    public bool ChangeTrig;
    public bool Delayed;
    public bool UnchildUp;
    public float TrigRad;
    public SphereCollider Trig;
    public CapsuleCollider CTrig;
    public virtual IEnumerator Start()
    {
        if (!this.Delayed && !this.UnchildUp)
        {
            this.transform.parent = null;
        }
        if (this.UnchildUp)
        {
            this.transform.parent = this.transform.parent.parent;
        }
        yield return new WaitForSeconds(0.25f);
        if (this.ChangeTrig)
        {
            if (this.Trig)
            {
                this.Trig.radius = this.TrigRad;
            }
            if (this.CTrig)
            {
                this.CTrig.radius = this.TrigRad;
            }
        }
        yield return new WaitForSeconds(0.25f);
        if (this.Delayed)
        {
            this.transform.parent = null;
        }
    }

    public UnchildInstantly()
    {
        this.TrigRad = 20;
    }

}