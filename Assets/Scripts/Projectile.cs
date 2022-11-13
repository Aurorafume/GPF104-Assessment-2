using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform firePosition;
    public GameObject Bullet;
    public int maxRange = 10;
    public float projectileSpeed;
    public GameObject ProjectileImpact;
    public Vector3 startingPosition;
    private Rigidbody2D rb;

    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * projectileSpeed;
        startingPosition = transform.localPosition;
    }

    void Update()
    {
        // get imput from player
        if (Input.GetMouseButtonDown(0))
        {
            bool isFacingRight = transform.localScale.x < 0;
            // spawn a projectile
            Quaternion q = gameObject.transform.rotation;
            // Flip Quaternion 
            if(isFacingRight)
                q.y = 180;
            Instantiate(Bullet, firePosition.position, q);
        }
    }
}
