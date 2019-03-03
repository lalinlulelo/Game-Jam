using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Text score = GameObject.Find("Score").GetComponentInChildren<Text>();
        score.text = "Score: " + ApplicationModel.days.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
