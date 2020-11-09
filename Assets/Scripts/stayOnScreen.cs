using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stayOnScreen : MonoBehaviour
{
    public bool vertical;
    public bool horizontal;
    float xAxis;
    float yAxis;
    void Start()
    {
        float x = Screen.width;
        float y = Screen.height;

        float screenRatio = x / y;

        xAxis = Camera.main.orthographicSize * screenRatio;
        yAxis = Camera.main.orthographicSize;
    }
    void Update()
    {
        if (transform.position.x > xAxis && horizontal)
            transform.position = new Vector3(-xAxis, transform.position.y, transform.position.z);
        else if (transform.position.x < -xAxis && horizontal)
            transform.position = new Vector3(xAxis, transform.position.y, transform.position.z);
        if (transform.position.y > yAxis && vertical)
            transform.position = new Vector3(transform.position.x, -yAxis, transform.position.z);
        else if (transform.position.y < -yAxis && vertical)
            transform.position = new Vector3(transform.position.x, yAxis, transform.position.z);
    }
}
