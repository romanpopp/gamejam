using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class boomerangController : MonoBehaviour
{
    private GameObject player;
    public float speed;
    public float speedDecay;
    public float rotationRate;

    private Vector2 movementDirection;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        speed -= speedDecay;

        movementDirection = new(
        transform.position.x - player.transform.position.x,
        transform.position.y - player.transform.position.y);
        movementDirection.Normalize();
        transform.Translate(speed * Time.deltaTime * movementDirection, Space.World);

        Vector3 rotation = new(0, 0, rotationRate);
        transform.Rotate(rotation);
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
