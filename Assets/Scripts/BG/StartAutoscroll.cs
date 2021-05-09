using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAutoscroll : MonoBehaviour{
    [SerializeField] CameraFollow cam;
    [SerializeField] Transform player;
    [SerializeField] StartAutoscroll self;
    [SerializeField] MouseSpawnPoint msp;
    [SerializeField] ShoeThrower st;
    [SerializeField] GameObject floor;
    [SerializeField] DifficultyScaling ds;
    void Update() {
        if(transform.position.y < player.position.y) {
            Destroy(floor);
            ds.enabled = true;
            msp.enabled = true;
            st.enabled = true;
            cam.enabled = true;
            Destroy(self);
        }
    }
}
