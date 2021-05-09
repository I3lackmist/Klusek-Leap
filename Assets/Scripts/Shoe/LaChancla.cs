using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaChancla : MonoBehaviour {
    public float min_spin_strength,max_spin_strength;
    [SerializeField] Rigidbody2D rb;
    public float max_icon_scale;
    [SerializeField] GameObject icon;
    [SerializeField] GameObject shoe;
    public float y_offset;
    public float scale_factor;
    private void Start() {
        transform.position = new Vector3(transform.position.x, transform.position.y, 10);
        icon.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0f, 1f, 0f)) + Vector3.up * y_offset;
        icon.transform.position = new Vector3(transform.position.x, icon.transform.position.y, transform.position.z);
        rb.angularVelocity = Random.Range(min_spin_strength, max_spin_strength);
    }

    private void FixedUpdate() {
        if(shoe.transform.position.y > Camera.main.ViewportToWorldPoint(new Vector3(0,1f,0)).y) {
            icon.transform.localScale = scale_factor * icon.transform.localScale * (shoe.transform.position.y - Camera.main.ViewportToWorldPoint(new Vector3(0, 1f, 0f)).y);
            icon.transform.localScale = Vector3.ClampMagnitude(icon.transform.localScale, max_icon_scale*max_icon_scale*max_icon_scale);
        }
        else {
            Destroy(gameObject, 3f);    
            Destroy(icon);
        }
    }
}
