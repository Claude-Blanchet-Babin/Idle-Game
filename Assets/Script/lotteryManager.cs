using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class lotteryManager : MonoBehaviour
{
    // D�claration des variables

    // Gestion du loot des coeurs
    public int RandomLoot;
    public int Minimum = 0;
    public int Maximum = 100;

    public int MaxRandomApple = 60;
    public int MaxRandomShell = 90;
    public int MaxRandomJewell = 99;

    public int NumberApple;
    public int NumberShell;
    public int NumberJewell;
    public int NumberAphrodite;

    public TextMeshProUGUI AppleUI;
    public TextMeshProUGUI ShellUI;
    public TextMeshProUGUI JewellUI;
    public TextMeshProUGUI AphroditeUI;

    public bool AppleActiv = false;
    public bool ShellActiv = false;
    public bool JewellActiv = false;
    public bool AphroditeActiv = false;

    public Vector3 PositionApple = new Vector3(8.3f, 4f, 0f);
    public Vector3 PositionShell = new Vector3(6.3f, 4f, 0f);
    public Vector3 PositionJewell = new Vector3(4.3f, 4f, 0f);
    public Vector3 PositionAphrodite = new Vector3(2.3f, 2f, 0f);

    public GameObject Apple;
    public GameObject Shell;
    public GameObject Jewell;
    public GameObject Aphrodite;

    public ScoreManager ReportScore;

    public BonusManager ReportBonus;

    public EnemyManager ReportEnemy;

    public int GainAphrodite =0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Lottery()
    {
        if (ReportScore.ScoreRainbow >= -50000)
        {

            ReportScore.ScoreRainbow -= 5;
            ReportScore.RainbowUI.text = "RAINBOW HEARTS : " + Mathf.Floor(ReportScore.ScoreRainbow);

            // D�finir un nombre al�toire lors d'un clic
            RandomLoot = Random.Range(Minimum, Maximum + 1);

            // Gagner une pomme
            if (RandomLoot <= MaxRandomApple)
            {
                // V�rifier si l'image est d�j� affich�e

                if (AppleActiv == false)
                {
                    Instantiate(Apple, PositionApple, Quaternion.identity);
                    AppleActiv = true;
                }

                NumberApple++;
                ReportEnemy.ClickDamage++;
                AppleUI.text = "" + NumberApple;
            }

            // Gagner un coquillage
            if (RandomLoot > MaxRandomApple && RandomLoot <= MaxRandomShell)
            {
                // V�rifier si l'image est d�j� affich�e

                if (ShellActiv == false)
                {
                    Instantiate(Shell, PositionShell, Quaternion.identity);
                    ShellActiv = true;
                }

                NumberShell++;
                ReportScore.HeartIncrease++;
                ShellUI.text = "" + NumberShell;
            }

            // Gagner un bijou
            if (RandomLoot > MaxRandomShell && RandomLoot <= MaxRandomJewell)
            {
                // V�rifier si l'image est d�j� affich�e

                if (JewellActiv == false)
                {
                    Instantiate(Jewell, PositionJewell, Quaternion.identity);
                    JewellActiv = true;
                }

                NumberJewell++;
                ReportBonus.PowerTime++;
                JewellUI.text = "" + NumberJewell;
            }

            // Gagner Aphrodite
            if (RandomLoot == 100)
            {
                // V�rifier si l'image est d�j� affich�e

                if (AphroditeActiv == false)
                {
                    Instantiate(Aphrodite, PositionAphrodite, Quaternion.identity);
                    AphroditeActiv = true;
                }

                NumberAphrodite++;

                GainAphrodite++;

                ReportScore.HeartIncrease++;
                ReportEnemy.ClickDamage++;
                AphroditeUI.text = "" + NumberAphrodite;
            }
        }
    }
}
