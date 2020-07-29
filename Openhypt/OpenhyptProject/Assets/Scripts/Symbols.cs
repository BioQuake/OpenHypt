using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class Symbols : MonoBehaviour
{
    public Transform Enter;
    public Transform Interact;
    public Transform Talk;
    public Transform Open;
    public Transform Ammo;
    public Transform Reticle;
    public static Symbols instance;
    public virtual void Awake()
    {
        Symbols.instance = this;
    }

}