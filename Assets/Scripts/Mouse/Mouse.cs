using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour {
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Sprite[] sprites;
    [SerializeField] SpriteRenderer sprend;
    [SerializeField] CircleCollider2D coll;
    [SerializeField] ScoreManager sm;
    [SerializeField] GameObject parent;
    [SerializeField] MouseReel reel;
    [SerializeField] SoundManage som;

    ParticleSystem ps;
    float time;
    float bounce_force;
    
    public float min_time, max_time;
    public float min_force, max_force;
    
    float time_elapsed;
    void Start() {
        som = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManage>();
        sm = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreManager>();
        ps = GetComponent<ParticleSystem>();
        reel = gameObject.GetComponentInParent<MouseReel>();
        bounce_force = Random.Range(min_force, max_force);
        sprend.sprite = sprites[Random.Range(0, sprites.Length)];
        rb.AddForce(Vector2.up * bounce_force * 100f,ForceMode2D.Impulse);
    }
    private void FixedUpdate() {
        if(time_elapsed >= time) {
            rb.AddForce(Vector2.up * bounce_force * 100f, ForceMode2D.Impulse);
            time_elapsed -= time;
            time = Random.Range(min_time, max_time);
        }
        time_elapsed += Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 1);
            som.Scratch();

            ps.Play();
            Destroy(sprend);
            Destroy(coll);
            reel.earlyReel();
        }
    }
}
