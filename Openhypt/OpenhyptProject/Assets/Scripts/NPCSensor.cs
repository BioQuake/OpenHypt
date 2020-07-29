using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class NPCSensor : MonoBehaviour
{
    public StuffSpawner NPCSpawner;
    public bool IsTrailer;
    public virtual void Start()
    {
    }

    public virtual void Removing()
    {
    }

}