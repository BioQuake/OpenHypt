using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MapButtons : MonoBehaviour
{
    public bool isHome;
    public bool GoingHome;
    public bool ZoomedOut;
    public virtual IEnumerator OnMouseDown()
    {
        if (this.isHome && !this.GoingHome)
        {
            this.GoingHome = true;
            ScreenFadeScript.FadeOut = true;
            yield return new WaitForSeconds(1);
            PlayerPrefs.SetFloat("Injured", 1);
            PlayerPrefs.Save();
            yield return new WaitForSeconds(1);
            WorldInformation.FPMode = false;
            PlayerCamFollow.HoldCam = false;
            Application.LoadLevel("PiriZerzek");
        }
        if (!this.isHome && !this.GoingHome)
        {
            if (this.ZoomedOut)
            {
                this.ZoomedOut = false;
                MapCamZ.ZoomDist = -32;
                this.GetComponent<AudioSource>().Play();
            }
            else
            {
                this.ZoomedOut = true;
                MapCamZ.ZoomDist = -1000;
                this.GetComponent<AudioSource>().Play();
            }
        }
    }

}