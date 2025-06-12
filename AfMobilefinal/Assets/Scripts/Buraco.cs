using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buraco : MonoBehaviour
{
    public Sprite Full;
    SpriteRenderer sp;
    Collider2D col;

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bloco"))
        {
            sp.color = Color.white;
            Destroy(collision.gameObject);
            col.enabled = false;
        }
    }
}
