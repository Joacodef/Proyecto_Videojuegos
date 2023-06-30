using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public float interpolationPeriod;
    public float fuerza;
    float time;
    float speed;
    Vector3 direccion;
    public GameObject proyectil;
    public GameObject ayuda;
    public GameObject instaKill;
    GameObject player;
    public SoundController soundController;

    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        interpolationPeriod = 5f;
        fuerza = 20f;
        speed = 0.1f;
        direccion = -transform.position;
        player = GameObject.Find("Pivote");
        player.GetComponent<Player>().playBossSound();
    }

    // Update is called once per frame
    void Update()
    {   
        time += Time.deltaTime;
        if (time >= interpolationPeriod)
        {
            time = Random.Range(0f, interpolationPeriod);
            GameObject balita = Instantiate(RandomObjToSpawn(), transform.position, Quaternion.identity);
            balita.transform.up = (player.transform.position-transform.position);
            balita.GetComponent<Rigidbody>().AddForce((player.transform.position-transform.position) * fuerza); 
        }
        Patrol();
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
            player.GetComponent<Player>().playGoblinSound();
            return instaKill;
        }
    }


    void Patrol() {
        transform.Translate(direccion * Time.deltaTime * speed);
    }
}
