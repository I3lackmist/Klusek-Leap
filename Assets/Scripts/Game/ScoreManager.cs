using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public int score;
    public int move_combo;
    [SerializeField] GameObject gameovertext;
    void Start() {
        score = 0;
    }

    public void amassScore(int n) {
        score += n;
        checkForHighScore();
    }

    public void setCombo(int n) {
        move_combo = 0;
    }
    public void increaseCombo(int n) {
        move_combo += n;
        if(move_combo%5==0 && move_combo >0) {
            score += 5;
        }
    }

    void checkForHighScore() {
        if(score > PlayerPrefs.GetInt("HighScore")) {
            PlayerPrefs.SetInt("HighScore",score);
            gameovertext.GetComponent<GameOverText>().setTextToIndicateHS();
        }
    }
}
