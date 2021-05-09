    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour {
    [SerializeField] Transform player;
    
    void LateUpdate() {
        transform.position = new Vector3(transform.position.x,Camera.main.ScreenToWorldPoint(new Vector3(0,.5f,0)).y, transform.position.z);
    }
}
