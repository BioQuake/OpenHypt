using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class LoadPiriLocation : MonoBehaviour
{
    public Transform ExitedLocation;
    public Transform ExitedLocation2;
    public Transform ExitedLocation3;
    public GameObject PlayerCamera;
    public static bool Exit1;
    public static bool Exit2;
    public static bool Exit3;
    public static bool CallingAmbulance;
    public bool Once;
    public virtual IEnumerator Start()
    {
        LoadPiriLocation.CallingAmbulance = false;
        if (LoadPiriLocation.Exit1)
        {
            this.MoveToExit1();
        }
        if (LoadPiriLocation.Exit2)
        {
            this.MoveToExit2();
        }
        if (LoadPiriLocation.Exit3)
        {
            this.MoveToExit3();
        }
        yield return new WaitForSeconds(1);
        WorldInformation.isSwitchingScene = false;
    }

    public virtual void Update()
    {
        if (LoadPiriLocation.CallingAmbulance && !this.Once)
        {
            this.Once = true;
            this.StartCoroutine(WorldInformation.instance.EscortHome());
        }
    }

    public virtual void MoveToExit1()
    {
        PlayerInformation.instance.Pirizuka.position = this.ExitedLocation.position;
        PlayerInformation.instance.Pirizuka.rotation = this.ExitedLocation.rotation;
        PlayerInformation.instance.PhysCam.rotation = this.ExitedLocation.rotation;
        PlayerInformation.instance.PlayerCam.rotation = this.ExitedLocation.rotation;

        {
            float _2274 = PlayerInformation.instance.Pirizuka.position.y + 1.8f;
            Vector3 _2275 = PlayerInformation.instance.Pirizuka.position;
            _2275.y = _2274;
            PlayerInformation.instance.Pirizuka.position = _2275;
        }
        LoadPiriLocation.Exit1 = false;
    }

    public virtual void MoveToExit2()
    {
        PlayerInformation.instance.Pirizuka.position = this.ExitedLocation2.position;
        PlayerInformation.instance.Pirizuka.rotation = this.ExitedLocation2.rotation;
        PlayerInformation.instance.PhysCam.rotation = this.ExitedLocation2.rotation;
        PlayerInformation.instance.PlayerCam.rotation = this.ExitedLocation2.rotation;

        {
            float _2276 = PlayerInformation.instance.Pirizuka.position.y + 1.8f;
            Vector3 _2277 = PlayerInformation.instance.Pirizuka.position;
            _2277.y = _2276;
            PlayerInformation.instance.Pirizuka.position = _2277;
        }
        LoadPiriLocation.Exit2 = false;
    }

    public virtual void MoveToExit3()
    {
        PlayerInformation.instance.Pirizuka.position = this.ExitedLocation3.position;
        PlayerInformation.instance.Pirizuka.rotation = this.ExitedLocation3.rotation;
        PlayerInformation.instance.PhysCam.rotation = this.ExitedLocation3.rotation;
        PlayerInformation.instance.PlayerCam.rotation = this.ExitedLocation3.rotation;

        {
            float _2278 = PlayerInformation.instance.Pirizuka.position.y + 1.8f;
            Vector3 _2279 = PlayerInformation.instance.Pirizuka.position;
            _2279.y = _2278;
            PlayerInformation.instance.Pirizuka.position = _2279;
        }
        LoadPiriLocation.Exit3 = false;
    }

}