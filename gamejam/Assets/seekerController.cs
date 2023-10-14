using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class seekerController : MonoBehaviour
{
    public GameObject ass;
    public SpriteRenderer spriteRenderer;
    public Color bodyColor;
    public Rigidbody2D rb;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationRate;
    private float damage;

    public GameObject deathParticle;

    private Vector2 movementDirection;

    private float health;
    public float maxHealth;

    private void Start()
    {
        damage = Random.Range(0.05f, 0.15f);
        health = maxHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movementDirection = ass.transform.position - transform.position;
        movementDirection.Normalize();
        transform.Translate(movementSpeed * Time.deltaTime * movementDirection, Space.World);

        Vector3 rotation = new(0, 0, rotationRate);
        transform.Rotate(rotation);
    }

    /// <summary>
    /// Damages the enemy.
    /// </summary>
    public void Damage(float damage)
    {
        health -= damage;
        spriteRenderer.color = new(0.8f, 0.8f, 0.8f);
        StartCoroutine(ResetColor());
        if (health <= 0)
        {
            Instantiate(deathParticle);
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Gets the damage value.
    /// </summary>
    /// <returns>Returns damage value.</returns>
    public float GetDamage()
    {
        return damage;
    }

    IEnumerator ResetColor()
    {
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = new Color(bodyColor.r, bodyColor.g, bodyColor.b);
    }
}
