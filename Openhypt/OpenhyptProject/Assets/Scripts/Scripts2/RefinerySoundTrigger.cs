using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class RefinerySoundTrigger : MonoBehaviour
{
    public virtual void SoundDump()
    {
        RefineryAniSound.IsDumping = true;
    }

    public virtual void SoundRefine()
    {
        RefineryAniSound.IsRefining = true;
    }

    public virtual void SoundDispense()
    {
        RefineryAniSound.IsDispensing = true;
    }

}