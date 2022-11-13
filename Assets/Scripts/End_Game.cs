using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_Game : MonoBehaviour
{   
    [SerializeField] private GameObject player;
    [SerializeField] public GameObject flag;

    private Collider2D flagCollider;
    private Collider2D Player;

    void Update()
    {
        // get collider2d of flag
        flagCollider = flag.GetComponent<Collider2D>();
        // get collider2d of player
        Player = player.GetComponent<Collider2D>();
        // check if player is in flag
        if (flagCollider.IsTouching(Player))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
