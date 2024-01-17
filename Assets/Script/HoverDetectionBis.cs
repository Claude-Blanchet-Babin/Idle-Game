using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverDetectionBis : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Appel� lorsque la souris entre dans la zone du bouton
    public void OnPointerEnter(PointerEventData eventData)
    {
        // V�rifiez si eventData.pointerEnter est un GameObject
        if (eventData.pointerEnter != null)
        {
            GameObject hoveredObject = eventData.pointerEnter;
            Debug.Log("Souris survolant le GameObject : " + hoveredObject.name);
            // Ajoutez votre logique sp�cifique ici en utilisant hoveredObject.
        }
    }

    // Appel� lorsque la souris quitte la zone du bouton
    public void OnPointerExit(PointerEventData eventData)
    {
        // Ajoutez votre logique ici, si n�cessaire.
    }
}
