using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBounce : MonoBehaviour
{
    private Vector3 originalScale;

    void Start()
    {
        // Enregistrez l'�chelle originale du bouton au d�marrage
        originalScale = transform.localScale;

        // Assurez-vous que le bouton a un composant Button attach�
        Button button = GetComponent<Button>();
        if (button != null)
        {
            // Ajoutez une fonction pour g�rer le clic du bouton
            button.onClick.AddListener(Bounce);
        }
    }

    void Bounce()
    {
        // Ajoutez votre logique sp�cifique au clic ici

        // Effectuez l'effet de rebond
        LeanTween.scale(gameObject, originalScale * 1.1f, 0.05f).setEase(LeanTweenType.easeOutQuad).setOnComplete(ResetScale);
    }

    void ResetScale()
    {
        // R�tablissez l'�chelle initiale apr�s l'effet de rebond
        LeanTween.scale(gameObject, originalScale, 0.1f).setEase(LeanTweenType.easeInQuad);
    }
}
