using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class assHealth : MonoBehaviour
{
    public Slider slider;

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
                Destroy(collision.gameObject);
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
    }
}
