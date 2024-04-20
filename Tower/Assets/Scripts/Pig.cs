using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : EnemyMove
{
    public override void EnemyMoveTick (){
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}