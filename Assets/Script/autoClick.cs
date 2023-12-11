using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoClick : MonoBehaviour
{

    public scoreManager report;
    public bool AutoPurchase = false;

    public Transform parent;
    public GameObject Arrow;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AutoCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator AutoCoroutine()
    {
        while (true)
        {
            if (AutoPurchase == true)
            {
                report.ScoreHearts += report.GainAuto;
                report.heartUI.text = "HEARTS : " + Mathf.Floor(report.ScoreHearts);
                
            }

            yield return new WaitForSeconds(1);
        }

    }

    public void Purchase()
    {
        if (report.ScoreGolden>= report.AutoPrice && AutoPurchase == false)
        {
            AutoPurchase = true;
            report.ScoreGolden -= report.AutoPrice;
            report.goldenUI.text = "GOLDEN HEARTS : " + report.ScoreGolden;
            Instantiate(Arrow, parent.position, parent.rotation);

        }

        if (AutoPurchase == true && report.ScoreHearts >= report.AutoPriceUpgrade)
        {
            report.GainAuto++;
            report.ScoreHearts -= report.AutoPriceUpgrade;
            report.heartUI.text = "HEARTS : " + Mathf.Floor(report.ScoreHearts);

            report.AutoPriceUpgrade = report.AutoPriceUpgrade * 1.10f;
        }
    }
}


