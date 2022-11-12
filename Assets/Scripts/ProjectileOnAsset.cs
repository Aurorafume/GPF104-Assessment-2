using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileOnAsset : MonoBehaviour
{
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

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, startingPosition) > maxRange)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponentInParent<EnemyScript>() != null) {
            Debug.Log("Hit");
            Instantiate(ProjectileImpact, transform.position, Quaternion.identity);
            collision.GetComponentInParent<EnemyScript>().TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
