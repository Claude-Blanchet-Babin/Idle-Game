using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeColor : MonoBehaviour
{
    public BonusManager ReportBonus;

    public Button ThunderButton;
    public Button FriendButton;

    public Color OriginalThunderColor;
    public Color OriginalFriendColor;


    // Start is called before the first frame update
    void Start()
    {
        // Enregistrez la couleur d'origine du bouton
        OriginalThunderColor = ThunderButton.colors.normalColor;

        OriginalFriendColor = FriendButton.colors.normalColor;

    }

    // Update is called once per frame
    void Update()
    {
        if (ReportBonus.ThunderCooldown < 10)
        {
            ThunderButton.image.color = Color.black;
        }

        if (ReportBonus.ThunderCooldown >= 10)
        {
            ThunderButton.image.color = OriginalThunderColor;
        }

        if (ReportBonus.FriendCooldown < 10)
        {
            FriendButton.image.color = Color.black;
        }

        if (ReportBonus.FriendCooldown >= 10)
        {
            FriendButton.image.color = OriginalThunderColor;
        }

    }
}
