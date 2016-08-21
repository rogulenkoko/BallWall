using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

    private Vector3 target;

    private double speed = 3; 

    void Start()
    {
        target = new Vector3(transform.position.x, 200000f, transform.position.z);
    }

    void Update()
    {
        if (Camera.main.GetComponent<Score>().score > 15)
        {
            speed = 4;
            Camera.main.GetComponent<AudioSource>().pitch = (float)1.02;
        }
            
        if (Camera.main.GetComponent<Score>().score > 30)
        {
            speed = 5.5;
            Camera.main.GetComponent<AudioSource>().pitch = (float)1.04;

        }
            
        if (Camera.main.GetComponent<Score>().score > 60)
        {
            speed = 7;
            Camera.main.GetComponent<AudioSource>().pitch = (float)1.06;
        }
            
        if (Camera.main.GetComponent<Score>().score > 100)
        {
            speed = 8.5;
            Camera.main.GetComponent<AudioSource>().pitch = (float)1.08;
        }
            
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * (float)speed);
    }
}
