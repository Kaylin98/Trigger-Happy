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
            Instantiate(projectilePrefab, projectileSpawnPoint.position, turretHead.rotation);
            yield return new WaitForSeconds(fireRate);
        }
    }
}
