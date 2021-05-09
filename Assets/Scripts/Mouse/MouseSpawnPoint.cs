using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSpawnPoint : MonoBehaviour {
    [SerializeField] GameObject mouseprefab;
    [SerializeField] PlayerLaunch pms;
    [SerializeField] CameraFollow cf;
    public float offset;
    public float max_x_offset;
    [Range(0,1)] public float spawn_chance;
    public float spawn_time;
    float time_elapsed;
    public float catch_up_speed;
    void Start() {
        time_elapsed = 0f;
        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(.5f, 1f)) + Vector3.up * offset + Vector3.forward * 110f;
    }
    void Update() {
        transform.position = Vector3.Lerp(transform.position, Camera.main.ViewportToWorldPoint(new Vector3(.5f, 1f)) + Vector3.up * offset,catch_up_speed * Time.deltaTime);
        if(time_elapsed >= spawn_time && Random.Range(0f,1f) < spawn_chance && !pms.in_air) {

            int player_x_half = Camera.main.WorldToScreenPoint(pms.gameObject.transform.position).x < Screen.width * 0.5f ? 1 : -1;
            if (Random.Range(0f, 1f) > .8f) player_x_half *= -1;
            
            Instantiate(mouseprefab, transform.position + Vector3.right * Random.Range(0, max_x_offset) * player_x_half + Vector3.forward,Quaternion.identity,transform);
            time_elapsed -= spawn_time;
        }
        time_elapsed += Time.deltaTime;
    }
}
