using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AnimationSoundController : MonoBehaviour
{
    public GameObject Sound1;
    public GameObject Sound2;
    public GameObject Sound3;
    public virtual void PlayS1()
    {
        this.Sound1.GetComponent<AudioSource>().Play();
    }

    public virtual void PlayS2()
    {
        this.Sound2.GetComponent<AudioSource>().Play();
    }

    public virtual void PlayS3()
    {
        this.Sound3.GetComponent<AudioSource>().Play();
    }

}