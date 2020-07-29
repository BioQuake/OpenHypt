using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class NoPass : MonoBehaviour
{
    public static bool IsAsleep;
    public bool Invert;
    public Transform cam;
    private Transform TargetPosition;
    public virtual void Start()
    {
        if (WorldInformation.instance.InvertedNoPass == true)
        {
            this.Invert = true;
        }
        if (WorldInformation.instance.InvertedNoPass == false)
        {
            this.Invert = false;
        }
        NoPass.IsAsleep = false;
        this.cam = GameObject.Find("PhysCam").transform;
        this.TargetPosition = this.transform;
    }

    public virtual void OnTriggerStay(Collider trigger)
    {
        if (!NoPass.IsAsleep)
        {
            if (trigger.gameObject.name.Contains("Nopass"))
            {
                if (this.Invert)
                {
                    this.cam.gameObject.layer = 23;
                    this.cam.GetComponent<Rigidbody>().isKinematic = true;
                    WorldInformation.IsNopass = true;
                    WorldInformation.FPMode = false;
                    FurtherActionScript.instance.NoPass = true;
                    FurtherActionScript.instance.ShowText();
                }
                else
                {
                    this.cam.GetComponent<Rigidbody>().isKinematic = false;
                    WorldInformation.IsNopass = false;
                }
            }
        }
    }

    public virtual void OnTriggerExit(Collider trigger)
    {
        if (!NoPass.IsAsleep)
        {
            if (trigger.gameObject.name.Contains("Nopass"))
            {
                if (this.Invert)
                {
                    this.cam.GetComponent<Rigidbody>().isKinematic = false;
                    this.cam.gameObject.layer = 8;
                    WorldInformation.IsNopass = false;
                }
                else
                {
                    this.cam.GetComponent<Rigidbody>().isKinematic = true;
                    this.cam.gameObject.layer = 23;
                    WorldInformation.IsNopass = true;
                    WorldInformation.FPMode = false;
                    FurtherActionScript.instance.NoPass = true;
                    FurtherActionScript.instance.ShowText();
                }
            }
        }
    }

}