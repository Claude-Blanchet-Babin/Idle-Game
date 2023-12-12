using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class enemyManager : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    //public TextMeshProUGUI nameEnemyUI, lifeEnemyUI;
    public scriptableObjectEnemy[] EnemyList;
    private scriptableObjectEnemy currentEnemy;
    public int hp;

    public float TimeSpawn;
    public float timer;

    public bool Enemyactiv;

    /*public int RandomSpawn;
    public Transform Parent;
    public GameObject EnemyAnger;
    public GameObject EnemyHate;
    public int enemyLife;
    */


    // Start is called before the first frame update
    void Start()
    {
        Enemyactiv = false;
        TimeSpawn = Random.Range(3, 10);
        //Invoke("EnemySpawn", TimeSpawn);

        //Invoke("spawnTest", 5f);

    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer >= TimeSpawn && (Enemyactiv == false))
        {
            EnemySpawn();
            timer = 0;
        }


    }

    public void EnemySpawn()
    {

        currentEnemy = EnemyList[Random.Range(0, EnemyList.Length)];

        spriteRenderer.sprite = currentEnemy.Appareance;
        spriteRenderer.enabled = true;
        Enemyactiv = true;
        //nameEnemyUI.text = currentEnemy.EnemyName;
        hp = currentEnemy.Healpoint;
        //lifeEnemyUI.text = hp.ToString();
    }

    /*public void spawnTest()
    {
        RandomSpawn = Random.Range(0, 100 + 1);

        if (RandomSpawn <= 75)
        {

            Instantiate(EnemyAnger, Parent.position, Parent.rotation);
            enemyLife = 3;
        }

        if (RandomSpawn > 75 && RandomSpawn <= 100)
        {
            Instantiate(EnemyHate, Parent.position, Parent.rotation);
            enemyLife = 5;
        }
    }*/

    public void OnMouseDown()
    {
        if (Enemyactiv == true)
        {
            hp = hp - 1;
        }

        if (hp <= 0 && Enemyactiv == true)
        {
            spriteRenderer.enabled = false;
            TimeSpawn = Random.Range(3, 10);
            //Invoke("EnemySpawn", TimeSpawn);
            Enemyactiv = false;
            timer = 0;
        }

    }
}
