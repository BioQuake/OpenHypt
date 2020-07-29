using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SceneSwitcher : MonoBehaviour
{
    public GameObject OverEffect;
    public GameObject PressEffect;
    public bool entered;
    public bool once;
    public GameObject DarkKeigan;
    public GameObject Jaeden;
    public GameObject Levia;
    public GameObject Anod;
    public GameObject Encydros;
    public GameObject Maedracan;
    public GameObject Oyhurat;
    public GameObject Athnias;
    public GameObject Azecreas;
    public GameObject Pirizuka;
    public GameObject Dutvutan;
    public GameObject TargetAnimation;
    public virtual void Update()
    {
        if (this.entered)
        {
            this.OverEffect.SetActive(true);
            if (Input.GetMouseButtonDown(0) && !this.once)
            {
                this.once = true;
                this.StartCoroutine(this.SwitchScene());
            }
        }
        else
        {
            this.OverEffect.SetActive(false);
        }
    }

    public virtual IEnumerator SwitchScene()
    {
        if (this.DarkKeigan.activeSelf == true)
        {
            if (WorldInformation.UsingBrightVessel)
            {
                this.TargetAnimation.GetComponent<Animation>().Play("ScreenTextFade");
                this.once = false;
                yield break;
            }
        }
        this.PressEffect.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        WorldInformation.isSwitchingScene = true;
        ScreenFadeScript.FadeOut = true;
        yield return new WaitForSeconds(1);
        if (WorldInformation.DrivingZerzek && (this.Pirizuka.activeSelf == true))
        {
            WorldInformation.isSwitchingScene = false;
        }
        yield return new WaitForSeconds(2);
        PlayerCamFollow.HoldCam = false;
        if (this.DarkKeigan.activeSelf == true)
        {
            Application.LoadLevel("DarkKeiganSanis");
        }
        if (this.Jaeden.activeSelf == true)
        {
            Application.LoadLevel("JaedenAgracoast");
        }
        if (this.Levia.activeSelf == true)
        {
            Application.LoadLevel("SunfrontPeninsula");
        }
        if (this.Anod.activeSelf == true)
        {
            Application.LoadLevel("AnodOutpost");
        }
        if (this.Encydros.activeSelf == true)
        {
            Application.LoadLevel("KabriusEstrellite");
        }
        if (this.Maedracan.activeSelf == true)
        {
            Application.LoadLevel("MaedracanDesert");
        }
        if (this.Oyhurat.activeSelf == true)
        {
            Application.LoadLevel("OyhuratIslands");
        }
        if (this.Athnias.activeSelf == true)
        {
            Application.LoadLevel("CentralAthnias");
        }
        if (this.Azecreas.activeSelf == true)
        {
            Application.LoadLevel("OuterAzecreas");
        }
        if (this.Dutvutan.activeSelf == true)
        {
            Application.LoadLevel("DutvutanOutpost1");
        }
        if (this.Pirizuka.activeSelf == true)
        {
            Application.LoadLevel("PiriZerzek");
        }
    }

    public virtual void OnMouseEnter()
    {
        this.entered = true;
    }

    public virtual void OnMouseExit()
    {
        this.entered = false;
    }

}