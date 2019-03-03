using UnityEngine;
using UnityEditor;

public class Item : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        float fixedSpeed = speed * Time.deltaTime;
        transform.Translate(Vector2.left * fixedSpeed);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        collision.SendMessage("ApplyEfect", this.GetType());
        Destroy(gameObject);
    }
}