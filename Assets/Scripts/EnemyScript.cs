using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{   
    public int enemyHP = 3;
    private bool isFacingRight = true;
    private Vector3 startingPosition;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {   

        int distance = (int)Vector3.Distance(transform.position, startingPosition);
        
        transform.position = new Vector3(transform.position.x + (isFacingRight? -0.005f : +0.005f), transform.position.y, transform.position.z);

        if (distance > 5)
        {   
            startingPosition = transform.position;
            Flip();
        }
    }

    // make enemy notice player and move towards player when player is in range
    void playerSensor(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            transform.position = Vector3.MoveTowards(transform.position, other.transform.position, 1 * Time.deltaTime);
            // make enemy deal 2 damage to player
            other.gameObject.GetComponent<Heart_System>().life -= 2;
            
        }
    } 

    private void Flip()
    {   
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

}