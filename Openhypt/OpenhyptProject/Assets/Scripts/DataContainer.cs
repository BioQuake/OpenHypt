using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class DataContainer : MonoBehaviour
{
    public Item item;
    public virtual void Start()
    {
        if (this.item.GetID() > 0)
        {
            this.item = new Item(this.item.GetID(), this.item.ItemType, this.item.ItemData, this.item.ItemDataType);
        }
    }

}