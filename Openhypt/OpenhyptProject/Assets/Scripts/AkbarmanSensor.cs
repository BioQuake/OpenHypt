using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AkbarmanSensor : MonoBehaviour
{
    public AkbarmanController AkbarAI;
    public GameObject Akbar;
    public LayerMask MtargetLayers;
    public SphereCollider Sensor;
    public virtual void Update()
    {
        if (this.Akbar != null)
        {
            this.transform.position = this.Akbar.transform.position;
        }
        else
        {
            UnityEngine.Object.Destroy(this.gameObject);
        }
    }

    public virtual void Notice()
    {
        this.Sensor.radius = 100;
    }

    public virtual void OnTriggerStay(Collider other)
    {
        string ON = other.name;
        Transform OT = other.transform;
        if (Physics.Linecast(this.transform.position, OT.position, (int) this.MtargetLayers))
        {
            return;
        }
        if ((((((((ON.Contains("TC0") || ON.Contains("TC1")) || ON.Contains("TC2")) || ON.Contains("TC3")) || ON.Contains("TC4")) || ON.Contains("TC5")) || ON.Contains("TC7")) || ON.Contains("TC8")) || ON.Contains("TC9"))
        {
            if (this.Akbar != null)
            {
                this.AkbarAI.Target = OT;
            }
            this.Sensor.radius = 0.1f;
        }
    }

    public virtual void Start()
    {
        this.InvokeRepeating("Notice", 1, 1);
    }

}