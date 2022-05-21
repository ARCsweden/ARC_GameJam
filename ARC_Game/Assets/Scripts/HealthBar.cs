using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public Player player;

    public void UpdateHealthBar() 
    {
        Color newColor = Color.green;
        // set new health, between 0 and 1
        healthBarImage.fillAmount = Mathf.Clamp(player.health / player.maxHealth, 0, 1f);
        //healthBarImage.fillAmount = -1f;

        // change the color when the health is low
        if(healthBarImage.fillAmount < 0.3f){
            newColor = Color.red;
        }else if(healthBarImage.fillAmount < 0.4f){
            newColor = Color.yellow;
        }else if(healthBarImage.fillAmount < 0){
            
        }
        // set new color
        healthBarImage.color = newColor;
    }
}