using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    //Take current transformed position of camera and subtract the transform position of the player
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Runs every frame after all items have been processed
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
