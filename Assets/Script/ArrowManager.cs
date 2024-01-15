using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    public ParticleSystem ArrowParticle;

    public AutoClick ReportAuto;
    public ScoreManager ReportScore;

    public bool ParticleActiv = false;

    public ParticleSystem.EmissionModule em; 

    // Start is called before the first frame update
    void Start()
    {
        ArrowParticle.Stop();

        ParticleSystem ps = GetComponent<ParticleSystem>();
        em = ArrowParticle.emission;
        em.enabled = true;


        em.SetBurst(0,new ParticleSystem.Burst(0.0f, new ParticleSystem.MinMaxCurve(ReportScore.GainAuto,ReportScore.GainAuto)));
    }

    // Update is called once per frame
    void Update()
    {
        if (ReportAuto.AutoPurchase == true && ParticleActiv == false)
        {
            ArrowParticle.Play();
            ParticleActiv = true;
        }

        ParticleSystem.Burst unBurst =  em.GetBurst(0);
        Debug.Log(ReportScore.GainAuto);
        //unBurst.count = new ParticleSystem.MinMaxCurve(ReportScore.GainAuto, ReportScore.GainAuto);
        unBurst.count = ReportScore.GainAuto;
        em.SetBurst(0,unBurst);
    }
}
