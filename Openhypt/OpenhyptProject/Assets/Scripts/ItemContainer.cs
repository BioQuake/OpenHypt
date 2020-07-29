using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using System.Collections;

public enum ItemEnum
{
    empty = 0,
    Ammunition_10mm = 100,
    Ammunition_20mm = 101,
    Ammunition_30mm = 102,
    Ammunition_40mmSK = 103,
    Ammunition_40mmSHE = 104,
    Ammunition_50mm = 105,
    Ammunition_100mmS = 106,
    Ammunition_100mm = 107,
    Ammunition_150mm = 108,
    LEXAM_Short_Missile = 150,
    Jolt_Missile = 151,
    Agrian_Bowl_Lamp = 201,
    Slav_Radio = 202,
    Trumpgun = 250,
    TestGun = 300,
    Anoca_PT13 = 301,
    Posmer_HC40 = 302,
    Posmer_10c = 303,
    Shakar_17 = 304,
    Tothler_Tygria_M2 = 305,
    AROT_Iter_1 = 306,
    BK = 307,
    TLF_PTSD_G1 = 308,
    MevNav_MRCHg = 309,
    Anoca_PT32 = 310,
    Posmer_10cR = 311,
    Metis_CAR_05 = 312,
    DASMUN_SR2 = 313,
    TRN_PTSD_Az = 314,
    Fawcett_Alton = 315,
    Katovari_MD = 316,
    Beverage_See_Cola = 401,
    Slavoico_Vodka = 402,
    Fidget_Spinner = 500,
    Snyf = 600,
    Snyfped = 601,
    Piribunny = 602,
    Agrian_Abettor = 700,
    Radar_Drone = 701,
    TLF_SDRBHc1 = 702,
    Terbotek_Dasinyk = 703,
    TAK_Ml1 = 750,
    Katovari_Motus = 751,
    Peuktuber = 800,
    Peuknyth = 801
}

public enum ItemTypes
{
    None = 0,
    Consumable = 1,
    Weapon = 2,
    Toy = 3,
    LongObject = 4,
    BigObject = 5,
    BigObject2 = 6
}

public enum DataType
{
    None = 0,
    Description = 1
}

public enum SizeEnum
{
    Container = 0,
    Pirizuka = 1
}

[System.Serializable]
public class ItemDisplay : object
{
    public Sprite ItemTexture;
    public GameObject ItemPrefab;
    public GameObject ItemDropPrefab;
    public ItemDisplay()
    {
        this.ItemTexture = null;
        this.ItemPrefab = null;
        this.ItemDropPrefab = null;
    }

    public ItemDisplay(Sprite _texture, GameObject _prefab, GameObject _dropPrefab)
    {
        this.ItemTexture = _texture;
        this.ItemPrefab = _prefab;
        this.ItemDropPrefab = _dropPrefab;
    }

}
[System.Serializable]
public class Item : object
{
    public ItemEnum ID;
    public ItemTypes ItemType;
    public DataType ItemDataType;
    public string ItemData;
    [UnityEngine.HideInInspector]
    public bool Initialized;
    [UnityEngine.HideInInspector]
    public Vector2 location;
    public Item()
    {
        this.ID = (ItemEnum) 0;
        this.ItemType = ItemTypes.None;
        this.ItemData = "";
        this.ItemDataType = DataType.None;
        this.Initialized = true;
    }

    public Item(int id)
    {
        this.ID = (ItemEnum) id;
        this.ItemType = ItemTypes.None;
        this.ItemData = "";
        this.ItemDataType = DataType.None;
        if (this.GetID() > 0)
        {
            this.Initialize();
        }
    }

    public Item(int id, ItemTypes itemType)
    {
        this.ID = (ItemEnum) id;
        this.ItemType = itemType;
        this.ItemData = "";
        this.ItemDataType = DataType.None;
        if (this.GetID() > 0)
        {
            this.Initialize();
        }
    }

    public Item(int id, ItemTypes itemType, string data, DataType dataType)
    {
        this.ID = (ItemEnum) id;
        this.ItemType = itemType;
        this.ItemData = data;
        this.ItemDataType = dataType;
        this.Initialize();
    }

    public virtual void Initialize()
    {
        ItemDisplay display = null;
        if (!InventoryManager.instance.ItemDictionary.ContainsKey(this.GetID()))
        {
            Sprite _itemTexture = (Sprite) Resources.Load(("Items/" + this.ID.ToString()) + "/sprite", typeof(Sprite));
            GameObject _itemPrefab = Resources.Load(("Items/" + this.ID.ToString()) + "/prefab") as GameObject;
            GameObject _itemDropPrefab = Resources.Load(("Items/" + this.ID.ToString()) + "/drop") as GameObject;
            display = new ItemDisplay(_itemTexture, _itemPrefab, _itemDropPrefab);
            InventoryManager.instance.ItemDictionary.Add(this.GetID(), display);
            if (_itemTexture == null)
            {
                Debug.LogWarning(((("Texture File (" + "Resources/Items/") + this.ID.ToString()) + "/sprite") + ") is missing!");
            }
            if (_itemPrefab == null)
            {
                Debug.LogWarning(((("Prefab File (" + "Resources/Items/") + this.ID.ToString()) + "/prefab") + ") is missing!");
            }
            if (_itemDropPrefab == null)
            {
                Debug.LogWarning(((("Prefab File (" + "Resources/Items/") + this.ID.ToString()) + "/drop") + ") is missing!");
            }
        }
        this.Initialized = true;
    }

    public virtual ItemDisplay GetDisplay()
    {
        int key = this.GetID();
        if (InventoryManager.instance.ItemDictionary.ContainsKey(key))
        {
            return InventoryManager.instance.ItemDictionary[key];
        }
        return new ItemDisplay();
    }

    public virtual float GetVolume()
    {
        switch (this.ID)
        {
            case ItemEnum.Ammunition_10mm:
                return 10f;
            case ItemEnum.Ammunition_20mm:
                return 20f;
            case ItemEnum.Ammunition_30mm:
                return 30f;
            case ItemEnum.Ammunition_40mmSK:
                return 30f;
            case ItemEnum.Ammunition_40mmSHE:
                return 30f;
            case ItemEnum.Ammunition_50mm:
                return 50f;
            case ItemEnum.Ammunition_100mmS:
                return 70f;
            case ItemEnum.Ammunition_100mm:
                return 80f;
            case ItemEnum.Ammunition_150mm:
                return 100f;
            case ItemEnum.LEXAM_Short_Missile:
                return 80f;
            case ItemEnum.Jolt_Missile:
                return 50f;
            case ItemEnum.Agrian_Bowl_Lamp:
                return 100f;
            case ItemEnum.Slav_Radio:
                return 100f;
            case ItemEnum.Trumpgun:
                return 100f;
            case ItemEnum.Anoca_PT13:
                return 150f;
            case ItemEnum.Posmer_HC40:
                return 200f;
            case ItemEnum.Posmer_10c:
                return 120f;
            case ItemEnum.Shakar_17:
                return 150f;
            case ItemEnum.Tothler_Tygria_M2:
                return 150f;
            case ItemEnum.AROT_Iter_1:
                return 150f;
            case ItemEnum.BK:
                return 200f;
            case ItemEnum.TLF_PTSD_G1:
                return 120f;
            case ItemEnum.MevNav_MRCHg:
                return 150f;
            case ItemEnum.TestGun:
                return 10f;
            case ItemEnum.Anoca_PT32:
                return 150f;
            case ItemEnum.Posmer_10cR:
                return 150f;
            case ItemEnum.Metis_CAR_05:
                return 150f;
            case ItemEnum.DASMUN_SR2:
                return 200f;
            case ItemEnum.TRN_PTSD_Az:
                return 150f;
            case ItemEnum.Fawcett_Alton:
                return 200f;
            case ItemEnum.Katovari_MD:
                return 200f;
            case ItemEnum.Beverage_See_Cola:
                return 50f;
            case ItemEnum.Slavoico_Vodka:
                return 70f;
            case ItemEnum.Fidget_Spinner:
                return 25f;
            case ItemEnum.Snyf:
                return 50f;
            case ItemEnum.Snyfped:
                return 60f;
            case ItemEnum.Piribunny:
                return 80f;
            case ItemEnum.Agrian_Abettor:
                return 150f;
            case ItemEnum.Radar_Drone:
                return 200f;
            case ItemEnum.TLF_SDRBHc1:
                return 170f;
            case ItemEnum.Terbotek_Dasinyk:
                return 200f;
            case ItemEnum.TAK_Ml1:
                return 400f;
            case ItemEnum.Katovari_Motus:
                return 400f;
            case ItemEnum.Peuktuber:
                return 50f;
            case ItemEnum.Peuknyth:
                return 60f;
            default:
                return 1f;
                break;
        }
    }

    public virtual int GetID()
    {
        int _id = (int) this.ID;
        return _id;
    }

}
[System.Serializable]
public partial class ItemContainer : MonoBehaviour
{
    public int ContainerID;
    public float MaxLoad;
    public SizeEnum ContainerSize;
    public System.Collections.Generic.List<Item> ContainerItems;
    public bool ResetItemsToPreset;
    public static ItemContainer PlayerContainer;
    public static ItemContainer PiriContainer;
    //InvokeRepeating("Refresher", 0.43, 0.45);
    public virtual void Awake()
    {
        if (this.ContainerID == -1)
        {
            Debug.LogError("Please give this container an ID!", this);
        }
    }

    public virtual void Start()
    {
        if (!this.ResetItemsToPreset)
        {
            this.LoadContainer();
        }
        switch (this.ContainerSize)
        {
            case SizeEnum.Pirizuka:
                ItemContainer.PiriContainer = this;
                this.CreatePiriSlot();
                break;
            case SizeEnum.Container:
                break;
        }
    }

    public virtual void CreatePiriSlot()
    {
        if (ItemContainer.PiriContainer.ContainerItems.Count > 0)
        {
            InventoryManager im = InventoryManager.instance;
            GameObject item_slot_prefab = Resources.Load("Prefabs/[Inventory_Item]") as GameObject;
            GameObject item_slot = UnityEngine.Object.Instantiate(item_slot_prefab) as GameObject;
            item_slot.name = "[Inventory_Hand_Item]";
            item_slot.transform.parent = im.transform;
            item_slot.transform.position = im.piri_hand_slot.position;
            item_slot.transform.localPosition = item_slot.transform.localPosition + new Vector3(0, 0, -0.25f);
            ((ItemDraw) item_slot.GetComponent(typeof(ItemDraw))).UpdateIcon(ItemContainer.PiriContainer, true, 0);
            if (!InventoryManager.container_opened)
            {
                item_slot.SetActive(false);
            }
        }
    }

    public virtual void DeletePiriSlot()
    {
        if (ItemContainer.PiriContainer.ContainerItems.Count > 0)
        {
            InventoryManager im = InventoryManager.instance;
            UnityEngine.Object.Destroy(ItemDraw.hand_instance.gameObject);
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (!WorldInformation.UsingVessel)
        {
            if (other.name.Contains("TC1p"))
            {
                ItemContainer.PlayerContainer = this;
            }
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (!WorldInformation.UsingVessel)
        {
            if (other.name.Contains("TC1p"))
            {
                InventoryManager.instance.SetChildActive(false);
                ItemContainer.PlayerContainer = null;
                CameraScript.InInterface = false;
                PlayerMotionAnimator.PiriStill = false;
                Screen.lockCursor = true;
                Cursor.visible = false;
            }
        }
        if (other.name.Contains("broken"))
        {
            InventoryManager.instance.SetChildActive(false);
            ItemContainer.PlayerContainer = null;
            CameraScript.InInterface = false;
            PlayerMotionAnimator.PiriStill = false;
            Screen.lockCursor = true;
            Cursor.visible = false;
        }
    }

    public virtual void SaveContainer()
    {
        XmlDocument xml_document = new XmlDocument();
        xml_document.LoadXml(string.Format("<Items {0}=\"{1}\"></Items>", "zerahypt_version", WorldInformation.VersionID));
        //XmlNode node_items = xml_document.GetElementsByTagName("Items").get_ItemOf(0);
        XmlNode node_items = xml_document.GetElementsByTagName("Items").Item(0);
        int i = 0;
        while (i < this.ContainerItems.Count)
        {
            int _dataType = (int) this.ContainerItems[i].ItemDataType;
            int _itemType = (int) this.ContainerItems[i].ItemType;
            XmlElement new_item = xml_document.CreateElement("Item");
            new_item.SetAttribute("id", this.ContainerItems[i].GetID().ToString());
            new_item.SetAttribute("itemtype", _itemType.ToString());
            new_item.SetAttribute("datatype", _dataType.ToString());
            new_item.SetAttribute("data", this.ContainerItems[i].ItemData);
            new_item.SetAttribute("x", this.ContainerItems[i].location.x.ToString());
            new_item.SetAttribute("y", this.ContainerItems[i].location.y.ToString());
            node_items.AppendChild(new_item);
            i++;
        }
        SaveInfo.SaveDataXml(this.GetKey(), xml_document);
    }

    public virtual void LoadContainer()
    {
        if (!SaveInfo.HasData(this.GetKey()))
        {
            Debug.Log("Container empty, didnt load any data.");
            return;
        }
        string xml_data = SaveInfo.LoadData(this.GetKey());
        XmlDocument xml_document = new XmlDocument();
        xml_document.LoadXml(xml_data);
        //XmlNode node_items = xml_document.GetElementsByTagName("Items").get_ItemOf(0);
        XmlNode node_items = xml_document.GetElementsByTagName("Items").Item(0);
        System.Collections.Generic.Dictionary<string, string> data_header = this.GetAttributes(node_items);
        if (data_header["zerahypt_version"] == WorldInformation.VersionID)
        {
            this.ContainerItems.Clear();
            foreach (XmlNode node in node_items.ChildNodes)
            {
                System.Collections.Generic.Dictionary<string, string> attributes = this.GetAttributes(node);
                int id = int.Parse(attributes["id"]);
                ItemTypes itemtype = (ItemTypes) int.Parse(attributes["itemtype"]);
                DataType datatype = (DataType) int.Parse(attributes["datatype"]);
                string data = attributes["data"];
                float x = float.Parse(attributes["x"]);
                float y = float.Parse(attributes["y"]);
                Item newItem = new Item(id, itemtype, data, datatype);
                newItem.location = new Vector2(x, y);
                this.Add(newItem);
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

    public virtual bool DoesFit(Item item)
    {
        float sum = 0f;
        int i = 0;
        while (i < this.ContainerItems.Count)
        {
            sum = sum + this.ContainerItems[i].GetVolume();
            i++;
        }
        return (sum + item.GetVolume()) < this.MaxLoad;
    }

    public virtual void Add(Item newItem)
    {
        this.ContainerItems.Add(newItem);
    }

    public virtual void Refresher()
    {
        if (!this.ResetItemsToPreset)
        {
            this.SaveContainer();
        }
    }

    public virtual void OnDisable()
    {
        if (!this.ResetItemsToPreset)
        {
            this.SaveContainer();
        }
    }

    public virtual string GetKey()
    {
        return "ItemContainers/" + this.ContainerID;
    }

    public ItemContainer()
    {
        this.ContainerID = -1;
        this.MaxLoad = 600;
        this.ContainerItems = new List<Item>();
    }

}