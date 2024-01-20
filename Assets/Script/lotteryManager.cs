using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LotteryManager : MonoBehaviour
{
    // Déclaration des variables

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

    // Mise en place du bonus spécial
    public int GainHelios;

    // Start is called before the first frame update
    void Start()
    {
        // Remise à zéro de l'affichage des éléments
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

        // Bonus spcécial à zéro au début de la partie
        GainHelios = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Fonction appelé lors d'un click sur Aphrodite
    public void Lottery()
    {
        // Vérification du prix d'achat
        if (ReportScore.ScoreRainbow >= 5)
        {
            // Mise à jour de la quantité de coeur arc-en-ciel
            ReportScore.ScoreRainbow -= 5;
            ReportScore.RainbowUI.text = ": " + Mathf.Floor(ReportScore.ScoreRainbow);

            // Affichage des particules
            Instantiate(AphroditeParticle, ParentAphroditeParticle.position, ParentAphroditeParticle.rotation);

            // Définir un nombre alétoire lors d'un clic
            RandomLoot = Random.Range(Minimum, Maximum + 1);

            // Gagner une pomme de la discorde
            if (RandomLoot <= MaxRandomApple)
            {
                // Vérifier si l'image est déjà affichée

                if (AppleActiv == false)
                {
                    AppleUI.enabled = true;
                    Apple.SetActive(true);
                    AppleActiv = true;
                }

                NumberApple++;
                AppleUI.text = "" + NumberApple;

                // Augmentation des dégâts
                ReportEnemy.ClickDamage++;

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
                // Vérifier si l'image est déjà affichée
                if (JewelActiv == false)
                {
                    JewelUI.enabled = true;
                    Jewel.SetActive(true);
                    //Instantiate(Jewel, PositionJewel, Quaternion.identity);
                    JewelActiv = true;
                }

                NumberJewel++;
                JewelUI.text = "" + NumberJewel;

                // Augmentation de la durée des pouvoirs d'Athena et Tyche
                ReportBonus.PowerTime++;

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
                    HeliosActiv = true;
                }

                NumberHelios++;
                HeliosUI.text = "" + NumberHelios;

                // Augmentation du pouvoir Spécial, Amélioration dégâts, Amélioration puissance click
                GainHelios++;
                ReportScore.HeartIncrease++;
                ReportEnemy.ClickDamage++;

                Instantiate(HeliosParticle, ParentHeliosParticle.position, ParentHeliosParticle.rotation);
            }
        }
    }
}
