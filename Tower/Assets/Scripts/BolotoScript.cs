using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolotoScript : MonoBehaviour
{
    public bool setActive, setDamage;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            if (setActive)
            {
                EnemyMove enemy = col.gameObject.GetComponent<EnemyMove>();
                enemy.speed -= 0.8f;
                if (setDamage) enemy.TakeDamage(1);
            }
            
        }
    }
}
