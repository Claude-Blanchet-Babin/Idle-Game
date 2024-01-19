using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    // D�claration des variables

    // Lien vers autre script
    public ScoreManager ReportScore;

    // Param�tres des pouvoirs d'Athena
    public int AthenaPrice;
    public float AthenaTime;
    public float AthenaCooldown;
    public bool AthenaActiv;

    // Param�tres des pouvoirs de Tyche
    public int TychePrice;
    public float TycheTime;
    public float TycheCooldown;
    public bool TycheActiv;

    // Dur�e des pouvoirs
    public float PowerTime;

    // Mise en place des particules
    public ParticleSystem AthenaParticle;
    public ParticleSystem TycheParticle;


    // Start is called before the first frame update
    void Start()
    {
        // Mise � jour des variables
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
        // D�finir les temps des pouvoirs

        // Lancement des cooldown
        TycheCooldown += Time.deltaTime;
        AthenaCooldown += Time.deltaTime;

        // Lancement de la dur�e d'utilisation
        if (TycheActiv == true)
        {
            TycheTime += Time.deltaTime;
        }

        if (AthenaActiv == true)
        {
            AthenaTime += Time.deltaTime;
        }

        // V�rification de la fin des pouvoirs
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
            // Retour � la normale des valeurs de loot
            ReportScore.MaxRandomGold += ReportScore.TycheBoost;
            ReportScore.MaxRandomNormal -= ReportScore.TycheBoost;
            TycheCooldown = 0;
            TycheParticle.Stop();
        }
    }

    public void Athena()
    {
        // D�finir le prix d'activation et v�rifier le cooldown
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
        // D�finir le prix d'activation et v�rifier le cooldown
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
