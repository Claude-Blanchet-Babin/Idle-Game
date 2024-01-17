using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverDetection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool isMouseOver = false;

    public GameObject ThunderTooltip;

    // Appelé lorsque la souris entre dans la zone du bouton

    void Start()
    {
        ThunderTooltip.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        isMouseOver = true;
    }

    // Appelé lorsque la souris quitte la zone du bouton
    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseOver = false;
    }

    void Update()
    {
        if (isMouseOver)
        {
            // Ajoutez votre logique ici, qui sera exécutée tant que la souris est sur le bouton.
            Debug.Log("La souris est sur le bouton !");

            ThunderTooltip.SetActive(true);

        }

        if (isMouseOver==false)
        {
            // Ajoutez votre logique ici, qui sera exécutée tant que la souris est sur le bouton.
            Debug.Log("La souris est sur le bouton !");

            ThunderTooltip.SetActive(false);

        }


    }
}
