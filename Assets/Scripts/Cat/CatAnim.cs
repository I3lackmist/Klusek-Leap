using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnim : MonoBehaviour {
    [SerializeField] public Sprite sit, leap, hang,fall,mid;
    [SerializeField] PlayerLaunch pms;
    [SerializeField] SpriteRenderer sprend;
    bool landed;
    void Start() {
        pms = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLaunch>();
        landed = false;
        sprend.sprite = sit;
    }
    void LateUpdate() {
        if(pms.in_air) {
            sprend.sprite = leap;
            landed = false;
        }
        
        else if(pms.on_wall && !landed) {
            StartCoroutine(land());
            landed = true;
        }

        else if (pms.fall) {
            sprend.sprite = fall;
        }
        
        else if(pms.on_floor) {
            sprend.sprite = sit;
            landed = false;
        }
    }

    IEnumerator land() {
        sprend.sprite = mid;
        yield return new WaitForSecondsRealtime(.04f);
        sprend.sprite = hang;
    }
}
