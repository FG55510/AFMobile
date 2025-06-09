using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantasmaMove : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 10;
    public float deadZone = 0.1f;
    public float pushforce;

    void Update()
    {
        Vector2 tilt = Input.acceleration;

        tilt.x = Mathf.Abs(tilt.x) < deadZone ? 0 : tilt.x;
        tilt.y = Mathf.Abs(tilt.y) < deadZone ? 0 : tilt.y;


        Vector2 direction = new Vector2(tilt.x * speed, tilt.y);
        rb.velocity = direction;

    }
}
