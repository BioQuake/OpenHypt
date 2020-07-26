using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class TCChanger : MonoBehaviour
{
    public static string TCName;
    public static int DidShootNum;
    public string forcedTCName;
    public AngyScript nameDisplayer;
    public virtual void Update()//}
    {
        if (PlayerInformation.instance.Pirizuka != null)
        {
            this.transform.position = PlayerInformation.instance.Pirizuka.position + (this.transform.up * 0.7f);
        }
        else
        {
            this.transform.localPosition = new Vector3(0, 0, 0);
        }
    }

    public virtual void Switcher()
    {
        if (this.nameDisplayer)
        {
            this.nameDisplayer.myText = this.name;
            this.nameDisplayer.DisplayName();
        }
        if (TCChanger.DidShootNum > 0)
        {
            TCChanger.DidShootNum = TCChanger.DidShootNum - 1;
        }
        if (!string.IsNullOrEmpty(this.forcedTCName))
        {
            this.name = this.forcedTCName;
            return;
        }
        if (this.name.Contains("snyf"))
        {
            return;
        }
        if (WorldInformation.playerCar == "null")
        {
            if (WorldInformation.PiriExposed < 1)
            {
                this.name = "csTC1p";
                WorldInformation.playerLevel = 0;
            }
            else
            {
                this.name = "sTC1p";
                WorldInformation.playerLevel = 0;
            }
        }
        else
        {
            this.name = TCChanger.TCName;
            if (this.name.Contains("7"))
            {
                if (TCChanger.DidShootNum > 1)
                {
                    this.name = "mTC7";
                }
                if (WorldInformation.PiriExposed > 1)
                {
                    this.name = "mTC1";
                }
            }
            if (WorldInformation.PiriExposed > 1)
            {
                //Debug.Log("IsExposed " + WorldInformation.PiriExposed);
                if (this.name.Contains("sT"))
                {
                    this.name = "sTC1p";
                }
                if (this.name.Contains("mT"))
                {
                    this.name = "mTC1p";
                }
                if (this.name.Contains("bT"))
                {
                    this.name = "bTC1p";
                }
            }
        }
        if (WorldInformation.playerCar.Contains("broken"))
        {
            this.name = "broken";
        }
    }

    public virtual void Start()
    {
        this.InvokeRepeating("Switcher", 0.83f, 0.25f);
    }

    static TCChanger()
    {
        TCChanger.TCName = "sTC1p";
    }

}