using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public PlayerController player;
    public float viewAngle;
    public float damage = 30;

    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;
    private PlayerHealth _playerHealth;

    private Vector3 OldPosition;
    private EnemySpawner _enemySpawner;
    public int value = 100;

    void Start()
    {
        OldPosition = transform.position;
        Links();
        PickNewPatrolPoint();
    }


    void Update()
    {
        AttackUpdate();
        NoticePlayerUpdate();
        ChaseUpdate();
        PatrolUpdate();
    }

    private void AttackUpdate()
    {
        if(_isPlayerNoticed)
        {
            if(_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                _playerHealth.DealDamage(damage * Time.deltaTime);
            }
        }
    }


    public bool IsAlive()
    {
        return value > 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var PlayerController = collision.gameObject.GetComponent<PlayerController>();
        if(collision.gameObject.tag == "Player" && transform.localScale.x <= player.transform.localScale.x)
        {
            PlayerController.AddProtein();
            Destroy(gameObject);
            value -= 100;
        }
    }


    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }

    private void Links()
    {
        _playerHealth = player.GetComponent<PlayerHealth>();
        _enemySpawner = GetComponent<EnemySpawner>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void PatrolUpdate()
    {
        if(!_isPlayerNoticed)
        {
            if(_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                PickNewPatrolPoint();
            }
        }
    }

    private void NoticePlayerUpdate()
    {
        var direction = player.transform.position - transform.position;
        _isPlayerNoticed = false;
        if(Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if(hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
    }

    private void ChaseUpdate()
    {
        if(_isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }
}
