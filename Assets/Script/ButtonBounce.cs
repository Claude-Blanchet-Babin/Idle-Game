using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBounce : MonoBehaviour
{
    // D�claration des variables
    private Vector3 OriginalScale;

    void Start()
    {
        // Enregistrez l'�chelle originale du bouton au d�marrage
        OriginalScale = transform.localScale;

        // V�rifier la pr�sence d'un bouton
        Button button = GetComponent<Button>();
        if (button != null)
        {
            // Ajouter une fonction pour g�rer le clic du bouton
            button.onClick.AddListener(Bounce);
        }
    }

    void Bounce()
    {
        // Faire l'effet de rebond
        // Utilisation du LeanTween pour l'effet "smooth"
        LeanTween.scale(gameObject, OriginalScale * 1.1f, 0.05f).setEase(LeanTweenType.easeOutQuad).setOnComplete(ResetScale);
    }

    void ResetScale()
    {
        // R�tablir l'�chelle initiale apr�s l'effet de rebond
        // Utilisation du LeanTween pour l'effet "smooth"
        LeanTween.scale(gameObject, OriginalScale, 0.1f).setEase(LeanTweenType.easeInQuad);
    }
}
