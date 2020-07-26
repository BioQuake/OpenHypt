using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AkbarArmyController : MonoBehaviour
{
    public static Transform AkbarArmyTarget;
    public Transform Following;
    public GameObject Parent;
    public GameObject ArmyDeathEffect;
    public SphereCollider Sensor;
    public bool Damaged;
    public virtual void FixedUpdate()
    {
        if (this.Following)
        {
            this.transform.position = this.Following.transform.position;
        }
        if (this.Sensor.radius < 300)
        {
            this.Sensor.radius = this.Sensor.radius + 1;
        }
        if (this.Damaged)
        {
            UnityEngine.Object.Instantiate(this.ArmyDeathEffect, this.transform.position, this.transform.rotation);
            UnityEngine.Object.Destroy(this.Parent);
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if (((((((other.GetComponent<Collider>().name.Contains("TC1") || other.GetComponent<Collider>().name.Contains("TC2")) || other.GetComponent<Collider>().name.Contains("TC3")) || other.GetComponent<Collider>().name.Contains("TC4")) || other.GetComponent<Collider>().name.Contains("TC5")) || other.GetComponent<Collider>().name.Contains("TC7")) || other.GetComponent<Collider>().name.Contains("TC8")) || other.GetComponent<Collider>().name.Contains("TC9"))
        {
            AkbarArmyController.AkbarArmyTarget = other.gameObject.transform;
            this.Sensor.radius = 1;
        }
    }

}