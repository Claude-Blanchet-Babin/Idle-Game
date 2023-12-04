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

    public int GainAuto = 2;
    public int AutoPrice = 20;
    public float AutoPriceUpgrade = 50;



    // Start is called before the first frame update
    void Start()
    {

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
            ScoreHearts++;
            heartUI.text = "HEARTS : " + ScoreHearts;
        }

        if (RandomLoot > MaxRandomNormal && RandomLoot <= MaxRandomGold)
        {
            ScoreGolden++;
            goldenUI.text = "GOLDEN HEARTS : " + ScoreGolden;
        }

        if (RandomLoot > MaxRandomGold && RandomLoot <= 100)
        {
            ScoreRainbow++;
            rainbowUI.text = "RAINBOW HEARTS : " + ScoreRainbow;
        }
    }

}
