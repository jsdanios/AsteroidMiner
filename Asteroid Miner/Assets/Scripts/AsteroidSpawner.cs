using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

    public GameObject[] prefabs;
    public Vector2 secondsBetweenSpawnsMinMax;

    float nextSpawnTime;

    public float spawnAngleMax;

    void Update() {

        if (Time.time > nextSpawnTime) {

            float secondsBetweenSpawns = Random.Range(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x);
            nextSpawnTime = Time.time + secondsBetweenSpawns;

            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);

            float x = Random.Range(transform.position.x - 30, transform.position.x + 30);

            Vector2 spawnPosition = new Vector2(x, transform.position.y);

            int prefab = Random.Range(0, prefabs.Length);

            GameObject newAsteroid = (GameObject) Instantiate(prefabs[prefab], spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));

        }

    }

}
