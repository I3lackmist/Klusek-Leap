using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighScoreText : MonoBehaviour {
    private void OnEnable() {
        GetComponent<Text>().text = PlayerPrefs.GetInt("HighScore").ToString();
    }
}
