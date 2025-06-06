using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostsMoviment : MonoBehaviour
{
    public Joystick joystick;
    public float speed = 5f;

    private Rigidbody2D rb;

    //public Animator anim;

    void Start()
    {
       // anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        joystick = FindAnyObjectByType<Joystick>();
    }

    void Update()
    {

        Vector2 move = joystick.Direction * speed;
        rb.velocity = new Vector2(move.x, move.y);
    }


}
