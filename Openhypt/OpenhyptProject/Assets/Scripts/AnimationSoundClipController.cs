using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AnimationSoundClipController : MonoBehaviour
{
    public AudioClip Sound1;
    public AudioClip Sound2;
    public AudioClip Sound3;
    public virtual void PlayS1()
    {
        this.GetComponent<AudioSource>().clip = this.Sound1;
        this.GetComponent<AudioSource>().Play();
    }

    public virtual void PlayS2()
    {
        this.GetComponent<AudioSource>().clip = this.Sound2;
        this.GetComponent<AudioSource>().Play();
    }

    public virtual void PlayS3()
    {
        this.GetComponent<AudioSource>().clip = this.Sound3;
        this.GetComponent<AudioSource>().Play();
    }

}