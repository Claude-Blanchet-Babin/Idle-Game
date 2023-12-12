using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreManager : MonoBehaviour
{
    public int RandomLoot;
    public int Minimum = 0;
    public int Maximum = 100;

    public int MaxRandomNormal = 70;
    public int MaxRandomGold = 95;


    public float ScoreHearts;
    public float ScoreGolden;
    public float ScoreRainbow;

    public TextMeshProUGUI heartUI;
    public TextMeshProUGUI goldenUI;
    public TextMeshProUGUI rainbowUI;
    public TextMeshProUGUI autoPriceUI;

    public int GainAuto;
    public int AutoPrice;
    public float AutoPriceUpgrade;

    public GameObject RedParticle;
    public GameObject GoldParticle;
    public GameObject RainbowParticle;

    public Transform Parent;

    public bool ThunderActiv;
    public float ThunderBoost;
    public int ThunderDamage;

    // Start is called before the first frame update
    void Start()
    {
        AutoPrice = 10;
        AutoPriceUpgrade = 15;
        GainAuto = 1;
        ThunderActiv = false;
        ThunderBoost = 10;
        ThunderDamage = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increase()
    {
        RandomLoot = Random.Range(Minimum, Maximum+1);

        if (RandomLoot <= MaxRandomNormal)
        {
            if(ThunderActiv == false)
            {
                ScoreHearts++;
                heartUI.text = "HEARTS : " + Mathf.Floor(ScoreHearts);
                Instantiate(RedParticle, Parent.position, Parent.rotation);
            }

            if (ThunderActiv == true)
            {
                ScoreHearts+=ThunderBoost;
                heartUI.text = "HEARTS : " + Mathf.Floor(ScoreHearts);
                Instantiate(RedParticle, Parent.position, Parent.rotation);
            }

        }

        if (RandomLoot > MaxRandomNormal && RandomLoot <= MaxRandomGold)
        {
            ScoreGolden++;
            goldenUI.text = "GOLDEN HEARTS : " + Mathf.Floor(ScoreGolden);
            Instantiate(GoldParticle, Parent.position, Parent.rotation);
        }

        if (RandomLoot > MaxRandomGold && RandomLoot <= 100)
        {

            ScoreRainbow++;
            rainbowUI.text = "RAINBOW HEARTS : " + Mathf.Floor(ScoreRainbow);
            Instantiate(RainbowParticle, Parent.position, Parent.rotation);


        }
    }

}
