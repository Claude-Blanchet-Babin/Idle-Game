using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBounce : MonoBehaviour
{
    // Déclaration des variables
    private Vector3 OriginalScale;

    void Start()
    {
        // Enregistrez l'échelle originale du bouton au démarrage
        OriginalScale = transform.localScale;

        // Vérifier la présence d'un bouton
        Button button = GetComponent<Button>();
        if (button != null)
        {
            // Ajouter une fonction pour gérer le clic du bouton
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
        // Rétablir l'échelle initiale après l'effet de rebond
        // Utilisation du LeanTween pour l'effet "smooth"
        LeanTween.scale(gameObject, OriginalScale, 0.1f).setEase(LeanTweenType.easeInQuad);
    }
}
