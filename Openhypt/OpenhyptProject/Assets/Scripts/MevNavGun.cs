using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MevNavGun : MonoBehaviour
{
    public GameObject Fire1;
    public Transform Muzzle;
    public LayerMask targetLayers;
    public bool Obscured;
    public bool Pausing;
    public bool LineOfFire;
    public int MaxShotSuccession;
    public int GunCooldown;
    public bool UseCooldown;
    public bool UseTrace;
    public int Shots;
    public virtual void Fire()
    {
        if (!this.Pausing)
        {
            if (this.LineOfFire)
            {
                UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle.position, this.Muzzle.rotation);
                this.Shots = this.Shots + 1;
                this.StartCoroutine(this.Pause());
            }
        }
    }

    public virtual IEnumerator Pause()
    {
        if ((this.Shots > this.MaxShotSuccession) && this.UseCooldown)
        {
            this.Pausing = true;
            yield return new WaitForSeconds(this.GunCooldown);
            this.Pausing = false;
            this.Shots = 0;
        }
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        this.LineOfFire = false;
        if (Physics.Raycast(this.transform.position + (this.transform.forward * 0.1f), this.transform.forward, out hit, 1000, (int) this.targetLayers))
        {
            if ((hit.collider != null) && hit.collider.name.Contains("T7Obscure"))
            {
                this.Obscured = true;
            }
            else
            {
                this.Obscured = false;
            }
            if (hit.collider.name.Contains("TC7"))
            {
                return;
            }
            if (!this.UseTrace)
            {
                if (hit.collider.name.Contains("TC"))
                {
                    if (this.Obscured == false)
                    {
                        this.LineOfFire = true;
                    }
                }
            }
            else
            {
                if (hit.collider.name.Contains("TLead") || hit.collider.name.Contains("TC"))
                {
                    if (this.Obscured == false)
                    {
                        this.LineOfFire = true;
                    }
                }
            }
        }
        else
        {
            this.LineOfFire = false;
        }
    }

    public MevNavGun()
    {
        this.MaxShotSuccession = 5;
        this.GunCooldown = 2;
    }

}