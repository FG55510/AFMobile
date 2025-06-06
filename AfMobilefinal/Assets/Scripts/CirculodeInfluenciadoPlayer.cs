using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirculodeInfluenciadoPlayer : MonoBehaviour
{
    private float touchStartTime = 0f;
    private bool isLongTap = false;
    public float longTapDuration = 2f; // Tempo para considerar um long tap (5s)

    public GameObject circlePrefab;
    public float growthSpeed = 2f;
    public float maxSize = 3f;
    public float minSize = 0.1f;
    private GameObject currentCircle;
    public bool growcircle;


    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartTime = Time.time; // Marca o tempo inicial do toque
                isLongTap = true;
            }
            else if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                // Se o toque durar mais do que longTapDuration, aciona o evento
                if (isLongTap && (Time.time - touchStartTime >= longTapDuration))
                {

                    isLongTap = false; // Evita que seja chamado várias vezes
                    if (!growcircle)
                    {
                        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane));
                        touchPosition.z = 0; // Garante que o círculo esteja na mesma camada do plano onde você deseja que ele apareça
                        currentCircle = Instantiate(circlePrefab, touchPosition, Quaternion.identity); // Create circle at touch position
                        currentCircle.transform.localScale = new Vector3(minSize, minSize, 1); // Initial scale of the circle
                        growcircle = true;
                    }
                }
                
                if (growcircle)
                {
                    // Grow the circle
                    float size = Mathf.Min(currentCircle.transform.localScale.x + growthSpeed * Time.deltaTime, maxSize);
                    currentCircle.transform.localScale = new Vector3(size, size, 1);
                }
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                growcircle = false;
                Destroy(currentCircle);
                // Resetamos o temporizador se o toque for interrompido antes dos 5s
                isLongTap = false;
            }
        }
    }
}
