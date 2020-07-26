using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class Nudge : MonoBehaviour
{
    public float Multiplier;
    public virtual void AddShit()
    {
        this.GetComponent<Rigidbody>().AddForce(this.transform.up * this.Multiplier, ForceMode.Impulse);
    }

    public virtual void Start()
    {
        this.InvokeRepeating("AddShit", 2, 3);
    }

}