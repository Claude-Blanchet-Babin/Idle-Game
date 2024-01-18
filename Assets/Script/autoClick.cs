using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoClick : MonoBehaviour
{
    // D�claration des variables

    public ScoreManager ReportScore;
    public LotteryManager ReportLottery;

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
                ReportScore.HeartUI.text = ": " + Mathf.Floor(ReportScore.ScoreHearts);
            }

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
            //Instantiate(Arrow, Parent.position, Parent.rotation);
            ReportScore.AutoPriceUI.text = ": " + Mathf.Floor(ReportScore.AutoPriceUpgrade);

        }

        // Phase d'am�lioration du gain automatique
        if (AutoPurchase == true && ReportScore.ScoreGolden >= ReportScore.AutoPriceUpgrade)
        {
            ReportScore.GainAuto++;
            ReportScore.ScoreGolden -= ReportScore.AutoPriceUpgrade;
            ReportScore.GoldenUI.text = ": " + Mathf.Floor(ReportScore.ScoreGolden);

            ReportScore.AutoPriceUpgrade = ReportScore.AutoPriceUpgrade * 1.10f;
            ReportScore.AutoPriceUI.text = ": " + Mathf.Floor(ReportScore.AutoPriceUpgrade);
        }
    }
}


