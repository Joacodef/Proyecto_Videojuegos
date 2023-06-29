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

    float spawnCounter;

    // Start is called before the first frame update
    void Start()
    {
        flag = false;
        spawnCounter = 0;
        spawnDelay = 5;
    }

    // Update is called once per frame
    void Update() {

        if (scoreCanvas.score % 250 <= 1 && scoreCanvas.score > 0 && canSpawn == true) {
            Debug.Log("boss debe aparecer");
            
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
            canSpawn = false;
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
