using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class TCInfo : MonoBehaviour
{
    public float IAmNumber;
    public string IAmName;
    public bool IAmStopping;
    public TCInfo()
    {
        this.IAmNumber = 1;
    }

}