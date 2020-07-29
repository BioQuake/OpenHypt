using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class CameraScript : MonoBehaviour
{
    public static CameraScript instance;
    public static bool InInterface;
    public float DefaultDistance;
    public Transform target;
    public GameObject speedOmeter;
    public GameObject PhysCam;
    public CapsuleCollider CamCol;
    public Transform PiriBodyCam;
    public Transform PiriHeadCam;
    public Transform CamResetPoint;
    public Transform pAimer;
    public static bool CamNoFP;
    public bool CamObstacle;
    public bool CamWater;
    public Camera TheCam;
    public Camera TheCam2;
    public bool StartingUp;
    public bool DoOnce;
    private Transform thisTF;
    private Transform presenceTF;
    public static bool changeColOnce;
    public static bool cameraSetOnce;
    public float UWallSensor;
    public float RWallSensor;
    public float CCRadius;
    public float CCHeight;
    public float UR;
    public float RR;
    public float URp;
    public float RRp;
    public static float ClipPlus;
    public float distance;
    private float OriginalDistance;
    public static int xSpeed;
    public static int ySpeed;
    public float yMinLimit;
    public int yMaxLimit;
    public float x;
    public float y;
    private int xdis;
    private Vector3 lastTarget;
    private bool rotating;
    public LayerMask targetLayers;
    public LayerMask targetLayersW;
    public LayerMask MtargetLayers;
    public virtual void Awake()
    {
        CameraScript.instance = this;
    }

    public virtual IEnumerator Start()
    {
        this.presenceTF = PlayerInformation.instance.PiriPresence;
        this.thisTF = this.PhysCam.transform;
        CameraScript.xSpeed = WorldInformation.Sensitivity;
        CameraScript.ySpeed = WorldInformation.Sensitivity;
        this.StartingUp = true;
        CameraScript.InInterface = false;
        if (!PlayerCamFollow.HoldCam)
        {
            if (!WorldInformation.FPMode)
            {
                this.StartCoroutine(this.ColOnceDelay2());
            }
        }
        Vector3 angles = this.transform.eulerAngles;
        this.x = angles.y;
        this.y = angles.x;
        yield return new WaitForSeconds(0.1f);
        this.lastTarget = this.target.position;
        this.StartingUp = false;
        if (!WorldInformation.FPMode)
        {
            this.CCRadius = 0.8f;
            this.CCHeight = 2.8f;
        }
        else
        {
            this.CCRadius = 0.2f;
            this.CCHeight = 0.2f;
        }
        this.tm = (TextMesh) this.speedOmeter.gameObject.GetComponent(typeof(TextMesh));
        yield return new WaitForSeconds(0.3f);
        Screen.lockCursor = true;
        yield return new WaitForSeconds(0.3f);
        Screen.lockCursor = false;
        yield return new WaitForSeconds(0.3f);
        Screen.lockCursor = true;
    }

    public virtual void CheckCars(Transform _target, float _distance)
    {
        if (_target != null)
        {
            this.target = _target;
            this.distance = _distance;
            this.OriginalDistance = _distance;
        }
        else
        {
            this.target = this.PiriBodyCam;
            this.distance = this.DefaultDistance;
            this.OriginalDistance = this.DefaultDistance;
        }
    }

    private int xtimer;
    public virtual void LateUpdate()
    {
        if (!CameraScript.InInterface)
        {
            this.x = this.x + ((Input.GetAxis("Mouse X") * CameraScript.xSpeed) * 0.02f);
            if (!this.CamWater)
            {
                this.y = this.y - ((Input.GetAxis("Mouse Y") * CameraScript.ySpeed) * 0.02f);
            }
            if (WorldInformation.playerCar != "null")
            {
                if (WorldInformation.FPMode)
                {
                    if (!Input.GetMouseButton(1))
                    {
                        this.x = this.PiriBodyCam.eulerAngles.y;
                    }
                }
            }
            if (WorldInformation.UsingClosedVessel == false)
            {
                if (WorldInformation.FPMode)
                {
                    if (!CameraScript.InInterface)
                    {
                        this.PhysCam.transform.position = this.PiriHeadCam.transform.position;
                        if (!WorldInformation.UsingBigVessel)
                        {
                            this.target = this.PiriHeadCam;
                        }
                    }
                }
                else
                {
                    if (!WorldInformation.UsingBigVessel)
                    {
                        this.target = this.PiriBodyCam;
                    }
                }
                if (!WorldInformation.IsNopass && !WorldInformation.FPMode)
                {
                    if (Input.GetMouseButton(1))
                    {
                        if (!CameraScript.InInterface && !CameraScript.CamNoFP)
                        {
                            this.PhysCam.transform.position = this.PiriHeadCam.transform.position;
                            if (!WorldInformation.UsingBigVessel)
                            {
                                this.target = this.PiriHeadCam;
                            }
                        }
                    }
                    else
                    {
                        if (!WorldInformation.UsingBigVessel)
                        {
                            this.target = this.PiriBodyCam;
                        }
                        CameraScript.CamNoFP = false;
                    }
                }
            }
        }
        else
        {
            if (WorldInformation.FPMode)
            {
                this.PhysCam.transform.position = this.PiriHeadCam.transform.position;
            }
        }
        CameraScript.ClipPlus = this.TheCam2.farClipPlane + 0.2f;
        this.UR = this.UWallSensor * this.TheCam2.farClipPlane;
        this.RR = this.RWallSensor * this.TheCam2.farClipPlane;
        this.URp = this.UR * 2;
        this.RRp = this.RR * 2;
        //Debug.DrawRay (PhysCam.transform.position + PhysCam.transform.forward * ClipPlus + PhysCam.transform.right * RR + PhysCam.transform.up * UR, -PhysCam.transform.right * RRp, Color.red);
        //Debug.DrawRay (PhysCam.transform.position + PhysCam.transform.forward * ClipPlus + PhysCam.transform.right * -RR + PhysCam.transform.up * UR, -PhysCam.transform.up * URp, Color.red);
        //Debug.DrawRay (PhysCam.transform.position + PhysCam.transform.forward * ClipPlus + PhysCam.transform.right * -RR + PhysCam.transform.up * -UR, PhysCam.transform.right * RRp, Color.red);
        //Debug.DrawRay (PhysCam.transform.position + PhysCam.transform.forward * ClipPlus + PhysCam.transform.right * RR + PhysCam.transform.up * -UR, PhysCam.transform.up * URp, Color.red);
        //Debug.DrawRay (PhysCam.transform.position + PhysCam.transform.forward * ClipPlus + PhysCam.transform.up * UR, -PhysCam.transform.up * URp, Color.red);
        if ((((!Physics.Raycast(((this.PhysCam.transform.position + (this.PhysCam.transform.forward * CameraScript.ClipPlus)) + (this.PhysCam.transform.right * this.RR)) + (this.PhysCam.transform.up * this.UR), -this.PhysCam.transform.right, this.RRp, (int) this.targetLayers) && !Physics.Raycast(((this.PhysCam.transform.position + (this.PhysCam.transform.forward * CameraScript.ClipPlus)) + (this.PhysCam.transform.right * -this.RR)) + (this.PhysCam.transform.up * this.UR), -this.PhysCam.transform.up, this.URp, (int) this.targetLayers)) && !Physics.Raycast(((this.PhysCam.transform.position + (this.PhysCam.transform.forward * CameraScript.ClipPlus)) + (this.PhysCam.transform.right * -this.RR)) + (this.PhysCam.transform.up * -this.UR), this.PhysCam.transform.right, this.RRp, (int) this.targetLayers)) && !Physics.Raycast(((this.PhysCam.transform.position + (this.PhysCam.transform.forward * CameraScript.ClipPlus)) + (this.PhysCam.transform.right * this.RR)) + (this.PhysCam.transform.up * -this.UR), this.PhysCam.transform.up, this.URp, (int) this.targetLayers)) && !Physics.Raycast((this.PhysCam.transform.position + (this.PhysCam.transform.forward * CameraScript.ClipPlus)) + (this.PhysCam.transform.up * this.UR), -this.PhysCam.transform.up, this.URp, (int) this.targetLayers))
        {
        }
        else
        {
            if (this.TheCam2.farClipPlane > 0.25f)
            {
                this.TheCam.nearClipPlane = this.TheCam.nearClipPlane - 0.1f;
                this.TheCam2.farClipPlane = this.TheCam2.farClipPlane - 0.1f;
            }
        }
    }

    public virtual void FixedUpdate()
    {
        Vector3 position2 = default(Vector3);
        if (!WorldInformation.FPMode)
        {
            if (!CameraScript.InInterface)
            {
                if (this.target && !WorldInformation.stopCamera)
                {
                    this.y = this.ClampAngle(this.y, this.yMinLimit, this.yMaxLimit);
                    Quaternion rotation = Quaternion.Euler(this.y, this.x, 0);
                    Vector3 position = (rotation * new Vector3(0f, 0f, -this.distance)) + this.target.position;
                    if (this.StartingUp)
                    {
                        rotation = this.transform.rotation;
                    }
                    if (!this.StartingUp)
                    {
                        this.transform.rotation = rotation;
                        this.transform.position = position;
                    }
                }
                if (this.target == null)
                {
                    this.target = this.PiriBodyCam;
                    this.transform.position = this.target.position;
                }
            }
            else
            {
                Quaternion rotation2 = Quaternion.Euler(this.y, this.x, 0);
                if (this.target)
                {
                    position2 = (rotation2 * new Vector3(0f, 0f, -this.distance)) + this.target.position;
                }
                else
                {
                    position2 = rotation2 * new Vector3(0f, 0f, -this.distance);
                }
                if (!this.StartingUp)
                {
                    if (!WorldInformation.stopCamera)
                    {
                        this.transform.position = position2;
                    }
                }
            }
            if (this.xtimer == 0)
            {
                this.xdis = (int) (Vector3.Distance(this.target.position, this.lastTarget) * 27);
                WorldInformation.vehicleSpeed = this.xdis;
                this.lastTarget = this.target.position;
                this.xtimer = 4;
            }
            else
            {
                this.xtimer = this.xtimer - 1;
            }
        }
        else
        {
            if (this.target && !WorldInformation.stopCamera)
            {
                this.y = this.ClampAngle(this.y, this.yMinLimit, this.yMaxLimit);
                Quaternion rotation3 = Quaternion.Euler(this.y, this.x, 0);
                this.transform.rotation = rotation3;
                this.transform.position = this.target.position;
            }
            if (this.target == null)
            {
                this.target = this.PiriBodyCam;
                this.transform.position = this.target.position;
            }
            if (this.xtimer == 0)
            {
                this.xdis = (int) (Vector3.Distance(this.target.position, this.lastTarget) * 27);
                WorldInformation.vehicleSpeed = this.xdis;
                this.lastTarget = this.target.position;
                this.xtimer = 4;
            }
            else
            {
                this.xtimer = this.xtimer - 1;
            }
        }
    }

    private TextMesh tm;
    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        RaycastHit hitSC = default(RaycastHit);
        if (!CameraScript.InInterface)
        {
            if (Physics.Raycast(this.PhysCam.transform.position, this.PhysCam.transform.forward, out hit, 0.5f, (int) this.targetLayers))
            {
                this.CamObstacle = true;
            }
            else
            {
                this.CamObstacle = false;
            }
            if (Physics.Raycast((this.PhysCam.transform.position + (this.PhysCam.transform.forward * 1.3f)) + (this.PhysCam.transform.up * 1), -this.PhysCam.transform.up, out hit, 1.75f, (int) this.targetLayersW))
            {
                if (hit.collider.name.Contains("w"))
                {
                    this.CamWater = true;
                }
            }
            else
            {
                this.CamWater = false;
            }
            if (this.tm != null)
            {
                this.tm.text = this.xdis.ToString();
            }
            if (!WorldInformation.FPMode)
            {
                if (this.DoOnce)
                {
                    this.CCRadius = 0.8f;
                    this.CCHeight = 2.8f;
                    if (!WorldInformation.UsingClosedVessel)
                    {
                        this.distance = this.OriginalDistance;
                        if (!Input.GetMouseButton(1))
                        {
                            this.CamCol.enabled = true;
                        }
                    }
                    else
                    {
                        this.CamCol.enabled = false;
                    }
                    this.DoOnce = false;
                }
            }
            if (WorldInformation.FPMode)
            {
                if (!this.DoOnce)
                {
                    this.CCRadius = 0.2f;
                    this.CCHeight = 0.2f;
                    if (!WorldInformation.UsingClosedVessel)
                    {
                        this.distance = 0;
                        this.CamCol.enabled = false;
                    }
                    else
                    {
                        this.CamCol.enabled = false;
                    }
                    this.DoOnce = true;
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                if (!WorldInformation.IsNopass)
                {
                    if (!WorldInformation.UsingClosedVessel)
                    {
                        this.CCRadius = 0.2f;
                        this.CCHeight = 0.2f;
                        PlayerMotionAnimator.PiriStill = true;
                        this.distance = 0;
                    }
                    if (WorldInformation.playerCar == "null")
                    {
                        this.PhysCam.GetComponent<Rigidbody>().isKinematic = true;
                        this.CamCol.enabled = false;
                    }
                    else
                    {
                        this.CamCol.enabled = true;
                        this.distance = this.OriginalDistance;
                    }
                }
            }
            if ((Input.GetMouseButtonUp(1) || (Input.GetMouseButtonDown(2) && (this.distance < 1))) || (Input.GetKeyDown(KeyCode.I) && (this.distance < 1)))
            {
                if (!WorldInformation.IsNopass && !CameraScript.InInterface)
                {
                    if (!WorldInformation.FPMode)
                    {
                        this.CCRadius = 0.8f;
                        this.CCHeight = 2.8f;
                        PlayerMotionAnimator.PiriStill = false;
                        this.distance = this.OriginalDistance;
                        if (!WorldInformation.UsingClosedVessel)
                        {
                            if (!WorldInformation.UsingBigVessel)
                            {
                                this.PhysCam.transform.position = this.CamResetPoint.transform.position;
                            }
                        }
                        if (!WorldInformation.UsingClosedVessel)
                        {
                            this.CamCol.enabled = false;
                        }
                        else
                        {
                            this.CamCol.enabled = true;
                        }
                        if (WorldInformation.playerCar == "null")
                        {
                            this.CamCol.enabled = true;
                            this.PhysCam.GetComponent<Rigidbody>().isKinematic = false;
                        }
                    }
                    else
                    {
                        this.CCRadius = 0.2f;
                        this.CCHeight = 0.2f;
                        if (!WorldInformation.UsingClosedVessel)
                        {
                            PlayerMotionAnimator.PiriStill = false;
                            this.CamCol.enabled = false;
                        }
                        else
                        {
                            this.CamCol.enabled = false;
                        }
                        if (WorldInformation.playerCar == "null")
                        {
                            this.CamCol.enabled = false;
                            this.PhysCam.GetComponent<Rigidbody>().isKinematic = false;
                        }
                    }
                }
            }
            if (!Input.GetMouseButton(1) && !WorldInformation.FPMode)
            {
                float d = Input.GetAxis("Mouse ScrollWheel");
                this.pAimer.LookAt(this.thisTF);
                if (this.distance > 0)
                {
                    Debug.DrawRay(this.pAimer.position, this.pAimer.forward * this.distance, Color.red);
                    if (Physics.Raycast(this.pAimer.position, this.pAimer.forward, out hitSC, this.distance, (int) this.MtargetLayers))
                    {
                        if (!Physics.Linecast(this.PhysCam.transform.position, this.pAimer.position, (int) this.MtargetLayers))
                        {
                            this.distance = hitSC.distance;
                        }
                    }
                }
                if (d > 0f)
                {
                    this.distance = this.distance - 1;
                }
                else
                {
                    if (d < 0f)
                    {
                        this.distance = this.distance + 1;
                    }
                }
            }
        }
        CameraScript.ClipPlus = this.TheCam2.farClipPlane + 0.2f;
        //Debug.DrawRay (PhysCam.transform.position + PhysCam.transform.forward * ClipPlus + PhysCam.transform.right * RR + PhysCam.transform.up * UR, -PhysCam.transform.right * RRp, Color.red);
        //Debug.DrawRay (PhysCam.transform.position + PhysCam.transform.forward * ClipPlus + PhysCam.transform.right * -RR + PhysCam.transform.up * UR, -PhysCam.transform.up * URp, Color.red);
        //Debug.DrawRay (PhysCam.transform.position + PhysCam.transform.forward * ClipPlus + PhysCam.transform.right * -RR + PhysCam.transform.up * -UR, PhysCam.transform.right * RRp, Color.red);
        //Debug.DrawRay (PhysCam.transform.position + PhysCam.transform.forward * ClipPlus + PhysCam.transform.right * RR + PhysCam.transform.up * -UR, PhysCam.transform.up * URp, Color.red);
        //Debug.DrawRay (PhysCam.transform.position + PhysCam.transform.forward * ClipPlus + PhysCam.transform.up * UR, -PhysCam.transform.up * URp, Color.red);
        if ((((!Physics.Raycast(((this.PhysCam.transform.position + (this.PhysCam.transform.forward * CameraScript.ClipPlus)) + (this.PhysCam.transform.right * this.RR)) + (this.PhysCam.transform.up * this.UR), -this.PhysCam.transform.right, this.RRp, (int) this.targetLayers) && !Physics.Raycast(((this.PhysCam.transform.position + (this.PhysCam.transform.forward * CameraScript.ClipPlus)) + (this.PhysCam.transform.right * -this.RR)) + (this.PhysCam.transform.up * this.UR), -this.PhysCam.transform.up, this.URp, (int) this.targetLayers)) && !Physics.Raycast(((this.PhysCam.transform.position + (this.PhysCam.transform.forward * CameraScript.ClipPlus)) + (this.PhysCam.transform.right * -this.RR)) + (this.PhysCam.transform.up * -this.UR), this.PhysCam.transform.right, this.RRp, (int) this.targetLayers)) && !Physics.Raycast(((this.PhysCam.transform.position + (this.PhysCam.transform.forward * CameraScript.ClipPlus)) + (this.PhysCam.transform.right * this.RR)) + (this.PhysCam.transform.up * -this.UR), this.PhysCam.transform.up, this.URp, (int) this.targetLayers)) && !Physics.Raycast((this.PhysCam.transform.position + (this.PhysCam.transform.forward * CameraScript.ClipPlus)) + (this.PhysCam.transform.up * this.UR), -this.PhysCam.transform.up, this.URp, (int) this.targetLayers))
        {
            if (this.TheCam2.farClipPlane < 1)
            {
                this.TheCam.nearClipPlane = this.TheCam.nearClipPlane + 0.1f;
                this.TheCam2.farClipPlane = this.TheCam2.farClipPlane + 0.1f;
            }
        }
        if (Input.GetKeyDown(KeyCode.I) || Input.GetMouseButtonDown(2))
        {
            if (!TalkScript.isTyping)
            {
                if (!CameraScript.InInterface)
                {
                    CameraScript.InInterface = true;
                    this.distance = this.OriginalDistance;
                    PlayerMotionAnimator.PiriStill = true;
                    Screen.lockCursor = false;
                    Cursor.visible = true;
                }
                else
                {
                    CameraScript.InInterface = false;
                    this.distance = this.OriginalDistance;
                    PlayerMotionAnimator.PiriStill = false;
                    Screen.lockCursor = true;
                    Cursor.visible = false;
                }
                if (Input.GetMouseButton(1))
                {
                    CameraScript.CamNoFP = true;
                }
            }
        }
        if (this.CamCol.radius < this.CCRadius)
        {
            this.CamCol.radius = this.CamCol.radius + 0.01f;
        }
        if (this.CamCol.height < this.CCHeight)
        {
            this.CamCol.height = this.CamCol.height + 0.02f;
        }
        if (this.CamCol.radius > this.CCRadius)
        {
            this.CamCol.radius = this.CCRadius;
        }
        if (this.CamCol.height > this.CCHeight)
        {
            this.CamCol.height = this.CCHeight;
        }
        if (CameraScript.changeColOnce)
        {
            this.StartCoroutine(this.ColOnceDelay());
            CameraScript.changeColOnce = false;
        }
        if (CameraScript.cameraSetOnce)
        {
            this.StartCoroutine(this.CameraSet());
            CameraScript.cameraSetOnce = false;
        }
    }

    public virtual IEnumerator ColOnceDelay()
    {
        this.CamCol.enabled = false;
        yield return new WaitForSeconds(0.3f);
        this.CCRadius = 0.8f;
        this.CCHeight = 2.8f;
        this.distance = this.OriginalDistance;
        this.CamCol.enabled = true;
    }

    public virtual IEnumerator ColOnceDelay2()
    {
        this.CamCol.enabled = false;
        yield return new WaitForSeconds(1);
        this.CamCol.enabled = true;
    }

    public virtual IEnumerator CameraSet()
    {
        WorldInformation.FPMode = true;
        yield return new WaitForSeconds(0.3f);
        WorldInformation.FPMode = false;
    }

    public virtual float ClampAngle(float angle, float min, float max)
    {
        if (this.CamWater)
        {
            angle = angle - 10;
            if (angle > 0)
            {
                angle = 0;
            }
        }
        else
        {
            if (this.CamObstacle)
            {
                angle = 0;
            }
        }
        if (WorldInformation.FPMode)
        {
            if (!Input.GetMouseButton(1))
            {
                if (angle < -30)
                {
                    angle = -30;
                }
                if (angle > 30)
                {
                    angle = 30;
                }
            }
            if (Input.GetMouseButton(1))
            {
                if (angle < -60)
                {
                    angle = -60;
                }
                if (angle > 60)
                {
                    angle = 60;
                }
            }
        }
        if (!WorldInformation.FPMode)
        {
            if (angle < -60)
            {
                angle = -60;
            }
            if (angle > 60)
            {
                angle = 60;
            }
        }
        return Mathf.Clamp(angle, min, max);
    }

    public CameraScript()
    {
        this.DefaultDistance = 3.5f;
        this.UWallSensor = 1.5f;
        this.RWallSensor = 1.5f;
        this.CCRadius = 0.8f;
        this.CCHeight = 2.8f;
        this.UR = 1;
        this.RR = 1;
        this.URp = 1;
        this.RRp = 1;
        this.distance = 3.5f;
        this.OriginalDistance = 3.5f;
        this.yMinLimit = -0.5f;
        this.yMaxLimit = 80;
        this.xtimer = 1;
    }

    static CameraScript()
    {
        CameraScript.ClipPlus = 1;
        CameraScript.xSpeed = 60;
        CameraScript.ySpeed = 60;
    }

}