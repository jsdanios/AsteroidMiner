using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    [SerializeField] InventoryUI inventoryUI;
    
    public Health playerHealth;
    public Transform camera;

    //need to be implemented for shooting;
    //public GameObject crosshairs;
    //public GameObject projectile;

    public float health = 10f;
    public float moveSpeed = 6f;
    public float turnSpeed = 40f;
    public float projectileSpeed = 40f;
    public bool moving;
    
    Rigidbody2D rigidbody;
    Inventory inventory;
    Vector3 target;

    void Start() {
        
        rigidbody = GetComponent<Rigidbody2D>();

        playerHealth = new Health(health);
        playerHealth.SetHealthMax(10f);

        inventory = new Inventory();
        inventoryUI.SetInventory(inventory);

        Cursor.visible = false;

    }

    void FixedUpdate() {

        Quaternion fixedRotation = camera.rotation;

        Move();

        camera.rotation = fixedRotation;

        Target();

    }

    void Move() {

        if (Input.GetKey(KeyCode.W)) {
            transform.Translate(0, moveSpeed * Time.fixedDeltaTime, 0);
            moving = true;
        } else {
            moving = false;
        }

        if (Input.GetKey(KeyCode.S)) {
            transform.Translate(0, -moveSpeed / 2 * Time.fixedDeltaTime, 0);
        }

        if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(-Vector3.forward * turnSpeed * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(Vector3.forward * turnSpeed * Time.fixedDeltaTime);
        }

    }

    void Fire(Vector2 direction, float rotationZ) {

        // GameObject proj = Instantiate(projectile) as GameObject;
        // proj.transform.position = this.transform.position;
        // proj.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        // proj.GetComponent<RigidBody2D>().velocity = direction * projectileSpeed;


    }

    void Target() {

        target = camera.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        //crosshairs.transform.position = new Vector2(target.x, target.y);

        Vector3 difference = target - this.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if (Input.GetMouseButtonDown(1)) {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            Fire(direction, rotationZ);
        }

    }



}
