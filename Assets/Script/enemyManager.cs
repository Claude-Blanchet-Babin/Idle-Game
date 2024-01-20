using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Déclaration des variables

    // Paramètres de l'ennemi depuis le scriptable object
    public SpriteRenderer SpriteRenderer;
    public ScriptableObjectEnemy[] EnemyList;
    private ScriptableObjectEnemy CurrentEnemy;
    public float Hp;
    public float Rob;
    public TextMeshProUGUI NameEnemyUI;

    // Lien vers autre script
    public ScoreManager ReportScore;
    public BonusManager ReportBonus;

    // Paramètres de l'ennemi pendant son affichage
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

    // Changement de décor
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

        // Définir un premier temps de spawn alétoire
        TimeSpawn = Random.Range(5, 20);

        // Mise en place de la coroutine de l'ennemi
        StartCoroutine(EnemyCoroutine());
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
            ReportScore.HeartUI.text = ": " + Mathf.Floor(ReportScore.ScoreHearts);
        }
    }

    public IEnumerator EnemyCoroutine()
    {
        while (true)
        {
            //// AJUSTEMENT PUISSANCE ENNEMI SI BESOIN ////

            // Activer un gain de puissance de l'ennemi pour obliger le joueur à s'en débarrasser
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
        // Changement de décor
        DarkBackground.SetActive(true);
        AtmosphereParticle.Play();

        // Sélection d'un ennemi aléatoire
        CurrentEnemy = EnemyList[Random.Range(0, EnemyList.Length)];

        // Enregistrez l'échelle originale du bouton au démarrage
        OriginalScale = transform.localScale;

        // Mise à jour des paramètres de l'ennemi selon l'ennemi aléatoire
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
      
            // Tous les 1000 coeurs, les stats des ennemis sont multipliés par 10%
            PowerAdjustment = ReportScore.ScoreHearts / 10000;
            Coefficient = 1 + PowerAdjustment;
            Hp = CurrentEnemy.HealPoint *Coefficient;
            Rob = CurrentEnemy.EnemyRob *Coefficient;

            RobAdjustement = ReportScore.ScoreHearts / 1000;
        }
    }

    // Faire perdre de la vie à un ennemi lors d'un clic
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

        // Prévoir la disparition d'un ennemi
        if (Hp <= 0 && EnemyActiv == true)
        {
            SpriteRenderer.enabled = false;

            Cursor.SetCursor(CursorArrow, Vector2.zero, CursorMode.Auto);

            // Définir un nouveau temps de spawn aléatoire
            TimeSpawn = Random.Range(3, 10);
            EnemyActiv = false;
            Timer = 0;
            NameEnemyUI.text = "";

            // Changement du décor
            DarkBackground.SetActive(false);
            AtmosphereParticle.Stop();

            // Montrer au joueur la disparition de l'ennemi
            Instantiate(KillParticle, ParentKillParticle.position, ParentKillParticle.rotation);
        }
    }

    void ResetScale()
    {
        // Rétablir l'échelle initiale après l'effet de rebond
        // Utilisation du LeanTween pour l'effet "smooth"
        LeanTween.scale(gameObject, OriginalScale, 0.1f).setEase(LeanTweenType.easeInQuad);
    }
}
