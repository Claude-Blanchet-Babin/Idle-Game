using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    // Déclaration des variables

    // Lien vers autre script
    public BonusManager ReportBonus;

    public Button AthenaButton;
    public Button TycheButton;

    public Color OriginalAthenaColor;
    public Color OriginalTycheColor;

    // Mise en place de la couleur pendant le cooldown
    public Color CooldownColor;


    // Start is called before the first frame update
    void Start()
    {
        // Enregistrez la couleur d'origine du bouton
        OriginalAthenaColor = AthenaButton.colors.normalColor;
        OriginalTycheColor = TycheButton.colors.normalColor;
    }

    // Update is called once per frame
    void Update()
    {
        // Vérification de la durée du cooldown pour changement de couleur

        if (ReportBonus.AthenaCooldown < 10)
        {
            AthenaButton.image.color = CooldownColor;
        }

        if (ReportBonus.AthenaCooldown >= 10)
        {
            AthenaButton.image.color = OriginalAthenaColor;
        }

        if (ReportBonus.TycheCooldown < 10)
        {
            TycheButton.image.color = CooldownColor;
        }

        if (ReportBonus.TycheCooldown >= 10)
        {
            TycheButton.image.color = OriginalAthenaColor;
        }

    }
}
