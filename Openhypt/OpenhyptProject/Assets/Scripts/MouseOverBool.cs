using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MouseOverBool : MonoBehaviour
{
    public bool entered;
    public GameObject OverEffect;
    public GameObject PressEffect;
    public virtual void Update()
    {
        if (this.entered)
        {
            this.OverEffect.SetActive(true);
        }
        else
        {
            this.OverEffect.SetActive(false);
        }
        if (Input.GetMouseButtonDown(0) && this.entered)
        {
            this.PressEffect.SetActive(true);
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

}