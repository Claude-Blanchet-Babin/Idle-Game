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

    public float ThunderBoost;
    public int ThunderDamage;

    public int FriendBoost;


    // Start is called before the first frame update
    void Start()
    {
        // Mise à jour des variables
        AutoPrice = 10;
        AutoPriceUpgrade = 15;
        GainAuto = 1;
        ThunderBoost = 10;
        ThunderDamage = 3;
        FriendBoost = 10;

        MaxRandomNormal = 70;
        MaxRandomGold = 95;
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void increase()
    {
        // Mise en place du loot des coeurs

        // Définir un nombre alétoire lors d'un clic
        RandomLoot = Random.Range(Minimum, Maximum+1);

        // Gagner un coeur normal
        if (RandomLoot <= MaxRandomNormal)
        {
            // Gagner un seul coeur si le boost n'est pas actif
            if(ReportBonus.ThunderActiv == false)
            {
                ScoreHearts++;
                HeartUI.text = "HEARTS : " + Mathf.Floor(ScoreHearts);
                Instantiate(RedParticle, Parent.position, Parent.rotation);
            }

            // Gagner plus de coeurs si le boost est actif
            if (ReportBonus.ThunderActiv == true)
            {
                ScoreHearts+=ThunderBoost;
                HeartUI.text = "HEARTS : " + Mathf.Floor(ScoreHearts);
                Instantiate(RedParticle, Parent.position, Parent.rotation);
            }
        }

        // Gagner un coeur en or
        if (RandomLoot > MaxRandomNormal && RandomLoot <= MaxRandomGold)
        {
            ScoreGolden++;
            GoldenUI.text = "GOLDEN HEARTS : " + Mathf.Floor(ScoreGolden);
            Instantiate(GoldParticle, Parent.position, Parent.rotation);
        }

        // Gagner un coeur arc-en-ciel
        if (RandomLoot > MaxRandomGold && RandomLoot <= 100)
        {
            ScoreRainbow++;
            RainbowUI.text = "RAINBOW HEARTS : " + Mathf.Floor(ScoreRainbow);
            Instantiate(RainbowParticle, Parent.position, Parent.rotation);
        }
    }
}
