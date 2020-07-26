using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SoundObscure : MonoBehaviour
{
    public Transform target;
    public AudioSource Snoud;
    public bool isDouble;
    public Transform otherPoint;
    public bool Obscured;
    public GameObject DebugPop;
    public bool usesTandemSoundManipulator;
    public VelocityNoiseConfigurable2 VelNoiseConf;
    public LayerMask targetLayers;
    public float StaticVol;
    public float volIncr;
    public virtual void Start()
    {
        this.target = PlayerInformation.instance.PhysCam;
        //if(!Snoud){
        //var Load = Resources.Load("Objects/CornerStone", GameObject) as GameObject;
        //Instantiate(Load, transform.position, transform.rotation);
        //Debug.Log(gameObject.name + "HasSnoud");
        //Debug.Break();
        //}
        if (Physics.Linecast(this.transform.position, this.target.position, (int) this.targetLayers))
        {
            this.Snoud.volume = 0;
        }
        if (this.GetComponent<AudioSource>())
        {
            this.Snoud = this.GetComponent<AudioSource>();
            if (this.StaticVol < 0.1f)
            {
                this.StaticVol = this.Snoud.volume;
            }
        }
        else
        {
            if (this.Snoud)
            {
                if (this.StaticVol < 0.1f)
                {
                    this.StaticVol = this.Snoud.volume;
                }
            }
            else
            {
                if (this.StaticVol < 0.1f)
                {
                    this.StaticVol = this.GetComponent<AudioSource>().volume;
                }
            }
        }
    }

    public virtual void FixedUpdate()
    {
        if (this.Snoud)
        {
            if (!this.isDouble)
            {
                if (Physics.Linecast(this.transform.position, this.target.position, (int) this.targetLayers))
                {
                    this.Obscured = true;
                }
                else
                {
                    this.Obscured = false;
                }
            }
            else
            {
                if (Physics.Linecast(this.transform.position, this.target.position, (int) this.targetLayers) && Physics.Linecast(this.otherPoint.position, this.target.position, (int) this.targetLayers))
                {
                    this.Obscured = true;
                }
                else
                {
                    this.Obscured = false;
                }
            }
            if (!this.usesTandemSoundManipulator)
            {
                if (!this.Obscured)
                {
                    if (this.Snoud.volume < this.StaticVol)
                    {
                        this.Snoud.volume = this.Snoud.volume + this.volIncr;
                    }
                }
            }
            else
            {
                if (!this.Obscured)
                {
                    if (this.Snoud.volume < this.VelNoiseConf.VolumeAmount)
                    {
                        this.Snoud.volume = this.Snoud.volume + this.volIncr;
                    }
                }
            }
            if (this.Obscured)
            {
                this.Snoud.volume = this.Snoud.volume - this.volIncr;
            }
        }
        else
        {
            UnityEngine.Object.Destroy(this);
        }
    }

    public SoundObscure()
    {
        this.StaticVol = 0.5f;
        this.volIncr = 0.02f;
    }

}