using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public bool flashRed;
    public float flashRedTime;

    private void Start(){
        flashRed = false;
        flashRedTime = 0;
    }

    private void Update(){
        if (flashRed){
            flashRedTime += 1 * Time.deltaTime;
            slider.fillRect.GetComponent<Image>().color = Color.white;
            if (flashRedTime >= 0.1){
                flashRed = false;
                flashRedTime = 0;
                slider.fillRect.GetComponent<Image>().color = Color.red;
            }
        }
    }

    public void setMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void setHealth(float health)
    {
        slider.value = health;
    }
}
