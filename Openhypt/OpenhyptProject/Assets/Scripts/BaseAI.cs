using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class BaseAI : MonoBehaviour
{
    public Transform target;
    public Transform thisTransform;
    public int Ogle;
    public TurretAI BaseGun1;
    public TurretAI BaseGun2;
    public TurretAI BaseGun3;
    public TurretAI BaseGun4;
    public TurretAI BaseGun5;
    public TurretAI BaseGun6;
    public int PissedAtTC0a;
    public int PissedAtTC1;
    public int PissedAtTC2;
    public int PissedAtTC3;
    public int PissedAtTC4;
    public int PissedAtTC5;
    public int PissedAtTC6;
    public int PissedAtTC7;
    public int PissedAtTC8;
    public int PissedAtTC9;
    public virtual void Start()
    {
        this.InvokeRepeating("Ticker", 4, 1);
        this.thisTransform = this.transform;
        this.PissedAtTC0a = 64;
        this.PissedAtTC1 = 64;
        this.PissedAtTC2 = 0;
        this.PissedAtTC3 = 0;
        this.PissedAtTC4 = 64;
        this.PissedAtTC5 = 64;
        this.PissedAtTC6 = 64;
        this.PissedAtTC7 = 64;
        this.PissedAtTC8 = 64;
        this.PissedAtTC9 = 64;
        if (Vector3.Distance(this.thisTransform.position, PlayerInformation.instance.Pirizuka.position) < 512)
        {
            this.convNum = 64;
            this.PissedAtTC0a = 0;
            this.PissedAtTC1 = 0;
        }
    }

    public virtual void Update()
    {
    }

    public virtual IEnumerator Process()
    {
        yield return new WaitForSeconds(12);
        if (TerrahyptianNetwork.TC1CriminalLevel > 10)
        {
            TerrahyptianNetwork.AlertLVL2 = 1;
            this.ReturnSpeech("I am sorry, Pirizuka, \n but you are a wanted criminal.");
            this.convNum = 66;
            WorldInformation.PiriExposed = 32;
            this.PissedAtTC0a = 64;
            this.PissedAtTC1 = 64;
        }
        else
        {
            this.ReturnSpeech("Overseer Pirizuka, \n you are permitted to enter.");
            this.convNum = 63;
            this.boredom = 1;
            WorldInformation.PiriExposed = 32;
            this.PissedAtTC0a = 0;
            this.PissedAtTC1 = 0;
            this.BaseGun1.Suspicion = 0;
            this.BaseGun2.Suspicion = 0;
            this.BaseGun3.Suspicion = 0;
            this.BaseGun4.Suspicion = 0;
            this.BaseGun6.Suspicion = 0;
            this.Ticker();
        }
    }

    public virtual IEnumerator Reminder()
    {
        yield return new WaitForSeconds(20);
        if (this.convNum < 3)
        {
            this.ReturnSpeech("You need to identify yourself! \n You will be swiftly eliminated if you proceed any further!");
        }
    }

    public virtual IEnumerator Reminder2()
    {
        yield return new WaitForSeconds(20);
        if (this.convNum < 3)
        {
            this.ReturnSpeech("Driver, you need to identify yourself! \n You may be marked for elimination.");
            this.boredom = 64;
        }
    }

    public virtual void Ticker()
    {
        if (this.BaseGun1)
        {
            this.BaseGun1.PissedAtTC0a = this.PissedAtTC0a;
            this.BaseGun1.PissedAtTC1 = this.PissedAtTC1;
            this.BaseGun1.PissedAtTC2 = this.PissedAtTC2;
            this.BaseGun1.PissedAtTC3 = this.PissedAtTC3;
            this.BaseGun1.PissedAtTC4 = this.PissedAtTC4;
            this.BaseGun1.PissedAtTC5 = this.PissedAtTC5;
            this.BaseGun1.PissedAtTC6 = this.PissedAtTC6;
            this.BaseGun1.PissedAtTC7 = this.PissedAtTC7;
            this.BaseGun1.PissedAtTC8 = this.PissedAtTC8;
            this.BaseGun1.PissedAtTC9 = this.PissedAtTC9;
        }
        if (this.BaseGun2)
        {
            this.BaseGun2.PissedAtTC0a = this.PissedAtTC0a;
            this.BaseGun2.PissedAtTC1 = this.PissedAtTC1;
            this.BaseGun2.PissedAtTC2 = this.PissedAtTC2;
            this.BaseGun2.PissedAtTC3 = this.PissedAtTC3;
            this.BaseGun2.PissedAtTC4 = this.PissedAtTC4;
            this.BaseGun2.PissedAtTC5 = this.PissedAtTC5;
            this.BaseGun2.PissedAtTC6 = this.PissedAtTC6;
            this.BaseGun2.PissedAtTC7 = this.PissedAtTC7;
            this.BaseGun2.PissedAtTC8 = this.PissedAtTC8;
            this.BaseGun2.PissedAtTC9 = this.PissedAtTC9;
        }
        if (this.BaseGun3)
        {
            this.BaseGun3.PissedAtTC0a = this.PissedAtTC0a;
            this.BaseGun3.PissedAtTC1 = this.PissedAtTC1;
            this.BaseGun3.PissedAtTC2 = this.PissedAtTC2;
            this.BaseGun3.PissedAtTC3 = this.PissedAtTC3;
            this.BaseGun3.PissedAtTC4 = this.PissedAtTC4;
            this.BaseGun3.PissedAtTC5 = this.PissedAtTC5;
            this.BaseGun3.PissedAtTC6 = this.PissedAtTC6;
            this.BaseGun3.PissedAtTC7 = this.PissedAtTC7;
            this.BaseGun3.PissedAtTC8 = this.PissedAtTC8;
            this.BaseGun3.PissedAtTC9 = this.PissedAtTC9;
        }
        if (this.BaseGun4)
        {
            this.BaseGun4.PissedAtTC0a = this.PissedAtTC0a;
            this.BaseGun4.PissedAtTC1 = this.PissedAtTC1;
            this.BaseGun4.PissedAtTC2 = this.PissedAtTC2;
            this.BaseGun4.PissedAtTC3 = this.PissedAtTC3;
            this.BaseGun4.PissedAtTC4 = this.PissedAtTC4;
            this.BaseGun4.PissedAtTC5 = this.PissedAtTC5;
            this.BaseGun4.PissedAtTC6 = this.PissedAtTC6;
            this.BaseGun4.PissedAtTC7 = this.PissedAtTC7;
            this.BaseGun4.PissedAtTC8 = this.PissedAtTC8;
            this.BaseGun4.PissedAtTC9 = this.PissedAtTC9;
        }
        if (this.BaseGun5)
        {
            this.BaseGun5.PissedAtTC0a = this.PissedAtTC0a;
            this.BaseGun5.PissedAtTC1 = this.PissedAtTC1;
            this.BaseGun5.PissedAtTC2 = this.PissedAtTC2;
            this.BaseGun5.PissedAtTC3 = this.PissedAtTC3;
            this.BaseGun5.PissedAtTC4 = this.PissedAtTC4;
            this.BaseGun5.PissedAtTC5 = this.PissedAtTC5;
            this.BaseGun5.PissedAtTC6 = this.PissedAtTC6;
            this.BaseGun5.PissedAtTC7 = this.PissedAtTC7;
            this.BaseGun5.PissedAtTC8 = this.PissedAtTC8;
            this.BaseGun5.PissedAtTC9 = this.PissedAtTC9;
        }
        if (this.BaseGun6)
        {
            this.BaseGun6.PissedAtTC0a = this.PissedAtTC0a;
            this.BaseGun6.PissedAtTC1 = this.PissedAtTC1;
            this.BaseGun6.PissedAtTC2 = this.PissedAtTC2;
            this.BaseGun6.PissedAtTC3 = this.PissedAtTC3;
            this.BaseGun6.PissedAtTC4 = this.PissedAtTC4;
            this.BaseGun6.PissedAtTC5 = this.PissedAtTC5;
            this.BaseGun6.PissedAtTC6 = this.PissedAtTC6;
            this.BaseGun6.PissedAtTC7 = this.PissedAtTC7;
            this.BaseGun6.PissedAtTC8 = this.PissedAtTC8;
            this.BaseGun6.PissedAtTC9 = this.PissedAtTC9;
        }
        if (this.Ogle > 0)
        {
            this.Ogle = this.Ogle - 1;
        }
        if (!TCChanger.TCName.Contains("2"))
        {
            if (Vector3.Distance(this.thisTransform.position, PlayerInformation.instance.Pirizuka.position) < 1024)
            {
                this.target = PlayerInformation.instance.PiriTarget;
                if (TCChanger.TCName.Contains("3"))
                {
                    if ((this.Ogle < 1) && (this.convNum < 4))
                    {
                        this.Ogle = 120;
                        this.convNum = 2;
                        this.ReturnSpeech("Driver, what is your identification?");
                        this.StartCoroutine(this.Reminder2());
                    }
                    if (this.convNum == 63)
                    {
                        WorldInformation.PiriExposed = 32;
                    }
                }
                else
                {
                    if ((this.Ogle < 1) && (this.convNum < 4))
                    {
                        this.Ogle = 120;
                        this.convNum = 2;
                        this.ReturnSpeech("Traveler, you are entering restricted area, \n identify yourself or you will be killed!");
                        this.StartCoroutine(this.Reminder());
                    }
                    if (this.convNum == 63)
                    {
                        WorldInformation.PiriExposed = 32;
                    }
                }
            }
            else
            {
                if (this.convNum == 63)
                {
                    this.ReturnSpeech("When you come back, \n you need to identify yourself again.");
                    this.convNum = 1;
                }
                if (this.convNum == 16)
                {
                    this.convNum = 1;
                }
            }
        }
        if (Vector3.Distance(this.thisTransform.position, PlayerInformation.instance.Pirizuka.position) < 330)
        {
            if (this.convNum < 32)
            {
                this.BaseGun1.target = this.target;
                this.BaseGun2.target = this.target;
                this.BaseGun3.target = this.target;
                this.BaseGun4.target = this.target;
                this.BaseGun6.target = this.target;
            }
            if (this.boredom > 32)
            {
                this.BaseGun1.Suspicion = 31;
                this.BaseGun2.Suspicion = 31;
                this.BaseGun3.Suspicion = 31;
                this.BaseGun4.Suspicion = 31;
                this.BaseGun6.Suspicion = 31;
            }
        }
        if (Vector3.Distance(this.thisTransform.position, PlayerInformation.instance.Pirizuka.position) < 700)
        {
            if (this.convNum < 32)
            {
                this.BaseGun5.target = this.target;
            }
            if (this.convNum == 63)
            {
                this.convNum = 64;
                WorldInformation.PiriExposed = 32;
            }
            if (this.convNum == 64)
            {
                WorldInformation.PiriExposed = 32;
            }
        }
        else
        {
            if (this.convNum == 64)
            {
                this.convNum = 16;
                this.boredom = 5;
                this.ReturnSpeech("When you come back, \n you need to identify yourself again.");
            }
        }
        if (WorldInformation.bigMissile1 != null)
        {
            if (Vector3.Distance(this.thisTransform.position, WorldInformation.bigMissile1.position) < 1024)
            {
                this.BaseGun6.target = WorldInformation.bigMissile1;
            }
        }
        //========================================================================================================================//
        //////////////////////////////////////////////////////[INTERACTION]/////////////////////////////////////////////////////////
        //========================================================================================================================//
        if (NotiScript.PiriNotis)
        {
            if (this.convNum > 1)
            {
                if (Vector3.Distance(this.thisTransform.position, PlayerInformation.instance.Pirizuka.position) < 1024)
                {
                    this.target = PlayerInformation.instance.PiriTarget;
                    this.Ogle = 30;
                    NotiScript.PiriNotis = false;
                }
            }
        }
        if (this.Ogle > 0)
        {
            if (WorldInformation.pSpeech)
            {
                if (Vector3.Distance(this.thisTransform.position, WorldInformation.pSpeech.position) < 1024)
                {
                    this.StartCoroutine(this.ProcessSpeech(TalkBubbleScript.myText, 0, 0));
                }
                WorldInformation.pSpeech = null;
            }
        }
    }

    //========================================================================================================================//
    //////////////////////////////////////////////////////[INTERACTION]/////////////////////////////////////////////////////////
    //========================================================================================================================//
    public int convNum;
    public int boredom;
    public virtual IEnumerator ProcessSpeech(string speech, int mode, int code)
    {
        yield return new WaitForSeconds(0.1f);
        if (!!string.IsNullOrEmpty(speech))
        {
            yield break;
        }
        if (this.convNum == 2)
        {
            //===============================================================================
            if (speech.Contains("pirizuka") && speech.Contains("overseer"))
            {
                this.convNum = 4;
                this.Ogle = 20;
                this.boredom = 4;
                yield return new WaitForSeconds(4);
                this.ReturnSpeech("Please be patient while we process you.");
                this.StartCoroutine(this.Process());
                yield break;
            }
            if (speech.Contains("pirizuka"))
            {
                this.convNum = 3;
                this.Ogle = 20;
                yield return new WaitForSeconds(8);
                this.ReturnSpeech("Are you an overseer?");
                yield break;
            }
            if (speech.Contains("overseer"))
            {
                this.convNum = 31;
                this.Ogle = 20;
                this.boredom = 4;
                yield return new WaitForSeconds(3);
                this.ReturnSpeech("What is your name?");
                yield break;
            }
        }
        //===============================================================================
        if (this.convNum == 3)
        {
            //===============================================================================
            if ((speech.Contains("ye") || speech.Contains("yu")) || speech.Contains("sure"))
            {
                this.convNum = 4;
                this.Ogle = 20;
                this.boredom = 4;
                yield return new WaitForSeconds(4);
                this.ReturnSpeech("Remain where you are.");
                this.StartCoroutine(this.Process());
                yield break;
            }
            if (speech.Contains("overseer"))
            {
                this.convNum = 4;
                this.Ogle = 20;
                this.boredom = 4;
                yield return new WaitForSeconds(4);
                this.ReturnSpeech("Do not go anywhere.");
                this.StartCoroutine(this.Process());
                yield break;
            }
        }
        //===============================================================================
        if (this.convNum == 16)
        {
            //===============================================================================
            if (speech.Contains("pirizuka") || speech.Contains("overseer"))
            {
                this.convNum = 4;
                this.Ogle = 20;
                this.boredom = 4;
                yield return new WaitForSeconds(4);
                this.ReturnSpeech("Please be patient while we process you.");
                this.StartCoroutine(this.Process());
                yield break;
            }
        }
        //===============================================================================
        if (this.convNum == 31)
        {
            //===============================================================================
            if (speech.Contains("pirizuka"))
            {
                this.convNum = 4;
                this.Ogle = 20;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Remain where you are.");
                this.StartCoroutine(this.Process());
                yield break;
            }
            if (speech.Contains("overseer"))
            {
                this.convNum = 32;
                this.Ogle = 20;
                this.boredom = 4;
                yield return new WaitForSeconds(4);
                this.ReturnSpeech("You need to state your name \n so we can process you!");
                this.StartCoroutine(this.Process());
                yield break;
            }
        }
        //===============================================================================
        if (this.convNum == 32)
        {
            //===============================================================================
            if (speech.Contains("pirizuka"))
            {
                this.convNum = 4;
                this.Ogle = 20;
                yield return new WaitForSeconds(2);
                this.ReturnSpeech("Remain where you are.");
                this.StartCoroutine(this.Process());
                yield break;
            }
        }
        //===============================================================================
        if (this.boredom == 4)
        {
            yield break;
        }
        yield return new WaitForSeconds(4);
        if (this.boredom == 0)
        {
            this.ReturnSpeech("What is your identification?");
        }
        if (this.boredom == 1)
        {
            this.ReturnSpeech("We need an accurate identification!");
        }
        if (this.boredom == 2)
        {
            this.ReturnSpeech("You need to leave. \n If you try to enter, we will eliminate you.");
            this.convNum = 5;
        }
        if (this.convNum == 16)
        {
            this.ReturnSpeech("Please state your proper \n identification again.");
        }
        this.boredom = this.boredom + 1;
    }

    public virtual void ReturnSpeech(string yourText)
    {
        GameObject Load = ((GameObject) Resources.Load("Prefabs/TalkBubble", typeof(GameObject))) as GameObject;
        GameObject TGO = UnityEngine.Object.Instantiate(Load, this.thisTransform.position, Load.transform.rotation);
        TGO.name = "CFC3";
        TalkBubbleScript.myText = yourText;
        ((TalkBubbleScript) TGO.GetComponent(typeof(TalkBubbleScript))).source = this.thisTransform;
    }

}