using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class WheelJointBreak : MonoBehaviour
{
    public GameObject WheelObjectIntact;
    public GameObject WheelObjectBroken;
    public virtual void OnJointBreak(float breakForce)
    {
        this.transform.parent = null;
        this.WheelObjectBroken.gameObject.SetActive(true);
        UnityEngine.Object.Destroy(this.WheelObjectIntact);
    }

}