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
    public float jumpForce = 5f;
    public float downForce = 0.5f;
    public float longitudMaximaCaida = 1f;
    void Start()
    {
        _anim = GetComponent<Animator>();
        Start_Scale = transform.localScale;
    }
    private bool falling = false;
    void Update()
    {
        if (this.guardoUna&&falling && this.GetComponent<BoxCollider2D>().size.Equals(new Vector3(1f, 1f)) 
            && Math.Abs(this.devolver().y - this.GetComponent<Transform>().position.y) <= 0.1)
        {
            falling = false;
        }
        if (Input.GetKey(KeyCode.UpArrow) && ground&&!falling)
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.up * jumpForce;
        }
        else if (!falling && Input.GetKey(KeyCode.DownArrow)&&ground)
        {            
            if (guardoUna)
                    this.cargar();
                this.guardar();
                _anim.SetBool("Move", true);
                this.GetComponent<BoxCollider2D>().size = new Vector2(0.001f, 0.001f);
                falling = true;                       
        }else{
            if (this.guardoUna&&falling&&Math.Abs(this.devolver().y-this.GetComponent<Transform>().position.y)>=longitudMaximaCaida)
            {
                GetComponent<Rigidbody2D>().velocity = Vector3.up * longitudMaximaCaida;                                
                _anim.SetBool("Move", false);
                this.GetComponent<BoxCollider2D>().size = new Vector3(1f, 1f);
            }                        
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
        {
            ground = false;
            _anim.SetBool("Jump", true);
        }
    }
    private Vector3 v3;
    private bool guardoUna = false;
    void guardar()
    {
        this.v3 = this.GetComponent<Transform>().position;
        guardoUna = true;
    }    
    Vector3 devolver()
    {
        return this.v3;
    }
    void cargar()
    {
        this.GetComponent<Transform>().position=v3;
    }


}
