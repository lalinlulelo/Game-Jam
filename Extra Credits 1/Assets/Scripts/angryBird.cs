using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angryBird : MonoBehaviour
{
    private int min = -2;
    private int max = 2;
    public float y;
    private Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D=GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody2D.AddForce(new Vector2(0,RandomNumber(min,max)));
    }

    // Generate a random number between two numbers
    public int RandomNumber(int min, int max)
    {
        System.Random random = new System.Random();
        return random.Next(min, max);
    }
}
