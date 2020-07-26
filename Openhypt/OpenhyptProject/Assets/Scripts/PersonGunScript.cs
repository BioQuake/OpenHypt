using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PersonGunScript : MonoBehaviour
{
    public GameObject Fire;
    public Transform BarrelLocation;
    public int TargetCode;
    public bool RigidFlash;
    public bool Firing;
    public bool SkipBursts;
    public float BurstTime;
    public int ShotChanceIn;
    public int Counter;
    public float RepTime;
    public virtual void Shot()
    {
        if (this.RigidFlash)
        {
            GameObject TheThing = UnityEngine.Object.Instantiate(this.Fire, this.BarrelLocation.position, this.BarrelLocation.rotation);
            TheThing.transform.parent = this.gameObject.transform;
        }
        if (!this.RigidFlash)
        {
            UnityEngine.Object.Instantiate(this.Fire, this.BarrelLocation.position, this.BarrelLocation.rotation);
        }
    }

    public virtual IEnumerator Burst1()
    {
        yield return new WaitForSeconds(this.BurstTime);
        UnityEngine.Object.Instantiate(this.Fire, this.BarrelLocation.position, this.BarrelLocation.rotation);
        yield return new WaitForSeconds(this.BurstTime);
        if (this.Firing)
        {
            UnityEngine.Object.Instantiate(this.Fire, this.BarrelLocation.position, this.BarrelLocation.rotation);
        }
        yield return new WaitForSeconds(this.BurstTime);
        if (this.Firing)
        {
            UnityEngine.Object.Instantiate(this.Fire, this.BarrelLocation.position, this.BarrelLocation.rotation);
        }
    }

    public virtual IEnumerator Burst2()
    {
        yield return new WaitForSeconds(this.BurstTime);
        UnityEngine.Object.Instantiate(this.Fire, this.BarrelLocation.position, this.BarrelLocation.rotation);
        yield return new WaitForSeconds(this.BurstTime);
        if (this.Firing)
        {
            UnityEngine.Object.Instantiate(this.Fire, this.BarrelLocation.position, this.BarrelLocation.rotation);
        }
        yield return new WaitForSeconds(this.BurstTime);
        if (this.Firing)
        {
            UnityEngine.Object.Instantiate(this.Fire, this.BarrelLocation.position, this.BarrelLocation.rotation);
        }
        yield return new WaitForSeconds(this.BurstTime);
        if (this.Firing)
        {
            UnityEngine.Object.Instantiate(this.Fire, this.BarrelLocation.position, this.BarrelLocation.rotation);
        }
    }

    public virtual IEnumerator Burst3()
    {
        yield return new WaitForSeconds(this.BurstTime);
        UnityEngine.Object.Instantiate(this.Fire, this.BarrelLocation.position, this.BarrelLocation.rotation);
        yield return new WaitForSeconds(this.BurstTime);
        if (this.Firing)
        {
            UnityEngine.Object.Instantiate(this.Fire, this.BarrelLocation.position, this.BarrelLocation.rotation);
        }
        yield return new WaitForSeconds(this.BurstTime);
        if (this.Firing)
        {
            UnityEngine.Object.Instantiate(this.Fire, this.BarrelLocation.position, this.BarrelLocation.rotation);
        }
        yield return new WaitForSeconds(this.BurstTime);
        if (this.Firing)
        {
            UnityEngine.Object.Instantiate(this.Fire, this.BarrelLocation.position, this.BarrelLocation.rotation);
        }
        yield return new WaitForSeconds(this.BurstTime);
        if (this.Firing)
        {
            UnityEngine.Object.Instantiate(this.Fire, this.BarrelLocation.position, this.BarrelLocation.rotation);
        }
        yield return new WaitForSeconds(this.BurstTime);
        if (this.Firing)
        {
            UnityEngine.Object.Instantiate(this.Fire, this.BarrelLocation.position, this.BarrelLocation.rotation);
        }
    }

    public virtual IEnumerator Burst4()
    {
        yield return new WaitForSeconds(this.BurstTime);
        UnityEngine.Object.Instantiate(this.Fire, this.BarrelLocation.position, this.BarrelLocation.rotation);
        yield return new WaitForSeconds(this.BurstTime);
        if (this.Firing)
        {
            UnityEngine.Object.Instantiate(this.Fire, this.BarrelLocation.position, this.BarrelLocation.rotation);
        }
        yield return new WaitForSeconds(this.BurstTime);
        if (this.Firing)
        {
            UnityEngine.Object.Instantiate(this.Fire, this.BarrelLocation.position, this.BarrelLocation.rotation);
        }
        yield return new WaitForSeconds(this.BurstTime);
        if (this.Firing)
        {
            UnityEngine.Object.Instantiate(this.Fire, this.BarrelLocation.position, this.BarrelLocation.rotation);
        }
        yield return new WaitForSeconds(this.BurstTime);
        if (this.Firing)
        {
            UnityEngine.Object.Instantiate(this.Fire, this.BarrelLocation.position, this.BarrelLocation.rotation);
        }
        yield return new WaitForSeconds(this.BurstTime);
        if (this.Firing)
        {
            UnityEngine.Object.Instantiate(this.Fire, this.BarrelLocation.position, this.BarrelLocation.rotation);
        }
        yield return new WaitForSeconds(this.BurstTime);
        if (this.Firing)
        {
            UnityEngine.Object.Instantiate(this.Fire, this.BarrelLocation.position, this.BarrelLocation.rotation);
        }
        yield return new WaitForSeconds(this.BurstTime);
        if (this.Firing)
        {
            UnityEngine.Object.Instantiate(this.Fire, this.BarrelLocation.position, this.BarrelLocation.rotation);
        }
    }

    public virtual void Shoot()
    {
        if ((this.gameObject.activeSelf == true) && this.Firing)
        {
            int Interval = Random.Range(0, this.ShotChanceIn);
            if (!this.SkipBursts)
            {
                if ((this.Counter == 0) && (this.TargetCode == 7))
                {
                    switch (Interval)
                    {
                        case 1:
                            this.Shot();
                            this.Counter = 1;
                            break;
                    }
                }
                if ((this.Counter == 0) && (this.TargetCode == 5))
                {
                    switch (Interval)
                    {
                        case 1:
                            this.StartCoroutine(this.Burst1());
                            this.Counter = 3;
                            break;
                        case 2:
                            this.StartCoroutine(this.Burst2());
                            this.Counter = 4;
                            break;
                        case 3:
                            this.StartCoroutine(this.Burst3());
                            this.Counter = 5;
                            break;
                        case 4:
                            this.StartCoroutine(this.Burst4());
                            this.Counter = 7;
                            break;
                    }
                }
                if ((this.Counter == 0) && (this.TargetCode == 6))
                {
                    switch (Interval)
                    {
                        case 1:
                            this.Shot();
                            this.Counter = 3;
                            break;
                        case 2:
                            this.StartCoroutine(this.Burst1());
                            this.Counter = 4;
                            break;
                        case 3:
                            this.StartCoroutine(this.Burst2());
                            this.Counter = 5;
                            break;
                    }
                }
                if (this.Counter > 0)
                {
                    this.Counter = this.Counter - 1;
                }
            }
            else
            {
                if ((this.Counter == 0) && (this.TargetCode == 7))
                {
                    switch (Interval)
                    {
                        case 1:
                            this.Shot();
                            this.Counter = 1;
                            break;
                    }
                }
                if ((this.Counter == 0) && (this.TargetCode == 5))
                {
                    switch (Interval)
                    {
                        case 1:
                            this.Shot();
                            this.Counter = 1;
                            break;
                    }
                }
                if ((this.Counter == 0) && (this.TargetCode == 6))
                {
                    switch (Interval)
                    {
                        case 1:
                            this.Shot();
                            this.Counter = 1;
                            break;
                    }
                }
                if (this.Counter > 0)
                {
                    this.Counter = this.Counter - 1;
                }
            }
        }
    }

    public virtual void Start()
    {
        this.InvokeRepeating("Shoot", Random.Range(0.1f, 2.9f), this.RepTime);
    }

    public PersonGunScript()
    {
        this.TargetCode = 6;
        this.BurstTime = 0.1f;
        this.ShotChanceIn = 8;
        this.RepTime = 0.3f;
    }

}