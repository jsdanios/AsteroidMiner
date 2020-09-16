using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {

    public enum ItemType {

        //asteroids closest to star
        Carbon,
        Nitrogen,
        Hydrogen,
        Oxygen,

        //silicate asteroids
        //Oxygen,
        Silicon,

        //metallic asteroids
        Iron, //80%
        Nickel,
        Iridium,
        Palladium,
        Platinum,
        Gold,
        Magnesium,
        Osmium,
        Ruthenium,
        Rhodium,

        Ice

    }

    public ItemType itemType;

    public float mass; //kg
    public float volume; //cubic meters //liters?
    public float value; //credits

    public Sprite GetSprite() {
        
        switch (itemType) {
            default:
            case ItemType.Iron:
                return ItemAssets.Instance.ironSprite; 
            case ItemType.Nickel:
                return ItemAssets.Instance.nickelSprite;
        }
    }

}
