using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    public Health asteroidHealth;

    public float health = 10f;
    public float speed = 0.55f;
    public float angle = 90f;

    EdgeCollider2D edgeCollider;
    GameObject asteroid;

    Vector2 moveAngle;

    void Start() {

        asteroidHealth = new Health(health);
        this.asteroidHealth.SetHealthMax(health);

        asteroid = this.gameObject;
        
        edgeCollider = GetComponent<EdgeCollider2D>();

        moveAngle = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

    }

    void Update() {

        transform.Translate(moveAngle * speed * Time.deltaTime, Space.World);

        if (asteroidHealth.GetHealth() <= 0) {
            Destroy(asteroid);
        }

    }

    public void DamageAsteroid(float damageAmount) {

        asteroidHealth.Damage(damageAmount);

    }

}
