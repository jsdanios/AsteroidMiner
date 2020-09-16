using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    PlayerController target;
    Rigidbody2D rigidbody;
    Vector2 moveDirection;

    float moveSpeed = 10f;

    void Start() {

        rigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<PlayerController>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rigidbody.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 20f);

    }

    void OnTriggerEnter2D(Collider2D collider) {

        if (collider.gameObject.name.Equals("Player")) {
            Debug.Log("hit");
            Destroy(gameObject);
        }

    }

}
