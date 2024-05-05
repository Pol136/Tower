using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float bulletSpeed = 5f;
    private float damage;

    private Transform target;

    private void Start()
    {
        StartCoroutine(DestroyAfterSeconds());
    }

    private void Update()
    {
        Tower tower = GameObject.FindGameObjectWithTag("Tower").GetComponent<Tower>();
        damage = tower.damage;
    }

    public void SetTarget(Transform _target)
    {
        this.target = _target;
    }

    private void FixedUpdate()
    {
        if (!target) return;
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<EnemyMove>().TakeDamage(damage);
        Destroy(gameObject);
    }

    IEnumerator DestroyAfterSeconds()
    {
        yield return new WaitForSeconds(5f);
        Object.Destroy(gameObject);
    }

}
