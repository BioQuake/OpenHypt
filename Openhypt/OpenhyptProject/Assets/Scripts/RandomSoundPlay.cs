using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class RandomSoundPlay : MonoBehaviour
{
    public AudioClip audioC1;
    public AudioClip audioC2;
    public AudioClip audioC3;
    public int NumRange;
    public virtual void Start()
    {
        int randomValue = Random.Range(1, this.NumRange);
        switch (randomValue)
        {
            case 1:
                this.GetComponent<AudioSource>().PlayOneShot(this.audioC1);
                break;
            case 2:
                this.GetComponent<AudioSource>().PlayOneShot(this.audioC2);
                break;
            case 3:
                this.GetComponent<AudioSource>().PlayOneShot(this.audioC3);
                break;
        }
    }

    public RandomSoundPlay()
    {
        this.NumRange = 4;
    }

}