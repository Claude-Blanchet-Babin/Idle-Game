using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LotteryManager : MonoBehaviour
{
    // Déclaration des variables

    // Gestion du loot des coeurs
    public int RandomLoot;
    public int Minimum = 0;
    public int Maximum = 100;

    public int MaxRandomApple = 60;
    public int MaxRandomShell = 90;
    public int MaxRandomJewel = 99;

    public int NumberApple;
    public int NumberShell;
    public int NumberJewel;
    public int NumberHelios;

    public TextMeshProUGUI AppleUI;
    public TextMeshProUGUI ShellUI;
    public TextMeshProUGUI JewelUI;
    public TextMeshProUGUI HeliosUI;

    public bool AppleActiv = false;
    public bool ShellActiv = false;
    public bool JewelActiv = false;
    public bool HeliosActiv = false;

    /*
    public Vector3 PositionApple = new Vector3(8.3f, 4f, 0f);
    public Vector3 PositionShell = new Vector3(6.3f, 4f, 0f);
    public Vector3 PositionJewel = new Vector3(4.3f, 4f, 0f);
    public Vector3 PositionHelios = new Vector3(2.3f, 2f, 0f);
    */

    public GameObject Apple;
    public GameObject Shell;
    public GameObject Jewel;
    public GameObject Helios;

    public ScoreManager ReportScore;

    public BonusManager ReportBonus;

    public EnemyManager ReportEnemy;

    public int GainHelios =0;

    public GameObject AppleParchment;
    public GameObject ShellParchment;
    public GameObject JewelParchment;
    public GameObject HeliosParchment;

    public GameObject AppleParticle;
    public GameObject ShellParticle;
    public GameObject JewelParticle;
    public GameObject HeliosParticle;
    public GameObject AphroditeParticle;

    public Transform ParentAppleParticle;
    public Transform ParentShellParticle;
    public Transform ParentJewelParticle;
    public Transform ParentHeliosParticle;
    public Transform ParentAphroditeParticle;



    // Start is called before the first frame update
    void Start()
    {
        AppleUI.enabled = false;
        ShellUI.enabled = false;
        JewelUI.enabled = false;
        HeliosUI.enabled = false;

        Apple.SetActive(false);
        Shell.SetActive(false);
        Jewel.SetActive(false);
        Helios.SetActive(false);

        AppleParchment.SetActive(false);
        ShellParchment.SetActive(false);
        JewelParchment.SetActive(false);
        HeliosParchment.SetActive(false);
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
            ReportScore.RainbowUI.text = ": " + Mathf.Floor(ReportScore.ScoreRainbow);
            Instantiate(AphroditeParticle, ParentAphroditeParticle.position, ParentAphroditeParticle.rotation);

            // Définir un nombre alétoire lors d'un clic
            RandomLoot = Random.Range(Minimum, Maximum + 1);

            // Gagner une pomme
            if (RandomLoot <= MaxRandomApple)
            {
                // Vérifier si l'image est déjà affichée

                if (AppleActiv == false)
                {
                    AppleUI.enabled = true;
                    Apple.SetActive(true);
                    //Instantiate(Apple, PositionApple, Quaternion.identity);
                    AppleActiv = true;
                }

                NumberApple++;
                ReportEnemy.ClickDamage++;
                AppleUI.text = "" + NumberApple;
                Instantiate(AppleParticle, ParentAppleParticle.position, ParentAppleParticle.rotation);
            }

            // Gagner un coquillage
            if (RandomLoot > MaxRandomApple && RandomLoot <= MaxRandomShell)
            {
                // Vérifier si l'image est déjà affichée

                if (ShellActiv == false)
                {
                    ShellUI.enabled = true;
                    Shell.SetActive(true);
                    //Instantiate(Shell, PositionShell, Quaternion.identity);
                    ShellActiv = true;
                }

                NumberShell++;
                ReportScore.HeartIncrease++;
                ShellUI.text = "" + NumberShell;
                Instantiate(ShellParticle, ParentShellParticle.position, ParentShellParticle.rotation);
            }

            // Gagner un bijou
            if (RandomLoot > MaxRandomShell && RandomLoot <= MaxRandomJewel)
            {
                // Vérifier si l'image est déjà affichée

                if (JewelActiv == false)
                {
                    JewelUI.enabled = true;
                    Jewel.SetActive(true);
                    //Instantiate(Jewel, PositionJewel, Quaternion.identity);
                    JewelActiv = true;
                }

                NumberJewel++;
                ReportBonus.PowerTime++;
                JewelUI.text = "" + NumberJewel;
                Instantiate(JewelParticle, ParentJewelParticle.position, ParentJewelParticle.rotation);
            }

            // Gagner Helios
            if (RandomLoot == 100)
            {
                // Vérifier si l'image est déjà affichée

                if (HeliosActiv == false)
                {
                    HeliosUI.enabled = true;
                    Helios.SetActive(true);
                    //Instantiate(Helios, PositionHelios, Quaternion.identity);
                    HeliosActiv = true;
                }

                NumberHelios++;

                GainHelios++;

                ReportScore.HeartIncrease++;
                ReportEnemy.ClickDamage++;
                HeliosUI.text = "" + NumberHelios;
                Instantiate(HeliosParticle, ParentHeliosParticle.position, ParentHeliosParticle.rotation);
            }
        }
    }
}
