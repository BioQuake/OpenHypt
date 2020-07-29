using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SoundRandomizer : MonoBehaviour
{
    public AudioClip[] soundsies;
    public float Lengthrandomizer;
    public float MinDelay;
    public float MaxDelay;
    public float lastTime;
    public virtual void Start()
    {
        this.lastTime = Time.time + 2;
    }

    public virtual void PlayClipAndChange()
    {
        this.GetComponent<AudioSource>().clip = this.soundsies[Random.Range(0, this.soundsies.Length)];
        this.GetComponent<AudioSource>().Play();
    }

    public virtual void Update()
    {
        if ((Time.time - this.lastTime) > this.Lengthrandomizer)
        {
            this.Lengthrandomizer = this.MinDelay + (Random.value * (this.MaxDelay - this.MinDelay));
            this.PlayClipAndChange();
            this.lastTime = Time.time;
        }
    }

    public SoundRandomizer()
    {
        this.Lengthrandomizer = 6f;
        this.MinDelay = 6f;
        this.MaxDelay = 12f;
    }

}