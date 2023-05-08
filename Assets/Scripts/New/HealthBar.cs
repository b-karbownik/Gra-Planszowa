using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Player player;
    public float playerHealth;
    public Image HealthImage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            player.health -= 10;
        }
        playerHealth = player.health;
        HealthImage.fillAmount = (float)player.health / 100f;
    }
}
