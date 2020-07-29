using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class TransformLock : MonoBehaviour
{
    public virtual void FixedUpdate()
    {
        this.transform.localPosition = new Vector3(0, 0, 0);
        this.transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

}