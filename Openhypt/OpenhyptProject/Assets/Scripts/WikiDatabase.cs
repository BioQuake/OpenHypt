using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class WikiDatabase : MonoBehaviour
{
    public TextMesh infoText;
    public TextMesh searchText;
    public GameObject UIFXpost;
    public GameObject UIFXmain;
    public GameObject UIFXselection1;
    public GameObject UIFXselection2;
    public GameObject UIIconLoad;
    public AudioSource SFX;
    public AudioClip onSFX;
    public AudioClip activeSFX;
    public AudioClip actionSFX;
    public bool isNear;
    public bool isOn;
    public bool isUsingSearch;
    public bool isUsingBrowse;
    public string[] Lines;
    public int totalLines;
    public int ScrollPos;
    public virtual void Start()
    {
        this.UIFXpost.SetActive(false);
        this.UIFXmain.SetActive(false);
        this.UIFXselection2.SetActive(false);
        this.UIIconLoad.SetActive(false);
        this.isUsingSearch = true;
        this.isUsingBrowse = false;
        this.searchText.text = null;
        this.infoText.text = null;
    }

    public virtual void Update()
    {
        if (!this.isOn)
        {
            if (Input.GetKeyDown("e"))
            {
                if (this.isNear)
                {
                    this.StartCoroutine(this.TurnOn());
                }
            }
        }
        if (this.isOn)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                this.isUsingSearch = true;
                this.isUsingBrowse = false;
                this.UIFXselection1.SetActive(true);
                this.UIFXselection2.SetActive(false);
                this.Lines = new string[] {};
                this.searchText.text = "No input.";
                this.infoText.text = "No output.";
                this.SFX.PlayOneShot(this.actionSFX);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                this.isUsingSearch = false;
                this.isUsingBrowse = true;
                this.UIFXselection1.SetActive(false);
                this.UIFXselection2.SetActive(true);
                this.StartCoroutine(this.InitializeDTXT());
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                this.StartCoroutine(this.InitializeTXT());
            }
            if (this.isUsingSearch)
            {
                if (Input.GetAxis("Mouse ScrollWheel") < 0f)
                {
                    this.ScrollPos = this.ScrollPos + 4;
                    if (this.ScrollPos > (this.Lines.Length - this.totalLines))
                    {
                        this.ScrollPos = this.Lines.Length - this.totalLines;
                    }
                    if (this.ScrollPos < 0)
                    {
                        this.ScrollPos = 0;
                    }
                    this.UpdateTXT();
                }
                if (Input.GetAxis("Mouse ScrollWheel") > 0f)
                {
                    this.ScrollPos = this.ScrollPos - 4;
                    if (this.ScrollPos < 0)
                    {
                        this.ScrollPos = 0;
                    }
                    this.UpdateTXT();
                }
            }
            if (this.isUsingBrowse)
            {
                if (Input.GetAxis("Mouse ScrollWheel") < 0f)
                {
                    this.ScrollPos = this.ScrollPos + 4;
                    if (this.ScrollPos > (this.Lines.Length - this.totalLines))
                    {
                        this.ScrollPos = this.Lines.Length - this.totalLines;
                    }
                    if (this.ScrollPos < 0)
                    {
                        this.ScrollPos = 0;
                    }
                    this.UpdateTXT();
                }
                if (Input.GetAxis("Mouse ScrollWheel") > 0f)
                {
                    this.ScrollPos = this.ScrollPos - 4;
                    if (this.ScrollPos < 0)
                    {
                        this.ScrollPos = 0;
                    }
                    this.UpdateTXT();
                }
            }
        }
    }

    public virtual IEnumerator InitializeTXT()
    {
        this.SFX.PlayOneShot(this.actionSFX);
        TextAsset ta = null;
        yield return new WaitForSeconds(0.1f);
        if (!WorldInformation.PopUp)
        {
            yield break;
        }
        this.ScrollPos = 0;
        ta = null;
        string tBST = TalkBubbleScript.myText;
        yield return new WaitForSeconds(0.1f);
        ta = ((TextAsset) Resources.Load("WikiDatabase/" + tBST, typeof(TextAsset))) as TextAsset;
        this.searchText.text = tBST;
        if (!ta)
        {
            this.Lines = new string[] {"This search inquiry did not yield any results."};
        }
        else
        {
            this.Lines = ta.text.Split(new char[] {"\n"[0]});
        }
        this.UpdateTXT();
    }

    public virtual IEnumerator InitializeDTXT()
    {
        this.SFX.PlayOneShot(this.actionSFX);
        string da = null;
        yield return new WaitForSeconds(0.1f);
        this.ScrollPos = 0;
        da = null;
        if (WorldInformation.instance.objectsScanned)
        {
            da = WorldInformation.DocumentationsStat;
        }
        else
        {
            da = WorldInformation.DocumentationsStat + "\n \nNothing yet to report.";
        }
        this.searchText.text = "Reports of scanned objects";
        this.infoText.text = da;
        this.Lines = da.Split(new char[] {"\n"[0]});
        this.UpdateTXT();
    }

    public virtual void UpdateTXT()
    {
        //infoText.text = "\n".Lines;
        this.infoText.text = "";
        int offset = 0;
        while (offset < this.totalLines)
        {
            int line = this.ScrollPos + offset;
            if (line >= this.Lines.Length)
            {
                break;
            }
            this.infoText.text = this.infoText.text + (this.Lines[line] + "\n");
            offset = offset + 1;
        }
    }

    public virtual IEnumerator TurnOn()
    {
        this.SFX.PlayOneShot(this.onSFX);
        this.UIFXpost.SetActive(true);
        this.UIIconLoad.SetActive(true);
        yield return new WaitForSeconds(2);
        this.SFX.PlayOneShot(this.activeSFX);
        this.UIFXpost.SetActive(false);
        this.UIFXmain.SetActive(true);
        this.UIFXselection1.SetActive(true);
        this.UIFXselection2.SetActive(false);
        this.UIIconLoad.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        this.searchText.text = "No input.";
        this.infoText.text = "No output.";
        this.isOn = true;
    }

    public virtual void TurnOff()
    {
        this.UIFXpost.SetActive(false);
        this.UIFXmain.SetActive(false);
        this.UIFXselection1.SetActive(false);
        this.UIFXselection2.SetActive(false);
        this.UIIconLoad.SetActive(false);
        this.searchText.text = null;
        this.infoText.text = null;
        this.Lines = new string[] {};
        this.ScrollPos = 0;
        this.isOn = false;
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (Vector3.Distance(this.transform.position, other.transform.position) < 16)
        {
            if (other.name.Contains("sTC1p"))
            {
                this.isNear = true;
            }
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("sTC1p"))
        {
            this.isNear = false;
            this.TurnOff();
        }
    }

    public WikiDatabase()
    {
        this.totalLines = 24;
    }

}