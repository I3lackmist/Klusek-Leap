using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BGHolder : MonoBehaviour {
    [SerializeField] GameObject[] bgs;
    [SerializeField] Transform player;
    public float parallax_factor;

    public float length;
    float[] start_ys;
    public bool freeze;
    int index;
    float sum_move,curry, lasty;

    [SerializeField] Transform BGCanvas;
    void Start() {
        freeze = false;
        index = 0;
        length = bgs[0].GetComponent<SpriteRenderer>().bounds.size.y;
        sum_move = 0;
        start_ys = new float[6];
        for(int i = 0; i < 6; i++) {
            bgs[i].transform.position = new Vector3(transform.position.x, (i-3)*length,100);
            start_ys[i] = (i - 3) * length;
        }
        transform.position += Vector3.up * 9f;
        curry = player.position.y;
        lasty = player.position.y;
    }


    private void FixedUpdate() {
        if (!freeze) {
            curry = player.transform.position.y;
            float move = (curry - lasty) * parallax_factor;
            for (int i = 0; i < 6; i++) {
                bgs[i].transform.position -= Vector3.up * move;
            }

            sum_move += move;
            if (sum_move >= length) {
                bgs[index].transform.position += length * 6 * Vector3.up;
                index = (index + 1) % 6;
                sum_move = 0;
            }

            lasty = player.transform.position.y;
        }
    }
}
