using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CurrencyText : MonoBehaviour {
    [SerializeField] Text text;
    void Start() {
        if (!PlayerPrefs.HasKey("Coins")) PlayerPrefs.SetInt("Coins", 0);
        text.text = PlayerPrefs.GetInt("Coins",0).ToString();
    }
    private void FixedUpdate() {
        text.text = PlayerPrefs.GetInt("Coins",0).ToString();
    }
}
