using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField] Transform otf;
    [SerializeField] DifficultyScaling ds;

    public float autoscroll_speed;
    public float max_autoscroll_speed;
    float init_autoscroll_speed;

    public float catch_up_speed;
    private void Start() {
        init_autoscroll_speed = autoscroll_speed;
    }
    void FixedUpdate() {
        if (otf.position.y > transform.position.y) {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, otf.position.y, -100), catch_up_speed);
        }
        autoscroll_speed = init_autoscroll_speed * ds.autoscroll_speed_increase;
        transform.position += Vector3.up * autoscroll_speed * Time.fixedDeltaTime;
    }
}
