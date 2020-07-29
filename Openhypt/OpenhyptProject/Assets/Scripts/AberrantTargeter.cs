using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AberrantTargeter : MonoBehaviour
{
    public NPCGun AberrantGun;
    public bool Obscured;
    public LayerMask targetLayers;
    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        if (this.AberrantGun == null)
        {
            return;
        }
        if (Physics.Raycast(this.transform.position + (this.transform.forward * 5), this.transform.forward, out hit, 600, (int) this.targetLayers))
        {
            if (hit.collider.tag == "TC4")
            {
                this.Obscured = true;
                this.AberrantGun.LineOfFire = false;
            }
            else
            {
                this.Obscured = false;
            }
            if ((((((((hit.collider.name.Contains("TC0") || hit.collider.name.Contains("TC1")) || hit.collider.name.Contains("TC2")) || hit.collider.name.Contains("TC3")) || hit.collider.name.Contains("TC5")) || hit.collider.name.Contains("TC6")) || hit.collider.name.Contains("TC7")) || hit.collider.name.Contains("TC8")) || hit.collider.name.Contains("TC9"))
            {
                if (this.Obscured == false)
                {
                    this.AberrantGun.LineOfFire = true;
                }
            }
            else
            {
                this.AberrantGun.LineOfFire = false;
            }
        }
    }

    public virtual void Nuller()
    {
        if (this.AberrantGun != null)
        {
            this.AberrantGun.LineOfFire = false;
        }
    }

    public virtual void Start()
    {
        this.InvokeRepeating("Nuller", 1, 1);
    }

}