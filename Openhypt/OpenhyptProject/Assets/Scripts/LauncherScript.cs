using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class LauncherScript : MonoBehaviour
{
    public Transform Target;
    public GameObject MainBody;
    public bool HasSecondLauncher;
    public bool SecondLauncherPlus;
    public bool SLPlusFiring;
    public Transform SecondLauncherSL1;
    public Transform SecondLauncherSL2;
    public Transform SecondLauncherSL3;
    public Transform SecondLauncherSL4;
    public bool HasThirdLauncher;
    public bool ThirdLauncherPlus;
    public bool TLPlusFiring;
    public Transform ThirdLauncherSL1;
    public Transform ThirdLauncherSL2;
    public Transform ThirdLauncherSL3;
    public Transform ThirdLauncherSL4;
    public Transform ThirdLauncherSL5;
    public Transform ThirdLauncherSL6;
    public Transform ThirdLauncherSL7;
    public Transform ThirdLauncherSL8;
    public GameObject AmmoBay;
    public GameObject AmmoBay2;
    public GameObject AmmoBay3;
    public GameObject Ammunition;
    public GameObject Ammunition2;
    public GameObject Ammunition3;
    public Transform ShockwaveLocation;
    public Transform SpawnLocation;
    public Transform SecondSpawnLocation;
    public Transform ThirdSpawnLocation;
    public Transform FourthSpawnLocation;
    public Transform FifthSpawnLocation;
    public Transform SixthSpawnLocation;
    public Transform SpawnLocation7;
    public Transform SpawnLocation8;
    public Transform SpawnLocation9;
    public Transform SpawnLocation10;
    public Transform SpawnLocation11;
    public Transform SpawnLocation12;
    public MeshRenderer RocketModel1;
    public MeshRenderer RocketModel2;
    public MeshRenderer RocketModel3;
    public MeshRenderer RocketModel4;
    public MeshRenderer RocketModel5;
    public GameObject VentEffect;
    public Transform Vent;
    public Transform Pivot;
    public GameObject Shockwave;
    public GameObject RecoilAnimationObject;
    public string RecoilAnimationName;
    public GameObject DispenseAnimationObject;
    public string DispenseAnimationName;
    public Transform Catapult1;
    public bool Catapult1Go;
    public float Catapult1Speed;
    public float Catapult1EndPoint;
    public Transform Catapult2;
    public bool Catapult2Go;
    public float Catapult2Speed;
    public float Catapult2EndPoint;
    public Transform Catapult3;
    public bool Catapult3Go;
    public float Catapult3Speed;
    public float Catapult3EndPoint;
    public bool Catapult4Go;
    public bool Catapult5Go;
    public AudioSource DispenseAudio;
    public AudioClip DispenseSoundClip;
    public AmmoBay Audlo;
    public bool SDSM;
    public bool pushOut;
    public float pushOutForce;
    public bool AnimatedLauncher;
    public bool AdvancedAnimatedLauncher;
    public bool UsesRevolverMagazine;
    public Transform RevolvingMagazine;
    public bool IsPentagonalRevolver;
    public bool RotToClose;
    public int RevolverRotAmount;
    public bool FireUsingMouse;
    public bool Broken;
    public bool Obscured;
    public bool CanFire;
    public bool CanFire2;
    public bool CanFire3;
    public bool UseTargetingSystem;
    public RayEndPoint TargeterSource;
    public bool CanFireNext;
    public float Cooldown;
    public float Cooldown2;
    public float Cooldown3;
    public bool UseSequence;
    public float SequenceDelay;
    public bool Delayed;
    public float DelayTime;
    public float DelayTime2;
    public float DelayTime3;
    private float lastShot;
    private float lastShot2;
    private float lastShot3;
    public virtual void Start()
    {
        this.InvokeRepeating("Tick", 1, 0.25f);
        this.RevolverRotAmount = 256;
        //if(UsesRevolverMagazine){
        //Catapult1Go = false;
        //}
        this.Target = GameObject.Find("AimPointTarget").gameObject.transform;
    }

    public virtual void FixedUpdate()
    {
        if (this.Broken)
        {
            return;
        }
        if (this.AnimatedLauncher)
        {
            if (!this.UsesRevolverMagazine)
            {
                if (this.Catapult1Go)
                {
                    if (this.Catapult1.localPosition.y > -this.Catapult1EndPoint)
                    {

                        {
                            float _2134 = this.Catapult1.localPosition.y - this.Catapult1Speed;
                            Vector3 _2135 = this.Catapult1.localPosition;
                            _2135.y = _2134;
                            this.Catapult1.localPosition = _2135;
                        }
                        this.Catapult1Speed = this.Catapult1Speed + 0.02f;
                    }
                    else
                    {
                        if (this.Catapult1Go)
                        {
                            this.StartCoroutine(this.Initiate());
                            this.RocketModel1.enabled = false;
                        }
                        this.Catapult1Go = false;
                    }
                }
                if (this.Catapult2Go)
                {
                    if (this.Catapult2.localPosition.y > -this.Catapult2EndPoint)
                    {

                        {
                            float _2136 = this.Catapult2.localPosition.y - this.Catapult2Speed;
                            Vector3 _2137 = this.Catapult2.localPosition;
                            _2137.y = _2136;
                            this.Catapult2.localPosition = _2137;
                        }
                        this.Catapult2Speed = this.Catapult2Speed + 0.02f;
                    }
                    else
                    {
                        if (this.Catapult2Go)
                        {
                            this.StartCoroutine(this.Initiate2());
                            this.RocketModel2.enabled = false;
                        }
                        this.Catapult2Go = false;
                    }
                }
                if (this.Catapult3Go)
                {
                    if (this.Catapult3.localPosition.y > -this.Catapult3EndPoint)
                    {

                        {
                            float _2138 = this.Catapult3.localPosition.y - this.Catapult3Speed;
                            Vector3 _2139 = this.Catapult3.localPosition;
                            _2139.y = _2138;
                            this.Catapult3.localPosition = _2139;
                        }
                        this.Catapult3Speed = this.Catapult3Speed + 0.02f;
                    }
                    else
                    {
                        if (this.Catapult3Go)
                        {
                            this.StartCoroutine(this.Initiate3());
                            this.RocketModel3.enabled = false;
                        }
                        this.Catapult3Go = false;
                    }
                }
                if (WorldInformation.playerCar == this.gameObject.name)
                {
                    if (Input.GetKey("5"))
                    {
                        if (!this.AdvancedAnimatedLauncher)
                        {
                            this.StartCoroutine(this.ShootMissilesD2());
                        }
                        else
                        {
                            this.StartCoroutine(this.ShootMissilesD3());
                        }
                    }
                }
            }
            else
            {
                if (!this.RotToClose)
                {
                    if (this.RevolverRotAmount < 256)
                    {
                        if (this.RevolverRotAmount > 0)
                        {

                            {
                                float _2140 = this.RevolvingMagazine.localEulerAngles.y - 1;
                                Vector3 _2141 = this.RevolvingMagazine.localEulerAngles;
                                _2141.y = _2140;
                                this.RevolvingMagazine.localEulerAngles = _2141;
                            }
                            this.RevolverRotAmount = this.RevolverRotAmount - 1;
                        }
                        else
                        {
                            if (!this.Catapult1Go)
                            {
                                this.RevolverRotAmount = 256;
                                this.StartCoroutine(this.Initiate());
                                this.RocketModel1.enabled = false;
                                this.Catapult1Go = true;
                                return;
                            }
                            if (!this.Catapult2Go)
                            {
                                this.RevolverRotAmount = 256;
                                this.StartCoroutine(this.Initiate2());
                                this.RocketModel2.enabled = false;
                                this.Catapult2Go = true;
                                return;
                            }
                            if (!this.Catapult3Go)
                            {
                                this.RevolverRotAmount = 256;
                                this.StartCoroutine(this.Initiate3());
                                this.RocketModel3.enabled = false;
                                this.Catapult3Go = true;
                                return;
                            }
                            if (!this.Catapult4Go)
                            {
                                this.RevolverRotAmount = 256;
                                this.StartCoroutine(this.Initiate4());
                                this.RocketModel4.enabled = false;
                                this.Catapult4Go = true;
                                return;
                            }
                            if (!this.Catapult5Go)
                            {
                                this.RevolverRotAmount = 256;
                                this.StartCoroutine(this.Initiate5());
                                this.RocketModel5.enabled = false;
                                this.Catapult5Go = true;
                                return;
                            }
                        }
                    }
                }
                else
                {
                    if (this.RevolverRotAmount > 0)
                    {

                        {
                            float _2142 = this.RevolvingMagazine.localEulerAngles.y - 1;
                            Vector3 _2143 = this.RevolvingMagazine.localEulerAngles;
                            _2143.y = _2142;
                            this.RevolvingMagazine.localEulerAngles = _2143;
                        }
                        this.RevolverRotAmount = this.RevolverRotAmount - 1;
                    }
                    else
                    {
                        this.RevolverRotAmount = 256;
                        this.RotToClose = false;
                    }
                }
                if (WorldInformation.playerCar == this.gameObject.name)
                {
                    if (Input.GetKey("5"))
                    {
                        this.ShootMissilesRevolve();
                    }
                }
            }
        }
        else
        {
            if (WorldInformation.playerCar == this.gameObject.name)
            {
                if (!this.FireUsingMouse)
                {
                    if (Input.GetKey("5"))
                    {
                        if (!this.Delayed)
                        {
                            this.StartCoroutine(this.ShootMissiles());
                        }
                        else
                        {
                            this.StartCoroutine(this.ShootMissilesD());
                        }
                    }
                    if (this.HasSecondLauncher)
                    {
                        if (Input.GetKey("6"))
                        {
                            this.StartCoroutine(this.ShootMissiles2());
                        }
                    }
                    if (this.HasThirdLauncher)
                    {
                        if (Input.GetKey("7"))
                        {
                            this.StartCoroutine(this.ShootMissiles3());
                        }
                    }
                }
                else
                {
                    if (Input.GetMouseButton(0) && !CameraScript.InInterface)
                    {
                        this.StartCoroutine(this.ShootMissiles());
                    }
                }
            }
        }
    }

    public virtual IEnumerator ShootMissiles()
    {
        if ((((Time.time - this.lastShot) > this.Cooldown) && this.CanFire) && !this.Obscured)
        {
            this.lastShot = Time.time;
            if (this.AnimatedLauncher)
            {
                this.DispenseAnimationObject.GetComponent<Animation>().Play(this.DispenseAnimationName + "");
            }
            if (!this.AnimatedLauncher)
            {
                this.SequencedGunShot(this.Ammunition, this.SpawnLocation, this.Shockwave, this.ShockwaveLocation);
                yield return new WaitForSeconds(this.SequenceDelay);
                if (this.SecondSpawnLocation != null)
                {
                    this.SequencedGunShot(this.Ammunition, this.SecondSpawnLocation, this.Shockwave, this.ShockwaveLocation);
                }
                yield return new WaitForSeconds(this.SequenceDelay);
                if (this.ThirdSpawnLocation != null)
                {
                    this.SequencedGunShot(this.Ammunition, this.ThirdSpawnLocation, this.Shockwave, this.ShockwaveLocation);
                }
                yield return new WaitForSeconds(this.SequenceDelay);
                if (this.FourthSpawnLocation != null)
                {
                    this.SequencedGunShot(this.Ammunition, this.FourthSpawnLocation, this.Shockwave, this.ShockwaveLocation);
                }
                yield return new WaitForSeconds(this.SequenceDelay);
                if (this.FifthSpawnLocation != null)
                {
                    this.SequencedGunShot(this.Ammunition, this.FifthSpawnLocation, this.Shockwave, this.ShockwaveLocation);
                }
                yield return new WaitForSeconds(this.SequenceDelay);
                if (this.SixthSpawnLocation != null)
                {
                    this.SequencedGunShot(this.Ammunition, this.SixthSpawnLocation, this.Shockwave, this.ShockwaveLocation);
                }
                yield return new WaitForSeconds(this.SequenceDelay);
                if (this.SpawnLocation7 != null)
                {
                    this.SequencedGunShot(this.Ammunition, this.SpawnLocation7, this.Shockwave, this.ShockwaveLocation);
                }
                yield return new WaitForSeconds(this.SequenceDelay);
                if (this.SpawnLocation8 != null)
                {
                    this.SequencedGunShot(this.Ammunition, this.SpawnLocation8, this.Shockwave, this.ShockwaveLocation);
                }
                yield return new WaitForSeconds(this.SequenceDelay);
                if (this.SpawnLocation9 != null)
                {
                    this.SequencedGunShot(this.Ammunition, this.SpawnLocation9, this.Shockwave, this.ShockwaveLocation);
                }
                yield return new WaitForSeconds(this.SequenceDelay);
                if (this.SpawnLocation10 != null)
                {
                    this.SequencedGunShot(this.Ammunition, this.SpawnLocation10, this.Shockwave, this.ShockwaveLocation);
                }
                yield return new WaitForSeconds(this.SequenceDelay);
                if (this.SpawnLocation11 != null)
                {
                    this.SequencedGunShot(this.Ammunition, this.SpawnLocation11, this.Shockwave, this.ShockwaveLocation);
                }
                yield return new WaitForSeconds(this.SequenceDelay);
                if (this.SpawnLocation12 != null)
                {
                    this.SequencedGunShot(this.Ammunition, this.SpawnLocation12, this.Shockwave, this.ShockwaveLocation);
                }
            }
        }
    }

    public virtual IEnumerator ShootMissiles2()
    {
        if ((((Time.time - this.lastShot2) > this.Cooldown2) && this.CanFire2) && !this.Obscured)
        {
            this.lastShot2 = Time.time;
            if (!this.SLPlusFiring)
            {
                this.SequencedGunShot2(this.Ammunition2, this.SecondLauncherSL1, this.Shockwave, this.ShockwaveLocation);
                yield return new WaitForSeconds(this.SequenceDelay);
                this.SequencedGunShot2(this.Ammunition2, this.SecondLauncherSL2, this.Shockwave, this.ShockwaveLocation);
                if (this.SecondLauncherPlus)
                {
                    this.SLPlusFiring = true;
                }
            }
            else
            {
                if (this.SecondLauncherSL3 != null)
                {
                    this.SequencedGunShot2(this.Ammunition2, this.SecondLauncherSL3, this.Shockwave, this.ShockwaveLocation);
                }
                yield return new WaitForSeconds(this.SequenceDelay);
                if (this.SecondLauncherSL4 != null)
                {
                    this.SequencedGunShot2(this.Ammunition2, this.SecondLauncherSL4, this.Shockwave, this.ShockwaveLocation);
                }
                if (this.SecondLauncherPlus)
                {
                    this.SLPlusFiring = false;
                }
            }
        }
    }

    public virtual IEnumerator ShootMissiles3()
    {
        if ((((Time.time - this.lastShot3) > this.Cooldown3) && this.CanFire3) && !this.Obscured)
        {
            this.lastShot3 = Time.time;
            if (!this.TLPlusFiring)
            {
                this.SequencedGunShot3(this.Ammunition3, this.ThirdLauncherSL1, this.Shockwave, this.ShockwaveLocation);
                yield return new WaitForSeconds(this.DelayTime3);
                this.SequencedGunShot3(this.Ammunition3, this.ThirdLauncherSL2, this.Shockwave, this.ShockwaveLocation);
                yield return new WaitForSeconds(this.DelayTime3);
                if (this.SecondLauncherSL3 != null)
                {
                    this.SequencedGunShot3(this.Ammunition3, this.ThirdLauncherSL3, this.Shockwave, this.ShockwaveLocation);
                }
                yield return new WaitForSeconds(this.DelayTime3);
                if (this.SecondLauncherSL4 != null)
                {
                    this.SequencedGunShot3(this.Ammunition3, this.ThirdLauncherSL4, this.Shockwave, this.ShockwaveLocation);
                }
                if (this.ThirdLauncherPlus)
                {
                    this.TLPlusFiring = true;
                }
            }
            else
            {
                if (this.ThirdLauncherSL5 != null)
                {
                    this.SequencedGunShot3(this.Ammunition3, this.ThirdLauncherSL5, this.Shockwave, this.ShockwaveLocation);
                }
                yield return new WaitForSeconds(this.DelayTime3);
                if (this.ThirdLauncherSL6 != null)
                {
                    this.SequencedGunShot3(this.Ammunition3, this.ThirdLauncherSL6, this.Shockwave, this.ShockwaveLocation);
                }
                yield return new WaitForSeconds(this.DelayTime3);
                if (this.ThirdLauncherSL7 != null)
                {
                    this.SequencedGunShot3(this.Ammunition3, this.ThirdLauncherSL7, this.Shockwave, this.ShockwaveLocation);
                }
                yield return new WaitForSeconds(this.DelayTime3);
                if (this.ThirdLauncherSL8 != null)
                {
                    this.SequencedGunShot3(this.Ammunition3, this.ThirdLauncherSL8, this.Shockwave, this.ShockwaveLocation);
                }
                if (this.ThirdLauncherPlus)
                {
                    this.TLPlusFiring = false;
                }
            }
        }
    }

    public virtual IEnumerator ShootMissilesD()
    {
        if ((((Time.time - this.lastShot) > this.Cooldown) && this.CanFire) && !this.Obscured)
        {
            this.lastShot = Time.time;
            GameObject TheThing = UnityEngine.Object.Instantiate(this.VentEffect, this.Vent.position, this.Vent.rotation);
            TheThing.transform.parent = this.Vent.transform;
            yield return new WaitForSeconds(this.DelayTime);
            this.SequencedGunShot(this.Ammunition, this.SpawnLocation, this.Shockwave, this.ShockwaveLocation);
        }
    }

    public virtual IEnumerator ShootMissilesD2()
    {
        if ((((Time.time - this.lastShot) > this.Cooldown) && this.CanFire) && !this.Obscured)
        {
            this.lastShot = Time.time;
            this.DispenseAnimationObject.GetComponent<Animation>().Play(this.DispenseAnimationName + "");
            this.GetComponent<AudioSource>().PlayOneShot(this.DispenseSoundClip);
            yield return new WaitForSeconds(this.DelayTime);
            this.SequencedGunShot(this.Ammunition, this.SpawnLocation, this.Shockwave, this.ShockwaveLocation);
            this.RocketModel1.enabled = false;
            yield return new WaitForSeconds(4);
            this.RocketModel1.enabled = true;
        }
    }

    public virtual IEnumerator ShootMissilesD3()
    {
        if ((((Time.time - this.lastShot) > this.Cooldown) && this.CanFire) && !this.Obscured)
        {
            this.lastShot = Time.time;
            this.DispenseAnimationObject.GetComponent<Animation>().Play(this.DispenseAnimationName + "");
            yield return new WaitForSeconds(this.DelayTime);
            this.Catapult1Go = true;
            this.GetComponent<AudioSource>().PlayOneShot(this.DispenseSoundClip);
            yield return new WaitForSeconds(this.DelayTime2);
            this.Catapult2Go = true;
            this.GetComponent<AudioSource>().PlayOneShot(this.DispenseSoundClip);
            yield return new WaitForSeconds(this.DelayTime2);
            this.Catapult3Go = true;
            this.GetComponent<AudioSource>().PlayOneShot(this.DispenseSoundClip);
        }
    }

    public virtual void ShootMissilesRevolve()
    {
        if ((((Time.time - this.lastShot) > this.Cooldown) && this.CanFire) && !this.Obscured)
        {
            this.lastShot = Time.time;
            if (this.IsPentagonalRevolver)
            {
                this.RevolverRotAmount = 36;
            }
        }
    }

    public virtual void SequencedGunShot(GameObject _prefab, Transform _SpawnP, GameObject _prefabS, Transform SpawnS)
    {
        GameObject _SpawnedObject = UnityEngine.Object.Instantiate(_prefab, _SpawnP.position, _SpawnP.rotation);
        if (_SpawnedObject != null)
        {
            _SpawnedObject.transform.parent = this.gameObject.transform;
            if (!this.SDSM)
            {
                _SpawnedObject.GetComponent<Rigidbody>().velocity = this.MainBody.GetComponent<Rigidbody>().velocity * 1;
            }
            if (this.pushOut)
            {
                _SpawnedObject.GetComponent<Rigidbody>().AddForce(_SpawnP.up * this.pushOutForce);
            }
        }
        if (this.AmmoBay)
        {
            this.AmmoBay.GetComponent<AmmoBay>().ExpendedRound(1);
        }
        if (this.UseTargetingSystem)
        {
            if (this.TargeterSource.target)
            {
                ((MissileScript) _SpawnedObject.transform.GetComponent(typeof(MissileScript))).target = this.TargeterSource.target;
            }
            else
            {
                ((MissileScript) _SpawnedObject.transform.GetComponent(typeof(MissileScript))).target = this.Target;
            }
        }
        if (_prefabS != null)
        {
            UnityEngine.Object.Instantiate(_prefabS, SpawnS.position, SpawnS.rotation);
        }
        if (this.RecoilAnimationObject != null)
        {
            this.RecoilAnimationObject.GetComponent<Animation>().Play(this.RecoilAnimationName + "");
        }
    }

    public virtual void SequencedGunShot2(GameObject _prefab, Transform _SpawnP, GameObject _prefabS, Transform SpawnS)
    {
        GameObject _SpawnedObject = UnityEngine.Object.Instantiate(_prefab, _SpawnP.position, _SpawnP.rotation);
        if (_SpawnedObject != null)
        {
            _SpawnedObject.transform.parent = this.gameObject.transform;
            if (!this.SDSM)
            {
                _SpawnedObject.GetComponent<Rigidbody>().velocity = this.MainBody.GetComponent<Rigidbody>().velocity * 1;
            }
            if (this.pushOut)
            {
                _SpawnedObject.GetComponent<Rigidbody>().AddForce(_SpawnP.up * this.pushOutForce);
            }
        }
        if (this.AmmoBay2)
        {
            this.AmmoBay2.GetComponent<AmmoBay>().ExpendedRound(1);
        }
        if (this.UseTargetingSystem)
        {
            if (this.TargeterSource.target)
            {
                ((MissileScript) _SpawnedObject.transform.GetComponent(typeof(MissileScript))).target = this.TargeterSource.target;
            }
            else
            {
                ((MissileScript) _SpawnedObject.transform.GetComponent(typeof(MissileScript))).target = this.Target;
            }
        }
        if (_prefabS != null)
        {
            UnityEngine.Object.Instantiate(_prefabS, SpawnS.position, SpawnS.rotation);
        }
        if (this.RecoilAnimationObject != null)
        {
            this.RecoilAnimationObject.GetComponent<Animation>().Play(this.RecoilAnimationName + "");
        }
    }

    public virtual void SequencedGunShot3(GameObject _prefab, Transform _SpawnP, GameObject _prefabS, Transform SpawnS)
    {
        GameObject _SpawnedObject = UnityEngine.Object.Instantiate(_prefab, _SpawnP.position, _SpawnP.rotation);
        if (_SpawnedObject != null)
        {
            _SpawnedObject.transform.parent = this.gameObject.transform;
            if (!this.SDSM)
            {
                _SpawnedObject.GetComponent<Rigidbody>().velocity = this.MainBody.GetComponent<Rigidbody>().velocity * 1;
            }
            if (this.pushOut)
            {
                _SpawnedObject.GetComponent<Rigidbody>().AddForce(_SpawnP.up * this.pushOutForce);
            }
        }
        if (this.AmmoBay3)
        {
            this.AmmoBay3.GetComponent<AmmoBay>().ExpendedRound(1);
        }
        if (this.UseTargetingSystem)
        {
            if (this.TargeterSource.target)
            {
                ((MissileScript) _SpawnedObject.transform.GetComponent(typeof(MissileScript))).target = this.TargeterSource.target;
            }
            else
            {
                ((MissileScript) _SpawnedObject.transform.GetComponent(typeof(MissileScript))).target = this.Target;
            }
        }
        if (_prefabS != null)
        {
            UnityEngine.Object.Instantiate(_prefabS, SpawnS.position, SpawnS.rotation);
        }
        if (this.RecoilAnimationObject != null)
        {
            this.RecoilAnimationObject.GetComponent<Animation>().Play(this.RecoilAnimationName + "");
        }
    }

    public virtual IEnumerator Initiate()
    {
        GameObject projectile = UnityEngine.Object.Instantiate(this.Ammunition, this.SpawnLocation.position, this.SpawnLocation.rotation);
        if (projectile != null)
        {
            projectile.GetComponent<Rigidbody>().velocity = this.MainBody.GetComponent<Rigidbody>().velocity * 1;
        }
        if (this.UseTargetingSystem)
        {
            if (this.TargeterSource.target)
            {
                ((MissileScript) projectile.transform.GetComponent(typeof(MissileScript))).target = this.TargeterSource.target;
            }
            else
            {
                ((MissileScript) projectile.transform.GetComponent(typeof(MissileScript))).target = this.Target;
            }
        }
        this.AmmoBay.GetComponent<AmmoBay>().ExpendedRound(1);
        yield return new WaitForSeconds(0.2f);
        if (this.IsPentagonalRevolver)
        {
            this.RotToClose = true;
            this.RevolverRotAmount = 36;
        }
    }

    public virtual IEnumerator Initiate2()
    {
        GameObject projectile = UnityEngine.Object.Instantiate(this.Ammunition, this.SecondSpawnLocation.position, this.SecondSpawnLocation.rotation);
        if (projectile != null)
        {
            projectile.GetComponent<Rigidbody>().velocity = this.MainBody.GetComponent<Rigidbody>().velocity * 1;
        }
        if (this.UseTargetingSystem)
        {
            if (this.TargeterSource.target)
            {
                ((MissileScript) projectile.transform.GetComponent(typeof(MissileScript))).target = this.TargeterSource.target;
            }
            else
            {
                ((MissileScript) projectile.transform.GetComponent(typeof(MissileScript))).target = this.Target;
            }
        }
        this.AmmoBay.GetComponent<AmmoBay>().ExpendedRound(1);
        yield return new WaitForSeconds(0.2f);
        if (this.IsPentagonalRevolver)
        {
            this.RotToClose = true;
            this.RevolverRotAmount = 36;
        }
    }

    public virtual IEnumerator Initiate3()
    {
        GameObject projectile = UnityEngine.Object.Instantiate(this.Ammunition, this.ThirdSpawnLocation.position, this.ThirdSpawnLocation.rotation);
        if (projectile != null)
        {
            projectile.GetComponent<Rigidbody>().velocity = this.MainBody.GetComponent<Rigidbody>().velocity * 1;
        }
        if (this.UseTargetingSystem)
        {
            if (this.TargeterSource.target)
            {
                ((MissileScript) projectile.transform.GetComponent(typeof(MissileScript))).target = this.TargeterSource.target;
            }
            else
            {
                ((MissileScript) projectile.transform.GetComponent(typeof(MissileScript))).target = this.Target;
            }
        }
        this.AmmoBay.GetComponent<AmmoBay>().ExpendedRound(1);
        yield return new WaitForSeconds(0.2f);
        if (this.IsPentagonalRevolver)
        {
            this.RotToClose = true;
            this.RevolverRotAmount = 36;
        }
    }

    public virtual IEnumerator Initiate4()
    {
        GameObject projectile = UnityEngine.Object.Instantiate(this.Ammunition, this.FourthSpawnLocation.position, this.FourthSpawnLocation.rotation);
        if (projectile != null)
        {
            projectile.GetComponent<Rigidbody>().velocity = this.MainBody.GetComponent<Rigidbody>().velocity * 1;
        }
        if (this.UseTargetingSystem)
        {
            if (this.TargeterSource.target)
            {
                ((MissileScript) projectile.transform.GetComponent(typeof(MissileScript))).target = this.TargeterSource.target;
            }
            else
            {
                ((MissileScript) projectile.transform.GetComponent(typeof(MissileScript))).target = this.Target;
            }
        }
        this.AmmoBay.GetComponent<AmmoBay>().ExpendedRound(1);
        yield return new WaitForSeconds(0.2f);
        if (this.IsPentagonalRevolver)
        {
            this.RotToClose = true;
            this.RevolverRotAmount = 36;
        }
    }

    public virtual IEnumerator Initiate5()
    {
        GameObject projectile = UnityEngine.Object.Instantiate(this.Ammunition, this.FifthSpawnLocation.position, this.FifthSpawnLocation.rotation);
        if (projectile != null)
        {
            projectile.GetComponent<Rigidbody>().velocity = this.MainBody.GetComponent<Rigidbody>().velocity * 1;
        }
        if (this.UseTargetingSystem)
        {
            if (this.TargeterSource.target)
            {
                ((MissileScript) projectile.transform.GetComponent(typeof(MissileScript))).target = this.TargeterSource.target;
            }
            else
            {
                ((MissileScript) projectile.transform.GetComponent(typeof(MissileScript))).target = this.Target;
            }
        }
        this.AmmoBay.GetComponent<AmmoBay>().ExpendedRound(1);
        yield return new WaitForSeconds(0.2f);
        if (this.IsPentagonalRevolver)
        {
            this.RotToClose = true;
            this.RevolverRotAmount = 36;
        }
    }

    public virtual void HideModel1()
    {
        this.RocketModel1.enabled = false;
    }

    public virtual void HideModel2()
    {
        this.RocketModel2.enabled = false;
    }

    public virtual void HideModel3()
    {
        this.RocketModel3.enabled = false;
    }

    public virtual void DispenseSound()
    {
        this.DispenseAudio.PlayOneShot(this.DispenseSoundClip);
    }

    public virtual void Tick()
    {
        if (this.Pivot)
        {
            this.Obscured = false;
            if ((this.Pivot.localEulerAngles.z < 40) || (this.Pivot.localEulerAngles.z > 320))
            {
                this.Obscured = true;
            }
        }
    }

    public LauncherScript()
    {
        this.RecoilAnimationName = "Name";
        this.DispenseAnimationName = "Name";
        this.Catapult1Speed = 0.1f;
        this.Catapult1EndPoint = 12.5f;
        this.Catapult2Speed = 0.1f;
        this.Catapult2EndPoint = 12.5f;
        this.Catapult3Speed = 0.1f;
        this.Catapult3EndPoint = 12.5f;
        this.pushOutForce = 16;
        this.RevolverRotAmount = 1;
        this.CanFire = true;
        this.CanFire2 = true;
        this.CanFire3 = true;
        this.Cooldown = 20;
        this.Cooldown2 = 20;
        this.Cooldown3 = 20;
        this.SequenceDelay = 0.5f;
        this.DelayTime = 0.5f;
        this.DelayTime2 = 0.5f;
        this.DelayTime3 = 0.3f;
    }

}