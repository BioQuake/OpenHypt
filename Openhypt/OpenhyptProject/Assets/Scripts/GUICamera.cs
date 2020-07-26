using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class GUICamera : MonoBehaviour
{
    public static Camera instance;
    public virtual void Awake()
    {
        GUICamera.instance = this.GetComponent<Camera>();
    }

}