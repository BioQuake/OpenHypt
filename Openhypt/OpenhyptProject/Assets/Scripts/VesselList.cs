using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using System.Collections;

[System.Serializable]
public class VehicleLinker : object
{
    public string vehicle_id;
    public string vehicle_name;
    public VehicleLinker(string id, string name)
    {
        this.vehicle_id = id;
        this.vehicle_name = name;
    }

}
[System.Serializable]
public partial class VesselList : MonoBehaviour
{
    public string StaticStringOut;
    public VesselList_Scroller VLScroller;
    public static VesselList instance;
    public Transform VLTF;
    public System.Collections.Generic.List<VehicleLinker> unlocked_vehicles;
    public static int offset;
    public GameObject summonButton;
    public GameObject summonButton2;
    public Transform ModelSpawn;
    public GameObject TheModel;
    public virtual void Awake()
    {
        VesselList.instance = this;
    }

    public virtual IEnumerator Start()
    {
        this.StaticStringOut = null;
        yield return 0;
        this.LoadList();
    }

    public virtual void OnDisable()
    {
        this.SaveList();
    }

    public virtual void OnMouseDown()
    {
        this.transform.parent.Translate(Vector3.right * -3);
        this.VLScroller.isActive = false;
    }

    public virtual void StringIn(VehicleLinker vehicle_linker)
    {
        if (!this.ListContains(vehicle_linker))
        {
            this.unlocked_vehicles.Add(vehicle_linker);
            Debug.Log(string.Format("Added {0} to the list with name {1}", vehicle_linker.vehicle_id, vehicle_linker.vehicle_name));
        }
        int i = 0;
        while (i < VesselList_Button.vessel_buttons.Length)
        {
            if (this.unlocked_vehicles.Count <= (i + VesselList.offset))
            {
                break;
            }
            if ((VesselList_Button.vessel_buttons.Length > i) && (VesselList_Button.vessel_buttons[i] != null))
            {
                VesselList_Button.vessel_buttons[i].UpdateUI(this.unlocked_vehicles[i + VesselList.offset].vehicle_name);
            }
            i++;
        }
        VesselList_Scroll.UpdateUI();
    }

    public virtual string StringOut()
    {
        if (VesselList_Button.selected_index > -1)
        {
            return this.StringOut_I(VesselList_Button.selected_index + VesselList.offset);
        }
        return null;
    }

    public virtual string StringOut_I(int index)
    {
        return this.unlocked_vehicles[index].vehicle_id;
    }

    public virtual bool IsVehicleInspect(string display_string)
    {
        return display_string.Contains("Vessel");
    }

    private bool ListContains(VehicleLinker vehicle_linker)
    {
        int i = 0;
        i = 0;
        while (i < this.unlocked_vehicles.Count)
        {
            if (this.unlocked_vehicles[i].vehicle_id == vehicle_linker.vehicle_id)
            {
                return true;
            }
            i++;
        }
        return false;
    }

    public static VehicleLinker GetVehicle(int index)
    {
        return VesselList.instance.unlocked_vehicles[index];
    }

    public static int Count()
    {
        return VesselList.instance.unlocked_vehicles.Count;
    }

    public static void UpdateSummonButton()
    {
        VesselList.instance.summonButton.SetActive(VesselList_Button.selected_button != null);
        VesselList.instance.summonButton2.SetActive(VesselList_Button.selected_button != null);
        VesselList.instance.UpdateModel();
    }

    public virtual void UpdateModel()
    {
        if (this.TheModel)
        {
            UnityEngine.Object.Destroy(this.TheModel);
        }
        GameObject Prefabionaise = ((GameObject) Resources.Load("VesselSilhouettes/S" + VesselList.instance.StringOut(), typeof(GameObject))) as GameObject;
        if (Prefabionaise)
        {
            this.TheModel = UnityEngine.Object.Instantiate(Prefabionaise, this.ModelSpawn.position, this.ModelSpawn.rotation);
            Transform MTF = this.TheModel.transform;
            MTF.parent = this.ModelSpawn.parent;
            MTF.localScale = new Vector3(MTF.localScale.x / 14, MTF.localScale.y / 14, MTF.localScale.z / 14);
        }
    }

    public virtual void SaveList()
    {
        XmlDocument xml_document = new XmlDocument();
        xml_document.LoadXml(string.Format("<Vessels {0}=\"{1}\"></Vessels>", "zerahypt_version", WorldInformation.VersionID));
        //XmlNode node_items = xml_document.GetElementsByTagName("Vessels").get_ItemOf(0);
        XmlNode node_items = xml_document.GetElementsByTagName("Vessels").Item(0);
        int i = 0;
        while (i < this.unlocked_vehicles.Count)
        {
            XmlElement new_item = xml_document.CreateElement("Item");
            new_item.SetAttribute("id", this.unlocked_vehicles[i].vehicle_id);
            new_item.SetAttribute("name", this.unlocked_vehicles[i].vehicle_name);
            node_items.AppendChild(new_item);
            i++;
        }
        SaveInfo.SaveDataXml(this.GetKey(), xml_document);
    }

    public virtual void LoadList()
    {
        if (!SaveInfo.HasData(this.GetKey()))
        {
            Debug.Log("VesselList empty, didnt load any data.");
            return;
        }
        string xml_data = SaveInfo.LoadData(this.GetKey());
        XmlDocument xml_document = new XmlDocument();
        xml_document.LoadXml(xml_data);
        //XmlNode node_items = xml_document.GetElementsByTagName("Vessels").get_ItemOf(0);
        XmlNode node_items = xml_document.GetElementsByTagName("Vessels").Item(0);
        System.Collections.Generic.Dictionary<string, string> data_header = this.GetAttributes(node_items);
        if (data_header["zerahypt_version"] == WorldInformation.VersionID)
        {
            this.unlocked_vehicles.Clear();
            foreach (XmlNode node in node_items.ChildNodes)
            {
                System.Collections.Generic.Dictionary<string, string> attributes = this.GetAttributes(node);
                string vehicle_id = attributes["id"];
                string vehicle_name = attributes["name"];
                this.StringIn(new VehicleLinker(vehicle_id, vehicle_name));
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

    public virtual string GetKey()
    {
        return "Vessels/List";
    }

    public VesselList()
    {
        this.unlocked_vehicles = new List<VehicleLinker>();
    }

}