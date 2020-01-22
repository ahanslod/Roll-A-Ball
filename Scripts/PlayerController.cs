using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private Vector3 startRb;

    void Start () {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame and before rendering a frame

    // Called before performing any physics calculations
    void FixedUpdate (){
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        Vector3 movement = new Vector3 (moveHorizontal, 0.0f ,moveVertical);
        rb.AddForce (movement*speed);
    }
}
