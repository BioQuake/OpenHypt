using UnityEngine;
using System.Collections;

public enum mDir
{
    RawWindow = 0,
    RefinedWindow = 1
}

public enum sDir
{
    Up = 0,
    Down = 1
}

[System.Serializable]
public partial class MineralGUIScroll : MonoBehaviour
{
    public mDir ScrollType;
    public sDir ScrollDirection;
    public virtual void OnMouseUpAsButton()
    {
        switch (this.ScrollType)
        {
            case mDir.RawWindow:
                if (this.ScrollDirection == sDir.Up)
                {
                    MineralGUI.RefineOffset = Mathf.Clamp(MineralGUI.RefineOffset - 1, 0, MineralRefinery.instance.RawMinerals.Count);
                }
                if (this.ScrollDirection == sDir.Down)
                {
                    MineralGUI.RefineOffset = Mathf.Clamp(MineralGUI.RefineOffset + 1, 0, MineralRefinery.instance.RawMinerals.Count);
                }
                break;
            case mDir.RefinedWindow:
                if (this.ScrollDirection == sDir.Up)
                {
                    MineralGUI.DispenseOffset = Mathf.Clamp(MineralGUI.DispenseOffset - 1, 0, MineralRefinery.instance.RefinedMinerals.Count);
                }
                if (this.ScrollDirection == sDir.Down)
                {
                    MineralGUI.DispenseOffset = Mathf.Clamp(MineralGUI.DispenseOffset + 1, 0, MineralRefinery.instance.RefinedMinerals.Count);
                }
                break;
        }
        MineralRefinery.instance.RefreshGUI();
    }

}