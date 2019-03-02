using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateAround : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float speed = 10;
    // Update is called once per frame
    void Update()
    {
        //primer parametro donde empieza, segundo ejes, tercero velocidad
        transform.RotateAround(Vector3.zero, Vector3.forward, speed * Time.deltaTime);
    }
}
