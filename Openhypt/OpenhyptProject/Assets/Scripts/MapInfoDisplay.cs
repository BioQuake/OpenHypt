using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MapInfoDisplay : MonoBehaviour
{
    public static MapInfoDisplay instance;
    public static bool isShowingWindow;
    public bool entered;
    public string HideAni;
    public string ShowAni;
    public GameObject InfoInterface;
    public virtual void Awake()
    {
        MapInfoDisplay.instance = this;
    }

    public virtual void Start()
    {
        MapInfoDisplay.isShowingWindow = false;
    }

    public virtual void UpdateName(string name)
    {
        TextMesh tm = (TextMesh) this.GetComponent(typeof(TextMesh));
        tm.text = name;
    }

    public virtual IEnumerator OnMouseDown()
    {
        if (MapInfoDisplay.isShowingWindow)
        {
            this.InfoInterface.GetComponent<Animation>().Play(this.HideAni);
            yield return new WaitForSeconds(0.1f);
            MapInfoDisplay.isShowingWindow = false;
        }
        else
        {
            this.InfoInterface.GetComponent<Animation>().Play(this.ShowAni);
            MapInfoDisplay.isShowingWindow = true;
        }
    }

}