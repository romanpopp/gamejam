using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class boomerangController : MonoBehaviour
{
    private GameObject player;
    private float speed = 5;

    private Vector2 movementDirection;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (speed > 0)
        {
            movementDirection = new(
            player.transform.position.x + transform.position.x,
            player.transform.position.y + transform.position.y);
            transform.Translate(speed * Time.deltaTime * movementDirection, Space.World);
            speed -= 5 * Time.deltaTime;
        }
        else
        {
            movementDirection = new(
            player.transform.position.x - transform.position.x,
            player.transform.position.y - transform.position.y);
            transform.Translate(-1 * speed * Time.deltaTime * movementDirection, Space.World);
            speed -= 5 * Time.deltaTime;
        }
        
    }

    public void SetPlayer(GameObject player)
    {
        this.player = player;
    }

    /// <summary>
    /// Collision event controller.
    /// </summary>
    /// <param name="collision">The collider that was hit.</param>
    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                Destroy(gameObject);
                break;
        }
    }
}
