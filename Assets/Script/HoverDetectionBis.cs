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

    // Appelé lorsque la souris entre dans la zone du bouton
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Vérifiez si eventData.pointerEnter est un GameObject
        if (eventData.pointerEnter != null)
        {
            GameObject hoveredObject = eventData.pointerEnter;
            Debug.Log("Souris survolant le GameObject : " + hoveredObject.name);
            // Ajoutez votre logique spécifique ici en utilisant hoveredObject.
        }
    }

    // Appelé lorsque la souris quitte la zone du bouton
    public void OnPointerExit(PointerEventData eventData)
    {
        // Ajoutez votre logique ici, si nécessaire.
    }
}
