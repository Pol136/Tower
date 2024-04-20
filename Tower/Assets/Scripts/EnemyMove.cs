using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class EnemyMove : MonoBehaviour
{
    public float speed;
    public float health = 2;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Tower").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        
        if (health <= 0)
        {   
            Destroy(gameObject);
            Tower tower = GameObject.FindGameObjectWithTag("Tower").GetComponent<Tower>();
            tower.money = tower.money + tower.moneyForKill;
            tower.moneyUpdate();

            Random random = new Random();
            int chance = random.Next(1, 15);
            if (chance == 13)
            {
                tower.ruby += 1;
                tower.rubyUpdate();
            }
        }
    }
}
