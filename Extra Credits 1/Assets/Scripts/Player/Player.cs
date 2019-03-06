using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;

public class Player : MonoBehaviour
{
    public float healthPoints = 2;
    private float maximoCorrer;
    private bool isInvincible = false;
    DateTime timeInvincible;

    // Start is called before the first frame update
    void Start()
    {
        maximoCorrer = this.GetComponent<Transform>().position.x + limite;
    }
    private bool sigueEntrando = false;
    // Update is called once per frame
    void Update()
    {
        DateTime currentTime = DateTime.Now;
        double milliseconds = (currentTime - timeInvincible).TotalMilliseconds;
        if (milliseconds > 3000)
        {
            isInvincible = false;
        }
        if (this.GetComponent<Animator>().GetBool("Shot")||sigueEntrando)
        {
            sigueEntrando = true;
            currentTime = DateTime.Now;
            milliseconds = (currentTime - fin).TotalMilliseconds;
            //cambiar este numero para la duracion
            if (milliseconds > 2000)
            {
                this.OnGameOver();
            }
        }
        
    }

    public void TakeDamage(float damage)
    {
        if (!isInvincible)
        {
            healthPoints -= damage;
            GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x - this.cuantoRetroceder, GetComponent<Transform>().position.y,
                GetComponent<Transform>().position.z);
            limite++;
        }        
    }


    private void OnGameOver()
    {
        Debug.Log("Game Over");
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }
    public float cuantoAvanzar = 1f;
    public float cuantoRetroceder = 1f;
    public float limite = 2f;
    public void ApplyEffect(Type t)
    {
        if (t == typeof(Orange))
        {
            this.healthPoints += 1;
            if (this.GetComponent<Transform>().position.x < (this.maximoCorrer - 0.5))
            {
                GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x + this.cuantoAvanzar, GetComponent<Transform>().position.y,
                GetComponent<Transform>().position.z);
                limite--;
            }
        }
        else if (t == typeof(Coin))
        {
            ApplicationModel.days += 10;
        }
        else if (t == typeof(FalseCoin))
        {
            ApplicationModel.days -= 15;
        }
        else if (t == typeof(Cookie))
        {
            isInvincible = true;
            timeInvincible = DateTime.Now;
        }
    }
    private DateTime fin;
    private bool primeraVez = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Human")&&!primeraVez)
        {
            this.GetComponent<Animator>().SetBool("Shot", true);
            fin = DateTime.Now;
            primeraVez = true;
        }
    }
}
