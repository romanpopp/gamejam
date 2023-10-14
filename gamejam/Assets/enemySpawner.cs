using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject seekerAsset;
    public Transform[] spawnPositions;

    private float timer;
    public float frequency;
    private float enemyCount;
    public float maxEnemies;

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > frequency)
        {
            timer = 0;
            Transform position = spawnPositions[Random.Range(0, spawnPositions.Length)];
            position.position.Set(position.position.x + Random.Range(-20, 20), position.position.y + Random.Range(-20, 20), position.position.z);
            Instantiate(seekerAsset, position.position, position.rotation);
            enemyCount++;
        }
        if (enemyCount > maxEnemies)
        {
            enemyCount = 0;
            frequency -= 0.1f;
            maxEnemies += 0.5f;
        }
    }
}
