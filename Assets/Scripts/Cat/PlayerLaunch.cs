using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class PlayerLaunch : MonoBehaviour {
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer sprend;

    [SerializeField] ScoreManager sm;
    [SerializeField] DifficultyScaling ds;

    [SerializeField] SoundManage som;
    [SerializeField] UIManager ui;
    public float power, distance_scaling, max_dist_scaling;
    public float slide_speed;

    public bool in_air, on_wall, move_lock, can_move, on_post, on_floor, fall, game_start;

    public float min_drag_space;
    Vector2 velocity;
    Vector2 init_touch_pos, sim_pos;

    float init_slide_speed;
    public float max_slide_speed;

    int lastx;
    Vector2 dir;
    [SerializeField] GameObject trajDot;
    GameObject[] trajDots;

    public int max_dots;
    float scaling;
    public float dot_scaling, dot_spacing;

    public float max_y, dir_differential;
    void Start() {
        init_slide_speed = slide_speed;

        in_air = false;
        on_wall = false;
        on_post = false;
        move_lock = false;
        can_move = false;
        on_floor = true;
        game_start = false;

        lastx = 0;

        trajDots = new GameObject[max_dots];
        for (int i = 0; i < max_dots; i++) {
            trajDots[i] = Instantiate(trajDot, new Vector3(0f, 0f, 0f), Quaternion.identity);
            trajDots[i].SetActive(false);
        }
    }

    void Update() {
        //Abandon all hope, ye who enter here
        if (!fall) {
            Touch touch;

            transform.rotation = Quaternion.identity;

            if (!game_start) {
                if (Input.touchCount > 0 && !in_air) {
                    touch = Input.GetTouch(0);

                    float checkdst = Mathf.Abs(((Vector2)Camera.main.ScreenToWorldPoint(touch.position) - (Vector2)transform.position).magnitude);

                    if (checkdst < min_drag_space * Camera.main.orthographicSize) {
                        ui.CloseUI();
                        game_start = true;
                    }
                }
            }

            else if (game_start && Input.touchCount > 0 && !in_air) {
                touch = Input.GetTouch(0);
                if (!in_air) {
                    if (touch.phase == TouchPhase.Began) {
                        init_touch_pos = touch.position;
                        sim_pos = touch.position;
                        dir = Vector2.zero;
                    }
                }
                if (touch.phase == TouchPhase.Moved && !in_air) {
                    sim_pos += touch.deltaPosition;
                }

                dir = Camera.main.ScreenToWorldPoint(sim_pos) - Camera.main.ScreenToWorldPoint(init_touch_pos);

                scaling = Mathf.Clamp(distance_scaling * dir.magnitude, 0f, max_dist_scaling);
                dir.Normalize();

                if (lastx != 0 && dir.x != lastx * Mathf.Abs(dir.x) && !on_floor) {
                    dir = new Vector2(-1f * dir.x, dir.y);
                }

                while (dir.y > max_y) {
                    if (dir.x < 0f) {
                        dir = new Vector2(dir.x - dir_differential, dir.y - dir_differential);
                    }
                    else {
                        dir = new Vector2(dir.x + dir_differential, dir.y - dir_differential);
                    }
                }

                velocity = dir * power * scaling;

                if (dir.y > 0) {
                    for (int i = 0; i < max_dots; i++) {
                        if (i > 2) {
                            trajDots[i].SetActive(true);
                        }

                        trajDots[i].transform.position = dotPosition(dir, i * dot_spacing);
                        trajDots[i].GetComponent<SpriteRenderer>().flipY = true;
                        if (dir.x < 0) {
                            trajDots[i].GetComponent<SpriteRenderer>().flipX = true;
                        }
                        else {
                            trajDots[i].GetComponent<SpriteRenderer>().flipX = false;
                        }
                        trajDots[i].transform.localScale = new Vector3(1, 1, 0) * (i - max_dots) * dot_scaling + Vector3.forward;
                    }
                }


                if (touch.phase == TouchPhase.Ended) {
                    foreach (GameObject dot in trajDots) {
                        dot.SetActive(false);
                    }
                    rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                    //Limit player from aiming down
                    if (dir.y < 0f) {
                        velocity = new Vector2(velocity.x, 0);
                    }
                    //Flip the sprite accordingly
                    if (dir.x > 0) {
                        sprend.flipX = true;
                    }
                    else if (dir.x < 0) {
                        sprend.flipX = false;
                    }
                    //If player is on the left,jump right and vice cersa
                    if (lastx == 0f) {
                        if (dir.x < 0) lastx = -1;
                        else if (dir.x > 0) lastx = 1;
                    }
                    if (lastx != 0f) {
                        lastx = -1 * lastx;
                    }
                    //JUMP
                    rb.AddForce(velocity, ForceMode2D.Impulse);
                    in_air = true;
                    on_wall = false;
                    move_lock = false;
                    on_post = false;
                    can_move = false;
                    on_floor = false;
                    sim_pos = Vector2.zero;
                    som.Meow();
                }
            }
        }

        if ((!in_air && !on_post && !on_floor) || fall) {
            slide_speed = init_slide_speed * ds.slide_speed_increase;
            rb.position += Vector2.down * slide_speed * Time.deltaTime;
        }
        if (rb.velocity == Vector2.zero) in_air = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Post")) {
            in_air = false;
            on_wall = false;
            move_lock = false;
            on_post = true;
            can_move = false;
            on_floor = false;
            if (collision.gameObject.GetComponent<IsScorable>().scorable == true && !on_wall) {
                collision.gameObject.GetComponent<IsScorable>().scorable = false;
                if (!fall) {
                    sm.increaseCombo(1);
                    sm.amassScore(1);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "LeftWall" || collision.gameObject.name == "RightWall") {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            in_air = false;
            on_wall = true;
            move_lock = false;
            can_move = false;
            on_floor = false;
            if (!on_post) {
                sm.setCombo(0);
            }
        }
        if (collision.gameObject.name == "Floor" && !on_post) {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            lastx = 0;
            in_air = false;
            on_wall = false;
            move_lock = false;
            on_post = false;
            can_move = false;
            on_floor = true;
            if (!on_post) {
                sm.setCombo(0);
            }
        }

        if ((on_wall && on_floor) || (on_post && on_floor)) {
            sm.setCombo(0);
            in_air = false;
            on_wall = false;
            move_lock = false;
            on_post = false;
            can_move = false;
            on_floor = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.name == "Floor" && !on_post) {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            lastx = 0;
            in_air = false;
            on_wall = false;
            move_lock = false;
            on_post = false;
            can_move = false;
            on_floor = true;
            if (!on_post) {
                sm.setCombo(0);
            }
        }

        if ((on_wall && on_floor) || (on_post && on_floor)) {
            sm.setCombo(0);
            in_air = false;
            on_wall = false;
            move_lock = false;
            on_post = false;
            can_move = false;
            on_floor = true;
        }
    }

    public Vector2 dotPosition(Vector2 dir, float time) {
        return (Vector2)transform.position + new Vector2(velocity.x, velocity.y) * time + .5f * rb.gravityScale * Physics2D.gravity * time * time;
    }
    public IEnumerator resetSprend() {
        yield return new WaitForEndOfFrame();
        sprend = gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    public void Fall() {
        rb.constraints = RigidbodyConstraints2D.None;

        in_air = false;
        on_wall = false;
        move_lock = false;
        on_post = false;
        can_move = false;
        on_floor = false;
        fall = true;
        rb.AddForce(-lastx * Vector3.right * 2f, ForceMode2D.Impulse);
    }
}
