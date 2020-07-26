using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class TravelerController : MonoBehaviour
{
    public static float DirForce;
    public float AngForce;
    public float OriDirForce;
    public int BoostTimer;
    public GameObject TargetAnimation1;
    public GameObject TargetAnimation2;
    public Transform ModelSpawn;
    public ParticleSystem FX;
    public Transform TFMaedracanDesert;
    public Transform TFOyhuratIsland;
    public Transform TFKabriusEstrellite;
    public Transform TFPiriPlanet;
    public Transform TFAthnias;
    public Transform TFJaedenAgracoast;
    public Transform TFSunfrontPeninsula;
    public Transform TFAnodOutpost;
    public Transform TFDarkKeigan;
    public Transform TFAzecreas;
    public Transform TFDutvutan;
    public Blinker MarkerGlow;
    public bool CanWarp;
    public bool Warping;
    public bool SpaceVessel;
    public bool RunningF;
    public bool RunningR;
    public bool RunningA;
    public bool RunningD;
    public virtual IEnumerator Start()
    {
        this.InvokeRepeating("Counter", 1, 1);
        if (DrivenVesselScript.isWarpVessel)
        {
            this.CanWarp = true;
        }
        if (DrivenVesselScript.LastScene == "PiriZerzek")
        {
            this.transform.position = this.TFPiriPlanet.position;
        }
        if (DrivenVesselScript.LastScene == "AnodOutpost")
        {
            this.transform.position = this.TFAnodOutpost.position;
        }
        if (DrivenVesselScript.LastScene == "DarkKeiganSanis")
        {
            this.transform.position = this.TFDarkKeigan.position;
        }
        if (DrivenVesselScript.LastScene == "MaedracanDesert")
        {
            this.transform.position = this.TFMaedracanDesert.position;
        }
        if (DrivenVesselScript.LastScene == "OyhuratIsland")
        {
            this.transform.position = this.TFOyhuratIsland.position;
        }
        if (DrivenVesselScript.LastScene == "CentralAthnias")
        {
            this.transform.position = this.TFAthnias.position;
        }
        if (DrivenVesselScript.LastScene == "JaedenAgracoast")
        {
            this.transform.position = this.TFJaedenAgracoast.position;
        }
        if (DrivenVesselScript.LastScene == "SunfrontPeninsula")
        {
            this.transform.position = this.TFSunfrontPeninsula.position;
        }
        if (DrivenVesselScript.LastScene == "KabriusEstrellite")
        {
            this.transform.position = this.TFKabriusEstrellite.position;
        }
        if (DrivenVesselScript.LastScene == "OuterAzecreas")
        {
            this.transform.position = this.TFAzecreas.position;
        }
        if (DrivenVesselScript.LastScene == "DutvutanOutpost1")
        {
            this.transform.position = this.TFDutvutan.position;
        }

        {
            float _3674 = this.transform.position.y + 30;
            Vector3 _3675 = this.transform.position;
            _3675.y = _3674;
            this.transform.position = _3675;
        }
        if (DrivenVesselScript.WhatToSpawn == "null")
        {
            TravelerController.DirForce = 60;
            this.OriDirForce = 60;
            this.CanWarp = true;
            this.SpaceVessel = true;
            GameObject Prefabionaise = ((GameObject) Resources.Load("VesselModels/MVessel1337", typeof(GameObject))) as GameObject;
            GameObject TheThing = UnityEngine.Object.Instantiate(Prefabionaise, this.ModelSpawn.position, this.ModelSpawn.rotation);
            TheThing.transform.parent = this.ModelSpawn.parent;
            TheThing.transform.localScale = TheThing.transform.localScale + new Vector3(0.5f, 0.5f, 0.5f);
        }
        else
        {
            TravelerController.DirForce = DrivenVesselScript.VesselTravelSpeed;
            this.OriDirForce = DrivenVesselScript.VesselTravelSpeed;
            GameObject Prefabionaise2 = ((GameObject) Resources.Load("VesselModels/M" + DrivenVesselScript.WhatToSpawn, typeof(GameObject))) as GameObject;
            GameObject TheThing2 = UnityEngine.Object.Instantiate(Prefabionaise2, this.ModelSpawn.position, this.ModelSpawn.rotation);
            TheThing2.transform.parent = this.ModelSpawn.parent;
            TheThing2.transform.localScale = TheThing2.transform.localScale + new Vector3(0.5f, 0.5f, 0.5f);
        }
        yield return new WaitForSeconds(0.1f);
        WorldInformation.isTraveling = true;
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        if (!MapInfoDisplay.isShowingWindow)
        {
            if (Input.GetKeyDown("w"))
            {
                this.RunningF = true;
            }
            if (Input.GetKeyUp("w"))
            {
                this.RunningF = false;
            }
            if (Input.GetKeyDown("a"))
            {
                this.RunningA = true;
            }
            if (Input.GetKeyUp("a"))
            {
                this.RunningA = false;
            }
            if (Input.GetKeyDown("d"))
            {
                this.RunningD = true;
            }
            if (Input.GetKeyUp("d"))
            {
                this.RunningD = false;
            }
        }
        else
        {
            this.RunningF = false;
            this.RunningR = false;
            this.RunningA = false;
            this.RunningD = false;
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        if (this.CanWarp)
        {
            if (this.BoostTimer == 0)
            {
                if (Input.GetKey(KeyCode.LeftShift) && !this.Warping)
                {
                    if (Input.GetKey("w"))
                    {
                        this.Warping = true;
                        this.RunningF = true;
                        this.GetComponent<Rigidbody>().AddForce(-this.transform.up * 10000);
                        TravelerController.DirForce = 1000;
                        this.BoostTimer = 2;
                        this.GetComponent<AudioSource>().Play();
                        this.FX.enableEmission = true;
                    }
                }
            }
            if (Input.GetKeyUp("w") || Input.GetKeyUp(KeyCode.LeftShift))
            {
                TravelerController.DirForce = this.OriDirForce;
                this.FX.enableEmission = false;
                this.Warping = false;
            }
        }
        if (!this.Warping)
        {
            Debug.DrawRay(this.transform.position + (-this.transform.up * 20), -this.transform.forward * 40, Color.white);
            if (!Physics.Raycast(this.transform.position + (-this.transform.up * 20), -this.transform.forward, 40))
            {
                TravelerController.DirForce = 0;
                if (!this.CanWarp)
                {
                    this.TargetAnimation1.GetComponent<Animation>().Play("ScreenTextFade");
                }
                else
                {
                    this.TargetAnimation2.GetComponent<Animation>().Play("ScreenTextFade");
                }
            }
            else
            {
                TravelerController.DirForce = this.OriDirForce;
            }
        }
        Debug.DrawRay(this.transform.position, -this.transform.forward * 500, Color.red);
        if (Physics.Raycast(this.transform.position, -this.transform.forward, out hit, 500))
        {
            if (((MapMarkerClick) hit.collider.gameObject.GetComponent(typeof(MapMarkerClick))) != null)
            {
                ((MapMarkerClick) hit.collider.gameObject.GetComponent(typeof(MapMarkerClick))).Entered = true;
                if (((MapMarkerClick) hit.collider.gameObject.GetComponent(typeof(MapMarkerClick))).HasMarker)
                {
                    this.MarkerGlow.IsActive = true;
                }
                else
                {
                    this.MarkerGlow.IsActive = false;
                }
            }
            else
            {
                this.MarkerGlow.IsActive = false;
            }
        }
        else
        {
            this.MarkerGlow.IsActive = false;
        }
    }

    public virtual void FixedUpdate()
    {
        if (this.RunningF)
        {
            this.GetComponent<Rigidbody>().AddForce(-this.transform.up * TravelerController.DirForce);
        }
        if (this.RunningA)
        {
            this.GetComponent<Rigidbody>().AddTorque(-this.transform.forward * this.AngForce);
        }
        if (this.RunningD)
        {
            this.GetComponent<Rigidbody>().AddTorque(this.transform.forward * this.AngForce);
        }
    }

    public virtual void Counter()
    {
        if (DrivenVesselScript.WhatToSpawn == "Vessel1337")
        {
            WorldInformation.DrivingZerzek = true;
        }
        else
        {
            WorldInformation.DrivingZerzek = false;
        }
        if ((this.transform.eulerAngles.y > 45) && (this.transform.eulerAngles.y < 135))
        {
            WorldInformation.FacingNorth = true;
            WorldInformation.FacingSouth = false;
            WorldInformation.FacingWest = false;
            WorldInformation.FacingEast = false;
        }
        if ((this.transform.eulerAngles.y > 135) && (this.transform.eulerAngles.y < 225))
        {
            WorldInformation.FacingNorth = false;
            WorldInformation.FacingSouth = false;
            WorldInformation.FacingWest = false;
            WorldInformation.FacingEast = true;
        }
        if ((this.transform.eulerAngles.y > 225) && (this.transform.eulerAngles.y < 315))
        {
            WorldInformation.FacingNorth = false;
            WorldInformation.FacingSouth = true;
            WorldInformation.FacingWest = false;
            WorldInformation.FacingEast = false;
        }
        if ((this.transform.eulerAngles.y > 315) || (this.transform.eulerAngles.y < 45))
        {
            WorldInformation.FacingNorth = false;
            WorldInformation.FacingSouth = false;
            WorldInformation.FacingWest = true;
            WorldInformation.FacingEast = false;
        }
        if (this.BoostTimer > 0)
        {
            this.BoostTimer = this.BoostTimer - 1;
        }
    }

    public TravelerController()
    {
        this.AngForce = 40;
        this.OriDirForce = 100;
    }

    static TravelerController()
    {
        TravelerController.DirForce = 100;
    }

}