using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vfxDestruction : MonoBehaviour
{

    public GameObject particle;
    public float timer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // faire en sorte que l'�metteur disparaisse au bout de quelques secondes
        timer += Time.deltaTime;
        if (timer >= 3)
        {
            Destroy(gameObject);
        }

    }
}