using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallCollision : MonoBehaviour
{
    public Player player;
    public float damage = 10f;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected");
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "FireProjectile") {
            if (this.gameObject.tag == "WaterBall")
            {
                player.TakeDamage(damage);
            }
            else if (this.gameObject.tag == "FireBall")
            {
                player.Heal(damage);
            }
        }
        else if (collision.gameObject.tag == "WaterProjectile") {
            if (this.gameObject.tag == "WaterBall")
            {
                player.Heal(damage);
            }
            else if (this.gameObject.tag == "FireBall")
            {
                player.TakeDamage(damage);
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
