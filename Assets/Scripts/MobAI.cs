using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class MobAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public PlayerControl player;
    public float viewAngle;
    private NavMeshAgent _navMeshAgent;
    public float damage = 20;
    public Animator animator;
    
    private bool _isPlayerNoticed;
    private bool _playerIsAgr = false;
    private PlayerHealth _playerHealth;
    Random rnd = new Random();

    void Start()
    {
        InitComponentLinks();
        PickNewPatrolPoint();
    }

    void Update()
    {
        NoticePlayerUpdate();
        ChaseUpdate();
        PatrolUpdate();
        AttackUpdate();
    }

    private void PickNewPatrolPoint()
    {
         _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }
    
    private void PatrolUpdate()
    {
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance || (_playerIsAgr & _isPlayerNoticed == false))
        {
            _playerIsAgr = false;
            PickNewPatrolPoint();
        }   
    }
    
    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth = player.GetComponent<PlayerHealth>();
    }
    
    private void NoticePlayerUpdate()
    {
        var direction = player.transform.position - transform.position;
        _isPlayerNoticed = false;
        if (_playerHealth.value <= 0) return;
        if (Vector3.Distance(transform.position, player.transform.position) > 40) return;

        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
    }
    
    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
            _playerIsAgr = true;
        }
    }

    private void AttackUpdate()
    {
        if (_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                animator.SetTrigger("Attack");
            }
        }
    }

    public void AttackDamage()
    {
        if (_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                _playerHealth.DealDamage(damage);
            }
        }
    }
}
