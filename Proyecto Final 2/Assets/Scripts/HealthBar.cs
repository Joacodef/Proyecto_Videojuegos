using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public bool flashWhite;
    public float flashWhiteTime;
    public bool flashGreen;
    public float flashGreenTime;

    private void Start(){
        flashWhite = false;
        flashWhiteTime = 0;
        flashGreen = false;
        flashGreenTime = 0;
    }

    private void Update(){
        if (flashWhite){
            flashWhiteTime += 1 * Time.deltaTime;
            slider.fillRect.GetComponent<Image>().color = Color.white;
            if (flashWhiteTime >= 0.1){
                flashWhite = false;
                flashWhiteTime = 0;
                slider.fillRect.GetComponent<Image>().color = new Color32(226,57,57,223);
            }
        }
        if (flashGreen){
            flashGreenTime += 1 * Time.deltaTime;
            //change the color of the health bar to a darker red:
            //slider.fillRect.GetComponent<Image>().color = Color.red;
            slider.fillRect.GetComponent<Image>().color = new Color32(57,226,57,223);
            
            if (flashGreenTime >= 0.1){
                flashGreen = false;
                flashGreenTime = 0;
                slider.fillRect.GetComponent<Image>().color = new Color32(226,57,57,223);
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
