using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateAround : MonoBehaviour
{
    public Transform obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float speed = 100;
    // Update is called once per frame
    void Update()
    {
        //primer parametro donde empieza, segundo ejes, tercero velocidad
        transform.RotateAround(obj.position, Vector3.forward, speed * Time.deltaTime);
    }
}
