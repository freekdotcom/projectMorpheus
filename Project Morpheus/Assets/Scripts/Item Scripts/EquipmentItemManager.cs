using UnityEngine;
using System.Collections;

public class EquipmentItemManager : CoreItemManager {

    private GameObject player;
    private PlayerHealthManager playerHealth;
    static ItemDataBaseList inventoryItemList;


    // Use this for initialization
    void Awake () {

        SetId(2);
        inventoryItemList = (ItemDataBaseList)Resources.Load("ItemDatabase");
        MakeItemPickUp();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void MakeItemPickUp()
    {
        {
            PickUpItem item = gameObject.AddComponent<PickUpItem>();
            item.item = inventoryItemList.itemList[GetId()];
        }
    }
}
