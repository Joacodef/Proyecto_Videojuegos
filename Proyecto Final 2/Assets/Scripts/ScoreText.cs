using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{

    public Text canvasText;
    // Start is called before the first frame update
    void Start()
    {
        canvasText.text = GameControl.control.score.ToString();
    }

}
