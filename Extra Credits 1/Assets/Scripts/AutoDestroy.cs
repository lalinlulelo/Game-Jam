using UnityEngine;
using UnityEditor;

public class AutoDestroy : MonoBehaviour
{
    void OnBecameInvisible()
    {
            Destroy(gameObject);
    }
}