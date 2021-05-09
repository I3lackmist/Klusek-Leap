using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsScorable : MonoBehaviour {
    public bool scorable;
    void Start() {
        scorable = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            scorable = true;
        }
    }
}
