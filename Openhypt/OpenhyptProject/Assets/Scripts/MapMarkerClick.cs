using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MapMarkerClick : MonoBehaviour
{
    public AudioClip Click;
    public AudioClip Unclick;
    public int ViewDistance;
    public int ZoomDistance;
    public GameObject MapCam;
    public GameObject ZoomCam;
    public string NameOfArea;
    public GameObject MarkerSelected;
    public GameObject InfoSelected;
    public GameObject VisiterSelected;
    public bool HasMarker;
    public bool Entered;
    public bool isActive;
    public virtual void Start()
    {
        this.Entered = false;
    }

    public virtual void Update()
    {
        if (this.Entered && !this.isActive)
        {
            this.isActive = true;
            if (this.HasMarker)
            {
                this.GetComponent<AudioSource>().clip = this.Click;
                this.GetComponent<AudioSource>().Play();
                this.MarkerSelected.SetActive(true);
                this.VisiterSelected.SetActive(true);
                this.InfoSelected.SetActive(true);
                WorldInformation.Unset = false;
            }
            else
            {
                WorldInformation.Unset = true;
            }
        }
        if ((WorldInformation.Unset && this.HasMarker) && this.isActive)
        {
            this.isActive = false;
            this.Entered = false;
            this.GetComponent<AudioSource>().clip = this.Unclick;
            this.GetComponent<AudioSource>().Play();
            this.MarkerSelected.SetActive(false);
            this.VisiterSelected.SetActive(false);
            this.InfoSelected.SetActive(false);
        }
        if ((!WorldInformation.Unset && !this.HasMarker) && this.isActive)
        {
            this.isActive = false;
            this.Entered = false;
        }
    }

    public MapMarkerClick()
    {
        this.ViewDistance = 10;
        this.ZoomDistance = 670;
    }

}