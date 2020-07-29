using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class Murksplosion : MonoBehaviour
{
    public GameObject explosion;
    public virtual void OnJointBreak(float breakForce)
    {
        UnityEngine.Object.Instantiate(this.explosion, this.transform.position, this.transform.rotation);
        this.GetComponent<Rigidbody>().AddTorque(this.transform.up * Random.Range(-1, 1));
        this.GetComponent<Rigidbody>().AddTorque(this.transform.right * Random.Range(-1, 1));
        this.GetComponent<Rigidbody>().AddTorque(this.transform.forward * Random.Range(-1, 1));
        this.GetComponent<Rigidbody>().velocity = this.transform.up * Random.Range(-10, 10);
        this.GetComponent<Rigidbody>().velocity = this.transform.right * Random.Range(-10, 10);
        this.GetComponent<Rigidbody>().velocity = this.transform.forward * 100;
    }

}