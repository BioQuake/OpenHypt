using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class NewgunControllerTurret : MonoBehaviour
{
    public GameObject Aimer;
    public GameObject HatchAniObject;
    public string Closing;
    public string Opening;
    public string GunForward;
    public string GunBack;
    public GameObject ActivateSound;
    public GameObject DeactivateSound;
    public GameObject GunBase;
    public GameObject NewGunBase;
    public GameObject AmmoBay;
    public GameObject Ammunition;
    public Transform ShockwaveLocation;
    public Transform BarrelLocation;
    public GameObject Shockwave;
    public GameObject RecoilAnimationObject;
    public string RecoilAnimationName;
    public bool Broken;
    public bool CanFire;
    public bool IsShooting;
    public bool IsAnimating;
    public bool IsOut;
    public float GunCooldown;
    private float xStartTime;
    private float gunTimer;
    public virtual void Update()
    {
        if (this.Broken)
        {
            return;
        }
        if (WorldInformation.playerCar == this.gameObject.name)
        {
            if ((Input.GetKey("6") && (this.IsAnimating == false)) && !this.IsShooting)
            {
                this.StartCoroutine(this.GunBoolean());
            }
            if (Input.GetKey("5"))
            {
                this.Shoot();
            }
        }
    }

    public virtual IEnumerator GunBoolean()
    {
        if ((this.IsAnimating == false) && !this.IsOut)
        {
            HingeJoint hinge = this.GunBase.GetComponent<HingeJoint>();
            this.StartCoroutine(this.Animating());
            this.HatchAniObject.GetComponent<Animation>().Play(this.Opening);
            yield return new WaitForSeconds(0.2f);
            ConfigurableJoint Cjoint = this.NewGunBase.GetComponent<ConfigurableJoint>();
            Cjoint.targetPosition = new Vector3(0, 0, 0);
            yield return new WaitForSeconds(0.6f);
            this.ActivateSound.GetComponent<AudioSource>().Play();

            {
                int _468 = 0;
                JointSpring _469 = hinge.spring;
                _469.targetPosition = _468;
            }
            yield return new WaitForSeconds(0.6f);
            this.RecoilAnimationObject.GetComponent<Animation>().Play(this.GunForward);

            {
                int _470 = 0;
                JointSpring _471 = hinge.spring;
                _471.spring = _470;
            }
            this.Aimer.GetComponent<TurretAim>().Activated = true;

            {
                int _472 = -15;
                JointLimits _473 = hinge.limits;
                _473.max = _472;
            }
            yield return new WaitForSeconds(0.05f);

            {
                int _474 = -10;
                JointLimits _475 = hinge.limits;
                _475.max = _474;
            }
            yield return new WaitForSeconds(0.05f);

            {
                int _476 = -5;
                JointLimits _477 = hinge.limits;
                _477.max = _476;
            }
            yield return new WaitForSeconds(0.05f);

            {
                int _478 = 0;
                JointLimits _479 = hinge.limits;
                _479.max = _478;
            }
            yield return new WaitForSeconds(0.05f);
            this.IsOut = true;
            this.CanFire = true;
        }
        if ((this.IsAnimating == false) && this.IsOut)
        {
            HingeJoint hinge = this.GunBase.GetComponent<HingeJoint>();
            this.StartCoroutine(this.Animating());
            this.IsOut = false;
            this.CanFire = false;

            {
                int _480 = -90;
                JointLimits _481 = hinge.limits;
                _481.max = _480;
            }
            this.Aimer.GetComponent<TurretAim>().Activated = false;
            this.RecoilAnimationObject.GetComponent<Animation>().Play(this.GunBack);
            this.DeactivateSound.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(0.4f);

            {
                float _482 = 0.3f;
                JointSpring _483 = hinge.spring;
                _483.spring = _482;
            }

            {
                int _484 = -90;
                JointSpring _485 = hinge.spring;
                _485.targetPosition = _484;
            }
            yield return new WaitForSeconds(0.8f);
            ConfigurableJoint Cjoint = this.NewGunBase.GetComponent<ConfigurableJoint>();
            Cjoint.targetPosition = new Vector3(0, 0, -3);
            this.HatchAniObject.GetComponent<Animation>().Play(this.Closing);
        }
    }

    public virtual IEnumerator Animating()
    {
        this.IsAnimating = true;
        yield return new WaitForSeconds(3);
        this.IsAnimating = false;
    }

    public virtual IEnumerator Shooting()
    {
        this.IsShooting = true;
        yield return new WaitForSeconds(3);
        this.IsShooting = false;
    }

    public virtual void Shoot()
    {
        if (((Mathf.Abs(this.xStartTime - Time.time) >= this.gunTimer) && (this.CanFire == true)) && this.IsOut)
        {
            this.xStartTime = Time.time;
            this.gunTimer = this.GunCooldown;
            this.gunShot();
            this.StartCoroutine(this.Shooting());
        }
    }

    public virtual void gunShot()
    {
        GameObject TheThing = UnityEngine.Object.Instantiate(this.Ammunition, this.BarrelLocation.position, this.BarrelLocation.rotation);
        TheThing.transform.parent = this.RecoilAnimationObject.transform;
        this.RecoilAnimationObject.GetComponent<Animation>().Play(this.RecoilAnimationName);
        this.AmmoBay.GetComponent<AmmoBay>().ExpendedRound(1);
    }

    public NewgunControllerTurret()
    {
        this.RecoilAnimationName = "Name";
        this.GunCooldown = 3;
    }

}