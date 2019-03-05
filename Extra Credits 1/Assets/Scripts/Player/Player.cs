using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public float healthPoints=2;
    private float maximoCorrer;
    // Start is called before the first frame update
    void Start()
    {
        maximoCorrer = this.GetComponent<Transform>().position.x+limite;
    }

    // Update is called once per frame
    void Update()
    {                
    }

    public void TakeDamage(float damage)
    {
        healthPoints -= damage;
        GetComponent<Transform>().position=new Vector3(GetComponent<Transform>().position.x-this.cuantoRetroceder, GetComponent<Transform>().position.y,
            GetComponent<Transform>().position.z);
        limite++;
            //this.GetComponent<Animator>().SetBool("Shot", true);
            //this.OnGameOver();        
    }
    

    private void OnGameOver() {
        Debug.Log("Game Over");
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }
    public float cuantoAvanzar = 1f;
    public float cuantoRetroceder = 1f;
    public float limite=2f;
    public void ApplyEfect(Type t) {
        if (t == typeof(Orange)) {
            this.healthPoints += 1;
            if (this.GetComponent<Transform>().position.x<(this.maximoCorrer-0.5))
            {
                GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x + this.cuantoAvanzar, GetComponent<Transform>().position.y,
                GetComponent<Transform>().position.z);
                limite--;
            }
        } else if (t == typeof(Coin)) {
            ApplicationModel.days += 10;
        }
    }
}
