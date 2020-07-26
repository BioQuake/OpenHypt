using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class StartSoundScript : MonoBehaviour
{
    public bool FadeOut;
    public bool StartScene;
    public float EndVolume;
    public float VolumeInSpeed;
    public float VolumeOutSpeed;
    public virtual IEnumerator Start()
    {
        if (!this.StartScene)
        {
            if (WorldInformation.MusicOff)
            {
                this.GetComponent<AudioSource>().volume = 0;
                this.FadeOut = true;
            }
        }
        else
        {
            AudioListener.volume = 1;
            yield return new WaitForSeconds(1);
            this.GetComponent<AudioSource>().Play();
        }
    }

    public virtual void Update()
    {
        if (Input.GetKey(KeyCode.E) && this.StartScene)
        {
            this.FadeOut = true;
        }
    }

    public virtual void FixedUpdate()
    {
        if (!this.FadeOut && (this.GetComponent<AudioSource>().volume < this.EndVolume))
        {
            this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume + this.VolumeInSpeed;
        }
        if (this.FadeOut && (this.GetComponent<AudioSource>().volume > 0))
        {
            this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume - this.VolumeOutSpeed;
        }
    }

    public StartSoundScript()
    {
        this.EndVolume = 0.5f;
        this.VolumeInSpeed = 0.002f;
        this.VolumeOutSpeed = 0.002f;
    }

}