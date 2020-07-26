using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ItemDraw : MonoBehaviour
{
    public static ItemDraw hand_instance;
    public bool inHand;
    public Item item;
    [UnityEngine.HideInInspector]
    public ItemDraw dragging;
    [UnityEngine.HideInInspector]
    public ItemContainer container;
    private Vector3 start_pos;
    private bool mouseEntered;
    public virtual void UpdateIcon(ItemContainer container, bool in_hand, int item_index)
    {
        this.container = container;
        this.inHand = in_hand;
        if (in_hand)
        {
            ItemDraw.hand_instance = this;
        }
        else
        {
            if (ItemDraw.hand_instance == this)
            {
                ItemDraw.hand_instance = null;
            }
        }
        this.item = container.ContainerItems[item_index];
        if (!this.item.Initialized)
        {
            this.item.Initialize();
        }
        ((SpriteRenderer) this.GetComponent(typeof(SpriteRenderer))).sprite = InventoryManager.instance.ItemDictionary[this.item.GetID()].ItemTexture;
    }

    public virtual void Update()
    {
        Ray ray = default(Ray);
        Vector3 newPos = default(Vector3);
        if (Input.GetMouseButtonDown(0) && this.mouseEntered)
        {
            ray = GUICamera.instance.ScreenPointToRay(Input.mousePosition);
            InventoryManager.MouseOffset = new Vector2(ray.origin.x - this.transform.position.x, ray.origin.y - this.transform.position.y);
            this.GetComponent<Collider>().enabled = false;
            this.dragging = this;
            this.start_pos = this.transform.position;
        }
        if (this.dragging == this)
        {
            InventoryManager im = InventoryManager.instance;
            Vector3 topleft_border = im.transform.position + im.Bounds_TopLeft;
            Vector3 bottomright_border = im.transform.position + im.Bounds_BottomRight;
            //var margin_right : float = im.piri_hand_slot.position.x - bottomright_border.x;
            float margin_bottom = im.piri_hand_slot.position.y - bottomright_border.y;
            ray = GUICamera.instance.ScreenPointToRay(Input.mousePosition);
            newPos = new Vector3(ray.origin.x - InventoryManager.MouseOffset.x, ray.origin.y - InventoryManager.MouseOffset.y, this.transform.position.z);
            if (Input.GetMouseButton(0))
            {
                newPos.x = Mathf.Clamp(newPos.x, topleft_border.x, bottomright_border.x);
                newPos.y = Mathf.Clamp(newPos.y, bottomright_border.y + margin_bottom, topleft_border.y);
                this.transform.position = Vector3.Lerp(this.transform.position, newPos, Time.smoothDeltaTime * 20);
            }
            if (Input.GetMouseButtonUp(0))
            {
                float dist = Vector2.Distance(this.transform.position, im.piri_hand_slot.position);
                if (dist < 0.5f) //if moving to piri hand then...
                {
                    if (this.inHand)
                    {
                        newPos.x = im.piri_hand_slot.position.x;
                        newPos.y = im.piri_hand_slot.position.y;
                        this.transform.position = newPos;
                    }
                    else
                    {
                        ItemContainer piri_container = ItemContainer.PiriContainer;
                        if (piri_container.ContainerItems.Count > 0)
                        {
                            Item item_a = this.item;
                            Item item_b = piri_container.ContainerItems[0];
                            if (this.container.DoesFit(item_b))
                            {
                                this.container.ContainerItems.Remove(item_a);
                                this.container.ContainerItems.Insert(0, item_b);
                                piri_container.ContainerItems.Remove(item_b);
                                piri_container.ContainerItems.Insert(0, item_a);
                                ItemDraw item_slot_b = ItemDraw.hand_instance;
                                item_slot_b.transform.position = this.start_pos;
                                item_slot_b.name = "[Inventory_Item](Clone)";
                                item_slot_b.UpdateIcon(this.container, false, 0);
                                this.UpdateIcon(piri_container, true, 0);
                                this.name = "[Inventory_Hand_Item]";
                                newPos.x = im.piri_hand_slot.position.x;
                                newPos.y = im.piri_hand_slot.position.y;
                                InventoryManager.UpdateWeightDisplay();
                                InventoryManager.instance.UpdateHand();
                            }
                            else
                            {
                                newPos = this.start_pos;
                            }
                        }
                        else
                        {
                            this.container.ContainerItems.Remove(this.item);
                            ItemContainer.PiriContainer.ContainerItems.Add(this.item);
                            this.name = "[Inventory_Hand_Item]";
                            this.UpdateIcon(ItemContainer.PiriContainer, true, 0);
                            newPos.x = im.piri_hand_slot.position.x;
                            newPos.y = im.piri_hand_slot.position.y;
                            InventoryManager.UpdateWeightDisplay();
                            InventoryManager.instance.UpdateHand();
                        }
                        this.transform.position = newPos;
                    }
                }
                else
                {
                     //else move back to container
                    if (this.inHand)
                    {
                        if (ItemContainer.PlayerContainer.DoesFit(this.item))
                        {
                            this.container.ContainerItems.Remove(this.item);
                            ItemContainer.PlayerContainer.ContainerItems.Insert(0, this.item);
                            this.UpdateIcon(ItemContainer.PlayerContainer, false, 0);
                            this.name = "[Inventory_Item](Clone)";
                            ray = GUICamera.instance.ScreenPointToRay(Input.mousePosition);
                            newPos = new Vector3(ray.origin.x - InventoryManager.MouseOffset.x, ray.origin.y - InventoryManager.MouseOffset.y, this.transform.position.z);
                            InventoryManager.UpdateWeightDisplay();
                            InventoryManager.instance.UpdateHand();
                            newPos.x = Mathf.Clamp(newPos.x, topleft_border.x, bottomright_border.x);
                            newPos.y = Mathf.Clamp(newPos.y, bottomright_border.y, topleft_border.y);
                        }
                        else
                        {
                            newPos = this.start_pos;
                        }
                    }
                    else
                    {
                        newPos.x = Mathf.Clamp(newPos.x, topleft_border.x, bottomright_border.x);
                        newPos.y = Mathf.Clamp(newPos.y, bottomright_border.y, topleft_border.y);
                    }
                    this.transform.position = newPos;
                }
                this.item.location = new Vector2(this.transform.localPosition.x, this.transform.localPosition.y);
                this.GetComponent<Collider>().enabled = true;
                this.dragging = null;
            }
        }
    }

    public virtual void OnMouseEnter()
    {
        this.mouseEntered = true;
    }

    public virtual void OnMouseExit()
    {
        this.mouseEntered = false;
    }

}