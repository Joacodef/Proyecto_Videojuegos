using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl control;
    public float score;
    private void Awake()
    {
        if(control == null)
        {
            control = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }
}
