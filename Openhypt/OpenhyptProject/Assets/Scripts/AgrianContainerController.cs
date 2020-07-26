using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AgrianContainerController : MonoBehaviour
{
    public bool isBulkContainer;
    public bool HasGarage;
    public Transform GaragePoint;
    public GameObject GarageLight;
    public AgrianTowerAI CarrierAI;
    public Rigidbody Cbody1;
    public Rigidbody Cbody2;
    public Rigidbody CbodyNull;
    public GameObject Marker;
    public Transform Node1;
    public Transform Node2;
    public Transform Magnet1;
    public Transform Magnet2;
    public bool Detach;
    public bool Attached;
    public float MagnetForce;
    public int AmountOfStuff;
    public bool GateBool;
    public bool Opening;
    public bool Closing;
    public bool RampOpening;
    public bool RampClosing;
    public ConfigurableJoint gateDirJoint;
    public HingeJoint gateAngJoint;
    public ConfigurableJoint rampDirJoint;
    public HingeJoint rampAngJoint;
    public AudioSource GateMoveSFX;
    public bool GateMoveSFXEnd;
    public AudioSource RampMoveSFX;
    public bool RampMoveSFXEnd;
    public AudioSource RampTurnSFX;
    public bool RampTurnSFXEnd;
    public AudioSource GateShockSFX;
    public bool GateShockedSFX;
    public AudioSource RampShockSFX;
    public bool RampShockedSFX;
    public AudioSource GateStopSFX;
    public bool GateStoppedSFX;
    public LayerMask targetLayers;
    public virtual void Start()
    {
        this.InvokeRepeating("Reader", 1, 0.5f);
        if (this.HasGarage)
        {
            if (this.CarrierAI.isFleetVessel1)
            {
                if (PlayerPrefs.HasKey("GaragedIDF1"))
                {
                    float Dist1 = PlayerPrefs.GetFloat("GaragedDistF1");
                    string ID1 = PlayerPrefs.GetString("GaragedIDF1");
                    GameObject Prefabionaise1 = ((GameObject) Resources.Load("VesselPrefabs/" + ID1, typeof(GameObject))) as GameObject;
                    GameObject TheThing1 = UnityEngine.Object.Instantiate(Prefabionaise1, this.GaragePoint.position, this.GaragePoint.rotation);

                    {
                        float _542 = TheThing1.transform.position.y + Dist1;
                        Vector3 _543 = TheThing1.transform.position;
                        _543.y = _542;
                        TheThing1.transform.position = _543;
                    }
                    if (ID1 != "Vessel74")
                    {
                        ((VehicleSensor) TheThing1.transform.GetComponent(typeof(VehicleSensor))).Vessel.name = "GaragedVesselF1";
                    }
                    ((VehicleSensor) TheThing1.transform.GetComponent(typeof(VehicleSensor))).Garaged = true;
                    ((VehicleSensor) TheThing1.transform.GetComponent(typeof(VehicleSensor))).Garage = this.gameObject.transform;
                }
                this.GaragePoint.name = "GaragePointF1";
            }
            if (this.CarrierAI.isFleetVessel2)
            {
                if (PlayerPrefs.HasKey("GaragedIDF2"))
                {
                    float Dist2 = PlayerPrefs.GetFloat("GaragedDistF2");
                    string ID2 = PlayerPrefs.GetString("GaragedIDF2");
                    GameObject Prefabionaise2 = ((GameObject) Resources.Load("VesselPrefabs/" + ID2, typeof(GameObject))) as GameObject;
                    GameObject TheThing2 = UnityEngine.Object.Instantiate(Prefabionaise2, this.GaragePoint.position, this.GaragePoint.rotation);

                    {
                        float _544 = TheThing2.transform.position.y + Dist2;
                        Vector3 _545 = TheThing2.transform.position;
                        _545.y = _544;
                        TheThing2.transform.position = _545;
                    }
                    if (ID2 != "Vessel74")
                    {
                        ((VehicleSensor) TheThing2.transform.GetComponent(typeof(VehicleSensor))).Vessel.name = "GaragedVesselF2";
                    }
                    ((VehicleSensor) TheThing2.transform.GetComponent(typeof(VehicleSensor))).Garaged = true;
                    ((VehicleSensor) TheThing2.transform.GetComponent(typeof(VehicleSensor))).Garage = this.gameObject.transform;
                }
                this.GaragePoint.name = "GaragePointF2";
            }
        }
    }

    public virtual void Reader()
    {
        this.GetComponent<Rigidbody>().centerOfMass = new Vector3(0, 0, 0);
        if (this.isBulkContainer)
        {
            if (!this.Marker.name.Contains("nerOFull"))
            {
                if (this.AmountOfStuff > 200)
                {
                    this.Marker.name = "ContainerFull";
                }
            }
            if (!this.Marker.name.Contains("nerOEmpty"))
            {
                if (this.AmountOfStuff == 0)
                {
                    this.Marker.name = "ContainerEmpty";
                }
            }
        }
        if (this.HasGarage)
        {
            if (this.CarrierAI.isFleetVessel1)
            {
                WorldInformation.GarageF1 = this.GaragePoint;
                if (WorldInformation.InGarageF1)
                {
                    this.GarageLight.SetActive(true);
                }
                if (!WorldInformation.InGarageF1)
                {
                    this.GarageLight.SetActive(false);
                }
            }
            if (this.CarrierAI.isFleetVessel2)
            {
                WorldInformation.GarageF2 = this.GaragePoint;
                if (WorldInformation.InGarageF2)
                {
                    this.GarageLight.SetActive(true);
                }
                if (!WorldInformation.InGarageF2)
                {
                    this.GarageLight.SetActive(false);
                }
            }
        }
    }

    public virtual void FixedUpdate()
    {
        RaycastHit hit = default(RaycastHit);
        if (this.GateBool)
        {
            if (!this.Opening && !this.Closing)
            {
                this.GateBool = false;
                this.GateStoppedSFX = false;
                this.GateShockedSFX = false;
                this.RampShockedSFX = false;
                this.GateMoveSFXEnd = false;
                this.RampMoveSFXEnd = false;
                this.RampTurnSFXEnd = false;
                this.GateMoveSFX.Stop();
                this.RampMoveSFX.Stop();
                this.RampTurnSFX.Stop();
                this.GateMoveSFX.volume = 1;
                this.RampMoveSFX.volume = 1;
                this.RampTurnSFX.volume = 1;
                if (this.gateDirJoint.targetPosition.z < 0.2f)
                {
                    this.Opening = true;
                    this.Closing = false;
                }
                else
                {
                    this.Closing = true;
                    this.Opening = false;
                    this.RampClosing = true;
                    this.RampOpening = false;
                }
            }
        }
        if (this.Opening)
        {
            if (this.gateAngJoint.spring.targetPosition < 90)
            {
                if (this.gateDirJoint.targetPosition.z < 14)
                {

                    {
                        float _546 = this.gateDirJoint.targetPosition.z + 0.05f;
                        Vector3 _547 = this.gateDirJoint.targetPosition;
                        _547.z = _546;
                        this.gateDirJoint.targetPosition = _547;
                    }
                    if (!this.GateMoveSFX.isPlaying)
                    {
                        this.GateMoveSFX.Play();
                    }
                }
                else
                {

                    {
                        float _548 = this.gateAngJoint.spring.targetPosition + 0.1f;
                        JointSpring _549 = this.gateAngJoint.spring;
                        _549.targetPosition = _548;
                        this.gateAngJoint.spring = _549;
                    }
                    this.RampOpening = true;
                    if (!this.RampMoveSFX.isPlaying)
                    {
                        this.RampMoveSFX.Play();
                    }
                    if (!this.GateShockedSFX)
                    {
                        this.GateShockSFX.Play();
                        this.GateShockedSFX = true;
                    }
                }
            }
            else
            {

                {
                    int _550 = 90;
                    JointSpring _551 = this.gateAngJoint.spring;
                    _551.targetPosition = _550;
                    this.gateAngJoint.spring = _551;
                }

                {
                    int _552 = 14;
                    Vector3 _553 = this.gateDirJoint.targetPosition;
                    _553.z = _552;
                    this.gateDirJoint.targetPosition = _553;
                }
                if (!this.GateStoppedSFX)
                {
                    this.GateStopSFX.Play();
                    this.GateStoppedSFX = true;
                }
                this.GateMoveSFXEnd = true;
                this.Opening = false;
            }
        }
        if (this.RampOpening)
        {
            if (this.rampAngJoint.spring.targetPosition < 20)
            {
                if (this.rampDirJoint.targetPosition.z < 89)
                {

                    {
                        float _554 = this.rampDirJoint.targetPosition.z + 0.15f;
                        Vector3 _555 = this.rampDirJoint.targetPosition;
                        _555.z = _554;
                        this.rampDirJoint.targetPosition = _555;
                    }
                }
                else
                {

                    {
                        float _556 = this.rampAngJoint.spring.targetPosition + 0.1f;
                        JointSpring _557 = this.rampAngJoint.spring;
                        _557.targetPosition = _556;
                        this.rampAngJoint.spring = _557;
                    }
                    if (!this.RampTurnSFX.isPlaying)
                    {
                        this.RampTurnSFX.Play();
                    }
                    this.RampMoveSFXEnd = true;
                }
            }
            else
            {

                {
                    int _558 = 20;
                    JointSpring _559 = this.rampAngJoint.spring;
                    _559.targetPosition = _558;
                    this.rampAngJoint.spring = _559;
                }

                {
                    int _560 = 89;
                    Vector3 _561 = this.rampDirJoint.targetPosition;
                    _561.z = _560;
                    this.rampDirJoint.targetPosition = _561;
                }
                if (!this.RampShockedSFX)
                {
                    this.RampShockSFX.Play();
                    this.RampShockedSFX = true;
                }
                this.RampTurnSFXEnd = true;
                this.RampOpening = false;
            }
        }
        if (this.Closing)
        {
            if (this.gateDirJoint.targetPosition.z > 0.1f)
            {
                if (this.gateAngJoint.spring.targetPosition > 0.2f)
                {

                    {
                        float _562 = this.gateAngJoint.spring.targetPosition - 0.1f;
                        JointSpring _563 = this.gateAngJoint.spring;
                        _563.targetPosition = _562;
                        this.gateAngJoint.spring = _563;
                    }
                    if (!this.GateMoveSFX.isPlaying)
                    {
                        this.GateMoveSFX.Play();
                    }
                }
                else
                {

                    {
                        int _564 = 0;
                        JointSpring _565 = this.gateAngJoint.spring;
                        _565.targetPosition = _564;
                        this.gateAngJoint.spring = _565;
                    }

                    {
                        float _566 = this.gateDirJoint.targetPosition.z - 0.05f;
                        Vector3 _567 = this.gateDirJoint.targetPosition;
                        _567.z = _566;
                        this.gateDirJoint.targetPosition = _567;
                    }
                    if (!this.GateShockedSFX)
                    {
                        this.GateShockSFX.Play();
                        this.GateShockedSFX = true;
                    }
                }
            }
            else
            {

                {
                    int _568 = 0;
                    JointSpring _569 = this.gateAngJoint.spring;
                    _569.targetPosition = _568;
                    this.gateAngJoint.spring = _569;
                }

                {
                    int _570 = 0;
                    Vector3 _571 = this.gateDirJoint.targetPosition;
                    _571.z = _570;
                    this.gateDirJoint.targetPosition = _571;
                }
                if (!this.GateStoppedSFX)
                {
                    this.GateStopSFX.Play();
                    this.GateStoppedSFX = true;
                }
                this.GateMoveSFXEnd = true;
                this.Closing = false;
                this.StartCoroutine(this.LockFunction());
            }
        }
        if (this.RampClosing)
        {
            if (this.rampDirJoint.targetPosition.z > 0.1f)
            {
                if (this.rampAngJoint.spring.targetPosition > 0.2f)
                {

                    {
                        float _572 = this.rampAngJoint.spring.targetPosition - 0.1f;
                        JointSpring _573 = this.rampAngJoint.spring;
                        _573.targetPosition = _572;
                        this.rampAngJoint.spring = _573;
                    }
                    if (!this.RampTurnSFX.isPlaying)
                    {
                        this.RampTurnSFX.Play();
                    }
                }
                else
                {

                    {
                        int _574 = 0;
                        JointSpring _575 = this.rampAngJoint.spring;
                        _575.targetPosition = _574;
                        this.rampAngJoint.spring = _575;
                    }

                    {
                        float _576 = this.rampDirJoint.targetPosition.z - 0.15f;
                        Vector3 _577 = this.rampDirJoint.targetPosition;
                        _577.z = _576;
                        this.rampDirJoint.targetPosition = _577;
                    }
                    if (!this.RampMoveSFX.isPlaying)
                    {
                        this.RampMoveSFX.Play();
                        this.RampShockSFX.Play();
                    }
                    this.RampTurnSFXEnd = true;
                }
            }
            else
            {

                {
                    int _578 = 0;
                    JointSpring _579 = this.rampAngJoint.spring;
                    _579.targetPosition = _578;
                    this.rampAngJoint.spring = _579;
                }

                {
                    int _580 = 0;
                    Vector3 _581 = this.rampDirJoint.targetPosition;
                    _581.z = _580;
                    this.rampDirJoint.targetPosition = _581;
                }
                this.RampClosing = false;
                if (!this.RampShockedSFX)
                {
                    this.RampShockSFX.Play();
                    this.RampShockedSFX = true;
                }
                this.RampMoveSFXEnd = true;
                this.StartCoroutine(this.RampLockFunction());
            }
        }
        if (this.GateMoveSFXEnd)
        {
            this.GateMoveSFX.volume = this.GateMoveSFX.volume - 0.025f;
            if (this.GateMoveSFX.volume == 0)
            {
                this.GateMoveSFX.Stop();
                this.GateMoveSFXEnd = false;
            }
        }
        if (this.RampMoveSFXEnd)
        {
            this.RampMoveSFX.volume = this.RampMoveSFX.volume - 0.025f;
            if (this.RampMoveSFX.volume == 0)
            {
                this.RampMoveSFX.Stop();
                this.RampMoveSFXEnd = false;
            }
        }
        if (this.RampTurnSFXEnd)
        {
            this.RampTurnSFX.volume = this.RampTurnSFX.volume - 0.025f;
            if (this.RampTurnSFX.volume == 0)
            {
                this.RampTurnSFX.Stop();
                this.RampTurnSFXEnd = false;
            }
        }
        if (this.Cbody1 == null)
        {
            Debug.DrawRay(this.transform.position + (this.transform.forward * 55), this.transform.forward * 20f, Color.red);
            if (Physics.Raycast(this.transform.position + (this.transform.forward * 55), this.transform.forward, out hit, 20, (int) this.targetLayers))
            {
                if (hit.collider.name.Contains("TC2HullA"))
                {
                    this.Cbody1 = hit.collider.gameObject.GetComponent<Rigidbody>();
                }
            }
        }
        if (this.Detach)
        {
            if (this.Node1)
            {
                this.Node1.gameObject.GetComponent<AgrianContainerArea>().Vacant = true;
            }
            this.GetComponent<Rigidbody>().drag = 1;
            this.Attached = false;
            this.Detach = false;
            ((FixedJoint) this.gameObject.GetComponent(typeof(FixedJoint))).connectedBody = this.CbodyNull;
        }
        if (this.Node1)
        {
            if (!this.Attached)
            {
                this.GetComponent<Rigidbody>().AddForce((this.Node1.transform.position - this.Magnet1.transform.position).normalized * this.MagnetForce);
                if (Vector3.Distance(this.Magnet1.transform.position, this.Node1.transform.position) < 0.1f)
                {
                    this.Attached = true;
                    this.Node1.gameObject.GetComponent<AgrianContainerArea>().Occupied = true;
                    ((FixedJoint) this.gameObject.GetComponent(typeof(FixedJoint))).connectedBody = this.Cbody2;
                    this.GetComponent<Rigidbody>().drag = 0.05f;
                }
            }
        }
        if (this.Node2)
        {
            if (!this.Attached)
            {
                this.GetComponent<Rigidbody>().AddForce((this.Node2.transform.position - this.Magnet2.transform.position).normalized * this.MagnetForce);
                if (Vector3.Distance(this.Magnet2.transform.position, this.Node2.transform.position) < 0.2f)
                {
                    this.Attached = true;
                    ((FixedJoint) this.gameObject.GetComponent(typeof(FixedJoint))).connectedBody = this.Cbody1;
                    this.GetComponent<Rigidbody>().drag = 0.05f;
                }
            }
        }
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("AgrianM"))
        {
            this.Cbody2 = collision.rigidbody;
        }
    }

    public virtual void Open()
    {
        if (this.Opening || this.Closing)
        {
            return;
        }
        this.GateStoppedSFX = false;
        this.GateShockedSFX = false;
        this.RampShockedSFX = false;
        this.GateMoveSFXEnd = false;
        this.RampMoveSFXEnd = false;
        this.RampTurnSFXEnd = false;
        this.GateMoveSFX.Stop();
        this.RampMoveSFX.Stop();
        this.RampTurnSFX.Stop();
        this.GateMoveSFX.volume = 1;
        this.RampMoveSFX.volume = 1;
        this.RampTurnSFX.volume = 1;
        if (this.gateDirJoint.targetPosition.z < 0.2f)
        {
            this.Opening = true;
            this.Closing = false;
        }
    }

    public virtual void Close()
    {
        if (this.Opening || this.Closing)
        {
            return;
        }
        this.GateStoppedSFX = false;
        this.GateShockedSFX = false;
        this.RampShockedSFX = false;
        this.GateMoveSFXEnd = false;
        this.RampMoveSFXEnd = false;
        this.RampTurnSFXEnd = false;
        this.GateMoveSFX.Stop();
        this.RampMoveSFX.Stop();
        this.RampTurnSFX.Stop();
        this.GateMoveSFX.volume = 1;
        this.RampMoveSFX.volume = 1;
        this.RampTurnSFX.volume = 1;
        if (this.gateDirJoint.targetPosition.z > 0.2f)
        {
            this.Closing = true;
            this.Opening = false;
            this.RampClosing = true;
            this.RampOpening = false;
        }
    }

    public virtual IEnumerator LockFunction()
    {
        yield return new WaitForSeconds(0.2f);

        {
            int _582 = -1;
            JointSpring _583 = this.gateAngJoint.spring;
            _583.targetPosition = _582;
            this.gateAngJoint.spring = _583;
        }

        {
            float _584 = 0.01f;
            Vector3 _585 = this.gateDirJoint.targetPosition;
            _585.z = _584;
            this.gateDirJoint.targetPosition = _585;
        }
        yield return new WaitForSeconds(0.2f);

        {
            int _586 = 0;
            JointSpring _587 = this.gateAngJoint.spring;
            _587.targetPosition = _586;
            this.gateAngJoint.spring = _587;
        }

        {
            int _588 = 0;
            Vector3 _589 = this.gateDirJoint.targetPosition;
            _589.z = _588;
            this.gateDirJoint.targetPosition = _589;
        }
    }

    public virtual IEnumerator RampLockFunction()
    {
        yield return new WaitForSeconds(0.1f);

        {
            float _590 = 0.01f;
            JointSpring _591 = this.rampAngJoint.spring;
            _591.targetPosition = _590;
            this.rampAngJoint.spring = _591;
        }

        {
            float _592 = 0.01f;
            Vector3 _593 = this.rampDirJoint.targetPosition;
            _593.z = _592;
            this.rampDirJoint.targetPosition = _593;
        }
        yield return new WaitForSeconds(0.1f);

        {
            int _594 = 0;
            JointSpring _595 = this.rampAngJoint.spring;
            _595.targetPosition = _594;
            this.rampAngJoint.spring = _595;
        }

        {
            int _596 = 0;
            Vector3 _597 = this.rampDirJoint.targetPosition;
            _597.z = _596;
            this.rampDirJoint.targetPosition = _597;
        }
    }

    public AgrianContainerController()
    {
        this.MagnetForce = 10f;
    }

}