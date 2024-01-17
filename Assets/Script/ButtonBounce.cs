using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBounce : MonoBehaviour
{
    private Vector3 originalScale;

    void Start()
    {
        // Enregistrez l'échelle originale du bouton au démarrage
        originalScale = transform.localScale;

        // Assurez-vous que le bouton a un composant Button attaché
        Button button = GetComponent<Button>();
        if (button != null)
        {
            // Ajoutez une fonction pour gérer le clic du bouton
            button.onClick.AddListener(Bounce);
        }
    }

    void Bounce()
    {
        // Ajoutez votre logique spécifique au clic ici

        // Effectuez l'effet de rebond
        LeanTween.scale(gameObject, originalScale * 1.1f, 0.05f).setEase(LeanTweenType.easeOutQuad).setOnComplete(ResetScale);
    }

    void ResetScale()
    {
        // Rétablissez l'échelle initiale après l'effet de rebond
        LeanTween.scale(gameObject, originalScale, 0.1f).setEase(LeanTweenType.easeInQuad);
    }
}
