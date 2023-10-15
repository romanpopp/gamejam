using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class assHealth : MonoBehaviour
{
    public Slider slider;
    public GameObject particle;
    public Color forcefieldColor;

    public killfield killfield;
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
                Damage(collision.GetComponent<seekerController>().GetDamage());
                collision.GetComponent<seekerController>().Die();
                scorekeeper.ChangeScore(-50);
                break;
        }
    }

    /// <summary>
    /// Damages the ass.
    /// </summary>
    /// <param name="damage">Amount of damage.</param>
    void Damage(float damage)
    {
        slider.value -= damage;
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        StartCoroutine(ResetColor());
        if (slider.value <= 0)
        {
            killfield.Expand();
            Instantiate(particle, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }

    IEnumerator ResetColor()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = forcefieldColor;
    }
}
