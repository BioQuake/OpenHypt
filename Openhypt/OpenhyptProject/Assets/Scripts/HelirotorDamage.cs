using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class HelirotorDamage : MonoBehaviour
{
    public int Health;
    public int ThisDamage;
    public int SendDamage;
    public bool Invincible;
    private bool once;
    private bool onceler;
    public GameObject BrokenSound;
    public GameObject BrokenishSound;
    public GameObject RemoveThreat;
    public GameObject MainDamage;
    public GameObject Rotator;
    public TorqueScript1 TorqueScript;
    public GameObject Gyro;
    public HelirotorAI HelirotorEye;
    public ConfigurableJoint ConJoint;
    public GameObject SwingNoise;
    public GameObject EngineNoise;
    public GameObject[] LimbSections;
    public GameObject TheThingie;
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
        if (((this.Health < 50) && (this.onceler == false)) && (this.once == false))
        {
            this.TheThingie = UnityEngine.Object.Instantiate(this.BrokenishSound, this.transform.position, this.BrokenSound.transform.rotation);
            this.TheThingie.transform.parent = this.gameObject.transform;
            this.Gyro.GetComponent<Simplehover>().Multiplier = 2;
            UnityEngine.Object.Destroy(this.SwingNoise);
            this.onceler = true;
        }
        if ((this.Health < 1) && (this.once == false))
        {
            this.StartCoroutine(this.Damaged());
        }
    }

    public virtual IEnumerator Damaged()
    {
        int i = 0;
        if (this.once || this.Invincible)
        {
            yield break;
        }
        this.once = true;
        AgrianNetwork.instance.RedAlertTime = 120;
        AgrianNetwork.instance.PriorityWaypoint.transform.position = this.transform.position;
        GameObject TheThing = UnityEngine.Object.Instantiate(this.BrokenSound, this.transform.position, this.BrokenSound.transform.rotation);
        TheThing.transform.parent = this.gameObject.transform;
        this.GetComponent<Rigidbody>().drag = 0.05f;
        this.MainDamage.GetComponent<Rigidbody>().drag = 0.05f;
        //this.HelirotorEye.Jammed = true;

        {
            int _1998 = 0;
            JointDrive _1999 = this.ConJoint.angularXDrive;
            _1999.positionSpring = _1998;
            this.ConJoint.angularXDrive = _1999;
        }

        {
            int _2000 = 0;
            JointDrive _2001 = ((ConfigurableJoint) this.ConJoint.GetComponent(typeof(ConfigurableJoint))).angularYZDrive;
            _2001.positionSpring = _2000;
            ((ConfigurableJoint) this.ConJoint.GetComponent(typeof(ConfigurableJoint))).angularYZDrive = _2001;
        }

        {
            int _2002 = 0;
            JointDrive _2003 = ((ConfigurableJoint) this.ConJoint.GetComponent(typeof(ConfigurableJoint))).angularXDrive;
            _2003.positionDamper = _2002;
            ((ConfigurableJoint) this.ConJoint.GetComponent(typeof(ConfigurableJoint))).angularXDrive = _2003;
        }

        {
            int _2004 = 0;
            JointDrive _2005 = ((ConfigurableJoint) this.ConJoint.GetComponent(typeof(ConfigurableJoint))).angularYZDrive;
            _2005.positionDamper = _2004;
            ((ConfigurableJoint) this.ConJoint.GetComponent(typeof(ConfigurableJoint))).angularYZDrive = _2005;
        }
        UnityEngine.Object.Destroy(this.RemoveThreat);
        UnityEngine.Object.Destroy(this.TheThingie);
        UnityEngine.Object.Destroy(this.Gyro);
        UnityEngine.Object.Destroy(this.SwingNoise);
        UnityEngine.Object.Destroy(this.EngineNoise);
        this.TorqueScript.Power = 900;
        yield return new WaitForSeconds(0.5f);
        this.TorqueScript.Power = 800;
        yield return new WaitForSeconds(0.5f);
        this.TorqueScript.Power = 700;
        yield return new WaitForSeconds(0.5f);
        this.TorqueScript.Power = 600;
        yield return new WaitForSeconds(0.5f);
        this.TorqueScript.Power = 500;
        yield return new WaitForSeconds(0.4f);
        this.TorqueScript.Power = 400;
        yield return new WaitForSeconds(0.3f);
        this.TorqueScript.Power = 300;
        yield return new WaitForSeconds(0.2f);
        this.TorqueScript.Power = 200;
        yield return new WaitForSeconds(0.1f);
        UnityEngine.Object.Destroy(this.Rotator);

        {
            int _2006 = 2;
            JointSpring _2007 = this.GetComponent<HingeJoint>().spring;
            _2007.damper = _2006;
            this.GetComponent<HingeJoint>().spring = _2007;
        }
        this.GetComponent<Rigidbody>().angularDrag = 0.05f;
        //AgrianNetwork.ActivateExecutor = true;
        i = 0;
        while (i < this.LimbSections.Length)
        {

            {
                int _2008 = 5;
                JointDrive _2009 = ((ConfigurableJoint) this.LimbSections[i].GetComponent(typeof(ConfigurableJoint))).angularXDrive;
                _2009.positionSpring = _2008;
                ((ConfigurableJoint) this.LimbSections[i].GetComponent(typeof(ConfigurableJoint))).angularXDrive = _2009;
            }

            {
                int _2010 = 5;
                JointDrive _2011 = ((ConfigurableJoint) this.LimbSections[i].GetComponent(typeof(ConfigurableJoint))).angularYZDrive;
                _2011.positionSpring = _2010;
                ((ConfigurableJoint) this.LimbSections[i].GetComponent(typeof(ConfigurableJoint))).angularYZDrive = _2011;
            }
            this.LimbSections[i].GetComponent<Rigidbody>().drag = 0.1f;
            this.LimbSections[i].GetComponent<Rigidbody>().useGravity = true;
            i++;
        }
    }

    public HelirotorDamage()
    {
        this.Health = 100;
    }

}