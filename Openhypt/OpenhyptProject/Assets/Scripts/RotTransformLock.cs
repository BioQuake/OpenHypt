using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class RotTransformLock : MonoBehaviour
{
    public float X;
    public float Y;
    public float Z;
    public virtual void Update()
    {
        this.transform.localPosition = new Vector3(this.X, this.Y, this.Z);
    }

}