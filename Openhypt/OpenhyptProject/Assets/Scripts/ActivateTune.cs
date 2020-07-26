using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ActivateTune : MonoBehaviour
{
    public float maxVolume;
    public bool CanClick;
    public bool IsOn;
    public virtual void FixedUpdate()
    {
        if (WorldInformation.playerCar != this.transform.parent.name)
        {
            return;
        }
        if ((Input.GetKeyDown("r") && !this.IsOn) && this.CanClick)
        {
            this.GetComponent<AudioSource>().volume = 0;
            this.GetComponent<AudioSource>().Play();
            this.CanClick = false;
            this.IsOn = true;
            this.gameObject.name = "AkbarLeader";
            this.StartCoroutine(this.Clicky());
        }
        else
        {
            if ((Input.GetKeyDown("r") && this.IsOn) && this.CanClick)
            {
                this.CanClick = false;
                this.IsOn = false;
                this.gameObject.name = "AkbarVessel";
                this.StartCoroutine(this.Clicky());
            }
        }
        if ((this.GetComponent<AudioSource>().volume > 0) && !this.IsOn)
        {
            this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume - 0.05f;
        }
        if ((this.GetComponent<AudioSource>().volume < this.maxVolume) && this.IsOn)
        {
            this.GetComponent<AudioSource>().volume = this.GetComponent<AudioSource>().volume + 0.05f;
        }
    }

    public virtual IEnumerator Clicky()
    {
        yield return new WaitForSeconds(1);
        this.CanClick = true;
    }

    public ActivateTune()
    {
        this.maxVolume = 1;
        this.CanClick = true;
    }

}