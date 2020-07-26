using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class RefineryTrigger : MonoBehaviour
{
    public static bool InsideRefinery;
    public GameObject RefineryIcon;
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().gameObject.name.Contains("Pirizuka"))
        {
            this.RefineryIcon.SetActive(true);
            RefineryTrigger.InsideRefinery = true;
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().gameObject.name.Contains("Pirizuka"))
        {
            this.RefineryIcon.SetActive(false);
            RefineryTrigger.InsideRefinery = false;
        }
    }

}