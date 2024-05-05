using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Pig : EnemyMove
{
    public override void EnemyMoveTick (){
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    public override void TakeDamage(float damage)
    {
        health -= damage;
        
        if (health <= 0)
        {   
            Destroy(gameObject);
            Tower tower = GameObject.FindGameObjectWithTag("Tower").GetComponent<Tower>();
            tower.money = tower.money + tower.moneyForKill;
            tower.moneyUpdate();

            Random random = new Random();
            int chance = random.Next(1, 100);
            if (chance <= rubyDropChance)
            {
                tower.ruby += 1;
                tower.rubyUpdate();
            }
        }
    }
}