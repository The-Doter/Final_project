using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class BossAI : MonoBehaviour
{
    public float damage = 30;
    public PlayerController player;
    public GameObject VinScreen;  


    private NavMeshAgent _navMeshAgent;
    private PlayerHealth _playerHealth;

    public int value = 100;

    void Start()
    {
        VinScreen.SetActive(false);
        Links();
    }


    void Update()
    {
        if(value <= 0)
        {
            Time.timeScale = 0;
            VinScreen.SetActive(true);
            Destroy(gameObject);
            if(Input.GetKeyDown(KeyCode.G))
            {
                SceneManager.LoadScene("Alina");
            }
        }
        _navMeshAgent.destination = player.transform.position;
        AttackUpdate();
    }

    private void AttackUpdate()
    {
        if(_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            _playerHealth.DealDamage(damage * Time.deltaTime);
        }
    }


    public bool IsAlive()
    {
        return value > 0;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Fireball")
        {
            value -= 50;
        }
    }

    private void Links()
    {
        _playerHealth = player.GetComponent<PlayerHealth>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

}
