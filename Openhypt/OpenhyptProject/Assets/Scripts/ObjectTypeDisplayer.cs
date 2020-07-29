using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ObjectTypeDisplayer : MonoBehaviour
{
    public static ObjectTypeDisplayer instance;
    public virtual void Awake()
    {
        ObjectTypeDisplayer.instance = this;
    }

    public virtual void UpdateType(string name)
    {
        TextMesh tm = (TextMesh) this.GetComponent(typeof(TextMesh));
        tm.text = name;
    }

}