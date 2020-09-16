using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {

    List<Item> itemList;

    public Inventory() {
        itemList = new List<Item>();

        //test
        //AddItem(new Item { itemType = Item.ItemType.Iron, mass = 1f, volume = 1f, value = 1f});
        //AddItem(new Item { itemType = Item.ItemType.Nickel, mass = 1f, volume = 1f, value = 1f});
    }

    public void AddItem(Item item) {

        itemList.Add(item);

    }

    public List<Item> GetItemList() {

        return itemList;

    }

}
