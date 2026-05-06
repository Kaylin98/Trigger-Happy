using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour
{
    FirstPersonController player;
    NavMeshAgent agent;
    const string PLAYER_TAG = "Player";

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        player = FindAnyObjectByType<FirstPersonController>();
    }

    void Update()
    {
        agent.SetDestination(player.transform.position);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with " + other.name);
        if (other.CompareTag(PLAYER_TAG))
        {
            Debug.Log("Collided with player");
            EnemyHealth enemyHealth = GetComponent<EnemyHealth>();
            enemyHealth.SelfDestruct();
        }
    }
}
