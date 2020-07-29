using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class CallVesselListButton : MonoBehaviour
{
    private bool entered;
    public bool Assistance;
    public GameObject VesselList;
    public VesselList_Scroller VLScroller;
    public GameObject AssistanceList;
    public virtual void Update()
    {
        if (this.entered && Input.GetMouseButtonDown(0))
        {
            if (!this.Assistance)
            {
                this.VesselList.transform.Translate(Vector3.right * 3);
                this.VLScroller.isActive = true;
            }
            else
            {
                this.AssistanceList.transform.Translate(Vector3.right * 5);
            }
            this.entered = false;
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