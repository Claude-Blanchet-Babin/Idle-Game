using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverDetection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // D�claration des variables
    private bool IsMouseOver = false;

    public Texture2D CursorHeart;
    public Texture2D CursorArrow;

    //public GameObject Tooltip; => Ancien syst�me d'affichage. Suite � un probl�me d'affichage avec un texte et son background, une autre solution a �t� mise en place
    public GameObject Parchment;

    void Start()
    {
        //Tooltip.SetActive(false); => Ancien syst�me d'affichage.

        // R�initialisation affichage
        Parchment.SetActive(false);
    }

    // V�rification du passage de la souris sur le bouton
    public void OnPointerEnter(PointerEventData eventData)
    {
        IsMouseOver = true;
        Cursor.SetCursor(CursorHeart, Vector2.zero, CursorMode.Auto);
    }

    // V�rification du d�part de la souris depuis le bouton
    public void OnPointerExit(PointerEventData eventData)
    {
        IsMouseOver = false;
        Cursor.SetCursor(CursorArrow, Vector2.zero, CursorMode.Auto);
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
        if (IsMouseOver==false)
        {
            //Tooltip.SetActive(false); => Ancien syst�me d'affichage.
            Parchment.SetActive(false);
        }
    }
}
