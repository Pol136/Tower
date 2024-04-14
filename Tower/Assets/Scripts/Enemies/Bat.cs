using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : EnemyMove
{
    public override void MoveTick (){
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
