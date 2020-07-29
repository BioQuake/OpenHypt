using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class TutorialScript : MonoBehaviour
{
    public string ShowUpAnimationName;
    public string HideAnimationName;
    public GameObject Arrow;
    public Transform ArrowPoint0;
    public Transform ArrowPoint1;
    public Transform ArrowPoint2;
    public Transform ArrowPoint3;
    public Transform ArrowPoint4;
    public Transform ArrowPoint5;
    private bool entered;
    public bool Once;
    public GameObject Page1;
    public GameObject Page2;
    public GameObject Page3;
    public GameObject Page4;
    public GameObject Page5;
    public GameObject Page6;
    public GameObject Page7;
    public GameObject Page8;
    public GameObject Page9;
    public GameObject Page10;
    public GameObject Page11;
    public GameObject Page12;
    public GameObject Page13;
    public GameObject Page14;
    public GameObject Page15;
    public int Page;
    public virtual void Update()
    {
        if (this.entered == true)
        {
            if (Input.GetMouseButtonDown(0) && (this.Once == false))
            {
                this.Page = this.Page + 1;
            }
            if (Input.GetMouseButtonDown(1) && (this.Once == false))
            {
                this.Page = this.Page - 1;
            }
        }
        if (this.Page < 1)
        {
            this.Page = 1;
        }
        if (this.Page == 1)
        {
            this.Page15.SetActive(false);
            this.Page1.SetActive(true);
            this.Page2.SetActive(false);
        }
        if (this.Page == 2)
        {
            this.Page1.SetActive(false);
            this.Page2.SetActive(true);
            this.Page3.SetActive(false);
            this.Arrow.GetComponent<Doppelganger2>().target = this.ArrowPoint0;
        }
        if (this.Page == 3)
        {
            this.Page2.SetActive(false);
            this.Page3.SetActive(true);
            this.Page4.SetActive(false);
            this.Arrow.GetComponent<Doppelganger2>().target = this.ArrowPoint1;
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
            this.Page7.SetActive(false);
        }
        if (this.Page == 7)
        {
            this.Page6.SetActive(false);
            this.Page7.SetActive(true);
            this.Page8.SetActive(false);
        }
        if (this.Page == 8)
        {
            this.Page7.SetActive(false);
            this.Page8.SetActive(true);
            this.Page9.SetActive(false);
            this.Arrow.GetComponent<Doppelganger2>().target = this.ArrowPoint1;
        }
        if (this.Page == 9)
        {
            this.Page8.SetActive(false);
            this.Page9.SetActive(true);
            this.Page10.SetActive(false);
            this.Arrow.GetComponent<Doppelganger2>().target = this.ArrowPoint0;
        }
        if (this.Page == 10)
        {
            this.Page9.SetActive(false);
            this.Page10.SetActive(true);
            this.Page11.SetActive(false);
            this.Arrow.GetComponent<Doppelganger2>().target = this.ArrowPoint2;
        }
        if (this.Page == 11)
        {
            this.Page10.SetActive(false);
            this.Page11.SetActive(true);
            this.Page12.SetActive(false);
            this.Arrow.GetComponent<Doppelganger2>().target = this.ArrowPoint2;
        }
        if (this.Page == 12)
        {
            this.Page11.SetActive(false);
            this.Page12.SetActive(true);
            this.Page13.SetActive(false);
            this.Arrow.GetComponent<Doppelganger2>().target = this.ArrowPoint3;
        }
        if (this.Page == 13)
        {
            this.Page12.SetActive(false);
            this.Page13.SetActive(true);
            this.Page14.SetActive(false);
            this.Arrow.GetComponent<Doppelganger2>().target = this.ArrowPoint4;
        }
        if (this.Page == 14)
        {
            this.Page13.SetActive(false);
            this.Page14.SetActive(true);
            this.Page15.SetActive(false);
            this.Arrow.GetComponent<Doppelganger2>().target = this.ArrowPoint5;
        }
        if (this.Page == 15)
        {
            this.Page14.SetActive(false);
            this.Page15.SetActive(true);
            this.Arrow.GetComponent<Doppelganger2>().target = this.ArrowPoint0;
        }
        if ((this.Page == 16) && (this.Once == false))
        {
            this.Once = true;
            this.GetComponent<Animation>().Play(this.HideAnimationName + "");
        }
    }

    public virtual void OnMouseEnter()
    {
        this.entered = true;
    }

    public virtual void OnMouseExit()
    {
        this.entered = false;
    }

    public TutorialScript()
    {
        this.ShowUpAnimationName = "Name";
        this.HideAnimationName = "Name";
        this.Page = 1;
    }

}