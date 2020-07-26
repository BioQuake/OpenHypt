using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class VelocityLightConfigurable : MonoBehaviour
{
    // speed at which audio clip plays at its original pitch:
    public Transform TargetVelocity;
    public float EmitSpeed;
    public float MaxLightionaise;
    public float MinLightionaise;
    public virtual void Update()
    {
        float p = this.TargetVelocity.GetComponent<Rigidbody>().velocity.magnitude / this.EmitSpeed;
        this.GetComponent<Light>().intensity = Mathf.Clamp(p, this.MinLightionaise, this.MaxLightionaise);
    }

    public VelocityLightConfigurable()
    {
        this.EmitSpeed = 60f;
        this.MaxLightionaise = 1;
    }

}