using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplierText : MonoBehaviour {
    [SerializeField] Text text;
    [SerializeField] ScoreManager sm;
    bool popped;
    void Start() {
        popped = false;
        text.text = "";
        sm = GameObject.Find("GameController").GetComponent<ScoreManager>();
    }
    private void Update() {
        if (sm.move_combo % 5 == 0 && !popped && sm.move_combo != 0) {
            StartCoroutine(Pop());
            popped = true;
        }
        if(sm.move_combo % 5 != 0) {
            popped = false;
        }
    }
    IEnumerator Pop() {
        text.text = sm.move_combo.ToString();
        yield return new WaitForSeconds(.4f);
        text.text = "";
        yield return null;
    }
}
