using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PhoneScript : MonoBehaviour
{
    public bool IsNear;
    public bool IsInUse;
    public Transform target;
    public Transform resetTarget;
    public Transform thisTransform;
    public int TargetCode;
    public AudioSource audioComponent;
    public AudioClip SFX1;
    public AudioClip SFX2;
    public GameObject SpecialDelivery;
    public ConfigurableJoint DrawerJ;
    public HingeJoint HingeJ;
    public HingeJoint GunJ;
    public Transform GunTF;
    public GameObject GunShot;
    public Transform BarrelLocation;
    public bool gunAiming;
    public bool drawerOut;
    public float Dist;
    public Vector3 relativePoint;
    public LayerMask targetLayers;
    public virtual void Start()
    {
    }

    public virtual void Update()
    {
        if (this.IsNear)
        {
            if (!this.IsInUse)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    this.target = PlayerInformation.instance.PiriTarget;
                    FurtherActionScript.instance.UsingPhone = true;
                    FurtherActionScript.instance.ShowText();
                    this.IsInUse = true;
                }
            }
            else
            {
                //========================================================================================================================//
                //////////////////////////////////////////////////////[INTERACTION]/////////////////////////////////////////////////////////
                //========================================================================================================================//
                if (NotiScript.PiriNotis)
                {
                    if (Vector3.Distance(this.thisTransform.position, PlayerInformation.instance.Pirizuka.position) < 8)
                    {
                        NotiScript.PiriNotis = false;
                    }
                }
                if (WorldInformation.pSpeech)
                {
                    if (Vector3.Distance(this.thisTransform.position, WorldInformation.pSpeech.position) < 8)
                    {
                        if (this.TargetCode == 2)
                        {
                            this.StartCoroutine(this.ProcessSpeech2(TalkBubbleScript.myText));
                        }
                        if (this.TargetCode == 3)
                        {
                            this.StartCoroutine(this.ProcessSpeech3(TalkBubbleScript.myText));
                        }
                        if (this.TargetCode == 9)
                        {
                            this.StartCoroutine(this.ProcessSpeech9(TalkBubbleScript.myText));
                        }
                    }
                    WorldInformation.pSpeech = null;
                }
            }
        }
    }

    public virtual void FixedUpdate()
    {
        if (this.TargetCode == 9)
        {
            if (this.target)
            {
                this.Dist = Vector3.Distance(this.thisTransform.position, this.target.position);
                this.relativePoint = this.GunTF.InverseTransformPoint(this.target.position);
                if (!this.gunAiming)
                {
                    this.relativePoint = this.GunTF.InverseTransformPoint(this.resetTarget.position);
                    this.Dist = Vector3.Distance(this.thisTransform.position, this.resetTarget.position);
                }
            }
            else
            {
                this.relativePoint = this.GunTF.InverseTransformPoint(this.resetTarget.position);
                this.Dist = Vector3.Distance(this.thisTransform.position, this.resetTarget.position);
            }
            if (this.drawerOut)
            {
                if (this.DrawerJ.targetPosition.x > -0.4f)
                {

                    {
                        float _2610 = this.DrawerJ.targetPosition.x - 0.03f;
                        Vector3 _2611 = this.DrawerJ.targetPosition;
                        _2611.x = _2610;
                        this.DrawerJ.targetPosition = _2611;
                    }
                }
                else
                {

                    {
                        float _2612 = -0.4f;
                        Vector3 _2613 = this.DrawerJ.targetPosition;
                        _2613.x = _2612;
                        this.DrawerJ.targetPosition = _2613;
                    }
                }
            }
            else
            {
                if (this.DrawerJ.targetPosition.x < 0)
                {

                    {
                        float _2614 = this.DrawerJ.targetPosition.x + 0.03f;
                        Vector3 _2615 = this.DrawerJ.targetPosition;
                        _2615.x = _2614;
                        this.DrawerJ.targetPosition = _2615;
                    }
                }
                else
                {

                    {
                        int _2616 = 0;
                        Vector3 _2617 = this.DrawerJ.targetPosition;
                        _2617.x = _2616;
                        this.DrawerJ.targetPosition = _2617;
                    }
                }
            }
            float LAndR = this.relativePoint.x * 4000;
            float UAndD = -this.relativePoint.y * 4000;

            {
                float _2618 = Mathf.Clamp(LAndR / this.Dist, -200, 200);
                JointMotor _2619 = this.GunJ.motor;
                _2619.targetVelocity = _2618;
                this.GunJ.motor = _2619;
            }

            {
                float _2620 = Mathf.Clamp(UAndD / this.Dist, -200, 200);
                JointMotor _2621 = this.HingeJ.motor;
                _2621.targetVelocity = _2620;
                this.HingeJ.motor = _2621;
            }
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("sTC1p") || other.name.Contains("csTC1p"))
        {
            this.IsNear = true;
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("sTC1p") || other.name.Contains("csTC1p"))
        {
            this.IsNear = false;
            this.IsInUse = false;
            if (this.convNum < 200)
            {
                this.convNum = 0;
            }
        }
    }

    public virtual IEnumerator GunOut()
    {
        yield return new WaitForSeconds(2);
        this.drawerOut = true;
        this.audioComponent.PlayOneShot(this.SFX1);
        yield return new WaitForSeconds(0.25f);
        this.audioComponent.PlayOneShot(this.SFX2);
        this.gunAiming = true;
        this.GunJ.useMotor = true;
        this.HingeJ.useMotor = true;
        yield return new WaitForSeconds(0.5f);
        Debug.DrawRay(this.BarrelLocation.position, this.BarrelLocation.forward * 16, Color.red);
        if (Physics.Raycast(this.BarrelLocation.position, this.BarrelLocation.forward, 16, (int) this.targetLayers))
        {
            UnityEngine.Object.Instantiate(this.GunShot, this.BarrelLocation.position, this.BarrelLocation.rotation);
        }
        yield return new WaitForSeconds(0.3f);
        Debug.DrawRay(this.BarrelLocation.position, this.BarrelLocation.forward * 16, Color.red);
        if (Physics.Raycast(this.BarrelLocation.position, this.BarrelLocation.forward, 16, (int) this.targetLayers))
        {
            UnityEngine.Object.Instantiate(this.GunShot, this.BarrelLocation.position, this.BarrelLocation.rotation);
        }
        yield return new WaitForSeconds(0.3f);
        Debug.DrawRay(this.BarrelLocation.position, this.BarrelLocation.forward * 16, Color.red);
        if (Physics.Raycast(this.BarrelLocation.position, this.BarrelLocation.forward, 16, (int) this.targetLayers))
        {
            UnityEngine.Object.Instantiate(this.GunShot, this.BarrelLocation.position, this.BarrelLocation.rotation);
        }
        yield return new WaitForSeconds(0.5f);
        this.audioComponent.PlayOneShot(this.SFX2);
        this.gunAiming = false;
        yield return new WaitForSeconds(0.25f);
        this.audioComponent.PlayOneShot(this.SFX1);
        this.GunJ.useMotor = false;
        this.HingeJ.useMotor = false;
        this.drawerOut = false;
    }

    public virtual IEnumerator Spawnaroo()
    {
        yield return new WaitForSeconds(1.5f);
        WorldInformation.instance.didDeliver = true;
        UnityEngine.Object.Instantiate(this.SpecialDelivery, WorldInformation.instance.SpecialDeliveryArea.position, WorldInformation.instance.SpecialDeliveryArea.rotation);
    }

    //========================================================================================================================//
    //////////////////////////////////////////////////////[INTERACTION]/////////////////////////////////////////////////////////
    //========================================================================================================================//
    public int convNum;
    public int boredom;
    public virtual IEnumerator ProcessSpeech2(string speech)
    {
        if (!this.IsInUse)
        {
            yield break;
        }
        yield return new WaitForSeconds(0.1f);
        if (!!string.IsNullOrEmpty(speech))
        {
            yield break;
        }
        if (this.convNum == 0)
        {
            //===============================================================================
            if (speech == "1")
            {
                this.convNum = 1;
                this.boredom = 0;
                yield return new WaitForSeconds(3);
                this.ReturnSpeech("You have reached the Agrian call centre, \n how may I help you?");
                yield break;
            }
        }
        //===============================================================================
        if (this.convNum == 1)
        {
            //===============================================================================
            if ((((speech.Contains("carrier") && speech.Contains("2")) || (speech.Contains("tower") && speech.Contains("2"))) || (speech.Contains("carrier") && speech.Contains("two"))) || (speech.Contains("tower") && speech.Contains("two")))
            {
                this.convNum = 21;
                this.boredom = 0;
                yield return new WaitForSeconds(3);
                this.ReturnSpeech("Do you want to hire 2 carriers \n to be in your fleet?");
                yield break;
            }
            //===============================================================================
            //===============================================================================
            if (speech.Contains("carrier") || speech.Contains("tower"))
            {
                this.convNum = 2;
                this.boredom = 0;
                yield return new WaitForSeconds(3);
                this.ReturnSpeech("Do you want to hire a carrier \n to be in your fleet?");
                yield break;
            }
            //===============================================================================
            //===============================================================================
            if (speech.Contains("uck") && speech.Contains("o"))
            {
                this.convNum = 128;
                yield return new WaitForSeconds(3);
                this.ReturnSpeech("k");
                AgrianNetwork.Spawn = 4;
                yield break;
            }
            //===============================================================================
            //===============================================================================
            if (((((((((((((((speech.Contains("3") || speech.Contains("three")) || speech.Contains("4")) || speech.Contains("four")) || speech.Contains("5")) || speech.Contains("five")) || speech.Contains("6")) || speech.Contains("six")) || speech.Contains("7")) || speech.Contains("seven")) || speech.Contains("7")) || speech.Contains("seven")) || speech.Contains("8")) || speech.Contains("eight")) || speech.Contains("9")) || speech.Contains("nine"))
            {
                this.convNum = 1;
                this.boredom = 0;
                yield return new WaitForSeconds(3);
                this.ReturnSpeech("I'm afraid we can't offer that much.");
                yield break;
            }
        }
        //===============================================================================
        //===============================================================================
        if (this.convNum == 2)
        {
            //===============================================================================
            if (speech.Contains("ye"))
            {
                this.convNum = 3;
                this.boredom = 0;
                yield return new WaitForSeconds(3);
                this.ReturnSpeech("Ok, we will have to ask you \n for your credentials");
                yield break;
            }
            //===============================================================================
            //===============================================================================
            if (speech.Contains("no"))
            {
                this.convNum = 1;
                this.boredom = 0;
                yield return new WaitForSeconds(3);
                this.ReturnSpeech("Well then, what other services \n are you looking for?");
                yield break;
            }
            //===============================================================================
            //===============================================================================
            if (speech.Contains("2") || speech.Contains("two"))
            {
                this.convNum = 3;
                this.boredom = 0;
                yield return new WaitForSeconds(3);
                this.ReturnSpeech("Ok, 2 of them, we will have to \n ask you for your credentials");
                yield break;
            }
            //===============================================================================
            //===============================================================================
            if (((((((((((((((speech.Contains("3") || speech.Contains("three")) || speech.Contains("4")) || speech.Contains("four")) || speech.Contains("5")) || speech.Contains("five")) || speech.Contains("6")) || speech.Contains("six")) || speech.Contains("7")) || speech.Contains("seven")) || speech.Contains("7")) || speech.Contains("seven")) || speech.Contains("8")) || speech.Contains("eight")) || speech.Contains("9")) || speech.Contains("nine"))
            {
                this.convNum = 2;
                this.boredom = 0;
                yield return new WaitForSeconds(3);
                this.ReturnSpeech("I'm afraid we can't offer that much.");
                yield break;
            }
            //===============================================================================
            //===============================================================================
            if (AgrianNetwork.TC1CriminalLevel < 200)
            {
                if (speech.Contains("pirizuka") && speech.Contains("overseer"))
                {
                    this.convNum = 6;
                    this.boredom = 0;
                    yield return new WaitForSeconds(3);
                    this.ReturnSpeech("Ok, Pirizuka. Is this what you want?");
                    yield break;
                }
            }
            else
            {
                if (speech.Contains("ye"))
                {
                    this.convNum = 512;
                    yield return new WaitForSeconds(3);
                    this.ReturnSpeech("Oh, it's Pirizuka! \n Why don't you just stay here for a bit?");
                    AgrianNetwork.Spawn = 4;
                    yield break;
                }
            }
            //===============================================================================
            yield return new WaitForSeconds(4);
            if (this.boredom < 1)
            {
                this.ReturnSpeech("What?");
                this.convNum = 2;
                this.boredom = this.boredom + 1;
                yield break;
            }
        }
        //===============================================================================
        if (this.convNum == 21)
        {
            //===============================================================================
            if (speech.Contains("ye"))
            {
                this.convNum = 31;
                this.boredom = 0;
                yield return new WaitForSeconds(3);
                this.ReturnSpeech("Ok, we will have to ask you \n for your credentials");
                yield break;
            }
            //===============================================================================
            //===============================================================================
            if (speech.Contains("no"))
            {
                this.convNum = 1;
                this.boredom = 0;
                yield return new WaitForSeconds(3);
                this.ReturnSpeech("Well then, what other services \n are you looking for?");
                yield break;
            }
            //===============================================================================
            //===============================================================================
            if (((((((((((((((speech.Contains("3") || speech.Contains("three")) || speech.Contains("4")) || speech.Contains("four")) || speech.Contains("5")) || speech.Contains("five")) || speech.Contains("6")) || speech.Contains("six")) || speech.Contains("7")) || speech.Contains("seven")) || speech.Contains("7")) || speech.Contains("seven")) || speech.Contains("8")) || speech.Contains("eight")) || speech.Contains("9")) || speech.Contains("nine"))
            {
                this.convNum = 21;
                this.boredom = 0;
                yield return new WaitForSeconds(3);
                this.ReturnSpeech("I'm afraid we can't offer that much.");
                yield break;
            }
            //===============================================================================
            //===============================================================================
            if (AgrianNetwork.TC1CriminalLevel < 200)
            {
                if (speech.Contains("pirizuka") && speech.Contains("overseer"))
                {
                    this.convNum = 61;
                    this.boredom = 0;
                    yield return new WaitForSeconds(3);
                    this.ReturnSpeech("Ok, Pirizuka. Is this what you want?");
                    yield break;
                }
            }
            else
            {
                if (speech.Contains("ye"))
                {
                    this.convNum = 512;
                    yield return new WaitForSeconds(3);
                    this.ReturnSpeech("Oh, it's Pirizuka! \n Why don't you just stay here for a bit?");
                    AgrianNetwork.Spawn = 4;
                    yield break;
                }
            }
            //===============================================================================
            yield return new WaitForSeconds(4);
            if (this.boredom < 1)
            {
                this.ReturnSpeech("What?");
                this.convNum = 21;
                this.boredom = this.boredom + 1;
                yield break;
            }
        }
        //===============================================================================
        if (this.convNum == 3)
        {
            //===============================================================================
            if (AgrianNetwork.TC1CriminalLevel < 200)
            {
                if (speech.Contains("pirizuka") && speech.Contains("overseer"))
                {
                    this.convNum = 128;
                    yield return new WaitForSeconds(3);
                    this.ReturnSpeech("Alright, you will be accompanied by \n a carrier in your Zerzek fleet.");
                    WorldInformation.FleetMember2 = "AgrianTower_P_Warper";
                    PlayerPrefs.SetString("FleetMember2", "AgrianTower_P_Warper");
                    PlayerPrefs.Save();
                    yield break;
                }
            }
            else
            {
                if (speech.Contains("ye"))
                {
                    this.convNum = 512;
                    yield return new WaitForSeconds(3);
                    this.ReturnSpeech("Oh, it's Pirizuka! \n Why don't you just stay here for a bit?");
                    AgrianNetwork.Spawn = 4;
                    yield break;
                }
            }
            //===============================================================================
            //===============================================================================
            if (speech.Contains("pirizuka"))
            {
                this.convNum = 4;
                this.boredom = 0;
                yield return new WaitForSeconds(3);
                this.ReturnSpeech("The overseer?");
                yield break;
            }
            //===============================================================================
            //===============================================================================
            if (speech.Contains("overseer"))
            {
                this.convNum = 5;
                this.boredom = 0;
                yield return new WaitForSeconds(3);
                this.ReturnSpeech("Ok, but what is your name?");
                yield break;
            }
            //===============================================================================
            yield return new WaitForSeconds(4);
            if (this.boredom < 1)
            {
                this.ReturnSpeech("Excuse me?");
                this.convNum = 3;
                this.boredom = this.boredom + 1;
                yield break;
            }
        }
        //===============================================================================
        if (this.convNum == 31)
        {
            //===============================================================================
            if (AgrianNetwork.TC1CriminalLevel < 200)
            {
                if (speech.Contains("pirizuka") && speech.Contains("overseer"))
                {
                    this.convNum = 128;
                    yield return new WaitForSeconds(3);
                    this.ReturnSpeech("Alright, you will be accompanied by \n 2 carriers in your Zerzek fleet.");
                    WorldInformation.FleetMember2 = "AgrianTower_P_Warper";
                    WorldInformation.FleetMember3 = "AgrianTower_P_Warper";
                    PlayerPrefs.SetString("FleetMember2", "AgrianTower_P_Warper");
                    PlayerPrefs.SetString("FleetMember3", "AgrianTower_P_Warper");
                    PlayerPrefs.Save();
                    yield break;
                }
            }
            else
            {
                if (speech.Contains("ye"))
                {
                    this.convNum = 512;
                    yield return new WaitForSeconds(3);
                    this.ReturnSpeech("Oh, it's Pirizuka! \n Why don't you just stay here for a bit?");
                    AgrianNetwork.Spawn = 4;
                    yield break;
                }
            }
            //===============================================================================
            //===============================================================================
            if (speech.Contains("pirizuka"))
            {
                this.convNum = 41;
                this.boredom = 0;
                yield return new WaitForSeconds(3);
                this.ReturnSpeech("The overseer?");
                yield break;
            }
            //===============================================================================
            //===============================================================================
            if (speech.Contains("overseer"))
            {
                this.convNum = 51;
                this.boredom = 0;
                yield return new WaitForSeconds(3);
                this.ReturnSpeech("Ok, but what is your name?");
                yield break;
            }
            //===============================================================================
            yield return new WaitForSeconds(4);
            if (this.boredom < 1)
            {
                this.ReturnSpeech("Excuse me?");
                this.convNum = 31;
                this.boredom = this.boredom + 1;
                yield break;
            }
        }
        //===============================================================================
        if (this.convNum == 4)
        {
            //===============================================================================
            if (AgrianNetwork.TC1CriminalLevel < 200)
            {
                if (speech.Contains("ye"))
                {
                    this.convNum = 128;
                    yield return new WaitForSeconds(3);
                    this.ReturnSpeech("Alright, you will be accompanied by \n a carrier in your Zerzek fleet.");
                    WorldInformation.FleetMember2 = "AgrianTower_P_Warper";
                    PlayerPrefs.SetString("FleetMember2", "AgrianTower_P_Warper");
                    PlayerPrefs.Save();
                    yield break;
                }
            }
            else
            {
                if (speech.Contains("ye"))
                {
                    this.convNum = 512;
                    yield return new WaitForSeconds(3);
                    this.ReturnSpeech("Oh, it's Pirizuka! \n Why don't you just stay here for a bit?");
                    AgrianNetwork.Spawn = 4;
                    yield break;
                }
            }
            //===============================================================================
            yield return new WaitForSeconds(4);
            if (this.boredom < 1)
            {
                this.ReturnSpeech("What?");
                this.convNum = 4;
                this.boredom = this.boredom + 1;
                yield break;
            }
        }
        //===============================================================================
        if (this.convNum == 41)
        {
            //===============================================================================
            if (AgrianNetwork.TC1CriminalLevel < 200)
            {
                if (speech.Contains("ye"))
                {
                    this.convNum = 128;
                    yield return new WaitForSeconds(3);
                    this.ReturnSpeech("Alright, you will be accompanied by \n 2 carriers in your Zerzek fleet.");
                    WorldInformation.FleetMember2 = "AgrianTower_P_Warper";
                    WorldInformation.FleetMember3 = "AgrianTower_P_Warper";
                    PlayerPrefs.SetString("FleetMember2", "AgrianTower_P_Warper");
                    PlayerPrefs.SetString("FleetMember3", "AgrianTower_P_Warper");
                    PlayerPrefs.Save();
                    yield break;
                }
            }
            else
            {
                if (speech.Contains("ye"))
                {
                    this.convNum = 512;
                    yield return new WaitForSeconds(3);
                    this.ReturnSpeech("Oh, it's Pirizuka! \n Why don't you just stay here for a bit?");
                    AgrianNetwork.Spawn = 4;
                    yield break;
                }
            }
            //===============================================================================
            yield return new WaitForSeconds(4);
            if (this.boredom < 1)
            {
                this.ReturnSpeech("What?");
                this.convNum = 41;
                this.boredom = this.boredom + 1;
                yield break;
            }
        }
        //===============================================================================
        if (this.convNum == 5)
        {
            //===============================================================================
            if (AgrianNetwork.TC1CriminalLevel < 200)
            {
                if (speech.Contains("pirizuka"))
                {
                    this.convNum = 128;
                    yield return new WaitForSeconds(3);
                    this.ReturnSpeech("Alright, you will be accompanied by \n a carrier in your Zerzek fleet.");
                    WorldInformation.FleetMember2 = "AgrianTower_P_Warper";
                    PlayerPrefs.SetString("FleetMember2", "AgrianTower_P_Warper");
                    PlayerPrefs.Save();
                    yield break;
                }
            }
            else
            {
                if (speech.Contains("ye"))
                {
                    this.convNum = 512;
                    yield return new WaitForSeconds(3);
                    this.ReturnSpeech("Oh, it's Pirizuka! \n Why don't you just stay here for a bit?");
                    AgrianNetwork.Spawn = 4;
                    yield break;
                }
            }
            //===============================================================================
            yield return new WaitForSeconds(4);
            if (this.boredom < 1)
            {
                this.ReturnSpeech("Who?");
                this.convNum = 5;
                this.boredom = this.boredom + 1;
                yield break;
            }
        }
        //===============================================================================
        if (this.convNum == 51)
        {
            //===============================================================================
            if (AgrianNetwork.TC1CriminalLevel < 200)
            {
                if (speech.Contains("pirizuka"))
                {
                    this.convNum = 128;
                    yield return new WaitForSeconds(3);
                    this.ReturnSpeech("Alright, you will be accompanied by \n 2 carriers in your Zerzek fleet.");
                    WorldInformation.FleetMember2 = "AgrianTower_P_Warper";
                    WorldInformation.FleetMember3 = "AgrianTower_P_Warper";
                    PlayerPrefs.SetString("FleetMember2", "AgrianTower_P_Warper");
                    PlayerPrefs.SetString("FleetMember3", "AgrianTower_P_Warper");
                    PlayerPrefs.Save();
                    yield break;
                }
            }
            else
            {
                if (speech.Contains("ye"))
                {
                    this.convNum = 512;
                    yield return new WaitForSeconds(3);
                    this.ReturnSpeech("Oh, it's Pirizuka! \n Why don't you just stay here for a bit?");
                    AgrianNetwork.Spawn = 4;
                    yield break;
                }
            }
            //===============================================================================
            yield return new WaitForSeconds(4);
            if (this.boredom < 1)
            {
                this.ReturnSpeech("Who?");
                this.convNum = 51;
                this.boredom = this.boredom + 1;
                yield break;
            }
        }
        //===============================================================================
        if (this.convNum == 6)
        {
            //===============================================================================
            if (AgrianNetwork.TC1CriminalLevel < 200)
            {
                if (speech.Contains("ye"))
                {
                    this.convNum = 128;
                    yield return new WaitForSeconds(3);
                    this.ReturnSpeech("Alright, you will be accompanied by \n a carrier in your Zerzek fleet.");
                    WorldInformation.FleetMember2 = "AgrianTower_P_Warper";
                    PlayerPrefs.SetString("FleetMember2", "AgrianTower_P_Warper");
                    PlayerPrefs.Save();
                    yield break;
                }
            }
            else
            {
                if (speech.Contains("ye"))
                {
                    this.convNum = 512;
                    yield return new WaitForSeconds(3);
                    this.ReturnSpeech("Oh, it's Pirizuka! \n Why don't you just stay here for a bit?");
                    AgrianNetwork.Spawn = 4;
                    yield break;
                }
            }
            //===============================================================================
            //===============================================================================
            if (speech.Contains("no"))
            {
                this.convNum = 1;
                this.boredom = 0;
                yield return new WaitForSeconds(3);
                this.ReturnSpeech("Well then, what other services \n are you looking for?");
                yield break;
            }
            //===============================================================================
            yield return new WaitForSeconds(4);
            if (this.boredom < 1)
            {
                this.ReturnSpeech("What?");
                this.convNum = 6;
                this.boredom = this.boredom + 1;
                yield break;
            }
        }
        //===============================================================================
        if (this.convNum == 61)
        {
            //===============================================================================
            if (AgrianNetwork.TC1CriminalLevel < 200)
            {
                if (speech.Contains("ye"))
                {
                    this.convNum = 128;
                    yield return new WaitForSeconds(3);
                    this.ReturnSpeech("Alright, you will be accompanied by \n 2 carriers in your Zerzek fleet.");
                    WorldInformation.FleetMember2 = "AgrianTower_P_Warper";
                    WorldInformation.FleetMember3 = "AgrianTower_P_Warper";
                    PlayerPrefs.SetString("FleetMember2", "AgrianTower_P_Warper");
                    PlayerPrefs.SetString("FleetMember3", "AgrianTower_P_Warper");
                    PlayerPrefs.Save();
                    yield break;
                }
            }
            else
            {
                if (speech.Contains("ye"))
                {
                    this.convNum = 512;
                    yield return new WaitForSeconds(3);
                    this.ReturnSpeech("Oh, it's Pirizuka! \n Why don't you just stay here for a bit?");
                    AgrianNetwork.Spawn = 4;
                    yield break;
                }
            }
            //===============================================================================
            //===============================================================================
            if (speech.Contains("no"))
            {
                this.convNum = 1;
                this.boredom = 0;
                yield return new WaitForSeconds(3);
                this.ReturnSpeech("Well then, what other services \n are you looking for?");
                yield break;
            }
            //===============================================================================
            yield return new WaitForSeconds(4);
            if (this.boredom < 1)
            {
                this.ReturnSpeech("What?");
                this.convNum = 61;
                this.boredom = this.boredom + 1;
                yield break;
            }
        }
        //===============================================================================
        yield return new WaitForSeconds(4);
        if (this.convNum > 0)
        {
            if (this.convNum == 512)
            {
                if (this.boredom == 0)
                {
                    this.ReturnSpeech("So, how does it feel to be \n an enemy of the Kabrians?");
                }
                if (this.boredom == 1)
                {
                    this.ReturnSpeech("Pretty rough, isn't it?");
                }
                if (this.boredom == 2)
                {
                    this.ReturnSpeech("Well, it was nice talking to you.");
                }
                this.boredom = this.boredom + 1;
            }
            else
            {
                if (this.boredom == 0)
                {
                    this.ReturnSpeech("Please elaborate?");
                }
                if (this.boredom == 1)
                {
                    this.ReturnSpeech("I do not think that I can \n help you with that.");
                }
                if (this.boredom == 2)
                {
                    this.ReturnSpeech("Well, it was nice talking to you.");
                    this.convNum = 128;
                }
                this.boredom = this.boredom + 1;
            }
        }
        else
        {
            this.ReturnSpeech("The number you have dialed \n is currently not in use.");
        }
        if (this.convNum == 128)
        {
            this.IsNear = false;
            this.IsInUse = false;
            this.convNum = 0;
            this.boredom = 0;
        }
    }

    public virtual IEnumerator ProcessSpeech3(string speech)
    {
        if (!this.IsInUse)
        {
            yield break;
        }
        yield return new WaitForSeconds(0.1f);
        if (!!string.IsNullOrEmpty(speech))
        {
            yield break;
        }
        if (this.convNum == 0)
        {
            //===============================================================================
            if (speech == "1")
            {
                this.convNum = 1;
                this.boredom = 0;
                yield return new WaitForSeconds(3);
                this.ReturnSpeech("You have reached the Terrahyptian call centre, \n how may I help you?");
                yield break;
            }
        }
        //===============================================================================
        if (this.convNum == 1)
        {
            //===============================================================================
            if (speech.Contains("carrier") || speech.Contains("tower"))
            {
                this.convNum = 2;
                this.boredom = 0;
                yield return new WaitForSeconds(3);
                this.ReturnSpeech("Are you sure you do not want to ask \n the Agrians for this kind of service?");
                yield break;
            }
            //===============================================================================
            //===============================================================================
            if (speech.Contains("uck") && speech.Contains("o"))
            {
                this.convNum = 128;
                yield return new WaitForSeconds(3);
                this.ReturnSpeech("Well, I will see you later");
                yield break;
            }
        }
        //===============================================================================
        //===============================================================================
        if (this.convNum == 2)
        {
            //===============================================================================
            if (speech.Contains("ye"))
            {
                this.convNum = 128;
                this.boredom = 0;
                yield return new WaitForSeconds(3);
                this.ReturnSpeech("Good luck then");
                yield break;
            }
            //===============================================================================
            //===============================================================================
            if (speech.Contains("no"))
            {
                this.convNum = 128;
                this.boredom = 0;
                yield return new WaitForSeconds(3);
                this.ReturnSpeech("Well, we are sorry to tell you that we don't have \n any of those services available at this moment");
                yield break;
            }
            //===============================================================================
            //===============================================================================
            if (speech.Contains("ok"))
            {
                this.convNum = 128;
                this.boredom = 0;
                yield return new WaitForSeconds(3);
                this.ReturnSpeech("Good luck then");
                yield break;
            }
            //===============================================================================
            yield return new WaitForSeconds(4);
            if (this.boredom < 1)
            {
                this.ReturnSpeech("What?");
                this.convNum = 2;
                this.boredom = this.boredom + 1;
                yield break;
            }
        }
        //===============================================================================
        yield return new WaitForSeconds(3);
        if (this.convNum > 0)
        {
            if (this.boredom == 0)
            {
                this.ReturnSpeech("Please elaborate?");
            }
            if (this.boredom == 1)
            {
                this.ReturnSpeech("I do not think that I can \n help you with that.");
            }
            if (this.boredom == 2)
            {
                this.ReturnSpeech("Well, it was nice talking to you.");
                this.convNum = 128;
            }
            this.boredom = this.boredom + 1;
        }
        else
        {
            this.ReturnSpeech("The number you have dialed \n is currently not in use.");
        }
        if (this.convNum == 128)
        {
            this.IsNear = false;
            this.IsInUse = false;
            this.convNum = 0;
            this.boredom = 0;
        }
    }

    public virtual IEnumerator ProcessSpeech9(string speech)
    {
        if (!this.IsInUse)
        {
            yield break;
        }
        yield return new WaitForSeconds(0.1f);
        if (!!string.IsNullOrEmpty(speech))
        {
            yield break;
        }
        if (this.convNum == 0)
        {
            //===============================================================================
            if (speech == "1")
            {
                this.convNum = 1;
                this.boredom = 0;
                yield return new WaitForSeconds(3);
                this.ReturnSpeech("This is the Dutvutanian call centre, \n What do you want?");
                yield break;
            }
        }
        //===============================================================================
        if (this.convNum == 200)
        {
            //===============================================================================
            if (speech.Contains("trigger remains untouched"))
            {
                this.convNum = 201;
                this.boredom = 1;
                yield return new WaitForSeconds(2);
                this.StartCoroutine(this.GunOut());
                yield break;
            }
            //===============================================================================
            yield return new WaitForSeconds(4);
            this.ReturnSpeech("You again? We do not have any \n services for you at the moment.");
            this.convNum = 201;
            this.boredom = this.boredom + 1;
            yield break;
        }
        if (this.convNum == 201)
        {
            yield return new WaitForSeconds(2);
            this.StartCoroutine(this.GunOut());
            yield break;
        }
        if (this.convNum == 1)
        {
            //===============================================================================
            if (speech.Contains("prank"))
            {
                this.convNum = 200;
                this.boredom = 1;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Ok, good for making it easy for us.");
                this.StartCoroutine(this.GunOut());
                yield break;
            }
            //===============================================================================
            //===============================================================================
            if (speech.Contains("trigger remains untouched"))
            {
                this.convNum = 20;
                this.boredom = 1;
                yield return new WaitForSeconds(3);
                this.ReturnSpeech("What are you on about?");
                yield break;
            }
            //===============================================================================
            //===============================================================================
            if (speech.Contains("carrier") || speech.Contains("tower"))
            {
                this.convNum = 2;
                this.boredom = 0;
                yield return new WaitForSeconds(3);
                this.ReturnSpeech("We don't even know who you are. \nstate your name.");
                yield break;
            }
            //===============================================================================
            //===============================================================================
            if (speech.Contains("irizuka"))
            {
                this.convNum = 2;
                this.boredom = 1;
                yield return new WaitForSeconds(3);
                this.ReturnSpeech("And?");
                yield break;
            }
            //===============================================================================
            //===============================================================================
            if (speech.Contains("verseer"))
            {
                this.convNum = 2;
                this.boredom = 1;
                yield return new WaitForSeconds(3);
                this.ReturnSpeech("So?");
                yield break;
            }
        }
        //===============================================================================
        if (this.convNum == 2)
        {
            //===============================================================================
            if (speech.Contains("irizuka"))
            {
                this.convNum = 128;
                this.boredom = 1;
                yield return new WaitForSeconds(3);
                this.ReturnSpeech("We don't know who that person is. \nDon't bother us in the future.");
                yield break;
            }
            //===============================================================================
            //===============================================================================
            if (speech.Contains("verseer"))
            {
                this.convNum = 128;
                this.boredom = 1;
                yield return new WaitForSeconds(3);
                this.ReturnSpeech("Good for you. \nWe don't respect your kind, beat it.");
                yield break;
            }
            //===============================================================================
            //===============================================================================
            if (speech.Contains("no") || speech.Contains("ye"))
            {
                this.convNum = 128;
                this.boredom = 2;
                yield return new WaitForSeconds(3);
                yield break;
            }
            //===============================================================================
            yield return new WaitForSeconds(4);
            if (this.boredom < 1)
            {
                this.ReturnSpeech("What do you want?");
                this.convNum = 2;
                this.boredom = this.boredom + 1;
                yield break;
            }
        }
        //===============================================================================
        if (this.convNum == 20)
        {
            //===============================================================================
            if (speech.Contains("thought you would know"))
            {
                this.convNum = 21;
                this.boredom = 1;
                yield return new WaitForSeconds(3);
                this.ReturnSpeech("I don't know who you are, or what you want \nstop wasting our time");
                yield break;
            }
            //===============================================================================
            yield return new WaitForSeconds(3);
            this.StartCoroutine(this.GunOut());
            this.convNum = 200;
            yield break;
        }
        //===============================================================================
        if (this.convNum == 21)
        {
            //===============================================================================
            if (speech.Contains("it be like that sometimes huh"))
            {
                this.convNum = 128;
                this.boredom = 1;
                yield return new WaitForSeconds(3);
                this.ReturnSpeech("Step away from this phone \n or I'll shoot your face off...");
                this.StartCoroutine(this.Spawnaroo());
                yield break;
            }
            //===============================================================================
            yield return new WaitForSeconds(3);
            this.StartCoroutine(this.GunOut());
            this.convNum = 200;
            yield break;
        }
        //===============================================================================
        yield return new WaitForSeconds(3);
        if (this.convNum > 0)
        {
            if (this.boredom == 0)
            {
                this.ReturnSpeech("Tell us something more important");
            }
            if (this.boredom == 1)
            {
                this.ReturnSpeech("I'm going to request you to be killed \nif you do not give us any reason to waste our time on you");
            }
            if (this.boredom == 2)
            {
                this.StartCoroutine(this.GunOut());
                this.convNum = 200;
            }
            this.boredom = this.boredom + 1;
        }
        else
        {
            this.ReturnSpeech("The number you have dialed \n is currently not in use.");
        }
        if (this.convNum == 128)
        {
            this.IsNear = false;
            this.IsInUse = false;
            this.convNum = 0;
            this.boredom = 0;
        }
    }

    public virtual void ReturnSpeech(string yourText)
    {
        GameObject Load = ((GameObject) Resources.Load("Prefabs/TalkBubble", typeof(GameObject))) as GameObject;
        GameObject TGO = UnityEngine.Object.Instantiate(Load, this.thisTransform.position, Load.transform.rotation);
        TGO.name = "C";
        TalkBubbleScript.myText = yourText;
        ((TalkBubbleScript) TGO.GetComponent(typeof(TalkBubbleScript))).source = this.thisTransform;
    }

}