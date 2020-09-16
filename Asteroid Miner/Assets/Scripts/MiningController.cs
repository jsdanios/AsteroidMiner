using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningController : MonoBehaviour {

    public static bool coroutineLocked = false;

    Collider2D asteroid;

    bool canMine;
    float damageAmount = 1f;

    void Update() {

        if (Input.GetMouseButton(0)) {
            Mine();
        }

    }

    void Mine() {

        if (coroutineLocked) {
            return;
        }

        coroutineLocked = true;

        StartCoroutine(DamageOverTimeCoroutine());

    }


    void OnTriggerEnter2D(Collider2D collider) {

        if (collider.CompareTag("mineable")) {
            asteroid = collider;
            canMine = true;
        }

    }

    void OnTriggerExit2D(Collider2D collider) {

        canMine = false;
        asteroid = null;

    }

    IEnumerator DamageOverTimeCoroutine() {

        while (canMine) {
            asteroid.gameObject.GetComponent<Asteroid>().DamageAsteroid(damageAmount);
            Debug.Log(asteroid.gameObject.GetComponent<Asteroid>().asteroidHealth.GetHealth());

            yield return new WaitForSeconds(1f);
        }

        coroutineLocked = false;

    }

}
