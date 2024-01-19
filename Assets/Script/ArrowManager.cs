using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    // D�claration des variables

    // Variables particules
    public ParticleSystem ArrowParticle;
    public ParticleSystem.EmissionModule Em;

    // Lien vers autre script
    public AutoClick ReportAuto;
    public ScoreManager ReportScore;

    public bool ParticleActive = false;

    // Start is called before the first frame update
    void Start()
    {
        // S'assurer que l'�metteur est inactif
        ArrowParticle.Stop();

        // Rectification des param�tres de l'�metteur
        ParticleSystem ps = GetComponent<ParticleSystem>();
        Em = ArrowParticle.emission;
        Em.enabled = true;
        Em.SetBurst(0,new ParticleSystem.Burst(0.0f, new ParticleSystem.MinMaxCurve(ReportScore.GainAuto,ReportScore.GainAuto)));
    }

    // Update is called once per frame
    void Update()
    {
        // V�rification de l'achat du mode auto
        if (ReportAuto.AutoPurchase == true && ParticleActive == false)
        {
            ArrowParticle.Play();
            ParticleActive = true;
        }

        // Mise � jour des param�tres de l'�metteur
        ParticleSystem.Burst FirstBurst =  Em.GetBurst(0);
        FirstBurst.count = ReportScore.GainAuto;
        Em.SetBurst(0,FirstBurst);
    }
}
