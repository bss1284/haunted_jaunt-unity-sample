using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{

    private bool isPlayerInRange;
    private GameObject player;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            isPlayerInRange = true;
            player = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player") {
            isPlayerInRange = false;
            player = null;
        }
    }

    private void Update() {
        if (isPlayerInRange) {
            Vector3 direction = (player.transform.position + Vector3.up) - transform.position;

            Ray ray = new Ray(transform.position,direction);
            RaycastHit hit;

            if (Physics.Raycast(ray,out hit)) {
                if (hit.collider.tag=="Player") {
                    FindObjectOfType<GameEnding>().CaughtEnd();
                }
            }
        }
    }
}
