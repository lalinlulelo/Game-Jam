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
        _anim.SetBool("jumpDan", false);
        _anim.SetBool("downDan", false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)&&ground)
        {            
                _anim.SetBool("jumpDan", true);                                    //1.Change to Jump State, and Play JumpAnimation.
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);                
        }
        else
        {
            _anim.SetBool("jumpDan", false);
        }


    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals(nombreTag))
            ground = true;
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals(nombreTag))
            ground = false;
    }



}
