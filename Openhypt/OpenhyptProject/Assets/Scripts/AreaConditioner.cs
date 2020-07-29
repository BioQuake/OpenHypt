using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AreaConditioner : MonoBehaviour
{
    public bool FXNorm;
    public bool FXPale;
    public bool FXDark;
    public virtual void Start()
    {
        if (this.FXNorm == true)
        {
            if (WorldInformation.instance.AreaBeige)
            {
                return;
            }
            UnityEngine.Object.Destroy(this.gameObject);
        }
        if (this.FXPale == true)
        {
            if (WorldInformation.instance.AreaGray)
            {
                return;
            }
            UnityEngine.Object.Destroy(this.gameObject);
        }
        if (this.FXDark == true)
        {
            if (WorldInformation.instance.AreaDark)
            {
                return;
            }
            UnityEngine.Object.Destroy(this.gameObject);
        }
        if (this.GetComponent<Renderer>())
        {
            this.GetComponent<Renderer>().material.SetColor("_ReflectiveTint", WorldInformation.instance.reflColors);
        }
        else
        {
            if (!WorldInformation.instance.AreaDark)
            {
                UnityEngine.Object.Destroy(this.GetComponent<Light>());
                if (this.gameObject.name.Contains("ight"))
                {
                    UnityEngine.Object.Destroy(this.gameObject);
                }
            }
            else
            {
                int i = 0;
                while (i < this.transform.childCount)
                {
                    this.transform.GetChild(i).gameObject.active = true;
                    ++i;
                }
            }
        }
    }

}