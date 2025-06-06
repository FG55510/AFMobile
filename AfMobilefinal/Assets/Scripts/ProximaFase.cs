using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximaFase : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fantasma"))
        {
            GameManager.Instance.Entregoufantasma();
        }
    }
}
