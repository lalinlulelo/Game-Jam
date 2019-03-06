using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyItem : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        float fixedSpeed = speed * Time.deltaTime;
        transform.Translate(Vector2.left * fixedSpeed);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
