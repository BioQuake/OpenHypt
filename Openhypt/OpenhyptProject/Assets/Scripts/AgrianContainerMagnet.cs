using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AgrianContainerMagnet : MonoBehaviour
{
    public AgrianContainerController Controller;
    public bool FrontMagnet;
    public bool IsActive;
    public virtual IEnumerator Start()
    {
        yield return new WaitForSeconds(2);
        this.IsActive = true;
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (this.IsActive)
        {
            if (other.GetComponent<Collider>().name.Contains("Magnet"))
            {
                if (this.FrontMagnet)
                {
                    if (!other.GetComponent<Collider>().name.Contains("TowerMagnet"))
                    {
                        this.Controller.Detach = true;
                        this.Controller.Node1 = other.gameObject.transform;
                        this.Controller.Node2 = null;
                        this.Controller.Cbody1 = null;
                    }
                }
                else
                {
                    this.Controller.Detach = true;
                    this.Controller.Node2 = other.gameObject.transform;
                    this.Controller.Node1 = null;
                    this.Controller.Cbody2 = null;
                }
            }
        }
    }

}