using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform firePosition;
    public GameObject Bullet;

    void Update()
    {
        // get imput from player
        if (Input.GetMouseButtonDown(0))
        {
            // spawn a projectile
            Instantiate(Bullet, firePosition.position, firePosition.rotation);
        }
    }
}
