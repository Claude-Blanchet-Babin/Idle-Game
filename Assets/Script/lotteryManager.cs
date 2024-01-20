using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LotteryManager : MonoBehaviour
{
    // D�claration des variables

    // Gestion du loot des coeurs
    public int RandomLoot;
    public int Minimum;
    public int Maximum;

    public int MaxRandomApple;
    public int MaxRandomShell;
    public int MaxRandomJewel;

    // Gestion de l'inventaire
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

    public GameObject Apple;
    public GameObject Shell;
    public GameObject Jewel;
    public GameObject Helios;

    // Lien vers autre script
    public ScoreManager ReportScore;
    public BonusManager ReportBonus;
    public EnemyManager ReportEnemy;

    // Gestion de l'affichage de l'inventaire
    public GameObject AppleParchment;
    public GameObject ShellParchment;
    public GameObject JewelParchment;
    public GameObject HeliosParchment;

    // Gestion des particules
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

    // Mise en place du bonus sp�cial
    public int GainHelios;

    // Start is called before the first frame update
    void Start()
    {
        // Remise � z�ro de l'affichage des �l�ments
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

        //// AJUSTEMENT TAUX DE LOOT SI BESOIN ////

        MaxRandomApple = 60;
        MaxRandomShell = 90;
        MaxRandomJewel = 99;

        Minimum = 0;
        Maximum = 100;

        // Bonus spc�cial � z�ro au d�but de la partie
        GainHelios = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Fonction appel� lors d'un click sur Aphrodite
    public void Lottery()
    {
        // V�rification du prix d'achat
        if (ReportScore.ScoreRainbow >= 5)
        {
            // Mise � jour de la quantit� de coeur arc-en-ciel
            ReportScore.ScoreRainbow -= 5;
            ReportScore.RainbowUI.text = ": " + Mathf.Floor(ReportScore.ScoreRainbow);

            // Affichage des particules
            Instantiate(AphroditeParticle, ParentAphroditeParticle.position, ParentAphroditeParticle.rotation);

            // D�finir un nombre al�toire lors d'un clic
            RandomLoot = Random.Range(Minimum, Maximum + 1);

            // Gagner une pomme de la discorde
            if (RandomLoot <= MaxRandomApple)
            {
                // V�rifier si l'image est d�j� affich�e

                if (AppleActiv == false)
                {
                    AppleUI.enabled = true;
                    Apple.SetActive(true);
                    AppleActiv = true;
                }

                NumberApple++;
                AppleUI.text = "" + NumberApple;

                // Augmentation des d�g�ts
                ReportEnemy.ClickDamage++;

                Instantiate(AppleParticle, ParentAppleParticle.position, ParentAppleParticle.rotation);
            }

            // Gagner un coquillage
            if (RandomLoot > MaxRandomApple && RandomLoot <= MaxRandomShell)
            {
                // V�rifier si l'image est d�j� affich�e
                if (ShellActiv == false)
                {
                    ShellUI.enabled = true;
                    Shell.SetActive(true);
                    ShellActiv = true;
                }

                NumberShell++;
                ShellUI.text = "" + NumberShell;

                // Augmentation de la puissance du click (pour le bouton coeur)
                ReportScore.HeartIncrease++;

                Instantiate(ShellParticle, ParentShellParticle.position, ParentShellParticle.rotation);
            }

            // Gagner un bijou
            if (RandomLoot > MaxRandomShell && RandomLoot <= MaxRandomJewel)
            {
                // V�rifier si l'image est d�j� affich�e
                if (JewelActiv == false)
                {
                    JewelUI.enabled = true;
                    Jewel.SetActive(true);
                    //Instantiate(Jewel, PositionJewel, Quaternion.identity);
                    JewelActiv = true;
                }

                NumberJewel++;
                JewelUI.text = "" + NumberJewel;

                // Augmentation de la dur�e des pouvoirs d'Athena et Tyche
                ReportBonus.PowerTime++;

                Instantiate(JewelParticle, ParentJewelParticle.position, ParentJewelParticle.rotation);
            }

            // Gagner Helios
            if (RandomLoot == 100)
            {
                // V�rifier si l'image est d�j� affich�e
                if (HeliosActiv == false)
                {
                    HeliosUI.enabled = true;
                    Helios.SetActive(true);
                    HeliosActiv = true;
                }

                NumberHelios++;
                HeliosUI.text = "" + NumberHelios;

                // Augmentation du pouvoir Sp�cial, Am�lioration d�g�ts, Am�lioration puissance click
                GainHelios++;
                ReportScore.HeartIncrease++;
                ReportEnemy.ClickDamage++;

                Instantiate(HeliosParticle, ParentHeliosParticle.position, ParentHeliosParticle.rotation);
            }
        }
    }
}
