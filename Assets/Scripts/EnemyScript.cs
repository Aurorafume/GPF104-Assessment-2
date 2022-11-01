using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // make enemy move left and right
        transform.position = new Vector3(Mathf.PingPong(Time.time * 1.5f, 6), transform.position.y, transform.position.z);

        // make enemy pause for a second before moving again
        if (Time.time % 2 == 0)
        {
            // make enemy pause for a second before moving again in the direction it was moving in
            transform.position = new Vector3(Mathf.PingPong(Time.time * 0, 6), transform.position.y, transform.position.z);

        }
        
        
    
    }

}

