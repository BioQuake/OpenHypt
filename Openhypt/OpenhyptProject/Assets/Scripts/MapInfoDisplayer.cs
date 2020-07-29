using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MapInfoDisplayer : MonoBehaviour
{
    public virtual void Start()
    {
        this.InvokeRepeating("Tick", 0, 0.1f);
    }

    public virtual void Tick()
    {
        RaycastHit hit = default(RaycastHit);
        if (Physics.Raycast(this.transform.position, -this.transform.forward, out hit, 8000))
        {
            if (MapInfoDisplay.instance != null)
            {
                if (((MapMarkerClick) hit.collider.gameObject.GetComponent(typeof(MapMarkerClick))) != null)
                {
                    MapInfoDisplay.instance.UpdateName(((MapMarkerClick) hit.collider.gameObject.GetComponent(typeof(MapMarkerClick))).NameOfArea);
                }
            }
        }
    }

}