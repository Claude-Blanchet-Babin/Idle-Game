using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    public ParticleSystem ArrowParticle;

    public AutoClick ReportAuto;

    public bool ParticleActiv = false;

    // Start is called before the first frame update
    void Start()
    {
        ArrowParticle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (ReportAuto.AutoPurchase == true && ParticleActiv == false)
        {
            ArrowParticle.Play();
            ParticleActiv = true;
        }


    }
}
