using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{   
    public int enemyHP = 3;
    private bool isFacingRight = true;
    private Vector3 startingPosition;
    private bool playerDetected = false;
    public int playerSensorDistance = 5;
    [field: SerializeField]
    private Collider2D playerSensor;

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
        int distance = (int)Vector3.Distance(transform.position, startingPosition);
        
        transform.position = new Vector3(transform.position.x + (isFacingRight? -0.003f : +0.003f), transform.position.y, transform.position.z);

        if (distance > 5)
        {   
            startingPosition = transform.position;
            Flip();
        }
    }

    private void Flip()
    {   
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
        {   
            if (collision.CompareTag(detectionTag))
            {
                PlayerInArea = true;
                Player = collision.gameObject.transform;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag(detectionTag))
            {
                PlayerInArea = false;
                Player = null;
            }
        }
}