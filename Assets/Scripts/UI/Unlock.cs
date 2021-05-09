using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unlock : MonoBehaviour {
    [SerializeField] Sprite unlocked;
    [SerializeField] Image image;
    public string cat_key;
    void Start() {
        StartCoroutine(checkIfUnlocked(cat_key));
    }

    IEnumerator checkIfUnlocked(string cat_key) {
        if(PlayerPrefs.GetInt(cat_key) == 1) {
            image.sprite = unlocked;
            Destroy(gameObject.GetComponent<Unlock>());
        }
        else {
            yield return new WaitForSecondsRealtime(.3f);
            StartCoroutine(checkIfUnlocked(cat_key));
        }
    }
}
