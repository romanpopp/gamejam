using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class seekerController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Color bodyColor;
    public Rigidbody2D rb;
    private float movementSpeed;
    [SerializeField] private float rotationRate;
    private float damage;

    public GameObject deathParticle;

    private Vector2 movementDirection;

    private float health;
    public float maxHealth;

    public scorekeeper scorekeeper;

    private void Start()
    {
        movementSpeed = Random.Range(2.5f, 4f);
        damage = Random.Range(0.05f, 0.15f);
        health = maxHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movementDirection = new Vector3(0,0) - transform.position;
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
            scorekeeper.ChangeScore(50);
            Die();
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

    public void Die()
    {
        Instantiate(deathParticle, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }

    public void SetScoreKeeper(scorekeeper sk)
    {
        scorekeeper = sk;
    }

    IEnumerator ResetColor()
    {
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = new Color(bodyColor.r, bodyColor.g, bodyColor.b);
    }
}
