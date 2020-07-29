using System.Collections.Generic;
using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class VesselList_Scroll : MonoBehaviour
{
    public int offset;
    public static VesselList_Scroll[] scroll_buttons;
    public virtual void Awake()
    {
        if (this.offset < 0)
        {
            VesselList_Scroll.scroll_buttons[0] = this;
        }
        else
        {
            VesselList_Scroll.scroll_buttons[1] = this;
        }
    }

    public virtual void Start()
    {
        this.CheckState();
    }

    public virtual void OnMouseDown()
    {
        this.Scroll();
    }

    public virtual void Scroll()
    {
        if (!this.GetComponent<Renderer>().enabled || this.CheckState())
        {
            return;
        }
        VesselList.offset = Mathf.Clamp(VesselList.offset + this.offset, 0, VesselList.Count() - VesselList_Button.Count());
        int i = 0;
        while (i < VesselList_Button.Count())
        {
            string _name = VesselList.GetVehicle(i + VesselList.offset).vehicle_name;
            VesselList_Button.vessel_buttons[i].UpdateUI(_name);
            i++;
        }
        VesselList_Button.DeselectAll();
        VesselList_Scroll.scroll_buttons[0].UpdateState(VesselList.offset != 0);
        VesselList_Scroll.scroll_buttons[1].UpdateState(VesselList.offset < (VesselList.Count() - VesselList_Button.Count()));
    }

    public virtual bool CheckState()
    {
        if (VesselList.Count() <= VesselList_Button.Count())
        {
            this.UpdateState(false);
            return true;
        }
        else
        {
            if ((VesselList.offset == 0) && (VesselList_Scroll.scroll_buttons[0] == this))
            {
                return true;
            }
        }
        return false;
    }

    public virtual void UpdateState(bool enable)
    {
        this.GetComponent<Renderer>().enabled = enable;
    }

    public static void UpdateUI()
    {
        int i = 0;
        while (i < VesselList_Scroll.scroll_buttons.Length)
        {
            if (!VesselList_Scroll.scroll_buttons[i].CheckState())
            {
                VesselList_Scroll.scroll_buttons[i].UpdateState(true);
            }
            i++;
        }
    }

    public VesselList_Scroll()
    {
        this.offset = 1;
    }

    static VesselList_Scroll()
    {
        VesselList_Scroll.scroll_buttons = new VesselList_Scroll[2];
    }

}