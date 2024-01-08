using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoClick : MonoBehaviour
{
    // Déclaration des variables

    public ScoreManager ReportScore;

    public bool AutoPurchase;

    public Transform Parent;
    public GameObject Arrow;

    // Start is called before the first frame update
    void Start()
    {
        AutoPurchase = false;
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
                ReportScore.ScoreHearts += ReportScore.GainAuto;
                ReportScore.HeartUI.text = "HEARTS : " + Mathf.Floor(ReportScore.ScoreHearts);
            }

            yield return new WaitForSeconds(1);
        }

    }

    public void Purchase()
    {
        // Phase de premier achat du gain automatique
        if (ReportScore.ScoreGolden>= ReportScore.AutoPrice && AutoPurchase == false)
        {
            AutoPurchase = true;
            ReportScore.ScoreGolden -= ReportScore.AutoPrice;
            ReportScore.GoldenUI.text = "GOLDEN HEARTS : " + Mathf.Floor(ReportScore.ScoreGolden);
            Instantiate(Arrow, Parent.position, Parent.rotation);
            ReportScore.AutoPriceUI.text = "Golden : " + Mathf.Floor(ReportScore.AutoPriceUpgrade);

        }

        // Phase d'amélioration du gain automatique
        if (AutoPurchase == true && ReportScore.ScoreGolden >= ReportScore.AutoPriceUpgrade)
        {
            ReportScore.GainAuto++;
            ReportScore.ScoreGolden -= ReportScore.AutoPriceUpgrade;
            ReportScore.GoldenUI.text = "GOLDEN HEARTS : " + Mathf.Floor(ReportScore.ScoreGolden);

            ReportScore.AutoPriceUpgrade = ReportScore.AutoPriceUpgrade * 1.10f;
            ReportScore.AutoPriceUI.text = "Golden : " + Mathf.Floor(ReportScore.AutoPriceUpgrade);
        }
    }
}


