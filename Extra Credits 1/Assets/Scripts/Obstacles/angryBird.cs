using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angryBird : MonoBehaviour
{
    private int min = -2;
    private int max = 2;
    public float y;
    //private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        //rigidbody=GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void Update()
    {
        //rigidbody.AddForce(new Vector2(0,0));
    }

    // Generate a random number between two numbers
    public int RandomNumber(int min, int max)
    {
        System.Random random = new System.Random();
        return random.Next(min, max);
    }
}
