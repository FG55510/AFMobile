using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerpegaFantasma : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Fantasma")) {
            GameManager.Instance.AdicionaFantasma();
        }
    }
}
