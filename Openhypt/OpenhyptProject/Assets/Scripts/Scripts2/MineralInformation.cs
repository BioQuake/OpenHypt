using System.Collections.Generic;
using UnityEngine;
using System.Collections;

[System.Serializable]
public class MineralAtt : object
{
    public eMineralType mineralType;
    public int mineralAmount;
    public int mineralReceivePerSec;
    public MineralAtt()
    {
        this.mineralReceivePerSec = 1;
    }

}
[System.Serializable]
public partial class MineralInformation : MonoBehaviour
{
    public System.Collections.Generic.List<MineralAtt> Minerals;
    public GameObject CrumblePrefab;
}