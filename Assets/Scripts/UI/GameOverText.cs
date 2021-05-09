using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour {
    [SerializeField] Text text1,text2;
    
    public void setTextToIndicateHS() {
        text1.text = "New High Score!";
        text2.text = "New High Score!";
    }
}
