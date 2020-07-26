using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class VelocityParticleEffects : MonoBehaviour
{
    public GameObject Vehicle;
    public float MagnitudeValue;
    public AnimationCurve curve;
    public float VolumeAmount;
    public float VolumeMod;
    public virtual void Update()
    {
        if ((this.Vehicle.GetComponent<Rigidbody>().velocity.magnitude > 0.1f) /*&& (PlayerInformation.playerCar.Contains(this.Vehicle.name) != null)*/)
        {
            float p = this.Vehicle.GetComponent<Rigidbody>().velocity.magnitude / this.MagnitudeValue;
            this.GetComponent<ParticleSystem>().emissionRate = this.VolumeAmount;
            this.VolumeAmount = this.curve.Evaluate(p) * this.VolumeMod;
        }
    }

    public VelocityParticleEffects()
    {
        this.MagnitudeValue = 30;
        this.curve = new AnimationCurve();
        this.VolumeMod = 1f;
    }

}