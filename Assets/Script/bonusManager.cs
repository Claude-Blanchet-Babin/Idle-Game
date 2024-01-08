using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    // D�claration des variables

    public ScoreManager ReportScore;

    public int ThunderPrice;
    public float ThunderTime;
    public float ThunderCooldown;

    public bool ThunderActiv;

    public int FriendPrice;
    public float FriendTime;
    public float FriendCooldown;

    public bool FriendActiv;


    // Start is called before the first frame update
    void Start()
    {
        // Mise � jour des variables
        ThunderPrice = 10;
        FriendPrice = 10;

        ThunderActiv = false;

    }

    // Update is called once per frame
    void Update()
    {
        // D�finir la dur�e d'activit�
        ThunderTime += Time.deltaTime;

        if ( ThunderTime >= 10)
        {
            ThunderActiv = false;
        }

        FriendTime += Time.deltaTime;

        if (FriendTime >= 10)
        {
            FriendActiv = false;
        }
    }

    public void Thunder()
    {
        // D�finir le prix d'activation
        if (ReportScore.ScoreGolden >= ThunderPrice && ThunderActiv == false)
        {
            ThunderActiv = true;
            ReportScore.ScoreGolden -= ThunderPrice;
            ReportScore.goldenUI.text = "GOLDEN HEARTS : " + Mathf.Floor(ReportScore.ScoreGolden);
            ThunderTime = 0;
        }
    }

    public void Friendship()
    {
        // D�finir le prix d'activation
        if (ReportScore.ScoreGolden >= FriendPrice && FriendActiv == false)
        {
            FriendActiv = true;
            ReportScore.ScoreGolden -= FriendPrice;
            ReportScore.goldenUI.text = "GOLDEN HEARTS : " + Mathf.Floor(ReportScore.ScoreGolden);
            FriendTime = 0;
        }
    }
}
