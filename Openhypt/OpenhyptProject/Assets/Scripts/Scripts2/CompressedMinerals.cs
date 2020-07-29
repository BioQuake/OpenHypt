using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class CompressedMinerals : MonoBehaviour
{
    public System.Collections.Generic.List<MineralBarrel> MineralData;
    public CompressedMinerals()
    {
        this.MineralData = new System.Collections.Generic.List<MineralBarrel>();
    }

}