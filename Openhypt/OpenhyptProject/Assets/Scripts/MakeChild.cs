using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MakeChild : MonoBehaviour
{
    public virtual void Start()
    {
        GameObject Diapos = GameObject.Find("DialoguePos");
        this.transform.parent = Diapos.transform;
    }

}