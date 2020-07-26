using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class NewSceneEntrance : MonoBehaviour
{
    private bool IsNearDoor;
    public string WhereToGo;
    public bool IsExit1;
    public bool IsExit2;
    public bool IsExit3;
    public bool ActivateFP;
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("TC1"))
        {
            this.IsNearDoor = true;
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("TC1"))
        {
            this.IsNearDoor = false;
        }
    }

    public virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && this.IsNearDoor)
        {
            this.StartCoroutine(this.SwitchScene());
        }
    }

    public virtual IEnumerator SwitchScene()
    {
        ScreenFadeScript.FadeOut = true;
        if (this.IsExit1)
        {
            LoadPiriLocation.Exit1 = true;
        }
        if (this.IsExit2)
        {
            LoadPiriLocation.Exit2 = true;
        }
        if (this.IsExit3)
        {
            LoadPiriLocation.Exit3 = true;
        }
        yield return new WaitForSeconds(2);
        if (this.ActivateFP)
        {
            WorldInformation.FPMode = true;
        }
        else
        {
            WorldInformation.FPMode = false;
            PlayerCamFollow.HoldCam = true;
        }
        Application.LoadLevel(this.WhereToGo);
    }

}