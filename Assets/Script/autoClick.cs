using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoClick : MonoBehaviour
{
    // Déclaration des variables

    public ScoreManager report;
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
            // Activer un gain automatique toute les secondes
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
        // Phase de premier achat du gain automatique
        if (report.ScoreGolden>= report.AutoPrice && AutoPurchase == false)
        {
            AutoPurchase = true;
            report.ScoreGolden -= report.AutoPrice;
            report.goldenUI.text = "GOLDEN HEARTS : " + Mathf.Floor(report.ScoreGolden);
            Instantiate(Arrow, parent.position, parent.rotation);
            report.autoPriceUI.text = "Golden : " + Mathf.Floor(report.AutoPriceUpgrade);

        }

        // Phase d'amélioration du gain automatique
        if (AutoPurchase == true && report.ScoreGolden >= report.AutoPriceUpgrade)
        {
            report.GainAuto++;
            report.ScoreGolden -= report.AutoPriceUpgrade;
            report.goldenUI.text = "GOLDEN HEARTS : " + Mathf.Floor(report.ScoreGolden);

            report.AutoPriceUpgrade = report.AutoPriceUpgrade * 1.10f;
            report.autoPriceUI.text = "Golden : " + Mathf.Floor(report.AutoPriceUpgrade);
        }
    }
}


