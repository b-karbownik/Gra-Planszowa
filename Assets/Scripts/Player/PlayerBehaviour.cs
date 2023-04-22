using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerTakeDamage(30);
            Debug.Log(GameManager.gameManager._playerHealth.Health);
        }if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            PlayerHeal(10);
            Debug.Log(GameManager.gameManager._playerHealth.Health);
        }
    }

    private void PlayerTakeDamage(int damage)
    {
        GameManager.gameManager._playerHealth.TakeDamage(damage);
        Debug.Log(GameManager.gameManager._playerHealth.Health);
    }

    private void PlayerHeal(int health)
    {
        GameManager.gameManager._playerHealth.TakeHeal(health);
        Debug.Log(GameManager.gameManager._playerHealth.Health);
    }
}   
