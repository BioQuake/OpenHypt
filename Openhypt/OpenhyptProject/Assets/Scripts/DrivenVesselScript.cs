using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class DrivenVesselScript : MonoBehaviour
{
    public static DrivenVesselScript instance;
    public static string WhatToSpawn;
    public static string LastScene;
    public static Vector3 WhereToSpawnPos;
    public static Quaternion WhereToSpawnRot;
    public static int VesselTravelSpeed;
    public static float VesselSpawnDist;
    public static bool isWarpVessel;
    public static bool isSpaceVessel;
    public static Transform DriverSpawn;
    public virtual void Start()
    {
        if (WorldInformation.isSwitchingScene)
        {
            GameObject Prefabionaise2 = ((GameObject) Resources.Load("VesselPrefabs/" + DrivenVesselScript.WhatToSpawn, typeof(GameObject))) as GameObject;
            if (WorldInformation.FacingNorth)
            {
                GameObject TheThing1 = UnityEngine.Object.Instantiate(Prefabionaise2, WorldInformation.instance.TravelLocationS.position, WorldInformation.instance.TravelLocationS.rotation);
                ((VehicleSensor) TheThing1.transform.GetComponent(typeof(VehicleSensor))).Repositioned = true;
                if (DrivenVesselScript.WhatToSpawn != "Vessel74")
                {
                    if (DrivenVesselScript.WhatToSpawn != "Vessel118")
                    {
                        ((VehicleSensor) TheThing1.transform.GetComponent(typeof(VehicleSensor))).Vessel.name = "DrivenVessel";
                    }
                }
                DrivenVesselScript.DriverSpawn = ((VehicleSensor) TheThing1.transform.GetComponent(typeof(VehicleSensor))).ExitSphere;

                {
                    float _1758 = TheThing1.transform.position.y + DrivenVesselScript.VesselSpawnDist;
                    Vector3 _1759 = TheThing1.transform.position;
                    _1759.y = _1758;
                    TheThing1.transform.position = _1759;
                }
            }
            if (WorldInformation.FacingEast)
            {
                GameObject TheThing2 = UnityEngine.Object.Instantiate(Prefabionaise2, WorldInformation.instance.TravelLocationW.position, WorldInformation.instance.TravelLocationW.rotation);
                ((VehicleSensor) TheThing2.transform.GetComponent(typeof(VehicleSensor))).Repositioned = true;
                if (DrivenVesselScript.WhatToSpawn != "Vessel74")
                {
                    if (DrivenVesselScript.WhatToSpawn != "Vessel118")
                    {
                        ((VehicleSensor) TheThing2.transform.GetComponent(typeof(VehicleSensor))).Vessel.name = "DrivenVessel";
                    }
                }
                DrivenVesselScript.DriverSpawn = ((VehicleSensor) TheThing2.transform.GetComponent(typeof(VehicleSensor))).ExitSphere;

                {
                    float _1760 = TheThing2.transform.position.y + DrivenVesselScript.VesselSpawnDist;
                    Vector3 _1761 = TheThing2.transform.position;
                    _1761.y = _1760;
                    TheThing2.transform.position = _1761;
                }
            }
            if (WorldInformation.FacingSouth)
            {
                GameObject TheThing3 = UnityEngine.Object.Instantiate(Prefabionaise2, WorldInformation.instance.TravelLocationN.position, WorldInformation.instance.TravelLocationN.rotation);
                ((VehicleSensor) TheThing3.transform.GetComponent(typeof(VehicleSensor))).Repositioned = true;
                if (DrivenVesselScript.WhatToSpawn != "Vessel74")
                {
                    if (DrivenVesselScript.WhatToSpawn != "Vessel118")
                    {
                        ((VehicleSensor) TheThing3.transform.GetComponent(typeof(VehicleSensor))).Vessel.name = "DrivenVessel";
                    }
                }
                DrivenVesselScript.DriverSpawn = ((VehicleSensor) TheThing3.transform.GetComponent(typeof(VehicleSensor))).ExitSphere;

                {
                    float _1762 = TheThing3.transform.position.y + DrivenVesselScript.VesselSpawnDist;
                    Vector3 _1763 = TheThing3.transform.position;
                    _1763.y = _1762;
                    TheThing3.transform.position = _1763;
                }
            }
            if (WorldInformation.FacingWest)
            {
                GameObject TheThing4 = UnityEngine.Object.Instantiate(Prefabionaise2, WorldInformation.instance.TravelLocationE.position, WorldInformation.instance.TravelLocationE.rotation);
                ((VehicleSensor) TheThing4.transform.GetComponent(typeof(VehicleSensor))).Repositioned = true;
                if (DrivenVesselScript.WhatToSpawn != "Vessel74")
                {
                    if (DrivenVesselScript.WhatToSpawn != "Vessel118")
                    {
                        ((VehicleSensor) TheThing4.transform.GetComponent(typeof(VehicleSensor))).Vessel.name = "DrivenVessel";
                    }
                }
                DrivenVesselScript.DriverSpawn = ((VehicleSensor) TheThing4.transform.GetComponent(typeof(VehicleSensor))).ExitSphere;

                {
                    float _1764 = TheThing4.transform.position.y + DrivenVesselScript.VesselSpawnDist;
                    Vector3 _1765 = TheThing4.transform.position;
                    _1765.y = _1764;
                    TheThing4.transform.position = _1765;
                }
            }
            PlayerInformation.instance.Pirizuka.position = DrivenVesselScript.DriverSpawn.position;
            PlayerInformation.instance.Pirizuka.rotation = DrivenVesselScript.DriverSpawn.rotation;
            PlayerInformation.instance.PhysCam.rotation = DrivenVesselScript.DriverSpawn.rotation;
            PlayerInformation.instance.PlayerCam.rotation = DrivenVesselScript.DriverSpawn.rotation;

            {
                float _1766 = PlayerInformation.instance.Pirizuka.position.y + 1.8f;
                Vector3 _1767 = PlayerInformation.instance.Pirizuka.position;
                _1767.y = _1766;
                PlayerInformation.instance.Pirizuka.position = _1767;
            }
        }
        else
        {
            if (DrivenVesselScript.WhatToSpawn != "null")
            {
                if (DrivenVesselScript.WhatToSpawn != "Vessel1337")
                {
                    if (DrivenVesselScript.LastScene == Application.loadedLevelName)
                    {
                        GameObject Prefabionaise = ((GameObject) Resources.Load("VesselPrefabs/" + DrivenVesselScript.WhatToSpawn, typeof(GameObject))) as GameObject;
                        GameObject TheThing = UnityEngine.Object.Instantiate(Prefabionaise, DrivenVesselScript.WhereToSpawnPos, DrivenVesselScript.WhereToSpawnRot);
                        ((VehicleSensor) TheThing.transform.GetComponent(typeof(VehicleSensor))).Repositioned = true;
                        if (DrivenVesselScript.WhatToSpawn != "Vessel74")
                        {
                            if (DrivenVesselScript.WhatToSpawn != "Vessel118")
                            {
                                ((VehicleSensor) TheThing.transform.GetComponent(typeof(VehicleSensor))).Vessel.name = "DrivenVessel";
                            }
                        }
                    }
                }
            }
        }
        WorldInformation.isSwitchingScene = false;
    }

    public virtual void Awake()
    {
        DrivenVesselScript.instance = this;
    }

    static DrivenVesselScript()
    {
        DrivenVesselScript.WhatToSpawn = "null";
        DrivenVesselScript.LastScene = "null";
        DrivenVesselScript.VesselTravelSpeed = 40;
        DrivenVesselScript.VesselSpawnDist = 1.5f;
    }

}