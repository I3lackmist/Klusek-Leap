using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTextSB : MonoBehaviour {
    void Update() {
    if(PlayerPrefs.GetInt("SBBought") == 1) {
            Destroy(gameObject);
        }   
    }
}
