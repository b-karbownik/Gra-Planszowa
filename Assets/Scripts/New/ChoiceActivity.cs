using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceActivity : MonoBehaviour
{
    public int choice;
    public GameManager _gameManager;
    public Player player1;
    public Player player2;
    public Fireball _fireball;

    public void ActivityTrue(int choice)
    {
        if(choice == 0)
        {
            _gameManager.Activity = true;
            Debug.Log("Pominiêcie kolejki!");
        }
        else if (choice == 1 && _gameManager.player.medkitAmount != 0)
        {
            _gameManager.Activity = true;
            _gameManager.player.medkitAmount -= 1;
            _gameManager.player.health += 25;
            Debug.Log("Uleczono Medkitem!");
        }
        else if (choice == 2 && _gameManager.player.fireballAmount != 0)
        {
            player1 = _gameManager.player;
            player2 = _gameManager._selectPlayer._selectedPlayer;
            
            _gameManager.Activity = true;
            _gameManager.player.fireballAmount -= 1;
            Debug.Log("Fireball leci!");
            StartCoroutine(_fireball.MoveFireball(player1, player2));
        }
    }

    public void ActivityFalse(int choice)
    {
        _gameManager.Activity = false;
        Debug.Log("False");
    }
}
