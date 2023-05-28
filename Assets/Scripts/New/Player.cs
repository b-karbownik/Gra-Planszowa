using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public int routePosition;
    public int steps;
    public Route currentRoute;
    public int health = 100;

    public int fireballAmount;
    public int medkitAmount;

    public int points;

    public TextMeshProUGUI pointsAmmount;



    void Start()
    {
        routePosition = 0;
        steps = 0;
        currentRoute = GameObject.Find("Route1").GetComponent<Route>();
    }

    void Update()
    {
        pointsAmmount.text = points.ToString();
    }

    public void TakeDamage(int damage)
    {
        if (health - damage <= 0)
        {
            health = 0;
            Debug.Log("Ilosc twojego zycia wyniosla 0");
        }
        else
        {
            health -= damage;
        }
        
    }

    public void TakeHeal(int heal)
    {
        if (health + heal >= 100)
        {
            health = 100;
        }
        else
        {
            health += heal;
        }
    }

    public void TakeFireball()
    {
        fireballAmount += 1;
    }

    public void TakeMedkit()
    {
        medkitAmount += 1;
    }

    public void TakeCoin()
    {
        points += 1;
    }

}
