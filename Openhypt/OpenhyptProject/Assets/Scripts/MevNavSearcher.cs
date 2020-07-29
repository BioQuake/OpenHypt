using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MevNavSearcher : MonoBehaviour
{
    public Transform target;
    public static Transform MevNavPriorityWaypoint;
    public int ScanArea;
    public virtual void Start()
    {
        this.InvokeRepeating("DoStuff", 10, 30);
        MevNavSearcher.MevNavPriorityWaypoint = this.gameObject.transform;
    }

    public virtual void Update()
    {
    }

    public virtual void FixedUpdate()
    {
        if (this.target != null)
        {
            this.transform.position = this.target.position;
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if (((((((other.name.Contains("TC1") || other.name.Contains("TC3")) || other.name.Contains("TC4")) || other.name.Contains("TC5")) || other.name.Contains("TC6")) || other.name.Contains("TC7")) || other.name.Contains("TC8")) || other.name.Contains("TC9"))
        {
            this.target = other.gameObject.transform;
        }
    }

    public virtual void DoStuff()
    {
        this.StartCoroutine(this.Scan());
    }

    public virtual IEnumerator Scan()
    {
        ((SphereCollider) this.gameObject.GetComponent(typeof(SphereCollider))).radius = this.ScanArea;
        yield return new WaitForSeconds(0.3f);
        ((SphereCollider) this.gameObject.GetComponent(typeof(SphereCollider))).radius = 50;
    }

    public MevNavSearcher()
    {
        this.ScanArea = 3000;
    }

}