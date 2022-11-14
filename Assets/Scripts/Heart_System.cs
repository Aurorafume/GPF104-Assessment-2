using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Heart_System : MonoBehaviour
{
    public GameObject[] hearts;
    public GameObject[] livesCounter;
    public int regenDelay = 15;
    public int maxHealth = 10;
    public int life;
    public int numberLives = 3;
    private long lastHealthUpdate = -1;

    [SerializeField] private AudioSource HurtSoundEffect;


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

        for (int i = 0; i < livesCounter.Length; i++) {
            if(i >= numberLives) {
                livesCounter[i].gameObject.SetActive(false);
            } else {
                livesCounter[i].gameObject.SetActive(true);
            }
        }

        // Show numberLives counter on screen


        if (life <= 0) {
            LoseLife();
        }

        if (numberLives == 0)
        {   
            SceneManager.LoadScene("Menu");
        }
    }

    public void TakeDamage(int d)
    
    {
        HurtSoundEffect.Play();
        lastHealthUpdate = System.DateTime.Now.Ticks;
        if(life == 0) return;
        life -= d;
      
        
    }



    public void GiveHealth(int h) {
        lastHealthUpdate = System.DateTime.Now.Ticks;
        if(life >= maxHealth) return;
        life += h;
    }

    // when player reaches 0 hearts, they lose a life
    public void LoseLife() {
        if (life == 0)
        {

            numberLives -= 1;
            life = 10;
        }
    }

    // when player reaches 0 lives, they lose the game
    public void LoseGame() {
        if(numberLives == 0) {
         
            SceneManager.LoadScene("Menu");
        }
    }

    public void showLives() {
        // show numberLives counter on screen

    }
}