using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform nhanvat;
    void Start()
    {
        nhanvat = GameObject.Find("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cam = transform.position;
        cam.x = nhanvat.position.x;
        transform.position = cam;
    }
}
