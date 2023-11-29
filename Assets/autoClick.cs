using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoClick : MonoBehaviour
{

    public scoreManager report;
    public bool autoActiv = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(testCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator testCoroutine()
    {
        while (true)
        {
            if (autoActiv == true)
            {
                report.score += 10;
                report.scoreUI.text = "Score : " + report.score;
            }

            yield return new WaitForSeconds(1);
        }

    }

    public void changeMode()
    {
        if(autoActiv == true)
        {
            autoActiv = false;
        }

        else
        {
            autoActiv = true;
        }
    }
}
