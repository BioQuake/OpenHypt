using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class StructurePieceScript : MonoBehaviour
{
    public GameObject BreakEffect;
    public GameObject BreakEffect2;
    public bool BrokenUp;
    public bool CanSound;
    public virtual void OnCollisionEnter(Collision collision)
    {
        if (!this.CanSound)
        {
            return;
        }
        if (((collision.gameObject.tag == "SoftTerrain") || (collision.gameObject.tag == "Terrain")) || (collision.gameObject.tag == "Structure"))
        {
            this.CanSound = false;
            if (collision.relativeVelocity.magnitude > 30)
            {
                UnityEngine.Object.Instantiate(this.BreakEffect2, this.transform.position, this.transform.rotation);
                UnityEngine.Object.Destroy(this.gameObject);
            }
            if (collision.relativeVelocity.magnitude > 15)
            {
                UnityEngine.Object.Instantiate(this.BreakEffect, this.transform.position, this.transform.rotation);
            }
        }
    }

    public virtual void Tick()
    {
        this.CanSound = true;
    }

    public virtual void Start()
    {
        this.InvokeRepeating("Tick", 1, 0.3f);
    }

}