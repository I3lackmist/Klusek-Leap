using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour {
    [SerializeField] ScoreManager sm;
    Text text;
    void Start() {
        text = GetComponent<Text>();
        
    }

    private void Update() {
        if (sm.score > float.Parse(text.text)) {
            text.text = sm.score.ToString();
        }
    }
}
