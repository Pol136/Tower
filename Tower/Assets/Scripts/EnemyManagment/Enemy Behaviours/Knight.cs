using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Knight : EnemyMove
{
    [SerializeField] Animator animator;
    public int shieldHits;
    public override void EnemyMoveTick (){
        if (transform.position.x > -2.41f) animator.SetBool("IsOnTheRight", true);
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    public override void TakeDamage(float damage)
    {
        if (shieldHits > 0){

            shieldHits--;

        } else {
            
            animator.SetBool("IsShielded", false);
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
}