using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShoeColl : MonoBehaviour {
    [SerializeField] SoundManage som;
    PlayerLaunch pms;

    private void Start() {
        pms = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLaunch>();
        som = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManage>();
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {

            collision.gameObject.GetComponent<PlayerLaunch>().fall = true;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity *= 0.1f;
            StartCoroutine(shoeHit());
        }
    }
    IEnumerator shoeHit() {
        yield return new WaitForSecondsRealtime(.2f);
        som.Bonk();
        pms.Fall();
    }
}
