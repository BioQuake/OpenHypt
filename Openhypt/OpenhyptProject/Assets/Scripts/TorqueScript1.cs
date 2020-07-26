using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class TorqueScript1 : MonoBehaviour
{
    public float Power;
    public virtual void FixedUpdate()
    {
        this.GetComponent<Rigidbody>().AddTorque(this.transform.up * this.Power);
    }

    public TorqueScript1()
    {
        this.Power = 100;
    }

}