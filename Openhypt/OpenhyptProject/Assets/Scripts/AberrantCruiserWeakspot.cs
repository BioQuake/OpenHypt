using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AberrantCruiserWeakspot : MonoBehaviour
{
    public GameObject AberrantAI;
    public GameObject BrokenSound;
    public ConfigurableJoint JointScript;
    public GameObject[] WhatToDestroy;
    private bool once;
    public int Health;
    public int ThisDamage;
    public int SendDamage;
    public virtual void OnCollisionEnter(Collision col)
    {
        int i = 0;
        if (col.gameObject.name.Contains("X#1"))
        {
            if (col.gameObject.name.Contains("TFC1") && (this.Health > 0))
            {
                this.ThisDamage = 2;
                this.SendDamage = 2;
                if (this.Health < 3)
                {
                    this.ThisDamage = this.ThisDamage - this.Health;
                    this.SendDamage = this.SendDamage - this.ThisDamage;
                }
                DamageCounter.instance.ShowDamage(this.SendDamage, 4);
            }
            this.Health = this.Health - 2;
        }
        if (col.gameObject.name.Contains("X#2"))
        {
            if (col.gameObject.name.Contains("TFC1") && (this.Health > 0))
            {
                this.ThisDamage = 3;
                this.SendDamage = 3;
                if (this.Health < 4)
                {
                    this.ThisDamage = this.ThisDamage - this.Health;
                    this.SendDamage = this.SendDamage - this.ThisDamage;
                }
                DamageCounter.instance.ShowDamage(this.SendDamage, 4);
            }
            this.Health = this.Health - 3;
        }
        if (col.gameObject.name.Contains("X#3"))
        {
            if (col.gameObject.name.Contains("TFC1") && (this.Health > 0))
            {
                this.ThisDamage = 6;
                this.SendDamage = 6;
                if (this.Health < 7)
                {
                    this.ThisDamage = this.ThisDamage - this.Health;
                    this.SendDamage = this.SendDamage - this.ThisDamage;
                }
                DamageCounter.instance.ShowDamage(this.SendDamage, 4);
            }
            this.Health = this.Health - 6;
        }
        if (col.gameObject.name.Contains("X#4"))
        {
            if (col.gameObject.name.Contains("TFC1") && (this.Health > 0))
            {
                this.ThisDamage = 10;
                this.SendDamage = 10;
                if (this.Health < 11)
                {
                    this.ThisDamage = this.ThisDamage - this.Health;
                    this.SendDamage = this.SendDamage - this.ThisDamage;
                }
                DamageCounter.instance.ShowDamage(this.SendDamage, 4);
            }
            this.Health = this.Health - 10;
        }
        if (col.gameObject.name.Contains("X#5"))
        {
            if (col.gameObject.name.Contains("TFC1") && (this.Health > 0))
            {
                this.ThisDamage = 32;
                this.SendDamage = 32;
                if (this.Health < 33)
                {
                    this.ThisDamage = this.ThisDamage - this.Health;
                    this.SendDamage = this.SendDamage - this.ThisDamage;
                }
                DamageCounter.instance.ShowDamage(this.SendDamage, 4);
            }
            this.Health = this.Health - 32;
        }
        if (col.gameObject.name.Contains("X#6"))
        {
            if (col.gameObject.name.Contains("TFC1") && (this.Health > 0))
            {
                this.ThisDamage = 64;
                this.SendDamage = 64;
                if (this.Health < 65)
                {
                    this.ThisDamage = this.ThisDamage - this.Health;
                    this.SendDamage = this.SendDamage - this.ThisDamage;
                }
                DamageCounter.instance.ShowDamage(this.SendDamage, 4);
            }
            this.Health = this.Health - 64;
        }
        if (col.gameObject.name.Contains("X#7"))
        {
            if (col.gameObject.name.Contains("TFC1") && (this.Health > 0))
            {
                this.ThisDamage = 128;
                this.SendDamage = 128;
                if (this.Health < 129)
                {
                    this.ThisDamage = this.ThisDamage - this.Health;
                    this.SendDamage = this.SendDamage - this.ThisDamage;
                }
                DamageCounter.instance.ShowDamage(this.SendDamage, 4);
            }
            this.Health = this.Health - 128;
        }
        if (col.gameObject.name.Contains("Z#1"))
        {
            if (col.gameObject.name.Contains("TFC1") && (this.Health > 0))
            {
                DamageCounter.instance.ShowDamage(1, 4);
            }
            this.Health = this.Health - 1;
        }
        if (col.gameObject.name.Contains("Z#2"))
        {
            if (col.gameObject.name.Contains("TFC1") && (this.Health > 0))
            {
                this.ThisDamage = 2;
                this.SendDamage = 2;
                if (this.Health < 3)
                {
                    this.ThisDamage = this.ThisDamage - this.Health;
                    this.SendDamage = this.SendDamage - this.ThisDamage;
                }
                DamageCounter.instance.ShowDamage(this.SendDamage, 4);
            }
            this.Health = this.Health - 2;
        }
        if (col.gameObject.name.Contains("Z#3"))
        {
            if (col.gameObject.name.Contains("TFC1") && (this.Health > 0))
            {
                this.ThisDamage = 4;
                this.SendDamage = 4;
                if (this.Health < 5)
                {
                    this.ThisDamage = this.ThisDamage - this.Health;
                    this.SendDamage = this.SendDamage - this.ThisDamage;
                }
                DamageCounter.instance.ShowDamage(this.SendDamage, 4);
            }
            this.Health = this.Health - 4;
        }
        if (col.gameObject.name.Contains("Z#4"))
        {
            if (col.gameObject.name.Contains("TFC1") && (this.Health > 0))
            {
                this.ThisDamage = 16;
                this.SendDamage = 16;
                if (this.Health < 17)
                {
                    this.ThisDamage = this.ThisDamage - this.Health;
                    this.SendDamage = this.SendDamage - this.ThisDamage;
                }
                DamageCounter.instance.ShowDamage(this.SendDamage, 4);
            }
            this.Health = this.Health - 16;
        }
        if (col.gameObject.name.Contains("Z#5"))
        {
            if (col.gameObject.name.Contains("TFC1") && (this.Health > 0))
            {
                this.ThisDamage = 32;
                this.SendDamage = 32;
                if (this.Health < 33)
                {
                    this.ThisDamage = this.ThisDamage - this.Health;
                    this.SendDamage = this.SendDamage - this.ThisDamage;
                }
                DamageCounter.instance.ShowDamage(this.SendDamage, 4);
            }
            this.Health = this.Health - 32;
        }
        if ((this.Health < 1) && (this.once == false))
        {
            this.once = true;
            GameObject TheThing = UnityEngine.Object.Instantiate(this.BrokenSound, this.transform.position, this.transform.rotation);
            TheThing.transform.parent = this.gameObject.transform;
            UnityEngine.Object.Destroy(this.JointScript);
            this.AberrantAI.GetComponent<AberrantCruiserAI>().Damaged = true;
            this.AberrantAI.GetComponent<AberrantCruiserAI>().Broken();
            i = 0;
            while (i < this.WhatToDestroy.Length)
            {
                UnityEngine.Object.Destroy(this.WhatToDestroy[i].gameObject);
                i++;
            }
        }
    }

    public virtual void InduceDamage()
    {
        this.StartCoroutine(this.Damager());
    }

    public virtual IEnumerator Damager()
    {
        int i = 0;
        if ((this.Health < 1) && (this.once == false))
        {
            this.once = true;
            yield return new WaitForSeconds(2);
            GameObject TheThing = UnityEngine.Object.Instantiate(this.BrokenSound, this.transform.position, this.transform.rotation);
            TheThing.transform.parent = this.gameObject.transform;
            UnityEngine.Object.Destroy(this.JointScript);
            this.AberrantAI.GetComponent<AberrantCruiserAI>().Damaged = true;
            this.AberrantAI.GetComponent<AberrantCruiserAI>().Broken();
            i = 0;
            while (i < this.WhatToDestroy.Length)
            {
                UnityEngine.Object.Destroy(this.WhatToDestroy[i].gameObject);
                i++;
            }
        }
    }

    public virtual void Start()
    {
        this.InvokeRepeating("InduceDamage", 5, 1);
    }

    public AberrantCruiserWeakspot()
    {
        this.Health = 32;
    }

}