using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart_System : MonoBehaviour
{
    public GameObject[] hearts;
    public int regenDelay = 15;
    public int maxHealth = 10;
    public int life;

    private long lastHealthUpdate = -1;

    void Update()
    {

        if(lastHealthUpdate == -1) 
            lastHealthUpdate = System.DateTime.Now.Ticks;
        
        if(System.DateTime.Now.Ticks - lastHealthUpdate >= regenDelay * 10000000) 
            GiveHealth(1);

        // Life is current amount of hearts that should be visible
        for (int i = 0; i < hearts.Length; i++) {
            if(i >= life) {
                hearts[i].gameObject.SetActive(false);
            } else {
                hearts[i].gameObject.SetActive(true);
            }
        }
    }

    public void TakeDamage(int d){
        lastHealthUpdate = System.DateTime.Now.Ticks;
        if(life == 0) return;
        life -= d;
    }

    public void GiveHealth(int h) {
        lastHealthUpdate = System.DateTime.Now.Ticks;
        if(life >= maxHealth) return;
        life += h;
    }
}