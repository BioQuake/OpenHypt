using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class FleetScript : MonoBehaviour
{
    public Transform fleetPoint1;
    public GameObject PresentFleetMember1;
    public Transform fleetPoint2;
    public GameObject PresentFleetMember2;
    public Transform fleetPoint3;
    public GameObject PresentFleetMember3;
    public Transform fleetPoint4;
    public GameObject PresentFleetMember4;
    public virtual IEnumerator Summon()
    {
        if (!WorldInformation.PiriZerzekPresent)
        {
            GameObject Prefabionaise1 = ((GameObject) Resources.Load("Prefabs/Izmir_P_Warper", typeof(GameObject))) as GameObject;
            this.PresentFleetMember1 = UnityEngine.Object.Instantiate(Prefabionaise1, this.fleetPoint1.position, this.fleetPoint1.rotation);
        }
        yield return new WaitForSeconds(0.5f);
        if (!string.IsNullOrEmpty(WorldInformation.FleetMember2))
        {
            GameObject Prefabionaise2 = ((GameObject) Resources.Load("Prefabs/" + WorldInformation.FleetMember2, typeof(GameObject))) as GameObject;
            this.PresentFleetMember2 = UnityEngine.Object.Instantiate(Prefabionaise2, this.fleetPoint2.position, this.fleetPoint2.rotation);
            ((Warper) this.PresentFleetMember2.transform.GetComponent(typeof(Warper))).FleetNum = 1;
        }
        yield return new WaitForSeconds(0.5f);
        if (!string.IsNullOrEmpty(WorldInformation.FleetMember3))
        {
            GameObject Prefabionaise3 = ((GameObject) Resources.Load("Prefabs/" + WorldInformation.FleetMember3, typeof(GameObject))) as GameObject;
            this.PresentFleetMember3 = UnityEngine.Object.Instantiate(Prefabionaise3, this.fleetPoint3.position, this.fleetPoint3.rotation);
            ((Warper) this.PresentFleetMember3.transform.GetComponent(typeof(Warper))).FleetNum = 2;
        }
        yield return new WaitForSeconds(0.5f);
        if (!string.IsNullOrEmpty(WorldInformation.FleetMember4))
        {
            GameObject Prefabionaise4 = ((GameObject) Resources.Load("Prefabs/" + WorldInformation.FleetMember4, typeof(GameObject))) as GameObject;
            this.PresentFleetMember4 = UnityEngine.Object.Instantiate(Prefabionaise4, this.fleetPoint4.position, this.fleetPoint4.rotation);
            ((Warper) this.PresentFleetMember4.transform.GetComponent(typeof(Warper))).FleetNum = 3;
        }
    }

}