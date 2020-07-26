using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class TalkScript : MonoBehaviour
{
    public static bool isTyping;
    public string yourText;
    public TextMesh textObject;
    public ParticleSystem snyfsies;
    public virtual void Start()
    {
    }

    public virtual void Update()
    {
        if (TalkScript.isTyping)
        {
            CameraScript.InInterface = true;
            if (Input.anyKeyDown)
            {
                this.KeyInput();
            }
            if (this.snyfsies.startColor.a < 0.25f)
            {

                {
                    float _3642 = this.snyfsies.startColor.a + 0.01f;
                    Color _3643 = this.snyfsies.startColor;
                    _3643.a = _3642;
                    this.snyfsies.startColor = _3643;
                }
            }
        }
        else
        {
            if (this.snyfsies.startColor.a > 0)
            {

                {
                    float _3644 = this.snyfsies.startColor.a - 0.01f;
                    Color _3645 = this.snyfsies.startColor;
                    _3645.a = _3644;
                    this.snyfsies.startColor = _3645;
                }
            }
        }
    }

    public virtual void KeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameObject Load = ((GameObject) Resources.Load("Prefabs/TalkBubble", typeof(GameObject))) as GameObject;
            GameObject TGO = UnityEngine.Object.Instantiate(Load, PlayerInformation.instance.PiriTarget.position, Load.transform.rotation);
            if (WorldInformation.playerLevel == 0)
            {
                TGO.name = "a1";
                TalkBubbleScript.myText = this.yourText;
                ((TalkBubbleScript) TGO.GetComponent(typeof(TalkBubbleScript))).source = NotiScript.thisTransform;
            }
            if (WorldInformation.playerLevel == 1)
            {
                TGO.name = "b1";
                TalkBubbleScript.myText = this.yourText;
                ((TalkBubbleScript) TGO.GetComponent(typeof(TalkBubbleScript))).source = NotiScript.thisTransform;
            }
            if (WorldInformation.playerLevel == 2)
            {
                TGO.name = "b1";
                TalkBubbleScript.myText = this.yourText;
                ((TalkBubbleScript) TGO.GetComponent(typeof(TalkBubbleScript))).source = NotiScript.thisTransform;
            }
            if (WorldInformation.playerLevel == 3)
            {
                TGO.name = "c1";
                TalkBubbleScript.myText = this.yourText;
                ((TalkBubbleScript) TGO.GetComponent(typeof(TalkBubbleScript))).source = NotiScript.thisTransform;
            }
            if (WorldInformation.playerLevel == 4)
            {
                TGO.name = "d1";
                TalkBubbleScript.myText = this.yourText;
                ((TalkBubbleScript) TGO.GetComponent(typeof(TalkBubbleScript))).source = NotiScript.thisTransform;
            }
            this.yourText = null;

            {
                int _3646 = 1;
                Vector3 _3647 = this.snyfsies.transform.localScale;
                _3647.x = _3646;
                this.snyfsies.transform.localScale = _3647;
            }
            this.snyfsies.emissionRate = 32;
            TalkScript.isTyping = false;
            CameraScript.InInterface = false;
            PlayerMotionAnimator.PiriStill = false;
            Screen.lockCursor = true;
            Cursor.visible = false;
            this.textObject.text = this.yourText;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (!string.IsNullOrEmpty(this.yourText))
            {
                if (this.yourText.Length > 0)
                {
                    this.yourText = this.yourText.Remove(this.yourText.Length - 1);
                }
            }
        }
        if (Input.GetKeyDown("a"))
        {
            this.yourText = this.yourText + "a";
        }
        if (Input.GetKeyDown("b"))
        {
            this.yourText = this.yourText + "b";
        }
        if (Input.GetKeyDown("c"))
        {
            this.yourText = this.yourText + "c";
        }
        if (Input.GetKeyDown("d"))
        {
            this.yourText = this.yourText + "d";
        }
        if (Input.GetKeyDown("e"))
        {
            this.yourText = this.yourText + "e";
        }
        if (Input.GetKeyDown("f"))
        {
            this.yourText = this.yourText + "f";
        }
        if (Input.GetKeyDown("g"))
        {
            this.yourText = this.yourText + "g";
        }
        if (Input.GetKeyDown("h"))
        {
            this.yourText = this.yourText + "h";
        }
        if (Input.GetKeyDown("i"))
        {
            this.yourText = this.yourText + "i";
        }
        if (Input.GetKeyDown("j"))
        {
            this.yourText = this.yourText + "j";
        }
        if (Input.GetKeyDown("k"))
        {
            this.yourText = this.yourText + "k";
        }
        if (Input.GetKeyDown("l"))
        {
            this.yourText = this.yourText + "l";
        }
        if (Input.GetKeyDown("m"))
        {
            this.yourText = this.yourText + "m";
        }
        if (Input.GetKeyDown("n"))
        {
            this.yourText = this.yourText + "n";
        }
        if (Input.GetKeyDown("o"))
        {
            this.yourText = this.yourText + "o";
        }
        if (Input.GetKeyDown("p"))
        {
            this.yourText = this.yourText + "p";
        }
        if (Input.GetKeyDown("q"))
        {
            this.yourText = this.yourText + "q";
        }
        if (Input.GetKeyDown("r"))
        {
            this.yourText = this.yourText + "r";
        }
        if (Input.GetKeyDown("s"))
        {
            this.yourText = this.yourText + "s";
        }
        if (Input.GetKeyDown("t"))
        {
            this.yourText = this.yourText + "t";
        }
        if (Input.GetKeyDown("u"))
        {
            this.yourText = this.yourText + "u";
        }
        if (Input.GetKeyDown("v"))
        {
            this.yourText = this.yourText + "v";
        }
        if (Input.GetKeyDown("w"))
        {
            this.yourText = this.yourText + "w";
        }
        if (Input.GetKeyDown("x"))
        {
            this.yourText = this.yourText + "x";
        }
        if (Input.GetKeyDown("y"))
        {
            this.yourText = this.yourText + "y";
        }
        if (Input.GetKeyDown("z"))
        {
            this.yourText = this.yourText + "z";
        }
        if (Input.GetKeyDown("1"))
        {
            this.yourText = this.yourText + "1";
        }
        if (Input.GetKeyDown("2"))
        {
            this.yourText = this.yourText + "2";
        }
        if (Input.GetKeyDown("3"))
        {
            this.yourText = this.yourText + "3";
        }
        if (Input.GetKeyDown("4"))
        {
            this.yourText = this.yourText + "4";
        }
        if (Input.GetKeyDown("5"))
        {
            this.yourText = this.yourText + "5";
        }
        if (Input.GetKeyDown("6"))
        {
            this.yourText = this.yourText + "6";
        }
        if (Input.GetKeyDown("7"))
        {
            this.yourText = this.yourText + "7";
        }
        if (Input.GetKeyDown("8"))
        {
            this.yourText = this.yourText + "8";
        }
        if (Input.GetKeyDown("9"))
        {
            this.yourText = this.yourText + "9";
        }
        if (Input.GetKeyDown("0"))
        {
            this.yourText = this.yourText + "0";
        }
        if (Input.GetKeyDown("!"))
        {
            this.yourText = this.yourText + "!";
        }
        if (Input.GetKeyDown("?"))
        {
            this.yourText = this.yourText + "?";
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.yourText = this.yourText + " ";
        }
        if (!string.IsNullOrEmpty(this.yourText))
        {
            if (this.yourText.Length > 34)
            {
                this.yourText = this.yourText.Remove(this.yourText.Length - 1);
            }
        }
        this.snyfsies.emissionRate = this.textObject.GetComponent<Renderer>().bounds.size.magnitude * 96;

        {
            float _3648 = this.textObject.GetComponent<Renderer>().bounds.size.magnitude * 5;
            Vector3 _3649 = this.snyfsies.transform.localScale;
            _3649.x = _3648;
            this.snyfsies.transform.localScale = _3649;
        }
        this.textObject.text = this.yourText;
    }

}