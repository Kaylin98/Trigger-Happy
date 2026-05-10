using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int startingHealth = 3;
    [SerializeField] ParticleSystem explosionEffect;
    int currentHealth;

    GameManager gameManager;


    void Awake()
    {
        currentHealth = startingHealth;
    }

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        gameManager.AdjustEnemiesLeftText(1);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            SelfDestruct();
        }
    }

    public void SelfDestruct()
    {
        Instantiate(explosionEffect, this.transform.position, Quaternion.identity);
        gameManager.AdjustEnemiesLeftText(-1);
        Destroy(this.gameObject);
    }
    
}
