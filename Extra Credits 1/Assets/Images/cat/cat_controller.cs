using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class cat_controller : MonoBehaviour
{
    Animator _anim;
    public float MoveSpeed = 2f;
    Vector3 Start_Scale;
    bool ground = false;
    public String nombreTag;
    public int jumpForce=2;
    void Start()
    {
        _anim = GetComponent<Animator>();
        Start_Scale = transform.localScale;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)&&ground)
        {            
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);                
        }
        else if (Input.GetKey(KeyCode.DownArrow) && ground)
        {
            _anim.SetBool("Move",true);
        }
        else
        {
            _anim.SetBool("Move", false);
        }



    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals(nombreTag))
        {
            ground = true;
            _anim.SetBool("Jump", false);

        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals(nombreTag))
            ground = false;
        _anim.SetBool("Jump", true);        
    }



}
