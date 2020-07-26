using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class RefineryAniSound : MonoBehaviour
{
    public AudioClip Dump;
    public AudioClip Refine;
    public AudioClip Dispense;
    public static bool IsDumping;
    public static bool IsRefining;
    public static bool IsDispensing;
    public virtual void Update()
    {
        if (RefineryAniSound.IsDumping == true)
        {
            this.SoundDump();
            RefineryAniSound.IsDumping = false;
        }
        if (RefineryAniSound.IsRefining == true)
        {
            this.SoundRefine();
            RefineryAniSound.IsRefining = false;
        }
        if (RefineryAniSound.IsDispensing == true)
        {
            this.SoundDispense();
            RefineryAniSound.IsDispensing = false;
        }
    }

    public virtual void SoundDump()
    {
        this.GetComponent<AudioSource>().PlayOneShot(this.Dump);
    }

    public virtual void SoundRefine()
    {
        this.GetComponent<AudioSource>().PlayOneShot(this.Refine);
    }

    public virtual void SoundDispense()
    {
        this.GetComponent<AudioSource>().PlayOneShot(this.Dispense);
    }

}