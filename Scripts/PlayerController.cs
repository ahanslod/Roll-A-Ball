using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private Vector3 startRb;
    private int count;
    private bool gameStarted;
    private GameObject[] gos;

    void Start () {
        rb = GetComponent<Rigidbody> ();
        gos = GameObject.FindGameObjectsWithTag ("Pick Up");
        gameStarted = false;
        DefaultScene ();
    }

    // Update is called once per frame and before rendering a frame
    void Update () {
        if (gameStarted == false) {
            if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow)) {
                StartGame ();
                gameStarted = true;
            }
        }
    }

    // Called before performing any physics calculations
    void FixedUpdate () {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        rb.AddForce (movement * speed);
    }

    void OnTriggerEnter (Collider other) {
        //Destroy(other.gameObject);
        if (other.gameObject.CompareTag ("Pick Up")) {
            other.gameObject.SetActive (false);
            count++;
            SetCountText ();
        }
    }

    void DefaultScene () {
        count = 0;
        SetCountText ();
        SetWinText ();
        HideObjects ();
    }

    void StartGame () {
        ShowObjects ();
    }

    void ResetGame () {
        DefaultScene ();
        StartGame ();
        transform.position = new Vector3 (0.0f, 0.5f, 0.0f);
    }

    void ShowObjects () {
        foreach (var go in gos)
            go.SetActive (true);
    }

    void HideObjects () {
        foreach (var go in gos)
            go.SetActive (false);
    }

    void SetCountText () {
        countText.text = "Score: " + count.ToString ();
        if (count >= 12) {
            SetWinText ();
            Invoke ("ResetGame", 5f);
        }
    }

    void SetWinText () {
        if (count < 12) {
            winText.text = "";
        } else {
            winText.text = "You Win!";
        }
    }

}