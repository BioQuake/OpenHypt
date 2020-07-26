using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class HelirotorOverallDamage : MonoBehaviour
{
    public int Health;
    public int ThisDamage;
    public int SendDamage;
    private bool once;
    public GameObject Rotator;
    public virtual void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name.Contains("TFC1"))
        {
            if (col.gameObject.name.Contains("#1"))
            {
                AgrianNetwork.TC1CriminalLevel = AgrianNetwork.TC1CriminalLevel + 50;
            }
            if (col.gameObject.name.Contains("#2"))
            {
                AgrianNetwork.TC1CriminalLevel = AgrianNetwork.TC1CriminalLevel + 100;
            }
            if (col.gameObject.name.Contains("#3"))
            {
                AgrianNetwork.TC1CriminalLevel = AgrianNetwork.TC1CriminalLevel + 200;
            }
            if (col.gameObject.name.Contains("#4"))
            {
                AgrianNetwork.TC1CriminalLevel = 300;
            }
            if (col.gameObject.name.Contains("#5"))
            {
                AgrianNetwork.TC1CriminalLevel = 300;
            }
            if (col.gameObject.name.Contains("#6"))
            {
                AgrianNetwork.TC1CriminalLevel = 300;
            }
            if (col.gameObject.name.Contains("#7"))
            {
                AgrianNetwork.TC1CriminalLevel = 300;
            }
        }
        if (col.gameObject.name.Contains("TFC6"))
        {
            if (col.gameObject.name.Contains("#1"))
            {
                AgrianNetwork.TC6CriminalLevel = AgrianNetwork.TC6CriminalLevel + 50;
            }
            if (col.gameObject.name.Contains("#2"))
            {
                AgrianNetwork.TC6CriminalLevel = AgrianNetwork.TC6CriminalLevel + 100;
            }
            if (col.gameObject.name.Contains("#3"))
            {
                AgrianNetwork.TC6CriminalLevel = AgrianNetwork.TC6CriminalLevel + 200;
            }
            if (col.gameObject.name.Contains("#4"))
            {
                AgrianNetwork.TC6CriminalLevel = 300;
            }
            if (col.gameObject.name.Contains("#5"))
            {
                AgrianNetwork.TC6CriminalLevel = 300;
            }
            if (col.gameObject.name.Contains("#6"))
            {
                AgrianNetwork.TC6CriminalLevel = 300;
            }
            if (col.gameObject.name.Contains("#7"))
            {
                AgrianNetwork.TC6CriminalLevel = 300;
            }
        }
        if (col.gameObject.name.Contains("TFC7"))
        {
            if (col.gameObject.name.Contains("#1"))
            {
                AgrianNetwork.TC7CriminalLevel = AgrianNetwork.TC7CriminalLevel + 50;
            }
            if (col.gameObject.name.Contains("#2"))
            {
                AgrianNetwork.TC7CriminalLevel = AgrianNetwork.TC7CriminalLevel + 100;
            }
            if (col.gameObject.name.Contains("#3"))
            {
                AgrianNetwork.TC7CriminalLevel = AgrianNetwork.TC7CriminalLevel + 200;
            }
            if (col.gameObject.name.Contains("#4"))
            {
                AgrianNetwork.TC7CriminalLevel = 300;
            }
            if (col.gameObject.name.Contains("#5"))
            {
                AgrianNetwork.TC7CriminalLevel = 300;
            }
            if (col.gameObject.name.Contains("#6"))
            {
                AgrianNetwork.TC7CriminalLevel = 300;
            }
            if (col.gameObject.name.Contains("#7"))
            {
                AgrianNetwork.TC7CriminalLevel = 300;
            }
        }
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
                DamageCounter.instance.ShowDamage(this.SendDamage, 2);
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
                DamageCounter.instance.ShowDamage(this.SendDamage, 2);
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
                DamageCounter.instance.ShowDamage(this.SendDamage, 2);
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
                DamageCounter.instance.ShowDamage(this.SendDamage, 2);
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
                DamageCounter.instance.ShowDamage(this.SendDamage, 2);
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
                DamageCounter.instance.ShowDamage(this.SendDamage, 2);
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
                DamageCounter.instance.ShowDamage(this.SendDamage, 2);
            }
            this.Health = this.Health - 128;
        }
        if (col.gameObject.name.Contains("Z#1"))
        {
            if (col.gameObject.name.Contains("TFC1") && (this.Health > 0))
            {
                DamageCounter.instance.ShowDamage(1, 2);
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
                DamageCounter.instance.ShowDamage(this.SendDamage, 2);
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
                DamageCounter.instance.ShowDamage(this.SendDamage, 2);
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
                DamageCounter.instance.ShowDamage(this.SendDamage, 2);
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
                DamageCounter.instance.ShowDamage(this.SendDamage, 2);
            }
            this.Health = this.Health - 32;
        }
        if ((this.Health < 1) && (this.once == false))
        {
            this.Rotator.GetComponent<HelirotorDamage>().Damaged();
            this.once = true;
        }
    }

    public HelirotorOverallDamage()
    {
        this.Health = 200;
    }

}