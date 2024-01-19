using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverDetection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool IsMouseOver = false;

    //public GameObject Tooltip;
    public GameObject Parchment;

    // Appelé lorsque la souris entre dans la zone du bouton

    void Start()
    {
        //Tooltip.SetActive(false);
        Parchment.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        IsMouseOver = true;
    }

    // Appelé lorsque la souris quitte la zone du bouton
    public void OnPointerExit(PointerEventData eventData)
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

        if (IsMouseOver==false)
        {
            // Ajoutez votre logique ici, qui sera exécutée tant que la souris est sur le bouton.
            //Debug.Log("La souris est sur le bouton !");

            //Tooltip.SetActive(false);
            Parchment.SetActive(false);

        }


    }
}
