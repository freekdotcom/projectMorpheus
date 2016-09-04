using UnityEngine;
using System.Collections;

/*
    This class is the core class of every item in the game.
    This class should NOT be changed, unless the programmer agrees
    */
public class CoreItemManager : MonoBehaviour {


    public enum ITEM_TYPE
    {
        PLAYER_ATTACK_UNIT, POTION
    }


    //The id of the item
    private int id;
    private ITEM_TYPE itemType;

    public void SetId(int id)
    {
        this.id = id;
    }

    public int GetId()
    {
        return id;
    }

    public void setItemType(ITEM_TYPE itemType)
    {
        this.itemType = itemType;
    }

    public ITEM_TYPE getItemType()
    {
        return itemType;
    }
}
