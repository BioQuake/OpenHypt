using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ObjectInfoDisplayer : MonoBehaviour
{
    public static ObjectInfoDisplayer instance;
    public virtual void Awake()
    {
        ObjectInfoDisplayer.instance = this;
    }

    public virtual void UpdateInfo(string name)
    {
        TextMesh tm = (TextMesh) this.GetComponent(typeof(TextMesh));
        tm.text = name;
    }

}