using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_Game : MonoBehaviour
{   
    public GameObject flag;
    private Collider2D flagCollider;
    private Collider2D Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flagCollider.IsTouching(Player))
        {
            Debug.Log("You Win!");
        }
    }
}
