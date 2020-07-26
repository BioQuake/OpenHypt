using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SimpleSensor : MonoBehaviour
{
    public PiriDefenseDroneAI MainScript;
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().name.Contains("MT"))
        {
            this.MainScript.EnteredMissile = other.gameObject.transform;
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().name.Contains("MT"))
        {
            this.MainScript.EnteredMissile = null;
        }
    }

}