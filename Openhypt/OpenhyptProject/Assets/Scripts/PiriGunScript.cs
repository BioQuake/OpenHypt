using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PiriGunScript : MonoBehaviour
{
    public bool useReload;
    public bool useAudio;
    public bool CanLoop;
    public bool CanFire;
    public bool GunLoaded;
    public bool Reloading;
    public bool CanHeatUp;
    public bool CanOverheat;
    public bool Overheated;
    public ParticleSystem OverheatFX;
    public bool ParentedPrefab;
    public int AmmoSelected;
    public int AmmoLoaded;
    public float SettleTime;
    public float UnloadTime;
    public float ReloadTime;
    public float ReadyTime;
    public float ForePauseTime;
    public GameObject ForePauseSound;
    public float SpinAcceleration;
    public float BarrelSpinSpeed;
    public float StaticSpinSpeed;
    public Transform BarrelTF;
    public GameObject AniPart;
    public GameObject EmptyMag;
    public GameObject FullMag;
    public int ShotsFired;
    public int ShotsInMag;
    public string ReloadAni;
    public string FireAni;
    public float cooldown;
    public float Heat;
    public float MaxHeat;
    public float HeatGained;
    public float CoolGained;
    public float Spread;
    public float MinSpread;
    public float MaxSpread;
    public LayerMask targetLayers;
    public GameObject firePrefab;
    public GameObject firePrefab2;
    public GameObject firePrefab3;
    public GameObject Ammo1Mesh;
    public GameObject Ammo2Mesh;
    public Transform barrel;
    public Transform barrelLocation;
    public Transform UserTF;
    public int GunWeight;
    public float Recoil;
    public float RecoilRecover;
    public float MaxRecoil;
    public float RecoilBleed;
    public float RecoilBleedRecover;
    public float MaxRecoilBleed;
    public bool Recoiling;
    public float Proddy1;
    public float Proddy2;
    public bool Locked;
    private float CurrentRecoil;
    private float CurrentRecoilBleed;
    private float startTime;
    private PiriUpperBodyController piriController;
    public virtual void Start()
    {
        GameObject torso = PlayerInformation.instance.PiriTorso;
        this.piriController = (PiriUpperBodyController) torso.GetComponent(typeof(PiriUpperBodyController));
        this.UserTF = PlayerInformation.instance.PiriTorso.transform;
        this.StaticSpinSpeed = this.BarrelSpinSpeed;
        this.Spread = this.MinSpread;
    }

    public virtual void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            this.Recoiling = false;
            this.CurrentRecoil = 0;
        }
        if (Input.GetMouseButtonDown(1))
        {
            PiriUpperBodyController.Weight = this.GunWeight;
        }
        if (this.useAudio)
        {
            if (this.GetComponent<AudioSource>().isPlaying)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if ((((Time.time - this.startTime) >= this.cooldown) && this.CanFire) && !this.Overheated)
                    {
                        this.GetComponent<AudioSource>().Stop();
                    }
                }
            }
        }
        if (((Input.GetMouseButton(1) && (CameraScript.InInterface == false)) && PiriUpperBodyController.IsAiming) && PiriUpperBodyController.CanShoot)
        {
            if (this.ForePauseTime > 0.1f)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    this.BarrelSpinSpeed = 0.2f;
                    this.CanFire = false;
                    this.StartCoroutine(this.ForePause());
                }
            }
            if (Input.GetMouseButton(0))
            {
                if (!this.CanOverheat)
                {
                    if (this.BarrelSpinSpeed > 0.1f)
                    {

                        {
                            float _2674 = this.BarrelTF.localEulerAngles.y + this.BarrelSpinSpeed;
                            Vector3 _2675 = this.BarrelTF.localEulerAngles;
                            _2675.y = _2674;
                            this.BarrelTF.localEulerAngles = _2675;
                        }
                    }
                    if (((((Time.time - this.startTime) >= this.cooldown) && this.CanFire) && !this.Reloading) && !this.Overheated)
                    {
                        this.startTime = Time.time;
                        this.Shoot();
                        if (this.useAudio)
                        {
                            if (!this.CanLoop)
                            {
                                this.GetComponent<AudioSource>().Play();
                            }
                            else
                            {
                                this.GetComponent<AudioSource>().loop = true;
                                if (!this.GetComponent<AudioSource>().isPlaying)
                                {
                                    this.GetComponent<AudioSource>().Play();
                                }
                            }
                        }
                        if (this.useReload)
                        {
                            this.ShotsFired = this.ShotsFired + 1;
                        }
                        if (!string.IsNullOrEmpty(this.FireAni))
                        {
                            this.AniPart.GetComponent<Animation>().CrossFade(this.FireAni);
                        }
                    }
                }
                else
                {
                    if (this.BarrelSpinSpeed > 0.1f)
                    {

                        {
                            float _2676 = this.BarrelTF.localEulerAngles.y + this.BarrelSpinSpeed;
                            Vector3 _2677 = this.BarrelTF.localEulerAngles;
                            _2677.y = _2676;
                            this.BarrelTF.localEulerAngles = _2677;
                        }
                    }
                    if ((((Time.time - this.startTime) >= this.cooldown) && this.CanFire) && !this.Reloading)
                    {
                        if (!this.Overheated)
                        {
                            this.startTime = Time.time;
                            this.Shoot();
                            if (this.useAudio)
                            {
                                if (!this.CanLoop)
                                {
                                    this.GetComponent<AudioSource>().Play();
                                }
                                else
                                {
                                    this.GetComponent<AudioSource>().loop = true;
                                    if (!this.GetComponent<AudioSource>().isPlaying)
                                    {
                                        this.GetComponent<AudioSource>().Play();
                                    }
                                }
                            }
                            if (this.useReload)
                            {
                                this.ShotsFired = this.ShotsFired + 1;
                            }
                            if (!string.IsNullOrEmpty(this.FireAni))
                            {
                                this.AniPart.GetComponent<Animation>().CrossFade(this.FireAni);
                            }
                        }
                        else
                        {
                            if (this.useAudio)
                            {
                                if (this.CanLoop)
                                {
                                    if (this.GetComponent<AudioSource>().isPlaying)
                                    {
                                        this.GetComponent<AudioSource>().loop = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (this.useAudio)
                {
                    if (this.CanLoop)
                    {
                        if (this.GetComponent<AudioSource>().isPlaying)
                        {
                            this.GetComponent<AudioSource>().loop = false;
                        }
                    }
                }
            }
        }
        else
        {
            if (this.useAudio)
            {
                if (this.CanLoop)
                {
                    if (this.GetComponent<AudioSource>().isPlaying)
                    {
                        this.GetComponent<AudioSource>().loop = false;
                    }
                }
            }
        }
        if (Input.GetMouseButton(1) && (CameraScript.InInterface == false))
        {
            if (ItemContainer.PiriContainer.ContainerItems.Count != 0)
            {
                if (Input.GetKey("1"))
                {
                    if (this.AmmoSelected != 1)
                    {
                        this.AmmoSelected = 1;
                        if (!this.Reloading)
                        {
                            this.CanFire = false;
                        }
                        if (this.GunLoaded && !this.Reloading)
                        {
                            this.ShotsFired = 0;
                            this.CanFire = false;
                            this.Reloading = true;
                            this.StartCoroutine(this.Switch());
                        }
                    }
                }
                else
                {
                    if (Input.GetKey("2") && InventoryManager.CanUseGunAmmo(ItemContainer.PiriContainer.ContainerItems[0].ID.ToString(), 2))
                    {
                        this.AmmoSelected = 2;
                        if (!this.Reloading)
                        {
                            this.CanFire = false;
                        }
                        if (this.GunLoaded && !this.Reloading)
                        {
                            this.ShotsFired = 0;
                            this.CanFire = false;
                            this.Reloading = true;
                            this.StartCoroutine(this.Switch());
                        }
                    }
                }
            }
        }
        if ((Input.GetMouseButton(1) && (CameraScript.InInterface == false)) && this.useReload)
        {
            if ((this.ShotsInMag == this.ShotsFired) && !this.Reloading)
            {
                this.FullMag.gameObject.SetActive(false);
                this.EmptyMag.gameObject.SetActive(true);
                this.GunLoaded = false;
                this.CanFire = false;
            }
            if (!this.GunLoaded && !this.Reloading)
            {
                this.Reloading = true;
                this.StartCoroutine(this.Reload());
            }
        }
        if ((Input.GetMouseButtonUp(1) && (CameraScript.InInterface == false)) && this.Reloading)
        {
            this.StopAllCoroutines();
            this.AniPart.GetComponent<Animation>().Rewind();
            this.Reloading = false;
            this.StartCoroutine(this.RewindAni());
        }
        if (this.ForePauseTime < 0.1f)
        {
            if (Input.GetMouseButtonDown(1) && this.GunLoaded)
            {
                this.CanFire = true;
            }
        }
    }

    public virtual IEnumerator ForePause()
    {
        GameObject TheThing0 = UnityEngine.Object.Instantiate(this.ForePauseSound, this.transform.position, this.transform.rotation);
        TheThing0.transform.parent = this.gameObject.transform;
        yield return new WaitForSeconds(this.ForePauseTime);
        if (Input.GetMouseButton(0))
        {
            if (this.GetComponent<AudioSource>().isPlaying)
            {
                this.GetComponent<AudioSource>().Stop();
            }
            this.CanFire = true;
        }
    }

    public virtual IEnumerator RewindAni()
    {
        yield return new WaitForSeconds(0.01f);
        this.AniPart.GetComponent<Animation>().Stop();
    }

    public virtual IEnumerator Reload()
    {
        yield return new WaitForSeconds(this.SettleTime);
        this.AniPart.GetComponent<Animation>().Play(this.ReloadAni);
        yield return new WaitForSeconds(this.UnloadTime);
        this.FullMag.gameObject.SetActive(true);
        this.EmptyMag.gameObject.SetActive(false);
        this.ShotsFired = 0;
        yield return new WaitForSeconds(this.ReloadTime);
        this.Reloading = false;
        this.GunLoaded = true;
        yield return new WaitForSeconds(this.ReadyTime);
        this.CanFire = true;
    }

    public virtual IEnumerator Switch()
    {
        yield return new WaitForSeconds(this.SettleTime);
        this.AniPart.GetComponent<Animation>().Play(this.ReloadAni);
        yield return new WaitForSeconds(this.UnloadTime);
        switch (this.AmmoSelected)
        {
            case 1:
                this.AmmoLoaded = 1;
                this.Ammo1Mesh.gameObject.SetActive(true);
                this.Ammo2Mesh.gameObject.SetActive(false);
                break;
            case 2:
                this.AmmoLoaded = 2;
                this.Ammo2Mesh.gameObject.SetActive(true);
                this.Ammo1Mesh.gameObject.SetActive(false);
                break;
        }
        yield return new WaitForSeconds(this.ReloadTime);
        this.Reloading = false;
        this.GunLoaded = true;
        yield return new WaitForSeconds(this.ReadyTime);
        this.CanFire = true;
    }

    public virtual void Shoot()
    {
        if ((this.Heat < 10) && !this.CanOverheat)
        {
            this.Heat = this.Heat + this.HeatGained;
        }
        if (this.CanOverheat)
        {
            this.Heat = this.Heat + this.HeatGained;
        }
        if (this.Recoil > 0)
        {
            this.Recoiling = true;
            if (this.CurrentRecoil < this.MaxRecoil)
            {
                this.CurrentRecoil = this.CurrentRecoil + this.Recoil;
            }
        }
        if (this.RecoilBleed > 0)
        {
            if (this.CurrentRecoilBleed < this.MaxRecoilBleed)
            {
                this.CurrentRecoilBleed = this.CurrentRecoilBleed + this.RecoilBleed;
            }
        }
        if (!this.ParentedPrefab)
        {
            switch (this.AmmoLoaded)
            {
                case 1:
                    UnityEngine.Object.Instantiate(this.firePrefab, this.barrelLocation.position, this.barrelLocation.rotation);
                    break;
                case 2:
                    UnityEngine.Object.Instantiate(this.firePrefab2, this.barrelLocation.position, this.barrelLocation.rotation);
                    break;
            }
        }
        else
        {
            GameObject TheThing = UnityEngine.Object.Instantiate(this.firePrefab, this.barrelLocation.position, this.barrelLocation.rotation);
            TheThing.transform.parent = this.gameObject.transform;
        }
        this.StartCoroutine(this.piriController.Recoil());
        if (this.CanHeatUp)
        {
            this.barrel.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (this.Recoiling)
        {
            this.UserTF.Rotate(this.CurrentRecoil, 0, 0);
        }
    }

    public virtual void FixedUpdate()
    {
        if (this.BarrelSpinSpeed > 0.1f)
        {
            this.Proddy1 = 180 - (this.BarrelSpinSpeed * 2);
            this.Proddy2 = 360 - (this.BarrelSpinSpeed * 2);
            if (((Input.GetMouseButton(1) && (CameraScript.InInterface == false)) && PiriUpperBodyController.IsAiming) && PiriUpperBodyController.CanShoot)
            {
                if (Input.GetMouseButton(0))
                {
                    this.Locked = false;
                    if (this.BarrelSpinSpeed < this.StaticSpinSpeed)
                    {
                        this.BarrelSpinSpeed = this.BarrelSpinSpeed + this.SpinAcceleration;
                    }

                    {
                        float _2678 = this.BarrelTF.localEulerAngles.y + this.BarrelSpinSpeed;
                        Vector3 _2679 = this.BarrelTF.localEulerAngles;
                        _2679.y = _2678;
                        this.BarrelTF.localEulerAngles = _2679;
                    }
                }
                else
                {
                    if (this.BarrelSpinSpeed > (this.SpinAcceleration * 10))
                    {
                        this.BarrelSpinSpeed = this.BarrelSpinSpeed - this.SpinAcceleration;
                    }
                    else
                    {
                        this.BarrelSpinSpeed = this.SpinAcceleration * 10;
                    }
                    if (this.BarrelSpinSpeed > (this.SpinAcceleration * 10))
                    {

                        {
                            float _2680 = this.BarrelTF.localEulerAngles.y + this.BarrelSpinSpeed;
                            Vector3 _2681 = this.BarrelTF.localEulerAngles;
                            _2681.y = _2680;
                            this.BarrelTF.localEulerAngles = _2681;
                        }
                    }
                    else
                    {
                        if (!this.Locked)
                        {
                            if (this.BarrelTF.localEulerAngles.y < 180)
                            {
                                if (this.BarrelTF.localEulerAngles.y > this.Proddy1)
                                {

                                    {
                                        int _2682 = 180;
                                        Vector3 _2683 = this.BarrelTF.localEulerAngles;
                                        _2683.y = _2682;
                                        this.BarrelTF.localEulerAngles = _2683;
                                    }
                                    this.Locked = true;
                                }
                                if (!this.Locked)
                                {

                                    {
                                        float _2684 = this.BarrelTF.localEulerAngles.y + this.BarrelSpinSpeed;
                                        Vector3 _2685 = this.BarrelTF.localEulerAngles;
                                        _2685.y = _2684;
                                        this.BarrelTF.localEulerAngles = _2685;
                                    }
                                }
                            }
                            if (this.BarrelTF.localEulerAngles.y > 180)
                            {
                                if (this.BarrelTF.localEulerAngles.y > this.Proddy2)
                                {

                                    {
                                        int _2686 = 0;
                                        Vector3 _2687 = this.BarrelTF.localEulerAngles;
                                        _2687.y = _2686;
                                        this.BarrelTF.localEulerAngles = _2687;
                                    }
                                    this.Locked = true;
                                }
                                if (!this.Locked)
                                {

                                    {
                                        float _2688 = this.BarrelTF.localEulerAngles.y + this.BarrelSpinSpeed;
                                        Vector3 _2689 = this.BarrelTF.localEulerAngles;
                                        _2689.y = _2688;
                                        this.BarrelTF.localEulerAngles = _2689;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (this.BarrelSpinSpeed > (this.SpinAcceleration * 10))
                {
                    this.BarrelSpinSpeed = this.BarrelSpinSpeed - this.SpinAcceleration;
                }
                else
                {
                    this.BarrelSpinSpeed = this.SpinAcceleration * 10;
                }
                if (this.BarrelSpinSpeed > (this.SpinAcceleration * 10))
                {

                    {
                        float _2690 = this.BarrelTF.localEulerAngles.y + this.BarrelSpinSpeed;
                        Vector3 _2691 = this.BarrelTF.localEulerAngles;
                        _2691.y = _2690;
                        this.BarrelTF.localEulerAngles = _2691;
                    }
                }
                else
                {
                    if (!this.Locked)
                    {
                        if (this.BarrelTF.localEulerAngles.y < 180)
                        {
                            if (this.BarrelTF.localEulerAngles.y > this.Proddy1)
                            {

                                {
                                    int _2692 = 180;
                                    Vector3 _2693 = this.BarrelTF.localEulerAngles;
                                    _2693.y = _2692;
                                    this.BarrelTF.localEulerAngles = _2693;
                                }
                                this.Locked = true;
                            }
                            if (!this.Locked)
                            {

                                {
                                    float _2694 = this.BarrelTF.localEulerAngles.y + this.BarrelSpinSpeed;
                                    Vector3 _2695 = this.BarrelTF.localEulerAngles;
                                    _2695.y = _2694;
                                    this.BarrelTF.localEulerAngles = _2695;
                                }
                            }
                        }
                        if (this.BarrelTF.localEulerAngles.y > 180)
                        {
                            if (this.BarrelTF.localEulerAngles.y > this.Proddy2)
                            {

                                {
                                    int _2696 = 0;
                                    Vector3 _2697 = this.BarrelTF.localEulerAngles;
                                    _2697.y = _2696;
                                    this.BarrelTF.localEulerAngles = _2697;
                                }
                                this.Locked = true;
                            }
                            if (!this.Locked)
                            {

                                {
                                    float _2698 = this.BarrelTF.localEulerAngles.y + this.BarrelSpinSpeed;
                                    Vector3 _2699 = this.BarrelTF.localEulerAngles;
                                    _2699.y = _2698;
                                    this.BarrelTF.localEulerAngles = _2699;
                                }
                            }
                        }
                    }
                }
            }
        }
        if (this.CanHeatUp)
        {
            if (this.CanOverheat)
            {
                if (this.OverheatFX)
                {
                    if (!this.Overheated)
                    {
                        if (this.Heat > 16)
                        {
                            this.OverheatFX.emissionRate = this.Heat;
                        }
                        else
                        {
                            this.OverheatFX.emissionRate = 0;
                        }
                    }
                    else
                    {
                        this.OverheatFX.emissionRate = this.Heat;
                    }
                }
                if ((this.Heat > this.MaxHeat) && !this.Overheated)
                {
                    this.Overheated = true;
                    this.Recoiling = false;
                }
                if ((this.Heat < 1) && this.Overheated)
                {
                    this.Overheated = false;
                }
            }
            if (this.CurrentRecoil > 0)
            {
                this.CurrentRecoil = this.CurrentRecoil - this.RecoilRecover;
            }
            if (this.CurrentRecoilBleed > 0)
            {
                this.CurrentRecoilBleed = this.CurrentRecoilBleed - this.RecoilBleedRecover;
            }
            PiriUpperBodyController.Weight = (int) (this.GunWeight - this.CurrentRecoilBleed);
            if (this.Heat > 0)
            {
                this.Heat = this.Heat - this.CoolGained;
            }
            if (this.Heat < 1)
            {
                this.barrel.transform.localRotation = Quaternion.Euler(0, 0, 0);
                this.Heat = 0;
            }
            if ((this.Heat > 5) && (this.Spread < this.MaxSpread))
            {
                this.Spread = this.Spread + 0.1f;
            }
            if ((this.Heat < 10) && (this.Spread > this.MinSpread))
            {
                this.Spread = this.Spread - 0.1f;
            }
            if (this.barrel.transform.localRotation.x < 0.02f)
            {
                this.barrel.transform.Rotate(Vector3.right * Random.Range(0, this.Spread));
            }
            if (this.barrel.transform.localRotation.x > -0.02f)
            {
                this.barrel.transform.Rotate(Vector3.left * Random.Range(0, this.Spread));
            }
            if (this.barrel.transform.localRotation.z < 0.02f)
            {
                this.barrel.transform.Rotate(Vector3.forward * Random.Range(0, this.Spread));
            }
            if (this.barrel.transform.localRotation.z > -0.02f)
            {
                this.barrel.transform.Rotate(Vector3.back * Random.Range(0, this.Spread));
            }
        }
        else
        {
            this.Spread = this.MaxSpread;
            if (this.barrel.transform.localRotation.x < 0.02f)
            {
                this.barrel.transform.Rotate(Vector3.right * Random.Range(0, this.Spread));
            }
            if (this.barrel.transform.localRotation.x > -0.02f)
            {
                this.barrel.transform.Rotate(Vector3.left * Random.Range(0, this.Spread));
            }
            if (this.barrel.transform.localRotation.z < 0.02f)
            {
                this.barrel.transform.Rotate(Vector3.forward * Random.Range(0, this.Spread));
            }
            if (this.barrel.transform.localRotation.z > -0.02f)
            {
                this.barrel.transform.Rotate(Vector3.back * Random.Range(0, this.Spread));
            }
            this.Spread = this.MinSpread;
        }
    }

    public PiriGunScript()
    {
        this.useAudio = true;
        this.AmmoSelected = 1;
        this.AmmoLoaded = 1;
        this.SettleTime = 1;
        this.UnloadTime = 1;
        this.ReloadTime = 3;
        this.ReadyTime = 0.5f;
        this.SpinAcceleration = 0.2f;
        this.ShotsInMag = 1;
        this.cooldown = 0.15f;
        this.MaxHeat = 50;
        this.HeatGained = 2;
        this.CoolGained = 1;
        this.MaxSpread = 5;
        this.GunWeight = 20;
    }

}