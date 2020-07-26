using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PiriUpperBodyController : MonoBehaviour
{
    public Transform target;
    public bool Recoiling;
    public GameObject Hand;
    public Transform HeadTF;
    public Transform thisTransform;
    public GameObject HandGunHold;
    public GameObject HeldWeapon;
    public GameObject HeldToy;
    public Transform Reticle;
    public bool HeadInStuff;
    public GameObject TargetAnimation5;
    private Quaternion NewRotation;
    public static int Weight;
    public static bool Resetting;
    public static bool CanShoot;
    public static bool IsAiming;
    public static bool Once;
    public bool CanHead;
    public LayerMask targetLayers;
    public virtual IEnumerator Start()
    {
        this.CanHead = false;
        PiriUpperBodyController.Weight = 20;
        PiriUpperBodyController.CanShoot = true;
        PiriUpperBodyController.IsAiming = false;
        this.target = GameObject.Find("PiriAimFront").transform;
        this.Reticle = Symbols.instance.Reticle;
        yield return new WaitForSeconds(0.3f);
        this.Hand.gameObject.SetActive(true);
        this.HandGunHold.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        this.Hand.gameObject.SetActive(true);
        this.HandGunHold.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        this.Hand.gameObject.SetActive(true);
        this.HandGunHold.gameObject.SetActive(false);
        this.CanHead = true;
    }

    public virtual void FixedUpdate()
    {
        if (PiriUpperBodyController.IsAiming)
        {
            this.NewRotation = Quaternion.LookRotation(this.transform.position - this.target.position);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.NewRotation, Time.deltaTime * PiriUpperBodyController.Weight);
        }
    }

    public virtual void Update()
    {
        if (WorldInformation.FPMode || Input.GetMouseButton(1))
        {
            if (!Physics.Linecast(this.thisTransform.position, this.HeadTF.position, (int) this.targetLayers))
            {
                if (this.HeadInStuff)
                {
                    PiriUpperBodyController.Once = true;
                }
                this.HeadInStuff = false;
            }
            else
            {
                if (!this.HeadInStuff)
                {
                    PiriUpperBodyController.Once = true;
                }
                this.HeadInStuff = true;
            }
        }
        else
        {
            if (this.HeadInStuff)
            {
                PiriUpperBodyController.Once = true;
            }
            this.HeadInStuff = false;
        }
        if (PiriUpperBodyController.Once && this.CanHead)
        {
            PiriUpperBodyController.Once = false;
            if (this.HeadInStuff)
            {
                ScreenFadeScript.BlackOut = true;
                FurtherActionScript.instance.HeadStuck = true;
                FurtherActionScript.instance.ShowText();
            }
            else
            {
                ScreenFadeScript.BlackOut = false;
            }
        }
        if (PiriUpperBodyController.Resetting)
        {
            PiriUpperBodyController.Resetting = false;
            this.Reset();
        }
        if (this.Hand.activeSelf && this.HandGunHold.activeSelf)
        {
            this.HandGunHold.gameObject.SetActive(false);
        }
        if (((CameraScript.InInterface == false) && PlayerMotionAnimator.instance.CanMove) && !PlayerMotionAnimator.Landing)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (!WorldInformation.IsNopass)
                {
                    PiriUpperBodyController.IsAiming = true;
                    this.Reticle.gameObject.SetActive(true);
                    if (ItemContainer.PiriContainer.ContainerItems.Count > 0)
                    {
                        switch (ItemContainer.PiriContainer.ContainerItems[0].ID)
                        {
                            case ItemEnum.TestGun:
                                this.GetComponent<Animation>().Play("PiriPullGunSRifle");
                                break;
                            case ItemEnum.Trumpgun:
                                this.GetComponent<Animation>().Play("PiriPullGunSRifle");
                                break;
                            case ItemEnum.Anoca_PT13:
                                this.GetComponent<Animation>().Play("PiriPullGunSRifle");
                                break;
                            case ItemEnum.Posmer_HC40:
                                this.GetComponent<Animation>().Play("PiriPullGunCannon");
                                break;
                            case ItemEnum.Posmer_10c:
                                this.GetComponent<Animation>().Play("PiriPullGunSRifle");
                                break;
                            case ItemEnum.Shakar_17:
                                this.GetComponent<Animation>().Play("PiriPullGunSRifle");
                                break;
                            case ItemEnum.Tothler_Tygria_M2:
                                this.GetComponent<Animation>().Play("PiriPullGunSRifle");
                                break;
                            case ItemEnum.AROT_Iter_1:
                                this.GetComponent<Animation>().Play("PiriPullGunSRifle");
                                break;
                            case ItemEnum.BK:
                                this.GetComponent<Animation>().Play("PiriPullGunSRifle");
                                break;
                            case ItemEnum.TLF_PTSD_G1:
                                this.GetComponent<Animation>().Play("PiriPullGunSRifle");
                                break;
                            case ItemEnum.MevNav_MRCHg:
                                this.GetComponent<Animation>().Play("PiriPullGunSRifle");
                                break;
                            case ItemEnum.Anoca_PT32:
                                this.GetComponent<Animation>().Play("PiriPullGunSRifle");
                                break;
                            case ItemEnum.Posmer_10cR:
                                this.GetComponent<Animation>().Play("PiriPullGunSRifle");
                                break;
                            case ItemEnum.Metis_CAR_05:
                                this.GetComponent<Animation>().Play("PiriPullGunRifle");
                                break;
                            case ItemEnum.DASMUN_SR2:
                                this.GetComponent<Animation>().Play("PiriPullGunRifle");
                                break;
                            case ItemEnum.TRN_PTSD_Az:
                                this.GetComponent<Animation>().Play("PiriPullGunSRifle");
                                break;
                            case ItemEnum.Fawcett_Alton:
                                this.GetComponent<Animation>().Play("PiriPullGunRifle");
                                break;
                            case ItemEnum.Katovari_MD:
                                this.GetComponent<Animation>().Play("PiriPullGunRifle");
                                break;
                            case ItemEnum.Fidget_Spinner:
                                this.GetComponent<Animation>().Play("PiriPullToy");
                                break;
                        }
                    }
                    this.Hand.gameObject.SetActive(false);
                    this.HandGunHold.gameObject.SetActive(true);
                }
            }
            if (Input.GetMouseButtonUp(1))
            {
                this.GetComponent<Animation>().Stop();
                if (this.HeldWeapon.transform.childCount > 0)
                {
                    this.GetComponent<Animation>().Play("PiriPutAwayGun");
                }
                if (this.HeldToy.transform.childCount > 0)
                {
                    this.GetComponent<Animation>().Play("PiriPutAwayToy");
                }
                this.Hand.gameObject.SetActive(true);
                this.HandGunHold.gameObject.SetActive(false);
                this.Reticle.gameObject.SetActive(false);
                PiriUpperBodyController.IsAiming = false;
            }
        }
        if ((Input.GetMouseButton(1) && Input.GetKeyDown(KeyCode.I)) || (Input.GetMouseButton(1) && Input.GetMouseButton(2)))
        {
            if (!CameraScript.CamNoFP)
            {
                this.GetComponent<Animation>().Stop();
                this.GetComponent<Animation>().Play("PiriPutAwayGun");
                this.Hand.gameObject.SetActive(true);
                this.HandGunHold.gameObject.SetActive(false);
                PiriUpperBodyController.IsAiming = false;
            }
            this.Reticle.gameObject.SetActive(false);
        }
        if (PiriUpperBodyController.IsAiming)
        {
            if (Input.GetMouseButtonUp(1))
            {
                PiriUpperBodyController.IsAiming = false;
            }
        }
    }

    public virtual IEnumerator Recoil()
    {
        this.Recoiling = true;
        this.PlayRecoilAnimation();
        yield return new WaitForSeconds(0.1f);
        this.ResetRecoilAnimation();
        yield return new WaitForSeconds(0.1f);
        this.Recoiling = false;
    }

    public virtual void Reset()
    {
        this.GetComponent<Animation>().Stop();
        this.Hand.gameObject.SetActive(true);
        this.HandGunHold.gameObject.SetActive(false);
        this.Reticle.gameObject.SetActive(false);
        PiriUpperBodyController.IsAiming = false;
    }

    public virtual void PlayRecoilAnimation()
    {
        switch (ItemContainer.PiriContainer.ContainerItems[0].ID)
        {
            case ItemEnum.TestGun:
                this.GetComponent<Animation>().Stop();
                this.GetComponent<Animation>().Play("PiriSRifleRecoil");
                break;
            case ItemEnum.Trumpgun:
                this.GetComponent<Animation>().Stop();
                this.GetComponent<Animation>().Play("PiriSRifleRecoil");
                break;
            case ItemEnum.Anoca_PT13:
                this.GetComponent<Animation>().Stop();
                this.GetComponent<Animation>().Play("PiriSRifleRecoil");
                break;
            case ItemEnum.Posmer_HC40:
                this.GetComponent<Animation>().Play("PiriCannonRecoil");
                break;
            case ItemEnum.Posmer_10c:
                this.GetComponent<Animation>().Stop();
                this.GetComponent<Animation>().Play("PiriSRifleRecoil");
                break;
            case ItemEnum.Shakar_17:
                this.GetComponent<Animation>().Stop();
                this.GetComponent<Animation>().Play("PiriSRifleRecoil");
                break;
            case ItemEnum.Tothler_Tygria_M2:
                this.GetComponent<Animation>().Stop();
                this.GetComponent<Animation>().Play("PiriSRifleRecoil");
                break;
            case ItemEnum.AROT_Iter_1:
                this.GetComponent<Animation>().Stop();
                this.GetComponent<Animation>().Play("PiriSRifleRecoil");
                break;
            case ItemEnum.BK:
                this.GetComponent<Animation>().Stop();
                this.GetComponent<Animation>().Play("PiriSRifleRecoil");
                break;
            case ItemEnum.TLF_PTSD_G1:
                this.GetComponent<Animation>().Stop();
                this.GetComponent<Animation>().Play("PiriSRifleRecoil");
                break;
            case ItemEnum.MevNav_MRCHg:
                this.GetComponent<Animation>().Stop();
                this.GetComponent<Animation>().Play("PiriSRifleRecoil");
                break;
            case ItemEnum.Anoca_PT32:
                this.GetComponent<Animation>().Stop();
                this.GetComponent<Animation>().Play("PiriSRifleRecoil");
                break;
            case ItemEnum.Posmer_10cR:
                this.GetComponent<Animation>().Stop();
                this.GetComponent<Animation>().Play("PiriSRifleRecoil");
                break;
            case ItemEnum.Metis_CAR_05:
                this.GetComponent<Animation>().Stop();
                this.GetComponent<Animation>().Play("PiriRifleRecoil");
                break;
            case ItemEnum.DASMUN_SR2:
                this.GetComponent<Animation>().Stop();
                this.GetComponent<Animation>().Play("PiriRifleRecoil");
                break;
            case ItemEnum.TRN_PTSD_Az:
                this.GetComponent<Animation>().Stop();
                this.GetComponent<Animation>().Play("PiriSRifleRecoil");
                break;
            case ItemEnum.Fawcett_Alton:
                this.GetComponent<Animation>().Stop();
                this.GetComponent<Animation>().Play("PiriRifleRecoil");
                break;
            case ItemEnum.Katovari_MD:
                this.GetComponent<Animation>().Stop();
                this.GetComponent<Animation>().Play("PiriCannonRecoil");
                break;
            case ItemEnum.Fidget_Spinner:
                this.GetComponent<Animation>().Stop();
                this.GetComponent<Animation>().Play("PiriToyFidget");
                break;
        }
        if (!PiriUpperBodyController.IsAiming)
        {
            this.GetComponent<Animation>().Stop();
            if (this.HeldWeapon.transform.childCount > 0)
            {
                this.GetComponent<Animation>().Play("PiriPutAwayGun");
            }
            if (this.HeldToy.transform.childCount > 0)
            {
                this.GetComponent<Animation>().Play("PiriPutAwayToy");
            }
            this.Hand.gameObject.SetActive(true);
            this.HandGunHold.gameObject.SetActive(false);
            this.Reticle.gameObject.SetActive(false);
            PiriUpperBodyController.IsAiming = false;
        }
    }

    public virtual void ResetRecoilAnimation()
    {
        switch (ItemContainer.PiriContainer.ContainerItems[0].ID)
        {
            case ItemEnum.TestGun:
                this.GetComponent<Animation>().CrossFade("PiriHoldGunSRifle");
                break;
            case ItemEnum.Trumpgun:
                this.GetComponent<Animation>().CrossFade("PiriHoldGunSRifle");
                break;
            case ItemEnum.Anoca_PT13:
                this.GetComponent<Animation>().CrossFade("PiriHoldGunSRifle");
                break;
            case ItemEnum.Posmer_HC40:
                this.GetComponent<Animation>().CrossFade("PiriHoldGunCannon");
                break;
            case ItemEnum.Posmer_10c:
                this.GetComponent<Animation>().CrossFade("PiriHoldGunSRifle");
                break;
            case ItemEnum.Shakar_17:
                this.GetComponent<Animation>().CrossFade("PiriHoldGunSRifle");
                break;
            case ItemEnum.Tothler_Tygria_M2:
                this.GetComponent<Animation>().CrossFade("PiriHoldGunSRifle");
                break;
            case ItemEnum.AROT_Iter_1:
                this.GetComponent<Animation>().CrossFade("PiriHoldGunSRifle");
                break;
            case ItemEnum.BK:
                this.GetComponent<Animation>().CrossFade("PiriHoldGunSRifle");
                break;
            case ItemEnum.TLF_PTSD_G1:
                this.GetComponent<Animation>().CrossFade("PiriHoldGunSRifle");
                break;
            case ItemEnum.MevNav_MRCHg:
                this.GetComponent<Animation>().CrossFade("PiriHoldGunSRifle");
                break;
            case ItemEnum.Anoca_PT32:
                this.GetComponent<Animation>().CrossFade("PiriHoldGunSRifle");
                break;
            case ItemEnum.Posmer_10cR:
                this.GetComponent<Animation>().CrossFade("PiriHoldGunSRifle");
                break;
            case ItemEnum.Metis_CAR_05:
                this.GetComponent<Animation>().CrossFade("PiriHoldGunRifle");
                break;
            case ItemEnum.DASMUN_SR2:
                this.GetComponent<Animation>().CrossFade("PiriHoldGunRifle");
                break;
            case ItemEnum.TRN_PTSD_Az:
                this.GetComponent<Animation>().CrossFade("PiriHoldGunSRifle");
                break;
            case ItemEnum.Fawcett_Alton:
                this.GetComponent<Animation>().CrossFade("PiriHoldGunRifle");
                break;
            case ItemEnum.Katovari_MD:
                this.GetComponent<Animation>().CrossFade("PiriHoldGunRifle");
                break;
            case ItemEnum.Fidget_Spinner:
                this.GetComponent<Animation>().CrossFade("PiriHoldToy");
                break;
        }
        if (!PiriUpperBodyController.IsAiming)
        {
            this.GetComponent<Animation>().Stop();
            if (this.HeldWeapon.transform.childCount > 0)
            {
                this.GetComponent<Animation>().Play("PiriPutAwayGun");
            }
            if (this.HeldToy.transform.childCount > 0)
            {
                this.GetComponent<Animation>().Play("PiriPutAwayToy");
            }
            this.Hand.gameObject.SetActive(true);
            this.HandGunHold.gameObject.SetActive(false);
            this.Reticle.gameObject.SetActive(false);
            PiriUpperBodyController.IsAiming = false;
        }
    }

}