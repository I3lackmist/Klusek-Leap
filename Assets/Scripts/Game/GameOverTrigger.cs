using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour {
    [SerializeField] PlayerLaunch pms;
    [SerializeField] GameObject gameoverpanel;
    [SerializeField] BGHolder holder;
    [SerializeField] CameraFollow cam;
    [SerializeField] SoundManage som;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            GameOverProcedure();
        }
    }

    public void GameOverProcedure() {
        som.Fall();
        pms.Fall();
        holder.freeze = true;
        Destroy(cam);
        gameoverpanel.SetActive(true);
    }
}
