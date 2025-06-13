using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaFinal : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);

                if (hit.collider != null)
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        Debug.Log("Tocouporta");
                        GameManager.Instance.TestedeEntrega();
                    }
                }
            }
        }
    }
}
