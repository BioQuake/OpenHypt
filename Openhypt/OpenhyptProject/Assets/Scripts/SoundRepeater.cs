using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SoundRepeater : MonoBehaviour
{
    public AudioClip Sound1;
    public float Reptime;
    public virtual void PlayStuff()
    {
        this.GetComponent<AudioSource>().PlayOneShot(this.Sound1);
    }

    public virtual void Start()
    {
        this.InvokeRepeating("PlayStuff", 2, this.Reptime);
    }

    public SoundRepeater()
    {
        this.Reptime = 2f;
    }

}