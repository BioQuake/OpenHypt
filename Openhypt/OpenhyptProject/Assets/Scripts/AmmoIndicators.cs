using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AmmoIndicators : MonoBehaviour
{
    public GameObject LP;
    public GameObject HP;
    public GameObject M;
    public static AmmoIndicators instance;
    public virtual void Awake()
    {
        AmmoIndicators.instance = this;
    }

}