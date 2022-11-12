using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{   
    public int enemyHP = 3;
    private bool isFacingRight = true;
    private Vector3 startingPosition;
    public int playerSensorDistance = 5;
    [field: SerializeField]
    public float entitySpeed = 3;
    [field: SerializeField]
    private Collider2D Enemy;
    [field: SerializeField]
    public bool PlayerInArea { get; private set; }
    [field: SerializeField]
    public Collider2D Player { get; private set; }

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
            transform.position = new Vector3(transform.position.x + (isFacingRight? -(entitySpeed * 0.001f) : +(entitySpeed * 0.001f)), transform.position.y, transform.position.z);
        }

        if (PlayerInArea == true)
        {
            bool isPlayerRight = Player.transform.position.x > transform.position.x;
            Flip(!isPlayerRight);
        }
        
        // calculation to check if enemy was walked 5 units
        int distance = (int)Vector3.Distance(transform.position, startingPosition);

        // once enemy has moved 5 units, turn around
        if (distance > 5)
        {   
            startingPosition = transform.position;
            Flip(!isFacingRight);
        }

        // Detect if player is within target range
        int playerDistance = (int)Vector3.Distance(transform.position, Player.bounds.center);
        if(playerDistance <= playerSensorDistance)
        {
            PlayerInArea = true;
        }
        else
        {
            PlayerInArea = false;
        }

    }

    public void TakeDamage(int i) {
        enemyHP -= i;
        if (enemyHP <= 0) {
            Destroy(gameObject);
        }
    }

    private void Flip(bool faceRight)
    {   
        isFacingRight = faceRight;
        if(!faceRight) {
            transform.localScale = new Vector3(-2, 2, 2);
        } else {
            transform.localScale = new Vector3(2, 2, 2);
        }
    }

       // function to make enemy shoot at player
        public void Shoot()
        {
            // Code to make enemy shoot at player
            
        }
    
}