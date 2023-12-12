using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonusManager : MonoBehaviour
{
    public scoreManager report;

    public int ThunderPrice;
    public float ThunderTime;
    public float ThunderCooldown;


    // Start is called before the first frame update
    void Start()
    {
        ThunderPrice = 10;
        
    }

    // Update is called once per frame
    void Update()
    {
        ThunderTime += Time.deltaTime;

        if ( ThunderTime >= 10)
        {
            report.ThunderActiv = false;
        }

    }

    public void Thunder()
    {
        if (report.ScoreGolden >= ThunderPrice && report.ThunderActiv == false)
        {
            report.ThunderActiv = true;
            report.ScoreGolden -= ThunderPrice;
            report.goldenUI.text = "GOLDEN HEARTS : " + Mathf.Floor(report.ScoreGolden);
            ThunderTime = 0;

        }


    }
}
