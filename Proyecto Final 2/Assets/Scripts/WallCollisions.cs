using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollisions : MonoBehaviour
{
    public SoundController soundController;

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "FireProjectile" || collision.gameObject.tag == "WaterProjectile" || 
        collision.gameObject.tag == "instaKill")
        {
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "BossProjectile"){

            soundController.bossMusic.Stop();
            soundController.backGroundMusic.Play();

            Destroy(collision.gameObject);
        }
    }
}
