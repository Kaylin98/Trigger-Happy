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
    [Header("Audio")]
    [SerializeField] AudioClip turretShootClip;
    [SerializeField] float minAudioDistance = 8f;
    [SerializeField] float maxAudioDistance = 40f;
    AudioSource audioSource;
    PlayerHealth playerHealth;

    void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.spatialBlend = 1f;              // fully 3D
        audioSource.rolloffMode = AudioRolloffMode.Linear;
        audioSource.minDistance = minAudioDistance;
        audioSource.maxDistance = maxAudioDistance;
        audioSource.playOnAwake = false;
    }

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
            audioSource.PlayOneShot(turretShootClip);
            Projectile projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity).GetComponent<Projectile>();
            projectile.transform.LookAt(playerTargetPoint);
            projectile.Init(projectileDamage);
        }
    }
}
