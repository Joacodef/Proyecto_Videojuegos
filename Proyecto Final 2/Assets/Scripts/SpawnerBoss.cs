using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBoss : MonoBehaviour
{
    public float interpolationPeriod;
    public float fuerza;
    float time;
    public GameObject proyectil;
    public GameObject ayuda;
    public GameObject instaKill;
    public ScoreCanvas scoreCanvas;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        interpolationPeriod = 5f;
        fuerza = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreCanvas.score >= 200){    
            time += Time.deltaTime;
            if (time >= interpolationPeriod)
            {
                time = Random.Range(0f, interpolationPeriod);
                GameObject balita = Instantiate(RandomObjToSpawn(), transform.position, Quaternion.identity);
                balita.GetComponent<Rigidbody>().AddForce((player.transform.position-transform.position) * fuerza);
                
            }
            Patrol();
        }
    }

    GameObject RandomObjToSpawn(){
        float randomNumber = Random.Range(0.0f, 1.0f);
        if (randomNumber < 0.25f) {
            return proyectil;
        }
        else if (randomNumber < 0.5f) {
            return ayuda;
        }
        else {
            return instaKill;
        }
    }


    void Patrol(){
        transform.Translate(Vector3.right * Time.deltaTime);
    }
}