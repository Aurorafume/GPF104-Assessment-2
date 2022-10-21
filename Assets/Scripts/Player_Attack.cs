using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{   
    Animator animator;
    Object projectileRef;

    void Start()
    {
        projectileRef = Resources.Load("Projectile");
        animator = GetComponent<Animator>();

    }

    void Update()
    { 

        if(Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Attack");
            GameObject projectile = (GameObject)Instantiate(projectileRef);
            projectile.transform.position = new Vector3(transform.position.x + .5f, transform.position.y + .2f, -1);
        }

    }
}
