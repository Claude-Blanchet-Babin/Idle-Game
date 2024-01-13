using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Déclaration des variables

    public SpriteRenderer SpriteRenderer;
    public ScriptableObjectEnemy[] EnemyList;
    private ScriptableObjectEnemy CurrentEnemy;
    public int Hp;
    public float Rob;

    public int ClickDamage;

    public float TimeSpawn;
    public float Timer;

    public bool EnemyActiv;

    public ScoreManager ReportScore;
    
    public BonusManager ReportBonus;

    // Start is called before the first frame update
    void Start()
    {
        EnemyActiv = false;
        ClickDamage = 1;

        // Définir un premier temps de spawn alétoire
        TimeSpawn = Random.Range(3, 10);
    }

    // Update is called once per frame
    void Update()
    {
        // Vérifier si un ennemi n'est pas actif et si le temps est écoulé
        Timer += Time.deltaTime;
        if (Timer >= TimeSpawn && (EnemyActiv == false))
        {
            EnemySpawn();
            Timer = 0;
        }

        // Activer le vol des coeurs si un ennemi est là
        if(EnemyActiv == true)
        {
            ReportScore.ScoreHearts -= Rob;
            ReportScore.HeartUI.text = "HEARTS : " + Mathf.Floor(ReportScore.ScoreHearts);
        }
    }

    // Faire apparaitre les ennemis depuis une liste
    public void EnemySpawn()
    {

        CurrentEnemy = EnemyList[Random.Range(0, EnemyList.Length)];

        SpriteRenderer.sprite = CurrentEnemy.Appareance;
        SpriteRenderer.enabled = true;
        EnemyActiv = true;
        //nameEnemyUI.text = currentEnemy.EnemyName;
        Hp = CurrentEnemy.HealPoint;
        //lifeEnemyUI.text = Hp.ToString();
        Rob = CurrentEnemy.EnemyRob;
    }

    // Faire perdre de la vie à un ennemi lors d'un clic
    public void OnMouseDown()
    {
        if (EnemyActiv == true)
        {
            // perdre plus de vie si le bonus est actif
            if (ReportBonus.ThunderActiv == false)
            {
                Hp-= ClickDamage;
            }

            // perte normal sans bonus actif
            if (ReportBonus.ThunderActiv == true)
            {
                Hp-= ReportScore.ThunderDamage + ClickDamage;
            }
        }

        // prévoir la disparition d'un ennemi
        if (Hp <= 0 && EnemyActiv == true)
        {
            SpriteRenderer.enabled = false;
            TimeSpawn = Random.Range(3, 10);
            EnemyActiv = false;
            Timer = 0;
        }
    }
}
