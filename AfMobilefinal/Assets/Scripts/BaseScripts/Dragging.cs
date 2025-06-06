using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Dragging : MonoBehaviour
{
    private bool isDragging = false;

    public LayerMask Void;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case UnityEngine.TouchPhase.Began:
                    // Raycast2D para verificar se tocou no objeto
                    RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero, 1000f, Void);

                    if (hit.collider != null && hit.transform == transform) // Se tocou no objeto
                    {
                        isDragging = true;
                        hit.collider.enabled = false;
                    }
                    break;

                case UnityEngine.TouchPhase.Moved:
                    if (isDragging)
                    {
                        transform.position = touchPosition;
                    }
                    break;

                case UnityEngine.TouchPhase.Ended:
                    isDragging = false;
                    break;
            }
        }
    }
}

