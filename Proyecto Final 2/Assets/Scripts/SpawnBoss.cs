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
    }

    // Update is called once per frame
    void Update() {

        if (scoreCanvas.score % 250 <= 1 && scoreCanvas.score > 0 && canSpawn == true) {
            Debug.Log("boss debe aparecer");
            Instantiate(Boss, transform.position, Quaternion.identity);
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
