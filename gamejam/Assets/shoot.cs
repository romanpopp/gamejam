using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject player;
    public float fireForce;
    public float fireCD;

    public Transform firePoint;
    public GameObject[] boomerList;
    private GameObject boomerang;

    /// <summary>
    /// Sets the boomerang to the index of the object in boomerList.
    /// </summary>
    /// <param name="boomerIndex">Index in the boomerList array to set to.</param>
    public void SetBoomerang(int boomerIndex)
    {
        boomerang = boomerList[boomerIndex];
    }

    /// <summary>
    /// Fires the current boomerang.
    /// </summary>
    public void Fire()
    {
        GameObject projectile = Instantiate(boomerang, firePoint.position, firePoint.rotation);
        projectile.GetComponent<boomerangController>().SetPlayer(player);
        projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
}
