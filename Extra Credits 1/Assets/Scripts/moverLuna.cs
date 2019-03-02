using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverLuna : MonoBehaviour
{
    
    public float alpha = 0f;

    public float tilt = 0f;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(-(0f + (1f * MCos(alpha) * MSin(tilt)) + (5f * MSin(alpha) * MCos(tilt))),
            -(0f + (1f * MCos(alpha) * MCos(tilt)) - (5f * MSin(alpha) * MSin(tilt))));
        alpha += 0.5f;
    }
    float MCos(float value)
    {
        return Mathf.Cos(Mathf.Deg2Rad * value);
    }

    float MSin(float value)
    {
        return Mathf.Sin(Mathf.Deg2Rad * value);
    }
}
