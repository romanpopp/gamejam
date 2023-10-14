using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    [SerializeField] float movementSpeed;
    [SerializeField] private float rotationSpeed;
    private Vector2 movementDirection;

    private Vector2 mousePosition;
    public Camera sceneCamera;

    // Update is called once per frame
    void FixedUpdate()
    {
        ProcessInputs();
        Move();
    }

    /// <summary>
    /// Processes the player's inputs.
    /// </summary>
    void ProcessInputs()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        movementDirection = new Vector2(moveX, moveY);
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    /// <summary>
    /// Moves and rotates the player.
    /// </summary>
    void Move()
    {
        // Position
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        movementDirection.Normalize();
        transform.Translate(inputMagnitude * movementSpeed * Time.deltaTime * movementDirection, Space.World);

        // Rotation
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }
}
