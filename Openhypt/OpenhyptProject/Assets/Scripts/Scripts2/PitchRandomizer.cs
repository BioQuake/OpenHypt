using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PitchRandomizer : MonoBehaviour
{
    public float MaxPitch;
    public virtual void Start()
    {
        this.GetComponent<AudioSource>().pitch = this.GetComponent<AudioSource>().pitch = this.GetComponent<AudioSource>().pitch + Random.Range(0, this.MaxPitch);
    }

    public PitchRandomizer()
    {
        this.MaxPitch = 0.05f;
    }

}