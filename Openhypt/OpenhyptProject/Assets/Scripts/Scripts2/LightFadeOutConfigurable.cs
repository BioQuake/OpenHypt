using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class LightFadeOutConfigurable : MonoBehaviour
{
    public float Step;
    public virtual void Start()
    {
    }

    public virtual void FixedUpdate()
    {
        this.GetComponent<Light>().intensity = this.GetComponent<Light>().intensity - this.Step;
    }

    public LightFadeOutConfigurable()
    {
        this.Step = 0.01f;
    }

}