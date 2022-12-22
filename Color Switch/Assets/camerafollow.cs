using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public Transform ball;
    public Transform bg;
    public Transform ui;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < ball.position.y)
        {
            transform.position = new Vector3 (transform.position.x, ball.position.y, transform.position.z);
            bg.position = new Vector3(transform.position.x, ball.position.y, bg.position.z);
        }
        
    }
}
