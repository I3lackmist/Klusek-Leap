using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoniaText : MonoBehaviour {
    void Start() {
        if (PlayerPrefs.GetInt("SoniaBought") == 1) {
            Destroy(gameObject);
        }

    }
    void Update() {
        if (PlayerPrefs.GetInt("SoniaBought") == 1) {
            Destroy(gameObject);
        }
    }
}
