using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // D�claration des variables

    // Param�tres de l'ennemi depuis le scriptable object
    public SpriteRenderer SpriteRenderer;
    public ScriptableObjectEnemy[] EnemyList;
    private ScriptableObjectEnemy CurrentEnemy;
    public float Hp;
    public float Rob;
    public TextMeshProUGUI NameEnemyUI;

    // Lien vers autre script
    public ScoreManager ReportScore;
    public BonusManager ReportBonus;

    // Param�tres de l'ennemi pendant son affichage
    public int ClickDamage;
    public float TimeSpawn;
    public float Timer;
    public bool EnemyActiv;
    private Vector3 OriginalScale;

    public float PowerAdjustment;
    public float Coefficient;
    public float RobAdjustement;

    // Gestion des particules
    public Transform ParentEnemyParticle;
    public Transform ParentKillParticle;

    public GameObject EnemyParticle;
    public GameObject KillParticle;

    public ParticleSystem AtmosphereParticle;

    // Changement de d�cor
    public GameObject DarkBackground;

    public Texture2D CursorArrow;


    // Start is called before the first frame update
    void Start()
    {
        AtmosphereParticle.Stop();
        DarkBackground.SetActive(false);
        EnemyActiv = false;

        //// AJUSTEMENT PUIISSANCE DE BASE DU CLICK SI BESOIN ////
        ClickDamage = 1;

        // D�finir un premier temps de spawn al�toire
        TimeSpawn = Random.Range(5, 20);

        // Mise en place de la coroutine de l'ennemi
        StartCoroutine(EnemyCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        // V�rifier si un ennemi n'est pas actif et si le temps est �coul�
        Timer += Time.deltaTime;
        if (Timer >= TimeSpawn && (EnemyActiv == false))
        {
            EnemySpawn();
            Timer = 0;
        }

        // Activer le vol des coeurs si un ennemi est l�
        if(EnemyActiv == true)
        {
            ReportScore.ScoreHearts -= Rob;
            ReportScore.HeartUI.text = ": " + Mathf.Floor(ReportScore.ScoreHearts);
        }
    }

    public IEnumerator EnemyCoroutine()
    {
        while (true)
        {
            //// AJUSTEMENT PUISSANCE ENNEMI SI BESOIN ////

            // Activer un gain de puissance de l'ennemi pour obliger le joueur � s'en d�barrasser
            if (EnemyActiv == true && ReportScore.ScoreHearts < 1000)
            {
                Rob += 0.003f;
            }

            if (EnemyActiv == true && ReportScore.ScoreHearts >= 1000)
            {
                Rob += 0.003f * RobAdjustement;
            }

            yield return new WaitForSeconds(1);
        }
    }

    // Faire apparaitre les ennemis depuis une liste
    public void EnemySpawn()
    {
        // Changement de d�cor
        DarkBackground.SetActive(true);
        AtmosphereParticle.Play();

        // S�lection d'un ennemi al�atoire
        CurrentEnemy = EnemyList[Random.Range(0, EnemyList.Length)];

        // Enregistrez l'�chelle originale du bouton au d�marrage
        OriginalScale = transform.localScale;

        // Mise � jour des param�tres de l'ennemi selon l'ennemi al�atoire
        SpriteRenderer.sprite = CurrentEnemy.Appearance;
        SpriteRenderer.enabled = true;
        EnemyActiv = true;
        NameEnemyUI.text = CurrentEnemy.EnemyName;

        // Renforecment des statistiques en fonction du score du joueur

        if (ReportScore.ScoreHearts < 1000)
        {
            Hp = CurrentEnemy.HealPoint;
            Rob = CurrentEnemy.EnemyRob;
            RobAdjustement = 1;
        }

        if (ReportScore.ScoreHearts >= 1000)
        {
            //// AJUSTEMENT PUISSANCE ENNEMI SI BESOIN ////
      
            // Tous les 1000 coeurs, les stats des ennemis sont multipli�s par 10%
            PowerAdjustment = ReportScore.ScoreHearts / 10000;
            Coefficient = 1 + PowerAdjustment;
            Hp = CurrentEnemy.HealPoint *Coefficient;
            Rob = CurrentEnemy.EnemyRob *Coefficient;

            RobAdjustement = ReportScore.ScoreHearts / 1000;
        }
    }

    // Faire perdre de la vie � un ennemi lors d'un clic
    public void OnMouseDown()
    {
        if (EnemyActiv == true)
        {
            // perdre de la vie selon le click sans le bonus Athena
            if (ReportBonus.AthenaActiv == false)
            {
                Hp-= ClickDamage;
                Instantiate(EnemyParticle, ParentEnemyParticle.position, ParentEnemyParticle.rotation);
            }

            // perdre plus de vie si le bonus Athena est actif
            if (ReportBonus.AthenaActiv == true)
            {
                Hp-= ReportScore.AthenaDamage + ClickDamage;
                Instantiate(EnemyParticle, ParentEnemyParticle.position, ParentEnemyParticle.rotation);
            }

            // Faire l'effet de rebond
            // Utilisation du LeanTween pour l'effet "smooth"
            LeanTween.scale(gameObject, OriginalScale * 1.1f, 0.05f).setEase(LeanTweenType.easeOutQuad).setOnComplete(ResetScale);
        }

        // Pr�voir la disparition d'un ennemi
        if (Hp <= 0 && EnemyActiv == true)
        {
            SpriteRenderer.enabled = false;

            Cursor.SetCursor(CursorArrow, Vector2.zero, CursorMode.Auto);

            // D�finir un nouveau temps de spawn al�atoire
            TimeSpawn = Random.Range(3, 10);
            EnemyActiv = false;
            Timer = 0;
            NameEnemyUI.text = "";

            // Changement du d�cor
            DarkBackground.SetActive(false);
            AtmosphereParticle.Stop();

            // Montrer au joueur la disparition de l'ennemi
            Instantiate(KillParticle, ParentKillParticle.position, ParentKillParticle.rotation);
        }
    }

    void ResetScale()
    {
        // R�tablir l'�chelle initiale apr�s l'effet de rebond
        // Utilisation du LeanTween pour l'effet "smooth"
        LeanTween.scale(gameObject, OriginalScale, 0.1f).setEase(LeanTweenType.easeInQuad);
    }
}
