using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class gameOver : MonoBehaviour
{
    public GameObject player;
    public Image overlay;
    public TextMeshProUGUI text;
    public scorekeeper scorekeeper;

    /// <summary>
    /// Collision event controller.
    /// </summary>
    /// <param name="collision">The collider that was hit.</param>
    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "SeekerEnemy":
                collision.GetComponent<seekerController>().Die();
                GameOver();
                break;
        }
    }

    /// <summary>
    /// Game over screen.
    /// </summary>
    void GameOver()
    {

        Destroy(player);
        overlay.color = new(0.1f, 0.1f, 0.1f, 0.8f);
        text.alpha = 1;

        text.text = "Game Over!\nScore: " + scorekeeper.GetScore();

        Destroy(gameObject);
    }
}
