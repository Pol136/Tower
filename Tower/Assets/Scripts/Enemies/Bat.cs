using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : EnemyMove
{
    float t = 0;
    float radius = 30f;
    
    public override void EnemyMoveTick (){
        t += Time.deltaTime;
        radius -= getSpeed() * t;
        transform.position = Vector2.Lerp(transform.position, new Vector2(Mathf.Cos(getSpeed() * t) * radius + target.position.x, Mathf.Sin(getSpeed() * t) * radius + target.position.y), Time.deltaTime);
        //transform.position = Vector2.MoveTowards(transform.position, (transform.position - target.position) * 0.01f, getSpeed() * Time.deltaTime);
    }
}