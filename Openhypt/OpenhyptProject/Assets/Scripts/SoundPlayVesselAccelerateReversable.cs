using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SoundPlayVesselAccelerateReversable : MonoBehaviour
{
    public AudioClip audioC;
    public bool WithCruise;
    public virtual void Update()
    {
        if (WorldInformation.playerCar.Contains(this.transform.parent.name))
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
            {
                this.GetComponent<AudioSource>().PlayOneShot(this.audioC);
            }
            if (Input.GetKeyDown("q") && this.WithCruise)
            {
                this.GetComponent<AudioSource>().PlayOneShot(this.audioC);
            }
        }
    }

}