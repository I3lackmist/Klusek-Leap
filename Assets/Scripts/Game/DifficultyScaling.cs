using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DifficultyScaling : MonoBehaviour {
    [SerializeField] PlayerLaunch pms;
    [SerializeField] DifficultyScaling self;
    public float difficulty_factor;
    public float slide_speed_increase,autoscroll_speed_increase;
    public float difficulty;
    public float autoscroll_factor, slide_factor;
    public float t;
    public bool started_countdown;
    void Start() {
        t = 0;
        self.enabled = false;
    }
    void FixedUpdate() {
        t += Time.deltaTime;
        difficulty = Mathf.Log(t, difficulty_factor);
        difficulty = Mathf.Clamp(difficulty, 0, 100);

        autoscroll_speed_increase = difficulty / autoscroll_factor;
        autoscroll_speed_increase = Mathf.Clamp(autoscroll_speed_increase, 1f, Mathf.Infinity);

        slide_speed_increase = difficulty / slide_factor;
        slide_speed_increase = Mathf.Clamp(slide_speed_increase, 1f, Mathf.Infinity);

    }
}
