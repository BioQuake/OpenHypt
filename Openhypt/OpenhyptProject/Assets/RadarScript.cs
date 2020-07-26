using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class RadarScript : MonoBehaviour
{
    public Transform target;
    public Transform thisTransform;
    public Transform thisGTransform;
    public Rigidbody thisGRB;
    public float GyroStabForce;
    public AudioSource Beep;
    public bool canBeepTime;
    public int BeepTime;
    public AudioClip CommandSuccessfulSFX;
    public AudioClip CommandFailedSFX;
    public AudioClip RadarRegisterSFX;
    public AudioClip RadarBeepSFX;
    public bool FindSmall;
    public bool FindMedium;
    public bool FindLarge;
    public bool FindTC0;
    public bool FindTC2;
    public bool FindTC3;
    public bool FindTC4;
    public bool FindTC5;
    public bool FindTC6;
    public bool FindTC7;
    public bool FindTC8;
    public bool FindTC9;
    public float rProd1;
    public float rProd2;
    public virtual void Start()
    {
        this.InvokeRepeating("Tick", 1, 0.66f);
    }

    public virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            this.StartCoroutine(this.InitiateRadar());
        }
    }

    public virtual void FixedUpdate()
    {
        float TDist = 0.0f;
        if (this.target)
        {
            Vector3 RelativeG = this.thisTransform.InverseTransformPoint(this.target.position);
            TDist = Vector3.Distance(this.thisTransform.position, this.target.position);
            this.rProd1 = (RelativeG.x / TDist) * 4;
        }
        else
        {
            this.rProd1 = 4;
            this.canBeepTime = false;
        }
        this.rProd2 = Mathf.Clamp(this.rProd1, -4, 4);

        {
            float _486 = this.thisTransform.localEulerAngles.z + this.rProd2;
            Vector3 _487 = this.thisTransform.localEulerAngles;
            _487.z = _486;
            this.thisTransform.localEulerAngles = _487;
        }
        this.thisGRB.AddForceAtPosition(Vector3.up * this.GyroStabForce, this.thisGTransform.up * 0.5f);
        this.thisGRB.AddForceAtPosition(-Vector3.up * this.GyroStabForce, -this.thisGTransform.up * 0.5f);
        if (this.canBeepTime)
        {
            if (this.BeepTime < 1)
            {
                this.BeepTime = (int) (Mathf.Clamp(TDist, 300, 2000) * 0.05f);
                this.Beep.PlayOneShot(this.RadarBeepSFX);
            }
            else
            {
                this.BeepTime = this.BeepTime - 1;
            }
        }
    }

    public virtual IEnumerator InitiateRadar()
    {
        yield return new WaitForSeconds(0.2f);
        if (WorldInformation.pSpeech)
        {
            if (Vector3.Distance(this.thisTransform.position, WorldInformation.pSpeech.position) < 64)
            {
                this.StartCoroutine(this.ProcessSpeech(TalkBubbleScript.myText));
            }
        }
    }

    public virtual IEnumerator ProcessSpeech(string speech)
    {
        yield return new WaitForSeconds(0.1f);
        if (!!string.IsNullOrEmpty(speech))
        {
            yield break;
        }
        //===============================================================================
        if (speech.Contains("adar"))
        {
            yield return new WaitForSeconds(1);
            if ((speech.Contains("mall") || speech.Contains("st")) || speech.Contains("sT"))
            {
                this.FindSmall = true;
            }
            if ((speech.Contains("edium") || speech.Contains("mt")) || speech.Contains("mT"))
            {
                this.FindMedium = true;
            }
            if ((speech.Contains("arge") || speech.Contains("bt")) || speech.Contains("bT"))
            {
                this.FindLarge = true;
            }
            if ((((speech.Contains("reature") || speech.Contains("nimal")) || speech.Contains("ivilian")) || speech.Contains("eople")) || speech.Contains("c0"))
            {
                this.CommandSuccessful();
                this.FindTC0 = true;
                this.target = null;
                yield break;
            }
            if (speech.Contains("grian") || speech.Contains("c2"))
            {
                this.CommandSuccessful();
                this.FindTC2 = true;
                this.target = null;
                yield break;
            }
            if (speech.Contains("errahypt") || speech.Contains("c3"))
            {
                this.CommandSuccessful();
                this.FindTC3 = true;
                this.target = null;
                yield break;
            }
            if (speech.Contains("berrant") || speech.Contains("c4"))
            {
                this.CommandSuccessful();
                this.FindTC4 = true;
                this.target = null;
                yield break;
            }
            if (speech.Contains("lavui") || speech.Contains("c5"))
            {
                this.CommandSuccessful();
                this.FindTC5 = true;
                this.target = null;
                yield break;
            }
            if ((speech.Contains("tiba") || speech.Contains("bia")) || speech.Contains("c6"))
            {
                this.CommandSuccessful();
                this.FindTC6 = true;
                this.target = null;
                yield break;
            }
            if (speech.Contains("evnav") || speech.Contains("c7"))
            {
                this.CommandSuccessful();
                this.FindTC7 = true;
                this.target = null;
                yield break;
            }
            if (speech.Contains("utvuta") || speech.Contains("c9"))
            {
                this.CommandSuccessful();
                this.FindTC9 = true;
                this.target = null;
                yield break;
            }
            if ((speech.Contains("eset") || speech.Contains("dle")) || speech.Contains("eactiva"))
            {
                this.CommandFailed();
                this.FindLarge = false;
                this.FindMedium = false;
                this.FindSmall = false;
                this.FindTC0 = false;
                this.FindTC2 = false;
                this.FindTC3 = false;
                this.FindTC4 = false;
                this.FindTC5 = false;
                this.FindTC6 = false;
                this.FindTC7 = false;
                this.FindTC8 = false;
                this.FindTC9 = false;
                this.target = null;
                yield break;
            }
            this.CommandFailed();
            yield break;
        }
    }

    public virtual IEnumerator RadarRegister()
    {
        this.Beep.PlayOneShot(this.RadarRegisterSFX);
        yield return new WaitForSeconds(0.6f);
        this.canBeepTime = true;
    }

    public virtual void CommandSuccessful()
    {
        this.Beep.PlayOneShot(this.CommandSuccessfulSFX);
        this.canBeepTime = false;
    }

    public virtual void CommandFailed()
    {
        this.Beep.PlayOneShot(this.CommandFailedSFX);
        this.canBeepTime = false;
    }

    public virtual void Tick()//VPFX.startSize = VPRadius * 2;
    {
        if (this.target)
        {
            return;
        }
        GameObject[] gos = null;
        gos = GameObject.FindGameObjectsWithTag("TC");
        //var Blip = Resources.Load("Prefabs/RadarBlip", GameObject) as GameObject;
        foreach (GameObject go in gos)
        {
            string ON = go.name;
            Transform OT = go.transform;
            //Debug.Log(ON);
            //Instantiate(Blip, OT.position, OT.rotation);
            Vector3 RTF = this.thisGTransform.InverseTransformPoint(OT.position);
            if (Vector3.Distance(this.thisTransform.position, OT.position) > 32)
            {
                if (RTF.y < 64)
                {
                    if (this.FindTC0)
                    {
                        if (ON.Contains("TC0"))
                        {
                            if (((ON.Contains("sT") && this.FindSmall) || (ON.Contains("mT") && this.FindMedium)) || (ON.Contains("bT") && this.FindLarge))
                            {
                                this.target = OT;
                                this.StartCoroutine(this.RadarRegister());
                            }
                        }
                    }
                    if (this.FindTC2)
                    {
                        if (ON.Contains("TC2"))
                        {
                            if (((ON.Contains("sT") && this.FindSmall) || (ON.Contains("mT") && this.FindMedium)) || (ON.Contains("bT") && this.FindLarge))
                            {
                                this.target = OT;
                                this.StartCoroutine(this.RadarRegister());
                            }
                        }
                    }
                    if (this.FindTC3)
                    {
                        if (ON.Contains("TC3"))
                        {
                            if (((ON.Contains("sT") && this.FindSmall) || (ON.Contains("mT") && this.FindMedium)) || (ON.Contains("bT") && this.FindLarge))
                            {
                                this.target = OT;
                                this.StartCoroutine(this.RadarRegister());
                            }
                        }
                    }
                    if (this.FindTC4)
                    {
                        if (ON.Contains("TC4"))
                        {
                            if (((ON.Contains("sT") && this.FindSmall) || (ON.Contains("mT") && this.FindMedium)) || (ON.Contains("bT") && this.FindLarge))
                            {
                                this.target = OT;
                                this.StartCoroutine(this.RadarRegister());
                            }
                        }
                    }
                    if (this.FindTC5)
                    {
                        if (ON.Contains("TC5"))
                        {
                            if (((ON.Contains("sT") && this.FindSmall) || (ON.Contains("mT") && this.FindMedium)) || (ON.Contains("bT") && this.FindLarge))
                            {
                                this.target = OT;
                                this.StartCoroutine(this.RadarRegister());
                            }
                        }
                    }
                    if (this.FindTC6)
                    {
                        if (ON.Contains("TC6"))
                        {
                            if (((ON.Contains("sT") && this.FindSmall) || (ON.Contains("mT") && this.FindMedium)) || (ON.Contains("bT") && this.FindLarge))
                            {
                                this.target = OT;
                                this.StartCoroutine(this.RadarRegister());
                            }
                        }
                    }
                    if (this.FindTC7)
                    {
                        if (ON.Contains("TC7"))
                        {
                            if (((ON.Contains("sT") && this.FindSmall) || (ON.Contains("mT") && this.FindMedium)) || (ON.Contains("bT") && this.FindLarge))
                            {
                                this.target = OT;
                                this.StartCoroutine(this.RadarRegister());
                            }
                        }
                    }
                    if (this.FindTC8)
                    {
                        if (ON.Contains("TC8"))
                        {
                            if (((ON.Contains("sT") && this.FindSmall) || (ON.Contains("mT") && this.FindMedium)) || (ON.Contains("bT") && this.FindLarge))
                            {
                                this.target = OT;
                                this.StartCoroutine(this.RadarRegister());
                            }
                        }
                    }
                    if (this.FindTC9)
                    {
                        if (ON.Contains("TC9"))
                        {
                            if (((ON.Contains("sT") && this.FindSmall) || (ON.Contains("mT") && this.FindMedium)) || (ON.Contains("bT") && this.FindLarge))
                            {
                                this.target = OT;
                                this.StartCoroutine(this.RadarRegister());
                            }
                        }
                    }
                }
            }
        }
    }

}

/*
[System.Serializable]
internal class EvalAssemblyReferences : object
{
    public static System.Reflection.Assembly[] Value;
    static EvalAssemblyReferences()
    {
        EvalAssemblyReferences.Value = new System.Reflection.Assembly[] {System.Reflection.Assembly.GetExecutingAssembly(), typeof(AndroidInput).Assembly, typeof(Physics).Assembly, typeof(Microsoft.Win32.Registry).Assembly, typeof(AudioSpeakerMode).Assembly, typeof(Boo.Lang.Environments.ActiveEnvironment).Assembly, typeof(AnimationEvent).Assembly, typeof(TextAlignment).Assembly, typeof(ParticleSystem).Assembly, typeof(System.Xml.XmlNamedNodeMap).Assembly, typeof(UnityScript.Core.BaseTypeAnnotations).Assembly};
    }

}
*/