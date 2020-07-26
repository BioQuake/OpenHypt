using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class FolderInfoDisplayer : MonoBehaviour
{
    public static FolderInfoDisplayer instance;
    public System.Collections.Generic.List<GameObject> pages;
    public int CurrentPage;
    public Camera UIcam;
    public GameObject InstantiatedPage;
    public Transform PageSpawn;
    public PageZoomScript Zoomer;
    private bool loaded;
    public virtual void Awake()
    {
        FolderInfoDisplayer.instance = this;
    }

    public virtual void Start()
    {
        this.LoadList();
    }

    public virtual void SaveList()
    {
        System.Collections.Generic.List<string> names = new List<string>();
        foreach (GameObject page in this.pages)
        {
            names.Add(page.name);
        }
        XmlDocument xml_document = new XmlDocument();
        xml_document.LoadXml(string.Format("<Pages {0}=\"{1}\"></Pages>", "zerahypt_version", WorldInformation.VersionID));
        //XmlNode node_items = xml_document.GetElementsByTagName("Pages").get_ItemOf(0);
        XmlNode node_items = xml_document.GetElementsByTagName("Pages").Item(0);
        int i = 0;
        while (i < names.Count)
        {
            XmlElement new_item = xml_document.CreateElement("Page");
            new_item.SetAttribute("name", names[i]);
            node_items.AppendChild(new_item);
            i++;
        }
        SaveInfo.SaveDataXml("Folder/Pages", xml_document);
    }

    public virtual void LoadList()
    {
        if (!SaveInfo.HasData("Folder/Pages"))
        {
            Debug.Log("Pages empty, didnt load any data.");
            return;
        }
        string xml_data = SaveInfo.LoadData("Folder/Pages");
        XmlDocument xml_document = new XmlDocument();
        xml_document.LoadXml(xml_data);
        //XmlNode node_items = xml_document.GetElementsByTagName("Pages").get_ItemOf(0);
        XmlNode node_items = xml_document.GetElementsByTagName("Pages").Item(0);
        System.Collections.Generic.Dictionary<string, string> data_header = this.GetAttributes(node_items);
        if (data_header["zerahypt_version"] == WorldInformation.VersionID)
        {
            this.pages.Clear();
            foreach (XmlNode node in node_items.ChildNodes)
            {
                System.Collections.Generic.Dictionary<string, string> attributes = this.GetAttributes(node);
                GameObject Prefabionaise = ((GameObject) Resources.Load("Pages/" + attributes["name"], typeof(GameObject))) as GameObject;
                this.pages.Add(Prefabionaise);
            }
        }
    }

    public virtual System.Collections.Generic.Dictionary<string, string> GetAttributes(XmlNode xml_node)
    {
        System.Collections.Generic.Dictionary<string, string> attributes = new Dictionary<string, string>();
        foreach (XmlAttribute att in xml_node.Attributes)
        {
            attributes.Add(att.Name, att.Value);
        }
        return attributes;
    }

    public static void ListContains(string name)
    {
        bool Add = false;
        int i = 0;
        GameObject Prefabionaise = ((GameObject) Resources.Load("Pages/" + name, typeof(GameObject))) as GameObject;
        if (FolderInfoDisplayer.instance.pages.Count > 0)
        {
            Add = true;
            i = 0;
            while (i < FolderInfoDisplayer.instance.pages.Count)
            {
                if (FolderInfoDisplayer.instance.pages[i].name == name)
                {
                    Add = false;
                    FurtherActionScript.instance.NoDocument = true;
                    FurtherActionScript.instance.ShowText();
                }
                i++;
            }
        }
        if (FolderInfoDisplayer.instance.pages.Count < 1)
        {
            FolderInfoDisplayer.instance.pages.Add(Prefabionaise);
        }
        if (Add)
        {
            FolderInfoDisplayer.instance.AddPage(Prefabionaise);
            FurtherActionScript.instance.NewDocument = true;
            FurtherActionScript.instance.ShowText();
        }
    }

    public virtual void AddPage(GameObject Prefabionaision)
    {
        this.pages.Add(Prefabionaision);
    }

    public virtual void OnMouseDown()
    {
        if (Input.mousePosition.x > this.UIcam.WorldToScreenPoint(this.transform.position).x)
        {
            if (this.CurrentPage < (this.pages.Count - 1))
            {
                this.CurrentPage = this.CurrentPage + 1;
                this.Pagionaise();
            }
        }
        else
        {
            if (this.CurrentPage > 0)
            {
                this.CurrentPage = this.CurrentPage - 1;
                this.Pagionaise();
            }
        }
    }

    public virtual void Pagionaise()
    {
        if (this.InstantiatedPage != null)
        {
            UnityEngine.Object.Destroy(this.InstantiatedPage);
        }
        TextMesh tm = (TextMesh) this.GetComponent(typeof(TextMesh));
        GameObject PageToSpawn = this.pages[this.CurrentPage];
        this.InstantiatedPage = UnityEngine.Object.Instantiate(PageToSpawn, this.PageSpawn.transform.position, this.PageSpawn.transform.rotation) as GameObject;
        this.InstantiatedPage.transform.parent = this.gameObject.transform;
        this.InstantiatedPage.name = PageToSpawn.name;
        this.Zoomer.PageTF = this.InstantiatedPage.transform;
        tm.text = PageToSpawn.name;
    }

    public virtual void PutUp()
    {
        this.Zoomer.IsActivated = true;
    }

    public virtual void PutDown()
    {
        this.Zoomer.Reset();
    }

    public virtual void OnDestroy()
    {
        this.SaveList();
    }

    public FolderInfoDisplayer()
    {
        this.pages = new List<GameObject>();
    }

}