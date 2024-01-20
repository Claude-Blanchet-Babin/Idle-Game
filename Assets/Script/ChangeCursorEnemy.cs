using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeCursorEnemy : MonoBehaviour
{
    // D�claration des variables
    public Texture2D CursorHeart;
    public Texture2D CursorArrow;

    // Lien vers autre script
    public EnemyManager ReportEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // V�rification du passage de la souris sur un objet
    public void OnMouseEnter()
    {
        if (ReportEnemy.EnemyActiv == true)
        {
            Cursor.SetCursor(CursorHeart, Vector2.zero, CursorMode.Auto);
        }
    }

    // V�rification du d�part de la souris depuis l'objet
    public void OnMouseExit()
    {
        if (ReportEnemy.EnemyActiv == true)
        {
            Cursor.SetCursor(CursorArrow, Vector2.zero, CursorMode.Auto);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
