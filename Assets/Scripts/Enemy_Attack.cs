using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    public Transform firePosition;
    public GameObject Bullet;
    public int maxRange = 10;
    public double fireRate = 2.0;
    public float projectileSpeed;
    public GameObject ProjectileImpact;
    public Vector3 startingPosition;
    private Rigidbody2D rb;
    private long lastShot = 0;

    void Start() {
        lastShot = System.DateTime.Now.Ticks;
    }

    void Update()
    {   
        
        if (gameObject.GetComponent<EnemyScript>().PlayerInArea == true && secondsSinceLastShot() >= fireRate) {
            lastShot = System.DateTime.Now.Ticks;
            bool isFacingRight = transform.localScale.x < 0;
            // spawn a projectile
            Quaternion q = gameObject.transform.rotation;
            // Flip Quaternion 
            if(!isFacingRight)
                q.y = 180;
            GameObject projectile = Instantiate(Bullet, firePosition.position, q);
            projectile.GetComponentInChildren<ProjectileOnAsset>().shooter = gameObject;
        }
    }

    int secondsSinceLastShot() {
        long now = System.DateTime.Now.Ticks;
        long diff = now - lastShot;
        return (int) (diff / 10000000);
    }
}
