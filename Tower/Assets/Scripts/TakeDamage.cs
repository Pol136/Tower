using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public HealthBar bar;
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bar.MinusHealth(damage);
        Destroy(collision.gameObject);
    }
}
