using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteBtn : MonoBehaviour {
    [SerializeField] Sprite muted, unmuted;
    void Update() {
        if (PlayerPrefs.GetInt("Mute") == 0 || PlayerPrefs.GetInt("Mute") == -1)
            gameObject.GetComponent<Button>().image.sprite = unmuted;
        else if (PlayerPrefs.GetInt("Mute") == 1) 
            gameObject.GetComponent<Button>().image.sprite = muted;
    }
}
