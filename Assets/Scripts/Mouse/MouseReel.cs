using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseReel : MonoBehaviour {
    public float min_time, max_time;
    float time_until_reel_back;
    public float reel_speed;
    float time_alive;
    public float min_dist, max_dist;
    [SerializeField] SpringJoint2D joint;

    void Start() {
        time_alive = 0f;
        time_until_reel_back = Random.Range(min_time, max_time);
        joint.distance = Random.Range(min_dist, max_dist);
    }
    void Update() {
        if(time_alive > time_until_reel_back) {
           joint.distance -=  reel_speed * Time.deltaTime;
        }

        if(joint.distance <=0.1f) {
            Destroy(gameObject);
        }
        time_alive += Time.deltaTime;
    }

    public void earlyReel() {
        time_alive = time_until_reel_back - 0.1f;
    }
}
