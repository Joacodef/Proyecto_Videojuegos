using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float movSpeed;
    public int sentido;
    public float rotationSpeed;
    public float maxHealth;
    public float currentHealth;
    public bool devMode;

    public ScoreCanvas scoreCanvas;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        sentido = 1;
        rotationSpeed = 150f;
        movSpeed = 15f;
        maxHealth = 100f;
        devMode = false;
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        // Make the object Pivote rotate
        transform.Rotate(new Vector3(0, 0, rotationSpeed * sentido) * Time.deltaTime);

        // If the player presses spacebar, the rotation direction changes
        if (Input.GetKeyDown(KeyCode.Space)) {
            sentido *= -1;
        }

        // Make the game object move in 2d with arrow keys with respect to the world
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * movSpeed * Time.deltaTime, Space.World);
        
        if (scoreCanvas.score >= 60) {
            if (scoreCanvas.score < 100) {
                TakeDamage(0.05f * Time.deltaTime * scoreCanvas.score);
            }
            else {
                TakeDamage(0.05f * Time.deltaTime * 100);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt)) {
            Debug.Log("DevMode On");
            devMode = true;
        }
    }

    public void TakeDamage(float damage)
    {
        if (currentHealth - damage <= 0) {
            Die();
        }
        else
        {
            currentHealth -= damage;
            healthBar.setHealth(currentHealth);
            //Debug.Log("Damage taken");
        }
    }

    public void Heal(float heal)
    {
        if (currentHealth + heal > maxHealth) {
            currentHealth = maxHealth;
            scoreCanvas.AddScore(10);
        }
        else {
            currentHealth += heal;
        }
        healthBar.setHealth(currentHealth);
        Debug.Log("Healed");
    }

    public void Die()
    {
        // Change scene to the game over scene
        if (devMode == false) {
            Debug.Log("Game Over");
            SceneManager.LoadScene("GameOver");
        } 
    }
    
}
