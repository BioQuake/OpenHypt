using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class VelocityNoise : MonoBehaviour
{
    public GameObject Vessel;
    public float audioClipSpeed;
    public virtual void Update()
    {
        float p = this.Vessel.GetComponent<Rigidbody>().velocity.magnitude / this.audioClipSpeed;
        this.GetComponent<AudioSource>().pitch = Mathf.Clamp(p, 0f, 5f);
    }

    public VelocityNoise()
    {
        this.audioClipSpeed = 60f;
    }

}