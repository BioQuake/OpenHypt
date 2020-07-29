using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MineralControlPanel : MonoBehaviour
{
    public bool IsNear;
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("TC1") && (WorldInformation.playerCar == "null"))
        {
            if (!other.name.Contains("TC1d"))
            {
                this.IsNear = true;
            }
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("TC1") && (WorldInformation.playerCar == "null"))
        {
            if (!other.name.Contains("TC1d"))
            {
                this.IsNear = false;
                MineralRefinery.instance.ToggleRefinery(false);
            }
        }
    }

    public virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && this.IsNear)
        {
            MineralRefinery.instance.ToggleRefinery(true);
            this.IsNear = false;
        }
    }

}