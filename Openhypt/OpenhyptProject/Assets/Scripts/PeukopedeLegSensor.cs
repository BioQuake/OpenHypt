using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PeukopedeLegSensor : MonoBehaviour
{
    public PeukopedeAI MainPeuk;
    public int LiftPower;
    public virtual void FixedUpdate()
    {
        if (this.MainPeuk)
        {
            this.GetComponent<Rigidbody>().AddForce(this.transform.right * this.LiftPower);
        }
        else
        {
            UnityEngine.Object.Destroy(this);
        }
    }

    public virtual void Resetter()
    {
        this.MainPeuk.Standing = false;
    }

    public virtual void OnCollisionStay(Collision collision)
    {
        if (((((collision.gameObject.tag == "SoftTerrain") || (collision.gameObject.tag == "Terrain")) || (collision.gameObject.tag == "Structure")) || (collision.gameObject.tag == "Metal")) || (collision.gameObject.tag == "Vehicle"))
        {
            this.MainPeuk.Standing = true;
        }
    }

    public virtual void Start()
    {
        this.InvokeRepeating("Resetter", 1, 0.3f);
    }

}