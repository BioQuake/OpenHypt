using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AmmoBotAI : MonoBehaviour
{
    public Transform target;
    public Transform ResetView;
    public Transform Waypoint;
    public Transform ReloadPoint;
    public Transform DispensePoint;
    public GameObject Gyro;
    public SphereCollider Trig;
    public GameObject Vessel;
    public VehicleDamage HealthScript;
    public GameObject Ammo1;
    public GameObject Ammo2;
    public GameObject Ammo3;
    public GameObject Ammo4;
    public GameObject Ammo5;
    public bool DoorOpen;
    public Transform VPoint;
    public int ThreatenedByTC1;
    public int ThreatenedByTC4;
    public int ThreatenedByTC6;
    public int ThreatenedByTC7;
    public int ThreatPerimiter;
    public Transform Stranger;
    public Transform RoadTF;
    public Transform RoadTF2;
    public bool Road;
    public int RoadTime;
    public bool SinglePath;
    public bool OpenTop;
    public bool DriftyVessel;
    public float Proddy;
    public bool IsInside;
    public bool FreeFloating;
    public bool CanDrive;
    public bool Threatened;
    public bool Obstacle;
    public bool TurnRight;
    public bool TurnLeft;
    public bool StrafeRight;
    public bool StrafeLeft;
    public bool Pivot;
    public float VelLowClamp;
    public float ObsStartY;
    public float ObsStartZ;
    public float StrafeEndSide;
    public float RightDist;
    public float LeftDist;
    public float UpDist;
    public float DownDist;
    public float TopSpeed;
    public float BrakeForce;
    public float TurnForce;
    public float TurnSpeed;
    public float DirForce;
    public float TurnStabForce;
    public float TurnStabMod;
    public float AimSpeed;
    public float IncThreshold;
    public float Ride;
    public float Vel;
    public bool IsClose;
    public bool IsSettled;
    public bool SteepInc;
    public LayerMask targetLayers;
    public LayerMask MtargetLayers;
    public bool Pathfind;
    public bool GoToPath;
    public int PRot;
    public int PCount;
    public bool FullRot;
    public Vector3 PathPoint1;
    public Vector3 PathPoint2;
    public Vector3 PathPoint3;
    public int Stuck;
    public int Escaping;
    public int TForce;
    public int Turnerisms;
    public ConfigurableJoint ConfJ;
    public virtual void Start()
    {
        this.InvokeRepeating("Updater", 2, 1);
        this.InvokeRepeating("Navigator", 1.33f, 0.33f);
        this.InvokeRepeating("Refresher", 1.13f, 0.16f);
        this.InvokeRepeating("Targety", 4, 4);
        this.InvokeRepeating("Pathy", 30, 30);

        {
            float _616 = this.Vessel.GetComponent<Rigidbody>().mass * 0.5f;
            JointDrive _617 = this.ConfJ.angularYZDrive;
            _617.maximumForce = _616;
            this.ConfJ.angularYZDrive = _617;
        }
        this.CanDrive = true;
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        RaycastHit hit2 = default(RaycastHit);
        RaycastHit Phit = default(RaycastHit);
        if ((!this.TurnLeft && !this.TurnRight) && !this.Obstacle)
        {
            this.GetComponent<Rigidbody>().freezeRotation = true;
        }
        if ((this.TurnLeft || this.TurnRight) || this.Obstacle)
        {
            this.GetComponent<Rigidbody>().freezeRotation = false;
        }
        Vector3 newRot2 = this.Vessel.GetComponent<Rigidbody>().velocity;
        Vector3 newRot = -this.Vessel.transform.up.normalized;
        float ObsStartZPLUS = this.ObsStartZ + this.Ride;
        float VelClamp = Mathf.Clamp(this.Vel, this.VelLowClamp, 1000);
        float ObsVelClamp = Mathf.Clamp(this.Vel, 0.1f, 1000);
        float VelSplit = VelClamp * 0.5f;
        float Angle = Mathf.Abs(this.UpDist - this.DownDist);
        if (!this.TurnLeft && !this.TurnRight)
        {
            Vector3 VesselAngVel = this.Vessel.transform.InverseTransformDirection(this.Vessel.GetComponent<Rigidbody>().angularVelocity);
            float AV1 = VesselAngVel.z * this.TurnStabMod;
            float AV2 = Mathf.Clamp(AV1, -10, 10);
            this.TurnStabForce = -AV2;
        }
        if (this.DriftyVessel || this.FreeFloating)
        {
            if (this.Vessel.GetComponent<Rigidbody>().velocity.magnitude > 1)
            {
                this.VPoint.transform.rotation = Quaternion.LookRotation(this.Vessel.GetComponent<Rigidbody>().velocity);
            }
        }
        Debug.DrawRay((this.Vessel.transform.position + (-this.Vessel.transform.up * this.ObsStartY)) + (this.Vessel.transform.forward * this.ObsStartZ), -this.Vessel.transform.up * ObsVelClamp, Color.white);
        if (Physics.Raycast((this.Vessel.transform.position + (-this.Vessel.transform.up * this.ObsStartY)) + (this.Vessel.transform.forward * this.ObsStartZ), -this.Vessel.transform.up, ObsVelClamp, (int) this.targetLayers))
        {
            if (this.SteepInc)
            {
                this.Obstacle = true;
            }
        }
        else
        {
            this.Obstacle = false;
        }
        if (!this.FreeFloating)
        {
            if (!this.SinglePath)
            {
                Debug.DrawRay(this.transform.position + (newRot * VelClamp), -this.Vessel.transform.forward * 10, Color.green);
                if (Physics.Raycast(this.transform.position + (newRot * VelClamp), -this.Vessel.transform.forward, out hit, 10, (int) this.MtargetLayers))
                {
                    if (hit.collider.name.Contains("RoadAlign"))
                    {
                        this.target = this.ResetView;
                        this.GoToPath = false;
                        this.Road = true;
                        this.RoadTF = hit.transform;
                        this.GetComponent<Rigidbody>().freezeRotation = true;
                    }
                }
            }
            else
            {
                Debug.DrawRay(this.transform.position + (newRot * VelClamp), -this.Vessel.transform.forward * 10, Color.green);
                if (Physics.Raycast(this.transform.position + (newRot * VelClamp), -this.Vessel.transform.forward, out hit, 10, (int) this.MtargetLayers))
                {
                    if (hit.collider.name.Contains("RoadAlign"))
                    {
                        if (hit.transform == this.RoadTF)
                        {
                            this.RoadTime = 20;
                            this.Road = true;
                        }
                        if (this.RoadTF == null)
                        {
                            this.target = this.ResetView;
                            this.GoToPath = false;
                            this.RoadTF = hit.transform;
                            this.GetComponent<Rigidbody>().freezeRotation = true;
                        }
                    }
                }
            }
        }
        else
        {
            if (!this.SinglePath)
            {
                Debug.DrawRay(this.transform.position + (newRot * VelClamp), -this.Vessel.transform.forward * 10, Color.green);
                if (Physics.Raycast(this.transform.position + (newRot * VelClamp), -this.Vessel.transform.forward, out hit, 10, (int) this.MtargetLayers))
                {
                    if (hit.collider.name.Contains("PathAlign"))
                    {
                        this.target = this.ResetView;
                        this.GoToPath = false;
                        this.Road = true;
                        this.RoadTF = hit.transform;
                        this.GetComponent<Rigidbody>().freezeRotation = true;
                    }
                }
            }
            else
            {
                Debug.DrawRay(this.transform.position + (newRot * VelClamp), -this.Vessel.transform.forward * 10, Color.green);
                if (Physics.Raycast(this.transform.position + (newRot * VelClamp), -this.Vessel.transform.forward, out hit, 10, (int) this.MtargetLayers))
                {
                    if (hit.collider.name.Contains("PathAlign"))
                    {
                        if (hit.transform == this.RoadTF)
                        {
                            this.RoadTime = 20;
                            this.Road = true;
                        }
                        if (this.RoadTF == null)
                        {
                            this.target = this.ResetView;
                            this.GoToPath = false;
                            this.RoadTF = hit.transform;
                            this.GetComponent<Rigidbody>().freezeRotation = true;
                        }
                    }
                }
            }
        }
        Debug.DrawRay(((this.Vessel.transform.position + (-this.Vessel.transform.up * this.ObsStartY)) + (this.Vessel.transform.forward * ObsStartZPLUS)) + (this.Vessel.transform.right * this.StrafeEndSide), newRot * VelClamp, Color.black);
        if (Physics.Raycast(((this.Vessel.transform.position + (-this.Vessel.transform.up * this.ObsStartY)) + (this.Vessel.transform.forward * ObsStartZPLUS)) + (this.Vessel.transform.right * this.StrafeEndSide), newRot, out hit, VelClamp, (int) this.targetLayers))
        {
            if (!this.IsClose)
            {
                this.RightDist = hit.distance;
            }
            else
            {
                this.StrafeRight = true;
            }
        }
        else
        {
            this.RightDist = VelClamp;
        }
        Debug.DrawRay(((this.Vessel.transform.position + (-this.Vessel.transform.up * this.ObsStartY)) + (this.Vessel.transform.forward * ObsStartZPLUS)) + (-this.Vessel.transform.right * this.StrafeEndSide), newRot * VelClamp, Color.black);
        if (Physics.Raycast(((this.Vessel.transform.position + (-this.Vessel.transform.up * this.ObsStartY)) + (this.Vessel.transform.forward * ObsStartZPLUS)) + (-this.Vessel.transform.right * this.StrafeEndSide), newRot, out hit, VelClamp, (int) this.targetLayers))
        {
            if (!this.IsClose)
            {
                this.LeftDist = hit.distance;
            }
            else
            {
                this.StrafeRight = true;
            }
        }
        else
        {
            this.LeftDist = VelClamp;
        }
        Debug.DrawRay((this.Vessel.transform.position + (-this.Vessel.transform.up * this.ObsStartY)) + (this.Vessel.transform.forward * 0.2f), (newRot * VelClamp) * 1.2f, Color.green);
        if (Physics.Raycast((this.Vessel.transform.position + (-this.Vessel.transform.up * this.ObsStartY)) + (this.Vessel.transform.forward * 0.2f), newRot, out hit2, VelClamp))
        {
            this.UpDist = hit2.distance;
        }
        else
        {
            this.UpDist = 8;
        }
        Debug.DrawRay((this.Vessel.transform.position + (-this.Vessel.transform.up * this.ObsStartY)) + (this.Vessel.transform.forward * -0.2f), (newRot * VelClamp) * 1.2f, Color.green);
        if (Physics.Raycast((this.Vessel.transform.position + (-this.Vessel.transform.up * this.ObsStartY)) + (this.Vessel.transform.forward * -0.2f), newRot, out hit2, VelClamp))
        {
            this.DownDist = hit2.distance;
        }
        else
        {
            this.DownDist = 8;
        }
        if (Angle < this.IncThreshold)
        {
            this.SteepInc = true;
        }
        else
        {
            this.SteepInc = false;
        }
        if ((this.RightDist > this.LeftDist) && this.SteepInc)
        {

            {
                float _618 = 0.1f;
                JointDrive _619 = this.ConfJ.angularYZDrive;
                _619.maximumForce = _618;
                this.ConfJ.angularYZDrive = _619;
            }
            this.TurnRight = true;
        }
        if ((this.LeftDist > this.RightDist) && this.SteepInc)
        {

            {
                float _620 = 0.1f;
                JointDrive _621 = this.ConfJ.angularYZDrive;
                _621.maximumForce = _620;
                this.ConfJ.angularYZDrive = _621;
            }
            this.TurnLeft = true;
        }
        if (this.RightDist == this.LeftDist)
        {
            this.TurnRight = false;
            this.TurnLeft = false;
        }
        //---------------------------------------------------------------------------------------------
        if (!this.FreeFloating)
        {
            Debug.DrawRay((this.transform.position + (this.Vessel.transform.forward * 10)) + (newRot * ObsVelClamp), -this.Vessel.transform.forward * 20, Color.white);
            if (!Physics.Raycast((this.transform.position + (this.Vessel.transform.forward * 10)) + (newRot * ObsVelClamp), -this.Vessel.transform.forward, 20))
            {
                this.Obstacle = true;

                {
                    float _622 = 0.1f;
                    JointDrive _623 = this.ConfJ.angularYZDrive;
                    _623.maximumForce = _622;
                    this.ConfJ.angularYZDrive = _623;
                }
            }
            Debug.DrawRay(((this.transform.position + (this.Vessel.transform.forward * 10)) + (this.Vessel.transform.right * this.StrafeEndSide)) + (-this.Vessel.transform.up * VelClamp), -this.Vessel.transform.forward * 20, Color.white);
            if (!Physics.Raycast(((this.transform.position + (this.Vessel.transform.forward * 10)) + (this.Vessel.transform.right * this.StrafeEndSide)) + (-this.Vessel.transform.up * VelClamp), -this.Vessel.transform.forward, 20))
            {

                {
                    float _624 = 0.1f;
                    JointDrive _625 = this.ConfJ.angularYZDrive;
                    _625.maximumForce = _624;
                    this.ConfJ.angularYZDrive = _625;
                }
                this.TurnLeft = true;
            }
            Debug.DrawRay(((this.transform.position + (this.Vessel.transform.forward * 10)) + (-this.Vessel.transform.right * this.StrafeEndSide)) + (-this.Vessel.transform.up * VelClamp), -this.Vessel.transform.forward * 20, Color.white);
            if (!Physics.Raycast(((this.transform.position + (this.Vessel.transform.forward * 10)) + (-this.Vessel.transform.right * this.StrafeEndSide)) + (-this.Vessel.transform.up * VelClamp), -this.Vessel.transform.forward, 20))
            {

                {
                    float _626 = 0.1f;
                    JointDrive _627 = this.ConfJ.angularYZDrive;
                    _627.maximumForce = _626;
                    this.ConfJ.angularYZDrive = _627;
                }
                this.TurnRight = true;
            }
            Debug.DrawRay(((this.transform.position + (this.Vessel.transform.forward * 10)) + (this.Vessel.transform.right * 10)) + (-this.Vessel.transform.up * VelClamp), -this.Vessel.transform.forward * 20, Color.white);
            if (!Physics.Raycast(((this.transform.position + (this.Vessel.transform.forward * 10)) + (this.Vessel.transform.right * 10)) + (-this.Vessel.transform.up * VelClamp), -this.Vessel.transform.forward, 20, (int) this.MtargetLayers))
            {

                {
                    float _628 = 0.1f;
                    JointDrive _629 = this.ConfJ.angularYZDrive;
                    _629.maximumForce = _628;
                    this.ConfJ.angularYZDrive = _629;
                }
                this.TurnLeft = true;
            }
            Debug.DrawRay(((this.transform.position + (this.Vessel.transform.forward * 10)) + (-this.Vessel.transform.right * 10)) + (-this.Vessel.transform.up * VelClamp), -this.Vessel.transform.forward * 20, Color.white);
            if (!Physics.Raycast(((this.transform.position + (this.Vessel.transform.forward * 10)) + (-this.Vessel.transform.right * 10)) + (-this.Vessel.transform.up * VelClamp), -this.Vessel.transform.forward, 20, (int) this.MtargetLayers))
            {

                {
                    float _630 = 0.1f;
                    JointDrive _631 = this.ConfJ.angularYZDrive;
                    _631.maximumForce = _630;
                    this.ConfJ.angularYZDrive = _631;
                }
                this.TurnRight = true;
            }
        }
        else
        {
            Debug.DrawRay(this.transform.position + (newRot * ObsVelClamp), -this.Vessel.transform.forward * 10, Color.white);
            if (Physics.Raycast(this.transform.position + (newRot * ObsVelClamp), -this.Vessel.transform.forward, 10, (int) this.MtargetLayers))
            {
                if (this.SteepInc)
                {
                    this.Obstacle = true;

                    {
                        float _632 = 0.1f;
                        JointDrive _633 = this.ConfJ.angularYZDrive;
                        _633.maximumForce = _632;
                        this.ConfJ.angularYZDrive = _633;
                    }
                }
            }
            Debug.DrawRay(((this.transform.position + (this.Vessel.transform.forward * 10)) + (this.VPoint.transform.right * 10)) + (this.VPoint.transform.forward * VelClamp), -this.Vessel.transform.forward * 20, Color.white);
            if (Physics.Raycast(((this.transform.position + (this.Vessel.transform.forward * 10)) + (this.VPoint.transform.right * 10)) + (this.VPoint.transform.forward * VelClamp), -this.Vessel.transform.forward, 20, (int) this.MtargetLayers))
            {

                {
                    float _634 = 0.1f;
                    JointDrive _635 = this.ConfJ.angularYZDrive;
                    _635.maximumForce = _634;
                    this.ConfJ.angularYZDrive = _635;
                }
                this.TurnLeft = true;
            }
            Debug.DrawRay(((this.transform.position + (this.Vessel.transform.forward * 10)) + (-this.VPoint.transform.right * 10)) + (this.VPoint.transform.forward * VelClamp), -this.Vessel.transform.forward * 20, Color.white);
            if (Physics.Raycast(((this.transform.position + (this.Vessel.transform.forward * 10)) + (-this.VPoint.transform.right * 10)) + (this.VPoint.transform.forward * VelClamp), -this.Vessel.transform.forward, 20, (int) this.MtargetLayers))
            {

                {
                    float _636 = 0.1f;
                    JointDrive _637 = this.ConfJ.angularYZDrive;
                    _637.maximumForce = _636;
                    this.ConfJ.angularYZDrive = _637;
                }
                this.TurnRight = true;
            }
            Debug.DrawRay(((this.transform.position + (this.Vessel.transform.forward * 10)) + (this.Vessel.transform.right * 10)) + (-this.Vessel.transform.up * VelClamp), -this.Vessel.transform.forward * 20, Color.white);
            if (Physics.Raycast(((this.transform.position + (this.Vessel.transform.forward * 10)) + (this.Vessel.transform.right * 10)) + (-this.Vessel.transform.up * VelClamp), -this.Vessel.transform.forward, 20, (int) this.MtargetLayers))
            {

                {
                    float _638 = 0.1f;
                    JointDrive _639 = this.ConfJ.angularYZDrive;
                    _639.maximumForce = _638;
                    this.ConfJ.angularYZDrive = _639;
                }
                this.TurnLeft = true;
            }
            Debug.DrawRay(((this.transform.position + (this.Vessel.transform.forward * 10)) + (-this.Vessel.transform.right * 10)) + (-this.Vessel.transform.up * VelClamp), -this.Vessel.transform.forward * 20, Color.white);
            if (Physics.Raycast(((this.transform.position + (this.Vessel.transform.forward * 10)) + (-this.Vessel.transform.right * 10)) + (-this.Vessel.transform.up * VelClamp), -this.Vessel.transform.forward, 20, (int) this.MtargetLayers))
            {

                {
                    float _640 = 0.1f;
                    JointDrive _641 = this.ConfJ.angularYZDrive;
                    _641.maximumForce = _640;
                    this.ConfJ.angularYZDrive = _641;
                }
                this.TurnRight = true;
            }
        }
        //---------------------------------------------------------------------------------------------
        if ((this.RoadTF != null) && (this.RoadTF2 != null))
        {
            if (!this.RoadTF.name.Contains(this.RoadTF2.name))
            {
                if (this.Vel > 30)
                {
                    this.Obstacle = true;
                }
                else
                {
                    this.Obstacle = false;
                }
            }
        }
        if (this.IsClose)
        {
            if (this.ReloadPoint)
            {
                if (Vector3.Distance(this.DispensePoint.position, this.ReloadPoint.position) > 1)
                {
                    Debug.DrawRay((this.Vessel.transform.position + (-this.Vessel.transform.up * this.ObsStartY)) + (this.Vessel.transform.forward * this.ObsStartZ), this.Vessel.transform.right * this.StrafeEndSide, Color.black);
                    if (Physics.Raycast((this.Vessel.transform.position + (-this.Vessel.transform.up * this.ObsStartY)) + (this.Vessel.transform.forward * this.ObsStartZ), this.Vessel.transform.right, this.StrafeEndSide, (int) this.targetLayers))
                    {
                        this.StrafeLeft = true;
                    }
                    else
                    {
                        this.StrafeLeft = false;
                    }
                    Debug.DrawRay((this.Vessel.transform.position + (-this.Vessel.transform.up * this.ObsStartY)) + (this.Vessel.transform.forward * this.ObsStartZ), -this.Vessel.transform.right * this.StrafeEndSide, Color.black);
                    if (Physics.Raycast((this.Vessel.transform.position + (-this.Vessel.transform.up * this.ObsStartY)) + (this.Vessel.transform.forward * this.ObsStartZ), -this.Vessel.transform.right, this.StrafeEndSide, (int) this.targetLayers))
                    {
                        this.StrafeRight = true;
                    }
                    else
                    {
                        this.StrafeRight = false;
                    }
                    Debug.DrawRay(((this.Vessel.transform.position + (-this.Vessel.transform.up * this.ObsStartY)) + (this.Vessel.transform.forward * 0.5f)) + ((this.Vessel.transform.right * this.StrafeEndSide) * 0.5f), newRot * 1.2f, Color.grey);
                    Debug.DrawRay(((this.Vessel.transform.position + (-this.Vessel.transform.up * this.ObsStartY)) + (-this.Vessel.transform.forward * 0.5f)) + ((this.Vessel.transform.right * this.StrafeEndSide) * 0.5f), newRot * 1.2f, Color.grey);
                    if (Physics.Raycast(((this.Vessel.transform.position + (-this.Vessel.transform.up * this.ObsStartY)) + (this.Vessel.transform.forward * 0.5f)) + ((this.Vessel.transform.right * this.StrafeEndSide) * 0.5f), newRot, 1.2f, (int) this.targetLayers) || Physics.Raycast(((this.Vessel.transform.position + (-this.Vessel.transform.up * this.ObsStartY)) + (-this.Vessel.transform.forward * 0.5f)) + ((this.Vessel.transform.right * this.StrafeEndSide) * 0.5f), newRot, 1.2f, (int) this.targetLayers))
                    {
                        this.StrafeLeft = true;
                    }
                    Debug.DrawRay(((this.Vessel.transform.position + (-this.Vessel.transform.up * this.ObsStartY)) + (this.Vessel.transform.forward * 0.5f)) + ((-this.Vessel.transform.right * this.StrafeEndSide) * 0.5f), newRot * 1.2f, Color.grey);
                    Debug.DrawRay(((this.Vessel.transform.position + (-this.Vessel.transform.up * this.ObsStartY)) + (-this.Vessel.transform.forward * 0.5f)) + ((-this.Vessel.transform.right * this.StrafeEndSide) * 0.5f), newRot * 1.2f, Color.grey);
                    if (Physics.Raycast(((this.Vessel.transform.position + (-this.Vessel.transform.up * this.ObsStartY)) + (this.Vessel.transform.forward * 0.5f)) + ((-this.Vessel.transform.right * this.StrafeEndSide) * 0.5f), newRot, 1.2f, (int) this.targetLayers) || Physics.Raycast(((this.Vessel.transform.position + (-this.Vessel.transform.up * this.ObsStartY)) + (-this.Vessel.transform.forward * 0.5f)) + ((-this.Vessel.transform.right * this.StrafeEndSide) * 0.5f), newRot, 1.2f, (int) this.targetLayers))
                    {
                        this.StrafeRight = true;
                    }
                }
            }
            Debug.DrawRay(((this.Vessel.transform.position + (-this.Vessel.transform.up * this.ObsStartY)) + (this.Vessel.transform.forward * 0.5f)) + ((this.Vessel.transform.right * this.StrafeEndSide) * 0.5f), newRot * 1, Color.white);
            Debug.DrawRay(((this.Vessel.transform.position + (-this.Vessel.transform.up * this.ObsStartY)) + (this.Vessel.transform.forward * 0.5f)) + ((-this.Vessel.transform.right * this.StrafeEndSide) * 0.5f), newRot * 1, Color.white);
            if (Physics.Raycast(((this.Vessel.transform.position + (-this.Vessel.transform.up * this.ObsStartY)) + (this.Vessel.transform.forward * 0.5f)) + ((this.Vessel.transform.right * this.StrafeEndSide) * 0.5f), newRot, 1, (int) this.targetLayers) || Physics.Raycast(((this.Vessel.transform.position + (-this.Vessel.transform.up * this.ObsStartY)) + (this.Vessel.transform.forward * 0.5f)) + ((-this.Vessel.transform.right * this.StrafeEndSide) * 0.5f), newRot, 1, (int) this.targetLayers))
            {
                this.Obstacle = true;
            }
        }
        if ((this.Stuck > 0) && !this.Pivot)
        {
            Debug.DrawRay((this.Vessel.transform.position + (this.Vessel.transform.up * this.ObsStartY)) + (this.Vessel.transform.forward * this.ObsStartZ), this.Vessel.transform.up * VelSplit, Color.white);
            if (Physics.Raycast((this.Vessel.transform.position + (this.Vessel.transform.up * this.ObsStartY)) + (this.Vessel.transform.forward * this.ObsStartZ), this.Vessel.transform.up, VelSplit * 0.5f))
            {
                this.Stuck = 0;
                this.Turnerisms = 0;
            }
            Debug.DrawRay(this.Vessel.transform.position + (this.Vessel.transform.up * VelSplit), -this.Vessel.transform.forward * 10f, Color.white);
            if (!Physics.Raycast(this.Vessel.transform.position + (this.Vessel.transform.up * VelSplit), -this.Vessel.transform.forward, 10))
            {
                this.Stuck = 0;
                this.Turnerisms = 0;
            }
        }
        if (this.RoadTF && this.FreeFloating)
        {
            Vector3 relativePoint = this.RoadTF.transform.InverseTransformPoint(this.Vessel.transform.position);
            this.Proddy = relativePoint.x;
            if (relativePoint.x < -20)
            {
                this.TurnRight = true;
            }
            if (relativePoint.x > 20)
            {
                this.TurnLeft = true;
            }
        }
        if (this.Pathfind)
        {
            Debug.DrawRay((this.Vessel.transform.position + (this.Vessel.transform.forward * 10)) + (this.ResetView.transform.up * 250), -this.Vessel.transform.forward * 20f, Color.red);
            if (Physics.Raycast((this.Vessel.transform.position + (this.Vessel.transform.forward * 10)) + (this.ResetView.transform.up * 250), -this.Vessel.transform.forward, out Phit, 20))
            {
                if (this.FullRot && (this.PCount == 1))
                {
                    this.PathPoint1 = Phit.point;
                    this.FullRot = false;
                }
                if (this.FullRot && (this.PCount == 2))
                {
                    this.PathPoint2 = Phit.point;
                    this.FullRot = false;
                }
                if (this.FullRot && (this.PCount == 3))
                {
                    this.PathPoint3 = Phit.point;
                    this.FullRot = false;
                }
                if (Vector3.Distance(this.PathPoint1, this.PathPoint2) < 200)
                {
                    if (Vector3.Distance(this.PathPoint2, this.PathPoint3) < 200)
                    {
                        this.Waypoint.position = Phit.point;
                    }
                }
            }
            this.ResetView.Rotate(0, 0, 5);
            this.PRot = this.PRot + 5;
            if (this.PRot == 360)
            {
                this.PRot = 0;
                this.PCount = this.PCount + 1;
                this.FullRot = true;
            }
            if (this.PCount == 4)
            {
                this.PRot = 0;
                this.PCount = 0;
                this.Pathfind = false;
                this.GoToPath = true;
            }
        }
    }

    private Quaternion NewRotation;
    public virtual void FixedUpdate()
    {
        Vector3 localV = this.Vessel.transform.InverseTransformDirection(this.Vessel.GetComponent<Rigidbody>().velocity);
        this.Vel = -localV.y * 2.24f;
        if (this.CanDrive)
        {
            if (!this.IsClose)
            {
                if (this.target)
                {
                    if (this.Road)
                    {
                        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, this.RoadTF.rotation, Time.deltaTime * this.AimSpeed);
                    }
                    else
                    {
                        this.NewRotation = Quaternion.LookRotation(this.target.position - this.transform.position);
                        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, this.NewRotation, Time.deltaTime * this.AimSpeed);
                    }
                }
            }
            else
            {
                if (this.ReloadPoint)
                {
                    Quaternion NewRotation2 = Quaternion.LookRotation(this.ReloadPoint.position - this.transform.position);
                    this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, NewRotation2, Time.deltaTime * this.AimSpeed);
                    if (Vector3.Distance(this.transform.position, this.ReloadPoint.position) > 3.5f)
                    {
                        this.Vessel.GetComponent<Rigidbody>().AddForce(((this.ReloadPoint.position - this.transform.position).normalized * this.DirForce) * 0.2f);
                    }
                    else
                    {
                        this.Vessel.GetComponent<Rigidbody>().AddForce(this.Vessel.transform.up * this.DirForce);
                    }
                }
                else
                {
                    Quaternion NewRotation3 = Quaternion.LookRotation(this.target.position - this.transform.position);
                    this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, NewRotation3, Time.deltaTime * this.AimSpeed);
                }
            }
            if (this.Obstacle)
            {
                if (this.Vel > 0)
                {
                    this.Vessel.GetComponent<Rigidbody>().AddForce(this.Vessel.transform.up * this.BrakeForce);
                }
                if (this.IsClose)
                {
                    if (-this.Vel < 2)
                    {
                        this.Vessel.GetComponent<Rigidbody>().AddForce(this.Vessel.transform.up * this.DirForce);
                    }
                }
            }
            if (this.Stuck > 0)
            {
                if (this.IsClose)
                {
                    if (this.Vessel.GetComponent<Rigidbody>().angularVelocity.magnitude < this.TurnSpeed)
                    {
                        this.Vessel.GetComponent<Rigidbody>().AddForce(this.Vessel.transform.right * this.DirForce);
                    }
                }
                else
                {
                    if (this.Vessel.GetComponent<Rigidbody>().angularVelocity.magnitude < this.TurnSpeed)
                    {
                        if (this.Turnerisms > 0)
                        {
                            this.Gyro.GetComponent<Rigidbody>().AddTorque(this.transform.up * this.TurnForce);
                        }
                        else
                        {
                            this.Gyro.GetComponent<Rigidbody>().AddTorque(this.transform.up * -this.TurnForce);
                        }
                    }
                }
                if (((-this.Vel < 10) && !this.Pivot) && !this.IsClose)
                {
                    this.Vessel.GetComponent<Rigidbody>().AddForce(this.Vessel.transform.up * this.DirForce);
                }
            }
            else
            {
                if (this.StrafeRight)
                {
                    this.Vessel.GetComponent<Rigidbody>().AddForce(this.Vessel.transform.right * this.DirForce);
                }
                if (this.StrafeLeft)
                {
                    this.Vessel.GetComponent<Rigidbody>().AddForce(this.Vessel.transform.right * -this.DirForce);
                }
                if (!this.IsClose)
                {
                    if (!this.Obstacle)
                    {
                        if (this.Vel < this.TopSpeed)
                        {
                            this.Vessel.GetComponent<Rigidbody>().AddForce(this.Vessel.transform.up * -this.DirForce);
                        }
                    }
                }
                if (this.TurnLeft && !this.TurnRight)
                {
                    if (this.Vel > 5)
                    {
                        if (this.Vessel.GetComponent<Rigidbody>().angularVelocity.magnitude < this.TurnSpeed)
                        {
                            this.Gyro.GetComponent<Rigidbody>().AddTorque(this.transform.up * -this.TurnForce);
                        }
                    }
                }
                if (this.TurnRight && !this.TurnLeft)
                {
                    if (this.Vel > 5)
                    {
                        if (this.Vessel.GetComponent<Rigidbody>().angularVelocity.magnitude < this.TurnSpeed)
                        {
                            this.Gyro.GetComponent<Rigidbody>().AddTorque(this.transform.up * this.TurnForce);
                        }
                    }
                }
            }
            if (this.IsClose && !this.Threatened)
            {
                if (this.Vel > 5)
                {
                    this.Vessel.GetComponent<Rigidbody>().AddForce(this.Vessel.transform.up * this.BrakeForce);
                }
            }
        }
        this.Gyro.GetComponent<Rigidbody>().AddTorque(this.transform.up * this.TurnStabForce);
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.GetComponent<Collider>().name.Contains("TFC1"))
            {
                if (Vector3.Distance(this.transform.position, other.transform.position) < this.ThreatPerimiter)
                {
                    CallAssistance.DismissAmmo = true;
                    this.ReloadPoint = null;
                    this.IsClose = false;
                    this.ThreatenedByTC1 = this.ThreatenedByTC1 + 1;
                }
            }
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if (CallAssistance.IsAmmoing)
        {
            if (other.GetComponent<Collider>().name.Contains("AmmoPointE"))
            {
                this.ReloadPoint = other.transform;
            }
            if (other.GetComponent<Collider>().name.Contains("AmmoPointF"))
            {
                this.ReloadPoint = null;
            }
        }
    }

    public virtual void Targety()
    {
        Vector3 lastPos = this.transform.position;
        this.StartCoroutine(this.IsEscaping(lastPos));
        if (this.RoadTF != this.RoadTF2)
        {
            this.RoadTF2 = this.RoadTF;
        }
    }

    public virtual void Navigator()
    {
        if (CallAssistance.IsAmmoing)
        {
            this.Waypoint.position = PlayerInformation.instance.Pirizuka.position;
            if (Vector3.Distance(this.transform.position, this.Waypoint.transform.position) > 50)
            {
                this.target = this.Waypoint;
                this.IsClose = false;
                this.IsSettled = false;
            }
            else
            {
                this.target = this.ResetView;
                if (this.ReloadPoint == null)
                {
                    this.IsSettled = true;
                    this.IsClose = false;
                }
                else
                {
                    this.IsSettled = false;
                    this.IsClose = true;
                }
            }
        }
        else
        {
            this.IsSettled = false;
        }
        if (this.ReloadPoint)
        {
            if (Vector3.Distance(this.DispensePoint.position, this.ReloadPoint.position) < 0.5f)
            {
                if (this.ReloadPoint.name.Contains("20mm"))
                {
                    UnityEngine.Object.Instantiate(this.Ammo1, this.DispensePoint.transform.position, this.DispensePoint.transform.rotation);
                    this.GetComponent<AudioSource>().Play();
                }
                if (this.ReloadPoint.name.Contains("30mm"))
                {
                    UnityEngine.Object.Instantiate(this.Ammo2, this.DispensePoint.transform.position, this.DispensePoint.transform.rotation);
                    this.GetComponent<AudioSource>().Play();
                }
                if (this.ReloadPoint.name.Contains("40mmSK"))
                {
                    UnityEngine.Object.Instantiate(this.Ammo3, this.DispensePoint.transform.position, this.DispensePoint.transform.rotation);
                    this.GetComponent<AudioSource>().Play();
                }
                if (this.ReloadPoint.name.Contains("40mmSHE"))
                {
                    UnityEngine.Object.Instantiate(this.Ammo4, this.DispensePoint.transform.position, this.DispensePoint.transform.rotation);
                    this.GetComponent<AudioSource>().Play();
                }
                if (this.ReloadPoint.name.Contains("50mm"))
                {
                    UnityEngine.Object.Instantiate(this.Ammo5, this.DispensePoint.transform.position, this.DispensePoint.transform.rotation);
                    this.GetComponent<AudioSource>().Play();
                }
            }
        }
    }

    public virtual void Refresher()
    {
        Vector3 localV = this.Vessel.transform.InverseTransformDirection(this.Vessel.GetComponent<Rigidbody>().angularVelocity);
        if (this.TurnRight)
        {
            if (this.Turnerisms < 5)
            {
                this.Turnerisms = this.Turnerisms + 1;
            }
        }
        if (this.TurnLeft)
        {
            if (this.Turnerisms > -5)
            {
                this.Turnerisms = this.Turnerisms - 1;
            }
        }
        if (localV.x > 0.2f)
        {
            if (this.Ride < 2)
            {
                this.Ride = this.Ride + 0.2f;
            }
        }
        else
        {
            if (this.Ride > 0)
            {
                this.Ride = this.Ride - 0.2f;
            }
        }
        if (this.DownDist == this.UpDist)
        {
            this.SteepInc = false;
        }
        this.Obstacle = false;
        this.TurnRight = false;
        this.TurnLeft = false;
        this.StrafeRight = false;
        this.StrafeLeft = false;
    }

    public virtual void Updater()
    {
        if (!this.SinglePath)
        {
            this.Road = false;
            this.RoadTF = null;
        }
        else
        {
            if (this.RoadTime > 0)
            {
                this.RoadTime = this.RoadTime - 1;
            }
            if (this.RoadTime < 1)
            {
                this.Road = false;
                this.RoadTF = null;
            }
        }

        {
            float _642 = this.Vessel.GetComponent<Rigidbody>().mass * 0.5f;
            JointDrive _643 = this.ConfJ.angularYZDrive;
            _643.maximumForce = _642;
            this.ConfJ.angularYZDrive = _643;
        }
        if (this.Threatened)
        {
            if ((this.target == this.ResetView) || (this.target == this.Waypoint))
            {
                this.Threatened = false;
                this.target = this.ResetView;
            }
        }
        if (this.target == null)
        {
            this.Threatened = false;
            this.target = this.ResetView;
        }
        if (this.Threatened)
        {
            this.IsClose = false;
        }
        if (this.Threatened)
        {
            this.Trig.radius = 20;
        }
        else
        {
            this.Trig.radius = 100;
        }
        if (this.Stuck > 0)
        {
            this.Stuck = this.Stuck - 1;
            if (this.Stuck == 1)
            {
                this.Turnerisms = 0;
                this.Stuck = 0;
            }
        }
        if (!CallAssistance.IsAmmoing)
        {
            this.target = this.ResetView;
        }
        if (this.ThreatenedByTC1 > 3)
        {
            this.ThreatenedByTC1 = 3;
        }
        if (this.ThreatenedByTC4 > 3)
        {
            this.ThreatenedByTC4 = 3;
        }
        if (this.ThreatenedByTC6 > 3)
        {
            this.ThreatenedByTC6 = 3;
        }
        if (this.ThreatenedByTC7 > 3)
        {
            this.ThreatenedByTC7 = 3;
        }
        if (this.GoToPath)
        {
            this.target = this.Waypoint;
            if (Vector3.Distance(this.transform.position, this.Waypoint.position) < 100)
            {
                this.target = this.ResetView;
                this.GoToPath = false;
            }
        }
    }

    public virtual IEnumerator IsEscaping(Vector3 lastPos)
    {
        yield return new WaitForSeconds(3);
        if (this.ReloadPoint)
        {
            if (Vector3.Distance(this.DispensePoint.position, this.ReloadPoint.position) < 2)
            {
                yield break;
            }
        }
        if (((Vector3.Distance(this.transform.position, lastPos) < 2) && this.CanDrive) && !this.IsSettled)
        {
            this.Stuck = 5;
            yield return new WaitForSeconds(0.5f);
            if (this.Stuck == 0)
            {
                this.Pivot = true;
                this.Stuck = 4;
            }
        }
    }

    public virtual void Pathy()
    {
        Vector3 lastArea = this.transform.position;
        this.StartCoroutine(this.IsPathfinding(lastArea));
    }

    public virtual IEnumerator IsPathfinding(Vector3 lastArea)
    {
        yield return new WaitForSeconds(30);
        if (((Vector3.Distance(this.transform.position, lastArea) < 250) && !this.IsClose) && !this.GoToPath)
        {
            this.Pathfind = true;
        }
    }

    public AmmoBotAI()
    {
        this.ThreatPerimiter = 50;
        this.VelLowClamp = 0.1f;
        this.ObsStartY = 4;
        this.ObsStartZ = 0.1f;
        this.StrafeEndSide = 2;
        this.RightDist = 200;
        this.LeftDist = 200;
        this.UpDist = 200;
        this.DownDist = 200;
        this.TopSpeed = 100;
        this.BrakeForce = 30;
        this.TurnForce = 60;
        this.TurnSpeed = 0.5f;
        this.DirForce = 10;
        this.TurnStabMod = 100;
        this.AimSpeed = 33;
        this.IncThreshold = 1.5f;
        this.TForce = 6;
    }

}