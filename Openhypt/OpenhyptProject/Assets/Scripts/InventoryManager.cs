using System.Collections.Generic;
using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public static Vector2 MouseOffset;
    public Transform piri_hand_slot;
    public TextMesh Weight_Text;
    public Vector3 Bounds_TopLeft;
    public Vector3 Bounds_BottomRight;
    public Vector2 Item_Padding;
    public Vector2 Item_Size;
    public GameObject MenuGraphics;
    public string IdleAnimation;
    public string DropAnimation;
    public Animation Pirizuka;
    public Transform PirizukaHand;
    public Transform PirizukaHandCan;
    public Transform PirizukaWeapon;
    public Transform PirizukaToy;
    public TextMesh ItemIndicator;
    public LayerMask targetLayers;
    [UnityEngine.HideInInspector]
    public GameObject CarryObject;
    public System.Collections.Generic.Dictionary<int, ItemDisplay> ItemDictionary;
    public bool UseMouseOffsetWhenDragging;
    private bool dropping;
    public virtual void OnDrawGizmos()
    {
        Vector3 pos_a = this.transform.position + this.Bounds_TopLeft;
        Vector3 pos_b = this.transform.position + this.Bounds_BottomRight;
        Gizmos.color = Color.clear;
        Gizmos.DrawWireCube(Vector3.Lerp(pos_a, pos_b, 0.5f), pos_b - pos_a);
        Vector3 item_width = new Vector3(this.Item_Size.x, 0);
        Vector3 item_height = new Vector3(0, this.Item_Size.y);
        Vector3 pos = ((this.transform.position + this.Bounds_TopLeft) + (item_width / 2f)) - (item_height / 2f);
        int max_on_one_line = (int) (((this.Bounds_BottomRight.x - this.Bounds_TopLeft.x) + this.Item_Padding.x) / (item_width.x + this.Item_Padding.x));
        int max_lines = (int) (((this.Bounds_TopLeft.y - this.Bounds_BottomRight.y) + this.Item_Padding.y) / (item_height.y + this.Item_Padding.y));
        int item_count = Mathf.Clamp(100, 0, max_on_one_line * max_lines);
        int i = 0;
        while (i < item_count)
        {
            int height_offset = item_count / max_on_one_line;
            Gizmos.DrawWireCube((pos + ((item_width + new Vector3(this.Item_Padding.x, 0)) * (i % max_on_one_line))) - ((item_height + new Vector3(0, this.Item_Padding.y)) * (i / max_on_one_line)), this.Item_Size);
            i++;
        }
    }

    public virtual void Awake()
    {
        InventoryManager.instance = this;
    }

    public virtual IEnumerator Start()
    {
        //Wait for all the other scripts to initialize.
        yield return 0;
        this.Pirizuka = PlayerInformation.instance.PiriAni;
        this.PirizukaHand = PlayerInformation.instance.PiriHeldThing;
        this.PirizukaWeapon = PlayerInformation.instance.PiriHeldWeapon;
        this.PirizukaToy = PlayerInformation.instance.PiriHeldToy;
        InventoryManager.instance.SetChildActive(false);
        this.UpdateHand();
        Debug.Log("InventoryManager Initialized!");
    }

    public virtual void RefreshItems(ItemContainer item_container)
    {
        int i = 0;
        float item_space_sum = 0.0f;
        Vector3 position = default(Vector3);
        i = 0;
        while (i < this.transform.childCount)
        {
            if (this.transform.GetChild(i).name.Contains("[Inventory_Item]"))
            {
                UnityEngine.Object.Destroy(this.transform.GetChild(i).gameObject);
            }
            i++;
        }
        int item_count = item_container.ContainerItems.Count;
        Vector3 item_width = new Vector3(this.Item_Size.x, 0);
        Vector3 item_height = new Vector3(0, this.Item_Size.y);
        Vector3 pos = ((this.transform.position + this.Bounds_TopLeft) + (item_width / 2f)) - (item_height / 2f);
        int max_on_one_line = (int) (((this.Bounds_BottomRight.x - this.Bounds_TopLeft.x) + this.Item_Padding.x) / (item_width.x + this.Item_Padding.x));
        int max_lines = (int) (((this.Bounds_TopLeft.y - this.Bounds_BottomRight.y) + this.Item_Padding.y) / (item_height.y + this.Item_Padding.y));
        GameObject item_slot_prefab = Resources.Load("Prefabs/[Inventory_Item]") as GameObject;
        item_count = Mathf.Clamp(item_count, 0, max_on_one_line * max_lines);
        i = 0;
        while (i < item_count)
        {
            int height_offset = item_count / max_on_one_line;
            Vector3 local_pos = item_container.ContainerItems[i].location;
            GameObject item_slot = null;
            if (local_pos == Vector3.zero)
            {
                position = (pos + ((item_width + new Vector3(this.Item_Padding.x, 0)) * (i % max_on_one_line))) - ((item_height + new Vector3(0, this.Item_Padding.y)) * (i / max_on_one_line));
                item_slot = UnityEngine.Object.Instantiate(item_slot_prefab, position - new Vector3(0, 0, 0.3f), Quaternion.identity) as GameObject;
                item_slot.transform.parent = this.transform;
            }
            else
            {
                position = new Vector3(local_pos.x, local_pos.y, -0.25f);
                item_slot = UnityEngine.Object.Instantiate(item_slot_prefab) as GameObject;
                item_slot.transform.parent = this.transform;
                item_slot.transform.localPosition = position;
            }
            ((ItemDraw) item_slot.GetComponent(typeof(ItemDraw))).UpdateIcon(item_container, false, i);
            item_space_sum = item_space_sum + item_container.ContainerItems[i].GetVolume();
            i++;
        }
        this.Weight_Text.text = string.Format("{0} / {1}", item_space_sum, item_container.MaxLoad);
    }

    public static void UpdateWeightDisplay()
    {
        float item_space_sum = 0;
        ItemContainer container = ItemContainer.PlayerContainer;
        int i = 0;
        while (i < container.ContainerItems.Count)
        {
            item_space_sum = item_space_sum + container.ContainerItems[i].GetVolume();
            i++;
        }
        InventoryManager.instance.Weight_Text.text = string.Format("{0} / {1}", item_space_sum, container.MaxLoad);
    }

    public virtual void Update()
    {
        //Open container
        if ((Input.GetKeyDown(KeyCode.E) && (WorldInformation.vehicleController == null)) && (WorldInformation.vehicleDoorController == null))
        {
            if (!InventoryManager.container_opened)
            {
                if (ItemContainer.PlayerContainer != null)
                {
                    InventoryManager.instance.RefreshItems(ItemContainer.PlayerContainer);
                    InventoryManager.instance.SetChildActive(true);
                    CameraScript.InInterface = true;
                    PlayerMotionAnimator.PiriStill = true;
                    Screen.lockCursor = false;
                    Cursor.visible = true;
                }
            }
            else
            {
                InventoryManager.instance.SetChildActive(false);
                CameraScript.InInterface = false;
                PlayerMotionAnimator.PiriStill = false;
                Screen.lockCursor = true;
                Cursor.visible = false;
            }
        }
        if ((Input.GetKeyDown(KeyCode.R) && (WorldInformation.vehicleController == null)) && !CameraScript.InInterface)
        {
            this.StartCoroutine(this.InteractWithEnviroment());
        }
    }

    //MUGG!
    public virtual void UpdateHand()
    {
        Item item = ItemContainer.PiriContainer.ContainerItems.Count > 0 ? ItemContainer.PiriContainer.ContainerItems[0] : new Item();
        ItemDisplay display = item.GetDisplay();
        InventoryManager im = InventoryManager.instance;
        //Update Hand
        if (im.CarryObject != display.ItemPrefab)
        {
            if (im.CarryObject != null)
            {
                UnityEngine.Object.Destroy(im.CarryObject);
            }
            if (display.ItemPrefab != null)
            {
                GameObject newHandItem = UnityEngine.Object.Instantiate(display.ItemPrefab) as GameObject;
                InventoryManager.Hold(newHandItem, item.ItemType);
            }
            else
            {
                Debug.LogWarning("Item doesnt have a prefab located in resources!", this);
            }
        }
    }

    //Pickup/drop item
    public virtual IEnumerator InteractWithEnviroment()
    {
        RaycastHit hit = default(RaycastHit);
        if (this.dropping)
        {
            yield break;
        }
        Item item = null;
        GameObject obj = null;
        if ((ItemContainer.PiriContainer.ContainerItems.Count > 0) && !(ItemContainer.PiriContainer.ContainerItems[0] == null))
        {
            //Has Item		->	  Drop
            item = ItemContainer.PiriContainer.ContainerItems[0];
            ItemDisplay display = item.GetDisplay();
            ItemContainer.PiriContainer.DeletePiriSlot();
            this.dropping = true;
            this.Pirizuka.CrossFade(this.DropAnimation);
            yield return new WaitForSeconds(0.5f);
            obj = UnityEngine.Object.Instantiate(display.ItemDropPrefab) as GameObject;
            switch (item.ItemType)
            {
                case ItemTypes.Weapon:
                    obj.transform.position = this.PirizukaWeapon.position;
                    obj.transform.eulerAngles = this.PirizukaWeapon.eulerAngles;
                    obj.name = "drop " + item.ID;
                    if (obj.GetComponent<Rigidbody>())
                    {
                        obj.GetComponent<Rigidbody>().velocity = PlayerInformation.instance.PirizukaRB.velocity;
                    }
                    break;
                case ItemTypes.Toy:
                    obj.transform.position = this.PirizukaToy.position;
                    obj.transform.eulerAngles = this.PirizukaToy.eulerAngles;
                    obj.name = "drop " + item.ID;
                    if (obj.GetComponent<Rigidbody>())
                    {
                        obj.GetComponent<Rigidbody>().velocity = PlayerInformation.instance.PirizukaRB.velocity;
                    }
                    break;
                case ItemTypes.LongObject:
                    obj.transform.position = this.PirizukaHand.position;
                    obj.transform.parent = InventoryManager.instance.PirizukaHand;
                    obj.transform.localRotation = Quaternion.Euler(90, 0, 0);
                    obj.name = "drop " + item.ID;
                    obj.transform.parent = null;
                    if (obj.GetComponent<Rigidbody>())
                    {
                        obj.GetComponent<Rigidbody>().velocity = PlayerInformation.instance.PirizukaRB.velocity;
                    }
                    break;
                case ItemTypes.BigObject:
                    obj.transform.position = this.PirizukaHand.position;
                    obj.transform.parent = InventoryManager.instance.PirizukaHand;
                    obj.transform.localRotation = Quaternion.Euler(0, 110, 0);
                    obj.name = "drop " + item.ID;
                    obj.transform.parent = null;
                    if (obj.GetComponent<Rigidbody>())
                    {
                        obj.GetComponent<Rigidbody>().velocity = PlayerInformation.instance.PirizukaRB.velocity;
                    }
                    break;
                case ItemTypes.BigObject2:
                    obj.transform.position = this.PirizukaHand.position;
                    obj.transform.parent = InventoryManager.instance.PirizukaHand;
                    obj.transform.localRotation = Quaternion.Euler(-90, -90, 20);
                    obj.name = "drop " + item.ID;
                    obj.transform.parent = null;
                    if (obj.GetComponent<Rigidbody>())
                    {
                        obj.GetComponent<Rigidbody>().velocity = PlayerInformation.instance.PirizukaRB.velocity;
                    }
                    break;
                default:
                    obj.transform.position = this.PirizukaHand.position;
                    obj.transform.eulerAngles = this.PirizukaHand.eulerAngles;
                    obj.name = "drop " + item.ID;
                    if (obj.GetComponent<Rigidbody>())
                    {
                        obj.GetComponent<Rigidbody>().velocity = PlayerInformation.instance.PirizukaRB.velocity;
                    }
                    break;
            }
            ((DataContainer) obj.AddComponent(typeof(DataContainer))).item = ItemContainer.PiriContainer.ContainerItems[0];
            ItemContainer.PiriContainer.ContainerItems.Clear();
            this.dropping = false;
            this.Pirizuka.CrossFade(this.IdleAnimation);
        }
        else
        {
            //Has no Item	->	  Pickup
            Vector3 pos = PlayerInformation.instance.PiriAim.position;
            Vector3 dir = PlayerInformation.instance.PiriAim.forward;
            if (Physics.Raycast(pos, dir, out hit, 5, (int) this.targetLayers))
            {
                obj = hit.collider.gameObject;
                if ((DataContainer) obj.GetComponent(typeof(DataContainer)))
                {
                    if ((ObjectInfo) obj.GetComponent(typeof(ObjectInfo)))
                    {
                        if (((ObjectInfo) obj.GetComponent(typeof(ObjectInfo))).ObjectStringCode == DrivenVesselScript.WhatToSpawn)
                        {
                            DrivenVesselScript.WhatToSpawn = null;
                        }
                    }
                    ItemContainer.PiriContainer.ContainerItems.Add(((DataContainer) obj.GetComponent(typeof(DataContainer))).item);
                    if (ItemDraw.hand_instance == null)
                    {
                        ItemContainer.PiriContainer.CreatePiriSlot();
                    }
                    if (obj.name.Contains("40mm"))
                    {
                        Item gun_item = ((DataContainer) obj.GetComponent(typeof(DataContainer))).item;
                        string name = gun_item.ItemData.Substring(1, gun_item.ItemData.Length - 1);
                        int offset = int.Parse(gun_item.ItemData[0].ToString());
                        InventoryManager.AllowGunAmmo(name, offset);
                    }
                    UnityEngine.Object.Destroy(obj);
                }
            }
        }
        //Required to update data for some strange reason	(disabled due to piris inventory possibly being empty)
        //item = ItemContainer.PiriContainer.ContainerItems[0];
        //display = item.GetDisplay();
        //Update Hand
        this.UpdateHand();
    }

    public static bool container_opened;
    public virtual void SetChildActive(bool @bool)
    {
        InventoryManager.container_opened = @bool;
        this.MenuGraphics.SetActive(@bool);
        int i = 0;
        while (i < this.transform.childCount)
        {
            this.transform.GetChild(i).gameObject.SetActive(@bool);
            i++;
        }
    }

    public static void Hold(GameObject obj, ItemTypes itemType)
    {
        InventoryManager.instance.CarryObject = obj;
        switch (itemType)
        {
            case ItemTypes.Weapon:
                obj.transform.position = InventoryManager.instance.PirizukaWeapon.position;
                obj.transform.eulerAngles = InventoryManager.instance.PirizukaWeapon.eulerAngles;
                obj.transform.parent = InventoryManager.instance.PirizukaWeapon;
                break;
            case ItemTypes.Toy:
                obj.transform.position = InventoryManager.instance.PirizukaToy.position;
                obj.transform.eulerAngles = InventoryManager.instance.PirizukaToy.eulerAngles;
                obj.transform.parent = InventoryManager.instance.PirizukaToy;
                break;
            case ItemTypes.LongObject:
                obj.transform.position = InventoryManager.instance.PirizukaHand.position;
                obj.transform.parent = InventoryManager.instance.PirizukaHand;
                obj.transform.localRotation = Quaternion.Euler(90, 0, 0);
                break;
            case ItemTypes.BigObject:
                obj.transform.position = InventoryManager.instance.PirizukaHand.position;
                obj.transform.parent = InventoryManager.instance.PirizukaHand;
                obj.transform.localRotation = Quaternion.Euler(0, 110, 0);
                break;
            case ItemTypes.BigObject2:
                obj.transform.position = InventoryManager.instance.PirizukaHand.position;
                obj.transform.parent = InventoryManager.instance.PirizukaHand;
                obj.transform.localRotation = Quaternion.Euler(-90, -90, 20);
                break;
            default:
                obj.transform.position = InventoryManager.instance.PirizukaHand.position;
                obj.transform.eulerAngles = InventoryManager.instance.PirizukaHand.eulerAngles;
                obj.transform.parent = InventoryManager.instance.PirizukaHand;
                break;
        }
    }

    public static void SetMouseOffset(Vector2 _offset)
    {
        if (InventoryManager.instance.UseMouseOffsetWhenDragging)
        {
            InventoryManager.MouseOffset = _offset;
        }
        else
        {
            InventoryManager.MouseOffset = Vector2.zero;
        }
    }

    //__________________________________________________________________________________________________\\
    //											GUN_MANAGER												\\
    //__________________________________________________________________________________________________\\
    public static System.Collections.Generic.Dictionary<string, bool> dictAllowedGunAmmo;
    public static void AllowGunAmmo(string gun_name, int offset)
    {
        if (offset == 1)
        {
            return;
        }
        string key = string.Format("Unlockables/unlockable_ammo_{0}_{1}", gun_name, offset);
        if (!InventoryManager.dictAllowedGunAmmo.ContainsKey(key))
        {
            InventoryManager.dictAllowedGunAmmo.Add(key, true);
            SaveInfo.SaveData(key, "1");
        }
    }

    public static bool CanUseGunAmmo(string gun_name, int offset)
    {
        if (offset == 1)
        {
            return true;
        }
        string key = string.Format("Unlockables/unlockable_ammo_{0}_{1}", gun_name, offset);
        if (!InventoryManager.dictAllowedGunAmmo.ContainsKey(key))
        {
            if (SaveInfo.HasData(key))
            {
                return true;
            }
        }
        else
        {
            return true;
        }
        return false;
    }

    public InventoryManager()
    {
        this.ItemDictionary = new Dictionary<int, ItemDisplay>();
    }

    static InventoryManager()
    {
        InventoryManager.dictAllowedGunAmmo = new Dictionary<string, bool>();
    }

}