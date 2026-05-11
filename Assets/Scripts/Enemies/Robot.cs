using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] AudioClip humClip;
    [SerializeField] [Range(0f, 1f)] float humVolume = 0.3f; 

    AudioSource audioSource;
    FirstPersonController player;
    NavMeshAgent agent;
    const string PLAYER_TAG = "Player";

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Start()
    {
        player = FindAnyObjectByType<FirstPersonController>();
        PlayRobotHum();
    }

    void PlayRobotHum()
    {
        if (humClip != null)
        {
            audioSource.clip = humClip;
            audioSource.loop = true;
            audioSource.spatialBlend = 1f;
            audioSource.volume = humVolume;
            audioSource.Play();
        }
    }

    void Update()
    {
        if (!player) return;
        agent.SetDestination(player.transform.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_TAG))
        {
            EnemyHealth enemyHealth = GetComponent<EnemyHealth>();
            enemyHealth.SelfDestruct();
        }
    }
}
