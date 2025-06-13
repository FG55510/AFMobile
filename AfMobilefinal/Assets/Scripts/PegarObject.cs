using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarObject : MonoBehaviour
{
    public LayerMask objetos;
    public bool Fantasmas;

    public bool Isbeingcontrolled;

    // Start is called before the first frame update
    void Start()
    {
        Isbeingcontrolled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero, 1000f, objetos);
            if (hit.collider != null && hit.transform == transform) 
            {
                if (Fantasmas)
                {
                    GhostStateMachine ativate = hit.collider.GetComponent<GhostStateMachine>();
                    Isbeingcontrolled = true;
                    GameManager.Instance.MudarMododeJogo(ModosdeJogo.ControlandoItens);
                }
                else
                {
                    BlocosMove ativate = hit.collider.GetComponent<BlocosMove>();
                }
            }
        }
            

    }
}
