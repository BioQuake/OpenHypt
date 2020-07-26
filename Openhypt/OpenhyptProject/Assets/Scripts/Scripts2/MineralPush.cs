using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MineralPush : MonoBehaviour
{
    public float xspin;
    public float yspin;
    public float zspin;
    public float Vel;
    public virtual void Start()
    {
        this.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(this.Vel, 0, 0) * (this.GetComponent<Rigidbody>().mass * 10));
        this.GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
    }

    public MineralPush()
    {
        this.Vel = 140f;
    }

}