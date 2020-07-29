using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SoundRepeaterRandomized : MonoBehaviour
{
    public AudioClip Sound1;
    public float MinReptime;
    public float MaxReptime;
    public virtual void PlayStuff()
    {
        this.GetComponent<AudioSource>().PlayOneShot(this.Sound1);
    }

    public virtual void Start()
    {
        this.InvokeRepeating("PlayStuff", 1, Random.Range(this.MinReptime, this.MaxReptime));
    }

    public SoundRepeaterRandomized()
    {
        this.MinReptime = 3f;
        this.MaxReptime = 6f;
    }

}