using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PressEtoStart : MonoBehaviour
{
    public GameObject IngameHUD;
    public Transform Tutstart;
    public Transform Nopass;
    public Transform PlayerCamera;
    public PlayerCamFollow PhysCamScript;
    public Transform SWISH;
    public Transform ScreenFreezer;
    public GameObject Titlemation;
    public Transform OrbitAnimation;
    public Transform OrbitPoint;
    public TextMesh UpdateText;
    public bool isStarting;
    public virtual void Start()
    {
        this.UpdateText.text = "Update " + WorldInformation.VersionID;
    }

    public virtual void FixedUpdate()
    {
        this.transform.position = this.OrbitPoint.position;
        this.transform.rotation = this.OrbitPoint.rotation;
    }

    public virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !this.isStarting)
        {
            this.isStarting = true;
            this.SWISH.GetComponent<AudioSource>().Play();
            this.Titlemation.GetComponent<Animation>().Play();
            this.StartCoroutine(this.Starting());
        }
    }

    public virtual IEnumerator Starting()
    {
        ScreenFadeScript.FadeOut = true;
        yield return new WaitForSeconds(3);
        Application.LoadLevel("PiriZerzek");
    }

}