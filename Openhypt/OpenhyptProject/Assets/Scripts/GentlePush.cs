using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class GentlePush : MonoBehaviour
{
    public float xvelocity;
    public float yvelocity;
    public float zvelocity;
    public float xspin;
    public float yspin;
    public float zspin;
    public virtual void Start()
    {
        this.GetComponent<Rigidbody>().velocity = new Vector3(this.xvelocity, this.yvelocity, this.zvelocity);
        this.GetComponent<Rigidbody>().angularVelocity = new Vector3(this.xspin, this.yspin, this.zspin);
    }

}