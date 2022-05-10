using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] 
    Transform _target;
    
    [SerializeField] [Range(0f, 10f)] 
    float _chaseRange = 5f;

    float _distanceToTarget = Mathf.Infinity;
    
    NavMeshAgent _navMeshAgent;

    void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        var targetPos = _target.position;
        _distanceToTarget = Vector3.Distance(transform.position, targetPos);
        if (_distanceToTarget > _chaseRange) { return; }
        
        _navMeshAgent.SetDestination(targetPos);
    }
}
