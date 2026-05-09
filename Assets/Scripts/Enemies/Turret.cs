using System;
using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] Transform turretHead;
    [SerializeField] Transform playerTargetPoint;
    [SerializeField] Transform projectileSpawnPoint;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float fireRate = 2f;
    [SerializeField] int projectileDamage = 2;
    PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = FindFirstObjectByType<PlayerHealth>();
        StartCoroutine(ShootRoutine());
    }

    void Update()
    {
        turretHead.LookAt(playerTargetPoint);
    }

    IEnumerator ShootRoutine()
    {
        while (playerHealth)
        {
            yield return new WaitForSeconds(fireRate);

            Projectile projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity).GetComponent<Projectile>();
            projectile.transform.LookAt(playerTargetPoint);
            projectile.Init(projectileDamage);
        }
    }
}
