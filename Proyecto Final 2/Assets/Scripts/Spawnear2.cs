using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnear2 : MonoBehaviour
{
    public float interpolationPeriod;
    public float fuerza;
    float time;
    public GameObject proyectil;
    public GameObject ayuda;
    public GameObject instaKill;
    public ScoreCanvas scoreCanvas;
    public SoundController soundController;

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
        if(scoreCanvas.score >= 20){    
            time += Time.deltaTime;
            if (time >= interpolationPeriod)
            {
                time = Random.Range(0f, interpolationPeriod);
                GameObject balita = Instantiate(RandomObjToSpawn(), transform.position, Quaternion.identity);
                balita.transform.up = -transform.position;
                balita.GetComponent<Rigidbody>().AddForce(-transform.position * fuerza);
                Patrol();
            }
        }
    }

    GameObject RandomObjToSpawn(){
        float randomNumber = Random.Range(0.0f, 1.0f);
        int startInstaKill = 150;
        if (scoreCanvas.score > startInstaKill) {
            if (randomNumber < 0.45f) {
                return proyectil;
            }
            else if (randomNumber < 0.9f) {
                return ayuda;
            }
            else {
                soundController.goblinSound.Play();
                return instaKill;
            }
        } else {
            if (randomNumber < 0.5f) {
                return proyectil;
            }
            else {
                return ayuda;
            }
        }
    }


    void Patrol(){
        // generate random number between 0 and 1
        float randomNumber = Random.Range(0.0f, 1.0f);
        if(randomNumber < 0.5f){
            float randomPos = Random.Range(-20f, 20f);
            transform.position = new Vector3(randomPos, transform.position.y, transform.position.z);
        }
    }
}
