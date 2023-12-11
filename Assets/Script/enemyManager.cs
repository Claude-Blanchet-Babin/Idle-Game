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


    // Start is called before the first frame update
    void Start()
    {
        EnemySpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemySpawn()
    {

        currentEnemy = EnemyList[Random.Range(0, EnemyList.Length)];

        spriteRenderer.sprite = currentEnemy.Appareance;
        //nameEnemyUI.text = currentEnemy.EnemyName;
        hp = currentEnemy.Healpoint;
        //lifeEnemyUI.text = hp.ToString();
    }
}
