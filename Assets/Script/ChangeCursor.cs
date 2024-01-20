using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ChangeCursor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // D�claration des variables
    public Texture2D CursorHeart;
    public Texture2D CursorArrow;

    void Start()
    {

    }

    // V�rification du passage de la souris sur le bouton
    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(CursorHeart, Vector2.zero, CursorMode.Auto);
    }

    // V�rification du d�part de la souris depuis le bouton
    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(CursorArrow, Vector2.zero, CursorMode.Auto);
    }

    void Update()
    {

    }
}
