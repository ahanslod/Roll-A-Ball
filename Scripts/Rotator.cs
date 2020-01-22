using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // Not using forces so we use Update instead of FixedUpdate
        transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
    }
}
