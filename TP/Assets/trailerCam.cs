using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailerCam : MonoBehaviour
{
    public float speed = 1.2f;

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position - Vector3.forward * speed * Time.deltaTime;
    }
}
