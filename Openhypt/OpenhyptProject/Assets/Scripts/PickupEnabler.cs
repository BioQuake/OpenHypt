using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PickupEnabler : MonoBehaviour
{
    public virtual void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "ElementMaterials") && !other.name.Contains("SM"))
        {
            other.gameObject.name = "CM8";
        }
    }

}