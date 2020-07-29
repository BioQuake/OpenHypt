using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ObjectNameDisplayer : MonoBehaviour
{
    public static ObjectNameDisplayer instance;
    public virtual void Awake()
    {
        ObjectNameDisplayer.instance = this;
    }

    public virtual void UpdateName(string name)
    {
        TextMesh tm = (TextMesh) this.GetComponent(typeof(TextMesh));
        tm.text = name;
    }

}