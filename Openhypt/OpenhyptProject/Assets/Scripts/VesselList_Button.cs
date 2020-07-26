using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class VesselList_Button : MonoBehaviour
{
    public static VesselList_Button[] vessel_buttons;
    public static VesselList_Button selected_button;
    public static int selected_index;
    public int index;
    public virtual void Awake()
    {
        VesselList_Button.vessel_buttons[this.index] = this;
    }

    public virtual void OnMouseDown()
    {
        if ((this.index + VesselList.offset) < VesselList.Count())
        {
            if (VesselList_Button.selected_button != null)
            {
                VesselList_Button.selected_button.UpdateState(false, -1);
                if (VesselList_Button.selected_button == this)
                {
                    VesselList_Button.selected_button = null;
                    VesselList_Button.selected_index = -1;
                }
                else
                {
                    this.UpdateState(true, this.index);
                    VesselList_Button.selected_button = this;
                }
            }
            else
            {
                this.UpdateState(true, this.index);
                VesselList_Button.selected_button = this;
            }
        }
        VesselList.UpdateSummonButton();
    }

    public virtual void UpdateUI(string str)
    {
        ((TextMesh) this.transform.GetChild(2).GetComponent(typeof(TextMesh))).text = str;
    }

    public virtual void UpdateState(bool selected, int new_index)
    {
        this.transform.GetChild(0).GetComponent<Renderer>().enabled = selected;
        if (selected)
        {
            VesselList_Button.selected_index = new_index;
        }
    }

    public static void DeselectAll()
    {
        //if (selected_index == -1) return;
        if (VesselList_Button.selected_button != null)
        {
            VesselList_Button.selected_button.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
            VesselList_Button.selected_button = null;
        }
    }

    public static int Count()
    {
        return VesselList_Button.vessel_buttons.Length;
    }

    static VesselList_Button()
    {
        VesselList_Button.vessel_buttons = new VesselList_Button[5];
    }

}