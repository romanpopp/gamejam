using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject seekerAsset;
    public Transform[] spawnPositions;

    private float timer;
    public float frequency;
    private float difficulty;
    public float difficultyChange;
    private float enemySpawns;

    public TextMeshProUGUI warningText;
    public TextMeshProUGUI swarmText;
    private bool textShow;
    private bool panicMode;
    public Color textColor;
    private float panicTimer;

    public scorekeeper scorekeeper;

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > frequency)
        {
            timer = 0;
            enemySpawns++;
            SpawnEnemies();
        }
        if (enemySpawns > difficultyChange && difficulty < 5)
        {
            difficulty++;
            if (difficulty == 5)
            {
                swarmText.alpha = 1;
                panicMode = true;
            }
            else
            {
                enemySpawns = 0;
                textShow = true;
                StartCoroutine(TextTimer());
            }
        }

        if (panicMode)
        {
            panicTimer += Time.deltaTime;
            if (panicTimer < 0.4)
            {
                swarmText.color = Color.white;
            }
            if (panicTimer >= 0.4)
            {
                swarmText.color = textColor;
            }
            if (panicTimer > 0.8)
            {
                panicTimer = 0;
            }
        }

        if (textShow && warningText.alpha <= 1)
        {
            warningText.alpha += 1 * Time.deltaTime;
        }
        if (!textShow && warningText.alpha >= 0)
        {
            warningText.alpha -= 1 * Time.deltaTime;
        }
    }

    /// <summary>
    /// Spawns enemies depending on the difficulty level.
    /// </summary>
    void SpawnEnemies()
    {
        
        switch (difficulty)
        {
            case 0:
                SpawnSeeker(1);
                break;
            case 1:
                SpawnSeeker(2);
                break;
            case 2:
                SpawnSeeker(3);
                break;
            case 3:
                SpawnSeeker(5);
                break;
            case 4:
                SpawnSeeker(7);
                break;
            case 5:
                SpawnSeeker(12);
                break;
        }
    }

    /// <summary>
    /// Spawns the specified number of seeker enemies.
    /// </summary>
    /// <param name="n">Number to spawn.</param>
    void SpawnSeeker(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Transform position = spawnPositions[Random.Range(0, spawnPositions.Length)];
            position.position.Set(position.position.x + Random.Range(-20, 20), position.position.y + Random.Range(-20, 20), position.position.z);
            GameObject enemy = Instantiate(seekerAsset, position.position, position.rotation);
            enemy.GetComponent<seekerController>().SetScoreKeeper(scorekeeper);
        }
    }

    IEnumerator TextTimer()
    {
        yield return new WaitForSeconds(4.5f);
        textShow = false;
    }
}
