using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public GameObject Boss;
    public ScoreCanvas scoreCanvas;
    public bool flag;
    public bool canSpawn;
    public float spawnDelay;
    public int numBossSpawned;
    public SoundController soundController;
    float spawnCounter;

    // Start is called before the first frame update
    void Start()
    {
        flag = false;
        spawnCounter = 0;
        spawnDelay = 5;
        canSpawn = true;
        numBossSpawned = 0;
    }

    // Update is called once per frame
    void Update() {

        if (scoreCanvas.score > 250  && scoreCanvas.score > (numBossSpawned+1)*250 && scoreCanvas.score > 0 && canSpawn == true) {

            //Se para musica de background y parte musica Boss
            soundController.backGroundMusic.Stop();
            soundController.bossMusic.Play();


            numBossSpawned++;
            Debug.Log("boss número "+numBossSpawned+" debe aparecer, score: " +scoreCanvas.score);
            
            int random = Random.Range(0, 4);
            if(random == 0){
                Instantiate(Boss, new Vector3(-28,0,0), Quaternion.identity);
            }
            else if(random == 1){
                Instantiate(Boss, new Vector3(28,0,0), Quaternion.identity);
            }
            else if(random == 2){
                Instantiate(Boss, new Vector3(0,-15,0), Quaternion.identity);
            }
            else if(random == 3){
                Instantiate(Boss, new Vector3(0,15,0), Quaternion.identity);
            }
            canSpawn = false  ;
        }

        if (!canSpawn){
            if (spawnCounter < spawnDelay){
                spawnCounter += Time.deltaTime;
            } else {
                canSpawn = true;
                spawnCounter = 0;
            }
        }
    }
}
