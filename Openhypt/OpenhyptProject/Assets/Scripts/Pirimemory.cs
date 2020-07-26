using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class Pirimemory : MonoBehaviour
{
    public Transform AmbulanceLocation;
    public GameObject Ambulance;//prefab
    public virtual void Start()
    {
        if (PlayerPrefs.HasKey("Injured"))
        {
            WorldInformation.playerCar = "null";
            PlayerPrefs.DeleteKey("Injured");
            GameObject Ambu = UnityEngine.Object.Instantiate(this.Ambulance, this.AmbulanceLocation.position, this.AmbulanceLocation.rotation);
            Ambu.GetComponent<Animation>().Play("animationName");
            PlayerPrefs.Save();
        }
        UnityEngine.Object.Destroy(this);
    }

}