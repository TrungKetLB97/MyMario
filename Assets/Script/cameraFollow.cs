using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    private Transform nhanvat;
    void Start()
    {
        nhanvat = GameObject.Find("player").transform;
    }

    void Update()
    {
        Vector3 cam = transform.position;
        cam.x = nhanvat.position.x;
        transform.position = cam;
    }
}
