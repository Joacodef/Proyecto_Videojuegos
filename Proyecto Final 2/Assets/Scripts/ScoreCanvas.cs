using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCanvas : MonoBehaviour
{
    public float score;
    public float multiplier;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        multiplier = 1;
        score = 0;
    }

    // Update is called once per frame
    void Update() {
        score += Time.deltaTime * multiplier;
        scoreText.text = "Score: " + Mathf.Round(score);
    }

    public void AddScore(float scoreToAdd) {
        score += scoreToAdd;
    }

    public void updateText() {
        scoreText.text = "Score: " + Mathf.Round(score);
    }
}
