using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormController : MonoBehaviour {

    [SerializeField] GameObject projectile;

    PlayerController target;
    Vector3 direction;
    Quaternion initialAngle;
    Transform wormHead;
    Transform wormSegment1;
    Transform wormSegment2;
    Transform projectileSpawner;

    public float fireRate = 5f;
    public float maxAngle = 30f;
    public float turnSpeed = 0.2f;

    float timeToNextFire;
    float angle;

    void Awake() {

        wormSegment1 = this.transform.Find("Worm Segment 1");
        wormSegment2 = wormSegment1.Find("Worm Segment 2");
        wormHead = wormSegment2.Find("Worm Head");
        projectileSpawner = wormHead.Find("Projectile Spawner");

        target = GameObject.FindObjectOfType<PlayerController>();

    }

    void Start() {

        timeToNextFire = Time.time;
        initialAngle = wormHead.transform.rotation;

    }


    void Update() {

        Fire();
        Target();

    }

    //fire projectile
    void Fire() {

        if (Time.time > timeToNextFire) {
            Instantiate(projectile, projectileSpawner.position, Quaternion.identity);
            timeToNextFire = Time.time + fireRate;
        }

    }

    //turns worm to face player
    void Target() {

        direction = target.transform.position - wormHead.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 45f;
        angle = Mathf.Clamp(angle, -maxAngle, maxAngle);

        Quaternion headRotation = Quaternion.AngleAxis(angle * 2f, Vector3.forward);
        Quaternion bodyRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        wormHead.transform.rotation = Quaternion.Slerp(wormHead.transform.rotation, headRotation, turnSpeed * Time.deltaTime);
        wormSegment2.transform.rotation = Quaternion.Slerp(wormSegment2.transform.rotation, bodyRotation, turnSpeed * Time.deltaTime);

    }

}