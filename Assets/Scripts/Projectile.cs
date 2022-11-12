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
