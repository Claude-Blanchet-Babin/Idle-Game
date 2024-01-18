using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    // Déclaration des variables

    public ScoreManager ReportScore;

    public int ThunderPrice;
    public float ThunderTime;
    public float ThunderCooldown;

    public bool ThunderActiv;

    public int FriendPrice;
    public float FriendTime;
    public float FriendCooldown;

    public bool FriendActiv;

    public float PowerTime;


    // Start is called before the first frame update
    void Start()
    {
        // Mise à jour des variables
        ThunderPrice = 10;
        FriendPrice = 10;

        ThunderActiv = false;
        FriendActiv = false;

        PowerTime = 5;

    }

    // Update is called once per frame
    void Update()
    {
        // Définir la durée d'activité

        FriendCooldown += Time.deltaTime;
        ThunderCooldown += Time.deltaTime;

        if (FriendActiv == true)
        {
            FriendTime += Time.deltaTime;
        }

        if (ThunderActiv == true)
        {
            ThunderTime += Time.deltaTime;
        }

        if (ThunderTime >= PowerTime)
        {
            ThunderTime = 0;
            ThunderActiv = false;
            ThunderCooldown = 0;
        }

        if (FriendTime >= PowerTime)
        {
            FriendTime = 0;
            FriendActiv = false;
            ReportScore.MaxRandomGold += ReportScore.FriendBoost;
            ReportScore.MaxRandomNormal -= ReportScore.FriendBoost;
            FriendCooldown = 0;
        }
    }

    public void Thunder()
    {
        // Définir le prix d'activation
        if (ReportScore.ScoreGolden >= ThunderPrice && ThunderActiv == false && ThunderCooldown>=10)
        {
            ThunderActiv = true;
            ReportScore.ScoreGolden -= ThunderPrice;
            ReportScore.GoldenUI.text = ": " + Mathf.Floor(ReportScore.ScoreGolden);
            ThunderTime = 0;
        }
    }

    public void Friendship()
    {
        // Définir le prix d'activation
        if (ReportScore.ScoreGolden >= FriendPrice && FriendActiv == false && FriendCooldown >= 10)
        {
            FriendActiv = true;
            ReportScore.ScoreGolden -= FriendPrice;
            ReportScore.GoldenUI.text = ": " + Mathf.Floor(ReportScore.ScoreGolden);
            FriendTime = 0;

            ReportScore.MaxRandomGold -= ReportScore.FriendBoost;
            ReportScore.MaxRandomNormal += ReportScore.FriendBoost;
        }
    }
}
