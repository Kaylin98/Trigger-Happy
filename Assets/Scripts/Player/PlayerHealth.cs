using Unity.Cinemachine;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int startingHealth = 5;
    [SerializeField] CinemachineCamera deathCamera;
    [SerializeField] Transform weaponCamera;
    int currentHealth;
    int deathCameraPriority = 20;


    void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log("Player took damage, current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            weaponCamera.parent = null;
            deathCamera.Priority = deathCameraPriority;
            Destroy(this.gameObject);
        }
    }
    
}
