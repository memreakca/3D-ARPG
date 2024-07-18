using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float speed = 5f;
    public float maxDistance = 30f;
    public float detectionRadius = 10f; 

    private float timeAfterCreated = 0f;
    private float maxTime = 5f;
    private Vector3 direction;
    private Vector3 initialPosition;

    [SerializeField] public float baseDamage = 15;
    public float damage;
    public bool damageApplied;

    private void Start()
    {
        damage = baseDamage + Player.main.INT * 5;
        initialPosition = transform.position;
    }

    public void SetDirection(Vector3 newDirection)
    {
        newDirection.y = 0;
        newDirection.Normalize();
        direction = newDirection;
    }

    void Update()
    {
        SeekAndDestroy();
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
        Extinguish();
    }

    private void SeekAndDestroy()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius);
        EnemyTakeDamage nearestEnemy = null;
        float nearestDistance = detectionRadius;

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.TryGetComponent(out EnemyTakeDamage enemy))
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearestEnemy = enemy;
                }
            }
        }

        if (nearestEnemy != null)
        {
            Vector3 targetDirection = nearestEnemy.transform.position - transform.position;
            targetDirection.y = 0; // Keep fireball on the same horizontal plane
            targetDirection.Normalize();
            direction = targetDirection;
        }
    }

    public void Extinguish()
    {
        timeAfterCreated += Time.deltaTime;
        float distance = Vector3.Distance(transform.position, initialPosition);

        if (distance > maxDistance || timeAfterCreated >= maxTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!damageApplied && other.TryGetComponent(out EnemyTakeDamage enm))
        {
            enm.TakeDamage(damage);
            damageApplied = true;
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
