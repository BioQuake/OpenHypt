using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class VehicleSensor : MonoBehaviour
{
    public Transform Target;
    public Transform ExitSphere;
    public int DeactivateDist;
    public float MidToGroundDist;
    public float TailEndDist;
    public bool IsTrailer;
    public bool HugeVessel;
    public bool LargeVessel;
    public bool Enabled;
    public bool Once;
    public bool HavePassed;
    public bool Repositioned;
    public bool Garaged;
    public Transform Garage;
    public string prefab_name;
    public GameObject Vessel;
    public GameObject Model;
    public GameObject Col;
    public LayerMask targetLayers;
    
    public virtual IEnumerator Start()
    {
        InvokeRepeating("VesselUpdate", 4, 1);
        
        Target = PlayerInformation.instance.Pirizuka;
        
        if (prefab_name != "Vessel74")  // "TAK M-l1" (Emergency scooter thing)
        {
            if (prefab_name != "Vessel118") // "Katovari Motus" (Emergency scooter thing)
            {
                if (prefab_name != "Vessel1337")    // "PiriZerzek"
                {
                    if (!Repositioned)
                    {
                        if ((prefab_name == DrivenVesselScript.WhatToSpawn) && (DrivenVesselScript.LastScene == Application.loadedLevelName))
                        {
                            Destroy(this.gameObject);
                        }
                        if ((prefab_name == DrivenVesselScript.WhatToSpawn) && WorldInformation.isSwitchingScene)
                        {
                            Destroy(this.gameObject);
                        }
                    }
                }
            }
        }
        
        yield return new WaitForSeconds(1);
        
        if (prefab_name == "Vessel1337")    // "PiriZerzek"
        {
            WorldInformation.PiriZerzekPresent = true;
        }
        
        yield return new WaitForSeconds(1);
        
        if (!Once)
        {
            Once = true;
            if (Vessel != null)
            {
                Vessel.transform.parent = null;
            }
        }
    }

    public virtual void VesselUpdate()
    {
        RaycastHit hit = default(RaycastHit);
        if (Vessel != null)
        {
            transform.position = Vessel.transform.position;
            transform.rotation = Vessel.transform.rotation;
            transform.Rotate(Vector3.right * -90);
            transform.Rotate(Vector3.up * -90);
            transform.Rotate(Vector3.forward * 180);
        }
        else
        {
            if (!HavePassed)
            {
                Destroy(this.gameObject);
            }
        }
        if (!Enabled)
        {
            return;
        }
        if (Garaged)
        {
            if (Vector3.Distance(this.transform.position, this.Garage.position) < 256)
            {
                return;
            }
            else
            {
                Garaged = false;
            }
        }
        if (Vessel != null)
        {
            if (!IsTrailer)
            {
                if (Vessel.GetComponent<MainVehicleController>().Broken == true)
                {
                    Destroy(this.gameObject);
                }
            }
        }
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 64, targetLayers))
        {
            if (hit.collider.name.Contains("Pir"))
            {
                return;
            }
        }
        if (!HavePassed)
        {
            if ((Vector3.Distance(transform.position, Target.position) > DeactivateDist) && (Vessel.GetComponent<Rigidbody>().velocity.magnitude < 2))
            {
                HavePassed = true;
                Model.gameObject.SetActive(true);
                if (Col != null)
                {
                    Col.gameObject.SetActive(true);
                }
                if (Vessel != null)
                {
                    Destroy(Vessel);
                }
            }
        }
        if (HavePassed)
        {
            if (!HugeVessel)
            {
                if (!LargeVessel)
                {
                    if (Vector3.Distance(transform.position, Target.position) > 2000)
                    {
                        Model.gameObject.SetActive(false);
                    }
                    else
                    {
                        Model.gameObject.SetActive(true);
                    }
                }
                if (LargeVessel)
                {
                    if (Vector3.Distance(transform.position, Target.position) > 4000)
                    {
                        Model.gameObject.SetActive(false);
                    }
                    else
                    {
                        Model.gameObject.SetActive(true);
                    }
                }
            }
        }
        if (Vector3.Distance(transform.position, Target.position) < DeactivateDist)
        {
            if (HavePassed)
            {
                if (Col != null)
                {
                    Col.gameObject.SetActive(false);
                }
                GameObject Prefabionaise = (GameObject) Resources.Load("VesselPrefabs/" + prefab_name, typeof(GameObject));
                GameObject TheThing = Instantiate(Prefabionaise, transform.position + (transform.up * 0.1f), transform.rotation);
                ((VehicleSensor) TheThing.transform.GetComponent(typeof(VehicleSensor))).Repositioned = true;
                Destroy(this.gameObject);
            }
        }
    }

    public VehicleSensor()
    {
        DeactivateDist = 300;
        MidToGroundDist = 1.3f;
        prefab_name = "prefab1";
    }

}