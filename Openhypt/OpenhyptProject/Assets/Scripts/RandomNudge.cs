using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class RandomNudge : MonoBehaviour
{
    public float Multiplier;
    public float Lengthrandomizer;
    public bool BandF;
    public bool Forth;
    public float MinDelay;
    public float MaxDelay;
    public virtual void PlayClipAndChange()
    {
        this.GetComponent<Rigidbody>().AddForce(this.transform.up * this.Multiplier, ForceMode.Impulse);
    }

    public float lastTime;
    public virtual void Update()
    {
        if ((Time.time - this.lastTime) > this.Lengthrandomizer)
        {
            this.Lengthrandomizer = this.MinDelay + (Random.value * (this.MaxDelay - this.MinDelay));
            this.PlayClipAndChange();
            this.lastTime = Time.time;
        }
    }

    public RandomNudge()
    {
        this.Lengthrandomizer = 6f;
        this.MinDelay = 6f;
        this.MaxDelay = 12f;
    }

}