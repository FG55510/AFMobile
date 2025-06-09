using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class BlocosMove : MonoBehaviour
{

    public float speed;
    public Vector2 movedirection;
    Rigidbody2D rb;
    public bool ismoving;
    Vector3 posicaocolisao;
    Vector2 input;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        input = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
            input += Vector2.up;
        if (Input.GetKey(KeyCode.S))
            input += Vector2.down;
        if (Input.GetKey(KeyCode.A))
            input += Vector2.left;
        if (Input.GetKey(KeyCode.D))
            input += Vector2.right;

        if (input != Vector2.zero && !ismoving)
        {
            Definirdirecao(input.normalized); // Normaliza para manter a velocidade constante
        }
    }
    void FixedUpdate()
    {
        if (ismoving)
        {
            rb.velocity = movedirection * speed;
        }
    }

    public void Definirdirecao(Vector2 direcao)
    {
        movedirection = direcao;
        ismoving = true;
        StartCoroutine(Parada(posicaocolisao));


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        posicaocolisao = transform.position;
        StartCoroutine(Parada(posicaocolisao));
    }

    public IEnumerator Parada(Vector3 test)
    {
        yield return new WaitForFixedUpdate();
        if(Vector3.Distance(test, transform.position) < 0.01f)
        {
            ismoving = false;
            rb.velocity = Vector2.zero;
        }
        yield return null;

    }

}
