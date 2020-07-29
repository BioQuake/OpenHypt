using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AberrantGyro : MonoBehaviour
{
    public float force;
    public float AimForce;
    public Transform AimTarget;
    public float TurnForce;
    public float Multiplier;
    public float offset;
    public bool BigGyro;
    public int Health;
    public int ThisDamage;
    public int SendDamage;
    public string AberrantAIName;
    public GameObject AberrantAI;
    public GameObject BrokenSound;
    public bool Broken;
    public virtual void OnCollisionEnter(Collision col)
    {
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
        if ((!this.BigGyro && (this.Health < 1)) && !this.Broken)
        {
            GameObject TheThing = UnityEngine.Object.Instantiate(this.BrokenSound, this.transform.position, this.BrokenSound.transform.rotation);
            TheThing.transform.parent = this.gameObject.transform;
            if (this.AberrantAI.GetComponent(this.AberrantAIName) != null)
            {
                //this.AberrantAI.GetComponent(this.AberrantAIName).GyroOff = true;
                ReflectionUtils.SetField(AberrantAI.GetComponent(AberrantAIName), AberrantAIName, "GyroOff", true);
            }
            this.GetComponent<Rigidbody>().angularDrag = 0;
            this.Broken = true;
            this.transform.parent = null;
            UnityEngine.Object.Destroy(this);
        }
    }

    public virtual void FixedUpdate()
    {
        if (this.Broken)
        {
            return;
        }
        this.GetComponent<Rigidbody>().AddTorque((this.transform.up * this.TurnForce) * this.Multiplier);
        if (this.BigGyro && this.AimTarget)
        {
            this.GetComponent<Rigidbody>().AddForceAtPosition((this.AimTarget.transform.position - this.transform.position).normalized * this.AimForce, this.transform.forward * this.offset);
            this.GetComponent<Rigidbody>().AddForceAtPosition((this.AimTarget.transform.position - this.transform.position).normalized * -this.AimForce, -this.transform.forward * this.offset);
        }
        this.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.up * this.force, this.transform.up * this.offset);
        this.GetComponent<Rigidbody>().AddForceAtPosition(-Vector3.up * this.force, -this.transform.up * this.offset);
    }

    public virtual void OnJointBreak(float breakForce)
    {
        if (this.AberrantAI.GetComponent(this.AberrantAIName) != null)
        {
            GameObject TheThing = UnityEngine.Object.Instantiate(this.BrokenSound, this.transform.position, this.BrokenSound.transform.rotation);

            TheThing.transform.parent = this.gameObject.transform;
            //this.AberrantAI.GetComponent(this.AberrantAIName).GyroOff = true;
            ReflectionUtils.SetField(AberrantAI.GetComponent(AberrantAIName), AberrantAIName, "GyroOff", true);
            this.GetComponent<Rigidbody>().angularDrag = 0;
            this.Broken = true;
            this.transform.parent = null;
            UnityEngine.Object.Destroy(this);
        }
    }

    public AberrantGyro()
    {
        this.force = 10f;
        this.AimForce = 10f;
        this.Multiplier = 1;
        this.offset = 1f;
        this.Health = 3;
        this.AberrantAIName = "AberrantAI";
    }

}