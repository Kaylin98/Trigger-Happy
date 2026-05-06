using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    [SerializeField] GameObject robotPrefab;
    [SerializeField] float spawnInterval = 5f;
    [SerializeField] Transform SpawnPoint;

    PlayerHealth player;

    void Start()
    {
        player = FindFirstObjectByType<PlayerHealth>();
        StartCoroutine(SpwanRoutine());
    }

    IEnumerator SpwanRoutine()
    {
        while (player)
        {
            Instantiate(robotPrefab, SpawnPoint.position, transform.rotation);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
