using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyAI enemyPrefab;

    public int enemiesMaxCount = 5;
    public float delay = 5;
    public PlayerController player;

    private List<Transform> _spawnerPoints;
    private List<EnemyAI> _enemies;

    public List<Transform> patrolPoints;

    private float _timeLastSpawned;

    void Start()
    {
        _spawnerPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());
        _enemies = new List<EnemyAI>();
    }

    void Update()
    {
        if(_enemies.Count >= enemiesMaxCount) return;
        if(Time.time - _timeLastSpawned < delay) return;

        CreateEnemy();
    }

    private void CreateEnemy()
    {
        var enemy = Instantiate(enemyPrefab);
        enemy.transform.position = _spawnerPoints[Random.Range(0, _spawnerPoints.Count)].position;
        enemy.player = player;
        enemy.patrolPoints = patrolPoints;
        _enemies.Add(enemy);
        _timeLastSpawned = Time.time;
    }
}
