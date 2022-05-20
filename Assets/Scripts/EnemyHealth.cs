using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float _healthPoints = 100f;

    public void TakeDamage(float damage)
    {
        _healthPoints -= damage;

        if (damage <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
