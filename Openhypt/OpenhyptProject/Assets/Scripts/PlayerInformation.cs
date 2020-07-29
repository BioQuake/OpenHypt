using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PlayerInformation : MonoBehaviour
{
    public Transform Pirizuka;
    public Rigidbody PirizukaRB;
    public Transform PiriTarget;
    public Transform PiriAim;
    public Transform PiriTurretAim;
    public Transform PiriHead;
    public Transform PiriNose;
    public Transform PiriREye;
    public Transform PiriLEye;
    public Transform PiriHeldThing;
    public Transform PiriHeldWeapon;
    public Transform PiriHeldToy;
    public Transform BackpackPoint;
    public Transform RBosom;
    public Transform LBosom;
    public GameObject PiriTorso;
    public GameObject PiriWheel;
    public GameObject PiriPivot;
    public Animation PiriAni;
    public GameObject PiriCol2;
    public Transform PiriPresence;
    public Transform PhysCam;
    public Transform PlayerCam;
    public CapsuleCollider TCCol;
    public static PlayerInformation instance;
    public virtual void Awake()
    {
        PlayerInformation.instance = this;
    }

}