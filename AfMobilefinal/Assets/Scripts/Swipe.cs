using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    Vector2 startTouchPosition, endTouchPosition;
    bool swipeDetected = false;
    
    void Update()
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
                Vector2 swipeDelta = endTouchPosition - startTouchPosition;

                if (swipeDelta.magnitude > 50)
                {
                    swipeDetected = true;

                    if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
                    {
                        if (swipeDelta.x > 0)
                            Debug.Log("Swipe para a direita");
                        else
                            Debug.Log("Swipe para a esquerda");
                    }
                    else
                    {
                        if (swipeDelta.y > 0)
                            Debug.Log("Swipe para cima");
                        else
                            Debug.Log("Swipe para baixo");
                    }
                }
            }
        }
    }
}
