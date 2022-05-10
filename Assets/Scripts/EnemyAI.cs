using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Timeline;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] 
    Transform _target;
    
    [SerializeField] [Range(0f, 20f)] 
    float _chaseRange = 10f;

    float _distanceToTarget = Mathf.Infinity;
    
    NavMeshAgent _navMeshAgent;
    bool _isProvoked;

    void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        CheckTarget();
    }

    void CheckTarget()
    {
        _distanceToTarget = Vector3.Distance(transform.position, _target.position);
        if (_isProvoked)
        {
            EngageTarget(_target.position);
        }
        else if (_distanceToTarget <= _chaseRange)
        {
            _isProvoked = true;
        }
        else
        {
            _isProvoked = false;
        }
    }

    void EngageTarget(Vector3 targetPos)
    {
        if (_distanceToTarget >= _navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (_distanceToTarget < _navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
        
    }

    void ChaseTarget()
    {
        _navMeshAgent.SetDestination(_target.position);
    }
    
    void AttackTarget()
    {
        Debug.Log($"{name} is attacking {_target.name}!!!");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _chaseRange);
    }
}
