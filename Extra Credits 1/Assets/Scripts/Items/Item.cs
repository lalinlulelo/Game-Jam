using UnityEngine;
using UnityEditor;

public class Item : AutoDestroy
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            collision.SendMessage("ApplyEfect", this.GetType());
            Destroy(gameObject);
        }
    }
}