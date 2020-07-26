using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class RadarDroneAI : MonoBehaviour
{
    public Transform target;
    public GameObject Waypoint;
    public Transform Home;
    public Transform Detect;
    public Transform thisTransform;
    public Transform thisVTransform;
    public Rigidbody vRigidbody;
    public Transform AIAnchor;
    public GameObject Vessel;
    public CapsuleCollider Trig;
    public GameObject Presence;
    public GameObject Wing;
    public AudioSource Sounds;
    public AudioSource Beep;
    public bool Obscurity;
    public bool Damaged;
    public bool IsActive;
    public bool Obstacle;
    public bool TurnRight;
    public bool TurnLeft;
    public bool HomeIsMoving;
    public bool SkipTC0;
    public bool SkipTC2;
    public bool SkipTC4;
    public bool SkipTC5;
    public bool SkipTC6;
    public bool SkipTC7;
    public bool SkipTiny;
    public bool SkipSmall;
    public bool SkipMedium;
    public bool SkipBig;
    public bool SkipHuge;
    public LayerMask targetLayers;
    public float GyroForce;
    public float TurnForce;
    public float Force;
    public float ManeuvForce;
    public float DetDist;
    public int TrigDir;
    public virtual IEnumerator Start()
    {
        this.InvokeRepeating("Regenerator", 0.7f, 1);
        this.Force = 0.1f;
        yield return new WaitForSeconds(2);
        this.ReturnSpeech("Hello, my new user. \n State my name to order me something.");
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        if (this.Vessel == null)
        {
            UnityEngine.Object.Destroy(this.Waypoint);
            UnityEngine.Object.Destroy(this.gameObject);
        }
        if (this.Damaged)
        {
            this.Sounds.volume = 0;
            this.vRigidbody.drag = 0.1f;
            this.vRigidbody.angularDrag = 0.1f;
            UnityEngine.Object.Destroy(this.Presence);
            UnityEngine.Object.Destroy(this.Waypoint);
            UnityEngine.Object.Destroy(this.gameObject);
        }
        if (this.Damaged)
        {
            return;
        }
        if (!this.IsActive || (this.Vessel == null))
        {
            return;
        }
        this.thisTransform.rotation = this.AIAnchor.transform.rotation;
        this.thisTransform.position = this.AIAnchor.transform.position;
        if (this.target == null)
        {
            this.Trig.center = new Vector3(0, 0, 20);
            this.Trig.radius = 10;
            this.Trig.height = 60;
        }
        if (this.TurnLeft)
        {
            this.TurnForce = -0.005f;
        }
        if (this.TurnRight)
        {
            this.TurnForce = 0.005f;
        }
        if (!this.TurnRight && !this.TurnLeft)
        {
            this.TurnForce = 0;
        }
        if (this.TurnRight && this.TurnLeft)
        {
            this.TurnForce = 0;
        }
        Vector3 newRot = (this.thisTransform.forward * 0.6f).normalized;
        newRot = ((this.thisTransform.forward * 0.6f) + (this.thisTransform.right * 0.4f)).normalized;
        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 1), newRot * 10f, Color.black);
        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 1), newRot, 10, (int) this.targetLayers))
        {
            this.TurnLeft = true;
        }
        else
        {
            this.TurnLeft = false;
        }
        newRot = ((this.thisTransform.forward * 0.6f) + (this.thisTransform.right * -0.4f)).normalized;
        Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 1), newRot * 10f, Color.black);
        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 1), newRot, 10, (int) this.targetLayers))
        {
            this.TurnRight = true;
        }
        else
        {
            this.TurnRight = false;
        }
        if (this.vRigidbody.velocity.magnitude > 10)
        {
            Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 1), this.thisTransform.forward * 20f, Color.black);
            if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 1), this.thisTransform.forward, 20, (int) this.targetLayers))
            {
                this.Obstacle = true;
            }
            else
            {
                this.Obstacle = false;
            }
        }
        else
        {
            Debug.DrawRay(this.thisTransform.position + (this.thisTransform.forward * 1), this.thisTransform.forward * 10f, Color.black);
            if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 1), this.thisTransform.forward, 10, (int) this.targetLayers))
            {
                this.Obstacle = true;
            }
            else
            {
                this.Obstacle = false;
            }
        }
        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 1), this.thisTransform.forward, out hit, 12) && hit.collider.tag.Contains("Te"))
        {
            this.Obscurity = true;
            this.target = null;
        }
        else
        {
            this.Obscurity = false;
        }
        //========================================================================================================================//
        //////////////////////////////////////////////////////[INTERACTION]/////////////////////////////////////////////////////////
        //========================================================================================================================//
        if (NotiScript.PiriNotis)
        {
            if (Vector3.Distance(this.thisTransform.position, PlayerInformation.instance.Pirizuka.position) < 128)
            {
                this.target = PlayerInformation.instance.PiriTarget;
                NotiScript.PiriNotis = false;
            }
        }
        if (WorldInformation.pSpeech)
        {
            if (Vector3.Distance(this.thisTransform.position, WorldInformation.pSpeech.position) < 128)
            {
                this.StartCoroutine(this.ProcessSpeech(TalkBubbleScript.myText));
            }
            WorldInformation.pSpeech = null;
        }
    }

    public virtual void FixedUpdate()
    {
        RaycastHit hit = default(RaycastHit);
        if (this.Vessel)
        {
            if (!this.IsActive)
            {
                if (this.Sounds.volume > 0)
                {
                    this.Sounds.volume = this.Sounds.volume - 0.05f;
                }
            }
            if (this.IsActive)
            {
                if (this.Sounds.volume < 0.5f)
                {
                    this.Sounds.volume = this.Sounds.volume + 0.05f;
                }
            }
        }
        if (!this.IsActive || (this.Vessel == null))
        {
            return;
        }
        Vector3 localV = this.thisVTransform.InverseTransformDirection(this.vRigidbody.velocity);
        if (-localV.y > 2)
        {
            this.vRigidbody.AddTorque(this.thisTransform.up * this.TurnForce);
            if (Physics.Raycast(this.thisTransform.position, Vector3.down, 2, (int) this.targetLayers))
            {
                this.vRigidbody.AddForce(Vector3.up * 0.1f);
            }
        }
        else
        {
            if (Physics.Raycast(this.thisTransform.position, Vector3.down, 2, (int) this.targetLayers))
            {
                this.vRigidbody.AddForce(Vector3.up * 0.07f);
            }
        }
        if (this.ManeuvForce != 0)
        {
            this.vRigidbody.AddForce(this.thisTransform.up * this.ManeuvForce);
        }
        if (this.target)
        {
            this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * 0.01f, this.thisTransform.forward * 0.8f);
            this.vRigidbody.AddForceAtPosition((this.target.transform.position - this.thisVTransform.position).normalized * -0.01f, -this.thisTransform.forward * 0.8f);
        }
        this.vRigidbody.AddForceAtPosition(Vector3.up * this.GyroForce, this.thisTransform.up * 0.4f);
        this.vRigidbody.AddForceAtPosition(-Vector3.up * this.GyroForce, -this.thisTransform.up * 0.4f);
        if (Physics.Raycast(this.thisTransform.position + (this.thisTransform.forward * 1), this.thisTransform.forward, out hit, 5))
        {
            if (hit.collider.tag.Contains("Te"))
            {
                this.vRigidbody.AddForce(this.thisVTransform.forward * 0.1f);
            }
            if (hit.collider.tag.Contains("Str"))
            {
                this.vRigidbody.AddForce(this.thisVTransform.forward * 0.1f);
            }
        }
        if (this.Obstacle && (-localV.y > 1))
        {
            if (-localV.y > 10)
            {
                this.vRigidbody.AddForce(-this.thisVTransform.up * -0.8f);
            }
            else
            {
                this.vRigidbody.AddForce(-this.thisVTransform.up * -0.2f);
            }
        }
        if (!this.Obstacle)
        {
            this.vRigidbody.AddForce(-this.thisVTransform.up * this.Force);
        }
        if (this.Obscurity)
        {
            this.vRigidbody.AddForce(this.thisVTransform.forward * 0.1f);
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().name.Contains("TC1"))
        {
            if (!other.GetComponent<Collider>().name.Contains("TC1d"))
            {
                this.GetComponent<Rigidbody>().isKinematic = true;
                this.Home = other.gameObject.transform;
            }
        }
        else
        {
            if (other.GetComponent<Collider>().name.Contains("tTC") && this.SkipTiny)
            {
                return;
            }
            if (other.GetComponent<Collider>().name.Contains("sTC") && this.SkipSmall)
            {
                return;
            }
            if (other.GetComponent<Collider>().name.Contains("mTC") && this.SkipMedium)
            {
                return;
            }
            if (other.GetComponent<Collider>().name.Contains("bTC") && this.SkipBig)
            {
                return;
            }
            if (other.GetComponent<Collider>().name.Contains("xbTC") && this.SkipHuge)
            {
                return;
            }
            if (other.GetComponent<Collider>().name.Contains("TC0") && !this.SkipTC0)
            {
                if (Vector3.Distance(this.thisTransform.position, other.transform.position) < this.DetDist)
                {
                    this.Detect = other.gameObject.transform;
                }
            }
            if (other.GetComponent<Collider>().name.Contains("TC2") && !this.SkipTC2)
            {
                if (Vector3.Distance(this.thisTransform.position, other.transform.position) < this.DetDist)
                {
                    this.Detect = other.gameObject.transform;
                }
            }
            if (other.GetComponent<Collider>().name.Contains("TC5") && !this.SkipTC5)
            {
                if (Vector3.Distance(this.thisTransform.position, other.transform.position) < this.DetDist)
                {
                    this.Detect = other.gameObject.transform;
                }
            }
            if (other.GetComponent<Collider>().name.Contains("TC4") && !this.SkipTC4)
            {
                if (Vector3.Distance(this.thisTransform.position, other.transform.position) < this.DetDist)
                {
                    this.Detect = other.gameObject.transform;
                }
            }
            if (other.GetComponent<Collider>().name.Contains("TC6") && !this.SkipTC6)
            {
                if (Vector3.Distance(this.thisTransform.position, other.transform.position) < this.DetDist)
                {
                    this.Detect = other.gameObject.transform;
                }
            }
            if (other.GetComponent<Collider>().name.Contains("TC7") && !this.SkipTC7)
            {
                if (Vector3.Distance(this.thisTransform.position, other.transform.position) < this.DetDist)
                {
                    this.Detect = other.gameObject.transform;
                }
            }
            if (other.GetComponent<Collider>().name.Contains("TC8"))
            {
                if (Vector3.Distance(this.thisTransform.position, other.transform.position) < this.DetDist)
                {
                    this.Detect = other.gameObject.transform;
                }
            }
            if (other.GetComponent<Collider>().name.Contains("TC9"))
            {
                if (Vector3.Distance(this.thisTransform.position, other.transform.position) < this.DetDist)
                {
                    this.Detect = other.gameObject.transform;
                }
            }
            this.Trig.center = new Vector3(0, 0, 20);
            this.Trig.radius = 10;
            this.Trig.height = 60;
        }
    }

    public virtual IEnumerator Unstick()
    {
        this.ManeuvForce = -0.2f;
        yield return new WaitForSeconds(0.5f);
        this.ManeuvForce = 0.2f;
        yield return new WaitForSeconds(0.5f);
        this.ManeuvForce = 0;
    }

    public virtual void Regenerator()
    {
        if (this.Damaged)
        {
            return;
        }
        if (this.Home)
        {
            this.IsActive = true;
            this.vRigidbody.drag = 0.4f;
            this.vRigidbody.angularDrag = 20;
            this.Wing.gameObject.SetActive(true);
            if (Vector3.Distance(this.thisTransform.position, this.Home.position) > 15)
            {
                this.target = this.Home;
            }
            else
            {
                if (this.Detect)
                {
                    if (!this.HomeIsMoving)
                    {
                        this.target = this.Detect;
                    }
                    else
                    {
                        this.target = this.Home;
                    }
                }
                else
                {
                    this.target = null;
                }
            }
            if (Vector3.Distance(this.thisTransform.position, this.Home.position) > 15)
            {
                this.Force = 0.1f;
            }
            else
            {
                this.Force = 0;
            }
            this.TrigDir = this.TrigDir + 1;
            if (this.TrigDir == 1)
            {
                this.Trig.center = new Vector3(0, 0, 2500);
                this.Trig.radius = 2500;
                this.Trig.height = 2500;
            }
            if (this.TrigDir == 2)
            {
                this.Trig.center = new Vector3(2500, 0, 0);
                this.Trig.radius = 2500;
                this.Trig.height = 2500;
            }
            if (this.TrigDir == 3)
            {
                this.Trig.center = new Vector3(0, 0, -2500);
                this.Trig.radius = 2500;
                this.Trig.height = 2500;
            }
            if (this.TrigDir == 4)
            {
                this.Trig.center = new Vector3(-2500, 0, 0);
                this.Trig.radius = 2500;
                this.Trig.height = 2500;
                this.TrigDir = 0;
            }
            this.ManeuvForce = 0;
            this.StartCoroutine(this.Blip());
            Vector3 lastPos = this.thisTransform.position;
            this.StartCoroutine(this.HomeMoving(lastPos));
        }
    }

    public virtual IEnumerator HomeMoving(Vector3 lastPos)
    {
        yield return new WaitForSeconds(0.5f);
        if (Vector3.Distance(this.transform.position, lastPos) > 1)
        {
            this.HomeIsMoving = true;
        }
        else
        {
            this.HomeIsMoving = false;
        }
    }

    public virtual IEnumerator Blip()
    {
        if (this.Detect == null)
        {
            this.DetDist = 5000;
        }
        else
        {
            this.DetDist = Vector3.Distance(this.transform.position, this.Detect.position);
            yield return new WaitForSeconds(0.25f);
            if (this.Detect != null)
            {
                float Dist = Vector3.Distance(this.transform.position, this.Detect.position);
            
                float p = 2000 / Dist;
                float q = p * 1;
                this.Beep.pitch = Mathf.Clamp(q, 1f, 3f);
                this.Beep.Play();
            }
        }
    }

    //========================================================================================================================//
    //////////////////////////////////////////////////////[INTERACTION]/////////////////////////////////////////////////////////
    //========================================================================================================================//
    public int convNum;
    public virtual IEnumerator ProcessSpeech(string speech)
    {
        yield return new WaitForSeconds(0.1f);
        if (!!string.IsNullOrEmpty(speech))
        {
            yield break;
        }
        if (this.convNum == 0)
        {
            //===============================================================================
            if (speech.Contains("radar") && speech.Contains("drone"))
            {
                this.convNum = 1;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Yes, my user. Say your command. \n You can say 'manual' for other commands.");
                yield break;
            }
        }
        //===============================================================================
        if (this.convNum == 1)
        {
            //===============================================================================
            if (speech.Contains("kip") || speech.Contains("gnore"))
            {
                yield return new WaitForSeconds(2);
                if ((((speech.Contains("reature") || speech.Contains("nimal")) || speech.Contains("ivilian")) || speech.Contains("eople")) || speech.Contains("c0"))
                {
                    this.ReturnSpeech("I am now ignoring civilians \n and other creatures.");
                    this.SkipTC0 = true;
                    this.target = null;
                    this.Detect = null;
                    this.convNum = 0;
                    yield break;
                }
                if (speech.Contains("grian") || speech.Contains("c2"))
                {
                    this.ReturnSpeech("I am now ignoring Agrians.");
                    this.convNum = 0;
                    this.SkipTC2 = true;
                    this.target = null;
                    this.Detect = null;
                    yield break;
                }
                if (speech.Contains("berrant") || speech.Contains("c4"))
                {
                    this.ReturnSpeech("I am now ignoring Aberrants.");
                    this.convNum = 0;
                    this.SkipTC4 = true;
                    this.target = null;
                    this.Detect = null;
                    yield break;
                }
                if (speech.Contains("lav") || speech.Contains("c5"))
                {
                    this.ReturnSpeech("I am now ignoring Slavuics.");
                    this.convNum = 0;
                    this.SkipTC5 = true;
                    this.target = null;
                    this.Detect = null;
                    yield break;
                }
                if ((speech.Contains("tiba") || speech.Contains("abia")) || speech.Contains("c6"))
                {
                    this.ReturnSpeech("I am now ignoring the Abia Syndicate.");
                    this.convNum = 0;
                    this.SkipTC6 = true;
                    this.target = null;
                    this.Detect = null;
                    yield break;
                }
                if (speech.Contains("evnav") || speech.Contains("c7"))
                {
                    this.ReturnSpeech("I am now ignoring MevNav.");
                    this.convNum = 0;
                    this.SkipTC7 = true;
                    this.target = null;
                    this.Detect = null;
                    yield break;
                }
                if ((speech.Contains("iny") || speech.Contains("tt")) || speech.Contains("tT"))
                {
                    this.ReturnSpeech("I am now ignoring tiny targets.");
                    this.convNum = 0;
                    this.SkipTiny = true;
                    this.target = null;
                    this.Detect = null;
                    yield break;
                }
                if ((speech.Contains("mall") || speech.Contains("st")) || speech.Contains("sT"))
                {
                    this.ReturnSpeech("I am now ignoring small targets.");
                    this.convNum = 0;
                    this.SkipSmall = true;
                    this.target = null;
                    this.Detect = null;
                    yield break;
                }
                if ((speech.Contains("edium") || speech.Contains("mt")) || speech.Contains("mT"))
                {
                    this.ReturnSpeech("I am now ignoring medium targets.");
                    this.convNum = 0;
                    this.SkipMedium = true;
                    this.target = null;
                    this.Detect = null;
                    yield break;
                }
                if ((speech.Contains("ig") || speech.Contains("bt")) || speech.Contains("bT"))
                {
                    this.ReturnSpeech("I am now ignoring big targets.");
                    this.convNum = 0;
                    this.SkipBig = true;
                    this.target = null;
                    this.Detect = null;
                    yield break;
                }
                if ((speech.Contains("uge") || speech.Contains("xbt")) || speech.Contains("xbT"))
                {
                    this.ReturnSpeech("I am now ignoring huge targets.");
                    this.convNum = 0;
                    this.SkipHuge = true;
                    this.target = null;
                    this.Detect = null;
                    yield break;
                }
                this.ReturnSpeech("I can not process your request. \n Try another word.");
                this.convNum = 1;
                yield break;
            }
            if (((speech.Contains("pot") || speech.Contains("ook")) || speech.Contains("earch")) || speech.Contains("ind"))
            {
                yield return new WaitForSeconds(2);
                if ((((speech.Contains("reature") || speech.Contains("nimal")) || speech.Contains("ivilian")) || speech.Contains("eople")) || speech.Contains("c0"))
                {
                    this.ReturnSpeech("I am now searching for civilians \n and other creatures.");
                    this.convNum = 0;
                    this.SkipTC0 = false;
                    yield break;
                }
                if (speech.Contains("grian") || speech.Contains("c2"))
                {
                    this.ReturnSpeech("I am now searching for Agrians.");
                    this.convNum = 0;
                    this.SkipTC2 = false;
                    yield break;
                }
                if (speech.Contains("berrant") || speech.Contains("c4"))
                {
                    this.ReturnSpeech("I am now searching for Aberrants.");
                    this.convNum = 0;
                    this.SkipTC4 = false;
                    yield break;
                }
                if (speech.Contains("lav") || speech.Contains("tc5"))
                {
                    this.ReturnSpeech("I am now searching for Slavuics.");
                    this.convNum = 0;
                    this.SkipTC5 = false;
                    yield break;
                }
                if ((speech.Contains("tiba") || speech.Contains("abia")) || speech.Contains("c6"))
                {
                    this.ReturnSpeech("I am now searching for the Abia Syndicate.");
                    this.convNum = 0;
                    this.SkipTC6 = false;
                    yield break;
                }
                if (speech.Contains("evnav") || speech.Contains("c7"))
                {
                    this.ReturnSpeech("I am now searching for MevNav.");
                    this.convNum = 0;
                    this.SkipTC7 = false;
                    yield break;
                }
                if ((speech.Contains("iny") || speech.Contains("tt")) || speech.Contains("tT"))
                {
                    this.ReturnSpeech("I am now searching for tiny targets.");
                    this.convNum = 0;
                    this.SkipTiny = false;
                    yield break;
                }
                if ((speech.Contains("mall") || speech.Contains("st")) || speech.Contains("sT"))
                {
                    this.ReturnSpeech("I am now searching for small targets.");
                    this.convNum = 0;
                    this.SkipSmall = false;
                    yield break;
                }
                if ((speech.Contains("edium") || speech.Contains("mt")) || speech.Contains("mT"))
                {
                    this.ReturnSpeech("I am now searching for medium targets.");
                    this.convNum = 0;
                    this.SkipMedium = false;
                    yield break;
                }
                if ((speech.Contains("ig") || speech.Contains("bt")) || speech.Contains("bT"))
                {
                    this.ReturnSpeech("I am now searching for big targets.");
                    this.convNum = 0;
                    this.SkipBig = false;
                    yield break;
                }
                if ((speech.Contains("uge") || speech.Contains("xbt")) || speech.Contains("xbT"))
                {
                    this.ReturnSpeech("I am now searching for huge targets.");
                    this.convNum = 0;
                    this.SkipHuge = false;
                    yield break;
                }
                this.ReturnSpeech("I can not process your request. \n Try another word.");
                this.convNum = 1;
                yield break;
            }
            //===============================================================================
            if (speech.Contains("target name"))
            {
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("I am looking at target code: " + this.target.name);
                this.convNum = 0;
                this.target = null;
                this.Detect = null;
                yield break;
            }
            if (speech.Contains("command 1") || speech.Contains("command1"))
            {
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Command 1. Say 'target name' if you \n want the name of what I'm looking at");
                this.convNum = 1;
                this.target = null;
                this.Detect = null;
                yield break;
            }
            if (speech.Contains("command 2") || speech.Contains("command2"))
            {
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Command 2. Say 'search' and then type \n your target name to make me search for it.");
                this.convNum = 1;
                this.target = null;
                this.Detect = null;
                yield break;
            }
            if (speech.Contains("command 3") || speech.Contains("command3"))
            {
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Command 3. Say 'skip' and then type \n your target name to make me ignore it.");
                this.convNum = 1;
                this.target = null;
                this.Detect = null;
                yield break;
            }
            if (speech.Contains("anual"))
            {
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Alright, type 'command' and any \n number to browse different commands.");
                this.convNum = 1;
                this.target = null;
                this.Detect = null;
                yield break;
            }
            yield return new WaitForSeconds(2);
            this.ReturnSpeech("I can not process your command. \n type your command correctly");
            this.convNum = 1;
            yield break;
        }
    }

    public virtual void ReturnSpeech(string yourText)
    {
        GameObject Load = ((GameObject) Resources.Load("Prefabs/TalkBubble", typeof(GameObject))) as GameObject;
        GameObject TGO = UnityEngine.Object.Instantiate(Load, this.thisTransform.position, Load.transform.rotation);
        TGO.name = "CFC0";
        TalkBubbleScript.myText = yourText;
        ((TalkBubbleScript) TGO.GetComponent(typeof(TalkBubbleScript))).source = this.thisVTransform;
    }

    public RadarDroneAI()
    {
        this.GyroForce = 10f;
        this.Force = 0.2f;
        this.DetDist = 5000;
    }

}