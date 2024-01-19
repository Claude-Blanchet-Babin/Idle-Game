using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverDetectionInventory : MonoBehaviour
{
    private bool IsMouseOver = false;

    //public GameObject Tooltip;
    public GameObject Parchment;

    // Appelé lorsque la souris entre dans la zone du bouton

    void Start()
    {
        //Tooltip.SetActive(false);

    }
    public void OnMouseEnter()
    {
        IsMouseOver = true;
    }

    // Appelé lorsque la souris quitte la zone du bouton
    public void OnMouseExit()
    {
        IsMouseOver = false;
    }

    void Update()
    {
        if (IsMouseOver)
        {
            // Ajoutez votre logique ici, qui sera exécutée tant que la souris est sur le bouton.
            //Debug.Log("La souris est sur le bouton !");

            //Tooltip.SetActive(true);
            Parchment.SetActive(true);

        }

        if (IsMouseOver == false)
        {
            // Ajoutez votre logique ici, qui sera exécutée tant que la souris est sur le bouton.
            //Debug.Log("La souris est sur le bouton !");

            //Tooltip.SetActive(false);
            Parchment.SetActive(false);

        }


    }
}
