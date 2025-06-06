using UnityEngine;

public class PinchZoom2D : MonoBehaviour
{
    public float zoomSpeed = 0.001f;  // Velocidade do zoom
    public float minZoom = .1f;  // Zoom mínimo
    public float maxZoom = 20f; // Zoom máximo

    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            // Calcula a distância entre os dois toques no frame anterior e atual
            float prevDistance = (touch0.position - touch0.deltaPosition - (touch1.position - touch1.deltaPosition)).magnitude;
            float currentDistance = (touch0.position - touch1.position).magnitude;

            // Diferença da distância
            float difference = prevDistance - currentDistance;

            // Aplica o zoom na câmera ortográfica
            Camera.main.orthographicSize += difference * zoomSpeed;
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minZoom, maxZoom);
        }
    }
}
