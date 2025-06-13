using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float moveDuration = 0.2f; // Duração do movimento após swipe

    private Rigidbody2D rb;
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private Vector2 moveDirection;

    private bool isMoving = false;
    private float moveTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        DetectSwipe();

        if (isMoving)
        {
            moveTimer -= Time.deltaTime;
            if (moveTimer <= 0f)
            {
                isMoving = false;
                rb.velocity = Vector2.zero; // Para o movimento
            }
        }
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            rb.velocity = moveDirection * moveSpeed;
        }
    }

    void DetectSwipe()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endTouchPosition = touch.position;
                Vector2 swipe = endTouchPosition - startTouchPosition;

                if (swipe.magnitude > 50f) // Mínimo para considerar um swipe
                {
                    swipe.Normalize();

                    if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
                        moveDirection = swipe.x > 0 ? Vector2.right : Vector2.left;
                    else
                        moveDirection = swipe.y > 0 ? Vector2.up : Vector2.down;

                    isMoving = true;
                    moveTimer = moveDuration;
                }
            }
        }
    }
}
