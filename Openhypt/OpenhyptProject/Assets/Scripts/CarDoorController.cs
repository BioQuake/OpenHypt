using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class CarDoorController : MonoBehaviour
{
    public float CameraDistance;
    public MainVehicleController connectedVehicle;
    private Transform car;
    private Rigidbody VehicleRB;
    public Rigidbody vTurretRB;
    public Rigidbody pRigidbody;
    private GameObject player;
    private GameObject playerH;
    private GameObject playerW;
    private GameObject playerP;
    public bool isNPC;
    public bool isInteriorDoor;
    public bool isCameraSetter;
    public bool rotBoost;
    public GameObject PiriCol2;
    public GameObject HeadCol;
    public Transform doorTriggerLeft;
    [UnityEngine.HideInInspector]
    public bool nearVehicle;
    [UnityEngine.HideInInspector]
    public bool inVehicle;
    private Vector3 aScale;
    private GameObject piri;
    private GameObject helmet;
    public Transform StandArea;
    public Transform EscapeBubble;
    public bool DenyEntrance;
    public Transform cameraFocus;
    public GameObject EngineFX1;
    public GameObject EngineFX2;
    public GameObject EngineFX3;
    public HingeJoint BodyJoint;
    public virtual void Start()
    {
        this.car = this.transform;
        this.VehicleRB = this.transform.parent.gameObject.GetComponent<Rigidbody>();
        this.player = PlayerInformation.instance.Pirizuka.gameObject;
        this.playerH = PlayerInformation.instance.PiriHead.gameObject;
        this.playerW = PlayerInformation.instance.PiriWheel;
        this.playerP = PlayerInformation.instance.PiriPivot;
        this.cameraFocus = this.transform.parent.Find("CameraFocus");
        this.EscapeBubble = this.transform.parent.Find("ExitSphere");
        this.PiriCol2 = PlayerInformation.instance.PiriCol2;
    }

    public virtual void FixedUpdate()
    {
        if (this.DenyEntrance)
        {
            this.nearVehicle = false;
            if ((WorldInformation.vehicleDoorController == this) && !this.inVehicle)
            {
                WorldInformation.vehicleDoorController = null;
            }
        }
        if (this.isNPC)
        {
            if (this.inVehicle)
            {
                if (Input.GetKey("a"))
                {
                    if (!this.rotBoost)
                    {
                        this.pRigidbody.AddTorque((this.transform.up * -this.pRigidbody.mass) * 10);
                    }
                    else
                    {
                        this.pRigidbody.AddTorque((this.transform.up * -this.pRigidbody.mass) * 20);
                    }
                }
                if (Input.GetKey("d"))
                {
                    if (!this.rotBoost)
                    {
                        this.pRigidbody.AddTorque((this.transform.up * this.pRigidbody.mass) * 10);
                    }
                    else
                    {
                        this.pRigidbody.AddTorque((this.transform.up * this.pRigidbody.mass) * 20);
                    }
                }
            }
        }
    }

    public virtual void ArtificialUpdate()
    {
        if (this.connectedVehicle.OpenVessel == false)
        {
            this.player.transform.position = this.EscapeBubble.transform.position;
        }
        else
        {
            if (Input.GetMouseButtonDown(1))
            {

                {
                    int _998 = 0;
                    JointSpring _999 = this.BodyJoint.spring;
                    _999.spring = _998;
                    this.BodyJoint.spring = _999;
                }
            }
            if (Input.GetMouseButtonUp(1))
            {
                this.player.transform.position = this.StandArea.transform.position;
                this.player.transform.rotation = this.StandArea.transform.rotation;

                {
                    int _1000 = 10;
                    JointSpring _1001 = this.BodyJoint.spring;
                    _1001.spring = _1000;
                    this.BodyJoint.spring = _1001;
                }
            }
        }
    }

    public virtual void Enter()
    {
        this.transform.parent.gameObject.name = "DV";
        if (!this.isNPC)
        {
            IndicatorScript.VehicleIsDamaged = false;
            IndicatorScript.GunIsDamaged = false;
            this.StartCoroutine(this.connectedVehicle.RefreshFX());
            if (this.connectedVehicle.OpenVessel == false)
            {
                if (this.player == null)
                {
                    this.player = GameObject.Find("Pirizuka").gameObject;
                }
                this.connectedVehicle.Inside = true;
                this.player.gameObject.SetActive(false);
                this.EscapeBubble.gameObject.SetActive(true);
                this.player.transform.parent = this.EscapeBubble.transform;
                PlayerInformation.instance.LBosom.localEulerAngles = new Vector3(280, 180, 0);
                PlayerInformation.instance.RBosom.localEulerAngles = new Vector3(280, 180, 0);
                PlayerInformation.instance.LBosom.localPosition = new Vector3(-0.09f, 0.44f, 0.02f);
                PlayerInformation.instance.RBosom.localPosition = new Vector3(0.09f, 0.44f, 0.02f);
                PlayerInformation.instance.PiriHead.localEulerAngles = new Vector3(0, 0, 0);
                PlayerInformation.instance.PiriHead.localPosition = new Vector3(0, 0.075f, 0);
                PlayerInformation.instance.PiriREye.localEulerAngles = new Vector3(0, 0, 0);
                PlayerInformation.instance.PiriLEye.localEulerAngles = new Vector3(0, 0, 0);
                this.playerW.transform.localEulerAngles = new Vector3(0, 0, 0);
                this.playerW.transform.localPosition = new Vector3(0, 0, 0);
                this.playerP.transform.localEulerAngles = new Vector3(0, 0, 0);
                this.playerP.transform.localPosition = new Vector3(0, -1.4f, 0);
                this.player.transform.localEulerAngles = new Vector3(0, 0, 0);
                this.player.transform.localPosition = new Vector3(0, -1.4f, 0);
                PlayerInformation.instance.TCCol.radius = this.CameraDistance * 0.5f;
                PlayerInformation.instance.TCCol.center = new Vector3(0, 0, 0);
                PlayerInformation.instance.TCCol.height = this.CameraDistance * 0.5f;

                {
                    int _1002 = 500;
                    Vector3 _1003 = PlayerInformation.instance.PiriTurretAim.localPosition;
                    _1003.y = _1002;
                    PlayerInformation.instance.PiriTurretAim.localPosition = _1003;
                }
                WorldInformation.UsingVessel = true;
                WorldInformation.UsingClosedVessel = true;
                WorldInformation.UsingBigVessel = false;
                WorldInformation.FPMode = false;
                CameraScript.changeColOnce = true;
                WorldInformation.playerCar = this.transform.parent.name;
                PresenceFollow.insideNPC = false;
                VehicleManager.EnterVehicle(this.connectedVehicle, this);
                NotiScript.Notipoint = WorldInformation.vehicleController.transform;
                this.inVehicle = true;
                this.nearVehicle = false;
                CameraScript.instance.CheckCars(this.cameraFocus, this.CameraDistance);
                if (this.connectedVehicle.ThisVehiclesID == "Vessel420")
                {
                    WorldInformation.UsingSnyf = true;
                }
                if (this.connectedVehicle.ThisVehiclesID == "Vessel1338")
                {
                    if (PiripodAI.IsActive)
                    {
                        CallAssistance.DismissCepto = true;
                    }
                }
            }
            else
            {
                if (this.connectedVehicle.ThisVehiclesID == "Vessel75")
                {
                    PlayerMotionAnimator.UsingMotus = false;
                }
                else
                {
                    PlayerMotionAnimator.UsingMotus = true;
                }
                this.connectedVehicle.Inside = true;
                ((CapsuleCollider) this.player.GetComponent(typeof(CapsuleCollider))).isTrigger = true;
                ((SphereCollider) this.playerW.GetComponent(typeof(SphereCollider))).isTrigger = true;
                PlayerMotionAnimator.instance.CanFPAnimationaise = true;
                if (this.HeadCol)
                {
                    this.HeadCol.gameObject.SetActive(true);
                }
                WorldInformation.UsingVessel = true;
                WorldInformation.playerCar = this.transform.parent.name;
                VehicleManager.EnterVehicle(this.connectedVehicle, this);

                {
                    int _1004 = 0;
                    Vector3 _1005 = PlayerInformation.instance.PiriTurretAim.localPosition;
                    _1005.y = _1004;
                    PlayerInformation.instance.PiriTurretAim.localPosition = _1005;
                }
                this.player.transform.position = this.StandArea.transform.position;
                this.player.transform.rotation = this.StandArea.transform.rotation;
                this.playerW.transform.localEulerAngles = new Vector3(0, 0, 0);
                this.playerW.transform.localPosition = new Vector3(0, 0, 0);
                this.playerP.transform.localEulerAngles = new Vector3(0, 0, 0);
                this.playerP.transform.localPosition = new Vector3(0, -1.4f, 0);
                this.BodyJoint = this.player.AddComponent<HingeJoint>();
                if (this.vTurretRB)
                {
                    this.BodyJoint.connectedBody = this.vTurretRB;
                }
                else
                {
                    this.BodyJoint.connectedBody = this.VehicleRB;
                }
                this.BodyJoint.axis = new Vector3(0, 1, 0);
                this.BodyJoint.useSpring = true;

                {
                    int _1006 = 10;
                    JointSpring _1007 = this.BodyJoint.spring;
                    _1007.spring = _1006;
                    this.BodyJoint.spring = _1007;
                }
                this.playerW.SetActive(false);
                this.inVehicle = true;
                this.nearVehicle = false;
                if (this.connectedVehicle.BigVessel)
                {
                    CameraScript.instance.CheckCars(this.cameraFocus, this.CameraDistance);
                    WorldInformation.UsingBigVessel = true;
                }
            }
        }
        else
        {
            if (this.player == null)
            {
                this.player = GameObject.Find("Pirizuka").gameObject;
            }
            this.player.gameObject.SetActive(false);
            this.EscapeBubble.gameObject.SetActive(true);
            this.player.transform.parent = this.EscapeBubble.transform;
            PlayerInformation.instance.LBosom.localEulerAngles = new Vector3(280, 180, 0);
            PlayerInformation.instance.RBosom.localEulerAngles = new Vector3(280, 180, 0);
            PlayerInformation.instance.LBosom.localPosition = new Vector3(-0.09f, 0.44f, 0.02f);
            PlayerInformation.instance.RBosom.localPosition = new Vector3(0.09f, 0.44f, 0.02f);
            PlayerInformation.instance.PiriHead.localEulerAngles = new Vector3(0, 0, 0);
            PlayerInformation.instance.PiriHead.localPosition = new Vector3(0, 0.075f, 0);
            PlayerInformation.instance.PiriREye.localEulerAngles = new Vector3(0, 0, 0);
            PlayerInformation.instance.PiriLEye.localEulerAngles = new Vector3(0, 0, 0);
            this.playerW.transform.localEulerAngles = new Vector3(0, 0, 0);
            this.playerW.transform.localPosition = new Vector3(0, 0, 0);
            this.playerP.transform.localEulerAngles = new Vector3(0, 0, 0);
            this.playerP.transform.localPosition = new Vector3(0, -1.4f, 0);
            this.player.transform.localEulerAngles = new Vector3(0, 0, 0);
            this.player.transform.localPosition = new Vector3(0, -1.4f, 0);
            PlayerInformation.instance.TCCol.radius = this.CameraDistance * 0.5f;
            PlayerInformation.instance.TCCol.center = new Vector3(0, 0, 0);
            PlayerInformation.instance.TCCol.height = this.CameraDistance * 0.5f;
            WorldInformation.UsingVessel = true;
            WorldInformation.UsingClosedVessel = true;
            WorldInformation.UsingBigVessel = false;
            WorldInformation.playerCar = this.transform.parent.name;
            PresenceFollow.insideNPC = true;
            NotiScript.Notipoint = this.transform.parent.transform;
            WorldInformation.npcVehicleTF = this.transform;
            this.inVehicle = true;
            this.nearVehicle = false;
            CameraScript.instance.CheckCars(this.cameraFocus, this.CameraDistance);
            WorldInformation.Hitching = true;
            FurtherActionScript.instance.Hitching = true;
            FurtherActionScript.instance.ShowText();
        }
        if (this.EngineFX1)
        {
            this.EngineFX1.SetActive(true);
        }
        if (this.EngineFX2)
        {
            this.EngineFX2.SetActive(true);
        }
        if (this.EngineFX3)
        {
            this.EngineFX3.SetActive(true);
        }
    }

    public virtual IEnumerator Exit()
    {
        if (!this.isNPC)
        {
            this.transform.parent.gameObject.name = "UV";
            IndicatorScript.VehicleIsDamaged = false;
            IndicatorScript.GunIsDamaged = false;
            if (this.connectedVehicle.OpenVessel == false)
            {
                this.connectedVehicle.Inside = false;
                this.connectedVehicle.Starting = false;
                PlayerMotionAnimator.Transit = true;
                PlayerMotionAnimator.CanCollide = false;
                this.player.gameObject.SetActive(true);
                this.EscapeBubble.gameObject.SetActive(false);
                NotiScript.Notipoint = PlayerInformation.instance.PiriNose;
                PlayerInformation.instance.LBosom.localEulerAngles = new Vector3(280, 180, 0);
                PlayerInformation.instance.RBosom.localEulerAngles = new Vector3(280, 180, 0);
                PlayerInformation.instance.LBosom.localPosition = new Vector3(-0.09f, 0.44f, 0.02f);
                PlayerInformation.instance.RBosom.localPosition = new Vector3(0.09f, 0.44f, 0.02f);
                PlayerInformation.instance.PiriHead.localEulerAngles = new Vector3(0, 0, 0);
                PlayerInformation.instance.PiriHead.localPosition = new Vector3(0, 0.075f, 0);
                PlayerInformation.instance.PiriREye.localEulerAngles = new Vector3(0, 0, 0);
                PlayerInformation.instance.PiriLEye.localEulerAngles = new Vector3(0, 0, 0);
                this.playerW.transform.localEulerAngles = new Vector3(0, 0, 0);
                this.playerW.transform.localPosition = new Vector3(0, 0, 0);
                this.playerP.transform.localEulerAngles = new Vector3(0, 0, 0);
                this.playerP.transform.localPosition = new Vector3(0, -1.4f, 0);
                this.player.transform.localPosition = new Vector3(0, 0.8f, 0);
                this.player.transform.eulerAngles = new Vector3(0, 0, 0);
                this.player.transform.parent = null;
                PlayerInformation.instance.TCCol.radius = 1;
                PlayerInformation.instance.TCCol.center = new Vector3(0, -1, 0);
                PlayerInformation.instance.TCCol.height = 3;
                PlayerMotionAnimator.instance.CanMove = true;
                PlayerMotionAnimator.Landing = false;
                WorldInformation.UsingClosedVessel = false;
                WorldInformation.UsingBigVessel = false;
                if (this.isInteriorDoor)
                {
                    if (!WorldInformation.IsNopass)
                    {
                        WorldInformation.FPMode = true;
                    }
                }
                if (this.isCameraSetter)
                {
                    if (!WorldInformation.IsNopass)
                    {
                        CameraScript.cameraSetOnce = true;
                    }
                }
                WorldInformation.playerCar = "null";
                VehicleManager.ExitVehicle();
                this.inVehicle = false;
                CameraScript.instance.CheckCars(null, 0);
                PlayerMotionAnimator.lastVelocity = 0;
                this.player.GetComponent<Rigidbody>().velocity = this.VehicleRB.velocity;
                this.playerH.GetComponent<Rigidbody>().velocity = this.VehicleRB.velocity;
                this.playerW.GetComponent<Rigidbody>().velocity = this.VehicleRB.velocity;
                if (this.connectedVehicle.ThisVehiclesID == "Vessel420")
                {
                    WorldInformation.UsingSnyf = false;
                }
                yield return new WaitForSeconds(0.1f);
                WorldInformation.UsingVessel = false;
            }
            else
            {
                this.connectedVehicle.Inside = false;
                this.connectedVehicle.Starting = false;
                ((CapsuleCollider) this.player.GetComponent(typeof(CapsuleCollider))).isTrigger = false;
                ((SphereCollider) this.playerW.GetComponent(typeof(SphereCollider))).isTrigger = false;
                PlayerMotionAnimator.Transit = true;
                PlayerMotionAnimator.CanCollide = false;
                PlayerMotionAnimator.instance.CanFPAnimationaise = false;
                if (this.HeadCol)
                {
                    this.HeadCol.gameObject.SetActive(false);
                }
                WorldInformation.playerCar = "null";
                VehicleManager.ExitVehicle();
                this.inVehicle = false;
                CameraScript.instance.CheckCars(null, 0);
                float Y2 = this.player.transform.eulerAngles.y;
                this.player.transform.rotation = Quaternion.Euler(0, Y2, 0);
                this.playerW.transform.localEulerAngles = new Vector3(0, 0, 0);
                this.playerW.transform.localPosition = new Vector3(0, 0, 0);
                this.playerP.transform.localEulerAngles = new Vector3(0, 0, 0);
                this.playerP.transform.localPosition = new Vector3(0, -1.4f, 0);
                WorldInformation.UsingBigVessel = false;
                PlayerMotionAnimator.lastVelocity = 0;
                this.player.GetComponent<Rigidbody>().velocity = this.VehicleRB.velocity;
                this.playerH.GetComponent<Rigidbody>().velocity = this.VehicleRB.velocity;
                this.playerW.GetComponent<Rigidbody>().velocity = this.VehicleRB.velocity;
                this.playerW.SetActive(true);
                UnityEngine.Object.Destroy(this.BodyJoint);
                yield return new WaitForSeconds(0.1f);
                WorldInformation.UsingVessel = false;
            }
        }
        else
        {
            PlayerMotionAnimator.Transit = true;
            this.player.gameObject.SetActive(true);
            this.EscapeBubble.gameObject.SetActive(false);
            NotiScript.Notipoint = PlayerInformation.instance.PiriNose;
            PlayerInformation.instance.LBosom.localEulerAngles = new Vector3(280, 180, 0);
            PlayerInformation.instance.RBosom.localEulerAngles = new Vector3(280, 180, 0);
            PlayerInformation.instance.LBosom.localPosition = new Vector3(-0.09f, 0.44f, 0.02f);
            PlayerInformation.instance.RBosom.localPosition = new Vector3(0.09f, 0.44f, 0.02f);
            PlayerInformation.instance.PiriHead.localEulerAngles = new Vector3(0, 0, 0);
            PlayerInformation.instance.PiriHead.localPosition = new Vector3(0, 0.075f, 0);
            PlayerInformation.instance.PiriREye.localEulerAngles = new Vector3(0, 0, 0);
            PlayerInformation.instance.PiriLEye.localEulerAngles = new Vector3(0, 0, 0);
            this.playerW.transform.localEulerAngles = new Vector3(0, 0, 0);
            this.playerW.transform.localPosition = new Vector3(0, 0, 0);
            this.playerP.transform.localEulerAngles = new Vector3(0, 0, 0);
            this.playerP.transform.localPosition = new Vector3(0, -1.4f, 0);
            this.player.transform.localPosition = new Vector3(0, 0.8f, 0);
            this.player.transform.eulerAngles = new Vector3(0, 0, 0);
            this.player.transform.parent = null;
            PlayerInformation.instance.TCCol.radius = 1;
            PlayerInformation.instance.TCCol.center = new Vector3(0, -1, 0);
            PlayerInformation.instance.TCCol.height = 3;
            PlayerMotionAnimator.instance.CanMove = true;
            PlayerMotionAnimator.Landing = false;
            WorldInformation.UsingClosedVessel = false;
            WorldInformation.UsingBigVessel = false;
            WorldInformation.playerCar = "null";
            this.inVehicle = false;
            CameraScript.instance.CheckCars(null, 0);
            PlayerMotionAnimator.lastVelocity = 0;
            this.player.GetComponent<Rigidbody>().velocity = this.VehicleRB.velocity;
            this.playerH.GetComponent<Rigidbody>().velocity = this.VehicleRB.velocity;
            this.playerW.GetComponent<Rigidbody>().velocity = this.VehicleRB.velocity;
            WorldInformation.Hitching = false;
            yield return new WaitForSeconds(0.1f);
            WorldInformation.UsingVessel = false;
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("TC1p") && !this.DenyEntrance)
        {
            if (!other.name.Contains("mTC1"))
            {
                this.nearVehicle = true;
                WorldInformation.NearEntrance = true;
                if ((WorldInformation.vehicleDoorController == null) && !this.inVehicle)
                {
                    WorldInformation.vehicleDoorController = this;
                }
            }
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if (!this.isNPC)
        {
            if (this.CameraDistance < 16)
            {
                if (other.name.Contains("GaragePoint"))
                {
                    WorldInformation.NearGarage = true;
                }
            }
            if (other.name.Contains("GaragePointF1"))
            {
                WorldInformation.NearGarageF1 = true;
            }
            if (other.name.Contains("GaragePointF2"))
            {
                WorldInformation.NearGarageF2 = true;
            }
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("GaragePoint"))
        {
            PlayerPrefs.DeleteKey("GaragedID");
            PlayerPrefs.DeleteKey("GaragedDist");
            WorldInformation.NearGarage = false;
            WorldInformation.InGarage = false;
        }
        if (other.name.Contains("GaragePointF1"))
        {
            PlayerPrefs.DeleteKey("GaragedIDF1");
            PlayerPrefs.DeleteKey("GaragedDistF1");
            WorldInformation.NearGarageF1 = false;
            WorldInformation.InGarageF1 = false;
        }
        if (other.name.Contains("GaragePointF2"))
        {
            PlayerPrefs.DeleteKey("GaragedIDF2");
            PlayerPrefs.DeleteKey("GaragedDistF2");
            WorldInformation.NearGarageF2 = false;
            WorldInformation.InGarageF2 = false;
        }
        if (other.name.Contains("TC1p") && !this.DenyEntrance)
        {
            if (!other.name.Contains("mTC1"))
            {
                this.nearVehicle = false;
                WorldInformation.NearEntrance = false;
                if ((WorldInformation.vehicleDoorController == this) && !this.inVehicle)
                {
                    WorldInformation.vehicleDoorController = null;
                }
            }
        }
    }

}