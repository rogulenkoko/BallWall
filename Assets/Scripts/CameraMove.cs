﻿using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

    private Vector3 target;

    private int speed = 3; 

    void Start()
    {
        target = new Vector3(transform.position.x, 200000f, transform.position.z);
    }

    void Update()
    {
        if (Camera.main.GetComponent<Score>().score > 15)
            speed = 4;
        if (Camera.main.GetComponent<Score>().score > 30)
            speed = 5;
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
    }
}