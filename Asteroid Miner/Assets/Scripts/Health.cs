using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health {

    public float health;
    public float healthMax;

    public Health(float health) {
        this.health = health;
    }

    public float GetHealth() {
        return health;
    }

    public float GetHealthPercent() {
        return health / healthMax;
    }

    public void SetHealthMax(float healthMax) {
        this.healthMax = healthMax;
    }

    public void Damage(float damageAmount) {
        health -= damageAmount;
        if (health < 0) {
            health = 0;
        }
    }

    public void Heal(float healAmount) {
        health += healAmount;
        if (health > healthMax) {
            health = healthMax;
        }
    }

}
