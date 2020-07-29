using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MineralPushout : MonoBehaviour
{
    public virtual void Start()
    {
        this.GetComponent<Rigidbody>().AddForce((this.transform.up * 50) * this.GetComponent<Rigidbody>().mass);
    }

}