using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private Vector3 touchStart;
    public float dragSpeed = 0.05f; // Velocidade do arrasto

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStart = Camera.main.ScreenToWorldPoint(touch.position);
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(touch.position);
                Camera.main.transform.position += direction * dragSpeed;
            }
        }
    }
}
