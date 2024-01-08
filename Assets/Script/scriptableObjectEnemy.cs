using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName ="enemy", order =0)]
public class ScriptableObjectEnemy : ScriptableObject
{
    // D�finir les diff�rentes caract�ristiques des ennemis
    public Sprite Appareance;
    public int HealPoint;
    public string EnemyName;
    public float EnemyRob;
}
