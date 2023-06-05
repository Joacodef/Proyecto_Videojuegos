using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreText : MonoBehaviour
{

    public TMP_Text canvasText;
    // Start is called before the first frame update
    void Start()
    {
        canvasText.text = GameControl.control.score.ToString();
    }

}
