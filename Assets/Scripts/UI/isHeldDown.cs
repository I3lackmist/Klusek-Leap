using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class isHeldDown : MonoBehaviour {
    Button button;
    [SerializeField] Sprite pressed_down, released;
    private void Start() {
        button = gameObject.GetComponent<Button>();
        
    }

    private void Update() {
        if(Input.touchCount == 0) {
            button.image.sprite = released;
        }
    }
    public void HeldDown() {
        button.image.sprite = pressed_down;
    }

    
}
