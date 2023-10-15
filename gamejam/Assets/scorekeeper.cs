using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scorekeeper : MonoBehaviour
{
    private int score;
    private float timer;
    public TextMeshProUGUI scoreText;

    /// <summary>
    /// Adds n to score.
    /// </summary>
    /// <param name="n">Amount to add / remove.</param>
    public void ChangeScore(int n)
    {
        score += n;
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            timer = 0;
            score += 10;
        }
        scoreText.text = "Score: " + score;
    }

    public int GetScore()
    {
        return score;
    }
}