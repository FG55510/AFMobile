using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostStateMachine : MonoBehaviour
{
    public FantasmaMove move;


    public bool Isbeingcontrolled;

    public Sprite fantasma;
    private SpriteRenderer spriteRenderer;

    public bool efantasma;


    // Start is called before the first frame update
    void Start()
    {
        Isbeingcontrolled = false;
        move = GetComponent<FantasmaMove>();
        GameManager.Instance.Desassociarbixinhos.AddListener(DesativarControle);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Isbeingcontrolled)
        {
            move.enabled = true;
        }
        else
        {
            move.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Isbeingcontrolled = true;
            GameManager.Instance.MudarMododeJogo(ModosdeJogo.ControlandoItens);
            if (efantasma)
            {
                spriteRenderer.sprite = fantasma;
            }
            
        }
        
    }

    private void DesativarControle()
    {
        Isbeingcontrolled = false;
    }

    private void OnDestroy()
    {
        GameManager.Instance.Desassociarbixinhos.RemoveListener(DesativarControle);
    }
}
