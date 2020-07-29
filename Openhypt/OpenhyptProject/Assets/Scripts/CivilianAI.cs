using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class CivilianAI : MonoBehaviour
{
	public Transform target;
	public Transform ResetView;
	public Transform Waypoint;
	public Transform MissionWaypoint;
	public GyroStabilizer Gyro;
	public SphereCollider Trig;
	public VehicleDamage HealthScript;
	public int TargetCode;
	public RemoveOverTime Remover;
	public CarDoorController vEntrance;
	public Transform VPoint;
	public Transform thisTransform;
	public Transform thisVTransform;
	public Rigidbody vRigidbody;
	public EngineRunsound Runsound;
	public EngineWhizzer Whizzer1;
	public EngineWhizzer Whizzer2;
	public AudioSource Blastoff;
	public ParticleSystem[] Particles;
	public Transform TaxiDoor;
	public bool DoorOpen;
	public bool IsCarrier;
	public bool ignoreInteraction;
	public HingeJoint Hinge1;
	public HingeJoint Hinge2;
	public HingeJoint Hinge3;
	public HingeJoint Hinge4;
	public HingeJoint Hinge5;
	public HingeJoint Hinge6;
	public HingeJoint Hinge7;
	public HingeJoint Hinge8;
	public HingeJoint Hinge9;
	public HingeJoint Hinge10;
	public HingeJoint Hinge11;
	public HingeJoint Hinge12;
	public Transform ContainerPoint1;
	public Transform ContainerPoint2;
	public Transform ContainerPoint3;
	public Transform ContainerPoint4;
	public Transform ContainerPoint5;
	public Transform ContainerPoint6;
	public Transform CargoSpawnTF;
	public Transform CargoTF;
	public GameObject Container1GO;
	public GameObject Container2GO;
	public GameObject Container3GO;
	public GameObject Container4GO;
	public GameObject Container5GO;
	public GameObject Container6GO;
	public bool HasVehicleShipment;
	public bool OffToDrop;
	public bool IsDropping;
	public int ThreatenedByTC1;
	public int ThreatenedByTC5;
	public int ThreatenedByTC4;
	public int ThreatenedByTC6;
	public int ThreatenedByTC7;
	public int ThreatPerimiter;
	public Transform Stranger;
	public Transform Sanctuary;
	public Transform RoadTF;
	public Transform RoadTF2;
	public bool Road;
	public int RoadTime;
	public float RoadTightness;
	public bool SinglePath;
	public bool DriftyVessel;
	public bool isBejsirf;
	public bool IsTaxi;
	public bool IsExit1;
	public bool IsExit2;
	public bool IsExit3;
	public int SceneTimer;
	public int StuckNum;
	public float Proddy;
	public bool IsInside;
	public bool FreeFloating;
	public bool HasHome;
	public bool CanDrive;
	public bool HasSpace;
	public bool Parked;
	public bool FullSpeed;
	public bool Threatened;
	public bool Obstacle;
	public bool TurnUp;
	public bool TurnDown;
	public bool TurnRight;
	public bool TurnLeft;
	public bool TurnRightX;
	public bool TurnLeftX;
	public bool StrafeRight;
	public bool StrafeLeft;
	public float ObsStartY;
	public float ObsStartZ;
	public float TurnEndSide;
	public float TurnEndSideS;
	public float RightDist;
	public float LeftDist;
	public int TurnVehicleTop;
	public int TurnVehicleBot;
	public float UpDist;
	public float DownDist;
	public float UpDist2;
	public float DownDist2;
	public float TopSpeed;
	public float StatTopSpeed;
	public float BrakeForce;
	public float SlowDownForce;
	public float TurnForce;
	public float RPMod;
	public float RPMod2;
	public float TurnSpeed;
	public float DirForce;
	public float TurnStabForce;
	public float TurnStabMod;
	public bool Stab;
	public float RayVelMod;
	public float AimSpeed;
	public float IncThreshold;
	public int DropTolerance;
	public int StopDist;
	public int UnstickTime;
	public float Ride;
	public float Vel;
	public float VelClamp;
	public float VelClamp2;
	public float VelSplit;
	public float TVel;
	public float TAVel;
	public float Dist;
	public float MissionDist;
	public bool AtDestination;
	public bool IsClose;
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
	public Vector3 newRot;
	public int Stuck;
	public int Escaping;
	public int Ogle;
	public int TForce;
	public int Turnerisms;
	public bool Once;
	public virtual void Start()
	{
		this.InvokeRepeating("Updater", 2, 1);
		this.InvokeRepeating("Refresher", 1, 0.2f);
		this.InvokeRepeating("Targety", 6, 6);
		this.InvokeRepeating("Pathy", 30, 30);
		if (this.vEntrance)
		{
			this.vEntrance.DenyEntrance = true;
		}
		if (this.DriftyVessel)
		{
			this.TurnStabMod = this.vRigidbody.mass * 48;
		}
		else
		{
			this.TurnStabMod = this.vRigidbody.mass * 28;
		}
		if (this.vRigidbody.mass > 1000)
		{
			this.TurnStabMod = this.vRigidbody.mass * 256;
		}
		this.StatTopSpeed = this.TopSpeed;
		this.VelSplit = 1;
		this.VelClamp = 1;
		this.TurnEndSideS = this.TurnEndSide * 0.75f;
		float MassMod = this.vRigidbody.mass * 16;
		if (this.BrakeForce > MassMod)
		{
			this.SlowDownForce = this.BrakeForce * 0.1f;
		}
		else
		{
			this.SlowDownForce = this.BrakeForce * 0.3f;
		}
		if (this.IsTaxi)
		{
			this.DoorOpen = true;
			this.CanDrive = false;
		}
		else
		{
			this.CanDrive = true;
		}
		if (this.IsCarrier)
		{
			GameObject Cargoionaise = ((GameObject)Resources.Load("Models/THookContainer", typeof(GameObject))) as GameObject;
			GameObject Cargoionaise2 = ((GameObject)Resources.Load("Models/THookContainer2", typeof(GameObject))) as GameObject;
			GameObject CargoionaiseD2 = ((GameObject)Resources.Load("Models/THookContainerD2", typeof(GameObject))) as GameObject;
			if (CallAssistance.IsCargoing)
			{
				int Rand0 = Random.Range(0, 3);
				switch (Rand0)
				{
					case 0:
						this.Container2GO = UnityEngine.Object.Instantiate(CargoionaiseD2, this.ContainerPoint2.position, this.ContainerPoint2.rotation);
						this.Container2GO.transform.parent = this.thisVTransform;
						GameObject TheCargo1 = UnityEngine.Object.Instantiate(Cargoionaise2, this.ContainerPoint5.position, this.ContainerPoint5.rotation);
						TheCargo1.transform.parent = this.thisVTransform;
						break;
					case 1:
						this.Container2GO = UnityEngine.Object.Instantiate(CargoionaiseD2, this.ContainerPoint2.position, this.ContainerPoint2.rotation);
						this.Container2GO.transform.parent = this.thisVTransform;
						GameObject TheCargo2 = UnityEngine.Object.Instantiate(Cargoionaise2, this.ContainerPoint5.position, this.ContainerPoint5.rotation);
						TheCargo2.transform.parent = this.thisVTransform;
						break;
					case 2:
						this.Container2GO = UnityEngine.Object.Instantiate(CargoionaiseD2, this.ContainerPoint2.position, this.ContainerPoint2.rotation);
						this.Container2GO.transform.parent = this.thisVTransform;
						GameObject TheCargo4 = UnityEngine.Object.Instantiate(Cargoionaise, this.ContainerPoint4.position, this.ContainerPoint4.rotation);
						TheCargo4.transform.parent = this.thisVTransform;
						GameObject TheCargo5 = UnityEngine.Object.Instantiate(Cargoionaise, this.ContainerPoint5.position, this.ContainerPoint5.rotation);
						TheCargo5.transform.parent = this.thisVTransform;
						GameObject TheCargo6 = UnityEngine.Object.Instantiate(Cargoionaise, this.ContainerPoint6.position, this.ContainerPoint6.rotation);
						TheCargo6.transform.parent = this.thisVTransform;
						break;
					case 3:
						this.Container2GO = UnityEngine.Object.Instantiate(CargoionaiseD2, this.ContainerPoint2.position, this.ContainerPoint2.rotation);
						this.Container2GO.transform.parent = this.thisVTransform;
						GameObject TheCargo8 = UnityEngine.Object.Instantiate(Cargoionaise, this.ContainerPoint4.position, this.ContainerPoint4.rotation);
						TheCargo8.transform.parent = this.thisVTransform;
						GameObject TheCargo9 = UnityEngine.Object.Instantiate(Cargoionaise, this.ContainerPoint5.position, this.ContainerPoint5.rotation);
						TheCargo9.transform.parent = this.thisVTransform;
						GameObject TheCargo10 = UnityEngine.Object.Instantiate(Cargoionaise, this.ContainerPoint6.position, this.ContainerPoint6.rotation);
						TheCargo10.transform.parent = this.thisVTransform;
						break;
				}
				this.HasVehicleShipment = true;
				this.target = PlayerInformation.instance.PiriTarget;
				this.MissionWaypoint = PlayerInformation.instance.PiriTarget;
				CallAssistance.IsCargoing = false;
				this.Remover.isVesselCarrier = true;
			}
			else
			{
				int Rand1 = Random.Range(0, 4);
				switch (Rand1)
				{
					case 0:
						GameObject TheCargo11 = UnityEngine.Object.Instantiate(Cargoionaise2, this.ContainerPoint2.position, this.ContainerPoint2.rotation);
						TheCargo11.transform.parent = this.thisVTransform;
						GameObject TheCargo12 = UnityEngine.Object.Instantiate(Cargoionaise2, this.ContainerPoint5.position, this.ContainerPoint5.rotation);
						TheCargo12.transform.parent = this.thisVTransform;
						break;
					case 1:
						GameObject TheCargo13 = UnityEngine.Object.Instantiate(Cargoionaise2, this.ContainerPoint2.position, this.ContainerPoint2.rotation);
						TheCargo13.transform.parent = this.thisVTransform;
						GameObject TheCargo14 = UnityEngine.Object.Instantiate(Cargoionaise, this.ContainerPoint4.position, this.ContainerPoint4.rotation);
						TheCargo14.transform.parent = this.thisVTransform;
						GameObject TheCargo15 = UnityEngine.Object.Instantiate(Cargoionaise, this.ContainerPoint5.position, this.ContainerPoint5.rotation);
						TheCargo15.transform.parent = this.thisVTransform;
						GameObject TheCargo16 = UnityEngine.Object.Instantiate(Cargoionaise, this.ContainerPoint6.position, this.ContainerPoint6.rotation);
						TheCargo16.transform.parent = this.thisVTransform;
						break;
					case 2:
						GameObject TheCargo17 = UnityEngine.Object.Instantiate(Cargoionaise2, this.ContainerPoint5.position, this.ContainerPoint5.rotation);
						TheCargo17.transform.parent = this.thisVTransform;
						GameObject TheCargo18 = UnityEngine.Object.Instantiate(Cargoionaise, this.ContainerPoint1.position, this.ContainerPoint1.rotation);
						TheCargo18.transform.parent = this.thisVTransform;
						GameObject TheCargo19 = UnityEngine.Object.Instantiate(Cargoionaise, this.ContainerPoint2.position, this.ContainerPoint2.rotation);
						TheCargo19.transform.parent = this.thisVTransform;
						GameObject TheCargo20 = UnityEngine.Object.Instantiate(Cargoionaise, this.ContainerPoint3.position, this.ContainerPoint3.rotation);
						TheCargo20.transform.parent = this.thisVTransform;
						break;
					case 3:
						GameObject TheCargo21 = UnityEngine.Object.Instantiate(Cargoionaise, this.ContainerPoint1.position, this.ContainerPoint1.rotation);
						TheCargo21.transform.parent = this.thisVTransform;
						GameObject TheCargo22 = UnityEngine.Object.Instantiate(Cargoionaise, this.ContainerPoint2.position, this.ContainerPoint2.rotation);
						TheCargo22.transform.parent = this.thisVTransform;
						GameObject TheCargo23 = UnityEngine.Object.Instantiate(Cargoionaise, this.ContainerPoint3.position, this.ContainerPoint3.rotation);
						TheCargo23.transform.parent = this.thisVTransform;
						GameObject TheCargo24 = UnityEngine.Object.Instantiate(Cargoionaise, this.ContainerPoint4.position, this.ContainerPoint4.rotation);
						TheCargo24.transform.parent = this.thisVTransform;
						GameObject TheCargo25 = UnityEngine.Object.Instantiate(Cargoionaise, this.ContainerPoint5.position, this.ContainerPoint5.rotation);
						TheCargo25.transform.parent = this.thisVTransform;
						GameObject TheCargo26 = UnityEngine.Object.Instantiate(Cargoionaise, this.ContainerPoint6.position, this.ContainerPoint6.rotation);
						TheCargo26.transform.parent = this.thisVTransform;
						break;
				}
			}
		}
	}

	public virtual void Update()
	{
		Vector3 newRot2 = default(Vector3);
		RaycastHit hit = default(RaycastHit);
		RaycastHit hit2 = default(RaycastHit);
		RaycastHit hit3 = default(RaycastHit);
		RaycastHit Phit = default(RaycastHit);
		if (this.IsTaxi)
		{
			if (this.IsInside)
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					this.CanDrive = true;
					this.DoorOpen = false;
				}
			}
		}
		if (this.IsClose && (this.Ogle == 1))
		{
			this.target = this.ResetView;
			if (this.ThreatenedByTC1 == 2)
			{
				this.ThreatenedByTC1 = 1;
			}
			if (this.ThreatenedByTC4 == 2)
			{
				this.ThreatenedByTC4 = 1;
			}
			if (this.ThreatenedByTC6 == 2)
			{
				this.ThreatenedByTC6 = 1;
			}
			if (this.ThreatenedByTC7 == 2)
			{
				this.ThreatenedByTC7 = 1;
			}
		}
		float ObsStartZPLUS = this.ObsStartZ + this.Ride;
		float VelPlus = this.VelClamp * this.RayVelMod;
		float VelTQ = this.VelClamp * 0.75f;
		float Angle = Mathf.Abs(this.UpDist - this.DownDist);
		float Angle2 = Mathf.Abs(this.UpDist2 - this.DownDist2);
		if (!this.TurnLeft && !this.TurnRight)
		{
			Vector3 VesselAngVel = this.thisVTransform.InverseTransformDirection(this.vRigidbody.angularVelocity);
			float AV1 = VesselAngVel.z * this.TurnStabMod;
			float AV2 = Mathf.Clamp(AV1, -this.TurnForce, this.TurnForce);
			this.TurnStabForce = -AV2;
		}
		else
		{
			this.TurnStabForce = 0;
		}
		this.Stab = false;
		if (this.DriftyVessel || this.FreeFloating)
		{
			if (this.vRigidbody.velocity.magnitude > 8)
			{
				newRot2 = this.vRigidbody.velocity;
				this.VPoint.rotation = Quaternion.LookRotation(newRot2);
			}
			else
			{
				newRot2 = this.ResetView.position - this.thisVTransform.position;
				this.VPoint.rotation = Quaternion.LookRotation(newRot2);
			}
		}
		if (!this.DriftyVessel)
		{
			Debug.DrawRay(((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * this.ObsStartZ)) + (this.thisVTransform.right * this.TurnEndSideS), -this.thisVTransform.up * VelTQ, Color.white);
			Debug.DrawRay(((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * this.ObsStartZ)) + (-this.thisVTransform.right * this.TurnEndSideS), -this.thisVTransform.up * VelTQ, Color.white);
			if (Physics.Raycast(((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * this.ObsStartZ)) + (this.thisVTransform.right * this.TurnEndSideS), -this.thisVTransform.up, VelTQ) || Physics.Raycast(((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * this.ObsStartZ)) + (-this.thisVTransform.right * this.TurnEndSideS), -this.thisVTransform.up, VelTQ))
			{
				this.Obstacle = true;
			}
			else
			{
				this.Obstacle = false;
			}
			Debug.DrawRay(((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * ObsStartZPLUS)) + (this.thisVTransform.right * this.TurnEndSide), this.newRot * VelPlus, Color.black);
			if (Physics.Raycast(((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * ObsStartZPLUS)) + (this.thisVTransform.right * this.TurnEndSide), this.newRot, out hit, VelPlus))
			{
				this.RightDist = hit.distance;
			}
			else
			{
				this.RightDist = VelPlus;
			}
			Debug.DrawRay(((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * ObsStartZPLUS)) + (-this.thisVTransform.right * this.TurnEndSide), this.newRot * VelPlus, Color.black);
			if (Physics.Raycast(((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * ObsStartZPLUS)) + (-this.thisVTransform.right * this.TurnEndSide), this.newRot, out hit, VelPlus))
			{
				this.LeftDist = hit.distance;
			}
			else
			{
				this.LeftDist = VelPlus;
			}
			if (!this.FreeFloating)
			{
				Debug.DrawRay(((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * this.ObsStartZ)) + (this.thisVTransform.forward * 0.4f), this.newRot * VelPlus, Color.green);
				if (Physics.Raycast(((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * this.ObsStartZ)) + (this.thisVTransform.forward * 0.4f), this.newRot, out hit2, VelPlus))
				{
					this.UpDist = hit2.distance;
				}
				else
				{
					this.UpDist = 8;
				}
				Debug.DrawRay((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * this.ObsStartZ), this.newRot * VelPlus, Color.green);
				if (Physics.Raycast((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * this.ObsStartZ), this.newRot, out hit2, VelPlus))
				{
					this.DownDist = hit2.distance;
				}
				else
				{
					this.DownDist = 2;
				}
				if (Angle < this.IncThreshold)
				{
					this.SteepInc = true;
				}
				else
				{
					this.SteepInc = false;
				}
			}
			else
			{
				this.TurnDown = false;
				this.TurnUp = false;
				Debug.DrawRay(((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * this.ObsStartZ)) + (this.thisVTransform.forward * this.TurnVehicleTop), this.newRot * VelPlus, Color.blue);
				if (Physics.Raycast(((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * this.ObsStartZ)) + (this.thisVTransform.forward * this.TurnVehicleTop), this.newRot, out hit2, VelPlus))
				{
					this.UpDist = hit2.distance;
				}
				else
				{
					this.UpDist = 8;
				}
				Debug.DrawRay(((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * this.ObsStartZ)) + (this.thisVTransform.forward * this.TurnVehicleBot), this.newRot * VelPlus, Color.red);
				if (Physics.Raycast(((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * this.ObsStartZ)) + (this.thisVTransform.forward * this.TurnVehicleBot), this.newRot, out hit2, VelPlus))
				{
					this.DownDist = hit2.distance;
				}
				else
				{
					this.DownDist = 8;
				}
				if (this.DownDist > this.UpDist)
				{
					this.TurnDown = true;
				}
				if (this.DownDist < this.UpDist)
				{
					this.TurnUp = true;
				}
			}
			Debug.DrawRay(((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * this.ObsStartZ)) + (this.thisVTransform.forward * 10.4f), this.newRot * VelPlus, Color.yellow);
			if (Physics.Raycast(((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * this.ObsStartZ)) + (this.thisVTransform.forward * 10.4f), this.newRot, out hit3, VelPlus))
			{
				this.UpDist2 = hit3.distance;
			}
			else
			{
				this.UpDist2 = 8;
			}
			Debug.DrawRay(((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * this.ObsStartZ)) + (this.thisVTransform.forward * 10), this.newRot * VelPlus, Color.yellow);
			if (Physics.Raycast(((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * this.ObsStartZ)) + (this.thisVTransform.forward * 10), this.newRot, out hit3, VelPlus))
			{
				this.DownDist2 = hit3.distance;
			}
			else
			{
				this.DownDist2 = 2;
			}
			if (Angle2 < this.IncThreshold)
			{
				this.SteepInc = true;
			}
			else
			{
				this.SteepInc = false;
			}
		}
		else
		{
			Debug.DrawRay((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * this.ObsStartZ), newRot2 * VelPlus, Color.white);
			if (Physics.Raycast((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * this.ObsStartZ), newRot2, VelPlus))
			{
				this.Obstacle = true;
			}
			else
			{
				this.Obstacle = false;
			}
			Debug.DrawRay(((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * ObsStartZPLUS)) + (this.VPoint.right * this.TurnEndSide), newRot2 * VelPlus, Color.black);
			if (Physics.Raycast(((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * ObsStartZPLUS)) + (this.VPoint.right * this.TurnEndSide), newRot2, out hit, VelPlus))
			{
				this.RightDist = hit.distance;
			}
			else
			{
				this.RightDist = VelPlus;
			}
			Debug.DrawRay(((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * ObsStartZPLUS)) + (-this.VPoint.right * this.TurnEndSide), newRot2 * VelPlus, Color.black);
			if (Physics.Raycast(((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * ObsStartZPLUS)) + (-this.VPoint.right * this.TurnEndSide), newRot2, out hit, VelPlus))
			{
				this.LeftDist = hit.distance;
			}
			else
			{
				this.LeftDist = VelPlus;
			}
			Debug.DrawRay(((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * this.ObsStartZ)) + (this.thisVTransform.forward * 0.4f), newRot2 * VelPlus, Color.green);
			if (Physics.Raycast(((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * this.ObsStartZ)) + (this.thisVTransform.forward * 0.4f), newRot2, out hit2, VelPlus))
			{
				this.UpDist = hit2.distance;
			}
			else
			{
				this.UpDist = 8;
			}
			Debug.DrawRay((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * this.ObsStartZ), newRot2 * VelPlus, Color.green);
			if (Physics.Raycast((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * this.ObsStartZ), newRot2, out hit2, VelPlus))
			{
				this.DownDist = hit2.distance;
			}
			else
			{
				this.DownDist = 2;
			}
			if (Angle < this.IncThreshold)
			{
				this.SteepInc = true;
			}
			else
			{
				this.SteepInc = false;
			}
		}
		if (this.RightDist == this.LeftDist)
		{
			this.TurnRight = false;
			this.TurnLeft = false;
		}
		//---------------------------------------------------------------------------------------------
		if (!this.FreeFloating)
		{
			Debug.DrawRay((this.thisTransform.position + (this.thisVTransform.forward * 10)) + (this.newRot * VelPlus), -this.thisVTransform.forward * this.DropTolerance, Color.white);
			if (!Physics.Raycast((this.thisTransform.position + (this.thisVTransform.forward * 10)) + (this.newRot * VelPlus), -this.thisVTransform.forward, out hit, this.DropTolerance))
			{
				this.Obstacle = true;
			}
			else
			{
				if (hit.collider.name.Contains("Wa") && !this.DriftyVessel)
				{
					this.Obstacle = true;
				}
			}
			if (!this.DriftyVessel)
			{
				Debug.DrawRay(((this.thisTransform.position + (this.thisVTransform.forward * 10)) + (this.thisVTransform.right * this.TurnEndSide)) + (-this.thisVTransform.up * VelPlus), -this.thisVTransform.forward * this.DropTolerance, Color.white);
				if (!Physics.Raycast(((this.thisTransform.position + (this.thisVTransform.forward * 10)) + (this.thisVTransform.right * this.TurnEndSide)) + (-this.thisVTransform.up * VelPlus), -this.thisVTransform.forward, this.DropTolerance))
				{
					this.TurnLeft = true;
				}
				Debug.DrawRay(((this.thisTransform.position + (this.thisVTransform.forward * 10)) + (-this.thisVTransform.right * this.TurnEndSide)) + (-this.thisVTransform.up * VelPlus), -this.thisVTransform.forward * this.DropTolerance, Color.white);
				if (!Physics.Raycast(((this.thisTransform.position + (this.thisVTransform.forward * 10)) + (-this.thisVTransform.right * this.TurnEndSide)) + (-this.thisVTransform.up * VelPlus), -this.thisVTransform.forward, this.DropTolerance))
				{
					this.TurnRight = true;
				}
				Debug.DrawRay(((this.thisTransform.position + (this.thisVTransform.forward * 10)) + (this.thisVTransform.right * 10)) + (-this.thisVTransform.up * VelPlus), -this.thisVTransform.forward * this.DropTolerance, Color.white);
				if (!Physics.Raycast(((this.thisTransform.position + (this.thisVTransform.forward * 10)) + (this.thisVTransform.right * 10)) + (-this.thisVTransform.up * VelPlus), -this.thisVTransform.forward, out hit, this.DropTolerance, (int)this.MtargetLayers))
				{
					this.TurnLeft = true;
				}
				else
				{
					if (hit.collider.name.Contains("Wa") && !this.DriftyVessel)
					{
						this.TurnLeft = true;
					}
				}
				Debug.DrawRay(((this.thisTransform.position + (this.thisVTransform.forward * 10)) + (-this.thisVTransform.right * 10)) + (-this.thisVTransform.up * VelPlus), -this.thisVTransform.forward * this.DropTolerance, Color.white);
				if (!Physics.Raycast(((this.thisTransform.position + (this.thisVTransform.forward * 10)) + (-this.thisVTransform.right * 10)) + (-this.thisVTransform.up * VelPlus), -this.thisVTransform.forward, out hit, this.DropTolerance, (int)this.MtargetLayers))
				{
					this.TurnRight = true;
				}
				else
				{
					if (hit.collider.name.Contains("Wa") && !this.DriftyVessel)
					{
						this.TurnRight = true;
					}
				}
			}
			else
			{
				Debug.DrawRay(((this.thisTransform.position + (this.thisVTransform.forward * 10)) + (this.VPoint.right * this.TurnEndSide)) + (this.VPoint.forward * VelPlus), -this.thisVTransform.forward * this.DropTolerance, Color.white);
				if (!Physics.Raycast(((this.thisTransform.position + (this.thisVTransform.forward * 10)) + (this.VPoint.right * this.TurnEndSide)) + (this.VPoint.forward * VelPlus), -this.thisVTransform.forward, this.DropTolerance))
				{
					this.TurnLeft = true;
				}
				Debug.DrawRay(((this.thisTransform.position + (this.thisVTransform.forward * 10)) + (-this.VPoint.right * this.TurnEndSide)) + (this.VPoint.forward * VelPlus), -this.thisVTransform.forward * this.DropTolerance, Color.white);
				if (!Physics.Raycast(((this.thisTransform.position + (this.thisVTransform.forward * 10)) + (-this.VPoint.right * this.TurnEndSide)) + (this.VPoint.forward * VelPlus), -this.thisVTransform.forward, this.DropTolerance))
				{
					this.TurnRight = true;
				}
			}
		}
		else
		{
			Debug.DrawRay(this.thisTransform.position + (this.newRot * VelPlus), -this.thisVTransform.forward * 10, Color.white);
			if (Physics.Raycast(this.thisTransform.position + (this.newRot * VelPlus), -this.thisVTransform.forward, 10, (int)this.MtargetLayers))
			{
				if (this.SteepInc)
				{
					this.Obstacle = true;
				}
			}
			Debug.DrawRay(((this.thisTransform.position + (this.thisVTransform.forward * 10)) + (this.VPoint.right * 10)) + (this.VPoint.forward * VelPlus), -this.thisVTransform.forward * this.DropTolerance, Color.white);
			if (Physics.Raycast(((this.thisTransform.position + (this.thisVTransform.forward * 10)) + (this.VPoint.right * 10)) + (this.VPoint.forward * VelPlus), -this.thisVTransform.forward, this.DropTolerance, (int)this.MtargetLayers))
			{
				this.TurnLeft = true;
			}
			Debug.DrawRay(((this.thisTransform.position + (this.thisVTransform.forward * 10)) + (-this.VPoint.right * 10)) + (this.VPoint.forward * VelPlus), -this.thisVTransform.forward * this.DropTolerance, Color.white);
			if (Physics.Raycast(((this.thisTransform.position + (this.thisVTransform.forward * 10)) + (-this.VPoint.right * 10)) + (this.VPoint.forward * VelPlus), -this.thisVTransform.forward, this.DropTolerance, (int)this.MtargetLayers))
			{
				this.TurnRight = true;
			}
			Debug.DrawRay(((this.thisTransform.position + (this.thisVTransform.forward * 10)) + (this.thisVTransform.right * 10)) + (-this.thisVTransform.up * VelPlus), -this.thisVTransform.forward * this.DropTolerance, Color.white);
			if (Physics.Raycast(((this.thisTransform.position + (this.thisVTransform.forward * 10)) + (this.thisVTransform.right * 10)) + (-this.thisVTransform.up * VelPlus), -this.thisVTransform.forward, this.DropTolerance, (int)this.MtargetLayers))
			{
				this.TurnLeft = true;
			}
			Debug.DrawRay(((this.thisTransform.position + (this.thisVTransform.forward * 10)) + (-this.thisVTransform.right * 10)) + (-this.thisVTransform.up * VelPlus), -this.thisVTransform.forward * this.DropTolerance, Color.white);
			if (Physics.Raycast(((this.thisTransform.position + (this.thisVTransform.forward * 10)) + (-this.thisVTransform.right * 10)) + (-this.thisVTransform.up * VelPlus), -this.thisVTransform.forward, this.DropTolerance, (int)this.MtargetLayers))
			{
				this.TurnRight = true;
			}
		}
		//---------------------------------------------------------------------------------------------
		if (this.DriftyVessel)
		{
			Debug.DrawRay((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * this.ObsStartZ), (this.VPoint.right * this.TurnEndSide) * 1.5f, Color.black);
			if (Physics.Raycast((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * this.ObsStartZ), this.VPoint.right, this.TurnEndSide * 1.5f))
			{
				this.TurnLeft = true;
			}
			Debug.DrawRay((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * this.ObsStartZ), (-this.VPoint.right * this.TurnEndSide) * 1.5f, Color.black);
			if (Physics.Raycast((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * this.ObsStartZ), -this.VPoint.right, this.TurnEndSide * 1.5f))
			{
				this.TurnRight = true;
			}
		}
		else
		{
			Debug.DrawRay((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * this.ObsStartZ), (this.thisVTransform.right * this.TurnEndSide) * 1.5f, Color.black);
			if (Physics.Raycast((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * this.ObsStartZ), this.thisVTransform.right, this.TurnEndSide * 1.5f))
			{
				this.TurnLeft = true;
			}
			Debug.DrawRay((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * this.ObsStartZ), (-this.thisVTransform.right * this.TurnEndSide) * 1.5f, Color.black);
			if (Physics.Raycast((this.thisVTransform.position + (-this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * this.ObsStartZ), -this.thisVTransform.right, this.TurnEndSide * 1.5f))
			{
				this.TurnRight = true;
			}
		}
		if (this.Stuck > 0)
		{
			Debug.DrawRay(((this.thisVTransform.position + (this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * this.ObsStartZ)) + (this.thisVTransform.right * this.TurnEndSideS), this.thisVTransform.up * this.VelSplit, Color.white);
			Debug.DrawRay(((this.thisVTransform.position + (this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * this.ObsStartZ)) + (-this.thisVTransform.right * this.TurnEndSideS), this.thisVTransform.up * this.VelSplit, Color.white);
			if (Physics.Raycast(((this.thisVTransform.position + (this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * this.ObsStartZ)) + (this.thisVTransform.right * this.TurnEndSideS), this.thisVTransform.up, this.VelSplit) || Physics.Raycast(((this.thisVTransform.position + (this.thisVTransform.up * this.ObsStartY)) + (this.thisVTransform.forward * this.ObsStartZ)) + (-this.thisVTransform.right * this.TurnEndSideS), this.thisVTransform.up, this.VelSplit))
			{
				this.Stuck = 0;
				this.Turnerisms = 0;
			}
			Debug.DrawRay(this.thisVTransform.position + (this.thisVTransform.up * VelTQ), -this.thisVTransform.forward * 10f, Color.white);
			if (!Physics.Raycast(this.thisVTransform.position + (this.thisVTransform.up * VelTQ), -this.thisVTransform.forward, 10))
			{
				this.Stuck = 0;
				this.Turnerisms = 0;
			}
		}
		if (this.OffToDrop && !this.GoToPath)
		{
			float VelMod1 = this.Vel * 1.5f;
			float VelMod2 = this.StopDist + VelMod1;
			if (this.MissionDist < VelMod2)
			{
				this.AtDestination = true;
				this.IsClose = true;
			}
			if (this.MissionDist < this.StopDist)
			{
				this.AtDestination = true;
				this.IsClose = true;
			}
		}
		if (this.Pathfind)
		{
			Debug.DrawRay((this.thisVTransform.position + (this.thisVTransform.forward * 10)) + (this.ResetView.transform.up * 250), -this.thisVTransform.forward * 20f, Color.red);
			if (Physics.Raycast((this.thisVTransform.position + (this.thisVTransform.forward * 10)) + (this.ResetView.transform.up * 250), -this.thisVTransform.forward, out Phit, 20))
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

	private Vector3 RP;
	public virtual void FixedUpdate()//[DoorAni]-----------------------------------------------------------------------------------------------------------------------------
	{
		RaycastHit hit = default(RaycastHit);
		if (!this.vRigidbody)
		{
			return;
		}
		if (this.IsCarrier)
		{
			this.TVel = this.vRigidbody.velocity.magnitude;
			this.TAVel = this.vRigidbody.angularVelocity.magnitude;
		}
		Vector3 localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
		this.Vel = -localV.y * 2.24f;
		float RPMod0 = (10 * this.TurnForce) * this.RP.x;
		float RPMod1 = (10 * this.TurnForce) * this.RP.z;
		this.RPMod = RPMod0 / this.Dist;
		this.RPMod2 = RPMod1 / this.Dist;
		this.VelClamp = Mathf.Clamp(this.Vel, 2, 1000);
		this.VelClamp2 = Mathf.Clamp(this.Vel * 0.07f, 1, 1000);
		this.VelSplit = this.VelClamp * 0.5f;
		this.newRot = -this.thisVTransform.up.normalized;
		if (this.target)
		{
			Vector3 RelativeTarget = this.thisTransform.InverseTransformPoint(this.target.position);

			float RTMod = (RelativeTarget.z * 0.2f) - 5;
			float RelativeDirForce = Mathf.Clamp(RTMod, -this.DirForce, this.DirForce);
			float RPClamp, RPClamp2;
			if (this.CanDrive)
			{
				if (!this.Parked)
				{
					if (this.Ogle < 1)
					{
						if (!this.FreeFloating)
						{
							if (!this.SinglePath)
							{
								Debug.DrawRay(this.thisTransform.position + (this.newRot * this.VelSplit), -this.thisVTransform.forward * 10, Color.green);
								if (Physics.Raycast(this.thisTransform.position + (this.newRot * this.VelSplit), -this.thisVTransform.forward, out hit, 10, (int)this.targetLayers))
								{
									if (hit.collider.name.Contains("RoadAlign"))
									{
										this.target = this.ResetView;
										this.GoToPath = false;
										this.RoadTime = 16;
										this.TopSpeed = this.StatTopSpeed;
										this.Road = true;
										this.RoadTF = hit.transform;
										this.GetComponent<Rigidbody>().freezeRotation = true;
										if (hit.collider.name.Contains("SS"))
										{
											this.TopSpeed = this.RoadTF.localScale.z;
										}
										if (hit.collider.name.Contains("SM"))
										{
											this.TopSpeed = 45;
										}
										if (hit.collider.name.Contains("SH"))
										{
											this.TopSpeed = 75;
										}
									}
								}
							}
							else
							{
								Debug.DrawRay(this.thisTransform.position + (this.newRot * this.VelSplit), -this.thisVTransform.forward * 10, Color.green);
								if (Physics.Raycast(this.thisTransform.position + (this.newRot * this.VelSplit), -this.thisVTransform.forward, out hit, 10, (int)this.targetLayers))
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
										this.TopSpeed = this.StatTopSpeed;
										if (hit.collider.name.Contains("SS"))
										{
											this.TopSpeed = this.RoadTF.localScale.z;
										}
										if (hit.collider.name.Contains("SM"))
										{
											this.TopSpeed = 45;
										}
										if (hit.collider.name.Contains("SH"))
										{
											this.TopSpeed = 75;
										}
									}
								}
							}
						}
						else
						{
							if (!this.SinglePath)
							{
								Debug.DrawRay(this.thisTransform.position + (this.newRot * this.VelSplit), -this.thisVTransform.forward * 10, Color.green);
								if (Physics.Raycast(this.thisTransform.position + (this.newRot * this.VelSplit), -this.thisVTransform.forward, out hit, 10, (int)this.targetLayers))
								{
									if (hit.collider.name.Contains("PathAlign"))
									{
										this.target = this.ResetView;
										this.GoToPath = false;
										this.TopSpeed = this.StatTopSpeed;
										this.Road = true;
										this.RoadTF = hit.transform;
										this.GetComponent<Rigidbody>().freezeRotation = true;
										if (hit.collider.name.Contains("SS"))
										{
											this.TopSpeed = this.RoadTF.localScale.z;
										}
										if (hit.collider.name.Contains("SM"))
										{
											this.TopSpeed = 45;
										}
										if (hit.collider.name.Contains("SH"))
										{
											this.TopSpeed = 75;
										}
									}
								}
							}
							else
							{
								Debug.DrawRay(this.thisTransform.position + (this.newRot * this.VelSplit), -this.thisVTransform.forward * 10, Color.green);
								if (Physics.Raycast(this.thisTransform.position + (this.newRot * this.VelSplit), -this.thisVTransform.forward, out hit, 10, (int)this.targetLayers))
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
										this.TopSpeed = this.StatTopSpeed;
										if (hit.collider.name.Contains("SS"))
										{
											this.TopSpeed = this.RoadTF.localScale.z;
										}
										if (hit.collider.name.Contains("SM"))
										{
											this.TopSpeed = 45;
										}
										if (hit.collider.name.Contains("SH"))
										{
											this.TopSpeed = 75;
										}
									}
								}
							}
						}
					}
					if (this.RoadTF)
					{
						Vector3 relativePoint = this.RoadTF.transform.InverseTransformPoint(this.ResetView.position);
						Vector3 relativePoint2 = this.RoadTF.transform.InverseTransformPoint(this.thisVTransform.position);
						Vector3 relativePointW = this.thisVTransform.InverseTransformPoint(this.Waypoint.position);
						this.Proddy = Mathf.Abs(relativePoint.x);
						this.Waypoint.rotation = this.RoadTF.rotation;
						this.Waypoint.position = this.RoadTF.position;
						this.Waypoint.position = this.Waypoint.position + ((this.RoadTF.forward * relativePoint2.z) * this.RoadTF.localScale.z);
						//if(RoadTF.localScale.z > 64)
						//ResetView.localPosition.y = -64;
						//else
						//ResetView.localPosition.y = -RoadTF.localScale.z;
						if (this.DriftyVessel)
						{
							if (this.RoadTF.localScale.z > 64)
							{

								{
									int _1086 = -64;
									Vector3 _1087 = this.ResetView.localPosition;
									_1087.y = _1086;
									this.ResetView.localPosition = _1087;
								}
								if (this.RoadTF.localScale.z > 256)
								{

									{
										int _1088 = -256;
										Vector3 _1089 = this.ResetView.localPosition;
										_1089.y = _1088;
										this.ResetView.localPosition = _1089;
									}
								}
							}
							else
							{
								if (this.TopSpeed > 44)
								{

									{
										int _1090 = -32;
										Vector3 _1091 = this.ResetView.localPosition;
										_1091.y = _1090;
										this.ResetView.localPosition = _1091;
									}
								}
								else
								{

									{
										int _1092 = -16;
										Vector3 _1093 = this.ResetView.localPosition;
										_1093.y = _1092;
										this.ResetView.localPosition = _1093;
									}
								}
							}
							if (relativePoint.x < -this.RoadTightness)
							{
								this.TurnLeft = false;
								this.TurnRight = true;
								if (this.TopSpeed > 44)
								{
									if (this.TopSpeed > 100)
									{
										if (this.Proddy > 2)
										{
											this.Obstacle = true;
										}
									}
									else
									{
										if (this.Proddy > 0.7f)
										{
											this.Obstacle = true;
										}
									}
								}
								else
								{
									if (this.Proddy > 0.35f)
									{
										this.Obstacle = true;
									}
								}
							}
							if (relativePoint.x > this.RoadTightness)
							{
								this.TurnRight = false;
								this.TurnLeft = true;
								if (this.TopSpeed > 44)
								{
									if (this.TopSpeed > 100)
									{
										if (this.Proddy > 2)
										{
											this.Obstacle = true;
										}
									}
									else
									{
										if (this.Proddy > 0.7f)
										{
											this.Obstacle = true;
										}
									}
								}
								else
								{
									if (this.Proddy > 0.35f)
									{
										this.Obstacle = true;
									}
								}
							}
						}
						else
						{
							if (this.RoadTF.localScale.z > 64)
							{

								{
									int _1094 = -32;
									Vector3 _1095 = this.ResetView.localPosition;
									_1095.y = _1094;
									this.ResetView.localPosition = _1095;
								}
								if (this.RoadTF.localScale.z > 256)
								{

									{
										int _1096 = -256;
										Vector3 _1097 = this.ResetView.localPosition;
										_1097.y = _1096;
										this.ResetView.localPosition = _1097;
									}
								}
							}
							else
							{
								if (this.TopSpeed > 44)
								{

									{
										int _1098 = -32;
										Vector3 _1099 = this.ResetView.localPosition;
										_1099.y = _1098;
										this.ResetView.localPosition = _1099;
									}
								}
								else
								{

									{
										float _1100 = -this.VelSplit;
										Vector3 _1101 = this.ResetView.localPosition;
										_1101.y = _1100;
										this.ResetView.localPosition = _1101;
									}
								}
							}
							if (relativePoint.x < -this.RoadTightness)
							{
								this.TurnLeft = false;
								this.TurnRight = true;
								if (this.TopSpeed > 44)
								{
									if (this.TopSpeed > 100)
									{
										if (this.Proddy > 2)
										{
											this.Obstacle = true;
										}
									}
									else
									{
										if (this.Proddy > 0.7f)
										{
											this.Obstacle = true;
										}
									}
								}
								else
								{
									if (this.Proddy > 0.35f)
									{
										this.Obstacle = true;
									}
								}
							}
							if (relativePoint.x > this.RoadTightness)
							{
								this.TurnRight = false;
								this.TurnLeft = true;
								if (this.TopSpeed > 44)
								{
									if (this.TopSpeed > 100)
									{
										if (this.Proddy > 2)
										{
											this.Obstacle = true;
										}
									}
									else
									{
										if (this.Proddy > 0.7f)
										{
											this.Obstacle = true;
										}
									}
								}
								else
								{
									if (this.Proddy > 0.35f)
									{
										this.Obstacle = true;
									}
								}
							}
						}
						if (relativePoint2.x < (-0.4f * this.VelClamp2))
						{
							this.TopSpeed = 25;
							this.Stab = true;
							this.Obstacle = false;
							if (relativePointW.x < -2)
							{
								this.TurnRight = false;
								this.TurnLeft = true;
							}
							if (relativePointW.x > 2)
							{
								this.TurnLeft = false;
								this.TurnRight = true;
							}
						}
						if (relativePoint2.x > (0.4f * this.VelClamp2))
						{
							this.TopSpeed = 25;
							this.Stab = true;
							this.Obstacle = false;
							if (relativePointW.x < -2)
							{
								this.TurnRight = false;
								this.TurnLeft = true;
							}
							if (relativePointW.x > 2)
							{
								this.TurnLeft = false;
								this.TurnRight = true;
							}
						}
					}
					if (!this.FreeFloating)
					{
						if ((this.RightDist > this.LeftDist) && this.SteepInc)
						{
							this.TurnLeft = false;
							this.TurnRight = true;
						}
						if ((this.LeftDist > this.RightDist) && this.SteepInc)
						{
							this.TurnRight = false;
							this.TurnLeft = true;
						}
					}
					else
					{
						if (this.RightDist > this.LeftDist)
						{
							this.TurnLeft = false;
							this.TurnRight = true;
						}
						if (this.LeftDist > this.RightDist)
						{
							this.TurnRight = false;
							this.TurnLeft = true;
						}
					}
					if (!this.TurnLeft && !this.TurnRight)
					{
						if (!this.IsClose)
						{
							RPClamp = Mathf.Clamp(this.RPMod, -this.TurnForce, this.TurnForce);
						}
						else
						{
							RPClamp = 0;
						}
						if (this.target)
						{
							this.RP = RelativeTarget;
							if (!this.Threatened)
							{
								this.vRigidbody.AddTorque(this.thisTransform.up * RPClamp);
							}
							else
							{
								this.vRigidbody.AddTorque(this.thisTransform.up * -RPClamp);
							}
						}
						this.vRigidbody.AddTorque(this.thisTransform.up * this.TurnStabForce);
					}
					else
					{
						if (this.Stab)
						{
							this.vRigidbody.AddTorque(this.thisTransform.up * this.TurnStabForce);
						}
						RPClamp = 0;
					}
					if (this.Obstacle)
					{
						if (this.Vel > 0)
						{
							this.vRigidbody.AddForce(this.thisVTransform.up * this.BrakeForce);
						}
						else
						{
							this.Obstacle = false;
						}
					}
					if (this.StrafeRight)
					{
						this.vRigidbody.AddForce(this.thisVTransform.right * this.DirForce);
					}
					if (this.StrafeLeft)
					{
						this.vRigidbody.AddForce(this.thisVTransform.right * -this.DirForce);
					}
					if (this.Stuck > 0)
					{
						if (!this.IsClose && !this.IsDropping)
						{
							if (this.vRigidbody.angularVelocity.magnitude < this.TurnSpeed)
							{
								if (this.Turnerisms > 0)
								{
									this.vRigidbody.AddTorque(this.thisTransform.up * this.TurnForce);
								}
								else
								{
									this.vRigidbody.AddTorque(this.thisTransform.up * -this.TurnForce);
								}
							}
							if (!this.DriftyVessel)
							{
								if (-this.Vel < 10)
								{
									this.vRigidbody.AddForce(this.thisVTransform.up * this.DirForce);
								}
							}
						}
					}
					if (this.isBejsirf)
					{
						if (((this.Stuck < 1) && !this.IsClose) && !this.IsDropping)
						{
							if (!this.Obstacle)
							{
								if (this.Vel < this.TopSpeed)
								{
									if (this.TopSpeed < 50)
									{
										this.vRigidbody.AddForce(this.thisVTransform.up * -3);
									}
									else
									{
										this.vRigidbody.AddForce(this.thisVTransform.up * -this.DirForce);
									}
								}
								else
								{
									this.vRigidbody.AddForce(this.thisVTransform.up * this.SlowDownForce);
								}
							}
						}
					}
					else
					{
						if (((this.Stuck < 1) && !this.IsClose) && !this.IsDropping)
						{
							if (!this.Obstacle)
							{
								if (this.Vel < this.TopSpeed)
								{
									this.vRigidbody.AddForce(this.thisVTransform.up * -this.DirForce);
								}
								else
								{
									this.vRigidbody.AddForce(this.thisVTransform.up * this.SlowDownForce);
								}
							}
						}
					}
					if ((this.Stuck < 1) && !this.IsDropping)
					{
						if (this.TurnLeftX)
						{
							if (this.vRigidbody.angularVelocity.magnitude < this.TurnSpeed)
							{
								this.vRigidbody.AddTorque(this.thisTransform.up * -this.TurnForce);
							}
						}
						if (this.TurnRightX)
						{
							if (this.vRigidbody.angularVelocity.magnitude < this.TurnSpeed)
							{
								this.vRigidbody.AddTorque(this.thisTransform.up * this.TurnForce);
							}
						}
						if (this.TurnLeft && !this.TurnRight)
						{
							if (this.Vel < (this.TopSpeed * 0.5f))
							{
								if (this.vRigidbody.angularVelocity.magnitude < this.TurnSpeed)
								{
									this.vRigidbody.AddTorque(this.thisTransform.up * -this.TurnForce);
								}
							}
							else
							{
								if (this.vRigidbody.angularVelocity.magnitude < this.TurnSpeed)
								{
									this.vRigidbody.AddTorque((this.thisTransform.up * -this.TurnForce) * 0.25f);
								}
							}
						}
						if (this.TurnRight && !this.TurnLeft)
						{
							if (this.Vel < (this.TopSpeed * 0.5f))
							{
								if (this.vRigidbody.angularVelocity.magnitude < this.TurnSpeed)
								{
									this.vRigidbody.AddTorque(this.thisTransform.up * this.TurnForce);
								}
							}
							else
							{
								if (this.vRigidbody.angularVelocity.magnitude < this.TurnSpeed)
								{
									this.vRigidbody.AddTorque((this.thisTransform.up * this.TurnForce) * 0.25f);
								}
							}
						}
						if (this.TurnUp)
						{
							if (this.vRigidbody.angularVelocity.magnitude < this.TurnSpeed)
							{
								this.vRigidbody.AddTorque(this.thisTransform.right * -this.TurnForce);
							}
						}
						if (this.TurnDown)
						{
							if (this.vRigidbody.angularVelocity.magnitude < this.TurnSpeed)
							{
								this.vRigidbody.AddTorque(this.thisTransform.right * this.TurnForce);
							}
						}
					}
				}
				else
				{
					if (this.Vel > 10)
					{
						RPClamp2 = Mathf.Clamp(this.RPMod2, -this.TurnForce, this.TurnForce);
						this.vRigidbody.AddTorque(this.thisTransform.up * RPClamp2);
					}
				}
				if (this.IsClose || this.Parked)
				{
					if (this.Vel > 0)
					{
						this.vRigidbody.AddForce(this.thisVTransform.up * this.BrakeForce);
					}
					if (-this.Vel > 0)
					{
						this.vRigidbody.AddForce(this.thisVTransform.up * -this.DirForce);
					}
				}
			}
			//[DoorAni]-----------------------------------------------------------------------------------------------------------------------------
			if (this.IsTaxi)
			{
				if (!this.DoorOpen)
				{
					if (this.TaxiDoor.transform.localPosition.y > -0.001f)
					{
						if (this.TaxiDoor.transform.localPosition.x < 0)
						{

							{
								float _1102 = this.TaxiDoor.transform.localPosition.x + 0.005f;
								Vector3 _1103 = this.TaxiDoor.transform.localPosition;
								_1103.x = _1102;
								this.TaxiDoor.transform.localPosition = _1103;
							}
						}
					}
					if (this.TaxiDoor.transform.localPosition.y < -0.001f)
					{

						{
							float _1104 = this.TaxiDoor.transform.localPosition.y + 0.01f;
							Vector3 _1105 = this.TaxiDoor.transform.localPosition;
							_1105.y = _1104;
							this.TaxiDoor.transform.localPosition = _1105;
						}
					}
				}
				else
				{
					if (this.TaxiDoor.transform.localPosition.x > -0.3f)
					{

						{
							float _1106 = this.TaxiDoor.transform.localPosition.x - 0.005f;
							Vector3 _1107 = this.TaxiDoor.transform.localPosition;
							_1107.x = _1106;
							this.TaxiDoor.transform.localPosition = _1107;
						}
					}
					if (this.TaxiDoor.transform.localPosition.x < -0.3f)
					{
						if (this.TaxiDoor.transform.localPosition.y > -1.8f)
						{

							{
								float _1108 = this.TaxiDoor.transform.localPosition.y - 0.01f;
								Vector3 _1109 = this.TaxiDoor.transform.localPosition;
								_1109.y = _1108;
								this.TaxiDoor.transform.localPosition = _1109;
							}
						}
					}
				}
			}
		}
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other != null)
		{
			if (other.GetComponent<Collider>().name.Contains("TFC"))
			{
				if (this.TargetCode == 2)
				{
					AgrianNetwork.instance.PriorityWaypoint.transform.position = other.transform.position;
					if (AgrianNetwork.instance.AlertTime < 120)
					{
						AgrianNetwork.instance.AlertTime = 120;
					}
				}
				if (this.TargetCode == 9)
				{
					DutvutanianNetwork.instance.PriorityWaypoint.transform.position = other.transform.position;
					if (DutvutanianNetwork.AlertTime < 120)
					{
						DutvutanianNetwork.AlertTime = 120;
					}
				}
				if (Vector3.Distance(this.thisTransform.position, other.transform.position) < this.ThreatPerimiter)
				{
					if (other.GetComponent<Collider>().name.Contains("C1"))
					{
						this.ThreatenedByTC1 = this.ThreatenedByTC1 + 1;
					}
					if (other.GetComponent<Collider>().name.Contains("C4"))
					{
						this.ThreatenedByTC4 = this.ThreatenedByTC4 + 1;
					}
					if (other.GetComponent<Collider>().name.Contains("C5"))
					{
						this.ThreatenedByTC5 = this.ThreatenedByTC5 + 1;
					}
					if (other.GetComponent<Collider>().name.Contains("C6"))
					{
						this.ThreatenedByTC6 = this.ThreatenedByTC6 + 1;
					}
					if (other.GetComponent<Collider>().name.Contains("C7"))
					{
						this.ThreatenedByTC7 = this.ThreatenedByTC7 + 1;
					}
				}
				if (this.Escaping < 60)
				{
					this.Escaping = this.Escaping + 3;
				}
				if (this.Ogle > 2)
				{
					this.StartCoroutine(this.Excuse());
				}
			}
		}
	}

	public virtual void OnTriggerStay(Collider other)
	{
		if (other != null)
		{
			if (other.GetComponent<Collider>().name.Contains("mTC2") || other.GetComponent<Collider>().name.Contains("mTC3"))
			{
				this.Sanctuary = other.gameObject.transform;
			}
			if (other.GetComponent<Collider>().name.Contains("TC"))
			{
				if (Vector3.Distance(this.thisTransform.position, other.transform.position) < 256)
				{
					this.Stranger = other.gameObject.transform;
					if (!this.IsCarrier)
					{
						if (this.Stranger.name.Contains("TC6"))
						{
							this.ThreatenedByTC6 = 3;
						}
						if (this.Stranger.name.Contains("TC7"))
						{
							this.ThreatenedByTC7 = 3;
						}
					}
				}
			}
		}
	}

	public virtual void Targety()
	{
		if ((!this.Threatened && this.HasHome) && (this.Ogle < 1))
		{
			if (Vector3.Distance(this.thisTransform.position, this.Waypoint.position) > 5000)
			{
				this.target = this.Waypoint;
			}
			if (this.target == this.Waypoint)
			{
				if (Vector3.Distance(this.thisTransform.position, this.Waypoint.position) < 5000)
				{
					this.target = this.ResetView;
				}
			}
		}
		if (this.RoadTF != this.RoadTF2)
		{
			this.RoadTF2 = this.RoadTF;
		}
	}

	public virtual void Refresher()
	{
		int i1 = 0;
		Vector3 localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.angularVelocity);
		if (this.isBejsirf)
		{
			if (this.TopSpeed > 45)
			{
				this.FullSpeed = !this.Obstacle;
			}
			else
			{
				this.FullSpeed = false;
			}
			if (this.Runsound)
			{
				this.Runsound.RunningF = this.FullSpeed;
			}
			if (this.Whizzer1)
			{
				this.Whizzer1.RunningF = this.FullSpeed;
			}
			if (this.Whizzer2)
			{
				this.Whizzer2.RunningF = this.FullSpeed;
			}
			if (this.Blastoff)
			{
				if (this.FullSpeed && !this.Once)
				{
					this.Once = true;
					if (!this.Blastoff.isPlaying)
					{
						this.Blastoff.Play();
					}
				}
				if (!this.FullSpeed && this.Once)
				{
					this.Once = false;
				}
			}
			if (!(this.Particles == null))
			{
				i1 = 0;
				while (i1 < this.Particles.Length)
				{
					this.Particles[i1].enableEmission = this.FullSpeed;
					i1++;
				}
			}
		}
		if (this.Gyro)
		{
			this.Gyro.Deactivated = false;
		}
		if (this.TurnRight)
		{
			if (this.Turnerisms < 5)
			{
				this.Turnerisms = this.Turnerisms + 1;
			}
			if (this.Gyro)
			{
				this.Gyro.Deactivated = true;
			}
		}
		if (this.TurnLeft)
		{
			if (this.Turnerisms > -5)
			{
				this.Turnerisms = this.Turnerisms - 1;
			}
			if (this.Gyro)
			{
				this.Gyro.Deactivated = true;
			}
		}
		if (this.TurnUp)
		{
			if (this.Gyro)
			{
				this.Gyro.Deactivated = true;
			}
		}
		if (this.TurnDown)
		{
			if (this.Gyro)
			{
				this.Gyro.Deactivated = true;
			}
		}
		if (localV.x > 0.1f)
		{
			if (this.Ride < 2)
			{
				this.Ride = this.Ride + 0.1f;
			}
		}
		else
		{
			if (this.Ride > 0)
			{
				this.Ride = this.Ride - 0.1f;
			}
		}
		if (this.DownDist == this.UpDist)
		{
			this.SteepInc = false;
		}
		this.Obstacle = false;
		this.TurnRight = false;
		this.TurnLeft = false;
	}

	public virtual void Updater()
	{
		if (this.target == null)
		{
			this.target = this.ResetView;
		}
		else
		{
			this.Dist = Vector3.Distance(this.thisTransform.position, this.target.position);
		}
		if (this.RoadTime > 0)
		{
			this.RoadTime = this.RoadTime - 1;
		}
		if (this.RoadTime < 1)
		{
			this.Road = false;
			this.RoadTF = null;
			this.TopSpeed = this.StatTopSpeed;
		}
		if (this.IsTaxi && this.CanDrive)
		{
			this.SceneTimer = this.SceneTimer - 1;
			if (this.SceneTimer == 0)
			{
				this.StartCoroutine(this.SwitchScene());
			}
		}
		if (WorldInformation.instance.RestrictedArea)
		{
			if (Vector3.Distance(this.thisTransform.position, WorldInformation.instance.RestrictedArea.position) < 1000)
			{
				this.target = WorldInformation.instance.RestrictedArea;
				this.Threatened = true;
			}
		}
		if (!this.Threatened && !this.OffToDrop)
		{
			this.IsClose = false;
		}
		if (this.target)
		{
			if (this.Threatened)
			{
				if (Vector3.Distance(this.thisTransform.position, this.target.position) > 1000)
				{
					this.target = this.ResetView;
					this.Threatened = false;
				}
			}
		}
		if (this.Threatened)
		{
			this.Trig.radius = 20;
		}
		else
		{
			this.Trig.radius = 200;
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
		if (this.Ogle > 0)
		{
			if (Vector3.Distance(this.thisTransform.position, this.target.position) < (32 + this.vRigidbody.mass))
			{
				this.PRot = 0;
				this.PCount = 0;
				this.Pathfind = false;
				this.GoToPath = false;
				this.Parked = true;
				this.Ogle = this.Ogle - 1;
			}
			else
			{
				this.Parked = false;
			}
			if (this.Ogle < 1)
			{
				this.Parked = false;
				//Reposition = false;
				this.target = this.Waypoint;
			}
		}
		if (this.Escaping > 0)
		{
			this.Escaping = this.Escaping - 1;
			if (!this.Sanctuary)
			{
				this.target = this.ResetView;
			}
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
		if (this.IsCarrier)
		{
			if (this.MissionWaypoint)
			{
				this.MissionDist = Vector3.Distance(this.thisTransform.position, this.MissionWaypoint.position);
			}
			if (this.HasVehicleShipment && !this.GoToPath)
			{
				if (!this.AtDestination)
				{
					this.OffToDrop = true;
					this.target = PlayerInformation.instance.PiriTarget;
				}
				else
				{
					this.OffToDrop = true;
					this.target = this.ResetView;
					if (((this.TVel < 0.02f) && (this.TAVel < 0.02f)) && !this.IsDropping)
					{
						this.IsDropping = true;
						this.StartCoroutine(this.StopToDrop());
					}
				}
				if (this.StrafeRight || this.StrafeLeft)
				{
					if (Vector3.Distance(this.thisTransform.position, this.CargoTF.position) > 24)
					{

						{
							int _1110 = 0;
							JointSpring _1111 = this.Hinge1.spring;
							_1111.targetPosition = _1110;
							this.Hinge1.spring = _1111;
						}

						{
							int _1112 = 0;
							JointSpring _1113 = this.Hinge2.spring;
							_1113.targetPosition = _1112;
							this.Hinge2.spring = _1113;
						}

						{
							int _1114 = 0;
							JointSpring _1115 = this.Hinge3.spring;
							_1115.targetPosition = _1114;
							this.Hinge3.spring = _1115;
						}

						{
							int _1116 = 0;
							JointSpring _1117 = this.Hinge4.spring;
							_1117.targetPosition = _1116;
							this.Hinge4.spring = _1117;
						}

						{
							int _1118 = 0;
							JointSpring _1119 = this.Hinge5.spring;
							_1119.targetPosition = _1118;
							this.Hinge5.spring = _1119;
						}

						{
							int _1120 = 0;
							JointSpring _1121 = this.Hinge6.spring;
							_1121.targetPosition = _1120;
							this.Hinge6.spring = _1121;
						}
						this.OffToDrop = false;
						this.IsDropping = false;
						this.StrafeRight = false;
						this.HasVehicleShipment = false;
						this.target = this.ResetView;
					}
				}
			}
		}
		if ((this.GoToPath && !this.IsDropping) && (this.Ogle < 1))
		{
			this.target = this.Waypoint;
			if (Vector3.Distance(this.thisTransform.position, this.Waypoint.position) < 100)
			{
				this.target = this.ResetView;
				this.GoToPath = false;
			}
			else
			{
				Vector3 relativePathPoint = this.thisTransform.InverseTransformPoint(this.Waypoint.position);
				if ((relativePathPoint.y > 64) || (-relativePathPoint.y > 64))
				{
					this.GoToPath = false;
				}
			}
		}
		if (this.IsTaxi)
		{
			if (Vector3.Distance(this.thisTransform.position, PlayerInformation.instance.Pirizuka.position) < 4)
			{
				this.IsInside = true;
			}
			else
			{
				this.IsInside = false;
			}
		}
		if (this.Stuck < 1)
		{
			if (this.StuckNum < 1)
			{
				this.StuckNum = 6;
				Vector3 lastPos = this.thisTransform.position;
				this.StartCoroutine(this.IsEscaping(lastPos));
			}
			else
			{
				this.StuckNum = this.StuckNum - 1;
			}
		}
		if (this.ignoreInteraction)
		{
			return;
		}
		//========================================================================================================================//
		//////////////////////////////////////////////////////[INTERACTION]/////////////////////////////////////////////////////////
		//========================================================================================================================//
		if (NotiScript.PiriNotis)
		{
			if (Vector3.Distance(this.thisTransform.position, PlayerInformation.instance.Pirizuka.position) < 128)
			{
				if (this.convNum < 4)
				{
					if (this.Escaping == 0)
					{
						this.target = PlayerInformation.instance.PiriTarget;
						this.Ogle = 20;
					}
					else
					{
						if (this.target)
						{
							if (this.target.name.Contains("TC1"))
							{
								this.target = PlayerInformation.instance.PiriTarget;
								this.Ogle = 20;
							}
						}
					}
				}
				NotiScript.PiriNotis = false;
			}
		}
		if (this.Ogle > 0)
		{
			if (WorldInformation.pSpeech)
			{
				if (WorldInformation.pSpeech.name.Contains("a1"))
				{
					if (Vector3.Distance(this.thisTransform.position, WorldInformation.pSpeech.position) < 32)
					{
						this.StartCoroutine(this.ProcessSpeech(TalkBubbleScript.myText, 0));
					}
				}
				if (WorldInformation.pSpeech.name.Contains("b1"))
				{
					if (Vector3.Distance(this.thisTransform.position, WorldInformation.pSpeech.position) < 64)
					{
						this.StartCoroutine(this.ProcessSpeech(TalkBubbleScript.myText, 1));
					}
				}
				if (WorldInformation.pSpeech.name.Contains("c1"))
				{
					if (Vector3.Distance(this.thisTransform.position, WorldInformation.pSpeech.position) < 128)
					{
						this.StartCoroutine(this.ProcessSpeech(TalkBubbleScript.myText, 2));
					}
				}
				WorldInformation.pSpeech = null;
			}
		}
	}

	public virtual IEnumerator StopToDrop()
	{
		GameObject Container = ((GameObject)Resources.Load("Objects/THookContainerD2", typeof(GameObject))) as GameObject;
		UnityEngine.Object.Destroy(this.Container2GO);
		UnityEngine.Object.Instantiate(Container, this.ContainerPoint2.position, this.ContainerPoint2.rotation);
		GameObject Prefabionaise1 = ((GameObject)Resources.Load("VesselPrefabs/" + VesselList.instance.StaticStringOut, typeof(GameObject))) as GameObject;
		GameObject TheThing1 = UnityEngine.Object.Instantiate(Prefabionaise1, this.CargoSpawnTF.position, this.CargoSpawnTF.rotation);
		((VehicleSensor)TheThing1.transform.GetComponent(typeof(VehicleSensor))).Vessel.name = "ShippedVessel" + WorldInformation.ShippedVehicleNum;
		((VehicleSensor)TheThing1.GetComponent(typeof(VehicleSensor))).Repositioned = true;

		{
			float _1122 = TheThing1.transform.position.y + ((VehicleSensor)TheThing1.transform.GetComponent(typeof(VehicleSensor))).MidToGroundDist;
			Vector3 _1123 = TheThing1.transform.position;
			_1123.y = _1122;
			TheThing1.transform.position = _1123;
		}
		VesselList.instance.StaticStringOut = null;
		WorldInformation.ShippedVehicleNum = WorldInformation.ShippedVehicleNum + 1;
		this.CargoTF = TheThing1.transform;

		{
			int _1124 = -100;
			JointSpring _1125 = this.Hinge1.spring;
			_1125.targetPosition = _1124;
			this.Hinge1.spring = _1125;
		}

		{
			int _1126 = -100;
			JointSpring _1127 = this.Hinge2.spring;
			_1127.targetPosition = _1126;
			this.Hinge2.spring = _1127;
		}

		{
			int _1128 = -100;
			JointSpring _1129 = this.Hinge3.spring;
			_1129.targetPosition = _1128;
			this.Hinge3.spring = _1129;
		}

		{
			int _1130 = -100;
			JointSpring _1131 = this.Hinge4.spring;
			_1131.targetPosition = _1130;
			this.Hinge4.spring = _1131;
		}

		{
			int _1132 = -100;
			JointSpring _1133 = this.Hinge5.spring;
			_1133.targetPosition = _1132;
			this.Hinge5.spring = _1133;
		}

		{
			int _1134 = -100;
			JointSpring _1135 = this.Hinge6.spring;
			_1135.targetPosition = _1134;
			this.Hinge6.spring = _1135;
		}
		yield return new WaitForSeconds(3);
		this.StrafeRight = true;
	}

	public virtual IEnumerator IsEscaping(Vector3 lastPos)
	{
		yield return new WaitForSeconds(1);
		if (((Vector3.Distance(this.thisTransform.position, lastPos) < 0.4f) && !this.IsClose) && this.CanDrive)
		{
			this.Stuck = this.UnstickTime;
			yield return new WaitForSeconds(0.5f);
			if (this.Stuck == 0)
			{
				this.Stuck = (int)(this.UnstickTime * 0.8f);
			}
		}
	}

	public virtual void Pathy()
	{
		Vector3 lastArea = this.thisTransform.position;
		this.StartCoroutine(this.IsPathfinding(lastArea));
	}

	public virtual IEnumerator IsPathfinding(Vector3 lastArea)
	{
		yield return new WaitForSeconds(30);
		if ((((Vector3.Distance(this.thisTransform.position, lastArea) < 250) && !this.IsClose) && !this.GoToPath) && !this.IsDropping)
		{
			this.Pathfind = true;
		}
	}

	public virtual IEnumerator SwitchScene()
	{
		ScreenFadeScript.FadeOut = true;
		if (WorldInformation.instance.TaxiExit1)
		{
			LoadPiriLocation.Exit1 = true;
		}
		if (WorldInformation.instance.TaxiExit2)
		{
			LoadPiriLocation.Exit2 = true;
		}
		if (WorldInformation.instance.TaxiExit3)
		{
			LoadPiriLocation.Exit3 = true;
		}
		PlayerCamFollow.HoldCam = true;
		yield return new WaitForSeconds(2);
		Application.LoadLevel(WorldInformation.instance.TaxiWhereToGo);
	}

	public virtual IEnumerator Excuse()
	{
		yield return new WaitForSeconds(0.2f);
		if (this.ThreatenedByTC1 > 0)
		{
			this.convNum = 99;
			this.Ogle = 1;
		}
		else
		{
			if (this.target.name.Contains("TC1"))
			{
				if (this.IsCarrier)
				{
					this.ReturnSpeech("Sorry, I don't feel like \n sacrificing my ship.");
				}
				else
				{
					this.ReturnSpeech("Sorry, I don't feel safe \n around here.");
				}
				this.convNum = 0;
				this.Ogle = 1;
			}
		}
	}

	//========================================================================================================================//
	//////////////////////////////////////////////////////[INTERACTION]/////////////////////////////////////////////////////////
	//========================================================================================================================//
	public int convNum;
	public int boredom;
	public virtual IEnumerator ProcessSpeech(string speech, int mode)
	{
		yield return new WaitForSeconds(0.1f);
		if (!!string.IsNullOrEmpty(speech))
		{
			yield break;
		}
		if (mode == 0)
		{
			if (this.convNum == 0)
			{
				//===============================================================================
				if (this.HasSpace)
				{
					if ((speech.Contains("hi") || speech.Contains("hey")) || speech.Contains("yo"))
					{
						this.convNum = 11;
						yield return new WaitForSeconds(2);
						this.ReturnSpeech("Hello stranger.");
						yield break;
					}
					if (speech.Contains("hello") || speech.Contains("greet"))
					{
						this.convNum = 1;
						yield return new WaitForSeconds(2);
						this.ReturnSpeech("You look lost. \n You need a ride?");
						yield break;
					}
					if (speech.Contains("in") || speech.Contains("on"))
					{
						this.convNum = 1;
						yield return new WaitForSeconds(2);
						this.ReturnSpeech("You want in?");
						yield break;
					}
					if (speech.Contains("ride") || speech.Contains("lift"))
					{
						this.convNum = 11;
						yield return new WaitForSeconds(2);
						this.ReturnSpeech("Alright. \n There is space for you.");
						this.vEntrance.DenyEntrance = false;
						yield break;
					}
				}
				else
				{
					if ((speech.Contains("hi") || speech.Contains("hey")) || speech.Contains("yo"))
					{
						this.convNum = 1;
						yield return new WaitForSeconds(2);
						this.ReturnSpeech("Hello stranger.");
						yield break;
					}
					if (speech.Contains("hello") || speech.Contains("greet"))
					{
						this.convNum = 1;
						yield return new WaitForSeconds(2);
						this.ReturnSpeech("Hello! You look lost.");
						yield break;
					}
				}
				if (speech.Contains("stop"))
				{
					this.convNum = 11;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Ok, I am stopping.");
					yield break;
				}
			}
			//===============================================================================
			if (this.convNum == 1)
			{
				//===============================================================================
				if (speech.Contains("yes"))
				{
					this.convNum = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Ok, There's room for you.");
					yield break;
				}
				if (speech.Contains("no"))
				{
					this.convNum = 2;
					this.Ogle = 1;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Alright, you have a good one.");
					yield break;
				}
				if (speech.Contains("go"))
				{
					this.convNum = 2;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Well then.");
					yield break;
				}
				if (speech.Contains("drive"))
				{
					this.convNum = 2;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Ok.");
					yield break;
				}
				if ((speech.Contains("leave") && !speech.Contains("i")) || (speech.Contains("u") && speech.Contains("leave")))
				{
					this.convNum = 2;
					this.Ogle = 1;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Ok.");
					yield break;
				}
				if (this.HasSpace)
				{
					if (speech.Contains("ride") || speech.Contains("lift"))
					{
						this.convNum = 2;
						yield return new WaitForSeconds(2);
						this.ReturnSpeech("Yes, just jump in.");
						this.vEntrance.DenyEntrance = false;
						yield break;
					}
					if (speech.Contains("i") && speech.Contains("leave"))
					{
						this.convNum = 2;
						yield return new WaitForSeconds(2);
						this.ReturnSpeech("Alright, go ahead.");
						this.vEntrance.DenyEntrance = false;
						yield break;
					}
				}
				if (speech.Contains("stop"))
				{
					this.convNum = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Ok, right here.");
					yield break;
				}
			}
			//===============================================================================
			if (this.convNum == 11)
			{
				//===============================================================================
				if (speech.Contains("yes"))
				{
					this.convNum = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("What is it?");
					yield break;
				}
				if (speech.Contains("no"))
				{
					this.convNum = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Wait, what?");
					yield break;
				}
				if ((speech.Contains("leave") && !speech.Contains("i")) || (speech.Contains("u") && speech.Contains("leave")))
				{
					this.convNum = 2;
					this.Ogle = 1;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Alright.");
					yield break;
				}
				if (this.HasSpace)
				{
					if (speech.Contains("ride") || speech.Contains("lift"))
					{
						this.convNum = 2;
						yield return new WaitForSeconds(2);
						this.ReturnSpeech("Sure, I can give you a lift.");
						this.vEntrance.DenyEntrance = false;
						yield break;
					}
					if (speech.Contains("i") && speech.Contains("leave"))
					{
						this.convNum = 2;
						yield return new WaitForSeconds(2);
						this.ReturnSpeech("Alright.");
						this.vEntrance.DenyEntrance = false;
						yield break;
					}
				}
				if (speech.Contains("stop"))
				{
					this.convNum = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Ok, will do.");
					yield break;
				}
			}
			//===============================================================================
			if (this.convNum == 12)
			{
				//===============================================================================
				if (speech.Contains("yes"))
				{
					this.convNum = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("What is it?");
					yield break;
				}
				if (speech.Contains("no"))
				{
					this.convNum = 2;
					this.Ogle = 1;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Alright, you have a good one.");
					yield break;
				}
				if ((speech.Contains("leave") && !speech.Contains("i")) || (speech.Contains("u") && speech.Contains("leave")))
				{
					this.convNum = 2;
					this.Ogle = 1;
					yield return new WaitForSeconds(2);
					yield break;
				}
				if (this.HasSpace)
				{
					if (speech.Contains("ride") || speech.Contains("lift"))
					{
						this.convNum = 2;
						yield return new WaitForSeconds(2);
						this.ReturnSpeech("Yes, just jump in.");
						this.vEntrance.DenyEntrance = false;
						yield break;
					}
					if (speech.Contains("i") && speech.Contains("leave"))
					{
						this.convNum = 2;
						yield return new WaitForSeconds(2);
						this.ReturnSpeech("Alright.");
						this.vEntrance.DenyEntrance = false;
						yield break;
					}
				}
				if (speech.Contains("stop"))
				{
					this.convNum = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Ok, hold on.");
					yield break;
				}
			}
			//===============================================================================
			if (this.convNum == 13)
			{
				//===============================================================================
				if (speech.Contains("yes"))
				{
					this.convNum = 4;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech(". . .");
					yield break;
				}
				if (speech.Contains("no"))
				{
					this.convNum = 3;
					this.Ogle = 1;
					yield return new WaitForSeconds(4);
					this.ReturnSpeech("What is wrong with you?");
					yield break;
				}
				if (speech.Contains("in") || speech.Contains("on"))
				{
					this.convNum = 3;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Just do it then.");
					yield break;
				}
				if (speech.Contains("ride") || speech.Contains("lift"))
				{
					this.convNum = 3;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Just do it already!");
					this.vEntrance.DenyEntrance = false;
					yield break;
				}
				if ((speech.Contains("leave") && !speech.Contains("i")) || (speech.Contains("u") && speech.Contains("leave")))
				{
					this.convNum = 3;
					this.Ogle = 1;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("*sigh*");
					yield break;
				}
				if (speech.Contains("i") && speech.Contains("leave"))
				{
					this.convNum = 3;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Jump in already.");
					this.vEntrance.DenyEntrance = false;
					yield break;
				}
				if (speech.Contains("stop"))
				{
					this.convNum = 3;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Alright.");
					yield break;
				}
			}
			//===============================================================================
			if (this.convNum == 14)
			{
				//===============================================================================
				if (speech.Contains("yes"))
				{
					this.convNum = 4;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech(". . .");
					yield break;
				}
				if (speech.Contains("no"))
				{
					this.convNum = 4;
					this.Ogle = 2;
					yield return new WaitForSeconds(4);
					this.ReturnSpeech(". . .");
					yield break;
				}
				if (speech.Contains("in") || speech.Contains("lift"))
				{
					this.convNum = 4;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("You already got your chance!");
					yield break;
				}
				if (speech.Contains("ride") || speech.Contains("on"))
				{
					this.convNum = 4;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("I think I'll pass on that now.");
					yield break;
				}
				if (speech.Contains("stop"))
				{
					this.convNum = 4;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Go bug somebody else.");
					yield break;
				}
			}
			//===============================================================================
			if (this.convNum == 2)
			{
				//===============================================================================
				if (speech.Contains("yes"))
				{
					this.convNum = 13;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Ok, what is it?");
					yield break;
				}
				if (speech.Contains("no"))
				{
					this.convNum = 3;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Ok.");
					yield break;
				}
				if (speech.Contains("in") || speech.Contains("on"))
				{
					this.convNum = 3;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("I do not have all day.");
					this.vEntrance.DenyEntrance = false;
					yield break;
				}
				if (speech.Contains("ride") || speech.Contains("lift"))
				{
					this.convNum = 3;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Ok, I do not have all day.");
					this.vEntrance.DenyEntrance = false;
					yield break;
				}
				if (speech.Contains("go"))
				{
					this.convNum = 3;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Yes, yes.");
					yield break;
				}
				if (speech.Contains("drive"))
				{
					this.convNum = 3;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Yes, yes.");
					yield break;
				}
				if ((speech.Contains("leave") && !speech.Contains("i")) || (speech.Contains("u") && speech.Contains("leave")))
				{
					this.convNum = 3;
					this.Ogle = 1;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Alright.");
					yield break;
				}
				if (speech.Contains("i") && speech.Contains("leave"))
				{
					this.convNum = 3;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Alright.");
					this.vEntrance.DenyEntrance = false;
					yield break;
				}
				if (speech.Contains("stop"))
				{
					this.convNum = 3;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Alright.");
					yield break;
				}
			}
			//===============================================================================
			if (this.convNum == 21)
			{
				//===============================================================================
				if (speech.Contains("hi"))
				{
					this.convNum = 4;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech(". . .");
					yield break;
				}
				if (speech.Contains("hello"))
				{
					this.convNum = 4;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech(". . .");
					yield break;
				}
				if (speech.Contains("in") || speech.Contains("on"))
				{
					this.convNum = 4;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Goodbye, idiot!");
					yield break;
				}
				if (speech.Contains("ride") || speech.Contains("lift"))
				{
					this.convNum = 4;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("You know what? Bug off!");
					yield break;
				}
				if (speech.Contains("stop"))
				{
					this.convNum = 4;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Leave!");
					yield break;
				}
			}
			//===============================================================================
			if (this.convNum == 3)
			{
				//===============================================================================
				if ((speech.Contains("hi") || speech.Contains("hey")) || speech.Contains("yo"))
				{
					this.convNum = 14;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("State your business! \n I do not have all day.");
					yield break;
				}
				if (speech.Contains("hello") || speech.Contains("greet"))
				{
					this.convNum = 14;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Just state what you want already!");
					yield break;
				}
				if (speech.Contains("in") || speech.Contains("on"))
				{
					this.convNum = 4;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("How about no.");
					yield break;
				}
				if (speech.Contains("ride") || speech.Contains("lift"))
				{
					this.convNum = 4;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Pick another ride. \n You already got one chance.");
					yield break;
				}
				if (speech.Contains("stop"))
				{
					this.convNum = 21;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Alright! \n Now get on with it!");
					yield break;
				}
				this.convNum = 4;
				this.boredom = 4;
				this.Ogle = 2;
				yield return new WaitForSeconds(2);
				this.ReturnSpeech("Goodbye!");
				yield break;
			}
		}
		//===============================================================================
		//======================================================================================================================================
		//======================================================================================================================================
		if (mode == 1)
		{
			if (this.convNum == 0)
			{
				//===============================================================================
				if ((speech.Contains("hi") || speech.Contains("hey")) || speech.Contains("yo"))
				{
					this.convNum = 1;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Hello stranger. You need something?");
					yield break;
				}
				if (speech.Contains("hello") || speech.Contains("greet"))
				{
					this.convNum = 1;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Greetings! You look lost. \n You want directions?");
					yield break;
				}
				if (speech.Contains("in") || speech.Contains("on"))
				{
					this.convNum = 1;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Wait, what?");
					yield break;
				}
				if (speech.Contains("ride") || speech.Contains("lift"))
				{
					this.convNum = 11;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("What, your vessel is broken?");
					yield break;
				}
				if (speech.Contains("stop"))
				{
					this.convNum = 11;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Why do you want me to stop?");
					yield break;
				}
			}
			//===============================================================================
			if (this.convNum == 1)
			{
				//===============================================================================
				if (speech.Contains("yes"))
				{
					this.convNum = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Ok, What is it?");
					yield break;
				}
				if (speech.Contains("no"))
				{
					this.convNum = 2;
					this.Ogle = 1;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Alright, you have a good one.");
					yield break;
				}
				if (speech.Contains("ride") || speech.Contains("lift"))
				{
					this.convNum = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Well then, go ahead.");
					this.vEntrance.DenyEntrance = false;
					yield break;
				}
				if (speech.Contains("go"))
				{
					this.convNum = 2;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Well then.");
					yield break;
				}
				if ((speech.Contains("leave") && !speech.Contains("i")) || (speech.Contains("u") && speech.Contains("leave")))
				{
					this.convNum = 2;
					this.Ogle = 1;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Alright.");
					yield break;
				}
				if (this.HasSpace)
				{
					if (speech.Contains("ride") || speech.Contains("lift"))
					{
						this.convNum = 2;
						yield return new WaitForSeconds(2);
						this.ReturnSpeech("Yes, just jump in.");
						this.vEntrance.DenyEntrance = false;
						yield break;
					}
					if (speech.Contains("i") && speech.Contains("leave"))
					{
						this.convNum = 2;
						yield return new WaitForSeconds(2);
						this.ReturnSpeech("Alright, go ahead.");
						this.vEntrance.DenyEntrance = false;
						yield break;
					}
				}
				if (speech.Contains("drive"))
				{
					this.convNum = 2;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Ok.");
					yield break;
				}
			}
			//===============================================================================
			if (this.convNum == 11)
			{
				//===============================================================================
				if (speech.Contains("yes"))
				{
					this.convNum = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("What is it?");
					yield break;
				}
				if (speech.Contains("no"))
				{
					this.convNum = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Wait, what?");
					yield break;
				}
				if ((speech.Contains("leave") && !speech.Contains("i")) || (speech.Contains("u") && speech.Contains("leave")))
				{
					this.convNum = 2;
					this.Ogle = 1;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Ok.");
					yield break;
				}
				if (this.HasSpace)
				{
					if (speech.Contains("ride") || speech.Contains("lift"))
					{
						this.convNum = 2;
						yield return new WaitForSeconds(2);
						this.ReturnSpeech("Well, jump out and get in!");
						this.vEntrance.DenyEntrance = false;
						yield break;
					}
					if (speech.Contains("i") && speech.Contains("leave"))
					{
						this.convNum = 2;
						yield return new WaitForSeconds(2);
						this.ReturnSpeech("Alright, go ahead.");
						this.vEntrance.DenyEntrance = false;
						yield break;
					}
				}
			}
			//===============================================================================
			if (this.convNum == 12)
			{
				//===============================================================================
				if (speech.Contains("yes"))
				{
					this.convNum = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("What is it?");
					yield break;
				}
				if (speech.Contains("no"))
				{
					this.convNum = 2;
					this.Ogle = 1;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Okey. Farewell.");
					yield break;
				}
				if ((speech.Contains("leave") && !speech.Contains("i")) || (speech.Contains("u") && speech.Contains("leave")))
				{
					this.convNum = 2;
					this.Ogle = 1;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Ok.");
					yield break;
				}
				if (this.HasSpace)
				{
					if (speech.Contains("ride") || speech.Contains("lift"))
					{
						this.convNum = 2;
						yield return new WaitForSeconds(2);
						this.ReturnSpeech("Yes, just jump in.");
						this.vEntrance.DenyEntrance = false;
						yield break;
					}
					if (speech.Contains("i") && speech.Contains("leave"))
					{
						this.convNum = 2;
						yield return new WaitForSeconds(2);
						this.ReturnSpeech("Alright, go ahead.");
						this.vEntrance.DenyEntrance = false;
						yield break;
					}
				}
			}
			//===============================================================================
			if (this.convNum == 13)
			{
				//===============================================================================
				if (speech.Contains("yes"))
				{
					this.convNum = 4;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech(". . .");
					yield break;
				}
				if (speech.Contains("no"))
				{
					this.convNum = 3;
					yield return new WaitForSeconds(4);
					this.ReturnSpeech("What is wrong with you?");
					yield break;
				}
				if (this.HasSpace)
				{
					if (speech.Contains("in") || speech.Contains("on"))
					{
						this.convNum = 3;
						yield return new WaitForSeconds(2);
						this.ReturnSpeech("Do it, you fool!");
						this.vEntrance.DenyEntrance = false;
						yield break;
					}
					if (speech.Contains("ride") || speech.Contains("lift"))
					{
						this.convNum = 3;
						yield return new WaitForSeconds(2);
						this.ReturnSpeech("Just do it already!");
						this.vEntrance.DenyEntrance = false;
						yield break;
					}
				}
			}
			//===============================================================================
			if (this.convNum == 14)
			{
				//===============================================================================
				if (speech.Contains("yes"))
				{
					this.convNum = 4;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech(". . .");
					yield break;
				}
				if (speech.Contains("no"))
				{
					this.convNum = 4;
					this.Ogle = 2;
					yield return new WaitForSeconds(4);
					this.ReturnSpeech(". . .");
					yield break;
				}
				if (this.HasSpace)
				{
					if (speech.Contains("in") || speech.Contains("lift"))
					{
						this.convNum = 4;
						this.Ogle = 2;
						yield return new WaitForSeconds(2);
						this.ReturnSpeech("You already got your chance!");
						yield break;
					}
				}
				if (speech.Contains("ride") || speech.Contains("on"))
				{
					this.convNum = 4;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("I think I'll pass on that now.");
					yield break;
				}
				if (speech.Contains("stop"))
				{
					this.convNum = 4;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Go bug somebody else.");
					yield break;
				}
			}
			//===============================================================================
			if (this.convNum == 2)
			{
				//===============================================================================
				if (speech.Contains("yes"))
				{
					this.convNum = 13;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Ok, what is it?");
					yield break;
				}
				if (speech.Contains("no"))
				{
					this.convNum = 3;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Ok.");
					yield break;
				}
				if (speech.Contains("go"))
				{
					this.convNum = 3;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Yes, yes.");
					yield break;
				}
				if ((speech.Contains("leave") && !speech.Contains("i")) || (speech.Contains("u") && speech.Contains("leave")))
				{
					this.convNum = 3;
					this.Ogle = 1;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Ok.");
					yield break;
				}
				if (this.HasSpace)
				{
					if (speech.Contains("in") || speech.Contains("on"))
					{
						this.convNum = 3;
						yield return new WaitForSeconds(2);
						this.ReturnSpeech("I do not have all day.");
						yield break;
					}
					if (speech.Contains("ride") || speech.Contains("lift"))
					{
						this.convNum = 3;
						yield return new WaitForSeconds(2);
						this.ReturnSpeech("Ok, I do not have all day.");
						yield break;
					}
					if (speech.Contains("i") && speech.Contains("leave"))
					{
						this.convNum = 3;
						yield return new WaitForSeconds(2);
						this.ReturnSpeech("Alright, go ahead.");
						yield break;
					}
				}
				if (speech.Contains("drive"))
				{
					this.convNum = 3;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Yes, yes.");
					yield break;
				}
			}
			//===============================================================================
			if (this.convNum == 21)
			{
				//===============================================================================
				if (speech.Contains("hi"))
				{
					this.convNum = 4;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech(". . .");
					yield break;
				}
				if (speech.Contains("hello"))
				{
					this.convNum = 4;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech(". . .");
					yield break;
				}
				if (speech.Contains("in") || speech.Contains("on"))
				{
					this.convNum = 4;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Go bite a snorp!");
					yield break;
				}
				if (speech.Contains("ride") || speech.Contains("lift"))
				{
					this.convNum = 4;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("You know what? NO!");
					yield break;
				}
				if (speech.Contains("stop"))
				{
					this.convNum = 4;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Leave me alone now.");
					yield break;
				}
			}
			//===============================================================================
			if (this.convNum == 3)
			{
				//===============================================================================
				if ((speech.Contains("hi") || speech.Contains("hey")) || speech.Contains("yo"))
				{
					this.convNum = 14;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("State your business! \n I do not have all day.");
					yield break;
				}
				if (speech.Contains("hello") || speech.Contains("greet"))
				{
					this.convNum = 14;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Just state what you want already!");
					yield break;
				}
				if (speech.Contains("in") || speech.Contains("on"))
				{
					this.convNum = 4;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("How about no.");
					yield break;
				}
				if (this.HasSpace)
				{
					if (speech.Contains("ride") || speech.Contains("lift"))
					{
						this.convNum = 4;
						this.Ogle = 2;
						yield return new WaitForSeconds(2);
						this.ReturnSpeech("Pick another ride. \n You already got one chance.");
						yield break;
					}
				}
				if (speech.Contains("stop"))
				{
					this.convNum = 21;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Get on with it then!");
					yield break;
				}
				this.convNum = 4;
				this.boredom = 4;
				this.Ogle = 2;
				yield return new WaitForSeconds(2);
				this.ReturnSpeech("Goodbye!");
				yield break;
			}
		}
		//===============================================================================
		//======================================================================================================================================
		//======================================================================================================================================
		if (mode == 2)
		{
			if (this.convNum == 0)
			{
				//===============================================================================
				if ((speech.Contains("hi") || speech.Contains("hey")) || speech.Contains("yo"))
				{
					this.convNum = 1;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Woah!");
					yield break;
				}
				if (speech.Contains("hello") || speech.Contains("greet"))
				{
					this.convNum = 1;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Hello? \n You want something?");
					yield break;
				}
				if (speech.Contains("in") || speech.Contains("on"))
				{
					this.convNum = 1;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Wait, what?");
					yield break;
				}
				if (speech.Contains("ride") || speech.Contains("lift"))
				{
					this.convNum = 11;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Are you serious?");
					yield break;
				}
				if (speech.Contains("stop"))
				{
					this.convNum = 11;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Oh no. What now?");
					yield break;
				}
			}
			//===============================================================================
			if (this.convNum == 1)
			{
				//===============================================================================
				if (speech.Contains("yes"))
				{
					this.convNum = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Ok, What is it?");
					yield break;
				}
				if (speech.Contains("no"))
				{
					this.convNum = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Okey. Was there something else?");
					yield break;
				}
				if (speech.Contains("go"))
				{
					this.convNum = 2;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Well then.");
					yield break;
				}
				if ((speech.Contains("leave") && !speech.Contains("i")) || (speech.Contains("u") && speech.Contains("leave")))
				{
					this.convNum = 2;
					this.Ogle = 1;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Ok.");
					yield break;
				}
				if (this.HasSpace)
				{
					if (speech.Contains("ride") || speech.Contains("lift"))
					{
						this.convNum = 2;
						yield return new WaitForSeconds(2);
						this.ReturnSpeech("What, you want a ride?");
						yield break;
					}
					if (speech.Contains("i") && speech.Contains("leave"))
					{
						this.convNum = 2;
						yield return new WaitForSeconds(2);
						this.ReturnSpeech("Alright, go ahead.");
						this.vEntrance.DenyEntrance = false;
						yield break;
					}
				}
				if (speech.Contains("drive"))
				{
					this.convNum = 2;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Ok.");
					yield break;
				}
			}
			//===============================================================================
			if (this.convNum == 11)
			{
				//===============================================================================
				if (speech.Contains("yes"))
				{
					this.convNum = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Ok.");
					yield break;
				}
				if (speech.Contains("no"))
				{
					this.convNum = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Wait, what?");
					yield break;
				}
				if ((speech.Contains("leave") && !speech.Contains("i")) || (speech.Contains("u") && speech.Contains("leave")))
				{
					this.convNum = 2;
					this.Ogle = 1;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Ok.");
					yield break;
				}
				if (this.HasSpace)
				{
					if (speech.Contains("ride") || speech.Contains("lift"))
					{
						this.convNum = 2;
						yield return new WaitForSeconds(2);
						this.ReturnSpeech("Well, jump out and get in!");
						this.vEntrance.DenyEntrance = false;
						yield break;
					}
					if (speech.Contains("i") && speech.Contains("leave"))
					{
						this.convNum = 2;
						yield return new WaitForSeconds(2);
						this.ReturnSpeech("Alright, go ahead.");
						this.vEntrance.DenyEntrance = false;
						yield break;
					}
				}
			}
			//===============================================================================
			if (this.convNum == 12)
			{
				//===============================================================================
				if (speech.Contains("yes"))
				{
					this.convNum = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("What is it?");
					yield break;
				}
				if (speech.Contains("no"))
				{
					this.convNum = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Okey. Was there something else?");
					yield break;
				}
				if ((speech.Contains("leave") && !speech.Contains("i")) || (speech.Contains("u") && speech.Contains("leave")))
				{
					this.convNum = 2;
					this.Ogle = 1;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Ok.");
					yield break;
				}
				if (this.HasSpace)
				{
					if (speech.Contains("ride") || speech.Contains("lift"))
					{
						this.convNum = 2;
						yield return new WaitForSeconds(2);
						this.ReturnSpeech("Yes, just jump in.");
						this.vEntrance.DenyEntrance = false;
						yield break;
					}
					if (speech.Contains("i") && speech.Contains("leave"))
					{
						this.convNum = 2;
						yield return new WaitForSeconds(2);
						this.ReturnSpeech("Alright, go ahead.");
						this.vEntrance.DenyEntrance = false;
						yield break;
					}
				}
			}
			//===============================================================================
			if (this.convNum == 13)
			{
				//===============================================================================
				if (speech.Contains("yes"))
				{
					this.convNum = 4;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech(". . .");
					yield break;
				}
				if (speech.Contains("no"))
				{
					this.convNum = 3;
					yield return new WaitForSeconds(4);
					this.ReturnSpeech("What is wrong with you?");
					yield break;
				}
				if (speech.Contains("in") || speech.Contains("on"))
				{
					this.convNum = 3;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Stop!");
					yield break;
				}
				if (speech.Contains("ride") || speech.Contains("lift"))
				{
					this.convNum = 3;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("I think I need to go.");
					yield break;
				}
			}
			//===============================================================================
			if (this.convNum == 14)
			{
				//===============================================================================
				if (speech.Contains("yes"))
				{
					this.convNum = 4;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech(". . .");
					yield break;
				}
				if (speech.Contains("no"))
				{
					this.convNum = 4;
					this.Ogle = 2;
					yield return new WaitForSeconds(4);
					this.ReturnSpeech(". . .");
					yield break;
				}
				if (speech.Contains("in") || speech.Contains("lift"))
				{
					this.convNum = 4;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("I think I'll pass. \n Good luck out there.");
					yield break;
				}
				if (speech.Contains("ride") || speech.Contains("on"))
				{
					this.convNum = 4;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("I think I'll pass on that now.");
					yield break;
				}
				if (speech.Contains("stop"))
				{
					this.convNum = 4;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Go bug somebody else.");
					yield break;
				}
			}
			//===============================================================================
			if (this.convNum == 2)
			{
				//===============================================================================
				if (speech.Contains("yes"))
				{
					this.convNum = 13;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Ok, what is it?");
					yield break;
				}
				if (speech.Contains("no"))
				{
					this.convNum = 3;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Ok.");
					yield break;
				}
				if (speech.Contains("in") || speech.Contains("on"))
				{
					this.convNum = 3;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("I do not have all day.");
					this.vEntrance.DenyEntrance = false;
					yield break;
				}
				if (speech.Contains("ride") || speech.Contains("lift"))
				{
					this.convNum = 3;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Ok, I do not have all day.");
					this.vEntrance.DenyEntrance = false;
					yield break;
				}
				if (speech.Contains("go"))
				{
					this.convNum = 3;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Yes, yes.");
					yield break;
				}
				if (speech.Contains("drive"))
				{
					this.convNum = 3;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Yes, yes.");
					yield break;
				}
			}
			//===============================================================================
			if (this.convNum == 21)
			{
				//===============================================================================
				if (speech.Contains("hi"))
				{
					this.convNum = 4;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech(". . .");
					yield break;
				}
				if (speech.Contains("hello"))
				{
					this.convNum = 4;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech(". . .");
					yield break;
				}
				if (speech.Contains("in") || speech.Contains("on"))
				{
					this.convNum = 4;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Nevermind. . .");
					yield break;
				}
				if (speech.Contains("ride") || speech.Contains("lift"))
				{
					this.convNum = 4;
					this.Ogle = 1;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Well. . . \n Good luck out there!");
					yield break;
				}
				if (speech.Contains("stop"))
				{
					this.convNum = 4;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Go away. . .");
					yield break;
				}
			}
			//===============================================================================
			if (this.convNum == 3)
			{
				//===============================================================================
				if ((speech.Contains("hi") || speech.Contains("hey")) || speech.Contains("yo"))
				{
					this.convNum = 14;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("State your business! \n I do not have all day.");
					yield break;
				}
				if (speech.Contains("hello") || speech.Contains("greet"))
				{
					this.convNum = 14;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Just state what you want already!");
					yield break;
				}
				if (speech.Contains("in") || speech.Contains("on"))
				{
					this.convNum = 4;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("How about no.");
					yield break;
				}
				if (speech.Contains("ride") || speech.Contains("lift"))
				{
					this.convNum = 4;
					this.Ogle = 2;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Pick another ride!");
					yield break;
				}
				if (speech.Contains("stop"))
				{
					this.convNum = 21;
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Alright! \n Now get on with it!");
					yield break;
				}
				this.convNum = 4;
				this.boredom = 4;
				this.Ogle = 2;
				yield return new WaitForSeconds(2);
				this.ReturnSpeech("Goodbye!");
				yield break;
			}
		}
		//===============================================================================
		if (this.convNum > 0)
		{
			if (this.boredom < 3)
			{
				if (((speech.Contains("bye") || speech.Contains("see")) || speech.Contains("fare")) || speech.Contains("later"))
				{
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Goodbye.");
					this.Ogle = 2;
					yield break;
				}
				if ((speech.Contains("thank") || speech.Contains("good")) || speech.Contains("like"))
				{
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("I'll see you!");
					this.Ogle = 2;
					yield break;
				}
			}
			//===============================================================================
			if (speech.Contains("fuck you"))
			{
				this.convNum = 99;
				this.Ogle = 2;
				yield return new WaitForSeconds(2);
				this.ReturnSpeech("Well fuck you too!");
				yield break;
			}
			if (speech.Contains("fuck off"))
			{
				this.convNum = 99;
				this.Ogle = 2;
				yield return new WaitForSeconds(2);
				this.ReturnSpeech("Ok. . .");
				yield break;
			}
			if (speech.Contains("go away"))
			{
				this.convNum = 99;
				this.Ogle = 2;
				yield return new WaitForSeconds(2);
				this.ReturnSpeech("Well then. . .");
				yield break;
			}
		}
		else
		{
			//===============================================================================
			if (this.boredom < 3)
			{
				if (((speech.Contains("bye") || speech.Contains("see")) || speech.Contains("fare")) || speech.Contains("later"))
				{
					yield return new WaitForSeconds(2);
					this.ReturnSpeech("Ok?");
					this.Ogle = 2;
					yield break;
				}
			}
		}
		yield return new WaitForSeconds(2);
		if (this.boredom == 0)
		{
			this.ReturnSpeech("Oh?");
		}
		if (this.boredom == 1)
		{
			this.ReturnSpeech("What do you want?");
			this.convNum = 1;
		}
		if (this.boredom == 2)
		{
			this.ReturnSpeech("Just get to the point. \n I don't have all day");
			this.convNum = 1;
		}
		if (this.boredom == 3)
		{
			this.ReturnSpeech("Well, good luck out there.");
			this.convNum = 4;
			this.Ogle = 2;
		}
		if (this.boredom == 4)
		{
			this.ReturnSpeech("Just go away.");
			this.convNum = 4;
			this.Ogle = 2;
		}
		if (this.boredom == 5)
		{
			this.ReturnSpeech("I told you. Go away!");
			this.convNum = 4;
			this.Ogle = 2;
		}
		if (this.boredom == 6)
		{
			this.ReturnSpeech("Please go away.");
			this.convNum = 4;
			this.Ogle = 2;
		}
		if (this.boredom == 7)
		{
			this.ReturnSpeech("You're dead to me. . .");
			this.convNum = 5;
			//PissedAtTC1 = 4;
			this.Ogle = 2;
		}
		this.boredom = this.boredom + 1;
	}

	public virtual void ReturnSpeech(string yourText)
	{
		GameObject Load = ((GameObject)Resources.Load("Prefabs/TalkBubble", typeof(GameObject))) as GameObject;
		GameObject TGO = UnityEngine.Object.Instantiate(Load, this.thisTransform.position, Load.transform.rotation);
		TGO.name = "CFC0";
		TalkBubbleScript.myText = yourText;
		((TalkBubbleScript)TGO.GetComponent(typeof(TalkBubbleScript))).source = this.thisVTransform;
	}

	public CivilianAI()
	{
		this.ThreatPerimiter = 50;
		this.RoadTightness = 0.1f;
		this.SceneTimer = 5;
		this.ObsStartY = 4;
		this.ObsStartZ = 0.1f;
		this.TurnEndSide = 2;
		this.TurnEndSideS = 2;
		this.RightDist = 200;
		this.LeftDist = 200;
		this.TurnVehicleTop = 2;
		this.TurnVehicleBot = -2;
		this.UpDist = 200;
		this.DownDist = 200;
		this.UpDist2 = 200;
		this.DownDist2 = 200;
		this.TopSpeed = 100;
		this.StatTopSpeed = 100;
		this.BrakeForce = 30;
		this.SlowDownForce = 30;
		this.TurnForce = 60;
		this.TurnSpeed = 0.5f;
		this.DirForce = 10;
		this.TurnStabMod = 100;
		this.RayVelMod = 1;
		this.AimSpeed = 33;
		this.IncThreshold = 1.5f;
		this.DropTolerance = 20;
		this.StopDist = 10;
		this.UnstickTime = 5;
		this.Dist = 8;
		this.MissionDist = 8;
		this.TForce = 6;
	}

}