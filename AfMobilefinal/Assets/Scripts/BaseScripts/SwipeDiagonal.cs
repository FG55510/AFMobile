using UnityEngine;

public class SwipeDiagonal : MonoBehaviour
{
    Vector2 startTouchPosition, endTouchPosition;
    bool swipeDetected = false;
    public float swipeThreshold = 50f; // Distância mínima para ser considerado um swipe
    public float diagonalThreshold = 0.5f; // Define a sensibilidade para diagonais

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

                if (swipeDelta.magnitude > swipeThreshold)
                {
                    swipeDetected = true;
                    float x = swipeDelta.x;
                    float y = swipeDelta.y;

                    // Calcula a relação entre X e Y
                    float ratio = Mathf.Abs(x / y);

                    if (ratio > 1 + diagonalThreshold) // Swipe horizontal
                    {
                        if (x > 0)
                            Debug.Log("Swipe para a Direita");
                        else
                            Debug.Log("Swipe para a Esquerda");
                    }
                    else if (ratio < 1 - diagonalThreshold) // Swipe vertical
                    {
                        if (y > 0)
                            Debug.Log("Swipe para Cima");
                        else
                            Debug.Log("Swipe para Baixo");
                    }
                    else // Swipe diagonal
                    {
                        if (x > 0 && y > 0)
                            Debug.Log("Swipe Diagonal Superior Direita");
                        else if (x > 0 && y < 0)
                            Debug.Log("Swipe Diagonal Inferior Direita");
                        else if (x < 0 && y > 0)
                            Debug.Log("Swipe Diagonal Superior Esquerda");
                        else
                            Debug.Log("Swipe Diagonal Inferior Esquerda");
                    }
                }
            }
        }
    }
}
