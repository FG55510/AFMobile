using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantasmaLife : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MataFantasma"))
        {
            GameManager.Instance.Fantasmamorreu();
        }
        Destroy(gameObject, 0);
    }
}
