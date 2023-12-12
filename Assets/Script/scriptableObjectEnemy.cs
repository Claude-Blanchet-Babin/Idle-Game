using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName ="enemy", order =0)]
public class scriptableObjectEnemy : ScriptableObject
{
    public Sprite Appareance;
    public int Healpoint;
    public string EnemyName;
    public float RobEnemy;
}
