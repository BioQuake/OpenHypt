using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SpeakerScript : MonoBehaviour
{
    public AudioSource AudioComponent;
    public AudioClip IdleMusic1;
    public AudioClip IdleMusic2;
    public AudioClip BellIn;
    public bool BelledIn;
    public AudioClip BellOut;
    public bool BelledOut;
    public bool IsAnnouncing;
    public AudioClip Announcement1;
    public int Announcement1Time;
    public AudioClip Announcement2;
    public int Announcement2Time;
    public AudioClip Announcement3;
    public int Announcement3Time;
    public bool FadingIn;
    public bool FadingOut;
    public virtual IEnumerator Start()
    {
        this.InvokeRepeating("Ticker", 1, 1);
        this.Announcement1Time = this.Announcement1Time - Random.Range(-10, 10);
        this.Announcement2Time = this.Announcement2Time - Random.Range(-10, 10);
        this.Announcement3Time = this.Announcement3Time - Random.Range(-10, 10);
        yield return new WaitForSeconds(0.3f);
        this.AudioComponent.clip = this.IdleMusic1;
        this.AudioComponent.Play();
    }

    public virtual void FixedUpdate()
    {
        if (!this.FadingOut)
        {
            if (this.AudioComponent.volume < 1)
            {
                this.AudioComponent.volume = this.AudioComponent.volume + 0.05f;
            }
        }
        if (this.Announcement1Time == 1)
        {
            if (!this.BelledIn)
            {
                this.FadingOut = true;
                this.AudioComponent.volume = this.AudioComponent.volume - 0.05f;
                if (this.AudioComponent.volume == 0)
                {
                    this.AudioComponent.loop = false;
                    this.AudioComponent.volume = 1;
                    this.AudioComponent.clip = this.BellIn;
                    this.AudioComponent.Play();
                    this.BelledIn = true;
                }
            }
            if (this.BelledIn && !this.IsAnnouncing)
            {
                if (!this.AudioComponent.isPlaying)
                {
                    this.AudioComponent.clip = this.Announcement1;
                    this.AudioComponent.Play();
                    this.IsAnnouncing = true;
                }
            }
            if (this.IsAnnouncing && !this.BelledOut)
            {
                if (!this.AudioComponent.isPlaying)
                {
                    this.AudioComponent.clip = this.BellOut;
                    this.AudioComponent.Play();
                    this.BelledOut = true;
                }
            }
            if (this.BelledOut)
            {
                if (!this.AudioComponent.isPlaying)
                {
                    this.AudioComponent.clip = this.IdleMusic1;
                    this.AudioComponent.Play();
                    this.AudioComponent.loop = true;
                    this.AudioComponent.volume = 0;
                    this.Announcement1Time = 0;
                    this.IsAnnouncing = false;
                    this.BelledIn = false;
                    this.BelledOut = false;
                    this.FadingOut = false;
                }
            }
        }
        if (this.Announcement2Time == 1)
        {
            if (!this.BelledIn)
            {
                this.FadingOut = true;
                this.AudioComponent.volume = this.AudioComponent.volume - 0.05f;
                if (this.AudioComponent.volume == 0)
                {
                    this.AudioComponent.loop = false;
                    this.AudioComponent.volume = 1;
                    this.AudioComponent.clip = this.BellIn;
                    this.AudioComponent.Play();
                    this.BelledIn = true;
                }
            }
            if (this.BelledIn && !this.IsAnnouncing)
            {
                if (!this.AudioComponent.isPlaying)
                {
                    this.AudioComponent.clip = this.Announcement2;
                    this.AudioComponent.Play();
                    this.IsAnnouncing = true;
                }
            }
            if (this.IsAnnouncing && !this.BelledOut)
            {
                if (!this.AudioComponent.isPlaying)
                {
                    this.AudioComponent.clip = this.BellOut;
                    this.AudioComponent.Play();
                    this.BelledOut = true;
                }
            }
            if (this.BelledOut)
            {
                if (!this.AudioComponent.isPlaying)
                {
                    this.AudioComponent.clip = this.IdleMusic1;
                    this.AudioComponent.Play();
                    this.AudioComponent.loop = true;
                    this.AudioComponent.volume = 0;
                    this.Announcement2Time = 0;
                    this.IsAnnouncing = false;
                    this.BelledIn = false;
                    this.BelledOut = false;
                    this.FadingOut = false;
                }
            }
        }
        if (this.Announcement3Time == 1)
        {
            if (!this.BelledIn)
            {
                this.FadingOut = true;
                this.AudioComponent.volume = this.AudioComponent.volume - 0.05f;
                if (this.AudioComponent.volume == 0)
                {
                    this.AudioComponent.loop = false;
                    this.AudioComponent.volume = 1;
                    this.AudioComponent.clip = this.BellIn;
                    this.AudioComponent.Play();
                    this.BelledIn = true;
                }
            }
            if (this.BelledIn && !this.IsAnnouncing)
            {
                if (!this.AudioComponent.isPlaying)
                {
                    this.AudioComponent.clip = this.Announcement3;
                    this.AudioComponent.Play();
                    this.IsAnnouncing = true;
                }
            }
            if (this.IsAnnouncing && !this.BelledOut)
            {
                if (!this.AudioComponent.isPlaying)
                {
                    this.AudioComponent.clip = this.BellOut;
                    this.AudioComponent.Play();
                    this.BelledOut = true;
                }
            }
            if (this.BelledOut)
            {
                if (!this.AudioComponent.isPlaying)
                {
                    this.AudioComponent.clip = this.IdleMusic1;
                    this.AudioComponent.Play();
                    this.AudioComponent.loop = true;
                    this.AudioComponent.volume = 0;
                    this.Announcement3Time = 0;
                    this.IsAnnouncing = false;
                    this.BelledIn = false;
                    this.BelledOut = false;
                    this.FadingOut = false;
                }
            }
        }
    }

    public virtual void Ticker()
    {
        if (this.Announcement1Time > 1)
        {
            this.Announcement1Time = this.Announcement1Time - 1;
        }
        if (this.Announcement2Time > 1)
        {
            this.Announcement2Time = this.Announcement2Time - 1;
        }
        if (this.Announcement3Time > 1)
        {
            this.Announcement3Time = this.Announcement3Time - 1;
        }
    }

    public SpeakerScript()
    {
        this.Announcement1Time = 10;
        this.Announcement2Time = 60;
        this.Announcement3Time = 90;
    }

}