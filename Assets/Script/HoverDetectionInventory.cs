using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverDetectionInventory : MonoBehaviour
{
    // D�claration des variables
    private bool IsMouseOver = false;

    //public GameObject Tooltip; => Ancien syst�me d'affichage. Suite � un probl�me d'affichage avec un texte et son background, une autre solution a �t� mise en place
    public GameObject Parchment;

    void Start()
    {
        //Tooltip.SetActive(false); => Ancien syst�me d'affichage.
    }

    // V�rification du passage de la souris sur un objet
    public void OnMouseEnter()
    {
        IsMouseOver = true;
    }

    // V�rification du d�part de la souris depuis l'objet
    public void OnMouseExit()
    {
        IsMouseOver = false;
    }

    void Update()
    {
        // Afficher message si souris dessus
        if (IsMouseOver)
        {
            //Tooltip.SetActive(true); => Ancien syst�me d'affichage.
            Parchment.SetActive(true);
        }

        // Retirer message si souris ailleurs
        if (IsMouseOver == false)
        {
            //Tooltip.SetActive(false); => Ancien syst�me d'affichage.
            Parchment.SetActive(false);
        }
    }
}
