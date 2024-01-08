using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VfxDestruction : MonoBehaviour
{
    // Déclaration des variables

    public GameObject particle;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // faire en sorte que l'émetteur disparaisse au bout de quelques secondes
        timer += Time.deltaTime;
        if (timer >= 3)
        {
            Destroy(gameObject);
        }

    }
}
