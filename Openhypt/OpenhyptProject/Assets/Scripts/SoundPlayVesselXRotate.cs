using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SoundPlayVesselXRotate : MonoBehaviour
{
    public AudioClip audioC;
    public virtual void Update()
    {
        if (WorldInformation.playerCar.Contains(this.transform.parent.name))
        {
            if (Input.GetKeyDown("x"))
            {
                this.GetComponent<AudioSource>().PlayOneShot(this.audioC);
            }
        }
    }

}