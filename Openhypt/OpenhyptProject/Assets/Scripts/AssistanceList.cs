using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AssistanceList : MonoBehaviour
{
    public virtual void OnMouseDown()
    {
        this.transform.parent.Translate(Vector3.right * -5);
    }

}