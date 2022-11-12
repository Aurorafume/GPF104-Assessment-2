using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileOnAsset : MonoBehaviour
{
    public float projectileSpeed;
    public GameObject ProjectileImpact;
    private Rigidbody2D rb;

    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * projectileSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(ProjectileImpact, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
