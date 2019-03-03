using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverLuna : MonoBehaviour
{
    //no se para que sirven
    public float alpha = 0f;
    public float tilt = 0f;
    /*sirven para poner el punto de inicio, es decir, en que coordenadas empieza, 
     * solo ajustar en caso de querer que empiece en cierto punto, si no lo entiendes
     * PREGUNTAME!!!!
     */
     //copia del unity en transform las coordenadas
    public float xInicio = 0f;
    public float yInicio = 0f;
    public float zInicio = 0f;

    /*ajustando los dos primeros puedes prolongar horizontalmente, ve probando,
     los dos que siguen para prolongar verticalmente*/
    //los valores que he puesto es para que me sirva a mi
    public float primero = 5f;
    public float segundo = 10f;
    public float tercero = 6f;
    public float cuarto = 5f;
    // Update is called once per frame
    void Update()
    {
        //modificar el segundo parametro hace que se prolongue verticalmente, el primero horizontalmente
        transform.position = new Vector3((xInicio + (primero * MCos(alpha) * MSin(tilt)) + (segundo * MSin(alpha) * MCos(tilt))),
            (yInicio + (tercero * MCos(alpha) * MCos(tilt)) - (cuarto * MSin(alpha) * MSin(tilt))),zInicio);
        //modificar ajusta la velocidad, negativo de derecha a izquierda, positivo de izquierda a derecha
        alpha += -1f;
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
