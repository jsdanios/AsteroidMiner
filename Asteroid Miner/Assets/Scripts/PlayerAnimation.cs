using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    PlayerController playerController;

    Animator exhaustRight;
    Animator exhaustLeft;
    Animator drillRight;
    Animator drillLeft;

    Transform boosterRight;
    Transform boosterLeft;

    void Start() {

        GameObject Player = GameObject.Find("Player");
        playerController = Player.GetComponent<PlayerController>();

        boosterRight = this.transform.Find("Booster Right");
        boosterLeft = this.transform.Find("Booster Left");

        exhaustRight = boosterRight.Find("Exhaust Right").GetComponent<Animator>();
        exhaustLeft = boosterLeft.Find("Exhaust Left").GetComponent<Animator>();
        drillRight = this.transform.Find("Arm Front Right").GetComponent<Animator>();
        drillLeft = this.transform.Find("Arm Front Left").GetComponent<Animator>();

    }

    void Update() {

        if (playerController.moving) {
            exhaustRight.SetBool("moving", true);
            exhaustLeft.SetBool("moving", true);
        } else {
            exhaustRight.SetBool("moving", false);
            exhaustLeft.SetBool("moving", false);
        }

        if (Input.GetMouseButton(0)) {
            drillRight.SetBool("mining", true);
            drillLeft.SetBool("mining", true);
        } else {
            drillRight.SetBool("mining", false);
            drillLeft.SetBool("mining", false);
        }

    }

}
