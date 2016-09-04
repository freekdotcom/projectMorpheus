using UnityEngine;
using System.Collections;

public class HealingItemsManager : CoreItemManager
{
    static ItemDataBaseList inventoryItemList;

    // Use this for initialization
    void Awake()
    {
        SetId(1);
        inventoryItemList = (ItemDataBaseList)Resources.Load("ItemDatabase");
        MakeItemPickUp();
    }

    void MakeItemPickUp()
    {
        {            
            PickUpItem item = gameObject.AddComponent<PickUpItem>();
            item.item = inventoryItemList.itemList[GetId()];
        }
    }

}
