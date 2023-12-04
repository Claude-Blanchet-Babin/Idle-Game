using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoClick : MonoBehaviour
{

    public scoreManager report;
    public bool autoActiv = false;
    public bool AutoPurchase = false;

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
            if (AutoPurchase == true)
            {
                report.ScoreHearts += report.GainAuto;
                report.heartUI.text = "HEARTS : " + report.ScoreHearts;
            }

            yield return new WaitForSeconds(1);
        }

    }

    public void changeMode()
    {
        /*
        if(autoActiv == true)
        {
            autoActiv = false;
        }

        else
        {
            autoActiv = true;
        }
        */
    }

    public void Purchase()
    {
        if (report.ScoreGolden>= report.AutoPrice && AutoPurchase == false)
        {
            AutoPurchase = true;
            report.ScoreGolden -= report.AutoPrice;
            report.goldenUI.text = "GOLDEN HEARTS : " + report.ScoreGolden;

        }

        if (AutoPurchase == true && report.ScoreHearts >= report.AutoPriceUpgrade)
        {
            report.GainAuto++;
            report.ScoreHearts -= report.AutoPriceUpgrade;
            report.heartUI.text = "HEARTS : " + report.ScoreHearts;

            report.AutoPriceUpgrade = report.AutoPriceUpgrade * 1.10f;
        }
    }
}
