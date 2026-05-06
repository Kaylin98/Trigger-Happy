using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] int startingHealth = 10;
    [SerializeField] CinemachineCamera deathCamera;
    [SerializeField] Transform weaponCamera;
    [SerializeField] Image[] shieldBars;
    int currentHealth;
    int deathCameraPriority = 20;


    void Awake()
    {
        currentHealth = startingHealth;
        AdjustShieldUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        AdjustShieldUI();

        if (currentHealth <= 0)
        {
            weaponCamera.parent = null;
            deathCamera.Priority = deathCameraPriority;
            Destroy(this.gameObject);
        }
    }

    void AdjustShieldUI()
    {
        for (int i = 0; i < shieldBars.Length; i++)
        {
            if (i < currentHealth)
            {
                shieldBars[i].enabled = true;
            }
            else
            {
                shieldBars[i].enabled = false;
            }
        }
    }
    
}
