using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoeThrower : MonoBehaviour {
    [SerializeField] GameObject shoeprefab;
    [SerializeField] PlayerLaunch pms;
    [SerializeField] CameraFollow cf;

    public float offset;
    float time_elapsed;
    public float max_x_offset;
    public float spawn_time;

    [Range(0, 1)] public float spawn_chance;

    void Start() {
        time_elapsed = 0f;
        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(.5f, 1f)) + Vector3.up * offset + Vector3.forward * 110f;
    }
    void Update() {
        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(.5f, 1f)) + Vector3.up * offset + Vector3.forward * 110f;
        if (time_elapsed >= spawn_time && Random.Range(0f, 1f) < spawn_chance) {

            int player_x_half = Camera.main.WorldToScreenPoint(pms.gameObject.transform.position).x < Screen.width * 0.5f ? 1 : -1;
            if (Random.Range(0f, 1f) > .8f) player_x_half *= -1;

            Instantiate(shoeprefab, transform.position + Vector3.right * Random.Range(0, max_x_offset) * player_x_half + Vector3.forward, Quaternion.identity, transform);
            
            time_elapsed -= spawn_time;
        }
        time_elapsed += Time.deltaTime;
    }
}
