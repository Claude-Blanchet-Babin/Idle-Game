using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoClick : MonoBehaviour
{
    // Déclaration des variables

    // Lien vers autre script
    public ScoreManager ReportScore;
    public LotteryManager ReportLottery;

    public bool AutoPurchase;

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

    // Mise en place du gain automatique des coeurs
    public IEnumerator AutoCoroutine()
    {
        while (true)
        {
            // Activer un gain automatique de coeurs rouges toutes les secondes
            if (AutoPurchase == true)
            {
                ReportScore.ScoreHearts += ReportScore.GainAuto;
                ReportScore.HeartUI.text = ": " + Mathf.Floor(ReportScore.ScoreHearts);
            }

            // Gain de coeur en or en cas de possession d'Helios
            if (ReportLottery.HeliosActiv == true && AutoPurchase == true)
            {
                ReportScore.ScoreGolden += ReportLottery.GainHelios;
                ReportScore.GoldenUI.text = ": " + Mathf.Floor(ReportScore.ScoreGolden);
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
            ReportScore.GoldenUI.text = ": " + Mathf.Floor(ReportScore.ScoreGolden);
            ReportScore.AutoPriceUI.text = ": " + Mathf.Floor(ReportScore.AutoPriceUpgrade);
        }

        // Phase d'amélioration du gain automatique
        if (AutoPurchase == true && ReportScore.ScoreGolden >= ReportScore.AutoPriceUpgrade)
        {
            ReportScore.GainAuto++;
            ReportScore.ScoreGolden -= ReportScore.AutoPriceUpgrade;
            ReportScore.GoldenUI.text = ": " + Mathf.Floor(ReportScore.ScoreGolden);

            // Augmentation du prix de l'amélioration
            ReportScore.AutoPriceUpgrade = ReportScore.AutoPriceUpgrade * 1.10f;
            ReportScore.AutoPriceUI.text = ": " + Mathf.Floor(ReportScore.AutoPriceUpgrade);
        }
    }
}


