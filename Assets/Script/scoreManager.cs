using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // Déclaration des variables

    // Gestion du loot des coeurs
    public int RandomLoot;
    public int Minimum = 0;
    public int Maximum = 100;

    public int MaxRandomNormal;
    public int MaxRandomGold;

    // Gestion du score 
    public float ScoreHearts;
    public float ScoreGolden;
    public float ScoreRainbow;

    public float HeartIncrease;
    public float GoldenIncrease;

    //Affichage de l'interface
    public TextMeshProUGUI HeartUI;
    public TextMeshProUGUI GoldenUI;
    public TextMeshProUGUI RainbowUI;
    public TextMeshProUGUI AutoPriceUI;

    // Gestion du mode automatique
    public int GainAuto;
    public int AutoPrice;
    public float AutoPriceUpgrade;

    // Gestion des particules
    public GameObject RedParticle;
    public GameObject GoldParticle;
    public GameObject RainbowParticle;

    public Transform Parent;

    // Gestion des bonus
    public BonusManager ReportBonus;

    public float AthenaBoost;
    public int AthenaDamage;

    public int TycheBoost;


    // Start is called before the first frame update
    void Start()
    {
        // Mise à jour des variables
        AutoPrice = 1;
        AutoPriceUpgrade = 1;
        GainAuto = 1;
        AthenaBoost = 10;
        AthenaDamage = 3;
        TycheBoost = 10;

        MaxRandomNormal = 70;
        MaxRandomGold = 95;

        HeartIncrease = 1; 
        GoldenIncrease = 1;
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void Increase()
    {
        // Mise en place du loot des coeurs

        // Définir un nombre alétoire lors d'un clic
        RandomLoot = Random.Range(Minimum, Maximum+1);

        // Gagner un coeur normal
        if (RandomLoot <= MaxRandomNormal)
        {
            // Gagner un seul coeur si le boost n'est pas actif
            if(ReportBonus.AthenaActiv == false)
            {
                ScoreHearts+= HeartIncrease;
                HeartUI.text = ": " + Mathf.Floor(ScoreHearts);
                Instantiate(RedParticle, Parent.position, Parent.rotation);
            }

            // Gagner plus de coeurs si le boost est actif
            if (ReportBonus.AthenaActiv == true)
            {
                ScoreHearts+=AthenaBoost + HeartIncrease;
                HeartUI.text = ": " + Mathf.Floor(ScoreHearts);
                Instantiate(RedParticle, Parent.position, Parent.rotation);
            }
        }

        // Gagner un coeur en or
        if (RandomLoot > MaxRandomNormal && RandomLoot <= MaxRandomGold)
        {
            ScoreGolden+= GoldenIncrease;
            GoldenUI.text = ": " + Mathf.Floor(ScoreGolden);
            Instantiate(GoldParticle, Parent.position, Parent.rotation);
        }

        // Gagner un coeur arc-en-ciel
        if (RandomLoot > MaxRandomGold && RandomLoot <= 100)
        {
            ScoreRainbow++;
            RainbowUI.text = ": " + Mathf.Floor(ScoreRainbow);
            Instantiate(RainbowParticle, Parent.position, Parent.rotation);
        }
    }
}
