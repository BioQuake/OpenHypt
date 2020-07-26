using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class BothunterGunController : MonoBehaviour
{
    public Transform TurretTarget;
    public Transform ResetView;
    public Transform Muzzle;
    public float Spread;
    public GameObject Fire1;
    public BothunterAI BothunterAI;
    public LayerMask targetLayers;
    public bool LineOfFire;
    private Quaternion NewRotation;
    public virtual void LateUpdate()
    {
        if (this.TurretTarget && (this.TurretTarget.name != "ResetViewAI"))
        {
            this.NewRotation = Quaternion.LookRotation(this.TurretTarget.position - this.transform.position);
            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, this.NewRotation, Time.deltaTime * 200);
        }
        this.Muzzle.transform.localRotation = Quaternion.Euler(90, 0, 0);
        this.Muzzle.transform.Rotate(Vector3.right * Random.Range(0, this.Spread));
        this.Muzzle.transform.Rotate(Vector3.left * Random.Range(0, this.Spread));
        this.Muzzle.transform.Rotate(Vector3.up * Random.Range(0, this.Spread));
        this.Muzzle.transform.Rotate(Vector3.down * Random.Range(0, this.Spread));
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        if (Physics.Raycast(this.Muzzle.transform.position + (this.Muzzle.transform.forward * 3), this.Muzzle.transform.forward, out hit, 400, (int) this.targetLayers))
        {
            if ((this.BothunterAI.PissedAtTC1 == 0) && hit.collider.name.Contains("TC1"))
            {
                this.LineOfFire = false;
                return;
            }
            if ((((((hit.collider.name.Contains("TC1") || hit.collider.name.Contains("TC4")) || hit.collider.name.Contains("TC5")) || hit.collider.name.Contains("TC6")) || hit.collider.name.Contains("TC7")) || hit.collider.name.Contains("TC8")) || hit.collider.name.Contains("TC9"))
            {
                this.LineOfFire = true;
            }
            else
            {
                this.LineOfFire = false;
            }
        }
    }

    public virtual void Fire()
    {
        if (this.LineOfFire)
        {
            UnityEngine.Object.Instantiate(this.Fire1, this.Muzzle.position, this.Muzzle.rotation);
        }
    }

    public virtual void Resetter()
    {
        this.LineOfFire = false;
        this.TurretTarget = this.BothunterAI.target;
        if (this.TurretTarget != null)
        {
            if (this.TurretTarget.name == "ResetViewAI")
            {
                this.TurretTarget = this.ResetView;
            }
        }
        this.GetComponent<Rigidbody>().freezeRotation = true;
    }

    public virtual void Start()
    {
        this.InvokeRepeating("Resetter", 1, 0.5f);
    }

    public BothunterGunController()
    {
        this.Spread = 1;
    }

}