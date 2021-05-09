using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchingPosts : MonoBehaviour {
    [SerializeField] DifficultyScaling ds;
    [SerializeField] GameObject[] post_prefabs;
    public float min_dist, max_dist;

    public int post_count;
    GameObject[] posts;

    [SerializeField] Transform player;

    float player_y_move;
    float distance;
    float player_y_last_frame;
    float lay_y;
    public float x_offset;

    int index;
    
    void Start() {
        if (gameObject.name == "LeftWall") {
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0, .5f, 0)) + Vector3.forward * 100f + Vector3.right * .1f;
        }

        else {
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1, .5f, 0)) + Vector3.forward * 100f + Vector3.left * .1f;
            x_offset *= -1f;
        }

        index = 0;
        player_y_last_frame = 0;
        player_y_move = 0;

        distance = 0;

        lay_y = -100f;

        posts = new GameObject[post_count];

        for(int i = 0;i<post_count;i++) {
            distance = Random.Range(min_dist, max_dist);
            posts[i] = Instantiate(post_prefabs[Random.Range(0,post_prefabs.Length)], Vector3.right * x_offset + Vector3.right * transform.position.x + Vector3.up * lay_y + Vector3.up * distance + Vector3.forward * -10f, Quaternion.identity).gameObject;

            lay_y += distance;
        }
    }

    void FixedUpdate() {
        player_y_move += player.transform.position.y - player_y_last_frame;

        if (player_y_move > distance) {
            distance = Random.Range(min_dist, max_dist);
            posts[index].transform.position = new Vector3(posts[index].transform.position.x,0, posts[index].transform.position.z) + Vector3.up * lay_y + Vector3.up * distance;

            posts[index].GetComponent<BoxCollider2D>().enabled = true;
            posts[index].GetComponent<IsScorable>().scorable = true;

            player_y_move -= distance;

            lay_y += distance;
            
            index++;
            index %= post_count;
        }
        player_y_last_frame = player.transform.position.y;
    }

   
}
