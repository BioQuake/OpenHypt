using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class RefineryEnterButton : MonoBehaviour
{
    public GameObject RefineryCam;
    public Camera Cam;
    public AudioListener CamAL;
    public GameObject RefineryRoom;
    //var RefineryGraphicsAnimationObject : GameObject;
    //var RefineryGraphicsAnimationName : String = "Name";
    public virtual void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            //RefineryGraphicsAnimationObject.audio.Play();
            this.Show();
        }
    }

    public virtual void Show()
    {
        if (this.RefineryCam.activeSelf == false)
        {
            this.RefineryCam.gameObject.SetActive(true);
            this.Cam.enabled = false;
            this.CamAL.enabled = false;
            this.RefineryRoom.gameObject.SetActive(true);
            Screen.lockCursor = false;
            Cursor.visible = true;
        }
        else
        {
            this.RefineryCam.gameObject.SetActive(false);
            this.Cam.enabled = true;
            this.CamAL.enabled = true;
            this.RefineryRoom.gameObject.SetActive(false);
            Screen.lockCursor = true;
            Cursor.visible = false;
        }
    }

}