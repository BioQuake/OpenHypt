using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AgrianContainerArea : MonoBehaviour
{
    public GameObject VacantArea;
    public bool Vacant;
    public bool Occupied;
    public AgrianDigesterAI MachineDigester;
    public bool MDContainer1;
    public bool MDContainer2;
    public virtual void Update()
    {
        if (this.Vacant)
        {
            this.Vacant = false;
            this.VacantArea.gameObject.SetActive(true);
        }
        if (this.Occupied)
        {
            this.Occupied = false;
            this.VacantArea.gameObject.name = "TowerDispatchArea";
            this.VacantArea.gameObject.SetActive(false);
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (this.MachineDigester)
        {
            if (other.GetComponent<Collider>().name.Contains("Magnet"))
            {
                if (this.MDContainer1)
                {
                    this.MachineDigester.Container1 = other.gameObject.transform.parent.gameObject;
                }
                if (this.MDContainer2)
                {
                    this.MachineDigester.Container2 = other.gameObject.transform.parent.gameObject;
                }
            }
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().name.Contains("Magnet"))
        {
            this.Vacant = true;
            if (this.MDContainer1)
            {
                this.MachineDigester.Container1 = null;
            }
            if (this.MDContainer2)
            {
                this.MachineDigester.Container2 = null;
            }
        }
    }

}