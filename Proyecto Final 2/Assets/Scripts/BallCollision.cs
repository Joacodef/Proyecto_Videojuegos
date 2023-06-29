using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallCollision : MonoBehaviour
{
    public Player player;
    public Transform elementPos;
    public float damage = 10f;
    public HealthBar healthBar;

    void Update(){
        //transform.rotation = player.transform.rotation;
        transform.position = elementPos.position;
        Debug.Log("Player rotation: " + player.transform.rotation+ "   rotation: " + transform.rotation);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected");
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "FireProjectile") {
            if (this.gameObject.tag == "WaterBall")
            {
                player.TakeDamage(damage);
                healthBar.flashWhite = true;
            }
            else if (this.gameObject.tag == "FireBall")
            {
                player.Heal(damage);
                healthBar.flashGreen = true;
            }
        }
        else if (collision.gameObject.tag == "WaterProjectile") {
            if (this.gameObject.tag == "WaterBall")
            {
                player.Heal(damage);
                healthBar.flashGreen = true;
            }
            else if (this.gameObject.tag == "FireBall")
            {
                player.TakeDamage(damage);
                healthBar.flashWhite = true;
            }
        }
        else if (collision.gameObject.tag == "instaKill" || collision.gameObject.tag == "BossProjectile") {
            player.Die();
        }

        Destroy(collision.gameObject);

        if (collision.gameObject.tag == "Muralla")
        {
            player.Die();
        }
    }
}
