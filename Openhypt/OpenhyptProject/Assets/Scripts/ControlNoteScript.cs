using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ControlNoteScript : MonoBehaviour
{
    public GameObject Page1;
    public GameObject Page2;
    public GameObject Page3;
    public GameObject Page4;
    public GameObject Page5;
    public GameObject Page6;
    public int Page;
    public Camera UIcam;
    public virtual void Pagionaise()
    {
        if (this.Page < 1)
        {
            this.Page = 1;
        }
        if (this.Page > 6)
        {
            this.Page = 6;
        }
        if (this.Page == 1)
        {
            this.Page6.SetActive(false);
            this.Page1.SetActive(true);
            this.Page2.SetActive(false);
        }
        if (this.Page == 2)
        {
            this.Page1.SetActive(false);
            this.Page2.SetActive(true);
            this.Page3.SetActive(false);
        }
        if (this.Page == 3)
        {
            this.Page2.SetActive(false);
            this.Page3.SetActive(true);
            this.Page4.SetActive(false);
        }
        if (this.Page == 4)
        {
            this.Page3.SetActive(false);
            this.Page4.SetActive(true);
            this.Page5.SetActive(false);
        }
        if (this.Page == 5)
        {
            this.Page4.SetActive(false);
            this.Page5.SetActive(true);
            this.Page6.SetActive(false);
        }
        if (this.Page == 6)
        {
            this.Page5.SetActive(false);
            this.Page6.SetActive(true);
            this.Page1.SetActive(false);
        }
    }

    public virtual void OnMouseDown()
    {
        if (Input.mousePosition.x > this.UIcam.WorldToScreenPoint(this.transform.position).x)
        {
            this.Page = this.Page + 1;
            this.Pagionaise();
        }
        else
        {
            this.Page = this.Page - 1;
            this.Pagionaise();
        }
    }

    public ControlNoteScript()
    {
        this.Page = 1;
    }

}