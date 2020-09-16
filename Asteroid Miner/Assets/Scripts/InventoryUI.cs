using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

    public Inventory inventory;

    Transform itemContainer;
    Transform itemSpriteContainer;
    

    void Awake() {
        itemContainer = transform.Find("ItemContainer");
        itemSpriteContainer = itemContainer.Find("ItemSpriteContainer");
    }
    

    public void SetInventory(Inventory inventory) {

        this.inventory = inventory;
        RefreshInventoryItems();

    }

    void RefreshInventoryItems() {

        int x = 0;
        int y = 0;
        float cellSize = 64f;

        foreach (Item item in inventory.GetItemList()) {
            RectTransform rectTransform = Instantiate(itemSpriteContainer, itemContainer).GetComponent<RectTransform>();
            rectTransform.gameObject.SetActive(true);

            rectTransform.anchoredPosition = new Vector2(x * cellSize, y * cellSize);
            
            Image image = rectTransform.GetComponent<Image>();
            image.sprite = item.GetSprite();

            x++;
            if (x > 3) {
                x = 0;
                y++;
            }
            
        }
    }
    
}
