using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class DestroyChildrenOnJointBreak : MonoBehaviour
{
    public bool Objects;
    public GameObject SelectedObject;
    public virtual void OnJointBreak(float breakForce)
    {
        if (!this.Objects)
        {
            UnityEngine.Object.Destroy(this.transform.GetChild(0).gameObject);
        }
        if (this.Objects)
        {
            UnityEngine.Object.Destroy(this.SelectedObject);
        }
        this.transform.parent = null;
    }

}