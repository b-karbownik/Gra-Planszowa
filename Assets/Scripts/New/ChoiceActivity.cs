using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceActivity : MonoBehaviour
{
    public int choice;
    public GameManager _gameManager;
    public Player player1;
    public Player player2;

    public void ActivityTrue(int choice)
    {
        if(choice == 0)
        {
            _gameManager.Activity = true;
            Debug.Log("Pomini�cie kolejki!");
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
        }
    }

    public void ActivityFalse(int choice)
    {
        _gameManager.Activity = false;
        Debug.Log("False");
    }
}
