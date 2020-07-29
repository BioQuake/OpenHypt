using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class RandomSoundPulse : MonoBehaviour
{
    public float MinRepetition;
    public float Chance;
    public virtual void PlayStuff()
    {
        int Interval = (int) Random.Range(0, this.Chance);
        switch (Interval)
        {
            case 1:
                this.GetComponent<AudioSource>().Play();
                break;
        }
    }

    public virtual void Start()
    {
        this.InvokeRepeating("PlayStuff", 4, Random.Range(this.MinRepetition, this.Chance));
    }

    public RandomSoundPulse()
    {
        this.MinRepetition = 0.2f;
        this.Chance = 2;
    }

}