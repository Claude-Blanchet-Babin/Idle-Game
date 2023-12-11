using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    public int score;

    public TextMeshProUGUI scoreUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            score ++ ;
            scoreUI.text = "Score : " + score;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            score++;
            scoreUI.text = "Score : " + score;
        }*/
    }

    /*void OnMouseDown()
    {
        score++;
        scoreUI.text = "Score : " + score;
    }*/
}
