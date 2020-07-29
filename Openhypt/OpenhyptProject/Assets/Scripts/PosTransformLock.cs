using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PosTransformLock : MonoBehaviour
{
    public float X;
    public float Y;
    public float Z;
    public GameObject Aimer;
    public GameObject Gun;
    public virtual void FixedUpdate()
    {
        this.transform.localPosition = new Vector3(this.X, this.Y, this.Z);
    }

    public virtual void OnJointBreak(float breakForce)
    {
        ((NewgunController) this.Gun.GetComponent(typeof(NewgunController))).enabled = false;
        this.GetComponent<Rigidbody>().useGravity = true;
        UnityEngine.Object.Destroy(this.Aimer);
        this.transform.parent = null;
        UnityEngine.Object.Destroy(this);
    }

}