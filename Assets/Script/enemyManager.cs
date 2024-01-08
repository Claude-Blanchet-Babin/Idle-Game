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
    public int hp;

    public float TimeSpawn;
    public float timer;

    public bool EnemyActiv;

    public ScoreManager report;
    public float Rob;

    // Start is called before the first frame update
    void Start()
    {
        EnemyActiv = false;

        // Définir un premier temps de spawn alétoire
        TimeSpawn = Random.Range(3, 10);
    }

    // Update is called once per frame
    void Update()
    {
        // Vérifier si un ennemi n'est pas actif et si le temps est écoulé
        timer += Time.deltaTime;
        if (timer >= TimeSpawn && (EnemyActiv == false))
        {
            EnemySpawn();
            timer = 0;
        }

        // Activer le vol des coeurs si un ennemi est là
        if(EnemyActiv == true)
        {
            report.ScoreHearts -= Rob;
            report.heartUI.text = "HEARTS : " + Mathf.Floor(report.ScoreHearts);
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
        hp = CurrentEnemy.Healpoint;
        //lifeEnemyUI.text = hp.ToString();
        Rob = CurrentEnemy.RobEnemy;
    }

    // Faire perdre de la vie à un ennemi lors d'un clic
    public void OnMouseDown()
    {
        if (EnemyActiv == true)
        {
            // perdre plus de vie si le bonus est actif
            if (report.ThunderActiv == false)
            {
                hp--;
            }

            // perte normal sans bonus actif
            if (report.ThunderActiv == true)
            {
                hp-=report.ThunderDamage;
            }
        }

        // prévoir la disparition d'un ennemi
        if (hp <= 0 && EnemyActiv == true)
        {
            SpriteRenderer.enabled = false;
            TimeSpawn = Random.Range(3, 10);
            //Invoke("EnemySpawn", TimeSpawn);
            EnemyActiv = false;
            timer = 0;
        }
    }
}
