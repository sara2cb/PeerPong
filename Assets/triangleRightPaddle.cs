using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class triangleRightPaddle : MonoBehaviour
{
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
    public float speed = 1.0f;
    public float boundYtop = 3.5f;
    public float boundYbottom = 2.25f;
    public float boundXtop = 2.25f;
    public float boundXbottom = 2.25f;
    public float sixtyRadians = (float)(Math.PI * 60) / 180;
    private Rigidbody2D rb2d;
    //public bool lastHit = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        var vel = rb2d.velocity;
        if (Input.GetKey(moveLeft))
        {
            vel.x = -speed * Mathf.Cos(sixtyRadians);
            vel.y = -speed* Mathf.Sin(sixtyRadians);
        }
        else if (Input.GetKey(moveRight))
        {
            vel.x = speed * Mathf.Cos(sixtyRadians);
            vel.y = speed*  Mathf.Sin(sixtyRadians);
        }
        else
        {
            vel.x = 0;
            vel.y = 0;
        }
        rb2d.velocity = vel;

        var pos = transform.position;
        if (pos.y > boundYtop)
        {
            pos.y = boundYtop;
        }
        if (pos.y < boundYbottom)
        {
            pos.y = boundYbottom;
        }
        if (pos.x > boundXtop)
        {
            pos.x = boundXtop;
        }
        if (pos.x < boundXbottom)
        {
            pos.x = boundXbottom;
        }
        transform.position = pos;
    }
}