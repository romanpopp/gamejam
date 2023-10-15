using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killfield : MonoBehaviour
{
    private bool active;
    private float timer;

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
                scorekeeper.ChangeScore(50);
                break;
        }
    }

    /// <summary>
    /// Expands the killfield briefly.
    /// </summary>
    public void Expand()
    {
        gameObject.transform.localScale = new(40, 40, 40);
        active = true;
    }

    void FixedUpdate()
    {
        if (active)
        {
            timer += Time.deltaTime;
            if (timer >= 1)
            {
                Destroy(gameObject);
            }
        }
    }
}
