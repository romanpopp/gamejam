using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    [SerializeField] private float movementSpeed;
    private Vector2 movementDirection;
    public GameObject booster;
    private bool boosting;
    private float boostPower;
    public float boostMax;

    private Vector2 mousePosition;
    public Camera sceneCamera;

    public shoot boomerangShooter;
    private bool canFire = true;
    private bool canDash = true;
    public float dashCD;

    // Start is called once
    void Start()
    {
        boomerangShooter.SetBoomerang(0);
    }

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

        if (Input.GetMouseButton(0) && canFire)
        {
            boomerangShooter.Fire();
            canFire = false;
            StartCoroutine(FireCooldown(boomerangShooter.fireCD));
        }

        if (Input.GetMouseButton(1) && canDash)
        {
            boostPower = boostMax;
            boosting = true;
            canDash = false;
            Instantiate(booster, transform.position, transform.rotation);
            StartCoroutine(DashCooldown(dashCD));
            StartCoroutine(DashStop(0.2f));
        }

        if (boostPower > 0.4)
        {
            boostPower -= 10 * Time.deltaTime;
        }
        
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);

        if (boosting)
        {
            movementDirection = mousePosition - rb.position;
        }
        else
        {
            movementDirection = new Vector2(moveX, moveY);
        }
    }

    /// <summary>
    /// Moves and rotates the player.
    /// </summary>
    void Move()
    {
        // Position
        if (boosting)
        {
            movementDirection.Normalize();
            transform.Translate(movementSpeed * boostPower / 1.4f * Time.deltaTime * movementDirection, Space.World);
        }
        else
        {
            float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
            movementDirection.Normalize();
            transform.Translate(inputMagnitude * movementSpeed * Time.deltaTime * movementDirection, Space.World);
        }
        // Rotation
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }

    IEnumerator FireCooldown(float delay)
    {
        yield return new WaitForSeconds(delay);
        canFire = true;
    }

    IEnumerator DashCooldown(float delay)
    {
        yield return new WaitForSeconds(delay);
        canDash = true;
    }

    IEnumerator DashStop(float delay)
    {
        yield return new WaitForSeconds(delay);
        boosting = false;
    }
}
