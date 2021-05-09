using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHang : MonoBehaviour {
    [SerializeField] Transform mouse;
    [SerializeField] LineRenderer lrend;
    void Start() {
       
        lrend.SetPosition(0, mouse.transform.position);
        lrend.SetPosition(1, transform.position);
    }
    void Update() {
        lrend.SetPosition(0, mouse.transform.position);
        lrend.SetPosition(1, transform.position);
    }
}
