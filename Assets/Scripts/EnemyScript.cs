using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{   
    public int enemyHP = 3;
    private bool isFacingRight = true;
    private bool isPlayerRight = true;
    private bool isEnemyMoving = true;
    private Vector3 startingPosition;
    private bool playerDetected = false;
    public int playerSensorDistance = 5;
    [field: SerializeField]
    private Collider2D Enemy;


    [field: SerializeField]
    public bool PlayerInArea { get; private set; }
    public Transform Player { get; private set; }

    [SerializeField]
    private string detectionTag = "Player";

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {   
        if (PlayerInArea == false)
        {
            // Code to walk back and forth between starting position and starting position + 5
            transform.position = new Vector3(transform.position.x + (isFacingRight? -0.003f : +0.003f), transform.position.y, transform.position.z);
        }
        
        // calculation to check if enemy was walked 5 units
        int distance = (int)Vector3.Distance(transform.position, startingPosition);

        // once enemy has moved 5 units, turn around
        if (distance > 5)
        {   
            startingPosition = transform.position;
            Flip();
        }

    }

    private void Flip()
    {   
        // Flip code to make enemy flip when it reaches the end of its patrol
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
        {   

            // Determine if player has entered the enemy's sensor
            if (collision.CompareTag(detectionTag))
            {
                PlayerInArea = true;
                Player = collision.gameObject.transform;
                Enemy = gameObject.GetComponent<Collider2D>();
                // Get the X coordinate of the player and enemt
                float enemyX = Enemy.bounds.center.x;
                float playerX = Player.position.x;
                // Determine if player is to the right or left of the enemy
                if (playerX < enemyX)
                {
                    Debug.Log("Player is to the left of the enemy");
                    isPlayerRight = false;
                } else
                {
                    Debug.Log("Player is to the right of the enemy");
                    isPlayerRight = true;
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            // Determine if player has left the enemy's sensor
            if (collision.CompareTag(detectionTag))
            {
                PlayerInArea = false;
                Player = null;
            }
        }

        /* determine if the player is to the left or right of the enemy
        void checkCollidingSide()
        {   
            // Check if player is in the sensor
            if (playerSensor.IsTouchingLayers(LayerMask.GetMask("Player")))
            {
                float enemyX = playerSensor.bounds.center.x;
                float playerX = Player.position.x;
                if (playerX < enemyX)
                {
                    Debug.Log("Player is to the left of the enemy");
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    Debug.Log("Player is to the right of the enemy");
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }
        }*/
    
}