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
    public TextMeshProUGUI NameEnemyUI;

    public ParticleSystem AtmosphereParticle;

    public int ClickDamage;

    public float TimeSpawn;
    public float Timer;

    public bool EnemyActiv;

    public ScoreManager ReportScore;
    
    public BonusManager ReportBonus;

    private Vector3 OriginalScale;

    public GameObject DarkBackground;

    public Transform ParentEnemyParticle;
    public Transform ParentKillParticle;
    public GameObject EnemyParticle;
    public GameObject KillParticle;

    // Start is called before the first frame update
    void Start()
    {
        AtmosphereParticle.Stop();
        DarkBackground.SetActive(false);
        EnemyActiv = false;
        ClickDamage = 1;

        // Définir un premier temps de spawn alétoire
        TimeSpawn = Random.Range(3, 10);

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
            // Activer un gain automatique toute les secondes
            if (EnemyActiv == true)
            {
                Rob += 0.001f;
            }

            yield return new WaitForSeconds(1);
        }

    }

        // Faire apparaitre les ennemis depuis une liste
    public void EnemySpawn()
    {
        DarkBackground.SetActive(true);
        AtmosphereParticle.Play();
        CurrentEnemy = EnemyList[Random.Range(0, EnemyList.Length)];

        // Enregistrez l'échelle originale du bouton au démarrage
        OriginalScale = transform.localScale;

        SpriteRenderer.sprite = CurrentEnemy.Appareance;
        SpriteRenderer.enabled = true;
        EnemyActiv = true;
        NameEnemyUI.text = CurrentEnemy.EnemyName;
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
            if (ReportBonus.AthenaActiv == false)
            {
                Hp-= ClickDamage;
                Instantiate(EnemyParticle, ParentEnemyParticle.position, ParentEnemyParticle.rotation);
            }

            // perte normal sans bonus actif
            if (ReportBonus.AthenaActiv == true)
            {
                Hp-= ReportScore.AthenaDamage + ClickDamage;
                Instantiate(EnemyParticle, ParentEnemyParticle.position, ParentEnemyParticle.rotation);
            }

            LeanTween.scale(gameObject, OriginalScale * 1.1f, 0.05f).setEase(LeanTweenType.easeOutQuad).setOnComplete(ResetScale);
        }

        // prévoir la disparition d'un ennemi
        if (Hp <= 0 && EnemyActiv == true)
        {
            SpriteRenderer.enabled = false;
            TimeSpawn = Random.Range(3, 10);
            EnemyActiv = false;
            Timer = 0;
            NameEnemyUI.text = "";
            DarkBackground.SetActive(false);
            AtmosphereParticle.Stop();
            Instantiate(KillParticle, ParentKillParticle.position, ParentKillParticle.rotation);
        }
    }

    void ResetScale()
    {
        // Rétablissez l'échelle initiale après l'effet de rebond
        LeanTween.scale(gameObject, OriginalScale, 0.1f).setEase(LeanTweenType.easeInQuad);
    }
}
