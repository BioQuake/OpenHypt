using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AmbVolumeController : MonoBehaviour
{
    public float Amb1Vol;
    public float Amb2Vol;
    public bool IsAmb1;
    public bool IsAmb2;
    public virtual void Start()
    {
    }

    public virtual void FixedUpdate()
    {
        if (this.IsAmb1)
        {
            if (this.GetComponent<AudioSource>().volume > this.Amb1Vol)
            {
                this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume - 0.002f;
            }
            if (this.GetComponent<AudioSource>().volume < this.Amb1Vol)
            {
                this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume + 0.002f;
            }
        }
        if (this.IsAmb2)
        {
            if (this.GetComponent<AudioSource>().volume > this.Amb2Vol)
            {
                this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume - 0.002f;
            }
            if (this.GetComponent<AudioSource>().volume < this.Amb2Vol)
            {
                this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume + 0.002f;
            }
        }
    }

    public AmbVolumeController()
    {
        this.Amb1Vol = 1;
    }

}