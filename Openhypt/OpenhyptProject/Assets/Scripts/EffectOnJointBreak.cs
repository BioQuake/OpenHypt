using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class EffectOnJointBreak : MonoBehaviour
{
    public GameObject effect;
    public bool CanBreakVessel;
    public VehicleDamage ParentDamage;
    public bool Persist;
    public virtual void OnJointBreak(float breakForce)
    {
        this.transform.parent = null;
        if (this.CanBreakVessel)
        {
            this.ParentDamage.DamageIn(2048, 0, 0, false);
        }
        UnityEngine.Object.Instantiate(this.effect, this.transform.position, this.transform.rotation);
        if (!this.Persist)
        {
            UnityEngine.Object.Destroy(this.gameObject);
        }
    }

}