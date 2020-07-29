using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class VesselList_Scroller : MonoBehaviour
{
    public VesselList_Scroll scrollUp;
    public VesselList_Scroll scrollDown;
    public Transform thisTransform;
    public BoxCollider thisCol;
    public bool isActive;
    public bool isScrollingUp;
    public virtual void Start()
    {
    }

    public virtual void Update()
    {
        if (this.isActive)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                this.isScrollingUp = true;
                this.thisCol.enabled = true;
                this.StartCoroutine(this.DisableCol());
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                this.isScrollingUp = false;
                this.thisCol.enabled = true;
                this.StartCoroutine(this.DisableCol());
            }
        }
    }

    public virtual void OnMouseOver()
    {
        if (this.isScrollingUp)
        {
            this.scrollUp.Scroll();
        }
        else
        {
            this.scrollDown.Scroll();
        }
        this.thisCol.enabled = false;
    }

    public virtual IEnumerator DisableCol()
    {
        yield return new WaitForSeconds(0.15f);
        this.thisCol.enabled = false;
    }

}