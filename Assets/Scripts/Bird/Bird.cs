using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Bird : MonoBehaviour {
    [SerializeField] GameObject bird_prefab;
    [SerializeField] Animator anim;
    [SerializeField] ParticleSystem ps;
    public float speed;
    int sidex;
    bool isflying;
    private void Start() {
        ps = gameObject.GetComponent<ParticleSystem>();
        GetComponent<CircleCollider2D>().enabled = true;
        sidex = 0;
        isflying = false;
        while (sidex == 0) {
            sidex = Random.Range(-1, 2);
        }
        float camx;
        if (sidex == 1) {
            camx = 0.95f;
        }
        else camx = 0.05f;
        if(sidex == 1) {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        transform.position = new Vector3(Camera.main.ViewportToWorldPoint( new Vector3(camx,0,0)).x , transform.position.y, transform.position.z);
    }
    private void Update() {
        if (isflying) {
            transform.position += new Vector3(0.2f * -sidex , 0.8f) * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
            ps.Play();
            Destroy(gameObject.GetComponent<CircleCollider2D>());
            anim.SetBool("is_flying", true);
            isflying = true;
            Instantiate(bird_prefab, transform.position + Vector3.up * 100f, transform.rotation);
            Destroy(gameObject, 3);
        }
    }
}
