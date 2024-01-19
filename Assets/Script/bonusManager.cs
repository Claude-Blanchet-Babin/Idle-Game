using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    // Déclaration des variables

    // Lien vers autre script
    public ScoreManager ReportScore;

    // Paramètres des pouvoirs d'Athena
    public int AthenaPrice;
    public float AthenaTime;
    public float AthenaCooldown;
    public bool AthenaActiv;

    // Paramètres des pouvoirs de Tyche
    public int TychePrice;
    public float TycheTime;
    public float TycheCooldown;
    public bool TycheActiv;

    // Durée des pouvoirs
    public float PowerTime;

    // Mise en place des particules
    public ParticleSystem AthenaParticle;
    public ParticleSystem TycheParticle;


    // Start is called before the first frame update
    void Start()
    {
        // Mise à jour des variables
        AthenaPrice = 10;
        TychePrice = 10;

        AthenaActiv = false;
        TycheActiv = false;

        PowerTime = 5;

        AthenaParticle.Stop();
        TycheParticle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        // Définir les temps des pouvoirs

        // Lancement des cooldown
        TycheCooldown += Time.deltaTime;
        AthenaCooldown += Time.deltaTime;

        // Lancement de la durée d'utilisation
        if (TycheActiv == true)
        {
            TycheTime += Time.deltaTime;
        }

        if (AthenaActiv == true)
        {
            AthenaTime += Time.deltaTime;
        }

        // Vérification de la fin des pouvoirs
        if (AthenaTime >= PowerTime)
        {
            AthenaTime = 0;
            AthenaActiv = false;
            AthenaCooldown = 0;
            AthenaParticle.Stop();
        }

        if (TycheTime >= PowerTime)
        {
            TycheTime = 0;
            TycheActiv = false;
            // Retour à la normale des valeurs de loot
            ReportScore.MaxRandomGold += ReportScore.TycheBoost;
            ReportScore.MaxRandomNormal -= ReportScore.TycheBoost;
            TycheCooldown = 0;
            TycheParticle.Stop();
        }
    }

    public void Athena()
    {
        // Définir le prix d'activation et vérifier le cooldown
        if (ReportScore.ScoreGolden >= AthenaPrice && AthenaActiv == false && AthenaCooldown>=10)
        {
            AthenaActiv = true;
            ReportScore.ScoreGolden -= AthenaPrice;
            ReportScore.GoldenUI.text = ": " + Mathf.Floor(ReportScore.ScoreGolden);
            AthenaTime = 0;
            AthenaParticle.Play();
        }
    }

    public void Tyche()
    {
        // Définir le prix d'activation et vérifier le cooldown
        if (ReportScore.ScoreGolden >= TychePrice && TycheActiv == false && TycheCooldown >= 10)
        {
            TycheActiv = true;
            ReportScore.ScoreGolden -= TychePrice;
            ReportScore.GoldenUI.text = ": " + Mathf.Floor(ReportScore.ScoreGolden);
            TycheTime = 0;

            // Changement des valeurs de loot
            ReportScore.MaxRandomGold -= ReportScore.TycheBoost;
            ReportScore.MaxRandomNormal += ReportScore.TycheBoost;
            TycheParticle.Play();
        }
    }
}
