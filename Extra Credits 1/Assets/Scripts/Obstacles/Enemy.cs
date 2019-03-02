using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;

    void Update()
    {
        float fixedSpeed = speed * Time.deltaTime;
        transform.Translate(Vector2.left * fixedSpeed);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.SendMessage("TakeDamage", damage);
            Destroy(gameObject);
        }
    }
}
