﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float healthPoints;

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
            this.OnGameOver();
        }
    }
    

    private void OnGameOver() {
        Debug.Log("Game Over");
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }
}
