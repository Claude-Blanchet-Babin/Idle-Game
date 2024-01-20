using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverDetectionInventory : MonoBehaviour
{
    // Déclaration des variables
    private bool IsMouseOver = false;

    //public GameObject Tooltip; => Ancien système d'affichage. Suite à un problème d'affichage avec un texte et son background, une autre solution a été mise en place
    public GameObject Parchment;

    void Start()
    {
        //Tooltip.SetActive(false); => Ancien système d'affichage.
    }

    // Vérification du passage de la souris sur un objet
    public void OnMouseEnter()
    {
        IsMouseOver = true;
    }

    // Vérification du départ de la souris depuis l'objet
    public void OnMouseExit()
    {
        IsMouseOver = false;
    }

    void Update()
    {
        // Afficher message si souris dessus
        if (IsMouseOver)
        {
            //Tooltip.SetActive(true); => Ancien système d'affichage.
            Parchment.SetActive(true);
        }

        // Retirer message si souris ailleurs
        if (IsMouseOver == false)
        {
            //Tooltip.SetActive(false); => Ancien système d'affichage.
            Parchment.SetActive(false);
        }
    }
}
