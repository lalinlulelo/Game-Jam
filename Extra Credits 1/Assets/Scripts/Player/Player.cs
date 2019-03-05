using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public float healthPoints=2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {                
    }

    public void TakeDamage(float damage)
    {
        healthPoints -= damage;

        if (healthPoints <= 0)
        {
            this.GetComponent<Animator>().SetBool("Shot", true);
            this.OnGameOver();
        }
    }
    

    private void OnGameOver() {
        Debug.Log("Game Over");
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }

    public void ApplyEfect(Type t) {
        if (t == typeof(Orange)) {
            this.healthPoints += 1;
        } else if (t == typeof(Coin)) {
            ApplicationModel.days += 10;
        }
    }
}
