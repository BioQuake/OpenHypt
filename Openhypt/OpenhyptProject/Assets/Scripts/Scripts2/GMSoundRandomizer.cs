using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class GMSoundRandomizer : MonoBehaviour
{
    public AudioClip[] soundsies;
    public float Lengthrandomizer;
    public bool Switchoff;
    public virtual void Start()
    {
        this.InvokeRepeating("PlayClipAndChange", 1f, this.Lengthrandomizer);
    }

    public virtual void PlayClipAndChange()
    {
        if (this.Switchoff == false)
        {
            this.GetComponent<AudioSource>().clip = this.soundsies[Random.Range(0, this.soundsies.Length)];
            this.GetComponent<AudioSource>().Play();
        }
    }

    public virtual void Update()
    {
        if (this.Switchoff == false)
        {
            this.Lengthrandomizer = 1f + (5f * Random.value);
            this.ActivateDestabilize();
        }
    }

    public virtual void ActivateDestabilize()
    {
        //if (null)
        //{
        //    this.Switchoff = true;
        //    this.GetComponent<AudioSource>().Stop();
        //}
    }

    public GMSoundRandomizer()
    {
        this.Lengthrandomizer = 6f;
    }

}